USE [master];
GO

-- Cerrar conexiones activas
ALTER DATABASE [HuellitasDigitales]
SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
GO

-- Restaurar la base de datos
RESTORE DATABASE [HuellitasDigitales]
FROM DISK = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\Backup\HuellitasDigitales.bak'
WITH
    FILE = 1,
    MOVE N'HuellitasDigitales'
        TO N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\HuellitasDigitales.mdf',
    MOVE N'HuellitasDigitales_log'
        TO N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\HuellitasDigitales_log.ldf',
    REPLACE,
    RECOVERY,
    STATS = 10;
GO

-- Habilitar acceso multiusuario
ALTER DATABASE [HuellitasDigitales]
SET MULTI_USER;
GO