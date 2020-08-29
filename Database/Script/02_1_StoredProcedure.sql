IF EXISTS(SELECT * FROM SYS.DATABASES WHERE NAME = 'PTTKPMCRM')
BEGIN
	USE PTTKPMCRM
END
GO
--=========================================================================================================================================================
--=========================================================================================================================================================
IF EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[LoadDataCombobox]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[LoadDataCombobox]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[LoadDataCombobox]
	@pType varchar(100) = '',
	@pOption bigint = -1
AS
	IF(@pType = 'CNT')
	BEGIN
		SELECT *
		FROM (
			SELECT CNT.[ID] AS CounterID,
			       CNT.[CounterCode],
				   CNT.[CounterName],
				   SHP.[ShopName],
				   CNT.OrderBy
			FROM CAT_COUNTER CNT
				 LEFT JOIN CAT_SHOP SHP ON SHP.ID = CNT.ShopID
			WHERE CNT.[IsActive] = 1 AND CNT.[IsDelete] = 0
				  AND (CNT.ShopID = @pOption OR @pOption = -1 OR @pOption IS NULL) 					
			UNION
			SELECT -1, '', '', '', -1
			) TMP
		ORDER BY TMP.OrderBy
	END
	ELSE IF(@pType = 'CRC')
	BEGIN
		SELECT *
		FROM (		
			SELECT CRC.[ID] AS CurrencyID,
			       CRC.[CurrencyCode],
				   CRC.[CurrencyDesc],
				   CRC.OrderBy
			FROM CAT_CURRENCY CRC
			WHERE CRC.[IsActive] = 1 AND CRC.[IsDelete] = 0
			UNION
			SELECT -1, '', '' , -1
			) TMP
		ORDER BY TMP.OrderBy
	END
	ELSE IF(@pType = 'CUS')
	BEGIN
		SELECT *
		FROM (	
			SELECT CUS.[ID] AS CustID,
				   CUS.[CustCode],
			       CUS.[CustName],
				   CUS.[Phone],
				   CUS.[CustAddress],
				   CUS.OrderBy
			FROM CAT_CUSTOMER CUS
			WHERE CUS.[IsActive] = 1 AND CUS.[IsDelete] = 0
			UNION
			SELECT -1, '', '', '', '' , -1
			) TMP
		ORDER BY TMP.OrderBy
	END
	ELSE IF(@pType = 'CUSG')
	BEGIN
		SELECT *
		FROM (	
			SELECT CUSG.[ID] AS CustGroupID,
			       CUSG.[CustGroupCode],
				   CUSG.[CustGroupName],
				   CUSG.OrderBy
			FROM CAT_CUSTOMERGROUP CUSG
			WHERE CUSG.[IsActive] = 1 AND CUSG.[IsDelete] = 0
			UNION
			SELECT -1, '', '' , -1
			) TMP
		ORDER BY TMP.OrderBy
	END
	ELSE IF(@pType = 'CUST')
	BEGIN
		SELECT *
		FROM (	
			SELECT CUST.[ID] AS CustTypeID,
			       CUST.[CustTypeCode],
				   CUST.[CustTypeName],
				   CUST.OrderBy
			FROM CAT_CUSTOMERTYPE CUST
			WHERE CUST.[IsActive] = 1 AND CUST.[IsDelete] = 0
			UNION
			SELECT -1, '', '' , -1
			) TMP
		ORDER BY TMP.OrderBy
	END
	ELSE IF(@pType = 'EMP')
	BEGIN
		SELECT *
		FROM (	
			SELECT EMP.[ID] AS EmpID,
			       EMP.[EmpCode],
				   EMP.[EmpName],
				   SHP.[ShopName],
				   EMP.OrderBy
			FROM CAT_EMPLOYEE EMP
				 LEFT JOIN CAT_SHOP SHP ON SHP.ID = EMP.ShopID
			WHERE EMP.[IsActive] = 1 AND EMP.[IsDelete] = 0
				  AND (EMP.ShopID = @pOption OR @pOption = -1 OR @pOption IS NULL) 
			UNION
			SELECT -1, '', '', '' , -1
			) TMP
		ORDER BY TMP.OrderBy
	END
	ELSE IF(@pType = 'PRC')
	BEGIN
		SELECT *
		FROM (	
			SELECT PRC.[ID] AS ProductCatID,
			       PRC.[ProductCatCode],
				   PRC.[ProductCatName],
				   PRC.OrderBy
			FROM CAT_PRODUCT PRC
			WHERE PRC.[IsActive] = 1 AND PRC.[IsDelete] = 0
			UNION
			SELECT -1, '', '' , -1
			) TMP
		ORDER BY TMP.OrderBy
	END
	ELSE IF(@pType = 'PRDG')
	BEGIN
		SELECT *
		FROM (	
			SELECT PRDG.[ID] AS ProductGroupID,
			       PRDG.[ProductGroupCode],
				   PRDG.[ProductGroupName],
				   PRDG.OrderBy
			FROM CAT_PRODUCTGROUP PRDG
			WHERE PRDG.[IsActive] = 1 AND PRDG.[IsDelete] = 0
			UNION
			SELECT -1, '', '' , -1
			) TMP
		ORDER BY TMP.OrderBy
	END
	ELSE IF(@pType = 'PRDT')
	BEGIN
		SELECT *
		FROM (	
			SELECT PRDT.[ID] AS ProductTypeID,
			       PRDT.[ProductTypeCode],
				   PRDT.[ProductTypeName],
				   PRDT.OrderBy
			FROM CAT_PRODUCTTYPE PRDT
			WHERE PRDT.[IsActive] = 1 AND PRDT.[IsDelete] = 0
			UNION
			SELECT -1, '', '' , -1
			) TMP
		ORDER BY TMP.OrderBy
	END
	ELSE IF(@pType = 'SHP')
	BEGIN
		SELECT *
		FROM (	
			SELECT SHP.[ID] AS ShopID,
			       SHP.[ShopCode],
				   SHP.[ShopName],
				   SHP.[ShopAddress],
				   SHP.[ShopTel],
				   SHP.OrderBy
			FROM CAT_SHOP SHP
			WHERE SHP.[IsActive] = 1 AND SHP.[IsDelete] = 0
			UNION
			SELECT -1, '', '', '', '' , -1
			) TMP
		ORDER BY TMP.OrderBy
	END
	ELSE IF(@pType = 'STL')
	BEGIN
		SELECT *
		FROM (	
			SELECT STL.[ID] AS StallsID,
			       STL.[StallsCode],
				   STL.[StallsName],
				   STL.OrderBy
			FROM CAT_STALLS STL
				 LEFT JOIN CAT_SHOP SHP ON SHP.ID = STL.ShopID
			WHERE STL.[IsActive] = 1 AND STL.[IsDelete] = 0
				  AND (STL.ShopID = @pOption OR @pOption = -1 OR @pOption IS NULL) 
			UNION
			SELECT -1, '', '' , -1
			) TMP
		ORDER BY TMP.OrderBy
	END
	ELSE IF(@pType = 'SUP')
	BEGIN
		SELECT *
		FROM (	
			SELECT SUP.[ID] AS SupplierID,
			       SUP.[SupplierCode],
				   SUP.[SupplierName],
				   SUP.[SupplierAddress],
				   SUP.[Phone],
				   SUP.OrderBy
			FROM CAT_SUPPLIER SUP
			WHERE SUP.[IsActive] = 1 AND SUP.[IsDelete] = 0
			UNION
			SELECT -1, '', '', '',  '' , -1
			) TMP
		ORDER BY TMP.OrderBy
	END
	ELSE IF(@pType = 'UNTI')
	BEGIN
		SELECT *
		FROM (	
			SELECT UNTI.[ID] AS UnitInID,
			       UNTI.[UnitInCode],
				   UNTI.[UnitInDesc],
				   UNTI.[ScaleChange],
				   UNTI.OrderBy
			FROM CAT_UNIT_IN UNTI
			WHERE UNTI.[IsActive] = 1 AND UNTI.[IsDelete] = 0
			UNION
			SELECT -1, '',  '' , 0, -1
			) TMP
		ORDER BY TMP.OrderBy
	END
	ELSE IF(@pType = 'UNTS')
	BEGIN
		SELECT *
		FROM (	
			SELECT UNTS.[ID] AS UnitSellID,
			       UNTS.[UnitSellCode],
				   UNTS.[UnitSellDesc],
				   UNTS.OrderBy
			FROM CAT_UNIT_SELL UNTS
			WHERE UNTS.[IsActive] = 1 AND UNTS.[IsDelete] = 0
			UNION
			SELECT -1, '',  '' , -1
			) TMP
		ORDER BY TMP.OrderBy
	END
	ELSE IF(@pType = 'UNTW')
	BEGIN
		SELECT *
		FROM (	
			SELECT UNTW.[ID] AS UnitWeightID,
			       UNTW.[UnitWeightCode],
				   UNTW.[UnitWeightDesc],
				   UNTW.OrderBy
			FROM CAT_UNIT_WEIGHT UNTW
			WHERE UNTW.[IsActive] = 1 AND UNTW.[IsDelete] = 0
			UNION
			SELECT -1, '',  '' , -1
			) TMP
		ORDER BY TMP.OrderBy
	END
	ELSE IF(@pType = 'URSG')
	BEGIN
		SELECT *
		FROM (	
			SELECT URSG.[ID] AS GroupID,
			       URSG.[GroupCode],
				   URSG.[GroupName],
				   URSG.OrderBy
			FROM CAT_USERGROUP URSG
			WHERE URSG.[IsActive] = 1 AND URSG.[IsDelete] = 0
			UNION
			SELECT -1, '',  '' , -1
			) TMP
		ORDER BY TMP.OrderBy
	END
	ELSE IF(@pType = 'URS')
	BEGIN
		SELECT *
		FROM (	
			SELECT URS.[ID] AS UserID,
			       URS.[UserName],
				   SHP.[ShopName],
				   URS.OrderBy
			FROM SYS_USERS URS
				 LEFT JOIN CAT_SHOP SHP ON SHP.ID = URS.ShopID
			WHERE URS.[IsActive] = 1 AND URS.[IsDelete] = 0
			UNION
			SELECT -1, '',  '' , -1
			) TMP
		ORDER BY TMP.OrderBy
	END
	ELSE IF(@pType = 'STATUS_CAT_COUNTER')
	BEGIN
		SELECT STS.StatusCode,
		       STS.StatusName
		FROM SYS_STATUS STS
		WHERE STS.IsActive = 1 AND STS.StatusObject = 'CAT_COUNTER'
	END
	ELSE IF(@pType = 'STATUS_OBJ_PRODUCT')
	BEGIN
		SELECT STS.StatusCode,
		       STS.StatusName
		FROM SYS_STATUS STS
		WHERE STS.IsActive = 1 AND STS.StatusObject = 'OBJ_PRODUCT'
	END
	ELSE IF(@pType = 'STATUS_TRN_COUNTER_INOUT')
	BEGIN
		SELECT STS.StatusCode,
		       STS.StatusName
		FROM SYS_STATUS STS
		WHERE STS.IsActive = 1 AND STS.StatusObject = 'TRN_COUNTER_INOUT'
	END
	ELSE IF(@pType = 'STATUS_TRN_COUNTER_TRANSFER')
	BEGIN
		SELECT STS.StatusCode,
		       STS.StatusName
		FROM SYS_STATUS STS
		WHERE STS.IsActive = 1 AND STS.StatusObject = 'TRN_COUNTER_TRANSFER'
	END
	ELSE IF(@pType = 'STATUS_TRN_PRODUCT_IN')
	BEGIN
		SELECT STS.StatusCode,
		       STS.StatusName
		FROM SYS_STATUS STS
		WHERE STS.IsActive = 1 AND STS.StatusObject = 'TRN_PRODUCT_IN'
	END
	ELSE IF(@pType = 'STATUS_TRN_PRODUCT_OUT')
	BEGIN
		SELECT STS.StatusCode,
		       STS.StatusName
		FROM SYS_STATUS STS
		WHERE STS.IsActive = 1 AND STS.StatusObject = 'TRN_PRODUCT_OUT'
	END
	ELSE IF(@pType = 'STATUS_TRN_PRODUCT_SELL')
	BEGIN
		SELECT STS.StatusCode,
		       STS.StatusName
		FROM SYS_STATUS STS
		WHERE STS.IsActive = 1 AND STS.StatusObject = 'TRN_PRODUCT_SELL'
	END
	ELSE IF(@pType = 'STATUS_TRN_PRODUCT_TRANSFER')
	BEGIN
		SELECT STS.StatusCode,
		       STS.StatusName
		FROM SYS_STATUS STS
		WHERE STS.IsActive = 1 AND STS.StatusObject = 'TRN_PRODUCT_TRANSFER'
	END
GO
--=========================================================================================================================================================
--=========================================================================================================================================================
IF EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SYS_USERS_Search]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[SYS_USERS_Search]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SYS_USERS_Search]
	@p_ID bigint = -1,
	@p_UserName nvarchar(255) = '',
	@p_Password nvarchar(max) = '',
	@p_IsAdmin bigint = -1,
	@p_ShopID bigint = -1,
	@p_OrderBy bigint = -1
AS
	SELECT	URS.ID,
			URS.UserName,
			URS.[Password],
			URS.ShopID,
			SHP.ShopName,
			URS.IsAdmin,
			URS.OrderBy,
			URS.IsActive,
			URS.UpdateDate,
			URS.UpdateBy,
			URSS.UserName AS UserUpdate,
			URS.IsDelete
	FROM dbo.SYS_USERS URS
		 LEFT JOIN dbo.CAT_SHOP SHP ON SHP.ID = URS.ShopID
		 LEFT JOIN dbo.SYS_USERS URSS ON URSS.ID = URS.UpdateBy
	WHERE URS.IsDelete = 0
		  AND (URS.ID = @p_ID OR @p_ID = -1 OR @p_ID IS NULL)
		  AND (URS.UserName = @p_UserName OR @p_UserName = '' OR @p_UserName IS NULL)
		  AND (URS.[Password] = @p_Password OR @p_Password = '' OR @p_Password IS NULL)
		  AND (URS.IsAdmin = @p_IsAdmin OR @p_IsAdmin = -1 OR @p_IsAdmin IS NULL)
		  AND (URS.ShopID = @p_ShopID OR @p_ShopID = -1 OR @p_ShopID IS NULL)
		  AND (URS.OrderBy = @p_OrderBy OR @p_OrderBy = -1 OR @p_OrderBy IS NULL)
GO
--=========================================================================================================================================================
--=========================================================================================================================================================
IF EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SYS_USERS_Login]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[SYS_USERS_Login]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[SYS_USERS_Login]
	@pUserName nvarchar(20) = NULL,
	@pPassword varchar(50) = NULL	
AS
	IF EXISTS(SELECT TOP 1 1 FROM SYS_USERS WHERE UserName = @pUserName AND [Password] = @pPassword AND IsActive = 1)
	BEGIN
		SELECT	1 AS Result,
				N'' AS MsgProcedure,
				USR.ID,
				USR.UserName,
				USR.IsAdmin,
				USR.IsActive,
				ISNULL(EMP.ID, -1) AS EmpID,
				ISNULL(EMP.EmpCode, '') AS EmpCode,
				ISNULL(EMP.EmpName, '') AS EmpName,
				ISNULL(CNTL.CounterID, -1) AS CounterID,
				ISNULL(CNT.CounterCode, '') AS CounterCode,
				ISNULL(CNT.CounterName, '') AS CounterName,
				ISNULL(SHP.ID, -1) AS ShopID,
				ISNULL(SHP.ShopCode, '') AS ShopCode,
				ISNULL(SHP.ShopName, '') AS ShopName
		FROM SYS_USERS USR
			 LEFT JOIN CAT_EMPLOYEE EMP ON EMP.UserID = USR.ID
			 LEFT JOIN CAT_COUNTER_LOG CNTL ON CNTL.EmpID = EMP.ID
			 LEFT JOIN CAT_COUNTER CNT ON CNT.ID = CNTL.CounterID
			 LEFT JOIN CAT_SHOP SHP ON SHP.ID = EMP.ShopID
		WHERE UserName = @pUserName 
	END
	ELSE
	BEGIN
		SELECT	0 AS Result,
				N'Đăng nhập thất bại' AS MsgProcedure,
				-1 AS ID,
				'' AS UserName,
				'' AS IsAdmin,
				'' AS IsActive,
				-1 AS EmpID,
				'' AS EmpCode,
				'' AS EmpName,
				-1 AS CounterID,
				'' AS CounterCode,
				'' AS CounterName,
				-1 AS ShopID,
				'' AS ShopCode,
				'' AS ShopName
	END
