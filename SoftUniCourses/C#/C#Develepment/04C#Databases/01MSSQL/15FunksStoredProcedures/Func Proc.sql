
--variables
DECLARE @Year SMALLINT = 0
SELECT @Year




DECLARE @MTempTable TABLE(Id INT PRIMARY KEY IDENTITY, [Name] nvarchar(MAX))
INSERT INTO @MTempTable (Name) VALUEs ('Niki')
SELECT * FROM @MTempTable


--conditional statments
IF YEAR(GETDATE())=2022
BEGIN
	SET @Year = 2021
	INSERT INTO @MTempTable (Name) VALUEs ('mONI')
END


ELSE IF YEAR(GETDATE())=2024
	SET @Year =-2000
ELSE
	 SET @YEAR = YEAR(GETDATE())

	SELECT @Year


SELECT CASE @Year
	WHEN 2020 THEN '2021?'
	WHEN 2021 THEN '2021!!!'
	ELSE 'UKNOWNyEAR ' END;
	
	GO
--loops
 
 use SoftUni
DECLARE @Year SMALLINT = 2000;
SELECT @Year,COUNT(*) FROM Employees WHERE YEAR(HireDate) = @Year

SET @Year = @Year + 1;
SELECT @Year,COUNT(*) FROM Employees WHERE YEAR(HireDate) = @Year

SET @Year = @Year + 1;
SELECT @Year,COUNT(*) FROM Employees WHERE YEAR(HireDate) = @Year

SET @Year = @Year + 1;
SELECT @Year,COUNT(*) FROM Employees WHERE YEAR(HireDate) = @Year

SET @Year = @Year + 1;
SELECT @Year,COUNT(*) FROM Employees WHERE YEAR(HireDate) = @Year

SET @Year = @Year + 1;
SELECT @Year,COUNT(*) FROM Employees WHERE YEAR(HireDate) = @Year
GO

DECLARE @Year SMALLINT = 2000;
WHILE (@Year<2008)
BEGIN 
SET @Year = @Year + 1;
SELECT @Year,COUNT(*) FROM Employees WHERE YEAR(HireDate) = @Year
END

--FUNKS
go

--CREATE FUNCTION udf_CustomPowerFunk(@Base INT,@Ext INT)
--RETURNS decimal(38)
--AS
--BEGIN
--	DECLARE @Result DECIMAL(38) =1;

--		WHILE(@Ext >0)
--	BEGIN 
--			SET @Result = @Result * @Base;
--			SET	@Ext -=1;
--	END

-- RETURN @Result;
--END

SELECT dbo.udf_CustomPowerFunk(2,100)



--wiew

CREATE OR ALTER VIEW EmployeesByYear AS
SELECT * 
FROM Employees AS E
WHERE E.HireDate>'2000'

--FUNK

CREATE or ALTER FUNCTION udf_EmployeeByYear(@Year SMALLINT)
RETURNS TABLE
AS 
RETURN
(
SELECT * FROM Employees
WHERE YEAR(HireDate)=@Year
)

SELECT * FROM udf_EmployeeByYear(1999)

SELECT * FROM dbo.udf_AllPowers(100)

CREATE FUNCTION udf_AllPowers(@MaxPower INT)
RETURNS @Table TABLE(Id INT IDENTITY PRIMARY KEY,SQUARE BIGINT)
AS
BEGIN
	DECLARE @I INT =1;
	WHILE(@MaxPower >=@I)
	BEGIN
	INSERT INTO @Table (SQUARE) VALUES (@I * @I)
	SET @I=@I+1;
	END
	RETURN
END


go

Create FUNCTION ufn_GetSalaryLevel(@Salary MONEY)
RETURNS VARCHAR(max)
AS
BEGIN
	
	IF @Salary< 30000
		RETURN 'Low'
	ELSE IF  @Salary<=50000
		RETURN 'Average'

		RETURN 'High'
