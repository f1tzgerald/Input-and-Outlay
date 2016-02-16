USE [Doors]
GO
/****** Object:  Trigger [dbo].[DeleteFromIncome]    Script Date: 16.02.2016 10:41:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER TRIGGER [dbo].[DeleteFromIncome]
ON [dbo].[IncomeMoney]
FOR DELETE
AS
	/*Змінні таблиці INSERTED*/
	DECLARE @inDatein datetime;
	DECLARE @inSumma decimal(19,2);
	DECLARE @inDaySumma decimal(19,2);

	SELECT @inDatein=i.DateIn FROM deleted i;
	SELECT @inSumma=i.Summa FROM deleted i;

	SET @inDaySumma = 
		(SELECT e.SummaInTheEvening
		FROM Balance as e
		WHERE e.Date=@inDatein);

	UPDATE [Balance]
		SET SummaInTheEvening = @inDaySumma - @inSumma
		WHERE Date = @inDatein;
