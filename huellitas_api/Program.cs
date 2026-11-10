using huellitas_api.Dtos;
using huellitas_api.Filters;
using huellitas_api.Handlers;
using huellitas_api.Models;
using huellitas_api.Repositories;
using huellitas_api.Repositories.Interfaces;
using huellitas_api.Services;
using huellitas_api.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi;
using System.Text.Json.Serialization;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

var jwtSettings = builder.Configuration.GetSection("JwtSettings").Get<JwtSettings>()
    ?? throw new InvalidOperationException("Falta la configuración JwtSettings.");
if (string.IsNullOrWhiteSpace(jwtSettings.SecurityKey) ||
    Encoding.UTF8.GetByteCount(jwtSettings.SecurityKey) < 32)
{
    throw new InvalidOperationException(
        "Configure JwtSettings:SecurityKey con una clave aleatoria de al menos 32 bytes mediante configuración segura.");
}
if (string.IsNullOrWhiteSpace(jwtSettings.Issuer) ||
    string.IsNullOrWhiteSpace(jwtSettings.Audience) ||
    jwtSettings.AccessTokenMinutes <= 0 ||
    jwtSettings.RefreshTokenDays <= 0)
{
    throw new InvalidOperationException("La configuración de emisor, audiencia y vigencia JWT debe ser válida.");
}

// ======================================
// 1. Configuración de Controllers
// ======================================
builder.Services
    .AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    });
builder.Services.AddCors(options =>
{
    options.AddPolicy("Frontend", policy =>
    {
        policy
            .WithOrigins("http://localhost:5173", "http://127.0.0.1:5173")
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});
builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection("JwtSettings"));

builder.Services
    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.RequireHttpsMetadata = true;
        options.SaveToken = false;
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.SecurityKey)),
            ValidateIssuer = true,
            ValidIssuer = jwtSettings.Issuer,
            ValidateAudience = true,
            ValidAudience = jwtSettings.Audience,
            ValidateLifetime = true,
            ValidAlgorithms = [SecurityAlgorithms.HmacSha256],
            ClockSkew = TimeSpan.Zero,
            NameClaimType = System.Security.Claims.ClaimTypes.Name,
            RoleClaimType = System.Security.Claims.ClaimTypes.Role
        };
    });

builder.Services.AddAuthorization(options =>
{
    options.FallbackPolicy = new AuthorizationPolicyBuilder()
        .RequireAuthenticatedUser()
        .Build();
});

// ======================================
// 2. Configuración SQL Server
// ======================================
builder.Services.AddDbContext<HuellitasDigitalesContext>(options =>
{
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")
    );
});

// ======================================
// 3. Registro de Repositorios
// ======================================
builder.Services.AddScoped<IHealthRepository, HealthRepository>();
builder.Services.AddScoped<IArchivosAdjuntoRepository, ArchivosAdjuntoRepository>();
builder.Services.AddScoped<ICatalogoVacunaRepository, CatalogoVacunaRepository>();
builder.Services.AddScoped<ICategoriasProductoRepository, CategoriasProductoRepository>();
builder.Services.AddScoped<ICierresCajaRepository, CierresCajaRepository>();
builder.Services.AddScoped<ICitaRepository, CitaRepository>();
builder.Services.AddScoped<IConfiguracionClinicaRepository, ConfiguracionClinicaRepository>();
builder.Services.AddScoped<IDetallesRecetumRepository, DetallesRecetumRepository>();
builder.Services.AddScoped<IDetallesTransaccionRepository, DetallesTransaccionRepository>();
builder.Services.AddScoped<IEspecyRepository, EspecyRepository>();
builder.Services.AddScoped<IExpedienteClinicoRepository, ExpedienteClinicoRepository>();
builder.Services.AddScoped<IFechasBloqueadaRepository, FechasBloqueadaRepository>();
builder.Services.AddScoped<IHistorialClinicoRepository, HistorialClinicoRepository>();
builder.Services.AddScoped<IHorariosAtencionRepository, HorariosAtencionRepository>();
builder.Services.AddScoped<IHospitalizacioneRepository, HospitalizacioneRepository>();
builder.Services.AddScoped<IHospitalizacionInsumoRepository, HospitalizacionInsumoRepository>();
builder.Services.AddScoped<IInteraccionesBotRepository, InteraccionesBotRepository>();
builder.Services.AddScoped<IKardexInventarioRepository, KardexInventarioRepository>();
builder.Services.AddScoped<ILogsSistemaRepository, LogsSistemaRepository>();
builder.Services.AddScoped<ILotesCaducidadRepository, LotesCaducidadRepository>();
builder.Services.AddScoped<IMonitoreoDiarioRepository, MonitoreoDiarioRepository>();
builder.Services.AddScoped<IMascotasRepository, MascotasRepository>();
builder.Services.AddScoped<IProductoRepository, ProductoRepository>();
builder.Services.AddScoped<IRazaRepository, RazaRepository>();
builder.Services.AddScoped<IRecetaRepository, RecetaRepository>();
builder.Services.AddScoped<IRegistroEscaneosQrRepository, RegistroEscaneosQrRepository>();
builder.Services.AddScoped<IRegistroNotificacioneRepository, RegistroNotificacioneRepository>();
builder.Services.AddScoped<IRoleRepository, RoleRepository>();
builder.Services.AddScoped<IServicioRepository, ServicioRepository>();
builder.Services.AddScoped<ITransaccionesCajaRepository, TransaccionesCajaRepository>();
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<IVacunasAplicadaRepository, VacunasAplicadaRepository>();
builder.Services.AddScoped<IRefreshTokenGenerator, RefreshTokenGenerator>();

