-- Hi, before evaluating the tasks change the dafult database to TelerikAcademy or run the whole query (without selecting anything). Happy evaluating :)
USE TelerikAcademy

/*
01. Write a SQL query to find the names and salaries of the employees that take the minimal salary in the company. Use a nested SELECT statement.
*/

SELECT FirstName + ' ' + LastName AS [Full Name], Salary
FROM Employees
WHERE Salary =
	(SELECT MIN(Salary)
	FROM Employees)

/*
02. Write a SQL query to find the names and salaries of the employees that have a salary that is up to 10% higher than the minimal salary for the company.
*/

DECLARE @minSalary INT;

SELECT @minSalary = MIN(Salary)
FROM Employees

SELECT FirstName + ' ' + LastName AS [Full Name], Salary
FROM Employees
WHERE Salary <= @minSalary + @minSalary * 10 / 100

GO

/*
03. Write a SQL query to find the full name, salary and department of the employees that take the minimal salary in their department. Use a nested SELECT statement.
*/

SELECT FirstName + ' ' + LastName AS [Full Name], Salary, DepartmentID
FROM Employees e
WHERE Salary =
  (SELECT MIN(Salary) FROM Employees
   WHERE DepartmentID = e.DepartmentID)

/*
04. Write a SQL query to find the average salary in the department #1.
*/

SELECT ROUND(AVG(Salary), 2)
FROM Employees
WHERE DepartmentID = 1

/*
05. Write a SQL query to find the average salary in the "Sales" department.
*/

SELECT ROUND(AVG(Salary), 2)
FROM Employees
WHERE DepartmentID =
	(SELECT DepartmentID
	FROM Departments
	WHERE Name = 'Sales')

/*
06. Write a SQL query to find the number of employees in the "Sales" department.
*/

SELECT COUNT(*)
FROM Employees
WHERE DepartmentID =
	(SELECT DepartmentID
	FROM Departments
	WHERE Name = 'Sales')

/*
07. Write a SQL query to find the number of all employees that have manager.
*/

SELECT COUNT(ManagerID) AS [Employees with manager]
FROM Employees

/*
08. Write a SQL query to find the number of all employees that have no manager.
*/

SELECT COUNT(*) AS [Employees without manager]
FROM Employees
WHERE ManagerID IS NULL

/*
09. Write a SQL query to find all departments and the average salary for each of them.
*/

SELECT d.Name AS Department, AVG(e.Salary) AS [Average salary]
FROM Employees e
	JOIN Departments d
	ON e.DepartmentID = d.DepartmentID
GROUP BY d.Name

/*
10. Write a SQL query to find the count of all employees in each department and for each town.
*/

-- In each department
SELECT d.Name AS Department, COUNT(*) AS [Number of employees]
FROM Employees e
	JOIN Departments d
	ON e.DepartmentID = d.DepartmentID
GROUP BY d.Name

-- For each town
SELECT t.Name AS Town, COUNT(*) AS [Number of employees]
FROM Employees e
	JOIN Addresses a
	ON e.AddressID = a.AddressID
		JOIN Towns t
		ON a.TownID = t.TownID
GROUP BY t.Name

/*
11. Write a SQL query to find all managers that have exactly 5 employees. Display their first name and last name.
*/

SELECT m.FirstName AS [First name], m.LastName AS [Last name]
FROM Employees e
	JOIN Employees m
	ON e.ManagerID = m.EmployeeID
GROUP BY m.FirstName, m.LastName
HAVING COUNT(*) = 5

/*
12. Write a SQL query to find all employees along with their managers. For employees that do not have manager display the value "(no manager)".
*/

SELECT e.FirstName + ' ' + e.LastName AS Employee, ISNULL(m.FirstName + ' ' + m.LastName, '(no manager)') AS Manager
FROM Employees e
	LEFT JOIN Employees m
	ON e.ManagerID = m.EmployeeID

/*
13. Write a SQL query to find the names of all employees whose last name is exactly 5 characters long. Use the built-in LEN(str) function.
*/

SELECT FirstName + ' ' + LastName AS [Full Name]
FROM Employees
WHERE LEN(LastName) = 5

/*
14. Write a SQL query to display the current date and time in the following format "day.month.year hour:minutes:seconds:milliseconds".
	Search in  Google to find how to format dates in SQL Server.
*/

/*
104 - dd.mm.yy
114 - hh:mi:ss:mmm (24h)
I made it composite to make it exacly the same as in the assignment - day.month.year hour:minutes:seconds:milliseconds
*/

