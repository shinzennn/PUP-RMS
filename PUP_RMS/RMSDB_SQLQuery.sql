IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'RMSDB')
BEGIN
    CREATE DATABASE RMSDB;
END
GO

USE RMSDB;
GO

IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Account')
BEGIN
    -- 1. Account
    CREATE TABLE Account (
        AccountID INT IDENTITY(1,1) PRIMARY KEY,
        Username VARCHAR(50) UNIQUE NOT NULL,
        Password VARCHAR(255) NOT NULL,
        FirstName VARCHAR(50) NOT NULL,
        LastName VARCHAR(50) NOT NULL,
        AccountType VARCHAR(20) NOT NULL
    );
END 
GO

IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Program')
BEGIN
    -- 2. Program
    CREATE TABLE Program (
        ProgramID INT IDENTITY(1,1) PRIMARY KEY,
        ProgramCode VARCHAR(20) UNIQUE NOT NULL,
        ProgramDescription VARCHAR(100) NOT NULL
    );
END 
GO

IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Course')
BEGIN
    -- 3. Course
    CREATE TABLE Course (
        CourseID INT IDENTITY(1,1) PRIMARY KEY,
        CourseCode VARCHAR(20) UNIQUE NOT NULL,
        CourseDescription VARCHAR(100) NOT NULL
    );
END 
GO

IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Faculty')
BEGIN
    -- 4. Faculty
    CREATE TABLE Faculty (
        FacultyID INT IDENTITY(1,1) PRIMARY KEY,
        FirstName VARCHAR(50) NOT NULL,
        MiddleName VARCHAR(50),
        LastName VARCHAR(50) NOT NULL,
        Suffix VARCHAR(10),
        Initials VARCHAR(20)
    );
END 
GO

IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'CurriculumHeader')
BEGIN
    -- 5. CurriculumHeader
    CREATE TABLE CurriculumHeader (
        CurriculumHeaderID INT IDENTITY(1,1) PRIMARY KEY,
        ProgramID INT NOT NULL,
        CurriculumYear VARCHAR(10) NOT NULL,

        CONSTRAINT FK_CH_Program FOREIGN KEY (ProgramID) REFERENCES Program(ProgramID),
        CONSTRAINT UQ_ProgramYear UNIQUE (ProgramID, CurriculumYear)
    );
END 
GO

IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Curriculum')
BEGIN
    -- 6. Curriculum
    CREATE TABLE Curriculum (
        CurriculumID INT IDENTITY(1,1) PRIMARY KEY,
        CurriculumHeaderID INT NOT NULL,
        YearLevel INT NOT NULL,
        Semester INT NOT NULL,

        CONSTRAINT FK_CS_Header FOREIGN KEY (CurriculumHeaderID) REFERENCES CurriculumHeader(CurriculumHeaderID),
        CONSTRAINT UQ_YearSem UNIQUE (CurriculumHeaderID, YearLevel, Semester)
    );
END 
GO

IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Offering')
BEGIN
    -- 7. Offering
    CREATE TABLE Offering (
        OfferingID INT IDENTITY(1,1) PRIMARY KEY,
        CurriculumID INT NOT NULL,
        CourseID INT NOT NULL,

        CONSTRAINT FK_Offering_Curriculum FOREIGN KEY (CurriculumID) REFERENCES Curriculum(CurriculumID),
        CONSTRAINT FK_Offering_Course FOREIGN KEY (CourseID) REFERENCES Course(CourseID),
    );
END 
GO

IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'ClassSection')
BEGIN
    -- 8. Section
    CREATE TABLE ClassSection (
        SectionID INT IDENTITY(1,1) PRIMARY KEY,
        OfferingID INT NOT NULL,
        FacultyID INT NOT NULL,
        Section INT NOT NULL,
        SchoolYear VARCHAR(20) NOT NULL,

        CONSTRAINT FK_Section_Offering FOREIGN KEY (OfferingID) REFERENCES Offering(OfferingID),
        CONSTRAINT FK_Section_Faculty FOREIGN KEY (FacultyID) REFERENCES Faculty(FacultyID)
    );
END 
GO

IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'GradeSheet')
BEGIN
    -- 9. GradeSheet
    CREATE TABLE GradeSheet (
        GradeSheetID INT IDENTITY(1,1) PRIMARY KEY,
        SectionID INT NOT NULL,
        Filename VARCHAR(100) UNIQUE NOT NULL,
        Filepath VARCHAR(200) NOT NULL,
        PageNumber INT DEFAULT 1,
        AccountID INT NOT NULL,
        DateUploaded DATETIME DEFAULT GETDATE(),

        CONSTRAINT FK_GradeSheet_Section FOREIGN KEY (SectionID) REFERENCES ClassSection(SectionID),
        CONSTRAINT FK_GradeSheet_Account FOREIGN KEY (AccountID) REFERENCES Account(AccountID)
    );
END 
GO

IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'ActivityLog')
BEGIN
    -- 10. ActivityLog: Audit trail
    CREATE TABLE ActivityLog (
        LogID INT IDENTITY(1,1) PRIMARY KEY,
        AccountID INT NOT NULL,
        ActivityDescription VARCHAR(255) NOT NULL,
        ActivityDate DATETIME DEFAULT GETDATE(),

        CONSTRAINT FK_Log_Account FOREIGN KEY (AccountID) REFERENCES Account(AccountID)
    );
END 
GO

IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'DbVersion')
BEGIN
    -- 11. DB Versioning
    CREATE TABLE DbVersion (
        VersionID INT IDENTITY(1,1) PRIMARY KEY,
        VersionNumber INT NOT NULL,
        DateApplied DATETIME DEFAULT GETDATE()
    );
    INSERT INTO DbVersion (VersionNumber) VALUES (1);
END
GO

-- SEED DATA
IF NOT EXISTS (SELECT 1 FROM Account)
BEGIN
    SET IDENTITY_INSERT [dbo].[Account] ON 
    INSERT [dbo].[Account] ([AccountID], [Username], [Password], [FirstName], [LastName], [AccountType]) VALUES (1, N'admin', N'12345678', N'John', N'Doe', N'Admin')
    SET IDENTITY_INSERT [dbo].[Account] OFF
END
GO

IF NOT EXISTS (SELECT 1 FROM Program)
BEGIN
    SET IDENTITY_INSERT [dbo].[Program] ON 
    INSERT [dbo].[Program] ([ProgramID], [ProgramCode], [ProgramDescription]) VALUES (1, N'BSIT', N'Bachelor of Science in Information Technology')
    SET IDENTITY_INSERT [dbo].[Program] OFF
END 
GO