// ======================================
// 4. Registro de Servicios
// ======================================
builder.Services.AddScoped<IHealthService, HealthService>();
builder.Services.AddScoped<IArchivosAdjuntoService, ArchivosAdjuntoService>();
builder.Services.AddScoped<ICatalogoVacunaService, CatalogoVacunaService>();
builder.Services.AddScoped<ICategoriasProductoService, CategoriasProductoService>();
builder.Services.AddScoped<ICierresCajaService, CierresCajaService>();
builder.Services.AddScoped<ICitaService, CitaService>();
builder.Services.AddScoped<IConfiguracionClinicaService, ConfiguracionClinicaService>();
builder.Services.AddScoped<IDetallesRecetumService, DetallesRecetumService>();
builder.Services.AddScoped<IDetallesTransaccionService, DetallesTransaccionService>();
builder.Services.AddScoped<IEspecyService, EspecyService>();
builder.Services.AddScoped<IExpedienteClinicoService, ExpedienteClinicoService>();
builder.Services.AddScoped<IFechasBloqueadaService, FechasBloqueadaService>();
builder.Services.AddScoped<IHistorialClinicoService, HistorialClinicoService>();
builder.Services.AddScoped<IHorariosAtencionService, HorariosAtencionService>();
builder.Services.AddScoped<IHospitalizacioneService, HospitalizacioneService>();
builder.Services.AddScoped<IHospitalizacionInsumoService, HospitalizacionInsumoService>();
builder.Services.AddScoped<IInteraccionesBotService, InteraccionesBotService>();
builder.Services.AddScoped<IKardexInventarioService, KardexInventarioService>();
builder.Services.AddScoped<ILogsSistemaService, LogsSistemaService>();
builder.Services.AddScoped<ILotesCaducidadService, LotesCaducidadService>();
builder.Services.AddScoped<IMascotasService, MascotasService>();
builder.Services.AddScoped<IMonitoreoDiarioService, MonitoreoDiarioService>();
builder.Services.AddScoped<IProductoService, ProductoService>();
builder.Services.AddScoped<IRazaService, RazaService>();
builder.Services.AddScoped<IRecetaService, RecetaService>();
builder.Services.AddScoped<IRegistroEscaneosQrService, RegistroEscaneosQrService>();
builder.Services.AddScoped<IRegistroNotificacioneService, RegistroNotificacioneService>();
builder.Services.AddScoped<IRoleService, RoleService>();
builder.Services.AddScoped<IServicioService, ServicioService>();
builder.Services.AddScoped<ITransaccionesCajaService, TransaccionesCajaService>();
builder.Services.AddScoped<IUsuarioService, UsuarioService>();
builder.Services.AddScoped<IVacunasAplicadaService, VacunasAplicadaService>();

// ======================================
// 5. Configuración AutoMapper
// ======================================
builder.Services.AddAutoMapper(typeof(AutoMapperProfile));
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Huellitas Digitales API",
        Version = "v1",
        Description = "API REST desarrollada con ASP.NET Core y SQL Server",
        Contact = new OpenApiContact
        {
            Name = "Equipo de Desarrollo"
        }
    });
    options.AddSecurityDefinition(JwtBearerDefaults.AuthenticationScheme, new OpenApiSecurityScheme
    {
        Description = "Ingrese un JWT válido con el esquema Bearer.",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = JwtBearerDefaults.AuthenticationScheme,
        BearerFormat = "JWT"
    });
    options.OperationFilter<JwtAuthorizationOperationFilter>();
});

// ======================================
// 5. Construcción de la aplicación
// ======================================
var app = builder.Build();

// ======================================
// 6. Middleware Swagger
// ======================================
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();

    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint(
            "/swagger/v1/swagger.json",
            "Huellitas Digitales API v1"
        );

        options.RoutePrefix = "swagger";
    });
}

// ======================================
// 7. Middleware HTTP
// ======================================
if (!app.Environment.IsDevelopment())
{
    app.UseHttpsRedirection();
}

app.UseCors("Frontend");
app.UseAuthentication();
app.UseAuthorization();

// ======================================
// 8. Mapeo de Controllers
// ======================================
app.MapControllers();

app.Run();