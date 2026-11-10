USE [HuellitasDigitales];
GO

SET NOCOUNT ON;
BEGIN TRANSACTION;

--------------------------------------------------------------------
-- 1. DECLARACIÓN DE VARIABLES PARA UNIQUEIDENTIFIERS DE PRUEBA
--------------------------------------------------------------------
DECLARE @AdminId UNIQUEIDENTIFIER = NEWID();
DECLARE @VetId1 UNIQUEIDENTIFIER = NEWID();
DECLARE @VetId2 UNIQUEIDENTIFIER = NEWID();
DECLARE @CajeroId UNIQUEIDENTIFIER = NEWID();
DECLARE @ClienteId1 UNIQUEIDENTIFIER = NEWID();
DECLARE @ClienteId2 UNIQUEIDENTIFIER = NEWID();

DECLARE @MascotaId1 UNIQUEIDENTIFIER = NEWID();
DECLARE @MascotaId2 UNIQUEIDENTIFIER = NEWID();
DECLARE @ExpedienteId1 UNIQUEIDENTIFIER = NEWID();
DECLARE @ExpedienteId2 UNIQUEIDENTIFIER = NEWID();

DECLARE @Prod1 UNIQUEIDENTIFIER = NEWID(); 
DECLARE @Prod2 UNIQUEIDENTIFIER = NEWID(); 
DECLARE @Prod3 UNIQUEIDENTIFIER = NEWID(); 
DECLARE @Prod4 UNIQUEIDENTIFIER = NEWID(); 

DECLARE @Lote1 UNIQUEIDENTIFIER = NEWID();
DECLARE @Lote2 UNIQUEIDENTIFIER = NEWID();

DECLARE @CitaId1 UNIQUEIDENTIFIER = NEWID();
DECLARE @HistorialId1 UNIQUEIDENTIFIER = NEWID();
DECLARE @HospitalizacionId1 UNIQUEIDENTIFIER = NEWID();

DECLARE @CierreId UNIQUEIDENTIFIER = NEWID();
DECLARE @TransaccionId1 UNIQUEIDENTIFIER = NEWID();

--------------------------------------------------------------------
-- 2. USUARIOS Y SU CONFIGURACIÓN
--------------------------------------------------------------------
INSERT INTO [dbo].[usuarios] 
    ([id], [rol_id], [nombres], [apellidos], [email], [password_hash], [telefono], [intentos_fallidos], [bloqueado_hasta], [created_at])
VALUES 
    (@AdminId, 1, 'Carlos', 'Mendoza', 'admin@huellitas.com', '$2a$12$e8x/H9p...hash', '70011223', 0, NULL, GETDATE()),
    (@VetId1, 2, 'Dra. Elena', 'Rostova', 'elena.vet@huellitas.com', '$2a$12$e8x/H9p...hash', '70022334', 0, NULL, GETDATE()),
    (@VetId2, 2, 'Dr. Marco', 'Pérez', 'marco.vet@huellitas.com', '$2a$12$e8x/H9p...hash', '70033445', 0, NULL, GETDATE()),
    (@CajeroId, 3, 'Lucía', 'Fernández', 'lucia.caja@huellitas.com', '$2a$12$e8x/H9p...hash', '70044556', 0, NULL, GETDATE()),
    (@ClienteId1, 4, 'Roberto', 'Gómez', 'roberto.gomez@gmail.com', '$2a$12$e8x/H9p...hash', '71234567', 0, NULL, GETDATE()),
    (@ClienteId2, 4, 'Ana', 'Martínez', 'ana.martinez@gmail.com', '$2a$12$e8x/H9p...hash', '77654321', 0, NULL, GETDATE());

INSERT INTO [dbo].[configuracion_clinica] ([clave], [valor], [descripcion], [updated_at])
VALUES 
    ('NOMBRE_CLINICA', 'Veterinaria Huellitas Digitales', 'Nombre comercial de la veterinaria', GETDATE()),
    ('MONEDA_PRINCIPAL', 'BOB', 'Moneda utilizada para la facturación (Bolivianos)', GETDATE()),
    ('HORARIO_ATENCION', '08:00 - 20:00', 'Rango general de atención presencial', GETDATE());