END

go

use SoftUni



SELECT FirstName,LastName,Salary,dbo.ufn_GetSalaryLevel(Salary)
FROM Employees

go


CREATE PROCEDURE dbo.usp_SlectEmployeesBySeniority
AS
	SELECT * 
		FROM Employees
		WHERE DATEDIFF(YEAR,HireDate,GETDATE()) >20
GO

EXEC dbo.usp_SlectEmployeesBySeniority

GO

USE SoftUni
GO
--1.	Employees with Salary Above 35000

CREATE PROCEDURE usp_GetEmployeesSalaryAbove35000
AS
	SELECT FirstName,LastName
		FROM Employees
		WHERE Salary>35000
GO

EXEC dbo.usp_GetEmployeesSalaryAbove35000

GO
--2.	Employees with Salary Above Number
CREATE PROCEDURE usp_GetEmployeesSalaryAboveNumber(@Number DECIMAL(18,4))
AS
	SELECT FirstName,LastName
		FROM Employees
		WHERE SALARY >= @Number
		
		GO

EXEC dbo.usp_GetEmployeesSalaryAboveNumber 48100




GO

--3.	Town Names Starting With

CREATE PROCEDURE usp_GetTownsStartingWith(@StartsWith NVARCHAR(50))
AS
	SELECT [Name] 
		FROM Towns
		WHERE [Name] like @StartsWith + '%'



GO

EXEC dbo.usp_GetTownsStartingWith b

go
--4.	Employees from Town
CREATE PROCEDURE usp_GetEmployeesFromTown(@TownName VARCHAR(50))
AS
	SELECT E.FirstName,E.LastName
		FROM Employees AS E
		JOIN Addresses AS ADR ON ADR.AddressID=E.AddressID
		JOIN Towns AS T ON T.TownID=ADR.TownID
		WHERE T.Name=@TownName

		GO

EXEC dbo.usp_GetEmployeesFromTown Sofia

go

--5.	Salary Level Function


CREATE or alter FUNCTION ufn_GetSalaryLevel(@salary DECIMAL(18,4))
RETURNS NVARCHAR(50)
AS
	BEGIN
		IF @salary<30000
			RETURN 'Low'
		ELSE IF @salary BETWEEN 30000 AND 50000
			RETURN 'Average'
		ELSE 
			RETURN 'High'

			RETURN NULL
	END

SELECT Salary ,dbo.ufn_GetSalaryLevel(Salary) AS [Salary level]
FROM Employees


--6.	Employees by Salary Level
GO

CREATE PROCEDURE usp_EmployeesBySalaryLevel(@SalaryLevel NVARCHAR(50))
AS
	SELECT ToSort.FirstName,LastName
	FROM
	(
	SELECT e.FirstName,e.LastName,dbo.ufn_GetSalaryLevel(Salary) as SalaryLevel
		FROM Employees AS E) AS ToSort
		where ToSort.SalaryLevel like @SalaryLevel


go

--7.	Define Function

GO

CREATE FUNCTION ufn_IsWordComprised(@setOfLetters NVARCHAR(MAX), @word NVARCHAR(MAX))
RETURNS BIT
AS
BEGIN

	DECLARE @Lenght int = LEN(@word)
	DECLARE @Ind int = 1

	WHILE(@Lenght >= @Ind)
	BEGIN
			DECLARE @currentLetter char(1) = substring(@word,@Ind,1)

			IF(CHARINDEX(@currentLetter,@setOfLetters)=0)
				return 0

		SET @Ind+=1
	END

RETURN 1

END
go

SELECT dbo.ufn_IsWordComprised ('oistmiahf','Sofia')

go



USE Bank

SELECT * FROM AccountHolders

SELECT * FROM Accounts

