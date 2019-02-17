/****** Script for filling in tables with initial data******/
USE [EmployeeRegistrationDb]
GO

INSERT INTO [dbo].[Positions] ([PositionName])
     VALUES ('Developer')
GO

INSERT INTO [dbo].[Positions] ([PositionName])
     VALUES ('Tester')
GO

INSERT INTO [dbo].[Positions] ([PositionName])
     VALUES ('Manager')
GO

INSERT INTO [dbo].[Positions] ([PositionName])
     VALUES ('Business Analyst')
GO

INSERT INTO [dbo].[Forms] ([FormName])
     VALUES ('OOO')
GO

INSERT INTO [dbo].[Forms] ([FormName])
     VALUES ('OAO')
GO

INSERT INTO [dbo].[Companies] ([CompanyName], [Size], [Form])
     VALUES ('Qulix Systems', 2, 1)
GO

INSERT INTO [dbo].[Companies] ([CompanyName], [Size], [Form])
     VALUES ('iTechArt', 1, 1)
GO

INSERT INTO [dbo].[Companies] ([CompanyName], [Size], [Form])
     VALUES ('EPAM', 1, 2)
GO

INSERT INTO [dbo].[Companies] ([CompanyName], [Size], [Form])
     VALUES ('SCAND', 1, 2)
GO

INSERT INTO [dbo].[Companies] ([CompanyName], [Size], [Form])
     VALUES ('ISSoft', 1, 2)
GO

INSERT INTO [dbo].[Companies] ([CompanyName], [Size], [Form])
     VALUES ('iTransition', 0, 2)
GO

INSERT INTO [dbo].[Employees]([Name], [Surname], [SecondName], [Date], [Position], [Company])
     VALUES ('Alexander', 'Zhigalov', 'Vladimirovich', '02/07/2019', 1, 1)
GO

INSERT INTO [dbo].[Employees]([Name], [Surname], [SecondName], [Date], [Position], [Company])
     VALUES ('Vladimir', 'Makarevich', 'Vladimirovich', '08/01/2017', 1, 1)
GO

INSERT INTO [dbo].[Employees]([Name], [Surname], [SecondName], [Date], [Position], [Company])
     VALUES ('Ivan', 'Ivanov', 'Ivanovich', '06/04/2015', 2, 2)
GO

INSERT INTO [dbo].[Employees]([Name], [Surname], [SecondName], [Date], [Position], [Company])
     VALUES ('Petr', 'Petrov', 'Petrovich', '03/09/2014', 3, 3)
GO

INSERT INTO [dbo].[Employees]([Name], [Surname], [SecondName], [Date], [Position], [Company])
     VALUES ('Egor', 'Baga', 'Petrovich', '08/02/2012', 4, 4)
GO

INSERT INTO [dbo].[Employees]([Name], [Surname], [SecondName], [Date], [Position], [Company])
     VALUES ('Alexei', 'Semashko', 'Alexandrovich', '05/01/2011', 4, 5)
GO