SELECT CONVERT(VARCHAR(8), GETDATE(), 104) + ' ' + CONVERT(VARCHAR(12), GETDATE(), 114)

/*
15. Write a SQL statement to create a table Users. Users should have username, password, full name and last login time.
	Choose appropriate data types for the table fields. Define a primary key column with a primary key constraint.
	Define the primary key column as identity to facilitate inserting records. Define unique constraint to avoid repeating usernames.
	Define a check constraint to ensure the password is at least 5 characters long.
*/

CREATE TABLE Users
	(UserID INT PRIMARY KEY IDENTITY,
	Username VARCHAR(50) NOT NULL UNIQUE,
	Password VARCHAR(40) CHECK(LEN(Password) >= 5),
	FullName VARCHAR(50) NOT NULL,
	LastLogin DATETIME DEFAULT(GETDATE()))

/*
16. Write a SQL statement to create a view that displays the users from the Users table that have been in the system today.
	Test if the view works correctly.
*/

-- It doesn't work without the GOs, because CREATE VIEW must be the only statement in the batch.
GO
CREATE VIEW UsersLoggedInToday AS
SELECT Username
FROM Users
WHERE Convert(VARCHAR(8), LastLogin, 104) = Convert(VARCHAR(8), GETDATE(), 104)
GO

SELECT *
FROM UsersLoggedInToday

/*
17. Write a SQL statement to create a table Groups. Groups should have unique name (use unique constraint). Define primary key and identity column.
*/

CREATE TABLE Groups
	(GroupID INT PRIMARY KEY IDENTITY,
	Name NVARCHAR(50) NOT NULL UNIQUE)

/*
18. Write a SQL statement to add a column GroupID to the table Users. Fill some data in this new column and as well in the Groups table.
	Write a SQL statement to add a foreign key constraint between tables Users and Groups tables.
*/

-- Uncommenting the following will work too, and it's the easier way.
ALTER TABLE Users
ADD GroupID INT NOT NULL DEFAULT(3) -- FOREIGN KEY REFERENCES Groups(GroupID)

INSERT INTO Groups (Name) VALUES
	('admins'),
	('moderators'),
	('users')

INSERT INTO Users (Username, Password, FullName, GroupID) VALUES
	('pesho', '12345', 'Pesho Goshov', 3),
	('gosho', '12345', 'Gosho Peshov', 2),
	('ninja', 'youCantGuessIt', 'Ultimate NINJA', 1)

ALTER TABLE Users
ADD CONSTRAINT FK_Users_Groups
FOREIGN KEY (GroupID)
REFERENCES Groups(GroupID)

SELECT u.Username, u.FullName, g.Name AS [Group]
FROM Users u
	JOIN Groups g
	ON u.GroupID = g.GroupID

/*
19. Write SQL statements to insert several records in the Users and Groups tables.
*/

-- I use the same as from the previous task, because there is nothing more I can show.
INSERT INTO Groups (Name) VALUES
	('admins'),
	('moderators'),
	('users')

INSERT INTO Users (Username, Password, FullName, GroupID) VALUES
	('pesho', '12345', 'Pesho Goshov', 3),
	('gosho', '12345', 'Gosho Peshov', 2),
	('ninja', 'youCantGuessIt', 'Ultimate NINJA', 1)

/*
20. Write SQL statements to update some of the records in the Users and Groups tables.
*/

UPDATE Groups
SET Name = 'Admins'
WHERE Name = 'admins'

UPDATE Groups
SET Name = 'Moderators'
WHERE Name = 'moderators'

UPDATE Groups
SET Name = 'Users'
WHERE Name = 'users'

UPDATE Users
SET Password = 'challengeAccepted'
WHERE Username = 'ninja'

/*
21. Write SQL statements to delete some of the records from the Users and Groups tables.
*/

-- Be carefull with this query, it will delete every record in Users
DELETE FROM Users

DELETE FROM Groups
WHERE Name = 'Moderators'

/*
22. Write SQL statements to insert in the Users table the names of all employees from the Employees table.
	Combine the first and last names as a full name. For username use the first letter of the first name + the last name (in lowercase).
	Use the same for the password, and NULL for last login time.
*/

