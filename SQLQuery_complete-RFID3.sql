USE [finals_DB]
GO
/****** Object:  StoredProcedure [dbo].[UpdateRecord]    Script Date: 11/8/2025 6:25:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

	CREATE PROCEDURE [dbo].[UpdateRecord]
		@id INT,
		@student_id VARCHAR(100),
		@program VARCHAR(100),
		@first_name VARCHAR(100),
		@middle_name VARCHAR(100),
		@last_name VARCHAR(100),
		@gender VARCHAR(100),
		@age VARCHAR(100)
	AS
	BEGIN 
		UPDATE user_records 
			SET 
			first_name = @first_name,
			middle_name = @middle_name,
			last_name = @last_name
		WHERE id = @id;
		EXEC GetAllRecords;
	END;
