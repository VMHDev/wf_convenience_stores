USE PTTKPMCRM
GO
EXEC sp_msforeachtable "ALTER TABLE ? NOCHECK CONSTRAINT all"
GO
--=========================================================================================================================================================
--=========================================================================================================================================================
-- Nhóm người sử dụng
DECLARE @countRow int
SELECT @countRow = COUNT(ID) FROM [dbo].[CAT_USERGROUP]
DELETE FROM CAT_USERGROUP
DECLARE @identCur int
SELECT @identCur = IDENT_CURRENT('CAT_USERGROUP')
IF(@identCur = 0 AND @countRow = 0)
	DBCC CHECKIDENT('[dbo].[CAT_USERGROUP]', RESEED, 0)
ELSE
	DBCC CHECKIDENT('[dbo].[CAT_USERGROUP]', RESEED, -1)
GO
INSERT [dbo].[CAT_USERGROUP] ([GroupCode], [GroupName], [Descriptions], [IsAdmin], [OrderBy], [IsActive], [UpdateDate], [UpdateBy], [IsDelete]) 
VALUES (N'AD',	N'Admin', N'Nhóm quản trị hệ thống', 1, 0, 1, CAST(N'2017-05-02 00:00:00.000' AS DateTime), 0, 0)
--SELECT * FROM CAT_USERGROUP
GO
--=========================================================================================================================================================
--=========================================================================================================================================================
-- Danh sách các menu trên phần mềm
DELETE FROM SYS_MENUS
GO
INSERT [dbo].[SYS_MENUS] ([MenuCode], [MenuDesc], [MenuParent], [FormName], [OrderBy], [IsActive]) VALUES (N'mnuRootProduct',			N'Giao dịch hàng',			N'',					N'',						100, 1)
INSERT [dbo].[SYS_MENUS] ([MenuCode], [MenuDesc], [MenuParent], [FormName], [OrderBy], [IsActive]) VALUES (N'mnuRootCounter',			N'Giao dịch quầy',			N'',					N'',						200, 1)
INSERT [dbo].[SYS_MENUS] ([MenuCode], [MenuDesc], [MenuParent], [FormName], [OrderBy], [IsActive]) VALUES (N'mnuRootCategory',			N'Danh mục',				N'',					N'',						300, 1)
INSERT [dbo].[SYS_MENUS] ([MenuCode], [MenuDesc], [MenuParent], [FormName], [OrderBy], [IsActive]) VALUES (N'mnuRootQuery',				N'Tra cứu',					N'',					N'',						400, 1)
INSERT [dbo].[SYS_MENUS] ([MenuCode], [MenuDesc], [MenuParent], [FormName], [OrderBy], [IsActive]) VALUES (N'mnuRootSystem',			N'Hệ thống',				N'',					N'',						500, 1)
INSERT [dbo].[SYS_MENUS] ([MenuCode], [MenuDesc], [MenuParent], [FormName], [OrderBy], [IsActive]) VALUES (N'mnuRootSkins',				N'Giao diện',				N'',					N'',						600, 1)
--INSERT [dbo].[SYS_MENUS] ([MenuCode], [MenuDesc], [MenuParent], [FormName], [OrderBy], [IsActive]) VALUES (N'mnuRootTest',				N'Test',				N'',					N'',						700, 1)

-----------------------------------------------------------------------------------------------------------------------------------------------------------
INSERT [dbo].[SYS_MENUS] ([MenuCode], [MenuDesc], [MenuParent], [FormName], [OrderBy], [IsActive]) VALUES (N'mnuProductIn',				N'Nhập hàng',				N'mnuRootProduct',		N'frmProductIn',			110, 1)
INSERT [dbo].[SYS_MENUS] ([MenuCode], [MenuDesc], [MenuParent], [FormName], [OrderBy], [IsActive]) VALUES (N'mnuProductOut',			N'Xuất hàng',				N'mnuRootProduct',		N'frmProductOut',			120, 1)
INSERT [dbo].[SYS_MENUS] ([MenuCode], [MenuDesc], [MenuParent], [FormName], [OrderBy], [IsActive]) VALUES (N'mnuProductTransfer',		N'Chuyển hàng',				N'mnuRootProduct',		N'frmProductTransfer',		130, 1)
INSERT [dbo].[SYS_MENUS] ([MenuCode], [MenuDesc], [MenuParent], [FormName], [OrderBy], [IsActive]) VALUES (N'mnuProductSell',			N'Bán hàng',				N'mnuRootProduct',		N'frmProductSell',			140, 1)

-----------------------------------------------------------------------------------------------------------------------------------------------------------
INSERT [dbo].[SYS_MENUS] ([MenuCode], [MenuDesc], [MenuParent], [FormName], [OrderBy], [IsActive]) VALUES (N'mnuCounterInOut',			N'Thu/Chi tại quầy',		N'mnuRootCounter',		N'',						210, 1)
INSERT [dbo].[SYS_MENUS] ([MenuCode], [MenuDesc], [MenuParent], [FormName], [OrderBy], [IsActive]) VALUES (N'mnuCounterTransfer',		N'Chuyển quầy',				N'mnuRootCounter',		N'',						220, 1)
INSERT [dbo].[SYS_MENUS] ([MenuCode], [MenuDesc], [MenuParent], [FormName], [OrderBy], [IsActive]) VALUES (N'mnuCounterOpenClose',		N'Đóng/Mở quầy',			N'mnuRootCounter',		N'',						230, 1)