IF NOT EXISTS (SELECT 1 FROM Course)
BEGIN
    SET IDENTITY_INSERT [dbo].[Course] ON 
    INSERT [dbo].[Course] ([CourseID], [CourseCode], [CourseDescription]) VALUES (1, N'ACCO 014', N'Principles of Accounting')
    INSERT [dbo].[Course] ([CourseID], [CourseCode], [CourseDescription]) VALUES (2, N'COMP 001', N'Introduction to Computing')
    INSERT [dbo].[Course] ([CourseID], [CourseCode], [CourseDescription]) VALUES (3, N'COMP 002', N'Computer Programming 1')
    INSERT [dbo].[Course] ([CourseID], [CourseCode], [CourseDescription]) VALUES (4, N'GEED 004', N'Mathematics in the Modern World/Matematika sa Makabagong Daigdig')
    INSERT [dbo].[Course] ([CourseID], [CourseCode], [CourseDescription]) VALUES (5, N'GEED 005', N'Purposive Communication/Malayuning Komunikasyon')
    INSERT [dbo].[Course] ([CourseID], [CourseCode], [CourseDescription]) VALUES (6, N'GEED 032', N'Filipinolohiya at Pambansang Kaunlaran')
    INSERT [dbo].[Course] ([CourseID], [CourseCode], [CourseDescription]) VALUES (7, N'NSTP 001', N'National Service Training Program 1')
    INSERT [dbo].[Course] ([CourseID], [CourseCode], [CourseDescription]) VALUES (8, N'PATHFIT 1', N'Physical Activity Towards Health and Fitness 1')
    INSERT [dbo].[Course] ([CourseID], [CourseCode], [CourseDescription]) VALUES (9, N'COMP 003', N'Computer Programming 2')
    INSERT [dbo].[Course] ([CourseID], [CourseCode], [CourseDescription]) VALUES (10, N'COMP 004', N'Discrete Structures 1')
    INSERT [dbo].[Course] ([CourseID], [CourseCode], [CourseDescription]) VALUES (11, N'GEED 002', N'Readings in Philippine History/Mga Babasahin Hinggil sa Kasaysayan ng Pilipinas')
    INSERT [dbo].[Course] ([CourseID], [CourseCode], [CourseDescription]) VALUES (12, N'GEED 010', N'People and the Earth''s Ecosystems')
    INSERT [dbo].[Course] ([CourseID], [CourseCode], [CourseDescription]) VALUES (13, N'GEED 020', N'Politics, Governance and Citizenship')
    INSERT [dbo].[Course] ([CourseID], [CourseCode], [CourseDescription]) VALUES (14, N'GEED 033', N'Pagsasalin sa Kontekstong Filipino')
    INSERT [dbo].[Course] ([CourseID], [CourseCode], [CourseDescription]) VALUES (15, N'NSTP 002', N'National Service Training Program 2')
    INSERT [dbo].[Course] ([CourseID], [CourseCode], [CourseDescription]) VALUES (16, N'PATHFIT 2', N'Physical Activity Towards Health and Fitness 2')
    INSERT [dbo].[Course] ([CourseID], [CourseCode], [CourseDescription]) VALUES (17, N'COMP 006', N'Data Structures and Algorithms')
    INSERT [dbo].[Course] ([CourseID], [CourseCode], [CourseDescription]) VALUES (18, N'COMP 007', N'Operating Systems')
    INSERT [dbo].[Course] ([CourseID], [CourseCode], [CourseDescription]) VALUES (19, N'COMP 008', N'Data Communications and Networking')
    INSERT [dbo].[Course] ([CourseID], [CourseCode], [CourseDescription]) VALUES (20, N'ELEC IT-FE1', N'BSIT Free Elective 1')
    INSERT [dbo].[Course] ([CourseID], [CourseCode], [CourseDescription]) VALUES (21, N'GEED 001', N'Understanding the Self/Pag-unawa sa Sarili')
    INSERT [dbo].[Course] ([CourseID], [CourseCode], [CourseDescription]) VALUES (22, N'GEED 028', N'Reading Visual Arts')
    INSERT [dbo].[Course] ([CourseID], [CourseCode], [CourseDescription]) VALUES (23, N'INTE 201', N'Programming 3 (Structured Programming)')
    INSERT [dbo].[Course] ([CourseID], [CourseCode], [CourseDescription]) VALUES (24, N'PATHFIT 3', N'Physical Activity Towards Health and Fitness 3')
    INSERT [dbo].[Course] ([CourseID], [CourseCode], [CourseDescription]) VALUES (25, N'COMP 009', N'Object Oriented Programming')
    INSERT [dbo].[Course] ([CourseID], [CourseCode], [CourseDescription]) VALUES (26, N'COMP 010', N'Information Management')
    INSERT [dbo].[Course] ([CourseID], [CourseCode], [CourseDescription]) VALUES (27, N'COMP 012', N'Network Administration')
    INSERT [dbo].[Course] ([CourseID], [CourseCode], [CourseDescription]) VALUES (28, N'COMP 013', N'Human Computer Interaction')
    INSERT [dbo].[Course] ([CourseID], [CourseCode], [CourseDescription]) VALUES (29, N'COMP 014', N'Quantitative Methods with Modeling and Simulation')
    INSERT [dbo].[Course] ([CourseID], [CourseCode], [CourseDescription]) VALUES (30, N'ELEC IT-FE2', N'BSIT Free Elective 2')
    INSERT [dbo].[Course] ([CourseID], [CourseCode], [CourseDescription]) VALUES (31, N'INTE 202', N'Integrative Programming and Technologies 1')
    INSERT [dbo].[Course] ([CourseID], [CourseCode], [CourseDescription]) VALUES (32, N'PATHFIT 4', N'Physical Activity Towards Health and Fitness 4')
    INSERT [dbo].[Course] ([CourseID], [CourseCode], [CourseDescription]) VALUES (33, N'COMP 015', N'Fundamentals of Research')
    INSERT [dbo].[Course] ([CourseID], [CourseCode], [CourseDescription]) VALUES (34, N'COMP 016', N'Web Development')
    INSERT [dbo].[Course] ([CourseID], [CourseCode], [CourseDescription]) VALUES (35, N'COMP 017', N'Multimedia')
    INSERT [dbo].[Course] ([CourseID], [CourseCode], [CourseDescription]) VALUES (36, N'COMP 018', N'Database Administration')
    INSERT [dbo].[Course] ([CourseID], [CourseCode], [CourseDescription]) VALUES (37, N'ELEC IT-E1', N'IT Elective 1')
    INSERT [dbo].[Course] ([CourseID], [CourseCode], [CourseDescription]) VALUES (38, N'GEED 006', N'Art Appreciation/Pagpapahalaga sa Sining')
    INSERT [dbo].[Course] ([CourseID], [CourseCode], [CourseDescription]) VALUES (39, N'INTE 301', N'Systems Integration and Architecture 1')
    INSERT [dbo].[Course] ([CourseID], [CourseCode], [CourseDescription]) VALUES (40, N'COMP 019', N'Applications Development and Emerging Technologies')
    INSERT [dbo].[Course] ([CourseID], [CourseCode], [CourseDescription]) VALUES (41, N'ELEC IT-E2', N'IT Elective 2')
    INSERT [dbo].[Course] ([CourseID], [CourseCode], [CourseDescription]) VALUES (42, N'GEED 003', N'The Contemporary World/Ang Kasalukuyang Daigdig')
    INSERT [dbo].[Course] ([CourseID], [CourseCode], [CourseDescription]) VALUES (43, N'GEED 008', N'Ethics/Etika')
    INSERT [dbo].[Course] ([CourseID], [CourseCode], [CourseDescription]) VALUES (44, N'HRMA 001', N'Principles of Organization and Management')
    INSERT [dbo].[Course] ([CourseID], [CourseCode], [CourseDescription]) VALUES (45, N'INTE 302', N'Information Assurance and Security 1')
    INSERT [dbo].[Course] ([CourseID], [CourseCode], [CourseDescription]) VALUES (46, N'INTE 303', N'Capstone Project 1')
    INSERT [dbo].[Course] ([CourseID], [CourseCode], [CourseDescription]) VALUES (47, N'ELEC IT-E3', N'IT Elective 3')
    INSERT [dbo].[Course] ([CourseID], [CourseCode], [CourseDescription]) VALUES (48, N'GEED 037', N'Life and Works of Rizal/Buhay at Mga Gawa ni Rizal')
    INSERT [dbo].[Course] ([CourseID], [CourseCode], [CourseDescription]) VALUES (49, N'COMP 023', N'Social and Professional Issues in Computing')
    INSERT [dbo].[Course] ([CourseID], [CourseCode], [CourseDescription]) VALUES (50, N'ELEC IT-E4', N'IT Elective 4')
    INSERT [dbo].[Course] ([CourseID], [CourseCode], [CourseDescription]) VALUES (51, N'GEED 007', N'Science, Technology and Society/Agham, Teknolohiya, at Lipunan')
    INSERT [dbo].[Course] ([CourseID], [CourseCode], [CourseDescription]) VALUES (52, N'INTE 401', N'Information Assurance and Security 2')
    INSERT [dbo].[Course] ([CourseID], [CourseCode], [CourseDescription]) VALUES (53, N'INTE 402', N'Capstone Project 2')
    INSERT [dbo].[Course] ([CourseID], [CourseCode], [CourseDescription]) VALUES (54, N'INTE 403', N'Systems Administration and Maintenance')
    INSERT [dbo].[Course] ([CourseID], [CourseCode], [CourseDescription]) VALUES (55, N'COMP 024', N'Technopreneurship')
    INSERT [dbo].[Course] ([CourseID], [CourseCode], [CourseDescription]) VALUES (56, N'INTE 404', N'Practicum (500 Hours)')
    SET IDENTITY_INSERT [dbo].[Course] OFF
END 
GO

IF NOT EXISTS (SELECT 1 FROM Faculty)
BEGIN
    SET IDENTITY_INSERT [dbo].[Faculty] ON 
    INSERT [dbo].[Faculty] ([FacultyID], [FirstName], [MiddleName], [LastName], [Suffix], [Initials]) VALUES (4, N'JOANNE', N'D', N'LEE', NULL, N'LEEJD')
    INSERT [dbo].[Faculty] ([FacultyID], [FirstName], [MiddleName], [LastName], [Suffix], [Initials]) VALUES (5, N'ICON', N'C', N'OBMERGA', NULL, N'OBMERGAIC')
    INSERT [dbo].[Faculty] ([FacultyID], [FirstName], [MiddleName], [LastName], [Suffix], [Initials]) VALUES (6, N'MARIE ANDREA', N'E', N'ZURBANO', NULL, N'ZURBANOMAE')
    INSERT [dbo].[Faculty] ([FacultyID], [FirstName], [MiddleName], [LastName], [Suffix], [Initials]) VALUES (7, N'ROLAND', N'V', N'MAGSINO', NULL, N'MAGSINORV')
    INSERT [dbo].[Faculty] ([FacultyID], [FirstName], [MiddleName], [LastName], [Suffix], [Initials]) VALUES (8, N'JOYCE', N'L', N'RIVERA', NULL, N'RIVERAJL')
    INSERT [dbo].[Faculty] ([FacultyID], [FirstName], [MiddleName], [LastName], [Suffix], [Initials]) VALUES (9, N'GEORGE', N'D', N'OMONGOS', NULL, N'OMONGOSGD')
    INSERT [dbo].[Faculty] ([FacultyID], [FirstName], [MiddleName], [LastName], [Suffix], [Initials]) VALUES (10, N'DIONYSIUS', N'A', N'VELAZQUEZ', NULL, N'VELAZQUEZDA')
    INSERT [dbo].[Faculty] ([FacultyID], [FirstName], [MiddleName], [LastName], [Suffix], [Initials]) VALUES (11, N'RONALDO', N'G', N'BULFA', NULL, N'BULFARG')
    INSERT [dbo].[Faculty] ([FacultyID], [FirstName], [MiddleName], [LastName], [Suffix], [Initials]) VALUES (12, N'JER ANTHONY', N'', N'PALO', NULL, N'PALOJA')
    INSERT [dbo].[Faculty] ([FacultyID], [FirstName], [MiddleName], [LastName], [Suffix], [Initials]) VALUES (13, N'LOURDES', N'B', N'AVILA', NULL, N'AVILALB')
    INSERT [dbo].[Faculty] ([FacultyID], [FirstName], [MiddleName], [LastName], [Suffix], [Initials]) VALUES (14, N'RODONES', N'S', N'TRIMILLOS', NULL, N'TRIMILLOSRS')
    INSERT [dbo].[Faculty] ([FacultyID], [FirstName], [MiddleName], [LastName], [Suffix], [Initials]) VALUES (15, N'RUFO', N'N', N'BUEZA', NULL, N'BUEZARN')
    INSERT [dbo].[Faculty] ([FacultyID], [FirstName], [MiddleName], [LastName], [Suffix], [Initials]) VALUES (16, N'CHRISTINE', N'S', N'MANZANERO', NULL, N'MANZANEROCS')
    INSERT [dbo].[Faculty] ([FacultyID], [FirstName], [MiddleName], [LastName], [Suffix], [Initials]) VALUES (17, N'SERGIO', N'V', N'PINEDA', NULL, N'PINEDASV')
    INSERT [dbo].[Faculty] ([FacultyID], [FirstName], [MiddleName], [LastName], [Suffix], [Initials]) VALUES (18, N'SAM', N'P', N'BULFA', NULL, N'BULFASP')
    INSERT [dbo].[Faculty] ([FacultyID], [FirstName], [MiddleName], [LastName], [Suffix], [Initials]) VALUES (19, N'ROSARIO', N'D', N'ANULAO', NULL, N'ANULAORD')
    INSERT [dbo].[Faculty] ([FacultyID], [FirstName], [MiddleName], [LastName], [Suffix], [Initials]) VALUES (20, N'DAVE', N'V', N'MARCAIDA', NULL, N'MARCAIDADV')
    INSERT [dbo].[Faculty] ([FacultyID], [FirstName], [MiddleName], [LastName], [Suffix], [Initials]) VALUES (21, N'ROXANNE', N'D', N'LAPISEROS', NULL, N'LAPISEROSRD')
    INSERT [dbo].[Faculty] ([FacultyID], [FirstName], [MiddleName], [LastName], [Suffix], [Initials]) VALUES (22, N'PATRICIA', N'R', N'DE ASIS', NULL, N'DEASISPR')
    INSERT [dbo].[Faculty] ([FacultyID], [FirstName], [MiddleName], [LastName], [Suffix], [Initials]) VALUES (23, N'LYNEL', N'P', N'TABIEN', NULL, N'TABIENLP')
    INSERT [dbo].[Faculty] ([FacultyID], [FirstName], [MiddleName], [LastName], [Suffix], [Initials]) VALUES (24, N'GILBERTO', N'A', N'VILLANUEVA', NULL, N'VILLANUEVAGA')
    INSERT [dbo].[Faculty] ([FacultyID], [FirstName], [MiddleName], [LastName], [Suffix], [Initials]) VALUES (25, N'MARIO', N'S', N'ENTERIA', NULL, N'ENTERIAMS')
    INSERT [dbo].[Faculty] ([FacultyID], [FirstName], [MiddleName], [LastName], [Suffix], [Initials]) VALUES (26, N'TITO', N'Z', N'LORETO', NULL, N'LORETOTZ')
    INSERT [dbo].[Faculty] ([FacultyID], [FirstName], [MiddleName], [LastName], [Suffix], [Initials]) VALUES (27, N'KIM', N'S', N'BITOIN', NULL, N'BITOINKS')
    INSERT [dbo].[Faculty] ([FacultyID], [FirstName], [MiddleName], [LastName], [Suffix], [Initials]) VALUES (28, N'CESAR', N'B', N'BERMUNDO', NULL, N'BERMUNDOCB')
    INSERT [dbo].[Faculty] ([FacultyID], [FirstName], [MiddleName], [LastName], [Suffix], [Initials]) VALUES (29, N'MARK VENCE', N'V', N'DUNGCA', NULL, N'DUNGCAMVV')
    INSERT [dbo].[Faculty] ([FacultyID], [FirstName], [MiddleName], [LastName], [Suffix], [Initials]) VALUES (30, N'RAY ANTHONY', N'', N'OIDEM', NULL, N'OIDEMRA')
    SET IDENTITY_INSERT [dbo].[Faculty] OFF
