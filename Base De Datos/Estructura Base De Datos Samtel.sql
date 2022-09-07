USE master
GO
CREATE DATABASE StudentsNotes

USE StudentsNotes
GO
CREATE TABLE Student (
	student_id INT IDENTITY(1,1),
	dni bigint not null,
	firstName VARCHAR(50) NOT NULL,
	lastName VARCHAR(50) NOT NULL,
	dateOfBirth DATE NOT NULL,
	genre CHAR(1),
	email VARCHAR(50) NOT NULL,
	isActive BIT DEFAULT(1)
	CONSTRAINT Pk_Student PRIMARY KEY CLUSTERED (student_id)
)
GO
CREATE TABLE Subject (
	subject_id INT IDENTITY(1,1),
	name bigint not null,
	description VARCHAR(50) NOT NULL,
	isActive BIT DEFAULT(1)
	CONSTRAINT Pk_Subject PRIMARY KEY CLUSTERED (subject_id)
)

GO
CREATE TABLE Note (
	note_id INT IDENTITY(1,1),
	student_id int not null,
	subject_id int NOT NULL,
	note DECIMAL(2,1) DEFAULT(1)
	CONSTRAINT Pk_Note PRIMARY KEY CLUSTERED (note_id),
	CONSTRAINT FK_Student FOREIGN KEY (student_id) REFERENCES Student(student_id),
	CONSTRAINT FK_Subject FOREIGN KEY (subject_id) REFERENCES Subject(subject_id),
)

GO
CREATE PROCEDURE spStudent
	@Op VARCHAR(50),
	@dni BIGINT = 0,
	@firstName VARCHAR(50) = '',
	@lastName  VARCHAR(50) = '',
	@dateOfBirth DATE = null,
	@genre CHAR(1) = 'M',
	@email  VARCHAR(50) = '',
	@isActive BIT = 0
AS
BEGIN
	IF(@Op = 'Listar')
	BEGIN
		SELECT * FROM Student
	END

	IF(@Op = 'Guardar')
	BEGIN
		INSERT INTO Student (dni,firstName,lastName,dateOfBirth,genre,email,isActive)
		VALUES(@dni,@firstName,@lastName,@dateOfBirth,@genre,@email,@isActive)

	END
END