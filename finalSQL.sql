/*
DROP TABLE IF EXISTS Section
DROP TABLE IF EXISTS Bookmarks;
DROP TABLE IF EXISTS Enrollment;
DROP TABLE IF EXISTS Announcement;
DROP TABLE IF EXISTS LectureNote;
DROP TABLE IF EXISTS Quiz;
DROP TABLE IF EXISTS Assignment;
DROP TABLE IF EXISTS Courses;
DROP TABLE IF EXISTS Users;
*/


CREATE TABLE Users (
    UserID INT PRIMARY KEY IDENTITY,
	uname VARCHAR(255) NOT NULL,
    Email VARCHAR(255) NOT NULL,
    passwordd VARCHAR(255) NOT NULL,
    UserType VARCHAR(255) NOT NULL CHECK (UserType IN ('Instructor', 'Student', 'Administrator'))
);

INSERT INTO Users (uname, Email, passwordd, UserType) VALUES 
('Hamna', 'admin@gmail.com', 'Admin1234', 'Administrator');

INSERT INTO Users (uname, Email, passwordd, UserType) VALUES 
    ('Hamna','hamna@gmail.com', 'Hamna1234', 'Student'),
    ('Zaib','zaib@gmail.com', 'Kissa1234', 'Student'),
    ('Arham','arham@gmail.com', 'Arham1234', 'Student'),
    ('Kalsoom','kalsoom@gmail.com', 'Kalsoom1234', 'Instructor');

CREATE TABLE Courses (
    CourseID INT PRIMARY KEY IDENTITY,
    CourseName VARCHAR(255) NOT NULL,
    InstructorID INT,
    FOREIGN KEY (InstructorID) REFERENCES Users(UserID)
);

CREATE TABLE Enrollment 
(
    EnrollmentID INT PRIMARY KEY IDENTITY,
	Section varchar(255),
    UserID INT,
    CourseID INT,
    FOREIGN KEY (UserID) REFERENCES Users(UserID),
    FOREIGN KEY (CourseID) REFERENCES Courses(CourseID),
);

INSERT INTO Courses (CourseName, InstructorID) VALUES
	('SE', 5),
	('Web Programming', 5),
	('AI', 5),
	('PDC', 5),
	('Numerical', 5),
	('CNet', 5),
	('DIP', 5);



--SELECT DISTINCT E.CourseID, C.CourseName AS [Course Name], U.uname AS [Instructor Name]
--FROM Enrollment AS E
--INNER JOIN Users AS U ON E.UserID = U.UserID AND U.UserType = 'Instructor'
--INNER JOIN Courses AS C ON E.CourseID = C.CourseID
--INNER JOIN Enrollment AS E2 ON E.Section = E2.Section AND E.CourseID = E2.CourseID
--WHERE E2.UserID IN (
--    SELECT UserID
--    FROM Users
--    WHERE UserType = 'Student'
--    AND UserID = 28
--);

--select * from users;
--select * from Enrollment


CREATE TABLE Assignment (
    AssignmentID INT PRIMARY KEY IDENTITY,
	CourseID INT,
	Section VARCHAR(255),
    Deadline VARCHAR(255),
	AssignmentFilePath VARCHAR(255),
    FOREIGN KEY (CourseID) REFERENCES Courses(CourseID)
);


CREATE TABLE Quiz (
    QuizID INT PRIMARY KEY IDENTITY,
	StudentID INT,
	Section VARCHAR(255),
	CourseID INT,
	QuizFilePath VARCHAR(255),
	FOREIGN KEY (StudentID) REFERENCES Users(UserID),
    FOREIGN KEY (CourseID) REFERENCES Courses(CourseID)
);


CREATE TABLE LectureNote (
    LectureNoteID INT PRIMARY KEY IDENTITY,
	Section VARCHAR(255),
	CourseID INT,
	NotesFilePath VARCHAR(255),
    FOREIGN KEY (CourseID) REFERENCES Courses(CourseID)
);



CREATE TABLE Announcement (
    AnnouncementID INT PRIMARY KEY IDENTITY,
	CourseID INT,
	Section VARCHAR(255),
	announcements VARCHAR(255),	--uploaded content
    FOREIGN KEY (CourseID) REFERENCES Courses(CourseID)
);

CREATE TABLE Section (
  SectionID INT PRIMARY KEY IDENTITY,
  SectionName VARCHAR(255) NOT NULL,

);


Insert into Section values
('A'),
('B'),
('C'),
('D'),
('E'),
('F'),
('G'),
('H'),
('Y'),
('Z');



CREATE TABLE StudentNotes (
    NoteID INT PRIMARY KEY IDENTITY,
    UserID INT,
    FilePath NVARCHAR(MAX),
    CONSTRAINT FK_StudentNotes_UserID FOREIGN KEY (UserID) REFERENCES Users(UserID)
);


CREATE TABLE Bookmarks (
    BookmarkID INT PRIMARY KEY IDENTITY,
    UserID INT,
    CourseID INT,
	AssignmentID INT,
	QuizID INT,
	ValueBookmark bit,
	
	LectureNoteID INT,
    FOREIGN KEY (UserID) REFERENCES Users(UserID),
    FOREIGN KEY (CourseID) REFERENCES Courses(CourseID),
    FOREIGN KEY (LectureNoteID) REFERENCES LectureNote(LectureNoteID),
	FOREIGN KEY (AssignmentID) REFERENCES Assignment(AssignmentID),
	Foreign key (QuizID) references Quiz(QuizID)
	
);