END 
GO

--==================================================
-- 1. COURSE STORED PROCEDURES                   
--==================================================
-- 1.1. CREATE COURSE //
CREATE OR ALTER PROCEDURE sp_CreateCourse
    @CourseCode VARCHAR(20),
    @CourseDescription VARCHAR(100)
AS
BEGIN
    INSERT INTO Course (CourseCode, CourseDescription)
    VALUES (@CourseCode, @CourseDescription);
END
GO

-- 1.2. GET ALL COURSE DESCRIPTION //
CREATE OR ALTER PROCEDURE sp_GetAllCourseDescription
AS
BEGIN
SELECT 
     CourseID, 
     CourseCode, 
     CourseDescription
FROM Course
END
GO

-- 1.3. GET ALL COURSE CODE PER COURSE DESCRIPTION //
CREATE OR ALTER PROCEDURE sp_GetAllCourseCodePerDescription
    @CourseDescription VARCHAR(100)
AS
BEGIN
    SELECT DISTINCT
        c.CourseID,
        c.CourseCode,
        ch.CurriculumYear
    FROM Course c
    LEFT JOIN Offering o 
        ON c.CourseID = o.CourseID
    LEFT JOIN Curriculum cur 
        ON o.CurriculumID = cur.CurriculumID
    LEFT JOIN CurriculumHeader ch 
        ON cur.CurriculumHeaderID = ch.CurriculumHeaderID
    WHERE c.CourseDescription = @CourseDescription
    ORDER BY c.CourseCode, ch.CurriculumYear;
END;
GO

-- 1.4. SEARCH COURSE 
CREATE OR ALTER PROCEDURE sp_SearchCourse
    @SearchTerm VARCHAR(100)       = NULL,
    @CurriculumYear VARCHAR(10)    = NULL,
    @ProgramID INT                 = NULL
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @Term VARCHAR(220) = NULL;
    IF LTRIM(RTRIM(ISNULL(@SearchTerm, ''))) <> ''
    BEGIN
        SET @Term = '%' + REPLACE(REPLACE(REPLACE(@SearchTerm, '[', '[[]'), '%', '[%]'), '_', '[_]') + '%';
    END

    SELECT
        c.CourseDescription
    FROM dbo.Course c
    LEFT JOIN dbo.Offering o ON c.CourseID = o.CourseID
    LEFT JOIN dbo.Curriculum cur ON o.CurriculumID = cur.CurriculumID
    LEFT JOIN dbo.CurriculumHeader ch ON cur.CurriculumHeaderID = ch.CurriculumHeaderID
    WHERE
        (@ProgramID IS NULL OR ch.ProgramID = @ProgramID)
        AND (@CurriculumYear IS NULL OR ch.CurriculumYear = @CurriculumYear)
        AND (
            @Term IS NULL
            OR c.CourseCode LIKE @Term
            OR c.CourseDescription LIKE @Term
        )
    GROUP BY c.CourseDescription
    ORDER BY c.CourseDescription DESC;
END;
GO

-- 1.5. UPDATE COURSE //
CREATE OR ALTER PROCEDURE sp_UpdateCourse
    @CourseID INT,
    @CourseCode VARCHAR(20),
    @CourseDescription VARCHAR(100)
AS
BEGIN
UPDATE Course
       SET 
        CourseCode = @CourseCode,
        CourseDescription = @CourseDescription
       WHERE CourseID = @CourseID;
END
GO

-- 1.6. DELETE COURSE //
CREATE OR ALTER PROCEDURE sp_DeleteCourse
    @CourseID INT
AS
BEGIN
    SET NOCOUNT ON;

    -- CANCEL DELETE IF COURSE IS LINKED TO AN OFFERING (The Academic Plan)
    IF EXISTS (SELECT 1 FROM Offering WHERE CourseID = @CourseID)
    BEGIN
        RAISERROR('Cannot delete: This course is linked to an existing Curriculum Offering.', 16, 1);
        RETURN;
    END

    DELETE FROM Course WHERE CourseID = @CourseID;
END;
GO

-- 1.7 Get all course by program
CREATE OR ALTER PROCEDURE sp_GetCoursesByProgram
    @ProgramID INT = NULL
AS
BEGIN
    SELECT DISTINCT
        c.CourseID,
        c.CourseCode,
        c.CourseDescription,
        cur.CurriculumID,
        ch.CurriculumYear,
        cur.YearLevel,
        cur.Semester
    FROM Offering o
    INNER JOIN Curriculum cur ON o.CurriculumID = cur.CurriculumID
    INNER JOIN CurriculumHeader ch ON cur.CurriculumHeaderID = ch.CurriculumHeaderID
    INNER JOIN Course c ON o.CourseID = c.CourseID
    WHERE (@ProgramID IS NULL OR ch.ProgramID = @ProgramID)
    ORDER BY c.CourseCode;
END;
GO

-- 1.8. Get all course per Curriculum Year
CREATE OR ALTER PROCEDURE sp_GetCoursesByCurriculumYear
    @CurriculumYear VARCHAR(10) = NULL
AS
BEGIN
    SELECT DISTINCT
        c.CourseID,
        c.CourseCode,
        c.CourseDescription,
        cur.CurriculumID,
        ch.CurriculumYear,
        ch.ProgramID,
        cur.YearLevel,
        cur.Semester
    FROM Offering o
    INNER JOIN Curriculum cur ON o.CurriculumID = cur.CurriculumID
    INNER JOIN CurriculumHeader ch ON cur.CurriculumHeaderID = ch.CurriculumHeaderID
    INNER JOIN Course c ON o.CourseID = c.CourseID
    WHERE (@CurriculumYear IS NULL OR ch.CurriculumYear = @CurriculumYear)
    ORDER BY c.CourseCode;
END;
GO

--==================================================
-- 2. PROGRAM STORED PROCEDURE
--==================================================
-- 2.1. CREATE PROGRAM //
CREATE OR ALTER PROCEDURE sp_CreateProgram
	@ProgramCode VARCHAR(20),
	@ProgramDescription VARCHAR(100)
AS
BEGIN
	INSERT INTO Program (ProgramCode, ProgramDescription)
	VALUES (@ProgramCode, @ProgramDescription);
END
GO

-- 2.2. GET ALL PROGRAM //
CREATE OR ALTER PROCEDURE sp_GetAllProgram
AS
BEGIN
	SELECT
        ProgramID,
		ProgramCode,
		ProgramDescription
	FROM
		Program
END
GO

-- 2.3. SEARCH PROGRAM //
CREATE OR ALTER PROCEDURE sp_SearchProgram
    @SearchTerm VARCHAR(100)      = NULL,
    @CurriculumYear VARCHAR(10)   = NULL
AS
BEGIN
    SET NOCOUNT ON;

    -- Normalize and escape search term
    DECLARE @Filter VARCHAR(220) = NULL;

    IF LTRIM(RTRIM(ISNULL(@SearchTerm, ''))) <> ''
    BEGIN
        SET @Filter = '%' + REPLACE(REPLACE(REPLACE(@SearchTerm, '[', '[[]'), '%', '[%]'), '_', '[_]') + '%';
    END

    SELECT DISTINCT
        p.ProgramID,
        p.ProgramCode,
        p.ProgramDescription
    FROM Program p
    LEFT JOIN CurriculumHeader ch
        ON ch.ProgramID = p.ProgramID
    WHERE
        -- Search term filter
        (@Filter IS NULL OR p.ProgramCode LIKE @Filter OR p.ProgramDescription LIKE @Filter)
        -- Curriculum year filter (now using CurriculumHeader)
        AND (@CurriculumYear IS NULL OR ch.CurriculumYear = @CurriculumYear)
    ORDER BY p.ProgramCode;
END
GO

-- 2.4. UPDATE PROGRAM //
CREATE OR ALTER PROCEDURE sp_UpdateProgram
	@ProgramID INT,
	@ProgramCode VARCHAR(20),
	@ProgramDescription VARCHAR(100)
AS
BEGIN
	UPDATE 
		Program
	SET
		ProgramCode = @ProgramCode,
		ProgramDescription = @ProgramDescription
	WHERE
		ProgramID = @ProgramID;
END
GO

-- 2.5. DELETE PROGRAM //
CREATE OR ALTER PROCEDURE sp_DeleteProgram
    @ProgramID INT
AS
BEGIN
    SET NOCOUNT ON;

    DELETE FROM Program WHERE ProgramID = @ProgramID;

END
GO

-- 2.6. Get all program by curriculum year
CREATE OR ALTER PROCEDURE sp_GetProgramsByCurriculumYear
    @CurriculumYear VARCHAR(10) = NULL
AS
BEGIN
    SELECT DISTINCT
        p.ProgramID,
        p.ProgramCode,
        p.ProgramDescription
    FROM Program p
    INNER JOIN CurriculumHeader ch
        ON p.ProgramID = ch.ProgramID
    WHERE (@CurriculumYear IS NULL OR ch.CurriculumYear = @CurriculumYear)
    ORDER BY p.ProgramCode;
END
GO

--==================================================
-- 3. FACULTY STORED PROCEDURE 
--==================================================
-- 3.1. CREATE FACULTY //
CREATE OR ALTER PROCEDURE sp_CreateFaculty
    @FirstName   VARCHAR(50),
    @MiddleName  VARCHAR(20) = NULL,
    @LastName    VARCHAR(50),
    @Suffix      VARCHAR(10) = NULL,
    @Initials    VARCHAR(20) = NULL
AS
BEGIN
    INSERT INTO Faculty (FirstName, MiddleName, LastName, Suffix, Initials)
    VALUES (@FirstName, @MiddleName, @LastName, @Suffix, @Initials);
END;
GO

-- 3.2. GET ALL FACULTY //
CREATE OR ALTER PROCEDURE sp_GetAllFaculty
AS
BEGIN
    SELECT 
        FacultyID,
        FirstName,
        MiddleName,
        LastName,
        LastName + ', ' + FirstName + ' ' + ISNULL(NULLIF(SUBSTRING(MiddleName, 1, 1), '') + '.', '') AS FullName,
        Initials
    FROM Faculty
    ORDER BY LastName, FirstName ASC;
END;
GO

-- 3.3. SEARCH FACULTY 
CREATE OR ALTER PROCEDURE sp_SearchFaculty
    @SearchTerm VARCHAR(50) = NULL
