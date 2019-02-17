USE [master]
GO

/****** Script for creating Database******/
/****** Object:  Database [EmployeeRegistrationDb]    Script Date: 2/7/2019 10:16:09 PM ******/
CREATE DATABASE [EmployeeRegistrationDb]
GO


/****** Script for creating Companies and Employees tables******/
USE [EmployeeRegistrationDb]
GO

/****** Object:  Table [dbo].[Companies]    Script Date: 2/7/2019 10:01:34 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Positions](
	[PositionId] [int] IDENTITY(1,1) NOT NULL,
	[PositionName] [nvarchar](20) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[PositionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[Forms](
	[FormId] [int] IDENTITY(1,1) NOT NULL,
	[FormName] [nvarchar](20) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[FormId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[Companies](
	[CompanyId] [int] IDENTITY(1,1) NOT NULL,
	[CompanyName] [nvarchar](20) NOT NULL,
	[Size] [int] NOT NULL,
	[Form] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[CompanyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[Employees](
	[EmployeeId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](20) NOT NULL,
	[Surname] [nvarchar](20) NOT NULL,
	[SecondName] [nvarchar](20) NOT NULL,
	[Date] [smalldatetime] NOT NULL,
	[Position] [int] NOT NULL,
	[Company] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[EmployeeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Employees]  WITH CHECK ADD FOREIGN KEY([Company])
REFERENCES [dbo].[Companies] ([CompanyId])
GO

ALTER TABLE [dbo].[Employees]  WITH CHECK ADD FOREIGN KEY([Position])
REFERENCES [dbo].[Positions] ([PositionId])
GO

ALTER TABLE [dbo].[Companies]  WITH CHECK ADD FOREIGN KEY([Form])
REFERENCES [dbo].[Forms] ([FormId])
GO