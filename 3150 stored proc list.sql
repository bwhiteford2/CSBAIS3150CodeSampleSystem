go 
CREATE PROC uspFindStudent 
	@StudentId varchar(10)
	AS
	DECLARE	@Status INT
	SET @Status = 1 -- set to fail initially
	IF @StudentId is null 
	BEGIN 
		RaisError('Error - Parameter is null',16,1)
	END
	ELSE
	BEGIN	
		SELECT StudentId, FirstName, LastName, Email
		FROM Student
		WHERE StudentId = @StudentId

		IF @@ERROR = 0
		BEGIN
			SET @Status = 0
		END
	END
go 

CREATE PROC uspModifyStudent
	@StudentId varchar(10),
	@FirstName varchar(25), 
	@LastName varchar(25),
	@Email varchar(50)
	AS
	DECLARE @Status INT
	SET @Status = 1
	IF  @StudentId is null or @FirstName is null or @LastName is null or @Email is null
	BEGIN
		RaisError('Error - one or more parameters are null', 16,1)
	END
	ELSE
	BEGIN
		UPDATE Student
		SET StudentID = @StudentId, 
			FirstName = @FirstName,
			LastName = @LastName,
			Email = @Email
		WHERE StudentID = @StudentId

		IF @@error = 0
		BEGIN 
			SET @Status = 0
		END
		ELSE
		BEGIN
			RaisError('error - updating Student failed',16,1)
		END
	END

go

create proc uspDeleteStudent 
	@StudentId varchar(10)
	AS
	DECLARE	@Status INT
	SET @Status = 1 -- set to fail initially
	IF @StudentId is null 
	BEGIN 
		RaisError('Error - Parameter is null',16,1)
	END
	ELSE
	BEGIN	
		DELETE FROM Student
		WHERE StudentId = @StudentId

		IF @@ERROR = 0
		BEGIN
			SET @Status = 0
		END
		ELSE
		BEGIN
			RAISERROR('Error - Deleting student unsuccessful',16,1)
		END
	END
GO

CREATE PROC uspAddStudent -- stored proc for enrolling student
	@StudentId varchar(10),
	@FirstName varchar(25), 
	@LastName varchar(25), 
	@Email varchar(50),
	@ProgramCode varChar(50)
	AS
	DECLARE @Status INT
	SET @Status = 1
	IF @StudentId is null 
	BEGIN
		RaisError('Error - parameter cannot be null', 16,1)
	END
	ELSE
	BEGIN
		INSERT INTO Student(StudentId,FirstName, LastName, Email, ProgramCode)
		VALUES (@StudentId, @FirstName,@LastName, @Email,@ProgramCode)
		IF @@error = 0
		BEGIN 
			SET @Status = 0
		END
		ELSE
		BEGIN
			RaisError('error - inserting into Student failed',16,1)
		END
	END

GO
	CREATE PROC uspAddProgram -- stored proc for enrolling student
	@ProgramCode varchar(10),
	@Description varchar(60)
	AS
	DECLARE @Status INT
	SET @Status = 1
	if @ProgramCode is null 
	BEGIN
		RaisError('Error - parameter cannot be null', 16,1)
	END
	ELSE
	BEGIN
		INSERT INTO Program(ProgramCode, Description)
		VALUES (@ProgramCode, @Description)
		IF @@error = 0
		BEGIN 
			SET @Status = 0
		END
		ELSE
		BEGIN
			RaisError('error - inserting into Program failed',16,1)
		END
	END
GO

CREATE PROC uspGetStudentsByProgram
	@ProgramCode as varchar(10)
	as 
	DECLARE @Status int 
	SET @Status = 1
	IF @ProgramCode is null
	BEGIN
		RaisError('Error - Parameter ProgramCode cannot be null', 16,1)
	END
	ELSE
	BEGIN
		SELECT StudentID, FirstName, LastName, Email, ProgramCode 
		FROM Student
		WHERE ProgramCode = @ProgramCode

		IF @@ERROR = 0 
		BEGIN
			SET @Status = 0
		END
		ELSE
		BEGIN
			RaisError('Error - Reading from database',16,1)
		END
		Return @Status
	END
GO
CREATE PROC uspFindProgram
	@ProgramCode varchar(10)
	AS
	DECLARE @Status INT
	SET @Status = 1
	IF @ProgramCode IS NULL
	BEGIN 
		RaisError('Error - Parameter ProgramCode cannot be null',16,1)
	END
	ELSE
	BEGIN
		SELECT ProgramCode, Description
		FROM Program
		WHERE ProgramCode = @ProgramCode

		IF @@ERROR = 0
		BEGIN
			SET @Status = 1
		END
		ELSE
		BEGIN
			RaisError('Error - Issue reading ProgramCode from Database',16,1)
		END
	END



