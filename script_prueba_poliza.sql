/****** Object:  Database [PruebaPoliza]    Script Date: 4/9/2018 11:16:14 AM ******/
CREATE DATABASE [PruebaPoliza]
GO
USE [PruebaPoliza]
GO
ALTER DATABASE [PruebaPoliza] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [PruebaPoliza].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [PruebaPoliza] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [PruebaPoliza] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [PruebaPoliza] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [PruebaPoliza] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [PruebaPoliza] SET ARITHABORT OFF 
GO
ALTER DATABASE [PruebaPoliza] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [PruebaPoliza] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [PruebaPoliza] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [PruebaPoliza] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [PruebaPoliza] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [PruebaPoliza] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [PruebaPoliza] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [PruebaPoliza] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [PruebaPoliza] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [PruebaPoliza] SET  DISABLE_BROKER 
GO
ALTER DATABASE [PruebaPoliza] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [PruebaPoliza] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [PruebaPoliza] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [PruebaPoliza] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [PruebaPoliza] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [PruebaPoliza] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [PruebaPoliza] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [PruebaPoliza] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [PruebaPoliza] SET  MULTI_USER 
GO
ALTER DATABASE [PruebaPoliza] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [PruebaPoliza] SET DB_CHAINING OFF 
GO
ALTER DATABASE [PruebaPoliza] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [PruebaPoliza] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [PruebaPoliza] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'PruebaPoliza', N'ON'
GO
ALTER DATABASE [PruebaPoliza] SET QUERY_STORE = OFF
GO
USE [PruebaPoliza]
GO
ALTER DATABASE SCOPED CONFIGURATION SET IDENTITY_CACHE = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO
USE [PruebaPoliza]
GO
/****** Object:  Table [dbo].[Cliente]    Script Date: 4/9/2018 11:16:15 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cliente](
	[id_cliente] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [nvarchar](50) NULL,
	[apellido] [nvarchar](50) NULL,
	[correo] [nvarchar](50) NULL,
	[cedula] [nvarchar](50) NULL,
	[genero] [char](1) NULL,
 CONSTRAINT [PK_Cliente] PRIMARY KEY CLUSTERED 
(
	[id_cliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cubrimiento]    Script Date: 4/9/2018 11:16:15 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cubrimiento](
	[cubrimiento] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Cubrimiento] PRIMARY KEY CLUSTERED 
(
	[cubrimiento] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Empleado]    Script Date: 4/9/2018 11:16:15 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Empleado](
	[id_empleado] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [nvarchar](50) NULL,
	[apellido] [nvarchar](50) NULL,
	[correo] [nvarchar](50) NULL,
	[cedula] [nvarchar](50) NULL,
	[username] [nvarchar](50) NULL,
	[password_hash] [nvarchar](max) NULL,
 CONSTRAINT [PK_Empleado] PRIMARY KEY CLUSTERED 
(
	[id_empleado] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Poliza]    Script Date: 4/9/2018 11:16:15 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Poliza](
	[id_poliza] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [nvarchar](50) NULL,
	[descripcion] [nvarchar](150) NULL,
	[periodo] [int] NULL,
	[deducible] [decimal](18, 0) NULL,
	[precio] [decimal](18, 0) NULL,
	[riesgo] [nvarchar](50) NULL,
	[cubrimiento] [nvarchar](50) NULL,
	[inicio_vigencia] [datetime] NULL,
	[id_cliente] [int] NULL,
 CONSTRAINT [PK_Poliza] PRIMARY KEY CLUSTERED 
(
	[id_poliza] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Riesgo]    Script Date: 4/9/2018 11:16:15 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Riesgo](
	[riesgo] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Riesgo] PRIMARY KEY CLUSTERED 
(
	[riesgo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Cliente] ON 
GO
INSERT [dbo].[Cliente] ([id_cliente], [nombre], [apellido], [correo], [cedula], [genero]) VALUES (1, N'Jean', N'Maradiaga', N'jmaradiaga@mail.com', N'161747589', N'M')
GO
INSERT [dbo].[Cliente] ([id_cliente], [nombre], [apellido], [correo], [cedula], [genero]) VALUES (2, N'Wendy', N'Villegas', N'wvilleg@mail.com', N'463895743', N'F')
GO
INSERT [dbo].[Cliente] ([id_cliente], [nombre], [apellido], [correo], [cedula], [genero]) VALUES (3, N'Emilio', N'Sanchez', N'esanchez@mail.com', N'173648495', N'M')
GO
INSERT [dbo].[Cliente] ([id_cliente], [nombre], [apellido], [correo], [cedula], [genero]) VALUES (4, N'Cesar', N'Mora', N'cmora@mail.com', N'127849573', N'M')
GO
SET IDENTITY_INSERT [dbo].[Cliente] OFF
GO
INSERT [dbo].[Cubrimiento] ([cubrimiento]) VALUES (N'Incendio')
GO
INSERT [dbo].[Cubrimiento] ([cubrimiento]) VALUES (N'Perdida')
GO
INSERT [dbo].[Cubrimiento] ([cubrimiento]) VALUES (N'Robo')
GO
INSERT [dbo].[Cubrimiento] ([cubrimiento]) VALUES (N'Terremoto')
GO
INSERT [dbo].[Cubrimiento] ([cubrimiento]) VALUES (N'Tsunami')
GO
SET IDENTITY_INSERT [dbo].[Empleado] ON 
GO
INSERT [dbo].[Empleado] ([id_empleado], [nombre], [apellido], [correo], [cedula], [username], [password_hash]) VALUES (1, N'Karla', N'Maradiaga', N'admin@mail.com', N'1726381', N'admin', N'q1w2e3r4t5y6')
GO
SET IDENTITY_INSERT [dbo].[Empleado] OFF
GO
SET IDENTITY_INSERT [dbo].[Poliza] ON 
GO
INSERT [dbo].[Poliza] ([id_poliza], [nombre], [descripcion], [periodo], [deducible], [precio], [riesgo], [cubrimiento], [inicio_vigencia], [id_cliente]) VALUES (5, N'POL-1910', N'Poliza renovable cada 4 meses', 8, CAST(50 AS Decimal(18, 0)), CAST(10393 AS Decimal(18, 0)), N'Medio-Alto', N'Perdida', CAST(N'2018-10-10T00:00:00.000' AS DateTime), 4)
GO
INSERT [dbo].[Poliza] ([id_poliza], [nombre], [descripcion], [periodo], [deducible], [precio], [riesgo], [cubrimiento], [inicio_vigencia], [id_cliente]) VALUES (6, N'POL-1736', N'Poliza renovada cada 2 meses en primer año', 6, CAST(70 AS Decimal(18, 0)), CAST(17374 AS Decimal(18, 0)), N'Medio', N'Perdida', CAST(N'2018-10-10T00:00:00.000' AS DateTime), 4)
GO
INSERT [dbo].[Poliza] ([id_poliza], [nombre], [descripcion], [periodo], [deducible], [precio], [riesgo], [cubrimiento], [inicio_vigencia], [id_cliente]) VALUES (7, N'POL-1736', N'Poliza de lujo en primer año', 6, CAST(70 AS Decimal(18, 0)), CAST(17374 AS Decimal(18, 0)), N'Medio-Alto', N'Incendio', CAST(N'2018-10-10T00:00:00.000' AS DateTime), 4)
GO
INSERT [dbo].[Poliza] ([id_poliza], [nombre], [descripcion], [periodo], [deducible], [precio], [riesgo], [cubrimiento], [inicio_vigencia], [id_cliente]) VALUES (9, N'Pol-1727', N'Poliza privada', 5, CAST(50 AS Decimal(18, 0)), CAST(10000 AS Decimal(18, 0)), N'Medio', N'Robo', CAST(N'2018-04-07T00:00:00.000' AS DateTime), 3)
GO
INSERT [dbo].[Poliza] ([id_poliza], [nombre], [descripcion], [periodo], [deducible], [precio], [riesgo], [cubrimiento], [inicio_vigencia], [id_cliente]) VALUES (16, N'POL-1736', N'Poliza renovada cada 2 meses en primer año', 6, CAST(70 AS Decimal(18, 0)), CAST(17374 AS Decimal(18, 0)), N'Medio', N'Tsunami', CAST(N'2018-10-10T00:00:00.000' AS DateTime), 4)
GO
INSERT [dbo].[Poliza] ([id_poliza], [nombre], [descripcion], [periodo], [deducible], [precio], [riesgo], [cubrimiento], [inicio_vigencia], [id_cliente]) VALUES (17, N'POL-1736', N'#DankMemes', 6, CAST(70 AS Decimal(18, 0)), CAST(17374 AS Decimal(18, 0)), N'Medio', N'Incendio', CAST(N'2018-10-10T00:00:00.000' AS DateTime), 4)
GO
INSERT [dbo].[Poliza] ([id_poliza], [nombre], [descripcion], [periodo], [deducible], [precio], [riesgo], [cubrimiento], [inicio_vigencia], [id_cliente]) VALUES (28, N'POL-M3M3', N'A titulo de "The dankest.SA"', 10, CAST(50 AS Decimal(18, 0)), CAST(25000 AS Decimal(18, 0)), N'Alto', N'Incendio', CAST(N'2015-12-12T00:00:00.000' AS DateTime), 1)
GO
INSERT [dbo].[Poliza] ([id_poliza], [nombre], [descripcion], [periodo], [deducible], [precio], [riesgo], [cubrimiento], [inicio_vigencia], [id_cliente]) VALUES (29, N'POL-M606', N'Poliza de seguro para gatos.', 12, CAST(40 AS Decimal(18, 0)), CAST(100000 AS Decimal(18, 0)), N'Bajo', N'Perdida', CAST(N'2018-03-10T00:00:00.000' AS DateTime), 1)
GO
INSERT [dbo].[Poliza] ([id_poliza], [nombre], [descripcion], [periodo], [deducible], [precio], [riesgo], [cubrimiento], [inicio_vigencia], [id_cliente]) VALUES (35, N'POL-2412', N'TEST', 12, CAST(12 AS Decimal(18, 0)), CAST(12 AS Decimal(18, 0)), N'Alto', N'Perdida', CAST(N'2019-09-09T00:00:00.000' AS DateTime), 4)
GO
INSERT [dbo].[Poliza] ([id_poliza], [nombre], [descripcion], [periodo], [deducible], [precio], [riesgo], [cubrimiento], [inicio_vigencia], [id_cliente]) VALUES (37, N'POL-0000', N'Poliza de prueba', 12, CAST(100 AS Decimal(18, 0)), CAST(12341 AS Decimal(18, 0)), N'Bajo', N'Incendio', CAST(N'1753-01-01T00:00:00.000' AS DateTime), 2)
GO
INSERT [dbo].[Poliza] ([id_poliza], [nombre], [descripcion], [periodo], [deducible], [precio], [riesgo], [cubrimiento], [inicio_vigencia], [id_cliente]) VALUES (44, N'Pol-7574', N'Prueba de Poliza', 6, CAST(40 AS Decimal(18, 0)), CAST(90 AS Decimal(18, 0)), N'Alto', N'Perdida', CAST(N'1998-11-11T00:00:00.000' AS DateTime), 1)
GO
SET IDENTITY_INSERT [dbo].[Poliza] OFF
GO
INSERT [dbo].[Riesgo] ([riesgo]) VALUES (N'Alto')
GO
INSERT [dbo].[Riesgo] ([riesgo]) VALUES (N'Bajo')
GO
INSERT [dbo].[Riesgo] ([riesgo]) VALUES (N'Medio')
GO
INSERT [dbo].[Riesgo] ([riesgo]) VALUES (N'Medio-Alto')
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UNQ__Cliente__correo]    Script Date: 4/9/2018 11:16:15 AM ******/
ALTER TABLE [dbo].[Cliente] ADD  CONSTRAINT [UNQ__Cliente__correo] UNIQUE NONCLUSTERED 
(
	[correo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UNQ__Empleado__correo]    Script Date: 4/9/2018 11:16:15 AM ******/
ALTER TABLE [dbo].[Empleado] ADD  CONSTRAINT [UNQ__Empleado__correo] UNIQUE NONCLUSTERED 
(
	[correo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UNQ__Empleado__username]    Script Date: 4/9/2018 11:16:15 AM ******/
ALTER TABLE [dbo].[Empleado] ADD  CONSTRAINT [UNQ__Empleado__username] UNIQUE NONCLUSTERED 
(
	[username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Poliza]  WITH CHECK ADD  CONSTRAINT [FK_Poliza_Cliente] FOREIGN KEY([id_cliente])
REFERENCES [dbo].[Cliente] ([id_cliente])
GO
ALTER TABLE [dbo].[Poliza] CHECK CONSTRAINT [FK_Poliza_Cliente]
GO
ALTER TABLE [dbo].[Poliza]  WITH CHECK ADD  CONSTRAINT [FK_Poliza_Cubrimiento] FOREIGN KEY([cubrimiento])
REFERENCES [dbo].[Cubrimiento] ([cubrimiento])
GO
ALTER TABLE [dbo].[Poliza] CHECK CONSTRAINT [FK_Poliza_Cubrimiento]
GO
/****** Object:  StoredProcedure [dbo].[ClienteById]    Script Date: 4/9/2018 11:16:15 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[ClienteById]
@id_cliente INT 
AS BEGIN
SELECT c.id_cliente as ID, c.nombre, c.apellido, c.cedula, c.correo, c.genero

FROM Cliente AS c
WHERE c.id_cliente = @id_cliente 
END
GO
/****** Object:  StoredProcedure [dbo].[ClienteByPolizaId]    Script Date: 4/9/2018 11:16:15 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[ClienteByPolizaId]
@id_poliza INT 
AS BEGIN
SELECT c.id_cliente as ID, c.nombre, c.apellido, c.cedula, c.correo, c.genero

FROM Cliente AS c
JOIN Poliza AS p ON p.id_cliente = c.id_cliente
WHERE p.id_poliza = @id_poliza
END
GO
/****** Object:  StoredProcedure [dbo].[ClienteViewAll]    Script Date: 4/9/2018 11:16:15 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[ClienteViewAll]
AS BEGIN
SELECT c.id_cliente as ID, c.nombre, c.apellido, c.cedula, c.correo, c.genero

FROM Cliente AS c
END
GO
/****** Object:  StoredProcedure [dbo].[CubrimientoViewAll]    Script Date: 4/9/2018 11:16:15 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[CubrimientoViewAll]
AS BEGIN
SELECT r.cubrimiento

FROM Cubrimiento AS r
END
GO
/****** Object:  StoredProcedure [dbo].[EmpleadoLogin]    Script Date: 4/9/2018 11:16:15 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[EmpleadoLogin]
@username nvarchar(50),
@password_hash nvarchar(MAX)

AS BEGIN
SELECT e.id_empleado as ID, e.nombre, e.apellido, e.cedula, e.correo, e.username, e.password_hash as Password

FROM Empleado AS e
WHERE e.username = @username AND e.password_hash = @password_hash
END
GO
/****** Object:  StoredProcedure [dbo].[PolizaAddOrEdit]    Script Date: 4/9/2018 11:16:15 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[PolizaAddOrEdit]

	@id_poliza int,
	@nombre nvarchar(50),
	@descripcion nvarchar(150),
	@periodo int,
	@deducible decimal(18,0),
	@precio decimal(18,0),
	@riesgo nvarchar(50),
	@cubrimiento nvarchar(50),
	@inicio_vigencia datetime,
	@id_cliente as int

	AS
	BEGIN
	IF(@id_poliza = 0)
	BEGIN
		INSERT INTO Poliza
		(
		nombre,
		descripcion,
		periodo,
		deducible,
		precio,
		riesgo,
		cubrimiento,
		inicio_vigencia,
		id_cliente
		)
		VALUES
		(
		@nombre,
		@descripcion,
		@periodo,
		@deducible,
		@precio,
		@riesgo,
		@cubrimiento,
		@inicio_vigencia,
		@id_cliente
		)
	END
	ELSE
	BEGIN
		UPDATE Poliza
		SET
		nombre = @nombre,
		descripcion = @descripcion,
		periodo = @periodo,
		deducible = @deducible,
		precio = @precio,
		riesgo = @riesgo,
		cubrimiento = @cubrimiento,
		inicio_vigencia = @inicio_vigencia,
		id_cliente = @id_cliente
		WHERE id_poliza = @id_poliza
	END
END
GO
/****** Object:  StoredProcedure [dbo].[PolizaById]    Script Date: 4/9/2018 11:16:15 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[PolizaById]
@id_poliza INT 
AS BEGIN
SELECT p.id_poliza, p.nombre, p.descripcion, p.periodo, p.deducible, p.riesgo, 
	   p.precio, p.cubrimiento, p.inicio_vigencia, p.id_cliente

FROM Poliza AS p
JOIN Cliente AS c ON p.id_cliente = c.id_cliente
WHERE p.id_poliza = @id_poliza
END
GO
/****** Object:  StoredProcedure [dbo].[PolizaDeleteById]    Script Date: 4/9/2018 11:16:15 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[PolizaDeleteById]

@id_poliza int
AS BEGIN
DELETE FROM Poliza
WHERE id_poliza = @id_poliza
END
GO
/****** Object:  StoredProcedure [dbo].[PolizaViewAll]    Script Date: 4/9/2018 11:16:15 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[PolizaViewAll]
AS BEGIN
SELECT p.id_poliza, p.nombre, p.descripcion, p.periodo, p.deducible, p.riesgo, 
	   p.precio, p.cubrimiento, p.inicio_vigencia, p.id_cliente

FROM Poliza AS p
JOIN Cliente AS c ON p.id_cliente = c.id_cliente;
END
GO
/****** Object:  StoredProcedure [dbo].[RiesgoViewAll]    Script Date: 4/9/2018 11:16:15 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[RiesgoViewAll]
AS BEGIN
SELECT r.riesgo

FROM riesgo AS r
END
GO
USE [master]
GO
ALTER DATABASE [PruebaPoliza] SET  READ_WRITE 
GO
