USE [SoftUni]

--1
SELECT FirstName, LastName FROM [Employees] 
WHERE LEFT(FirstName, 2) = 'Sa'

--2
SELECT FirstName, LastName FROM [Employees] 
WHERE CHARINDEX('ei', LastName) <> 0

--2.1
SELECT FirstName, LastName FROM [Employees] 
WHERE LastName LIKE '%ei%'

--3
SELECT FirstName FROM [Employees] 
WHERE [DepartmentID] IN (3, 10) AND YEAR(HireDate) BETWEEN 1995 AND 2005

--5
SELECT [Name] FROM [Towns] 
WHERE LEN([Name]) IN (5,6)
ORDER BY [Name]

--6
SELECT * FROM Towns
WHERE LEFT(Name, 1) IN ('M','K','B','E')
ORDER BY [Name]

--10
SELECT EmployeeID, FirstName, LastName, Salary,
DENSE_RANK() OVER(PARTITION BY [Salary] ORDER BY [EmployeeID]) AS [Rank]
FROM [Employees]
WHERE Salary BETWEEN 10000 AND 50000
ORDER BY Salary DESC

--11
SELECT * FROM 
(SELECT EmployeeID, FirstName, LastName, Salary,
DENSE_RANK() OVER(PARTITION BY [Salary] ORDER BY [EmployeeID]) AS [Rank]
FROM [Employees]
WHERE Salary BETWEEN 10000 AND 50000 ) AS RankingTable
WHERE [Rank] = 2
ORDER BY Salary DESC

--12
USE [Geography]

SELECT [CountryName] AS [Country Name], [IsoCode] AS [ISO Code] FROM Countries
WHERE [CountryName] LIKE '%a%a%a%'
ORDER BY [ISO Code]

--13
SELECT p.PeakName , r.RiverName,
LOWER(CONCAT(LEFT(p.PeakName, LEN(p.PeakName) -1 ), r.RiverName)) AS [Mix]
FROM [Peaks] AS p,
     [Rivers] AS r
WHERE LOWER(RIGHT(p.PeakName, 1)) = LOWER(LEFT(r.RiverName, 1))
ORDER BY Mix

--17
Use Diablo

SELECT [Name] AS Game, 
CASE 
WHEN DATEPART(HOUR, [Start]) >= 0 AND DATEPART(HOUR, [Start]) < 12 THEN 'Morning'
WHEN DATEPART(HOUR, [Start]) >= 12 AND DATEPART(HOUR, [Start]) < 18 THEN 'Afternoon'
ELSE 'Evening'
END AS [Part of the Day],
CASE
WHEN Duration <= 3 THEN 'Extra Short'
WHEN Duration BETWEEN 4 AND 6 THEN 'Short'
WHEN Duration > 6 THEN 'Long'
ELSE 'Extra Long'
END AS 
Duration FROM Games AS g
ORDER BY Game, Duration, [Part of the Day]