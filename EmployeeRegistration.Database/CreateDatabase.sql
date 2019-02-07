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

CREATE TABLE [dbo].[Companies](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](20) NOT NULL,
	[Size] [int] NOT NULL,
	[Form] [varchar](20) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[Employees](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](20) NOT NULL,
	[Surname] [varchar](20) NOT NULL,
	[SecondName] [varchar](20) NOT NULL,
	[Date] [smalldatetime] NOT NULL,
	[Position] [varchar](20) NOT NULL,
	[CompanyId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Employees]  WITH CHECK ADD FOREIGN KEY([CompanyId])
REFERENCES [dbo].[Companies] ([Id])
GO