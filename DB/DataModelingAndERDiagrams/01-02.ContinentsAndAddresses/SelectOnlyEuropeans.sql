-- With JOINs
SELECT FirstName + ' ' + LastName AS Name
FROM Persons
	JOIN Addresses
	ON Persons.AddressID = Addresses.ID
		JOIN Towns
		ON Addresses.TownID = Towns.ID
			JOIN Countries
			ON Towns.CountryID = Countries.ID
				JOIN Continents
				ON Countries.ContinentID = Continents.ID
WHERE Continents.Name='Europe';

-- With nested SELECTs
/*
SELECT FirstName + ' ' + LastName AS Name FROM Persons
WHERE AddressID IN (
	SELECT ID FROM Addresses
	WHERE TownID IN (
		SELECT ID FROM Towns
		WHERE CountryID IN (
			SELECT ID FROM Countries
			WHERE ContinentID IN (
				SELECT ID FROM Continents
				WHERE Name='Europe'
			)
		)
	)
);
*/