-----------------------------------------------------------------------------------------------------------------------------------------------------------
INSERT [dbo].[SYS_MENUS] ([MenuCode], [MenuDesc], [MenuParent], [FormName], [OrderBy], [IsActive]) VALUES (N'mnuGrpEmployee',			N'Nhân viên',				N'mnuRootCategory',		N'',						310, 1)
INSERT [dbo].[SYS_MENUS] ([MenuCode], [MenuDesc], [MenuParent], [FormName], [OrderBy], [IsActive]) VALUES (N'mnuGrpUnit',				N'Đơn vị',					N'mnuRootCategory',		N'',						320, 1)
INSERT [dbo].[SYS_MENUS] ([MenuCode], [MenuDesc], [MenuParent], [FormName], [OrderBy], [IsActive]) VALUES (N'mnuGrpCustomer',			N'Khách hàng',				N'mnuRootCategory',		N'',						330, 1)
INSERT [dbo].[SYS_MENUS] ([MenuCode], [MenuDesc], [MenuParent], [FormName], [OrderBy], [IsActive]) VALUES (N'mnuGrpShop',				N'Cửa hàng',				N'mnuRootCategory',		N'',						340, 1)
INSERT [dbo].[SYS_MENUS] ([MenuCode], [MenuDesc], [MenuParent], [FormName], [OrderBy], [IsActive]) VALUES (N'mnuGrpProduct',			N'Hàng hóa',				N'mnuRootCategory',		N'',						350, 1)
INSERT [dbo].[SYS_MENUS] ([MenuCode], [MenuDesc], [MenuParent], [FormName], [OrderBy], [IsActive]) VALUES (N'mnuSupplier',				N'Nhà cung cấp',			N'mnuRootCategory',		N'',						360, 1)
INSERT [dbo].[SYS_MENUS] ([MenuCode], [MenuDesc], [MenuParent], [FormName], [OrderBy], [IsActive]) VALUES (N'mnuCurrency',				N'Tiền tệ',					N'mnuRootCategory',		N'',						370, 1)

INSERT [dbo].[SYS_MENUS] ([MenuCode], [MenuDesc], [MenuParent], [FormName], [OrderBy], [IsActive]) VALUES (N'mnuCustomer',				N'Khách hàng',				N'mnuGrpCustomer',		N'',						331, 1)
INSERT [dbo].[SYS_MENUS] ([MenuCode], [MenuDesc], [MenuParent], [FormName], [OrderBy], [IsActive]) VALUES (N'mnuCustomerGroup',			N'Nhóm khách hàng',			N'mnuGrpCustomer',		N'',						332, 1)
INSERT [dbo].[SYS_MENUS] ([MenuCode], [MenuDesc], [MenuParent], [FormName], [OrderBy], [IsActive]) VALUES (N'mnuCustomerType',			N'Loại khách hàng',			N'mnuGrpCustomer',		N'',						333, 1)

INSERT [dbo].[SYS_MENUS] ([MenuCode], [MenuDesc], [MenuParent], [FormName], [OrderBy], [IsActive]) VALUES (N'mnuProductType',			N'Loại hàng',				N'mnuGrpProduct',		N'',						351, 1)
INSERT [dbo].[SYS_MENUS] ([MenuCode], [MenuDesc], [MenuParent], [FormName], [OrderBy], [IsActive]) VALUES (N'mnuProductGroup',			N'Nhóm hàng',				N'mnuGrpProduct',		N'',						352, 1)
INSERT [dbo].[SYS_MENUS] ([MenuCode], [MenuDesc], [MenuParent], [FormName], [OrderBy], [IsActive]) VALUES (N'mnuProductCat',			N'Danh mục hàng',			N'mnuGrpProduct',		N'',						353, 1)

INSERT [dbo].[SYS_MENUS] ([MenuCode], [MenuDesc], [MenuParent], [FormName], [OrderBy], [IsActive]) VALUES (N'mnuShop',					N'Cửa hàng',				N'mnuGrpShop',			N'',						341,  1)
INSERT [dbo].[SYS_MENUS] ([MenuCode], [MenuDesc], [MenuParent], [FormName], [OrderBy], [IsActive]) VALUES (N'mnuCounter',				N'Quầy thu ngân',			N'mnuGrpShop',			N'',						342, 1)
INSERT [dbo].[SYS_MENUS] ([MenuCode], [MenuDesc], [MenuParent], [FormName], [OrderBy], [IsActive]) VALUES (N'mnuStalls',				N'Quầy/Kho',				N'mnuGrpShop',			N'',						343, 1)

INSERT [dbo].[SYS_MENUS] ([MenuCode], [MenuDesc], [MenuParent], [FormName], [OrderBy], [IsActive]) VALUES (N'mnuEmployee',				N'Nhân viên',				N'mnuGrpEmployee',		N'',						311, 1)
INSERT [dbo].[SYS_MENUS] ([MenuCode], [MenuDesc], [MenuParent], [FormName], [OrderBy], [IsActive]) VALUES (N'mnuUser',					N'Tài khoản',				N'mnuGrpEmployee',		N'',						312, 1)
INSERT [dbo].[SYS_MENUS] ([MenuCode], [MenuDesc], [MenuParent], [FormName], [OrderBy], [IsActive]) VALUES (N'mnuUserGroup',				N'Nhóm tài khoản',			N'mnuGrpEmployee',		N'',						313, 1)

INSERT [dbo].[SYS_MENUS] ([MenuCode], [MenuDesc], [MenuParent], [FormName], [OrderBy], [IsActive]) VALUES (N'mnuUnitSell',				N'Đơn vị bán',				N'mnuGrpUnit',			N'',						321, 1)
INSERT [dbo].[SYS_MENUS] ([MenuCode], [MenuDesc], [MenuParent], [FormName], [OrderBy], [IsActive]) VALUES (N'mnuUnitWeight',			N'Đơn vị cân',				N'mnuGrpUnit',			N'',						322, 1)
INSERT [dbo].[SYS_MENUS] ([MenuCode], [MenuDesc], [MenuParent], [FormName], [OrderBy], [IsActive]) VALUES (N'mnuUnitIn',				N'Đơn vị nhập',				N'mnuGrpUnit',			N'',						323, 1)

