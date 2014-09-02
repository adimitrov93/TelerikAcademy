USE [master]
GO
/****** Object:  Database [UniversitiesNoDuplicateChance]    Script Date: 21.08.2014 12:27:13 ******/
CREATE DATABASE [UniversitiesNoDuplicateChance]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'UniversitiesNoDuplicateChance', FILENAME = N'D:\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\UniversitiesNoDuplicateChance.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'UniversitiesNoDuplicateChance_log', FILENAME = N'D:\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\UniversitiesNoDuplicateChance_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [UniversitiesNoDuplicateChance] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [UniversitiesNoDuplicateChance].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [UniversitiesNoDuplicateChance] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [UniversitiesNoDuplicateChance] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [UniversitiesNoDuplicateChance] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [UniversitiesNoDuplicateChance] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [UniversitiesNoDuplicateChance] SET ARITHABORT OFF 
GO
ALTER DATABASE [UniversitiesNoDuplicateChance] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [UniversitiesNoDuplicateChance] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [UniversitiesNoDuplicateChance] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [UniversitiesNoDuplicateChance] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [UniversitiesNoDuplicateChance] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [UniversitiesNoDuplicateChance] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [UniversitiesNoDuplicateChance] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [UniversitiesNoDuplicateChance] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [UniversitiesNoDuplicateChance] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [UniversitiesNoDuplicateChance] SET  DISABLE_BROKER 
GO
ALTER DATABASE [UniversitiesNoDuplicateChance] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [UniversitiesNoDuplicateChance] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [UniversitiesNoDuplicateChance] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [UniversitiesNoDuplicateChance] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [UniversitiesNoDuplicateChance] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [UniversitiesNoDuplicateChance] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [UniversitiesNoDuplicateChance] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [UniversitiesNoDuplicateChance] SET RECOVERY FULL 
GO
ALTER DATABASE [UniversitiesNoDuplicateChance] SET  MULTI_USER 
GO
ALTER DATABASE [UniversitiesNoDuplicateChance] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [UniversitiesNoDuplicateChance] SET DB_CHAINING OFF 
GO
ALTER DATABASE [UniversitiesNoDuplicateChance] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [UniversitiesNoDuplicateChance] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [UniversitiesNoDuplicateChance] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'UniversitiesNoDuplicateChance', N'ON'
GO
USE [UniversitiesNoDuplicateChance]
GO
/****** Object:  Table [dbo].[Cources]    Script Date: 21.08.2014 12:27:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cources](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[DepartmentID] [int] NOT NULL,
	[ProfessorID] [int] NOT NULL,
 CONSTRAINT [PK_Cources] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Cources_Students]    Script Date: 21.08.2014 12:27:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cources_Students](
	[CourseID] [int] NOT NULL,
	[StudentID] [int] NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Departments]    Script Date: 21.08.2014 12:27:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Departments](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[FacultyID] [int] NOT NULL,
 CONSTRAINT [PK_Departments] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Faculties]    Script Date: 21.08.2014 12:27:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Faculties](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Faculties] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[People]    Script Date: 21.08.2014 12:27:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[People](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_People] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Professors]    Script Date: 21.08.2014 12:27:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Professors](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[PersonID] [int] NOT NULL,
	[DepartmentID] [int] NOT NULL,
 CONSTRAINT [PK_Professors] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UK_Professors] UNIQUE NONCLUSTERED 
(
	[PersonID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Professors_Titles]    Script Date: 21.08.2014 12:27:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Professors_Titles](
	[ProfessorID] [int] NOT NULL,
	[TitleID] [int] NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Students]    Script Date: 21.08.2014 12:27:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Students](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[PersonID] [int] NOT NULL,
	[FacultyID] [int] NOT NULL,
 CONSTRAINT [PK_Students] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UK_Students] UNIQUE NONCLUSTERED 
(
	[PersonID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Titles]    Script Date: 21.08.2014 12:27:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Titles](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](20) NOT NULL,
 CONSTRAINT [PK_Titles] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[Cources]  WITH CHECK ADD  CONSTRAINT [FK_Cources_Departments] FOREIGN KEY([DepartmentID])
REFERENCES [dbo].[Departments] ([ID])
GO
ALTER TABLE [dbo].[Cources] CHECK CONSTRAINT [FK_Cources_Departments]
GO
ALTER TABLE [dbo].[Cources]  WITH CHECK ADD  CONSTRAINT [FK_Cources_Professors] FOREIGN KEY([ProfessorID])
REFERENCES [dbo].[Professors] ([ID])
GO
ALTER TABLE [dbo].[Cources] CHECK CONSTRAINT [FK_Cources_Professors]
GO
ALTER TABLE [dbo].[Cources_Students]  WITH CHECK ADD  CONSTRAINT [FK_Cources_Students_Cources] FOREIGN KEY([CourseID])
REFERENCES [dbo].[Cources] ([ID])
GO
ALTER TABLE [dbo].[Cources_Students] CHECK CONSTRAINT [FK_Cources_Students_Cources]
GO
ALTER TABLE [dbo].[Cources_Students]  WITH CHECK ADD  CONSTRAINT [FK_Cources_Students_Students] FOREIGN KEY([StudentID])
REFERENCES [dbo].[Students] ([ID])
GO
ALTER TABLE [dbo].[Cources_Students] CHECK CONSTRAINT [FK_Cources_Students_Students]
GO
ALTER TABLE [dbo].[Departments]  WITH CHECK ADD  CONSTRAINT [FK_Departments_Faculties] FOREIGN KEY([FacultyID])
REFERENCES [dbo].[Faculties] ([ID])
GO
ALTER TABLE [dbo].[Departments] CHECK CONSTRAINT [FK_Departments_Faculties]
GO
ALTER TABLE [dbo].[Professors]  WITH CHECK ADD  CONSTRAINT [FK_Professors_Departments] FOREIGN KEY([DepartmentID])
REFERENCES [dbo].[Departments] ([ID])
GO
ALTER TABLE [dbo].[Professors] CHECK CONSTRAINT [FK_Professors_Departments]
GO
ALTER TABLE [dbo].[Professors]  WITH CHECK ADD  CONSTRAINT [FK_Professors_People] FOREIGN KEY([PersonID])
REFERENCES [dbo].[People] ([ID])
GO
ALTER TABLE [dbo].[Professors] CHECK CONSTRAINT [FK_Professors_People]
GO
ALTER TABLE [dbo].[Professors_Titles]  WITH CHECK ADD  CONSTRAINT [FK_Professors_Titles_Professors] FOREIGN KEY([ProfessorID])
REFERENCES [dbo].[Professors] ([ID])
GO
ALTER TABLE [dbo].[Professors_Titles] CHECK CONSTRAINT [FK_Professors_Titles_Professors]
GO
ALTER TABLE [dbo].[Professors_Titles]  WITH CHECK ADD  CONSTRAINT [FK_Professors_Titles_Titles] FOREIGN KEY([TitleID])
REFERENCES [dbo].[Titles] ([ID])
GO
ALTER TABLE [dbo].[Professors_Titles] CHECK CONSTRAINT [FK_Professors_Titles_Titles]
GO
ALTER TABLE [dbo].[Students]  WITH CHECK ADD  CONSTRAINT [FK_Students_Faculties] FOREIGN KEY([FacultyID])
REFERENCES [dbo].[Faculties] ([ID])
GO
ALTER TABLE [dbo].[Students] CHECK CONSTRAINT [FK_Students_Faculties]
GO
ALTER TABLE [dbo].[Students]  WITH CHECK ADD  CONSTRAINT [FK_Students_People] FOREIGN KEY([PersonID])
REFERENCES [dbo].[People] ([ID])
GO
ALTER TABLE [dbo].[Students] CHECK CONSTRAINT [FK_Students_People]
GO
USE [master]
GO
ALTER DATABASE [UniversitiesNoDuplicateChance] SET  READ_WRITE 
GO
