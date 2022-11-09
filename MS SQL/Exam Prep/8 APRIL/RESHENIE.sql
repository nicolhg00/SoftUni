CREATE DATABASE [Service]

USE [Service]

--1
CREATE TABLE Users(
Id INT PRIMARY KEY IDENTITY,
Username VARCHAR(30) UNIQUE NOT NULL,
[Password] VARCHAR(50) NOT NULL,
[Name] VARCHAR(50),
Birthdate DATETIME2,
Age INT,
Email VARCHAR(50) NOT NULL,
CHECK(Age >= 14 AND AGE <= 110)
)

CREATE TABLE Departments(
Id INT PRIMARY KEY IDENTITY,
[Name] VARCHAR(50) NOT NULL
)

CREATE TABLE Employees(
Id INT PRIMARY KEY IDENTITY,
FirstName VARCHAR(25),
LastName VARCHAR(25),
Birthdate DATETIME2,
Age INT,
DepartmentId INT FOREIGN KEY REFERENCES Departments(Id),
CHECK(Age >= 18 AND AGE <= 110)
)

CREATE TABLE Categories(
Id INT PRIMARY KEY IDENTITY,
[Name] VARCHAR(50) NOT NULL,
DepartmentId INT FOREIGN KEY REFERENCES Departments(Id) NOT NULL
)

CREATE TABLE [Status](
Id INT PRIMARY KEY IDENTITY,
[Label] VARCHAR(30) NOT NULL
)

CREATE TABLE Reports(
Id INT PRIMARY KEY IDENTITY,
CategoryId INT FOREIGN KEY REFERENCES Categories(Id) NOT NULL,
StatusId INT FOREIGN KEY REFERENCES [Status](Id) NOT NULL,
OpenDate DATETIME2 NOT NULL,
CloseDate DATETIME2,
[Description] VARCHAR(200) NOT NULL,
UserId INT FOREIGN KEY REFERENCES Users(Id) NOT NULL,
EmployeeId INT FOREIGN KEY REFERENCES Employees(Id)
)

--2
INSERT INTO Employees(FirstName, LastName, Birthdate, DepartmentId)
VALUES
('Marlo', 'O Malley','1958-9-21', 1),
('Niki', 'Stanaghan', '1969-11-26',	4),
('Ayrton', 'Senna',	'1960-03-21', 9),
('Ronnie', 'Peterson', '1944-02-14', 9),
('Giovanna', 'Amati', '1959-07-20',	5)

INSERT INTO Reports(CategoryId,StatusId,OpenDate,CloseDate,[Description], UserId,EmployeeId)
VALUES
(1, 1, '2017-04-13', NULL, 'Stuck Road on Str.133', 6, 2),
(6, 3, '2015-09-05', '2015-12-06', 'Charity trail running', 3, 5),
(14, 2, '2015-09-07', NULL, 'Falling bricks on Str.58', 5, 2),
(4, 3, '2017-07-03', '2017-07-06', 'Cut off streetlight on Str.11', 1, 1)

--3
SELECT CloseDate
FROM Reports
WHERE CloseDate IS NULL

UPDATE Reports SET CloseDate = GETDATE()
WHERE CloseDate IS NULL

--4
SELECT *
FROM Reports
WHERE [StatusId] = 4

DELETE FROM Reports WHERE [StatusId] = 4

--5
SELECT [Description], 
		FORMAT(OpenDate, 'dd-MM-yyyy')
FROM Reports
WHERE EmployeeId IS NULL
ORDER BY OpenDate, [Description] 

--6
SELECT r.[Description], c.[Name] AS [CategoryName]
FROM Reports AS r
JOIN Categories AS c
ON r.CategoryId = c.Id
ORDER BY [Description], CategoryName

--7
SELECT TOP(5) c.[Name],
			  COUNT(r.CategoryId) AS ReportsNumber
FROM Reports AS r
JOIN Categories AS c
ON c.Id = r.CategoryId
GROUP BY c.[Name]
ORDER BY ReportsNumber DESC, c.[Name]

--8
SELECT u.Username,
       c.[Name] AS CategoryName
