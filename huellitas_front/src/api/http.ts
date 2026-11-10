import axios, {
  AxiosError,
  type InternalAxiosRequestConfig,
} from 'axios'
import type { TokenResponse } from '../interfaces/generated'
import { useAuthStore } from '../store/authStore'

interface RetryableRequest extends InternalAxiosRequestConfig {
  _retry?: boolean
}

const apiBaseUrl = (import.meta.env.VITE_API_URL ?? 'http://localhost:5189/api')
  .trim()
  .replace(/\/+$/, '')

export const http = axios.create({
  baseURL: apiBaseUrl,
  headers: { 'Content-Type': 'application/json' },
  timeout: 20_000,
})

http.interceptors.request.use((config) => {
  const token = useAuthStore.getState().token
  if (token && !config.url?.includes('/Auth/')) {
    config.headers.Authorization = `Bearer ${token}`
  }
  return config
})

let refreshRequest: Promise<string | null> | null = null

http.interceptors.response.use(
  (response) => response,
  async (error: AxiosError) => {
    const request = error.config as RetryableRequest | undefined
    const isAuthRoute = request?.url?.includes('/Auth/')

    if (
      error.response?.status === 401 &&
      request &&
      !request._retry &&
      !isAuthRoute
    ) {
      request._retry = true
      const session = useAuthStore.getState()
      if (!session.refreshToken) {
        session.logout()
        return Promise.reject(error)
      }

      refreshRequest ??= axios
        .post<TokenResponse>(
          `${apiBaseUrl}/Auth/Refresh`,
          {
            jwtToken: session.token,
            refreshToken: session.refreshToken,
          },
          { timeout: 20_000 },
        )
        .then(({ data }) => {
          if (!data.jwtToken || !data.refreshToken) {
            throw new Error('La API no devolvió un par de tokens válido.')
          }
          useAuthStore.getState().setTokens(data.jwtToken, data.refreshToken)
          return data.jwtToken
        })
        .catch(() => {
          useAuthStore.getState().logout()
          return null
        })
        .finally(() => {
          refreshRequest = null
        })

      const token = await refreshRequest
      if (token) {
        request.headers.Authorization = `Bearer ${token}`
        return http(request)
      }
    }

    if (error.response?.status === 401 && request?._retry) {
      useAuthStore.getState().logout()
    }

    if (error.response?.status !== 401 && !isAuthRoute) {
      const data = error.response?.data
      const message =
        typeof data === 'object' &&
        data !== null &&
        'message' in data &&
        typeof data.message === 'string'
          ? data.message
          : error.message
      window.dispatchEvent(
        new CustomEvent('huellitas:api-error', { detail: message }),
      )
    }

    return Promise.reject(error)
  },
)
