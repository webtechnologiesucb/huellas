import { useEffect, useMemo, useState } from 'react'
import { NavLink, Outlet, useLocation, useNavigate } from 'react-router-dom'
import {
  Activity,
  ArrowDownUp,
  Bell,
  CalendarDays,
  ChevronDown,
  ChevronRight,
  ClipboardList,
  Heart,
  LayoutDashboard,
  LogOut,
  Menu,
  Moon,
  Package,
  PawPrint,
  Settings,
  ShieldCheck,
  Sun,
} from 'lucide-react'
import Swal from 'sweetalert2'
import { entities } from '../constants/entities.generated'
import { useAuthStore } from '../store/authStore'
import { useThemeStore } from '../store/themeStore'

let lastApiError = { message: '', timestamp: 0 }

const groupIcons: Record<string, typeof PawPrint> = {
  'Atención clínica': Heart,
  Agenda: CalendarDays,
  Inventario: Package,
  Administración: ShieldCheck,
  Catálogos: ClipboardList,
  Plataforma: Activity,
}

export function AppShell() {
  const [collapsed, setCollapsed] = useState(false)
  const [mobileOpen, setMobileOpen] = useState(false)
  const [openGroups, setOpenGroups] = useState<string[]>(['Atención clínica'])
  const { pathname } = useLocation()
  const navigate = useNavigate()
  const email = useAuthStore((state) => state.email)
  const logout = useAuthStore((state) => state.logout)
  const themeMode = useThemeStore((state) => state.mode)
  const toggleTheme = useThemeStore((state) => state.toggle)

  const page = useMemo(() => {
    const moduleKey = pathname.split('/').filter(Boolean)[0]
    return entities.find((entity) => entity.key === moduleKey)
  }, [pathname])
  const heading = pathname === '/' ? 'Resumen general' : page?.label ?? 'Detalle'

  useEffect(() => {
    const onApiError = (event: Event) => {
      const message =
        event instanceof CustomEvent && typeof event.detail === 'string'
          ? event.detail
          : 'No fue posible completar la solicitud.'
      const timestamp = Date.now()
      if (
        message === lastApiError.message &&
        timestamp - lastApiError.timestamp < 3000
      ) {
        return
      }
      lastApiError = { message, timestamp }
      void Swal.fire({
        icon: 'error',
        title: 'No se pudo completar la operación',
        text: message,
        confirmButtonText: 'Entendido',
        confirmButtonColor: '#23876c',
      })
    }

    window.addEventListener('huellitas:api-error', onApiError)
    return () => window.removeEventListener('huellitas:api-error', onApiError)
  }, [])

  const groups = useMemo(
    () => [...new Set(entities.map((entity) => entity.group))],
    [],
  )

  const toggleGroup = (group: string) => {
    setOpenGroups((current) =>
      current.includes(group)
        ? current.filter((value) => value !== group)
        : [...current, group],
    )
  }

  const handleLogout = async () => {
    const result = await Swal.fire({
      icon: 'question',
      title: '¿Cerrar sesión?',
      text: 'Tendrás que volver a iniciar sesión para acceder a tu espacio.',
      showCancelButton: true,
      confirmButtonText: 'Cerrar sesión',
      cancelButtonText: 'Cancelar',
      confirmButtonColor: '#23876c',
    })
    if (result.isConfirmed) {
      logout()
      navigate('/login', { replace: true })
    }
  }

  return (
    <div className={`shell${collapsed ? ' sidebar-collapsed' : ''}`}>
      <aside
        className={`sidebar${collapsed ? ' collapsed' : ''}${mobileOpen ? ' mobile-open' : ''}`}
        aria-label="Navegación principal"
      >
        <NavLink
          className="brand"
          to="/"
          onClick={() => setMobileOpen(false)}
          aria-label="Huellitas, inicio"
        >
          <span className="brand-mark">
            <PawPrint size={22} />
          </span>
          {!collapsed && (
            <span>
              <span className="brand-name">huellitas</span>
              <span className="brand-caption">gestión veterinaria</span>
            </span>
          )}
        </NavLink>

        <div className="side-section">{!collapsed && 'Espacio de trabajo'}</div>
        <nav className="side-nav">
          <NavLink
            to="/"
            end
            className={({ isActive }) =>
              `side-link${isActive ? ' active' : ''}`
            }
            onClick={() => setMobileOpen(false)}
            title={collapsed ? 'Resumen general' : undefined}
          >
            <LayoutDashboard size={17} />
            {!collapsed && <span>Resumen general</span>}
          </NavLink>
        </nav>

        {groups.map((group) => {
          const Icon = groupIcons[group] ?? Settings
          const expanded = collapsed || openGroups.includes(group)
          return (
            <section key={group}>
              <button
                className="side-link"
                type="button"
                onClick={() => toggleGroup(group)}
                title={collapsed ? group : undefined}
                aria-expanded={expanded}
                style={{ width: '100%', border: 0, background: 'transparent' }}
              >
                <Icon size={16} />
                {!collapsed && <span style={{ flex: 1, textAlign: 'left' }}>{group}</span>}
                {!collapsed &&
                  (expanded ? <ChevronDown size={14} /> : <ChevronRight size={14} />)}
              </button>
              {expanded &&
                entities
                  .filter((entity) => entity.group === group)
                  .map((entity) => {
                    const ItemIcon = entity.key.includes('Mascota')
                      ? PawPrint
                      : ArrowDownUp
                    return (
                      <NavLink
                        key={entity.key}
                        to={`/${entity.key}`}
                        className={({ isActive }) =>
                          `side-link${isActive ? ' active' : ''}`
                        }
                        onClick={() => setMobileOpen(false)}
                        title={collapsed ? entity.label : undefined}
                        style={{ paddingLeft: collapsed ? 12 : 27, minHeight: 36 }}
                      >
                        <ItemIcon size={14} />
                        {!collapsed && <span>{entity.label}</span>}
                      </NavLink>
                    )
                  })}
            </section>
          )
        })}

        <div className="side-footer">
          <span className="avatar">{(email?.[0] ?? 'U').toLocaleUpperCase('es')}</span>
          {!collapsed && (
            <>
              <div style={{ minWidth: 0, flex: 1 }}>
                <div className="side-user-name">{email ?? 'Usuario'}</div>
                <div className="side-user-role">Sesión activa</div>
              </div>
              <button
                className="row-action"
                type="button"
                onClick={() => void handleLogout()}
                title="Cerrar sesión"
                aria-label="Cerrar sesión"
              >
                <LogOut size={15} />
              </button>
            </>
          )}
        </div>
      </aside>

      <div className="main-shell">
        <header className="topbar">
          <div className="topbar-left">
            <button
              className="icon-button"
              type="button"
              aria-label="Mostrar navegación"
              onClick={() => {
                if (window.innerWidth <= 820) setMobileOpen((value) => !value)
                else setCollapsed((value) => !value)
              }}
            >
              <Menu size={18} />
            </button>
            <div className="breadcrumbs">
              <span>Huellitas</span>
              <ChevronRight size={14} />
              <strong>{heading}</strong>
            </div>
          </div>
          <div className="topbar-actions">
            <button
              className="icon-button notification-dot"
              type="button"
              aria-label="Notificaciones"
              onClick={() =>
                navigate('/RegistroNotificaciones')
              }
            >
              <Bell size={17} />
            </button>
            <button
              className="icon-button"
              type="button"
              aria-label={themeMode === 'light' ? 'Activar modo oscuro' : 'Activar modo claro'}
              onClick={toggleTheme}
            >
              {themeMode === 'light' ? <Moon size={17} /> : <Sun size={17} />}
            </button>
          </div>
        </header>
        <main className="page-content">
          <Outlet />
        </main>
      </div>
    </div>
  )
}
