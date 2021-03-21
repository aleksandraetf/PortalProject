USE [master]
GO
/****** Object:  Database [NewsPortal]    Script Date: 21-Mar-21 22:30:32 ******/
CREATE DATABASE [NewsPortal]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'NewsPortal', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\NewsPortal.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'NewsPortal_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\NewsPortal_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [NewsPortal] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [NewsPortal].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [NewsPortal] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [NewsPortal] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [NewsPortal] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [NewsPortal] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [NewsPortal] SET ARITHABORT OFF 
GO
ALTER DATABASE [NewsPortal] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [NewsPortal] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [NewsPortal] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [NewsPortal] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [NewsPortal] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [NewsPortal] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [NewsPortal] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [NewsPortal] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [NewsPortal] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [NewsPortal] SET  ENABLE_BROKER 
GO
ALTER DATABASE [NewsPortal] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [NewsPortal] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [NewsPortal] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [NewsPortal] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [NewsPortal] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [NewsPortal] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [NewsPortal] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [NewsPortal] SET RECOVERY FULL 
GO
ALTER DATABASE [NewsPortal] SET  MULTI_USER 
GO
ALTER DATABASE [NewsPortal] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [NewsPortal] SET DB_CHAINING OFF 
GO
ALTER DATABASE [NewsPortal] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [NewsPortal] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [NewsPortal] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'NewsPortal', N'ON'
GO
ALTER DATABASE [NewsPortal] SET QUERY_STORE = OFF
GO
USE [NewsPortal]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 21-Mar-21 22:30:32 ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[News]    Script Date: 21-Mar-21 22:30:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[News](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[Text] [nvarchar](max) NULL,
	[Date] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_News] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 21-Mar-21 22:30:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](max) NULL,
	[LastName] [nvarchar](max) NULL,
	[Username] [nvarchar](max) NULL,
	[Password] [nvarchar](max) NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210319193340_InitMigration', N'3.1.3')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210321143630_UserPassword', N'3.1.3')
GO
SET IDENTITY_INSERT [dbo].[News] ON 

INSERT [dbo].[News] ([Id], [UserId], [Text], [Date]) VALUES (1, 2, N'NOva', CAST(N'2021-03-21T22:29:01.8970771' AS DateTime2))
INSERT [dbo].[News] ([Id], [UserId], [Text], [Date]) VALUES (2, 1, N'Aleksandrina Edit', CAST(N'2021-03-21T18:57:39.6006316' AS DateTime2))
INSERT [dbo].[News] ([Id], [UserId], [Text], [Date]) VALUES (3, 2, N'Nova objava - EDIT', CAST(N'2021-03-21T18:48:46.9232258' AS DateTime2))
INSERT [dbo].[News] ([Id], [UserId], [Text], [Date]) VALUES (4, 2, N'Nova novost - EDIT', CAST(N'2021-03-21T18:54:30.4086338' AS DateTime2))
INSERT [dbo].[News] ([Id], [UserId], [Text], [Date]) VALUES (5, 2, N'promenjen naslov2', CAST(N'2021-03-21T18:29:45.1968662' AS DateTime2))
INSERT [dbo].[News] ([Id], [UserId], [Text], [Date]) VALUES (6, 2, N'Nova', CAST(N'2021-03-21T18:50:00.2683638' AS DateTime2))
INSERT [dbo].[News] ([Id], [UserId], [Text], [Date]) VALUES (7, 2, N'45', CAST(N'2021-03-21T18:51:44.2187676' AS DateTime2))
INSERT [dbo].[News] ([Id], [UserId], [Text], [Date]) VALUES (8, 2, N'1', CAST(N'2021-03-21T18:54:23.0687453' AS DateTime2))
INSERT [dbo].[News] ([Id], [UserId], [Text], [Date]) VALUES (9, 1, N'12', CAST(N'2021-03-21T18:57:58.1516628' AS DateTime2))
INSERT [dbo].[News] ([Id], [UserId], [Text], [Date]) VALUES (10, 2, N'nova skroz', CAST(N'2021-03-21T22:29:06.2429711' AS DateTime2))
SET IDENTITY_INSERT [dbo].[News] OFF
GO
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([Id], [FirstName], [LastName], [Username], [Password]) VALUES (1, N'Aleksandra', N'Milekic', N'aleksandra', N'123')
INSERT [dbo].[User] ([Id], [FirstName], [LastName], [Username], [Password]) VALUES (2, N'Marko', N'Markovic', N'marko', N'marko')
SET IDENTITY_INSERT [dbo].[User] OFF
GO
/****** Object:  Index [IX_News_UserId]    Script Date: 21-Mar-21 22:30:33 ******/
CREATE NONCLUSTERED INDEX [IX_News_UserId] ON [dbo].[News]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[News]  WITH CHECK ADD  CONSTRAINT [FK_News_User_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[News] CHECK CONSTRAINT [FK_News_User_UserId]
GO
USE [master]
GO
ALTER DATABASE [NewsPortal] SET  READ_WRITE 
GO