-----------------------------------------------------------------------------------------------------------------------------------------------------------
INSERT [dbo].[SYS_MENUS] ([MenuCode], [MenuDesc], [MenuParent], [FormName], [OrderBy], [IsActive]) VALUES (N'mnuQueryInStockCounter',	N'Tra cứu số dư quầy thu ngân',	N'mnuRootQuery',			N'',				410, 1)
INSERT [dbo].[SYS_MENUS] ([MenuCode], [MenuDesc], [MenuParent], [FormName], [OrderBy], [IsActive]) VALUES (N'mnuQueryInfoProduct',		N'Tra cứu hàng',				N'mnuRootQuery',			N'',				420, 1)
INSERT [dbo].[SYS_MENUS] ([MenuCode], [MenuDesc], [MenuParent], [FormName], [OrderBy], [IsActive]) VALUES (N'mnuQueryTransaction',		N'Tra cứu giao dịch',			N'mnuRootQuery',			N'',				430, 1)

-----------------------------------------------------------------------------------------------------------------------------------------------------------
INSERT [dbo].[SYS_MENUS] ([MenuCode], [MenuDesc], [MenuParent], [FormName], [OrderBy], [IsActive]) VALUES (N'mnuGrpUser',				N'Người dùng',				N'mnuRootSystem',		N'',						610, 1)
INSERT [dbo].[SYS_MENUS] ([MenuCode], [MenuDesc], [MenuParent], [FormName], [OrderBy], [IsActive]) VALUES (N'mnuGrpConfig',				N'Cấu hình',				N'mnuRootSystem',		N'',						620, 1)
INSERT [dbo].[SYS_MENUS] ([MenuCode], [MenuDesc], [MenuParent], [FormName], [OrderBy], [IsActive]) VALUES (N'mnuAccessRights',			N'Phân quyền',				N'mnuRootSystem',		N'frmAccessRights',			630, 1)
INSERT [dbo].[SYS_MENUS] ([MenuCode], [MenuDesc], [MenuParent], [FormName], [OrderBy], [IsActive]) VALUES (N'mnuCustomerService',		N'Chăm sóc khách hàng',		N'mnuRootSystem',		N'frmCustomerService',		640, 1)
INSERT [dbo].[SYS_MENUS] ([MenuCode], [MenuDesc], [MenuParent], [FormName], [OrderBy], [IsActive]) VALUES (N'mnuProductUpdateRate',		N'Chăm sóc khách hàng',		N'mnuRootSystem',		N'frmProductUpdateRate',	650, 1)

INSERT [dbo].[SYS_MENUS] ([MenuCode], [MenuDesc], [MenuParent], [FormName], [OrderBy], [IsActive]) VALUES (N'mnuLogin',					N'Đăng nhập',				N'mnuGroupUser',		N'frmLogin',				611, 1)
INSERT [dbo].[SYS_MENUS] ([MenuCode], [MenuDesc], [MenuParent], [FormName], [OrderBy], [IsActive]) VALUES (N'mnuPasswordChange',		N'Đổi mật khẩu',			N'mnuGroupUser',		N'frmPasswordChange',		612, 1)
INSERT [dbo].[SYS_MENUS] ([MenuCode], [MenuDesc], [MenuParent], [FormName], [OrderBy], [IsActive]) VALUES (N'mnuPasswordReset',			N'Reset mật khẩu',			N'mnuGroupUser',		N'frmPasswordReset',		613, 1)
INSERT [dbo].[SYS_MENUS] ([MenuCode], [MenuDesc], [MenuParent], [FormName], [OrderBy], [IsActive]) VALUES (N'mnuAccountUpdate',			N'Cập nhật thông tin',		N'mnuGroupUser',		N'frmAccountUpdate',		614, 1)
INSERT [dbo].[SYS_MENUS] ([MenuCode], [MenuDesc], [MenuParent], [FormName], [OrderBy], [IsActive]) VALUES (N'mnuAccountBlock',			N'Khóa tài khoản',			N'mnuGroupUser',		N'frmAccountBlock',			615, 1)

