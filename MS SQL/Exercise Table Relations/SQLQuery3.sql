CREATE DATABASE EntityRelstionsDemo

USE EntityRelstionsDemo

CREATE TABLE Passports(
PassportID INT PRIMARY KEY NOT NULL,
PassportNumber CHAR(8) NOT NULL,
)

CREATE TABLE Persons(
PersonID INT PRIMARY KEY IDENTITY NOT NULL,
FirstName VARCHAR(50) NOT NULL,
Salary DECIMAL(9, 2) NOT NULL,
PassportID INT FOREIGN KEY REFERENCES Passports (PassportID) UNIQUE
)

INSERT INTO Passports(PassportID, PassportNumber)
VALUES (101, 'N34FG21B'),
       (102, 'K65LO4R7'),
	   (103, 'ZE657QP2')

INSERT INTO Persons(FirstName,Salary,PassportID)
VALUES ('Roberto', 43300.00, 102),
	   ('Tom', 56100.00, 103),
	   ('Yana', 60200.00, 101)

CREATE TABLE Manufacturers(
ManufacturerID INT PRIMARY KEY IDENTITY NOT NULL,
[Name] VARCHAR(50) NOT NULL,
EstablishedOn DATE NOT NULL
)

CREATE TABLE Models(
ModelID INT PRIMARY KEY IDENTITY(101, 1) NOT NULL,
[Name] VARCHAR(50) NOT NULL,
ManufacturerID INT FOREIGN KEY REFERENCES [Manufacturers](ManufacturerID) NOT NULL
)

INSERT INTO Manufacturers([Name], EstablishedOn)
VALUES ('BMW', '07/03/1916'),
       ('Tesla', '01/01/2003'),
	   ('Lada', '01/05/1966')

INSERT INTO Models([Name], ManufacturerID)
VALUES ('X1', 1),
       ('i6', 1),
	   ('Model S', 2),
	   ('Model X', 2),
	   ('Model 3', 2),
	   ('Nova', 3)


CREATE TABLE Students(
StudentID INT PRIMARY KEY IDENTITY NOT NULL,
[Name] VARCHAR(50) NOT NULL
)

CREATE TABLE Exams(
ExamID INT PRIMARY KEY IDENTITY(101, 1) NOT NULL,
[Name] NVARCHAR(75) NOT NULL
)

CREATE TABLE StudentsExams(
StudentID INT FOREIGN KEY REFERENCES [Students](StudentID) NOT NULL,
ExamID INT FOREIGN KEY REFERENCES [Exams](ExamID) NOT NULL,
PRIMARY KEY(StudentID, ExamID)
)

