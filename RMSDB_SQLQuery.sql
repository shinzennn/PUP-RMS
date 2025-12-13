CREATE DATABASE RMSDB;

USE RMSDB;

CREATE TABLE Admin(
	AdminID INT IDENTITY(1,1) PRIMARY KEY,
	Username VARCHAR(50) UNIQUE NOT NULL,
	Password VARCHAR(50) UNIQUE NOT NULL
);

CREATE TABLE Course(
	CourseID INT IDENTITY(1,1) PRIMARY KEY,
	CourseCode VARCHAR(10) NOT NULL,
	CourseDecription VARCHAR(50) NOT NULL,
	SchoolYear VARCHAR(20) NOT NULL,
	Semester INT
);

CREATE TABLE Professor(
	ProfessorID INT IDENTITY(1,1) PRIMARY KEY,
	FirstName VARCHAR(50) NOT NULL,
	MiddleName VARCHAR(10),
	LastName VARCHAR(50) NOT NULL
);

CREATE TABLE CourseProfessor(
	CourseID INT NOT NULL,
	ProfessorID INT NOT NULL,

	CONSTRAINT FK_CourseID_CourseProfessor FOREIGN KEY (CourseID) REFERENCES Course(CourseID),
	CONSTRAINT FK_ProfessorID_CourseProfessor FOREIGN KEY (ProfessorID) REFERENCES Professor(ProfessorID)
);

CREATE TABLE GradeSheet(
	GradeSheetID INT IDENTITY(1,1) PRIMARY KEY,
	Filename VARCHAR(100) UNIQUE NOT NULL,
	CourseID INT,
	AdminID INT,

	CONSTRAINT FK_CourseID_GradeSheet FOREIGN KEY (CourseID) REFERENCES Course(CourseID),
	CONSTRAINT FK_AdminID_GradeSheet FOREIGN KEY (AdminID) REFERENCES Admin(AdminID)
);


-- SAMPLE DATA

-- ADMIN Account
INSERT INTO Admin(Username, Password) VALUES('user', '12345678');

-- PROFESSOR
INSERT INTO Professor(FirstName, MiddleName, LastName) VALUES('Mark Vence', 'V' , 'Dungca');
INSERT INTO Professor(FirstName, MiddleName, LastName) VALUES('Mario', 'S' , 'Enteria');
INSERT INTO Professor(FirstName, MiddleName, LastName) VALUES('Icon', 'C' , 'Obmerga');
INSERT INTO Professor(FirstName, MiddleName, LastName) VALUES('Marie Andrea', 'E' , 'Zurbano');
INSERT INTO Professor(FirstName, MiddleName, LastName) VALUES('Tito Ernesto', 'Z' , 'Loreto');

-- COURSE
INSERT INTO Course(CourseCode, CourseDecription, SchoolYear, Semester) VALUES('COMP 015', 'Fundamentals of Research', '2025-2026', 1);
INSERT INTO Course(CourseCode, CourseDecription, SchoolYear, Semester) VALUES('COMP 016', 'Web Development', '2025-2026', 2);
INSERT INTO Course(CourseCode, CourseDecription, SchoolYear, Semester) VALUES('COMP 017', 'Multimedia', '2024-2025', 1);
INSERT INTO Course(CourseCode, CourseDecription, SchoolYear, Semester) VALUES('COMP 018', 'Database Administration', '2025-2026', 2);
INSERT INTO Course(CourseCode, CourseDecription, SchoolYear, Semester) VALUES('	INTE 301', 'Systems Integration and Architecture 1', '2024-2025', 2);

SELECT * FROM Admin;
SELECT * FROM Course;
SELECT * FROM Professor;

