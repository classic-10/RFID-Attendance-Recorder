GO
CREATE PROCEDURE [dbo].[TimeInRecord]
		@id INT
	AS 
	BEGIN  
		SELECT * FROM user_records WHERE student_id = @id;  


	END 

GO 

EXEC TimeInRecord '02000348565'   

GO
ALTER PROCEDURE [dbo].[TimeInStudent]
		@timein VARCHAR(255),
		@student_id VARCHAR(255)
	AS 
	BEGIN  
		INSERT INTO TimeIn(TimeIn, student_id) VALUES (@timein, @student_id); 
	END 

GO  

EXEC TimeInStudent'6:52PM' 

SELECT * FROM TimeIn
