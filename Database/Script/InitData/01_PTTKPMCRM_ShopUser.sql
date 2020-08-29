IF EXISTS(SELECT * FROM SYS.DATABASES WHERE NAME = 'PTTKPMCRM')
BEGIN
	USE PTTKPMCRM
END
GO
EXEC sp_msforeachtable "ALTER TABLE ? NOCHECK CONSTRAINT all"
GO
--=========================================================================================================================================================
--=========================================================================================================================================================
-- Cửa hàng
DECLARE @countRow int
SELECT @countRow = COUNT(ID) FROM [dbo].[CAT_SHOP]
DELETE FROM CAT_SHOP
DECLARE @identCur int
SELECT @identCur = IDENT_CURRENT('CAT_SHOP')
IF(@identCur = 0 AND @countRow = 0)
	DBCC CHECKIDENT('[dbo].[CAT_SHOP]', RESEED, 0)
ELSE
	DBCC CHECKIDENT('[dbo].[CAT_SHOP]', RESEED, -1)
GO
INSERT [dbo].[CAT_SHOP] ([ShopCode], [ShopName], [ShopAddress], [ShopTel], [ShopFax], [ShopTax], [ShopWebsite], [OrderBy], [IsActive], [UpdateDate], [UpdateBy], [IsDelete]) VALUES ('AAA', N'Shop A', N'Hà Nội',		N'0124568973', 	N'0124568973', N'0124568973', N'https://www.microsoft.com/vi-vn',	0, 1, CAST(N'2017-05-02 00:00:00.000' AS DateTime), NULL, 0)
INSERT [dbo].[CAT_SHOP] ([ShopCode], [ShopName], [ShopAddress], [ShopTel], [ShopFax], [ShopTax], [ShopWebsite], [OrderBy], [IsActive], [UpdateDate], [UpdateBy], [IsDelete]) VALUES ('BBB', N'Shop B', N'Lâm Đồng',		N'0124568425', 	N'0124568425', N'0124568425', N'https://www.oracle.com/',			1, 1, CAST(N'2018-05-02 00:00:00.000' AS DateTime), NULL, 0)
INSERT [dbo].[CAT_SHOP] ([ShopCode], [ShopName], [ShopAddress], [ShopTel], [ShopFax], [ShopTax], [ShopWebsite], [OrderBy], [IsActive], [UpdateDate], [UpdateBy], [IsDelete]) VALUES ('CCC', N'Shop C', N'Hồ Chí Minh',	N'0124568883', 	N'0124568883', N'0124568883', N'https://www.devexpress.com/',		2, 1, CAST(N'2019-05-02 00:00:00.000' AS DateTime), NULL, 0)
--SELECT * FROM CAT_SHOP
GO
--=========================================================================================================================================================
--=========================================================================================================================================================
-- Người sử dụng
DECLARE @countRow int
SELECT @countRow = COUNT(ID) FROM [dbo].[SYS_USERS]
DELETE  FROM SYS_USERS
DECLARE @identCur int
SELECT @identCur = IDENT_CURRENT('SYS_USERS')
IF(@identCur = 0 AND @countRow = 0)
	DBCC CHECKIDENT('[dbo].[SYS_USERS]', RESEED, 0)
ELSE
	DBCC CHECKIDENT('[dbo].[SYS_USERS]', RESEED, -1)
