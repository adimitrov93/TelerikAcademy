USE [master]
GO
/****** Object:  Database [DictionaryNoDuplicateChance]    Script Date: 24.08.2014 08:16:47 ******/
CREATE DATABASE [DictionaryNoDuplicateChance]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'DictionaryNoDuplicateChance', FILENAME = N'D:\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\DictionaryNoDuplicateChance.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'DictionaryNoDuplicateChance_log', FILENAME = N'D:\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\DictionaryNoDuplicateChance_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [DictionaryNoDuplicateChance] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DictionaryNoDuplicateChance].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [DictionaryNoDuplicateChance] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [DictionaryNoDuplicateChance] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [DictionaryNoDuplicateChance] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [DictionaryNoDuplicateChance] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [DictionaryNoDuplicateChance] SET ARITHABORT OFF 
GO
ALTER DATABASE [DictionaryNoDuplicateChance] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [DictionaryNoDuplicateChance] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [DictionaryNoDuplicateChance] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [DictionaryNoDuplicateChance] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [DictionaryNoDuplicateChance] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [DictionaryNoDuplicateChance] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [DictionaryNoDuplicateChance] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [DictionaryNoDuplicateChance] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [DictionaryNoDuplicateChance] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [DictionaryNoDuplicateChance] SET  DISABLE_BROKER 
GO
ALTER DATABASE [DictionaryNoDuplicateChance] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [DictionaryNoDuplicateChance] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [DictionaryNoDuplicateChance] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [DictionaryNoDuplicateChance] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [DictionaryNoDuplicateChance] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [DictionaryNoDuplicateChance] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [DictionaryNoDuplicateChance] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [DictionaryNoDuplicateChance] SET RECOVERY FULL 
GO
ALTER DATABASE [DictionaryNoDuplicateChance] SET  MULTI_USER 
GO
ALTER DATABASE [DictionaryNoDuplicateChance] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [DictionaryNoDuplicateChance] SET DB_CHAINING OFF 
GO
ALTER DATABASE [DictionaryNoDuplicateChance] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [DictionaryNoDuplicateChance] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [DictionaryNoDuplicateChance] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'DictionaryNoDuplicateChance', N'ON'
GO
USE [DictionaryNoDuplicateChance]
GO
/****** Object:  Table [dbo].[Chains]    Script Date: 24.08.2014 08:16:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Chains](
	[HypernymID] [int] NOT NULL,
	[HyponymID] [int] NOT NULL,
 CONSTRAINT [PK_Chains] PRIMARY KEY CLUSTERED 
(
	[HypernymID] ASC,
	[HyponymID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Explanations]    Script Date: 24.08.2014 08:16:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Explanations](
	[WordID] [int] NOT NULL,
	[ExplanationsText] [nvarchar](200) NOT NULL,
	[LanguageID] [int] NOT NULL,
 CONSTRAINT [PK_Explanations] PRIMARY KEY CLUSTERED 
(
	[WordID] ASC,
	[LanguageID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Languages]    Script Date: 24.08.2014 08:16:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Languages](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Language] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Languages] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PartsOfSpeech]    Script Date: 24.08.2014 08:16:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PartsOfSpeech](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[PartOfSpeech] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_PartsOfSpeech] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Synonyms]    Script Date: 24.08.2014 08:16:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Synonyms](
	[WordID] [int] NOT NULL,
	[SynonymID] [int] NOT NULL,
 CONSTRAINT [PK_Synonyms] PRIMARY KEY CLUSTERED 
(
	[WordID] ASC,
	[SynonymID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Translations]    Script Date: 24.08.2014 08:16:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Translations](
	[WordID] [int] NOT NULL,
	[TranslationID] [int] NOT NULL,
 CONSTRAINT [PK_Translations] PRIMARY KEY CLUSTERED 
(
	[WordID] ASC,
	[TranslationID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Words]    Script Date: 24.08.2014 08:16:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Words](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Word] [nvarchar](50) NOT NULL,
	[LanguageID] [int] NOT NULL,
	[AntonymID] [int] NULL,
	[PartOfSpeechID] [int] NULL,
 CONSTRAINT [PK_Words] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[Chains]  WITH CHECK ADD  CONSTRAINT [FK_Chains_Words] FOREIGN KEY([HypernymID])
REFERENCES [dbo].[Words] ([ID])
GO
ALTER TABLE [dbo].[Chains] CHECK CONSTRAINT [FK_Chains_Words]
GO
ALTER TABLE [dbo].[Chains]  WITH CHECK ADD  CONSTRAINT [FK_Chains_Words1] FOREIGN KEY([HyponymID])
REFERENCES [dbo].[Words] ([ID])
GO
ALTER TABLE [dbo].[Chains] CHECK CONSTRAINT [FK_Chains_Words1]
GO
ALTER TABLE [dbo].[Explanations]  WITH CHECK ADD  CONSTRAINT [FK_Explanations_Languages] FOREIGN KEY([LanguageID])
REFERENCES [dbo].[Languages] ([ID])
GO
ALTER TABLE [dbo].[Explanations] CHECK CONSTRAINT [FK_Explanations_Languages]
GO
ALTER TABLE [dbo].[Explanations]  WITH CHECK ADD  CONSTRAINT [FK_Explanations_Words] FOREIGN KEY([WordID])
REFERENCES [dbo].[Words] ([ID])
GO
ALTER TABLE [dbo].[Explanations] CHECK CONSTRAINT [FK_Explanations_Words]
GO
ALTER TABLE [dbo].[Synonyms]  WITH CHECK ADD  CONSTRAINT [FK_Synonyms_Words] FOREIGN KEY([WordID])
REFERENCES [dbo].[Words] ([ID])
GO
ALTER TABLE [dbo].[Synonyms] CHECK CONSTRAINT [FK_Synonyms_Words]
GO
ALTER TABLE [dbo].[Synonyms]  WITH CHECK ADD  CONSTRAINT [FK_Synonyms_Words1] FOREIGN KEY([SynonymID])
REFERENCES [dbo].[Words] ([ID])
GO
ALTER TABLE [dbo].[Synonyms] CHECK CONSTRAINT [FK_Synonyms_Words1]
GO
ALTER TABLE [dbo].[Translations]  WITH CHECK ADD  CONSTRAINT [FK_Translations_Words] FOREIGN KEY([WordID])
REFERENCES [dbo].[Words] ([ID])
GO
ALTER TABLE [dbo].[Translations] CHECK CONSTRAINT [FK_Translations_Words]
GO
ALTER TABLE [dbo].[Translations]  WITH CHECK ADD  CONSTRAINT [FK_Translations_Words1] FOREIGN KEY([TranslationID])
REFERENCES [dbo].[Words] ([ID])
GO
ALTER TABLE [dbo].[Translations] CHECK CONSTRAINT [FK_Translations_Words1]
GO
ALTER TABLE [dbo].[Words]  WITH CHECK ADD  CONSTRAINT [FK_Words_Languages] FOREIGN KEY([LanguageID])
REFERENCES [dbo].[Languages] ([ID])
GO
ALTER TABLE [dbo].[Words] CHECK CONSTRAINT [FK_Words_Languages]
GO
ALTER TABLE [dbo].[Words]  WITH CHECK ADD  CONSTRAINT [FK_Words_PartsOfSpeech] FOREIGN KEY([PartOfSpeechID])
REFERENCES [dbo].[PartsOfSpeech] ([ID])
GO
ALTER TABLE [dbo].[Words] CHECK CONSTRAINT [FK_Words_PartsOfSpeech]
GO
ALTER TABLE [dbo].[Words]  WITH CHECK ADD  CONSTRAINT [FK_Words_Words] FOREIGN KEY([AntonymID])
REFERENCES [dbo].[Words] ([ID])
GO
ALTER TABLE [dbo].[Words] CHECK CONSTRAINT [FK_Words_Words]
GO
USE [master]
GO
ALTER DATABASE [DictionaryNoDuplicateChance] SET  READ_WRITE 
GO
