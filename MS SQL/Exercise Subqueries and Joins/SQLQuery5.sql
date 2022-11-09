USE SoftUni
--1
SELECT TOP (5) e.EmployeeID, e.JobTitle, e.AddressID, a.AddressText
FROM Employees AS e
LEFT JOIN Addresses AS a
ON e.AddressID = a.AddressID
ORDER BY e.AddressID

--5
SELECT TOP (3) e.EmployeeID, e.FirstName
FROM Employees AS e
LEFT JOIN EmployeesProjects AS ep
ON e.EmployeeID = ep.EmployeeID
WHERE ep.ProjectID IS NULL
ORDER BY e.EmployeeID

--7
SELECT TOP (5) e.EmployeeID, e.FirstName, p.[Name] AS ProjectName
FROM Employees AS e
INNER JOIN EmployeesProjects AS ep
ON e.EmployeeID = ep.EmployeeID
INNER JOIN Projects AS p
ON ep.ProjectID = p.ProjectID
WHERE p.StartDate > '08.13.2002' AND p.EndDate IS NULL
ORDER BY e.EmployeeID

--8
SELECT e.EmployeeID, e.FirstName,
CASE 
WHEN YEAR (p.StartDate) >= 2005 THEN NULL
ELSE p.[Name]
END AS ProjectName
FROM Employees AS e
INNER JOIN EmployeesProjects AS ep
ON e.EmployeeID = ep.EmployeeID
INNER JOIN Projects AS p
ON ep.ProjectID = p.ProjectID
WHERE e.EmployeeID = 24

USE [Geography]
--12
SELECT c.CountryCode, m.MountainRange, p.PeakName, p.Elevation
FROM Peaks AS p
LEFT JOIN Mountains AS m
ON p.MountainId = m.Id
LEFT JOIN MountainsCountries AS mc
ON m.Id = mc.MountainId
LEFT JOIN Countries AS c
ON mc.CountryCode = c.CountryCode
WHERE c.CountryCode = 'BG' AND p.Elevation > 2835
ORDER BY p.Elevation DESC

--13
SELECT c.CountryCode, 
COUNT(mc.MountainId) AS MountainRanges
FROM Countries AS c
LEFT JOIN MountainsCountries AS mc
ON c.CountryCode = mc.CountryCode
WHERE c.CountryCode IN ('BG','RU','US')
GROUP BY c.CountryCode

--15
SELECT ContinentCode, CurrencyCode, CurrencyCount AS CurrencyUsage
FROM 
(
SELECT * ,
DENSE_RANK() OVER(PARTITION BY ContinentCode ORDER BY CurrencyCount DESC)
AS CurrencyRank
FROM (
SELECT ContinentCode, CurrencyCode,
COUNT (CurrencyCode) AS CurrencyCount
FROM Countries
GROUP BY ContinentCode, CurrencyCode
)
AS CurrencyCountSubQuery
WHERE CurrencyCount > 1
) AS CurrencyRankingSubQuery
WHERE CurrencyRank = 1
ORDER BY ContinentCode

--16
select top (5) c.CountryName ,
MAX(p.Elevation) as HighestPeakElevation,
MAX(r.[Length]) as LongestRiverLength
from Countries as c
left join MountainsCountries as mc
on c.CountryCode  = mc.CountryCode
left join Mountains as m
on mc.MountainId = m.Id
left join Peaks as p
on m.Id = p.MountainId
left join CountriesRivers as cr
on c.CountryCode = cr.CountryCode
left join Rivers as r
on cr.RiverId = r.Id
group by c.CountryName
order by HighestPeakElevation desc, LongestRiverLength desc, CountryName