USE [Doors]
GO
/****** Object:  Trigger [dbo].[DeleteFromOutlay]    Script Date: 16.02.2016 10:44:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER TRIGGER [dbo].[DeleteFromOutlay]
ON [dbo].[OutlayMoney]
FOR DELETE
AS
	DECLARE @outDate datetime;
	/*Значення витрати*/
	DECLARE @outSumma decimal(19,2);
	/*Існуюче значення в таблиці баланса*/
	DECLARE @outDaySumma decimal(19,2);

	SELECT @outDate=i.DateOut FROM deleted i;
	SELECT @outSumma=i.Summa FROM deleted i;

	SET @outDaySumma = 
		(SELECT e.SummaInTheEvening
		FROM Balance as e
		WHERE e.Date=@outDate);

	/*Додамо значення так, як це таблиця видаляємо з БД значення витрат*/
	UPDATE [Balance]
		SET SummaInTheEvening = @outDaySumma + @outSumma
		WHERE Date = @outDate;