INSERT [dbo].[SYS_MENUS] ([MenuCode], [MenuDesc], [MenuParent], [FormName], [OrderBy], [IsActive]) VALUES (N'mnuConfigDatabase',		N'Cơ sở dữ liệu',		N'mnuGroupConfig',		N'frmConfigDatabase',			621, 1)
--SELECT * FROM SYS_MENUS
GO
--=========================================================================================================================================================
--=========================================================================================================================================================
-- Danh sách các phân quyền
DELETE FROM SYS_RIGHTS
GO
INSERT [dbo].[SYS_RIGHTS] ([MenuCode], [GroupID], [AccessRights]) VALUES (N'mnuRootProduct',			0, 1)
INSERT [dbo].[SYS_RIGHTS] ([MenuCode], [GroupID], [AccessRights]) VALUES (N'mnuRootCounter',			0, 1)
INSERT [dbo].[SYS_RIGHTS] ([MenuCode], [GroupID], [AccessRights]) VALUES (N'mnuRootCategory',			0, 1)
INSERT [dbo].[SYS_RIGHTS] ([MenuCode], [GroupID], [AccessRights]) VALUES (N'mnuRootQuery',				0, 1)
INSERT [dbo].[SYS_RIGHTS] ([MenuCode], [GroupID], [AccessRights]) VALUES (N'mnuRootSystem',				0, 1)
INSERT [dbo].[SYS_RIGHTS] ([MenuCode], [GroupID], [AccessRights]) VALUES (N'mnuRootSkins',				0, 1)
INSERT [dbo].[SYS_RIGHTS] ([MenuCode], [GroupID], [AccessRights]) VALUES (N'mnuProductIn',				0, 1)
INSERT [dbo].[SYS_RIGHTS] ([MenuCode], [GroupID], [AccessRights]) VALUES (N'mnuProductOut',				0, 1)
INSERT [dbo].[SYS_RIGHTS] ([MenuCode], [GroupID], [AccessRights]) VALUES (N'mnuProductTransfer',		0, 1)
INSERT [dbo].[SYS_RIGHTS] ([MenuCode], [GroupID], [AccessRights]) VALUES (N'mnuProductSell',			0, 1)
INSERT [dbo].[SYS_RIGHTS] ([MenuCode], [GroupID], [AccessRights]) VALUES (N'mnuCounterInOut',			0, 1)
INSERT [dbo].[SYS_RIGHTS] ([MenuCode], [GroupID], [AccessRights]) VALUES (N'mnuCounterTransfer',		0, 1)
INSERT [dbo].[SYS_RIGHTS] ([MenuCode], [GroupID], [AccessRights]) VALUES (N'mnuCounterOpenClose',		0, 1)
INSERT [dbo].[SYS_RIGHTS] ([MenuCode], [GroupID], [AccessRights]) VALUES (N'mnuGrpEmployee',			0, 1)
INSERT [dbo].[SYS_RIGHTS] ([MenuCode], [GroupID], [AccessRights]) VALUES (N'mnuGrpUnit',				0, 1)
INSERT [dbo].[SYS_RIGHTS] ([MenuCode], [GroupID], [AccessRights]) VALUES (N'mnuGrpCustomer',			0, 1)
INSERT [dbo].[SYS_RIGHTS] ([MenuCode], [GroupID], [AccessRights]) VALUES (N'mnuGrpShop',				0, 1)
INSERT [dbo].[SYS_RIGHTS] ([MenuCode], [GroupID], [AccessRights]) VALUES (N'mnuGrpProduct',				0, 1)
INSERT [dbo].[SYS_RIGHTS] ([MenuCode], [GroupID], [AccessRights]) VALUES (N'mnuSupplier',				0, 1)
INSERT [dbo].[SYS_RIGHTS] ([MenuCode], [GroupID], [AccessRights]) VALUES (N'mnuCurrency',				0, 1)
INSERT [dbo].[SYS_RIGHTS] ([MenuCode], [GroupID], [AccessRights]) VALUES (N'mnuCustomer',				0, 1)
INSERT [dbo].[SYS_RIGHTS] ([MenuCode], [GroupID], [AccessRights]) VALUES (N'mnuCustomerGroup',			0, 1)
INSERT [dbo].[SYS_RIGHTS] ([MenuCode], [GroupID], [AccessRights]) VALUES (N'mnuCustomerType',			0, 1)
INSERT [dbo].[SYS_RIGHTS] ([MenuCode], [GroupID], [AccessRights]) VALUES (N'mnuProductType',			0, 1)
INSERT [dbo].[SYS_RIGHTS] ([MenuCode], [GroupID], [AccessRights]) VALUES (N'mnuProductGroup',			0, 1)
INSERT [dbo].[SYS_RIGHTS] ([MenuCode], [GroupID], [AccessRights]) VALUES (N'mnuProductCat',				0, 1)
INSERT [dbo].[SYS_RIGHTS] ([MenuCode], [GroupID], [AccessRights]) VALUES (N'mnuShop',					0, 1)
INSERT [dbo].[SYS_RIGHTS] ([MenuCode], [GroupID], [AccessRights]) VALUES (N'mnuCounter',				0, 1)
INSERT [dbo].[SYS_RIGHTS] ([MenuCode], [GroupID], [AccessRights]) VALUES (N'mnuStalls',					0, 1)
INSERT [dbo].[SYS_RIGHTS] ([MenuCode], [GroupID], [AccessRights]) VALUES (N'mnuEmployee',				0, 1)
INSERT [dbo].[SYS_RIGHTS] ([MenuCode], [GroupID], [AccessRights]) VALUES (N'mnuUser',					0, 1)
INSERT [dbo].[SYS_RIGHTS] ([MenuCode], [GroupID], [AccessRights]) VALUES (N'mnuUserGroup',				0, 1)
INSERT [dbo].[SYS_RIGHTS] ([MenuCode], [GroupID], [AccessRights]) VALUES (N'mnuUnitSell',				0, 1)
INSERT [dbo].[SYS_RIGHTS] ([MenuCode], [GroupID], [AccessRights]) VALUES (N'mnuUnitWeight',				0, 1)
INSERT [dbo].[SYS_RIGHTS] ([MenuCode], [GroupID], [AccessRights]) VALUES (N'mnuUnitIn',					0, 1)
INSERT [dbo].[SYS_RIGHTS] ([MenuCode], [GroupID], [AccessRights]) VALUES (N'mnuQueryInStockCounter',	0, 1)
INSERT [dbo].[SYS_RIGHTS] ([MenuCode], [GroupID], [AccessRights]) VALUES (N'mnuQueryInfoProduct',		0, 1)
INSERT [dbo].[SYS_RIGHTS] ([MenuCode], [GroupID], [AccessRights]) VALUES (N'mnuQueryTransaction',		0, 1)
INSERT [dbo].[SYS_RIGHTS] ([MenuCode], [GroupID], [AccessRights]) VALUES (N'mnuGrpUser',				0, 1)
INSERT [dbo].[SYS_RIGHTS] ([MenuCode], [GroupID], [AccessRights]) VALUES (N'mnuGrpConfig',				0, 1)
INSERT [dbo].[SYS_RIGHTS] ([MenuCode], [GroupID], [AccessRights]) VALUES (N'mnuAccessRights',			0, 1)
INSERT [dbo].[SYS_RIGHTS] ([MenuCode], [GroupID], [AccessRights]) VALUES (N'mnuCustomerService',		0, 1)
INSERT [dbo].[SYS_RIGHTS] ([MenuCode], [GroupID], [AccessRights]) VALUES (N'mnuProductUpdateRate',		0, 1)
INSERT [dbo].[SYS_RIGHTS] ([MenuCode], [GroupID], [AccessRights]) VALUES (N'mnuLogin',					0, 1)
INSERT [dbo].[SYS_RIGHTS] ([MenuCode], [GroupID], [AccessRights]) VALUES (N'mnuPasswordChange',			0, 1)
INSERT [dbo].[SYS_RIGHTS] ([MenuCode], [GroupID], [AccessRights]) VALUES (N'mnuPasswordReset',			0, 1)
INSERT [dbo].[SYS_RIGHTS] ([MenuCode], [GroupID], [AccessRights]) VALUES (N'mnuAccountUpdate',			0, 1)
INSERT [dbo].[SYS_RIGHTS] ([MenuCode], [GroupID], [AccessRights]) VALUES (N'mnuAccountBlock',			0, 1)
INSERT [dbo].[SYS_RIGHTS] ([MenuCode], [GroupID], [AccessRights]) VALUES (N'mnuConfigDatabase',			0, 1)