GO
INSERT [dbo].[SYS_USERS] ([UserName], [Password], [ShopID], [IsAdmin], [OrderBy], [IsActive], [UpdateDate], [UpdateBy], [IsDelete]) VALUES (N'1',		N'c4ca4238a0b923820dcc509a6f75849b', 0, 1, 0,		1, CAST(N'2017-05-02 00:00:00.000' AS DateTime), NULL, 0)
INSERT [dbo].[SYS_USERS] ([UserName], [Password], [ShopID], [IsAdmin], [OrderBy], [IsActive], [UpdateDate], [UpdateBy], [IsDelete]) VALUES (N'adminA',	N'c4ca4238a0b923820dcc509a6f75849b', 0, 0, 1,		1, CAST(N'2017-05-02 00:00:00.000' AS DateTime), NULL, 0)
INSERT [dbo].[SYS_USERS] ([UserName], [Password], [ShopID], [IsAdmin], [OrderBy], [IsActive], [UpdateDate], [UpdateBy], [IsDelete]) VALUES (N'adminB',	N'c4ca4238a0b923820dcc509a6f75849b', 0, 0, 2,		1, CAST(N'2017-05-02 00:00:00.000' AS DateTime), NULL, 0)
INSERT [dbo].[SYS_USERS] ([UserName], [Password], [ShopID], [IsAdmin], [OrderBy], [IsActive], [UpdateDate], [UpdateBy], [IsDelete]) VALUES (N'adminC',	N'c4ca4238a0b923820dcc509a6f75849b', 0, 0, 3,		1, CAST(N'2017-05-02 00:00:00.000' AS DateTime), NULL, 0)
INSERT [dbo].[SYS_USERS] ([UserName], [Password], [ShopID], [IsAdmin], [OrderBy], [IsActive], [UpdateDate], [UpdateBy], [IsDelete]) VALUES (N'BHA1',	N'c4ca4238a0b923820dcc509a6f75849b', 0, 0, 4,		1, CAST(N'2017-05-02 00:00:00.000' AS DateTime), NULL, 0)
INSERT [dbo].[SYS_USERS] ([UserName], [Password], [ShopID], [IsAdmin], [OrderBy], [IsActive], [UpdateDate], [UpdateBy], [IsDelete]) VALUES (N'BHB1',	N'c4ca4238a0b923820dcc509a6f75849b', 0, 0, 5,		1, CAST(N'2017-05-02 00:00:00.000' AS DateTime), NULL, 0)
INSERT [dbo].[SYS_USERS] ([UserName], [Password], [ShopID], [IsAdmin], [OrderBy], [IsActive], [UpdateDate], [UpdateBy], [IsDelete]) VALUES (N'BHC1',	N'c4ca4238a0b923820dcc509a6f75849b', 0, 0, 6,		1, CAST(N'2017-05-02 00:00:00.000' AS DateTime), NULL, 0)
INSERT [dbo].[SYS_USERS] ([UserName], [Password], [ShopID], [IsAdmin], [OrderBy], [IsActive], [UpdateDate], [UpdateBy], [IsDelete]) VALUES (N'BHA2',	N'c4ca4238a0b923820dcc509a6f75849b', 0, 0, 7,		1, CAST(N'2017-05-02 00:00:00.000' AS DateTime), NULL, 0)
INSERT [dbo].[SYS_USERS] ([UserName], [Password], [ShopID], [IsAdmin], [OrderBy], [IsActive], [UpdateDate], [UpdateBy], [IsDelete]) VALUES (N'BHB2',	N'c4ca4238a0b923820dcc509a6f75849b', 0, 0, 8,		1, CAST(N'2017-05-02 00:00:00.000' AS DateTime), NULL, 0)
INSERT [dbo].[SYS_USERS] ([UserName], [Password], [ShopID], [IsAdmin], [OrderBy], [IsActive], [UpdateDate], [UpdateBy], [IsDelete]) VALUES (N'BHC2',	N'c4ca4238a0b923820dcc509a6f75849b', 0, 0, 9,		1, CAST(N'2017-05-02 00:00:00.000' AS DateTime), NULL, 0)
INSERT [dbo].[SYS_USERS] ([UserName], [Password], [ShopID], [IsAdmin], [OrderBy], [IsActive], [UpdateDate], [UpdateBy], [IsDelete]) VALUES (N'BHA3',	N'c4ca4238a0b923820dcc509a6f75849b', 0, 0, 10,		1, CAST(N'2017-05-02 00:00:00.000' AS DateTime), NULL, 0)
INSERT [dbo].[SYS_USERS] ([UserName], [Password], [ShopID], [IsAdmin], [OrderBy], [IsActive], [UpdateDate], [UpdateBy], [IsDelete]) VALUES (N'BHB3',	N'c4ca4238a0b923820dcc509a6f75849b', 0, 0, 11,		1, CAST(N'2017-05-02 00:00:00.000' AS DateTime), NULL, 0)
INSERT [dbo].[SYS_USERS] ([UserName], [Password], [ShopID], [IsAdmin], [OrderBy], [IsActive], [UpdateDate], [UpdateBy], [IsDelete]) VALUES (N'BHC3',	N'c4ca4238a0b923820dcc509a6f75849b', 0, 0, 12,		1, CAST(N'2017-05-02 00:00:00.000' AS DateTime), NULL, 0)
--SELECT * FROM SYS_USERS
GO
UPDATE [dbo].[SYS_USERS] SET [UpdateBy] = 0 WHERE [ID] = 0
UPDATE [dbo].[CAT_SHOP] SET [UpdateBy] = 0 WHERE [UpdateBy] IS NULL
--=========================================================================================================================================================
--=========================================================================================================================================================
-- Nhóm người sử dụng
DECLARE @countRow int
SELECT @countRow = COUNT(ID) FROM [dbo].[CAT_USERGROUP]
DELETE  FROM CAT_USERGROUP
DECLARE @identCur int
SELECT @identCur = IDENT_CURRENT('CAT_USERGROUP')
IF(@identCur = 0 AND @countRow = 0)
	DBCC CHECKIDENT('[dbo].[CAT_USERGROUP]', RESEED, 0)
