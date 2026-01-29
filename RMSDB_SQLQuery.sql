CREATE DATABASE RMSDB;
GO

USE RMSDB;
GO

CREATE TABLE Account(
	AccountID INT IDENTITY(1,1) PRIMARY KEY,
	Username VARCHAR(50) UNIQUE NOT NULL,
	Password VARCHAR(50) NOT NULL,
	FirstName VARCHAR(50) NOT NULL,
	LastName VARCHAR(50) NOT NULL,
	AccountType VARCHAR(20) NOT NULL
);
GO

CREATE TABLE Program(
	ProgramID INT IDENTITY(1,1) PRIMARY KEY,
	ProgramCode VARCHAR(20) NOT NULL,
	ProgramDescription VARCHAR(100) NOT NULL,
);
GO

CREATE TABLE Course(
	CourseID INT IDENTITY(1,1) PRIMARY KEY,
	CourseCode VARCHAR(20) NOT NULL,
	CourseDescription VARCHAR(100) NOT NULL,
);
GO

CREATE TABLE Faculty(
	FacultyID INT IDENTITY(1,1) PRIMARY KEY,
	FirstName VARCHAR(50) NOT NULL,
	MiddleName VARCHAR(20),
	LastName VARCHAR(50) NOT NULL,
	Suffix VARCHAR(10),
	Initials VARCHAR(20)
);
GO

CREATE TABLE Curriculum(
    CurriculumID INT IDENTITY(1, 1) PRIMARY KEY,
    CurriculumYear VARCHAR(10),
    ProgramID INT,
    YearLevel INT,
    Semester INT,

    CONSTRAINT FK_ProgramID_Curriculum FOREIGN KEY (ProgramID) REFERENCES Program(ProgramID)
);
GO

CREATE TABLE CurriculumCourse(
    CurriculumCourseID INT IDENTITY(1, 1) PRIMARY KEY,
    CurriculumID INT,
    CourseID INT,
    FacultyID INT
    
    CONSTRAINT FK_CurriculumID_CurriculumCourse FOREIGN KEY (CurriculumID) REFERENCES Curriculum(CurriculumID),
    CONSTRAINT FK_CourseID_CurriculumCourse FOREIGN KEY (CourseID) REFERENCES Course(CourseID),
    CONSTRAINT FK_Faculty_CurriculumCourse FOREIGN KEY (FacultyID) REFERENCES Faculty(FacultyID),
   
);
GO

CREATE TABLE GradeSheet(
	GradeSheetID INT IDENTITY(1,1) PRIMARY KEY,
	Filename VARCHAR(100) UNIQUE NOT NULL,
    Filepath VARCHAR(200) NOT NULL,
	SchoolYear VARCHAR(20) NOT NULL,
	CurriculumID INT,
    Section INT,
	CourseID INT,
	FacultyID INT,
    PageNumber INT,
	AccountID INT,
    DateUploaded DATETIME DEFAULT GETDATE()

	CONSTRAINT FK_CourseID_GradeSheet FOREIGN KEY (CourseID) REFERENCES Course(CourseID),
	CONSTRAINT FK_FacultyID_GradeSheet FOREIGN KEY (FacultyID) REFERENCES Faculty(FacultyID),
	CONSTRAINT FK_AccountID_GradeSheet FOREIGN KEY (AccountID) REFERENCES Account(AccountID),
	CONSTRAINT FK_CurriculumID_Curriculum FOREIGN KEY (CurriculumID) REFERENCES Curriculum(CurriculumID)
);
GO

CREATE TABLE ActivityLog(
	LogID INT IDENTITY(1,1) PRIMARY KEY,
	AccountID INT,
	ActivityDescription VARCHAR(255) NOT NULL,
	ActivityDate DATETIME,

	CONSTRAINT FK_AccountID_ActivityLog FOREIGN KEY (AccountID) REFERENCES Account(AccountID)
);
GO

-- =================================================
-- Sample Admin Account
-- =================================================
INSERT INTO Account(Username, Password, FirstName, LastName, AccountType) VALUES('admin', '12345678', 'Bong', 'Montante', 'Admin');

-- =================================================
-- =            STORED PROCEDURES LIST             =
-- =================================================

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
CREATE PROCEDURE sp_GetAllCourseCodePerDescription
    @CourseDescription VARCHAR(100)
AS
BEGIN
    SELECT DISTINCT
        c.CourseID,
        c.CourseCode,
        cur.CurriculumYear
    FROM Course c
    LEFT JOIN CurriculumCourse cc
        ON c.CourseID = cc.CourseID
    LEFT JOIN Curriculum cur
        ON cc.CurriculumID = cur.CurriculumID
    WHERE c.CourseDescription = @CourseDescription
    ORDER BY c.CourseCode, cur.CurriculumYear;
