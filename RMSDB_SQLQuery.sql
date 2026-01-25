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
	ProgramDescription VARCHAR(100) NOT NULL
);
GO

CREATE TABLE Course(
	 CourseID INT IDENTITY(1,1) PRIMARY KEY,       
    CourseCode VARCHAR(20) NOT NULL,              
    CourseDescription VARCHAR(100) NOT NULL,     
    CurriculumYear VARCHAR(10) NOT NULL,         

    -- Rule 1: Same CourseCode cannot exist in the same CurriculumYear
    CONSTRAINT UQ_Course_Code_Year UNIQUE (CourseCode, CurriculumYear),

    -- Rule 2: Same CourseDescription cannot exist in the same CurriculumYear
    CONSTRAINT UQ_Course_Desc_Year UNIQUE (CourseDescription, CurriculumYear)
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

CREATE TABLE GradeSheet(
	GradeSheetID INT IDENTITY(1,1) PRIMARY KEY,
	Filename VARCHAR(100) UNIQUE NOT NULL,
    Filepath VARCHAR(200) NOT NULL,
	SchoolYear VARCHAR(20) NOT NULL,
	Semester INT,
    ProgramID INT,
    YearLevel INT,
	CourseID INT,
	FacultyID INT,
    PageNumber INT,
	AccountID INT,
    DateUploaded DATETIME DEFAULT GETDATE(),

    CONSTRAINT FK_ProgramID_GradeSheet FOREIGN KEY (ProgramID) REFERENCES Program(ProgramID),
	CONSTRAINT FK_CourseID_GradeSheet FOREIGN KEY (CourseID) REFERENCES Course(CourseID),
	CONSTRAINT FK_FacultyID_GradeSheet FOREIGN KEY (FacultyID) REFERENCES Faculty(FacultyID),
	CONSTRAINT FK_AccountID_GradeSheet FOREIGN KEY (AccountID) REFERENCES Account(AccountID)
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


-- SAMPLE DATA

-- ACCOUNT
INSERT INTO Account(Username, Password, FirstName, LastName, AccountType) VALUES('admin', '12345678', 'Bong', 'Montante', 'Admin');

-- PROGRAM
INSERT INTO Program(ProgramCode, ProgramDescription) VALUES('BSIT-LQ', 'Bachelor of Science in Information Technology');
INSERT INTO Program(ProgramCode, ProgramDescription) VALUES('DIT-LQ', 'Diploma in Information Technology');
INSERT INTO Program(ProgramCode, ProgramDescription) VALUES('DICT-LQ', 'Diploma in Information Communication Technology');

-- COURSE
INSERT INTO Course(CourseCode, CourseDescription, CurriculumYear) VALUES('ACCO 014', 'Principles of Accounting', '22-23');
INSERT INTO Course(CourseCode, CourseDescription, CurriculumYear) VALUES('COMP 001', 'Introduction to Computing', '22-23');
INSERT INTO Course(CourseCode, CourseDescription, CurriculumYear) VALUES('COMP 002', 'Computer Programming 1', '22-23');
INSERT INTO Course(CourseCode, CourseDescription, CurriculumYear) VALUES('ACCO 20213', 'Principles of Accounting', '18-19');
INSERT INTO Course(CourseCode, CourseDescription, CurriculumYear) VALUES('COMP 20013', 'Introduction to Computing', '18-19');
INSERT INTO Course(CourseCode, CourseDescription, CurriculumYear) VALUES('COMP 20023', 'Computer Programming 1', '18-19');

-- FACULTY
INSERT INTO Faculty(FirstName, MiddleName, LastName, Initials) VALUES('Mark Vence', 'V' , 'Dungca', 'DUNGCAMVV');
INSERT INTO Faculty(FirstName, MiddleName, LastName, Initials) VALUES('Mario', 'S' , 'Enteria', 'ENTERIAMS');
INSERT INTO Faculty(FirstName, MiddleName, LastName, Initials) VALUES('Icon', 'C' , 'Obmerga', 'OBMERGAIC');
INSERT INTO Faculty(FirstName, MiddleName, LastName, Initials) VALUES('Marie Andrea', 'E' , 'Zurbano', 'ZURBANOMAE');
INSERT INTO Faculty(FirstName, MiddleName, LastName, Initials) VALUES('Tito Ernesto', 'Z' , 'Loreto', 'LORETOTEZ');

-- GRADESHEET
INSERT INTO GradeSheet (Filename, Filepath, SchoolYear, Semester, ProgramID, YearLevel, CourseID, FacultyID, PageNumber, AccountID)
VALUES ('BSIT_IT101_S1_Y1.pdf', 'C:/Uploads/2025/', '2025-2026', 1, 1, 1, 1, 1, 1, 1);

-- Example 2: Second page of the same report
INSERT INTO GradeSheet (Filename, Filepath, SchoolYear, Semester, ProgramID, YearLevel, CourseID, FacultyID, PageNumber, AccountID)
VALUES ('BSIT_IT101_S1_Y1_P2.pdf', 'C:/Uploads/2025/', '2025-2026', 1, 1, 1, 1, 1, 2, 1);

SELECT * FROM Account;
SELECT * FROM Program;
SELECT * FROM Course;
SELECT * FROM Faculty;
SELECT * FROM GradeSheet;
SELECT * FROM ActivityLog;


-- STORED PROCEDURES --

GO
-- 1. COURSE STORED PROCEDURES ///
-- 1.1. CREATE COURSE //
CREATE PROCEDURE sp_CreateCourse
    @CourseCode VARCHAR(20),
    @CourseDescription VARCHAR(100),
     @CurriculumYear VARCHAR(10)
AS
BEGIN
       

    BEGIN TRY
        BEGIN TRANSACTION;

            INSERT INTO Course (CourseCode, CourseDescription, CurriculumYear)
            VALUES (@CourseCode, @CourseDescription, @CurriculumYear);
            COMMIT TRANSACTION;

    END TRY
    BEGIN CATCH

        -- Check error number for unique constraint violations
        IF ERROR_NUMBER() IN (2627, 2601)
        BEGIN
            IF ERROR_MESSAGE() LIKE '%UQ_Course_Code_Year%'
                RAISERROR('The Course Code already exists in the same Curriculum Year. Please use a different code.', 16, 1);
            ELSE IF ERROR_MESSAGE() LIKE '%UQ_Course_Desc_Year%'
                RAISERROR('The Course Description already exists in the same Curriculum Year. Please use a different description.', 16, 1);
            ELSE
                RAISERROR('A course with the same details already exists.', 16, 1);
        END
        ELSE
        BEGIN
            -- Other errors
            DECLARE @ErrMsg NVARCHAR(4000) = ERROR_MESSAGE();
            RAISERROR('Database error: %s', 16, 1, @ErrMsg);

        END
    END CATCH

END

GO

-- 1.2. GET ALL COURSE DESCRIPTION //
CREATE PROCEDURE sp_GetAllCourseDescription
AS
BEGIN
    SET NOCOUNT ON;
    WITH TrackedCourses AS (
        SELECT 
            CourseID, 
            CourseCode, 
            CourseDescription, 
            CurriculumYear,
            -- Partition by the duplicate column, order by ID to get the first occurrence
            ROW_NUMBER() OVER (
                PARTITION BY CourseDescription 
                ORDER BY CourseID ASC
            ) AS RowNum
        FROM Course
    )
    SELECT 
        CourseID,
        CourseCode,
        CourseDescription,
        CurriculumYear
    FROM TrackedCourses
    WHERE RowNum = 1; -- Only take the first instance of each description
END



GO

GO

-- 1.3. GET ALL COURSE CODE PER COURSE DESCRIPTION //
CREATE PROCEDURE sp_GetAllCourseCodePerDescription
    @CourseDescription VARCHAR(100)
AS
BEGIN
    SELECT
        CourseID,
        CourseCode,
        CurriculumYear
    FROM
        Course
    WHERE
        CourseDescription = @CourseDescription;
END

GO

-- 1.4. SEARCH COURSE //
CREATE PROCEDURE sp_SearchCourse
    @CurriculumYear VARCHAR(10) = NULL,
    @SearchTerm VARCHAR(100) = NULL,
    @ProgramID INT = NULL -- New Parameter
AS
BEGIN
    -- Prepare the search filter
    DECLARE @Filter VARCHAR(102) = '%' + ISNULL(@SearchTerm, '') + '%';
    SET NOCOUNT ON;
    WITH FilteredAndTracked AS (
        SELECT 
            CourseID, 
            CourseCode, 
            CourseDescription, 
            CurriculumYear,
            ROW_NUMBER() OVER (
                PARTITION BY CourseDescription 
                ORDER BY CourseID ASC
            ) AS RowNum
        FROM Course c
        WHERE 
            (@CurriculumYear IS NULL OR c.CurriculumYear = @CurriculumYear)
            AND (@SearchTerm IS NULL 
                 OR c.CourseCode LIKE @Filter 
                 OR c.CourseDescription LIKE @Filter)
            -- Filter by ProgramID via the GradeSheet table
            AND (@ProgramID IS NULL OR EXISTS (
                SELECT 1 
                FROM GradeSheet gs 
                WHERE gs.CourseID = c.CourseID 
                AND gs.ProgramID = @ProgramID
            ))
    )
    SELECT 
        CourseID, 
        CourseDescription
    FROM 
        FilteredAndTracked
    WHERE 
        RowNum = 1;
END


GO

-- 1.5. UPDATE COURSE //
CREATE PROCEDURE sp_UpdateCourse
    @CourseID INT,
    @CourseCode VARCHAR(20),
    @CourseDescription VARCHAR(100),
    @CurriculumYear VARCHAR(10)
AS

    BEGIN TRY
        UPDATE Course
        SET 
            CourseCode = @CourseCode,
            CourseDescription = @CourseDescription,
            CurriculumYear = @CurriculumYear
        WHERE CourseID = @CourseID;
    END TRY
    BEGIN CATCH
        -- Handle unique constraint violations
        IF ERROR_NUMBER() IN (2627, 2601)
        BEGIN
            IF ERROR_MESSAGE() LIKE '%UQ_Course_Code_Year%'
                RAISERROR('The Course Code already exists in the same Curriculum Year. Please use a different code.', 16, 1);
            ELSE IF ERROR_MESSAGE() LIKE '%UQ_Course_Desc_Year%'
                RAISERROR('The Course Description already exists in the same Curriculum Year. Please use a different description.', 16, 1);
            ELSE
                RAISERROR('A course with the same details already exists.', 16, 1);
        END
        ELSE
        BEGIN
            -- Other errors
            DECLARE @ErrMsg NVARCHAR(4000) = ERROR_MESSAGE();
            RAISERROR('Database error: %s', 16, 1, @ErrMsg);
        END
    END CATCH

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


-- 2. PROGRAM STORED PROCEDURE ///
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
    @SearchTerm VARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @Filter VARCHAR(52) = '%' + @SearchTerm + '%';

    SELECT 
        ProgramID,
        ProgramCode,
        ProgramDescription
    FROM 
        Program
    WHERE 
        ProgramCode LIKE @Filter 
        OR ProgramDescription LIKE @Filter;
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


-- 3. FACULTY STORED PROCEDURE ///
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
    @SearchTerm VARCHAR(50) = NULL,
    @ProgramID INT = NULL -- New Parameter
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
        -- Program Filter Logic
        AND (@ProgramID IS NULL OR EXISTS (
            SELECT 1 
            FROM GradeSheet gs 
            WHERE gs.FacultyID = f.FacultyID 
            AND gs.ProgramID = @ProgramID
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


-- 4. GRADESHEET STORED PROCEDURE ///
-- 4.1. CREATE GRADESHEET //
CREATE PROCEDURE sp_InsertGradeSheet 
    @Filename     VARCHAR(100),
    @Filepath     VARCHAR(200),
    @SchoolYear   VARCHAR(20),
    @Semester     INT,
    @ProgramID    INT,
    @YearLevel    INT,
    @CourseID     INT,
    @FacultyID    INT,
    @PageNumber   INT,
    @AccountID    INT
AS
BEGIN
    SET NOCOUNT ON;

    -- Basic validation
    IF @Filename IS NULL OR @Filename = ''
    BEGIN
        RAISERROR('Filename is required.', 16, 1);
        RETURN;
    END

    -- Insert record
    INSERT INTO GradeSheet
    (
        Filename, Filepath, SchoolYear, Semester, 
        ProgramID, YearLevel, CourseID, FacultyID, 
        PageNumber, AccountID               
    )
    VALUES
    (
        @Filename, @Filepath, @SchoolYear, @Semester, 
        @ProgramID, @YearLevel, @CourseID, @FacultyID, 
        @PageNumber, @AccountID
    );

    -- >>> ADD THIS LINE BELOW <<<
    -- This returns the new ID so Dapper's QuerySingle<int> can read it
    SELECT CAST(SCOPE_IDENTITY() AS INT);
END;

GO

-- 4.2. GET ALL GRADESHEET //
CREATE PROCEDURE sp_GetAllGradeSheets
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        gs.GradeSheetID,
        gs.Filename,
        gs.Filepath,
        gs.SchoolYear,
        gs.Semester,
        p.ProgramCode,
        gs.YearLevel,
        c.CourseCode,
        f.LastName + ', ' + f.FirstName + ' ' + ISNULL(NULLIF(SUBSTRING(f.MiddleName, 1, 1), '') + '.', '') AS FullName,
        a.LastName + ', ' + a.FirstName AS UploadedBy,
        gs.PageNumber
    FROM GradeSheet gs
    INNER JOIN Course c ON gs.CourseID = c.CourseID
    INNER JOIN Faculty f ON gs.FacultyID = f.FacultyID
    INNER JOIN Account a ON gs.AccountID = a.AccountID
    INNER JOIN Program p ON gs.ProgramID = p.ProgramID
    ORDER BY gs.SchoolYear DESC, gs.Semester DESC, gs.PageNumber ASC;
END

GO

-- 4.3. SEARCH GRADESHEET //
CREATE PROCEDURE sp_SearchGradeSheet
    @SchoolYear   VARCHAR(20) = NULL,
    @Semester     INT = NULL,
    @ProgramID    INT = NULL,
    @YearLevel    INT = NULL,
    @CourseID     INT = NULL,
    @FacultyID    INT = NULL
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        gs.GradeSheetID,
        gs.Filename,
        gs.Filepath,
        gs.SchoolYear,
        gs.Semester,
        p.ProgramCode,
        gs.YearLevel,
        c.CourseCode,
        f.LastName + ', ' + f.FirstName + ' ' + ISNULL(NULLIF(SUBSTRING(f.MiddleName, 1, 1), '') + '.', '') AS FullName,
        gs.PageNumber,
        a.LastName + ', ' + a.FirstName AS UploadedBy

    FROM GradeSheet gs
    INNER JOIN Course c ON gs.CourseID = c.CourseID
    INNER JOIN Faculty f ON gs.FacultyID = f.FacultyID
    INNER JOIN Account a ON gs.AccountID = a.AccountID
    INNER JOIN Program p ON gs.ProgramID = p.ProgramID

    WHERE
        (@SchoolYear IS NULL OR gs.SchoolYear = @SchoolYear)
        AND (@Semester IS NULL OR gs.Semester = @Semester)
        AND (@ProgramID IS NULL OR gs.ProgramID = @ProgramID)
        AND (@YearLevel IS NULL OR gs.YearLevel = @YearLevel)
        AND (@CourseID IS NULL OR gs.CourseID = @CourseID)
        AND (@FacultyID IS NULL OR gs.FacultyID = @FacultyID)

    ORDER BY gs.SchoolYear DESC, gs.Semester DESC, gs.PageNumber ASC;
END

GO

-- 4.4. UPDATE GRADESHEET //
CREATE PROCEDURE sp_UpdateGradeSheet
    @GradeSheetID INT,
    @Filename     VARCHAR(100),
    @Filepath     VARCHAR(200),
    @SchoolYear   VARCHAR(20),
    @Semester     INT,
    @ProgramID    INT,
    @YearLevel    INT,
    @CourseID     INT,
    @FacultyID    INT,
    @PageNumber   INT
AS
BEGIN
    SET NOCOUNT ON;

    -- Validate ID
    IF NOT EXISTS (SELECT 1 FROM GradeSheet WHERE GradeSheetID = @GradeSheetID)
    BEGIN
        RAISERROR('Gradesheet record not found.', 16, 1);
        RETURN;
    END

    -- Update record
    UPDATE 
        GradeSheet
    SET
        Filename   = @Filename,
        Filepath   = @Filepath,
        SchoolYear = @SchoolYear,
        Semester   = @Semester,
        ProgramID  = @ProgramID,
        YearLevel  = @YearLevel,
        CourseID   = @CourseID,
        FacultyID  = @FacultyID,
        PageNumber = @PageNumber
    WHERE 
        GradeSheetID = @GradeSheetID;
END

GO

-- 4.5. DELETE GRADESHEET //
CREATE  PROCEDURE sp_DeleteGradeSheet
    @GradeSheetID INT
AS
BEGIN
    SET NOCOUNT ON
               
    IF NOT EXISTS (SELECT 1 FROM GradeSheet WHERE GradeSheetID = @GradeSheetID)
    BEGIN
        RAISERROR('Gradesheet record not found.', 16, 1);
        RETURN;
    END           
    DELETE FROM GradeSheet
    WHERE GradeSheetID = @GradeSheetID;
END

GO


-- 5. ACCOUNT STORED PROCEDURE ///
-- 5.1. CREATE ACCOUNT //
CREATE PROCEDURE sp_CreateAccount
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

-- 5.2. GET ALL ACCOUNT //
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

-- 5.3. SEARCH ACCOUNT //
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

-- 5.4. UPDATE ACCOUNT //
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

-- 5.5. DELETE ACCOUNT //
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

-- 5.6. Login Account //
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


-- 6. ACTIVITY LOG STORED PROCEDURE ///
-- 6.1. CREATE ACTIVITY //
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

-- 6.2. GET ALL ACTIVITY //
CREATE PROCEDURE sp_GetAllActivityLog
AS
BEGIN
    SELECT
        CONCAT_WS(' ', ActivityDescription, ActivityDate) AS Log
    FROM 
        ActivityLog;
END

GO

-- 7. SYSTEM DASHBOARD 4 CARDS STORED PROCEDURE ///
-- 7.1. Count for TOTAL GRADE SHEETS
CREATE PROCEDURE sp_GetGradeSheetCount
AS
BEGIN
    SELECT COUNT(*) FROM GradeSheet;
END

GO

-- 7.2. Count for TOTAL SUBJECTS (Counts the Course table)
CREATE PROCEDURE sp_GetSubjectCount
AS
BEGIN
    SELECT COUNT(*) FROM Course;
END

GO

-- 7.3. Count for TOTAL PROFESSORS (Counts the Faculty table)
CREATE PROCEDURE sp_GetFacultyCount
AS
BEGIN
    SELECT COUNT(*) FROM Faculty;
END

GO

-- 7.4. Distribution by PROGRAM
CREATE PROCEDURE sp_GetDistributionByProgram
AS
BEGIN
    SELECT 
        p.ProgramCode AS Label, 
        COUNT(gs.GradeSheetID) AS Value
    FROM GradeSheet gs
    INNER JOIN Program p ON gs.ProgramID = p.ProgramID
    GROUP BY p.ProgramCode
    ORDER BY Value DESC;
END

GO

-- 7.5. Distribution by PROFESSOR
CREATE PROCEDURE sp_GetDistributionByFaculty
AS
BEGIN
    SELECT 
        f.LastName + ', ' + f.FirstName AS Name,
        COUNT(gs.GradeSheetID) AS RecordCount
    FROM GradeSheet gs
    INNER JOIN Faculty f ON gs.FacultyID = f.FacultyID
    GROUP BY f.LastName, f.FirstName
    ORDER BY RecordCount DESC;
END

GO

-- 7.6. Distribution by SUBJECT
CREATE PROCEDURE sp_GetDistributionBySubject
AS
BEGIN
    SELECT 
        c.CourseDescription AS SubjectName,
        COUNT(gs.GradeSheetID) AS Count
    FROM GradeSheet gs
    INNER JOIN Course c ON gs.CourseID = c.CourseID
    GROUP BY c.CourseDescription
    ORDER BY Count DESC;
END
GO

-- 7.7. Distribution by YEAR & SEMESTER 
CREATE PROCEDURE sp_GetDistributionByYearSem
    @Program     VARCHAR(50) = NULL,
    @Faculty     VARCHAR(100) = NULL,
    @Subject     VARCHAR(100) = NULL,
    @SchoolYear  VARCHAR(20) = NULL
AS
BEGIN
    SELECT 
        gs.SchoolYear,
        gs.Semester,
        COUNT(gs.GradeSheetID) AS Total
    FROM GradeSheet gs
    INNER JOIN Program p ON gs.ProgramID = p.ProgramID
    INNER JOIN Faculty f ON gs.FacultyID = f.FacultyID
    INNER JOIN Course c ON gs.CourseID = c.CourseID
    WHERE 
        (@Program IS NULL OR p.ProgramCode = @Program) 
        AND (@Faculty IS NULL OR (f.LastName + ', ' + f.FirstName) = @Faculty)
        AND (@Subject IS NULL OR c.CourseDescription = @Subject)
        AND (@SchoolYear IS NULL OR gs.SchoolYear = @SchoolYear)
    GROUP BY gs.SchoolYear, gs.Semester
    ORDER BY gs.SchoolYear DESC, gs.Semester ASC;
END

--course filter in dashboard
CREATE PROCEDURE sp_GetSubjectDetailsByName
    @CourseDescription VARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;

    SELECT DISTINCT
        c.CourseCode,
        f.LastName + ', ' + f.FirstName + ISNULL(' ' + LEFT(f.MiddleName, 1) + '.', '') AS FacultyName,
        c.CurriculumYear
    FROM 
        GradeSheet gs
    INNER JOIN 
        Course c ON gs.CourseID = c.CourseID
    INNER JOIN 
        Faculty f ON gs.FacultyID = f.FacultyID
    WHERE 
        c.CourseDescription = @CourseDescription
    ORDER BY 
        c.CurriculumYear DESC, FacultyName ASC;
END
GO

CREATE PROCEDURE sp_GetAllSchoolYears
AS
BEGIN
    SET NOCOUNT ON;
    SELECT DISTINCT SchoolYear 
    FROM GradeSheet 
    ORDER BY SchoolYear DESC;
END
GO

CREATE PROCEDURE sp_GetDistributionByProgram_Filtered
    @SchoolYear VARCHAR(20) = NULL
AS
BEGIN
    SET NOCOUNT ON;

    -- If @SchoolYear is NULL, it gets all data. 
    -- If provided, it filters by that year.
    SELECT 
        p.ProgramCode AS Label, 
        COUNT(gs.GradeSheetID) AS Value
    FROM GradeSheet gs
    INNER JOIN Program p ON gs.ProgramID = p.ProgramID
    WHERE (@SchoolYear IS NULL OR gs.SchoolYear = @SchoolYear)
    GROUP BY p.ProgramCode
    ORDER BY Value DESC;
END
GO

--Filter faculty by school year 
CREATE PROCEDURE sp_GetDistributionByFaculty_Filtered
    @SchoolYear VARCHAR(20) = NULL
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        f.LastName + ', ' + f.FirstName AS Name,
        COUNT(gs.GradeSheetID) AS RecordCount
    FROM 
        GradeSheet gs
    INNER JOIN 
        Faculty f ON gs.FacultyID = f.FacultyID
    WHERE 
        (@SchoolYear IS NULL OR gs.SchoolYear = @SchoolYear)
    GROUP BY 
        f.LastName, f.FirstName
    ORDER BY 
        RecordCount DESC;
END
GO

--GET ACTIVITY LOG ACTION
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

--show recently upload gradesheet in dashboard
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

--count total prof
CREATE OR ALTER PROCEDURE countTotalProgram
AS 
BEGIN
    -- This counts unique ProgramCode values only
    SELECT COUNT(DISTINCT ProgramCode) AS TotalProgram
    FROM Program
END
GO

--coursefilter in dashboard using schoolyear
CREATE OR ALTER PROCEDURE sp_GetDistributionBySubject_FilteredSchoolYears
    @SchoolYear VARCHAR(20) = NULL
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        c.CourseDescription AS SubjectName, 
        COUNT(gs.GradeSheetID) AS Count
    FROM GradeSheet gs
    INNER JOIN Course c ON gs.CourseID = c.CourseID
    WHERE 
        (@SchoolYear IS NULL OR gs.SchoolYear = @SchoolYear)
    GROUP BY c.CourseDescription
    ORDER BY Count DESC;
END
GO




