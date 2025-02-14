USE [master]
GO
/****** Object:  Database [VILLAEJEMPLO]    Script Date: 14/05/2023 22:16:09 ******/
CREATE DATABASE [VILLAEJEMPLO]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'VILLAEJEMPLO', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\VILLAEJEMPLO.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'VILLAEJEMPLO_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\VILLAEJEMPLO_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [VILLAEJEMPLO] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [VILLAEJEMPLO].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [VILLAEJEMPLO] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [VILLAEJEMPLO] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [VILLAEJEMPLO] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [VILLAEJEMPLO] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [VILLAEJEMPLO] SET ARITHABORT OFF 
GO
ALTER DATABASE [VILLAEJEMPLO] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [VILLAEJEMPLO] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [VILLAEJEMPLO] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [VILLAEJEMPLO] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [VILLAEJEMPLO] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [VILLAEJEMPLO] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [VILLAEJEMPLO] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [VILLAEJEMPLO] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [VILLAEJEMPLO] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [VILLAEJEMPLO] SET  ENABLE_BROKER 
GO
ALTER DATABASE [VILLAEJEMPLO] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [VILLAEJEMPLO] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [VILLAEJEMPLO] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [VILLAEJEMPLO] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [VILLAEJEMPLO] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [VILLAEJEMPLO] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [VILLAEJEMPLO] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [VILLAEJEMPLO] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [VILLAEJEMPLO] SET  MULTI_USER 
GO
ALTER DATABASE [VILLAEJEMPLO] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [VILLAEJEMPLO] SET DB_CHAINING OFF 
GO
ALTER DATABASE [VILLAEJEMPLO] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [VILLAEJEMPLO] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [VILLAEJEMPLO] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [VILLAEJEMPLO] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [VILLAEJEMPLO] SET QUERY_STORE = OFF
GO
USE [VILLAEJEMPLO]
GO
/****** Object:  Table [dbo].[Alumno]    Script Date: 14/05/2023 22:16:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Alumno](
	[idAlumno] [int] IDENTITY(1,1) NOT NULL,
	[matricula] [varchar](6) NOT NULL,
	[nombreAlumno] [varchar](50) NOT NULL,
	[apellidoPaterno] [varchar](30) NOT NULL,
	[apellidoMaterno] [varchar](30) NULL,
	[sexo] [char](1) NULL,
	[CURP] [varchar](18) NOT NULL,
	[telefono] [varchar](10) NULL,
	[estadoAlumno] [varchar](10) NOT NULL,
	[fechaEntrada] [date] NOT NULL,
	[gradoActual] [smallint] NOT NULL,
 CONSTRAINT [PK_Alumno] PRIMARY KEY CLUSTERED 
(
	[matricula] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[VAlumno]    Script Date: 14/05/2023 22:16:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[VAlumno] AS

SELECT idAlumno AS ID, matricula, nombreAlumno AS Nombre, apellidoPaterno AS 'Apellido Paterno', apellidoMaterno AS 'Apellido Materno', sexo, CURP, telefono, estadoAlumno AS Estado, fechaEntrada, gradoActual
FROM dbo.Alumno
GO
/****** Object:  Table [dbo].[Secretario]    Script Date: 14/05/2023 22:16:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Secretario](
	[idRegistro] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](30) NOT NULL,
	[apellidoPaterno] [varchar](30) NOT NULL,
	[apellidoMaterno] [varchar](30) NOT NULL,
	[claveAcceso] [varchar](10) NOT NULL,
	[matricula] [varchar](6) NOT NULL,
 CONSTRAINT [PK_matricula] PRIMARY KEY CLUSTERED 
(
	[matricula] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HistorialAcceso]    Script Date: 14/05/2023 22:16:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HistorialAcceso](
	[idHistorial] [int] IDENTITY(1,1) NOT NULL,
	[matricula] [varchar](6) NOT NULL,
	[fechaAcceso] [datetime] NOT NULL,
 CONSTRAINT [PK_idHistorial] PRIMARY KEY CLUSTERED 
(
	[idHistorial] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[VHistorialAcceso]    Script Date: 14/05/2023 22:16:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[VHistorialAcceso] AS
SELECT h.idHistorial AS 'ID', CONCAT(s.nombre ,' ',s.apellidoPaterno,' ',s.apellidoMaterno )AS 'Usuario', h.matricula AS 'Matricula', h.fechaAcceso AS 'Fecha de Acceso'
FROM HistorialAcceso h
JOIN Secretario s ON h.matricula = s.matricula;
GO
/****** Object:  Table [dbo].[Materia]    Script Date: 14/05/2023 22:16:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Materia](
	[idMateria] [int] IDENTITY(1,1) NOT NULL,
	[claveMateria] [varchar](3) NOT NULL,
	[nombre] [varchar](20) NOT NULL,
 CONSTRAINT [PK_Materia] PRIMARY KEY CLUSTERED 
(
	[claveMateria] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[VMateria]    Script Date: 14/05/2023 22:16:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[VMateria] AS
SELECT 
    idMateria AS ID, 
    claveMateria AS Clave, 
    nombre AS Nombre
FROM Materia;
GO
/****** Object:  Table [dbo].[Profesor]    Script Date: 14/05/2023 22:16:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Profesor](
	[idProfesor] [int] IDENTITY(1,1) NOT NULL,
	[claveProfesor] [varchar](3) NOT NULL,
	[nombreProfesor] [varchar](50) NOT NULL,
	[apellidoPaterno] [varchar](30) NOT NULL,
	[apellidoMaterno] [varchar](30) NULL,
	[correoLaboral] [varchar](200) NOT NULL,
	[telefonoProfesor] [varchar](10) NOT NULL,
 CONSTRAINT [PK_claveProfesor] PRIMARY KEY CLUSTERED 
(
	[claveProfesor] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[VProfesor]    Script Date: 14/05/2023 22:16:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[VProfesor] AS
SELECT idProfesor AS ID, claveProfesor AS Clave, nombreProfesor AS Nombre, apellidoPaterno AS [Apellido Paterno], apellidoMaterno AS [Apellido Materno], correoLaboral AS Correo, telefonoProfesor AS Telefono
FROM     dbo.Profesor
GO
/****** Object:  Table [dbo].[DatosAcademicos]    Script Date: 14/05/2023 22:16:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DatosAcademicos](
	[idRegistro] [int] IDENTITY(1,1) NOT NULL,
	[matricula] [varchar](6) NOT NULL,
	[claveProfesor] [varchar](3) NOT NULL,
	[grado] [smallint] NOT NULL,
	[claveMateria] [varchar](3) NOT NULL,
	[calificacionFINAL] [decimal](2, 1) NOT NULL,
	[estadoReprobado] [varchar](10) NOT NULL,
 CONSTRAINT [PK_DatosAcademicos] PRIMARY KEY CLUSTERED 
(
	[idRegistro] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[VDatosAcademicos]    Script Date: 14/05/2023 22:16:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[VDatosAcademicos] AS
SELECT 
    idRegistro AS ID, 
	CONCAT(Alumno.nombreAlumno,' ',Alumno.apellidoPaterno, ' ',  Alumno.apellidoMaterno) AS 'Alumno',
    Alumno.matricula AS 'Matricula', 
	CONCAT(Profesor.nombreProfesor, ' ', Profesor.apellidoPaterno, ' ', Profesor.apellidoMaterno) AS 'Profesor', 
    Profesor.claveProfesor AS 'Clave de Profesor', 
    DatosAcademicos.grado AS Grado, 
	Materia.nombre AS 'Materia',
    Materia.claveMateria AS 'Clave de Materia', 
    DatosAcademicos.calificacionFINAL AS 'Calificacion Final', 
    DatosAcademicos.estadoReprobado AS 'Estado'
FROM DatosAcademicos
INNER JOIN Alumno ON DatosAcademicos.matricula = Alumno.matricula
INNER JOIN Profesor ON DatosAcademicos.claveProfesor = Profesor.claveProfesor
INNER JOIN Materia ON DatosAcademicos.claveMateria = Materia.claveMateria;
GO
/****** Object:  View [dbo].[VistaHistorialAcceso]    Script Date: 14/05/2023 22:16:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[VistaHistorialAcceso] AS
SELECT 
    idHistorial AS ID,
    Secretario.matricula AS Matricula, 
    fechaAcceso AS FechaAcceso, 
    Secretario.nombre + ' ' + Secretario.apellidoPaterno + ' ' + Secretario.apellidoMaterno AS Secretario
FROM HistorialAcceso
INNER JOIN Secretario ON HistorialAcceso.matricula = Secretario.matricula;
GO
/****** Object:  View [dbo].[VSecretario]    Script Date: 14/05/2023 22:16:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[VSecretario] AS
SELECT 
    idRegistro AS ID, 
    nombre AS Nombre, 
    apellidoPaterno AS 'Apellido Paterno', 
    apellidoMaterno AS 'Apellido Materno', 
		  claveAcceso AS ClaveAcceso ,
    matricula AS Matricula

FROM Secretario;
GO
SET IDENTITY_INSERT [dbo].[Alumno] ON 

INSERT [dbo].[Alumno] ([idAlumno], [matricula], [nombreAlumno], [apellidoPaterno], [apellidoMaterno], [sexo], [CURP], [telefono], [estadoAlumno], [fechaEntrada], [gradoActual]) VALUES (1, N'201000', N'Leonardo', N'Loza', N'Milán', N'M', N'LOML01010102', N'8721318983', N'ACTIVO', CAST(N'2023-06-04' AS Date), 3)
INSERT [dbo].[Alumno] ([idAlumno], [matricula], [nombreAlumno], [apellidoPaterno], [apellidoMaterno], [sexo], [CURP], [telefono], [estadoAlumno], [fechaEntrada], [gradoActual]) VALUES (2, N'201002', N'Leonardo', N'Paco', N'Pariente', N'F', N'LOCP394567', N'8724564', N'ACTIVO', CAST(N'2023-05-02' AS Date), 2)
INSERT [dbo].[Alumno] ([idAlumno], [matricula], [nombreAlumno], [apellidoPaterno], [apellidoMaterno], [sexo], [CURP], [telefono], [estadoAlumno], [fechaEntrada], [gradoActual]) VALUES (4, N'201003', N'Pablinski Paquito', N'Ulises', N'Carpincho', N'M', N'FOCM770826MVZLHR74', N'8721319999', N'GRADUADO', CAST(N'2023-05-14' AS Date), 5)
SET IDENTITY_INSERT [dbo].[Alumno] OFF
GO
SET IDENTITY_INSERT [dbo].[DatosAcademicos] ON 

INSERT [dbo].[DatosAcademicos] ([idRegistro], [matricula], [claveProfesor], [grado], [claveMateria], [calificacionFINAL], [estadoReprobado]) VALUES (1, N'201002', N'001', 3, N'100', CAST(5.2 AS Decimal(2, 1)), N'Reprobado')
INSERT [dbo].[DatosAcademicos] ([idRegistro], [matricula], [claveProfesor], [grado], [claveMateria], [calificacionFINAL], [estadoReprobado]) VALUES (2, N'201002', N'002', 4, N'200', CAST(7.8 AS Decimal(2, 1)), N'Aprobado')
INSERT [dbo].[DatosAcademicos] ([idRegistro], [matricula], [claveProfesor], [grado], [claveMateria], [calificacionFINAL], [estadoReprobado]) VALUES (3, N'201000', N'002', 4, N'100', CAST(4.3 AS Decimal(2, 1)), N'Reprobado')
INSERT [dbo].[DatosAcademicos] ([idRegistro], [matricula], [claveProfesor], [grado], [claveMateria], [calificacionFINAL], [estadoReprobado]) VALUES (4, N'201002', N'003', 3, N'200', CAST(8.6 AS Decimal(2, 1)), N'Aprobado')
INSERT [dbo].[DatosAcademicos] ([idRegistro], [matricula], [claveProfesor], [grado], [claveMateria], [calificacionFINAL], [estadoReprobado]) VALUES (5, N'201002', N'003', 3, N'100', CAST(8.6 AS Decimal(2, 1)), N'Aprobado')
INSERT [dbo].[DatosAcademicos] ([idRegistro], [matricula], [claveProfesor], [grado], [claveMateria], [calificacionFINAL], [estadoReprobado]) VALUES (6, N'201002', N'003', 5, N'100', CAST(8.6 AS Decimal(2, 1)), N'Aprobado')
SET IDENTITY_INSERT [dbo].[DatosAcademicos] OFF
GO
SET IDENTITY_INSERT [dbo].[HistorialAcceso] ON 

INSERT [dbo].[HistorialAcceso] ([idHistorial], [matricula], [fechaAcceso]) VALUES (5, N'201002', CAST(N'2023-05-02T18:16:58.130' AS DateTime))
INSERT [dbo].[HistorialAcceso] ([idHistorial], [matricula], [fechaAcceso]) VALUES (6, N'201002', CAST(N'2023-05-02T19:17:18.340' AS DateTime))
INSERT [dbo].[HistorialAcceso] ([idHistorial], [matricula], [fechaAcceso]) VALUES (7, N'201002', CAST(N'2023-05-05T18:25:51.000' AS DateTime))
INSERT [dbo].[HistorialAcceso] ([idHistorial], [matricula], [fechaAcceso]) VALUES (8, N'201002', CAST(N'2023-05-05T18:45:05.000' AS DateTime))
INSERT [dbo].[HistorialAcceso] ([idHistorial], [matricula], [fechaAcceso]) VALUES (9, N'201002', CAST(N'2023-05-05T18:45:28.000' AS DateTime))
INSERT [dbo].[HistorialAcceso] ([idHistorial], [matricula], [fechaAcceso]) VALUES (10, N'201002', CAST(N'2023-05-05T18:51:31.000' AS DateTime))
INSERT [dbo].[HistorialAcceso] ([idHistorial], [matricula], [fechaAcceso]) VALUES (11, N'201002', CAST(N'2023-05-05T19:04:03.000' AS DateTime))
INSERT [dbo].[HistorialAcceso] ([idHistorial], [matricula], [fechaAcceso]) VALUES (12, N'201002', CAST(N'2023-05-05T19:06:02.000' AS DateTime))
INSERT [dbo].[HistorialAcceso] ([idHistorial], [matricula], [fechaAcceso]) VALUES (13, N'201002', CAST(N'2023-05-05T19:06:56.000' AS DateTime))
INSERT [dbo].[HistorialAcceso] ([idHistorial], [matricula], [fechaAcceso]) VALUES (14, N'201002', CAST(N'2023-05-05T19:08:17.000' AS DateTime))
INSERT [dbo].[HistorialAcceso] ([idHistorial], [matricula], [fechaAcceso]) VALUES (15, N'201002', CAST(N'2023-05-05T19:13:15.000' AS DateTime))
INSERT [dbo].[HistorialAcceso] ([idHistorial], [matricula], [fechaAcceso]) VALUES (16, N'201002', CAST(N'2023-05-05T19:15:52.000' AS DateTime))
INSERT [dbo].[HistorialAcceso] ([idHistorial], [matricula], [fechaAcceso]) VALUES (17, N'201002', CAST(N'2023-07-05T21:40:06.000' AS DateTime))
INSERT [dbo].[HistorialAcceso] ([idHistorial], [matricula], [fechaAcceso]) VALUES (18, N'201002', CAST(N'2023-07-05T22:20:22.000' AS DateTime))
INSERT [dbo].[HistorialAcceso] ([idHistorial], [matricula], [fechaAcceso]) VALUES (19, N'201002', CAST(N'2023-07-05T22:21:25.000' AS DateTime))
INSERT [dbo].[HistorialAcceso] ([idHistorial], [matricula], [fechaAcceso]) VALUES (20, N'201002', CAST(N'2023-07-05T22:24:00.000' AS DateTime))
INSERT [dbo].[HistorialAcceso] ([idHistorial], [matricula], [fechaAcceso]) VALUES (21, N'201002', CAST(N'2023-07-05T22:26:00.000' AS DateTime))
INSERT [dbo].[HistorialAcceso] ([idHistorial], [matricula], [fechaAcceso]) VALUES (22, N'201002', CAST(N'2023-07-05T22:27:23.000' AS DateTime))
INSERT [dbo].[HistorialAcceso] ([idHistorial], [matricula], [fechaAcceso]) VALUES (23, N'201002', CAST(N'2023-07-05T22:28:34.000' AS DateTime))
INSERT [dbo].[HistorialAcceso] ([idHistorial], [matricula], [fechaAcceso]) VALUES (24, N'201002', CAST(N'2023-07-05T22:29:50.000' AS DateTime))
INSERT [dbo].[HistorialAcceso] ([idHistorial], [matricula], [fechaAcceso]) VALUES (25, N'201002', CAST(N'2023-07-05T22:36:55.000' AS DateTime))
INSERT [dbo].[HistorialAcceso] ([idHistorial], [matricula], [fechaAcceso]) VALUES (26, N'201002', CAST(N'2023-07-05T22:54:05.000' AS DateTime))
INSERT [dbo].[HistorialAcceso] ([idHistorial], [matricula], [fechaAcceso]) VALUES (27, N'201002', CAST(N'2023-09-05T11:29:04.000' AS DateTime))
INSERT [dbo].[HistorialAcceso] ([idHistorial], [matricula], [fechaAcceso]) VALUES (28, N'201002', CAST(N'2023-09-05T11:31:12.000' AS DateTime))
INSERT [dbo].[HistorialAcceso] ([idHistorial], [matricula], [fechaAcceso]) VALUES (29, N'201002', CAST(N'2023-09-05T11:33:10.000' AS DateTime))
INSERT [dbo].[HistorialAcceso] ([idHistorial], [matricula], [fechaAcceso]) VALUES (30, N'201002', CAST(N'2023-09-05T12:27:22.000' AS DateTime))
INSERT [dbo].[HistorialAcceso] ([idHistorial], [matricula], [fechaAcceso]) VALUES (31, N'201002', CAST(N'2023-09-05T12:50:53.000' AS DateTime))
INSERT [dbo].[HistorialAcceso] ([idHistorial], [matricula], [fechaAcceso]) VALUES (32, N'201002', CAST(N'2023-11-05T11:39:42.000' AS DateTime))
INSERT [dbo].[HistorialAcceso] ([idHistorial], [matricula], [fechaAcceso]) VALUES (33, N'201002', CAST(N'2023-11-05T11:42:04.000' AS DateTime))
INSERT [dbo].[HistorialAcceso] ([idHistorial], [matricula], [fechaAcceso]) VALUES (34, N'201002', CAST(N'2023-11-05T23:56:32.000' AS DateTime))
INSERT [dbo].[HistorialAcceso] ([idHistorial], [matricula], [fechaAcceso]) VALUES (35, N'201002', CAST(N'2023-12-05T00:42:01.000' AS DateTime))
INSERT [dbo].[HistorialAcceso] ([idHistorial], [matricula], [fechaAcceso]) VALUES (36, N'201002', CAST(N'2023-12-05T00:43:02.000' AS DateTime))
INSERT [dbo].[HistorialAcceso] ([idHistorial], [matricula], [fechaAcceso]) VALUES (37, N'201002', CAST(N'2023-12-05T00:46:30.000' AS DateTime))
INSERT [dbo].[HistorialAcceso] ([idHistorial], [matricula], [fechaAcceso]) VALUES (38, N'201002', CAST(N'2023-12-05T00:49:14.000' AS DateTime))
INSERT [dbo].[HistorialAcceso] ([idHistorial], [matricula], [fechaAcceso]) VALUES (39, N'201002', CAST(N'2023-12-05T00:49:56.000' AS DateTime))
INSERT [dbo].[HistorialAcceso] ([idHistorial], [matricula], [fechaAcceso]) VALUES (40, N'201002', CAST(N'2023-12-05T00:50:31.000' AS DateTime))
INSERT [dbo].[HistorialAcceso] ([idHistorial], [matricula], [fechaAcceso]) VALUES (41, N'201002', CAST(N'2023-12-05T00:55:36.000' AS DateTime))
INSERT [dbo].[HistorialAcceso] ([idHistorial], [matricula], [fechaAcceso]) VALUES (42, N'201002', CAST(N'2023-12-05T00:57:38.000' AS DateTime))
INSERT [dbo].[HistorialAcceso] ([idHistorial], [matricula], [fechaAcceso]) VALUES (43, N'201002', CAST(N'2023-12-05T01:00:30.000' AS DateTime))
INSERT [dbo].[HistorialAcceso] ([idHistorial], [matricula], [fechaAcceso]) VALUES (44, N'201002', CAST(N'2023-12-05T01:06:37.000' AS DateTime))
INSERT [dbo].[HistorialAcceso] ([idHistorial], [matricula], [fechaAcceso]) VALUES (45, N'201002', CAST(N'2023-05-13T17:57:14.857' AS DateTime))
INSERT [dbo].[HistorialAcceso] ([idHistorial], [matricula], [fechaAcceso]) VALUES (46, N'201002', CAST(N'2023-05-13T17:57:59.697' AS DateTime))
INSERT [dbo].[HistorialAcceso] ([idHistorial], [matricula], [fechaAcceso]) VALUES (47, N'201002', CAST(N'2023-05-13T17:58:57.353' AS DateTime))
INSERT [dbo].[HistorialAcceso] ([idHistorial], [matricula], [fechaAcceso]) VALUES (48, N'201002', CAST(N'2023-05-13T17:59:57.103' AS DateTime))
INSERT [dbo].[HistorialAcceso] ([idHistorial], [matricula], [fechaAcceso]) VALUES (49, N'201002', CAST(N'2023-05-13T18:10:03.273' AS DateTime))
INSERT [dbo].[HistorialAcceso] ([idHistorial], [matricula], [fechaAcceso]) VALUES (50, N'201002', CAST(N'2023-05-13T18:16:41.920' AS DateTime))
INSERT [dbo].[HistorialAcceso] ([idHistorial], [matricula], [fechaAcceso]) VALUES (51, N'201002', CAST(N'2023-05-13T18:20:08.887' AS DateTime))
INSERT [dbo].[HistorialAcceso] ([idHistorial], [matricula], [fechaAcceso]) VALUES (52, N'201002', CAST(N'2023-05-13T18:23:01.800' AS DateTime))
INSERT [dbo].[HistorialAcceso] ([idHistorial], [matricula], [fechaAcceso]) VALUES (53, N'201002', CAST(N'2023-05-13T18:24:09.530' AS DateTime))
INSERT [dbo].[HistorialAcceso] ([idHistorial], [matricula], [fechaAcceso]) VALUES (54, N'201002', CAST(N'2023-05-13T18:52:08.707' AS DateTime))
INSERT [dbo].[HistorialAcceso] ([idHistorial], [matricula], [fechaAcceso]) VALUES (55, N'201002', CAST(N'2023-05-13T19:12:34.520' AS DateTime))
INSERT [dbo].[HistorialAcceso] ([idHistorial], [matricula], [fechaAcceso]) VALUES (56, N'201002', CAST(N'2023-05-13T19:15:23.123' AS DateTime))
INSERT [dbo].[HistorialAcceso] ([idHistorial], [matricula], [fechaAcceso]) VALUES (57, N'201002', CAST(N'2023-05-13T19:20:34.637' AS DateTime))
INSERT [dbo].[HistorialAcceso] ([idHistorial], [matricula], [fechaAcceso]) VALUES (58, N'201002', CAST(N'2023-05-13T19:23:02.040' AS DateTime))
INSERT [dbo].[HistorialAcceso] ([idHistorial], [matricula], [fechaAcceso]) VALUES (59, N'201002', CAST(N'2023-05-13T21:12:04.153' AS DateTime))
INSERT [dbo].[HistorialAcceso] ([idHistorial], [matricula], [fechaAcceso]) VALUES (60, N'201002', CAST(N'2023-05-13T21:56:16.230' AS DateTime))
INSERT [dbo].[HistorialAcceso] ([idHistorial], [matricula], [fechaAcceso]) VALUES (61, N'201002', CAST(N'2023-05-13T21:57:24.190' AS DateTime))
INSERT [dbo].[HistorialAcceso] ([idHistorial], [matricula], [fechaAcceso]) VALUES (62, N'201002', CAST(N'2023-05-13T21:57:45.400' AS DateTime))
INSERT [dbo].[HistorialAcceso] ([idHistorial], [matricula], [fechaAcceso]) VALUES (63, N'201002', CAST(N'2023-05-13T21:59:23.747' AS DateTime))
INSERT [dbo].[HistorialAcceso] ([idHistorial], [matricula], [fechaAcceso]) VALUES (64, N'201002', CAST(N'2023-05-13T22:02:03.163' AS DateTime))
INSERT [dbo].[HistorialAcceso] ([idHistorial], [matricula], [fechaAcceso]) VALUES (65, N'201002', CAST(N'2023-05-13T22:02:58.300' AS DateTime))
INSERT [dbo].[HistorialAcceso] ([idHistorial], [matricula], [fechaAcceso]) VALUES (66, N'201002', CAST(N'2023-05-13T22:06:09.300' AS DateTime))
INSERT [dbo].[HistorialAcceso] ([idHistorial], [matricula], [fechaAcceso]) VALUES (67, N'201002', CAST(N'2023-05-13T22:32:03.007' AS DateTime))
INSERT [dbo].[HistorialAcceso] ([idHistorial], [matricula], [fechaAcceso]) VALUES (68, N'201002', CAST(N'2023-05-13T22:37:46.420' AS DateTime))
INSERT [dbo].[HistorialAcceso] ([idHistorial], [matricula], [fechaAcceso]) VALUES (69, N'201002', CAST(N'2023-05-13T22:43:23.073' AS DateTime))
INSERT [dbo].[HistorialAcceso] ([idHistorial], [matricula], [fechaAcceso]) VALUES (70, N'201002', CAST(N'2023-05-13T22:45:15.700' AS DateTime))
INSERT [dbo].[HistorialAcceso] ([idHistorial], [matricula], [fechaAcceso]) VALUES (71, N'201002', CAST(N'2023-05-13T22:49:51.620' AS DateTime))
INSERT [dbo].[HistorialAcceso] ([idHistorial], [matricula], [fechaAcceso]) VALUES (72, N'201002', CAST(N'2023-05-13T22:55:31.280' AS DateTime))
INSERT [dbo].[HistorialAcceso] ([idHistorial], [matricula], [fechaAcceso]) VALUES (73, N'201002', CAST(N'2023-05-13T22:56:39.580' AS DateTime))
INSERT [dbo].[HistorialAcceso] ([idHistorial], [matricula], [fechaAcceso]) VALUES (74, N'201002', CAST(N'2023-05-13T23:01:08.213' AS DateTime))
INSERT [dbo].[HistorialAcceso] ([idHistorial], [matricula], [fechaAcceso]) VALUES (75, N'201002', CAST(N'2023-05-13T23:01:36.110' AS DateTime))
INSERT [dbo].[HistorialAcceso] ([idHistorial], [matricula], [fechaAcceso]) VALUES (76, N'201002', CAST(N'2023-05-13T23:12:56.903' AS DateTime))
INSERT [dbo].[HistorialAcceso] ([idHistorial], [matricula], [fechaAcceso]) VALUES (77, N'201002', CAST(N'2023-05-13T23:15:26.570' AS DateTime))
INSERT [dbo].[HistorialAcceso] ([idHistorial], [matricula], [fechaAcceso]) VALUES (78, N'201002', CAST(N'2023-05-13T23:16:37.147' AS DateTime))
INSERT [dbo].[HistorialAcceso] ([idHistorial], [matricula], [fechaAcceso]) VALUES (79, N'201002', CAST(N'2023-05-13T23:20:18.747' AS DateTime))
INSERT [dbo].[HistorialAcceso] ([idHistorial], [matricula], [fechaAcceso]) VALUES (80, N'201002', CAST(N'2023-05-13T23:21:13.070' AS DateTime))
INSERT [dbo].[HistorialAcceso] ([idHistorial], [matricula], [fechaAcceso]) VALUES (81, N'201002', CAST(N'2023-05-13T23:22:21.423' AS DateTime))
INSERT [dbo].[HistorialAcceso] ([idHistorial], [matricula], [fechaAcceso]) VALUES (82, N'201002', CAST(N'2023-05-13T23:25:21.573' AS DateTime))
INSERT [dbo].[HistorialAcceso] ([idHistorial], [matricula], [fechaAcceso]) VALUES (83, N'201002', CAST(N'2023-05-13T23:26:27.313' AS DateTime))
INSERT [dbo].[HistorialAcceso] ([idHistorial], [matricula], [fechaAcceso]) VALUES (84, N'201002', CAST(N'2023-05-13T23:27:45.473' AS DateTime))
INSERT [dbo].[HistorialAcceso] ([idHistorial], [matricula], [fechaAcceso]) VALUES (85, N'201002', CAST(N'2023-05-13T23:29:06.677' AS DateTime))
INSERT [dbo].[HistorialAcceso] ([idHistorial], [matricula], [fechaAcceso]) VALUES (86, N'201002', CAST(N'2023-05-13T23:30:23.207' AS DateTime))
INSERT [dbo].[HistorialAcceso] ([idHistorial], [matricula], [fechaAcceso]) VALUES (87, N'201002', CAST(N'2023-05-13T23:31:24.570' AS DateTime))
INSERT [dbo].[HistorialAcceso] ([idHistorial], [matricula], [fechaAcceso]) VALUES (88, N'201002', CAST(N'2023-05-13T23:34:15.543' AS DateTime))
INSERT [dbo].[HistorialAcceso] ([idHistorial], [matricula], [fechaAcceso]) VALUES (89, N'201002', CAST(N'2023-05-13T23:36:01.920' AS DateTime))
INSERT [dbo].[HistorialAcceso] ([idHistorial], [matricula], [fechaAcceso]) VALUES (90, N'201002', CAST(N'2023-05-13T23:38:30.333' AS DateTime))
INSERT [dbo].[HistorialAcceso] ([idHistorial], [matricula], [fechaAcceso]) VALUES (91, N'201002', CAST(N'2023-05-13T23:39:33.347' AS DateTime))
INSERT [dbo].[HistorialAcceso] ([idHistorial], [matricula], [fechaAcceso]) VALUES (92, N'201002', CAST(N'2023-05-13T23:41:49.467' AS DateTime))
INSERT [dbo].[HistorialAcceso] ([idHistorial], [matricula], [fechaAcceso]) VALUES (93, N'201002', CAST(N'2023-05-13T23:51:55.327' AS DateTime))
INSERT [dbo].[HistorialAcceso] ([idHistorial], [matricula], [fechaAcceso]) VALUES (94, N'201002', CAST(N'2023-05-13T23:53:49.247' AS DateTime))
INSERT [dbo].[HistorialAcceso] ([idHistorial], [matricula], [fechaAcceso]) VALUES (95, N'201002', CAST(N'2023-05-14T00:03:24.703' AS DateTime))
INSERT [dbo].[HistorialAcceso] ([idHistorial], [matricula], [fechaAcceso]) VALUES (96, N'201002', CAST(N'2023-05-14T00:05:01.230' AS DateTime))
INSERT [dbo].[HistorialAcceso] ([idHistorial], [matricula], [fechaAcceso]) VALUES (97, N'201002', CAST(N'2023-05-14T00:06:55.080' AS DateTime))
INSERT [dbo].[HistorialAcceso] ([idHistorial], [matricula], [fechaAcceso]) VALUES (98, N'201002', CAST(N'2023-05-14T00:11:42.023' AS DateTime))
INSERT [dbo].[HistorialAcceso] ([idHistorial], [matricula], [fechaAcceso]) VALUES (99, N'201002', CAST(N'2023-05-14T00:13:29.497' AS DateTime))
INSERT [dbo].[HistorialAcceso] ([idHistorial], [matricula], [fechaAcceso]) VALUES (100, N'201002', CAST(N'2023-05-14T00:14:51.190' AS DateTime))
INSERT [dbo].[HistorialAcceso] ([idHistorial], [matricula], [fechaAcceso]) VALUES (101, N'201002', CAST(N'2023-05-14T00:16:03.153' AS DateTime))
INSERT [dbo].[HistorialAcceso] ([idHistorial], [matricula], [fechaAcceso]) VALUES (102, N'201002', CAST(N'2023-05-14T00:16:47.117' AS DateTime))
INSERT [dbo].[HistorialAcceso] ([idHistorial], [matricula], [fechaAcceso]) VALUES (103, N'201002', CAST(N'2023-05-14T00:17:27.567' AS DateTime))
GO
INSERT [dbo].[HistorialAcceso] ([idHistorial], [matricula], [fechaAcceso]) VALUES (104, N'201002', CAST(N'2023-05-14T17:32:38.703' AS DateTime))
INSERT [dbo].[HistorialAcceso] ([idHistorial], [matricula], [fechaAcceso]) VALUES (105, N'201002', CAST(N'2023-05-14T17:35:44.393' AS DateTime))
INSERT [dbo].[HistorialAcceso] ([idHistorial], [matricula], [fechaAcceso]) VALUES (106, N'201002', CAST(N'2023-05-14T17:43:41.597' AS DateTime))
INSERT [dbo].[HistorialAcceso] ([idHistorial], [matricula], [fechaAcceso]) VALUES (107, N'201002', CAST(N'2023-05-14T18:07:10.330' AS DateTime))
INSERT [dbo].[HistorialAcceso] ([idHistorial], [matricula], [fechaAcceso]) VALUES (108, N'201002', CAST(N'2023-05-14T18:23:43.657' AS DateTime))
INSERT [dbo].[HistorialAcceso] ([idHistorial], [matricula], [fechaAcceso]) VALUES (109, N'201002', CAST(N'2023-05-14T18:51:39.137' AS DateTime))
INSERT [dbo].[HistorialAcceso] ([idHistorial], [matricula], [fechaAcceso]) VALUES (110, N'201002', CAST(N'2023-05-14T18:55:10.783' AS DateTime))
INSERT [dbo].[HistorialAcceso] ([idHistorial], [matricula], [fechaAcceso]) VALUES (111, N'201002', CAST(N'2023-05-14T19:16:46.983' AS DateTime))
INSERT [dbo].[HistorialAcceso] ([idHistorial], [matricula], [fechaAcceso]) VALUES (112, N'201002', CAST(N'2023-05-14T19:23:53.680' AS DateTime))
INSERT [dbo].[HistorialAcceso] ([idHistorial], [matricula], [fechaAcceso]) VALUES (113, N'201002', CAST(N'2023-05-14T19:30:15.503' AS DateTime))
INSERT [dbo].[HistorialAcceso] ([idHistorial], [matricula], [fechaAcceso]) VALUES (114, N'201002', CAST(N'2023-05-14T19:36:36.327' AS DateTime))
INSERT [dbo].[HistorialAcceso] ([idHistorial], [matricula], [fechaAcceso]) VALUES (115, N'201002', CAST(N'2023-05-14T20:09:01.783' AS DateTime))
INSERT [dbo].[HistorialAcceso] ([idHistorial], [matricula], [fechaAcceso]) VALUES (116, N'201004', CAST(N'2023-05-14T20:09:27.590' AS DateTime))
INSERT [dbo].[HistorialAcceso] ([idHistorial], [matricula], [fechaAcceso]) VALUES (117, N'201004', CAST(N'2023-05-14T20:12:02.830' AS DateTime))
INSERT [dbo].[HistorialAcceso] ([idHistorial], [matricula], [fechaAcceso]) VALUES (118, N'201004', CAST(N'2023-05-14T20:15:44.440' AS DateTime))
INSERT [dbo].[HistorialAcceso] ([idHistorial], [matricula], [fechaAcceso]) VALUES (119, N'201002', CAST(N'2023-05-14T20:27:06.547' AS DateTime))
INSERT [dbo].[HistorialAcceso] ([idHistorial], [matricula], [fechaAcceso]) VALUES (120, N'201002', CAST(N'2023-05-14T20:38:38.423' AS DateTime))
INSERT [dbo].[HistorialAcceso] ([idHistorial], [matricula], [fechaAcceso]) VALUES (121, N'201002', CAST(N'2023-05-14T20:42:02.610' AS DateTime))
INSERT [dbo].[HistorialAcceso] ([idHistorial], [matricula], [fechaAcceso]) VALUES (122, N'201002', CAST(N'2023-05-14T20:44:01.140' AS DateTime))
INSERT [dbo].[HistorialAcceso] ([idHistorial], [matricula], [fechaAcceso]) VALUES (123, N'201004', CAST(N'2023-05-14T20:49:11.687' AS DateTime))
INSERT [dbo].[HistorialAcceso] ([idHistorial], [matricula], [fechaAcceso]) VALUES (124, N'201002', CAST(N'2023-05-14T20:54:49.170' AS DateTime))
INSERT [dbo].[HistorialAcceso] ([idHistorial], [matricula], [fechaAcceso]) VALUES (125, N'201002', CAST(N'2023-05-14T21:18:13.387' AS DateTime))
INSERT [dbo].[HistorialAcceso] ([idHistorial], [matricula], [fechaAcceso]) VALUES (126, N'201002', CAST(N'2023-05-14T21:21:58.030' AS DateTime))
INSERT [dbo].[HistorialAcceso] ([idHistorial], [matricula], [fechaAcceso]) VALUES (127, N'201002', CAST(N'2023-05-14T21:22:51.503' AS DateTime))
INSERT [dbo].[HistorialAcceso] ([idHistorial], [matricula], [fechaAcceso]) VALUES (128, N'201002', CAST(N'2023-05-14T21:31:40.650' AS DateTime))
INSERT [dbo].[HistorialAcceso] ([idHistorial], [matricula], [fechaAcceso]) VALUES (129, N'201002', CAST(N'2023-05-14T21:37:52.507' AS DateTime))
INSERT [dbo].[HistorialAcceso] ([idHistorial], [matricula], [fechaAcceso]) VALUES (130, N'201002', CAST(N'2023-05-14T21:39:07.083' AS DateTime))
INSERT [dbo].[HistorialAcceso] ([idHistorial], [matricula], [fechaAcceso]) VALUES (131, N'201002', CAST(N'2023-05-14T21:41:41.003' AS DateTime))
INSERT [dbo].[HistorialAcceso] ([idHistorial], [matricula], [fechaAcceso]) VALUES (132, N'201002', CAST(N'2023-05-14T21:42:21.050' AS DateTime))
INSERT [dbo].[HistorialAcceso] ([idHistorial], [matricula], [fechaAcceso]) VALUES (133, N'201002', CAST(N'2023-05-14T21:43:52.643' AS DateTime))
INSERT [dbo].[HistorialAcceso] ([idHistorial], [matricula], [fechaAcceso]) VALUES (134, N'201002', CAST(N'2023-05-14T21:45:09.037' AS DateTime))
INSERT [dbo].[HistorialAcceso] ([idHistorial], [matricula], [fechaAcceso]) VALUES (135, N'201002', CAST(N'2023-05-14T21:53:20.200' AS DateTime))
INSERT [dbo].[HistorialAcceso] ([idHistorial], [matricula], [fechaAcceso]) VALUES (136, N'201002', CAST(N'2023-05-14T21:55:17.330' AS DateTime))
INSERT [dbo].[HistorialAcceso] ([idHistorial], [matricula], [fechaAcceso]) VALUES (137, N'201002', CAST(N'2023-05-14T21:56:49.263' AS DateTime))
INSERT [dbo].[HistorialAcceso] ([idHistorial], [matricula], [fechaAcceso]) VALUES (138, N'201002', CAST(N'2023-05-14T21:57:46.047' AS DateTime))
INSERT [dbo].[HistorialAcceso] ([idHistorial], [matricula], [fechaAcceso]) VALUES (139, N'201002', CAST(N'2023-05-14T21:59:14.560' AS DateTime))
SET IDENTITY_INSERT [dbo].[HistorialAcceso] OFF
GO
SET IDENTITY_INSERT [dbo].[Materia] ON 

INSERT [dbo].[Materia] ([idMateria], [claveMateria], [nombre]) VALUES (2, N'100', N'Inglees')
INSERT [dbo].[Materia] ([idMateria], [claveMateria], [nombre]) VALUES (1, N'200', N'Español')
INSERT [dbo].[Materia] ([idMateria], [claveMateria], [nombre]) VALUES (3, N'202', N'Educación Física 2')
INSERT [dbo].[Materia] ([idMateria], [claveMateria], [nombre]) VALUES (6, N'203', N'Educación Especial')
INSERT [dbo].[Materia] ([idMateria], [claveMateria], [nombre]) VALUES (7, N'205', N'Artes')
SET IDENTITY_INSERT [dbo].[Materia] OFF
GO
SET IDENTITY_INSERT [dbo].[Profesor] ON 

INSERT [dbo].[Profesor] ([idProfesor], [claveProfesor], [nombreProfesor], [apellidoPaterno], [apellidoMaterno], [correoLaboral], [telefonoProfesor]) VALUES (3, N'', N'', N'', N'', N'', N'')
INSERT [dbo].[Profesor] ([idProfesor], [claveProfesor], [nombreProfesor], [apellidoPaterno], [apellidoMaterno], [correoLaboral], [telefonoProfesor]) VALUES (1, N'001', N'Juan', N'Pérez', N'González', N'juan.perez@escuela.edu.mx', N'5551234567')
INSERT [dbo].[Profesor] ([idProfesor], [claveProfesor], [nombreProfesor], [apellidoPaterno], [apellidoMaterno], [correoLaboral], [telefonoProfesor]) VALUES (2, N'002', N'Leo', N'Patinon', N'Carraspera', N'leonardo.loza@escuela.edu.mx', N'87213189')
INSERT [dbo].[Profesor] ([idProfesor], [claveProfesor], [nombreProfesor], [apellidoPaterno], [apellidoMaterno], [correoLaboral], [telefonoProfesor]) VALUES (4, N'003', N'Paco Pérez', N'Álvarez', N'Matrínez', N'paco.alvarez@tecsanpedro.edu.mx', N'8721310000')
SET IDENTITY_INSERT [dbo].[Profesor] OFF
GO
SET IDENTITY_INSERT [dbo].[Secretario] ON 

INSERT [dbo].[Secretario] ([idRegistro], [nombre], [apellidoPaterno], [apellidoMaterno], [claveAcceso], [matricula]) VALUES (1, N'Pablo', N'Rodriguez', N'Estrada', N'pepe123', N'201002')
INSERT [dbo].[Secretario] ([idRegistro], [nombre], [apellidoPaterno], [apellidoMaterno], [claveAcceso], [matricula]) VALUES (2, N'Pablo Papás', N'Rodríguez', N'Velazquéz', N'elpepe122', N'201004')
SET IDENTITY_INSERT [dbo].[Secretario] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ_CURP]    Script Date: 14/05/2023 22:16:09 ******/
ALTER TABLE [dbo].[Alumno] ADD  CONSTRAINT [UQ_CURP] UNIQUE NONCLUSTERED 
(
	[CURP] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ_telefono]    Script Date: 14/05/2023 22:16:09 ******/
