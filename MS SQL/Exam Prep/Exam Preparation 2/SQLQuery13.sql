CREATE DATABASE School

USE School

--1
CREATE TABLE Students(
Id INT PRIMARY KEY IDENTITY,
FirstName VARCHAR(30) NOT NULL,
MiddleName VARCHAR(25) ,
LastName VARCHAR(30) NOT NULL,
Age INT CHECK(Age >= 5 AND Age <= 100) NOT NULL,
[Address] VARCHAR(50),
Phone CHAR(10) CHECK (LEN(Phone) = 10)
)

CREATE TABLE Subjects(
Id INT PRIMARY KEY IDENTITY,
[Name] VARCHAR(20) NOT NULL,
Lessons INT CHECK(Lessons > 0) NOT NULL
)

CREATE TABLE StudentsSubjects(
Id INT PRIMARY KEY IDENTITY,
StudentId INT FOREIGN KEY REFERENCES Students(Id) NOT NULL,
SubjectId INT FOREIGN KEY REFERENCES Subjects(Id) NOT NULL,
Grade DECIMAL(18, 2) CHECK (Grade BETWEEN 2 AND 6) NOT NULL
)

CREATE TABLE Exams(
Id INT PRIMARY KEY IDENTITY,
[Date] DATETIME,
SubjectId INT FOREIGN KEY REFERENCES Subjects(Id) NOT NULL
)

CREATE TABLE StudentsExams(
StudentId INT FOREIGN KEY REFERENCES Students(Id) NOT NULL,
ExamId INT FOREIGN KEY REFERENCES Exams(Id) NOT NULL,
Grade DECIMAL(18, 2) CHECK (Grade BETWEEN 2 AND 6) NOT NULL
)

CREATE TABLE Teachers(
Id INT PRIMARY KEY IDENTITY,
FirstName VARCHAR(20) NOT NULL,
LastName VARCHAR(20) NOT NULL,
[Address] VARCHAR(20) NOT NULL,
Phone CHAR(10) CHECK (LEN(Phone) = 10),
SubjectId INT FOREIGN KEY REFERENCES Subjects(Id) NOT NULL
)

CREATE TABLE StudentsTeachers(
StudentId INT FOREIGN KEY REFERENCES Students(Id) NOT NULL,
TeacherId INT FOREIGN KEY REFERENCES Teachers(Id) NOT NULL,
PRIMARY KEY(StudentId, TeacherId)
)

--2
INSERT INTO Teachers(FirstName,LastName,[Address],Phone,SubjectId)
VALUES
('Ruthanne', 'Bamb', '84948 Mesta Junction', 3105500146, 6),
('Gerrard',	'Lowin', '370 Talisman Plaza',	3324874824,	2),
('Merrile',	'Lambdin',	'81 Dahle Plaza',	4373065154,	5),
('Bert', 'Ivie', '2 Gateway Circle', 4409584510, 4)

INSERT INTO Subjects( [Name], Lessons)
VALUES
('Geometry', 12),
('Health', 10),
('Drama', 7),
('Sports', 9)

--3
UPDATE StudentsSubjects
	SET Grade = 6.00
	WHERE SubjectId IN (1,2) AND Grade >= 5.50

--4
SELECT *
FROM Teachers
WHERE Phone LIKE '%72%'

DELETE FROM StudentsTeachers
	WHERE TeacherId IN (SELECT Id FROM Teachers WHERE Phone LIKE '%72%')
DELETE FROM Teachers WHERE Phone LIKE '%72%'

--5
SELECT FirstName, LastName, Age
FROM Students
WHERE Age >= 12
ORDER BY FirstName, LastName

--6
SELECT  s.FirstName, s.LastName, COUNT(*) AS TeachersCount
FROM Students AS s
LEFT JOIN StudentsTeachers AS st
ON s.Id = st.StudentId
GROUP BY s.FirstName, s.LastName

--7
SELECT CONCAT(s.FirstName,' ',s.LastName) AS FullName
FROM Students AS s
LEFT JOIN StudentsExams AS se
ON se.StudentId = s.Id
WHERE se.StudentId IS NULL
ORDER BY FullName

--8
SELECT TOP(10) s.FirstName, s.LastName,
			   CAST(AVG(se.Grade) AS DECIMAL(18,2)) AS Grade
FROM Students AS s
LEFT JOIN StudentsExams AS se
ON se.StudentId = s.Id
GROUP BY s.FirstName, s.LastName
ORDER BY Grade DESC, FirstName, LastName

--9
SELECT CONCAT(s.FirstName, ISNULL(' ' + s.MiddleName + ' ',' '), s.LastName) AS [Full Name] 
FROM Students AS s
LEFT JOIN StudentsSubjects AS ss
ON ss.StudentId = s.Id
WHERE ss.StudentId IS NULL
ORDER BY [Full Name]

--10
SELECT sub.[Name], AVG(ss.Grade)
	FROM Subjects AS sub
	JOIN StudentsSubjects AS ss 
	ON ss.SubjectId = sub.Id
	GROUP BY sub.Id,sub.[Name]
	ORDER BY sub.Id

--11
GO

CREATE FUNCTION udf_ExamGradesToUpdate(@studentId INT, @grade DECIMAL(18,2))
RETURNS VARCHAR(MAX) AS 
BEGIN
	IF(@grade > 6.00)
		RETURN 'Grade cannot be above 6.00!'
	IF(NOT EXISTS (SELECT 1 FROM Students WHERE Id = @studentId))
		RETURN 'The student with provided id does not exist in the school!'

	DECLARE @GradesCount INT = (SELECT COUNT(*) FROM StudentsExams WHERE StudentId = @studentId AND Grade BETWEEN @grade AND (@grade + 0.50))

	DECLARE @FirstName NVARCHAR(30) = (SELECT FirstName FROM Students WHERE Id = @studentId)

	RETURN CONCAT('You have to update ', @GradesCount, ' grades for the student ', @FirstName)
END

GO
SELECT dbo.udf_ExamGradesToUpdate(12, 6.20)
SELECT dbo.udf_ExamGradesToUpdate(12, 5.50)
SELECT dbo.udf_ExamGradesToUpdate(121, 5.50)

--12
GO
CREATE PROC usp_ExcludeFromSchool(@StudentId INT)
AS
BEGIN
	IF(NOT EXISTS (SELECT 1 FROM Students WHERE Id = @StudentId))
		 RAISERROR('This school has no student with the provided id!',16,1)

	DELETE FROM StudentsExams
		WHERE StudentId = @StudentId

	DELETE FROM StudentsSubjects
		WHERE StudentId = @StudentId

	DELETE FROM StudentsTeachers
		WHERE StudentId = @StudentId

	DELETE FROM Students
		WHERE Id = @StudentId
END