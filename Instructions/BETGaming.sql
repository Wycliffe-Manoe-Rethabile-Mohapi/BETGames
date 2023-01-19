USE [master]
GO

/****** Object:  Database [BETGaming]    Script Date: 2023/01/17 22:35:39 ******/
CREATE DATABASE [BETGaming]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'BETGaming', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\BETGaming.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'BETGaming_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\BETGaming_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BETGaming].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [BETGaming] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [BETGaming] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [BETGaming] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [BETGaming] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [BETGaming] SET ARITHABORT OFF 
GO

ALTER DATABASE [BETGaming] SET AUTO_CLOSE OFF 
GO

ALTER DATABASE [BETGaming] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [BETGaming] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [BETGaming] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [BETGaming] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [BETGaming] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [BETGaming] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [BETGaming] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [BETGaming] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [BETGaming] SET  DISABLE_BROKER 
GO

ALTER DATABASE [BETGaming] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [BETGaming] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [BETGaming] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [BETGaming] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [BETGaming] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [BETGaming] SET READ_COMMITTED_SNAPSHOT OFF 
GO

ALTER DATABASE [BETGaming] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [BETGaming] SET RECOVERY FULL 
GO

ALTER DATABASE [BETGaming] SET  MULTI_USER 
GO

ALTER DATABASE [BETGaming] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [BETGaming] SET DB_CHAINING OFF 
GO

ALTER DATABASE [BETGaming] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO

ALTER DATABASE [BETGaming] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO

ALTER DATABASE [BETGaming] SET DELAYED_DURABILITY = DISABLED 
GO

ALTER DATABASE [BETGaming] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO

ALTER DATABASE [BETGaming] SET QUERY_STORE = ON
GO

ALTER DATABASE [BETGaming] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO

ALTER DATABASE [BETGaming] SET  READ_WRITE 
GO



