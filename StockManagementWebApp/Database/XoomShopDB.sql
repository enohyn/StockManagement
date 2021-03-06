USE [master]
GO
/****** Object:  Database [XoomShopDB]    Script Date: 11/28/2018 4:21:59 PM ******/
CREATE DATABASE [XoomShopDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'XoomShopDB', FILENAME = N'G:\Project\ASPDOTNET\Database\XoomShopDB.mdf' , SIZE = 4096KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'XoomShopDB_log', FILENAME = N'G:\Project\ASPDOTNET\Database\XoomShopDB_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [XoomShopDB] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [XoomShopDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [XoomShopDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [XoomShopDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [XoomShopDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [XoomShopDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [XoomShopDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [XoomShopDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [XoomShopDB] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [XoomShopDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [XoomShopDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [XoomShopDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [XoomShopDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [XoomShopDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [XoomShopDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [XoomShopDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [XoomShopDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [XoomShopDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [XoomShopDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [XoomShopDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [XoomShopDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [XoomShopDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [XoomShopDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [XoomShopDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [XoomShopDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [XoomShopDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [XoomShopDB] SET  MULTI_USER 
GO
ALTER DATABASE [XoomShopDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [XoomShopDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [XoomShopDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [XoomShopDB] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [XoomShopDB]
GO
/****** Object:  Table [dbo].[Admin]    Script Date: 11/28/2018 4:22:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Admin](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[Signature] [nvarchar](50) NULL,
 CONSTRAINT [PK_Admin] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Category]    Script Date: 11/28/2018 4:22:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CategoryName] [nvarchar](30) NULL,
 CONSTRAINT [PK_AllCategory] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Company]    Script Date: 11/28/2018 4:22:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Company](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CompanyName] [nvarchar](30) NULL,
 CONSTRAINT [PK_CompanyTable] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Item]    Script Date: 11/28/2018 4:22:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Item](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CategoryId] [int] NULL,
	[CompanyId] [int] NULL,
	[ItemName] [nvarchar](50) NULL,
	[ReorderLevel] [nvarchar](50) NULL,
	[Quantity] [nvarchar](50) NULL,
 CONSTRAINT [PK_Item] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[StockOut]    Script Date: 11/28/2018 4:22:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[StockOut](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ItemId] [int] NULL,
	[Quantity] [int] NULL,
	[Type] [varchar](50) NULL,
	[Date] [varchar](50) NULL,
 CONSTRAINT [PK_StockInAndOutTable] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  View [dbo].[ItemInfo]    Script Date: 11/28/2018 4:22:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[ItemInfo]
AS
SELECT        dbo.Item.Id AS ItemId, dbo.Item.ItemName, dbo.Item.ReorderLevel, dbo.Item.CategoryId, dbo.Category.CategoryName, dbo.Item.CompanyId, dbo.Company.CompanyName, dbo.Item.Quantity
FROM            dbo.Item INNER JOIN
                         dbo.Category ON dbo.Item.CategoryId = dbo.Category.Id INNER JOIN
                         dbo.Company ON dbo.Item.CompanyId = dbo.Company.Id

GO
/****** Object:  View [dbo].[StockOutInfo]    Script Date: 11/28/2018 4:22:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[StockOutInfo] AS


SELECT

ItemInfo.ItemId,
ItemInfo.ItemName,
ItemInfo.ReorderLevel,
ItemInfo.CategoryId,
ItemInfo.CategoryName,
ItemInfo.CompanyId,
ItemInfo.CompanyName,
ItemInfo.Quantity,
StockOut.Quantity AS SellQuanity,
StockOut.Type,
StockOut.Date
FROM ItemInfo INNER JOIN StockOut ON ItemInfo.ItemId=StockOut.ItemId
GO
/****** Object:  View [dbo].[SellsInfo]    Script Date: 11/28/2018 4:22:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[SellsInfo] AS
SELECT * From StockOutInfo WHERE Type='Sell'
GO
ALTER TABLE [dbo].[Item]  WITH CHECK ADD  CONSTRAINT [FK_Item_Category] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Category] ([Id])
GO
ALTER TABLE [dbo].[Item] CHECK CONSTRAINT [FK_Item_Category]
GO
ALTER TABLE [dbo].[Item]  WITH CHECK ADD  CONSTRAINT [FK_Item_Company] FOREIGN KEY([CompanyId])
REFERENCES [dbo].[Company] ([Id])
GO
ALTER TABLE [dbo].[Item] CHECK CONSTRAINT [FK_Item_Company]
GO
ALTER TABLE [dbo].[StockOut]  WITH CHECK ADD  CONSTRAINT [FK_StockOut_Item] FOREIGN KEY([ItemId])
REFERENCES [dbo].[Item] ([Id])
GO
ALTER TABLE [dbo].[StockOut] CHECK CONSTRAINT [FK_StockOut_Item]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "Item"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 136
               Right = 208
            End
            DisplayFlags = 280
            TopColumn = 2
         End
         Begin Table = "Category"
            Begin Extent = 
               Top = 6
               Left = 246
               Bottom = 102
               Right = 416
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Company"
            Begin Extent = 
               Top = 102
               Left = 246
               Bottom = 198
               Right = 419
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ItemInfo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ItemInfo'
GO
USE [master]
GO
ALTER DATABASE [XoomShopDB] SET  READ_WRITE 
GO