GO
--=========================================================================================================================================================
--=========================================================================================================================================================
IF EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SYS_USERS_GetAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[SYS_USERS_GetAll]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SYS_USERS_GetAll]
AS
	SELECT	URS.ID,
			URS.UserName,
			URS.[Password],
			URS.ShopID,
			SHP.ShopName,
			URS.IsAdmin,
			URS.OrderBy,
			URS.IsActive,
			URS.UpdateDate,
			URS.UpdateBy,
			URSS.UserName AS UserUpdate,
			URS.IsDelete
	FROM dbo.SYS_USERS URS
		 LEFT JOIN dbo.CAT_SHOP SHP ON SHP.ID = URS.ShopID
		 LEFT JOIN dbo.SYS_USERS URSS ON URSS.ID = URS.UpdateBy
	WHERE URS.IsDelete = 0
GO
--=========================================================================================================================================================
--=========================================================================================================================================================
IF EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SYS_USERS_ChangePassword]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[SYS_USERS_ChangePassword]
GO
CREATE PROCEDURE [dbo].[SYS_USERS_ChangePassword]
	@pUserName nvarchar(255) = '',
	@pOldPass varchar(255) = '',
	@pNewPass varchar(255) = ''
AS
BEGIN TRANSACTION
	DECLARE @vMessage nvarchar(max)
	SET @vMessage = ''

	IF EXISTS (SELECT TOP 1 1  FROM [SYS_USERS] WHERE [UserName] = @pUserName AND [Password] = @pOldPass)
	BEGIN
		UPDATE [dbo].[SYS_USERS]
		SET [Password] = @pNewPass
		WHERE [UserName] = @pUserName
		IF @@Error <> 0 GOTO ABORT
	END
	ELSE
	BEGIN
		SET @vMessage = N'Tên đăng nhập, Mật khẩu cũ không hợp lệ!'
		GOTO ABORT
	END

COMMIT TRANSACTION
	SELECT 1 AS Result, @vMessage AS MsgProcedure
	RETURN 1
ABORT:
BEGIN
	ROLLBACK TRANSACTION
	IF(@vMessage = '')
	BEGIN
		SET @vMessage = N'Đổi mật khẩu thất bại!'
	END
	SELECT 0 AS Result, @vMessage AS MsgProcedure
	RETURN 0
END
GO
--=========================================================================================================================================================
--=========================================================================================================================================================
IF EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SYS_RIGHTS_GetAccessRights]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[SYS_RIGHTS_GetAccessRights]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[SYS_RIGHTS_GetAccessRights]
	@p_UserID bigint = -1
AS
	SELECT	MNU.MenuCode
	FROM SYS_MENUS MNU
		 RIGHT JOIN SYS_RIGHTS RIG ON MNU.MenuCode = RIG.MenuCode
		 LEFT JOIN CAT_USERGROUP USRG ON USRG.ID = RIG.GroupID
	WHERE MNU.IsActive = 1
		  AND USRG.ID = @p_UserID
		  AND RIG.AccessRights = 1
	ORDER BY MNU.OrderBy
GO

--=========================================================================================================================================================
--=========================================================================================================================================================
IF EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SYS_RIGHTS_UpdAccessRights]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[SYS_RIGHTS_UpdAccessRights]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SYS_RIGHTS_UpdAccessRights]
	@p_Menus xml = NULL
AS
BEGIN TRANSACTION
	DECLARE @vMessage nvarchar(max)
	SET @vMessage = ''

	DECLARE @tblAccessRights TABLE(MenuCode varchar(100),
								   GroupID bigint,
								   MenuDesc nvarchar(max),
								   MenuParent varchar(100),
								   AccessRights tinyint,
								   CheckState varchar(100))
	INSERT INTO @tblAccessRights SELECT	Tbl.Col.value('(MenuCode/text())[1]', 'varchar(100)') AS MenuCode,	
										Tbl.Col.value('(GroupID/text())[1]', 'bigint') AS GroupID,
										Tbl.Col.value('(MenuDesc/text())[1]', 'nvarchar(max)') AS MenuDesc,	
										Tbl.Col.value('(MenuParent/text())[1]', 'varchar(100)') AS MenuCode,																
										Tbl.Col.value('(AccessRights/text())[1]', 'tinyint') AS AccessRights,
										Tbl.Col.value('(CheckState/text())[1]', 'varchar(100)') AS CheckState
						   FROM @p_Menus.nodes('//MENU') AS Tbl(Col)

	UPDATE SYS_RIGHTS
	SET AccessRights = tmp.AccessRights 
	FROM @tblAccessRights AS tmp
	WHERE	SYS_RIGHTS.MenuCode = tmp.MenuCode 
			AND SYS_RIGHTS.GroupID = tmp.GroupID
	IF @@Error <> 0 GOTO ABORT 

COMMIT TRANSACTION
	SELECT 1 AS Result, @vMessage AS MsgProcedure
	RETURN 1
ABORT:
BEGIN
	ROLLBACK TRANSACTION
	IF(@vMessage = '')
	BEGIN
		SET @vMessage = N'Thao tác thất bại!'
	END
	SELECT 0 AS Result, @vMessage AS MsgProcedure
	RETURN 0
END
GO
--=========================================================================================================================================================
--=========================================================================================================================================================
IF EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SYS_MENUS_GetAccessRights]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[SYS_MENUS_GetAccessRights]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[SYS_MENUS_GetAccessRights]
	@p_GroupID bigint = -1
AS
	SELECT	MNU.MenuCode,
			RIG.GroupID,
			MNU.MenuDesc,
			MNU.MenuParent,
			RIG.AccessRights,		
			CASE RIG.AccessRights WHEN 0 THEN "Unchecked" 
								  WHEN 1 THEN "Checked"
			ELSE "Indeterminate" 
			END CheckState
	FROM SYS_MENUS MNU
		 RIGHT JOIN SYS_RIGHTS RIG ON MNU.MenuCode = RIG.MenuCode
	WHERE MNU.IsActive = 1
		  AND RIG.GroupID = @p_GroupID
	ORDER BY OrderBy
GO
--=========================================================================================================================================================
--=========================================================================================================================================================
IF EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SYS_GENCODE_GetCurrentID]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[SYS_GENCODE_GetCurrentID]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[SYS_GENCODE_GetCurrentID]
	@p_TableName varchar(100)
AS	
	SELECT	TBL.[Name] AS TableName,
			PTT.[Rows] AS RowCounts
	INTO #temp
	FROM sys.tables TBL
		 INNER JOIN sys.partitions PTT ON TBL.object_id = PTT.OBJECT_ID 
	WHERE TBL.[Name] NOT LIKE 'dt%' 
		  AND TBL.is_ms_shipped = 0
	      AND PTT.[Rows] = 0
	GROUP BY TBL.[Name], PTT.[Rows]
	ORDER BY TBL.[Name]

	IF @p_TableName = 'OBJ_PRODUCT'
	BEGIN
		SELECT COUNT(ProductCode) AS CurrentID FROM TRN_PRODUCT_IN_DT
	END
	ELSE
	BEGIN
		IF IDENT_CURRENT(@p_TableName) = 0
		BEGIN
			IF EXISTS (SELECT TOP 1 1 FROM #temp WHERE TableName = @p_TableName)
			BEGIN
				SELECT 0 AS CurrentID
			END
			ELSE
			BEGIN
				SELECT 1 AS CurrentID
			END
		END
		ELSE
		BEGIN
			SELECT IDENT_CURRENT(@p_TableName) + 1 AS CurrentID
		END
	END
GO
--=========================================================================================================================================================
--=========================================================================================================================================================
IF EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SYS_GENCODE_Get]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[SYS_GENCODE_Get]
GO
CREATE PROCEDURE [dbo].[SYS_GENCODE_Get]
	@p_TableName varchar(100),
	@p_CurrentID bigint,
	@p_ProductTypeID bigint,
	@p_ProductGroupID bigint
AS
	DECLARE @identCur int	

	IF @p_TableName = 'OBJ_PRODUCT'
	BEGIN
		SELECT dbo.fn_GenCodeProduct(@p_TableName, @p_CurrentID, @p_ProductTypeID, @p_ProductGroupID) AS CodeGen
	END
	ELSE
	BEGIN
		SELECT dbo.fn_GenCode(@p_TableName, @p_CurrentID) AS CodeGen
	END
GO
--=========================================================================================================================================================
--=========================================================================================================================================================
IF EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CAT_USERGROUP_Del]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[CAT_USERGROUP_Del]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CAT_USERGROUP_Del]
	@p_ID bigint = -1,
	@p_UpdateBy bigint = -1
AS
BEGIN TRANSACTION
	DECLARE @vMessage nvarchar(max)
	SET @vMessage = ''

	UPDATE CAT_USERGROUP
	SET IsDelete = 1,
		UpdateBy = @p_UpdateBy,
		UpdateDate = GETDATE()
	WHERE ID = @p_ID
	IF @@Error <> 0 GOTO ABORT

COMMIT TRANSACTION
	SELECT 1 AS Result, @vMessage AS MsgProcedure
	RETURN 1
ABORT:
BEGIN
	ROLLBACK TRANSACTION
	IF(@vMessage = '')
	BEGIN
		SET @vMessage = N'Thao tác thất bại'
	END
	SELECT 0 AS Result, @vMessage AS MsgProcedure
	RETURN 0
END
GO
--=========================================================================================================================================================
--=========================================================================================================================================================
IF EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CAT_UNIT_WEIGHT_Search]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[CAT_UNIT_WEIGHT_Search]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CAT_UNIT_WEIGHT_Search]
	@p_ID bigint = -1,
	@p_UnitWeightCode varchar(15) = '',
	@p_UnitWeightDesc nvarchar(500) = '',
	@p_IsActive bit = NULL,
	@p_OrderBy bigint = -1
AS
	SELECT	UNTW.ID,
			UNTW.UnitWeightCode,
			UNTW.UnitWeightDesc,
			UNTW.OrderBy,
			UNTW.IsActive,
			UNTW.UpdateDate,
			UNTW.UpdateBy,
			URS.UserName AS UserUpdate,
			UNTW.IsDelete
	FROM dbo.CAT_UNIT_WEIGHT UNTW
		 LEFT JOIN dbo.SYS_USERS URS ON URS.ID = UNTW.UpdateBy
	WHERE UNTW.IsDelete = 0
		  AND (UNTW.ID = @p_ID OR @p_ID = -1 OR @p_ID IS NULL)
		  AND (UNTW.UnitWeightCode = @p_UnitWeightCode OR @p_UnitWeightCode = '' OR @p_UnitWeightCode IS NULL)
		  AND (UNTW.UnitWeightDesc = @p_UnitWeightDesc OR @p_UnitWeightDesc = '' OR @p_UnitWeightDesc IS NULL)
		  AND (UNTW.IsActive = @p_IsActive OR @p_IsActive = -1 OR @p_IsActive IS NULL)
		  AND (UNTW.OrderBy = @p_OrderBy OR @p_OrderBy = -1 OR @p_OrderBy IS NULL)
GO
--=========================================================================================================================================================
--=========================================================================================================================================================
IF EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CAT_UNIT_WEIGHT_InsUpd]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[CAT_UNIT_WEIGHT_InsUpd]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CAT_UNIT_WEIGHT_InsUpd]
	@p_ID bigint = -1,
	@p_UnitWeightCode varchar(15) = '',
	@p_UnitWeightDesc nvarchar(500) = '',
	@p_OrderBy bigint = -1,
	@p_IsActive bit = 1,
	@p_UpdateBy bigint = -1
AS
BEGIN TRANSACTION
	DECLARE @vMessage nvarchar(max)
	SET @vMessage = ''

	IF(@p_ID = -1 OR @p_ID IS NULL)
	BEGIN
		INSERT INTO [dbo].[CAT_UNIT_WEIGHT]
		       (UnitWeightCode,
				UnitWeightDesc,
				OrderBy,
				IsActive,
				UpdateDate,
				UpdateBy,
				IsDelete)
		VALUES
		       (@p_UnitWeightCode,
		        @p_UnitWeightDesc,
		        @p_OrderBy,
		        1,
				GETDATE(),
		        @p_UpdateBy,
		        0)
		IF @@Error <> 0 GOTO ABORT
	END
	ELSE
	BEGIN
		UPDATE [dbo].[CAT_UNIT_WEIGHT]
		SET UnitWeightCode = @p_UnitWeightCode,
			UnitWeightDesc = UnitWeightDesc,
			OrderBy = @p_OrderBy,
			IsActive = @p_IsActive,
			UpdateDate = GETDATE(),
			UpdateBy = @p_UpdateBy,
			IsDelete = 0 
		WHERE [ID] = @p_ID
		IF @@Error <> 0 GOTO ABORT
	END

COMMIT TRANSACTION
	SELECT 1 AS Result, @vMessage AS MsgProcedure
	RETURN 1
ABORT:
BEGIN
	ROLLBACK TRANSACTION
	IF(@vMessage = '')
	BEGIN
		SET @vMessage = N'Thao tác thất bại'
	END
	SELECT 0 AS Result, @vMessage AS MsgProcedure
	RETURN 0
END
GO
--=========================================================================================================================================================
--=========================================================================================================================================================
IF EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CAT_UNIT_WEIGHT_GetAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[CAT_UNIT_WEIGHT_GetAll]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CAT_UNIT_WEIGHT_GetAll]
AS
	SELECT	UNTW.ID,
			UNTW.UnitWeightCode,
			UNTW.UnitWeightDesc,
			UNTW.OrderBy,
			UNTW.IsActive,
			UNTW.UpdateDate,
			UNTW.UpdateBy,
			URS.UserName AS UserUpdate,
			UNTW.IsDelete
	FROM dbo.CAT_UNIT_WEIGHT UNTW
		 LEFT JOIN dbo.SYS_USERS URS ON URS.ID = UNTW.UpdateBy
	WHERE UNTW.IsDelete = 0
GO
--=========================================================================================================================================================
--=========================================================================================================================================================
IF EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CAT_UNIT_WEIGHT_Del]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[CAT_UNIT_WEIGHT_Del]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CAT_UNIT_WEIGHT_Del]
	@p_ID bigint = -1,
	@p_UpdateBy bigint = -1
AS
BEGIN TRANSACTION
	DECLARE @vMessage nvarchar(max)
	SET @vMessage = ''

	UPDATE CAT_UNIT_WEIGHT
	SET IsDelete = 1,
		UpdateBy = @p_UpdateBy,
		UpdateDate = GETDATE()
	WHERE ID = @p_ID
	IF @@Error <> 0 GOTO ABORT

COMMIT TRANSACTION
	SELECT 1 AS Result, @vMessage AS MsgProcedure
	RETURN 1
ABORT:
BEGIN
	ROLLBACK TRANSACTION
	IF(@vMessage = '')
	BEGIN
		SET @vMessage = N'Thao tác thất bại'
	END
	SELECT 0 AS Result, @vMessage AS MsgProcedure
	RETURN 0
END
GO
--=========================================================================================================================================================
--=========================================================================================================================================================
IF EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CAT_UNIT_SELL_GetWithCode]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[CAT_UNIT_SELL_GetWithCode]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CAT_UNIT_SELL_GetWithCode]
	@p_Code bigint = -1	
AS
	SELECT	UNTS.ID,
			UNTS.UnitSellCode,
			UNTS.UnitSellDesc,
			UNTS.OrderBy,
			UNTS.IsActive,
			UNTS.UpdateDate,
			UNTS.UpdateBy,
			URS.UserName AS UserUpdate,
			UNTS.IsDelete
	FROM dbo.CAT_UNIT_SELL UNTS
		 LEFT JOIN dbo.SYS_USERS URS ON URS.ID = UNTS.UpdateBy
	WHERE UNTS.IsDelete = 0
		  AND (UNTS.ID = @p_Code OR @p_Code IS NULL OR @p_Code = '')