INSERT [dbo].[SYS_RIGHTS] ([MenuCode], [GroupID], [AccessRights]) VALUES (N'mnuRootProduct',			1, 0)
INSERT [dbo].[SYS_RIGHTS] ([MenuCode], [GroupID], [AccessRights]) VALUES (N'mnuRootCounter',			1, 0)
INSERT [dbo].[SYS_RIGHTS] ([MenuCode], [GroupID], [AccessRights]) VALUES (N'mnuRootCategory',			1, 0)
INSERT [dbo].[SYS_RIGHTS] ([MenuCode], [GroupID], [AccessRights]) VALUES (N'mnuRootQuery',				1, 0)
INSERT [dbo].[SYS_RIGHTS] ([MenuCode], [GroupID], [AccessRights]) VALUES (N'mnuRootSystem',				1, 0)
INSERT [dbo].[SYS_RIGHTS] ([MenuCode], [GroupID], [AccessRights]) VALUES (N'mnuRootSkins',				1, 0)
INSERT [dbo].[SYS_RIGHTS] ([MenuCode], [GroupID], [AccessRights]) VALUES (N'mnuProductIn',				1, 0)
INSERT [dbo].[SYS_RIGHTS] ([MenuCode], [GroupID], [AccessRights]) VALUES (N'mnuProductOut',				1, 0)
INSERT [dbo].[SYS_RIGHTS] ([MenuCode], [GroupID], [AccessRights]) VALUES (N'mnuProductTransfer',		1, 0)
INSERT [dbo].[SYS_RIGHTS] ([MenuCode], [GroupID], [AccessRights]) VALUES (N'mnuProductSell',			1, 0)
INSERT [dbo].[SYS_RIGHTS] ([MenuCode], [GroupID], [AccessRights]) VALUES (N'mnuCounterInOut',			1, 0)
INSERT [dbo].[SYS_RIGHTS] ([MenuCode], [GroupID], [AccessRights]) VALUES (N'mnuCounterTransfer',		1, 0)
INSERT [dbo].[SYS_RIGHTS] ([MenuCode], [GroupID], [AccessRights]) VALUES (N'mnuCounterOpenClose',		1, 0)
INSERT [dbo].[SYS_RIGHTS] ([MenuCode], [GroupID], [AccessRights]) VALUES (N'mnuGrpEmployee',			1, 0)
INSERT [dbo].[SYS_RIGHTS] ([MenuCode], [GroupID], [AccessRights]) VALUES (N'mnuGrpUnit',				1, 0)
INSERT [dbo].[SYS_RIGHTS] ([MenuCode], [GroupID], [AccessRights]) VALUES (N'mnuGrpCustomer',			1, 0)
INSERT [dbo].[SYS_RIGHTS] ([MenuCode], [GroupID], [AccessRights]) VALUES (N'mnuGrpShop',				1, 0)
INSERT [dbo].[SYS_RIGHTS] ([MenuCode], [GroupID], [AccessRights]) VALUES (N'mnuGrpProduct',				1, 0)
INSERT [dbo].[SYS_RIGHTS] ([MenuCode], [GroupID], [AccessRights]) VALUES (N'mnuSupplier',				1, 0)
INSERT [dbo].[SYS_RIGHTS] ([MenuCode], [GroupID], [AccessRights]) VALUES (N'mnuCurrency',				1, 0)
INSERT [dbo].[SYS_RIGHTS] ([MenuCode], [GroupID], [AccessRights]) VALUES (N'mnuCustomer',				1, 0)
INSERT [dbo].[SYS_RIGHTS] ([MenuCode], [GroupID], [AccessRights]) VALUES (N'mnuCustomerGroup',			1, 0)
INSERT [dbo].[SYS_RIGHTS] ([MenuCode], [GroupID], [AccessRights]) VALUES (N'mnuCustomerType',			1, 0)
INSERT [dbo].[SYS_RIGHTS] ([MenuCode], [GroupID], [AccessRights]) VALUES (N'mnuProductType',			1, 0)
INSERT [dbo].[SYS_RIGHTS] ([MenuCode], [GroupID], [AccessRights]) VALUES (N'mnuProductGroup',			1, 0)
INSERT [dbo].[SYS_RIGHTS] ([MenuCode], [GroupID], [AccessRights]) VALUES (N'mnuProductCat',				1, 0)
INSERT [dbo].[SYS_RIGHTS] ([MenuCode], [GroupID], [AccessRights]) VALUES (N'mnuShop',					1, 0)
INSERT [dbo].[SYS_RIGHTS] ([MenuCode], [GroupID], [AccessRights]) VALUES (N'mnuCounter',				1, 0)
INSERT [dbo].[SYS_RIGHTS] ([MenuCode], [GroupID], [AccessRights]) VALUES (N'mnuStalls',					1, 0)
INSERT [dbo].[SYS_RIGHTS] ([MenuCode], [GroupID], [AccessRights]) VALUES (N'mnuEmployee',				1, 0)
INSERT [dbo].[SYS_RIGHTS] ([MenuCode], [GroupID], [AccessRights]) VALUES (N'mnuUser',					1, 0)
INSERT [dbo].[SYS_RIGHTS] ([MenuCode], [GroupID], [AccessRights]) VALUES (N'mnuUserGroup',				1, 0)
INSERT [dbo].[SYS_RIGHTS] ([MenuCode], [GroupID], [AccessRights]) VALUES (N'mnuUnitSell',				1, 0)
INSERT [dbo].[SYS_RIGHTS] ([MenuCode], [GroupID], [AccessRights]) VALUES (N'mnuUnitWeight',				1, 0)
INSERT [dbo].[SYS_RIGHTS] ([MenuCode], [GroupID], [AccessRights]) VALUES (N'mnuUnitIn',					1, 0)
INSERT [dbo].[SYS_RIGHTS] ([MenuCode], [GroupID], [AccessRights]) VALUES (N'mnuQueryInStockCounter',	1, 0)
INSERT [dbo].[SYS_RIGHTS] ([MenuCode], [GroupID], [AccessRights]) VALUES (N'mnuQueryInfoProduct',		1, 0)
INSERT [dbo].[SYS_RIGHTS] ([MenuCode], [GroupID], [AccessRights]) VALUES (N'mnuQueryTransaction',		1, 0)
INSERT [dbo].[SYS_RIGHTS] ([MenuCode], [GroupID], [AccessRights]) VALUES (N'mnuGrpUser',				1, 0)
INSERT [dbo].[SYS_RIGHTS] ([MenuCode], [GroupID], [AccessRights]) VALUES (N'mnuGrpConfig',				1, 0)
INSERT [dbo].[SYS_RIGHTS] ([MenuCode], [GroupID], [AccessRights]) VALUES (N'mnuAccessRights',			1, 0)
INSERT [dbo].[SYS_RIGHTS] ([MenuCode], [GroupID], [AccessRights]) VALUES (N'mnuCustomerService',		1, 0)
INSERT [dbo].[SYS_RIGHTS] ([MenuCode], [GroupID], [AccessRights]) VALUES (N'mnuProductUpdateRate',		1, 0)
INSERT [dbo].[SYS_RIGHTS] ([MenuCode], [GroupID], [AccessRights]) VALUES (N'mnuLogin',					1, 0)
INSERT [dbo].[SYS_RIGHTS] ([MenuCode], [GroupID], [AccessRights]) VALUES (N'mnuPasswordChange',			1, 0)
INSERT [dbo].[SYS_RIGHTS] ([MenuCode], [GroupID], [AccessRights]) VALUES (N'mnuPasswordReset',			1, 0)
INSERT [dbo].[SYS_RIGHTS] ([MenuCode], [GroupID], [AccessRights]) VALUES (N'mnuAccountUpdate',			1, 0)
INSERT [dbo].[SYS_RIGHTS] ([MenuCode], [GroupID], [AccessRights]) VALUES (N'mnuAccountBlock',			1, 0)
INSERT [dbo].[SYS_RIGHTS] ([MenuCode], [GroupID], [AccessRights]) VALUES (N'mnuConfigDatabase',			1, 0)
--SELECT * FROM SYS_RIGHTS
GO
--=========================================================================================================================================================
--=========================================================================================================================================================
-- Danh sách trạng thái
DELETE FROM SYS_STATUS
GO
INSERT [dbo].[SYS_STATUS] ([StatusObject], [StatusCode], [StatusName], [Notes], [IsActive]) VALUES (N'TRN_PRODUCT_IN',			'S', N'Lưu tạm',	N'Giao dịch nhập hàng',			1)
INSERT [dbo].[SYS_STATUS] ([StatusObject], [StatusCode], [StatusName], [Notes], [IsActive]) VALUES (N'TRN_PRODUCT_IN',			'C', N'Hoàn tất',	N'Giao dịch nhập hàng',			1)
INSERT [dbo].[SYS_STATUS] ([StatusObject], [StatusCode], [StatusName], [Notes], [IsActive]) VALUES (N'TRN_PRODUCT_OUT',			'S', N'Lưu tạm',	N'Giao dịch xuất hàng',			1)
INSERT [dbo].[SYS_STATUS] ([StatusObject], [StatusCode], [StatusName], [Notes], [IsActive]) VALUES (N'TRN_PRODUCT_OUT',			'C', N'Hoàn tất',	N'Giao dịch xuất hàng',			1)
INSERT [dbo].[SYS_STATUS] ([StatusObject], [StatusCode], [StatusName], [Notes], [IsActive]) VALUES (N'TRN_PRODUCT_SELL',		'S', N'Lưu tạm',	N'Giao dịch bán hàng',			1)
INSERT [dbo].[SYS_STATUS] ([StatusObject], [StatusCode], [StatusName], [Notes], [IsActive]) VALUES (N'TRN_PRODUCT_SELL',		'C', N'Hoàn tất',	N'Giao dịch bán hàng',			1)
INSERT [dbo].[SYS_STATUS] ([StatusObject], [StatusCode], [StatusName], [Notes], [IsActive]) VALUES (N'TRN_PRODUCT_TRANSFER',	'S', N'Lưu tạm',	N'Giao dịch chuyển hàng',		1)
INSERT [dbo].[SYS_STATUS] ([StatusObject], [StatusCode], [StatusName], [Notes], [IsActive]) VALUES (N'TRN_PRODUCT_TRANSFER',	'C', N'Hoàn tất',	N'Giao dịch chuyển hàng',		1)
INSERT [dbo].[SYS_STATUS] ([StatusObject], [StatusCode], [StatusName], [Notes], [IsActive]) VALUES (N'TRN_COUNTER_INOUT',		'S', N'Lưu tạm',	N'Giao dịch thu chi tại quầy',	1)
INSERT [dbo].[SYS_STATUS] ([StatusObject], [StatusCode], [StatusName], [Notes], [IsActive]) VALUES (N'TRN_COUNTER_INOUT',		'C', N'Hoàn tất',	N'Giao dịch thu chi tại quầy',	1)
INSERT [dbo].[SYS_STATUS] ([StatusObject], [StatusCode], [StatusName], [Notes], [IsActive]) VALUES (N'TRN_COUNTER_TRANSFER',	'S', N'Lưu tạm',	N'Giao dịch chuyển quầy',		1)
INSERT [dbo].[SYS_STATUS] ([StatusObject], [StatusCode], [StatusName], [Notes], [IsActive]) VALUES (N'TRN_COUNTER_TRANSFER',	'C', N'Hoàn tất',	N'Giao dịch chuyển quầy',		1)
INSERT [dbo].[SYS_STATUS] ([StatusObject], [StatusCode], [StatusName], [Notes], [IsActive]) VALUES (N'OBJ_PRODUCT',				'I', N'Còn tồn',	N'Hàng hóa',					1)
INSERT [dbo].[SYS_STATUS] ([StatusObject], [StatusCode], [StatusName], [Notes], [IsActive]) VALUES (N'OBJ_PRODUCT',				'O', N'Đã xuất',	N'Hàng hóa',					1)
INSERT [dbo].[SYS_STATUS] ([StatusObject], [StatusCode], [StatusName], [Notes], [IsActive]) VALUES (N'OBJ_PRODUCT',				'S', N'Đã bán',		N'Hàng hóa',					1)
INSERT [dbo].[SYS_STATUS] ([StatusObject], [StatusCode], [StatusName], [Notes], [IsActive]) VALUES (N'CAT_COUNTER',				'O', N'Đang mở',	N'Quầy thu ngân',				1)
INSERT [dbo].[SYS_STATUS] ([StatusObject], [StatusCode], [StatusName], [Notes], [IsActive]) VALUES (N'CAT_COUNTER',				'C', N'Đã đóng',	N'Quầy thu ngân',				1)
--SELECT * FROM SYS_STATUS
GO
--=========================================================================================================================================================
--=========================================================================================================================================================
-- Cấu hình phát sinh mã
DELETE FROM SYS_GENCODE
GO
INSERT INTO [dbo].[SYS_GENCODE]([TableName], [Prefix], [LengthCode], [FormatCode], [Descriptions]) VALUES ('CAT_COUNTER',				'CT',		0, '', 'CT1,CT2, ... CT10, CT11, ..., CT100, CT101, ...')
INSERT INTO [dbo].[SYS_GENCODE]([TableName], [Prefix], [LengthCode], [FormatCode], [Descriptions]) VALUES ('CAT_CURRENCY',				'CY',		0, '', 'CY1,CY2, ... CY10, CY11, ..., CY100, CY101, ...')
INSERT INTO [dbo].[SYS_GENCODE]([TableName], [Prefix], [LengthCode], [FormatCode], [Descriptions]) VALUES ('CAT_CUSTOMER',				'CS',		0, '', 'CS1,CS2, ... CS10, CS11, ..., CS100, CS101, ...')
INSERT INTO [dbo].[SYS_GENCODE]([TableName], [Prefix], [LengthCode], [FormatCode], [Descriptions]) VALUES ('CAT_CUSTOMERGROUP',			'CG',		0, '', 'CG1,CG2, ... CG10, CG11, ..., CG100, CG101, ...')
INSERT INTO [dbo].[SYS_GENCODE]([TableName], [Prefix], [LengthCode], [FormatCode], [Descriptions]) VALUES ('CAT_CUSTOMERTYPE',			'CT',		0, '', 'CT1,CT2, ... CT10, CT11, ..., CT100, CT101, ...')
INSERT INTO [dbo].[SYS_GENCODE]([TableName], [Prefix], [LengthCode], [FormatCode], [Descriptions]) VALUES ('CAT_EMPLOYEE',				'EM',		0, '', 'EM1,EM2, ... EM10, EM11, ..., EM100, EM101, ...')
INSERT INTO [dbo].[SYS_GENCODE]([TableName], [Prefix], [LengthCode], [FormatCode], [Descriptions]) VALUES ('CAT_PRODUCT',				'PC',		0, '', 'PC1,PC2, ... PC10, PC11, ..., PC100, PC101, ...')
INSERT INTO [dbo].[SYS_GENCODE]([TableName], [Prefix], [LengthCode], [FormatCode], [Descriptions]) VALUES ('CAT_PRODUCTTYPE',			'PT',		0, '', 'PT1,PT2, ... PT10, PT11, ..., PT100, PT101, ...')
INSERT INTO [dbo].[SYS_GENCODE]([TableName], [Prefix], [LengthCode], [FormatCode], [Descriptions]) VALUES ('CAT_PRODUCTGROUP',			'PG',		0, '', 'PG1,PG2, ... PG10, PG11, ..., PG100, PG101, ...')
INSERT INTO [dbo].[SYS_GENCODE]([TableName], [Prefix], [LengthCode], [FormatCode], [Descriptions]) VALUES ('CAT_SHOP',					'SH',		0, '', 'SH1,SH2, ... SH10, SH11, ..., SH100, SH101, ...')
INSERT INTO [dbo].[SYS_GENCODE]([TableName], [Prefix], [LengthCode], [FormatCode], [Descriptions]) VALUES ('CAT_STALLS',				'ST',		0, '', 'ST1,ST2, ... ST10, ST11, ..., ST100, ST101, ...')
INSERT INTO [dbo].[SYS_GENCODE]([TableName], [Prefix], [LengthCode], [FormatCode], [Descriptions]) VALUES ('CAT_SUPPLIER',				'SL',		0, '', 'SL1,SL2, ... SL10, SL11, ..., SL100, SL101, ...')
INSERT INTO [dbo].[SYS_GENCODE]([TableName], [Prefix], [LengthCode], [FormatCode], [Descriptions]) VALUES ('CAT_UNIT_IN',				'UI',		0, '', 'UI1,UI2, ... UI10, UI11, ..., UI100, UI101, ...')
INSERT INTO [dbo].[SYS_GENCODE]([TableName], [Prefix], [LengthCode], [FormatCode], [Descriptions]) VALUES ('CAT_UNIT_WEIGHT',			'UW',		0, '', 'UW1,UW2, ... UW10, UW11, ..., UW100, UW101, ...')
INSERT INTO [dbo].[SYS_GENCODE]([TableName], [Prefix], [LengthCode], [FormatCode], [Descriptions]) VALUES ('CAT_USERGROUP',				'UG',		0, '', 'UG1,UG2, ... UG10, UG11, ..., UG100, UG101, ...')

