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
);

CREATE TABLE Professor(
	ProfessorID INT IDENTITY(1,1) PRIMARY KEY,
	FirstName VARCHAR(50) NOT NULL,
	MiddleName VARCHAR(10),
	LastName VARCHAR(50) NOT NULL
);

CREATE TABLE GradeSheet(
	GradeSheetID INT IDENTITY(1,1) PRIMARY KEY,
	Filename VARCHAR(100) UNIQUE NOT NULL,
	SchoolYear VARCHAR(20) NOT NULL,
	Semester INT,
	CourseID INT,
	ProfessorID INT,
	AdminID INT,

	CONSTRAINT FK_CourseID_GradeSheet FOREIGN KEY (CourseID) REFERENCES Course(CourseID),
	CONSTRAINT FK_ProfessorID_GradeSheet FOREIGN KEY (ProfessorID) REFERENCES Professor(ProfessorID),
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
INSERT INTO Course(CourseCode, CourseDecription) VALUES('COMP 015', 'Fundamentals of Research');
INSERT INTO Course(CourseCode, CourseDecription) VALUES('COMP 016', 'Web Development');
INSERT INTO Course(CourseCode, CourseDecription) VALUES('COMP 017', 'Multimedia');
INSERT INTO Course(CourseCode, CourseDecription) VALUES('COMP 018', 'Database Administration');
INSERT INTO Course(CourseCode, CourseDecription) VALUES('INTE 301', 'Systems Integration and Architecture 1');

SELECT * FROM Admin;
SELECT * FROM Course;
SELECT * FROM Professor;
