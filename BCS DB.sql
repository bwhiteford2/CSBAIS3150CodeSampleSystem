GO
CREATE DATABASE [BCS-db]
--BCS-db
GO 
USE [BCS-db]
CREATE TABLE Program 
(
	ProgramCode 
		varchar(10)
		NOT NULL,
	Description
		varchar(60)
		NOT NULL,
	CONSTRAINT PK_Program_ProgramCode PRIMARY KEY (ProgramCode)
);

CREATE TABLE Student
(
	StudentID
		varchar(10)
		NOT NULL,
	FirstName
		varchar(25)
		NOT NULL,
	LastName
		varchar(25)
		NOT NULL,
	Email
		varchar(50)
		NOT NULL,
	ProgramCode 
		varchar(10)
		NOT NULL,
	CONSTRAINT PK_Student_StudentID PRIMARY KEY (StudentID),
	CONSTRAINT FK_Student_ProgramCode FOREIGN KEY (ProgramCode) 
		REFERENCES Program(ProgramCode)
);
