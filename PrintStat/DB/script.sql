USE [master]
GO
/****** Object:  Database [PrintStat]    Script Date: 02.11.2014 1:34:25 ******/
CREATE DATABASE [PrintStat]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'PrintStat', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\PrintStat.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'PrintStat_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\PrintStat_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [PrintStat] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [PrintStat].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [PrintStat] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [PrintStat] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [PrintStat] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [PrintStat] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [PrintStat] SET ARITHABORT OFF 
GO
ALTER DATABASE [PrintStat] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [PrintStat] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [PrintStat] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [PrintStat] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [PrintStat] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [PrintStat] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [PrintStat] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [PrintStat] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [PrintStat] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [PrintStat] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [PrintStat] SET  DISABLE_BROKER 
GO
ALTER DATABASE [PrintStat] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [PrintStat] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [PrintStat] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [PrintStat] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [PrintStat] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [PrintStat] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [PrintStat] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [PrintStat] SET RECOVERY FULL 
GO
ALTER DATABASE [PrintStat] SET  MULTI_USER 
GO
ALTER DATABASE [PrintStat] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [PrintStat] SET DB_CHAINING OFF 
GO
ALTER DATABASE [PrintStat] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [PrintStat] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
EXEC sys.sp_db_vardecimal_storage_format N'PrintStat', N'ON'
GO
USE [PrintStat]
GO
/****** Object:  Table [dbo].[Application]    Script Date: 02.11.2014 1:34:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Application](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Application] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Cartridge]    Script Date: 02.11.2014 1:34:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cartridge](
	[ID] [int] NOT NULL,
	[DeviceID] [int] NOT NULL,
	[ColorID] [int] NOT NULL,
	[Name] [nvarchar](50) NULL,
	[ShortName] [nvarchar](5) NULL,
 CONSTRAINT [PK_Cartridge] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CartridgeColor]    Script Date: 02.11.2014 1:34:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CartridgeColor](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[ShortName] [varchar](2) NOT NULL,
 CONSTRAINT [PK_CartridgeColor] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CartridgeDevice]    Script Date: 02.11.2014 1:34:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CartridgeDevice](
	[CartridgeID] [int] NOT NULL,
	[DeviceID] [int] NOT NULL,
	[CurAmountOfInk] [int] NULL,
 CONSTRAINT [PK_CartridgeDevice] PRIMARY KEY CLUSTERED 
(
	[DeviceID] ASC,
	[CartridgeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Components]    Script Date: 02.11.2014 1:34:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Components](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Type] [varchar](50) NOT NULL,
	[Endurance] [int] NULL,
 CONSTRAINT [PK_Components] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Department]    Script Date: 02.11.2014 1:34:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Department](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[ShortName] [varchar](20) NOT NULL,
 CONSTRAINT [PK_Department] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Device]    Script Date: 02.11.2014 1:34:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Device](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[ModelID] [int] NOT NULL,
	[PrintKindID] [int] NOT NULL,
	[SearchString] [nvarchar](50) NOT NULL,
	[InvNumber] [nvarchar](10) NULL,
	[StatisticsSupported] [bit] NOT NULL,
 CONSTRAINT [PK_Device] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[DeviceComponents]    Script Date: 02.11.2014 1:34:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DeviceComponents](
	[ComponentsID] [int] NOT NULL,
	[DeviceID] [int] NOT NULL,
	[CurEndurance] [int] NULL,
 CONSTRAINT [PK_DeviceComponents] PRIMARY KEY CLUSTERED 
(
	[DeviceID] ASC,
	[ComponentsID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[DeviceType]    Script Date: 02.11.2014 1:34:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DeviceType](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
 CONSTRAINT [PK_DeviceType] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Employee]    Script Date: 02.11.2014 1:34:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employee](
	[TabNumber] [nvarchar](50) NOT NULL,
	[Name] [nvarchar](150) NOT NULL,
	[DepartmentID] [int] NOT NULL,
 CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED 
(
	[TabNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ExpForJob]    Script Date: 02.11.2014 1:34:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ExpForJob](
	[JobID] [int] NOT NULL,
	[CartridgeID] [int] NOT NULL,
	[Amount] [int] NULL,
 CONSTRAINT [PK_ExpForJob] PRIMARY KEY CLUSTERED 
(
	[JobID] ASC,
	[CartridgeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Job]    Script Date: 02.11.2014 1:34:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Job](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](2000) NOT NULL,
	[DeviceID] [int] NOT NULL,
	[ApplicationID] [int] NOT NULL,
	[Duration] [int] NULL,
	[StartTime] [datetime] NULL,
	[EndTime] [datetime] NULL,
	[UserTabNumber] [nvarchar](50) NOT NULL,
	[Pages] [int] NULL,
	[Copies] [int] NOT NULL,
	[Width_cm] [numeric](6, 2) NOT NULL,
	[Height_cm] [numeric](6, 2) NOT NULL,
	[Width_px] [int] NULL,
	[Height_px] [int] NULL,
	[SizePaperID] [int] NULL,
	[AuthorTabNumber] [nvarchar](50) NULL,
	[Size_kb] [int] NULL,
	[IP] [nvarchar](16) NULL,
	[ComputerName] [nvarchar](50) NULL,
	[IsManual] [bit] NOT NULL,
	[ParseDoc] [varbinary](max) NULL,
	[ExpForJobID] [int] NULL,
	[PaperTypeID] [int] NULL,
 CONSTRAINT [PK_Job] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Manufacturer]    Script Date: 02.11.2014 1:34:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING OFF
GO
CREATE TABLE [dbo].[Manufacturer](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](255) NOT NULL,
 CONSTRAINT [PK_Manufacturer] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Model]    Script Date: 02.11.2014 1:34:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING OFF
GO
CREATE TABLE [dbo].[Model](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](30) NOT NULL,
	[ManufacturerID] [int] NULL,
	[DeviceTypeID] [int] NULL,
	[PrintKindID] [int] NULL,
 CONSTRAINT [PK_Model] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ModelTag]    Script Date: 02.11.2014 1:34:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ModelTag](
	[TagID] [int] NOT NULL,
	[ModelID] [int] NOT NULL,
 CONSTRAINT [PK_ModelTag] PRIMARY KEY CLUSTERED 
(
	[TagID] ASC,
	[ModelID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PaperType]    Script Date: 02.11.2014 1:34:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PaperType](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[ModelID] [int] NULL,
 CONSTRAINT [PK_PaperType] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [IX_PaperType] UNIQUE NONCLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PrintKind]    Script Date: 02.11.2014 1:34:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PrintKind](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
 CONSTRAINT [PK_PrintKind] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Profile]    Script Date: 02.11.2014 1:34:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING OFF
GO
CREATE TABLE [dbo].[Profile](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](30) NULL,
 CONSTRAINT [PK_Profile] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Settings]    Script Date: 02.11.2014 1:34:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Settings](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ParameterName] [varchar](50) NULL,
	[UserTabNumber] [nvarchar](50) NULL,
 CONSTRAINT [PK_Settings] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[SettingValue]    Script Date: 02.11.2014 1:34:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING OFF
GO
CREATE TABLE [dbo].[SettingValue](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Value] [varchar](50) NULL,
	[SettingsID] [int] NULL,
	[ProfileID] [int] NULL,
 CONSTRAINT [PK_SettingValue] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[SizePaper]    Script Date: 02.11.2014 1:34:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SizePaper](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Width_cm] [numeric](6, 2) NULL,
	[Height_cm] [numeric](6, 2) NULL,
 CONSTRAINT [PK_SizePaper] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SNMP]    Script Date: 02.11.2014 1:34:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SNMP](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Date] [date] NOT NULL,
	[Value] [int] NULL,
	[TagID] [int] NULL,
	[DeviceID] [int] NULL,
 CONSTRAINT [PK_SNMP] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SupportSize]    Script Date: 02.11.2014 1:34:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SupportSize](
	[ModelID] [int] NOT NULL,
	[SizePaperID] [int] NOT NULL,
 CONSTRAINT [PK_SupportSize] PRIMARY KEY CLUSTERED 
(
	[SizePaperID] ASC,
	[ModelID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Tag]    Script Date: 02.11.2014 1:34:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING OFF
GO
CREATE TABLE [dbo].[Tag](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Tag] [varchar](30) NOT NULL,
	[Name] [varchar](50) NULL,
	[TagTypeID] [int] NULL,
 CONSTRAINT [PK_Tag] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TagType]    Script Date: 02.11.2014 1:34:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING OFF
GO
CREATE TABLE [dbo].[TagType](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Type] [varchar](255) NOT NULL,
 CONSTRAINT [PK_TagType] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[Job] ADD  CONSTRAINT [DF_Job_IsManual]  DEFAULT ((0)) FOR [IsManual]
GO
ALTER TABLE [dbo].[Cartridge]  WITH CHECK ADD  CONSTRAINT [FK_Cartridge_CartridgeColor] FOREIGN KEY([ColorID])
REFERENCES [dbo].[CartridgeColor] ([ID])
GO
ALTER TABLE [dbo].[Cartridge] CHECK CONSTRAINT [FK_Cartridge_CartridgeColor]
GO
ALTER TABLE [dbo].[CartridgeDevice]  WITH CHECK ADD  CONSTRAINT [FK_CartridgeDevice_Cartridge] FOREIGN KEY([CartridgeID])
REFERENCES [dbo].[Cartridge] ([ID])
GO
ALTER TABLE [dbo].[CartridgeDevice] CHECK CONSTRAINT [FK_CartridgeDevice_Cartridge]
GO
ALTER TABLE [dbo].[CartridgeDevice]  WITH CHECK ADD  CONSTRAINT [FK_CartridgeDevice_Device] FOREIGN KEY([DeviceID])
REFERENCES [dbo].[Device] ([ID])
GO
ALTER TABLE [dbo].[CartridgeDevice] CHECK CONSTRAINT [FK_CartridgeDevice_Device]
GO
ALTER TABLE [dbo].[Device]  WITH CHECK ADD  CONSTRAINT [FK_Device_Model] FOREIGN KEY([ModelID])
REFERENCES [dbo].[Model] ([ID])
GO
ALTER TABLE [dbo].[Device] CHECK CONSTRAINT [FK_Device_Model]
GO
ALTER TABLE [dbo].[Device]  WITH CHECK ADD  CONSTRAINT [FK_Device_PrintKind] FOREIGN KEY([PrintKindID])
REFERENCES [dbo].[PrintKind] ([ID])
GO
ALTER TABLE [dbo].[Device] CHECK CONSTRAINT [FK_Device_PrintKind]
GO
ALTER TABLE [dbo].[Device]  WITH CHECK ADD  CONSTRAINT [FK_Device_PrintKind1] FOREIGN KEY([PrintKindID])
REFERENCES [dbo].[PrintKind] ([ID])
GO
ALTER TABLE [dbo].[Device] CHECK CONSTRAINT [FK_Device_PrintKind1]
GO
ALTER TABLE [dbo].[DeviceComponents]  WITH CHECK ADD  CONSTRAINT [FK_DeviceComponents_Components] FOREIGN KEY([ComponentsID])
REFERENCES [dbo].[Components] ([ID])
GO
ALTER TABLE [dbo].[DeviceComponents] CHECK CONSTRAINT [FK_DeviceComponents_Components]
GO
ALTER TABLE [dbo].[DeviceComponents]  WITH CHECK ADD  CONSTRAINT [FK_DeviceComponents_Device] FOREIGN KEY([DeviceID])
REFERENCES [dbo].[Device] ([ID])
GO
ALTER TABLE [dbo].[DeviceComponents] CHECK CONSTRAINT [FK_DeviceComponents_Device]
GO
ALTER TABLE [dbo].[Employee]  WITH CHECK ADD  CONSTRAINT [FK_Employee_Department] FOREIGN KEY([DepartmentID])
REFERENCES [dbo].[Department] ([ID])
GO
ALTER TABLE [dbo].[Employee] CHECK CONSTRAINT [FK_Employee_Department]
GO
ALTER TABLE [dbo].[ExpForJob]  WITH CHECK ADD  CONSTRAINT [FK_ExpForJob_Cartridge] FOREIGN KEY([CartridgeID])
REFERENCES [dbo].[Cartridge] ([ID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ExpForJob] CHECK CONSTRAINT [FK_ExpForJob_Cartridge]
GO
ALTER TABLE [dbo].[ExpForJob]  WITH CHECK ADD  CONSTRAINT [FK_ExpForJob_Job] FOREIGN KEY([JobID])
REFERENCES [dbo].[Job] ([ID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ExpForJob] CHECK CONSTRAINT [FK_ExpForJob_Job]
GO
ALTER TABLE [dbo].[Job]  WITH CHECK ADD  CONSTRAINT [FK_Job_Application] FOREIGN KEY([ApplicationID])
REFERENCES [dbo].[Application] ([ID])
GO
ALTER TABLE [dbo].[Job] CHECK CONSTRAINT [FK_Job_Application]
GO
ALTER TABLE [dbo].[Job]  WITH CHECK ADD  CONSTRAINT [FK_Job_Author] FOREIGN KEY([AuthorTabNumber])
REFERENCES [dbo].[Employee] ([TabNumber])
GO
ALTER TABLE [dbo].[Job] CHECK CONSTRAINT [FK_Job_Author]
GO
ALTER TABLE [dbo].[Job]  WITH CHECK ADD  CONSTRAINT [FK_Job_Device] FOREIGN KEY([DeviceID])
REFERENCES [dbo].[Device] ([ID])
GO
ALTER TABLE [dbo].[Job] CHECK CONSTRAINT [FK_Job_Device]
GO
ALTER TABLE [dbo].[Job]  WITH CHECK ADD  CONSTRAINT [FK_Job_Employee] FOREIGN KEY([UserTabNumber])
REFERENCES [dbo].[Employee] ([TabNumber])
GO
ALTER TABLE [dbo].[Job] CHECK CONSTRAINT [FK_Job_Employee]
GO
ALTER TABLE [dbo].[Job]  WITH CHECK ADD  CONSTRAINT [FK_Job_PaperType] FOREIGN KEY([PaperTypeID])
REFERENCES [dbo].[PaperType] ([ID])
GO
ALTER TABLE [dbo].[Job] CHECK CONSTRAINT [FK_Job_PaperType]
GO
ALTER TABLE [dbo].[Job]  WITH CHECK ADD  CONSTRAINT [FK_Job_SizePaper] FOREIGN KEY([SizePaperID])
REFERENCES [dbo].[SizePaper] ([ID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Job] CHECK CONSTRAINT [FK_Job_SizePaper]
GO
ALTER TABLE [dbo].[Model]  WITH CHECK ADD  CONSTRAINT [FK_Model_DeviceType] FOREIGN KEY([DeviceTypeID])
REFERENCES [dbo].[DeviceType] ([ID])
GO
ALTER TABLE [dbo].[Model] CHECK CONSTRAINT [FK_Model_DeviceType]
GO
ALTER TABLE [dbo].[Model]  WITH CHECK ADD  CONSTRAINT [FK_Model_Manufacturer] FOREIGN KEY([ManufacturerID])
REFERENCES [dbo].[Manufacturer] ([ID])
GO
ALTER TABLE [dbo].[Model] CHECK CONSTRAINT [FK_Model_Manufacturer]
GO
ALTER TABLE [dbo].[Model]  WITH CHECK ADD  CONSTRAINT [FK_Model_PrintKind] FOREIGN KEY([PrintKindID])
REFERENCES [dbo].[PrintKind] ([ID])
GO
ALTER TABLE [dbo].[Model] CHECK CONSTRAINT [FK_Model_PrintKind]
GO
ALTER TABLE [dbo].[ModelTag]  WITH CHECK ADD  CONSTRAINT [FK_ModelTag_Model] FOREIGN KEY([ModelID])
REFERENCES [dbo].[Model] ([ID])
GO
ALTER TABLE [dbo].[ModelTag] CHECK CONSTRAINT [FK_ModelTag_Model]
GO
ALTER TABLE [dbo].[ModelTag]  WITH CHECK ADD  CONSTRAINT [FK_ModelTag_Tag] FOREIGN KEY([TagID])
REFERENCES [dbo].[Tag] ([ID])
GO
ALTER TABLE [dbo].[ModelTag] CHECK CONSTRAINT [FK_ModelTag_Tag]
GO
ALTER TABLE [dbo].[PaperType]  WITH CHECK ADD  CONSTRAINT [FK_PaperType_Model] FOREIGN KEY([ModelID])
REFERENCES [dbo].[Model] ([ID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PaperType] CHECK CONSTRAINT [FK_PaperType_Model]
GO
ALTER TABLE [dbo].[Settings]  WITH CHECK ADD  CONSTRAINT [FK_Settings_Employee] FOREIGN KEY([UserTabNumber])
REFERENCES [dbo].[Employee] ([TabNumber])
GO
ALTER TABLE [dbo].[Settings] CHECK CONSTRAINT [FK_Settings_Employee]
GO
ALTER TABLE [dbo].[SettingValue]  WITH CHECK ADD  CONSTRAINT [FK_SettingValue_Profile] FOREIGN KEY([ProfileID])
REFERENCES [dbo].[Profile] ([ID])
GO
ALTER TABLE [dbo].[SettingValue] CHECK CONSTRAINT [FK_SettingValue_Profile]
GO
ALTER TABLE [dbo].[SettingValue]  WITH CHECK ADD  CONSTRAINT [FK_SettingValue_Settings] FOREIGN KEY([SettingsID])
REFERENCES [dbo].[Settings] ([ID])
GO
ALTER TABLE [dbo].[SettingValue] CHECK CONSTRAINT [FK_SettingValue_Settings]
GO
ALTER TABLE [dbo].[SNMP]  WITH CHECK ADD  CONSTRAINT [FK_SNMP_Device] FOREIGN KEY([DeviceID])
REFERENCES [dbo].[Device] ([ID])
GO
ALTER TABLE [dbo].[SNMP] CHECK CONSTRAINT [FK_SNMP_Device]
GO
ALTER TABLE [dbo].[SNMP]  WITH CHECK ADD  CONSTRAINT [FK_SNMP_Tag] FOREIGN KEY([TagID])
REFERENCES [dbo].[Tag] ([ID])
GO
ALTER TABLE [dbo].[SNMP] CHECK CONSTRAINT [FK_SNMP_Tag]
GO
ALTER TABLE [dbo].[SupportSize]  WITH CHECK ADD  CONSTRAINT [FK_SupportSize_Model] FOREIGN KEY([ModelID])
REFERENCES [dbo].[Model] ([ID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[SupportSize] CHECK CONSTRAINT [FK_SupportSize_Model]
GO
ALTER TABLE [dbo].[SupportSize]  WITH CHECK ADD  CONSTRAINT [FK_SupportSize_SizePaper] FOREIGN KEY([SizePaperID])
REFERENCES [dbo].[SizePaper] ([ID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[SupportSize] CHECK CONSTRAINT [FK_SupportSize_SizePaper]
GO
ALTER TABLE [dbo].[Tag]  WITH CHECK ADD  CONSTRAINT [FK_Tag_TagType] FOREIGN KEY([TagTypeID])
REFERENCES [dbo].[TagType] ([ID])
GO
ALTER TABLE [dbo].[Tag] CHECK CONSTRAINT [FK_Tag_TagType]
GO
USE [master]
GO
ALTER DATABASE [PrintStat] SET  READ_WRITE 
GO
