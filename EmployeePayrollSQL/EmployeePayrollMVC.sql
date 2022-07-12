--CREATE DATABASE--
create database EmployeePayrollMVC;

--USE DATABASE--
use EmployeePayrollMVC;

--TABLE EMPLOYEE--
Create Table employee_payroll(
	EmployeeId int identity (1,1) primary key,
	Name varchar(200) not null,
	ProfileImage varchar(255) not null,
	Gender varchar(6) not null,
	Department varchar(20) not null,
	Salary float,
	StartDate date,
	Notes varchar(255)
);

--ADD EMPLOYEE--
Create procedure spAddEmployee         
(        
    @Name VARCHAR(20),         
    @ProfileImage varchar(255),               
    @Gender VARCHAR(6),
	@Department VARCHAR(20), 
	@Salary float,
	@StartDate date,
	@Notes varchar(255)        
)       
as         
Begin         
    Insert into employee_payroll (Name, ProfileImage, Gender, Department ,Salary , StartDate , Notes)         
    Values (@Name ,@ProfileImage ,@Gender, @Department, @Salary, @StartDate , @Notes)
End 

--UPDATE EMPLOYEE--
Create procedure spUpdateEmployee          
(          
    @EmployeeId INTEGER ,        
    @Name VARCHAR(20),         
	@ProfileImage varchar(255),               
	@Gender VARCHAR(6),
	@Department VARCHAR(20), 
	@Salary float,
	@StartDate date,
	@Notes varchar(255)        
)          
as          
begin          
   Update employee_payroll           
   set Name=@Name,          
   ProfileImage=@ProfileImage, 
   Gender=@Gender,         
   Department=@Department,
   Salary=@Salary,    
   StartDate=@StartDate,
   Notes=@Notes        
   where EmployeeId=@EmployeeId          
End 

--DELETE EMPLOYEE--
Create procedure spDeleteEmployee         
(          
   @EmployeeId int          
)          
as           
begin          
   Delete from employee_payroll where EmployeeId=@EmployeeId        
End

--GET ALL EMPLOYEE--
Create procedure spGetAllEmployees      
as      
Begin      
    select *      
    from employee_payroll      
End

--GET EMPLOYEE BY ID--
Create procedure spGetEmployeeByID    
(
	@EmployeeId int
)
as      
Begin      
    select * from employee_payroll where EmployeeId=@EmployeeId      
End 