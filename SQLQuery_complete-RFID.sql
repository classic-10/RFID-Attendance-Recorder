USE [finals_DB]
GO

/****** Object:  StoredProcedure [dbo].[TimeInStudent]    Script Date: 11/8/2025 6:58:14 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[TimeInStudentNow]
		@timein VARCHAR(255), 
		@student_id VARCHAR(255) 
	AS 
	BEGIN  
		INSERT INTO TimeInRecords(time_in, student_id) VALUES (@timein, @student_id); 
	END 

GO


SELECT * FROM  TimeInRecords