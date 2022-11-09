CREATE DATABASE CigarShop
USE CigarShop

--1
CREATE TABLE Sizes(
Id INT PRIMARY KEY IDENTITY,
[Length] INT CHECK([Length] BETWEEN 10 AND 25) NOT NULL,
RingRange DECIMAL(18, 2) CHECK(RingRange BETWEEN 1.5 AND 7.5) NOT NULL
)

CREATE TABLE Tastes(
Id INT PRIMARY KEY IDENTITY,
TasteType VARCHAR(20) NOT NULL,
TasteStrength VARCHAR(15) NOT NULL,
ImageURL NVARCHAR(100) NOT NULL
)

CREATE TABLE Brands(
Id INT PRIMARY KEY IDENTITY,
BrandName VARCHAR(30) UNIQUE NOT NULL,
BrandDescription VARCHAR(MAX) 
)

CREATE TABLE Cigars(
Id INT PRIMARY KEY IDENTITY,
CigarName VARCHAR(80) NOT NULL,
BrandId INT FOREIGN KEY REFERENCES Brands(Id) NOT NULL,
TastId INT FOREIGN KEY REFERENCES Tastes(Id) NOT NULL,
SizeId INT FOREIGN KEY REFERENCES Sizes(Id) NOT NULL,
PriceForSingleCigar DECIMAL(18, 2) NOT NULL,
ImageURL NVARCHAR(100) NOT NULL
)

CREATE TABLE Addresses(
Id INT PRIMARY KEY IDENTITY,
Town VARCHAR(30) NOT NULL,
Country NVARCHAR(30) NOT NULL,
Streat NVARCHAR(100) NOT NULL,
ZIP VARCHAR(20) NOT NULL
)

CREATE TABLE Clients(
Id INT PRIMARY KEY IDENTITY,
FirstName NVARCHAR(30) NOT NULL,
LastName NVARCHAR(30) NOT NULL,
Email NVARCHAR(50) NOT NULL,
AddressId INT FOREIGN KEY REFERENCES Addresses(Id) NOT NULL
)

CREATE TABLE ClientsCigars(
ClientId INT FOREIGN KEY REFERENCES Clients(Id),
CigarId INT FOREIGN KEY REFERENCES Cigars(Id),
PRIMARY KEY (ClientId, CigarId)
)

--2
INSERT INTO Cigars(CigarName, BrandId, TastId, SizeId, PriceForSingleCigar, ImageURL)
VALUES
('COHIBA ROBUSTO', 9, 1, 5, 15.50, 'cohiba-robusto-stick_18.jpg'),
('COHIBA SIGLO I', 9, 1, 10, 410.00, 'cohiba-siglo-i-stick_12.jpg'),
('HOYO DE MONTERREY LE HOYO DU MAIRE', 14, 5, 11, 7.50, 'hoyo-du-maire-stick_17.jpg'),
('HOYO DE MONTERREY LE HOYO DE SAN JUAN', 14, 4, 15, 32.00, 'hoyo-de-san-juan-stick_20.jpg'),
('TRINIDAD COLONIALES', 2, 3, 8, 85.21, 'trinidad-coloniales-stick_30.jpg')


INSERT INTO Addresses(Town, Country, Streat, ZIP)
VALUES
('Sofia', 'Bulgaria', '18 Bul. Vasil levski', '1000'),
('Athens', 'Greece', '4342 McDonald Avenue', '10435'),
('Zagreb', 'Croatia', '4333 Lauren Drive', '10000')

--3
SELECT*
FROM Cigars AS c
LEFT JOIN Tastes AS t
ON c.TastId = t.Id
WHERE t.TasteType = 'Spicy'

SELECT *
FROM Brands
WHERE BrandDescription IS NULL

UPDATE Cigars SET PriceForSingleCigar = PriceForSingleCigar * 1.20
WHERE TastId IN(SELECT Id FROM Tastes WHERE TasteType = 'Spicy')

UPDATE Brands SET BrandDescription = 'New description'
WHERE BrandDescription IS NULL

--4
SELECT * FROM Addresses
WHERE Country LIKE 'C%'

DELETE FROM Clients WHERE AddressId IN(SELECT Id FROM Addresses WHERE Country LIKE 'C%' )
DELETE FROM Addresses WHERE Country LIKE 'C%'