ELSE
	DBCC CHECKIDENT('[dbo].[CAT_USERGROUP]', RESEED, -1)
GO
INSERT [dbo].[CAT_USERGROUP] ([GroupCode], [GroupName], [Descriptions], [IsAdmin], [OrderBy], [IsActive], [UpdateDate], [UpdateBy], [IsDelete]) VALUES (N'AD',		N'Admin',		'',	 1, 0, 1, CAST(N'2017-05-02 00:00:00.000' AS DateTime), 0, 0)
INSERT [dbo].[CAT_USERGROUP] ([GroupCode], [GroupName], [Descriptions], [IsAdmin], [OrderBy], [IsActive], [UpdateDate], [UpdateBy], [IsDelete]) VALUES (N'EM',		N'Nhân viên',	'',	 0, 1, 1, CAST(N'2017-05-02 00:00:00.000' AS DateTime), 0, 0)
--SELECT * FROM CAT_USERGROUP
GO
--=========================================================================================================================================================
--=========================================================================================================================================================
-- Quầy thu ngân
DECLARE @countRow int
SELECT @countRow = COUNT(ID) FROM [dbo].[CAT_COUNTER]
DELETE FROM CAT_COUNTER
DECLARE @identCur int
SELECT @identCur = IDENT_CURRENT('CAT_COUNTER')
IF(@identCur = 0 AND @countRow = 0)
	DBCC CHECKIDENT('[dbo].[CAT_COUNTER]', RESEED, 0)
ELSE
	DBCC CHECKIDENT('[dbo].[CAT_COUNTER]', RESEED, -1)
