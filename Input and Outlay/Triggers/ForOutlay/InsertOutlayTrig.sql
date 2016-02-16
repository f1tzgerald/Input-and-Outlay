USE [Doors]
GO
/****** Object:  Trigger [dbo].[InsertInOutlay]    Script Date: 16.02.2016 10:42:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER TRIGGER [dbo].[InsertInOutlay]
ON [dbo].[OutlayMoney]
AFTER INSERT
AS
	/*Змінні таблиці INSERTED*/
	DECLARE @outDate datetime;
	DECLARE @outSumma decimal(19,2);
	/*Проміжні значення*/
	/*Сума надходження за день*/
	DECLARE @inDaySumma decimal(19,2);
	/*Сума вранці*/
	DECLARE @yesterdayDaySumma decimal(19,2);
	/*Сума витрат за день*/
	DECLARE @outDaySumma decimal(19,2);

	SELECT @outDate=i.DateOut FROM INSERTED i;
	SELECT @outSumma=i.Summa FROM INSERTED i;

	/*Сума надходження за день*/	
	IF ((SELECT COUNT(*) FROM IncomeMoney as e WHERE e.DateIn=@outDate) > 0)
		BEGIN
			SET @inDaySumma = (SELECT SUM(e.Summa) FROM IncomeMoney as e WHERE e.DateIn=@outDate);
		END
	ELSE
		BEGIN
			SET @inDaySumma = 0;
		END

	/*Сума вранці*/
	SET @yesterdayDaySumma =
		(SELECT e.SummaInTheEvening
		FROM [dbo].[Balance] as e
		WHERE e.Date=DATEADD(DAY,-1,@outDate));
	
	/*Сума витрат за день*/
	SET @outDaySumma =
		(SELECT SUM(e.Summa)
		FROM [dbo].[OutlayMoney] as e
		WHERE e.DateOut=@outDate);

	IF EXISTS (SELECT * FROM Balance WHERE Date=@outDate)
	/*Если уже есть запись изменяем ее*/
		BEGIN
			UPDATE Balance
			SET SummaInTheEvening = @yesterdayDaySumma+@inDaySumma-@outDaySumma
			WHERE Date=@outDate;
		END
	ELSE
	/*Если записи не существует добавляем новую*/
		BEGIN
			INSERT INTO [dbo].[Balance] (Date, SummaInTheMorning, SummaInTheEvening)
			VALUES (
			@outDate,
			@yesterdayDaySumma,
			@yesterdayDaySumma-@outSumma
			);
		END
