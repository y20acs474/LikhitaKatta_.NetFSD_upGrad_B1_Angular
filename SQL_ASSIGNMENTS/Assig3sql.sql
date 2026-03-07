USE ASSIG
CREATE TABLE Departments (
DepartmentID INT PRIMARY KEY,
DepartmentName VARCHAR(100) UNIQUE,
Location VARCHAR(100)
);

CREATE TABLE Teachers (
TeacherID INT PRIMARY KEY,
TeacherName VARCHAR(100),
Email VARCHAR(100) UNIQUE,
DepartmentID INT,
HireDate DATE,
FOREIGN KEY (DepartmentID) REFERENCES Departments(DepartmentID)
);

CREATE TABLE Students (
StudentID INT PRIMARY KEY,
FirstName VARCHAR(50),
LastName VARCHAR(50),
DateOfBirth DATE,
Gender CHAR(1) CHECK (Gender IN ('M','F')),
DepartmentID INT,
AdmissionDate DATE,
FOREIGN KEY (DepartmentID) REFERENCES Departments(DepartmentID)
);

CREATE TABLE Courses (
CourseID INT PRIMARY KEY,
CourseName VARCHAR(100),
Credits INT CHECK (Credits BETWEEN 1 AND 5),
DepartmentID INT,
TeacherID INT,
FOREIGN KEY (DepartmentID) REFERENCES Departments(DepartmentID),
FOREIGN KEY (TeacherID) REFERENCES Teachers(TeacherID)
);

CREATE TABLE Enrollments (
EnrollmentID INT PRIMARY KEY,
StudentID INT,
CourseID INT,
EnrollmentDate DATE DEFAULT GETDATE(),
FOREIGN KEY (StudentID) REFERENCES Students(StudentID),
FOREIGN KEY (CourseID) REFERENCES Courses(CourseID)
);

CREATE TABLE Exams (
ExamID INT PRIMARY KEY,
CourseID INT,
ExamDate DATE,
ExamType VARCHAR(50),
FOREIGN KEY (CourseID) REFERENCES Courses(CourseID)
);

CREATE TABLE Marks (
MarkID INT PRIMARY KEY,
StudentID INT,
ExamID INT,
MarksObtained INT CHECK (MarksObtained BETWEEN 0 AND 100),
FOREIGN KEY (StudentID) REFERENCES Students(StudentID),
FOREIGN KEY (ExamID) REFERENCES Exams(ExamID)
);
-- 1 Add PhoneNumber
ALTER TABLE Students
ADD PhoneNumber VARCHAR(15);

-- 2 Add Salary
ALTER TABLE Teachers
ADD Salary INT;

-- 3 Modify datatype
ALTER TABLE Teachers
ALTER COLUMN Salary DECIMAL(10,2);

-- 4 Add CHECK constraint
ALTER TABLE Teachers
ADD CONSTRAINT chk_salary CHECK (Salary > 20000);

-- 5 Drop PhoneNumber
ALTER TABLE Students
DROP COLUMN PhoneNumber;

-- 6 Rename column
EXEC sp_rename 'Teachers.TeacherName', 'FullName', 'COLUMN';
INSERT INTO Departments VALUES
(1,'Computer Science','Block A'),
(2,'Mechanical','Block B'),
(3,'Electrical','Block C'),
(4,'Civil','Block D'),
(5,'Mathematics','Block E');

INSERT INTO Teachers VALUES
(1,'John','john@gmail.com',1,'2021-05-10',50000),
(2,'Smith','smith@gmail.com',1,'2022-03-12',55000),
(3,'David','david@gmail.com',2,'2020-02-11',60000),
(4,'Robert','robert@gmail.com',3,'2023-01-15',45000),
(5,'James','james@gmail.com',4,'2019-04-21',70000),
(6,'William','will@gmail.com',5,'2022-07-11',48000),
(7,'Joseph','joseph@gmail.com',1,'2021-06-10',52000),
(8,'Thomas','thomas@gmail.com',2,'2023-02-19',46000),
(9,'Charles','charles@gmail.com',3,'2020-09-14',62000),
(10,'Daniel','daniel@gmail.com',4,'2021-11-20',51000);

INSERT INTO Students VALUES
(1,'Arjun','Kumar','2006-05-10','M',1,'2023-06-01'),
(2,'Anita','Reddy','2007-07-12','F',1,'2023-06-01'),
(3,'Aman','Sharma','2005-02-14','M',2,'2023-06-01'),
(4,'Priya','Verma','2006-09-21','F',3,'2023-06-01'),
(5,'Rahul','Naidu','2007-04-11','M',4,'2023-06-01'),
(6,'Sneha','Patel','2006-12-01','F',1,'2023-06-01'),
(7,'Kiran','Rao','2005-03-19','M',2,'2023-06-01'),
(8,'Pooja','Shah','2006-08-18','F',3,'2023-06-01'),
(9,'Vikram','Singh','2005-06-22','M',4,'2023-06-01'),
(10,'Meena','Joshi','2007-10-30','F',5,'2023-06-01');

