USE [master]
GO

/****** Object:  Database [MyFavoritesWeather]    Script Date: 23/02/2020 18:54:49 ******/
CREATE DATABASE [MyFavoritesWeather]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'MyFavoritesWeather', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\MyFavoritesWeather.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'MyFavoritesWeather_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\MyFavoritesWeather_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [MyFavoritesWeather].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [MyFavoritesWeather] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [MyFavoritesWeather] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [MyFavoritesWeather] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [MyFavoritesWeather] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [MyFavoritesWeather] SET ARITHABORT OFF 
GO

ALTER DATABASE [MyFavoritesWeather] SET AUTO_CLOSE OFF 
GO

ALTER DATABASE [MyFavoritesWeather] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [MyFavoritesWeather] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [MyFavoritesWeather] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [MyFavoritesWeather] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [MyFavoritesWeather] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [MyFavoritesWeather] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [MyFavoritesWeather] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [MyFavoritesWeather] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [MyFavoritesWeather] SET  DISABLE_BROKER 
GO

ALTER DATABASE [MyFavoritesWeather] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [MyFavoritesWeather] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [MyFavoritesWeather] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [MyFavoritesWeather] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [MyFavoritesWeather] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [MyFavoritesWeather] SET READ_COMMITTED_SNAPSHOT OFF 
GO

ALTER DATABASE [MyFavoritesWeather] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [MyFavoritesWeather] SET RECOVERY SIMPLE 
GO

ALTER DATABASE [MyFavoritesWeather] SET  MULTI_USER 
GO

ALTER DATABASE [MyFavoritesWeather] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [MyFavoritesWeather] SET DB_CHAINING OFF 
GO

ALTER DATABASE [MyFavoritesWeather] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO

ALTER DATABASE [MyFavoritesWeather] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO

ALTER DATABASE [MyFavoritesWeather] SET DELAYED_DURABILITY = DISABLED 
GO

ALTER DATABASE [MyFavoritesWeather] SET QUERY_STORE = OFF
GO

ALTER DATABASE [MyFavoritesWeather] SET  READ_WRITE 
GO

CREATE TABLE [dbo].[FavoritesCities](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CityKey] [nvarchar](50) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[CelsiusTemprature] [float] NULL,
	[Status] [int] NOT NULL,
	[WeatherText] [nvarchar](max) NULL,
 CONSTRAINT [PK_FavoritesCities] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] T
go
