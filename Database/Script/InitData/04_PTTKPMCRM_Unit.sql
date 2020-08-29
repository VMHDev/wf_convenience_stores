IF EXISTS(SELECT * FROM SYS.DATABASES WHERE NAME = 'PTTKPMCRM')
BEGIN
	USE PTTKPMCRM
END
GO
EXEC sp_msforeachtable "ALTER TABLE ? NOCHECK CONSTRAINT all"
GO
--=========================================================================================================================================================
--=========================================================================================================================================================
-- Đơn vị bán
DECLARE @countRow int
SELECT @countRow = COUNT(ID) FROM [dbo].[CAT_UNIT_SELL]
DELETE FROM CAT_UNIT_SELL
DECLARE @identCur int
SELECT @identCur = IDENT_CURRENT('CAT_UNIT_SELL')
IF(@identCur = 0 AND @countRow = 0)
	DBCC CHECKIDENT('[dbo].[CAT_UNIT_SELL]', RESEED, 0)
ELSE
	DBCC CHECKIDENT('[dbo].[CAT_UNIT_SELL]', RESEED, -1)
GO
INSERT [dbo].[CAT_UNIT_SELL]([UnitSellCode], [UnitSellDesc], [OrderBy], [IsActive], [UpdateDate], [UpdateBy], [IsDelete]) VALUES (N'MON',		N'Món',				0,	1, CAST(N'2017-05-02 00:00:00.000' AS DateTime), 0, 0)
----
INSERT [dbo].[CAT_UNIT_SELL]([UnitSellCode], [UnitSellDesc], [OrderBy], [IsActive], [UpdateDate], [UpdateBy], [IsDelete]) VALUES (N'GRAM',		N'Gram',			1,	1, CAST(N'2017-05-02 00:00:00.000' AS DateTime), 0, 0)
INSERT [dbo].[CAT_UNIT_SELL]([UnitSellCode], [UnitSellDesc], [OrderBy], [IsActive], [UpdateDate], [UpdateBy], [IsDelete]) VALUES (N'KG',		N'Kilogram',		2,	1, CAST(N'2017-05-02 00:00:00.000' AS DateTime), 0, 0)
INSERT [dbo].[CAT_UNIT_SELL]([UnitSellCode], [UnitSellDesc], [OrderBy], [IsActive], [UpdateDate], [UpdateBy], [IsDelete]) VALUES (N'LANG',		N'Lạng',			3,	1, CAST(N'2017-05-02 00:00:00.000' AS DateTime), 0, 0)
INSERT [dbo].[CAT_UNIT_SELL]([UnitSellCode], [UnitSellDesc], [OrderBy], [IsActive], [UpdateDate], [UpdateBy], [IsDelete]) VALUES (N'YEN',		N'Yến',				4,	1, CAST(N'2017-05-02 00:00:00.000' AS DateTime), 0, 0)
----
INSERT [dbo].[CAT_UNIT_SELL]([UnitSellCode], [UnitSellDesc], [OrderBy], [IsActive], [UpdateDate], [UpdateBy], [IsDelete]) VALUES (N'HOP',		N'Hộp',				5,	1, CAST(N'2017-05-02 00:00:00.000' AS DateTime), 0, 0)
INSERT [dbo].[CAT_UNIT_SELL]([UnitSellCode], [UnitSellDesc], [OrderBy], [IsActive], [UpdateDate], [UpdateBy], [IsDelete]) VALUES (N'GOI',		N'Gói/Bịch',		6,	1, CAST(N'2017-05-02 00:00:00.000' AS DateTime), 0, 0)
INSERT [dbo].[CAT_UNIT_SELL]([UnitSellCode], [UnitSellDesc], [OrderBy], [IsActive], [UpdateDate], [UpdateBy], [IsDelete]) VALUES (N'LON',		N'Lon/Chai/LọCan',	7,	1, CAST(N'2017-05-02 00:00:00.000' AS DateTime), 0, 0)
INSERT [dbo].[CAT_UNIT_SELL]([UnitSellCode], [UnitSellDesc], [OrderBy], [IsActive], [UpdateDate], [UpdateBy], [IsDelete]) VALUES (N'DAY',		N'Dây',				8,	1, CAST(N'2017-05-02 00:00:00.000' AS DateTime), 0, 0)
INSERT [dbo].[CAT_UNIT_SELL]([UnitSellCode], [UnitSellDesc], [OrderBy], [IsActive], [UpdateDate], [UpdateBy], [IsDelete]) VALUES (N'MIENG',		N'Miếng/Món',		9,	1, CAST(N'2017-05-02 00:00:00.000' AS DateTime), 0, 0)
INSERT [dbo].[CAT_UNIT_SELL]([UnitSellCode], [UnitSellDesc], [OrderBy], [IsActive], [UpdateDate], [UpdateBy], [IsDelete]) VALUES (N'CAI',		N'Cái/Chiếc/Cục',	10, 1, CAST(N'2017-05-02 00:00:00.000' AS DateTime), 0, 0)
--SELECT * FROM CAT_UNIT_SELL
GO
--=========================================================================================================================================================
--=========================================================================================================================================================
-- Đơn vị nhập
DECLARE @countRow int
SELECT @countRow = COUNT(ID) FROM [dbo].[CAT_UNIT_IN]
DELETE FROM CAT_UNIT_IN
DECLARE @identCur int
SELECT @identCur = IDENT_CURRENT('CAT_UNIT_IN')
IF(@identCur = 0 AND @countRow = 0)
	DBCC CHECKIDENT('[dbo].[CAT_UNIT_IN]', RESEED, 0)
