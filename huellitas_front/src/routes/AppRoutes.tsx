import { lazy, Suspense } from 'react'
import { Navigate, Route, Routes } from 'react-router-dom'
import { AppShell } from '../layouts/AppShell'
import { LoadingState } from '../components/LoadingState'
import { ProtectedRoute } from '../components/ProtectedRoute'
import { useAuthStore } from '../store/authStore'

const DashboardPage = lazy(async () =>
  import('../pages/DashboardPage').then((module) => ({
    default: module.DashboardPage,
  })),
)
const EntityDetailPage = lazy(async () =>
  import('../pages/EntityDetailPage').then((module) => ({
    default: module.EntityDetailPage,
  })),
)
const EntityFormPage = lazy(async () =>
  import('../pages/EntityFormPage').then((module) => ({
    default: module.EntityFormPage,
  })),
)
const EntityListPage = lazy(async () =>
  import('../pages/EntityListPage').then((module) => ({
    default: module.EntityListPage,
  })),
)
const LoginPage = lazy(async () =>
  import('../pages/LoginPage').then((module) => ({
    default: module.LoginPage,
  })),
)

function NotFoundPage() {
  return (
    <div className="empty-state">
      <div>
        <h1 className="page-title">Página no encontrada</h1>
        <p style={{ margin: '10px 0 16px' }}>
          La dirección no corresponde a una sección disponible.
        </p>
        <a className="button" href="/">Ir al resumen</a>
      </div>
    </div>
  )
}

function LoginRoute() {
  const token = useAuthStore((state) => state.token)
  return token ? <Navigate to="/" replace /> : <LoginPage />
}

export function AppRoutes() {
  return (
    <Suspense fallback={<LoadingState rows={4} />}>
      <Routes>
        <Route path="/login" element={<LoginRoute />} />
        <Route element={<ProtectedRoute />}>
          <Route element={<AppShell />}>
            <Route index element={<DashboardPage />} />
            <Route path=":module/new" element={<EntityFormPage mode="new" />} />
            <Route path=":module/:id/edit" element={<EntityFormPage mode="edit" />} />
            <Route path=":module/:id" element={<EntityDetailPage />} />
            <Route path=":module" element={<EntityListPage />} />
          </Route>
        </Route>
        <Route path="*" element={<NotFoundPage />} />
      </Routes>
    </Suspense>
  )
}