END;
GO

-- 1.4. SEARCH COURSE 
CREATE PROCEDURE dbo.sp_SearchCourse
    @SearchTerm VARCHAR(100)       = NULL,
    @CurriculumYear VARCHAR(10)    = NULL,
    @ProgramID INT                 = NULL
AS
BEGIN
    SET NOCOUNT ON;

    -- Normalize search term
    DECLARE @TrimmedSearch VARCHAR(100) = NULL;
    DECLARE @Term VARCHAR(220) = NULL;

    IF @SearchTerm IS NOT NULL
        SET @TrimmedSearch = LTRIM(RTRIM(@SearchTerm));

    IF @TrimmedSearch IS NOT NULL AND @TrimmedSearch <> ''
    BEGIN
        -- Escape wildcard characters so user input is treated literally
        SET @Term = REPLACE(REPLACE(REPLACE(@TrimmedSearch, '[', '[[]'), '%', '[%]'), '_', '[_]');
        SET @Term = '%' + @Term + '%';
    END

    SELECT
        c.CourseDescription
    FROM dbo.Course c
    LEFT JOIN dbo.CurriculumCourse cc
        ON c.CourseID = cc.CourseID
    LEFT JOIN dbo.Curriculum cur
        ON cc.CurriculumID = cur.CurriculumID
    WHERE
        -- Program filter (ignored when @ProgramID IS NULL)
        (@ProgramID IS NULL OR cur.ProgramID = @ProgramID)
        -- CurriculumYear filter (ignored when @CurriculumYear IS NULL)
        AND (@CurriculumYear IS NULL OR cur.CurriculumYear = @CurriculumYear)
        -- Search term filter (ignored when search is NULL/empty)
        AND (
            @TrimmedSearch IS NULL
            OR @TrimmedSearch = ''
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
CREATE PROCEDURE sp_DeleteCourse
    @CourseID INT
AS
BEGIN
    SET NOCOUNT ON;

    -- CANCEL DELETE IF COURSE IS LINKED TO GRADESHEET
    IF EXISTS (SELECT 1 FROM GradeSheet WHERE CourseID = @CourseID)
    BEGIN
        RAISERROR('Cannot delete: This course is linked to existing Grade Sheets.', 16, 1);
        RETURN;
    END

    -- PERFORM DELETE IT NOT LINKED
    DELETE FROM Course WHERE CourseID = @CourseID;
END
GO

-- 1.7 Get all course by program
CREATE PROCEDURE sp_GetCoursesByProgram
    @ProgramID INT = null
AS
BEGIN
    SELECT DISTINCT
        c.CourseID,
        c.CourseCode,
        c.CourseDescription,
        cur.CurriculumID,
        cur.CurriculumYear,
        cur.YearLevel,
        cur.Semester
    FROM CurriculumCourse cc
    INNER JOIN Curriculum cur
        ON cc.CurriculumID = cur.CurriculumID
    INNER JOIN Course c
        ON cc.CourseID = c.CourseID
    WHERE cur.ProgramID = @ProgramID
    ORDER BY c.CourseCode;
END;
GO

-- 1.8. Get all course per Curriculum Year
CREATE PROCEDURE sp_GetCoursesByCurriculumYear
    @CurriculumYear VARCHAR(10) = NULL  -- pass NULL to return courses from all years
AS
BEGIN
    SELECT DISTINCT
        c.CourseID,
        c.CourseCode,
        c.CourseDescription,
        cur.CurriculumID,
        cur.CurriculumYear,
        cur.ProgramID,
        cur.YearLevel,
        cur.Semester
    FROM CurriculumCourse cc
    INNER JOIN Curriculum cur
        ON cc.CurriculumID = cur.CurriculumID
    INNER JOIN Course c
        ON cc.CourseID = c.CourseID
    WHERE (@CurriculumYear IS NULL OR cur.CurriculumYear = @CurriculumYear)
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
CREATE PROCEDURE sp_SearchProgram
    @SearchTerm VARCHAR(100)      = NULL,
    @CurriculumYear VARCHAR(10)   = NULL
AS
BEGIN
    SET NOCOUNT ON;

    -- Normalize and escape search term (treat user input literally)
    DECLARE @TrimmedSearch VARCHAR(100) = NULL;
    DECLARE @Filter VARCHAR(220) = NULL;

    IF @SearchTerm IS NOT NULL
        SET @TrimmedSearch = LTRIM(RTRIM(@SearchTerm));

    IF @TrimmedSearch IS NOT NULL AND @TrimmedSearch <> ''
    BEGIN
        SET @Filter = REPLACE(REPLACE(REPLACE(@TrimmedSearch, '[', '[[]'), '%', '[%]'), '_', '[_]');
        SET @Filter = '%' + @Filter + '%';
    END

    SELECT DISTINCT
        p.ProgramID,
        p.ProgramCode,
        p.ProgramDescription
    FROM Program p
    LEFT JOIN Curriculum cur
        ON cur.ProgramID = p.ProgramID
    WHERE
        -- search term filter (ignored when @SearchTerm is NULL/empty)
        (@Filter IS NULL OR p.ProgramCode LIKE @Filter OR p.ProgramDescription LIKE @Filter)
        -- curriculum year filter (ignored when @CurriculumYear IS NULL)
        AND (@CurriculumYear IS NULL OR cur.CurriculumYear = @CurriculumYear)
    ORDER BY p.ProgramCode;
END;
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
CREATE PROCEDURE sp_GetProgramsByCurriculumYear
    @CurriculumYear VARCHAR(10) = NULL
AS
BEGIN
    SELECT DISTINCT
        p.ProgramID,
        p.ProgramCode,
        p.ProgramDescription
    FROM Program p
    INNER JOIN Curriculum c
        ON p.ProgramID = c.ProgramID
    WHERE (@CurriculumYear IS NULL OR c.CurriculumYear = @CurriculumYear)
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
    IF EXISTS (SELECT 1 FROM GradeSheet WHERE FacultyID = @FacultyID)

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
-- 4.1. CREATE CURRICULUM
CREATE PROCEDURE sp_InsertCurriculum
	@CurriculumYear VARCHAR(10),
    @ProgramID INT,
    @YearLevel INT,
    @Semester INT

AS BEGIN
	INSERT INTO Curriculum (CurriculumYear, ProgramID, YearLevel, Semester)
	VALUES (@CurriculumYear, @ProgramID, @YearLevel, @Semester)
END
GO

-- 4.2. Get all Curriculum grouped by curriculum year
CREATE PROCEDURE sp_GetAllCurriculum
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        CurriculumYear
    FROM Curriculum
    GROUP BY CurriculumYear
    ORDER BY CurriculumYear;
END
GO

-- 4.3. COUNT CURRICULUM
CREATE PROCEDURE sp_CountCurriculum
    @CurriculumYear VARCHAR(10),
    @ProgramID INT,
    @YearLevel INT,
    @Semester INT
AS BEGIN
    SELECT COUNT(*) From Curriculum where CurriculumYear = @CurriculumYear and ProgramID = @ProgramID and YearLevel = @YearLevel and Semester = @Semester
END
GO

-- 4.4. VIEW ALL CURRICULUM
CREATE PROCEDURE sp_ViewAllCurriculum
	@CurriculumYear VARCHAR(10),
    @ProgramID INT

	AS BEGIN
		SELECT Curriculum.CurriculumID, Curriculum.CurriculumYear, Program.ProgramCode, Curriculum.YearLevel, Curriculum.Semester
		FROM Curriculum INNER JOIN Program ON Curriculum.ProgramID = Program.ProgramID
		WHERE Curriculum.CurriculumYear = @CurriculumYear AND Curriculum.ProgramID = @ProgramID
        ORDER BY Curriculum.YearLevel ASC, Curriculum.Semester ASC
	END
GO

-- 4.5. SELECT CURRICULUM 
CREATE PROCEDURE sp_SelectCurriculumID
	@CurriculumYear VARCHAR(10),
    @ProgramID INT,
    @YearLevel INT,
    @Semester INT

	AS BEGIN
		SELECT CurriculumID FROM Curriculum 
		WHERE CurriculumYear = @CurriculumYear AND 
			  ProgramID = @ProgramID AND 
			  YearLevel = @YearLevel AND 
			  Semester = @Semester
	END
GO

-- 4.6. CREATE CURRICULUM COURSE
CREATE PROCEDURE sp_InsertCurriculumCourse
	@CurriculumID INT,
    @CourseID INT,
    @FacultyID INT

	AS BEGIN
		INSERT INTO CurriculumCourse (CurriculumID, CourseID, FacultyID)
        VALUES (@CurriculumID, @CourseID, @FacultyID)
	END
GO

-- 4.7. SELECT CURRICULUM COURSE
CREATE PROCEDURE sp_SelectCurriculumCourse
    @CurriculumID INT

    AS BEGIN
        SELECT CurriculumCourse.CurriculumID, CurriculumCourse.CourseID, CurriculumCourse.FacultyID, Course.CourseCode, 
        CONCAT(Faculty.LastName, ', ', Faculty.FirstName, Faculty.MiddleName) AS [Full Name]
        FROM CurriculumCourse INNER JOIN Course ON CurriculumCourse.CourseID = Course.CourseID
                        INNER JOIN Faculty ON CurriculumCourse.FacultyID = Faculty.FacultyID 
        WHERE CurriculumCourse.CurriculumID = @CurriculumID
    END
GO

-- 4.8. DELETE CURRICULUM COURSE
CREATE PROCEDURE sp_DeleteCurriculumCourse
    @CurriculumID INT,
    @CourseID INT,
    @FacultyID INT

    AS BEGIN 
        DELETE FROM CurriculumCourse WHERE CurriculumID = @CurriculumID AND CourseID = @CourseID AND FacultyID = @FacultyID
    END
GO

--==================================================
-- 5. GRADESHEET STORED PROCEDURE
--==================================================
-- 5.1 CREATE GRADESHEET
CREATE OR ALTER PROCEDURE sp_AddGradeSheet
    @Filename      VARCHAR(100),
    @Filepath      VARCHAR(200),
    @SchoolYear    VARCHAR(20),
    @CurriculumID  INT,
    @Section       INT,
    @CourseID      INT,
    @FacultyID     INT,
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
        SchoolYear,
        CurriculumID,
        Section,
        CourseID,
        FacultyID,
        PageNumber,
        AccountID
    )
    VALUES
    (
        @Filename,
        @Filepath,
        @SchoolYear,
        @CurriculumID,
        @Section,
        @CourseID,
        @FacultyID,
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
        gs.GradeSheetID,           -- newly added
        gs.Filename,
        gs.SchoolYear,

        -- Curriculum year
        c.CurriculumYear AS Curriculum,

        -- Program
        p.ProgramCode AS Program,

        -- Academic info
        c.YearLevel,
        gs.Section,
        c.Semester,

        -- Course
        co.CourseCode AS Course,

        -- Professor (Last, First M.)
        f.LastName + ', ' + f.FirstName +
            ISNULL(
                ' ' + NULLIF(LEFT(f.MiddleName, 1), '') + '.',
                ''
            ) AS Professor,

        -- Page number
        gs.PageNumber

    FROM GradeSheet gs
        INNER JOIN Curriculum c ON gs.CurriculumID = c.CurriculumID
        INNER JOIN Program p ON c.ProgramID = p.ProgramID
        INNER JOIN Course co ON gs.CourseID = co.CourseID
        INNER JOIN Faculty f ON gs.FacultyID = f.FacultyID

    ORDER BY
        gs.SchoolYear DESC,
        c.Semester DESC,
        c.YearLevel ASC,
        gs.Section ASC,
        co.CourseCode ASC,
        gs.PageNumber ASC;
END;
GO

-- 5.4. SEARCH GRADESHEETS
CREATE OR ALTER PROCEDURE sp_SearchGradeSheets
    @SchoolYear VARCHAR(20) = NULL,
    @Semester INT = NULL,
    @ProgramID INT = NULL,
    @CurriculumYear VARCHAR(10) = NULL,  -- filter by string
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
        gs.SchoolYear,
        c.CurriculumYear AS Curriculum,
        p.ProgramCode AS Program,
        c.YearLevel,
        gs.Section,
        c.Semester,
        co.CourseCode AS Course,
        f.LastName + ', ' + f.FirstName +
            ISNULL(' ' + NULLIF(LEFT(f.MiddleName, 1), ''), '') AS Professor,
        gs.PageNumber
    FROM GradeSheet gs
        INNER JOIN Curriculum c ON gs.CurriculumID = c.CurriculumID
        INNER JOIN Program p ON c.ProgramID = p.ProgramID
        INNER JOIN Course co ON gs.CourseID = co.CourseID
        INNER JOIN Faculty f ON gs.FacultyID = f.FacultyID
    WHERE (@SchoolYear IS NULL OR gs.SchoolYear = @SchoolYear)
      AND (@Semester IS NULL OR c.Semester = @Semester)
      AND (@ProgramID IS NULL OR p.ProgramID = @ProgramID)
      AND (@CurriculumYear IS NULL OR c.CurriculumYear = @CurriculumYear)
      AND (@YearLevel IS NULL OR c.YearLevel = @YearLevel)
      AND (@Section IS NULL OR gs.Section = @Section)
      AND (@CourseID IS NULL OR co.CourseID = @CourseID)
      AND (@FacultyID IS NULL OR f.FacultyID = @FacultyID)
    ORDER BY
        gs.SchoolYear DESC,
        c.Semester DESC,
        c.YearLevel ASC,
        gs.Section ASC,
        co.CourseCode ASC,
        gs.PageNumber ASC;
END;
GO

-- 5.5. UPDATE GRADESHEETS
CREATE OR ALTER PROCEDURE sp_UpdateGradeSheets
    @GradeSheetID INT,
    @Filename VARCHAR(255),
    @Filepath VARCHAR(500),
    @SchoolYear VARCHAR(20),
    @Semester INT,
    @ProgramID INT,
    @YearLevel INT,
    @CourseID INT,
    @FacultyID INT,
    @PageNumber INT
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @CurriculumID INT;

    SELECT TOP 1 @CurriculumID = c.CurriculumID
    FROM Curriculum c
    WHERE c.ProgramID = @ProgramID
      AND c.YearLevel = @YearLevel
      AND c.Semester = @Semester
    ORDER BY c.CurriculumYear DESC; 

    IF @CurriculumID IS NULL
    BEGIN
        RAISERROR('No matching Curriculum found.', 16, 1);
        RETURN;
    END

    -- Update GradeSheet
    UPDATE GradeSheet
    SET
        CurriculumID = @CurriculumID,
        CourseID     = @CourseID,
        FacultyID    = @FacultyID,
        SchoolYear   = @SchoolYear,
        PageNumber   = @PageNumber,
        Filename     = @Filename,
        Filepath     = @Filepath
    WHERE GradeSheetID = @GradeSheetID;
END
GO

--==================================================
-- 6. ACCOUNT STORED PROCEDURE 
--==================================================
-- 6.1. CREATE ACCOUNT //
CREATE OR ALTER PROCEDURE sp_CreateAccount
    @Username     VARCHAR(50),
    @Password     VARCHAR(50),
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
CREATE PROCEDURE RecentUploadedGradeSheets
AS BEGIN
    SELECT TOP 10
           g.Filename, 
           c.CourseCode, 
           a.Firstname + ' ' + a.LastName AS UploadedBy
    FROM GradeSheet g
    JOIN Course AS c
        ON g.CourseID = c.CourseID
    JOIN Account AS a  
        ON g.AccountID = a.AccountID
    ORDER BY g.GradeSheetID DESC
END
GO

--------------------------------------------------
-- 8.7. Distribution by PROGRAM
--------------------------------------------------
-- 8.7.1. Get all unique Curriculum Years for the ComboBox
CREATE OR ALTER PROCEDURE sp_GetAllCurriculums
AS
BEGIN
    SET NOCOUNT ON;
    SELECT DISTINCT CurriculumYear 
    FROM Curriculum 
    ORDER BY CurriculumYear DESC;
END
GO

-- 8.7.2. Get School Years filtered by the selected Curriculum
CREATE OR ALTER PROCEDURE sp_GetSchoolYearsByCurriculum
    @CurriculumYear VARCHAR(10) = NULL
AS
BEGIN
    SET NOCOUNT ON;
    SELECT DISTINCT gs.SchoolYear
    FROM GradeSheet gs
    INNER JOIN Curriculum c ON gs.CurriculumID = c.CurriculumID
    WHERE (@CurriculumYear IS NULL OR @CurriculumYear = 'All' OR c.CurriculumYear = @CurriculumYear)
    ORDER BY gs.SchoolYear DESC;
END
Go
-- 8.7.3. Get Chart Data: Joins GradeSheet -> Curriculum -> Program
CREATE OR ALTER PROCEDURE sp_GetDistributionByProgram_Filtered
    @SchoolYear VARCHAR(20) = NULL,
    @CurriculumYear VARCHAR(10) = NULL
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        p.ProgramCode AS Label, 
        COUNT(gs.GradeSheetID) AS Value
    FROM GradeSheet gs
    INNER JOIN Curriculum c ON gs.CurriculumID = c.CurriculumID -- Link to Curriculum
    INNER JOIN Program p ON c.ProgramID = p.ProgramID       -- Link to Program
    WHERE 
        (@SchoolYear IS NULL OR @SchoolYear = 'All' OR gs.SchoolYear = @SchoolYear) -- Filter by School Year
        AND 
        (@CurriculumYear IS NULL OR @CurriculumYear = 'All' OR c.CurriculumYear = @CurriculumYear) -- Filter by Curriculum
    GROUP BY p.ProgramCode
    ORDER BY Value DESC;
END
GO

--8.7.4 Get Year Level Distribution for a specific Program
CREATE OR ALTER PROCEDURE sp_GetYearLevelDistributionByProgram
    @ProgramCode VARCHAR(20),
    @SchoolYear VARCHAR(20) = NULL,
    @CurriculumYear VARCHAR(10) = NULL
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        c.YearLevel,
        COUNT(gs.GradeSheetID) AS Total
    FROM GradeSheet gs
    INNER JOIN Curriculum c ON gs.CurriculumID = c.CurriculumID
    INNER JOIN Program p ON c.ProgramID = p.ProgramID
    WHERE 
        p.ProgramCode = @ProgramCode
        AND (@SchoolYear IS NULL OR @SchoolYear = 'All' OR gs.SchoolYear = @SchoolYear)
        AND (@CurriculumYear IS NULL OR @CurriculumYear = 'All' OR c.CurriculumYear = @CurriculumYear)
    GROUP BY c.YearLevel
    ORDER BY c.YearLevel ASC;
END
GO

-- 8.7.5. Filter Data: Get School Years filtered by Curriculum AND Program
CREATE OR ALTER PROCEDURE sp_GetSchoolYearsByCurriculumAndProgram
    @CurriculumYear VARCHAR(10) = NULL,
    @ProgramCode    VARCHAR(20) = NULL
AS
BEGIN
    SET NOCOUNT ON;
    SELECT DISTINCT gs.SchoolYear
    FROM GradeSheet gs
    INNER JOIN Curriculum c ON gs.CurriculumID = c.CurriculumID
    INNER JOIN Program p ON c.ProgramID = p.ProgramID
    WHERE 
        (@CurriculumYear IS NULL OR @CurriculumYear = 'All' OR c.CurriculumYear = @CurriculumYear)
        AND
        (@ProgramCode IS NULL OR @ProgramCode = 'All' OR p.ProgramCode = @ProgramCode)
    ORDER BY gs.SchoolYear DESC;
END
GO

--------------------------------------------------
-- 8.8. Distribution by PROFESSOR
--------------------------------------------------
-- 8.8.1. 
CREATE OR ALTER PROCEDURE sp_GetDistributionByFaculty_Filtered
    @SchoolYear VARCHAR(20) = NULL,
    @CurriculumYear VARCHAR(10) = NULL
AS
BEGIN
    SET NOCOUNT ON;

SELECT
        f.LastName + ', ' + f.FirstName AS Name,
        COUNT(gs.GradeSheetID) AS RecordCount
    FROM GradeSheet gs
    INNER JOIN Faculty f ON gs.FacultyID = f.FacultyID
    -- We use LEFT JOIN here in case a gradesheet wasn't tagged with a curriculum (optional safety)
    LEFT JOIN Curriculum c ON gs.CurriculumID = c.CurriculumID 
    WHERE 
        (@SchoolYear IS NULL OR @SchoolYear = 'All' OR gs.SchoolYear = @SchoolYear)
        AND
        (@CurriculumYear IS NULL OR @CurriculumYear = 'All' OR c.CurriculumYear = @CurriculumYear)
    GROUP BY f.LastName, f.FirstName
    ORDER BY RecordCount DESC;
END
GO

-- 8.8.2. Stored Procedure that fetches the specific files based on the Professor's name and the active filters
CREATE OR ALTER PROCEDURE sp_GetGradeSheetsByFacultyDetails
    @FacultyName VARCHAR(100), -- Matches the format "LastName, FirstName"
    @SchoolYear VARCHAR(20) = NULL,
    @CurriculumYear VARCHAR(10) = NULL
AS
BEGIN
    SET NOCOUNT ON;

SELECT
        gs.Filename AS[File Name],
        c.CourseCode AS [Course Code],
        gs.DateUploaded AS[Date Uploaded]
    FROM GradeSheet gs
    INNER JOIN Faculty f ON gs.FacultyID = f.FacultyID
    INNER JOIN Course c ON gs.CourseID = c.CourseID
    LEFT JOIN Curriculum curr ON gs.CurriculumID = curr.CurriculumID
    WHERE   
        (f.LastName + ', ' + f.FirstName) = @FacultyName
        AND
        (@SchoolYear IS NULL OR @SchoolYear = 'All' OR gs.SchoolYear = @SchoolYear)
        AND
        (@CurriculumYear IS NULL OR @CurriculumYear = 'All' OR curr.CurriculumYear = @CurriculumYear)
    ORDER BY 
        gs.DateUploaded DESC;
END
GO
--------------------------------------------------
-- 8.9. Distribution by SUBJECT
--------------------------------------------------
-- 8.9.1. 
CREATE OR ALTER PROCEDURE sp_GetSemestersByFilters
    @CurriculumYear VARCHAR(10) = NULL,
    @SchoolYear VARCHAR(20) = NULL
AS
BEGIN
    SET NOCOUNT ON;

    SELECT DISTINCT c.Semester  -- Changed from gs.Semester to c.Semester
    FROM GradeSheet gs
    INNER JOIN Curriculum c ON gs.CurriculumID = c.CurriculumID
    WHERE 
        (@CurriculumYear IS NULL OR @CurriculumYear = 'All' OR c.CurriculumYear = @CurriculumYear)
        AND
        (@SchoolYear IS NULL OR @SchoolYear = 'All' OR gs.SchoolYear = @SchoolYear)
    ORDER BY c.Semester ASC;
END
GO

-- 8.9.2. GET SUBJECT DISTRIBUTION (Filtered by Curr, Year, Sem)
CREATE OR ALTER PROCEDURE sp_GetDistributionBySubject_FilteredFull
    @CurriculumYear VARCHAR(10) = NULL,
    @SchoolYear VARCHAR(20) = NULL,
    @Semester INT = NULL
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        c.CourseDescription AS SubjectName,
        COUNT(gs.GradeSheetID) AS Count
    FROM GradeSheet gs
    INNER JOIN Course c ON gs.CourseID = c.CourseID
    INNER JOIN Curriculum cur ON gs.CurriculumID = cur.CurriculumID
    WHERE 
        (@CurriculumYear IS NULL OR @CurriculumYear = 'All' OR cur.CurriculumYear = @CurriculumYear)
        AND
        (@SchoolYear IS NULL OR @SchoolYear = 'All' OR gs.SchoolYear = @SchoolYear)
        AND
        (@Semester IS NULL OR cur.Semester = @Semester)
    GROUP BY c.CourseDescription
    ORDER BY Count DESC;
END
GO
-- 8.9.3. Get Subject Details
CREATE PROCEDURE sp_GetSubjectDetailsByName
    @CourseDescription VARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;

    SELECT DISTINCT
        c.CourseCode,
        -- Formatted Faculty Name
        f.LastName + ', ' + f.FirstName + ISNULL(' ' + LEFT(f.MiddleName, 1) + '.', '') AS FacultyName,
        -- Pulled from the Curriculum table as per your schema
        curr.CurriculumYear
    FROM 
        GradeSheet gs
    INNER JOIN 
        Course c ON gs.CourseID = c.CourseID
    INNER JOIN 
        Faculty f ON gs.FacultyID = f.FacultyID
    INNER JOIN 
        Curriculum curr ON gs.CurriculumID = curr.CurriculumID
    WHERE 
        c.CourseDescription = @CourseDescription
    ORDER BY 
        curr.CurriculumYear DESC, FacultyName ASC;
END
GO

--------------------------------------------------
-- 8.10. Distribution by YEAR & SEMESTER 
--------------------------------------------------
-- 8.10.1. GET PROGRAMS (Filtered by Curriculum)
CREATE OR ALTER PROCEDURE sp_GetProgramsByFilter
    @Curriculum VARCHAR(10) = NULL
AS
BEGIN
    SELECT DISTINCT p.ProgramCode AS Label
    FROM GradeSheet gs
    INNER JOIN Curriculum cur ON gs.CurriculumID = cur.CurriculumID
    INNER JOIN Program p ON cur.ProgramID = p.ProgramID
    WHERE (@Curriculum IS NULL OR @Curriculum = 'All' OR cur.CurriculumYear = @Curriculum)
    ORDER BY p.ProgramCode;
END
GO


-- 8.10.2. GET PROFESSORS (Filtered by Curr + Prog)
CREATE OR ALTER PROCEDURE sp_GetFacultyByFilter
    @Curriculum VARCHAR(10) = NULL,
    @Program    VARCHAR(50) = NULL
AS
BEGIN
    SELECT DISTINCT f.LastName + ', ' + f.FirstName AS Name
    FROM GradeSheet gs
    INNER JOIN Curriculum cur ON gs.CurriculumID = cur.CurriculumID
    INNER JOIN Program p ON cur.ProgramID = p.ProgramID
    INNER JOIN Faculty f ON gs.FacultyID = f.FacultyID
    WHERE 
        (@Curriculum IS NULL OR @Curriculum = 'All' OR cur.CurriculumYear = @Curriculum)
        AND (@Program IS NULL OR @Program = 'All' OR p.ProgramCode = @Program)
    ORDER BY Name;
END
GO

-- 8.10.3. GET SUBJECTS (Filtered by Curr + Prog + Prof)
CREATE OR ALTER PROCEDURE sp_GetSubjectsByFilter
    @Curriculum VARCHAR(10) = NULL,
    @Program    VARCHAR(50) = NULL,
    @Faculty    VARCHAR(100) = NULL
AS
BEGIN
    SELECT DISTINCT c.CourseDescription AS SubjectName
    FROM GradeSheet gs
    INNER JOIN Curriculum cur ON gs.CurriculumID = cur.CurriculumID
    INNER JOIN Program p ON cur.ProgramID = p.ProgramID
    INNER JOIN Faculty f ON gs.FacultyID = f.FacultyID
    INNER JOIN Course c ON gs.CourseID = c.CourseID
    WHERE 
        (@Curriculum IS NULL OR @Curriculum = 'All' OR cur.CurriculumYear = @Curriculum)
        AND (@Program IS NULL OR @Program = 'All' OR p.ProgramCode = @Program)
        AND (@Faculty IS NULL OR @Faculty = 'All' OR (f.LastName + ', ' + f.FirstName) = @Faculty)
    ORDER BY c.CourseDescription;
END
GO

-- 8.10.4. GET SCHOOL YEARS (Filtered by All Previous)
CREATE OR ALTER PROCEDURE sp_GetSchoolYearsByFilter
    @Curriculum VARCHAR(10) = NULL,
    @Program    VARCHAR(50) = NULL,
    @Faculty    VARCHAR(100) = NULL,
    @Subject    VARCHAR(100) = NULL
AS
BEGIN
    SELECT DISTINCT gs.SchoolYear
    FROM GradeSheet gs
    INNER JOIN Curriculum cur ON gs.CurriculumID = cur.CurriculumID
    INNER JOIN Program p ON cur.ProgramID = p.ProgramID
    INNER JOIN Faculty f ON gs.FacultyID = f.FacultyID
    INNER JOIN Course c ON gs.CourseID = c.CourseID
    WHERE 
        (@Curriculum IS NULL OR @Curriculum = 'All' OR cur.CurriculumYear = @Curriculum)
        AND (@Program IS NULL OR @Program = 'All' OR p.ProgramCode = @Program)
        AND (@Faculty IS NULL OR @Faculty = 'All' OR (f.LastName + ', ' + f.FirstName) = @Faculty)
        AND (@Subject IS NULL OR @Subject = 'All' OR c.CourseDescription = @Subject)
    ORDER BY gs.SchoolYear DESC;
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
    SET NOCOUNT ON;

    SELECT 
        cur.Semester, -- FIXED: Semester comes from the Curriculum table, not GradeSheet
        COUNT(gs.GradeSheetID) AS Total
    FROM GradeSheet gs
    INNER JOIN Curriculum cur ON gs.CurriculumID = cur.CurriculumID
    INNER JOIN Program p ON cur.ProgramID = p.ProgramID
    INNER JOIN Faculty f ON gs.FacultyID = f.FacultyID
    INNER JOIN Course c ON gs.CourseID = c.CourseID
    WHERE 
        (@Curriculum IS NULL OR @Curriculum = 'All' OR cur.CurriculumYear = @Curriculum)
        AND (@Program IS NULL OR @Program = 'All' OR p.ProgramCode = @Program)
        AND (@Faculty IS NULL OR @Faculty = 'All' OR (f.LastName + ', ' + f.FirstName) = @Faculty)
        AND (@Subject IS NULL OR @Subject = 'All' OR c.CourseDescription = @Subject)
        AND (@SchoolYear IS NULL OR @SchoolYear = 'All' OR gs.SchoolYear = @SchoolYear)
    GROUP BY 
        cur.Semester -- FIXED
    ORDER BY 
        cur.Semester ASC; -- FIXED
END
GO


--==================================================
-- 9. REPORT STORED PROCEDURES
--==================================================
-- 9.1 GET ALL EXISTING AND NOT EXISTING GRADESHEETS
SELECT 
    CASE 
        WHEN gs.GradeSheetID IS NOT NULL THEN 'Grade Sheet Submitted'
        ELSE 'No Grade Sheet'
    END AS Remarks,
    gs.SchoolYear,
    co.CourseCode,
    f.FirstName + ' ' + f.LastName AS Faculty,
    p.ProgramCode,
    c.YearLevel AS [Year Level]
FROM CurriculumCourse cc
INNER JOIN Curriculum c ON cc.CurriculumID = c.CurriculumID
INNER JOIN Program p ON c.ProgramID = p.ProgramID
INNER JOIN Course co ON cc.CourseID = co.CourseID
INNER JOIN Faculty f ON cc.FacultyID = f.FacultyID
LEFT JOIN GradeSheet gs ON gs.CourseID = cc.CourseID
    AND gs.FacultyID = cc.FacultyID
    AND gs.CurriculumID = cc.CurriculumID
ORDER BY c.CurriculumYear, p.ProgramCode, c.YearLevel, c.Semester;