ELSE
	DBCC CHECKIDENT('[dbo].[CAT_UNIT_IN]', RESEED, -1)
GO
INSERT [dbo].[CAT_UNIT_IN]([UnitInCode], [UnitInDesc], [ScaleChange], [OrderBy], [IsActive], [UpdateDate], [UpdateBy], [IsDelete]) VALUES (N'LOC12',		N'Lốc 12',			12,		1,		1, CAST(N'2017-05-02 00:00:00.000' AS DateTime), 0, 0)
INSERT [dbo].[CAT_UNIT_IN]([UnitInCode], [UnitInDesc], [ScaleChange], [OrderBy], [IsActive], [UpdateDate], [UpdateBy], [IsDelete]) VALUES (N'LOC20',		N'Lốc 20',			20,		2,		1, CAST(N'2017-05-02 00:00:00.000' AS DateTime), 0, 0)
INSERT [dbo].[CAT_UNIT_IN]([UnitInCode], [UnitInDesc], [ScaleChange], [OrderBy], [IsActive], [UpdateDate], [UpdateBy], [IsDelete]) VALUES (N'THUNG4',		N'Thùng 4',			4,		3,		1, CAST(N'2017-05-02 00:00:00.000' AS DateTime), 0, 0)
INSERT [dbo].[CAT_UNIT_IN]([UnitInCode], [UnitInDesc], [ScaleChange], [OrderBy], [IsActive], [UpdateDate], [UpdateBy], [IsDelete]) VALUES (N'THUNG10',		N'Thùng 10',		10,		4,		1, CAST(N'2017-05-02 00:00:00.000' AS DateTime), 0, 0)
INSERT [dbo].[CAT_UNIT_IN]([UnitInCode], [UnitInDesc], [ScaleChange], [OrderBy], [IsActive], [UpdateDate], [UpdateBy], [IsDelete]) VALUES (N'THUNG12',		N'Thùng 12',		12,		5,		1, CAST(N'2017-05-02 00:00:00.000' AS DateTime), 0, 0)
INSERT [dbo].[CAT_UNIT_IN]([UnitInCode], [UnitInDesc], [ScaleChange], [OrderBy], [IsActive], [UpdateDate], [UpdateBy], [IsDelete]) VALUES (N'THUNG24',		N'Thùng 24',		24,		6,		1, CAST(N'2017-05-02 00:00:00.000' AS DateTime), 0, 0)
INSERT [dbo].[CAT_UNIT_IN]([UnitInCode], [UnitInDesc], [ScaleChange], [OrderBy], [IsActive], [UpdateDate], [UpdateBy], [IsDelete]) VALUES (N'THUNG30',		N'Thùng 30',		30,		7,		1, CAST(N'2017-05-02 00:00:00.000' AS DateTime), 0, 0)
INSERT [dbo].[CAT_UNIT_IN]([UnitInCode], [UnitInDesc], [ScaleChange], [OrderBy], [IsActive], [UpdateDate], [UpdateBy], [IsDelete]) VALUES (N'HOP10',		N'Hộp 10',			10,		8,		1, CAST(N'2017-05-02 00:00:00.000' AS DateTime), 0, 0)
INSERT [dbo].[CAT_UNIT_IN]([UnitInCode], [UnitInDesc], [ScaleChange], [OrderBy], [IsActive], [UpdateDate], [UpdateBy], [IsDelete]) VALUES (N'HOP50',		N'Hộp 50',			50,		9,		1, CAST(N'2017-05-02 00:00:00.000' AS DateTime), 0, 0)
INSERT [dbo].[CAT_UNIT_IN]([UnitInCode], [UnitInDesc], [ScaleChange], [OrderBy], [IsActive], [UpdateDate], [UpdateBy], [IsDelete]) VALUES (N'HOP100',		N'Hộp 100',			100,	10,		1, CAST(N'2017-05-02 00:00:00.000' AS DateTime), 0, 0)
GO
--=========================================================================================================================================================
--=========================================================================================================================================================
-- Đơn vị cân
DECLARE @countRow int
SELECT @countRow = COUNT(ID) FROM [dbo].[CAT_UNIT_WEIGHT]
DELETE FROM CAT_UNIT_WEIGHT
DECLARE @identCur int
SELECT @identCur = IDENT_CURRENT('CAT_UNIT_WEIGHT')
IF(@identCur = 0 AND @countRow = 0)
	DBCC CHECKIDENT('[dbo].[CAT_UNIT_WEIGHT]', RESEED, 0)