GO
--=========================================================================================================================================================
--=========================================================================================================================================================
IF EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CAT_UNIT_SELL_Search]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[CAT_UNIT_SELL_Search]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CAT_UNIT_SELL_Search]
	@p_ID bigint = -1,
	@p_UnitSellCode varchar(15) = '',
	@p_UnitSellDesc nvarchar(500) = '',
	@p_IsActive bit = NULL,
	@p_OrderBy bigint = -1
AS
	SELECT	UNTS.ID,
			UNTS.UnitSellCode,
			UNTS.UnitSellDesc,
			UNTS.OrderBy,
			UNTS.IsActive,
			UNTS.UpdateDate,
			UNTS.UpdateBy,
			URS.UserName AS UserUpdate,
			UNTS.IsDelete
	FROM dbo.CAT_UNIT_SELL UNTS
		 LEFT JOIN dbo.SYS_USERS URS ON URS.ID = UNTS.UpdateBy
	WHERE UNTS.IsDelete = 0
		  AND (UNTS.ID = @p_ID OR @p_ID = -1 OR @p_ID IS NULL)
		  AND (UNTS.UnitSellCode = @p_UnitSellCode OR @p_UnitSellCode = '' OR @p_UnitSellCode IS NULL)
		  AND (UNTS.UnitSellDesc = @p_UnitSellDesc OR @p_UnitSellDesc = '' OR @p_UnitSellDesc IS NULL)
		  AND (UNTS.IsActive = @p_IsActive OR @p_IsActive = -1 OR @p_IsActive IS NULL)
		  AND (UNTS.OrderBy = @p_OrderBy OR @p_OrderBy = -1 OR @p_OrderBy IS NULL)
GO
--=========================================================================================================================================================
--=========================================================================================================================================================
IF EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CAT_UNIT_SELL_InsUpd]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[CAT_UNIT_SELL_InsUpd]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CAT_UNIT_SELL_InsUpd]
	@p_ID bigint = -1,
	@p_UnitSellCode varchar(15) = '',
	@p_UnitSellDesc nvarchar(500) = '',
	@p_OrderBy bigint = -1,
	@p_IsActive bit = 1,
	@p_UpdateBy bigint = -1
AS
BEGIN TRANSACTION
	DECLARE @vMessage nvarchar(max)
	SET @vMessage = ''

	IF(@p_ID = -1 OR @p_ID IS NULL)
	BEGIN
		INSERT INTO [dbo].[CAT_UNIT_SELL]
		       (UnitSellCode,
				UnitSellDesc,
				OrderBy,
				IsActive,
				UpdateDate,
				UpdateBy,
				IsDelete)
		VALUES
		       (@p_UnitSellCode,
		        @p_UnitSellDesc,
		        @p_OrderBy,
		        1,
				GETDATE(),
		        @p_UpdateBy,
		        0)
		IF @@Error <> 0 GOTO ABORT
	END
	ELSE
	BEGIN
		UPDATE [dbo].[CAT_UNIT_SELL]
		SET UnitSellCode = @p_UnitSellCode,
			UnitSellDesc = @p_UnitSellDesc,
			OrderBy = @p_OrderBy,
			IsActive = @p_IsActive,
			UpdateDate = GETDATE(),
			UpdateBy = @p_UpdateBy,
			IsDelete = 0
		WHERE [ID] = @p_ID
		IF @@Error <> 0 GOTO ABORT
	END

COMMIT TRANSACTION
	SELECT 1 AS Result, @vMessage AS MsgProcedure
	RETURN 1
ABORT:
BEGIN
	ROLLBACK TRANSACTION
	IF(@vMessage = '')
	BEGIN
		SET @vMessage = N'Thao tác thất bại'
	END
	SELECT 0 AS Result, @vMessage AS MsgProcedure
	RETURN 0
END
GO
--=========================================================================================================================================================
--=========================================================================================================================================================
IF EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CAT_UNIT_SELL_GetAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[CAT_UNIT_SELL_GetAll]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CAT_UNIT_SELL_GetAll]
AS
	SELECT	UNTS.ID,
			UNTS.UnitSellCode,
			UNTS.UnitSellDesc,
			UNTS.OrderBy,
			UNTS.IsActive,
			UNTS.UpdateDate,
			UNTS.UpdateBy,
			URS.UserName AS UserUpdate,
			UNTS.IsDelete
	FROM dbo.CAT_UNIT_SELL UNTS
		 LEFT JOIN dbo.SYS_USERS URS ON URS.ID = UNTS.UpdateBy
	WHERE UNTS.IsDelete = 0
GO
--=========================================================================================================================================================
--=========================================================================================================================================================
IF EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CAT_UNIT_SELL_Del]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[CAT_UNIT_SELL_Del]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CAT_UNIT_SELL_Del]
	@p_ID bigint = -1,
	@p_UpdateBy bigint = -1
AS
BEGIN TRANSACTION
	DECLARE @vMessage nvarchar(max)
	SET @vMessage = ''

	UPDATE CAT_UNIT_SELL
	SET IsDelete = 1,
		UpdateBy = @p_UpdateBy,
		UpdateDate = GETDATE()
	WHERE ID = @p_ID
	IF @@Error <> 0 GOTO ABORT

COMMIT TRANSACTION
	SELECT 1 AS Result, @vMessage AS MsgProcedure
	RETURN 1
ABORT:
BEGIN
	ROLLBACK TRANSACTION
	IF(@vMessage = '')
	BEGIN
		SET @vMessage = N'Thao tác thất bại'
	END
	SELECT 0 AS Result, @vMessage AS MsgProcedure
	RETURN 0
END
GO
--=========================================================================================================================================================
--=========================================================================================================================================================
IF EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CAT_UNIT_IN_Search]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[CAT_UNIT_IN_Search]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CAT_UNIT_IN_Search]
	@p_ID bigint = -1,
	@p_UnitInCode varchar(15) = '',
	@p_UnitInDesc nvarchar(500) = '',
	@p_IsActive bit = NULL,
	@p_OrderBy bigint = -1
AS
	SELECT	UNTI.ID,
			UNTI.UnitInCode,
			UNTI.UnitInDesc,
			UNTI.ScaleChange,
			UNTI.OrderBy,
			UNTI.IsActive,
			UNTI.UpdateDate,
			UNTI.UpdateBy,
			URS.UserName AS UserUpdate,
			UNTI.IsDelete
	FROM dbo.CAT_UNIT_IN UNTI
		 LEFT JOIN dbo.SYS_USERS URS ON URS.ID = UNTI.UpdateBy
	WHERE UNTI.IsDelete = 0
		  AND (UNTI.ID = @p_ID OR @p_ID = -1 OR @p_ID IS NULL)
		  AND (UNTI.UnitInCode = @p_UnitInCode OR @p_UnitInCode = '' OR @p_UnitInCode IS NULL)
		  AND (UNTI.UnitInDesc = @p_UnitInDesc OR @p_UnitInDesc = '' OR @p_UnitInDesc IS NULL)
		  AND (UNTI.IsActive = @p_IsActive OR @p_IsActive = -1 OR @p_IsActive IS NULL)
		  AND (UNTI.OrderBy = @p_OrderBy OR @p_OrderBy = -1 OR @p_OrderBy IS NULL)
GO
--=========================================================================================================================================================
--=========================================================================================================================================================
IF EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CAT_UNIT_IN_InsUpd]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[CAT_UNIT_IN_InsUpd]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CAT_UNIT_IN_InsUpd]
	@p_ID bigint = -1,
	@p_UnitInCode varchar(15) = '',
	@p_UnitInDesc nvarchar(500) = '',
	@p_ScaleChange bigint = 0,
	@p_OrderBy bigint = -1,
	@p_IsActive bit = 1,
	@p_UpdateBy bigint = -1
AS
BEGIN TRANSACTION
	DECLARE @vMessage nvarchar(max)
	SET @vMessage = ''

	IF(@p_ID = -1 OR @p_ID IS NULL)
	BEGIN
		INSERT INTO [dbo].[CAT_UNIT_IN]
		       (UnitInCode,
				UnitInDesc,
				ScaleChange,
				OrderBy,
				IsActive,
				UpdateDate,
				UpdateBy,
				IsDelete)
		VALUES
		       (@p_UnitInCode,
		        @p_UnitInDesc,
				@p_ScaleChange,
		        @p_OrderBy,
		        1,
				GETDATE(),
		        @p_UpdateBy,
		        0)
		IF @@Error <> 0 GOTO ABORT
	END
	ELSE
	BEGIN
		UPDATE [dbo].[CAT_UNIT_IN]
		SET UnitInCode = @p_UnitInCode,
			UnitInDesc = @p_UnitInDesc,
			ScaleChange = @p_ScaleChange,
			OrderBy = @p_OrderBy,
			IsActive = @p_IsActive,
			UpdateDate = GETDATE(),
			UpdateBy = @p_UpdateBy,
			IsDelete = 0
		WHERE [ID] = @p_ID
		IF @@Error <> 0 GOTO ABORT
	END

COMMIT TRANSACTION
	SELECT 1 AS Result, @vMessage AS MsgProcedure
	RETURN 1
ABORT:
BEGIN
	ROLLBACK TRANSACTION
	IF(@vMessage = '')
	BEGIN
		SET @vMessage = N'Thao tác thất bại'
	END
	SELECT 0 AS Result, @vMessage AS MsgProcedure
	RETURN 0
END
GO
--=========================================================================================================================================================
--=========================================================================================================================================================
IF EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CAT_UNIT_IN_GetAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[CAT_UNIT_IN_GetAll]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CAT_UNIT_IN_GetAll]
AS
	SELECT	UNTI.ID,
			UNTI.UnitInCode,
			UNTI.UnitInDesc,
			UNTI.ScaleChange,
			UNTI.OrderBy,
			UNTI.IsActive,
			UNTI.UpdateDate,
			UNTI.UpdateBy,
			URS.UserName AS UserUpdate,
			UNTI.IsDelete
	FROM dbo.CAT_UNIT_IN UNTI
		 LEFT JOIN dbo.SYS_USERS URS ON URS.ID = UNTI.UpdateBy
	WHERE UNTI.IsDelete = 0
GO
--=========================================================================================================================================================
--=========================================================================================================================================================
IF EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CAT_UNIT_IN_Del]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[CAT_UNIT_IN_Del]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CAT_UNIT_IN_Del]
	@p_ID bigint = -1,
	@p_UpdateBy bigint = -1
AS
BEGIN TRANSACTION
	DECLARE @vMessage nvarchar(max)
	SET @vMessage = ''

	UPDATE CAT_UNIT_IN
	SET IsDelete = 1,
		UpdateBy = @p_UpdateBy,
		UpdateDate = GETDATE()
	WHERE ID = @p_ID
	IF @@Error <> 0 GOTO ABORT

COMMIT TRANSACTION
	SELECT 1 AS Result, @vMessage AS MsgProcedure
	RETURN 1
ABORT:
BEGIN
	ROLLBACK TRANSACTION
	IF(@vMessage = '')
	BEGIN
		SET @vMessage = N'Thao tác thất bại'
	END
	SELECT 0 AS Result, @vMessage AS MsgProcedure
	RETURN 0
END
GO
--=========================================================================================================================================================
--=========================================================================================================================================================
IF EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CAT_SUPPLIER_Search]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[CAT_SUPPLIER_Search]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CAT_SUPPLIER_Search]
	@p_ID bigint = -1,
	@p_SupplierCode varchar(15) = '',
	@p_SupplierName nvarchar(500) = '',
	@p_SupplierAddress nvarchar(max) = '',
	@p_Phone varchar(15) = '',
	@p_IsActive bit = NULL,
	@p_OrderBy bigint = -1
AS
	SELECT	SUP.ID,
			SUP.SupplierCode,
			SUP.SupplierName,
			SUP.SupplierAddress,
			SUP.Phone,
			SUP.OrderBy,
			SUP.IsActive,
			SUP.UpdateDate,
			SUP.UpdateBy,
			URS.UserName AS UserUpdate,
			SUP.IsDelete
	FROM dbo.CAT_SUPPLIER SUP
		 LEFT JOIN dbo.SYS_USERS URS ON URS.ID = SUP.UpdateBy
	WHERE SUP.IsDelete = 0
		  AND (SUP.ID = @p_ID OR @p_ID = -1 OR @p_ID IS NULL)
		  AND (SUP.SupplierCode = @p_SupplierCode OR @p_SupplierCode = '' OR @p_SupplierCode IS NULL)
		  AND (SUP.SupplierName = @p_SupplierName OR @p_SupplierName = '' OR @p_SupplierName IS NULL)
		  AND (SUP.SupplierAddress = @p_SupplierAddress OR @p_SupplierAddress = '' OR @p_SupplierAddress IS NULL)
		  AND (SUP.Phone = @p_Phone OR @p_Phone = '' OR @p_Phone IS NULL)
		  AND (SUP.IsActive = @p_IsActive OR @p_IsActive = -1 OR @p_IsActive IS NULL)
		  AND (SUP.OrderBy = @p_OrderBy OR @p_OrderBy = -1 OR @p_OrderBy IS NULL)
GO
--=========================================================================================================================================================
--=========================================================================================================================================================
IF EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CAT_SUPPLIER_InsUpd]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[CAT_SUPPLIER_InsUpd]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CAT_SUPPLIER_InsUpd]
	@p_ID bigint = -1,
	@p_SupplierCode varchar(15) = '',
	@p_SupplierName nvarchar(500) = '',
	@p_SupplierAddress nvarchar(max) = '',
	@p_Phone varchar(15) = '',
	@p_OrderBy bigint = -1,
	@p_IsActive bit = 1,
	@p_UpdateBy bigint = -1
AS
BEGIN TRANSACTION
	DECLARE @vMessage nvarchar(max)
	SET @vMessage = ''

	IF(@p_ID = -1 OR @p_ID IS NULL)
	BEGIN
		INSERT INTO [dbo].[CAT_SUPPLIER]
		       (SupplierCode,
				SupplierName,
				SupplierAddress,
				Phone,
				OrderBy,
				IsActive,
				UpdateDate,
				UpdateBy,
				IsDelete)
		VALUES
		       (@p_SupplierCode,
		        @p_SupplierName,
		        @p_SupplierAddress,
		        @p_Phone,
		        @p_OrderBy,
		        1,
				GETDATE(),
		        @p_UpdateBy,
		        0)
		IF @@Error <> 0 GOTO ABORT
	END
	ELSE
	BEGIN
		UPDATE [dbo].[CAT_SUPPLIER]
		SET SupplierCode = @p_SupplierCode,
			SupplierName = @p_SupplierName,
			SupplierAddress =  @p_SupplierAddress,
			Phone = @p_Phone,
			OrderBy = @p_OrderBy,
			IsActive = @p_IsActive,
			UpdateDate = GETDATE(),
			UpdateBy = @p_UpdateBy,
			IsDelete = 0
		WHERE [ID] = @p_ID
		IF @@Error <> 0 GOTO ABORT
	END

COMMIT TRANSACTION
	SELECT 1 AS Result, @vMessage AS MsgProcedure
	RETURN 1
ABORT:
BEGIN
	ROLLBACK TRANSACTION
	IF(@vMessage = '')
	BEGIN
		SET @vMessage = N'Thao tác thất bại'
	END
	SELECT 0 AS Result, @vMessage AS MsgProcedure
	RETURN 0
END
GO
--=========================================================================================================================================================
--=========================================================================================================================================================
IF EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CAT_SUPPLIER_GetAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[CAT_SUPPLIER_GetAll]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CAT_SUPPLIER_GetAll]
AS
	SELECT	SUP.ID,
			SUP.SupplierCode,
			SUP.SupplierName,
			SUP.SupplierAddress,
			SUP.Phone,
			SUP.OrderBy,
			SUP.IsActive,
			SUP.UpdateDate,
			SUP.UpdateBy,
			URS.UserName AS UserUpdate,
			SUP.IsDelete
	FROM dbo.CAT_SUPPLIER SUP
		 LEFT JOIN dbo.SYS_USERS URS ON URS.ID = SUP.UpdateBy
	WHERE SUP.IsDelete = 0
GO
--=========================================================================================================================================================
--=========================================================================================================================================================
IF EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CAT_SUPPLIER_Del]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[CAT_SUPPLIER_Del]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CAT_SUPPLIER_Del]
	@p_ID bigint = -1,
	@p_UpdateBy bigint = -1
