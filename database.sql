USE [master]
GO
/****** Object:  Database [TurbokartDb23]    Script Date: 30-11-2023 10:37:35 ******/
CREATE DATABASE [TurbokartDb23]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'TurbokartDb23', FILENAME = N'C:\Users\seba127c\TurbokartDb23.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'TurbokartDb23_log', FILENAME = N'C:\Users\seba127c\TurbokartDb23_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [TurbokartDb23] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [TurbokartDb23].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [TurbokartDb23] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [TurbokartDb23] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [TurbokartDb23] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [TurbokartDb23] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [TurbokartDb23] SET ARITHABORT OFF 
GO
ALTER DATABASE [TurbokartDb23] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [TurbokartDb23] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [TurbokartDb23] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [TurbokartDb23] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [TurbokartDb23] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [TurbokartDb23] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [TurbokartDb23] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [TurbokartDb23] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [TurbokartDb23] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [TurbokartDb23] SET  ENABLE_BROKER 
GO
ALTER DATABASE [TurbokartDb23] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [TurbokartDb23] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [TurbokartDb23] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [TurbokartDb23] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [TurbokartDb23] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [TurbokartDb23] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [TurbokartDb23] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [TurbokartDb23] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [TurbokartDb23] SET  MULTI_USER 
GO
ALTER DATABASE [TurbokartDb23] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [TurbokartDb23] SET DB_CHAINING OFF 
GO
ALTER DATABASE [TurbokartDb23] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [TurbokartDb23] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [TurbokartDb23] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [TurbokartDb23] SET QUERY_STORE = OFF
GO
USE [TurbokartDb23]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
USE [TurbokartDb23]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 30-11-2023 10:37:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Bookings]    Script Date: 30-11-2023 10:37:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bookings](
	[BookingId] [int] IDENTITY(1,1) NOT NULL,
	[Grandprix] [nvarchar](max) NOT NULL,
	[Email] [nvarchar](max) NOT NULL,
	[Phonenumber] [nvarchar](max) NOT NULL,
	[Date] [datetime2](7) NOT NULL,
	[Amount] [bigint] NOT NULL,
	[CustomerId] [int] NOT NULL,
 CONSTRAINT [PK_Bookings] PRIMARY KEY CLUSTERED 
(
	[BookingId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customers]    Script Date: 30-11-2023 10:37:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customers](
	[CustomerId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Customers] PRIMARY KEY CLUSTERED 
(
	[CustomerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DeletedBookings]    Script Date: 30-11-2023 10:37:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DeletedBookings](
	[DeletedBookingId] [int] IDENTITY(1,1) NOT NULL,
	[BookingId] [int] NOT NULL,
	[Grandprix] [nvarchar](max) NOT NULL,
	[Email] [nvarchar](max) NOT NULL,
	[Phonenumber] [nvarchar](max) NOT NULL,
	[Date] [datetime2](7) NOT NULL,
	[Amount] [bigint] NOT NULL,
	[CustomerId] [int] NOT NULL,
	[ReasonOfDeletion] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_DeletedBookings] PRIMARY KEY CLUSTERED 
(
	[DeletedBookingId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20231122095712_InitialCreate', N'7.0.14')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20231130084349_DeletedBookings', N'7.0.14')
GO
SET IDENTITY_INSERT [dbo].[Bookings] ON 

INSERT [dbo].[Bookings] ([BookingId], [Grandprix], [Email], [Phonenumber], [Date], [Amount], [CustomerId]) VALUES (1, N'Enkelt', N'hundemad@spar.dk', N'12345678', CAST(N'2023-11-23T00:00:00.0000000' AS DateTime2), 5, 1)
INSERT [dbo].[Bookings] ([BookingId], [Grandprix], [Email], [Phonenumber], [Date], [Amount], [CustomerId]) VALUES (2, N'Double', N'vand@spar.dk', N'12345678', CAST(N'2023-12-23T00:00:00.0000000' AS DateTime2), 16, 2)
INSERT [dbo].[Bookings] ([BookingId], [Grandprix], [Email], [Phonenumber], [Date], [Amount], [CustomerId]) VALUES (6, N'string', N'string', N'string', CAST(N'2023-11-23T10:13:47.4850000' AS DateTime2), 0, 7)
INSERT [dbo].[Bookings] ([BookingId], [Grandprix], [Email], [Phonenumber], [Date], [Amount], [CustomerId]) VALUES (7, N'string', N'string', N'string', CAST(N'2023-11-23T10:14:30.8900000' AS DateTime2), 0, 4)
INSERT [dbo].[Bookings] ([BookingId], [Grandprix], [Email], [Phonenumber], [Date], [Amount], [CustomerId]) VALUES (1002, N'Double', N'sad@sd.ck', N'12345678', CAST(N'2023-11-25T11:30:00.0000000' AS DateTime2), 12, 1002)
SET IDENTITY_INSERT [dbo].[Bookings] OFF
GO
SET IDENTITY_INSERT [dbo].[Customers] ON 

INSERT [dbo].[Customers] ([CustomerId], [Name]) VALUES (1, N'Hans')
INSERT [dbo].[Customers] ([CustomerId], [Name]) VALUES (2, N'Begitte')
INSERT [dbo].[Customers] ([CustomerId], [Name]) VALUES (3, N'Leif')
INSERT [dbo].[Customers] ([CustomerId], [Name]) VALUES (4, N'Erik')
INSERT [dbo].[Customers] ([CustomerId], [Name]) VALUES (5, N'UNDEFINED')
INSERT [dbo].[Customers] ([CustomerId], [Name]) VALUES (6, N'UNDEFINED')
INSERT [dbo].[Customers] ([CustomerId], [Name]) VALUES (7, N'string')
INSERT [dbo].[Customers] ([CustomerId], [Name]) VALUES (8, N'errrrik')
INSERT [dbo].[Customers] ([CustomerId], [Name]) VALUES (1002, N'sad')
SET IDENTITY_INSERT [dbo].[Customers] OFF
GO
SET IDENTITY_INSERT [dbo].[DeletedBookings] ON 

INSERT [dbo].[DeletedBookings] ([DeletedBookingId], [BookingId], [Grandprix], [Email], [Phonenumber], [Date], [Amount], [CustomerId], [ReasonOfDeletion]) VALUES (1, 4, N'string', N'string', N'string', CAST(N'2023-11-23T10:11:02.2370000' AS DateTime2), 0, 5, N'yes')
INSERT [dbo].[DeletedBookings] ([DeletedBookingId], [BookingId], [Grandprix], [Email], [Phonenumber], [Date], [Amount], [CustomerId], [ReasonOfDeletion]) VALUES (2, 3, N'Double', N'vhat@spar.dk', N'12345678', CAST(N'2023-10-23T00:00:00.0000000' AS DateTime2), 12, 3, N'Thats crazy my drilla')
SET IDENTITY_INSERT [dbo].[DeletedBookings] OFF
GO
/****** Object:  Index [IX_Bookings_CustomerId]    Script Date: 30-11-2023 10:37:35 ******/
CREATE NONCLUSTERED INDEX [IX_Bookings_CustomerId] ON [dbo].[Bookings]
(
	[CustomerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_DeletedBookings_CustomerId]    Script Date: 30-11-2023 10:37:35 ******/
CREATE NONCLUSTERED INDEX [IX_DeletedBookings_CustomerId] ON [dbo].[DeletedBookings]
(
	[CustomerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Bookings]  WITH CHECK ADD  CONSTRAINT [FK_Bookings_Customers_CustomerId] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customers] ([CustomerId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Bookings] CHECK CONSTRAINT [FK_Bookings_Customers_CustomerId]
GO
ALTER TABLE [dbo].[DeletedBookings]  WITH CHECK ADD  CONSTRAINT [FK_DeletedBookings_Customers_CustomerId] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customers] ([CustomerId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[DeletedBookings] CHECK CONSTRAINT [FK_DeletedBookings_Customers_CustomerId]
GO
USE [master]
GO
ALTER DATABASE [TurbokartDb23] SET  READ_WRITE 
GO