/*
-- Query written for the assignment, but it doesn't work, because of the passoword check constraint (>= 5),
-- and because of the unique key constaint of the username column.
INSERT INTO Users (Username, Password, FullName, LastLogin)
	SELECT LOWER(SUBSTRING(FirstName, 1, 1) + LastName) AS Username,
		LOWER(SUBSTRING(FirstName, 1, 1) + LastName) AS Password,
		FirstName + ' ' + LastName AS FullName,
		NULL AS LastLogin
	FROM Employees
*/

-- This query will probably works for you too, it worked for me.
INSERT INTO Users (Username, Password, FullName, LastLogin)
	SELECT LOWER(FirstName + LastName) AS Username,
		LOWER(SUBSTRING(FirstName, 1, 3) + LastName) AS Password,
		FirstName + ' ' + LastName AS FullName,
		NULL AS LastLogin
	FROM Employees

/*
23. Write a SQL statement that changes the password to NULL for all users that have not been in the system since 10.03.2010.
*/

UPDATE Users
SET Password = NULL
WHERE LastLogin < CONVERT(DATETIME, '10.03.2010', 104)

/*
24. Write a SQL statement that deletes all users without passwords (NULL password).
*/

DELETE FROM Users
WHERE Password IS NULL

/*
25. Write a SQL query to display the average employee salary by department and job title.
*/

SELECT d.Name AS Department, e.JobTitle AS [Job title], AVG(e.Salary) AS [Average salary]
FROM Employees e
	JOIN Departments d
	ON e.DepartmentID = d.DepartmentID
GROUP BY d.Name, e.JobTitle

/*
26. Write a SQL query to display the minimal employee salary by department and job title along with the name of some of the employees that take it.
*/

-- This is not the best query but works for the situation. I could not find better way.
SELECT s.Department, s.[Job title], s.[Minimal salary], e.FirstName + ' ' + e.LastName AS Employee
FROM
	(SELECT d.Name AS Department, e.JobTitle AS [Job title], MIN(e.Salary) AS [Minimal salary]
	FROM Employees e
		JOIN Departments d
		ON e.DepartmentID = d.DepartmentID
	GROUP BY d.Name, e.JobTitle) s
		JOIN Departments d
		ON s.Department = d.Name
			JOIN Employees e
			ON d.DepartmentID = e.DepartmentID AND s.[Job title] = e.JobTitle AND s.[Minimal salary] = e.Salary
ORDER BY s.Department, s.[Job title], Employee

/*
27. Write a SQL query to display the town where maximal number of employees work.
*/

SELECT TOP 1 t.Name AS Town, COUNT(*) AS [Number of employees]
FROM Employees e
	JOIN Addresses a
	ON e.AddressID = a.AddressID
		JOIN Towns t
		ON a.TownID = t.TownID
GROUP BY t.Name
ORDER BY [Number of employees] DESC

/*
28. Write a SQL query to display the number of managers from each town.
*/

SELECT t.Name AS Town, COUNT(*) AS [Number of managers]
FROM Employees e
	JOIN Addresses a
	ON e.AddressID = a.AddressID
		JOIN Towns t
		ON a.TownID = t.TownID
WHERE e.EmployeeID IN
	(SELECT DISTINCT ManagerID
	FROM Employees
	WHERE ManagerID IS NOT NULL)
GROUP BY t.Name

/*
29. Write a SQL to create table WorkHours to store work reports for each employee (employee id, date, task, hours, comments). Don't forget to define identity,
	primary key and appropriate foreign key. Issue few SQL statements to insert, update and delete of some data in the table.
	Define a table WorkHoursLogs to track all changes in the WorkHours table with triggers. For each change keep the old record data,
	the new record data and the command (insert / update / delete).
*/

CREATE TABLE WorkHours
	(ReportID INT PRIMARY KEY IDENTITY,
	EmployeeID INT REFERENCES Employees(EmployeeID),
	Date DATE NOT NULL,
	Task NVARCHAR(100) NOT NULL,
	Hours INT NOT NULL,
	Comments NVARCHAR(200));

INSERT INTO WorkHours (EmployeeID, Date, Task, Hours) VALUES
	(1, CONVERT(DATE, '12.02.2012', 104), 'Update database', 2),
	(2, CONVERT(DATE, '13.02.2012', 104), 'Add triggers to the DB', 3),
	(3, CONVERT(DATE, '14.02.2012', 104), 'Drop the database', 1)

UPDATE WorkHours
SET Hours = 3
WHERE EmployeeID = 1 AND Task = 'Update database'

DELETE FROM WorkHours
WHERE EmployeeID = 3 AND Task = 'Drop the database'

