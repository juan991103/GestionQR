CREATE DATABASE [GestionQR]
USE [GestionQR]
GO

CREATE TABLE [dbo].[Estado](
	[Id] [int] NOT NULL primary key identity (1,1),
	[Descripcion] varchar(50) not null
) ON [PRIMARY]
GO
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
	Estado int not NULL FOREIGN KEY REFERENCES Estado(ID)
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
	[encargado_departamento] varchar(50) not NULL
) ON [PRIMARY]
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
CREATE TABLE [dbo].[Producto](
	[Id] [int] NOT NULL primary key identity (1,1),
	[Tipo_Producto] [nchar](50) not NULL,
	[Fecha_Ortogamiento] [datetime] not NULL,
	Estado_Producto int not NULL FOREIGN KEY REFERENCES Estado(ID)
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
/****** Object:  Table [dbo].[Tipo de quejas]    Script Date: 2/10/2022 3:09:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tipo_quejas](
	[Id] [int] NOT NULL primary key identity (1,1),
	[Descripción] [varchar](50) NOT NULL,
	Estado int not NULL FOREIGN KEY REFERENCES Estado(ID)
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tipo_de_reclamación]    Script Date: 2/10/2022 3:09:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tipo_reclamacion](
	[Id] [int] NOT NULL primary key identity (1,1),
	[Descripción] [varchar](150) NOT NULL,
	Estado int not NULL FOREIGN KEY REFERENCES Estado(ID)
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Quejas](
	[Id] [int] NOT NULL primary key identity (1,1),
	[Id_Cliente] [int] NOT NULL,
	[Usuario_Quejas] [nchar](10) NOT NULL,
	[Tipo_Quejas] int not NULL FOREIGN KEY REFERENCES Tipo_quejas(ID),
	[Departamento_Queja] [nchar](10) NOT NULL,
	[Encargado_Queja] [nchar](10) NOT NULL,
	[Fecha_Queja] [datetime] NOT NULL,
	[Hora_Queja] [datetime] NOT NULL,
	[Departamento_Respuesta] [varchar](150) NOT NULL,
	[Fecha_Respuesta] [datetime] NOT NULL,
	[Estado_Quejas] int not NULL FOREIGN KEY REFERENCES Estado(ID),
	[Comentarios_Queja] [varchar](150) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Reclamaciones]    Script Date: 2/10/2022 3:09:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Reclamaciones](
	[Id] [int] NOT NULL primary key identity (1,1),
	[Cliente] varchar(50) NOT NULL,
	[Usuario_Reclamo] [nchar](10) NOT NULL,
	[Tipo_Reclamacion] int not NULL FOREIGN KEY REFERENCES Tipo_reclamacion(ID),
	[Departamento_Reclamacion] [varchar](50) NOT NULL,
	[Encargado_Reclamacion] [varchar](50) NOT NULL,
	[Fecha_Reclamacion] [datetime] NOT NULL,
	[Hora_Reclamacion] [datetime] NOT NULL,
	[Departamento_Respuesta] [varchar](50) NOT NULL,
	[Fecha_Respuesta] [datetime] NOT NULL,
	Estado_Reclamacion int not NULL FOREIGN KEY REFERENCES Estado(ID),
	[Comentarios_Reclamaciones] [varchar](50) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Rol]    Script Date: 2/10/2022 3:09:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rol](
	[Id] [int] NOT NULL primary key identity (1,1),
	[Descripcion_Rol] [varchar](100) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuarios_de_quejas]    Script Date: 2/10/2022 3:09:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuarios_quejas](
	[Id] [int] NOT NULL primary key identity (1,1),
	[Usuario_quejas] [bigint] not NULL,
	[Clave] int not NULL,
	[Departamento_Queja] int not NULL FOREIGN KEY REFERENCES Departamentos(ID),
	[Fecha_Queja] [datetime] not NULL,
	[Hora_Queja] [datetime] not NULL,
	[Rol] int not NULL FOREIGN KEY REFERENCES Rol(ID),
	[Puesto] int not NULL FOREIGN KEY REFERENCES Puesto(ID),
	[Cliente] int not NULL FOREIGN KEY REFERENCES Clientes(ID),
	[Producto] int not NULL FOREIGN KEY REFERENCES Producto(ID),
	Estado int not NULL FOREIGN KEY REFERENCES Estado(ID)
)
GO
/****** Object:  Table [dbo].[Usuarios_de_reclamaciones]    Script Date: 2/10/2022 3:09:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuarios_reclamaciones](
	[Id] [int] NOT NULL primary key identity (1,1),
	[Usuario_reclamo] [bigint] not NULL,
	[Clave] int not NULL,
	[Departamento_Reclamacion] int not NULL FOREIGN KEY REFERENCES Departamentos(ID),
	[Fecha_Reclamacion] [datetime] not NULL,
	[Hora_Reclamacion] [datetime] not NULL,
	[Rol] int not NULL FOREIGN KEY REFERENCES Rol(ID),
	[Puesto] int not NULL FOREIGN KEY REFERENCES Puesto(ID),
	[Cliente] int not NULL FOREIGN KEY REFERENCES Clientes(ID),
	[Producto] int not NULL FOREIGN KEY REFERENCES Producto(ID),
	Estado int not NULL FOREIGN KEY REFERENCES Estado(ID)
) ON [PRIMARY]
GO