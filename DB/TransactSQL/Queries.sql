/*
01. Create a database with two tables: Persons(Id(PK), FirstName, LastName, SSN) and Accounts(Id(PK), PersonId(FK), Balance).
Insert few records for testing. Write a stored procedure that selects the full names of all persons.
*/

CREATE DATABASE BankSystem

USE BankSystem

CREATE TABLE Persons
	(PersonID int PRIMARY KEY IDENTITY,
	FirstName nvarchar(50) NOT NULL,
	LastName nvarchar(50) NOT NULL,
	SSN varchar(9) NOT NULL CHECK(LEN(SSN) = 9))

CREATE TABLE Accounts
	(AccountID int PRIMARY KEY IDENTITY,
	PersonID int REFERENCES Persons(PersonID),
	Balance money NOT NULL)

INSERT INTO Persons (FirstName, LastName, SSN) VALUES
	('Gosho', 'Peshov', '123456789'),
	('Pesho', 'Goshov', '987654321'),
	('Dimitar', 'Dimitrov', '999999999'),
	('Aleksandar', 'Ivanov', '555444666'),
	('Kristian', 'Karakachanov', '123789456')

INSERT INTO Accounts (PersonID, Balance) VALUES
	(1, 500),
	(2, 1000),
	(3, 999999999),
	(4, 100),
	(5, 0)

GO
CREATE PROCEDURE usp_SelectFullNamesOfAllPersons
AS
	SELECT FirstName + ' ' + LastName AS [Full name]
	FROM Persons
GO

EXEC usp_SelectFullNamesOfAllPersons

/*
02. Create a stored procedure that accepts a number as a parameter and returns all persons who have more money in their accounts than the supplied number.
*/

GO
CREATE PROCEDURE usp_AllPersonsWithMoreMoneyThan(@minAmountOfMoney money)
AS
	SELECT p.FirstName + ' ' + p.LastName AS [Full name], a.Balance
	FROM Persons p
		JOIN Accounts a
		ON p.PersonID = a.AccountID
	WHERE a.Balance > @minAmountOfMoney
GO

EXEC usp_AllPersonsWithMoreMoneyThan 400

/*
03. Create a function that accepts as parameters – sum, yearly interest rate and number of months.
It should calculate and return the new sum. Write a SELECT to test whether the function works as expected.
*/

GO
CREATE FUNCTION ufn_CalculateInterest(@sum money, @yearlyInterestRate decimal(5, 2), @numberOfMonths int)
	RETURNS money
AS
BEGIN
	RETURN (@sum * @yearlyInterestRate / 100 * @numberOfMonths / 12)
END
GO

DECLARE @yearlyInterestRate decimal(5, 2) = 20,
		@numberOfMonths int = 1

SELECT p.FirstName + ' ' + p.LastName AS [Full name], CONVERT(varchar(10), @yearlyInterestRate) + '%' AS [Yearly interest rate], @numberOfMonths AS [Number of months],
		dbo.ufn_CalculateInterest(a.Balance, @yearlyInterestRate, @numberOfMonths) AS Interest
FROM Persons p
	JOIN Accounts a
	ON p.PersonID = a.PersonID

/*
04. Create a stored procedure that uses the function from the previous example to give an interest to a person's account for one month.
It should take the AccountId and the interest rate as parameters.
*/

GO
CREATE PROCEDURE usp_GiveInterestForOneMonth(@accountId int, @interestRate decimal(5, 2))
AS
	UPDATE Accounts
	SET Balance = Balance + dbo.ufn_CalculateInterest(Balance, @interestRate, 1)
	WHERE AccountID = @accountId
GO

EXEC usp_GiveInterestForOneMonth 1, 20

/*
05. Add two more stored procedures WithdrawMoney( AccountId, money) and DepositMoney (AccountId, money) that operate in transactions.
*/

GO
CREATE PROCEDURE usp_WithdrawMoney(@accountId int, @amount money)
AS
	DECLARE @availableMoney money

	SELECT @availableMoney = Balance
	FROM Accounts
	WHERE AccountID = @accountId

	IF @availableMoney < @amount
		THROW 50000, 'Not enough money in the account', 1
	ELSE
		UPDATE Accounts
		SET Balance = Balance - @amount
		WHERE AccountID = @accountId
GO

EXEC usp_WithdrawMoney 1, 100
-- The following will throw exception
EXEC usp_WithdrawMoney 1, 1000

