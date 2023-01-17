USE [master]
GO
/****** Object:  Database [ClientsOrderSomeStuff]    Script Date: 17.01.2023 16:34:32 ******/
CREATE DATABASE [ClientsOrderSomeStuff]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ClientsOrderSomeStuff', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\ClientsOrderSomeStuff.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 10%)
 LOG ON 
( NAME = N'ClientsOrderSomeStuff_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\ClientsOrderSomeStuff_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [ClientsOrderSomeStuff] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ClientsOrderSomeStuff].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ClientsOrderSomeStuff] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ClientsOrderSomeStuff] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ClientsOrderSomeStuff] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ClientsOrderSomeStuff] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ClientsOrderSomeStuff] SET ARITHABORT OFF 
GO
ALTER DATABASE [ClientsOrderSomeStuff] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ClientsOrderSomeStuff] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ClientsOrderSomeStuff] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ClientsOrderSomeStuff] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ClientsOrderSomeStuff] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ClientsOrderSomeStuff] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ClientsOrderSomeStuff] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ClientsOrderSomeStuff] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ClientsOrderSomeStuff] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ClientsOrderSomeStuff] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ClientsOrderSomeStuff] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ClientsOrderSomeStuff] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ClientsOrderSomeStuff] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ClientsOrderSomeStuff] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ClientsOrderSomeStuff] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ClientsOrderSomeStuff] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ClientsOrderSomeStuff] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ClientsOrderSomeStuff] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [ClientsOrderSomeStuff] SET  MULTI_USER 
GO
ALTER DATABASE [ClientsOrderSomeStuff] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ClientsOrderSomeStuff] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ClientsOrderSomeStuff] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ClientsOrderSomeStuff] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [ClientsOrderSomeStuff] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [ClientsOrderSomeStuff] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [ClientsOrderSomeStuff] SET QUERY_STORE = OFF
GO
USE [ClientsOrderSomeStuff]
GO
/****** Object:  Table [dbo].[Clients]    Script Date: 17.01.2023 16:34:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Clients](
	[ClientId] [int] IDENTITY(1,1) NOT NULL,
	[ClientSurname] [nvarchar](20) NOT NULL,
	[ClientAddress] [nvarchar](50) NULL,
	[ClientPhone] [nvarchar](11) NOT NULL,
 CONSTRAINT [PK_Clients] PRIMARY KEY CLUSTERED 
(
	[ClientId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderList]    Script Date: 17.01.2023 16:34:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderList](
	[OrderId] [int] NOT NULL,
	[ClientId] [int] NOT NULL,
	[OrderCost] [float] NOT NULL,
 CONSTRAINT [PK_OrderList] PRIMARY KEY CLUSTERED 
(
	[OrderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 17.01.2023 16:34:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[OrderId] [int] IDENTITY(1,1) NOT NULL,
	[OrderDate] [date] NOT NULL,
	[ServiceId] [int] NOT NULL,
	[ServiceCost] [float] NOT NULL,
	[PaymentMethod] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED 
(
	[OrderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Services]    Script Date: 17.01.2023 16:34:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Services](
	[ServiceId] [int] IDENTITY(1,1) NOT NULL,
	[ServiceName] [nvarchar](50) NOT NULL,
	[ServiceCost] [float] NOT NULL,
 CONSTRAINT [PK_Services] PRIMARY KEY CLUSTERED 
(
	[ServiceId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Clients] ON 

INSERT [dbo].[Clients] ([ClientId], [ClientSurname], [ClientAddress], [ClientPhone]) VALUES (1, N'Сухарева', N'', N'823730485')
INSERT [dbo].[Clients] ([ClientId], [ClientSurname], [ClientAddress], [ClientPhone]) VALUES (2, N'Мартынов', NULL, N'9274666246')
INSERT [dbo].[Clients] ([ClientId], [ClientSurname], [ClientAddress], [ClientPhone]) VALUES (3, N'Малышев', NULL, N'416844226')
INSERT [dbo].[Clients] ([ClientId], [ClientSurname], [ClientAddress], [ClientPhone]) VALUES (4, N'Астахова', NULL, N'5398711749')
INSERT [dbo].[Clients] ([ClientId], [ClientSurname], [ClientAddress], [ClientPhone]) VALUES (5, N'Ермолаев', NULL, N'447003499')
SET IDENTITY_INSERT [dbo].[Clients] OFF
GO
INSERT [dbo].[OrderList] ([OrderId], [ClientId], [OrderCost]) VALUES (8, 1, 350)
INSERT [dbo].[OrderList] ([OrderId], [ClientId], [OrderCost]) VALUES (9, 2, 99.99)
INSERT [dbo].[OrderList] ([OrderId], [ClientId], [OrderCost]) VALUES (10, 3, 1499.99)
INSERT [dbo].[OrderList] ([OrderId], [ClientId], [OrderCost]) VALUES (12, 4, 234)
INSERT [dbo].[OrderList] ([OrderId], [ClientId], [OrderCost]) VALUES (13, 5, 82.99)
GO
SET IDENTITY_INSERT [dbo].[Orders] ON 

INSERT [dbo].[Orders] ([OrderId], [OrderDate], [ServiceId], [ServiceCost], [PaymentMethod]) VALUES (8, CAST(N'2023-03-18' AS Date), 1, 350, N'наличными')
INSERT [dbo].[Orders] ([OrderId], [OrderDate], [ServiceId], [ServiceCost], [PaymentMethod]) VALUES (9, CAST(N'2023-01-01' AS Date), 2, 99.99, N'по безналичному расчёту')
INSERT [dbo].[Orders] ([OrderId], [OrderDate], [ServiceId], [ServiceCost], [PaymentMethod]) VALUES (10, CAST(N'2023-02-19' AS Date), 3, 1499.99, N'наличными')
INSERT [dbo].[Orders] ([OrderId], [OrderDate], [ServiceId], [ServiceCost], [PaymentMethod]) VALUES (12, CAST(N'2023-01-19' AS Date), 4, 234, N'по безналичному расчёту')
INSERT [dbo].[Orders] ([OrderId], [OrderDate], [ServiceId], [ServiceCost], [PaymentMethod]) VALUES (13, CAST(N'2023-01-23' AS Date), 5, 82.99, N'наличными')
SET IDENTITY_INSERT [dbo].[Orders] OFF
GO
SET IDENTITY_INSERT [dbo].[Services] ON 

INSERT [dbo].[Services] ([ServiceId], [ServiceName], [ServiceCost]) VALUES (1, N'Услуга 1', 350)
INSERT [dbo].[Services] ([ServiceId], [ServiceName], [ServiceCost]) VALUES (2, N'Услуга 2', 99.99)
INSERT [dbo].[Services] ([ServiceId], [ServiceName], [ServiceCost]) VALUES (3, N'Услуга 3', 1499.99)
INSERT [dbo].[Services] ([ServiceId], [ServiceName], [ServiceCost]) VALUES (4, N'Услуга 4', 234)
INSERT [dbo].[Services] ([ServiceId], [ServiceName], [ServiceCost]) VALUES (5, N'Услуга 5', 82.99)
SET IDENTITY_INSERT [dbo].[Services] OFF
GO
ALTER TABLE [dbo].[OrderList]  WITH CHECK ADD  CONSTRAINT [FK_OrderList_Clients] FOREIGN KEY([ClientId])
REFERENCES [dbo].[Clients] ([ClientId])
GO
ALTER TABLE [dbo].[OrderList] CHECK CONSTRAINT [FK_OrderList_Clients]
GO
ALTER TABLE [dbo].[OrderList]  WITH CHECK ADD  CONSTRAINT [FK_OrderList_Orders] FOREIGN KEY([OrderId])
REFERENCES [dbo].[Orders] ([OrderId])
GO
ALTER TABLE [dbo].[OrderList] CHECK CONSTRAINT [FK_OrderList_Orders]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Services1] FOREIGN KEY([ServiceId])
REFERENCES [dbo].[Services] ([ServiceId])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_Services1]
GO
USE [master]
GO
ALTER DATABASE [ClientsOrderSomeStuff] SET  READ_WRITE 
GO
