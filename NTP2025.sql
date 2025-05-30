USE [master]
GO
/****** Object:  Database [NYP2025]    Script Date: 29.05.2025 21:33:26 ******/
CREATE DATABASE [NYP2025]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'NYP2025', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER02\MSSQL\DATA\NYP2025.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'NYP2025_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER02\MSSQL\DATA\NYP2025_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [NYP2025] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [NYP2025].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [NYP2025] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [NYP2025] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [NYP2025] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [NYP2025] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [NYP2025] SET ARITHABORT OFF 
GO
ALTER DATABASE [NYP2025] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [NYP2025] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [NYP2025] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [NYP2025] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [NYP2025] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [NYP2025] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [NYP2025] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [NYP2025] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [NYP2025] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [NYP2025] SET  ENABLE_BROKER 
GO
ALTER DATABASE [NYP2025] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [NYP2025] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [NYP2025] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [NYP2025] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [NYP2025] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [NYP2025] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [NYP2025] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [NYP2025] SET RECOVERY FULL 
GO
ALTER DATABASE [NYP2025] SET  MULTI_USER 
GO
ALTER DATABASE [NYP2025] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [NYP2025] SET DB_CHAINING OFF 
GO
ALTER DATABASE [NYP2025] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [NYP2025] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [NYP2025] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [NYP2025] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'NYP2025', N'ON'
GO
ALTER DATABASE [NYP2025] SET QUERY_STORE = ON
GO
ALTER DATABASE [NYP2025] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [NYP2025]
GO
/****** Object:  Table [dbo].[Lessons_Info]    Script Date: 29.05.2025 21:33:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Lessons_Info](
	[lesson_id] [int] IDENTITY(1,1) NOT NULL,
	[matematik] [int] NULL,
	[fizik] [int] NULL,
	[kimya] [int] NULL,
	[biyoloji] [int] NULL,
	[student_no] [int] NULL,
	[updated_at] [datetime] NULL,
	[created_at] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[lesson_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Personel_Info]    Script Date: 29.05.2025 21:33:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Personel_Info](
	[personel_id] [int] NOT NULL,
	[personel_name] [varchar](20) NOT NULL,
	[personel_surname] [varchar](25) NOT NULL,
	[personel_tc] [varchar](20) NOT NULL,
	[personel_username] [varchar](20) NOT NULL,
	[personel_parola] [varchar](20) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[personel_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Student_Info]    Script Date: 29.05.2025 21:33:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Student_Info](
	[student_no] [int] NOT NULL,
	[student_name] [nvarchar](50) NULL,
	[student_surname] [nvarchar](50) NULL,
	[student_tc] [nvarchar](11) NULL,
	[student_veliNo] [nvarchar](15) NULL,
	[student_class] [nvarchar](15) NULL,
	[student_sube] [nvarchar](15) NULL,
	[created_at] [datetime] NULL,
	[updated_at] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[student_no] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Lessons_Info] ON 

INSERT [dbo].[Lessons_Info] ([lesson_id], [matematik], [fizik], [kimya], [biyoloji], [student_no], [updated_at], [created_at]) VALUES (2002, 96, 70, 77, 71, 1, CAST(N'2025-05-27T23:30:25.530' AS DateTime), CAST(N'2025-05-27T23:30:06.890' AS DateTime))
INSERT [dbo].[Lessons_Info] ([lesson_id], [matematik], [fizik], [kimya], [biyoloji], [student_no], [updated_at], [created_at]) VALUES (2003, 90, 96, 88, 96, 2, CAST(N'2025-05-27T23:40:37.117' AS DateTime), CAST(N'2025-05-27T23:40:25.067' AS DateTime))
SET IDENTITY_INSERT [dbo].[Lessons_Info] OFF
GO
INSERT [dbo].[Student_Info] ([student_no], [student_name], [student_surname], [student_tc], [student_veliNo], [student_class], [student_sube], [created_at], [updated_at]) VALUES (1, N'Hakan', N'Karadeniz', N'11111111111', N'05111111112', N'11', N'B', CAST(N'2025-05-27T23:15:55.123' AS DateTime), CAST(N'2025-05-27T23:16:10.143' AS DateTime))
INSERT [dbo].[Student_Info] ([student_no], [student_name], [student_surname], [student_tc], [student_veliNo], [student_class], [student_sube], [created_at], [updated_at]) VALUES (2, N'Şebnem', N'Ferah', N'22222222222', N'05222222222', N'12', N'A', CAST(N'2025-05-27T23:17:01.090' AS DateTime), NULL)
INSERT [dbo].[Student_Info] ([student_no], [student_name], [student_surname], [student_tc], [student_veliNo], [student_class], [student_sube], [created_at], [updated_at]) VALUES (3, N'Onur Recep', N'Kıvrak', N'33333333333', N'05333333333', N'12', N'B', CAST(N'2025-05-27T23:18:00.303' AS DateTime), NULL)
INSERT [dbo].[Student_Info] ([student_no], [student_name], [student_surname], [student_tc], [student_veliNo], [student_class], [student_sube], [created_at], [updated_at]) VALUES (4, N'Uğurcan', N'Çakır', N'44444444444', N'05444444444', N'10', N'A', CAST(N'2025-05-27T23:18:29.853' AS DateTime), NULL)
INSERT [dbo].[Student_Info] ([student_no], [student_name], [student_surname], [student_tc], [student_veliNo], [student_class], [student_sube], [created_at], [updated_at]) VALUES (5, N'Arda', N'Güler', N'55555555555', N'05555555555', N'9', N'B', CAST(N'2025-05-27T23:19:30.997' AS DateTime), NULL)
GO
ALTER TABLE [dbo].[Lessons_Info]  WITH CHECK ADD  CONSTRAINT [FK_Courses_Students] FOREIGN KEY([student_no])
REFERENCES [dbo].[Student_Info] ([student_no])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Lessons_Info] CHECK CONSTRAINT [FK_Courses_Students]
GO
USE [master]
GO
ALTER DATABASE [NYP2025] SET  READ_WRITE 
GO