GO
CREATE PROCEDURE usp_DepositMoney(@accountId int, @amount money)
AS
	IF @amount < 0
		THROW 50000, 'You cannot deposit negative amount', 1
	ELSE
		UPDATE Accounts
		SET Balance = Balance + @amount
		WHERE AccountID = @accountId
GO

EXEC usp_DepositMoney 2, 1000
-- The following will throw exception
EXEC usp_DepositMoney 1, -100

/*
06. Create another table – Logs(LogID, AccountID, OldSum, NewSum).
Add a trigger to the Accounts table that enters a new entry into the Logs table every time the sum on an account changes.
*/

CREATE TABLE Logs
	(LogID int PRIMARY KEY IDENTITY,
	AccountID int REFERENCES Accounts(AccountID),
	OldSum money NOT NULL,
	NewSum money NOT NULL)

GO
CREATE TRIGGER tr_AmountChangeLogger ON Accounts FOR UPDATE
AS
	DECLARE @accountId int,
			@oldSum money,
			@newSum money,
			@id int

	SELECT DISTINCT AccountID
	INTO #LoopTempTable
	FROM inserted

	WHILE ((SELECT Count(*) FROM #LoopTempTable) > 0)
	BEGIN
		SELECT TOP 1 @id = AccountID FROM #LoopTempTable
		
		SELECT @oldSum = Balance FROM deleted WHERE AccountID = @id
		SELECT @newSum = Balance FROM inserted WHERE AccountID = @id

		INSERT INTO Logs (AccountID, OldSum, NewSum) VALUES
			(@id, @oldSum, @newSum)

		DELETE FROM #LoopTempTable WHERE AccountID = @id
	END
GO

/*
07. Define a function in the database TelerikAcademy that returns all Employee's names (first or middle or last name)
and all town's names that are comprised of given set of letters. Example 'oistmiahf' will return 'Sofia', 'Smith', … but not 'Rob' and 'Guy'.
*/

-- The Function For Every String
CREATE FUNCTION ufn_NameContainingLetters(@name NVARCHAR(50), @letters NVARCHAR(50))
	RETURNS bit
AS
BEGIN
    DECLARE @contains bit = 1,
			@curLetter NVARCHAR(1),
			@counter INT = 1

	IF @name IS NULL
		SET @contains = 0
 
    WHILE(@counter <= LEN(@name))
    BEGIN
		SET @curLetter = SUBSTRING(@name, @counter, 1)
		IF (CHARINDEX(@curLetter, @letters) = 0)
				SET @contains = 0
		SET @counter = @counter + 1
    END

    RETURN @contains
END
GO

-- Procedure to search through First Names
CREATE PROC usp_FindNames(@lettersToSearch NVARCHAR(50))
AS                      
	SELECT FirstName AS [First Names]
	FROM Employees
	WHERE 1 =
		(SELECT dbo.ufn_NameContainingLetters(FirstName, @lettersToSearch))
GO
 
--Procedure to search through Middle Names
CREATE PROC usp_FindMiddleNames(@lettersToSearch NVARCHAR(50))
AS                           
    SELECT MiddleName AS [Middle Names]
    FROM Employees
    WHERE 1 =
		(SELECT dbo.ufn_NameContainingLetters(MiddleName, @lettersToSearch))
GO

--Procedure to search through Last Names
CREATE PROC usp_FindLastNames(@lettersToSearch NVARCHAR(50))
AS                       
    SELECT LastName AS [Last Names]
    FROM Employees
    WHERE 1 =
		(SELECT dbo.ufn_NameContainingLetters(LastName, @lettersToSearch))
GO

--Procedure to search through Towns
CREATE PROC usp_FindTowns(@lettersToSearch NVARCHAR(50))
AS             
    SELECT Name AS Towns
    FROM Towns
    WHERE 1 =
		(SELECT dbo.ufn_NameContainingLetters(Name, @lettersToSearch))    
GO
 
EXEC usp_FindNames @letterstosearch = 'oistmiahf'
EXEC usp_FindMiddleNames @letterstosearch = 'oistmiahf'
EXEC usp_FindLastNames @letterstosearch = 'oistmiahf'
EXEC usp_FindTowns @letterstosearch = 'oistmiahf'

/*
08. Using database cursor write a T-SQL script that scans all employees and their addresses and prints all pairs of employees that live in the same town.
*/

DECLARE empCursor CURSOR READ_ONLY FOR
    SELECT e1.FirstName, e1.LastName, t1.Name, e2.FirstName, e2.LastName
    FROM Employees e1
		JOIN Addresses a1
        ON e1.AddressID = a1.AddressID
			JOIN Towns t1
			ON a1.TownID = t1.TownID,
        Employees e2
			JOIN Addresses a2
            ON e2.AddressID = a2.AddressID
				JOIN Towns t2
				ON a2.TownID = t2.TownID
    WHERE t1.TownID = t2.TownID AND e1.EmployeeID != e2.EmployeeID
    ORDER BY e1.FirstName, e2.FirstName

OPEN empCursor
	DECLARE @firstName1 nvarchar(50), 
			@lastName1 nvarchar(50),
			@townName nvarchar(50),
			@firstName2 nvarchar(50),
			@lastName2 nvarchar(50)
	FETCH NEXT FROM empCursor INTO @firstName1, @lastName1, @townName, @firstName2, @lastName2

	WHILE @@FETCH_STATUS = 0
	BEGIN
		PRINT @firstName1 + ' ' + @lastName1 + '     ' + @townName + '       ' + @firstName2 + ' ' + @lastName2;

		FETCH NEXT FROM empCursor INTO @firstName1, @lastName1, @townName, @firstName2, @lastName2
	END
CLOSE empCursor
DEALLOCATE empCursor

/*
09. * Write a T-SQL script that shows for each town a list of all employees that live in it. Sample output:
*/

CREATE TABLE UsersTowns
	(ID INT PRIMARY KEY IDENTITY,
    FullName NVARCHAR(50),
    TownName NVARCHAR(50))

INSERT INTO UsersTowns
SELECT e.FirstName + ' ' + e.LastName, t.Name
FROM Employees e
        JOIN Addresses a
        ON a.AddressID = e.AddressID
			JOIN Towns t
            ON t.TownID = a.TownID
GROUP BY t.Name, e.FirstName, e.LastName
 
-- Nested cursors to fetch info
DECLARE @name NVARCHAR(50)
DECLARE @town NVARCHAR(50)
 
DECLARE empCursor1 CURSOR READ_ONLY FOR
        SELECT DISTINCT TownName
        FROM UsersTowns
		 
OPEN empCursor1
	FETCH NEXT FROM empCursor1 INTO @town
 
    WHILE @@FETCH_STATUS = 0
    BEGIN
        PRINT @town
 
        DECLARE empCursor2 CURSOR READ_ONLY FOR
                SELECT ut.FullName
                FROM UsersTowns ut
                WHERE ut.TownName = @town

        OPEN empCursor2
                       
			FETCH NEXT FROM empCursor2 INTO @name
                               
			WHILE @@FETCH_STATUS = 0
			BEGIN
				PRINT '   ' + @name
				FETCH NEXT FROM empCursor2 INTO @name
			END

		CLOSE empCursor2
		DEALLOCATE empCursor2
        FETCH NEXT FROM empCursor1 INTO @town
    END
 
CLOSE empCursor1
DEALLOCATE empCursor1

/*
10. Define a .NET aggregate function StrConcat that takes as input a sequence of strings and return a single string that consists of the input strings separated by ','.
For example the following SQL statement should return a single string:
		SELECT StrConcat(FirstName + ' ' + LastName)
		FROM Employees
*/

IF NOT EXISTS (
    SELECT value
    FROM sys.configurations
    WHERE name = 'clr enabled' AND value = 1
)
BEGIN
    EXEC sp_configure @configname = clr_enabled, @configvalue = 1
    RECONFIGURE
END
GO

-- Remove the aggregate and assembly if they're there
IF (OBJECT_ID('dbo.concat') IS NOT NULL) 
    DROP Aggregate concat; 
GO 

IF EXISTS (SELECT * FROM sys.assemblies WHERE name = 'concat_assembly') 
    DROP assembly concat_assembly; 
GO      

CREATE Assembly concat_assembly 
   AUTHORIZATION dbo 
   FROM 'C:\SqlStringConcatenation.dll' --- CHANGE THE LOCATION
   WITH PERMISSION_SET = SAFE; 
GO 

CREATE AGGREGATE dbo.concat ( 
    @Value NVARCHAR(MAX),
    @Delimiter NVARCHAR(4000) 
) 
    RETURNS NVARCHAR(MAX) 
    EXTERNAL Name concat_assembly.concat; 
GO 

SELECT dbo.concat(FirstName + ' ' + LastName, ', ')
FROM Employees
GO

DROP Aggregate concat; 
DROP assembly concat_assembly; 
GO