AS
BEGIN TRANSACTION
	DECLARE @vMessage nvarchar(max)
	SET @vMessage = ''

	UPDATE CAT_SUPPLIER
	SET IsDelete = 1,
		UpdateBy = @p_UpdateBy,
		UpdateDate = GETDATE()
	WHERE ID = @p_ID
	IF @@Error <> 0 GOTO ABORT

COMMIT TRANSACTION
	SELECT 1 AS Result, @vMessage AS MsgProcedure
	RETURN 1
ABORT:
BEGIN
	ROLLBACK TRANSACTION
	IF(@vMessage = '')
	BEGIN
		SET @vMessage = N'Thao tác thất bại'
	END
	SELECT 0 AS Result, @vMessage AS MsgProcedure
	RETURN 0
END
GO
--=========================================================================================================================================================
--=========================================================================================================================================================
IF EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CAT_STALLS_Search]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[CAT_STALLS_Search]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CAT_STALLS_Search]
	@p_ID bigint = -1,
	@p_StallsCode varchar(15) = '',
	@p_StallsName nvarchar(500) = '',
	@p_ShopID nvarchar(max) = '',
	@p_IsActive bit = NULL,
	@p_OrderBy bigint = -1
AS
	SELECT	STL.ID,
			STL.StallsCode,
			STL.StallsName,
			STL.ShopID,
			SHP.ShopName,
			STL.OrderBy,
			STL.IsActive,
			STL.UpdateDate,
			STL.UpdateBy,
			URS.UserName AS UserUpdate,
			STL.IsDelete
	FROM dbo.CAT_STALLS STL
		 LEFT JOIN dbo.CAT_SHOP SHP ON SHP.ID = STL.ShopID
		 LEFT JOIN dbo.SYS_USERS URS ON URS.ID = STL.UpdateBy
	WHERE STL.IsDelete = 0
		  AND (STL.ID = @p_ID OR @p_ID = -1 OR @p_ID IS NULL)
		  AND (STL.StallsCode = @p_StallsCode OR @p_StallsCode = '' OR @p_StallsCode IS NULL)
		  AND (STL.StallsName = @p_StallsName OR @p_StallsName = '' OR @p_StallsName IS NULL)
		  AND (STL.ShopID = @p_ShopID OR @p_ShopID = -1 OR @p_ShopID IS NULL)
		  AND (STL.IsActive = @p_IsActive OR @p_IsActive = -1 OR @p_IsActive IS NULL)
		  AND (STL.OrderBy = @p_OrderBy OR @p_OrderBy = -1 OR @p_OrderBy IS NULL)
GO
--=========================================================================================================================================================
--=========================================================================================================================================================
IF EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CAT_STALLS_InsUpd]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[CAT_STALLS_InsUpd]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CAT_STALLS_InsUpd]
	@p_ID bigint = -1,
	@p_StallsCode varchar(15) = '',
	@p_StallsName nvarchar(500) = '',
	@p_ShopID nvarchar(max) = '',
	@p_OrderBy bigint = -1,
	@p_IsActive bit = 1,
	@p_UpdateBy bigint = -1
AS
BEGIN TRANSACTION
	DECLARE @vMessage nvarchar(max)
	SET @vMessage = ''

	IF(@p_ID = -1 OR @p_ID IS NULL)
	BEGIN
		INSERT INTO [dbo].[CAT_STALLS]
		       (StallsCode,
				StallsName,
				ShopID,
				OrderBy,
				IsActive,
				UpdateDate,
				UpdateBy,
				IsDelete)
		VALUES
		       (@p_StallsCode,
		        @p_StallsName,
		        @p_ShopID,
		        @p_OrderBy,
		        1,
				GETDATE(),
		        @p_UpdateBy,
		        0)
		IF @@Error <> 0 GOTO ABORT
	END
	ELSE
	BEGIN
		UPDATE [dbo].[CAT_STALLS]
		SET StallsCode = @p_StallsCode,
			StallsName = @p_StallsName,
			ShopID = @p_ShopID,
			OrderBy = @p_OrderBy,
			IsActive = @p_IsActive,
			UpdateDate = GETDATE(),
			UpdateBy = @p_UpdateBy,
			IsDelete = 0
		WHERE [ID] = @p_ID
		IF @@Error <> 0 GOTO ABORT
	END

COMMIT TRANSACTION
	SELECT 1 AS Result, @vMessage AS MsgProcedure
	RETURN 1
ABORT:
BEGIN
	ROLLBACK TRANSACTION
	IF(@vMessage = '')
	BEGIN
		SET @vMessage = N'Thao tác thất bại'
	END
	SELECT 0 AS Result, @vMessage AS MsgProcedure
	RETURN 0
END
GO
--=========================================================================================================================================================
--=========================================================================================================================================================
IF EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CAT_STALLS_GetAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[CAT_STALLS_GetAll]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CAT_STALLS_GetAll]
AS
	SELECT	STL.ID,
			STL.StallsCode,
			STL.StallsName,
			STL.ShopID,
			SHP.ShopName,
			STL.OrderBy,
			STL.IsActive,
			STL.UpdateDate,
			STL.UpdateBy,
			URS.UserName AS UserUpdate,
			STL.IsDelete
	FROM dbo.CAT_STALLS STL
		 LEFT JOIN dbo.CAT_SHOP SHP ON SHP.ID = STL.ShopID
		 LEFT JOIN dbo.SYS_USERS URS ON URS.ID = STL.UpdateBy
	WHERE STL.IsDelete = 0
GO
--=========================================================================================================================================================
--=========================================================================================================================================================
IF EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CAT_STALLS_Del]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[CAT_STALLS_Del]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CAT_STALLS_Del]
	@p_ID bigint = -1,
	@p_UpdateBy bigint = -1
AS
BEGIN TRANSACTION
	DECLARE @vMessage nvarchar(max)
	SET @vMessage = ''

	UPDATE CAT_STALLS
	SET IsDelete = 1,
		UpdateBy = @p_UpdateBy,
		UpdateDate = GETDATE()
	WHERE ID = @p_ID
	IF @@Error <> 0 GOTO ABORT

COMMIT TRANSACTION
	SELECT 1 AS Result, @vMessage AS MsgProcedure
	RETURN 1
ABORT:
BEGIN
	ROLLBACK TRANSACTION
	IF(@vMessage = '')
	BEGIN
		SET @vMessage = N'Thao tác thất bại'
	END
	SELECT 0 AS Result, @vMessage AS MsgProcedure
	RETURN 0
END
GO
--=========================================================================================================================================================
--=========================================================================================================================================================
IF EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CAT_SHOP_Search]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[CAT_SHOP_Search]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CAT_SHOP_Search]
	@p_ID bigint = -1,
	@p_ShopCode varchar(15) = '',
	@p_ShopName nvarchar(max) = '',
	@p_ShopAddress nvarchar(max) = '',
	@p_ShopTel varchar(100) = '',
	@p_ShopFax varchar(100) = '',
	@p_ShopTax varchar(100) = '',
	@p_ShopWebsite varchar(200) = '',
	@p_IsActive bit = NULL,
	@p_OrderBy bigint = -1
AS
	SELECT	SHP.ID,
			SHP.ShopCode,
			SHP.ShopName,
			SHP.ShopAddress,
			SHP.ShopTel,
			SHP.ShopFax,
			SHP.ShopTax,
			SHP.ShopWebsite,
			SHP.OrderBy,
			SHP.IsActive,
			SHP.UpdateDate,
			SHP.UpdateBy,
			URS.UserName AS UserUpdate,
			SHP.IsDelete
	FROM dbo.CAT_SHOP SHP
		 LEFT JOIN dbo.SYS_USERS URS ON URS.ID = SHP.UpdateBy
	WHERE SHP.IsDelete = 0
		  AND (SHP.ID = @p_ID OR @p_ID = -1 OR @p_ID IS NULL)
		  AND (SHP.ShopCode = @p_ShopCode OR @p_ShopCode = '' OR @p_ShopCode IS NULL)
		  AND (SHP.ShopName = @p_ShopName OR @p_ShopName = '' OR @p_ShopName IS NULL)
		  AND (SHP.ShopAddress = @p_ShopAddress OR @p_ShopAddress = '' OR @p_ShopAddress IS NULL)
		  AND (SHP.ShopTel = @p_ShopTel OR @p_ShopTel = '' OR @p_ShopTel IS NULL)
		  AND (SHP.ShopFax = @p_ShopFax OR @p_ShopFax = '' OR @p_ShopFax IS NULL)
		  AND (SHP.ShopTax = @p_ShopTax OR @p_ShopTax = '' OR @p_ShopTax IS NULL)
		  AND (SHP.ShopWebsite = @p_ShopWebsite OR @p_ShopWebsite = '' OR @p_ShopWebsite IS NULL)
		  AND (SHP.IsActive = @p_IsActive OR @p_IsActive = -1 OR @p_IsActive IS NULL)
		  AND (SHP.OrderBy = @p_OrderBy OR @p_OrderBy = -1 OR @p_OrderBy IS NULL)
GO
--=========================================================================================================================================================
--=========================================================================================================================================================
IF EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CAT_SHOP_InsUpd]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[CAT_SHOP_InsUpd]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CAT_SHOP_InsUpd]
	@p_ID bigint = -1,
	@p_ShopCode varchar(15) = '',
	@p_ShopName nvarchar(max) = '',
	@p_ShopAddress nvarchar(max) = '',
	@p_ShopTel varchar(100) = '',
	@p_ShopFax varchar(100) = '',
	@p_ShopTax varchar(100) = '',
	@p_ShopWebsite varchar(200) = '',
	@p_OrderBy bigint = -1,
	@p_IsActive bit = 1,
	@p_UpdateBy bigint = -1
AS
BEGIN TRANSACTION
	DECLARE @vMessage nvarchar(max)
	SET @vMessage = ''

	IF(@p_ID = -1 OR @p_ID IS NULL)
	BEGIN
		INSERT INTO [dbo].[CAT_SHOP]
		       (ShopCode,
				ShopName,
				ShopAddress,
				ShopTel,
				ShopFax,
				ShopTax,
				ShopWebsite,
				OrderBy,
				IsActive,
				UpdateDate,
				UpdateBy,
				IsDelete)
		VALUES
		       (@p_ShopCode,
				@p_ShopName,
				@p_ShopAddress,
				@p_ShopTel,
				@p_ShopFax,
				@p_ShopTax,
				@p_ShopWebsite,
		        @p_OrderBy,
		        1,
				GETDATE(),
		        @p_UpdateBy,
		        0)
		IF @@Error <> 0 GOTO ABORT
	END
	ELSE
	BEGIN
		UPDATE [dbo].[CAT_SHOP]
		SET ShopCode = @p_ShopCode,
			ShopName = @p_ShopName,
			ShopAddress = @p_ShopAddress,
			ShopTel = @p_ShopTel,
			ShopFax = @p_ShopFax,
			ShopTax = @p_ShopTax,
			ShopWebsite = @p_ShopWebsite,
			OrderBy = @p_OrderBy,
			IsActive = @p_IsActive,
			UpdateDate = GETDATE(),
			UpdateBy = @p_UpdateBy,
			IsDelete = 0
		WHERE [ID] = @p_ID
		IF @@Error <> 0 GOTO ABORT
	END

COMMIT TRANSACTION
	SELECT 1 AS Result, @vMessage AS MsgProcedure
	RETURN 1
ABORT:
BEGIN
	ROLLBACK TRANSACTION
	IF(@vMessage = '')
	BEGIN
		SET @vMessage = N'Thao tác thất bại'
	END
	SELECT 0 AS Result, @vMessage AS MsgProcedure
	RETURN 0
END
GO
--=========================================================================================================================================================
--=========================================================================================================================================================
IF EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CAT_SHOP_GetAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[CAT_SHOP_GetAll]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CAT_SHOP_GetAll]
AS
	SELECT	SHP.ID,
			SHP.ShopCode,
			SHP.ShopName,
			SHP.ShopAddress,
			SHP.ShopTel,
			SHP.ShopFax,
			SHP.ShopTax,
			SHP.ShopWebsite,
			SHP.OrderBy,
			SHP.IsActive,
			SHP.UpdateDate,
			SHP.UpdateBy,
			URS.UserName AS UserUpdate,
			SHP.IsDelete
	FROM dbo.CAT_SHOP SHP
		 LEFT JOIN dbo.SYS_USERS URS ON URS.ID = SHP.UpdateBy
	WHERE SHP.IsDelete = 0
GO
--=========================================================================================================================================================
--=========================================================================================================================================================
IF EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CAT_SHOP_Del]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[CAT_SHOP_Del]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CAT_SHOP_Del]
	@p_ID bigint = -1,
	@p_UpdateBy bigint = -1
AS
BEGIN TRANSACTION
	DECLARE @vMessage nvarchar(max)
	SET @vMessage = ''

	UPDATE CAT_SHOP
	SET IsDelete = 1,
		UpdateBy = @p_UpdateBy,
		UpdateDate = GETDATE()
	WHERE ID = @p_ID
	IF @@Error <> 0 GOTO ABORT

COMMIT TRANSACTION
	SELECT 1 AS Result, @vMessage AS MsgProcedure
	RETURN 1
ABORT:
BEGIN
	ROLLBACK TRANSACTION
	IF(@vMessage = '')
	BEGIN
		SET @vMessage = N'Thao tác thất bại'
	END
	SELECT 0 AS Result, @vMessage AS MsgProcedure
	RETURN 0
END
GO
--=========================================================================================================================================================
--=========================================================================================================================================================
IF EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CAT_PRODUCTTYPE_Search]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[CAT_PRODUCTTYPE_Search]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CAT_PRODUCTTYPE_Search]
	@p_ID bigint = -1,
	@p_ProductTypeCode varchar(15) = '',
	@p_ProductTypeName nvarchar(500) = '',
	@p_Descriptions nvarchar(max) = '',
	@p_IsActive bit = NULL,
	@p_OrderBy bigint = -1
AS
	SELECT	PRDT.ID,
			PRDT.ProductTypeCode,
			PRDT.ProductTypeName,
			PRDT.Descriptions,
			PRDT.OrderBy,
			PRDT.IsActive,
			PRDT.UpdateDate,
			PRDT.UpdateBy,
			URS.UserName AS UserUpdate,
			PRDT.IsDelete
	FROM dbo.CAT_PRODUCTTYPE PRDT
		 LEFT JOIN dbo.SYS_USERS URS ON URS.ID = PRDT.UpdateBy
	WHERE PRDT.IsDelete = 0
		  AND (PRDT.ID = @p_ID OR @p_ID = -1 OR @p_ID IS NULL)
		  AND (PRDT.ProductTypeCode = @p_ProductTypeCode OR @p_ProductTypeCode = '' OR @p_ProductTypeCode IS NULL)
		  AND (PRDT.ProductTypeName = @p_ProductTypeName OR @p_ProductTypeName = '' OR @p_ProductTypeName IS NULL)
		  AND (PRDT.Descriptions = @p_Descriptions OR @p_Descriptions = '' OR @p_Descriptions IS NULL)
		  AND (PRDT.IsActive = @p_IsActive OR @p_IsActive = -1 OR @p_IsActive IS NULL)
		  AND (PRDT.OrderBy = @p_OrderBy OR @p_OrderBy = -1 OR @p_OrderBy IS NULL)
GO
--=========================================================================================================================================================
--=========================================================================================================================================================
IF EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CAT_PRODUCTTYPE_InsUpd]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[CAT_PRODUCTTYPE_InsUpd]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CAT_PRODUCTTYPE_InsUpd]
	@p_ID bigint = -1,
	@p_ProductTypeCode varchar(15) = '',
	@p_ProductTypeName nvarchar(500) = '',
	@p_Descriptions nvarchar(max) = '',
	@p_OrderBy bigint = -1,
	@p_IsActive bit = 1,
	@p_UpdateBy bigint = -1