CREATE TABLE WorkHoursLogs
	(LogID INT PRIMARY KEY IDENTITY,
	ReportID INT,
	OldEmployeeID INT,
	OldDate DATE,
	OldTask NVARCHAR(100),
	OldHours INT,
	OldComments NVARCHAR(200),
	NewEmployeeID INT,
	NewDate DATE,
	NewTask NVARCHAR(100),
	NewHours INT,
	NewComments NVARCHAR(200),
	Command VARCHAR(10))

-- I know this may be a little bit complicated, but it's 1, not 3 and it's unified.
GO
CREATE TRIGGER TR_WorkHoursInsert ON WorkHours FOR INSERT, UPDATE, DELETE
AS
	DECLARE @reportID INT,
			@type VARCHAR(10),
			@oldEmployeeId INT,
			@oldDate DATE,
			@oldTask NVARCHAR(100),
			@oldHours INT,
			@oldComments NVARCHAR(200),
			@newEmployeeId INT,
			@newDate DATE,
			@newTask NVARCHAR(100),
			@newHours INT,
			@newComments NVARCHAR(200)

	IF EXISTS (SELECT * FROM inserted)
		IF EXISTS (SELECT * FROM deleted)
			SELECT @type = 'UPDATE'
		ELSE
			SELECT @type = 'INSERT'
	ELSE
		SELECT @type = 'DELETE'

	SELECT DISTINCT ReportID
	INTO #LoopTempTable
	FROM inserted
	UNION
	SELECT DISTINCT ReportID
	FROM deleted

	Declare @id INT

	WHILE ((SELECT Count(*) FROM #LoopTempTable) > 0)
	BEGIN
		SELECT TOP 1 @id = ReportID FROM #LoopTempTable
		
		SELECT @oldEmployeeId = EmployeeID FROM deleted WHERE ReportID = @id
		SELECT @oldDate = Date FROM deleted WHERE ReportID = @id
		SELECT @oldTask = Task FROM deleted WHERE ReportID = @id
		SELECT @oldHours = Hours FROM deleted WHERE ReportID = @id
		SELECT @oldComments = Comments FROM deleted WHERE ReportID = @id

		SELECT @newEmployeeId = EmployeeID FROM inserted WHERE ReportID = @id
		SELECT @newDate = Date FROM inserted WHERE ReportID = @id
		SELECT @newTask = Task FROM inserted WHERE ReportID = @id
		SELECT @newHours = Hours FROM inserted WHERE ReportID = @id
		SELECT @newComments = Comments FROM inserted WHERE ReportID = @id

		INSERT INTO WorkHoursLogs (ReportID, OldEmployeeID, OldDate, OldTask, OldHours, OldComments, NewEmployeeID, NewDate, NewTask, NewHours, NewComments, Command) VALUES
			(@id, @oldEmployeeId, @oldDate, @oldTask, @oldHours, @oldComments, @newEmployeeId, @newDate, @newTask, @newHours, @newComments, @type)

		DELETE FROM #LoopTempTable WHERE ReportID = @id
	END
GO

/*
30. Start a database transaction, delete all employees from the 'Sales' department along with all dependent records from the pother tables. At the end rollback the transaction.
*/

BEGIN TRANSACTION
	ALTER TABLE Departments DROP CONSTRAINT FK_Departments_Employees;

	ALTER TABLE Departments
	   ADD CONSTRAINT FK_Departments_Employees
	   FOREIGN KEY (ManagerID) REFERENCES Employees(EmployeeID) ON DELETE CASCADE;

	DELETE FROM Employees
	WHERE DepartmentID =
		(SELECT DepartmentID
		FROM Departments
		WHERE Name = 'Sales')
ROLLBACK TRANSACTION

/*
31. Start a database transaction and drop the table EmployeesProjects. Now how you could restore back the lost table data?
*/

BEGIN TRANSACTION
	DROP TABLE EmployeesProjects
ROLLBACK TRANSACTION

/*
32. Find how to use temporary tables in SQL Server.
Using temporary tables backup all records from EmployeesProjects and restore them back after dropping and re-creating the table.
*/

SELECT *
INTO #Backup
FROM EmployeesProjects

DROP TABLE EmployeesProjects

CREATE TABLE EmployeesProjects(
  EmployeeID int NOT NULL,
  ProjectID int NOT NULL,
  CONSTRAINT PK_EmployeesProjects PRIMARY KEY CLUSTERED (EmployeeID ASC, ProjectID ASC)
)

INSERT INTO EmployeesProjects
	SELECT * FROM #Backup