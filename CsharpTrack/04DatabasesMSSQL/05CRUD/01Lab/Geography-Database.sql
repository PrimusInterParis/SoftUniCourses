select lastName as LN,FirstName,Salary,JobTitle 
	from Employees AS e

SELECT 
	FirstName, 
	LastName ,
	FirstName +' '+ LastName as [Full Name],
	RIGHT(FirstName,2)
	FROM Employees


SELECT 
FirstName+' '+ LastName AS [Full Name],
JobTitle,
Salary
FROM Employees


--UNIQUNESS OF COLUMNS
SELECT DISTINCT
	JobTitle
	FROM Employees

	SELECT *
		FROM Employees
		WHERE Salary>50000 
		and
		HireDate<'2003'

		SELECT *
		FROM Employees
		WHERE Salary>50000 
		or
		DepartmentID=1

SELECT * 
	FROM Employees
	WHERE DepartmentID =1 OR
	WHERE DepartmentID =2 OR
	WHERE DepartmentID =3 OR
	WHERE DepartmentID =4 OR
	WHERE DepartmentID =5

SELECT *
	FROM Employees
	WHERE DepartmentID IN (1,2,3,4,5)

SELECT*
	FROM Employees
	WHERE ManagerID IS NULL

	SELECT*
	FROM 
		Employees
	WHERE 
		JobTitle LIKE '%Manager%'


			SELECT*
	FROM 
		Employees
	WHERE 
		FirstName LIKE '[AB]%'

		
			SELECT*
	FROM 
		Employees
	WHERE 
		Salary >20000
		ORDER BY SALARY ASC

		--
CREATE VIEW v_EmployeesWithHighestSalaries AS
SELECT FirstName,LastName , FirstName+' '+LastName AS [Full name]
FROM Employees
WHERE Salary >40000
	
	SELECT * FROM v_EmployeesWithHighestSalaries

	USE Geography
SELECT TOP(1) * FROM [Geography].[dbo].[Peaks]
ORDER BY elevation DESC

CREATE VIEW v_HighestPeack AS
	SELECT TOP(1) * FROM [Geography].[dbo].[Peaks]
	ORDER BY Elevation DESC

	SELECT * FROM v_HighestPeack

INSERT INTO Peaks(PeakName,MountainId,Elevation)
	VALUES
	('Mancho',17,2771)

	USE SoftUni
INSERT INTO Projects([Name],[Description],[StartDate],[EndDate]) 
	SELECT 
	[Name] + ' Restructuring...',
	[Name] + ' Restructuring...',
	GETDATE(),
	NULL 
FROM Departments

SELECT FirstName + ' '+ LastName AS [Full name],Salary
	INTO NamesWithSalaries
FROM Employees


SELECT TOP (100) [Full name],[Salary]
	FROM [SoftUni].[dbo].[NamesWithSalaries]

DELETE FROM[NamesWithSalaries]
	WHERE [Salary]<50000

UPDATE [NamesWithSalaries]
	SET 
	Salary = Salary*0.9
WHERE 
	Salary>60000

	USE SoftUni
UPDATE Projects
SET
EndDate = GETDATE()
WHERE EndDate IS NULL

SELECT * FROM Projects
