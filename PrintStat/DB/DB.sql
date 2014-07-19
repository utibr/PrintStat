USE [PrinterStat]
GO
/****** Object:  Table [dbo].[Application]    Script Date: 19.07.2014 23:28:01 ******/
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
/****** Object:  Table [dbo].[Cartridge]    Script Date: 19.07.2014 23:28:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cartridge](
	[ID] [int] NOT NULL,
	[PrinterID] [int] NOT NULL,
	[ColorID] [int] NOT NULL,
	[Name] [nvarchar](50) NULL,
	[ShortName] [nvarchar](5) NULL,
 CONSTRAINT [PK_Cartridge] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CartridgeColor]    Script Date: 19.07.2014 23:28:01 ******/
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
/****** Object:  Table [dbo].[Department]    Script Date: 19.07.2014 23:28:01 ******/
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
/****** Object:  Table [dbo].[DeviceType]    Script Date: 19.07.2014 23:28:01 ******/
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
/****** Object:  Table [dbo].[Employee]    Script Date: 19.07.2014 23:28:01 ******/
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
/****** Object:  Table [dbo].[Job]    Script Date: 19.07.2014 23:28:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Job](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](2000) NOT NULL,
	[PrinterID] [int] NOT NULL,
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
	[PaperTypeID] [int] NULL,
	[AuthorTabNumber] [nvarchar](50) NULL,
	[Size_kb] [int] NULL,
	[IP] [nvarchar](16) NULL,
	[ComputerName] [nvarchar](50) NULL,
	[IsManual] [bit] NOT NULL CONSTRAINT [DF_Job_IsManual]  DEFAULT ((0)),
 CONSTRAINT [PK_Job] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PaperType]    Script Date: 19.07.2014 23:28:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PaperType](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Width_cm] [numeric](6, 2) NULL,
	[Height_cm] [numeric](6, 2) NULL,
	[DeviceTypeID] [int] NULL,
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
/****** Object:  Table [dbo].[Printer]    Script Date: 19.07.2014 23:28:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Printer](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[DeviceTypeID] [int] NOT NULL,
	[PrintKindID] [int] NOT NULL,
	[SearchString] [nvarchar](50) NOT NULL,
	[InvNumber] [nvarchar](10) NULL,
	[StatisticsSupported] [bit] NOT NULL,
 CONSTRAINT [PK_Printer] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PrintKind]    Script Date: 19.07.2014 23:28:01 ******/
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
/****** Object:  Table [dbo].[Setup]    Script Date: 19.07.2014 23:28:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Setup](
	[MailServer] [nvarchar](150) NOT NULL,
	[AccountName] [nvarchar](50) NOT NULL,
	[Pwd] [nvarchar](50) NOT NULL,
	[Protocol] [nvarchar](4) NOT NULL,
	[Port] [int] NOT NULL,
	[TabNumber] [nvarchar](50) NOT NULL,
	[ID] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_Setup] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[Cartridge]  WITH CHECK ADD  CONSTRAINT [FK_Cartridge_CartridgeColor] FOREIGN KEY([ColorID])
REFERENCES [dbo].[CartridgeColor] ([ID])
GO
ALTER TABLE [dbo].[Cartridge] CHECK CONSTRAINT [FK_Cartridge_CartridgeColor]
GO
ALTER TABLE [dbo].[Cartridge]  WITH CHECK ADD  CONSTRAINT [FK_Cartridge_Printer] FOREIGN KEY([PrinterID])
REFERENCES [dbo].[Printer] ([ID])
GO
ALTER TABLE [dbo].[Cartridge] CHECK CONSTRAINT [FK_Cartridge_Printer]
GO
ALTER TABLE [dbo].[Employee]  WITH CHECK ADD  CONSTRAINT [FK_Employee_Department] FOREIGN KEY([DepartmentID])
REFERENCES [dbo].[Department] ([ID])
GO
ALTER TABLE [dbo].[Employee] CHECK CONSTRAINT [FK_Employee_Department]
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
ALTER TABLE [dbo].[Job]  WITH CHECK ADD  CONSTRAINT [FK_Job_Printer] FOREIGN KEY([PrinterID])
REFERENCES [dbo].[Printer] ([ID])
GO
ALTER TABLE [dbo].[Job] CHECK CONSTRAINT [FK_Job_Printer]
GO
ALTER TABLE [dbo].[PaperType]  WITH CHECK ADD  CONSTRAINT [FK_PaperType_DeviceType] FOREIGN KEY([DeviceTypeID])
REFERENCES [dbo].[DeviceType] ([ID])
GO
ALTER TABLE [dbo].[PaperType] CHECK CONSTRAINT [FK_PaperType_DeviceType]
GO
ALTER TABLE [dbo].[Printer]  WITH CHECK ADD  CONSTRAINT [FK_Printer_DeviceType] FOREIGN KEY([DeviceTypeID])
REFERENCES [dbo].[DeviceType] ([ID])
GO
ALTER TABLE [dbo].[Printer] CHECK CONSTRAINT [FK_Printer_DeviceType]
GO
ALTER TABLE [dbo].[Printer]  WITH CHECK ADD  CONSTRAINT [FK_Printer_PrintKind] FOREIGN KEY([PrintKindID])
REFERENCES [dbo].[PrintKind] ([ID])
GO
ALTER TABLE [dbo].[Printer] CHECK CONSTRAINT [FK_Printer_PrintKind]
GO
ALTER TABLE [dbo].[Setup]  WITH CHECK ADD  CONSTRAINT [FK_Setup_Employee] FOREIGN KEY([TabNumber])
REFERENCES [dbo].[Employee] ([TabNumber])
GO
ALTER TABLE [dbo].[Setup] CHECK CONSTRAINT [FK_Setup_Employee]
GO