INSERT INTO [dbo].[SYS_GENCODE]([TableName], [Prefix], [LengthCode], [FormatCode], [Descriptions]) VALUES ('TRN_COUNTER_INOUT',			'TCIO-',	8, '', 'TCIO-00000001, TCIO-00000002, ... TCIO-00000010, TCIO-00000011, ..., TCIO-00000100, TCIO-00000101, ...')
INSERT INTO [dbo].[SYS_GENCODE]([TableName], [Prefix], [LengthCode], [FormatCode], [Descriptions]) VALUES ('TRN_COUNTER_TRANSFER',		'TCTF-',	8, '', 'TCTF-00000001, TCTF-00000002, ... TCTF-00000010, TCTF-00000011, ..., TCTF-00000100, TCTF-00000101, ...')
INSERT INTO [dbo].[SYS_GENCODE]([TableName], [Prefix], [LengthCode], [FormatCode], [Descriptions]) VALUES ('TRN_PRODUCT_IN',			'TPDI-',	8, '', 'TPDI-00000001, TPDI-00000002, ... TPDI-00000010, TPDI-00000011, ..., TPDI-00000100, TPDI-00000101, ...')
INSERT INTO [dbo].[SYS_GENCODE]([TableName], [Prefix], [LengthCode], [FormatCode], [Descriptions]) VALUES ('TRN_PRODUCT_OUT',			'TPDO-',	8, '', 'TPDO-00000001, TPDO-00000002, ... TPDO-00000010, TPDO-00000011, ..., TPDO-00000100, TPDO-00000101, ...')
INSERT INTO [dbo].[SYS_GENCODE]([TableName], [Prefix], [LengthCode], [FormatCode], [Descriptions]) VALUES ('TRN_PRODUCT_SELL',			'TPDS-',	8, '', 'TPDS-00000001, TPDS-00000002, ... TPDS-00000010, TPDS-00000011, ..., TPDS-00000100, TPDS-00000101, ...')
INSERT INTO [dbo].[SYS_GENCODE]([TableName], [Prefix], [LengthCode], [FormatCode], [Descriptions]) VALUES ('TRN_PRODUCT_TRANSFER',		'TPDT-',	8, '', 'TPDT-00000001, TPDT-00000002, ... TPDT-00000010, TPDT-00000011, ..., TPDT-00000100, TPDT-00000101, ...')

