import { create } from 'zustand'
import { createJSONStorage, persist } from 'zustand/middleware'

interface AuthState {
  token: string | null
  refreshToken: string | null
  email: string | null
  setSession: (token: string, refreshToken: string, email: string) => void
  setTokens: (token: string, refreshToken: string) => void
  logout: () => void
}

export const useAuthStore = create<AuthState>()(
  persist(
    (set) => ({
      token: null,
      refreshToken: null,
      email: null,
      setSession: (token, refreshToken, email) =>
        set({ token, refreshToken, email }),
      setTokens: (token, refreshToken) => set({ token, refreshToken }),
      logout: () => set({ token: null, refreshToken: null, email: null }),
    }),
    {
      name: 'huellitas-session',
      storage: createJSONStorage(() => localStorage),
      partialize: ({ token, refreshToken, email }) => ({
        token,
        refreshToken,
        email,
      }),
    },
  ),
)
