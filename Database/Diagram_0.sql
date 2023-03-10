/*
   29 января 2023 г.19:17:12
   Пользователь: 
   Сервер: LAPTOP-DJ70UDCI\SQLEXPRESS
   База данных: ShopDB
   Приложение: 
*/

/* Чтобы предотвратить возможность потери данных, необходимо внимательно просмотреть этот скрипт, прежде чем запускать его вне контекста конструктора баз данных.*/
BEGIN TRANSACTION
SET QUOTED_IDENTIFIER ON
SET ARITHABORT ON
SET NUMERIC_ROUNDABORT OFF
SET CONCAT_NULL_YIELDS_NULL ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
COMMIT
BEGIN TRANSACTION
GO
EXECUTE sp_rename N'dbo.Goods.AmountAll', N'Tmp_Amount', 'COLUMN' 
GO
EXECUTE sp_rename N'dbo.Goods.Tmp_Amount', N'Amount', 'COLUMN' 
GO
ALTER TABLE dbo.Goods
	DROP COLUMN AmountAvailable
GO
ALTER TABLE dbo.Goods SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