FROM Reports AS r
LEFT JOIN Users AS u
ON r.UserId = u.Id
LEFT JOIN Categories AS c
ON r.CategoryId = c.Id
LEFT JOIN [Status] AS s
ON r.StatusId = s.Id
WHERE (DATEPART(mm,u.Birthdate) = 
	   DATEPART(mm, r.OpenDate))
   AND (DATEPART(d, u.Birthdate) =
       DATEPART(d, r.OpenDate))
ORDER BY Username, c.[Name]

--9
SELECT CONCAT(e.FirstName, ' ', e.LastName) AS FullName,
       COUNT(u.Id) AS UsersCount
FROM Employees AS e
LEFT JOIN Reports AS r
ON e.Id = r.EmployeeId
LEFT JOIN Users AS u
ON r.UserId = u.Id
GROUP BY CONCAT(e.FirstName, ' ', e.LastName)
ORDER BY UsersCount DESC, FullName

--10
SELECT CONCAT(e.FirstName, ' ', e.LastName) AS Employee,
	   IIF(d.[Name] IS NULL, 'None', d.[Name]) AS Department,
	   c.[Name] AS Category,
	   r.[Description],
	   FORMAT(OpenDate, 'dd.MM.yyyy') AS OpenDate,
	   s.[Label] AS [Status],
	   u.[Name] AS [User]
FROM Employees AS e
LEFT JOIN Reports AS r 
	ON r.EmployeeId= e.Id
LEFT JOIN Users AS u 
	ON u.Id= r.UserId
LEFT JOIN Departments AS d 
	ON d.Id =e.DepartmentId
LEFT JOIN Categories AS c 
	ON r.CategoryId= c.Id
JOIN Status AS s 
	ON r.StatusId= s.Id 
 ORDER BY e.FirstName DESC,
		 e.LastName DESC,
		 Department ASC,
		 Category ASC,
		 [Description] ASC,
		 OpenDate ASC,
		 [Status] ASC,
		 [User] ASC

--11
GO
CREATE FUNCTION udf_HoursToComplete(@StartDate DATETIME, @EndDate DATETIME)
RETURNS INT
BEGIN
RETURN (SELECT ISNULL(CASE WHEN DATEDIFF(HOUR, @StartDate, @EndDate) = 0 THEN 0
		ELSE DATEDIFF(HOUR, @StartDate, @EndDate) END, 0))
END

GO

SELECT dbo.udf_HoursToComplete(OpenDate, CloseDate) AS TotalHours
   FROM Reports
   GO
--12
CREATE PROC usp_AssignEmployeeToReport(@EmployeeId INT, @ReportId INT)
AS
 
UPDATE Reports SET EmployeeId=@EmployeeId
WHERE Reports.Id IN (
SELECT  Tbl02.RaportId
FROM(SELECT E.DepartmentId, D1.Name,E.Id
FROM Departments AS D1
JOIN Employees AS E
ON E.DepartmentId=D1.Id) AS Tbl01
JOIN 
(SELECT C.DepartmentId,D2.Name,R.Id AS [RaportId]
FROM Departments AS D2
JOIN Categories AS C
ON C.DepartmentId=D2.Id
JOIN Reports AS R
ON R.CategoryId=C.Id) AS Tbl02
ON Tbl02.DepartmentId=Tbl01.DepartmentId
WHERE Tbl01.Id=@EmployeeId AND TBL02.RaportId=@ReportId)
BEGIN TRY
   IF NOT EXISTS (
 
  SELECT  Tbl02.RaportId
FROM(SELECT E.DepartmentId, D1.Name,E.Id
FROM Departments AS D1
JOIN Employees AS E
ON E.DepartmentId=D1.Id) AS Tbl01
JOIN 
(SELECT C.DepartmentId,D2.Name,R.Id AS [RaportId]
FROM Departments AS D2
JOIN Categories AS C
ON C.DepartmentId=D2.Id
JOIN Reports AS R
ON R.CategoryId=C.Id) AS Tbl02
ON Tbl02.DepartmentId=Tbl01.DepartmentId
WHERE Tbl01.Id=@EmployeeId AND TBL02.RaportId=@ReportId
 
   )
        THROW 51000, 'Employee doesn''t belong to the appropriate department!', 1;
 
 
END TRY
BEGIN CATCH
    THROW;
END CATCH