AS
BEGIN
    SET NOCOUNT ON;

    -- Prepare the search filter to handle NULLs and prevent repetitive string building
    DECLARE @Filter VARCHAR(52) = '%' + ISNULL(@SearchTerm, '') + '%';

    SELECT 
        FacultyID,
        FirstName,
        MiddleName,
        LastName,
        LastName + ', ' + FirstName + ' ' + ISNULL(NULLIF(SUBSTRING(MiddleName, 1, 1), '') + '.', '') AS FullName,
        Initials
    FROM Faculty f
    WHERE 
        -- Name Search Logic
        (@SearchTerm IS NULL OR (
            FirstName  LIKE @Filter
            OR MiddleName LIKE @Filter
            OR LastName   LIKE @Filter
        ))
    ORDER BY LastName, FirstName ASC;
END;
GO

-- 3.4. UPDATE FACULTY //
CREATE OR ALTER PROCEDURE sp_UpdateFaculty
    @FacultyID INT,
    @FirstName   VARCHAR(50),
    @MiddleName  VARCHAR(20) = NULL,
    @LastName    VARCHAR(50),
    @Suffix      VARCHAR(10) = NULL,
    @Initials    VARCHAR(20) = NULL
AS
BEGIN
    UPDATE Faculty
    SET
        FirstName  = @FirstName,
        MiddleName = @MiddleName,
        LastName   = @LastName,
        Suffix     = @Suffix,
        Initials   = @Initials
    WHERE FacultyID = @FacultyID;
END;
GO

-- 3.5. DELETE FACULTY //
CREATE OR ALTER PROCEDURE sp_DeleteFaculty
    @FacultyID INT
AS
BEGIN
    -- para di agad madelete pag connected sa iabng table alsin nalang if di needed
    IF EXISTS (SELECT 1 FROM ClassSection WHERE FacultyID = @FacultyID)

    BEGIN
        RAISERROR('Cannot delete Faculty. Faculty is currently in use.', 16, 1);
        RETURN;
    END

    DELETE FROM Faculty
    WHERE FacultyID = @FacultyID;
END;
GO

--==================================================
-- 4. CURRICULUM STORED PROCEDURE
--==================================================
--------------------------------------------------
-- 4.1. CURRICULUM HEADER
--------------------------------------------------
-- 4.1.1. INSERT CURRICULUM HEADER
CREATE OR ALTER PROCEDURE sp_InsertCurriculumHeader
    @ProgramID INT,    
    @CurriculumYear VARCHAR(10)
AS BEGIN 
	INSERT INTO CurriculumHeader (ProgramID, CurriculumYear)
	VALUES (@ProgramID, @CurriculumYear);
END
GO

-- 4.1.2. GET CURRICULUM HEADER ID
CREATE OR ALTER PROCEDURE sp_SelectCurriculumHeaderID
    @ProgramID INT ,    
    @CurriculumYear VARCHAR(10) 
AS BEGIN
	SELECT CurriculumHeaderID FROM CurriculumHeader 
	WHERE ProgramID = @ProgramID AND
	      CurriculumYear = @CurriculumYear 
END
GO

-- 4.1.3. COUNT CURRICULUM HEADER
CREATE OR ALTER PROCEDURE sp_CountCurriculumHeader
    @ProgramID INT,
    @CurriculumYear VARCHAR(10)
    
AS BEGIN
    SELECT COUNT(*) From CurriculumHeader where CurriculumYear = @CurriculumYear and ProgramID = @ProgramID
END
GO

-- 4.1.4. Get all Curriculum grouped by curriculum year
CREATE OR ALTER PROCEDURE sp_GetAllCurriculum
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        CurriculumYear
    FROM CurriculumHeader
    GROUP BY CurriculumYear
    ORDER BY CurriculumYear;
END
GO

--------------------------------------------------
-- 4.2. CURRICULUM STRUCTURE
--------------------------------------------------
-- 4.2.1. INSERT CURRICULUM
CREATE OR ALTER PROCEDURE sp_InsertCurriculum
    @CurriculumHeaderID INT,
    @YearLevel INT,
    @Semester INT
AS BEGIN
	INSERT INTO Curriculum (CurriculumHeaderID, YearLevel, Semester)
	VALUES (@CurriculumHeaderID, @YearLevel, @Semester)
END
GO

-- 4.2.2. GET CURRICULUM ID
CREATE OR ALTER PROCEDURE sp_SelectCurriculumID
    @CurriculumHeaderID INT,
    @YearLevel INT,
    @Semester INT
AS BEGIN
	SELECT CurriculumID FROM Curriculum 
	WHERE CurriculumHeaderID = @CurriculumHeaderID AND
	      YearLevel = @YearLevel AND
	      Semester = @Semester
END
GO

-- 4.2.3. VIEW ALL CURRICULUM
CREATE OR ALTER PROCEDURE sp_ViewAllCurriculum
    @CurriculumHeaderID VARCHAR(10)
AS 
BEGIN
    SELECT 
        C.CurriculumID,
        C.YearLevel, 
        C.Semester
    FROM Curriculum C
    INNER JOIN CurriculumHeader CH ON C.CurriculumHeaderID = CH.CurriculumHeaderID
    WHERE CH.CurriculumHeaderID = @CurriculumHeaderID
    ORDER BY C.YearLevel ASC, C.Semester ASC;
END
GO

-- 4.2.4. COUNT CURRICULUM
CREATE OR ALTER PROCEDURE sp_CountCurriculum
    @CurriculumHeaderID VARCHAR(10),
    @YearLevel INT,
    @Semester INT
AS BEGIN
    SELECT COUNT(*) From Curriculum where CurriculumHeaderID = @CurriculumHeaderID and YearLevel = @YearLevel and Semester = @Semester
END
GO

-- 4.2.5. SEARCH VIEW CURRICULUM
CREATE OR ALTER PROCEDURE sp_SearchViewCurriculum
    @ProgramID INT,
    @CurriculumYear VARCHAR(10)
AS BEGIN
    SELECT 
        c.YearLevel, 
        c.Semester, 
        co.CourseID,
        co.CourseCode,
        co.CourseDescription
    FROM CurriculumHeader ch
    JOIN Curriculum c ON ch.CurriculumHeaderID = c.CurriculumHeaderID
    JOIN Offering o ON c.CurriculumID = o.CurriculumID
    JOIN Course co ON o.CourseID = co.CourseID
    WHERE ch.ProgramID = @ProgramID          
      AND ch.CurriculumYear = @CurriculumYear
    ORDER BY c.YearLevel, c.Semester, co.CourseDescription;
END
GO

--------------------------------------------------
-- 4.3. OFFERING
--------------------------------------------------
-- 4.3.1. INSERT OFFERING COURSE
CREATE OR ALTER PROCEDURE sp_InsertCurriculumCourse
    @CurriculumID INT,
    @CourseID INT
   
AS BEGIN
	INSERT INTO Offering (CurriculumID, CourseID)
        VALUES (@CurriculumID, @CourseID)
END
GO

-- 4.3.2. GET OFFERING COURSE
CREATE OR ALTER PROCEDURE sp_SelectCurriculumCourse
    @CurriculumID INT
AS 
BEGIN

    SELECT 
        O.CurriculumID,
        O.OfferingID,
        O.CourseID,
        C.CourseCode,
        C.CourseDescription
    FROM Offering O
    INNER JOIN Course C ON O.CourseID = C.CourseID
    WHERE O.CurriculumID = @CurriculumID
    ORDER BY C.CourseCode ASC;
END
GO

-- 4.3.3. DELETE OFFERING COURSE
CREATE OR ALTER PROCEDURE sp_DeleteCurriculumCourse
    @OfferingID INT

AS BEGIN 
    DELETE FROM Offering WHERE OfferingID = @OfferingID 
END
GO

--------------------------------------------------
-- 4.4. CLASS SECTION
--------------------------------------------------
-- 4.4.1. INSERT CLASS SECTION
CREATE OR ALTER PROCEDURE sp_InsertClassSection
    @CurriculumYear VARCHAR(10),
    @ProgramCode VARCHAR(20),
    @YearLevel INT,
    @Semester INT,
    @CourseCode VARCHAR(20),
    @FacultyID INT,
    @Section INT,
    @SchoolYear VARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @OfferingID INT;

    -- Look up the OfferingID based on the provided filters
    SELECT @OfferingID = O.OfferingID
    FROM Offering O
    INNER JOIN Curriculum CU ON O.CurriculumID = CU.CurriculumID
    INNER JOIN CurriculumHeader CH ON CU.CurriculumHeaderID = CH.CurriculumHeaderID
    INNER JOIN Program P ON CH.ProgramID = P.ProgramID
    INNER JOIN Course C ON O.CourseID = C.CourseID
    WHERE CH.CurriculumYear = @CurriculumYear
      AND P.ProgramCode = @ProgramCode
      AND CU.YearLevel = @YearLevel
      AND CU.Semester = @Semester
      AND C.CourseCode = @CourseCode;

    IF @OfferingID IS NOT NULL
    BEGIN
        -- Check if assignment exists for this section and school year to prevent duplicates
        -- You can choose to UPDATE or IGNORE if it exists.
        IF EXISTS (SELECT 1 FROM ClassSection WHERE OfferingID = @OfferingID AND Section = @Section AND SchoolYear = @SchoolYear)
        BEGIN
            UPDATE ClassSection
            SET FacultyID = @FacultyID
            WHERE OfferingID = @OfferingID AND Section = @Section AND SchoolYear = @SchoolYear;
        END
        ELSE
        BEGIN
            INSERT INTO ClassSection (OfferingID, FacultyID, Section, SchoolYear)
            VALUES (@OfferingID, @FacultyID, @Section, @SchoolYear);
        END
    END
    ELSE
    BEGIN
        RAISERROR('Offering not found for the specified course and curriculum.', 16, 1);
    END
END
GO

-- 4.4.2. UPDATE CLASS SECTION
CREATE OR ALTER PROCEDURE sp_UpdateClassSection
    @CurriculumYear VARCHAR(10),
    @ProgramCode VARCHAR(20),
    @YearLevel INT,
    @Semester INT,
    @CourseCode VARCHAR(20),
    -- Search Criteria (The "Old" values)
    @OldSection INT,
    @OldSchoolYear VARCHAR(20),
    -- New Values to set
    @NewFacultyID INT,
    @NewSection INT,
    @NewSchoolYear VARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @OfferingID INT;

    -- 1. Look up the OfferingID based on the curriculum/course filters
    SELECT @OfferingID = O.OfferingID
    FROM Offering O
    INNER JOIN Curriculum CU ON O.CurriculumID = CU.CurriculumID
    INNER JOIN CurriculumHeader CH ON CU.CurriculumHeaderID = CH.CurriculumHeaderID
    INNER JOIN Program P ON CH.ProgramID = P.ProgramID
    INNER JOIN Course C ON O.CourseID = C.CourseID
    WHERE CH.CurriculumYear = @CurriculumYear
      AND P.ProgramCode = @ProgramCode
      AND CU.YearLevel = @YearLevel
      AND CU.Semester = @Semester
      AND C.CourseCode = @CourseCode;

    -- 2. Update the record using the OfferingID + Old Section/Year
    IF @OfferingID IS NOT NULL
    BEGIN
        UPDATE ClassSection
        SET FacultyID = @NewFacultyID,
            Section = @NewSection,
            SchoolYear = @NewSchoolYear
        WHERE OfferingID = @OfferingID 
          AND Section = @OldSection 
          AND SchoolYear = @OldSchoolYear;

        IF @@ROWCOUNT = 0
        BEGIN
            RAISERROR('Update failed: No existing record found with the provided Section and School Year.', 16, 1);
        END
    END
    ELSE
    BEGIN
        RAISERROR('Update failed: Offering not found.', 16, 1);
    END
