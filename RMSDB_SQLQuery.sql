CREATE DATABASE RMSDB;
GO
USE RMSDB;
GO

-- 1. Account
CREATE TABLE Account (
    AccountID INT IDENTITY(1,1) PRIMARY KEY,
    Username VARCHAR(50) UNIQUE NOT NULL,
    Password VARCHAR(255) NOT NULL,
    FirstName VARCHAR(50) NOT NULL,
    LastName VARCHAR(50) NOT NULL,
    AccountType VARCHAR(20) NOT NULL
);

-- 2. Program
CREATE TABLE Program (
    ProgramID INT IDENTITY(1,1) PRIMARY KEY,
    ProgramCode VARCHAR(20) UNIQUE NOT NULL,
    ProgramDescription VARCHAR(100) NOT NULL
);

-- 3. Course
CREATE TABLE Course (
    CourseID INT IDENTITY(1,1) PRIMARY KEY,
    CourseCode VARCHAR(20) UNIQUE NOT NULL,
    CourseDescription VARCHAR(100) NOT NULL
);

-- 4. Faculty
CREATE TABLE Faculty (
    FacultyID INT IDENTITY(1,1) PRIMARY KEY,
    FirstName VARCHAR(50) NOT NULL,
    MiddleName VARCHAR(50),
    LastName VARCHAR(50) NOT NULL,
    Suffix VARCHAR(10),
    Initials VARCHAR(20)
);

-- 5. CurriculumHeader
CREATE TABLE CurriculumHeader (
    CurriculumHeaderID INT IDENTITY(1,1) PRIMARY KEY,
    ProgramID INT NOT NULL,
    CurriculumYear VARCHAR(10) NOT NULL,

    CONSTRAINT FK_CH_Program FOREIGN KEY (ProgramID) REFERENCES Program(ProgramID),
    CONSTRAINT UQ_ProgramYear UNIQUE (ProgramID, CurriculumYear)
);

-- 6. Curriculum
CREATE TABLE Curriculum (
    CurriculumID INT IDENTITY(1,1) PRIMARY KEY,
    CurriculumHeaderID INT NOT NULL,
    YearLevel INT NOT NULL,
    Semester INT NOT NULL,

    CONSTRAINT FK_CS_Header FOREIGN KEY (CurriculumHeaderID) REFERENCES CurriculumHeader(CurriculumHeaderID),
    CONSTRAINT UQ_YearSem UNIQUE (CurriculumHeaderID, YearLevel, Semester)
);

-- 7. Offering
CREATE TABLE Offering (
    OfferingID INT IDENTITY(1,1) PRIMARY KEY,
    CurriculumID INT NOT NULL,
    CourseID INT NOT NULL,

    CONSTRAINT FK_Offering_Curriculum FOREIGN KEY (CurriculumID) REFERENCES Curriculum(CurriculumID),
    CONSTRAINT FK_Offering_Course FOREIGN KEY (CourseID) REFERENCES Course(CourseID),
);

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

-- 10. ActivityLog: Audit trail
CREATE TABLE ActivityLog (
    LogID INT IDENTITY(1,1) PRIMARY KEY,
    AccountID INT NOT NULL,
    ActivityDescription VARCHAR(255) NOT NULL,
    ActivityDate DATETIME DEFAULT GETDATE(),

    CONSTRAINT FK_Log_Account FOREIGN KEY (AccountID) REFERENCES Account(AccountID)
);

-- SAMPLE ACCOUNT FOR LOG IN
INSERT INTO Account (Username, Password, FirstName, LastName, AccountType) VALUES ('admin', '12345678', 'John', 'Doe', 'Admin');
GO

SELECT * FROM Account;
SELECT * FROM Program;
SELECT * FROM Course;
SELECT * FROM Faculty;
SELECT * FROM CurriculumHeader;
SELECT * FROM Curriculum;
SELECT * FROM Offering;
SELECT * FROM ClassSection;
SELECT * FROM GradeSheet;
SELECT * FROM ActivityLog;
GO

--==================================================
-- 1. COURSE STORED PROCEDURES                   
--==================================================
-- 1.1. CREATE COURSE //
CREATE PROCEDURE sp_CreateCourse
    @CourseCode VARCHAR(20),
    @CourseDescription VARCHAR(100)
AS
BEGIN
    INSERT INTO Course (CourseCode, CourseDescription)
    VALUES (@CourseCode, @CourseDescription);
END
GO

-- 1.2. GET ALL COURSE DESCRIPTION //
CREATE PROCEDURE sp_GetAllCourseDescription
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
CREATE PROCEDURE sp_UpdateCourse
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
CREATE PROCEDURE sp_CreateProgram
	@ProgramCode VARCHAR(20),
	@ProgramDescription VARCHAR(100)
