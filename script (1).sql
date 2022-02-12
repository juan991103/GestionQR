CREATE DATABASE [GestionQR]
USE [GestionQR]
GO
/****** Object:  Table [dbo].[Clientes]    Script Date: 2/10/2022 3:09:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Clientes](
	[Id] [int] NOT NULL primary key identity (1,1),
	[Nombres_Cliente] [nchar](10) not NULL,
	[Apellidos_Cliente] [nchar](10) not NULL,
	[Teléfono] [varchar](45) not NULL,
	[Direccion] [varchar](50) not NULL,
	[Provincia] [varchar](20) not NULL,
	[Sector] [varchar](50) not null,
	[Email] [varchar](50) not null,
	Estado bit not null
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Departamentos]    Script Date: 2/10/2022 3:09:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Departamentos](
	[id] [int] NOT NULL primary key identity (1,1),
	[tipo_departamento] [bigint] not NULL,
	[encargado_departamento] [varchar](50) not NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Estatus_de_la_queja]    Script Date: 2/10/2022 3:09:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/****** Object:  Table [dbo].[Estatus_de_la_reclamación]    Script Date: 2/10/2022 3:09:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/****** Object:  Table [dbo].[Identificación]    Script Date: 2/10/2022 3:09:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/****** Object:  Table [dbo].[Producto]    Script Date: 2/10/2022 3:09:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Producto](
	[Id] [int] NOT NULL primary key identity (1,1),
	[Tipo_Producto] [nchar](10) not NULL,
	[Fecha_Ortogamiento] [datetime] not NULL,
	[Estatus_Producto] bit not NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Puesto]    Script Date: 2/10/2022 3:09:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Puesto](
	[Id] [int] NOT NULL primary key identity (1,1),
	[Descripcion] [nchar](100) not NULL,
	[Funciones] [nchar](50) not NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Quejas]    Script Date: 2/10/2022 3:09:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Quejas](
	[Id] [int] NOT NULL primary key identity (1,1),
	[Id_Cliente] [int] NOT NULL,
	[Usuario_Quejas] [nchar](10) NOT NULL,
	[Tipo_Quejas] [nchar](10) NOT NULL,
	[Departamento_Queja] [nchar](10) NOT NULL,
	[Encargado_Queja] [nchar](10) NOT NULL,
	[Fecha_Queja] [datetime] NOT NULL,
	[Hora_Queja] [datetime] NOT NULL,
	[Departamento_Respuesta] [varchar](150) NOT NULL,
	[Fecha_Respuesta] [datetime] NOT NULL,
	[Estatus_Quejas] [nchar](10) NOT NULL,
	[Comentarios_Queja] [varchar](150) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Reclamaciones]    Script Date: 2/10/2022 3:09:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Reclamaciones](
	[Id] [int] NOT NULL identity (1,1),
	[Cliente] varchar(50) NOT NULL,
	[Usuario_Reclamo] [nchar](10) NOT NULL,
	[Tipo_Reclamacion] varchar(50) not NULL,
	[Departamento_Reclamacion] [varchar](50) NOT NULL,
	[Encargado_Reclamacion] [varchar](50) NOT NULL,
	[Fecha_Reclamacion] [datetime] NOT NULL,
	[Hora_Reclamacion] [datetime] NOT NULL,
	[Departamento_Respuesta] [varchar](50) NOT NULL,
	[Fecha_Respuesta] [datetime] NOT NULL,
	[Estatus_Reclamacion] bit not NULL,
	[Comentarios_Reclamaciones] [varchar](50) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Rol]    Script Date: 2/10/2022 3:09:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rol](
	[Id] [int] NOT NULL identity (1,1),
	[Descripcion_Rol] [nchar](100) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tipo de quejas]    Script Date: 2/10/2022 3:09:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tipo de quejas](
	[Id] [int] NOT NULL identity (1,1),
	[Descripción] [varchar](50) NOT NULL,
	Estado bit not null
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tipo_de_reclamación]    Script Date: 2/10/2022 3:09:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tipo_de_reclamación](
	[Id] [int] NOT NULL identity (1,1),
	[Descripción] [varchar](150) NOT NULL,
	Estado bit not null
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuarios_de_quejas]    Script Date: 2/10/2022 3:09:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuarios_de_quejas](
	[Id] [int] NOT NULL identity (1,1),
	[Usuario_quejas] [bigint] not NULL,
	[Clave] int not NULL,
	[Departamento_Queja] [bigint] not NULL,
	[Fecha_Queja] [datetime] not NULL,
	[Hora_Queja] [datetime] not NULL,
	[Rol] varchar(50) not NULL,
	[Puesto] varchar(50) not NULL,
	[Cliente] varchar(50) not NULL,
	[Producto] varchar(50) not NULL,
	Estado bit not null
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuarios_de_reclamaciones]    Script Date: 2/10/2022 3:09:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuarios_de_reclamaciones](
	[Id] [int] NOT NULL identity (1,1),
	[Usuario_reclamo] [bigint] not NULL,
	[Clave] int not NULL,
	[Departamento_Reclamacion] [nchar](50) not NULL,
	[Fecha_Reclamacion] [datetime] not NULL,
	[Hora_Reclamacion] [datetime] not NULL,
	[Rol] varchar(50) not NULL,
	[Puesto] varchar(50) not NULL,
	[Cliente] varchar(50) not NULL,
	[Producto] varchar(50) not NULL,
	Estado bit not null
) ON [PRIMARY]
GO
