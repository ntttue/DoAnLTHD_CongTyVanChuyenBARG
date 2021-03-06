USE [master]
GO
/****** Object:  Database [VanChuyenBarg]    Script Date: 24/02/2017 10:10:05 p.m. ******/
CREATE DATABASE [VanChuyenBarg]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'VanChuyenBarg', FILENAME = N'C:\Program Files (x86)\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\VanChuyenBarg.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'VanChuyenBarg_log', FILENAME = N'C:\Program Files (x86)\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\VanChuyenBarg_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [VanChuyenBarg] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [VanChuyenBarg].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [VanChuyenBarg] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [VanChuyenBarg] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [VanChuyenBarg] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [VanChuyenBarg] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [VanChuyenBarg] SET ARITHABORT OFF 
GO
ALTER DATABASE [VanChuyenBarg] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [VanChuyenBarg] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [VanChuyenBarg] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [VanChuyenBarg] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [VanChuyenBarg] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [VanChuyenBarg] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [VanChuyenBarg] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [VanChuyenBarg] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [VanChuyenBarg] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [VanChuyenBarg] SET  ENABLE_BROKER 
GO
ALTER DATABASE [VanChuyenBarg] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [VanChuyenBarg] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [VanChuyenBarg] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [VanChuyenBarg] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [VanChuyenBarg] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [VanChuyenBarg] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [VanChuyenBarg] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [VanChuyenBarg] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [VanChuyenBarg] SET  MULTI_USER 
GO
ALTER DATABASE [VanChuyenBarg] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [VanChuyenBarg] SET DB_CHAINING OFF 
GO
ALTER DATABASE [VanChuyenBarg] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [VanChuyenBarg] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [VanChuyenBarg] SET DELAYED_DURABILITY = DISABLED 
GO
USE [VanChuyenBarg]
GO
/****** Object:  Table [dbo].[KhachHang]    Script Date: 24/02/2017 10:10:05 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KhachHang](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[HoTen] [nvarchar](50) NULL,
	[SDT] [nvarchar](50) NULL,
	[DiaChiDon] [nvarchar](50) NULL,
	[GhiChu] [nvarchar](50) NULL,
	[LoaiXe] [int] NULL,
	[ThoiDiemDat] [datetime] NULL,
	[TinhTrang] [nvarchar](50) NULL
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[KhachHang] ON 

INSERT [dbo].[KhachHang] ([id], [HoTen], [SDT], [DiaChiDon], [GhiChu], [LoaiXe], [ThoiDiemDat], [TinhTrang]) VALUES (1, N'Tuệ Xinh Đẹp', N'01699952101', N'abc', N'asdfasdf', 1, NULL, N'Đã xử lý')
INSERT [dbo].[KhachHang] ([id], [HoTen], [SDT], [DiaChiDon], [GhiChu], [LoaiXe], [ThoiDiemDat], [TinhTrang]) VALUES (2, N'ntttue', N'0123', N'gsgsdfg', N'sdfgsdg', 2, NULL, N'Chưa xử lý')
INSERT [dbo].[KhachHang] ([id], [HoTen], [SDT], [DiaChiDon], [GhiChu], [LoaiXe], [ThoiDiemDat], [TinhTrang]) VALUES (3, N'abc', N'123', N'123', N'123', 3, NULL, N'123')
SET IDENTITY_INSERT [dbo].[KhachHang] OFF
USE [master]
GO
ALTER DATABASE [VanChuyenBarg] SET  READ_WRITE 
GO


ALTER DATABASE [VanChuyenBarg] set Enable_broker with rollback IMMEDIATE;

CREATE TABLE [dbo].[TaiXe] (
    [id]        INT           IDENTITY (1, 1) NOT NULL,
    [HoTen]     NVARCHAR (50) NULL,
    [Lat]       DECIMAL (18)  NULL,
    [Lng]       DECIMAL (18)  NULL,
    [TrangThai] BIT           NULL,
    [usename]   NVARCHAR (50) NULL,
    [pass]      NVARCHAR (50) NULL
);