-- 1
SELECT * FROM Students
WHERE DepartmentID = 1;

-- 2
SELECT * FROM Teachers
WHERE HireDate > '2022-01-01';

-- 3
SELECT * FROM Students
WHERE FirstName LIKE 'A%';

-- 4
SELECT * FROM Courses
WHERE Credits > 3;

-- 5
SELECT * FROM Students
WHERE DateOfBirth BETWEEN '2005-01-01' AND '2008-12-31';

-- 6
SELECT * FROM Students
WHERE DepartmentID <> 2;

-- 7
SELECT * FROM Teachers
WHERE Salary BETWEEN 40000 AND 70000;

-- 8
SELECT * FROM Courses
WHERE TeacherID <> 3;

-- 1
SELECT DepartmentID, COUNT(*) AS TotalStudents
FROM Students
GROUP BY DepartmentID;

-- 2
SELECT ExamID, AVG(MarksObtained) AS AvgMarks
FROM Marks
GROUP BY ExamID;

-- 3
SELECT CourseID, COUNT(StudentID) AS TotalEnrollments
FROM Enrollments
GROUP BY CourseID;

-- 4
SELECT ExamID, MAX(MarksObtained) AS MaxMarks
FROM Marks
GROUP BY ExamID;

-- 5
SELECT e.CourseID, MIN(m.MarksObtained) AS MinMarks
FROM Marks m
JOIN Exams e ON m.ExamID = e.ExamID
GROUP BY e.CourseID;

-- 6
SELECT DepartmentID, COUNT(*) AS StudentCount
FROM Students
GROUP BY DepartmentID
HAVING COUNT(*) > 5;

-- 1
SELECT * FROM Marks
WHERE MarksObtained >
(SELECT AVG(MarksObtained) FROM Marks);

-- 2
SELECT * FROM Courses
WHERE Credits =
(SELECT MAX(Credits) FROM Courses);

-- 3
SELECT StudentID
FROM Enrollments
GROUP BY StudentID
HAVING COUNT(CourseID) > 2;

-- 4
SELECT * FROM Teachers
WHERE DepartmentID =
(SELECT DepartmentID FROM Teachers
WHERE FullName='John');

-- 5
SELECT * FROM Marks
WHERE MarksObtained =
(SELECT MAX(MarksObtained) FROM Marks);

-- 6
SELECT DepartmentID
FROM Students
GROUP BY DepartmentID
HAVING COUNT(*) =
(
SELECT MAX(StudentCount)
FROM
(
SELECT COUNT(*) AS StudentCount
FROM Students
GROUP BY DepartmentID
) AS T
);

-- View 1
CREATE VIEW StudentDepartmentView AS
SELECT s.StudentID,
s.FirstName + ' ' + s.LastName AS StudentName,
d.DepartmentName
FROM Students s
JOIN Departments d
ON s.DepartmentID = d.DepartmentID;

-- View 2
CREATE VIEW StudentCourseView AS
SELECT s.FirstName + ' ' + s.LastName AS StudentName,
c.CourseName,
e.EnrollmentDate
FROM Students s
JOIN Enrollments e ON s.StudentID = e.StudentID
JOIN Courses c ON e.CourseID = c.CourseID;

-- View 3
CREATE VIEW ExamResultView AS
SELECT s.FirstName + ' ' + s.LastName AS StudentName,
c.CourseName,
e.ExamType,
m.MarksObtained
FROM Marks m
JOIN Students s ON m.StudentID = s.StudentID
JOIN Exams e ON m.ExamID = e.ExamID
JOIN Courses c ON e.CourseID = c.CourseID;

-- Query view
SELECT * FROM StudentDepartmentView;

-- Drop view
DROP VIEW StudentDepartmentView;

-- 1
CREATE INDEX idx_student_lastname
ON Students(LastName);

-- 2
CREATE INDEX idx_teacher_email
ON Teachers(Email);

-- 3
CREATE INDEX idx_enrollment_student_course
ON Enrollments(StudentID, CourseID);

-- 4
CREATE UNIQUE INDEX idx_department_name
ON Departments(DepartmentName);

-- 5 Drop index
DROP INDEX idx_student_lastname
ON Students;