GO
INSERT [dbo].[CAT_COUNTER] ([CounterCode], [CounterName], [StatusCode], [ShopID], [OrderBy], [IsActive], [UpdateDate], [UpdateBy], [IsDelete]) VALUES ('QTTS', N'Quầy tổng',		N'C', 0, 0,		1, CAST(N'2017-05-02 00:00:00.000' AS DateTime), 0, 0)
INSERT [dbo].[CAT_COUNTER] ([CounterCode], [CounterName], [StatusCode], [ShopID], [OrderBy], [IsActive], [UpdateDate], [UpdateBy], [IsDelete]) VALUES ('QTTA', N'Quầy tổng A',		N'C', 0, 1,		1, CAST(N'2017-05-02 00:00:00.000' AS DateTime), 0, 0)
INSERT [dbo].[CAT_COUNTER] ([CounterCode], [CounterName], [StatusCode], [ShopID], [OrderBy], [IsActive], [UpdateDate], [UpdateBy], [IsDelete]) VALUES ('QTA1', N'Quầy thu ngân A1',	N'C', 0, 2,		1, CAST(N'2017-05-02 00:00:00.000' AS DateTime), 0, 0)
INSERT [dbo].[CAT_COUNTER] ([CounterCode], [CounterName], [StatusCode], [ShopID], [OrderBy], [IsActive], [UpdateDate], [UpdateBy], [IsDelete]) VALUES ('QTA2', N'Quầy thu ngân A2',	N'C', 0, 3,		1, CAST(N'2017-05-02 00:00:00.000' AS DateTime), 0, 0)
INSERT [dbo].[CAT_COUNTER] ([CounterCode], [CounterName], [StatusCode], [ShopID], [OrderBy], [IsActive], [UpdateDate], [UpdateBy], [IsDelete]) VALUES ('QTA3', N'Quầy thu ngân A3',	N'C', 0, 4,		1, CAST(N'2017-05-02 00:00:00.000' AS DateTime), 0, 0)
INSERT [dbo].[CAT_COUNTER] ([CounterCode], [CounterName], [StatusCode], [ShopID], [OrderBy], [IsActive], [UpdateDate], [UpdateBy], [IsDelete]) VALUES ('QTTB', N'Quầy tổng B',		N'C', 1, 5,		1, CAST(N'2017-05-02 00:00:00.000' AS DateTime), 0, 0)
INSERT [dbo].[CAT_COUNTER] ([CounterCode], [CounterName], [StatusCode], [ShopID], [OrderBy], [IsActive], [UpdateDate], [UpdateBy], [IsDelete]) VALUES ('QTB1', N'Quầy thu ngân B1',	N'C', 1, 6,		1, CAST(N'2017-05-02 00:00:00.000' AS DateTime), 0, 0)
INSERT [dbo].[CAT_COUNTER] ([CounterCode], [CounterName], [StatusCode], [ShopID], [OrderBy], [IsActive], [UpdateDate], [UpdateBy], [IsDelete]) VALUES ('QTB2', N'Quầy thu ngân B2',	N'C', 1, 7,		1, CAST(N'2017-05-02 00:00:00.000' AS DateTime), 0, 0)
INSERT [dbo].[CAT_COUNTER] ([CounterCode], [CounterName], [StatusCode], [ShopID], [OrderBy], [IsActive], [UpdateDate], [UpdateBy], [IsDelete]) VALUES ('QTB3', N'Quầy thu ngân B3',	N'C', 1, 8,		1, CAST(N'2017-05-02 00:00:00.000' AS DateTime), 0, 0)
INSERT [dbo].[CAT_COUNTER] ([CounterCode], [CounterName], [StatusCode], [ShopID], [OrderBy], [IsActive], [UpdateDate], [UpdateBy], [IsDelete]) VALUES ('QTTC', N'Quầy tổng C',		N'C', 2, 9,		1, CAST(N'2017-05-02 00:00:00.000' AS DateTime), 0, 0)
INSERT [dbo].[CAT_COUNTER] ([CounterCode], [CounterName], [StatusCode], [ShopID], [OrderBy], [IsActive], [UpdateDate], [UpdateBy], [IsDelete]) VALUES ('QTC1', N'Quầy thu ngân C1',	N'C', 2, 10,	1, CAST(N'2017-05-02 00:00:00.000' AS DateTime), 0, 0)
INSERT [dbo].[CAT_COUNTER] ([CounterCode], [CounterName], [StatusCode], [ShopID], [OrderBy], [IsActive], [UpdateDate], [UpdateBy], [IsDelete]) VALUES ('QTC2', N'Quầy thu ngân C2',	N'C', 2, 11,	1, CAST(N'2017-05-02 00:00:00.000' AS DateTime), 0, 0)
INSERT [dbo].[CAT_COUNTER] ([CounterCode], [CounterName], [StatusCode], [ShopID], [OrderBy], [IsActive], [UpdateDate], [UpdateBy], [IsDelete]) VALUES ('QTC3', N'Quầy thu ngân C3',	N'C', 2, 12,	1, CAST(N'2017-05-02 00:00:00.000' AS DateTime), 0, 0)
--SELECT * FROM CAT_COUNTER
GO
--=========================================================================================================================================================
--=========================================================================================================================================================
-- Quầy hàng
DECLARE @countRow int
SELECT @countRow = COUNT(ID) FROM [dbo].[CAT_STALLS]
DELETE FROM CAT_STALLS
DECLARE @identCur int
SELECT @identCur = IDENT_CURRENT('CAT_STALLS')
IF(@identCur = 0 AND @countRow = 0)
	DBCC CHECKIDENT('[dbo].[CAT_STALLS]', RESEED, 0)
ELSE
	DBCC CHECKIDENT('[dbo].[CAT_STALLS]', RESEED, -1)
