USE [master]
GO
/****** Object:  Database [TALLER]    Script Date: 08/03/2018 5:05:02 ******/
CREATE DATABASE [TALLER] ON  PRIMARY 
( NAME = N'TALLER', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.SQLEXPRESS\MSSQL\DATA\TALLER.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'TALLER_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.SQLEXPRESS\MSSQL\DATA\TALLER_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [TALLER] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [TALLER].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [TALLER] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [TALLER] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [TALLER] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [TALLER] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [TALLER] SET ARITHABORT OFF 
GO
ALTER DATABASE [TALLER] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [TALLER] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [TALLER] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [TALLER] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [TALLER] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [TALLER] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [TALLER] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [TALLER] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [TALLER] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [TALLER] SET  DISABLE_BROKER 
GO
ALTER DATABASE [TALLER] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [TALLER] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [TALLER] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [TALLER] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [TALLER] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [TALLER] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [TALLER] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [TALLER] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [TALLER] SET  MULTI_USER 
GO
ALTER DATABASE [TALLER] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [TALLER] SET DB_CHAINING OFF 
GO
USE [TALLER]
GO
/****** Object:  Table [dbo].[Alarma]    Script Date: 08/03/2018 5:05:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Alarma](
	[CodAlarma] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](500) NULL,
	[Fecha] [date] NULL,
 CONSTRAINT [PK_Alarma] PRIMARY KEY CLUSTERED 
(
	[CodAlarma] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Auto]    Script Date: 08/03/2018 5:05:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Auto](
	[CodAuto] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[Patente] [varchar](50) NULL,
	[CodMarca] [numeric](18, 0) NULL,
	[Descripcion] [varchar](500) NULL,
	[Kilometros] [numeric](18, 0) NULL,
	[CodCiudad] [numeric](18, 0) NULL,
	[Propio] [numeric](1, 0) NULL,
	[Concesion] [numeric](1, 0) NULL,
	[Observacion] [varchar](3000) NULL,
	[Anio] [varchar](4) NULL,
	[Importe] [numeric](18, 2) NULL,
	[Motor] [varchar](100) NULL,
	[Chasis] [varchar](100) NULL,
	[Color] [varchar](100) NULL,
	[CodTipoCombustible] [numeric](18, 0) NULL,
	[CodCliente] [numeric](18, 0) NULL,
 CONSTRAINT [PK_MarcaAuto] PRIMARY KEY CLUSTERED 
(
	[CodAuto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Barrio]    Script Date: 08/03/2018 5:05:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Barrio](
	[CodBarrio] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](200) NULL,
 CONSTRAINT [PK_Barrio] PRIMARY KEY CLUSTERED 
(
	[CodBarrio] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cheque]    Script Date: 08/03/2018 5:05:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cheque](
	[CodCheque] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[NroCheque] [varchar](100) NULL,
	[Importe] [numeric](18, 2) NULL,
	[Saldo] [numeric](18, 2) NULL,
	[CodOrden] [numeric](18, 0) NULL,
	[Fecha] [date] NULL,
	[FechaVto] [date] NULL,
 CONSTRAINT [PK_Cheque] PRIMARY KEY CLUSTERED 
(
	[CodCheque] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ciudad]    Script Date: 08/03/2018 5:05:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ciudad](
	[CodCiudad] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](250) NULL,
 CONSTRAINT [PK_Ciudad] PRIMARY KEY CLUSTERED 
(
	[CodCiudad] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cliente]    Script Date: 08/03/2018 5:05:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cliente](
	[CodCliente] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[CodTipoDoc] [numeric](4, 0) NULL,
	[NroDocumento] [varchar](50) NULL,
	[Nombre] [varchar](100) NULL,
	[Apellido] [varchar](100) NULL,
	[Telefono] [varchar](50) NULL,
	[Celular] [varchar](50) NULL,
	[Calle] [varchar](250) NULL,
	[Numero] [varchar](20) NULL,
	[CodBarrio] [numeric](18, 0) NULL,
 CONSTRAINT [PK_Cliente] PRIMARY KEY CLUSTERED 
(
	[CodCliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CobroCheque]    Script Date: 08/03/2018 5:05:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CobroCheque](
	[CodCobro] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[CodCheque] [numeric](18, 0) NULL,
	[Importe] [numeric](18, 2) NULL,
	[Fecha] [date] NULL,
 CONSTRAINT [PK_CobroCheque] PRIMARY KEY CLUSTERED 
(
	[CodCobro] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CobroDocumento]    Script Date: 08/03/2018 5:05:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CobroDocumento](
	[CodCobro] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[CodDocumento] [numeric](18, 0) NULL,
	[Fecha] [date] NULL,
	[Importe] [numeric](18, 2) NULL,
 CONSTRAINT [PK_CobroDocumento] PRIMARY KEY CLUSTERED 
(
	[CodCobro] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CobroTarjeta]    Script Date: 08/03/2018 5:05:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CobroTarjeta](
	[CodCobro] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[CodOrden] [numeric](18, 0) NULL,
	[Fecha] [date] NULL,
	[CodTarjeta] [numeric](18, 0) NULL,
	[Saldo] [numeric](18, 2) NULL,
	[Importe] [numeric](18, 2) NULL,
	[cupon] [varchar](50) NULL,
 CONSTRAINT [PK_CobroTarjeta] PRIMARY KEY CLUSTERED 
(
	[CodCobro] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Compra]    Script Date: 08/03/2018 5:05:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Compra](
	[CodCompra] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[CodProveedor] [numeric](18, 0) NULL,
	[Fecha] [date] NULL,
	[Factura] [varchar](200) NULL,
 CONSTRAINT [PK_Compra] PRIMARY KEY CLUSTERED 
(
	[CodCompra] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DetalleCompra]    Script Date: 08/03/2018 5:05:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DetalleCompra](
	[CodCompra] [numeric](18, 0) NOT NULL,
	[CodInsumo] [numeric](18, 0) NOT NULL,
	[Cantidad] [numeric](18, 0) NULL,
	[Precio] [numeric](18, 2) NULL,
 CONSTRAINT [PK_DetalleCompra] PRIMARY KEY CLUSTERED 
(
	[CodCompra] ASC,
	[CodInsumo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Documento]    Script Date: 08/03/2018 5:05:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Documento](
	[CodDocumento] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[Fecha] [date] NULL,
	[Importe] [numeric](18, 2) NULL,
	[Saldo] [numeric](18, 2) NULL,
	[CodOrden] [numeric](18, 0) NULL,
 CONSTRAINT [PK_Documento] PRIMARY KEY CLUSTERED 
(
	[CodDocumento] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Entidad]    Script Date: 08/03/2018 5:05:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Entidad](
	[CodEntidad] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](100) NULL,
 CONSTRAINT [PK_Entidad] PRIMARY KEY CLUSTERED 
(
	[CodEntidad] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Garantia]    Script Date: 08/03/2018 5:05:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Garantia](
	[CodGarantia] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[Importe] [numeric](18, 2) NULL,
	[CodOrden] [numeric](18, 0) NULL,
	[Saldo] [numeric](18, 2) NULL,
	[FechaPago] [date] NULL,
	[Fecha] [date] NULL,
 CONSTRAINT [PK_Garantia] PRIMARY KEY CLUSTERED 
(
	[CodGarantia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GastosNegocio]    Script Date: 08/03/2018 5:05:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GastosNegocio](
	[CodGasto] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[Fecha] [date] NULL,
	[CodEntidad] [numeric](18, 0) NULL,
	[Descripcion] [varchar](100) NULL,
	[Importe] [numeric](18, 2) NULL,
 CONSTRAINT [PK_GastosNegocio] PRIMARY KEY CLUSTERED 
(
	[CodGasto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Insumo]    Script Date: 08/03/2018 5:05:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Insumo](
	[CodInsumo] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](500) NULL,
	[Factura] [varchar](100) NULL,
	[Proveedor] [varchar](100) NULL,
	[ActualizaStock] [numeric](1, 0) NULL,
	[Cantidad] [numeric](18, 0) NULL,
	[Precio] [numeric](18, 2) NULL,
	[CodProveedor] [numeric](18, 0) NULL,
 CONSTRAINT [PK_Insumo] PRIMARY KEY CLUSTERED 
(
	[CodInsumo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[InsumosxTarea]    Script Date: 08/03/2018 5:05:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InsumosxTarea](
	[CodOrden] [numeric](18, 0) NOT NULL,
	[CodTarea] [numeric](18, 0) NOT NULL,
	[CodInsumo] [numeric](18, 0) NOT NULL,
	[PrecioCosto] [numeric](18, 2) NULL,
	[PrecioVenta] [numeric](18, 2) NULL,
 CONSTRAINT [PK_InsumosxTarea] PRIMARY KEY CLUSTERED 
(
	[CodOrden] ASC,
	[CodTarea] ASC,
	[CodInsumo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Marca]    Script Date: 08/03/2018 5:05:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Marca](
	[CodMarca] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](250) NULL,
 CONSTRAINT [PK_Marca] PRIMARY KEY CLUSTERED 
(
	[CodMarca] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Mecanico]    Script Date: 08/03/2018 5:05:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Mecanico](
	[CodMecanico] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](100) NULL,
	[Apellido] [varchar](100) NULL,
 CONSTRAINT [PK_Mecanico] PRIMARY KEY CLUSTERED 
(
	[CodMecanico] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Mensaje]    Script Date: 08/03/2018 5:05:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Mensaje](
	[CodMensaje] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[Fecha] [date] NULL,
	[Descripcion] [varchar](5000) NULL,
	[CodOrden] [numeric](18, 0) NULL,
 CONSTRAINT [PK_Mensaje] PRIMARY KEY CLUSTERED 
(
	[CodMensaje] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Movimientos]    Script Date: 08/03/2018 5:05:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Movimientos](
	[CodMovimiento] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[Fecha] [date] NULL,
	[Importe] [numeric](18, 2) NULL,
	[Descripcion] [varchar](1000) NULL,
	[CodUsuario] [numeric](18, 0) NULL,
	[CodOrden] [numeric](18, 0) NULL,
 CONSTRAINT [PK_Movimientos] PRIMARY KEY CLUSTERED 
(
	[CodMovimiento] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Orden]    Script Date: 08/03/2018 5:05:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orden](
	[CodOrden] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[CodCliente] [numeric](18, 0) NULL,
	[CodMecanico] [numeric](18, 0) NULL,
	[Fecha] [date] NULL,
	[CodAuto] [numeric](18, 0) NULL,
	[Procesada] [numeric](1, 0) NULL,
	[Descripcion] [varchar](5000) NULL,
	[ImporteEfectivo] [numeric](18, 2) NULL,
 CONSTRAINT [PK_Orden] PRIMARY KEY CLUSTERED 
(
	[CodOrden] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrdenDetalle]    Script Date: 08/03/2018 5:05:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrdenDetalle](
	[CodOrden] [numeric](18, 0) NOT NULL,
	[CodInsumo] [numeric](18, 0) NOT NULL,
	[Cantidad] [numeric](18, 2) NULL,
	[PrecioCosto] [numeric](18, 2) NULL,
	[PrecioVenta] [numeric](18, 2) NULL,
	[PrecioManoObra] [numeric](18, 2) NULL,
 CONSTRAINT [PK_OrdenDetalle] PRIMARY KEY CLUSTERED 
(
	[CodOrden] ASC,
	[CodInsumo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Proveedor]    Script Date: 08/03/2018 5:05:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Proveedor](
	[CodProveedor] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](500) NULL,
	[Telefono] [varchar](50) NULL,
 CONSTRAINT [PK_Proveedor] PRIMARY KEY CLUSTERED 
(
	[CodProveedor] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tarea]    Script Date: 08/03/2018 5:05:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tarea](
	[CodTarea] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](200) NULL,
 CONSTRAINT [PK_Tarea] PRIMARY KEY CLUSTERED 
(
	[CodTarea] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tarjeta]    Script Date: 08/03/2018 5:05:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tarjeta](
	[Codtarjeta] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](500) NULL,
 CONSTRAINT [PK_Tarjeta] PRIMARY KEY CLUSTERED 
(
	[Codtarjeta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TipoCombustible]    Script Date: 08/03/2018 5:05:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoCombustible](
	[Codigo] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[Nombre] [nchar](10) NULL,
 CONSTRAINT [PK_TipoCombustible] PRIMARY KEY CLUSTERED 
(
	[Codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TipoDocumento]    Script Date: 08/03/2018 5:05:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoDocumento](
	[CodTipoDoc] [numeric](4, 0) IDENTITY(1,1) NOT NULL,
	[Nombre] [nchar](10) NULL,
 CONSTRAINT [PK_TipoDocumento] PRIMARY KEY CLUSTERED 
(
	[CodTipoDoc] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 08/03/2018 5:05:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[CodUsuario] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](100) NULL,
	[Clave] [varchar](20) NULL,
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[CodUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Vale]    Script Date: 08/03/2018 5:05:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Vale](
	[CodVale] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[Fecha] [date] NULL,
	[Nombre] [varchar](250) NULL,
	[Apellido] [varchar](250) NULL,
	[Importe] [numeric](18, 1) NULL,
	[Saldo] [numeric](18, 0) NULL,
	[FechaDevolucion] [date] NULL,
	[Descripcion] [varchar](2000) NULL,
 CONSTRAINT [PK_Vale] PRIMARY KEY CLUSTERED 
(
	[CodVale] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[backupdb]    Script Date: 08/03/2018 5:05:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[backupdb]
as
BACKUP DATABASE [TALLER] TO  DISK =N'C:\copia\TALLER.bak'
WITH NOFORMAT, NOINIT,  NAME = N'test-Completa Base de datos Copia de seguridad', SKIP,NOREWIND, NOUNLOAD,  STATS = 10
GO
USE [master]
GO
ALTER DATABASE [TALLER] SET  READ_WRITE 
GO
