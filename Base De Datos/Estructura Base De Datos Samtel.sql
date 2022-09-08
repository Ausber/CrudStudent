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
	name VARCHAR(50) not null,
	description VARCHAR(50) NOT NULL,
	isActive BIT DEFAULT(1)
	CONSTRAINT Pk_Subject PRIMARY KEY CLUSTERED (subject_id)
)

GO
CREATE TABLE Note (
	note_id INT IDENTITY(1,1),
	student_id int not null,
	subject_id int NOT NULL,
	note DECIMAL(2,1) NOT NULL
	CONSTRAINT Pk_Note PRIMARY KEY CLUSTERED (note_id),
	CONSTRAINT FK_Student FOREIGN KEY (student_id) REFERENCES Student(student_id),
	CONSTRAINT FK_Subject FOREIGN KEY (subject_id) REFERENCES Subject(subject_id),
)

GO
ALTER PROCEDURE spStudent
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
		IF EXISTS (SELECT 1 FROM Student WHERE dni = @dni)
		BEGIN
			UPDATE Student SET firstName = @firstName,lastName = @lastName,dateOfBirth = @dateOfBirth, genre = @genre, Email = @email,isActive = @isActive  WHERE dni = @dni
		END
		ELSE
		BEGIN
		INSERT INTO Student (dni,firstName,lastName,dateOfBirth,genre,email,isActive)
		VALUES(@dni,@firstName,@lastName,@dateOfBirth,@genre,@email,@isActive)
		END
	END
END
GO
CREATE PROCEDURE spSubject
	@Op VARCHAR(50),
	@name VARCHAR(50)= '',
	@descripcion VARCHAR(50)= '',
	@isActive BIT = 0
AS
BEGIN
	IF(@Op = 'Listar')
	BEGIN
		SELECT * FROM Subject
	END

	IF(@Op = 'Guardar')
	BEGIN
		INSERT INTO Subject (name,description,isActive)
		VALUES(@name,@descripcion,@isActive)
	END
END
GO
CREATE PROCEDURE spNotes
	@Op VARCHAR(50),
	@student_id int= 0,
	@subject_id VARCHAR(50)= '',
	@note DECIMAL(18,2) = 0
AS
BEGIN
	IF(@Op = 'Listar')
	BEGIN
		SELECT Note.note_id,Note.student_id,Subject.subject_id,Subject.name,ISNULL(Note.note,0) Note
		FROM Subject 
		LEFT JOIN Note ON Subject.subject_id = Note.subject_id
		LEFT JOIN Student ON Student.student_id = Note.student_id
		WHERE Student.student_id = @student_id 
	END

	IF(@Op = 'Guardar')
	BEGIN
		IF EXISTS (SELECT 1 FROM Note WHERE subject_id = @subject_id AND student_id = @student_id)
		BEGIN
			UPDATE Note SET note = @note
		END
		ELSE
		BEGIN
			INSERT INTO Note (student_id,subject_id,note)
			VALUES(@student_id,@subject_id,@note)
		END
	END
END

