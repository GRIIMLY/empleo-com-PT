USE [EmpleadoCom]
GO
/****** Object:  User [AdminUsuario]    Script Date: 10/7/2024 20:21:52 ******/
CREATE USER [AdminUsuario] FOR LOGIN [AdminUsuario] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  User [EmpleadoComUser]    Script Date: 10/7/2024 20:21:52 ******/
CREATE USER [EmpleadoComUser] FOR LOGIN [EmpleadoComUser] WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_owner] ADD MEMBER [AdminUsuario]
GO
ALTER ROLE [db_owner] ADD MEMBER [EmpleadoComUser]
GO
/****** Object:  Table [dbo].[Demandantes]    Script Date: 10/7/2024 20:21:52 ******/
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
/****** Object:  Table [dbo].[DescripcionesTrabajo]    Script Date: 10/7/2024 20:21:52 ******/
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
/****** Object:  Table [dbo].[Emparejamientos]    Script Date: 10/7/2024 20:21:52 ******/
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
/****** Object:  Table [dbo].[Empleadores]    Script Date: 10/7/2024 20:21:52 ******/
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
/****** Object:  Table [dbo].[Habilidad]    Script Date: 10/7/2024 20:21:52 ******/
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
/****** Object:  Table [dbo].[HabilidadUsuarioTrabajo]    Script Date: 10/7/2024 20:21:52 ******/
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
/****** Object:  Table [dbo].[Usuarios]    Script Date: 10/7/2024 20:21:52 ******/
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
