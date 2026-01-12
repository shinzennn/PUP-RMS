CREATE DATABASE RMSDB;

USE RMSDB;

CREATE TABLE Account(
	AccountID INT IDENTITY(1,1) PRIMARY KEY,
	Username VARCHAR(50) UNIQUE NOT NULL,
	Password VARCHAR(50) UNIQUE NOT NULL,
	FirstName VARCHAR(50) NOT NULL,
	LastName VARCHAR(50) NOT NULL,
	UserType VARCHAR(20) NOT NULL
);

CREATE TABLE Curriculum(
	CurriculumID INT IDENTITY(1,1) PRIMARY KEY,
	CurriculumYear VARCHAR(20) NOT NULL,
);

CREATE TABLE Program(
	ProgramID INT IDENTITY(1,1) PRIMARY KEY,
	ProgramCode VARCHAR(20) NOT NULL,
	ProgramDescription VARCHAR(50) NOT NULL,
	CurriculumID INT
	
	CONSTRAINT FK_Curriculum_Program FOREIGN KEY (CurriculumID) REFERENCES Curriculum(CurriculumID)
);

CREATE TABLE Course(
	CourseID INT IDENTITY(1,1) PRIMARY KEY,
	CourseCode VARCHAR(20) NOT NULL,
	CourseDescription VARCHAR(50) NOT NULL,
	ProgramID INT,

	CONSTRAINT FK_Program_Course FOREIGN KEY (ProgramID) REFERENCES Program(ProgramID)
);

CREATE TABLE Professor(
	ProfessorID INT IDENTITY(1,1) PRIMARY KEY,
	FirstName VARCHAR(50) NOT NULL,
	MiddleName VARCHAR(20),
	LastName VARCHAR(50) NOT NULL,
	Suffix VARCHAR(10)
);

CREATE TABLE ProfessorProgram(
	ProfessorID INT,
	ProgramID INT,

	CONSTRAINT FK_ProfessorID_ProfessorProgram FOREIGN KEY (ProfessorID) REFERENCES Professor(ProfessorID),
	CONSTRAINT FK_ProgramID_ProfessorProgram FOREIGN KEY (ProgramID) REFERENCES Program(ProgramID)
);

CREATE TABLE GradeSheet(
	GradeSheetID INT IDENTITY(1,1) PRIMARY KEY,
	Filename VARCHAR(100) UNIQUE NOT NULL,
	SchoolYear VARCHAR(20) NOT NULL,
	Semester INT,
	CourseID INT,
	ProfessorID INT,
	AccountID INT,

	CONSTRAINT FK_CourseID_GradeSheet FOREIGN KEY (CourseID) REFERENCES Course(CourseID),
	CONSTRAINT FK_ProfessorID_GradeSheet FOREIGN KEY (ProfessorID) REFERENCES Professor(ProfessorID),
	CONSTRAINT FK_AccountID_GradeSheet FOREIGN KEY (AccountID) REFERENCES Account(AccountID)
);

CREATE TABLE ActivityLog(
	LogID INT IDENTITY(1,1) PRIMARY KEY,
	AccountID INT,
	ActivityDescription VARCHAR(255) NOT NULL,
	ActivityDate DATETIME,

	CONSTRAINT FK_AccountID_ActivityLog FOREIGN KEY (AccountID) REFERENCES Account(AccountID)
);


-- SAMPLE DATA

-- ACCOUNT
INSERT INTO Account(Username, Password) VALUES('admin', '12345678', 'Bong', 'Montante', 'Admin');

-- CURRICULUM
INSERT INTO Curriculum(CurriculumYear) VALUES('2021-2025');

-- PROGRAM
INSERT INTO Program(ProgramCode, ProgramDescription, CurriculumID) VALUES('BSIT-LQ', 'Bachelor of Science in Information Technology', 1);

-- COURSE
INSERT INTO Course(CourseCode, CourseDescription, ProgramID) VALUES('COMP 015', 'Fundamentals of Research', 1);
INSERT INTO Course(CourseCode, CourseDescription, ProgramID) VALUES('COMP 016', 'Web Development', 1);
INSERT INTO Course(CourseCode, CourseDescription, ProgramID) VALUES('COMP 017', 'Multimedia', 1);
INSERT INTO Course(CourseCode, CourseDescription, ProgramID) VALUES('COMP 018', 'Database Administration', 1);
INSERT INTO Course(CourseCode, CourseDescription, ProgramID) VALUES('INTE 301', 'Systems Integration and Architecture 1', 1);

-- PROFESSOR
INSERT INTO Professor(FirstName, MiddleName, LastName) VALUES('Mark Vence', 'V' , 'Dungca');
INSERT INTO Professor(FirstName, MiddleName, LastName) VALUES('Mario', 'S' , 'Enteria');
INSERT INTO Professor(FirstName, MiddleName, LastName) VALUES('Icon', 'C' , 'Obmerga');
INSERT INTO Professor(FirstName, MiddleName, LastName) VALUES('Marie Andrea', 'E' , 'Zurbano');
INSERT INTO Professor(FirstName, MiddleName, LastName) VALUES('Tito Ernesto', 'Z' , 'Loreto');

-- PROFESSOR-PROGRAM
INSERT INTO ProfessorProgram(ProfessorID, ProgramID) VALUES(1, 1);
INSERT INTO ProfessorProgram(ProfessorID, ProgramID) VALUES(2, 1);
INSERT INTO ProfessorProgram(ProfessorID, ProgramID) VALUES(3, 1);
INSERT INTO ProfessorProgram(ProfessorID, ProgramID) VALUES(4, 1);
INSERT INTO ProfessorProgram(ProfessorID, ProgramID) VALUES(5, 1);

SELECT * FROM Admin;
SELECT * FROM Curriculum;
SELECT * FROM Program;
SELECT * FROM Course;
SELECT * FROM Professor;
SELECT * FROM ProfessorProgram;

-- GAWA NI RENZ
-- STORED PROCEDURE TO SEARCH COURSES BASED ON FILTERS
CREATE PROCEDURE sp_SearchCourses
    @ProgramID INT = NULL,
    @SchoolYear VARCHAR(20) = NULL,
    @CurriculumYear VARCHAR(20) = NULL,
    @Semester INT = NULL
AS
BEGIN
    SELECT DISTINCT
        c.CourseID,
        c.CourseCode,
        c.CourseDescription,
        p.ProgramCode,
        p.ProgramDescription,
        cur.CurriculumYear
    FROM Course c
    INNER JOIN Program p 
        ON c.ProgramID = p.ProgramID
    INNER JOIN Curriculum cur 
        ON p.CurriculumID = cur.CurriculumID
    LEFT JOIN GradeSheet gs 
        ON c.CourseID = gs.CourseID
    WHERE
        (@ProgramID IS NULL OR p.ProgramID = @ProgramID)
        AND (@CurriculumYear IS NULL OR cur.CurriculumYear = @CurriculumYear)
        AND (@SchoolYear IS NULL OR gs.SchoolYear = @SchoolYear)
        AND (@Semester IS NULL OR gs.Semester = @Semester)
    ORDER BY
        c.CourseCode;
END
GO

-- show all courses
EXEC sp_SearchCourses;

-- show courses by program
EXEC sp_SearchCourses @ProgramID = 1;

-- show courses school year & semester
EXEC sp_SearchCourses 
    @SchoolYear = '2024-2025',
    @Semester = 1;

-- show base on all filter
EXEC sp_SearchCourses 
    @ProgramID = 1,
    @CurriculumYear = '2021-2025',
    @SchoolYear = '2024-2025',
    @Semester = 2;

-- END-GAWA NI RENZ