END
GO

-- 4.4.3. SAVE AND UPDATE WORKSHEET
CREATE OR ALTER PROCEDURE sp_SyncClassSectionAssignment
    @OfferingID INT,
    @FacultyID INT,      -- Can be NULL for partial save
    @Section INT,
    @SchoolYear VARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;

    -- CASE 1: User selected a faculty (Save/Update)
    IF @FacultyID IS NOT NULL
    BEGIN
        IF EXISTS (SELECT 1 FROM ClassSection WHERE OfferingID = @OfferingID AND Section = @Section AND SchoolYear = @SchoolYear)
        BEGIN
            UPDATE ClassSection 
            SET FacultyID = @FacultyID
            WHERE OfferingID = @OfferingID AND Section = @Section AND SchoolYear = @SchoolYear;
        END
        ELSE
        BEGIN
            INSERT INTO ClassSection (OfferingID, FacultyID, Section, SchoolYear)
            VALUES (@OfferingID, @FacultyID, @Section, @SchoolYear);
        END
    END

    -- CASE 2: User left faculty blank (Delete if exists and safe)
    ELSE 
    BEGIN
        -- We only delete the assignment if there is no GradeSheet uploaded yet
        IF NOT EXISTS (
            SELECT 1 FROM GradeSheet gs
            INNER JOIN ClassSection cs ON gs.SectionID = cs.SectionID
            WHERE cs.OfferingID = @OfferingID AND cs.Section = @Section AND cs.SchoolYear = @SchoolYear
        )
        BEGIN
            DELETE FROM ClassSection 
            WHERE OfferingID = @OfferingID AND Section = @Section AND SchoolYear = @SchoolYear;
        END
    END
END
GO

-- 4.4.4. VIEW SECTION AND FACULTY ASSIGNMENT
CREATE OR ALTER PROCEDURE sp_GetSubjectFacultyAssignment
    @CurriculumYear VARCHAR(10),
    @ProgramCode VARCHAR(20),
    @SchoolYear VARCHAR(20),
    @Section INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        Curr.YearLevel,
        Curr.Semester,
        C.CourseCode,
        C.CourseDescription,
        -- If no section/faculty exists for this filter, it shows 'No Faculty Assigned'
        ISNULL(F.FirstName + ' ' + ISNULL(F.MiddleName + ' ', '') + F.LastName, 'No Faculty Assigned') AS Faculty
    FROM Offering O
    INNER JOIN Course C ON O.CourseID = C.CourseID
    INNER JOIN Curriculum Curr ON O.CurriculumID = Curr.CurriculumID
    INNER JOIN CurriculumHeader CH ON Curr.CurriculumHeaderID = CH.CurriculumHeaderID
    INNER JOIN Program P ON CH.ProgramID = P.ProgramID
    -- Logic: Join section only if it matches our specific filter
    LEFT JOIN ClassSection CS ON O.OfferingID = CS.OfferingID 
        AND CS.SchoolYear = @SchoolYear 
        AND CS.Section = @Section
    LEFT JOIN Faculty F ON CS.FacultyID = F.FacultyID
    WHERE 
        CH.CurriculumYear = @CurriculumYear
        AND P.ProgramCode = @ProgramCode;
END;
GO

--==================================================
-- 5. GRADESHEET STORED PROCEDURE
--==================================================
-- 5.1. UPLOAD GRADESHEET
CREATE OR ALTER PROCEDURE sp_AddGradeSheet
    @Filename      VARCHAR(100),
    @Filepath      VARCHAR(200),
    @SectionID     INT,
    @PageNumber    INT,
    @AccountID     INT
