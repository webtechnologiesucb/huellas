import { zodResolver } from '@hookform/resolvers/zod'
import { Heart, PawPrint, ShieldCheck } from 'lucide-react'
import { useState } from 'react'
import { useForm } from 'react-hook-form'
import { useNavigate } from 'react-router-dom'
import Swal from 'sweetalert2'
import { z } from 'zod'
import loginPets from '../assets/login-pets.svg'
import { authService } from '../services/authService'
import { useAuthStore } from '../store/authStore'
import { getApiErrorMessage } from '../utils/format'

const credentialsSchema = z.object({
  email: z.email('Ingresa un correo electrónico válido.'),
  password: z.string().min(1, 'Ingresa tu contraseña.'),
})

type Credentials = z.infer<typeof credentialsSchema>

export function LoginPage() {
  const [serverError, setServerError] = useState<string>()
  const setSession = useAuthStore((state) => state.setSession)
  const navigate = useNavigate()
  const {
    register,
    handleSubmit,
    formState: { errors, isSubmitting },
  } = useForm<Credentials>({
    resolver: zodResolver(credentialsSchema),
    defaultValues: { email: '', password: '' },
  })

  const onSubmit = handleSubmit(async (credentials) => {
    setServerError(undefined)
    try {
      const tokens = await authService.login(credentials)
      setSession(tokens.jwtToken, tokens.refreshToken, credentials.email)
      navigate('/', { replace: true })
    } catch (error) {
      const message = getApiErrorMessage(error)
      setServerError(message)
      await Swal.fire({
        icon: 'error',
        title: 'No pudimos iniciar sesión',
        text: message,
        confirmButtonColor: '#23876c',
      })
    }
  })

  return (
    <div className="login-page">
      <section className="login-aside">
        <div className="brand" style={{ margin: 0 }}>
          <span className="brand-mark">
            <PawPrint size={22} />
          </span>
          <span>
            <span className="brand-name">huellitas</span>
            <span className="brand-caption">gestión veterinaria</span>
          </span>
        </div>
        <div>
          <div className="login-illustration" aria-hidden="true">
            <img className="login-pets" src={loginPets} alt="" />
            <div className="login-pet-note">
              <span className="login-pet-note-icon">
                <Heart size={16} fill="currentColor" />
              </span>
              <span>
                <strong>Cada huella cuenta</strong>
                <small>Cuidado con cariño, gestión sencilla</small>
              </span>
            </div>
          </div>
          <h1 className="login-headline">
            Cuidar mejor empieza con una gestión más simple.
          </h1>
          <p className="login-description">
            Agenda, expedientes y operación clínica, en un solo espacio creado
            para que cada mascota reciba la atención que merece.
          </p>
        </div>
        <div className="login-footnote">
          © {new Date().getFullYear()} Huellitas · Plataforma de gestión clínica
        </div>
      </section>

      <main className="login-main">
        <form className="login-form" onSubmit={(event) => void onSubmit(event)}>
          <div className="login-form-heading">
            <div className="stat-icon login-shield">
              <ShieldCheck size={20} />
            </div>
            <div>
              <div className="eyebrow">Acceso seguro</div>
              <h2 className="page-title">Bienvenido de nuevo</h2>
              <p className="page-subtitle">
                Ingresa tus credenciales para continuar.
              </p>
            </div>
          </div>
          <div className="form-grid">
            <label className="form-field">
              <span className="form-label">Correo electrónico</span>
              <input
                className="form-control"
                type="email"
                autoComplete="username"
                placeholder="nombre@clinica.com"
                {...register('email')}
              />
              {errors.email && (
                <span className="field-error">{errors.email.message}</span>
              )}
            </label>
            <label className="form-field">
              <span className="form-label">Contraseña</span>
              <input
                className="form-control"
                type="password"
                autoComplete="current-password"
                placeholder="Ingresa tu contraseña"
                {...register('password')}
              />
              {errors.password && (
                <span className="field-error">{errors.password.message}</span>
              )}
            </label>
          </div>
          {serverError && (
            <p className="field-error" role="alert" style={{ marginTop: 12 }}>
              {serverError}
            </p>
          )}
          <button className="button" type="submit" disabled={isSubmitting}>
            {isSubmitting ? 'Verificando…' : 'Iniciar sesión'}
          </button>
          <p className="login-security-note">
            <ShieldCheck size={14} />
            Conexión protegida · Las sesiones se renuevan automáticamente
          </p>
        </form>
      </main>
    </div>
  )
}
