USE [finals_DB]
GO
/****** Object:  StoredProcedure [dbo].[GetAllRecords]    Script Date: 11/8/2025 6:13:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAllRecords]
AS 
	BEGIN
	SELECT * FROM user_records
	END;