GO
INSERT [dbo].[CAT_STALLS] ([StallsCode], [StallsName], [ShopID], [OrderBy], [IsActive], [UpdateDate], [UpdateBy], [IsDelete]) VALUES ('QKA01', N'Quầy pha chế - chế biến',			0, 0,		1, CAST(N'2017-05-02 00:00:00.000' AS DateTime), 0, 0) 
INSERT [dbo].[CAT_STALLS] ([StallsCode], [StallsName], [ShopID], [OrderBy], [IsActive], [UpdateDate], [UpdateBy], [IsDelete]) VALUES ('QKA02', N'Quầy bánh kẹo',					0, 1,		1, CAST(N'2017-05-02 00:00:00.000' AS DateTime), 0, 0) 
INSERT [dbo].[CAT_STALLS] ([StallsCode], [StallsName], [ShopID], [OrderBy], [IsActive], [UpdateDate], [UpdateBy], [IsDelete]) VALUES ('QKA03', N'Quầy trái cây',					0, 2,		1, CAST(N'2017-05-02 00:00:00.000' AS DateTime), 0, 0) 
INSERT [dbo].[CAT_STALLS] ([StallsCode], [StallsName], [ShopID], [OrderBy], [IsActive], [UpdateDate], [UpdateBy], [IsDelete]) VALUES ('QKA04', N'Quầy nước uống',					0, 3,		1, CAST(N'2017-05-02 00:00:00.000' AS DateTime), 0, 0) 
INSERT [dbo].[CAT_STALLS] ([StallsCode], [StallsName], [ShopID], [OrderBy], [IsActive], [UpdateDate], [UpdateBy], [IsDelete]) VALUES ('QKA05', N'Quầy rượu bia',					0, 4,		1, CAST(N'2017-05-02 00:00:00.000' AS DateTime), 0, 0) 
INSERT [dbo].[CAT_STALLS] ([StallsCode], [StallsName], [ShopID], [OrderBy], [IsActive], [UpdateDate], [UpdateBy], [IsDelete]) VALUES ('QKB01', N'Quầy pha chế - chế biến',			1, 5,		1, CAST(N'2017-05-02 00:00:00.000' AS DateTime), 0, 0) 
INSERT [dbo].[CAT_STALLS] ([StallsCode], [StallsName], [ShopID], [OrderBy], [IsActive], [UpdateDate], [UpdateBy], [IsDelete]) VALUES ('QKB02', N'Quầy bánh kẹo',					1, 6,		1, CAST(N'2017-05-02 00:00:00.000' AS DateTime), 0, 0) 
INSERT [dbo].[CAT_STALLS] ([StallsCode], [StallsName], [ShopID], [OrderBy], [IsActive], [UpdateDate], [UpdateBy], [IsDelete]) VALUES ('QKB03', N'Quầy trái cây',					1, 7,		1, CAST(N'2017-05-02 00:00:00.000' AS DateTime), 0, 0) 
INSERT [dbo].[CAT_STALLS] ([StallsCode], [StallsName], [ShopID], [OrderBy], [IsActive], [UpdateDate], [UpdateBy], [IsDelete]) VALUES ('QKB04', N'Quầy nước uống',					1, 8,		1, CAST(N'2017-05-02 00:00:00.000' AS DateTime), 0, 0) 
INSERT [dbo].[CAT_STALLS] ([StallsCode], [StallsName], [ShopID], [OrderBy], [IsActive], [UpdateDate], [UpdateBy], [IsDelete]) VALUES ('QKB05', N'Quầy rượu bia',					1, 9,		1, CAST(N'2017-05-02 00:00:00.000' AS DateTime), 0, 0) 
INSERT [dbo].[CAT_STALLS] ([StallsCode], [StallsName], [ShopID], [OrderBy], [IsActive], [UpdateDate], [UpdateBy], [IsDelete]) VALUES ('QKC01', N'Quầy pha chế - chế biến',			2, 10,		1, CAST(N'2017-05-02 00:00:00.000' AS DateTime), 0, 0) 
INSERT [dbo].[CAT_STALLS] ([StallsCode], [StallsName], [ShopID], [OrderBy], [IsActive], [UpdateDate], [UpdateBy], [IsDelete]) VALUES ('QKC02', N'Quầy bánh kẹo',					2, 11,		1, CAST(N'2017-05-02 00:00:00.000' AS DateTime), 0, 0) 
INSERT [dbo].[CAT_STALLS] ([StallsCode], [StallsName], [ShopID], [OrderBy], [IsActive], [UpdateDate], [UpdateBy], [IsDelete]) VALUES ('QKC03', N'Quầy trái cây',					2, 12,		1, CAST(N'2017-05-02 00:00:00.000' AS DateTime), 0, 0) 
INSERT [dbo].[CAT_STALLS] ([StallsCode], [StallsName], [ShopID], [OrderBy], [IsActive], [UpdateDate], [UpdateBy], [IsDelete]) VALUES ('QKC04', N'Quầy nước uống',					2, 13,		1, CAST(N'2017-05-02 00:00:00.000' AS DateTime), 0, 0) 
INSERT [dbo].[CAT_STALLS] ([StallsCode], [StallsName], [ShopID], [OrderBy], [IsActive], [UpdateDate], [UpdateBy], [IsDelete]) VALUES ('QKC05', N'Quầy rượu bia',					2, 14,		1, CAST(N'2017-05-02 00:00:00.000' AS DateTime), 0, 0) 
--SELECT * FROM CAT_STALLS
GO
--=========================================================================================================================================================
--=========================================================================================================================================================
-- Nhân viên
DECLARE @countRow int
SELECT @countRow = COUNT(ID) FROM [dbo].[CAT_EMPLOYEE]
DELETE FROM CAT_EMPLOYEE
DECLARE @identCur int
SELECT @identCur = IDENT_CURRENT('CAT_EMPLOYEE')
IF(@identCur = 0 AND @countRow = 0)
	DBCC CHECKIDENT('[dbo].[CAT_EMPLOYEE]', RESEED, 0)
