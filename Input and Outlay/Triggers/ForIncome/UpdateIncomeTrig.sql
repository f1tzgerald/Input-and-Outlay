USE [Doors]
GO
/****** Object:  Trigger [dbo].[UpdateInIncome]    Script Date: 16.02.2016 10:41:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER TRIGGER [dbo].[UpdateInIncome]
ON [dbo].[IncomeMoney]
FOR UPDATE
AS
	/*Змінні таблиці INSERTED*/
	DECLARE @inDatein datetime;

	/*Сума надходжень за день*/
	DECLARE @inDaySumma decimal(19,2);
	/*Сума зранку*/
	DECLARE @yesterdayDaySumma decimal(19,2);
	/*Сума витрат за день*/
	DECLARE @outDaySumma decimal(19,2);

	SELECT @inDatein=i.DateIn FROM INSERTED i;

	/*Сума надходження за день*/	
	IF ((SELECT COUNT(*) FROM IncomeMoney as e WHERE e.DateIn=@inDatein) > 0)
		BEGIN
			SET @inDaySumma = (SELECT SUM(e.Summa) FROM IncomeMoney as e WHERE e.DateIn=@inDatein);
		END
	ELSE
		BEGIN
			SET @inDaySumma = 0;
		END

	/*Сума, яка залишилась вчора ввечері = Сума вранці*/
	SET @yesterdayDaySumma =
		(SELECT e.SummaInTheEvening
		FROM Balance as e
		WHERE e.Date=DATEADD(DAY,-1,@inDatein));
	
	/*Сума витрат за день*/
	IF ((SELECT COUNT(*) FROM OutlayMoney as e WHERE e.DateOut=@inDatein) > 0)
		BEGIN
			SET @outDaySumma = (SELECT SUM(e.Summa) FROM OutlayMoney as e WHERE e.DateOut=@inDatein);
		END
	ELSE
		SET @outDaySumma = 0;
		
	UPDATE Balance
		SET SummaInTheEvening = @yesterdayDaySumma+@inDaySumma-@outDaySumma
		WHERE Balance.Date=@inDatein;
