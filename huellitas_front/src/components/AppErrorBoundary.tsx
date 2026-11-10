import { Component, type ErrorInfo, type ReactNode } from 'react'

interface AppErrorBoundaryProps {
  children: ReactNode
}

interface AppErrorBoundaryState {
  error?: Error
}

export class AppErrorBoundary extends Component<
  AppErrorBoundaryProps,
  AppErrorBoundaryState
> {
  state: AppErrorBoundaryState = {}

  static getDerivedStateFromError(error: Error): AppErrorBoundaryState {
    return { error }
  }

  componentDidCatch(error: Error, info: ErrorInfo) {
    console.error('Error no controlado en la interfaz:', error, info.componentStack)
  }

  render() {
    if (this.state.error) {
      return (
        <main className="empty-state" role="alert">
          <div>
            <h1 className="page-title">No se pudo mostrar esta pantalla</h1>
            <p style={{ margin: '10px 0 16px' }}>
              {this.state.error.message || 'Ocurrió un error inesperado.'}
            </p>
            <button
              className="button"
              type="button"
              onClick={() => this.setState({ error: undefined })}
            >
              Intentar de nuevo
            </button>
          </div>
        </main>
      )
    }

    return this.props.children
  }
}
