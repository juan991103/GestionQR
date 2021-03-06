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
CREATE TABLE [dbo].[Departamentos](
	[id] [int] NOT NULL primary key identity (1,1),
	[Nombre_departamento] varchar(50) not NULL,
	[tipo_departamento] [bigint] not NULL,
	[Estado_Departamento] int not NULL FOREIGN KEY REFERENCES Estado(ID)
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
CREATE TABLE [dbo].[Reclamos](
	[Id] [int] NOT NULL primary key identity (1,1),
	[Tipo_Producto] [nchar](50) not NULL,
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
	[Descripcion] [nchar](100) not NULL
) ON [PRIMARY]
GO
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
CREATE TABLE [dbo].[Clientes](
	[Id] [int] NOT NULL primary key identity (1,1),
	[Nombres_Cliente] [varchar](50) not NULL,
	[Apellidos_Cliente] [varchar](50) not NULL,
	[Teléfono] [varchar](45) not NULL,
	[Direccion] [varchar](50) not NULL,
	[Provincia] [varchar](50) not NULL,
	[Sector] [varchar](50) not null,
	[Email] [varchar](50) not null,
	Estado int not NULL FOREIGN KEY REFERENCES Estado(ID)
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Quejas](
	[Id] [int] NOT NULL primary key identity (1,1),
	[Nombre_Cliente] [int] NOT NULL FOREIGN KEY REFERENCES Clientes(ID),
	[Tipo_Quejas] int not NULL FOREIGN KEY REFERENCES Tipo_quejas(ID),
	[Tipo_Producto] int not NULL FOREIGN KEY REFERENCES Producto(ID),
	[Departamento_a_Queja] int not NULL FOREIGN KEY REFERENCES Departamentos(ID),
	[Usuario_Quejas_Atendido] int not null,
	[Fecha_Queja] [date] NOT NULL,
	[Hora_Queja] [time] NOT NULL,
	[Departamento_Respuesta] [varchar](150) NULL,
	[Fecha_Respuesta] [datetime] NULL,
	[Estado_Quejas] int not NULL FOREIGN KEY REFERENCES Estado(ID),
	[Comentarios_Queja] [varchar] (200) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Reclamaciones]    Script Date: 2/10/2022 3:09:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Reclamaciones](
	[Id] [int] NOT NULL primary key identity (1,1),
	[Nombre_Cliente] [int] NOT NULL FOREIGN KEY REFERENCES Clientes(ID),
	[Tipo_Reclamacion] int not NULL FOREIGN KEY REFERENCES Tipo_reclamacion(ID),
	[Tipo_Producto] int not NULL FOREIGN KEY REFERENCES Producto(ID),
	[Departamento_a_Reclamacion] int not NULL FOREIGN KEY REFERENCES Departamentos(ID),
	[Usuario_Reclamo_Atendido] int not null ,
	[Fecha_Reclamacion] [date] NOT NULL, 
	[Hora_Reclamacion] [time] NOT NULL,
	[Departamento_Respuesta] [varchar](50) NULL,
	[Fecha_Respuesta] [datetime] NULL,
	Estado_Reclamacion int not NULL FOREIGN KEY REFERENCES Estado(ID),
	[Comentarios_Reclamaciones] [varchar] (200) NOT NULL
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
	Id int NOT NULL primary key identity (1,1),
	[Usuario_quejas] varchar(50) not NULL,
	[Clave] varchar(100) not NULL,
	Departamento int not NULL FOREIGN KEY REFERENCES Departamentos(ID),
	[Rol] int not NULL FOREIGN KEY REFERENCES Rol(ID),
	[Puesto] int not NULL FOREIGN KEY REFERENCES Puesto(ID)
)
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuarios_reclamaciones](
	Id int NOT NULL primary key identity (1,1),
	[Usuario_reclamo] varchar(50) not NULL,
	[Clave] varchar(100) not NULL,
	Departamento int not NULL FOREIGN KEY REFERENCES Departamentos(ID),
	[Rol] int not NULL FOREIGN KEY REFERENCES Rol(ID),
	[Puesto] int not NULL FOREIGN KEY REFERENCES Puesto(ID),
)
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER TABLE Quejas
ADD FOREIGN KEY (Usuario_Quejas_Atendido) REFERENCES Usuarios_quejas(Id);

ALTER TABLE Reclamaciones
ADD FOREIGN KEY (Usuario_Reclamo_Atendido) REFERENCES Usuarios_reclamaciones(ID);

/*--------------------------------------------------*/

CREATE TABLE [dbo].[Estado2](
	[Id] [int] NOT NULL primary key identity (1,1),
	[Descripcion] varchar(50) not null
) ON [PRIMARY]
GO

CREATE TABLE EncuestaSatisfaccion1(
	Id int not null primary key identity (1,1),
	Pregunta1 int not null foreign key references Estado2(Id),
	Pregunta2 int not null foreign key references Estado2(Id),
	Pregunta3 int not null foreign key references Estado2(Id),
	Pregunta4 int not null foreign key references Estado2(Id),
	Pregunta5 int not null foreign key references Estado2(Id),
	Pregunta6 int not null foreign key references Estado2(Id),
	Cliente int not null foreign key references Clientes(Id)
)