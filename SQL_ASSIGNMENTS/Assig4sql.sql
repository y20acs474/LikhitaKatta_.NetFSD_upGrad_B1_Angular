use NewPracticeDp;
CREATE TABLE StudentAudit(
AuditID INT IDENTITY(1,1) PRIMARY KEY,
StudentID INT,
ActionType VARCHAR(20),
ActionDate DATETIME
);

CREATE TRIGGER trg_StudentInsertAudit
ON Student
AFTER INSERT
AS
BEGIN
INSERT INTO StudentAudit(StudentID, ActionType, ActionDate)
SELECT StudentID,'INSERT',GETDATE()
FROM inserted;
END;

INSERT INTO Student
VALUES (20,'Teja','female',1,'2024-07-01','2003-05-01');

SELECT * FROM StudentAudit;

CREATE TRIGGER trg_PreventStudentDelete
ON Student
INSTEAD OF DELETE
AS
BEGIN

IF EXISTS(
SELECT *
FROM Enrollments E
JOIN deleted D
ON E.StudentID=D.StudentID
)
BEGIN
RAISERROR('Student has course enrollments and cannot be deleted',16,1);
ROLLBACK TRANSACTION;
END

ELSE
DELETE FROM Student
WHERE StudentID IN (SELECT StudentID FROM deleted);

END;

CREATE TABLE MarksAudit(
AuditID INT IDENTITY(1,1),
StudentID INT,
ExamID INT,
OldMarks INT,
NewMarks INT,
UpdatedDate DATETIME
);

CREATE TRIGGER trg_UpdateMarksAudit
ON Marks
AFTER UPDATE
AS
BEGIN

INSERT INTO MarksAudit(StudentID,ExamID,OldMarks,NewMarks,UpdatedDate)

SELECT 
d.StudentID,
d.ExamID,
d.MarksObtained,
i.MarksObtained,
GETDATE()

FROM deleted d
JOIN inserted i
ON d.MarkID=i.MarkID;

END;

UPDATE Marks
SET MarksObtained=90
WHERE MarkID=1;

SELECT * FROM MarksAudit;
CREATE PROCEDURE sp_AddStudent

@FirstName VARCHAR(50),
@LastName VARCHAR(50),
@DepartmentID INT,
@Gender VARCHAR(10),
@AdmissionDate DATE

AS
BEGIN

BEGIN TRY

INSERT INTO Student(StudentName,Gender,DepartmentID,AdmissionDate)

VALUES(@FirstName+' '+@LastName,@Gender,@DepartmentID,@AdmissionDate);

PRINT 'Student inserted successfully';

END TRY

BEGIN CATCH

PRINT ERROR_MESSAGE();

END CATCH

END;

EXEC sp_AddStudent 'Rahul','Kumar',1,'Male','2024-06-01';

CREATE PROCEDURE sp_InsertMarks

@StudentID INT,
@ExamID INT,
@MarksObtained INT

AS
BEGIN

IF @MarksObtained < 0 OR @MarksObtained > 100
BEGIN
RAISERROR('Invalid Marks',16,1);
RETURN;
END

INSERT INTO Marks(StudentID,ExamID,MarksObtained)
VALUES(@StudentID,@ExamID,@MarksObtained);

END;

EXEC sp_InsertMarks 1,201,85;
EXEC sp_InsertMarks 1,201,150;

CREATE PROCEDURE sp_DeleteStudent
@StudentID INT
AS
BEGIN

BEGIN TRY

DELETE FROM Student
WHERE StudentID=@StudentID;

PRINT 'Student Deleted';

END TRY

BEGIN CATCH

PRINT ERROR_MESSAGE();

END CATCH

END;

CREATE PROCEDURE sp_DisplayStudentsCursor
AS
BEGIN

DECLARE @ID INT
DECLARE @Name VARCHAR(50)

DECLARE StudentCursor CURSOR FOR

SELECT StudentID,StudentName
FROM Student

OPEN StudentCursor

FETCH NEXT FROM StudentCursor INTO @ID,@Name

WHILE @@FETCH_STATUS=0
BEGIN

PRINT 'ID: '+CAST(@ID AS VARCHAR)+' Name: '+@Name

FETCH NEXT FROM StudentCursor INTO @ID,@Name

END

CLOSE StudentCursor
DEALLOCATE StudentCursor

END;

ALTER TABLE Courses
ADD Credits INT DEFAULT 2;

CREATE PROCEDURE sp_EnrollStudentTransaction

@StudentID INT,
@CourseID INT

AS
BEGIN

BEGIN TRY

BEGIN TRANSACTION

INSERT INTO Enrollments(StudentID,CourseID,EnrollmentDate)
VALUES(@StudentID,@CourseID,GETDATE())

COMMIT TRANSACTION

PRINT 'Enrollment Successful'

END TRY

BEGIN CATCH

ROLLBACK TRANSACTION

PRINT ERROR_MESSAGE()

END CATCH

END;

CREATE PROCEDURE sp_RecordExamMarks

@StudentID INT,
@ExamID INT,
@Marks INT

AS
BEGIN

BEGIN TRY

BEGIN TRANSACTION

INSERT INTO Marks(StudentID,ExamID,MarksObtained)
VALUES(@StudentID,@ExamID,@Marks)

UPDATE Exams
SET ExamType=ExamType

WHERE ExamID=@ExamID

COMMIT

END TRY

BEGIN CATCH

ROLLBACK

PRINT ERROR_MESSAGE()

END CATCH

END;

CREATE PROCEDURE sp_TransferStudentDepartment

@StudentID INT,
@NewDepartmentID INT

AS
BEGIN

BEGIN TRY

BEGIN TRANSACTION

IF NOT EXISTS(
SELECT *
FROM Departments
WHERE DepartmentID=@NewDepartmentID
)
BEGIN
RAISERROR('Department does not exist',16,1)
ROLLBACK
RETURN
END

UPDATE Student
SET DepartmentID=@NewDepartmentID
WHERE StudentID=@StudentID

COMMIT

END TRY

BEGIN CATCH

ROLLBACK
PRINT ERROR_MESSAGE()

END CATCH

END;

