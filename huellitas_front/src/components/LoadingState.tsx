export function LoadingState({ rows = 5 }: { rows?: number }) {
  return (
    <div className="loading-grid" aria-label="Cargando información">
      {Array.from({ length: rows }, (_, index) => (
        <div className="skeleton" key={index} />
      ))}
    </div>
  )
}

export function ErrorState({
  message,
  onRetry,
}: {
  message: string
  onRetry?: () => void
}) {
  return (
    <div className="error-state" role="alert">
      <div>
        <strong>No se pudo cargar la información</strong>
        <p style={{ margin: '8px 0 14px' }}>{message}</p>
        {onRetry && (
          <button className="button secondary" onClick={onRetry} type="button">
            Reintentar
          </button>
        )}
      </div>
    </div>
  )
}
