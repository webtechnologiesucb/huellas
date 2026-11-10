# Huellitas · Gestión veterinaria

Frontend administrativo para la API de Huellitas Digitales. Construido con React, TypeScript y Vite; los módulos, DTO y campos se generan a partir de OpenAPI.

## Requisitos

- Node.js 20.19+ o 22.12+
- npm
- API disponible (por defecto, `http://localhost:5189`)

## Instalación y desarrollo

```powershell
npm install
Copy-Item .env.example .env
npm run dev
```

Configura `VITE_API_URL` en `.env` con la raíz de la API, por ejemplo:

```dotenv
VITE_API_URL=http://localhost:5189/api
```

En desarrollo, ejecuta la API con el perfil `http` y el frontend en el puerto predeterminado de Vite (`5173`). La API permite los orígenes locales `localhost` y `127.0.0.1` para ese puerto.

La aplicación requiere credenciales válidas de la API para iniciar sesión. Las rutas administrativas están protegidas; el JWT se agrega a las solicitudes, se renueva mediante `/Auth/Refresh` y se conserva la sesión entre recargas.

## Generar contrato y módulos

Con Swagger accesible, ejecuta:

```powershell
npm run generate:api
```

El generador lee `http://localhost:5189/swagger/v1/swagger.json` y escribe:

- `src/interfaces/generated.ts`: interfaces de los esquemas OpenAPI.
- `src/constants/entities.generated.ts`: endpoints CRUD, campos, relaciones, etiquetas y módulos de navegación.

Para usar otro documento OpenAPI:

```powershell
$env:OPENAPI_URL = "https://servidor/swagger/v1/swagger.json"
npm run generate:api
```

Los archivos generados se pueden volver a crear; no edites esos archivos manualmente. El frontend detecta los recursos listables con operaciones GET/POST/PUT/DELETE y crea páginas de listado, alta, edición y detalle mediante componentes reutilizables.

## Funcionalidad

- Dashboard con conteos por módulo, indicadores, actividad reciente y gráficos.
- Navegación adaptable, sidebar colapsable, breadcrumbs y tema oscuro.
- Tablas MUI DataGrid con búsqueda, filtros, ordenamiento, paginación y acciones CRUD.
- Exportación de los resultados filtrados a Excel y PDF.
- Formularios React Hook Form con validación Zod, tipos de entrada y combos para relaciones.
- Caché e invalidación de consultas con TanStack Query.
- Interceptores Axios para JWT, renovación de sesión y errores de API.
- Confirmaciones y alertas con SweetAlert2.

## Validación

```powershell
npm run lint
npm run build
```

## Despliegue

1. Define `VITE_API_URL` para el entorno de destino. Las variables `VITE_*` se incorporan al bundle durante la compilación; configura la URL antes del build.
2. Ejecuta `npm ci`.
3. Ejecuta `npm run build`.
4. Publica el contenido de `dist/` en un servidor estático con fallback de rutas SPA a `index.html`.
5. Habilita CORS en la API para el origen del frontend y sirve la API mediante HTTPS en producción.

Para una vista local del bundle de producción:

```powershell
npm run preview
```

## Estructura

```text
src/
├── api/                 # Extensión para clientes y contratos específicos
├── assets/
├── components/          # Shell, formularios y estados compartidos
├── constants/           # Metadatos de módulos generados desde OpenAPI
├── hooks/               # Hooks de React Query para CRUD
├── interfaces/          # DTO generados y tipos compartidos
├── layouts/             # Reservado para layouts adicionales
├── pages/               # Dashboard, login y páginas CRUD genéricas
├── routes/              # Rutas protegidas
├── services/            # Axios, autenticación y operaciones CRUD
├── store/               # Sesión y tema persistidos con Zustand
└── utils/
```