AS
BEGIN
	INSERT INTO Program (ProgramCode, ProgramDescription)
	VALUES (@ProgramCode, @ProgramDescription);
END
GO

-- 2.2. GET ALL PROGRAM //
CREATE PROCEDURE sp_GetAllProgram
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
CREATE PROCEDURE sp_UpdateProgram
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
CREATE PROCEDURE sp_DeleteProgram
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
CREATE PROCEDURE sp_CreateFaculty
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
CREATE PROCEDURE sp_GetAllFaculty
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
CREATE PROCEDURE sp_SearchFaculty
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
CREATE PROCEDURE sp_UpdateFaculty
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
CREATE PROCEDURE sp_DeleteFaculty
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
CREATE PROCEDURE sp_InsertCurriculumHeader
    @ProgramID INT,    
    @CurriculumYear VARCHAR(10)
AS BEGIN 
	INSERT INTO CurriculumHeader (ProgramID, CurriculumYear)
	VALUES (@ProgramID, @CurriculumYear);
END
GO

-- 4.1.2. GET CURRICULUM HEADER ID
CREATE PROCEDURE sp_SelectCurriculumHeaderID
    @ProgramID INT ,    
    @CurriculumYear VARCHAR(10) 
AS BEGIN
	SELECT CurriculumHeaderID FROM CurriculumHeader 
	WHERE ProgramID = @ProgramID AND
	      CurriculumYear = @CurriculumYear 
END
GO

-- 4.1.3. COUNT CURRICULUM HEADER
CREATE PROCEDURE sp_CountCurriculumHeader
    @ProgramID INT,
    @CurriculumYear VARCHAR(10)
    
AS BEGIN
    SELECT COUNT(*) From CurriculumHeader where CurriculumYear = @CurriculumYear and ProgramID = @ProgramID
END
GO

-- 4.1.4. Get all Curriculum grouped by curriculum year
CREATE PROCEDURE sp_GetAllCurriculum
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
CREATE PROCEDURE sp_InsertCurriculum
    @CurriculumHeaderID INT,
    @YearLevel INT,
    @Semester INT
AS BEGIN
	INSERT INTO Curriculum (CurriculumHeaderID, YearLevel, Semester)
	VALUES (@CurriculumHeaderID, @YearLevel, @Semester)
END
GO

-- 4.2.2. GET CURRICULUM ID
CREATE PROCEDURE sp_SelectCurriculumID
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
CREATE PROCEDURE sp_ViewAllCurriculum
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
CREATE PROCEDURE sp_CountCurriculum
    @CurriculumHeaderID VARCHAR(10),
    @YearLevel INT,
    @Semester INT
AS BEGIN
    SELECT COUNT(*) From Curriculum where CurriculumHeaderID = @CurriculumHeaderID and YearLevel = @YearLevel and Semester = @Semester
END
GO

-- 4.2.5. SEARCH VIEW CURRICULUM
CREATE PROCEDURE sp_SearchViewCurriculum
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
CREATE PROCEDURE sp_InsertCurriculumCourse
    @CurriculumID INT,
    @CourseID INT
   
AS BEGIN
	INSERT INTO Offering (CurriculumID, CourseID)
        VALUES (@CurriculumID, @CourseID)
END
GO

-- 4.3.2. GET OFFERING COURSE
CREATE PROCEDURE sp_SelectCurriculumCourse
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
CREATE PROCEDURE sp_DeleteCurriculumCourse
    @OfferingID INT

AS BEGIN 
    DELETE FROM Offering WHERE OfferingID = @OfferingID 
END
GO

--------------------------------------------------
-- 4.4. CLASS SECTION
--------------------------------------------------
-- 4.4.1. INSERT CLASS SECTION
CREATE PROCEDURE sp_InsertClassSection
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
CREATE PROCEDURE sp_UpdateClassSection
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
CREATE PROCEDURE sp_AddGradeSheet
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
CREATE PROCEDURE sp_GetAllAccount
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
CREATE PROCEDURE sp_SearchAccount
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
CREATE PROCEDURE sp_UpdateAccount
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
CREATE PROCEDURE sp_DeleteAccount
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
CREATE PROCEDURE sp_LoginAccount
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
CREATE PROCEDURE sp_CreateActivityLog
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
CREATE PROCEDURE sp_GetAllActivityLog
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
CREATE PROCEDURE sp_GetGradeSheetCount
AS
BEGIN
    SELECT COUNT(*) FROM GradeSheet;
END
GO

-- 8.2. Count for TOTAL SUBJECTS (Counts the Course table)
CREATE PROCEDURE sp_GetSubjectCount
AS
BEGIN
    SELECT COUNT(*) FROM Course;
END
GO
-- 8.3. Count for TOTAL PROFESSORS (Counts the Faculty table)
CREATE PROCEDURE sp_GetFacultyCount
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

