USE [local]
GO
/****** Object:  StoredProcedure [dbo].[PRD_MANDATORY_TEST]    Script Date: 11/30/2023 12:01:43 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[PRD_MANDATORY_TEST]
AS
BEGIN	

	DECLARE @Id varchar(max)
	DECLARE @MarketValue varchar(max)
	DECLARE @Category varchar(max)
	DECLARE @CategoryId varchar(max)

	DECLARE financial_cursor CURSOR FOR   
	SELECT ID, MARKETVALUE FROM FINANCIALINSTRUMENT WHERE CATEGORYID IS NULL;  

	OPEN financial_cursor  
	
	FETCH NEXT FROM financial_cursor   
	INTO @Id, @MarketValue

	WHILE @@FETCH_STATUS = 0  
	BEGIN 		

		IF @MarketValue < 1000000.0 
			SET @Category = 'Low Value'
		IF @MarketValue >= 1000000.0 and @MarketValue <= 5000000.0
			SET @Category = 'Medium Value'
		IF @MarketValue > 5000000.0
			SET @Category = 'High Value'		

		SET @CategoryId = newid()

		INSERT INTO Category
           (Id ,Name)
		VALUES
           (@CategoryId, @Category)

		UPDATE FINANCIALINSTRUMENT
		SET CategoryId = @CategoryId
		WHERE Id = @Id

		SELECT NAME FROM Category

		FETCH NEXT FROM financial_cursor   
		INTO @Id, @MarketValue

	END   
	CLOSE financial_cursor;  
	DEALLOCATE financial_cursor; 

END


