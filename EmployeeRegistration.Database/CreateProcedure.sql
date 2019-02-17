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
    @CompanyName NVARCHAR(20),
	@Size int,     
    @Form int        
)    
as     
Begin     
    Insert into Companies (CompanyName, Size, Form)     
    Values (@CompanyName, @Size, @Form)     
End
GO

/****** Script for creating new employee in the table Employees******/
Create procedure [dbo].[AddEmployee]    
(    
    @Name NVARCHAR(20),     
    @Surname NVARCHAR(20),
	@SecondName NVARCHAR(20),
	@Date smalldatetime,
	@Position int,
	@Company int        
)    
as     
Begin     
    Insert into Employees (Name, Surname, SecondName, Date, Position, Company)     
    Values (@Name,@Surname, @SecondName, @Date, @Position, @Company)     
End
GO

/****** Script for deleting company by Id from the table Companies******/
Create procedure [dbo].[DeleteCompany]     
(      
   @Id int      
)      
as       
begin      
   Delete from Companies where CompanyId=@Id      
End
GO

/****** Script for deleting employee by Id from the table Employees******/
Create procedure [dbo].[DeleteEmployee]     
(      
   @Id int      
)      
as       
begin      
   Delete from Employees where EmployeeId=@Id      
End
GO

/****** Script for getting all companies from the table Companies******/
Create procedure [dbo].[GetAllCompanies]    
as    
Begin    
    select * from Companies
	join Forms
	on Forms.FormId = Companies.Form
	left join Employees
	on Employees.Company = CompanyId
End
GO

/****** Script for getting all employees from the table Employees******/
Create procedure [dbo].[GetAllEmployees]    
as    
Begin    
    select *    
    from Employees
	join Positions
	on Employees.Position = Positions.PositionId
	join Companies
	on Employees.Company = Companies.CompanyId    
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
	join Positions
	on Employees.Position = Positions.PositionId
	join Companies
	on Employees.Company = Companies.CompanyId  
	where Company=@CompanyId    
End
GO

/****** Script for getting all employees with current position from the table Employees******/
Create procedure [dbo].[GetEmployeesByPosition]
(
@PositionId int
)    
as    
Begin    
    select *    
    from Employees
	join Positions
	on Employees.Position = Positions.PositionId
	join Companies
	on Employees.Company = Companies.CompanyId  
	where Position=@PositionId    
End
GO

/****** Script for updating company******/
Create procedure [dbo].[UpdateCompany]      
(      
   @Id INTEGER ,    
   @CompanyName NVARCHAR(20),     
   @Size NVARCHAR(20),    
   @Form int        
)      
as      
begin      
   Update Companies       
   set CompanyName=@CompanyName,      
   Size=@Size,      
   Form=@Form         
   where CompanyId=@Id      
End
GO

/****** Script for updating employee******/
Create procedure [dbo].[UpdateEmployee]      
(      
	@Id INTEGER ,    
	@Name NVARCHAR(20),     
	@Surname NVARCHAR(20),
	@SecondName NVARCHAR(20),
	@Date smalldatetime,
	@Position int,
	@Company int        
)      
as      
begin      
   Update Employees       
   set Name=@Name,      
   Surname=@Surname,      
   secondName=@SecondName,
   Date=@Date,
   Position=@Position,
   Company=@Company        
   where EmployeeId=@Id      
End
GO

/****** Script for getting employee by Id from the table Employees******/
Create procedure [dbo].[GetEmployeeById]
(
	@Id int
)    
as    
Begin    
    select * from Employees
	join Companies
	on Companies.CompanyId = Employees.Company
	join Positions
	on Positions.PositionId = Employees.Position
	where Employees.EmployeeId = @Id    
End
GO

/****** Script for getting company by Id from the table Companies******/
Create procedure [dbo].[GetCompanyById]
(
	@Id int
)    
as    
Begin    
    select * from Companies
	left join Employees
	on Employees.Company = Companies.CompanyId
	join Forms
	on Forms.FormId = Companies.Form
	where Companies.CompanyId = @Id    
End
GO

/****** Script for getting all positions from the table Positions******/
Create procedure [dbo].[GetAllPositions]    
as    
Begin    
    select *    
    from Positions  
End
GO

/****** Script for getting all forms from the table Forms******/
Create procedure [dbo].[GetAllForms]    
as    
Begin    
    select *    
    from Forms  
End
GO

/****** Script for updating size of the company from the table Companies******/
Create procedure [dbo].[UpdateCompanySize]
(
@Id int
)
as      
begin 
	Update Companies
	set Size=
		(select Count(Company) as Size 
		from Employees 
		where Company = @Id)
	where CompanyId = @Id
End
GO