AS
BEGIN TRANSACTION
	DECLARE @vMessage nvarchar(max)
	SET @vMessage = ''

	IF(@p_ID = -1 OR @p_ID IS NULL)
	BEGIN
		INSERT INTO [dbo].[CAT_PRODUCTTYPE]
		       (ProductTypeCode,
				ProductTypeName,
				Descriptions,
				OrderBy,
				IsActive,
				UpdateDate,
				UpdateBy,
				IsDelete)
		VALUES
		       (@p_ProductTypeCode,
		        @p_ProductTypeName,
		        @p_Descriptions,
		        @p_OrderBy,
		        1,
				GETDATE(),
		        @p_UpdateBy,
		        0)
		IF @@Error <> 0 GOTO ABORT
	END
	ELSE
	BEGIN
		UPDATE [dbo].[CAT_PRODUCTTYPE]
		SET ProductTypeCode = @p_ProductTypeCode,
			ProductTypeName = @p_ProductTypeName,
			Descriptions =  @p_Descriptions,
			OrderBy = @p_OrderBy,
			IsActive = @p_IsActive,
			UpdateDate = GETDATE(),
			UpdateBy = @p_UpdateBy,
			IsDelete = 0
		WHERE [ID] = @p_ID
		IF @@Error <> 0 GOTO ABORT
	END

COMMIT TRANSACTION
	SELECT 1 AS Result, @vMessage AS MsgProcedure
	RETURN 1
ABORT:
BEGIN
	ROLLBACK TRANSACTION
	IF(@vMessage = '')
	BEGIN
		SET @vMessage = N'Thao tác thất bại'
	END
	SELECT 0 AS Result, @vMessage AS MsgProcedure
	RETURN 0
END
GO
--=========================================================================================================================================================
--=========================================================================================================================================================
IF EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CAT_PRODUCTTYPE_GetAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[CAT_PRODUCTTYPE_GetAll]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CAT_PRODUCTTYPE_GetAll]
AS
	SELECT	PRDT.ID,
			PRDT.ProductTypeCode,
			PRDT.ProductTypeName,
			PRDT.Descriptions,
			PRDT.OrderBy,
			PRDT.IsActive,
			PRDT.UpdateDate,
			PRDT.UpdateBy,
			URS.UserName AS UserUpdate,
			PRDT.IsDelete
	FROM dbo.CAT_PRODUCTTYPE PRDT
		 LEFT JOIN dbo.SYS_USERS URS ON URS.ID = PRDT.UpdateBy
	WHERE PRDT.IsDelete = 0
GO
--=========================================================================================================================================================
--=========================================================================================================================================================
IF EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CAT_PRODUCTTYPE_Del]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[CAT_PRODUCTTYPE_Del]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CAT_PRODUCTTYPE_Del]
	@p_ID bigint = -1,
	@p_UpdateBy bigint = -1
AS
BEGIN TRANSACTION
	DECLARE @vMessage nvarchar(max)
	SET @vMessage = ''

	UPDATE CAT_PRODUCTTYPE
	SET IsDelete = 1,
		UpdateBy = @p_UpdateBy,
		UpdateDate = GETDATE()
	WHERE ID = @p_ID
	IF @@Error <> 0 GOTO ABORT

COMMIT TRANSACTION
	SELECT 1 AS Result, @vMessage AS MsgProcedure
	RETURN 1
ABORT:
BEGIN
	ROLLBACK TRANSACTION
	IF(@vMessage = '')
	BEGIN
		SET @vMessage = N'Thao tác thất bại'
	END
	SELECT 0 AS Result, @vMessage AS MsgProcedure
	RETURN 0
END
GO
--=========================================================================================================================================================
--=========================================================================================================================================================
IF EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CAT_PRODUCTGROUP_Search]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[CAT_PRODUCTGROUP_Search]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CAT_PRODUCTGROUP_Search]
	@p_ID bigint = -1,
	@p_ProductGroupCode  varchar(15) = '',
	@p_ProductGroupName  nvarchar(500) = '',
	@p_Descriptions nvarchar(max) = '',
	@p_IsActive bit = NULL,
	@p_OrderBy bigint = -1
AS
	SELECT	PRDG.ID,
			PRDG.ProductGroupCode,
			PRDG.ProductGroupName,
			PRDG.Descriptions,
			PRDG.OrderBy,
			PRDG.IsActive,
			PRDG.UpdateDate,
			PRDG.UpdateBy,
			URS.UserName AS UserUpdate,
			PRDG.IsDelete
	FROM dbo.CAT_PRODUCTGROUP PRDG
		 LEFT JOIN dbo.SYS_USERS URS ON URS.ID = PRDG.UpdateBy
	WHERE PRDG.IsDelete = 0
		  AND (PRDG.ID = @p_ID OR @p_ID = -1 OR @p_ID IS NULL)
		  AND (PRDG.ProductGroupCode = @p_ProductGroupCode OR @p_ProductGroupCode = '' OR @p_ProductGroupCode IS NULL)
		  AND (PRDG.ProductGroupName = @p_ProductGroupName OR @p_ProductGroupName = '' OR @p_ProductGroupName IS NULL)
		  AND (PRDG.Descriptions = @p_Descriptions OR @p_Descriptions = '' OR @p_Descriptions IS NULL)
		  AND (PRDG.IsActive = @p_IsActive OR @p_IsActive = -1 OR @p_IsActive IS NULL)
		  AND (PRDG.OrderBy = @p_OrderBy OR @p_OrderBy = -1 OR @p_OrderBy IS NULL)
GO
--=========================================================================================================================================================
--=========================================================================================================================================================
IF EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CAT_PRODUCTGROUP_InsUpd]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[CAT_PRODUCTGROUP_InsUpd]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CAT_PRODUCTGROUP_InsUpd]
	@p_ID bigint = -1,
	@p_ProductGroupCode  varchar(15) = '',
	@p_ProductGroupName  nvarchar(500) = '',
	@p_Descriptions nvarchar(max) = '',
	@p_OrderBy bigint = -1,
	@p_IsActive bit = 1,
	@p_UpdateBy bigint = -1
AS
BEGIN TRANSACTION
	DECLARE @vMessage nvarchar(max)
	SET @vMessage = ''

	IF(@p_ID = -1 OR @p_ID IS NULL)
	BEGIN
		INSERT INTO [dbo].[CAT_PRODUCTGROUP]
		       (ProductGroupCode,
				ProductGroupName,
				Descriptions,
				OrderBy,
				IsActive,
				UpdateDate,
				UpdateBy,
				IsDelete)
		VALUES
		       (@p_ProductGroupCode,
		        @p_ProductGroupName,
		        @p_Descriptions,
		        @p_OrderBy,
		        1,
				GETDATE(),
		        @p_UpdateBy,
		        0)
		IF @@Error <> 0 GOTO ABORT
	END
	ELSE
	BEGIN
		UPDATE [dbo].[CAT_PRODUCTGROUP]
		SET ProductGroupCode = @p_ProductGroupCode,
			ProductGroupName = @p_ProductGroupName,
			Descriptions =  @p_Descriptions,
			OrderBy = @p_OrderBy,
			IsActive = @p_IsActive,
			UpdateDate = GETDATE(),
			UpdateBy = @p_UpdateBy,
			IsDelete = 0
		WHERE [ID] = @p_ID
		IF @@Error <> 0 GOTO ABORT
	END

COMMIT TRANSACTION
	SELECT 1 AS Result, @vMessage AS MsgProcedure
	RETURN 1
ABORT:
BEGIN
	ROLLBACK TRANSACTION
	IF(@vMessage = '')
	BEGIN
		SET @vMessage = N'Thao tác thất bại'
	END
	SELECT 0 AS Result, @vMessage AS MsgProcedure
	RETURN 0
END
GO
--=========================================================================================================================================================
--=========================================================================================================================================================
IF EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CAT_PRODUCTGROUP_GetAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[CAT_PRODUCTGROUP_GetAll]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CAT_PRODUCTGROUP_GetAll]
AS
	SELECT	PRDG.ID,
			PRDG.ProductGroupCode,
			PRDG.ProductGroupName,
			PRDG.Descriptions,
			PRDG.OrderBy,
			PRDG.IsActive,
			PRDG.UpdateDate,
			PRDG.UpdateBy,
			URS.UserName AS UserUpdate,
			PRDG.IsDelete
	FROM dbo.CAT_PRODUCTGROUP PRDG
		 LEFT JOIN dbo.SYS_USERS URS ON URS.ID = PRDG.UpdateBy
	WHERE PRDG.IsDelete = 0
GO
--=========================================================================================================================================================
--=========================================================================================================================================================
IF EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CAT_PRODUCTGROUP_Del]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[CAT_PRODUCTGROUP_Del]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CAT_PRODUCTGROUP_Del]
	@p_ID bigint = -1,
	@p_UpdateBy bigint = -1
AS
BEGIN TRANSACTION
	DECLARE @vMessage nvarchar(max)
	SET @vMessage = ''

	UPDATE CAT_PRODUCTGROUP
	SET IsDelete = 1,
		UpdateBy = @p_UpdateBy,
		UpdateDate = GETDATE()
	WHERE ID = @p_ID
	IF @@Error <> 0 GOTO ABORT

COMMIT TRANSACTION
	SELECT 1 AS Result, @vMessage AS MsgProcedure
	RETURN 1
ABORT:
BEGIN
	ROLLBACK TRANSACTION
	IF(@vMessage = '')
	BEGIN
		SET @vMessage = N'Thao tác thất bại'
	END
	SELECT 0 AS Result, @vMessage AS MsgProcedure
	RETURN 0
END
GO
--=========================================================================================================================================================
--=========================================================================================================================================================
IF EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CAT_PRODUCT_Search]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[CAT_PRODUCT_Search]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CAT_PRODUCT_Search]
	@p_ID bigint = -1,
	@p_ProductCatCode varchar(15) = '',
	@p_ProductCatName nvarchar(500) = '',
	@p_Descriptions nvarchar(max) = '',
	@p_ProductType bigint = -1,
	@p_ProductGroup bigint = -1,
	@p_Supplier bigint = -1,
	@p_ProductCatImage image = NULL,
	@p_IsActive bit = NULL,
	@p_OrderBy bigint = -1
AS
	SELECT	PRDC.ID,
			PRDC.ProductCatCode,
			PRDC.ProductCatName,
			PRDC.Descriptions,
			PRDC.ProductType AS ProductTypeID,
			PRDT.ProductTypeCode,
			PRDT.ProductTypeName,
			PRDC.ProductGroup AS ProductGroupID,
			PRDG.ProductGroupCode,
			PRDG.ProductGroupName,
			PRDC.Supplier AS SupplierID,
			SPL.SupplierCode,
			SPL.SupplierName,
			PRDC.ProductCatImage,
			PRDC.OrderBy,
			PRDC.IsActive,
			PRDC.UpdateDate,
			PRDC.UpdateBy,
			URS.UserName AS UserUpdate,
			PRDC.IsDelete
	FROM CAT_PRODUCT PRDC
		 LEFT JOIN SYS_USERS URS ON URS.ID = PRDC.UpdateBy
		 LEFT JOIN CAT_SUPPLIER SPL ON SPL.ID = PRDC.Supplier
		 LEFT JOIN CAT_PRODUCTTYPE PRDT ON PRDT.ID = PRDC.ProductType
		 LEFT JOIN CAT_PRODUCTGROUP PRDG ON PRDG.ID = PRDC.ProductGroup
	WHERE PRDC.IsDelete = 0
		  AND (PRDC.ID = @p_ID OR @p_ID = -1 OR @p_ID IS NULL)
		  AND (PRDC.ProductCatCode = @p_ProductCatCode OR @p_ProductCatCode = '' OR @p_ProductCatCode IS NULL)
		  AND (PRDC.ProductCatName = @p_ProductCatName OR @p_ProductCatName = '' OR @p_ProductCatName IS NULL)
		  AND (PRDC.Descriptions = @p_Descriptions OR @p_Descriptions = '' OR @p_Descriptions IS NULL)
		  AND (PRDC.ID = @p_ProductType OR @p_ProductType = -1 OR @p_ProductType IS NULL)
		  AND (PRDC.ProductGroup = @p_ProductGroup OR @p_ProductGroup = -1 OR @p_ProductGroup IS NULL)
		  AND (PRDC.Supplier = @p_Supplier OR @p_Supplier = -1 OR @p_Supplier IS NULL)
		  AND (CAST(PRDC.ProductCatImage AS varbinary(max)) = CAST(@p_ProductCatImage AS varbinary(max)) OR @p_ProductCatImage IS NULL)
		  AND (PRDC.IsActive = @p_IsActive OR @p_IsActive = -1 OR @p_IsActive IS NULL)
		  AND (PRDC.OrderBy = @p_OrderBy OR @p_OrderBy = -1 OR @p_OrderBy IS NULL)
GO
--=========================================================================================================================================================
--=========================================================================================================================================================
IF EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CAT_PRODUCT_InsUpd]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[CAT_PRODUCT_InsUpd]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CAT_PRODUCT_InsUpd]
	@p_ID bigint = -1,
	@p_ProductCatCode varchar(15) = '',
	@p_ProductCatName nvarchar(500) = '',
	@p_Descriptions nvarchar(max) = '',
	@p_ProductType bigint = -1,
	@p_ProductGroup bigint = -1,
	@p_Supplier bigint = -1,
	@p_ProductCatImage image = NULL,
	@p_OrderBy bigint = -1,
	@p_IsActive bit = 1,
	@p_UpdateBy bigint = -1
AS
BEGIN TRANSACTION
	DECLARE @vMessage nvarchar(max)
	SET @vMessage = ''

	IF(@p_ID = -1 OR @p_ID IS NULL)
	BEGIN
		INSERT INTO [dbo].[CAT_PRODUCT]
		       (ProductCatCode,
				ProductCatName,
				Descriptions,
				ProductType,
				ProductGroup,
				Supplier,
				ProductCatImage,
				OrderBy,
				IsActive,
				UpdateDate,
				UpdateBy,
				IsDelete)
		VALUES
		       (@p_ProductCatCode,
		        @p_ProductCatName,
		        @p_Descriptions,
				@p_ProductType,
				@p_ProductGroup,
				@p_Supplier,
				@p_ProductCatImage,
		        @p_OrderBy,
		        1,
				GETDATE(),
		        @p_UpdateBy,
		        0)
		IF @@Error <> 0 GOTO ABORT

		-- Cập nhật thông tin hàng
		INSERT INTO OBJ_PRODUCT (ProductCode,
								 ProductDesc,
								 Descriptions,
								 ProductType,
								 ProductGroup,
								 UnitWeight,
								 UnitSell,
								 Supplier,
								 StatusCode,
								 UpdateDate,
								 UpdateBy,
								 IsDelete)
		VALUES ( @p_ProductCatCode,
				 @p_ProductCatName,
				 @p_Descriptions,
				 0,
				 @p_ProductGroup,
				 0,
				 0,
				 0,
				 'I',
				 GETDATE(),
				 @p_UpdateBy,
				 0)
		IF @@Error <> 0 GOTO ABORT

		-- Thêm vào giá bán
		INSERT INTO SYS_PRODUCT_RATE (ProductID,
									  RateDate,
									  RateIn,
									  RateEstimate,
									  DiscountPercent,
									  Discount,
									  DiscountTotal,
									  RateSell,
									  IsSellCurrent)
		VALUES ( @p_ProductCatCode,
				 GETDATE(),
				 0,
				 0,
				 0,
				 0,
				 0,
				 0,
				 1)
		IF @@Error <> 0 GOTO ABORT
	END
	ELSE
	BEGIN
		UPDATE [dbo].[CAT_PRODUCT]
		SET ProductCatName = @p_ProductCatName,
			Descriptions =  @p_Descriptions,
			ProductType = @p_ProductType,
			ProductGroup = @p_ProductGroup,
			Supplier = @p_Supplier, 
			ProductCatImage = @p_ProductCatImage,
			OrderBy = @p_OrderBy,
			IsActive = @p_IsActive,
			UpdateDate = GETDATE(),
			UpdateBy = @p_UpdateBy,
			IsDelete = 0
		WHERE [ID] = @p_ID
		IF @@Error <> 0 GOTO ABORT

		UPDATE [dbo].[OBJ_PRODUCT]
		SET ProductDesc = @p_ProductCatName,
			Descriptions =  @p_Descriptions,
			ProductGroup = @p_ProductGroup,
			Supplier = @p_Supplier,
			UpdateDate = GETDATE(),
			UpdateBy = @p_UpdateBy,
			IsDelete = 0
		WHERE [ID] = @p_ID
		IF @@Error <> 0 GOTO ABORT
	END

