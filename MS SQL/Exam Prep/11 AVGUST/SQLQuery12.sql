CREATE DATABASE Bakery

USE Bakery

--1
CREATE TABLE Countries
(
	Id INT PRIMARY KEY IDENTITY,
	Name NVARCHAR(50) UNIQUE NOT NULL
)
CREATE TABLE Customers
(
	Id INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(25) NOT NULL,
	LastName NVARCHAR(25) NOT NULL,
	Gender CHAR(1) CHECK(Gender IN ('M','F')) NOT NULL,
	Age INT NOT NULL,
	PhoneNumber CHAR(10) NOT NULL,
	CountryId INT REFERENCES Countries(Id) NOT NULL
)

CREATE TABLE Products
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(25) UNIQUE NOT NULL,
	[Description] NVARCHAR(250) NOT NULL,
	Recipe NVARCHAR(MAX) NOT NULL,
	Price DECIMAL(18,2) CHECK(Price >= 0) NOT NULL
)

CREATE TABLE Feedbacks
(
	Id INT PRIMARY KEY IDENTITY,
	[Description] NVARCHAR(255) NOT NULL,
	Rate DECIMAL(4,2) CHECK(Rate BETWEEN 0 AND 10) NOT NULL,
	ProductId INT REFERENCES Products(Id) NOT NULL,
	CustomerId INT REFERENCES Customers(Id) NOT NULL,
)

CREATE TABLE Distributors
(
	Id INT PRIMARY KEY IDENTITY,
	Name NVARCHAR(25) UNIQUE NOT NULL,
	AddressText NVARCHAR(30) NOT NULL,
	Summary NVARCHAR(200) NOT NULL,
	CountryId INT REFERENCES Countries(Id) NOT NULL
)
CREATE TABLE Ingredients
(
	Id INT PRIMARY KEY IDENTITY,
	Name NVARCHAR(25) NOT NULL,
	[Description] NVARCHAR(200) NOT NULL,
	OriginCountryId INT REFERENCES Countries(Id) NOT NULL,
	DistributorId INT REFERENCES Distributors(Id) NOT NULL,
)

CREATE TABLE ProductsIngredients
(
	ProductId INT REFERENCES Products(Id) NOT NULL,
	IngredientId INT REFERENCES Ingredients(Id) NOT NULL,
	PRIMARY KEY (ProductId,IngredientId)
)


--2
INSERT INTO Distributors(Name,CountryId,AddressText,Summary) VALUES
('Deloitte & Touche', 2, '6 Arch St #9757',	'Customizable neutral traveling'),
('Congress Title', 13, '58 Hancock St',	'Customer loyalty'),
('Kitchen People', 1, '3 E 31st St #77', 'Triple-buffered stable delivery'),
('General Color Co Inc', 21, '6185 Bohn St #72', 'Focus group'),
('Beck Corporation',23, '21 E 64th Ave', 'Quality-focused 4th generation hardware')

INSERT INTO Customers(FirstName,LastName,Age,Gender,PhoneNumber,CountryId) VALUES
('Francoise', 'Rautenstrauch', 15, 'M', '0195698399', 5),
('Kendra', 'Loud',	22,	'F', '0063631526', 11),
('Lourdes', 'Bauswell',	50,	'M', '0139037043', 8),
('Hannah', 'Edmison',	18,	'F', '0043343686', 1),
('Tom', 'Loeza', 31, 'M', '0144876096', 23),
('Queenie', 'Kramarczyk', 30, 'F', '0064215793', 29),
('Hiu', 'Portaro',	25, 'M', '0068277755', 16),
('Josefa', 'Opitz', 43, 'F', '0197887645', 17)

--3
SELECT * FROM Ingredients
WHERE [Name] IN ('Bay Leaf', 'Paprika', 'Poppy') 

SELECT * FROM Ingredients
WHERE OriginCountryId = 8

UPDATE Ingredients SET DistributorId = 35 WHERE [Name] IN ('Bay Leaf', 'Paprika', 'Poppy') 
UPDATE Ingredients SET OriginCountryId = 14 WHERE OriginCountryId = 8

--4
DELETE FROM FeedBacks
	WHERE CustomerId = 14 OR ProductId = 5

--5
SELECT [Name] , Price, [Description]
FROM Products
ORDER BY Price DESC, [Name]

--6
SELECT f.ProductId,f.Rate,f.Description,f.CustomerId,c.Age,c.Gender
	FROM Feedbacks AS f
	JOIN Customers AS c ON c.Id = f.CustomerId
	WHERE f.Rate < 5.0
 ORDER BY f.ProductId DESC,f.Rate

 --7
 SELECT CONCAT(FirstName,' ',LastName) AS CustomerName,PhoneNumber,Gender
	FROM Customers
	WHERE Id NOT IN (SELECT CustomerId FROM Feedbacks)
 ORDER BY Id 

 --8
 SELECT c.FirstName,c.Age,c.PhoneNumber
	FROM Customers AS c
	JOIN Countries AS cr ON cr.Id = c.CountryId
	WHERE (Age >= 21 AND FirstName LIKE '%an%') 
		  OR (PhoneNumber LIKE '%38' AND cr.Name != 'Greece')
 ORDER BY c.FirstName,c.Age DESC

 --9
 SELECT d.Name,i.Name,p.Name,AVG(f.Rate) AS AverageRate
	FROM ProductsIngredients AS pi
	JOIN Ingredients AS i ON i.Id = pi.IngredientId
	JOIN Products AS p ON p.Id = pi.ProductId
	JOIN Distributors AS d ON d.Id = i.DistributorId
	JOIN Feedbacks AS f ON f.ProductId = p.Id
 GROUP BY d.Name,i.Name,p.Name
 HAVING AVG(f.Rate) BETWEEN 5 AND 8
 ORDER BY d.Name,i.Name,p.Name

 --10
 SELECT r.CName,r.DName
	FROM (SELECT c.Name AS CName,r.Name AS DName,DENSE_RANK() OVER (PARTITION BY c.Name ORDER BY r.count DESC) AS Rank
	FROM (SELECT *,(SELECT COUNT(*) FROM Ingredients AS i  WHERE i.DistributorId = d.Id) AS Count
	FROM Distributors AS d) AS r
 JOIN Countries AS c  ON c.Id = r.CountryId) AS r
 WHERE r.Rank = 1
 ORDER BY r.CName,r.DName

 --11
 GO

 CREATE VIEW v_UserWithCountries AS 
SELECT CONCAT(c.FirstName,' ',c.LastName) AS CustomerName,
	   c.Age,
	   c.Gender,
	   ct.Name
	FROM Customers AS c
	JOIN Countries AS ct ON ct.Id = c.CountryId

--12
GO
CREATE TRIGGER tr_InstedDeleteOnProducts
ON Products INSTEAD OF DELETE
AS
	DELETE FROM Feedbacks
		WHERE ProductId IN (SELECT Id FROM deleted)

	DELETE FROM ProductsIngredients
		WHERE ProductId IN (SELECT Id FROM deleted)

	DELETE FROM Products
		WHERE Id IN (SELECT Id FROM deleted)


DELETE FROM Products WHERE Id = 7