ELSE
	DBCC CHECKIDENT('[dbo].[CAT_UNIT_WEIGHT]', RESEED, -1)
GO
INSERT [dbo].[CAT_UNIT_WEIGHT]([UnitWeightCode], [UnitWeightDesc], [OrderBy], [IsActive], [UpdateDate], [UpdateBy], [IsDelete]) VALUES (N'KG',	 N'Kilogram',	0, 1, CAST(N'2017-05-02 00:00:00.000' AS DateTime), 0, 0)
INSERT [dbo].[CAT_UNIT_WEIGHT]([UnitWeightCode], [UnitWeightDesc], [OrderBy], [IsActive], [UpdateDate], [UpdateBy], [IsDelete]) VALUES (N'LANG', N'Lạng',		1, 1, CAST(N'2017-05-02 00:00:00.000' AS DateTime), 0, 0)
INSERT [dbo].[CAT_UNIT_WEIGHT]([UnitWeightCode], [UnitWeightDesc], [OrderBy], [IsActive], [UpdateDate], [UpdateBy], [IsDelete]) VALUES (N'YEN',  N'Yến',		2, 1, CAST(N'2017-05-02 00:00:00.000' AS DateTime), 0, 0)
--SELECT * FROM CAT_UNIT_WEIGHT
GO
--=========================================================================================================================================================
--=========================================================================================================================================================
EXEC sp_msforeachtable "ALTER TABLE ? WITH CHECK CHECK CONSTRAINT all"
GO	