COMMIT TRANSACTION
	SELECT 1 AS Result, @vMessage AS MsgProcedure
	RETURN 1
ABORT:
BEGIN
	ROLLBACK TRANSACTION
	IF(@vMessage = '')
	BEGIN
		SET @vMessage = N'Thao tác thất bại'
	END
	SELECT 0 AS Result, @vMessage AS MsgProcedure
	RETURN 0
END
GO
--=========================================================================================================================================================
--=========================================================================================================================================================
IF EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CAT_PRODUCT_GetAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[CAT_PRODUCT_GetAll]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CAT_PRODUCT_GetAll]
AS
	SELECT	PRDC.ID,
			PRDC.ProductCatCode,
			PRDC.ProductCatName,
			PRDC.Descriptions,
			PRDC.ProductType AS ProductTypeID,
			PRDT.ProductTypeCode,
			PRDT.ProductTypeName,			
			PRDC.ProductGroup AS ProductGroupID,
			PRDG.ProductGroupCode,
			PRDG.ProductGroupName,
			PRDC.Supplier AS SupplierID,
			SPL.SupplierCode,
			SPL.SupplierName,
			PRDC.ProductCatImage,
			PRDC.OrderBy,
			PRDC.IsActive,
			PRDC.UpdateDate,
			PRDC.UpdateBy,
			URS.UserName AS UserUpdate,
			PRDC.IsDelete
	FROM CAT_PRODUCT PRDC
		 LEFT JOIN SYS_USERS URS ON URS.ID = PRDC.UpdateBy
		 LEFT JOIN CAT_SUPPLIER SPL ON SPL.ID = PRDC.Supplier
		 LEFT JOIN CAT_PRODUCTTYPE PRDT ON PRDT.ID = PRDC.ProductType
		 LEFT JOIN CAT_PRODUCTGROUP PRDG ON PRDG.ID = PRDC.ProductGroup
	WHERE PRDC.IsDelete = 0
GO
--=========================================================================================================================================================
--=========================================================================================================================================================
IF EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CAT_PRODUCT_Del]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[CAT_PRODUCT_Del]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CAT_PRODUCT_Del]
	@p_ID bigint = -1,
	@p_UpdateBy bigint = -1
AS
BEGIN TRANSACTION
	DECLARE @vMessage nvarchar(max)
	SET @vMessage = ''

	UPDATE CAT_PRODUCT
	SET IsDelete = 1,
		UpdateBy = @p_UpdateBy,
		UpdateDate = GETDATE()
	WHERE ID = @p_ID
	IF @@Error <> 0 GOTO ABORT

COMMIT TRANSACTION
	SELECT 1 AS Result, @vMessage AS MsgProcedure
	RETURN 1
ABORT:
BEGIN
	ROLLBACK TRANSACTION
	IF(@vMessage = '')
	BEGIN
		SET @vMessage = N'Thao tác thất bại'
	END
	SELECT 0 AS Result, @vMessage AS MsgProcedure
	RETURN 0
END
GO
--=========================================================================================================================================================
--=========================================================================================================================================================
IF EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CAT_EMPLOYEE_Search]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[CAT_EMPLOYEE_Search]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CAT_EMPLOYEE_Search]
	@p_ID bigint = -1,
	@p_EmpCode varchar(15) = '',
	@p_EmpName nvarchar(500) = '',
	@p_UserID bigint = -1,
	@p_ShopID bigint = -1,
	@p_IsActive bit = NULL,
	@p_OrderBy bigint = -1
AS
	SELECT	EMP.ID,
			EMP.EmpCode,
			EMP.EmpName,
			EMP.UserID,
			URS.UserName AS UserName,
			EMP.ShopID,
			SHP.ShopName,
			EMP.OrderBy,
			EMP.IsActive,
			EMP.UpdateDate,
			EMP.UpdateBy,
			URSS.UserName AS UserUpdate,
			EMP.IsDelete
	FROM dbo.CAT_EMPLOYEE EMP
		 LEFT JOIN dbo.SYS_USERS URS ON URS.ID = EMP.UpdateBy
		 LEFT JOIN dbo.CAT_SHOP SHP ON SHP.ID = URS.ShopID
		 LEFT JOIN dbo.SYS_USERS URSS ON URS.ID = EMP.UpdateBy
	WHERE EMP.IsDelete = 0
		  AND (EMP.ID = @p_ID OR @p_ID = -1 OR @p_ID IS NULL)
		  AND (EMP.EmpCode = @p_EmpCode OR @p_EmpCode = '' OR @p_EmpCode IS NULL)
		  AND (EMP.EmpName = @p_EmpName OR @p_EmpName = '' OR @p_EmpName IS NULL)
		  AND (EMP.UserID = @p_UserID OR @p_UserID = -1 OR @p_UserID IS NULL)
		  AND (EMP.ShopID = @p_ShopID OR @p_ShopID = -1 OR @p_ShopID IS NULL)		
		  AND (EMP.IsActive = @p_IsActive OR @p_IsActive = -1 OR @p_IsActive IS NULL)	    
		  AND (EMP.OrderBy = @p_OrderBy OR @p_OrderBy = -1 OR @p_OrderBy IS NULL)
GO
--=========================================================================================================================================================
--=========================================================================================================================================================
IF EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CAT_EMPLOYEE_InsUpd]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[CAT_EMPLOYEE_InsUpd]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CAT_EMPLOYEE_InsUpd]
	@p_ID bigint = -1,
	@p_EmpCode varchar(15) = '',
	@p_EmpName nvarchar(500) = '',
	@p_UserID bigint = -1,
	@p_ShopID bigint = -1,
	@p_OrderBy bigint = -1,
	@p_IsActive bit = 1,
	@p_UpdateBy bigint = -1
AS
BEGIN TRANSACTION
	DECLARE @vMessage nvarchar(max)
	SET @vMessage = ''

	IF(@p_ID = -1 OR @p_ID IS NULL)
	BEGIN
		INSERT INTO [dbo].[CAT_EMPLOYEE]
		       (EmpCode,
				EmpName,
				UserID,
				ShopID,
				OrderBy,
				IsActive,
				UpdateDate,
				UpdateBy,
				IsDelete)
		VALUES
		       (@p_EmpCode,
		        @p_EmpName,
		        @p_UserID,
		        @p_ShopID,
		        @p_OrderBy,
		        1,
				GETDATE(),
		        @p_UpdateBy,
		        0)
		IF @@Error <> 0 GOTO ABORT
	END
	ELSE
	BEGIN
		UPDATE [dbo].[CAT_EMPLOYEE]
		SET EmpCode = @p_EmpCode,
			EmpName = @p_EmpName,
			UserID = @p_UserID,
			ShopID = @p_ShopID,
			OrderBy = @p_OrderBy,
			IsActive = @p_IsActive,
			UpdateDate = GETDATE(),
			UpdateBy = @p_UpdateBy,
			IsDelete = 0
		WHERE [ID] = @p_ID
		IF @@Error <> 0 GOTO ABORT
	END

COMMIT TRANSACTION
	SELECT 1 AS Result, @vMessage AS MsgProcedure
	RETURN 1
ABORT:
BEGIN
	ROLLBACK TRANSACTION
	IF(@vMessage = '')
	BEGIN
		SET @vMessage = N'Thao tác thất bại'
	END
	SELECT 0 AS Result, @vMessage AS MsgProcedure
	RETURN 0
END
GO
--=========================================================================================================================================================
--=========================================================================================================================================================
IF EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CAT_EMPLOYEE_GetAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[CAT_EMPLOYEE_GetAll]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CAT_EMPLOYEE_GetAll]
AS
	SELECT	EMP.ID,
			EMP.EmpCode,
			EMP.EmpName,
			EMP.UserID,
			URS.UserName AS UserName,
			EMP.ShopID,
			SHP.ShopName,
			EMP.OrderBy,
			EMP.IsActive,
			EMP.UpdateDate,
			EMP.UpdateBy,
			URSS.UserName AS UserUpdate,
			EMP.IsDelete
	FROM dbo.CAT_EMPLOYEE EMP
		 LEFT JOIN dbo.SYS_USERS URS ON URS.ID = EMP.UpdateBy
		 LEFT JOIN dbo.CAT_SHOP SHP ON SHP.ID = URS.ShopID
		 LEFT JOIN dbo.SYS_USERS URSS ON URS.ID = EMP.UpdateBy
	WHERE EMP.IsDelete = 0
GO
--=========================================================================================================================================================
--=========================================================================================================================================================
IF EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CAT_EMPLOYEE_Del]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[CAT_EMPLOYEE_Del]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CAT_EMPLOYEE_Del]
	@p_ID bigint = -1,
	@p_UpdateBy bigint = -1
AS
BEGIN TRANSACTION
	DECLARE @vMessage nvarchar(max)
	SET @vMessage = ''

	UPDATE CAT_EMPLOYEE
	SET IsDelete = 1,
		UpdateBy = @p_UpdateBy,
		UpdateDate = GETDATE()
	WHERE ID = @p_ID
	IF @@Error <> 0 GOTO ABORT

COMMIT TRANSACTION
	SELECT 1 AS Result, @vMessage AS MsgProcedure
	RETURN 1
ABORT:
BEGIN
	ROLLBACK TRANSACTION
	IF(@vMessage = '')
	BEGIN
		SET @vMessage = N'Thao tác thất bại'
	END
	SELECT 0 AS Result, @vMessage AS MsgProcedure
	RETURN 0
END
GO
--=========================================================================================================================================================
--=========================================================================================================================================================
IF EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CAT_CUSTOMERTYPE_Search]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[CAT_CUSTOMERTYPE_Search]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CAT_CUSTOMERTYPE_Search]
	@p_ID bigint = -1,
	@p_CustTypeCode  varchar(15) = '',
	@p_CustTypeName  nvarchar(500) = '',
	@p_Notes nvarchar(max) = '',
	@p_IsActive bit = NULL,
	@p_OrderBy bigint = -1
AS
	SELECT	CUST.ID,
			CUST.CustTypeCode,
			CUST.CustTypeName,
			CUST.Notes,
			CUST.OrderBy,
			CUST.IsActive,
			CUST.UpdateDate,
			CUST.UpdateBy,
			URS.UserName AS UserUpdate,
			CUST.IsDelete
	FROM dbo.CAT_CUSTOMERTYPE CUST
		 LEFT JOIN dbo.SYS_USERS URS ON URS.ID = CUST.UpdateBy
	WHERE CUST.IsDelete = 0
		  AND (CUST.ID = @p_ID OR @p_ID = -1 OR @p_ID IS NULL)
		  AND (CUST.CustTypeCode = @p_CustTypeCode OR @p_CustTypeCode = '' OR @p_CustTypeCode IS NULL)
		  AND (CUST.CustTypeName = @p_CustTypeName OR @p_CustTypeName = '' OR @p_CustTypeName IS NULL)
		  AND (CUST.Notes = @p_Notes OR @p_Notes = '' OR @p_Notes IS NULL)
		  AND (CUST.IsActive = @p_IsActive OR @p_IsActive = -1 OR @p_IsActive IS NULL)
		  AND (CUST.OrderBy = @p_OrderBy OR @p_OrderBy = -1 OR @p_OrderBy IS NULL)
GO
--=========================================================================================================================================================
--=========================================================================================================================================================
IF EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CAT_CUSTOMERTYPE_InsUpd]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[CAT_CUSTOMERTYPE_InsUpd]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CAT_CUSTOMERTYPE_InsUpd]
	@p_ID bigint = -1,
	@p_CustTypeCode  varchar(15) = '',
	@p_CustTypeName  nvarchar(500) = '',
	@p_Notes nvarchar(max) = '',
	@p_OrderBy bigint = -1,
	@p_IsActive bit = 1,
	@p_UpdateBy bigint = -1
AS
BEGIN TRANSACTION
	DECLARE @vMessage nvarchar(max)
	SET @vMessage = ''

	IF(@p_ID = -1 OR @p_ID IS NULL)
	BEGIN
		INSERT INTO [dbo].[CAT_CUSTOMERTYPE]
		       (CustTypeCode,
				CustTypeName,
				Notes,
				OrderBy,
				IsActive,
				UpdateDate,
				UpdateBy,
				IsDelete)
		VALUES
		       (@p_CustTypeCode,
		        @p_CustTypeName,
		        @p_Notes,
		        @p_OrderBy,
		        1,
				GETDATE(),
		        @p_UpdateBy,
		        0)
		IF @@Error <> 0 GOTO ABORT
	END
	ELSE
	BEGIN
		UPDATE [dbo].[CAT_CUSTOMERTYPE]
		SET CustTypeCode = @p_CustTypeCode,
			CustTypeName = @p_CustTypeName,
			Notes =  @p_Notes,
			OrderBy = @p_OrderBy,
			IsActive = @p_IsActive,
			UpdateDate = GETDATE(),
			UpdateBy = @p_UpdateBy,
			IsDelete = 0
		WHERE [ID] = @p_ID
		IF @@Error <> 0 GOTO ABORT
	END

COMMIT TRANSACTION
	SELECT 1 AS Result, @vMessage AS MsgProcedure
	RETURN 1
ABORT:
BEGIN
	ROLLBACK TRANSACTION
	IF(@vMessage = '')
	BEGIN
		SET @vMessage = N'Thao tác thất bại'
	END
	SELECT 0 AS Result, @vMessage AS MsgProcedure
	RETURN 0
END
GO
--=========================================================================================================================================================
--=========================================================================================================================================================
IF EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CAT_CUSTOMERTYPE_GetAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[CAT_CUSTOMERTYPE_GetAll]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CAT_CUSTOMERTYPE_GetAll]
AS
	SELECT	CUST.ID,
			CUST.CustTypeCode,
			CUST.CustTypeName,
			CUST.Notes,
			CUST.OrderBy,
			CUST.IsActive,
			CUST.UpdateDate,
			CUST.UpdateBy,
			URS.UserName AS UserUpdate,
			CUST.IsDelete
	FROM dbo.CAT_CUSTOMERTYPE CUST
		 LEFT JOIN dbo.SYS_USERS URS ON URS.ID = CUST.UpdateBy
	WHERE CUST.IsDelete = 0
GO
--=========================================================================================================================================================
--=========================================================================================================================================================
IF EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CAT_CUSTOMERTYPE_Del]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[CAT_CUSTOMERTYPE_Del]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CAT_CUSTOMERTYPE_Del]
	@p_ID bigint = -1,
	@p_UpdateBy bigint = -1
AS
BEGIN TRANSACTION
	DECLARE @vMessage nvarchar(max)
	SET @vMessage = ''

	UPDATE CAT_CUSTOMERTYPE
	SET IsDelete = 1,
		UpdateBy = @p_UpdateBy,
		UpdateDate = GETDATE()
	WHERE ID = @p_ID
	IF @@Error <> 0 GOTO ABORT

COMMIT TRANSACTION
	SELECT 1 AS Result, @vMessage AS MsgProcedure
	RETURN 1
ABORT:
BEGIN
	ROLLBACK TRANSACTION
	IF(@vMessage = '')
	BEGIN
		SET @vMessage = N'Thao tác thất bại'
	END
	SELECT 0 AS Result, @vMessage AS MsgProcedure
	RETURN 0
END
GO
--=========================================================================================================================================================
--=========================================================================================================================================================
IF EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CAT_CUSTOMERGROUP_Search]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[CAT_CUSTOMERGROUP_Search]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CAT_CUSTOMERGROUP_Search]
	@p_ID bigint = -1, 
	@p_CustGroupCode varchar(15) = '',
	@p_CustGroupName nvarchar(500) = '',
	@p_Notes nvarchar(max) = '',
	@p_IsActive bit = NULL,
	@p_OrderBy bigint = -1