INSERT INTO [dbo].[horarios_atencion] ([id], [veterinario_id], [dia_semana], [hora_inicio], [hora_fin], [created_at])
VALUES 
    (NEWID(), @VetId1, 1, '08:00:00', '16:00:00', GETDATE()), 
    (NEWID(), @VetId1, 2, '08:00:00', '16:00:00', GETDATE()), 
    (NEWID(), @VetId2, 3, '14:00:00', '20:00:00', GETDATE()); 

INSERT INTO [dbo].[fechas_bloqueadas] ([id], [veterinario_id], [fecha], [motivo])
VALUES 
    (NEWID(), @VetId1, '2026-11-25', 'Asistencia a Congreso Veterinario Internacional');

--------------------------------------------------------------------
-- 3. PRODUCTOS, SERVICIOS, LOTES Y CATALOGO VACUNAS
--------------------------------------------------------------------
INSERT INTO [dbo].[productos] 
    ([id], [categoria_id], [nombre], [descripcion], [precio_venta], [stock_actual], [stock_minimo], [requiere_receta], [es_servicio], [created_at])
VALUES 
    (@Prod1, 1, 'Amoxicilina + Ac. Clavulánico 250mg', 'Antibiótico de amplio espectro en tabletas', 45.50, 150, 20, 1, 0, GETDATE()),
    (@Prod2, 2, 'Alimento Royal Canin Gastrointestinal 3kg', 'Alimento prescrito para problemas digestivos', 220.00, 12, 3, 0, 0, GETDATE()),
    (@Prod3, 1, 'Vacuna Nobivac DHPPi', 'Vacuna séxtuple canina contra Parvovirus, Moquillo, etc.', 85.00, 45, 10, 1, 0, GETDATE()),
    (@Prod4, 1, 'Suero Fisiológico 500ml', 'Solución Salina 0.9% para hidratación/intravenosa', 18.00, 80, 15, 0, 0, GETDATE());

SET IDENTITY_INSERT [dbo].[servicios] ON;
INSERT INTO [dbo].[servicios] 
    ([id], [nombre], [descripcion], [precio], [duracion_minutos], [requiere_veterinario], [created_at])
VALUES 
    (1, 'Consulta Médica General', 'Evaluación clínica completa de rutina o emergencia', 70.00, 30, 1, GETDATE()),
    (2, 'Profilaxis Dental Canina', 'Limpieza ultrasonica y pulido dental bajo anestesia', 350.00, 90, 1, GETDATE()),
    (3, 'Baño y Peluquería Completa', 'Corte, baño medicado, secado y vaciado de glándulas', 80.00, 60, 0, GETDATE());
SET IDENTITY_INSERT [dbo].[servicios] OFF;

SET IDENTITY_INSERT [dbo].[catalogo_vacunas] ON;
INSERT INTO [dbo].[catalogo_vacunas] 
    ([id], [especie_id], [producto_id], [nombre], [dias_para_refuerzo], [created_at])
VALUES 
    (1, 1, @Prod3, 'Séxtuple Canina (DHPPi)', 365, GETDATE()),
    (2, 1, NULL, 'Antirrábica Canina', 365, GETDATE()),
    (3, 2, NULL, 'Triple Felina', 365, GETDATE());
SET IDENTITY_INSERT [dbo].[catalogo_vacunas] OFF;

INSERT INTO [dbo].[lotes_caducidad] 
    ([id], [producto_id], [numero_lote], [fecha_vencimiento], [cantidad_inicial], [cantidad_actual], [created_at])
VALUES 
    (@Lote1, @Prod3, 'LOT-VAC-2026-A', '2027-08-15', 50, 45, GETDATE()),
    (@Lote2, @Prod1, 'LOT-AMX-99812', '2028-01-10', 200, 150, GETDATE());

INSERT INTO [dbo].[kardex_inventario] ([id], [producto_id], [tipo_movimiento], [cantidad], [saldo_resultante], [motivo], [created_at])
VALUES 
    (NEWID(), @Prod3, 'ENTRADA', 50, 50, 'Compra inicial a proveedor FarmaVet', GETDATE()),
    (NEWID(), @Prod3, 'SALIDA', 5, 45, 'Aplicación a pacientes en clínica', GETDATE());

