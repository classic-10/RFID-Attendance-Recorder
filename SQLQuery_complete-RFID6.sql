SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

	CREATE PROCEDURE [dbo].[SaveRecords]
		@student_id VARCHAR(255),
		@first_name VARCHAR(255),
		@middle_name VARCHAR(255),
		@last_name VARCHAR(255),
		@gender VARCHAR(255),
		@program VARCHAR(255),
		@age VARCHAR(255)
		AS
	BEGIN
		SET NOCOUNT ON;
		INSERT INTO user_records(student_id, first_name, middle_name, last_name, date_created, gender, program, age)
		VALUES(@student_id, @first_name, @middle_name, @last_name, GETDATE(), @gender, @program, @age);

	--EXEC GetAllRecords;

	END;
GO