ALTER TABLE [dbo].[Alumno] ADD  CONSTRAINT [UQ_telefono] UNIQUE NONCLUSTERED 
(
	[telefono] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ_correoLaboral]    Script Date: 14/05/2023 22:16:09 ******/
ALTER TABLE [dbo].[Profesor] ADD  CONSTRAINT [UQ_correoLaboral] UNIQUE NONCLUSTERED 
(
	[correoLaboral] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ_telefonoProfesor]    Script Date: 14/05/2023 22:16:09 ******/
ALTER TABLE [dbo].[Profesor] ADD  CONSTRAINT [UQ_telefonoProfesor] UNIQUE NONCLUSTERED 
(
	[telefonoProfesor] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Alumno] ADD  DEFAULT ('SN') FOR [telefono]
GO
ALTER TABLE [dbo].[DatosAcademicos]  WITH CHECK ADD  CONSTRAINT [FK_AlumnoDatosAcademicos] FOREIGN KEY([matricula])
REFERENCES [dbo].[Alumno] ([matricula])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[DatosAcademicos] CHECK CONSTRAINT [FK_AlumnoDatosAcademicos]
GO
ALTER TABLE [dbo].[DatosAcademicos]  WITH CHECK ADD  CONSTRAINT [FK_MateriaDatosAcademicos] FOREIGN KEY([claveMateria])
REFERENCES [dbo].[Materia] ([claveMateria])
GO
ALTER TABLE [dbo].[DatosAcademicos] CHECK CONSTRAINT [FK_MateriaDatosAcademicos]
GO
ALTER TABLE [dbo].[DatosAcademicos]  WITH CHECK ADD  CONSTRAINT [FK_ProfesorDatosAcademicos] FOREIGN KEY([claveProfesor])
REFERENCES [dbo].[Profesor] ([claveProfesor])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[DatosAcademicos] CHECK CONSTRAINT [FK_ProfesorDatosAcademicos]
GO
ALTER TABLE [dbo].[HistorialAcceso]  WITH CHECK ADD  CONSTRAINT [FK_SecretarioHistorial] FOREIGN KEY([matricula])
REFERENCES [dbo].[Secretario] ([matricula])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[HistorialAcceso] CHECK CONSTRAINT [FK_SecretarioHistorial]
GO
/****** Object:  StoredProcedure [dbo].[RegistrarAccesoSecretario]    Script Date: 14/05/2023 22:16:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[RegistrarAccesoSecretario]
    @matricula VARCHAR(6),
    @fechaAcceso DATETIME
AS
BEGIN TRY
    INSERT INTO HistorialAcceso (matricula, fechaAcceso)
    VALUES (@matricula, @fechaAcceso)
END TRY
BEGIN CATCH
    -- Capturar el error y hacer algo con él, por ejemplo:
    SELECT ERROR_MESSAGE() AS ErrorMessage
END CATCH
GO
/****** Object:  StoredProcedure [dbo].[sp_InsertarAcceso]    Script Date: 14/05/2023 22:16:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_InsertarAcceso] (@matricula VARCHAR(6))
AS
BEGIN
    BEGIN TRANSACTION
    INSERT INTO HistorialAcceso (matricula, fechaAcceso)
    VALUES (@matricula, GETDATE())

 
    BEGIN
        ROLLBACK TRANSACTION
  
    END

    COMMIT TRANSACTION
    
END
GO
/****** Object:  StoredProcedure [dbo].[sp_InsertarAlumno]    Script Date: 14/05/2023 22:16:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_InsertarAlumno]
(
    @matricula VARCHAR(6),
    @nombreAlumno VARCHAR(50),
    @apellidoPaterno VARCHAR(30),
    @apellidoMaterno VARCHAR(30),
    @sexo CHAR(1),
    @CURP VARCHAR(18),
    @telefono VARCHAR(10),
    @estadoAlumno VARCHAR(10),
    @fechaEntrada DATE,
    @gradoActual SMALLINT
)
AS
BEGIN
    
    BEGIN TRY
        BEGIN TRANSACTION

        INSERT INTO Alumno(matricula, nombreAlumno, apellidoPaterno, apellidoMaterno, sexo, CURP, telefono, estadoAlumno, fechaEntrada, gradoActual)
        VALUES (@matricula, @nombreAlumno, @apellidoPaterno, @apellidoMaterno, @sexo, @CURP, @telefono, @estadoAlumno, @fechaEntrada, @gradoActual)

        COMMIT TRANSACTION
    END TRY
    BEGIN CATCH
      
            ROLLBACK TRANSACTION

        THROW;
    END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[sp_InsertarDatosAcademicos]    Script Date: 14/05/2023 22:16:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_InsertarDatosAcademicos]
  
    @matricula VARCHAR(6),
    @claveProfesor VARCHAR(3),
    @grado SMALLINT,
    @claveMateria VARCHAR(3),
    @calificacionFINAL DECIMAL(2,1)
AS
BEGIN
    INSERT INTO DatosAcademicos (matricula, claveProfesor, grado, claveMateria, calificacionFINAL, estadoReprobado)
    VALUES (@matricula, @claveProfesor, @grado, @claveMateria, @calificacionFINAL, '')

  
END
GO
/****** Object:  StoredProcedure [dbo].[sp_InsertarHistorial]    Script Date: 14/05/2023 22:16:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_InsertarHistorial]
(
    @matricula VARCHAR(6),
    @fechaAcceso DATETIME
)
AS
BEGIN TRY
    BEGIN TRANSACTION

    INSERT INTO HistorialAcceso (matricula, fechaAcceso)
    VALUES (@matricula, @fechaAcceso)

    COMMIT TRANSACTION
END TRY
BEGIN CATCH
    ROLLBACK TRANSACTION
END CATCH
GO
/****** Object:  StoredProcedure [dbo].[sp_InsertarMateria]    Script Date: 14/05/2023 22:16:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_InsertarMateria]
    @claveMateria VARCHAR(3),
    @nombre VARCHAR(20)
AS
BEGIN
   
    BEGIN TRY
        BEGIN TRANSACTION;
        INSERT INTO Materia (claveMateria, nombre)
        VALUES (@claveMateria, @nombre);
        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[sp_InsertarProfesor]    Script Date: 14/05/2023 22:16:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_InsertarProfesor] (
    @claveProfesor VARCHAR(3),
    @nombreProfesor VARCHAR(50),
    @apellidoPaterno VARCHAR(30),
    @apellidoMaterno VARCHAR(30),
    @correoLaboral VARCHAR(200),
    @telefonoProfesor VARCHAR(10)
)
AS
BEGIN

    BEGIN TRY
        BEGIN TRANSACTION

        -- Insertar en la tabla Profesor
        INSERT INTO Profesor (
            claveProfesor,
            nombreProfesor,
            apellidoPaterno,
            apellidoMaterno,
            correoLaboral,
            telefonoProfesor
        )
        VALUES (
            @claveProfesor,
            @nombreProfesor,
            @apellidoPaterno,
            @apellidoMaterno,
            @correoLaboral,
            @telefonoProfesor
        )

        COMMIT TRANSACTION
    END TRY
    BEGIN CATCH
       ROLLBACK TRANSACTION
        THROW
    END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[sp_InsertarSecretario]    Script Date: 14/05/2023 22:16:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_InsertarSecretario]
(
    @nombre VARCHAR(30),
    @apellidoPaterno VARCHAR(30),
    @apellidoMaterno VARCHAR(30),
    @claveAcceso VARCHAR(10),
    @matricula VARCHAR(6)
)
AS
BEGIN
    
    BEGIN TRY
        BEGIN TRANSACTION

        INSERT INTO Secretario(nombre, apellidoPaterno, apellidoMaterno, claveAcceso, matricula)
        VALUES (@nombre, @apellidoPaterno, @apellidoMaterno, @claveAcceso, @matricula)

        COMMIT TRANSACTION
    END TRY
    BEGIN CATCH
        
            ROLLBACK TRANSACTION

        THROW;
    END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[sp_ModificarAlumno]    Script Date: 14/05/2023 22:16:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_ModificarAlumno]
(
    @matricula VARCHAR(6),
    @nombreAlumno VARCHAR(50),
    @apellidoPaterno VARCHAR(30),
    @apellidoMaterno VARCHAR(30),
    @sexo CHAR(1),
    @CURP VARCHAR(18),
    @telefono VARCHAR(10),
    @estadoAlumno VARCHAR(10),
    @fechaEntrada DATE,
    @gradoActual SMALLINT
)
AS
BEGIN TRY
    BEGIN TRANSACTION

    UPDATE Alumno
    SET nombreAlumno = @nombreAlumno,
        apellidoPaterno = @apellidoPaterno,
        apellidoMaterno = @apellidoMaterno,
        sexo = @sexo,
        CURP = @CURP,
        telefono = @telefono,
        estadoAlumno = @estadoAlumno,
        fechaEntrada = @fechaEntrada,
        gradoActual = @gradoActual
    WHERE matricula = @matricula

    COMMIT TRANSACTION
END TRY
BEGIN CATCH
    ROLLBACK TRANSACTION
END CATCH
GO
/****** Object:  StoredProcedure [dbo].[sp_ModificarDatosAcademicos]    Script Date: 14/05/2023 22:16:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_ModificarDatosAcademicos] 
    @idRegistro INT,
    @matricula VARCHAR(6),
    @claveProfesor VARCHAR(3),
    @grado SMALLINT,
    @claveMateria VARCHAR(3),
    @calificacionFINAL DECIMAL(2,1)
  
AS
BEGIN

    
    BEGIN TRY
        BEGIN TRANSACTION;
        
        UPDATE DatosAcademicos
        SET matricula = @matricula,
            claveProfesor = @claveProfesor,
            grado = @grado,
            claveMateria = @claveMateria,
            calificacionFINAL = @calificacionFinal
            
        WHERE idRegistro = @idRegistro;
        
        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
      
            ROLLBACK TRANSACTION;
        
        THROW;
    END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[sp_ModificarMateria]    Script Date: 14/05/2023 22:16:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_ModificarMateria]
(
    @claveMateria VARCHAR(3),
    @nombre VARCHAR(20)
)
AS
BEGIN TRY
    BEGIN TRANSACTION

    UPDATE Materia
    SET nombre = @nombre
    WHERE claveMateria = @claveMateria

    COMMIT TRANSACTION
END TRY
BEGIN CATCH
    ROLLBACK TRANSACTION
END CATCH
GO
/****** Object:  StoredProcedure [dbo].[sp_ModificarProfesor]    Script Date: 14/05/2023 22:16:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_ModificarProfesor]
(
    @claveProfesor VARCHAR(3),
    @nombreProfesor VARCHAR(50),
    @apellidoPaterno VARCHAR(30),
    @apellidoMaterno VARCHAR(30),
    @correoLaboral VARCHAR(200),
    @telefonoProfesor VARCHAR(10)
)
AS
BEGIN TRY
    BEGIN TRANSACTION

    UPDATE Profesor
    SET nombreProfesor = @nombreProfesor,
        apellidoPaterno = @apellidoPaterno,
        apellidoMaterno = @apellidoMaterno,
        correoLaboral = @correoLaboral,
        telefonoProfesor = @telefonoProfesor
    WHERE claveProfesor = @claveProfesor
	
    COMMIT TRANSACTION
END TRY
BEGIN CATCH
    ROLLBACK TRANSACTION
END CATCH
GO
/****** Object:  StoredProcedure [dbo].[sp_ModificarSecretario]    Script Date: 14/05/2023 22:16:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_ModificarSecretario]
(
    @nombre VARCHAR(30),
    @apellidoPaterno VARCHAR(30),
    @apellidoMaterno VARCHAR(30),
    @claveAcceso VARCHAR(10),
    @matricula VARCHAR(6)
)
AS
BEGIN TRY
    BEGIN TRANSACTION

    UPDATE Secretario
    SET nombre = @nombre,
        apellidoPaterno = @apellidoPaterno,
        apellidoMaterno = @apellidoMaterno,
        claveAcceso = @claveAcceso
    WHERE matricula = @matricula

    COMMIT TRANSACTION
END TRY
BEGIN CATCH
    ROLLBACK TRANSACTION
END CATCH
GO
USE [master]
GO
ALTER DATABASE [VILLAEJEMPLO] SET  READ_WRITE 
GO