--------------------------------------------------------------------
-- 4. MASCOTAS Y EXPEDIENTES CLINICOS
--------------------------------------------------------------------
INSERT INTO [dbo].[mascotas] 
    ([id], [dueño_id], [raza_id], [nombre], [genero], [fecha_nacimiento], [peso_actual], [hash_qr_identidad], [perdida], [created_at])
VALUES 
    (@MascotaId1, @ClienteId1, 2, 'Max', 'Macho', '2022-04-12', 28.50, 'HASH_QR_MAX_99218281', 0, GETDATE()),
    (@MascotaId2, @ClienteId2, 3, 'Luna', 'Hembra', '2023-01-20', 4.10, 'HASH_QR_LUNA_1120491', 0, GETDATE());

INSERT INTO [dbo].[expediente_clinico] ([id], [mascota_id], [created_at])
VALUES 
    (@ExpedienteId1, @MascotaId1, GETDATE()),
    (@ExpedienteId2, @MascotaId2, GETDATE());

--------------------------------------------------------------------
-- 5. FLUJO CLINICO: CITAS, HISTORIAL, HOSPITALIZACION, RECETAS
--------------------------------------------------------------------
INSERT INTO [dbo].[citas] 
    ([id], [mascota_id], [veterinario_id], [fecha_hora], [origen], [prioridad], [estado], [created_at])
VALUES 
    (@CitaId1, @MascotaId1, @VetId1, '2026-11-05 09:30:00', 'WEB', 'MEDIA', 'COMPLETADA', GETDATE());

INSERT INTO [dbo].[historial_clinico] 
    ([id], [expediente_id], [cita_id], [veterinario_id], [peso], [temperatura], [frecuencia_cardiaca], [frecuencia_respiratoria], [motivo_consulta], [diagnostico], [notas_internas], [estado], [created_at])
VALUES 
    (@HistorialId1, @ExpedienteId1, @CitaId1, @VetId1, 28.50, 38.60, 95, 22, 'Paciente presenta cuadro de gastroenteritis leve y deshidratación moderada.', 'Gastroenteritis aguda no complicada.', 'Revisar evolución en 48 horas.', 'FINALIZADO', GETDATE());

INSERT INTO [dbo].[vacunas_aplicadas] 
    ([id], [historial_id], [hospitalizacion_id], [catalogo_vacuna_id], [lote_id], [fecha_aplicacion], [fecha_proxima_dosis])
VALUES 
    (NEWID(), @HistorialId1, NULL, 1, @Lote1, '2026-11-05 09:45:00', '2027-11-05');

INSERT INTO [dbo].[archivos_adjuntos] 
    ([id], [historial_id], [hospitalizacion_id], [url_archivo], [tipo_archivo], [nombre_archivo], [created_at])
VALUES 
    (NEWID(), @HistorialId1, NULL, 'https://storage.huellitas.com/radiografias/rad_max_20261105.jpg', 'IMAGE/JPEG', 'Radiografía Abdominal Max', GETDATE());

DECLARE @RecetaId1 UNIQUEIDENTIFIER = NEWID();
INSERT INTO [dbo].[recetas] ([id], [historial_id], [veterinario_id], [indicaciones_generales], [created_at])
VALUES 
    (@RecetaId1, @HistorialId1, @VetId1, 'Ofrecer abundante agua limpia, dieta blanda (arroz con pollo hervido) por 3 días.', GETDATE());

INSERT INTO [dbo].[detalles_receta] ([id], [receta_id], [producto_id], [medicamento_texto_libre], [dosis], [frecuencia], [duracion])
VALUES 
    (NEWID(), @RecetaId1, @Prod1, NULL, '1 Tableta (250mg)', 'Cada 12 horas', '7 días'),
    (NEWID(), @RecetaId1, NULL, 'Probiótico Canino en Pasta', '2 ml', 'Cada 24 horas', '5 días');

INSERT INTO [dbo].[hospitalizaciones] 
    ([id], [historial_id], [mascota_id], [veterinario_id], [fecha_ingreso], [fecha_egreso], [estado], [observaciones], [created_at])