AS
	SELECT	CUSG.ID,
			CUSG.CustGroupCode,
			CUSG.CustGroupName,
			CUSG.Notes,
			CUSG.OrderBy,
			CUSG.IsActive,
			CUSG.UpdateDate,
			CUSG.UpdateBy,
			URS.UserName AS UserUpdate,
			CUSG.IsDelete
	FROM dbo.CAT_CUSTOMERGROUP CUSG
		 LEFT JOIN dbo.SYS_USERS URS ON URS.ID = CUSG.UpdateBy
	WHERE CUSG.IsDelete = 0
		  AND (CUSG.ID = @p_ID OR @p_ID = -1 OR @p_ID IS NULL)
		  AND (CUSG.CustGroupCode = @p_CustGroupCode OR @p_CustGroupCode = '' OR @p_CustGroupCode IS NULL)
		  AND (CUSG.CustGroupName = @p_CustGroupName OR @p_CustGroupName = '' OR @p_CustGroupName IS NULL)
		  AND (CUSG.Notes = @p_Notes OR @p_Notes = '' OR @p_Notes IS NULL)	
		  AND (CUSG.IsActive = @p_IsActive OR @p_IsActive = -1 OR @p_IsActive IS NULL)	  
		  AND (CUSG.OrderBy = @p_OrderBy OR @p_OrderBy = -1 OR @p_OrderBy IS NULL)
GO
--=========================================================================================================================================================
--=========================================================================================================================================================
IF EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CAT_CUSTOMERGROUP_InsUpd]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[CAT_CUSTOMERGROUP_InsUpd]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CAT_CUSTOMERGROUP_InsUpd]
	@p_ID bigint = -1, 
	@p_CustGroupCode varchar(15) = '',
	@p_CustGroupName nvarchar(500) = '',
	@p_Notes nvarchar(max) = '',
	@p_OrderBy bigint = -1,
	@p_IsActive bit = 1,
	@p_UpdateBy bigint = -1
AS
BEGIN TRANSACTION
	DECLARE @vMessage nvarchar(max)
	SET @vMessage = ''

	IF(@p_ID = -1 OR @p_ID IS NULL)
	BEGIN
		INSERT INTO [dbo].[CAT_CUSTOMERGROUP]
		       (CustGroupCode,
				CustGroupName,
				Notes,
				OrderBy,
				IsActive,
				UpdateDate,
				UpdateBy,
				IsDelete)
		VALUES
		       (@p_CustGroupCode,
		        @p_CustGroupName,
		        @p_Notes,
		        @p_OrderBy,
		        1,
				GETDATE(),
		        @p_UpdateBy,
		        0)
		IF @@Error <> 0 GOTO ABORT
	END
	ELSE
	BEGIN
		UPDATE [dbo].[CAT_CUSTOMERGROUP]
		SET CustGroupCode = @p_CustGroupCode,
			CustGroupName = @p_CustGroupName,
			Notes = @p_Notes,
			OrderBy = @p_OrderBy,
			IsActive = @p_IsActive,
			UpdateDate = GETDATE(),
			UpdateBy = @p_UpdateBy,
			IsDelete = 0
		WHERE [ID] = @p_ID
		IF @@Error <> 0 GOTO ABORT
	END

COMMIT TRANSACTION
	SELECT 1 AS Result, @vMessage AS MsgProcedure
	RETURN 1
ABORT:
BEGIN
	ROLLBACK TRANSACTION
	IF(@vMessage = '')
	BEGIN
		SET @vMessage = N'Thao tác thất bại'
	END
	SELECT 0 AS Result, @vMessage AS MsgProcedure
	RETURN 0
END
GO
--=========================================================================================================================================================
--=========================================================================================================================================================
IF EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CAT_CUSTOMERGROUP_GetAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[CAT_CUSTOMERGROUP_GetAll]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CAT_CUSTOMERGROUP_GetAll]
AS
	SELECT	CUSG.ID,
			CUSG.CustGroupCode,
			CUSG.CustGroupName,
			CUSG.Notes,
			CUSG.OrderBy,
			CUSG.IsActive,
			CUSG.UpdateDate,
			CUSG.UpdateBy,
			URS.UserName AS UserUpdate,
			CUSG.IsDelete
	FROM dbo.CAT_CUSTOMERGROUP CUSG
		 LEFT JOIN dbo.SYS_USERS URS ON URS.ID = CUSG.UpdateBy
	WHERE CUSG.IsDelete = 0
GO
--=========================================================================================================================================================
--=========================================================================================================================================================
IF EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CAT_CUSTOMERGROUP_Del]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[CAT_CUSTOMERGROUP_Del]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CAT_CUSTOMERGROUP_Del]
	@p_ID bigint = -1,
	@p_UpdateBy bigint = -1
AS
BEGIN TRANSACTION
	DECLARE @vMessage nvarchar(max)
	SET @vMessage = ''

	UPDATE CAT_CUSTOMERGROUP
	SET IsDelete = 1,
		UpdateBy = @p_UpdateBy,
		UpdateDate = GETDATE()
	WHERE ID = @p_ID
	IF @@Error <> 0 GOTO ABORT

COMMIT TRANSACTION
	SELECT 1 AS Result, @vMessage AS MsgProcedure
	RETURN 1
ABORT:
BEGIN
	ROLLBACK TRANSACTION
	IF(@vMessage = '')
	BEGIN
		SET @vMessage = N'Thao tác thất bại'
	END
	SELECT 0 AS Result, @vMessage AS MsgProcedure
	RETURN 0
END
GO
--=========================================================================================================================================================
--=========================================================================================================================================================
IF EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CAT_CUSTOMER_Search]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[CAT_CUSTOMER_Search]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CAT_CUSTOMER_Search]
	@p_ID bigint = -1,
	@p_CustCode varchar(15) = '',
	@p_CustName nvarchar(500) = '',
	@p_CustAddress nvarchar(max) = '',
	@p_Phone varchar(30) = '',
	@p_Notes nvarchar(max) = '',
	@p_IdentificationCard varchar(20) = '',
	@p_BirthDate datetime = NULL,
	@p_Gender bit = NULL,
	@p_Email varchar(128) = '',
	@p_CustGroupID bigint = -1,
	@p_CustTypeID bigint = -1,
	@p_OrderBy bigint = -1,
	@p_IsActive bit = NULL
AS
	SELECT	CUS.ID,
			CUS.CustCode,
			CUS.CustName,
			CUS.CustAddress,
			CUS.Phone,
			CUS.Notes,
			CUS.IdentificationCard,
			CUS.BirthDate,
			CUS.Gender,
			CUS.Email,
			CUS.CustGroupID,
			CUSG.CustGroupName,
			CUS.CustTypeID,
			CUST.CustTypeName,
			CUS.OrderBy,
			CUS.IsActive,
			CUS.UpdateDate,
			CUS.UpdateBy,
			URS.UserName AS UserUpdate,
			CUS.IsDelete
	FROM dbo.CAT_CUSTOMER CUS
		 LEFT JOIN dbo.CAT_CUSTOMERGROUP CUSG ON CUSG.ID = CUS.CustGroupID
		 LEFT JOIN dbo.CAT_CUSTOMERTYPE CUST ON CUST.ID = CUS.CustTypeID
		 LEFT JOIN dbo.SYS_USERS URS ON URS.ID = CUS.UpdateBy
	WHERE CUS.IsDelete = 0
		  AND (CUS.ID = @p_ID OR @p_ID = -1 OR @p_ID IS NULL)
		  AND (CUS.CustCode = @p_CustCode OR @p_CustCode = '' OR @p_CustCode IS NULL)
		  AND (CUS.CustName = @p_CustName OR @p_CustName = '' OR @p_CustName IS NULL)
		  AND (CUS.CustAddress = @p_CustAddress OR @p_CustAddress = '' OR @p_CustAddress IS NULL)
		  AND (CUS.Phone = @p_Phone OR @p_Phone = '' OR @p_Phone IS NULL)
		  AND (CUS.Notes = @p_Notes OR @p_Notes = '' OR @p_Notes IS NULL)
		  AND (CUS.IdentificationCard = @p_IdentificationCard OR @p_IdentificationCard = '' OR @p_IdentificationCard IS NULL)
		  AND (CUS.BirthDate = @p_BirthDate OR @p_BirthDate IS NULL)
		  AND (CUS.Gender = @p_Gender OR @p_Gender IS NULL)
		  AND (CUS.Email = @p_Email OR @p_Email = '' OR @p_Email IS NULL)
		  AND (CUS.CustGroupID = @p_CustGroupID OR @p_CustGroupID = -1 OR @p_CustGroupID IS NULL)
		  AND (CUS.CustTypeID = @p_CustTypeID OR @p_CustTypeID = -1 OR @p_CustTypeID IS NULL)
		  AND (CUS.IsActive = @p_IsActive OR @p_IsActive = -1 OR @p_IsActive IS NULL)		  		  
		  AND (CUS.OrderBy = @p_OrderBy OR @p_OrderBy = -1 OR @p_OrderBy IS NULL)
GO
--=========================================================================================================================================================
--=========================================================================================================================================================
IF EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CAT_CUSTOMER_InsUpd]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[CAT_CUSTOMER_InsUpd]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CAT_CUSTOMER_InsUpd]
	@p_ID bigint = -1,
	@p_CustCode varchar(15) = '',
	@p_CustName nvarchar(500) = '',
	@p_CustAddress nvarchar(max) = '',
	@p_Phone varchar(30) = '',
	@p_Notes nvarchar(max) = '',
	@p_IdentificationCard varchar(20) = '',
	@p_BirthDate datetime = NULL,
	@p_Gender bit = 1,
	@p_Email varchar(128) = '',
	@p_CustGroupID bigint = -1,
	@p_CustTypeID bigint = -1,
	@p_OrderBy bigint = -1,
	@p_IsActive bit = 1,
	@p_UpdateBy bigint = -1
AS
BEGIN TRANSACTION
	DECLARE @vMessage nvarchar(max)
	SET @vMessage = ''

	IF(@p_ID = -1 OR @p_ID IS NULL)
	BEGIN
		INSERT INTO [dbo].[CAT_CUSTOMER]
		       (ID,
				CustCode,
				CustName,
				CustAddress,
				Phone,
				Notes,
				IdentificationCard,
				BirthDate,
				Gender,
				Email,
				CustGroupID,
				CustTypeID,
				OrderBy,
				IsActive,
				UpdateDate,
				UpdateBy,
				IsDelete)
		VALUES
		       (@p_ID,
				@p_CustCode,
				@p_CustName,
				@p_CustAddress,
				@p_Phone,
				@p_Notes,
				@p_IdentificationCard,
				@p_BirthDate,
				@p_Gender,
				@p_Email,
				@p_CustGroupID,
				@p_CustTypeID,
				@p_OrderBy,
		        1,
				GETDATE(),
		        @p_UpdateBy,
		        0)
		IF @@Error <> 0 GOTO ABORT
	END
	ELSE
	BEGIN
		UPDATE [dbo].[CAT_CUSTOMER]
		SET CustCode = @p_CustCode,
			CustName = @p_CustName,
			CustAddress = @p_CustAddress,
			Phone = @p_Phone,
			Notes = @p_Notes,
			IdentificationCard = @p_IdentificationCard,
			BirthDate = @p_BirthDate,
			Gender = @p_Gender,
			Email = @p_Email,
			CustGroupID = @p_CustGroupID,
			CustTypeID = @p_CustTypeID,
			OrderBy = @p_OrderBy,
			IsActive = @p_IsActive,
			UpdateDate = GETDATE(),
			UpdateBy = @p_UpdateBy,
			IsDelete = 0
		WHERE [ID] = @p_ID
		IF @@Error <> 0 GOTO ABORT
	END

COMMIT TRANSACTION
	SELECT 1 AS Result, @vMessage AS MsgProcedure
	RETURN 1
ABORT:
BEGIN
	ROLLBACK TRANSACTION
	IF(@vMessage = '')
	BEGIN
		SET @vMessage = N'Thao tác thất bại'
	END
	SELECT 0 AS Result, @vMessage AS MsgProcedure
	RETURN 0
END
GO
--=========================================================================================================================================================
--=========================================================================================================================================================
IF EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CAT_CUSTOMER_GetAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[CAT_CUSTOMER_GetAll]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CAT_CUSTOMER_GetAll]
AS
	SELECT	CUS.ID,
			CUS.CustCode,
			CUS.CustName,
			CUS.CustAddress,
			CUS.Phone,
			CUS.Notes,
			CUS.IdentificationCard,
			CUS.BirthDate,
			CUS.Gender,
			CUS.Email,
			CUS.CustGroupID,
			CUSG.CustGroupName,
			CUS.CustTypeID,
			CUST.CustTypeName,
			CUS.OrderBy,
			CUS.IsActive,
			CUS.UpdateDate,
			CUS.UpdateBy,
			URS.UserName AS UserUpdate,
			CUS.IsDelete
	FROM dbo.CAT_CUSTOMER CUS
		 LEFT JOIN dbo.CAT_CUSTOMERGROUP CUSG ON CUSG.ID = CUS.CustGroupID
		 LEFT JOIN dbo.CAT_CUSTOMERTYPE CUST ON CUST.ID = CUS.CustTypeID
		 LEFT JOIN dbo.SYS_USERS URS ON URS.ID = CUS.UpdateBy
	WHERE CUS.IsDelete = 0
GO
--=========================================================================================================================================================
--=========================================================================================================================================================
IF EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CAT_CUSTOMER_Del]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[CAT_CUSTOMER_Del]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CAT_CUSTOMER_Del]
	@p_ID bigint = -1,
	@p_UpdateBy bigint = -1
AS
BEGIN TRANSACTION
	DECLARE @vMessage nvarchar(max)
	SET @vMessage = ''

	UPDATE CAT_CUSTOMER
	SET IsDelete = 1,
		UpdateBy = @p_UpdateBy,
		UpdateDate = GETDATE()
	WHERE ID = @p_ID
	IF @@Error <> 0 GOTO ABORT

COMMIT TRANSACTION
	SELECT 1 AS Result, @vMessage AS MsgProcedure
	RETURN 1
ABORT:
BEGIN
	ROLLBACK TRANSACTION
	IF(@vMessage = '')
	BEGIN
		SET @vMessage = N'Thao tác thất bại'
	END
	SELECT 0 AS Result, @vMessage AS MsgProcedure
	RETURN 0
END
GO
--=========================================================================================================================================================
--=========================================================================================================================================================
IF EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CAT_COUNTER_Search]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[CAT_COUNTER_Search]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CAT_COUNTER_Search]
	@p_ID bigint = -1,
	@p_CounterCode varchar(15) = '',
	@p_CounterName nvarchar(500) = '',
	@p_StatusCode varchar(15) = '',
	@p_ShopID bigint = -1,
	@p_IsActive bit = NULL,
	@p_OrderBy bigint = -1
AS
	SELECT	[ID],
			[CounterCode],
			[CounterName],
			[StatusCode],
			[ShopID],
			[OrderBy],
			[IsActive],
			[UpdateDate],
			[UpdateBy],
			[IsDelete]
	FROM [dbo].[CAT_COUNTER] CNT
	WHERE CNT.IsDelete = 0
		  AND (CNT.ID = @p_ID OR @p_ID = -1 OR @p_ID IS NULL)
		  AND (CNT.CounterCode = @p_CounterCode OR @p_CounterCode = '' OR @p_CounterCode IS NULL)
		  AND (CNT.CounterName = @p_CounterName OR @p_CounterName = '' OR @p_CounterName IS NULL)
		  AND (CNT.StatusCode = @p_StatusCode OR @p_StatusCode = '' OR @p_StatusCode IS NULL)
		  AND (CNT.ShopID = @p_ShopID OR @p_ShopID = -1 OR @p_ShopID IS NULL)
		  AND (CNT.IsActive = @p_IsActive OR @p_IsActive = -1 OR @p_IsActive IS NULL)
		  AND (CNT.OrderBy = @p_OrderBy OR @p_OrderBy = -1 OR @p_OrderBy IS NULL)
GO
--=========================================================================================================================================================
--=========================================================================================================================================================
IF EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CAT_COUNTER_OpenClose]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[CAT_COUNTER_OpenClose]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CAT_COUNTER_OpenClose]
	@p_Counter bigint = -1,
	@p_EmpID bigint = -1,
	@p_Types bit = 1
