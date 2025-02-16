USE [master]
GO
/****** Object:  Database [EmpleadoCom]    Script Date: 10/7/2024 20:44:42 ******/
CREATE DATABASE [EmpleadoCom]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'EmpleadoCom', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS01\MSSQL\DATA\EmpleadoCom.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'EmpleadoCom_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS01\MSSQL\DATA\EmpleadoCom_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [EmpleadoCom] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [EmpleadoCom].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [EmpleadoCom] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [EmpleadoCom] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [EmpleadoCom] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [EmpleadoCom] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [EmpleadoCom] SET ARITHABORT OFF 
GO
ALTER DATABASE [EmpleadoCom] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [EmpleadoCom] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [EmpleadoCom] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [EmpleadoCom] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [EmpleadoCom] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [EmpleadoCom] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [EmpleadoCom] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [EmpleadoCom] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [EmpleadoCom] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [EmpleadoCom] SET  ENABLE_BROKER 
GO
ALTER DATABASE [EmpleadoCom] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [EmpleadoCom] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [EmpleadoCom] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [EmpleadoCom] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [EmpleadoCom] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [EmpleadoCom] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [EmpleadoCom] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [EmpleadoCom] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [EmpleadoCom] SET  MULTI_USER 
GO
ALTER DATABASE [EmpleadoCom] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [EmpleadoCom] SET DB_CHAINING OFF 
GO
ALTER DATABASE [EmpleadoCom] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [EmpleadoCom] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [EmpleadoCom] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [EmpleadoCom] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [EmpleadoCom] SET QUERY_STORE = OFF
GO
USE [EmpleadoCom]
GO
/****** Object:  User [EmpleadoComUser]    Script Date: 10/7/2024 20:44:42 ******/
CREATE USER [EmpleadoComUser] FOR LOGIN [EmpleadoComUser] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  User [AdminUsuario]    Script Date: 10/7/2024 20:44:42 ******/
CREATE USER [AdminUsuario] FOR LOGIN [AdminUsuario] WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_owner] ADD MEMBER [EmpleadoComUser]
GO
ALTER ROLE [db_owner] ADD MEMBER [AdminUsuario]
GO
/****** Object:  Table [dbo].[Demandantes]    Script Date: 10/7/2024 20:44:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Demandantes](
	[DemandanteID] [int] NOT NULL,
	[Nombre] [nvarchar](100) NOT NULL,
	[Edad] [int] NULL,
	[Contacto] [nvarchar](100) NULL,
	[NivelEducacion] [nvarchar](50) NULL,
	[Notas] [nvarchar](500) NULL,
	[ExperienciaLaboral] [nvarchar](500) NULL,
PRIMARY KEY CLUSTERED 
(
	[DemandanteID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DescripcionesTrabajo]    Script Date: 10/7/2024 20:44:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DescripcionesTrabajo](
	[TrabajoID] [int] IDENTITY(1,1) NOT NULL,
	[EmpleadorID] [int] NOT NULL,
	[Titulo] [nvarchar](100) NOT NULL,
	[Descripcion] [nvarchar](500) NULL,
	[Requisitos] [nvarchar](500) NULL,
	[FechaPublicacion] [date] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[TrabajoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Emparejamientos]    Script Date: 10/7/2024 20:44:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Emparejamientos](
	[EmparejamientoID] [int] IDENTITY(1,1) NOT NULL,
	[DemandanteID] [int] NOT NULL,
	[TrabajoID] [int] NOT NULL,
	[FechaEmparejamiento] [date] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[EmparejamientoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Empleadores]    Script Date: 10/7/2024 20:44:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Empleadores](
	[EmpleadorID] [int] NOT NULL,
	[NombreEmpresa] [nvarchar](100) NOT NULL,
	[Localizacion] [nvarchar](100) NULL,
	[Industria] [nvarchar](50) NULL,
	[NumeroEmpleados] [int] NULL,
	[Vacantes] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[EmpleadorID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Habilidad]    Script Date: 10/7/2024 20:44:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Habilidad](
	[HabilidadID] [int] NOT NULL,
	[NombreHabilidad] [nvarchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[HabilidadID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HabilidadUsuarioTrabajo]    Script Date: 10/7/2024 20:44:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HabilidadUsuarioTrabajo](
	[HabilidadUsuarioID] [int] IDENTITY(1,1) NOT NULL,
	[UsuarioID] [int] NULL,
	[HabilidadID] [int] NOT NULL,
	[TrabajoID] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[HabilidadUsuarioID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuarios]    Script Date: 10/7/2024 20:44:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuarios](
	[UsuarioID] [int] IDENTITY(1,1) NOT NULL,
	[NombreUsuario] [nvarchar](50) NOT NULL,
	[Contrasenia] [nvarchar](100) NOT NULL,
	[TipoUsuario] [nvarchar](10) NOT NULL,
 CONSTRAINT [PK__Usuarios__2B3DE79856C7FF79] PRIMARY KEY CLUSTERED 
(
	[UsuarioID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Demandantes] ([DemandanteID], [Nombre], [Edad], [Contacto], [NivelEducacion], [Notas], [ExperienciaLaboral]) VALUES (1, N'Nicolas', 21, N'324', N'Profesional', N'sdasd', N'asd')
INSERT [dbo].[Demandantes] ([DemandanteID], [Nombre], [Edad], [Contacto], [NivelEducacion], [Notas], [ExperienciaLaboral]) VALUES (11, N'Nicolas Morales G', 273, N'nicolas@ejemplo.com', N'Profesional', N'...', N'...')
INSERT [dbo].[Demandantes] ([DemandanteID], [Nombre], [Edad], [Contacto], [NivelEducacion], [Notas], [ExperienciaLaboral]) VALUES (12, N'Nicolas Morales Galindo', 24, N'nicolas@ejemplo.com', N'Profesional', N'...', N'...')
GO
SET IDENTITY_INSERT [dbo].[DescripcionesTrabajo] ON 

INSERT [dbo].[DescripcionesTrabajo] ([TrabajoID], [EmpleadorID], [Titulo], [Descripcion], [Requisitos], [FechaPublicacion]) VALUES (2, 1, N'Net Developer', N'....', N'...', CAST(N'2023-01-01' AS Date))
INSERT [dbo].[DescripcionesTrabajo] ([TrabajoID], [EmpleadorID], [Titulo], [Descripcion], [Requisitos], [FechaPublicacion]) VALUES (3, 1, N'Desarrollador de Software 1', N'Descripción del puesto de desarrollador de software 1', N'Requisitos para el puesto de desarrollador de software 1', CAST(N'2024-07-10' AS Date))
INSERT [dbo].[DescripcionesTrabajo] ([TrabajoID], [EmpleadorID], [Titulo], [Descripcion], [Requisitos], [FechaPublicacion]) VALUES (4, 2, N'Desarrollador de Software 2', N'Descripción del puesto de desarrollador de software 2', N'Requisitos para el puesto de desarrollador de software 2', CAST(N'2024-07-10' AS Date))
INSERT [dbo].[DescripcionesTrabajo] ([TrabajoID], [EmpleadorID], [Titulo], [Descripcion], [Requisitos], [FechaPublicacion]) VALUES (5, 3, N'Desarrollador de Software 3', N'Descripción del puesto de desarrollador de software 3', N'Requisitos para el puesto de desarrollador de software 3', CAST(N'2024-07-10' AS Date))
INSERT [dbo].[DescripcionesTrabajo] ([TrabajoID], [EmpleadorID], [Titulo], [Descripcion], [Requisitos], [FechaPublicacion]) VALUES (6, 4, N'Desarrollador de Software 4', N'Descripción del puesto de desarrollador de software 4', N'Requisitos para el puesto de desarrollador de software 4', CAST(N'2024-07-10' AS Date))
INSERT [dbo].[DescripcionesTrabajo] ([TrabajoID], [EmpleadorID], [Titulo], [Descripcion], [Requisitos], [FechaPublicacion]) VALUES (7, 5, N'Desarrollador de Software 5', N'Descripción del puesto de desarrollador de software 5', N'Requisitos para el puesto de desarrollador de software 5', CAST(N'2024-07-10' AS Date))
INSERT [dbo].[DescripcionesTrabajo] ([TrabajoID], [EmpleadorID], [Titulo], [Descripcion], [Requisitos], [FechaPublicacion]) VALUES (8, 6, N'Desarrollador de Software 6', N'Descripción del puesto de desarrollador de software 6', N'Requisitos para el puesto de desarrollador de software 6', CAST(N'2024-07-10' AS Date))
INSERT [dbo].[DescripcionesTrabajo] ([TrabajoID], [EmpleadorID], [Titulo], [Descripcion], [Requisitos], [FechaPublicacion]) VALUES (9, 7, N'Desarrollador de Software 7', N'Descripción del puesto de desarrollador de software 7', N'Requisitos para el puesto de desarrollador de software 7', CAST(N'2024-07-10' AS Date))
INSERT [dbo].[DescripcionesTrabajo] ([TrabajoID], [EmpleadorID], [Titulo], [Descripcion], [Requisitos], [FechaPublicacion]) VALUES (10, 8, N'Desarrollador de Software 8', N'Descripción del puesto de desarrollador de software 8', N'Requisitos para el puesto de desarrollador de software 8', CAST(N'2024-07-10' AS Date))
INSERT [dbo].[DescripcionesTrabajo] ([TrabajoID], [EmpleadorID], [Titulo], [Descripcion], [Requisitos], [FechaPublicacion]) VALUES (11, 9, N'Desarrollador de Software 9', N'Descripción del puesto de desarrollador de software 9', N'Requisitos para el puesto de desarrollador de software 9', CAST(N'2024-07-10' AS Date))
INSERT [dbo].[DescripcionesTrabajo] ([TrabajoID], [EmpleadorID], [Titulo], [Descripcion], [Requisitos], [FechaPublicacion]) VALUES (12, 10, N'Desarrollador de Software 10', N'Descripción del puesto de desarrollador de software 10', N'Requisitos para el puesto de desarrollador de software 10', CAST(N'2024-07-10' AS Date))
INSERT [dbo].[DescripcionesTrabajo] ([TrabajoID], [EmpleadorID], [Titulo], [Descripcion], [Requisitos], [FechaPublicacion]) VALUES (13, 11, N'Desarrollador de Software 11', N'Descripción del puesto de desarrollador de software 11', N'Requisitos para el puesto de desarrollador de software 11', CAST(N'2024-07-10' AS Date))
SET IDENTITY_INSERT [dbo].[DescripcionesTrabajo] OFF
GO
INSERT [dbo].[Empleadores] ([EmpleadorID], [NombreEmpresa], [Localizacion], [Industria], [NumeroEmpleados], [Vacantes]) VALUES (1, N'Prueba', N'Bogota', N'Software', 200, 2)
INSERT [dbo].[Empleadores] ([EmpleadorID], [NombreEmpresa], [Localizacion], [Industria], [NumeroEmpleados], [Vacantes]) VALUES (2, N'Empresa IT Solutions', N'Ciudad A', N'Tecnologías de la Información', 100, 5)
INSERT [dbo].[Empleadores] ([EmpleadorID], [NombreEmpresa], [Localizacion], [Industria], [NumeroEmpleados], [Vacantes]) VALUES (3, N'Tech Innovations', N'Ciudad B', N'Tecnologías de la Información', 200, 8)
INSERT [dbo].[Empleadores] ([EmpleadorID], [NombreEmpresa], [Localizacion], [Industria], [NumeroEmpleados], [Vacantes]) VALUES (4, N'SoftTech Labs', N'Ciudad C', N'Tecnologías de la Información', 150, 6)
INSERT [dbo].[Empleadores] ([EmpleadorID], [NombreEmpresa], [Localizacion], [Industria], [NumeroEmpleados], [Vacantes]) VALUES (5, N'Code Masters', N'Ciudad D', N'Tecnologías de la Información', 180, 7)
INSERT [dbo].[Empleadores] ([EmpleadorID], [NombreEmpresa], [Localizacion], [Industria], [NumeroEmpleados], [Vacantes]) VALUES (6, N'Digital Solutions', N'Ciudad E', N'Tecnologías de la Información', 120, 4)
INSERT [dbo].[Empleadores] ([EmpleadorID], [NombreEmpresa], [Localizacion], [Industria], [NumeroEmpleados], [Vacantes]) VALUES (7, N'IT Connect', N'Ciudad F', N'Tecnologías de la Información', 90, 3)
INSERT [dbo].[Empleadores] ([EmpleadorID], [NombreEmpresa], [Localizacion], [Industria], [NumeroEmpleados], [Vacantes]) VALUES (8, N'Tech Visionaries', N'Ciudad G', N'Tecnologías de la Información', 210, 9)
INSERT [dbo].[Empleadores] ([EmpleadorID], [NombreEmpresa], [Localizacion], [Industria], [NumeroEmpleados], [Vacantes]) VALUES (9, N'InnoTech Solutions', N'Ciudad H', N'Tecnologías de la Información', 140, 5)
INSERT [dbo].[Empleadores] ([EmpleadorID], [NombreEmpresa], [Localizacion], [Industria], [NumeroEmpleados], [Vacantes]) VALUES (10, N'Byte Builders', N'Ciudad I', N'Tecnologías de la Información', 160, 7)
INSERT [dbo].[Empleadores] ([EmpleadorID], [NombreEmpresa], [Localizacion], [Industria], [NumeroEmpleados], [Vacantes]) VALUES (11, N'IT Experts', N'Ciudad J', N'Tecnologías de la Información', 230, 10)
GO
INSERT [dbo].[Habilidad] ([HabilidadID], [NombreHabilidad]) VALUES (1, N'Java')
INSERT [dbo].[Habilidad] ([HabilidadID], [NombreHabilidad]) VALUES (2, N'C#')
INSERT [dbo].[Habilidad] ([HabilidadID], [NombreHabilidad]) VALUES (3, N'Angular')
INSERT [dbo].[Habilidad] ([HabilidadID], [NombreHabilidad]) VALUES (4, N'React JS')
INSERT [dbo].[Habilidad] ([HabilidadID], [NombreHabilidad]) VALUES (5, N'Python')
INSERT [dbo].[Habilidad] ([HabilidadID], [NombreHabilidad]) VALUES (6, N'JavaScript')
INSERT [dbo].[Habilidad] ([HabilidadID], [NombreHabilidad]) VALUES (7, N'Node.js')
INSERT [dbo].[Habilidad] ([HabilidadID], [NombreHabilidad]) VALUES (8, N'SQL')
INSERT [dbo].[Habilidad] ([HabilidadID], [NombreHabilidad]) VALUES (9, N'HTML')
INSERT [dbo].[Habilidad] ([HabilidadID], [NombreHabilidad]) VALUES (10, N'CSS')
INSERT [dbo].[Habilidad] ([HabilidadID], [NombreHabilidad]) VALUES (11, N'TypeScript')
INSERT [dbo].[Habilidad] ([HabilidadID], [NombreHabilidad]) VALUES (12, N'Ruby on Rails')
INSERT [dbo].[Habilidad] ([HabilidadID], [NombreHabilidad]) VALUES (13, N'PHP')
INSERT [dbo].[Habilidad] ([HabilidadID], [NombreHabilidad]) VALUES (14, N'Swift')
INSERT [dbo].[Habilidad] ([HabilidadID], [NombreHabilidad]) VALUES (15, N'Kotlin')
GO
SET IDENTITY_INSERT [dbo].[HabilidadUsuarioTrabajo] ON 

INSERT [dbo].[HabilidadUsuarioTrabajo] ([HabilidadUsuarioID], [UsuarioID], [HabilidadID], [TrabajoID]) VALUES (18, 11, 1, NULL)
INSERT [dbo].[HabilidadUsuarioTrabajo] ([HabilidadUsuarioID], [UsuarioID], [HabilidadID], [TrabajoID]) VALUES (19, 11, 2, NULL)
INSERT [dbo].[HabilidadUsuarioTrabajo] ([HabilidadUsuarioID], [UsuarioID], [HabilidadID], [TrabajoID]) VALUES (20, NULL, 1, 2)
INSERT [dbo].[HabilidadUsuarioTrabajo] ([HabilidadUsuarioID], [UsuarioID], [HabilidadID], [TrabajoID]) VALUES (21, NULL, 6, 3)
INSERT [dbo].[HabilidadUsuarioTrabajo] ([HabilidadUsuarioID], [UsuarioID], [HabilidadID], [TrabajoID]) VALUES (22, NULL, 10, 4)
INSERT [dbo].[HabilidadUsuarioTrabajo] ([HabilidadUsuarioID], [UsuarioID], [HabilidadID], [TrabajoID]) VALUES (23, NULL, 1, 5)
INSERT [dbo].[HabilidadUsuarioTrabajo] ([HabilidadUsuarioID], [UsuarioID], [HabilidadID], [TrabajoID]) VALUES (24, NULL, 1, 6)
INSERT [dbo].[HabilidadUsuarioTrabajo] ([HabilidadUsuarioID], [UsuarioID], [HabilidadID], [TrabajoID]) VALUES (25, NULL, 7, 7)
INSERT [dbo].[HabilidadUsuarioTrabajo] ([HabilidadUsuarioID], [UsuarioID], [HabilidadID], [TrabajoID]) VALUES (26, NULL, 6, 8)
INSERT [dbo].[HabilidadUsuarioTrabajo] ([HabilidadUsuarioID], [UsuarioID], [HabilidadID], [TrabajoID]) VALUES (27, NULL, 1, 9)
INSERT [dbo].[HabilidadUsuarioTrabajo] ([HabilidadUsuarioID], [UsuarioID], [HabilidadID], [TrabajoID]) VALUES (28, NULL, 4, 10)
INSERT [dbo].[HabilidadUsuarioTrabajo] ([HabilidadUsuarioID], [UsuarioID], [HabilidadID], [TrabajoID]) VALUES (29, NULL, 1, 11)
INSERT [dbo].[HabilidadUsuarioTrabajo] ([HabilidadUsuarioID], [UsuarioID], [HabilidadID], [TrabajoID]) VALUES (30, NULL, 1, 12)
INSERT [dbo].[HabilidadUsuarioTrabajo] ([HabilidadUsuarioID], [UsuarioID], [HabilidadID], [TrabajoID]) VALUES (31, NULL, 1, 13)
INSERT [dbo].[HabilidadUsuarioTrabajo] ([HabilidadUsuarioID], [UsuarioID], [HabilidadID], [TrabajoID]) VALUES (32, NULL, 8, 2)
INSERT [dbo].[HabilidadUsuarioTrabajo] ([HabilidadUsuarioID], [UsuarioID], [HabilidadID], [TrabajoID]) VALUES (33, NULL, 7, 3)
INSERT [dbo].[HabilidadUsuarioTrabajo] ([HabilidadUsuarioID], [UsuarioID], [HabilidadID], [TrabajoID]) VALUES (34, NULL, 12, 4)
INSERT [dbo].[HabilidadUsuarioTrabajo] ([HabilidadUsuarioID], [UsuarioID], [HabilidadID], [TrabajoID]) VALUES (35, NULL, 4, 5)
INSERT [dbo].[HabilidadUsuarioTrabajo] ([HabilidadUsuarioID], [UsuarioID], [HabilidadID], [TrabajoID]) VALUES (36, NULL, 4, 6)
INSERT [dbo].[HabilidadUsuarioTrabajo] ([HabilidadUsuarioID], [UsuarioID], [HabilidadID], [TrabajoID]) VALUES (37, NULL, 4, 7)
INSERT [dbo].[HabilidadUsuarioTrabajo] ([HabilidadUsuarioID], [UsuarioID], [HabilidadID], [TrabajoID]) VALUES (38, NULL, 5, 8)
INSERT [dbo].[HabilidadUsuarioTrabajo] ([HabilidadUsuarioID], [UsuarioID], [HabilidadID], [TrabajoID]) VALUES (39, NULL, 5, 9)
INSERT [dbo].[HabilidadUsuarioTrabajo] ([HabilidadUsuarioID], [UsuarioID], [HabilidadID], [TrabajoID]) VALUES (40, NULL, 6, 10)
INSERT [dbo].[HabilidadUsuarioTrabajo] ([HabilidadUsuarioID], [UsuarioID], [HabilidadID], [TrabajoID]) VALUES (41, NULL, 10, 11)
INSERT [dbo].[HabilidadUsuarioTrabajo] ([HabilidadUsuarioID], [UsuarioID], [HabilidadID], [TrabajoID]) VALUES (42, NULL, 2, 12)
INSERT [dbo].[HabilidadUsuarioTrabajo] ([HabilidadUsuarioID], [UsuarioID], [HabilidadID], [TrabajoID]) VALUES (43, NULL, 2, 13)
INSERT [dbo].[HabilidadUsuarioTrabajo] ([HabilidadUsuarioID], [UsuarioID], [HabilidadID], [TrabajoID]) VALUES (44, NULL, 4, 2)
INSERT [dbo].[HabilidadUsuarioTrabajo] ([HabilidadUsuarioID], [UsuarioID], [HabilidadID], [TrabajoID]) VALUES (45, NULL, 8, 3)
INSERT [dbo].[HabilidadUsuarioTrabajo] ([HabilidadUsuarioID], [UsuarioID], [HabilidadID], [TrabajoID]) VALUES (46, NULL, 11, 4)
INSERT [dbo].[HabilidadUsuarioTrabajo] ([HabilidadUsuarioID], [UsuarioID], [HabilidadID], [TrabajoID]) VALUES (47, NULL, 3, 5)
INSERT [dbo].[HabilidadUsuarioTrabajo] ([HabilidadUsuarioID], [UsuarioID], [HabilidadID], [TrabajoID]) VALUES (48, NULL, 3, 6)
INSERT [dbo].[HabilidadUsuarioTrabajo] ([HabilidadUsuarioID], [UsuarioID], [HabilidadID], [TrabajoID]) VALUES (49, NULL, 15, 7)
INSERT [dbo].[HabilidadUsuarioTrabajo] ([HabilidadUsuarioID], [UsuarioID], [HabilidadID], [TrabajoID]) VALUES (50, NULL, 3, 8)
INSERT [dbo].[HabilidadUsuarioTrabajo] ([HabilidadUsuarioID], [UsuarioID], [HabilidadID], [TrabajoID]) VALUES (51, NULL, 3, 9)
INSERT [dbo].[HabilidadUsuarioTrabajo] ([HabilidadUsuarioID], [UsuarioID], [HabilidadID], [TrabajoID]) VALUES (52, NULL, 7, 10)
INSERT [dbo].[HabilidadUsuarioTrabajo] ([HabilidadUsuarioID], [UsuarioID], [HabilidadID], [TrabajoID]) VALUES (53, NULL, 10, 11)
INSERT [dbo].[HabilidadUsuarioTrabajo] ([HabilidadUsuarioID], [UsuarioID], [HabilidadID], [TrabajoID]) VALUES (54, NULL, 12, 12)
INSERT [dbo].[HabilidadUsuarioTrabajo] ([HabilidadUsuarioID], [UsuarioID], [HabilidadID], [TrabajoID]) VALUES (55, NULL, 11, 13)
INSERT [dbo].[HabilidadUsuarioTrabajo] ([HabilidadUsuarioID], [UsuarioID], [HabilidadID], [TrabajoID]) VALUES (59, 12, 1, NULL)
INSERT [dbo].[HabilidadUsuarioTrabajo] ([HabilidadUsuarioID], [UsuarioID], [HabilidadID], [TrabajoID]) VALUES (60, 12, 2, NULL)
INSERT [dbo].[HabilidadUsuarioTrabajo] ([HabilidadUsuarioID], [UsuarioID], [HabilidadID], [TrabajoID]) VALUES (61, 12, 4, NULL)
INSERT [dbo].[HabilidadUsuarioTrabajo] ([HabilidadUsuarioID], [UsuarioID], [HabilidadID], [TrabajoID]) VALUES (62, 12, 15, NULL)
SET IDENTITY_INSERT [dbo].[HabilidadUsuarioTrabajo] OFF
GO
SET IDENTITY_INSERT [dbo].[Usuarios] ON 

INSERT [dbo].[Usuarios] ([UsuarioID], [NombreUsuario], [Contrasenia], [TipoUsuario]) VALUES (1, N'Nicolas', N'12345*', N'Empleador')
INSERT [dbo].[Usuarios] ([UsuarioID], [NombreUsuario], [Contrasenia], [TipoUsuario]) VALUES (2, N'NicolasSS', N'12312312312', N'Empleador')
INSERT [dbo].[Usuarios] ([UsuarioID], [NombreUsuario], [Contrasenia], [TipoUsuario]) VALUES (3, N'weqrqwer', N'qwer', N'Empleador')
INSERT [dbo].[Usuarios] ([UsuarioID], [NombreUsuario], [Contrasenia], [TipoUsuario]) VALUES (4, N'NicolasSS', N'qweqweeqwe', N'Demandante')
INSERT [dbo].[Usuarios] ([UsuarioID], [NombreUsuario], [Contrasenia], [TipoUsuario]) VALUES (5, N'qeqweqw', N'eqweqwe', N'Empleador')
INSERT [dbo].[Usuarios] ([UsuarioID], [NombreUsuario], [Contrasenia], [TipoUsuario]) VALUES (6, N'qweqwe', N'qweqwe', N'Empleador')
INSERT [dbo].[Usuarios] ([UsuarioID], [NombreUsuario], [Contrasenia], [TipoUsuario]) VALUES (7, N'qwewe', N'dddqd', N'Empleador')
INSERT [dbo].[Usuarios] ([UsuarioID], [NombreUsuario], [Contrasenia], [TipoUsuario]) VALUES (8, N'123123', N'3123123', N'Empleador')
INSERT [dbo].[Usuarios] ([UsuarioID], [NombreUsuario], [Contrasenia], [TipoUsuario]) VALUES (9, N'asdasdfas', N'2|13123asfdasf', N'Empleador')
INSERT [dbo].[Usuarios] ([UsuarioID], [NombreUsuario], [Contrasenia], [TipoUsuario]) VALUES (10, N'asascz', N'xzcz', N'Empleador')
INSERT [dbo].[Usuarios] ([UsuarioID], [NombreUsuario], [Contrasenia], [TipoUsuario]) VALUES (11, N'Nicolas123', N'fgQrubkQrCLSMwRzeAc/oA==:3qzMIISv42omLqKnHBex23WGY3Y0bYtyqVEd/GvexWA=', N'Demandante')
INSERT [dbo].[Usuarios] ([UsuarioID], [NombreUsuario], [Contrasenia], [TipoUsuario]) VALUES (12, N'Nicolas1234', N'3o6kdPI2H2pYx6aaitXI7A==:ms9OziG22uElU3wBX4irGlP+iXezK/GAp9/X+l6FqbI=', N'Empleador')
SET IDENTITY_INSERT [dbo].[Usuarios] OFF
GO
ALTER TABLE [dbo].[Demandantes]  WITH CHECK ADD  CONSTRAINT [FK__Demandant__Deman__398D8EEE] FOREIGN KEY([DemandanteID])
REFERENCES [dbo].[Usuarios] ([UsuarioID])
GO
ALTER TABLE [dbo].[Demandantes] CHECK CONSTRAINT [FK__Demandant__Deman__398D8EEE]
GO
ALTER TABLE [dbo].[DescripcionesTrabajo]  WITH CHECK ADD FOREIGN KEY([EmpleadorID])
REFERENCES [dbo].[Empleadores] ([EmpleadorID])
GO
ALTER TABLE [dbo].[Emparejamientos]  WITH CHECK ADD FOREIGN KEY([DemandanteID])
REFERENCES [dbo].[Demandantes] ([DemandanteID])
GO
ALTER TABLE [dbo].[Emparejamientos]  WITH CHECK ADD FOREIGN KEY([TrabajoID])
REFERENCES [dbo].[DescripcionesTrabajo] ([TrabajoID])
GO
ALTER TABLE [dbo].[Empleadores]  WITH CHECK ADD  CONSTRAINT [FK__Empleador__Emple__3C69FB99] FOREIGN KEY([EmpleadorID])
REFERENCES [dbo].[Usuarios] ([UsuarioID])
GO
ALTER TABLE [dbo].[Empleadores] CHECK CONSTRAINT [FK__Empleador__Emple__3C69FB99]
GO
ALTER TABLE [dbo].[HabilidadUsuarioTrabajo]  WITH CHECK ADD FOREIGN KEY([HabilidadID])
REFERENCES [dbo].[Habilidad] ([HabilidadID])
GO
ALTER TABLE [dbo].[HabilidadUsuarioTrabajo]  WITH CHECK ADD FOREIGN KEY([TrabajoID])
REFERENCES [dbo].[DescripcionesTrabajo] ([TrabajoID])
GO
ALTER TABLE [dbo].[HabilidadUsuarioTrabajo]  WITH CHECK ADD FOREIGN KEY([UsuarioID])
REFERENCES [dbo].[Usuarios] ([UsuarioID])
GO
ALTER TABLE [dbo].[Usuarios]  WITH CHECK ADD  CONSTRAINT [CK__Usuarios__TipoUs__36B12243] CHECK  (([TipoUsuario]='Demandante' OR [TipoUsuario]='Empleador'))
GO
ALTER TABLE [dbo].[Usuarios] CHECK CONSTRAINT [CK__Usuarios__TipoUs__36B12243]
GO
USE [master]
GO
ALTER DATABASE [EmpleadoCom] SET  READ_WRITE 
GO
