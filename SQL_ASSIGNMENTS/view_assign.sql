USE  NewPracticeDp;
CREATE TABLE Departments(
DepartmentID INT PRIMARY KEY,
DepartmentName VARCHAR(50)
);

INSERT INTO Departments VALUES
(1,'Computer Science'),
(2,'Information Technology'),
(3,'Electronics');

CREATE TABLE Student;
StudentID INT PRIMARY KEY,
StudentName VARCHAR(50),
Gender VARCHAR(10),
DepartmentID INT,
AdmissionDate DATE,
DateOfBirth DATE
);

INSERT INTO Student VALUES
(1,'Rahul','Male',1,'2023-06-10','2003-02-15'),
(2,'Anjali','Female',1,'2023-06-10','2004-01-12'),
(3,'Kiran','Male',2,'2022-06-15','2002-09-10'),
(4,'Sneha','Female',3,'2023-06-12','2003-07-21'),
(5,'Arjun','Male',1,'2024-01-15','2005-03-11');

CREATE TABLE Courses(
CourseID INT PRIMARY KEY,
CourseName VARCHAR(50),
DepartmentID INT
);

INSERT INTO Courses VALUES
(101,'Database Systems',1),
(102,'Machine Learning',1),
(103,'Operating Systems',2),
(104,'Digital Electronics',3);

CREATE TABLE Enrollments(
EnrollmentID INT PRIMARY KEY,
StudentID INT,
CourseID INT,
EnrollmentDate DATE
);

INSERT INTO Enrollments VALUES
(1,1,101,'2023-07-01'),
(2,2,102,'2023-07-02'),
(3,3,103,'2022-07-10'),
(4,4,104,'2023-07-12'),
(5,5,101,'2024-02-01');

CREATE TABLE Exams(
ExamID INT PRIMARY KEY,
CourseID INT,
ExamType VARCHAR(50)
);

INSERT INTO Exams VALUES
(201,101,'Midterm'),
(202,102,'Midterm'),
(203,103,'Final'),
(204,104,'Final');

CREATE TABLE Marks(
MarkID INT PRIMARY KEY,
StudentID INT,
ExamID INT,
MarksObtained INT
);

INSERT INTO Marks VALUES
(1,1,201,85),
(2,2,202,92),
(3,3,203,70),
(4,4,204,55),
(5,5,201,60);

CREATE VIEW vw_StudentDepartment AS
SELECT 
S.StudentID,
S.StudentName,
D.DepartmentName,
S.AdmissionDate
FROM Student S
JOIN Departments D
ON S.DepartmentID = D.DepartmentID;

CREATE VIEW vw_StudentDepartment AS
SELECT 
S.StudentID,
S.StudentName,
D.DepartmentName,
S.AdmissionDate
FROM Student S
JOIN Departments D
ON S.DepartmentID = D.DepartmentID;
SELECT * FROM vw_StudentDepartment;

SELECT *
FROM vw_StudentDepartment
WHERE DepartmentName = 'Computer Science';

DROP VIEW vw_StudentDepartment;

CREATE VIEW vw_StudentCourses AS
SELECT 
S.StudentID,
S.StudentName,
C.CourseName,
E.EnrollmentDate
FROM Student S
JOIN Enrollments E ON S.StudentID = E.StudentID
JOIN Courses C ON E.CourseID = C.CourseID;

SELECT *
FROM vw_StudentCourses
WHERE StudentID = 5;

SELECT StudentName, COUNT(CourseName) AS TotalCourses
FROM vw_StudentCourses
GROUP BY StudentName;

SELECT *
FROM vw_StudentCourses
WHERE EnrollmentDate > '2024-01-01';.

CREATE VIEW vw_ExamResults AS
SELECT 
S.StudentName,
C.CourseName,
E.ExamType,
M.MarksObtained
FROM Student S
JOIN Marks M ON S.StudentID = M.StudentID
JOIN Exams E ON M.ExamID = E.ExamID
JOIN Courses C ON E.CourseID = C.CourseID;

SELECT *
FROM vw_ExamResults
WHERE MarksObtained > 80;

SELECT MAX(MarksObtained) AS TopScore
FROM vw_ExamResults;

SELECT *
FROM vw_ExamResults
WHERE MarksObtained < 60;

CREATE VIEW vw_DepartmentStudentCount AS
SELECT 
D.DepartmentName,
COUNT(S.StudentID) AS TotalStudents
FROM Departments D
LEFT JOIN Student S
ON D.DepartmentID = S.DepartmentID
GROUP BY D.DepartmentName;
.
SELECT *
FROM vw_DepartmentStudentCount
WHERE TotalStudents > 1;

SELECT *
FROM vw_DepartmentStudentCount
ORDER BY TotalStudents DESC;

CREATE PROCEDURE sp_InsertStudent
@FirstName VARCHAR(50),
@LastName VARCHAR(50),
@Gender VARCHAR(10),
@DepartmentID INT,
@AdmissionDate DATE
AS
BEGIN
INSERT INTO Student(StudentName, Gender, DepartmentID, AdmissionDate)
VALUES(@FirstName + ' ' + @LastName, @Gender, @DepartmentID, @AdmissionDate);
END;



CREATE PROCEDURE sp_GetStudentsByDepartment
@DepartmentID INT
AS
BEGIN
SELECT StudentID, StudentName, AdmissionDate
FROM Student
WHERE DepartmentID = @DepartmentID;
END;

EXEC sp_GetStudentsByDepartment 2;
EXEC sp_GetStudentsByDepartment 3;

CREATE PROCEDURE sp_GetStudentMarks
@StudentID INT
AS
BEGIN
SELECT 
S.StudentName,
C.CourseName,
E.ExamType,
M.MarksObtained
FROM Student S
JOIN Marks M ON S.StudentID = M.StudentID
JOIN Exams E ON M.ExamID = E.ExamID
JOIN Courses C ON E.CourseID = C.CourseID
WHERE S.StudentID = @StudentID;
END;

CREATE FUNCTION fn_GetGrade(@Marks INT)
RETURNS VARCHAR(10)
AS
BEGIN
DECLARE @Grade VARCHAR(10)

IF @Marks >= 90
SET @Grade='A'
ELSE IF @Marks >= 75
SET @Grade='B'
ELSE IF @Marks >= 60
SET @Grade='C'
ELSE
SET @Grade='Fail'

RETURN @Grade
END;


SELECT MarksObtained,
dbo.fn_GetGrade(MarksObtained) AS Grade
FROM Marks;

CREATE FUNCTION fn_GetStudentAge(@DOB DATE)
RETURNS INT
AS
BEGIN
RETURN DATEDIFF(YEAR,@DOB,GETDATE())
END;

CREATE FUNCTION fn_GetStudentAge(@DOB DATE)
RETURNS INT
AS
BEGIN
RETURN DATEDIFF(YEAR,@DOB,GETDATE())
END;

SELECT StudentName,
dbo.fn_GetStudentAge(DateOfBirth) AS Age
FROM Student;

CREATE FUNCTION fn_GetTotalMarks(@StudentID INT)
RETURNS INT
AS
BEGIN
DECLARE @Total INT

SELECT @Total = SUM(MarksObtained)
FROM Marks
WHERE StudentID = @StudentID

RETURN @Total
END;