--5
SELECT CigarName, PriceForSingleCigar, ImageURL
FROM Cigars
ORDER BY PriceForSingleCigar, CigarName DESC

--6
SELECT c.Id, c.CigarName, c.PriceForSingleCigar, t.TasteType, t.TasteStrength
FROM Cigars AS c
LEFT JOIN Tastes AS t
ON c.TastId = t.Id
WHERE t.TasteType = 'Earthy' OR t.TasteType = 'Woody'
ORDER BY PriceForSingleCigar DESC

--7
SELECT Id, 
        CONCAT(c.FirstName, ' ',c.LastName) AS ClientName,
		Email
FROM Clients AS c
LEFT JOIN ClientsCigars AS cc
ON cc.ClientId = c.Id
WHERE cc.ClientId IS NULL
ORDER BY ClientName

--8
SELECT TOP(5) c.CigarName, c.PriceForSingleCigar, c.ImageURL
FROM Cigars AS c
LEFT JOIN Sizes AS s
ON c.SizeId = s.Id
WHERE s.[Length] >= 12 AND (c.CigarName LIKE '%ci%' OR
      c.PriceForSingleCigar > 50.00) AND s.RingRange > 2.55
ORDER BY c.CigarName, c.PriceForSingleCigar DESC

--9
SELECT CONCAT(c.FirstName, ' ', c.LastName) AS FullName,
       a.Country,
	   a.ZIP,
	   CONCAT('$',MAX(ci.PriceForSingleCigar)) AS CigarPrice
FROM Clients AS c
LEFT JOIN Addresses AS a
ON c.AddressId = a.Id
LEFT JOIN ClientsCigars AS cc
ON cc.ClientId = c.Id
LEFT JOIN Cigars AS ci
ON cc.CigarId= ci.Id
WHERE a.ZIP NOT LIKE '%[^0123456789]%'
GROUP BY c.FirstName,c.LastName, a.Country, a.ZIP
ORDER BY FullName

--10
SELECT c.LastName,
		AVG(s.[Length]) AS CiagrLength,
		CEILING(AVG(s.RingRange)) AS CiagrRingRange
FROM Clients AS c
JOIN ClientsCigars AS cc
ON cc.ClientId = c.Id
JOIN Cigars AS ci
ON cc.CigarId = ci.Id
JOIN Sizes AS s
ON ci.SizeId = s.Id
GROUP BY c.LastName
ORDER BY CiagrLength DESC

--11
GO
SELECT c.FirstName,
COUNT(*)
FROM Clients AS c
LEFT JOIN ClientsCigars AS cc
ON cc.ClientId = c.Id
GROUP BY c.FirstName
GO

CREATE FUNCTION udf_ClientWithCigars(@name VARCHAR(30))
RETURNS INT 
BEGIN
    RETURN(
			SELECT COUNT(*)
			FROM Clients AS c
			LEFT JOIN ClientsCigars AS cc
			ON cc.ClientId = c.Id
			WHERE c.FirstName = @name)

END

--12
SELECT c.CigarName, 
       CONCAT(c.PriceForSingleCigar,'$') AS [Price],
	   b.BrandName,
	   CONCAT(s.[Length],' cm') AS CigarLength,
	   CONCAT(s.RingRange, ' cm') AS CigarRingRange
FROM Cigars AS c
LEFT JOIN Brands AS b
ON c.BrandId = b.Id
LEFT JOIN Sizes AS s
ON c.SizeId = s.Id
LEFT JOIN Tastes AS t
ON c.TastId = t.Id

GO
CREATE PROCEDURE usp_SearchByTaste(@taste VARCHAR(20)) 
AS
BEGIN
SELECT c.CigarName, 
       CONCAT('$', c.PriceForSingleCigar) AS [Price],
	   t.TasteType,
	   b.BrandName,
	   CONCAT(s.[Length],' cm') AS CigarLength,
	   CONCAT(s.RingRange, ' cm') AS CigarRingRange
FROM Cigars AS c
LEFT JOIN Brands AS b
ON c.BrandId = b.Id
LEFT JOIN Sizes AS s
ON c.SizeId = s.Id
LEFT JOIN Tastes AS t
ON c.TastId = t.Id
WHERE t.TasteType = @taste
ORDER BY CigarLength, CigarRingRange DESC 
END
GO

EXEC usp_SearchByTaste 'Woody'