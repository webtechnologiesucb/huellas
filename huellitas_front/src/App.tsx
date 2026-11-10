import { QueryClient, QueryClientProvider } from '@tanstack/react-query'
import { BrowserRouter } from 'react-router-dom'
import { AppErrorBoundary } from './components/AppErrorBoundary'
import { AppRoutes } from './routes/AppRoutes'
import { useThemeStore } from './store/themeStore'
import './App.css'

const queryClient = new QueryClient({
  defaultOptions: {
    queries: {
      retry: 1,
      refetchOnWindowFocus: false,
      staleTime: 30_000,
    },
  },
})

export default function App() {
  const mode = useThemeStore((state) => state.mode)
  return (
    <QueryClientProvider client={queryClient}>
      <BrowserRouter>
        <div className={`app-root theme-${mode}`}>
          <AppErrorBoundary>
            <AppRoutes />
          </AppErrorBoundary>
        </div>
      </BrowserRouter>
    </QueryClientProvider>
  )
}
