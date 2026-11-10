import type { UserCred, TokenResponse } from '../interfaces/generated'
import { http } from '../api/http'

export interface AuthTokens {
  jwtToken: string
  refreshToken: string
}

export const authService = {
  async login(credentials: UserCred): Promise<AuthTokens> {
    const { data } = await http.post<TokenResponse>('/Auth/Login', credentials)
    if (!data.jwtToken || !data.refreshToken) {
      throw new Error('La respuesta de autenticación no contiene tokens válidos.')
    }
    return { jwtToken: data.jwtToken, refreshToken: data.refreshToken }
  },
}
