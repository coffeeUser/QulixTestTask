/****** Scripts for creating stored procedures******/

USE [EmployeeRegistrationDb]
GO

/****** Object:  StoredProcedure [dbo].[AddCompany]    Script Date: 2/7/2019 10:04:51 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

/****** Script for creating new company in the table Companies******/
Create procedure [dbo].[AddCompany]    
(    
    @Name VARCHAR(20),
	@Size int,     
    @Form VARCHAR(20)        
)    
as     
Begin     
    Insert into Companies (Name, Size, Form)     
    Values (@Name, @Size, @Form)     
End
GO

/****** Script for creating new employee in the table Employees******/
Create procedure [dbo].[AddEmployee]    
(    
    @Name VARCHAR(20),     
    @Surname VARCHAR(20),
	@SecondName VARCHAR(20),
	@Date smalldatetime,
	@Position VARCHAR(20),
	@CompanyId int        
)    
as     
Begin     
    Insert into Employees (Name, Surname, SecondName, Date, Position, CompanyId)     
    Values (@Name,@Surname, @SecondName, @Date, @Position, @CompanyId)     
End
GO

/****** Script for deleting company by Id from the table Companies******/
Create procedure [dbo].[DeleteCompany]     
(      
   @Id int      
)      
as       
begin      
   Delete from Companies where Id=@Id      
End
GO

/****** Script for deleting employee by Id from the table Employees******/
Create procedure [dbo].[DeleteEmployee]     
(      
   @Id int      
)      
as       
begin      
   Delete from Employees where Id=@Id      
End
GO

/****** Script for getting all companies from the table Companies******/
Create procedure [dbo].[GetAllCompanies]    
as    
Begin    
    select *    
    from Companies    
End
GO

/****** Script for getting all employees from the table Employees******/
Create procedure [dbo].[GetAllEmployees]    
as    
Begin    
    select *    
    from Employees    
End
GO

/****** Script for getting all employees belonging to the one company from the table Employees******/
Create procedure [dbo].[GetCompanyEmployees]
(
@CompanyId int
)    
as    
Begin    
    select *    
    from Employees
	where CompanyId=@CompanyId    
End
GO

/****** Script for getting all employees with current position from the table Employees******/
Create procedure [dbo].[GetEmployeesByPosition]
(
@Position [varchar](20)
)    
as    
Begin    
    select *    
    from Employees
	where Position=@Position    
End
GO

/****** Script for updating company******/
Create procedure [dbo].[UpdateCompany]      
(      
   @Id INTEGER ,    
   @Name VARCHAR(20),     
   @Size VARCHAR(20),    
   @Form VARCHAR(20)        
)      
as      
begin      
   Update Companies       
   set Name=@Name,      
   Size=@Size,      
   Form=@Form         
   where Id=@Id      
End
GO

/****** Script for updating employee******/
Create procedure [dbo].[UpdateEmployee]      
(      
	@Id INTEGER ,    
	@Name VARCHAR(20),     
	@Surname VARCHAR(20),
	@SecondName VARCHAR(20),
	@Date smalldatetime,
	@Position VARCHAR(20),
	@CompanyId int        
)      
as      
begin      
   Update Employees       
   set Name=@Name,      
   Surname=@Surname,      
   secondName=@SecondName,
   Date=@Date,
   Position=@Position,
   CompanyId=@CompanyId        
   where Id=@Id      
End
GO