ELSE
	DBCC CHECKIDENT('[dbo].[CAT_EMPLOYEE]', RESEED, -1)
GO
INSERT [dbo].[CAT_EMPLOYEE] ([EmpCode], [EmpName], [UserID], [ShopID], [OrderBy], [IsActive], [UpdateDate], [UpdateBy], [IsDelete]) VALUES (N'NV'	,		N'1',						0,	0, 0, 1, CAST(N'2017-05-02 00:00:00.000' AS DateTime), 0, 0)
INSERT [dbo].[CAT_EMPLOYEE] ([EmpCode], [EmpName], [UserID], [ShopID], [OrderBy], [IsActive], [UpdateDate], [UpdateBy], [IsDelete]) VALUES (N'NVAA'	,		N'adminA',					1,	0, 0, 1, CAST(N'2017-05-02 00:00:00.000' AS DateTime), 0, 0)
INSERT [dbo].[CAT_EMPLOYEE] ([EmpCode], [EmpName], [UserID], [ShopID], [OrderBy], [IsActive], [UpdateDate], [UpdateBy], [IsDelete]) VALUES (N'NVBA'	,		N'adminB',					2,	1, 0, 1, CAST(N'2017-05-02 00:00:00.000' AS DateTime), 0, 0)
INSERT [dbo].[CAT_EMPLOYEE] ([EmpCode], [EmpName], [UserID], [ShopID], [OrderBy], [IsActive], [UpdateDate], [UpdateBy], [IsDelete]) VALUES (N'NVCA'	,		N'adminC',					3,	2, 0, 1, CAST(N'2017-05-02 00:00:00.000' AS DateTime), 0, 0)
INSERT [dbo].[CAT_EMPLOYEE] ([EmpCode], [EmpName], [UserID], [ShopID], [OrderBy], [IsActive], [UpdateDate], [UpdateBy], [IsDelete]) VALUES (N'BHA1'	,		N'Bán hàng A1',				4,	0, 0, 1, CAST(N'2017-05-02 00:00:00.000' AS DateTime), 0, 0)
INSERT [dbo].[CAT_EMPLOYEE] ([EmpCode], [EmpName], [UserID], [ShopID], [OrderBy], [IsActive], [UpdateDate], [UpdateBy], [IsDelete]) VALUES (N'BHB1'	,		N'Bán hàng B1',				5,	1, 0, 1, CAST(N'2017-05-02 00:00:00.000' AS DateTime), 0, 0)
INSERT [dbo].[CAT_EMPLOYEE] ([EmpCode], [EmpName], [UserID], [ShopID], [OrderBy], [IsActive], [UpdateDate], [UpdateBy], [IsDelete]) VALUES (N'BHC1'	,		N'Bán hàng C1',				6,	2, 0, 1, CAST(N'2017-05-02 00:00:00.000' AS DateTime), 0, 0)
INSERT [dbo].[CAT_EMPLOYEE] ([EmpCode], [EmpName], [UserID], [ShopID], [OrderBy], [IsActive], [UpdateDate], [UpdateBy], [IsDelete]) VALUES (N'BHA2'	,		N'Bán hàng A2',				7,	0, 0, 1, CAST(N'2017-05-02 00:00:00.000' AS DateTime), 0, 0)
INSERT [dbo].[CAT_EMPLOYEE] ([EmpCode], [EmpName], [UserID], [ShopID], [OrderBy], [IsActive], [UpdateDate], [UpdateBy], [IsDelete]) VALUES (N'BHB2'	,		N'Bán hàng B2',				8,	1, 0, 1, CAST(N'2017-05-02 00:00:00.000' AS DateTime), 0, 0)
INSERT [dbo].[CAT_EMPLOYEE] ([EmpCode], [EmpName], [UserID], [ShopID], [OrderBy], [IsActive], [UpdateDate], [UpdateBy], [IsDelete]) VALUES (N'BHC2'	,		N'Bán hàng C2',				9,	2, 0, 1, CAST(N'2017-05-02 00:00:00.000' AS DateTime), 0, 0)
INSERT [dbo].[CAT_EMPLOYEE] ([EmpCode], [EmpName], [UserID], [ShopID], [OrderBy], [IsActive], [UpdateDate], [UpdateBy], [IsDelete]) VALUES (N'BHA3'	,		N'Bán hàng A3',				10, 0, 0, 1, CAST(N'2017-05-02 00:00:00.000' AS DateTime), 0, 0)
INSERT [dbo].[CAT_EMPLOYEE] ([EmpCode], [EmpName], [UserID], [ShopID], [OrderBy], [IsActive], [UpdateDate], [UpdateBy], [IsDelete]) VALUES (N'BHB3'	,		N'Bán hàng B3',				11, 1, 0, 1, CAST(N'2017-05-02 00:00:00.000' AS DateTime), 0, 0)
INSERT [dbo].[CAT_EMPLOYEE] ([EmpCode], [EmpName], [UserID], [ShopID], [OrderBy], [IsActive], [UpdateDate], [UpdateBy], [IsDelete]) VALUES (N'BHC3'	,		N'Bán hàng C3',				12, 2, 0, 1, CAST(N'2017-05-02 00:00:00.000' AS DateTime), 0, 0)
--SELECT * FROM CAT_EMPLOYEE
GO
--=========================================================================================================================================================
--=========================================================================================================================================================
-- Map giữa Người sử dụng và Nhóm người sử dụng
DELETE FROM MAP_USER_USERGROUP
GO
INSERT [dbo].[MAP_USER_USERGROUP] ([GroupID], [UserID]) VALUES (0, 0)
INSERT [dbo].[MAP_USER_USERGROUP] ([GroupID], [UserID]) VALUES (0, 1)
INSERT [dbo].[MAP_USER_USERGROUP] ([GroupID], [UserID]) VALUES (0, 2)
INSERT [dbo].[MAP_USER_USERGROUP] ([GroupID], [UserID]) VALUES (0, 3)
INSERT [dbo].[MAP_USER_USERGROUP] ([GroupID], [UserID]) VALUES (1, 4)
INSERT [dbo].[MAP_USER_USERGROUP] ([GroupID], [UserID]) VALUES (1, 5)
INSERT [dbo].[MAP_USER_USERGROUP] ([GroupID], [UserID]) VALUES (1, 6)
INSERT [dbo].[MAP_USER_USERGROUP] ([GroupID], [UserID]) VALUES (1, 7)
INSERT [dbo].[MAP_USER_USERGROUP] ([GroupID], [UserID]) VALUES (1, 8)
INSERT [dbo].[MAP_USER_USERGROUP] ([GroupID], [UserID]) VALUES (1, 9)
INSERT [dbo].[MAP_USER_USERGROUP] ([GroupID], [UserID]) VALUES (1, 10)
INSERT [dbo].[MAP_USER_USERGROUP] ([GroupID], [UserID]) VALUES (1, 11)
INSERT [dbo].[MAP_USER_USERGROUP] ([GroupID], [UserID]) VALUES (1, 12)
--SELECT * FROM MAP_USER_USERGROUP
GO
--=========================================================================================================================================================
--=========================================================================================================================================================
EXEC sp_msforeachtable "ALTER TABLE ? WITH CHECK CHECK CONSTRAINT all"
GO	