GO
CREATE PROC usp_GetHoldersWithBalanceHigherThan(@Number MONEY)
AS
	SELECT RES.FirstName,RES.LastName
	FROM
	(
	SELECT SUM(A.Balance)AS [SUM],FirstName,LastName
	FROM AccountHolders AS AH
	JOIN Accounts AS A ON A.AccountHolderId=AH.Id) AS RES
	WHERE [SUM]>@Number
	ORDER BY FirstName,LastName
	

	--8. Delete Employees and Department
GO

	USE SoftUni

ALTER TABLE Departments
ALTER column ManagerId INT NULL

GO

CREATE PROC usp_DeleteEmployeesFromDepartment(@departmentId INT) 
AS
	ALTER TABLE Departments
	ALTER column ManagerId INT NULL

	DELETE FROM EmployeesProjects
			WHERE EmployeeID IN (SELECT EmployeeID FROM Employees 
									WHERE DepartmentID LIKE @departmentId)
	UPDATE Employees
		SET ManagerID = NULL
			WHERE EmployeeID IN (SELECT EmployeeID FROM Employees 
										WHERE DepartmentID LIKE @departmentId)
	UPDATE Employees
		SET ManagerID = NULL
			WHERE ManagerID IN (SELECT EmployeeID FROM Employees 
										WHERE DepartmentID LIKE @departmentId)	
	UPDATE Departments
		SET ManagerID = NULL
			WHERE DepartmentID LIKE @departmentId

	DELETE FROM Employees
		WHERE DepartmentID=@departmentId

	DELETE FROM Departments
		WHERE DepartmentID=@departmentId


	SELECT COUNT(*)
		FROM Departments
			WHERE DepartmentID=@departmentId


--9 	Find Full Name

GO

USE Bank

GO

CREATE PROC usp_GetHoldersFullName
AS
	SELECT FirstName + ' ' + LastName AS [Full Name]
		FROM AccountHolders


--10.	People with Balance Higher Than

go

CREATE PROC usp_GetHoldersWithBalanceHigherThan(@TargetAmount money)
AS	

		SELECT A.FirstName,A.LastName
		FROM Accounts AS AH
		JOIN AccountHolders AS A ON A.Id=AH.AccountHolderId
		GROUP BY AccountHolderId,A.FirstName,A.LastName
		HAVING SUM(AH.Balance) >@TargetAmount
		ORDER BY A.FirstName,A.LastName



GO

--11.	Future Value Function
GO

CREATE FUNCTION ufn_CalculateFutureValue(@Sum DECIMAL(15,4),@Yearly  FLOAT,@Years INT)
RETURNS DECIMAL(15,4)
BEGIN
	   DECLARE @Result DECIMAL(15,4) 
	   SET @Result=(@sum*POWER((1+@Yearly),@Years))
	   RETURN @Result
END

GO
USE Bank

select dbo.ufn_CalculateFutureValue(1000,0.1,5)


go

--12.	Calculating Interest

CREATE PROC usp_CalculateFutureValueForAccount( @AccountId INT,@Yearly  FLOAT)
AS
	SELECT AH.Id,AH.FirstName,LastName,a.Balance,dbo.ufn_CalculateFutureValue(a.Balance,@Yearly,5) AS [Balance in 5 years]
	FROM AccountHolders AS AH
	JOIN Accounts AS A ON A.AccountHolderId=AH.Id
	WHERE A.Id=@AccountId

	GO

	USE Diablo

--13.	*Scalar Function: Cash in User Games Odd Rows


	GO

CREATE FUNCTION ufn_CashInUsersGames(@GameName NVARCHAR(50))
RETURNS TABLE
AS
RETURN
(select SUM(K.c) AS [SumCash]
	from(
		SELECT Cash AS c,
			ROW_NUMBER() OVER (ORDER BY Cash desc) as RowNumb
				FROM UsersGames AS UG
					JOIN Games AS G ON G.Id = UG.GameId
				WHERE G.Name = @GameName) as k	
	WHERE K.RowNumb%2=1)
			

GO




				 
				