VALUES 
    (@HospitalizacionId1, @HistorialId1, @MascotaId1, @VetId1, '2026-11-05 10:00:00', '2026-11-06 17:00:00', 'ALTA_MEDICA', 'Monitoreo de fluidoterapia completado con éxito.', GETDATE());

INSERT INTO [dbo].[hospitalizacion_insumos] ([id], [hospitalizacion_id], [producto_id], [servicio_id], [cantidad], [subtotal], [created_at])
VALUES 
    (NEWID(), @HospitalizacionId1, @Prod4, NULL, 2, 36.00, GETDATE());

-- AQUÍ ESTABA EL ERROR (CORREGIDO DE @Vet1 A @VetId1)
INSERT INTO [dbo].[monitoreo_diario] 
    ([id], [hospitalizacion_id], [responsable_id], [turno], [peso], [temperatura], [frecuencia_cardiaca], [observaciones], [created_at])
VALUES 
    (NEWID(), @HospitalizacionId1, @VetId1, 'MANANA', 28.50, 38.50, 92, 'Paciente estable, tolerando fluidoterapia oral.', GETDATE());

--------------------------------------------------------------------
-- 6. MODULO DE CAJA Y FACTURACIÓN
--------------------------------------------------------------------
INSERT INTO [dbo].[transacciones_caja] 
    ([id], [cajero_id], [historial_id], [hospitalizacion_id], [subtotal], [descuento], [total], [metodo_pago], [estado], [created_at])
VALUES 
    (@TransaccionId1, @CajeroId, @HistorialId1, @HospitalizacionId1, 191.00, 10.00, 181.00, 'EFECTIVO', 'PAGADO', GETDATE());

INSERT INTO [dbo].[detalles_transaccion] ([id], [transaccion_id], [producto_id], [servicio_id], [cantidad], [precio_unitario], [subtotal], [tipo_cobro])
VALUES 
    (NEWID(), @TransaccionId1, NULL, 1, 1, 70.00, 70.00, 'SERVICIO'),          
    (NEWID(), @TransaccionId1, @Prod3, NULL, 1, 85.00, 85.00, 'PRODUCTO'),      
    (NEWID(), @TransaccionId1, @Prod4, NULL, 2, 18.00, 36.00, 'HOSPITALIZACION');

INSERT INTO [dbo].[cierres_caja] 
    ([id], [cajero_id], [fecha], [turno], [total_efectivo], [total_qr_transferencia], [total_tarjeta], [monto_total_recaudado], [created_at])
VALUES 
    (@CierreId, @CajeroId, '2026-11-05', 'TARDE', 181.00, 250.00, 500.00, 931.00, GETDATE());

--------------------------------------------------------------------
-- 7. AUDITORÍA, NOTIFICACIONES Y BOT
--------------------------------------------------------------------
INSERT INTO [dbo].[registro_escaneos_qr] ([id], [mascota_id], [latitud], [longitud], [user_agent], [created_at])
VALUES 
    (NEWID(), @MascotaId1, -16.500093, -68.119293, 'Mozilla/5.0 (iPhone; CPU iPhone OS 16_5 like Mac OS X)', GETDATE());

INSERT INTO [dbo].[interacciones_bot] ([id], [mascota_id], [mensaje_usuario], [intencion_detectada], [respuesta_ia], [created_at])
VALUES 
    (NEWID(), @MascotaId1, '¿Cuándo le toca la próxima vacuna a Max?', 'CONSULTA_VACUNAS', 'A Max le corresponde su próxima dosis de Séxtuple Canina el 05/11/2027.', GETDATE());

INSERT INTO [dbo].[registro_notificaciones] ([id], [usuario_id], [canal], [mensaje], [estado], [created_at])
VALUES 
    (NEWID(), @ClienteId1, 'WHATSAPP', 'Estimado Roberto, recordatorio de cita médica para Max mañana a las 09:30 AM.', 'ENVIADO', GETDATE());

INSERT INTO [dbo].[logs_sistema] ([id], [usuario_id], [categoria], [accion], [detalles], [created_at])
VALUES 
    (NEWID(), @AdminId, 'SEGURIDAD', 'Inicio de sesión exitoso', N'El usuario admin@huellitas.com inició sesión desde la IP 192.168.1.10', GETDATE());

COMMIT TRANSACTION;
GO