AS
BEGIN
    SET NOCOUNT ON;

    
    IF @Filename IS NULL OR @Filename = ''
    BEGIN
        RAISERROR('Filename is required.', 16, 1);
        RETURN;
    END

    IF @Filepath IS NULL OR @Filepath = ''
    BEGIN
        RAISERROR('Filepath is required.', 16, 1);
        RETURN;
    END

    INSERT INTO GradeSheet
    (
        Filename,
        Filepath,
        SectionID,
        PageNumber,
        AccountID
    )
    VALUES
    (
        @Filename,
        @Filepath,
        @SectionID,
        @PageNumber,
        @AccountID
    );

    -- Return newly inserted ID (for Dapper / C# usage)
    SELECT CAST(SCOPE_IDENTITY() AS INT);
END;
GO

-- 5.2 DELETE GRADESHEET
CREATE OR ALTER PROCEDURE sp_DeleteGradeSheet
@GradeSheetID INT
AS
BEGIN
DELETE FROM GradeSheet
WHERE GradeSheetID = @GradeSheetID
END;
GO

-- 5.3. GET ALL GRADESHEET
CREATE OR ALTER PROCEDURE sp_GetAllGradeSheets
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        gs.GradeSheetID,
        gs.Filename,
        cs.SchoolYear,
        ch.CurriculumYear AS Curriculum,
        p.ProgramCode AS Program,
        cur.YearLevel,
        cs.Section,
        cur.Semester,
        c.CourseCode AS Course,
        f.LastName + ', ' + f.FirstName AS Professor,
        gs.PageNumber
    FROM GradeSheet gs
        INNER JOIN ClassSection cs ON gs.SectionID = cs.SectionID
        INNER JOIN Faculty f ON cs.FacultyID = f.FacultyID
        INNER JOIN Offering o ON cs.OfferingID = o.OfferingID
        INNER JOIN Course c ON o.CourseID = c.CourseID
        INNER JOIN Curriculum cur ON o.CurriculumID = cur.CurriculumID
        INNER JOIN CurriculumHeader ch ON cur.CurriculumHeaderID = ch.CurriculumHeaderID
        INNER JOIN Program p ON ch.ProgramID = p.ProgramID
        INNER JOIN Account a ON gs.AccountID = a.AccountID
    ORDER BY 
        cs.SchoolYear DESC,
        cur.Semester DESC,
        cur.YearLevel ASC,
        cs.Section ASC,
        c.CourseCode ASC,
        gs.PageNumber ASC;
END;
GO

-- 5.4. SEARCH GRADESHEETS
CREATE OR ALTER PROCEDURE sp_SearchGradeSheets
    @SchoolYear VARCHAR(20) = NULL,
    @Semester INT = NULL,
    @ProgramID INT = NULL,
    @CurriculumYear VARCHAR(10) = NULL,
    @YearLevel INT = NULL,
    @Section INT = NULL,
    @CourseID INT = NULL,
    @FacultyID INT = NULL
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        gs.GradeSheetID,           -- newly added
        gs.Filename,
        cs.SchoolYear,
        ch.CurriculumYear AS Curriculum,
        p.ProgramCode AS Program,
        cur.YearLevel,
        cs.Section,
        cur.Semester,
        c.CourseCode AS Course,
        f.LastName + ', ' + f.FirstName + ISNULL(' ' + NULLIF(LEFT(f.MiddleName, 1), ''), '') AS Professor,
        gs.PageNumber
    FROM GradeSheet gs
        INNER JOIN ClassSection cs ON gs.SectionID = cs.SectionID
        INNER JOIN Faculty f ON cs.FacultyID = f.FacultyID
        INNER JOIN Offering o ON cs.OfferingID = o.OfferingID
        INNER JOIN Course c ON o.CourseID = c.CourseID
        INNER JOIN Curriculum cur ON o.CurriculumID = cur.CurriculumID
        INNER JOIN CurriculumHeader ch ON cur.CurriculumHeaderID = ch.CurriculumHeaderID
        INNER JOIN Program p ON ch.ProgramID = p.ProgramID
    WHERE (@SchoolYear IS NULL OR cs.SchoolYear = @SchoolYear)
      AND (@Semester IS NULL OR cur.Semester = @Semester)
      AND (@ProgramID IS NULL OR p.ProgramID = @ProgramID)
      AND (@CurriculumYear IS NULL OR ch.CurriculumYear = @CurriculumYear)
      AND (@YearLevel IS NULL OR cur.YearLevel = @YearLevel)
      AND (@Section IS NULL OR cs.Section = @Section)
      AND (@CourseID IS NULL OR c.CourseID = @CourseID)
      AND (@FacultyID IS NULL OR f.FacultyID = @FacultyID)
    ORDER BY
        cs.SchoolYear DESC,
        cur.Semester DESC,
        cur.YearLevel ASC,
        cs.Section ASC,
        c.CourseCode ASC,
        gs.PageNumber ASC;
END;
GO

-- 5.5. UPDATE GRADESHEETS
CREATE OR ALTER PROCEDURE sp_UpdateGradeSheets
    @GradeSheetID INT,
    @SectionID INT = NULL,      -- The new Class Section it belongs to
    @Filename VARCHAR(100) = NULL,
    @Filepath VARCHAR(200) = NULL,
    @PageNumber INT
AS
BEGIN
    SET NOCOUNT ON;

    -- 1. Validation: Ensure the GradeSheet exists
    IF NOT EXISTS (SELECT 1 FROM GradeSheet WHERE GradeSheetID = @GradeSheetID)
    BEGIN
        RAISERROR('GradeSheet record not found.', 16, 1);
        RETURN;
    END

    -- 2. Validation: If SectionID is being updated, ensure the new section exists
    IF @SectionID IS NOT NULL AND NOT EXISTS (SELECT 1 FROM ClassSection WHERE SectionID = @SectionID)
    BEGIN
        RAISERROR('The target Class Section does not exist.', 16, 1);
        RETURN;
    END

    -- 3. Perform the Update
    UPDATE GradeSheet
    SET 
        SectionID = ISNULL(@SectionID, SectionID),
        Filename = ISNULL(@Filename, Filename),
        Filepath = ISNULL(@Filepath, Filepath),
        PageNumber = ISNULL(@PageNumber, PageNumber)
    WHERE GradeSheetID = @GradeSheetID;

    SELECT 'Success' AS Result;
END;
GO

--==================================================
-- 6. ACCOUNT STORED PROCEDURE 
--==================================================
-- 6.1. CREATE ACCOUNT //
CREATE OR ALTER PROCEDURE sp_CreateAccount
    @Username     VARCHAR(50),
    @Password     VARCHAR(255),
    @FirstName    VARCHAR(50),
    @LastName     VARCHAR(50),
    @AccountType  VARCHAR(20)
AS
BEGIN
    IF EXISTS (SELECT 1 FROM Account WHERE Username = @Username)
    BEGIN
        RAISERROR('Username already exists.', 16, 1);
        RETURN;
    END

    INSERT INTO Account (Username, Password, FirstName, LastName, AccountType)
    VALUES (@Username, @Password, @FirstName, @LastName, @AccountType);
END;
GO

-- 6.2. GET ALL ACCOUNT //
CREATE OR ALTER PROCEDURE sp_GetAllAccount
AS
BEGIN
    SELECT
        AccountID,
        Username,
        FirstName,
        LastName,
        LastName + ', ' + FirstName AS FullName,
        AccountType
    FROM 
        Account
    ORDER BY 
        LastName, FirstName ASC;
END;
GO

-- 6.3. SEARCH ACCOUNT //
CREATE OR ALTER PROCEDURE sp_SearchAccount
    @SearchTerm VARCHAR(50)
AS
BEGIN
    SELECT
        AccountID,
        Username,
        FirstName,
        LastName,
        AccountType
    FROM Account
    WHERE Username  LIKE '%' + @SearchTerm + '%'
       OR FirstName LIKE '%' + @SearchTerm + '%'
       OR LastName  LIKE '%' + @SearchTerm + '%'
    ORDER BY LastName, FirstName;
END;
GO

-- 6.4. UPDATE ACCOUNT //
CREATE OR ALTER PROCEDURE sp_UpdateAccount
    @AccountID    INT,
    @Username     VARCHAR(50),
    @Password     VARCHAR(50),
    @FirstName    VARCHAR(50),
    @LastName     VARCHAR(50),
    @AccountType  VARCHAR(20)
AS
BEGIN
    IF EXISTS (
        SELECT 1 FROM Account 
        WHERE Username = @Username 
        AND AccountID <> @AccountID
    )
    BEGIN
        RAISERROR('Username already exists.', 16, 1);
        RETURN;
    END

    UPDATE 
        Account
    SET
        Username    = @Username,
        Password    = @Password,
        FirstName   = @FirstName,
        LastName    = @LastName,
        AccountType = @AccountType
    WHERE 
        AccountID = @AccountID;
END;
GO

-- 6.5. DELETE ACCOUNT //
CREATE OR ALTER PROCEDURE sp_DeleteAccount
    @AccountID INT
AS
BEGIN
    IF EXISTS (SELECT 1 FROM GradeSheet WHERE AccountID = @AccountID)
       OR EXISTS (SELECT 1 FROM ActivityLog WHERE AccountID = @AccountID)
    BEGIN
        RAISERROR('Cannot delete account. Account is currently in use.', 16, 1);
        RETURN;
    END

    DELETE FROM Account
    WHERE AccountID = @AccountID;
END;
GO

-- 6.6. Login Account //
CREATE OR ALTER PROCEDURE sp_LoginAccount
    @Username VARCHAR(50),
    @Password VARCHAR(50)
AS
BEGIN
    SELECT *
    FROM Account
    WHERE Username = @Username
      AND Password = @Password;
END;
GO

--==================================================
-- 7. ACTIVITY LOG STORED PROCEDURE 
--==================================================
-- 7.1. CREATE ACTIVITY //
CREATE OR ALTER PROCEDURE sp_CreateActivityLog
    @AccountID INT,
    @ActivityDescription VARCHAR(255),
    @ActivityDate DATETIME
AS
BEGIN
    INSERT INTO ActivityLog(AccountID, ActivityDescription, ActivityDate)
    VALUES (@AccountID, @ActivityDescription, @ActivityDate);
END
GO

-- 7.2. GET ALL ACTIVITY //
CREATE OR ALTER PROCEDURE sp_GetAllActivityLog
AS
BEGIN
    SELECT
        CONCAT_WS(' ', ActivityDescription, ActivityDate) AS Log
    FROM 
        ActivityLog;
END
GO

--==================================================
-- 8. DASHBOARD STORED PROCEDURES
--==================================================
-- 8.1. Count for TOTAL GRADE SHEETS
CREATE OR ALTER PROCEDURE sp_GetGradeSheetCount
AS
BEGIN
    SELECT COUNT(*) FROM GradeSheet;
END
GO

-- 8.2. Count for TOTAL SUBJECTS (Counts the Course table)
CREATE OR ALTER PROCEDURE sp_GetSubjectCount
AS
BEGIN
    SELECT COUNT(*) FROM Course;
END
GO
-- 8.3. Count for TOTAL PROFESSORS (Counts the Faculty table)
CREATE OR ALTER PROCEDURE sp_GetFacultyCount
AS
BEGIN
    SELECT COUNT(*) FROM Faculty;
END
GO

-- 8.4 Count for TOTAL PROGRAM
CREATE OR ALTER PROCEDURE sp_GetProgramCount
AS 
BEGIN
    -- This counts unique ProgramCode values only
    SELECT COUNT(*) FROM Program
END
GO

-- 8.5. GET ACTIVITY LOG ACTION
CREATE or ALTER PROCEDURE sp_GetActivityLogWithUserDesc
AS
BEGIN
    SET NOCOUNT ON;

    SELECT TOP 20
        AL.LogID,
        A.Username,
        AL.ActivityDescription,
        AL.ActivityDate
    FROM 
        ActivityLog AL
    INNER JOIN 
        Account A ON AL.AccountID = A.AccountID
    ORDER BY 
        AL.ActivityDate DESC, -- Primary: Sort by Date/Time (Newest First)
        AL.LogID DESC;        -- Secondary: If times are equal, higher ID comes first
END
GO

-- 8.6. show recently upload gradesheet in dashboard
CREATE OR ALTER PROCEDURE RecentUploadedGradeSheets
AS 
BEGIN
    SELECT TOP 10
           g.Filename, 
           c.CourseCode, 
           a.FirstName + ' ' + a.LastName AS UploadedBy
    FROM GradeSheet g
    JOIN ClassSection cs ON g.SectionID = cs.SectionID
    JOIN Offering o ON cs.OfferingID = o.OfferingID
    JOIN Course c ON o.CourseID = c.CourseID
    JOIN Account a ON g.AccountID = a.AccountID
    ORDER BY g.GradeSheetID DESC;
END;
GO

--------------------------------------------------
-- 8.7. Distribution by PROGRAM
--------------------------------------------------
-- 8.7.1. Get all unique Curriculum Years for the ComboBox
CREATE OR ALTER PROCEDURE sp_GetAllCurriculums
AS
BEGIN
    SELECT DISTINCT CurriculumYear 
    FROM CurriculumHeader 
    ORDER BY CurriculumYear DESC;
END;
GO

-- 8.7.2. Get School Years filtered by the selected Curriculum
CREATE OR ALTER PROCEDURE sp_GetSchoolYearsByCurriculum
    @CurriculumYear VARCHAR(10) = NULL
AS
BEGIN
    SET NOCOUNT ON;
    SELECT DISTINCT cs.SchoolYear
    FROM ClassSection cs
    INNER JOIN Offering o ON cs.OfferingID = o.OfferingID
    INNER JOIN Curriculum cur ON o.CurriculumID = cur.CurriculumID
    INNER JOIN CurriculumHeader ch ON cur.CurriculumHeaderID = ch.CurriculumHeaderID
    WHERE (@CurriculumYear IS NULL OR @CurriculumYear = 'All' OR ch.CurriculumYear = @CurriculumYear)
    ORDER BY cs.SchoolYear DESC;
END;
GO

-- 8.7.3. Get Chart Data: Joins GradeSheet -> Curriculum -> Program
CREATE OR ALTER PROCEDURE sp_GetDistributionByProgram_Filtered
    @SchoolYear VARCHAR(20) = NULL,
    @CurriculumYear VARCHAR(10) = NULL
AS
BEGIN
    SELECT 
        p.ProgramCode AS Label, 
        COUNT(gs.GradeSheetID) AS Value
    FROM GradeSheet gs
    INNER JOIN ClassSection cs ON gs.SectionID = cs.SectionID
    INNER JOIN Offering o ON cs.OfferingID = o.OfferingID
    INNER JOIN Curriculum cur ON o.CurriculumID = cur.CurriculumID
    INNER JOIN CurriculumHeader ch ON cur.CurriculumHeaderID = ch.CurriculumHeaderID
    INNER JOIN Program p ON ch.ProgramID = p.ProgramID
    WHERE 
        (@SchoolYear IS NULL OR @SchoolYear = 'All' OR cs.SchoolYear = @SchoolYear)
        AND (@CurriculumYear IS NULL OR @CurriculumYear = 'All' OR ch.CurriculumYear = @CurriculumYear)
    GROUP BY p.ProgramCode
    ORDER BY Value DESC;
END;
GO

--8.7.4 Get Year Level Distribution for a specific Program
CREATE OR ALTER PROCEDURE sp_GetYearLevelDistributionByProgram
    @ProgramCode VARCHAR(20),
    @SchoolYear VARCHAR(20) = NULL,
    @CurriculumYear VARCHAR(10) = NULL
AS
BEGIN
    SELECT 
        cur.YearLevel,
        COUNT(gs.GradeSheetID) AS Total
    FROM GradeSheet gs
    INNER JOIN ClassSection cs ON gs.SectionID = cs.SectionID
    INNER JOIN Offering o ON cs.OfferingID = o.OfferingID
    INNER JOIN Curriculum cur ON o.CurriculumID = cur.CurriculumID
    INNER JOIN CurriculumHeader ch ON cur.CurriculumHeaderID = ch.CurriculumHeaderID
    INNER JOIN Program p ON ch.ProgramID = p.ProgramID
    WHERE 
        p.ProgramCode = @ProgramCode
        AND (@SchoolYear IS NULL OR @SchoolYear = 'All' OR cs.SchoolYear = @SchoolYear)
        AND (@CurriculumYear IS NULL OR @CurriculumYear = 'All' OR ch.CurriculumYear = @CurriculumYear)
    GROUP BY cur.YearLevel
    ORDER BY cur.YearLevel ASC;
END
GO

-- 8.7.5. Filter Data: Get School Years filtered by Curriculum AND Program
CREATE OR ALTER PROCEDURE sp_GetSchoolYearsByCurriculumAndProgram
    @CurriculumYear VARCHAR(10) = NULL,
    @ProgramCode    VARCHAR(20) = NULL
AS
BEGIN
    SET NOCOUNT ON;
    SELECT DISTINCT cs.SchoolYear
    FROM ClassSection cs
    INNER JOIN Offering o ON cs.OfferingID = o.OfferingID
    INNER JOIN Curriculum cur ON o.CurriculumID = cur.CurriculumID
    INNER JOIN CurriculumHeader ch ON cur.CurriculumHeaderID = ch.CurriculumHeaderID
    INNER JOIN Program p ON ch.ProgramID = p.ProgramID
    WHERE (@CurriculumYear IS NULL OR @CurriculumYear = 'All' OR ch.CurriculumYear = @CurriculumYear)
      AND (@ProgramCode IS NULL OR @ProgramCode = 'All' OR p.ProgramCode = @ProgramCode)
    ORDER BY cs.SchoolYear DESC;
END;
GO

-- 8.7.6 Get Count of Submitted vs Total Curriculum Courses for a Program
CREATE OR ALTER PROCEDURE sp_GetProgramGradeSheetCounts
    @ProgramCode VARCHAR(20),
    @SchoolYear VARCHAR(20) = NULL,
    @CurriculumYear VARCHAR(10) = NULL
AS
BEGIN
    DECLARE @SubmittedCount INT;
    DECLARE @TotalCount INT;

    -- 1. Count actual uploads (via GradeSheet)
    SELECT @SubmittedCount = COUNT(gs.GradeSheetID)
    FROM GradeSheet gs
    INNER JOIN ClassSection cs ON gs.SectionID = cs.SectionID
    INNER JOIN Offering o ON cs.OfferingID = o.OfferingID
    INNER JOIN Curriculum cur ON o.CurriculumID = cur.CurriculumID
    INNER JOIN CurriculumHeader ch ON cur.CurriculumHeaderID = ch.CurriculumHeaderID
    INNER JOIN Program p ON ch.ProgramID = p.ProgramID
    WHERE p.ProgramCode = @ProgramCode
      AND (@SchoolYear IS NULL OR @SchoolYear = 'All' OR cs.SchoolYear = @SchoolYear)
      AND (@CurriculumYear IS NULL OR @CurriculumYear = 'All' OR ch.CurriculumYear = @CurriculumYear);

    -- 2. Count Total Offerings defined in that curriculum (The "Target")
    SELECT @TotalCount = COUNT(o.OfferingID)
    FROM Offering o
    INNER JOIN Curriculum cur ON o.CurriculumID = cur.CurriculumID
    INNER JOIN CurriculumHeader ch ON cur.CurriculumHeaderID = ch.CurriculumHeaderID
    INNER JOIN Program p ON ch.ProgramID = p.ProgramID
    WHERE p.ProgramCode = @ProgramCode
      AND (@CurriculumYear IS NULL OR @CurriculumYear = 'All' OR ch.CurriculumYear = @CurriculumYear);

    SELECT ISNULL(@SubmittedCount, 0) AS SubmittedCount, ISNULL(@TotalCount, 0) AS TotalCurriculumCourses;
END
GO

-- 8.7.7. GET YEAR LEVEL AGGREGATE STATUS
CREATE OR ALTER PROCEDURE sp_GetYearLevelAggregateStatus -- Renamed to match helper
    @ProgramCode VARCHAR(20),
    @CurriculumYear VARCHAR(10) = NULL, -- Allow NULL
    @SchoolYear VARCHAR(20) = NULL      -- Allow NULL
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        cur.YearLevel,
        COUNT(DISTINCT o.OfferingID) AS SubjectsInCurriculum,
        COUNT(DISTINCT cs.SectionID) AS TotalSectionsCreated,
        COUNT(DISTINCT gs.GradeSheetID) AS TotalSubmitted,
        (COUNT(DISTINCT cs.SectionID) - COUNT(DISTINCT gs.GradeSheetID)) AS TotalPending,
        CASE 
            WHEN COUNT(DISTINCT cs.SectionID) = 0 THEN 0 
            ELSE CAST((COUNT(DISTINCT gs.GradeSheetID) * 100.0 / COUNT(DISTINCT cs.SectionID)) AS DECIMAL(5,2)) 
        END AS YearlyCompletionRate
    FROM Program p
    INNER JOIN CurriculumHeader ch ON p.ProgramID = ch.ProgramID
    INNER JOIN Curriculum cur ON ch.CurriculumHeaderID = cur.CurriculumHeaderID
    LEFT JOIN Offering o ON cur.CurriculumID = o.CurriculumID
    LEFT JOIN ClassSection cs ON o.OfferingID = cs.OfferingID 
        -- Handle "All" logic here:
        AND (@SchoolYear IS NULL OR cs.SchoolYear = @SchoolYear)
    LEFT JOIN GradeSheet gs ON cs.SectionID = gs.SectionID
    
    WHERE p.ProgramCode = @ProgramCode
      -- Handle "All" logic here:
      AND (@CurriculumYear IS NULL OR ch.CurriculumYear = @CurriculumYear)
    
    GROUP BY cur.YearLevel
    ORDER BY cur.YearLevel ASC;
END;
GO

--------------------------------------------------
-- 8.8. Distribution by PROFESSOR
--------------------------------------------------
-- 8.8.1. Main Faculty Distribution
CREATE OR ALTER PROCEDURE sp_GetDistributionByFaculty_Filtered
    @SchoolYear VARCHAR(20) = NULL,
    @CurriculumYear VARCHAR(10) = NULL
AS
BEGIN
    SELECT
        f.LastName + ', ' + f.FirstName AS Name,
        COUNT(gs.GradeSheetID) AS RecordCount
    FROM GradeSheet gs
    INNER JOIN ClassSection cs ON gs.SectionID = cs.SectionID
    INNER JOIN Faculty f ON cs.FacultyID = f.FacultyID
    INNER JOIN Offering o ON cs.OfferingID = o.OfferingID
    INNER JOIN Curriculum cur ON o.CurriculumID = cur.CurriculumID
    INNER JOIN CurriculumHeader ch ON cur.CurriculumHeaderID = ch.CurriculumHeaderID
    WHERE 
        (@SchoolYear IS NULL OR @SchoolYear = 'All' OR cs.SchoolYear = @SchoolYear)
        AND (@CurriculumYear IS NULL OR @CurriculumYear = 'All' OR ch.CurriculumYear = @CurriculumYear)
    GROUP BY f.LastName, f.FirstName
    ORDER BY RecordCount DESC;
END;
GO

-- 8.8.2. Stored Procedure that fetches the specific files based on the Professor's name and the active filters
CREATE OR ALTER PROCEDURE sp_GetGradeSheetsByFacultyDetails
    @FacultyName VARCHAR(100), -- "LastName, FirstName"
    @SchoolYear VARCHAR(20) = NULL,
    @CurriculumYear VARCHAR(10) = NULL
AS
BEGIN
    SELECT
        cs.SchoolYear AS [School Year],
        cur.Semester AS [Sem],
        p.ProgramCode AS [Program],
        cur.YearLevel AS [Year Level],
        c.CourseCode AS [Course Code],
        CASE 
            WHEN gs.GradeSheetID IS NOT NULL THEN 'Gradesheet uploaded' 
            ELSE 'No Grade Sheet' 
        END AS [Status]
    FROM ClassSection cs
    INNER JOIN Faculty f ON cs.FacultyID = f.FacultyID
    INNER JOIN Offering o ON cs.OfferingID = o.OfferingID
    INNER JOIN Course c ON o.CourseID = c.CourseID
    INNER JOIN Curriculum cur ON o.CurriculumID = cur.CurriculumID
    INNER JOIN CurriculumHeader ch ON cur.CurriculumHeaderID = ch.CurriculumHeaderID
    INNER JOIN Program p ON ch.ProgramID = p.ProgramID
    -- Use LEFT JOIN so we still see sections even if no gradesheet exists
    LEFT JOIN GradeSheet gs ON cs.SectionID = gs.SectionID
    WHERE 
        (f.LastName + ', ' + f.FirstName) = @FacultyName
        AND (@SchoolYear IS NULL OR @SchoolYear = 'All' OR cs.SchoolYear = @SchoolYear)
        AND (@CurriculumYear IS NULL OR @CurriculumYear = 'All' OR ch.CurriculumYear = @CurriculumYear)
    ORDER BY 
        cs.SchoolYear DESC, 
        cur.Semester DESC, 
        cur.YearLevel ASC;
END
GO

-- 8.8.3. FACULTY COUNT (Submitted vs Total Assigned)
CREATE OR ALTER PROCEDURE sp_GetFacultyDistribution_WithCounts
    @SchoolYear VARCHAR(20) = NULL,
    @CurriculumYear VARCHAR(10) = NULL
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        f.FacultyID,
        f.LastName + ', ' + f.FirstName AS Name,
        
        -- 1. COUNT SUBMITTED (Numerator)
        -- Counts actual uploads in GradeSheet table linked to this faculty via Section
        (SELECT COUNT(gs.GradeSheetID) 
         FROM GradeSheet gs
         INNER JOIN ClassSection cs_sub ON gs.SectionID = cs_sub.SectionID
         INNER JOIN Offering o_sub ON cs_sub.OfferingID = o_sub.OfferingID
         INNER JOIN Curriculum cur_sub ON o_sub.CurriculumID = cur_sub.CurriculumID
         INNER JOIN CurriculumHeader ch_sub ON cur_sub.CurriculumHeaderID = ch_sub.CurriculumHeaderID
         WHERE cs_sub.FacultyID = f.FacultyID
           AND (@SchoolYear IS NULL OR @SchoolYear = 'All' OR cs_sub.SchoolYear = @SchoolYear)
           AND (@CurriculumYear IS NULL OR @CurriculumYear = 'All' OR ch_sub.CurriculumYear = @CurriculumYear)
        ) AS SubmittedCount,

        -- 2. COUNT TOTAL ASSIGNED (Denominator)
        -- In the new schema, total assigned is found in ClassSection
        (SELECT COUNT(cs_all.SectionID) 
         FROM ClassSection cs_all
         INNER JOIN Offering o_all ON cs_all.OfferingID = o_all.OfferingID
         INNER JOIN Curriculum cur_all ON o_all.CurriculumID = cur_all.CurriculumID
         INNER JOIN CurriculumHeader ch_all ON cur_all.CurriculumHeaderID = ch_all.CurriculumHeaderID
         WHERE cs_all.FacultyID = f.FacultyID
           AND (@SchoolYear IS NULL OR @SchoolYear = 'All' OR cs_all.SchoolYear = @SchoolYear)
           AND (@CurriculumYear IS NULL OR @CurriculumYear = 'All' OR ch_all.CurriculumYear = @CurriculumYear)
        ) AS TotalAssigned

    FROM Faculty f
    -- Filtering to show only faculty with active assignments or uploads
    WHERE EXISTS (
        SELECT 1 FROM ClassSection cs_exist
        INNER JOIN Offering o_exist ON cs_exist.OfferingID = o_exist.OfferingID
        INNER JOIN Curriculum cur_exist ON o_exist.CurriculumID = cur_exist.CurriculumID
        INNER JOIN CurriculumHeader ch_exist ON cur_exist.CurriculumHeaderID = ch_exist.CurriculumHeaderID
        WHERE cs_exist.FacultyID = f.FacultyID
        AND (@SchoolYear IS NULL OR @SchoolYear = 'All' OR cs_exist.SchoolYear = @SchoolYear)
        AND (@CurriculumYear IS NULL OR @CurriculumYear = 'All' OR ch_exist.CurriculumYear = @CurriculumYear)
    )
    ORDER BY Name ASC;
END;
GO

--------------------------------------------------
-- 8.9. Distribution by SUBJECT
--------------------------------------------------
-- 8.9.1. Get Semesters By Filters
CREATE OR ALTER PROCEDURE sp_GetSemestersByFilters
    @CurriculumYear VARCHAR(10) = NULL,
    @SchoolYear VARCHAR(20) = NULL
AS
BEGIN
    SET NOCOUNT ON;

    SELECT DISTINCT cur.Semester
    FROM ClassSection cs
    INNER JOIN Offering o ON cs.OfferingID = o.OfferingID
    INNER JOIN Curriculum cur ON o.CurriculumID = cur.CurriculumID
    INNER JOIN CurriculumHeader ch ON cur.CurriculumHeaderID = ch.CurriculumHeaderID
    WHERE (@CurriculumYear IS NULL OR @CurriculumYear = 'All' OR ch.CurriculumYear = @CurriculumYear)
      AND (@SchoolYear IS NULL OR @SchoolYear = 'All' OR cs.SchoolYear = @SchoolYear)
    ORDER BY cur.Semester ASC;
END;
GO

-- 8.9.2. GET SUBJECT DISTRIBUTION (Filtered by Curr, Year, Sem)
CREATE OR ALTER PROCEDURE sp_GetDistributionBySubject_FilteredFull
    @CurriculumYear VARCHAR(10) = NULL,
    @SchoolYear VARCHAR(20) = NULL,
    @Semester INT = NULL
AS
BEGIN
    SELECT 
        c.CourseDescription AS SubjectName,
        COUNT(gs.GradeSheetID) AS Count
    FROM GradeSheet gs
    INNER JOIN ClassSection cs ON gs.SectionID = cs.SectionID
    INNER JOIN Offering o ON cs.OfferingID = o.OfferingID
    INNER JOIN Course c ON o.CourseID = c.CourseID
    INNER JOIN Curriculum cur ON o.CurriculumID = cur.CurriculumID
    INNER JOIN CurriculumHeader ch ON cur.CurriculumHeaderID = ch.CurriculumHeaderID
    WHERE 
        (@CurriculumYear IS NULL OR @CurriculumYear = 'All' OR ch.CurriculumYear = @CurriculumYear)
        AND (@SchoolYear IS NULL OR @SchoolYear = 'All' OR cs.SchoolYear = @SchoolYear)
        AND (@Semester IS NULL OR cur.Semester = @Semester)
    GROUP BY c.CourseDescription
    ORDER BY Count DESC;
END;
GO

-- 8.9.3. Get Subject Details
CREATE OR ALTER PROCEDURE sp_GetSubjectDetailsByName
    @CourseDescription VARCHAR(100)
AS
BEGIN
    SELECT DISTINCT
        c.CourseCode,
        f.LastName + ', ' + f.FirstName + ISNULL(' ' + LEFT(f.MiddleName, 1) + '.', '') AS FacultyName,
        ch.CurriculumYear
    FROM ClassSection cs
    INNER JOIN Faculty f ON cs.FacultyID = f.FacultyID
    INNER JOIN Offering o ON cs.OfferingID = o.OfferingID
    INNER JOIN Course c ON o.CourseID = c.CourseID
    INNER JOIN Curriculum cur ON o.CurriculumID = cur.CurriculumID
    INNER JOIN CurriculumHeader ch ON cur.CurriculumHeaderID = ch.CurriculumHeaderID
    WHERE c.CourseDescription = @CourseDescription
    ORDER BY ch.CurriculumYear DESC, FacultyName ASC;
END
GO

-- 8.9.4. GET TOTAL CURRICULUM COURSES (Global Numerator/Denominator)
CREATE OR ALTER PROCEDURE sp_GetTotalCurriculumCourses
    @SchoolYear VARCHAR(20) = NULL,
    @CurriculumYear VARCHAR(10) = NULL
AS
BEGIN
    DECLARE @SubmittedCount INT;
    DECLARE @TotalCount INT;

    -- Numerator: Actual Files
    SELECT @SubmittedCount = COUNT(gs.GradeSheetID)
    FROM GradeSheet gs
    INNER JOIN ClassSection cs ON gs.SectionID = cs.SectionID
    INNER JOIN Offering o ON cs.OfferingID = o.OfferingID
    INNER JOIN Curriculum cur ON o.CurriculumID = cur.CurriculumID
    INNER JOIN CurriculumHeader ch ON cur.CurriculumHeaderID = ch.CurriculumHeaderID
    WHERE (@SchoolYear IS NULL OR @SchoolYear = 'All' OR cs.SchoolYear = @SchoolYear)
      AND (@CurriculumYear IS NULL OR @CurriculumYear = 'All' OR ch.CurriculumYear = @CurriculumYear);

    -- Denominator: All Offerings defined in the Plan
    SELECT @TotalCount = COUNT(o.OfferingID)
    FROM Offering o
    INNER JOIN Curriculum cur ON o.CurriculumID = cur.CurriculumID
    INNER JOIN CurriculumHeader ch ON cur.CurriculumHeaderID = ch.CurriculumHeaderID
    WHERE (@CurriculumYear IS NULL OR @CurriculumYear = 'All' OR ch.CurriculumYear = @CurriculumYear);

    SELECT ISNULL(@SubmittedCount, 0) AS SubmittedCount, ISNULL(@TotalCount, 0) AS TotalCount;
END
GO

--------------------------------------------------
-- 8.10. Distribution by YEAR & SEMESTER 
--------------------------------------------------
-- 8.10.1. GET PROGRAMS (Filtered by Curriculum Year)
CREATE OR ALTER PROCEDURE sp_GetProgramsByFilter
    @Curriculum VARCHAR(10) = NULL
AS
BEGIN
    SELECT DISTINCT p.ProgramCode AS Label
    FROM Program p
    INNER JOIN CurriculumHeader ch ON p.ProgramID = ch.ProgramID
    WHERE (@Curriculum IS NULL OR @Curriculum = 'All' OR ch.CurriculumYear = @Curriculum)
    ORDER BY p.ProgramCode;
END
GO

-- 8.10.2 GET PROFESSORS (Filtered by Curr + Prog)
CREATE OR ALTER PROCEDURE sp_GetFacultyByFilter
    @Curriculum VARCHAR(10) = NULL,
    @Program    VARCHAR(50) = NULL
AS
BEGIN
    SELECT DISTINCT f.LastName + ', ' + f.FirstName AS Name
    FROM ClassSection cs
    INNER JOIN Faculty f ON cs.FacultyID = f.FacultyID
    INNER JOIN Offering o ON cs.OfferingID = o.OfferingID
    INNER JOIN Curriculum cur ON o.CurriculumID = cur.CurriculumID
    INNER JOIN CurriculumHeader ch ON cur.CurriculumHeaderID = ch.CurriculumHeaderID
    INNER JOIN Program p ON ch.ProgramID = p.ProgramID
    WHERE (@Curriculum IS NULL OR @Curriculum = 'All' OR ch.CurriculumYear = @Curriculum)
      AND (@Program IS NULL OR @Program = 'All' OR p.ProgramCode = @Program)
    ORDER BY Name;
END
GO

-- 8.10.3 GET SUBJECTS (Filtered by Curr + Prog + Prof)
CREATE OR ALTER PROCEDURE sp_GetSubjectsByFilter
    @Curriculum VARCHAR(10) = NULL,
    @Program    VARCHAR(50) = NULL,
    @Faculty    VARCHAR(100) = NULL
AS
BEGIN
    SELECT DISTINCT c.CourseDescription AS SubjectName
    FROM Offering o
    INNER JOIN Course c ON o.CourseID = c.CourseID
    INNER JOIN ClassSection cs ON o.OfferingID = cs.OfferingID
    INNER JOIN Faculty f ON cs.FacultyID = f.FacultyID
    INNER JOIN Curriculum cur ON o.CurriculumID = cur.CurriculumID
    INNER JOIN CurriculumHeader ch ON cur.CurriculumHeaderID = ch.CurriculumHeaderID
    INNER JOIN Program p ON ch.ProgramID = p.ProgramID
    WHERE (@Curriculum IS NULL OR @Curriculum = 'All' OR ch.CurriculumYear = @Curriculum)
      AND (@Program IS NULL OR @Program = 'All' OR p.ProgramCode = @Program)
      AND (@Faculty IS NULL OR @Faculty = 'All' OR (f.LastName + ', ' + f.FirstName) = @Faculty)
    ORDER BY c.CourseDescription;
END
GO

-- 8.10.4. GET SCHOOL YEARS (Filtered by Curriculum, Program, Faculty, and Subject)
CREATE OR ALTER PROCEDURE sp_GetSchoolYearsByFilter
    @Curriculum VARCHAR(10) = NULL,
    @Program    VARCHAR(50) = NULL,
    @Faculty    VARCHAR(100) = NULL,
    @Subject    VARCHAR(100) = NULL
AS
BEGIN
    SELECT DISTINCT cs.SchoolYear
    FROM ClassSection cs
    INNER JOIN Offering o ON cs.OfferingID = o.OfferingID
    INNER JOIN Course c ON o.CourseID = c.CourseID
    INNER JOIN Faculty f ON cs.FacultyID = f.FacultyID
    INNER JOIN Curriculum cur ON o.CurriculumID = cur.CurriculumID
    INNER JOIN CurriculumHeader ch ON cur.CurriculumHeaderID = ch.CurriculumHeaderID
    INNER JOIN Program p ON ch.ProgramID = p.ProgramID
    WHERE 
        (@Curriculum IS NULL OR @Curriculum = 'All' OR ch.CurriculumYear = @Curriculum)
        AND (@Program IS NULL OR @Program = 'All' OR p.ProgramCode = @Program)
        AND (@Faculty IS NULL OR @Faculty = 'All' OR (f.LastName + ', ' + f.FirstName) = @Faculty)
        AND (@Subject IS NULL OR @Subject = 'All' OR c.CourseDescription = @Subject)
    ORDER BY cs.SchoolYear DESC;
END
GO

-- 8.10.5. THE CHART DATA (Final Distribution) - FIXED
CREATE OR ALTER PROCEDURE sp_GetDistributionByYearSem
    @Curriculum VARCHAR(10) = NULL,
    @Program    VARCHAR(50) = NULL,
    @Faculty    VARCHAR(100) = NULL,
    @Subject    VARCHAR(100) = NULL,
    @SchoolYear VARCHAR(20) = NULL
AS
BEGIN
    SELECT 
        cur.Semester,
        COUNT(gs.GradeSheetID) AS Total
    FROM GradeSheet gs
    INNER JOIN ClassSection cs ON gs.SectionID = cs.SectionID
    INNER JOIN Faculty f ON cs.FacultyID = f.FacultyID
    INNER JOIN Offering o ON cs.OfferingID = o.OfferingID
    INNER JOIN Course c ON o.CourseID = c.CourseID
    INNER JOIN Curriculum cur ON o.CurriculumID = cur.CurriculumID
    INNER JOIN CurriculumHeader ch ON cur.CurriculumHeaderID = ch.CurriculumHeaderID
    INNER JOIN Program p ON ch.ProgramID = p.ProgramID
    WHERE 
        (@Curriculum IS NULL OR @Curriculum = 'All' OR ch.CurriculumYear = @Curriculum)
        AND (@Program IS NULL OR @Program = 'All' OR p.ProgramCode = @Program)
        AND (@Faculty IS NULL OR @Faculty = 'All' OR (f.LastName + ', ' + f.FirstName) = @Faculty)
        AND (@Subject IS NULL OR @Subject = 'All' OR c.CourseDescription = @Subject)
        AND (@SchoolYear IS NULL OR @SchoolYear = 'All' OR cs.SchoolYear = @SchoolYear)
    GROUP BY cur.Semester
    ORDER BY cur.Semester ASC;
END;
GO

