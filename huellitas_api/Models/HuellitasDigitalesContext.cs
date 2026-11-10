using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace huellitas_api.Models;

public partial class HuellitasDigitalesContext : DbContext
{
    public HuellitasDigitalesContext()
    {
    }

    public HuellitasDigitalesContext(DbContextOptions<HuellitasDigitalesContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ArchivosAdjunto> ArchivosAdjuntos { get; set; }

    public virtual DbSet<CatalogoVacuna> CatalogoVacunas { get; set; }

    public virtual DbSet<CategoriasProducto> CategoriasProductos { get; set; }

    public virtual DbSet<CierresCaja> CierresCajas { get; set; }

    public virtual DbSet<Cita> Citas { get; set; }

    public virtual DbSet<ConfiguracionClinica> ConfiguracionClinicas { get; set; }

    public virtual DbSet<DetallesRecetum> DetallesReceta { get; set; }

    public virtual DbSet<DetallesTransaccion> DetallesTransaccions { get; set; }

    public virtual DbSet<Especy> Especies { get; set; }

    public virtual DbSet<ExpedienteClinico> ExpedienteClinicos { get; set; }

    public virtual DbSet<FechasBloqueada> FechasBloqueadas { get; set; }

    public virtual DbSet<HistorialClinico> HistorialClinicos { get; set; }

    public virtual DbSet<HorariosAtencion> HorariosAtencions { get; set; }

    public virtual DbSet<HospitalizacionInsumo> HospitalizacionInsumos { get; set; }

    public virtual DbSet<Hospitalizacione> Hospitalizaciones { get; set; }

    public virtual DbSet<InteraccionesBot> InteraccionesBots { get; set; }

    public virtual DbSet<KardexInventario> KardexInventarios { get; set; }

    public virtual DbSet<LogsSistema> LogsSistemas { get; set; }

    public virtual DbSet<LotesCaducidad> LotesCaducidads { get; set; }

    public virtual DbSet<Mascota> Mascotas { get; set; }

    public virtual DbSet<MonitoreoDiario> MonitoreoDiarios { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }

    public virtual DbSet<Raza> Razas { get; set; }

    public virtual DbSet<Receta> Recetas { get; set; }

    public virtual DbSet<RegistroEscaneosQr> RegistroEscaneosQrs { get; set; }

    public virtual DbSet<RegistroNotificacione> RegistroNotificaciones { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Servicio> Servicios { get; set; }

    public virtual DbSet<TransaccionesCaja> TransaccionesCajas { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    public virtual DbSet<VacunasAplicada> VacunasAplicadas { get; set; }
    public virtual DbSet<RefreshToken> RefreshTokens { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=ConnectionStrings:DefaultConnection");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ArchivosAdjunto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__archivos__3213E83F4CB13B76");

            entity.ToTable("archivos_adjuntos");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(sysdatetime())")
                .HasColumnName("created_at");
            entity.Property(e => e.HistorialId).HasColumnName("historial_id");
            entity.Property(e => e.HospitalizacionId).HasColumnName("hospitalizacion_id");
            entity.Property(e => e.NombreArchivo)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("nombre_archivo");
            entity.Property(e => e.TipoArchivo)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("tipo_archivo");
            entity.Property(e => e.UrlArchivo)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("url_archivo");

            entity.HasOne(d => d.Historial).WithMany(p => p.ArchivosAdjuntos)
                .HasForeignKey(d => d.HistorialId)
                .HasConstraintName("FK_archivo_historial");

            entity.HasOne(d => d.Hospitalizacion).WithMany(p => p.ArchivosAdjuntos)
                .HasForeignKey(d => d.HospitalizacionId)
                .HasConstraintName("FK_archivo_hosp");
        });

        modelBuilder.Entity<CatalogoVacuna>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__catalogo__3213E83FE0586E94");

            entity.ToTable("catalogo_vacunas");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(sysdatetime())")
                .HasColumnName("created_at");
            entity.Property(e => e.DeletedAt).HasColumnName("deleted_at");
            entity.Property(e => e.DiasParaRefuerzo)
                .HasDefaultValue(365)
                .HasColumnName("dias_para_refuerzo");
            entity.Property(e => e.EspecieId).HasColumnName("especie_id");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.ProductoId).HasColumnName("producto_id");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(sysdatetime())")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.Especie).WithMany(p => p.CatalogoVacunas)
                .HasForeignKey(d => d.EspecieId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_vacunas_especie");

            entity.HasOne(d => d.Producto).WithMany(p => p.CatalogoVacunas)
                .HasForeignKey(d => d.ProductoId)
                .HasConstraintName("FK_vacunas_producto");
        });

        modelBuilder.Entity<CategoriasProducto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__categori__3213E83FD2844C78");

            entity.ToTable("categorias_producto");

            entity.HasIndex(e => e.Nombre, "UQ__categori__72AFBCC625F6B160").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(sysdatetime())")
                .HasColumnName("created_at");
            entity.Property(e => e.DeletedAt).HasColumnName("deleted_at");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("descripcion");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(sysdatetime())")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<CierresCaja>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__cierres___3213E83F5D984C80");

            entity.ToTable("cierres_caja");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("id");
            entity.Property(e => e.CajeroId).HasColumnName("cajero_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(sysdatetime())")
                .HasColumnName("created_at");
            entity.Property(e => e.Fecha).HasColumnName("fecha");
            entity.Property(e => e.MontoTotalRecaudado)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("monto_total_recaudado");
            entity.Property(e => e.TotalEfectivo)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("total_efectivo");
            entity.Property(e => e.TotalQrTransferencia)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("total_qr_transferencia");
            entity.Property(e => e.TotalTarjeta)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("total_tarjeta");
            entity.Property(e => e.Turno)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("turno");

            entity.HasOne(d => d.Cajero).WithMany(p => p.CierresCajas)
                .HasForeignKey(d => d.CajeroId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_cierre_cajero");
        });

        modelBuilder.Entity<Cita>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__citas__3213E83FF5F21A55");

            entity.ToTable("citas");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(sysdatetime())")
                .HasColumnName("created_at");
            entity.Property(e => e.DeletedAt).HasColumnName("deleted_at");
            entity.Property(e => e.Estado)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValue("Pendiente")
                .HasColumnName("estado");
            entity.Property(e => e.FechaHora).HasColumnName("fecha_hora");
            entity.Property(e => e.MascotaId).HasColumnName("mascota_id");
            entity.Property(e => e.MotivoCancelacion)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("motivo_cancelacion");
            entity.Property(e => e.Origen)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("origen");
            entity.Property(e => e.Prioridad)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValue("Normal")
                .HasColumnName("prioridad");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(sysdatetime())")
                .HasColumnName("updated_at");
            entity.Property(e => e.VeterinarioId).HasColumnName("veterinario_id");

            entity.HasOne(d => d.Mascota).WithMany(p => p.Cita)
                .HasForeignKey(d => d.MascotaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_citas_mascota");

            entity.HasOne(d => d.Veterinario).WithMany(p => p.Cita)
                .HasForeignKey(d => d.VeterinarioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_citas_veterinario");
        });

        modelBuilder.Entity<ConfiguracionClinica>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__configur__3213E83FC0353923");

            entity.ToTable("configuracion_clinica");

            entity.HasIndex(e => e.Clave, "UQ__configur__71DCA3DB3B4ABD25").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Clave)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("clave");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("descripcion");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(sysdatetime())")
                .HasColumnName("updated_at");
            entity.Property(e => e.Valor)
                .IsUnicode(false)
                .HasColumnName("valor");
        });

        modelBuilder.Entity<DetallesRecetum>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__detalles__3213E83FC309C65F");

            entity.ToTable("detalles_receta");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("id");
            entity.Property(e => e.Dosis)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("dosis");
            entity.Property(e => e.Duracion)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("duracion");
            entity.Property(e => e.Frecuencia)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("frecuencia");
            entity.Property(e => e.MedicamentoTextoLibre)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("medicamento_texto_libre");
            entity.Property(e => e.ProductoId).HasColumnName("producto_id");
            entity.Property(e => e.RecetaId).HasColumnName("receta_id");

            entity.HasOne(d => d.Producto).WithMany(p => p.DetallesReceta)
                .HasForeignKey(d => d.ProductoId)
                .HasConstraintName("FK_detalles_producto");

            entity.HasOne(d => d.Receta).WithMany(p => p.DetallesReceta)
                .HasForeignKey(d => d.RecetaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_detalles_receta");
        });

        modelBuilder.Entity<DetallesTransaccion>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__detalles__3213E83F6DF4B67B");

            entity.ToTable("detalles_transaccion");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("id");
            entity.Property(e => e.Cantidad).HasColumnName("cantidad");
            entity.Property(e => e.PrecioUnitario)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("precio_unitario");
            entity.Property(e => e.ProductoId).HasColumnName("producto_id");
            entity.Property(e => e.ServicioId).HasColumnName("servicio_id");
            entity.Property(e => e.Subtotal)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("subtotal");
            entity.Property(e => e.TipoCobro)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("tipo_cobro");
            entity.Property(e => e.TransaccionId).HasColumnName("transaccion_id");

            entity.HasOne(d => d.Producto).WithMany(p => p.DetallesTransaccions)
                .HasForeignKey(d => d.ProductoId)
                .HasConstraintName("FK_detnotrans_prod");

            entity.HasOne(d => d.Servicio).WithMany(p => p.DetallesTransaccions)
                .HasForeignKey(d => d.ServicioId)
                .HasConstraintName("FK_detnotrans_serv");

            entity.HasOne(d => d.Transaccion).WithMany(p => p.DetallesTransaccions)
                .HasForeignKey(d => d.TransaccionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_detnotrans_trans");
        });

        modelBuilder.Entity<Especy>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__especies__3213E83FFDD97B8D");

            entity.ToTable("especies");

            entity.HasIndex(e => e.Nombre, "UQ__especies__72AFBCC69A93A73B").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(sysdatetime())")
                .HasColumnName("created_at");
            entity.Property(e => e.DeletedAt).HasColumnName("deleted_at");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("descripcion");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(sysdatetime())")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<ExpedienteClinico>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__expedien__3213E83FED17C7A6");

            entity.ToTable("expediente_clinico");

            entity.HasIndex(e => e.MascotaId, "UQ__expedien__84837E7627E7DC67").IsUnique();

            entity.Property(e => e.Id)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(sysdatetime())")
                .HasColumnName("created_at");
            entity.Property(e => e.DeletedAt).HasColumnName("deleted_at");
            entity.Property(e => e.MascotaId).HasColumnName("mascota_id");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(sysdatetime())")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.Mascota).WithOne(p => p.ExpedienteClinico)
                .HasForeignKey<ExpedienteClinico>(d => d.MascotaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_expediente_mascota");
        });

        modelBuilder.Entity<FechasBloqueada>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__fechas_b__3213E83F6646F3EB");

            entity.ToTable("fechas_bloqueadas");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("id");
            entity.Property(e => e.Fecha).HasColumnName("fecha");
            entity.Property(e => e.Motivo)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("motivo");
            entity.Property(e => e.VeterinarioId).HasColumnName("veterinario_id");

            entity.HasOne(d => d.Veterinario).WithMany(p => p.FechasBloqueada)
                .HasForeignKey(d => d.VeterinarioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_bloqueos_veterinario");
        });

        modelBuilder.Entity<HistorialClinico>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__historia__3213E83F3FAC9854");

            entity.ToTable("historial_clinico");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("id");
            entity.Property(e => e.CitaId).HasColumnName("cita_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(sysdatetime())")
                .HasColumnName("created_at");
            entity.Property(e => e.DeletedAt).HasColumnName("deleted_at");
            entity.Property(e => e.Diagnostico)
                .IsUnicode(false)
                .HasColumnName("diagnostico");
            entity.Property(e => e.Estado)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValue("Abierto")
                .HasColumnName("estado");
            entity.Property(e => e.ExpedienteId).HasColumnName("expediente_id");
            entity.Property(e => e.FrecuenciaCardiaca).HasColumnName("frecuencia_cardiaca");
            entity.Property(e => e.FrecuenciaRespiratoria).HasColumnName("frecuencia_respiratoria");
            entity.Property(e => e.MotivoConsulta)
                .IsUnicode(false)
                .HasColumnName("motivo_consulta");
            entity.Property(e => e.NotasInternas)
                .IsUnicode(false)
                .HasColumnName("notas_internas");
            entity.Property(e => e.Peso)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("peso");
            entity.Property(e => e.Temperatura)
                .HasColumnType("decimal(4, 2)")
                .HasColumnName("temperatura");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(sysdatetime())")
                .HasColumnName("updated_at");
            entity.Property(e => e.VeterinarioId).HasColumnName("veterinario_id");

            entity.HasOne(d => d.Cita).WithMany(p => p.HistorialClinicos)
                .HasForeignKey(d => d.CitaId)
                .HasConstraintName("FK_historial_cita");

            entity.HasOne(d => d.Expediente).WithMany(p => p.HistorialClinicos)
                .HasForeignKey(d => d.ExpedienteId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_historial_expediente");

            entity.HasOne(d => d.Veterinario).WithMany(p => p.HistorialClinicos)
                .HasForeignKey(d => d.VeterinarioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_historial_veterinario");
        });

        modelBuilder.Entity<HorariosAtencion>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__horarios__3213E83FA6F0F53A");

            entity.ToTable("horarios_atencion");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(sysdatetime())")
                .HasColumnName("created_at");
            entity.Property(e => e.DiaSemana).HasColumnName("dia_semana");
            entity.Property(e => e.HoraFin).HasColumnName("hora_fin");
            entity.Property(e => e.HoraInicio).HasColumnName("hora_inicio");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(sysdatetime())")
                .HasColumnName("updated_at");
            entity.Property(e => e.VeterinarioId).HasColumnName("veterinario_id");

            entity.HasOne(d => d.Veterinario).WithMany(p => p.HorariosAtencions)
                .HasForeignKey(d => d.VeterinarioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_horarios_veterinario");
        });

        modelBuilder.Entity<HospitalizacionInsumo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__hospital__3213E83F97E2C505");

            entity.ToTable("hospitalizacion_insumos");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("id");
            entity.Property(e => e.Cantidad)
                .HasDefaultValue(1)
                .HasColumnName("cantidad");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(sysdatetime())")
                .HasColumnName("created_at");
            entity.Property(e => e.HospitalizacionId).HasColumnName("hospitalizacion_id");
            entity.Property(e => e.ProductoId).HasColumnName("producto_id");
            entity.Property(e => e.ServicioId).HasColumnName("servicio_id");
            entity.Property(e => e.Subtotal)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("subtotal");

            entity.HasOne(d => d.Hospitalizacion).WithMany(p => p.HospitalizacionInsumos)
                .HasForeignKey(d => d.HospitalizacionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_hospins_hosp");

            entity.HasOne(d => d.Producto).WithMany(p => p.HospitalizacionInsumos)
                .HasForeignKey(d => d.ProductoId)
                .HasConstraintName("FK_hospins_producto");

            entity.HasOne(d => d.Servicio).WithMany(p => p.HospitalizacionInsumos)
                .HasForeignKey(d => d.ServicioId)
                .HasConstraintName("FK_hospins_servicio");
        });

        modelBuilder.Entity<Hospitalizacione>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__hospital__3213E83F34F3F3AF");

            entity.ToTable("hospitalizaciones");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(sysdatetime())")
                .HasColumnName("created_at");
            entity.Property(e => e.Estado)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasDefaultValue("En_Observacion")
                .HasColumnName("estado");
            entity.Property(e => e.FechaEgreso).HasColumnName("fecha_egreso");
            entity.Property(e => e.FechaIngreso).HasColumnName("fecha_ingreso");
            entity.Property(e => e.HistorialId).HasColumnName("historial_id");
            entity.Property(e => e.MascotaId).HasColumnName("mascota_id");
            entity.Property(e => e.Observaciones)
                .IsUnicode(false)
                .HasColumnName("observaciones");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(sysdatetime())")
                .HasColumnName("updated_at");
            entity.Property(e => e.VeterinarioId).HasColumnName("veterinario_id");

            entity.HasOne(d => d.Historial).WithMany(p => p.Hospitalizaciones)
                .HasForeignKey(d => d.HistorialId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_hosp_historial");

            entity.HasOne(d => d.Mascota).WithMany(p => p.Hospitalizaciones)
                .HasForeignKey(d => d.MascotaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_hosp_mascota");

            entity.HasOne(d => d.Veterinario).WithMany(p => p.Hospitalizaciones)
                .HasForeignKey(d => d.VeterinarioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_hosp_veterinario");
        });

        modelBuilder.Entity<InteraccionesBot>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__interacc__3213E83F122AA311");

            entity.ToTable("interacciones_bot");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(sysdatetime())")
                .HasColumnName("created_at");
            entity.Property(e => e.IntencionDetectada)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("intencion_detectada");
            entity.Property(e => e.MascotaId).HasColumnName("mascota_id");
            entity.Property(e => e.MensajeUsuario)
                .IsUnicode(false)
                .HasColumnName("mensaje_usuario");
            entity.Property(e => e.RespuestaIa)
                .IsUnicode(false)
                .HasColumnName("respuesta_ia");

            entity.HasOne(d => d.Mascota).WithMany(p => p.InteraccionesBots)
                .HasForeignKey(d => d.MascotaId)
                .HasConstraintName("FK_bot_mascota");
        });

        modelBuilder.Entity<KardexInventario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__kardex_i__3213E83FB7865125");

            entity.ToTable("kardex_inventario");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("id");
            entity.Property(e => e.Cantidad).HasColumnName("cantidad");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(sysdatetime())")
                .HasColumnName("created_at");
            entity.Property(e => e.Motivo)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("motivo");
            entity.Property(e => e.ProductoId).HasColumnName("producto_id");
            entity.Property(e => e.SaldoResultante).HasColumnName("saldo_resultante");
            entity.Property(e => e.TipoMovimiento)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("tipo_movimiento");

            entity.HasOne(d => d.Producto).WithMany(p => p.KardexInventarios)
                .HasForeignKey(d => d.ProductoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_kardex_producto");
        });

        modelBuilder.Entity<LogsSistema>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__logs_sis__3213E83FB317F906");

            entity.ToTable("logs_sistema");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("id");
            entity.Property(e => e.Accion)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("accion");
            entity.Property(e => e.Categoria)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("categoria");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(sysdatetime())")
                .HasColumnName("created_at");
            entity.Property(e => e.Detalles).HasColumnName("detalles");
            entity.Property(e => e.UsuarioId).HasColumnName("usuario_id");

            entity.HasOne(d => d.Usuario).WithMany(p => p.LogsSistemas)
                .HasForeignKey(d => d.UsuarioId)
                .HasConstraintName("FK_logs_usuario");
        });

        modelBuilder.Entity<LotesCaducidad>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__lotes_ca__3213E83F6A39315F");

            entity.ToTable("lotes_caducidad");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("id");
            entity.Property(e => e.CantidadActual).HasColumnName("cantidad_actual");
            entity.Property(e => e.CantidadInicial).HasColumnName("cantidad_inicial");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(sysdatetime())")
                .HasColumnName("created_at");
            entity.Property(e => e.FechaVencimiento).HasColumnName("fecha_vencimiento");
            entity.Property(e => e.NumeroLote)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("numero_lote");
            entity.Property(e => e.ProductoId).HasColumnName("producto_id");

            entity.HasOne(d => d.Producto).WithMany(p => p.LotesCaducidads)
                .HasForeignKey(d => d.ProductoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_lotes_producto");
        });

        modelBuilder.Entity<Mascota>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__mascotas__3213E83F3BEDA5B1");

            entity.ToTable("mascotas");

            entity.HasIndex(e => e.HashQrIdentidad, "UQ__mascotas__0302389B080AD978").IsUnique();

            entity.Property(e => e.Id)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(sysdatetime())")
                .HasColumnName("created_at");
            entity.Property(e => e.DeletedAt).HasColumnName("deleted_at");
            entity.Property(e => e.DueñoId).HasColumnName("dueño_id");
            entity.Property(e => e.FechaNacimiento).HasColumnName("fecha_nacimiento");
            entity.Property(e => e.Genero)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("genero");
            entity.Property(e => e.HashQrIdentidad)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("hash_qr_identidad");
            entity.Property(e => e.LatitudPerdida).HasColumnName("latitud_perdida");
            entity.Property(e => e.LongitudPerdida).HasColumnName("longitud_perdida");
            entity.Property(e => e.MensajeEncontrado)
                .IsUnicode(false)
                .HasColumnName("mensaje_encontrado");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.Perdida)
                .HasDefaultValue(false)
                .HasColumnName("perdida");
            entity.Property(e => e.PesoActual)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("peso_actual");
            entity.Property(e => e.PuntoEntrega)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("punto_entrega");
            entity.Property(e => e.RazaId).HasColumnName("raza_id");
            entity.Property(e => e.Recompensa)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("recompensa");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(sysdatetime())")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.Dueño).WithMany(p => p.Mascota)
                .HasForeignKey(d => d.DueñoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_mascotas_dueño");

            entity.HasOne(d => d.Raza).WithMany(p => p.Mascota)
                .HasForeignKey(d => d.RazaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_mascotas_raza");
        });

        modelBuilder.Entity<MonitoreoDiario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__monitore__3213E83F1748E158");

            entity.ToTable("monitoreo_diario");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(sysdatetime())")
                .HasColumnName("created_at");
            entity.Property(e => e.FrecuenciaCardiaca).HasColumnName("frecuencia_cardiaca");
            entity.Property(e => e.HospitalizacionId).HasColumnName("hospitalizacion_id");
            entity.Property(e => e.Observaciones)
                .IsUnicode(false)
                .HasColumnName("observaciones");
            entity.Property(e => e.Peso)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("peso");
            entity.Property(e => e.ResponsableId).HasColumnName("responsable_id");
            entity.Property(e => e.Temperatura)
                .HasColumnType("decimal(4, 2)")
                .HasColumnName("temperatura");
            entity.Property(e => e.Turno)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("turno");

            entity.HasOne(d => d.Hospitalizacion).WithMany(p => p.MonitoreoDiarios)
                .HasForeignKey(d => d.HospitalizacionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_monitoreo_hosp");

            entity.HasOne(d => d.Responsable).WithMany(p => p.MonitoreoDiarios)
                .HasForeignKey(d => d.ResponsableId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_monitoreo_responsable");
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__producto__3213E83FA9F701B8");

            entity.ToTable("productos");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("id");
            entity.Property(e => e.CategoriaId).HasColumnName("categoria_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(sysdatetime())")
                .HasColumnName("created_at");
            entity.Property(e => e.DeletedAt).HasColumnName("deleted_at");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("descripcion");
            entity.Property(e => e.EsServicio)
                .HasDefaultValue(false)
                .HasColumnName("es_servicio");
            entity.Property(e => e.Nombre)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.PrecioVenta)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("precio_venta");
            entity.Property(e => e.RequiereReceta)
                .HasDefaultValue(false)
                .HasColumnName("requiere_receta");
            entity.Property(e => e.StockActual).HasColumnName("stock_actual");
            entity.Property(e => e.StockMinimo)
                .HasDefaultValue(5)
                .HasColumnName("stock_minimo");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(sysdatetime())")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.Categoria).WithMany(p => p.Productos)
                .HasForeignKey(d => d.CategoriaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_productos_categoria");
        });

        modelBuilder.Entity<Raza>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__razas__3213E83FE06E7FEC");

            entity.ToTable("razas");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(sysdatetime())")
                .HasColumnName("created_at");
            entity.Property(e => e.DeletedAt).HasColumnName("deleted_at");
            entity.Property(e => e.EspecieId).HasColumnName("especie_id");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(sysdatetime())")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.Especie).WithMany(p => p.Razas)
                .HasForeignKey(d => d.EspecieId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_razas_especie");
        });

        modelBuilder.Entity<Receta>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__recetas__3213E83F77A4B35E");

            entity.ToTable("recetas");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(sysdatetime())")
                .HasColumnName("created_at");
            entity.Property(e => e.HistorialId).HasColumnName("historial_id");
            entity.Property(e => e.IndicacionesGenerales)
                .IsUnicode(false)
                .HasColumnName("indicaciones_generales");
            entity.Property(e => e.VeterinarioId).HasColumnName("veterinario_id");

            entity.HasOne(d => d.Historial).WithMany(p => p.Receta)
                .HasForeignKey(d => d.HistorialId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_recetas_historial");

            entity.HasOne(d => d.Veterinario).WithMany(p => p.Receta)
                .HasForeignKey(d => d.VeterinarioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_recetas_veterinario");
        });

        modelBuilder.Entity<RegistroEscaneosQr>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__registro__3213E83F1524F366");

            entity.ToTable("registro_escaneos_qr");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(sysdatetime())")
                .HasColumnName("created_at");
            entity.Property(e => e.Latitud).HasColumnName("latitud");
            entity.Property(e => e.Longitud).HasColumnName("longitud");
            entity.Property(e => e.MascotaId).HasColumnName("mascota_id");
            entity.Property(e => e.UserAgent)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("user_agent");

            entity.HasOne(d => d.Mascota).WithMany(p => p.RegistroEscaneosQrs)
                .HasForeignKey(d => d.MascotaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_qrscan_mascota");
        });

        modelBuilder.Entity<RegistroNotificacione>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__registro__3213E83F670D42DE");

            entity.ToTable("registro_notificaciones");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("id");
            entity.Property(e => e.Canal)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("canal");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(sysdatetime())")
                .HasColumnName("created_at");
            entity.Property(e => e.Estado)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValue("Enviado")
                .HasColumnName("estado");
            entity.Property(e => e.Mensaje)
                .IsUnicode(false)
                .HasColumnName("mensaje");
            entity.Property(e => e.UsuarioId).HasColumnName("usuario_id");

            entity.HasOne(d => d.Usuario).WithMany(p => p.RegistroNotificaciones)
                .HasForeignKey(d => d.UsuarioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_notif_usuario");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__roles__3213E83F1E3A5009");

            entity.ToTable("roles");

            entity.HasIndex(e => e.Nombre, "UQ__roles__72AFBCC6102FD743").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(sysdatetime())")
                .HasColumnName("created_at");
            entity.Property(e => e.DeletedAt).HasColumnName("deleted_at");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("descripcion");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(sysdatetime())")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<Servicio>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__servicio__3213E83FF694C8EA");

            entity.ToTable("servicios");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(sysdatetime())")
                .HasColumnName("created_at");
            entity.Property(e => e.DeletedAt).HasColumnName("deleted_at");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("descripcion");
            entity.Property(e => e.DuracionMinutos).HasColumnName("duracion_minutos");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.Precio)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("precio");
            entity.Property(e => e.RequiereVeterinario)
                .HasDefaultValue(true)
                .HasColumnName("requiere_veterinario");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(sysdatetime())")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<TransaccionesCaja>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__transacc__3213E83F34BF2591");

            entity.ToTable("transacciones_caja");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("id");
            entity.Property(e => e.CajeroId).HasColumnName("cajero_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(sysdatetime())")
                .HasColumnName("created_at");
            entity.Property(e => e.Descuento)
                .HasDefaultValue(0.00m)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("descuento");
            entity.Property(e => e.Estado)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValue("Completada")
                .HasColumnName("estado");
            entity.Property(e => e.HistorialId).HasColumnName("historial_id");
            entity.Property(e => e.HospitalizacionId).HasColumnName("hospitalizacion_id");
            entity.Property(e => e.MetodoPago)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("metodo_pago");
            entity.Property(e => e.Subtotal)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("subtotal");
            entity.Property(e => e.Total)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("total");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(sysdatetime())")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.Cajero).WithMany(p => p.TransaccionesCajas)
                .HasForeignKey(d => d.CajeroId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_caja_cajero");

            entity.HasOne(d => d.Historial).WithMany(p => p.TransaccionesCajas)
                .HasForeignKey(d => d.HistorialId)
                .HasConstraintName("FK_caja_historial");

            entity.HasOne(d => d.Hospitalizacion).WithMany(p => p.TransaccionesCajas)
                .HasForeignKey(d => d.HospitalizacionId)
                .HasConstraintName("FK_caja_hosp");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__usuarios__3213E83FDD1C43D9");

            entity.ToTable("usuarios");

            entity.HasIndex(e => e.Email, "idx_usuarios_email_activo")
                .IsUnique()
                .HasFilter("([deleted_at] IS NULL)");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("id");
            entity.Property(e => e.Apellidos)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("apellidos");
            entity.Property(e => e.BloqueadoHasta).HasColumnName("bloqueado_hasta");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(sysdatetime())")
                .HasColumnName("created_at");
            entity.Property(e => e.DeletedAt).HasColumnName("deleted_at");
            entity.Property(e => e.Email)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.IntentosFallidos)
                .HasDefaultValue(0)
                .HasColumnName("intentos_fallidos");
            entity.Property(e => e.Nombres)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombres");
            entity.Property(e => e.PasswordHash)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("password_hash");
            entity.Property(e => e.RolId).HasColumnName("rol_id");
            entity.Property(e => e.Telefono)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("telefono");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(sysdatetime())")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.Rol).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.RolId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_usuarios_rol");
        });

        modelBuilder.Entity<VacunasAplicada>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__vacunas___3213E83F0822BDDE");

            entity.ToTable("vacunas_aplicadas");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("id");
            entity.Property(e => e.CatalogoVacunaId).HasColumnName("catalogo_vacuna_id");
            entity.Property(e => e.FechaAplicacion).HasColumnName("fecha_aplicacion");
            entity.Property(e => e.FechaProximaDosis).HasColumnName("fecha_proxima_dosis");
            entity.Property(e => e.HistorialId).HasColumnName("historial_id");
            entity.Property(e => e.HospitalizacionId).HasColumnName("hospitalizacion_id");
            entity.Property(e => e.LoteId).HasColumnName("lote_id");

            entity.HasOne(d => d.CatalogoVacuna).WithMany(p => p.VacunasAplicada)
                .HasForeignKey(d => d.CatalogoVacunaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_vacapp_catalogo");

            entity.HasOne(d => d.Historial).WithMany(p => p.VacunasAplicada)
                .HasForeignKey(d => d.HistorialId)
                .HasConstraintName("FK_vacapp_historial");

            entity.HasOne(d => d.Hospitalizacion).WithMany(p => p.VacunasAplicada)
                .HasForeignKey(d => d.HospitalizacionId)
                .HasConstraintName("FK_vacapp_hosp");

            entity.HasOne(d => d.Lote).WithMany(p => p.VacunasAplicada)
                .HasForeignKey(d => d.LoteId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_vacapp_lote");
        });

        modelBuilder.Entity<RefreshToken>(entity =>
        {
            entity.HasKey(e => e.Id)
                .HasName("PK_refresh_tokens");

            entity.ToTable("refresh_tokens");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");
            entity.Property(e => e.UserEmail)
                .HasMaxLength(150)
                .IsUnicode(false)
                .IsRequired()
                .HasColumnName("user_email");
            entity.Property(e => e.Token)
                .HasMaxLength(64)
                .IsUnicode(false)
                .IsRequired()
                .HasColumnName("token");
            entity.Property(e => e.IsValid)
                .HasColumnName("is_valid");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime2")
                .HasColumnName("created_at");
            entity.Property(e => e.ExpiresAt)
                .HasColumnType("datetime2")
                .HasColumnName("expires_at");

            entity.HasIndex(e => e.UserEmail)
                .IsUnique()
                .HasDatabaseName("UX_refresh_tokens_user_email");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
