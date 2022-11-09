GO

CREATE PROCEDURE usp_GetEmployeesSalaryAboveNumber 
AS
BEGIN
	SELECT FirstName, LastName FROM Employees
	WHERE Salary > 35000
END

GO

--4
CREATE PROCEDURE usp_GetEmployeesFromTown @townName VARCHAR(50)
AS
BEGIN
	SELECT e.FirstName, e.LastName
	FROM Employees AS e
	LEFT JOIN Addresses AS a
	ON e.AddressID = a.AddressID
	LEFT JOIN Towns AS t
	ON a.TownID = t.TownID
	WHERE t.[Name] = @townName
END

EXEC usp_GetEmployeesFromTown 'Sofia'

GO 
--5
CREATE FUNCTION ufn_GetSalaryLevel(@salary DECIMAL(18,4)) 
RETURNS VARCHAR(7)
AS
BEGIN
	DECLARE @salaryLevel VARCHAR(7)
	IF @salary < 30000
	BEGIN
		SET @salaryLevel = 'Low'
	END
	
	ELSE IF @salary BETWEEN 30000 AND 50000
	BEGIN
		SET @salaryLevel = 'Average'
	END

	ELSE 
	BEGIN
		SET @salaryLevel = 'High'
	END

	RETURN @salaryLevel
END

GO
--6
CREATE PROCEDURE usp_EmployeesBySalaryLevel @salaryLevel VARCHAR(7)
AS
BEGIN
	SELECT FirstName, LastName
	FROM Employees
	WHERE dbo.ufn_GetSalaryLevel(Salary) = @salaryLevel
END

GO


--8

SELECT EmployeeID 
FROM Employees
WHERE DepartmentID = 4
GO

CREATE PROCEDURE usp_DeleteEmployeesFromDepartment (@departmentId INT) 
AS
BEGIN
	--First we need to delete all records from EmployeeProject where EmplID is one of the lately
	DELETE FROM EmployeesProjects
	WHERE EmployeeID IN (
		SELECT EmployeeID 
		FROM Employees
		WHERE DepartmentID = @departmentId
		)
	--We need to set ManagerID to NULL of all Employees which have their Manager lately deleted
	UPDATE Employees
	SET ManagerID = NULL
	WHERE ManagerID IN (
		SELECT EmployeeID 
		FROM Employees
		WHERE DepartmentID = @departmentId
		)
	--Wee need to alter ManagerID column from Departments in order to be nullable because we need to set
	--ManagerID to NULL of all Departments that have their Manager lately deleted
	ALTER TABLE Departments
	ALTER COLUMN ManagerID INT 

	UPDATE Departments
	SET ManagerID = NULL
	WHERE ManagerID IN (
		SELECT EmployeeID 
		FROM Employees
		WHERE DepartmentID = @departmentId
		)

	DELETE FROM Employees
	WHERE DepartmentID = @departmentId

	DELETE FROM Departments 
	WHERE DepartmentID = @departmentId

	SELECT COUNT(*) 
	FROM Employees
	WHERE DepartmentID = @departmentId
END

GO

--13
USE Diablo