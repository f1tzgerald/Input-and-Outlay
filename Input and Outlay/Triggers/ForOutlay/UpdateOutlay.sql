USE [Doors]
GO
/****** Object:  Trigger [dbo].[UpdateOutlayTb]    Script Date: 16.02.2016 10:43:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER TRIGGER [dbo].[UpdateOutlayTb]
ON [dbo].[OutlayMoney]
FOR UPDATE
AS
	DECLARE @outDate datetime;

	/*НЕОБХІДНИЙ ПЕРЕРАХУНОК ВСІХ ЗНАЧЕНЬ ТАК ЯК НЕ ВІДОМО ЧИ ЗБІЛЬШИЛАСЬ СУМА ЧИ ЗМЕНШИЛАСЬ*/
	/*Проміжні значення*/
	/*Загальна сума витрат за день*/
	DECLARE @outDaySumma decimal(19,2);
	/*Загальна сума надходжень за день*/
	DECLARE @inDaySumma decimal(19,2);
	/*Сума зранку*/
	DECLARE @yesterdayDaySumma decimal(19,2);

	SELECT @outDate=i.DateOut FROM INSERTED i;

	/*Сума, яка залишилась вчора ввечері = Сума вранці*/
	SET @yesterdayDaySumma =
		(SELECT e.SummaInTheEvening
		FROM [dbo].[Balance] as e
		WHERE e.Date=DATEADD(DAY,-1,@outDate));

	/*Сума надходження за день*/
	SET @inDaySumma =
		(SELECT SUM(e.Summa)
		FROM [dbo].[IncomeMoney] as e 
		WHERE e.DateIn=@outDate);
	
	/*Сума витрат за день*/
	SET @outDaySumma =
		(SELECT SUM(e.Summa)
		FROM [dbo].[OutlayMoney] as e
		WHERE e.DateOut=@outDate);

	UPDATE Balance
		SET SummaInTheEvening = @yesterdayDaySumma+@inDaySumma-@outDaySumma
		WHERE Date=@outDate;