USE [BETGaming]
GO
/****** Object:  Table [dbo].[Categories]    Script Date: 2023/01/17 22:32:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Url] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Products]    Script Date: 2023/01/17 22:32:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](max) NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
	[ImageURL] [nvarchar](max) NOT NULL,
	[CategoryId] [int] NOT NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductTypes]    Script Date: 2023/01/17 22:32:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductTypes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_ProductTypes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductVariants]    Script Date: 2023/01/17 22:32:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductVariants](
	[ProductId] [int] NOT NULL,
	[ProductTypeId] [int] NOT NULL,
	[Price] [decimal](18, 4) NOT NULL,
	[OriginalPrice] [decimal](18, 4) NOT NULL,
 CONSTRAINT [PK_ProductVariants] PRIMARY KEY CLUSTERED 
(
	[ProductId] ASC,
	[ProductTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 2023/01/17 22:32:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Email] [nvarchar](max) NOT NULL,
	[PaswordHash] [varbinary](max) NOT NULL,
	[PasswordSalt] [varbinary](max) NOT NULL,
	[DateCreated] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Categories] ON 
GO
INSERT [dbo].[Categories] ([Id], [Name], [Url]) VALUES (1, N'Sandbox', N'Sandbox')
GO
INSERT [dbo].[Categories] ([Id], [Name], [Url]) VALUES (2, N'Shooters', N'Shooters')
GO
INSERT [dbo].[Categories] ([Id], [Name], [Url]) VALUES (3, N'Multiplayer', N'Multiplayer')
GO
INSERT [dbo].[Categories] ([Id], [Name], [Url]) VALUES (4, N'Role-playing', N'Role-playing')
GO
INSERT [dbo].[Categories] ([Id], [Name], [Url]) VALUES (5, N'Electronics', N'Electronics')
GO
SET IDENTITY_INSERT [dbo].[Categories] OFF
GO
SET IDENTITY_INSERT [dbo].[Products] ON 
GO
INSERT [dbo].[Products] ([Id], [Title], [Description], [ImageURL], [CategoryId]) VALUES (1, N'Game 1', N'The first game', N'https://www.trustedreviews.com/wp-content/uploads/sites/54/2019/01/Best-FPS-Games.jpg', 1)
GO
INSERT [dbo].[Products] ([Id], [Title], [Description], [ImageURL], [CategoryId]) VALUES (2, N'Game 2', N'The second game', N'https://www.trustedreviews.com/wp-content/uploads/sites/54/2019/01/Best-FPS-Games.jpg', 2)
GO
INSERT [dbo].[Products] ([Id], [Title], [Description], [ImageURL], [CategoryId]) VALUES (3, N'Game 3', N'the third game', N'https://www.trustedreviews.com/wp-content/uploads/sites/54/2019/01/Best-FPS-Games.jpg', 3)
GO
INSERT [dbo].[Products] ([Id], [Title], [Description], [ImageURL], [CategoryId]) VALUES (4, N'Game 4', N'The fourth game', N'https://www.trustedreviews.com/wp-content/uploads/sites/54/2019/01/Best-FPS-Games.jpg', 4)
GO
INSERT [dbo].[Products] ([Id], [Title], [Description], [ImageURL], [CategoryId]) VALUES (5, N'Apple iPhone 12', N'The latest iPhone with a 6.1-inch Super Retina XDR display.', N'https://m.media-amazon.com/images/I/61bK6PMOC3L._AC_SL1500_.jpg', 5)
GO
INSERT [dbo].[Products] ([Id], [Title], [Description], [ImageURL], [CategoryId]) VALUES (6, N'Samsung Galaxy S21', N'The latest Samsung flagship with a 6.2-inch Dynamic AMOLED 2X display.', N'https://m.media-amazon.com/images/I/61bK6PMOC3L._AC_SL1500_.jpg', 5)
GO
INSERT [dbo].[Products] ([Id], [Title], [Description], [ImageURL], [CategoryId]) VALUES (7, N'Google Pixel 4a', N'A budget-friendly phone from Google with a 5.8-inch OLED display.', N'https://m.media-amazon.com/images/I/61bK6PMOC3L._AC_SL1500_.jpg', 5)
GO
INSERT [dbo].[Products] ([Id], [Title], [Description], [ImageURL], [CategoryId]) VALUES (8, N'OnePlus 8T', N'A high-performance phone with a 6.55-inch Fluid AMOLED display.', N'https://m.media-amazon.com/images/I/61bK6PMOC3L._AC_SL1500_.jpg', 5)
GO
INSERT [dbo].[Products] ([Id], [Title], [Description], [ImageURL], [CategoryId]) VALUES (9, N'Sony PlayStation 5', N'The latest gaming console from Sony with 8K graphics and ray tracing.', N'https://m.media-amazon.com/images/I/61bK6PMOC3L._AC_SL1500_.jpg', 5)
GO
INSERT [dbo].[Products] ([Id], [Title], [Description], [ImageURL], [CategoryId]) VALUES (10, N'Microsoft Xbox Series X', N'The latest gaming console from Microsoft with 4K graphics and 120fps.', N'https://m.media-amazon.com/images/I/61bK6PMOC3L._AC_SL1500_.jpg', 5)
GO
INSERT [dbo].[Products] ([Id], [Title], [Description], [ImageURL], [CategoryId]) VALUES (11, N'Nintendo Switch', N'A portable gaming console from Nintendo with a 6.2-inch capacitive touchscreen.', N'https://example.com/switch.jpg', 5)
GO
INSERT [dbo].[Products] ([Id], [Title], [Description], [ImageURL], [CategoryId]) VALUES (12, N'LG OLED CX Series TV', N'A 4K OLED TV with AI ThinQ and Google Assistant built-in.', N'https://m.media-amazon.com/images/I/61bK6PMOC3L._AC_SL1500_.jpg', 5)
GO
INSERT [dbo].[Products] ([Id], [Title], [Description], [ImageURL], [CategoryId]) VALUES (13, N'Samsung QN900A Series TV', N'A 8K QLED TV with Quantum Processor 8K and Alexa built-in.', N'https://m.media-amazon.com/images/I/61bK6PMOC3L._AC_SL1500_.jpg', 5)
GO
INSERT [dbo].[Products] ([Id], [Title], [Description], [ImageURL], [CategoryId]) VALUES (14, N'Sony A8H Series TV', N'A 4K OLED TV with Acoustic Surface Audio and Android TV built-in.', N'https://m.media-amazon.com/images/I/61bK6PMOC3L._AC_SL1500_.jpg', 5)
GO
INSERT [dbo].[Products] ([Id], [Title], [Description], [ImageURL], [CategoryId]) VALUES (16, N'The Last of Us Part II', N'The highly-anticipated sequel to the critically-acclaimed game.', N'https://m.media-amazon.com/images/I/61bK6PMOC3L._AC_SL1500_.jpg', 1)
GO
INSERT [dbo].[Products] ([Id], [Title], [Description], [ImageURL], [CategoryId]) VALUES (17, N'Cyberpunk 2077', N'An open-world RPG set in a futuristic metropolis.', N'', 1)
GO
INSERT [dbo].[Products] ([Id], [Title], [Description], [ImageURL], [CategoryId]) VALUES (18, N'Horizon Zero Dawn', N'An action RPG set in a post-apocalyptic world ruled by robotic creatures.', N'https://m.media-amazon.com/images/I/61bK6PMOC3L._AC_SL1500_.jpg', 1)
GO
INSERT [dbo].[Products] ([Id], [Title], [Description], [ImageURL], [CategoryId]) VALUES (19, N'Red Dead Redemption 2', N'An epic tale of life in America''s unforgiving heartland.', N'https://m.media-amazon.com/images/I/61bK6PMOC3L._AC_SL1500_.jpg', 1)
GO
INSERT [dbo].[Products] ([Id], [Title], [Description], [ImageURL], [CategoryId]) VALUES (20, N'The Witcher 3: Wild Hunt', N'An open-world action RPG based on the bestselling fantasy series.', N'https://m.media-amazon.com/images/I/61bK6PMOC3L._AC_SL1500_.jpg', 1)
GO
INSERT [dbo].[Products] ([Id], [Title], [Description], [ImageURL], [CategoryId]) VALUES (21, N'Death Stranding', N'An action game developed by Hideo Kojima, creator of the Metal Gear series.', N'https://m.media-amazon.com/images/I/61bK6PMOC3L._AC_SL1500_.jpg', 1)
GO
INSERT [dbo].[Products] ([Id], [Title], [Description], [ImageURL], [CategoryId]) VALUES (22, N'The Legend of Zelda: Breath of the Wild', N'An open-air adventure game set in a vast wilderness.', N'https://m.media-amazon.com/images/I/61bK6PMOC3L._AC_SL1500_.jpg', 1)
GO
INSERT [dbo].[Products] ([Id], [Title], [Description], [ImageURL], [CategoryId]) VALUES (23, N'Super Mario Odyssey', N'A 3D platformer featuring Mario''s first sandbox-style gameplay.', N'https://m.media-amazon.com/images/I/61bK6PMOC3L._AC_SL1500_.jpg', 1)
GO
INSERT [dbo].[Products] ([Id], [Title], [Description], [ImageURL], [CategoryId]) VALUES (24, N'Persona 5', N'A role-playing game that follows a group of high school students.', N'https://m.media-amazon.com/images/I/61bK6PMOC3L._AC_SL1500_.jpg', 1)
GO
INSERT [dbo].[Products] ([Id], [Title], [Description], [ImageURL], [CategoryId]) VALUES (25, N'Final Fantasy VII Remake', N'A modern retelling of the classic RPG.', N'', 1)
GO
INSERT [dbo].[Products] ([Id], [Title], [Description], [ImageURL], [CategoryId]) VALUES (26, N'Monster Hunter: World', N'A game where players take on the role of a hunter and slay different monsters', N'https://m.media-amazon.com/images/I/61bK6PMOC3L._AC_SL1500_.jpg', 1)
GO
INSERT [dbo].[Products] ([Id], [Title], [Description], [ImageURL], [CategoryId]) VALUES (27, N'Overwatch', N'A team-based first-person shooter game developed by Blizzard Entertainment.', N'https://m.media-amazon.com/images/I/61bK6PMOC3L._AC_SL1500_.jpg', 1)
GO
INSERT [dbo].[Products] ([Id], [Title], [Description], [ImageURL], [CategoryId]) VALUES (28, N'Minecraft', N'A sandbox game where players can build and explore virtual worlds.', N'https://m.media-amazon.com/images/I/61bK6PMOC3L._AC_SL1500_.jpg', 1)
GO
SET IDENTITY_INSERT [dbo].[Products] OFF
GO
SET IDENTITY_INSERT [dbo].[ProductTypes] ON 
GO
INSERT [dbo].[ProductTypes] ([Id], [Name]) VALUES (1, N'Usb')
GO
INSERT [dbo].[ProductTypes] ([Id], [Name]) VALUES (2, N'CD')
GO
INSERT [dbo].[ProductTypes] ([Id], [Name]) VALUES (3, N'Download')
GO
INSERT [dbo].[ProductTypes] ([Id], [Name]) VALUES (4, N'Hardware')
GO
SET IDENTITY_INSERT [dbo].[ProductTypes] OFF
GO
INSERT [dbo].[ProductVariants] ([ProductId], [ProductTypeId], [Price], [OriginalPrice]) VALUES (1, 1, CAST(10.0000 AS Decimal(18, 4)), CAST(5.0000 AS Decimal(18, 4)))
GO
INSERT [dbo].[ProductVariants] ([ProductId], [ProductTypeId], [Price], [OriginalPrice]) VALUES (1, 2, CAST(10.0000 AS Decimal(18, 4)), CAST(5.0000 AS Decimal(18, 4)))
GO
INSERT [dbo].[ProductVariants] ([ProductId], [ProductTypeId], [Price], [OriginalPrice]) VALUES (2, 1, CAST(10.0000 AS Decimal(18, 4)), CAST(5.0000 AS Decimal(18, 4)))
GO
INSERT [dbo].[ProductVariants] ([ProductId], [ProductTypeId], [Price], [OriginalPrice]) VALUES (3, 1, CAST(10.0000 AS Decimal(18, 4)), CAST(5.0000 AS Decimal(18, 4)))
GO
INSERT [dbo].[ProductVariants] ([ProductId], [ProductTypeId], [Price], [OriginalPrice]) VALUES (4, 1, CAST(10.0000 AS Decimal(18, 4)), CAST(5.0000 AS Decimal(18, 4)))
GO
INSERT [dbo].[ProductVariants] ([ProductId], [ProductTypeId], [Price], [OriginalPrice]) VALUES (5, 1, CAST(10.0000 AS Decimal(18, 4)), CAST(5.0000 AS Decimal(18, 4)))
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK_Products_Categories_CategoryId] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Categories] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_Products_Categories_CategoryId]
GO
ALTER TABLE [dbo].[ProductVariants]  WITH CHECK ADD  CONSTRAINT [FK_ProductVariants_Products_ProductId] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Products] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ProductVariants] CHECK CONSTRAINT [FK_ProductVariants_Products_ProductId]
GO
ALTER TABLE [dbo].[ProductVariants]  WITH CHECK ADD  CONSTRAINT [FK_ProductVariants_ProductTypes_ProductTypeId] FOREIGN KEY([ProductTypeId])
REFERENCES [dbo].[ProductTypes] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ProductVariants] CHECK CONSTRAINT [FK_ProductVariants_ProductTypes_ProductTypeId]
GO
