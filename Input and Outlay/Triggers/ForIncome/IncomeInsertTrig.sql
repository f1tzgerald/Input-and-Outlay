USE [Doors]
GO
/****** Object:  Trigger [dbo].[InsertInIncome]    Script Date: 16.02.2016 10:40:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER TRIGGER [dbo].[InsertInIncome]
ON [dbo].[IncomeMoney]
AFTER INSERT
AS
	/*Змінні таблиці INSERTED*/
	DECLARE @inDatein datetime;
	DECLARE @inSumma decimal(19,2);
	/*Проміжні значення*/
	DECLARE @inDaySumma decimal(19,2);
	DECLARE @yesterdayDaySumma decimal(19,2);
	DECLARE @outDaySumma decimal(19,2);

	SELECT @inDatein=i.DateIn FROM INSERTED i;
	SELECT @inSumma=i.Summa FROM INSERTED i;

	/*Сума надходження за день*/	
	IF ((SELECT COUNT(*) FROM IncomeMoney as e WHERE e.DateIn=@inDatein) > 0)
		BEGIN
			SET @inDaySumma = (SELECT SUM(e.Summa) FROM IncomeMoney as e WHERE e.DateIn=@inDatein);
		END
	ELSE
		BEGIN
			SET @inDaySumma = 0;
		END

	/*Сума вранці*/
	SET @yesterdayDaySumma =
		(SELECT e.SummaInTheEvening
		FROM [dbo].[Balance] as e
		WHERE e.Date=DATEADD(DAY,-1,@inDatein));
	
	/*Сума витрат за день*/
	IF ((SELECT COUNT(*) FROM OutlayMoney as e WHERE e.DateOut=@inDatein) > 0)
		BEGIN
			SET @outDaySumma = (SELECT SUM(e.Summa) FROM OutlayMoney as e WHERE e.DateOut=@inDatein);
		END
	ELSE
		SET @outDaySumma = 0;

	IF EXISTS (SELECT * FROM Balance WHERE Date=@inDatein)
		BEGIN
			UPDATE Balance
			SET SummaInTheEvening = @yesterdayDaySumma+@inDaySumma-@outDaySumma
			WHERE Date=@inDatein;
		END
	ELSE
		BEGIN
			INSERT INTO [dbo].[Balance] (Date, SummaInTheMorning, SummaInTheEvening)
			VALUES (
			@inDatein,
			@yesterdayDaySumma,
			@yesterdayDaySumma+@inSumma
			);
		END