INSERT INTO [dbo].[SYS_GENCODE]([TableName], [Prefix], [LengthCode], [FormatCode], [Descriptions]) VALUES ('OBJ_PRODUCT',				'PD-',		4, '<CAT_PRODUCTGROUP>-<CAT_PRODUCTTYPE>-', 'PR-PT1-PG1-0001, PR-PT1-PG1-0002, ... PR-PT1-PG1-0010, PR-PT1-PG1-0011, ..., PR-PT1-PG1-0100, PR-PT1-PG1-0101 ...')
GO
--=========================================================================================================================================================
--=========================================================================================================================================================
-- Cấu hình phát sinh mã
DELETE FROM SYS_GENCODE_AUTOINCREMENT
GO
INSERT INTO [dbo].[SYS_GENCODE_AUTOINCREMENT]([TableName], [CurrentID]) VALUES ('OBJ_PRODUCT',	0)
INSERT INTO [dbo].[SYS_GENCODE_AUTOINCREMENT]([TableName], [CurrentID]) VALUES ('TRN_PRODUCT_IN',	0)
INSERT INTO [dbo].[SYS_GENCODE_AUTOINCREMENT]([TableName], [CurrentID]) VALUES ('TRN_PRODUCT_OUT',	0)
GO
--=========================================================================================================================================================
--=========================================================================================================================================================
EXEC sp_msforeachtable "ALTER TABLE ? WITH CHECK CHECK CONSTRAINT all"
GO	