USE [SoftUni]
--4
SELECT [FirstName], [LastName], [Salary] FROM [Employees]

--5
SELECT [FirstName], [MiddleName], [LastName] FROM [Employees]

--6
SELECT [FirstName] + '.' + [LastName] + '@'+ 'softuni.bg' FROM [Employees]

--6.2
SELECT CONCAT([FirstName], '.', [LastName], '@', 'softuni.bg') AS [Full Email Address] FROM [Employees]

--7
SELECT DISTINCT [Salary] FROM [Employees]

--9
SELECT [FirstName], [LastName], [JobTitle] FROM [Employees]
WHERE [Salary] BETWEEN 20000 AND 30000

--10
SELECT CONCAT([FirstName],' ' , [MiddleName], ' ',[LastName])
AS [Full Name]
FROM [Employees]
WHERE [Salary] IN (25000, 14000, 12500, 23600)

--11
SELECT [FirstName], [LastName] FROM [Employees]
WHERE [ManagerID] IS NULL

--12
SELECT [FirstName], [LastName], [Salary] FROM [Employees]
WHERE [Salary] > 50000
ORDER BY [Salary] DESC

--13
SELECT TOP(5)[FirstName], [LastName] FROM [Employees]
ORDER BY [Salary] DESC

--15
SELECT * FROM [Employees]
ORDER BY [Salary] DESC, [FirstName] ASC, [LastName] DESC, [MiddleName] ASC

--17
GO 

CREATE VIEW [V_EmployeeNameJobTitle] AS (
SELECT CONCAT([FirstName], ' ', [MiddleName], ' ', [LastName]) AS [Full Name],
[JobTitle] AS [Job Title]
FROM [Employees])

GO

--21
SELECT * FROM [Departments]
SELECT * FROM [Employees]
WHERE   [DepartmentID] IN (1, 2, 4, 11)

UPDATE [Employees]
SET [Salary] += [Salary] * 0.12
WHERE [DepartmentID] IN (1, 2, 4, 11)

SELECT [Salary] FROM [Employees]

--24
USE [Geography]

SELECT [CountryName], [CountryCode], [CurrencyCode],
      CASE
	    WHEN [CurrencyCode] = 'EUR' THEN 'Euro'
		ELSE 'Not Euro'
	END AS [Currency]
FROM [Countries]
ORDER BY [CountryName]