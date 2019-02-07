/****** Script for filling in tables with initial data******/
USE [EmployeeRegistrationDb]
GO

INSERT INTO [dbo].[Companies] ([Name], [Size], [Form])
     VALUES ('Qulix Systems', 2, 'OOO')
GO

INSERT INTO [dbo].[Companies] ([Name], [Size], [Form])
     VALUES ('iTechArt', 1, 'OOO')
GO

INSERT INTO [dbo].[Companies] ([Name], [Size], [Form])
     VALUES ('EPAM', 1, 'OAO')
GO

INSERT INTO [dbo].[Companies] ([Name], [Size], [Form])
     VALUES ('SCAND', 1, 'OAO')
GO

INSERT INTO [dbo].[Companies] ([Name], [Size], [Form])
     VALUES ('ISSoft', 1, 'OAO')
GO

INSERT INTO [dbo].[Companies] ([Name], [Size], [Form])
     VALUES ('iTransition', 0, 'OAO')
GO

INSERT INTO [dbo].[Employees]([Name], [Surname], [SecondName], [Date], [Position], [CompanyId])
     VALUES ('Alexander', 'Zhigalov', 'Vladimirovich', '02/07/2019', 'Developer', 1)
GO

INSERT INTO [dbo].[Employees]([Name], [Surname], [SecondName], [Date], [Position], [CompanyId])
     VALUES ('Vladimir', 'Makarevich', 'Vladimirovich', '08/01/2017', 'Developer', 1)
GO

INSERT INTO [dbo].[Employees]([Name], [Surname], [SecondName], [Date], [Position], [CompanyId])
     VALUES ('Ivan', 'Ivanov', 'Ivanovich', '06/04/2015', 'Tester', 2)
GO

INSERT INTO [dbo].[Employees]([Name], [Surname], [SecondName], [Date], [Position], [CompanyId])
     VALUES ('Petr', 'Petrov', 'Petrovich', '03/09/2014', 'Manager', 3)
GO

INSERT INTO [dbo].[Employees]([Name], [Surname], [SecondName], [Date], [Position], [CompanyId])
     VALUES ('Egor', 'Baga', 'Petrovich', '08/02/2012', 'Business Analyst', 4)
GO

INSERT INTO [dbo].[Employees]([Name], [Surname], [SecondName], [Date], [Position], [CompanyId])
     VALUES ('Alexei', 'Semashko', 'Alexandrovich', '05/01/2011', 'Business Analyst', 5)
GO