AS
BEGIN TRANSACTION
	DECLARE @vMessage nvarchar(max)
	SET @vMessage = ''

	IF @p_Counter <> -1 OR @p_Counter IS NOT NULL
	BEGIN
		DECLARE @vStatusCode varchar(5)
		IF @p_Types = 1
		BEGIN
			SET @vStatusCode = 'O'
		END
		ELSE
		BEGIN
			SET @vStatusCode = 'C'
		END

		UPDATE CAT_COUNTER SET StatusCode = @vStatusCode WHERE ID = @p_Counter
		IF @@Error <> 0 GOTO ABORT

		IF EXISTS (SELECT TOP 1 1 FROM CAT_COUNTER_LOG WHERE CounterID = @p_Counter AND EmpID = @p_EmpID AND StatusCode = @vStatusCode)
		BEGIN
			UPDATE CAT_COUNTER_LOG
			SET CounterDateTime = GETDATE()
			WHERE CounterID = @p_Counter 
				  AND EmpID = @p_EmpID 
				  AND StatusCode = @vStatusCode
		END
		ELSE
		BEGIN
			INSERT INTO CAT_COUNTER_LOG (CounterID, EmpID, CounterDateTime, StatusCode)
			VALUES (@p_Counter, @p_EmpID, GETDATE(), @vStatusCode)
		END
		IF @@Error <> 0 GOTO ABORT
	END
	ELSE
	BEGIN
		SET @vMessage = N'Quầy thu ngân không tồn tại'
	END

COMMIT TRANSACTION
	SELECT 1 AS Result, @vMessage AS MsgProcedure
	RETURN 1
ABORT:
BEGIN
	ROLLBACK TRANSACTION
	IF(@vMessage = '')
	BEGIN
		SET @vMessage = N'Thao tác thất bại'
	END
	SELECT 0 AS Result, @vMessage AS MsgProcedure
	RETURN 0
END
GO
--=========================================================================================================================================================
--=========================================================================================================================================================
IF EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CAT_COUNTER_LOG_Search]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[CAT_COUNTER_LOG_Search]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CAT_COUNTER_LOG_Search]
	@p_CounterID bigint = -1,
	@p_EmpID bigint = -1,
	@p_StatusCode varchar(5) = ''
AS
	SELECT	CNTL.CounterID,
			CNT.CounterName,
			CNTL.EmpID,
			EMP.EmpName,
			CounterDateTime,
			CNT.StatusCode,
			STS.StatusName
	FROM CAT_COUNTER_LOG CNTL
		 LEFT JOIN CAT_COUNTER CNT ON CNT.ID = CNTL.CounterID
		 LEFT JOIN CAT_EMPLOYEE EMP ON EMP.ID = CNTL.EmpID
		 LEFT JOIN SYS_STATUS STS ON STS.StatusCode = CNTL.StatusCode AND STS.StatusObject = 'CAT_COUNTER'
	WHERE 1 = 1 
		  AND (CNTL.CounterID = @p_CounterID OR @p_CounterID = -1 OR @p_CounterID IS NULL)
		  AND (CNTL.EmpID = @p_EmpID OR @p_EmpID = -1 OR @p_EmpID IS NULL)
		  AND (CNTL.StatusCode = @p_StatusCode OR @p_StatusCode = '' OR @p_StatusCode IS NULL)
GO
--=========================================================================================================================================================
--=========================================================================================================================================================
IF EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CAT_COUNTER_LOG_GetWithCounter]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[CAT_COUNTER_LOG_GetWithCounter]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CAT_COUNTER_LOG_GetWithCounter]
	@p_CounterID bigint = -1
AS
	SELECT TOP 1 CNTL.CounterID,
				  CNT.CounterName,
				  CNTL.EmpID,
				  EMP.EmpName,
				  CNTL.CounterDateTime,
				  CNT.StatusCode,
				  STS.StatusName
	FROM CAT_COUNTER_LOG CNTL
		 LEFT JOIN CAT_COUNTER CNT ON CNT.ID = CNTL.CounterID
		 LEFT JOIN CAT_EMPLOYEE EMP ON EMP.ID = CNTL.EmpID
		 LEFT JOIN SYS_STATUS STS ON STS.StatusCode = CNT.StatusCode AND STS.StatusObject = 'CAT_COUNTER'
	WHERE CNTL.CounterID = @p_CounterID
	ORDER BY CNTL.CounterDateTime DESC
GO
--=========================================================================================================================================================
--=========================================================================================================================================================
IF EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CAT_COUNTER_InsUpd]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[CAT_COUNTER_InsUpd]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CAT_COUNTER_InsUpd]
	@p_ID bigint = -1,
	@p_CounterCode varchar(15) = '',
	@p_CounterName nvarchar(500) = '',
	@p_StatusCode varchar(15) = '',
	@p_ShopID bigint = -1,
	@p_OrderBy bigint = -1,
	@p_IsActive bit = 1,
	@p_UpdateBy bigint = -1
AS
BEGIN TRANSACTION
	DECLARE @vMessage nvarchar(max)
	SET @vMessage = ''

	IF(@p_ID = -1 OR @p_ID IS NULL)
	BEGIN
		INSERT INTO [dbo].[CAT_COUNTER]
		       (CounterCode,
		       CounterName,
		       StatusCode,
		       ShopID,
		       OrderBy,
		       IsActive,
		       UpdateDate,
		       UpdateBy,
		       IsDelete)
		VALUES
		       (@p_CounterCode,
		        @p_CounterName,
		        @p_StatusCode,
		        @p_ShopID,
		        @p_OrderBy,
		        1,
				GETDATE(),
		        @p_UpdateBy,
		        0)
		IF @@Error <> 0 GOTO ABORT
	END
	ELSE
	BEGIN
		UPDATE [dbo].[CAT_COUNTER]
		SET CounterCode = @p_CounterCode,
			CounterName = @p_CounterName,
			StatusCode =  @p_StatusCode,
			ShopID = @p_ShopID,
			OrderBy = @p_OrderBy,
			IsActive = @p_IsActive,
			UpdateDate = GETDATE(),
			UpdateBy = @p_UpdateBy,
			IsDelete = 0
		WHERE ID = @p_ID
		IF @@Error <> 0 GOTO ABORT
	END

COMMIT TRANSACTION
	SELECT 1 AS Result, @vMessage AS MsgProcedure
	RETURN 1
ABORT:
BEGIN
	ROLLBACK TRANSACTION
	IF(@vMessage = '')
	BEGIN
		SET @vMessage = N'Thao tác thất bại'
	END
	SELECT 0 AS Result, @vMessage AS MsgProcedure
	RETURN 0
END
GO
--=========================================================================================================================================================
--=========================================================================================================================================================
IF EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CAT_COUNTER_GetAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[CAT_COUNTER_GetAll]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CAT_COUNTER_GetAll]
AS
	SELECT	CNT.ID,
			CNT.CounterCode,
			CNT.CounterName,
			CNT.StatusCode,
			STT.StatusName,
			CNT.ShopID,
			SHP.ShopName,
			CNT.OrderBy,
			CNT.IsActive,
			CNT.UpdateDate,
			CNT.UpdateBy,
			URS.UserName AS UserUpdate
	FROM dbo.CAT_COUNTER CNT
		 LEFT JOIN SYS_STATUS STT ON STT.StatusCode = CNT.StatusCode AND STT.StatusObject = 'CAT_COUNTER'
		 LEFT JOIN dbo.CAT_SHOP SHP ON SHP.ID = CNT.ShopID
		 LEFT JOIN dbo.SYS_USERS URS ON URS.ID = CNT.UpdateBy
	WHERE CNT.IsDelete = 0
GO
--=========================================================================================================================================================
--=========================================================================================================================================================
IF EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CAT_COUNTER_Del]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[CAT_COUNTER_Del]
GO
CREATE PROCEDURE [dbo].[CAT_COUNTER_Del]
	@p_ID bigint = -1,
	@p_UpdateBy bigint = -1
AS
BEGIN TRANSACTION
	DECLARE @vMessage nvarchar(max)
	SET @vMessage = ''

	UPDATE CAT_COUNTER
	SET IsDelete = 1,
		UpdateBy = @p_UpdateBy,
		UpdateDate = GETDATE()
	WHERE ID = @p_ID
	IF @@Error <> 0 GOTO ABORT

COMMIT TRANSACTION
	SELECT 1 AS Result, @vMessage AS MsgProcedure
	RETURN 1
ABORT:
BEGIN
	ROLLBACK TRANSACTION
	IF(@vMessage = '')
	BEGIN
		SET @vMessage = N'Thao tác thất bại'
	END
	SELECT 0 AS Result, @vMessage AS MsgProcedure
	RETURN 0
END
GO
--=========================================================================================================================================================
--=========================================================================================================================================================
IF EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CAT_CURRENCY_Search]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[CAT_CURRENCY_Search]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CAT_CURRENCY_Search]
	@p_ID bigint = -1,
	@p_CurrencyCode varchar(15) = '',
	@p_CurrencyDesc nvarchar(500) = '',
	@p_OrderBy bigint = -1,
	@p_IsActive bit = NULL,
	@p_UpdateBy bigint = -1
AS
	SELECT	ID,
			CurrencyCode,
			CurrencyDesc,
			OrderBy,
			IsActive,
			UpdateDate,
			UpdateBy,
			IsDelete
	FROM [dbo].[CAT_CURRENCY] CCY
	WHERE CCY.IsDelete = 0
		  AND (CCY.ID = @p_ID OR @p_ID = -1 OR @p_ID IS NULL)
		  AND (CCY.CurrencyCode = @p_CurrencyCode OR @p_CurrencyCode = '' OR @p_CurrencyCode IS NULL)
		  AND (CCY.CurrencyDesc = @p_CurrencyDesc OR @p_CurrencyDesc = '' OR @p_CurrencyDesc IS NULL)
		  AND (CCY.IsActive = @p_IsActive OR @p_IsActive = -1 OR @p_IsActive IS NULL)
		  AND (CCY.OrderBy = @p_OrderBy OR @p_OrderBy = -1 OR @p_OrderBy IS NULL)
		  AND (CCY.UpdateBy = @p_UpdateBy OR @p_UpdateBy = -1 OR @p_UpdateBy IS NULL)
GO
--=========================================================================================================================================================
--=========================================================================================================================================================
IF EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CAT_CURRENCY_InsUpd]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[CAT_CURRENCY_InsUpd]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CAT_CURRENCY_InsUpd]
	@p_ID bigint = -1,
	@p_CurrencyCode varchar(15) = '',
	@p_CurrencyDesc nvarchar(500) = '',
	@p_OrderBy bigint = -1,
	@p_IsActive bit = 1,
	@p_UpdateBy bigint = -1
AS
BEGIN TRANSACTION
	DECLARE @vMessage nvarchar(max)
	SET @vMessage = ''

	IF(@p_ID = -1 OR @p_ID IS NULL)
	BEGIN
		INSERT INTO [dbo].[CAT_CURRENCY]
		       (CurrencyCode,
				CurrencyDesc,
				OrderBy,
				IsActive,
				UpdateDate,
				UpdateBy,
				IsDelete)
		VALUES
		       (@p_CurrencyCode,
		        @p_CurrencyDesc,
		        @p_OrderBy,
		        1,
				GETDATE(),
		        @p_UpdateBy,
		        0)
		IF @@Error <> 0 GOTO ABORT
	END
	ELSE
	BEGIN
		UPDATE [dbo].[CAT_CURRENCY]
		SET CurrencyCode = @p_CurrencyCode,
			CurrencyDesc = @p_CurrencyDesc,
			OrderBy = @p_OrderBy,
			IsActive = @p_IsActive,
			UpdateDate = GETDATE(),
			UpdateBy = @p_UpdateBy,
			IsDelete = 0
		WHERE ID = @p_ID
		IF @@Error <> 0 GOTO ABORT
	END

COMMIT TRANSACTION
	SELECT 1 AS Result, @vMessage AS MsgProcedure
	RETURN 1
ABORT:
BEGIN
	ROLLBACK TRANSACTION
	IF(@vMessage = '')
	BEGIN
		SET @vMessage = N'Thao tác thất bại'
	END
	SELECT 0 AS Result, @vMessage AS MsgProcedure
	RETURN 0
END
GO
--=========================================================================================================================================================
--=========================================================================================================================================================
IF EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CAT_CURRENCY_GetAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[CAT_CURRENCY_GetAll]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CAT_CURRENCY_GetAll]
AS
	SELECT	CCY.ID,
			CCY.CurrencyCode,
			CCY.CurrencyDesc,
			CCY.OrderBy,
			CCY.IsActive,
			CCY.UpdateDate,
			CCY.UpdateBy,
			URS.UserName AS UserUpdate
	FROM dbo.CAT_CURRENCY CCY
		 LEFT JOIN dbo.SYS_USERS URS ON URS.ID = CCY.UpdateBy
	WHERE CCY.IsDelete = 0
GO
--=========================================================================================================================================================
--=========================================================================================================================================================
IF EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CAT_CURRENCY_Del]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[CAT_CURRENCY_Del]
GO
CREATE PROCEDURE [dbo].[CAT_CURRENCY_Del]
	@p_ID bigint = -1,
	@p_UpdateBy bigint = -1
AS
BEGIN TRANSACTION
	DECLARE @vMessage nvarchar(max)
	SET @vMessage = ''

	UPDATE CAT_CURRENCY
	SET IsDelete = 1,
		UpdateBy = @p_UpdateBy,
		UpdateDate = GETDATE()
	WHERE ID = @p_ID
	IF @@Error <> 0 GOTO ABORT

COMMIT TRANSACTION
	SELECT 1 AS Result, @vMessage AS MsgProcedure
	RETURN 1
ABORT:
BEGIN
	ROLLBACK TRANSACTION
	IF(@vMessage = '')
	BEGIN
		SET @vMessage = N'Thao tác thất bại'
	END
	SELECT 0 AS Result, @vMessage AS MsgProcedure
	RETURN 0
END
GO
--=========================================================================================================================================================
--=========================================================================================================================================================
IF EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SYS_COUNTER_STOCK_GetAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[SYS_COUNTER_STOCK_GetAll]
GO
CREATE PROCEDURE [dbo].[SYS_COUNTER_STOCK_GetAll]
AS
	SELECT	CounterID,
      		CurrencyID,
      		InStock
  FROM [dbo].[SYS_COUNTER_STOCK]
GO
--=========================================================================================================================================================
--=========================================================================================================================================================
IF EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SYS_COUNTER_STOCK_GetWithCounter]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[SYS_COUNTER_STOCK_GetWithCounter]
GO
CREATE PROCEDURE [dbo].[SYS_COUNTER_STOCK_GetWithCounter]
	@p_CounterID bigint = -1
AS
	SELECT	CounterID,
      		CurrencyID,
      		InStock
	FROM [dbo].[SYS_COUNTER_STOCK]
	WHERE CounterID = @p_CounterID
GO
--=========================================================================================================================================================
--=========================================================================================================================================================
IF EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SYS_COUNTER_STOCK_GetWithCounterCurrency]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[SYS_COUNTER_STOCK_GetWithCounterCurrency]
GO
CREATE PROCEDURE [dbo].[SYS_COUNTER_STOCK_GetWithCounterCurrency]
	@p_CounterID bigint = -1,
	@p_Currency bigint = -1
AS
	SELECT	CounterID,
      		CurrencyID,
      		InStock
	FROM [dbo].[SYS_COUNTER_STOCK]
	WHERE CounterID = @p_CounterID
		  AND CurrencyID = @p_Currency
GO
--=========================================================================================================================================================
--=========================================================================================================================================================
IF EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SYS_PRODUCT_STOCK_GetWithStalls]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[SYS_PRODUCT_STOCK_GetWithStalls]
GO
CREATE PROCEDURE [dbo].[SYS_PRODUCT_STOCK_GetWithStalls]
	@p_StallsID bigint = -1
AS
	SELECT	PRDS.StallsID,
			STL.StallsCode,
			STL.StallsName,
			PRDS.ProductID,
			PRD.ProductCode,
			PRD.ProductDesc,
			PRD.Descriptions,
			PRD.Supplier AS SupplierID,
			SPL.SupplierCode,
			SPL.SupplierName,
			PRDS.Quantity AS QuantityStock,
			PRDS.QuantityReal AS QuantityStockReal,
			PRDS.Weights AS WeightsStock,
			PRDS.WeightsReal AS WeightsStockReal
	FROM SYS_PRODUCT_STOCK PRDS
		 LEFT JOIN CAT_STALLS STL ON STL.ID = PRDS.StallsID
		 LEFT JOIN OBJ_PRODUCT PRD ON PRD.ID = PRDS.ProductID
		 LEFT JOIN CAT_SUPPLIER SPL ON SPL.ID = PRD.Supplier
	WHERE StallsID = @p_StallsID
GO