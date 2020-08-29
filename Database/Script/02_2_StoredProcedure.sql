IF EXISTS(SELECT * FROM SYS.DATABASES WHERE NAME = 'PTTKPMCRM')
BEGIN
	USE PTTKPMCRM
END
GO
--=========================================================================================================================================================
--=========================================================================================================================================================
IF EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TRN_PRODUCT_TRANSFER_Del]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[TRN_PRODUCT_TRANSFER_Del]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[TRN_PRODUCT_TRANSFER_Del]
	@p_TrnID bigint = -1,
	@p_UpdateBy bigint = -1
AS
BEGIN TRANSACTION
	DECLARE @vMessage nvarchar(max)
	SET @vMessage = ''

	IF EXISTS (SELECT TOP 1 1 FROM TRN_PRODUCT_TRANSFER WHERE TrnID = @p_TrnID AND StatusCode = 'C')
	BEGIN
		SET @vMessage = N'Giao dịch đã hoàn tất không thể xóa!'
		GOTO ABORT
	END

	-----------------------------------------------------------------------------------------------------------------------------------------------------------
	-- Lấy thông tin chuyển quầy trước khi cập nhật
	DECLARE @vStallsFrom bigint
	DECLARE @vStallsTo bigint

	SELECT	@vStallsFrom = StallsFrom, @vStallsTo = StallsTo
	FROM TRN_PRODUCT_TRANSFER
	WHERE TrnID = @p_TrnID

	SELECT ProductID, Quantity, ProductWeight
	INTO #tblTransfer
	FROM TRN_PRODUCT_TRANSFER_DT
	WHERE TrnID = @p_TrnID

	-----------------------------------------------------------------------------------------------------------------------------------------------------------
	-- Cập nhật tồn kho quầy chuyển
	UPDATE PDS
	SET PDS.QuantityReal = PDS.QuantityReal + #tblTransfer.Quantity,
		PDS.WeightsReal = PDS.WeightsReal + #tblTransfer.ProductWeight
	FROM SYS_PRODUCT_STOCK PDS
		 LEFT JOIN OBJ_PRODUCT PRD ON PRD.ID = PDS.ProductID
		 LEFT JOIN #tblTransfer ON #tblTransfer.ProductID = PDS.ProductID
	WHERE StallsID = @vStallsFrom
		  AND PRD.ProductType <> 0
	IF @@Error <> 0 GOTO ABORT

	-----------------------------------------------------------------------------------------------------------------------------------------------------------
	-- Cập nhật tồn kho quầy nhận
	UPDATE PDS
	SET PDS.QuantityReal = PDS.QuantityReal - #tblTransfer.Quantity,
		PDS.WeightsReal = PDS.WeightsReal - #tblTransfer.ProductWeight
	FROM SYS_PRODUCT_STOCK PDS
		 LEFT JOIN OBJ_PRODUCT PRD ON PRD.ID = PDS.ProductID
		 LEFT JOIN #tblTransfer ON #tblTransfer.ProductID = PDS.ProductID
	WHERE StallsID = @vStallsTo
		  AND PRD.ProductType <> 0
	IF @@Error <> 0 GOTO ABORT

	-----------------------------------------------------------------------------------------------------------------------------------------------------------
	-- Xóa giao dịch
	UPDATE TRN_PRODUCT_TRANSFER
	SET IsDelete = 1,
		UpdateBy = @p_UpdateBy,
		UpdateDate = GETDATE()
	WHERE TrnID = @p_TrnID
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
IF EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TRN_PRODUCT_TRANSFER_Lst]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[TRN_PRODUCT_TRANSFER_Lst]
GO
CREATE PROCEDURE [dbo].[TRN_PRODUCT_TRANSFER_Lst]
      @p_TrnCode varchar(15) = '',
      @p_TrnDateFrom varchar(10) = '',
	  @p_TrnDateTo varchar(10) = '',
      @p_StallsFrom bigint = -1,
      @p_StallsTo bigint = -1,
      @p_Notes nvarchar(max) = '',
      @p_EmpID bigint = -1,
      @p_StatusCode varchar(5) = ''
AS
	SELECT	PRT.TrnID,
			PRT.TrnCode,
			PRT.TrnDate,
			PRT.TrnTime,
			PRT.StallsFrom AS StallsFromID,
			STLF.StallsCode AS StallsFromCode,
			STLF.StallsName AS StallsFromName,
			PRT.StallsTo AS StallsToID,
			STLT.StallsCode AS StallsToCode,
			STLT.StallsName AS StallsToName,
			PRT.Notes,
			PRT.EmpID,
			EMP.EmpCode,
			EMP.EmpName,
			PRT.StatusCode,
			STT.StatusName
	FROM TRN_PRODUCT_TRANSFER PRT
		 LEFT JOIN SYS_STATUS STT ON STT.StatusCode = PRT.StatusCode AND STT.StatusObject = 'TRN_PRODUCT_TRANSFER'
		 LEFT JOIN CAT_EMPLOYEE EMP ON EMP.ID = PRT.EmpID
		 LEFT JOIN CAT_STALLS STLF ON STLF.ID = PRT.StallsFrom
		 LEFT JOIN CAT_STALLS STLT ON STLT.ID = PRT.StallsTo
	WHERE PRT.IsDelete = 0
		  AND (PRT.TrnCode LIKE N'%' + @p_TrnCode + '%' OR @p_TrnCode = '' OR @p_TrnCode IS NULL)
		  AND (PRT.TrnDate >= CONVERT(date, @p_TrnDateFrom, 103) OR @p_TrnDateFrom = '' OR @p_TrnDateFrom IS NULL)
		  AND (PRT.TrnDate <= CONVERT(date, @p_TrnDateTo, 103) OR @p_TrnDateTo = '' OR @p_TrnDateTo IS NULL)
		  AND (PRT.StallsFrom = @p_StallsFrom OR @p_StallsFrom = -1 OR @p_StallsFrom IS NULL)
		  AND (PRT.StallsTo = @p_StallsTo OR @p_StallsTo = -1 OR @p_StallsTo IS NULL)
		  AND (PRT.Notes LIKE N'%' + @p_Notes + '%' OR @p_Notes = '' OR @p_Notes IS NULL)
		  AND (PRT.EmpID = @p_EmpID OR @p_EmpID = -1 OR @p_EmpID IS NULL)
		  AND (PRT.StatusCode = @p_StatusCode OR @p_StatusCode = '' OR @p_StatusCode IS NULL)
GO
--=========================================================================================================================================================
--=========================================================================================================================================================
IF EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TRN_PRODUCT_TRANSFER_InsUpd]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[TRN_PRODUCT_TRANSFER_InsUpd]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[TRN_PRODUCT_TRANSFER_InsUpd]
	@p_TrnID bigint = -1,
	@p_TrnCode varchar(15) = '',
	@p_StallsFrom bigint = -1,
	@p_StallsTo bigint = -1,
	@p_Notes nvarchar(max) = '',
	@p_EmpID bigint = -1,
	@p_StatusCode varchar(15) = '',
	@p_UpdateBy bigint = -1,
	@p_xmlDtl xml
AS
BEGIN TRANSACTION
	DECLARE @vMessage nvarchar(max)
	SET @vMessage = ''
	IF(@p_TrnID = -1 OR @p_TrnID IS NULL)
	BEGIN
		INSERT INTO [dbo].[TRN_PRODUCT_TRANSFER]
		           (TrnCode,
		            TrnDate,
		            TrnTime,
					StallsFrom,
					StallsTo,
		            Notes,
		            EmpID,
		            StatusCode,
		            UpdateDate,
		            UpdateBy,
		            IsDelete)
		VALUES (@p_TrnCode,
		        CONVERT(date, GETDATE()),
		        CONVERT(time, GETDATE()),
				@p_StallsFrom,
				@p_StallsTo,
		        @p_Notes,
		        @p_EmpID,
		        @p_StatusCode,
		        CONVERT(datetime, GETDATE()),
		        @p_UpdateBy,
		        0)
		IF @@Error <> 0 GOTO ABORT

		SET @p_TrnID = IDENT_CURRENT('TRN_PRODUCT_TRANSFER')
		IF @@Error <> 0 GOTO ABORT
	END
	ELSE
	BEGIN
		UPDATE [dbo].[TRN_PRODUCT_TRANSFER]
		SET TrnCode = @p_TrnCode,
			StallsFrom = @p_StallsFrom,
			StallsTo = @p_StallsTo,
		    Notes = @p_Notes,
		    EmpID = @p_EmpID,
		    StatusCode = @p_StatusCode,
			UpdateDate = GETDATE(),
			UpdateBy = @p_UpdateBy
		WHERE TrnID = @p_TrnID
		IF @@Error <> 0 GOTO ABORT
	END  

	-----------------------------------------------------------------------------------------------------------
	-- Lấy thông tin chuyển quầy trước khi cập nhật
	SELECT ProductID, Quantity, ProductWeight
	INTO #tblTransfer
	FROM TRN_PRODUCT_TRANSFER_DT
	WHERE TrnID = @p_TrnID

	-- Cập nhật chi tiết chuyển quầy
	DELETE FROM TRN_PRODUCT_TRANSFER_DT WHERE TrnID = @p_TrnID
	
	DECLARE @tblTRN_PRODUCT_TRANSFER TABLE(	ProductID bigint,
											ProductWeight numeric(19,8), 
											Quantity int,
											Notes nvarchar(max))
	INSERT INTO @tblTRN_PRODUCT_TRANSFER SELECT Tbl.Col.value('(ProductID/text())[1]', 'bigint') AS ProductID,
												Tbl.Col.value('(ProductWeight/text())[1]', 'numeric(19,8)') AS ProductWeight,																		
												Tbl.Col.value('(Quantity/text())[1]', 'int') AS Quantity,
												Tbl.Col.value('(Notes/text())[1]', 'nvarchar(max)') AS Notes
									FROM @p_xmlDtl.nodes('//Transaction') AS Tbl(Col)

	INSERT INTO TRN_PRODUCT_TRANSFER_DT ([TrnID]
										,[ProductID]
										,[ProductWeight]
										,[Quantity]
										,[Notes])
	SELECT	@p_TrnID AS TrnID,
			ProductID,
			ProductWeight,
			Quantity,
			ISNULL(Notes, '')
	FROM @tblTRN_PRODUCT_TRANSFER
	IF @@Error <> 0 GOTO ABORT

	-- Cập nhật tồn kho quầy chuyển
	UPDATE PDS
	SET PDS.QuantityReal = PDS.QuantityReal + #tblTransfer.Quantity - tmpDT.Quantity,
		PDS.WeightsReal = PDS.WeightsReal + #tblTransfer.ProductWeight - tmpDT.ProductWeight
	FROM SYS_PRODUCT_STOCK PDS
		 LEFT JOIN @tblTRN_PRODUCT_TRANSFER tmpDT ON tmpDT.ProductID = PDS.ProductID
		 LEFT JOIN #tblTransfer ON #tblTransfer.ProductID = PDS.ProductID
	WHERE StallsID = @p_StallsFrom
	IF @@Error <> 0 GOTO ABORT

	-- Cập nhật tồn kho quầy nhận
	UPDATE PDS
	SET PDS.QuantityReal = PDS.QuantityReal - #tblTransfer.Quantity + tmpDT.Quantity,
		PDS.WeightsReal = PDS.WeightsReal - #tblTransfer.ProductWeight + tmpDT.ProductWeight
	FROM SYS_PRODUCT_STOCK PDS
		 LEFT JOIN @tblTRN_PRODUCT_TRANSFER tmpDT ON tmpDT.ProductID = PDS.ProductID
		 LEFT JOIN #tblTransfer ON #tblTransfer.ProductID = PDS.ProductID
	WHERE StallsID = @p_StallsFrom
	IF @@Error <> 0 GOTO ABORT

COMMIT TRANSACTION
	SELECT 1 AS Result, @vMessage AS MsgProcedure, @p_TrnID AS TrnID
	RETURN 1
ABORT:
BEGIN
	ROLLBACK TRANSACTION
	IF(@vMessage = '')
	BEGIN
		SET @vMessage = N'Thao tác thất bại'
	END
	SELECT 0 AS Result, @vMessage AS MsgProcedure, @p_TrnID AS TrnID
	RETURN 0
END
GO
--=========================================================================================================================================================
--=========================================================================================================================================================
IF EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TRN_PRODUCT_TRANSFER_GetWithID]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[TRN_PRODUCT_TRANSFER_GetWithID]
GO
CREATE PROCEDURE [dbo].[TRN_PRODUCT_TRANSFER_GetWithID]
	@p_TrnID bigint = -1
AS
	SELECT	PRT.TrnID,
			PRT.TrnCode,
			PRT.TrnDate,
			PRT.TrnTime,
			PRT.StallsFrom AS StallsFromID,
			STLF.StallsCode AS StallsFromCode,
			STLF.StallsName AS StallsFromName,
			STLF.ShopID AS ShopFromID,
			SHPF.ShopCode AS ShopFromCode,
			SHPF.ShopName AS ShopFromName,
			PRT.StallsTo AS StallsToID,
			STLT.StallsCode AS StallsToCode,
			STLT.StallsName AS StallsToName,
			STLT.ShopID AS ShopToID,
			SHPT.ShopCode AS ShopToCode,
			SHPT.ShopName AS ShopToName,
			PRT.Notes,
			PRT.EmpID,
			EMP.EmpCode,
			EMP.EmpName,
			PRT.StatusCode,
			STT.StatusName
	FROM TRN_PRODUCT_TRANSFER PRT
		 LEFT JOIN SYS_STATUS STT ON STT.StatusCode = PRT.StatusCode AND STT.StatusObject = 'TRN_PRODUCT_TRANSFER'
		 LEFT JOIN CAT_EMPLOYEE EMP ON EMP.ID = PRT.EmpID
		 LEFT JOIN CAT_STALLS STLF ON STLF.ID = PRT.StallsFrom
		 LEFT JOIN CAT_SHOP SHPF ON SHPF.ID = STLF.ShopID
		 LEFT JOIN CAT_STALLS STLT ON STLT.ID = PRT.StallsTo
		 LEFT JOIN CAT_SHOP SHPT ON SHPT.ID = STLT.ShopID
	WHERE PRT.TrnID = @p_TrnID

	SELECT PRTD.TrnID,
	       PRTD.ProductID,
		   PRD.ProductCode,
		   PRD.ProductDesc,
	       PRTD.ProductWeight,
	       PRTD.Quantity,
	       PRTD.Notes
	FROM TRN_PRODUCT_TRANSFER_DT PRTD
		 LEFT JOIN OBJ_PRODUCT PRD ON PRD.ID = PRTD.ProductID
	WHERE PRTD.TrnID = @p_TrnID	
GO
--=========================================================================================================================================================
--=========================================================================================================================================================
IF EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TRN_PRODUCT_TRANSFER_GetDtl]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[TRN_PRODUCT_TRANSFER_GetDtl]
GO
CREATE PROCEDURE [dbo].[TRN_PRODUCT_TRANSFER_GetDtl]
	@p_TrnID bigint = -1
AS
	SELECT PRTD.TrnID,
	       PRTD.ProductID,
		   PRD.ProductCode,
		   PRD.ProductDesc,
	       PRTD.ProductWeight,
	       PRTD.Quantity,
	       PRTD.Notes
	FROM TRN_PRODUCT_TRANSFER_DT PRTD
		 LEFT JOIN OBJ_PRODUCT PRD ON PRD.ID = PRTD.ProductID
	WHERE 1 = 1
		  AND (PRTD.TrnID = @p_TrnID OR @p_TrnID = -1 OR @p_TrnID IS NULL)		 
GO
--=========================================================================================================================================================
--=========================================================================================================================================================
IF EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TRN_PRODUCT_TRANSFER_Complete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[TRN_PRODUCT_TRANSFER_Complete]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[TRN_PRODUCT_TRANSFER_Complete]
	@p_TrnID bigint = -1,
	@p_UpdateBy bigint = -1
AS
SET XACT_ABORT ON;
BEGIN TRANSACTION
	DECLARE @vMessage nvarchar(max)
	SET @vMessage = ''

	DECLARE @vProductID bigint = -1
	DECLARE @vProductWeight numeric(19,8) = 0
	DECLARE @vQuantity int = 0
	DECLARE @vNotes nvarchar(max) = ''

	DECLARE pCurProductTransferComplete CURSOR FOR SELECT ProductID, ProductWeight, Quantity, Notes
											 FROM TRN_PRODUCT_TRANSFER_DT WHERE TrnID = @p_TrnID
	OPEN pCurProductTransferComplete
	FETCH NEXT FROM pCurProductTransferComplete INTO @vProductID, @vProductWeight, @vQuantity, @vNotes
	WHILE @@FETCH_STATUS = 0
	BEGIN
		-- Cập nhật tồn kho quầy chuyển
		DECLARE @p_StallsFrom bigint
		SELECT @p_StallsFrom = StallsFrom FROM TRN_PRODUCT_TRANSFER WHERE TrnID = @p_TrnID

		UPDATE SYS_PRODUCT_STOCK
		SET Quantity = Quantity - @vQuantity,
			Weights = Weights - @vProductWeight
		WHERE StallsID = @p_StallsFrom AND ProductID = @vProductID
		IF @@Error <> 0 GOTO ABORT

		-- Cập nhật tồn kho quầy nhận
		DECLARE @p_StallsTo bigint
		SELECT @p_StallsTo = StallsFrom FROM TRN_PRODUCT_TRANSFER WHERE TrnID = @p_TrnID

		UPDATE SYS_PRODUCT_STOCK
		SET Quantity = Quantity + @vQuantity,
			Weights = Weights + @vProductWeight
		WHERE StallsID = @p_StallsTo AND ProductID = @vProductID
		IF @@Error <> 0 GOTO ABORT

		FETCH NEXT FROM pCurProductTransferComplete INTO @vProductID, @vProductWeight, @vQuantity, @vNotes
	END
	CLOSE pCurProductTransferComplete
	DEALLOCATE pCurProductTransferComplete
	IF @@Error <> 0 GOTO ABORT

	-- Cập nhật trạng thái xuất hàng
	UPDATE TRN_PRODUCT_TRANSFER 
	SET StatusCode = 'C',
		UpdateBy = @p_UpdateBy,
		UpdateDate = GETDATE()
	WHERE TrnID = @p_TrnID 
	IF @@Error <> 0 GOTO ABORT

COMMIT TRANSACTION
	SELECT 1 AS Result, @vMessage AS MsgProcedure
	RETURN 1
ABORT:
BEGIN
	ROLLBACK TRANSACTION
	IF (SELECT CURSOR_STATUS('global','pCurProductTransferComplete')) >= -1
	BEGIN
		IF (SELECT CURSOR_STATUS('global','pCurProductTransferComplete')) > -1
		BEGIN
			CLOSE pCur
		END
		DEALLOCATE pCur
	END

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
IF EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TRN_PRODUCT_SELL_Del]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[TRN_PRODUCT_SELL_Del]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[TRN_PRODUCT_SELL_Del]
	@p_TrnID bigint = -1,
	@p_UpdateBy bigint = -1
AS
BEGIN TRANSACTION
	DECLARE @vMessage nvarchar(max)
	SET @vMessage = ''

	IF EXISTS (SELECT TOP 1 1 FROM TRN_PRODUCT_SELL WHERE TrnID = @p_TrnID AND StatusCode = 'C')
	BEGIN
		SET @vMessage = N'Giao dịch đã hoàn tất không thể xóa!'
		GOTO ABORT
	END

	-----------------------------------------------------------------------------------------------------------------------------------------------------------
	-- Cập nhật tồn kho
	UPDATE PDS
	SET PDS.QuantityReal = PDS.QuantityReal + ISNULL(PDSD.Quantity, 0),
		PDS.WeightsReal = PDS.WeightsReal + ISNULL(PDSD.ProductWeight, 0)
	FROM SYS_PRODUCT_STOCK PDS
	     LEFT JOIN OBJ_PRODUCT PRD ON PRD.ID = PDS.ProductID
		 LEFT JOIN TRN_PRODUCT_SELL_DT PDSD ON PDSD.ProductID = PDS.ProductID 
	WHERE PRD.ProductType <> 0
		  AND PDSD.TrnID = @p_TrnID
	IF @@Error <> 0 GOTO ABORT

	-----------------------------------------------------------------------------------------------------------------------------------------------------------
	-- Xóa giao dịch
	UPDATE TRN_PRODUCT_SELL
	SET IsDelete = 1,
		UpdateBy = @p_UpdateBy,
		UpdateDate = GETDATE()
	WHERE TrnID = @p_TrnID
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
IF EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TRN_PRODUCT_SELL_Lst]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[TRN_PRODUCT_SELL_Lst]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[TRN_PRODUCT_SELL_Lst]
      @p_TrnCode varchar(15) = '',
      @p_TrnDateFrom varchar(10) = '',
	  @p_TrnDateTo varchar(10) = '',
      @p_CustID bigint = -1,
      @p_Notes nvarchar(max) = '',
      @p_EmpID bigint = -1,
      @p_StatusCode varchar(5) = ''	
AS
	SELECT	PRDS.TrnID,
			SUM(CASE WHEN PRD.ProductType = 2 THEN PRDS.ProductWeight ELSE PRDS.Quantity END) AS QuantitySell
	INTO #tmpPRDS
	FROM TRN_PRODUCT_SELL_DT PRDS
		 LEFT JOIN OBJ_PRODUCT PRD ON PRD.ID = PRDS.ProductID
		 LEFT JOIN CAT_PRODUCTTYPE PRDT ON PRDT.ID = PRD.ProductType
	GROUP BY PRDS.TrnID

	SELECT	PRS.TrnID,
			PRS.TrnCode,
			PRS.TrnDate,
			PRS.TrnTime,
			PRS.CustID,
			CUS.CustCode,
			CUS.CustName,
			PRS.CounterID,
			CNT.CounterCode,
			CNT.CounterName,
			PRS.DiscountTrn,
			PRS.DiscountTotal,
			PRS.AmountTotal,
			PRS.AmountPay,
			PRS.UnitPayment,
			CRC.CurrencyCode,
			CRC.CurrencyDesc,
			PRS.Notes,
			PRS.EmpID,
			EMP.EmpCode,
			EMP.EmpName,
			PRS.StatusCode,
			STT.StatusName,
			#tmpPRDS.QuantitySell 
	FROM TRN_PRODUCT_SELL PRS
		 LEFT JOIN SYS_STATUS STT ON STT.StatusCode = PRS.StatusCode AND STT.StatusObject = 'TRN_PRODUCT_SELL'
		 LEFT JOIN CAT_EMPLOYEE EMP ON EMP.ID = PRS.EmpID
		 LEFT JOIN CAT_CURRENCY CRC ON CRC.ID = PRS.UnitPayment
		 LEFT JOIN CAT_CUSTOMER CUS ON CUS.ID = PRS.CustID
		 LEFT JOIN CAT_COUNTER CNT ON CNT.ID = PRS.CounterID
		 LEFT JOIN #tmpPRDS ON #tmpPRDS.TrnID = PRS.TrnID
	WHERE PRS.IsDelete = 0
		  AND (PRS.TrnCode LIKE N'%' + @p_TrnCode + '%' OR @p_TrnCode = '' OR @p_TrnCode IS NULL)
		  AND (PRS.TrnDate >= CONVERT(date, @p_TrnDateFrom, 103) OR @p_TrnDateFrom = '' OR @p_TrnDateFrom IS NULL)
		  AND (PRS.TrnDate <= CONVERT(date, @p_TrnDateTo, 103) OR @p_TrnDateTo = '' OR @p_TrnDateTo IS NULL)
		  AND (PRS.CustID = @p_CustID OR @p_CustID = -1 OR @p_CustID IS NULL)
		  AND (PRS.Notes LIKE N'%' + @p_Notes + '%' OR @p_Notes = '' OR @p_Notes IS NULL)
		  AND (PRS.EmpID = @p_EmpID OR @p_EmpID = -1 OR @p_EmpID IS NULL)
		  AND (PRS.StatusCode = @p_StatusCode OR @p_StatusCode = '' OR @p_StatusCode IS NULL)		 	 
GO
--=========================================================================================================================================================
--=========================================================================================================================================================
IF EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TRN_PRODUCT_SELL_InsUpd]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[TRN_PRODUCT_SELL_InsUpd]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[TRN_PRODUCT_SELL_InsUpd]
	@p_TrnID bigint = -1,
	@p_TrnCode varchar(15) = '',
	@p_CustID bigint = -1,
	@p_CounterID bigint = -1,
	@p_DiscountTrn numeric(19,8),
	@p_DiscountTotal numeric(19,8),
	@p_AmountTotal numeric(19,8),
	@p_AmountPay numeric(19,8),
	@p_UnitPayment bigint = -1,
	@p_Notes nvarchar(max) = '',
	@p_EmpID bigint = -1,
	@p_StatusCode varchar(15) = '',
	@p_UpdateBy bigint = -1,
	@p_xmlDtl xml
AS
BEGIN TRANSACTION
	DECLARE @vMessage nvarchar(max)
	SET @vMessage = ''
	-----------------------------------------------------------------------------------------------------------------------------------------------------------
	-- Cập nhật bảng giao dịch
	IF(@p_TrnID = -1 OR @p_TrnID IS NULL)
	BEGIN
		INSERT INTO [dbo].[TRN_PRODUCT_SELL]
							([TrnCode],
							 [TrnDate],
							 [TrnTime],
							 [CustID],
							 [CounterID],
							 [DiscountTrn],
							 [DiscountTotal],
							 [AmountTotal],
							 [AmountPay],
							 [UnitPayment],
							 [Notes],
							 [EmpID],
							 [StatusCode],
							 [UpdateDate],
							 [UpdateBy],
							 [IsDelete])
		VALUES (@p_TrnCode,
		        CONVERT(date, GETDATE()),
		        CONVERT(time, GETDATE()),
				@p_CustID,
				@p_CounterID,
				@p_DiscountTrn,
				@p_DiscountTotal,
				@p_AmountTotal,
				@p_AmountPay,
				@p_UnitPayment,
		        @p_Notes,
		        @p_EmpID,
		        @p_StatusCode,
		        CONVERT(datetime, GETDATE()),
		        @p_UpdateBy,
		        0)
		IF @@Error <> 0 GOTO ABORT

		SET @p_TrnID = IDENT_CURRENT('TRN_PRODUCT_SELL')
		IF @@Error <> 0 GOTO ABORT
	END
	ELSE
	BEGIN
		UPDATE [dbo].[TRN_PRODUCT_SELL]
		SET TrnCode = @p_TrnCode,
            CustID = @p_CustID,
			CounterID = @p_CounterID,
            DiscountTrn = @p_DiscountTrn,
            DiscountTotal = @p_DiscountTotal,
            AmountTotal = @p_AmountTotal,
            AmountPay = @p_AmountPay,
            UnitPayment = @p_UnitPayment,
		    Notes = @p_Notes,
		    EmpID = @p_EmpID,
		    StatusCode = @p_StatusCode,
			UpdateDate = GETDATE(),
			UpdateBy = @p_UpdateBy
		WHERE TrnID = @p_TrnID
		IF @@Error <> 0 GOTO ABORT
	END  

	-----------------------------------------------------------------------------------------------------------------------------------------------------------
	-- Lấy thông tin xuất hàng để cập nhật tồn kho
	SELECT PDSD.ProductID, PDSD.Quantity, PDSD.ProductWeight
	INTO #tblSell
	FROM TRN_PRODUCT_SELL_DT PDSD
	WHERE TrnID = @p_TrnID

	-----------------------------------------------------------------------------------------------------------------------------------------------------------
	-- Cập nhật bảng chi tiết
	DELETE FROM TRN_PRODUCT_SELL_DT WHERE TrnID = @p_TrnID
	
	DECLARE @tblTRN_PRODUCT_SELL TABLE( ProductID bigint,
										StallsID bigint,
									    ProductWeight numeric(19,8),
									    Quantity int,
									    UnitSell bigint,
									    Rate numeric(19,8),
									    Discount numeric(19,8),
									    Amount numeric(19,8),
									    Notes nvarchar(max))
	INSERT INTO @tblTRN_PRODUCT_SELL SELECT Tbl.Col.value('(ProductID/text())[1]', 'bigint') AS ProductID,
											Tbl.Col.value('(StallsID/text())[1]', 'bigint') AS StallsID,
											Tbl.Col.value('(ProductWeight/text())[1]', 'numeric(19,8)') AS ProductWeight,																		
											Tbl.Col.value('(Quantity/text())[1]', 'int') AS Quantity,
											Tbl.Col.value('(UnitSellID/text())[1]', 'bigint') AS UnitSell,
											Tbl.Col.value('(RateSell/text())[1]', 'numeric(19,8)') AS Rate,
											Tbl.Col.value('(DiscountTotal/text())[1]', 'numeric(19,8)') AS Discount,
											Tbl.Col.value('(Amount/text())[1]', 'numeric(19,8)') AS Amount,
											Tbl.Col.value('(Notes/text())[1]', 'nvarchar(max)') AS Notes
									FROM @p_xmlDtl.nodes('//Transaction') AS Tbl(Col)

	INSERT INTO TRN_PRODUCT_SELL_DT (TrnID,
									 ProductID,
									 StallsID,
									 ProductWeight,
									 Quantity,
									 UnitSell,
									 Rate,
									 Discount,
									 Amount,
									 Notes)
	SELECT	@p_TrnID AS TrnID,
						ProductID,
						StallsID,
						ProductWeight,
						Quantity,
						UnitSell,
						Rate,
						Discount,
						Amount,
						ISNULL(Notes,'')
	FROM @tblTRN_PRODUCT_SELL
	IF @@Error <> 0 GOTO ABORT

	-----------------------------------------------------------------------------------------------------------------------------------------------------------
	-- Cập nhật tồn kho
	UPDATE PDS
	SET PDS.QuantityReal = PDS.QuantityReal + ISNULL(#tblSell.Quantity, 0) - ISNULL(tmpDT.Quantity, 0),
		PDS.WeightsReal = PDS.WeightsReal + ISNULL(#tblSell.ProductWeight, 0) - ISNULL(tmpDT.ProductWeight, 0)
	FROM SYS_PRODUCT_STOCK PDS
	     LEFT JOIN OBJ_PRODUCT PRD ON PRD.ID = PDS.ProductID
		 LEFT JOIN @tblTRN_PRODUCT_SELL tmpDT ON tmpDT.ProductID = PDS.ProductID AND tmpDT.StallsID = PDS.StallsID
		 LEFT JOIN #tblSell ON #tblSell.ProductID = PDS.ProductID
	WHERE PRD.ProductType <> 0
	IF @@Error <> 0 GOTO ABORT

COMMIT TRANSACTION
	SELECT 1 AS Result, @vMessage AS MsgProcedure, @p_TrnID AS TrnID
	RETURN 1
ABORT:
BEGIN
	ROLLBACK TRANSACTION
	IF(@vMessage = '')
	BEGIN
		SET @vMessage = N'Thao tác thất bại'
	END
	SELECT 0 AS Result, @vMessage AS MsgProcedure, @p_TrnID AS TrnID
	RETURN 0
END
GO
--=========================================================================================================================================================
--=========================================================================================================================================================
IF EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TRN_PRODUCT_SELL_GetWithID]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[TRN_PRODUCT_SELL_GetWithID]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[TRN_PRODUCT_SELL_GetWithID]
	@p_TrnID bigint = -1
AS
	SELECT	PRS.TrnID,
			PRS.TrnCode,
			PRS.TrnDate,
			PRS.TrnTime,
			PRS.CustID,
			CUS.CustCode,
			CUS.CustName,
			PRS.CounterID,
			CNT.CounterCode,
			CNT.CounterName,
			PRS.DiscountTrn,
			PRS.DiscountTotal,
			PRS.AmountTotal,
			PRS.AmountPay,
			PRS.UnitPayment,
			CRC.CurrencyCode,
			CRC.CurrencyDesc,
			PRS.Notes,
			PRS.EmpID,
			EMP.EmpCode,
			EMP.EmpName,
			PRS.StatusCode,
			STT.StatusName
	FROM TRN_PRODUCT_SELL PRS
		 LEFT JOIN SYS_STATUS STT ON STT.StatusCode = PRS.StatusCode AND STT.StatusObject = 'TRN_PRODUCT_SELL'
		 LEFT JOIN CAT_EMPLOYEE EMP ON EMP.ID = PRS.EmpID
		 LEFT JOIN CAT_CURRENCY CRC ON CRC.ID = PRS.UnitPayment
		 LEFT JOIN CAT_CUSTOMER CUS ON CUS.ID = PRS.CustID
		 LEFT JOIN CAT_COUNTER CNT ON CNT.ID = PRS.CounterID
	WHERE PRS.TrnID = @p_TrnID	

	SELECT	PRSD.TrnID,
			PRS.TrnCode,
			PRSD.ProductID,
			PRD.ProductCode,
			PRD.ProductDesc,
			PRD.Descriptions,
			PRSD.StallsID AS StallsID,
			STL.StallsCode AS StallsCode,
			STL.StallsName AS StallsName,
			PRD.ProductType AS ProductTypeID,
			PRDT.ProductTypeCode,
			PRDT.ProductTypeName,
			PRD.ProductGroup AS ProductGroupID,
			PRDG.ProductGroupCode,
			PRDG.ProductGroupName,
			PRD.Supplier AS SupplierID,
			SPL.SupplierCode,
			SPL.SupplierName,
			PRSD.ProductWeight,
			PRSD.Quantity,
			PRSD.UnitSell AS UnitSellID,
			USEL.UnitSellCode,
			USEL.UnitSellDesc,
			ISNULL(PRDR.RateIn, 0) AS RateIn,
			ISNULL(PRDR.RateEstimate, 0) AS RateEstimate,
			ISNULL(PRDR.DiscountPercent, 0) AS DiscountPercent,
			ISNULL(PRDR.Discount, 0) AS Discount,
			PRSD.Discount AS DiscountTotal,
			PRSD.Rate AS RateSell,
			PRSD.Amount,
			PRSD.Notes
	FROM TRN_PRODUCT_SELL_DT PRSD
		 LEFT JOIN TRN_PRODUCT_SELL PRS ON PRS.TrnID = PRSD.TrnID
		 LEFT JOIN OBJ_PRODUCT PRD ON PRD.ID = PRSD.ProductID
		 LEFT JOIN CAT_STALLS STL ON STL.ID = PRSD.StallsID
		 LEFT JOIN CAT_UNIT_SELL USEL ON USEL.ID = PRSD.UnitSell
		 LEFT JOIN SYS_PRODUCT_STOCK PRDS ON PRDS.ProductID = PRD.ID
		 LEFT JOIN SYS_PRODUCT_RATE PRDR ON PRDR.ProductID = PRD.ID
		 LEFT JOIN CAT_SUPPLIER SPL ON SPL.ID = PRD.Supplier
		 LEFT JOIN CAT_PRODUCTTYPE PRDT ON PRDT.ID = PRD.ProductType
		 LEFT JOIN CAT_PRODUCTGROUP PRDG ON PRDG.ID = PRD.ProductGroup
	WHERE PRSD.TrnID = @p_TrnID
		  AND (PRDR.IsSellCurrent = 1 OR PRDR.IsSellCurrent IS NULL)
GO
--=========================================================================================================================================================
--=========================================================================================================================================================
IF EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TRN_PRODUCT_SELL_GetDtl]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[TRN_PRODUCT_SELL_GetDtl]
GO
CREATE PROCEDURE [dbo].[TRN_PRODUCT_SELL_GetDtl]
	@p_TrnID bigint = -1
AS
	SELECT PRSD.TrnID,
	       PRSD.ProductID,
		   PRD.ProductCode,
		   PRD.ProductDesc,
		   PRSD.StallsID,
		   STN.StallsCode,
		   STN.StallsName,
	       PRSD.ProductWeight,
	       PRSD.Quantity,
	       PRSD.UnitSell,
	       PRSD.Rate,
	       PRSD.Discount,
	       PRSD.Amount,
	       PRSD.Notes
	FROM TRN_PRODUCT_SELL_DT PRSD
		 LEFT JOIN OBJ_PRODUCT PRD ON PRD.ID = PRSD.ProductID
		 LEFT JOIN CAT_STALLS STN ON STN.ID = PRSD.StallsID
	WHERE 1 = 1
		  AND (PRSD.TrnID = @p_TrnID OR @p_TrnID = -1 OR @p_TrnID IS NULL)
GO
--=========================================================================================================================================================
--=========================================================================================================================================================
IF EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TRN_PRODUCT_OUT_Complete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[TRN_PRODUCT_OUT_Complete]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[TRN_PRODUCT_OUT_Complete]
	@p_TrnID bigint = -1,
	@p_UpdateBy bigint = -1
AS
SET XACT_ABORT ON;
BEGIN TRANSACTION
	DECLARE @vMessage nvarchar(max)
	SET @vMessage = ''

	DECLARE @vProductID bigint = -1
	DECLARE @vProductWeight numeric(19,8) = 0
	DECLARE @vQuantity int = 0
	DECLARE @vNotes nvarchar(max) = ''

	DECLARE pCurProductOutComplete CURSOR FOR SELECT ProductID, ProductWeight, Quantity, Notes
											 FROM TRN_PRODUCT_OUT_DT WHERE TrnID = @p_TrnID
	OPEN pCurProductOutComplete
	FETCH NEXT FROM pCurProductOutComplete INTO @vProductID, @vProductWeight, @vQuantity, @vNotes
	WHILE @@FETCH_STATUS = 0
	BEGIN
		-- Cập nhật tình trạng món hàng
		UPDATE OBJ_PRODUCT 
		SET StatusCode = 'O',
			UpdateDate = GETDATE(),
			UpdateBy = @p_UpdateBy
		WHERE ID = @vProductID
		IF @@Error <> 0 GOTO ABORT

		-- Thêm vào log hàng hóa
		UPDATE SYS_PRODUCT_LOG
		SET OutTrnID = @p_TrnID,
			OutTrnType = 'OUT',
			OutDateTime = GETDATE(),
			OutQuantity = @vQuantity,
			OutWeights = @vProductWeight
		IF @@Error <> 0 GOTO ABORT
		
		-- Cập nhật tồn kho
		DECLARE @p_StallsID bigint
		SELECT @p_StallsID = StallsID FROM TRN_PRODUCT_OUT WHERE TrnID = @p_TrnID

		UPDATE SYS_PRODUCT_STOCK
		SET Quantity = Quantity - @vQuantity,
			QuantityReal = QuantityReal - @vQuantity,
			Weights = Weights - @vProductWeight,
			WeightsReal = WeightsReal - @vProductWeight
		WHERE StallsID = @p_StallsID AND ProductID = @vProductID
		IF @@Error <> 0 GOTO ABORT

		FETCH NEXT FROM pCurProductOutComplete INTO @vProductID, @vProductWeight, @vQuantity, @vNotes
	END
	CLOSE pCurProductOutComplete
	DEALLOCATE pCurProductOutComplete
	IF @@Error <> 0 GOTO ABORT

	-- Cập nhật trạng thái xuất hàng
	UPDATE TRN_PRODUCT_OUT 
	SET StatusCode = 'C',
		UpdateBy = @p_UpdateBy,
		UpdateDate = GETDATE()
	WHERE TrnID = @p_TrnID 
	IF @@Error <> 0 GOTO ABORT

COMMIT TRANSACTION
	SELECT 1 AS Result, @vMessage AS MsgProcedure
	RETURN 1
ABORT:
BEGIN
	ROLLBACK TRANSACTION
	IF (SELECT CURSOR_STATUS('global','pCurProductOutComplete')) >= -1
	BEGIN
		IF (SELECT CURSOR_STATUS('global','pCurProductOutComplete')) > -1
		BEGIN
			CLOSE pCur
		END
		DEALLOCATE pCur
	END

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
IF EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TRN_PRODUCT_OUT_Del]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[TRN_PRODUCT_OUT_Del]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[TRN_PRODUCT_OUT_Del]
	@p_TrnID bigint = -1,
	@p_UpdateBy bigint = -1
AS
BEGIN TRANSACTION
	DECLARE @vMessage nvarchar(max)
	SET @vMessage = ''

	-- Lấy thông tin xuất hàng trước khi cập nhật
	DECLARE @vStallsID bigint
	SELECT @vStallsID = StallsID
	FROM TRN_PRODUCT_OUT
	WHERE TrnID = @p_TrnID

	SELECT ProductID, Quantity, ProductWeight
	INTO #tblOut
	FROM TRN_PRODUCT_OUT_DT
	WHERE TrnID = @p_TrnID

	-- Cập nhật tồn kho
	UPDATE PDS
	SET PDS.QuantityReal = PDS.QuantityReal + #tblOut.Quantity,
		PDS.WeightsReal = PDS.WeightsReal + #tblOut.ProductWeight
	FROM SYS_PRODUCT_STOCK PDS
		 LEFT JOIN #tblOut ON #tblOut.ProductID = PDS.ProductID
	WHERE StallsID = @vStallsID
	IF @@Error <> 0 GOTO ABORT

	-- Xóa giao dịch
	UPDATE TRN_PRODUCT_OUT
	SET IsDelete = 1,
		UpdateBy = @p_UpdateBy,
		UpdateDate = GETDATE()
	WHERE TrnID = @p_TrnID
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
IF EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TRN_PRODUCT_OUT_Lst]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[TRN_PRODUCT_OUT_Lst]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[TRN_PRODUCT_OUT_Lst]
      @p_TrnCode varchar(15) = '',
      @p_TrnDateFrom varchar(10) = '',
	  @p_TrnDateTo varchar(10) = '',
      @p_Notes nvarchar(max) = '',
      @p_EmpID bigint = -1,
      @p_StatusCode varchar(5) = ''	
AS
	SELECT	PROD.TrnID,
			SUM(PROD.Quantity) AS QuantityOut
	INTO #tmpPROD
	FROM TRN_PRODUCT_OUT_DT PROD
	GROUP BY PROD.TrnID

	SELECT PRO.TrnID,
	       PRO.TrnCode,
	       PRO.TrnDate,
	       PRO.TrnTime,
		   PRO.StallsID,
		   STL.StallsCode,
		   STL.StallsName,
		   STL.ShopID,
		   SHP.ShopCode,
		   SHP.ShopName,
	       PRO.Notes,
	       PRO.EmpID,
		   EMP.EmpCode,
		   EMP.EmpName,
	       PRO.StatusCode,
		   STT.StatusName,
		   #tmpPROD.QuantityOut
	FROM TRN_PRODUCT_OUT PRO
		 LEFT JOIN SYS_STATUS STT ON STT.StatusCode = PRO.StatusCode AND STT.StatusObject = 'TRN_PRODUCT_OUT'
		 LEFT JOIN CAT_EMPLOYEE EMP ON EMP.ID = PRO.EmpID
		 LEFT JOIN CAT_STALLS STL ON STL.ID = PRO.StallsID
		 LEFT JOIN CAT_SHOP SHP ON SHP.ID = STL.ShopID
		 LEFT JOIN #tmpPROD ON #tmpPROD.TrnID = PRO.TrnID
	WHERE PRO.IsDelete = 0
		  AND (PRO.TrnCode LIKE N'%' + @p_TrnCode + '%' OR @p_TrnCode = '' OR @p_TrnCode IS NULL)
		  AND (PRO.TrnDate >= CONVERT(date, @p_TrnDateFrom, 103) OR @p_TrnDateFrom = '' OR @p_TrnDateFrom IS NULL)
		  AND (PRO.TrnDate <= CONVERT(date, @p_TrnDateTo, 103) OR @p_TrnDateTo = '' OR @p_TrnDateTo IS NULL)
		  AND (PRO.Notes LIKE N'%' + @p_Notes + '%' OR @p_Notes = '' OR @p_Notes IS NULL)
		  AND (PRO.EmpID = @p_EmpID OR @p_EmpID = -1 OR @p_EmpID IS NULL)
		  AND (PRO.StatusCode = @p_StatusCode OR @p_StatusCode = '' OR @p_StatusCode IS NULL)
GO
--=========================================================================================================================================================
--=========================================================================================================================================================
IF EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TRN_PRODUCT_OUT_InsUpd]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[TRN_PRODUCT_OUT_InsUpd]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[TRN_PRODUCT_OUT_InsUpd]
	@p_TrnID bigint = -1,
	@p_TrnCode varchar(15) = '',
	@p_StallsID bigint = -1,
	@p_Notes nvarchar(max) = '',
	@p_EmpID bigint = -1,
	@p_StatusCode varchar(15) = '',
	@p_UpdateBy bigint = -1,
	@p_xmlDtl xml
AS
BEGIN TRANSACTION
	DECLARE @vMessage nvarchar(max)
	SET @vMessage = ''

	-----------------------------------------------------------------------------------------------------------------------------------------------------------
	-- Cập nhật bảng giao dịch
	IF(@p_TrnID = -1 OR @p_TrnID IS NULL)
	BEGIN
		INSERT INTO [dbo].[TRN_PRODUCT_OUT]
		           (TrnCode,
		            TrnDate,
		            TrnTime,
					StallsID,
		            Notes,
		            EmpID,
		            StatusCode,
		            UpdateDate,
		            UpdateBy,
		            IsDelete)
		VALUES (@p_TrnCode,
		        CONVERT(date, GETDATE()),
		        CONVERT(time, GETDATE()),
				@p_StallsID,
		        @p_Notes,
		        @p_EmpID,
		        @p_StatusCode,
		        CONVERT(datetime, GETDATE()),
		        @p_UpdateBy,
		        0)
		IF @@Error <> 0 GOTO ABORT

		SET @p_TrnID = IDENT_CURRENT('TRN_PRODUCT_OUT')
		IF @@Error <> 0 GOTO ABORT
	END
	ELSE
	BEGIN
		UPDATE [dbo].[TRN_PRODUCT_OUT]
		SET TrnCode = @p_TrnCode,
		    Notes = @p_Notes,
		    EmpID = @p_EmpID,
		    StatusCode = @p_StatusCode,
			UpdateDate = GETDATE(),
			UpdateBy = @p_UpdateBy
		WHERE TrnID = @p_TrnID
		IF @@Error <> 0 GOTO ABORT
	END  

	-----------------------------------------------------------------------------------------------------------------------------------------------------------
	-- Lấy thông tin xuất hàng để cập nhật tồn kho
	SELECT PDOD.ProductID, PDOD.Quantity, PDOD.ProductWeight
	INTO #tblOut
	FROM TRN_PRODUCT_OUT_DT PDOD
	WHERE TrnID = @p_TrnID

	-----------------------------------------------------------------------------------------------------------------------------------------------------------
	-- Cập nhật bảng chi tiết
	DELETE FROM TRN_PRODUCT_OUT_DT WHERE TrnID = @p_TrnID
	
	DECLARE @tblTRN_PRODUCT_OUT TABLE(ProductID bigint, 
									  ProductWeight numeric(19,8),
									  Quantity int,
									  Notes nvarchar(max))
	INSERT INTO @tblTRN_PRODUCT_OUT SELECT Tbl.Col.value('(ProductID/text())[1]', 'bigint') AS ProductID,
										   Tbl.Col.value('(ProductWeight/text())[1]', 'numeric(19,8)') AS ProductWeight,																		
										   Tbl.Col.value('(Quantity/text())[1]', 'int') AS Quantity,
										   Tbl.Col.value('(Notes/text())[1]', 'nvarchar(max)') AS Notes
									FROM @p_xmlDtl.nodes('//Transaction') AS Tbl(Col)

	INSERT INTO TRN_PRODUCT_OUT_DT ([TrnID]
									,[ProductID]
									,[ProductWeight]
									,[Quantity]
									,[Notes])
	SELECT	@p_TrnID AS TrnID,
			ProductID,
			ProductWeight,
			Quantity,
			ISNULL(Notes,'')
	FROM @tblTRN_PRODUCT_OUT
	IF @@Error <> 0 GOTO ABORT

	-----------------------------------------------------------------------------------------------------------------------------------------------------------
	-- Cập nhật tồn kho
	UPDATE PDS
	SET PDS.QuantityReal = PDS.QuantityReal + ISNULL(#tblOut.Quantity, 0) - ISNULL(tmpDT.Quantity, 0),
		PDS.WeightsReal = PDS.WeightsReal + ISNULL(#tblOut.ProductWeight, 0) - ISNULL(tmpDT.ProductWeight, 0)
	FROM SYS_PRODUCT_STOCK PDS
		 LEFT JOIN OBJ_PRODUCT PRD ON PRD.ID = PDS.ProductID
		 LEFT JOIN @tblTRN_PRODUCT_OUT tmpDT ON tmpDT.ProductID = PDS.ProductID
		 LEFT JOIN #tblOut ON #tblOut.ProductID = PDS.ProductID
	WHERE StallsID = @p_StallsID
		  AND PRD.ProductType <> 0
	IF @@Error <> 0 GOTO ABORT

COMMIT TRANSACTION
	SELECT 1 AS Result, @vMessage AS MsgProcedure, @p_TrnID AS TrnID
	RETURN 1
ABORT:
BEGIN
	ROLLBACK TRANSACTION
	IF(@vMessage = '')
	BEGIN
		SET @vMessage = N'Thao tác thất bại'
	END
	SELECT 0 AS Result, @vMessage AS MsgProcedure, @p_TrnID AS TrnID
	RETURN 0
END
GO
--=========================================================================================================================================================
--=========================================================================================================================================================
IF EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TRN_PRODUCT_OUT_GetWithID]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[TRN_PRODUCT_OUT_GetWithID]
GO
CREATE PROCEDURE [dbo].[TRN_PRODUCT_OUT_GetWithID]
	@p_TrnID bigint = -1
AS
	SELECT PRO.TrnID,
	       PRO.TrnCode,
	       PRO.TrnDate,
	       PRO.TrnTime,
		   PRO.StallsID,
		   STL.StallsCode,
		   STL.StallsName,
		   STL.ShopID,
		   SHP.ShopCode,
		   SHP.ShopName,
	       PRO.Notes,
	       PRO.EmpID,
		   EMP.EmpCode,
		   EMP.EmpName,
	       PRO.StatusCode,
		   STT.StatusName
	FROM TRN_PRODUCT_OUT PRO
		 LEFT JOIN SYS_STATUS STT ON STT.StatusCode = PRO.StatusCode AND STT.StatusObject = 'TRN_PRODUCT_OUT'
		 LEFT JOIN CAT_EMPLOYEE EMP ON EMP.ID = PRO.EmpID
		 LEFT JOIN CAT_STALLS STL ON STL.ID = PRO.StallsID
		 LEFT JOIN CAT_SHOP SHP ON SHP.ID = STL.ShopID
	WHERE PRO.TrnID = @p_TrnID

	DECLARE @vStallsID bigint
	SELECT @vStallsID = PRO.StallsID FROM TRN_PRODUCT_OUT PRO WHERE PRO.TrnID = @p_TrnID

	SELECT	PROD.TrnID,
			PROD.ProductID,
			PRD.ProductCode,
			PRD.ProductDesc,
			PRD.Descriptions,
			PRDS.StallsID,
			STL.StallsCode,
			STL.StallsName,
			PRD.Supplier AS SupplierID,
			SPL.SupplierCode,
			SPL.SupplierName,
			PROD.ProductWeight AS WeightsOut,
			PRDS.Weights AS WeightsStock,
			PRDS.WeightsReal AS WeightsStockReal,
			PROD.Quantity AS QuantityOut,
			PRDS.Quantity AS QuantityStock,
			PRDS.QuantityReal AS QuantityStockReal,
			PROD.Notes
	FROM TRN_PRODUCT_OUT_DT PROD
		 LEFT JOIN OBJ_PRODUCT PRD ON PRD.ID = PROD.ProductID
		 LEFT JOIN SYS_PRODUCT_STOCK PRDS ON PRDS.ProductID = PRD.ID
		 LEFT JOIN CAT_STALLS STL ON STL.ID = PRDS.StallsID AND PRDS.StallsID = @vStallsID
		 LEFT JOIN CAT_SUPPLIER SPL ON SPL.ID = PRD.Supplier
	WHERE PROD.TrnID = @p_TrnID
GO
--=========================================================================================================================================================
--=========================================================================================================================================================
IF EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TRN_PRODUCT_OUT_GetDtl]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[TRN_PRODUCT_OUT_GetDtl]
GO
CREATE PROCEDURE [dbo].[TRN_PRODUCT_OUT_GetDtl]
	@p_TrnID bigint = -1
AS
	DECLARE @vStallsID bigint
	SELECT @vStallsID = PRO.StallsID FROM TRN_PRODUCT_OUT PRO WHERE PRO.TrnID = @p_TrnID

	SELECT	PROD.TrnID,
			PROD.ProductID,
			PRD.ProductCode,
			PRD.ProductDesc,
			PRD.Descriptions,
			PRDS.StallsID,
			STL.StallsCode,
			STL.StallsName,
			PRD.Supplier AS SupplierID,
			SPL.SupplierCode,
			SPL.SupplierName,
			PROD.ProductWeight AS WeightsOut,
			PRDS.Weights AS WeightsStock,
			PRDS.WeightsReal AS WeightsStockReal,
			PROD.Quantity AS QuantityOut,
			PRDS.Quantity AS QuantityStock,
			PRDS.QuantityReal AS QuantityStockReal,
			PROD.Notes
	FROM TRN_PRODUCT_OUT_DT PROD
		 LEFT JOIN OBJ_PRODUCT PRD ON PRD.ID = PROD.ProductID
		 LEFT JOIN SYS_PRODUCT_STOCK PRDS ON PRDS.ProductID = PRD.ID
		 LEFT JOIN CAT_STALLS STL ON STL.ID = PRDS.StallsID AND PRDS.StallsID = @vStallsID
		 LEFT JOIN CAT_SUPPLIER SPL ON SPL.ID = PRD.Supplier
	WHERE 1 = 1
		  AND (PROD.TrnID = @p_TrnID OR @p_TrnID = -1 OR @p_TrnID IS NULL)
GO
--=========================================================================================================================================================
--=========================================================================================================================================================
IF EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TRN_PRODUCT_IN_Complete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[TRN_PRODUCT_IN_Complete]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[TRN_PRODUCT_IN_Complete]
	@p_TrnID bigint = -1,
	@p_UpdateBy bigint = -1
AS
SET XACT_ABORT ON;
BEGIN TRANSACTION
	DECLARE @vMessage nvarchar(max)
	SET @vMessage = ''

	DECLARE @vProductCode varchar(15) = ''
	DECLARE @vProductDesc nvarchar(max) = ''
	DECLARE @vProductType bigint = -1
	DECLARE @vProductGroup bigint = -1
	DECLARE @vDescriptions nvarchar(max) = ''
	DECLARE @vProductWeight numeric(19,8) = 0
	DECLARE @vQuantity int = 0
	DECLARE @vUnitWeight bigint = -1
	DECLARE @vUnitIn bigint = -1
	DECLARE @vUnitSell bigint = -1
	DECLARE @vRateIn numeric(19,8) = 0
	DECLARE @vRateSell numeric(19,8) = 0
	DECLARE @vSupplier bigint = -1

	DECLARE pCurProductInComplete CURSOR FOR SELECT ProductCode, ProductDesc, ProductType, ProductGroup, Descriptions, ProductWeight, Quantity, UnitWeight, UnitIn, UnitSell, RateIn, RateSell, Supplier
							FROM TRN_PRODUCT_IN_DT WHERE TrnID = @p_TrnID
	OPEN pCurProductInComplete
	FETCH NEXT FROM pCurProductInComplete INTO @vProductCode, @vProductDesc, @vProductType, @vProductGroup, @vDescriptions, @vProductWeight, @vQuantity, @vUnitWeight, @vUnitIn, @vUnitSell, @vRateIn, @vRateSell, @vSupplier
	WHILE @@FETCH_STATUS = 0
	BEGIN
		-- Thêm vào bảng hàng hóa
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
		VALUES ( @vProductCode,
				 @vProductDesc,
				 @vDescriptions,
				 @vProductType,
				 @vProductGroup,
				 @vUnitWeight,
				 @vUnitSell,
				 @vSupplier,
				 'I',
				 GETDATE(),
				 @p_UpdateBy,
				 0)
		IF @@Error <> 0 GOTO ABORT

		DECLARE @vProductID int
		SELECT @vProductID = IDENT_CURRENT('OBJ_PRODUCT')
		IF @@Error <> 0 GOTO ABORT

		-- Thêm vào log hàng hóa
		INSERT INTO SYS_PRODUCT_LOG	(ProductID, 
									 InTrnID, 
									 InDateTime,
									 InQuantity,
									 InWeights,
									 OutTrnID,
									 OutTrnType,
									 OutDateTime,
									 OutQuantity,
									 OutWeights)
		VALUES ( @vProductID,
				 @p_TrnID,
				 GETDATE(),
				 @vQuantity,
				 @vProductWeight,
				 -1,
				 '',
				 NULL,
				 0,
				 0
				)
		IF @@Error <> 0 GOTO ABORT
		
		-- Cập nhật tồn kho
		DECLARE @vStallsID bigint
		SELECT @vStallsID = StallsID FROM TRN_PRODUCT_IN WHERE TrnID = @p_TrnID

		DECLARE @vScaleChange numeric(19,8)
		SELECT @vScaleChange = ISNULL(ScaleChange, 1)
		FROM CAT_UNIT_IN UNTI
		WHERE UNTI.ID = @vUnitIn

		IF EXISTS (SELECT TOP 1 1 FROM SYS_PRODUCT_STOCK WHERE StallsID = @vStallsID AND ProductID = @vProductID)
		BEGIN
			UPDATE SYS_PRODUCT_STOCK
			SET Quantity = Quantity + @vQuantity * @vScaleChange,
				QuantityReal = QuantityReal + @vQuantity * @vScaleChange,
				Weights = Weights + @vProductWeight,
				WeightsReal = WeightsReal + @vProductWeight
			WHERE StallsID = @vStallsID AND ProductID = @vProductID
			IF @@Error <> 0 GOTO ABORT
		END
		ELSE
		BEGIN
			INSERT INTO SYS_PRODUCT_STOCK (	StallsID,
											ProductID,
											Quantity,
											QuantityReal,
											Weights,
											WeightsReal)
			VALUES ( @vStallsID,
					 @vProductID,
					 @vQuantity * @vScaleChange,
					 @vQuantity* @vScaleChange,
					 @vProductWeight,
					 @vProductWeight)	 
			IF @@Error <> 0 GOTO ABORT
		END

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
		VALUES ( @vProductID,
				 GETDATE(),
				 @vRateIn,
				 @vRateSell,
				 0,
				 0,
				 0,
				 @vRateSell,
				 1)
		IF @@Error <> 0 GOTO ABORT

		FETCH NEXT FROM pCurProductInComplete INTO @vProductCode, @vProductDesc, @vProductType, @vProductGroup, @vDescriptions, @vProductWeight, @vQuantity, @vUnitWeight, @vUnitIn, @vUnitSell, @vRateIn, @vRateSell, @vSupplier
	END
	CLOSE pCurProductInComplete
	DEALLOCATE pCurProductInComplete
	IF @@Error <> 0 GOTO ABORT

	-- Cập nhật trạng thái nhập hàng
	UPDATE TRN_PRODUCT_IN 
	SET StatusCode = 'C',
		UpdateBy = @p_UpdateBy,
		UpdateDate = GETDATE()
	WHERE TrnID = @p_TrnID 
	IF @@Error <> 0 GOTO ABORT

COMMIT TRANSACTION
	SELECT 1 AS Result, @vMessage AS MsgProcedure
	RETURN 1
ABORT:
BEGIN
	ROLLBACK TRANSACTION
	IF (SELECT CURSOR_STATUS('global','pCurProductInComplete')) >= -1
	BEGIN
		IF (SELECT CURSOR_STATUS('global','pCurProductInComplete')) > -1
		BEGIN
			CLOSE pCur
		END
		DEALLOCATE pCur
	END

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
IF EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TRN_PRODUCT_IN_Del]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[TRN_PRODUCT_IN_Del]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[TRN_PRODUCT_IN_Del]
	@p_ID bigint = -1,
	@p_UpdateBy bigint = -1
AS
BEGIN TRANSACTION
	DECLARE @vMessage nvarchar(max)
	SET @vMessage = ''

	UPDATE TRN_PRODUCT_IN
	SET IsDelete = 1,
		UpdateBy = @p_UpdateBy,
		UpdateDate = GETDATE()
	WHERE TrnID = @p_ID
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
IF EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TRN_PRODUCT_IN_Lst]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[TRN_PRODUCT_IN_Lst]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[TRN_PRODUCT_IN_Lst]
      @p_TrnCode varchar(15) = '',
      @p_TrnDateFrom varchar(10) = '',
	  @p_TrnDateTo varchar(10) = '',
      @p_StallsID bigint = -1,
      @p_Notes nvarchar(max) = '',
      @p_EmpID bigint = -1,
      @p_StatusCode varchar(5) = ''
AS
	SELECT	PRI.TrnID,
			PRI.TrnCode,
			PRI.TrnDate,
			PRI.TrnTime,
			PRI.StallsID,
			STL.StallsCode,
			STL.StallsName,
			STL.ShopID,
			SHP.ShopCode,
			SHP.ShopName,
			PRI.Notes,
			PRI.EmpID,
			EMP.EmpCode,
			EMP.EmpName,
			PRI.StatusCode,
			STT.StatusName
	FROM TRN_PRODUCT_IN PRI
		 LEFT JOIN SYS_STATUS STT ON STT.StatusCode = PRI.StatusCode AND STT.StatusObject = 'TRN_PRODUCT_IN'
		 LEFT JOIN CAT_EMPLOYEE EMP ON EMP.ID = PRI.EmpID
		 LEFT JOIN CAT_STALLS STL ON STL.ID = PRI.StallsID
		 LEFT JOIN CAT_SHOP SHP ON SHP.ID = STL.ShopID
	WHERE PRI.IsDelete = 0
		  AND (PRI.TrnCode LIKE N'%' + @p_TrnCode + '%' OR @p_TrnCode = '' OR @p_TrnCode IS NULL)
		  AND (PRI.TrnDate >= CONVERT(date, @p_TrnDateFrom, 103) OR @p_TrnDateFrom = '' OR @p_TrnDateFrom IS NULL)
		  AND (PRI.TrnDate <= CONVERT(date, @p_TrnDateTo, 103) OR @p_TrnDateTo = '' OR @p_TrnDateTo IS NULL)
		  AND (PRI.StallsID = @p_StallsID OR @p_StallsID = -1 OR @p_StallsID IS NULL)
		  AND (PRI.Notes LIKE N'%' + @p_Notes + '%' OR @p_Notes = '' OR @p_Notes IS NULL)
		  AND (PRI.EmpID = @p_EmpID OR @p_EmpID = -1 OR @p_EmpID IS NULL)
		  AND (PRI.StatusCode = @p_StatusCode OR @p_StatusCode = '' OR @p_StatusCode IS NULL)		 
		 
GO

--=========================================================================================================================================================
--=========================================================================================================================================================
IF EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TRN_PRODUCT_IN_InsUpd]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[TRN_PRODUCT_IN_InsUpd]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[TRN_PRODUCT_IN_InsUpd]
	@p_TrnID bigint = -1,
	@p_TrnCode varchar(15) = '',
	@p_StallsID  bigint = -1,
	@p_Notes nvarchar(max) = '',
	@p_EmpID bigint = -1,
	@p_StatusCode varchar(15) = '',
	@p_UpdateBy bigint = -1,
	@p_xmlDtl xml
AS
BEGIN TRANSACTION
	DECLARE @vMessage nvarchar(max)
	SET @vMessage = ''
	IF(@p_TrnID = -1 OR @p_TrnID IS NULL)
	BEGIN
		INSERT INTO [dbo].[TRN_PRODUCT_IN]
		           (TrnCode,
		            TrnDate,
		            TrnTime,
					StallsID,
		            Notes,
		            EmpID,
		            StatusCode,
		            UpdateDate,
		            UpdateBy,
		            IsDelete)
		VALUES (@p_TrnCode,
		        CONVERT(date, GETDATE()),
		        CONVERT(time, GETDATE()),
				@p_StallsID,
		        ISNULL(@p_Notes,''),
		        @p_EmpID,
		        @p_StatusCode,
		        CONVERT(datetime, GETDATE()),
		        @p_UpdateBy,
		        0)
		IF @@Error <> 0 GOTO ABORT

		SET @p_TrnID = IDENT_CURRENT('TRN_PRODUCT_IN')
		IF @@Error <> 0 GOTO ABORT
	END
	ELSE
	BEGIN
		UPDATE [dbo].[TRN_PRODUCT_IN]
		SET StallsID = @p_StallsID,
		    Notes = ISNULL(@p_Notes,''),
		    EmpID = @p_EmpID,
		    StatusCode = @p_StatusCode,
			UpdateDate = GETDATE(),
			UpdateBy = @p_UpdateBy
		WHERE TrnID = @p_TrnID
		IF @@Error <> 0 GOTO ABORT
	END  

	-----------------------------------------------------------------------------------------------------------
	DELETE FROM TRN_PRODUCT_IN_DT WHERE TrnID = @p_TrnID
	
	DECLARE @tblTRN_PRODUCT_IN TABLE(ProductCode varchar(15),
									 ProductDesc nvarchar(max),
									 ProductTypeID bigint,
									 ProductGroupID bigint,
									 Descriptions nvarchar(max),
									 ProductWeight numeric(19,8),
									 Quantity int,
									 UnitWeightID bigint,
									 UnitInID bigint,
									 UnitSellID bigint,
									 RateIn numeric(19,8),
									 RateSell numeric(19,8),
									 SupplierID bigint)
	INSERT INTO @tblTRN_PRODUCT_IN SELECT Tbl.Col.value('(ProductCode/text())[1]', 'varchar(15)') AS ProductCode,
										  Tbl.Col.value('(ProductDesc/text())[1]', 'nvarchar(max)') AS ProductDesc,																		
										  Tbl.Col.value('(ProductTypeID/text())[1]', 'bigint') AS ProductType,
										  Tbl.Col.value('(ProductGroupID/text())[1]', 'bigint') AS ProductGroup,
										  Tbl.Col.value('(Descriptions/text())[1]', 'nvarchar(max)') AS Descriptions,
										  Tbl.Col.value('(ProductWeight/text())[1]', 'numeric(19,8)') AS ProductWeight,
										  Tbl.Col.value('(Quantity/text())[1]', 'int') AS Quantity,
										  Tbl.Col.value('(UnitWeightID/text())[1]', 'bigint') AS UnitWeight,
										  Tbl.Col.value('(UnitInID/text())[1]', 'bigint') AS UnitIn,
										  Tbl.Col.value('(UnitSellID/text())[1]', 'bigint') AS UnitSell,
										  Tbl.Col.value('(RateIn/text())[1]', ' numeric(19,8)') AS RateIn,
										  Tbl.Col.value('(RateSell/text())[1]', ' numeric(19,8)') AS RateSell,
										  Tbl.Col.value('(SupplierID/text())[1]', 'bigint') AS Supplier
									FROM @p_xmlDtl.nodes('//Transaction') AS Tbl(Col)

	INSERT INTO [dbo].[TRN_PRODUCT_IN_DT]	(TrnID
											,ProductCode
											,ProductDesc
											,ProductType
											,ProductGroup
											,Descriptions
											,ProductWeight
											,Quantity
											,UnitWeight
											,UnitIn
											,UnitSell
											,RateIn
											,RateSell
											,Supplier)
	SELECT	@p_TrnID AS TrnID,
			ISNULL(ProductCode, ''),
			ISNULL(ProductDesc, ''),
			CASE WHEN ProductTypeID = -1 THEN NULL ELSE ProductTypeID END AS ProductTypeID,
			CASE WHEN ProductGroupID = -1 THEN NULL ELSE ProductGroupID END AS ProductGroupID,
			ISNULL(Descriptions,''),
			ISNULL(ProductWeight, 0),
			ISNULL(Quantity, 0),
			CASE WHEN UnitWeightID = -1 THEN NULL ELSE UnitWeightID END AS UnitWeightID,
			CASE WHEN UnitInID = -1 THEN NULL ELSE UnitInID END AS UnitInID,
			CASE WHEN UnitSellID = -1 THEN NULL ELSE UnitSellID END AS UnitSellID,
			ISNULL(RateIn, 0),
			ISNULL(RateSell, 0),
			CASE WHEN SupplierID = -1 THEN NULL ELSE SupplierID END AS SupplierID
	FROM @tblTRN_PRODUCT_IN
	IF @@Error <> 0 GOTO ABORT

COMMIT TRANSACTION
	SELECT 1 AS Result, @vMessage AS MsgProcedure, @p_TrnID AS TrnID
	RETURN 1
ABORT:
BEGIN
	ROLLBACK TRANSACTION
	IF(@vMessage = '')
	BEGIN
		SET @vMessage = N'Thao tác thất bại'
	END
	SELECT 0 AS Result, @vMessage AS MsgProcedure, @p_TrnID AS TrnID
	RETURN 0
END
GO
--=========================================================================================================================================================
--=========================================================================================================================================================
IF EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TRN_PRODUCT_IN_GetWithID]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[TRN_PRODUCT_IN_GetWithID]
GO
CREATE PROCEDURE [dbo].[TRN_PRODUCT_IN_GetWithID]
	@p_TrnID bigint = -1
AS
	SELECT	PRI.TrnID,
			PRI.TrnCode,
			PRI.TrnDate,
			PRI.TrnTime,
			PRI.StallsID,
			STL.StallsCode,
			STL.StallsName,
			STL.ShopID,
			SHP.ShopCode,
			SHP.ShopName,
			PRI.Notes,
			PRI.EmpID,
			EMP.EmpCode,
			EMP.EmpName,
			PRI.StatusCode,
			STT.StatusName
	FROM TRN_PRODUCT_IN PRI
		 LEFT JOIN SYS_STATUS STT ON STT.StatusCode = PRI.StatusCode AND STT.StatusObject = 'TRN_PRODUCT_IN'
		 LEFT JOIN CAT_EMPLOYEE EMP ON EMP.ID = PRI.EmpID
		 LEFT JOIN CAT_STALLS STL ON STL.ID = PRI.StallsID
		 LEFT JOIN CAT_SHOP SHP ON SHP.ID = STL.ShopID
	WHERE PRI.TrnID = @p_TrnID

	SELECT PRID.TrnID,
	       PRID.ProductCode,
	       PRID.ProductDesc,
	       PRID.ProductType AS ProductTypeID,
		   PRT.ProductTypeCode,
		   PRT.ProductTypeName,
	       PRID.ProductGroup AS ProductGroupID,
		   PRG.ProductGroupCode,
		   PRG.ProductGroupName,
	       PRID.Descriptions,
	       PRID.ProductWeight,
	       PRID.Quantity,
	       PRID.UnitWeight AS UnitWeightID,
		   UNW.UnitWeightCode,
		   UNW.UnitWeightDesc,
	       PRID.UnitIn AS UnitInID,
		   UNI.UnitInCode,
		   UNI.UnitInDesc,
	       PRID.UnitSell AS UnitSellID,
		   UNS.UnitSellCode,
		   UNS.UnitSellDesc,
	       PRID.RateIn,
	       PRID.RateSell,
	       PRID.Supplier AS SupplierID,
		   SUP.SupplierCode,
		   SUP.SupplierName
	FROM TRN_PRODUCT_IN_DT PRID
		 LEFT JOIN CAT_PRODUCTTYPE PRT ON PRT.ID = PRID.ProductType
		 LEFT JOIN CAT_PRODUCTGROUP PRG ON PRG.ID = PRID.ProductGroup
		 LEFT JOIN CAT_UNIT_WEIGHT UNW ON UNW.ID = PRID.UnitWeight
		 LEFT JOIN CAT_UNIT_IN UNI ON UNI.ID = PRID.UnitIn
		 LEFT JOIN CAT_UNIT_SELL UNS ON UNS.ID = PRID.UnitSell
		 LEFT JOIN CAT_SUPPLIER SUP ON SUP.ID = PRID.Supplier
	WHERE PRID.TrnID = @p_TrnID
GO
--=========================================================================================================================================================
--=========================================================================================================================================================
IF EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TRN_PRODUCT_IN_GetDtl]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[TRN_PRODUCT_IN_GetDtl]
GO
CREATE PROCEDURE [dbo].[TRN_PRODUCT_IN_GetDtl]
	@p_TrnID bigint = -1
AS
	SELECT PRID.TrnID,
	       PRID.ProductCode,
	       PRID.ProductDesc,
	       PRID.ProductType AS ProductTypeID,
		   PRT.ProductTypeCode,
		   PRT.ProductTypeName,
	       PRID.ProductGroup AS ProductGroupID,
		   PRG.ProductGroupCode,
		   PRG.ProductGroupName,
	       PRID.Descriptions,
	       PRID.ProductWeight,
	       PRID.Quantity,
	       PRID.UnitWeight AS UnitWeightID,
		   UNW.UnitWeightCode,
		   UNW.UnitWeightDesc,
	       PRID.UnitIn AS UnitInID,
		   UNI.UnitInCode,
		   UNI.UnitInDesc,
	       PRID.UnitSell AS UnitSellID,
		   UNS.UnitSellCode,
		   UNS.UnitSellDesc,
	       PRID.RateIn,
	       PRID.RateSell,
	       PRID.Supplier AS SupplierID,
		   SUP.SupplierCode,
		   SUP.SupplierName
	FROM TRN_PRODUCT_IN_DT PRID
		 LEFT JOIN CAT_PRODUCTTYPE PRT ON PRT.ID = PRID.ProductType
		 LEFT JOIN CAT_PRODUCTGROUP PRG ON PRG.ID = PRID.ProductGroup
		 LEFT JOIN CAT_UNIT_WEIGHT UNW ON UNW.ID = PRID.UnitWeight
		 LEFT JOIN CAT_UNIT_IN UNI ON UNI.ID = PRID.UnitIn
		 LEFT JOIN CAT_UNIT_SELL UNS ON UNS.ID = PRID.UnitSell
		 LEFT JOIN CAT_SUPPLIER SUP ON SUP.ID = PRID.Supplier
	WHERE 1 = 1
		  AND (PRID.TrnID = @p_TrnID OR @p_TrnID = -1 OR @p_TrnID IS NULL)
GO
--=========================================================================================================================================================
--=========================================================================================================================================================
IF EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TRN_COUNTER_TRANSFER_Complete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[TRN_COUNTER_TRANSFER_Complete]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[TRN_COUNTER_TRANSFER_Complete]
	@p_TrnID bigint = -1,
	@p_UpdateBy bigint = -1
AS
SET XACT_ABORT ON;
BEGIN TRANSACTION
	DECLARE @vMessage nvarchar(max)
	SET @vMessage = ''

	DECLARE @vCurrencyID bigint = -1
	DECLARE @vAmount numeric(19,8) = 0

	DECLARE pCurCounterTransferComplete CURSOR FOR SELECT Currency, Amount
												   FROM TRN_COUNTER_TRANSFER_DT WHERE TrnID = @p_TrnID
	OPEN pCurCounterTransferComplete
	FETCH NEXT FROM pCurCounterTransferComplete INTO @vCurrencyID, @vAmount
	WHILE @@FETCH_STATUS = 0
	BEGIN
		-- Cập nhật tồn quầy chuyển
		DECLARE @p_CounterFrom bigint
		SELECT @p_CounterFrom = CounterFrom FROM TRN_COUNTER_TRANSFER WHERE TrnID = @p_TrnID

		UPDATE SYS_COUNTER_STOCK
		SET InStock = InStock - @vAmount
		WHERE CounterID = @p_CounterFrom AND CurrencyID = @vCurrencyID
		IF @@Error <> 0 GOTO ABORT

		-- Cập nhật tồn kho quầy nhận
		DECLARE @p_CounterTo bigint
		SELECT @p_CounterTo = CounterFrom FROM TRN_COUNTER_TRANSFER WHERE TrnID = @p_TrnID

		UPDATE SYS_COUNTER_STOCK
		SET InStock = InStock + @vAmount
		WHERE CounterID = @p_CounterTo AND CurrencyID = @vCurrencyID
		IF @@Error <> 0 GOTO ABORT

		FETCH NEXT FROM pCurCounterTransferComplete INTO @vCurrencyID, @vAmount
	END
	CLOSE pCurCounterTransferComplete
	DEALLOCATE pCurCounterTransferComplete
	IF @@Error <> 0 GOTO ABORT

	-- Cập nhật trạng thái chuyển quầy
	UPDATE TRN_COUNTER_TRANSFER 
	SET StatusCode = 'C',
		UpdateBy = @p_UpdateBy,
		UpdateDate = GETDATE()
	WHERE TrnID = @p_TrnID 
	IF @@Error <> 0 GOTO ABORT

COMMIT TRANSACTION
	SELECT 1 AS Result, @vMessage AS MsgProcedure
	RETURN 1
ABORT:
BEGIN
	ROLLBACK TRANSACTION
	IF (SELECT CURSOR_STATUS('global','pCurCounterTransferComplete')) >= -1
	BEGIN
		IF (SELECT CURSOR_STATUS('global','pCurCounterTransferComplete')) > -1
		BEGIN
			CLOSE pCur
		END
		DEALLOCATE pCur
	END

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
IF EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TRN_COUNTER_TRANSFER_Del]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[TRN_COUNTER_TRANSFER_Del]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[TRN_COUNTER_TRANSFER_Del]
	@p_ID bigint = -1,
	@p_UpdateBy bigint = -1
AS
BEGIN TRANSACTION
	DECLARE @vMessage nvarchar(max)
	SET @vMessage = ''

	UPDATE TRN_COUNTER_TRANSFER
	SET IsDelete = 1,
		UpdateBy = @p_UpdateBy,
		UpdateDate = GETDATE()
	WHERE TrnID = @p_ID
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
IF EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TRN_COUNTER_TRANSFER_Lst]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[TRN_COUNTER_TRANSFER_Lst]
GO
CREATE PROCEDURE [dbo].[TRN_COUNTER_TRANSFER_Lst]
      @p_TrnCode varchar(15) = '',
      @p_TrnDateFrom varchar(10) = '',
	  @p_TrnDateTo varchar(10) = '',
      @p_CounterFrom bigint = -1,
      @p_CounterTo bigint = -1,
      @p_Notes nvarchar(max) = '',
      @p_EmpID bigint = -1,
      @p_StatusCode varchar(5) = ''	
AS
	SELECT	CTF.TrnID,
			CTF.TrnCode,
			CTF.TrnDate,
			CTF.TrnTime,
			CTF.CounterFrom AS CounterFromID,
			CNTF.CounterCode AS CounterFromCode,
			CNTF.CounterName AS CounterFromName,
			CTF.CounterTo AS CounterToID,
			CNTT.CounterCode AS CounterToCode,
			CNTT.CounterName AS CounterToName,
			CTF.Notes,
			CTF.EmpID,
			EMP.EmpCode,
			EMP.EmpName,
			CTF.StatusCode,
			STT.StatusName
	FROM TRN_COUNTER_TRANSFER CTF
		 LEFT JOIN SYS_STATUS STT ON STT.StatusCode = CTF.StatusCode AND STT.StatusObject = 'TRN_COUNTER_TRANSFER'
		 LEFT JOIN CAT_EMPLOYEE EMP ON EMP.ID = CTF.EmpID
		 LEFT JOIN CAT_COUNTER CNTF ON CNTF.ID = CTF.CounterFrom
		 LEFT JOIN CAT_COUNTER CNTT ON CNTT.ID = CTF.CounterTo
	WHERE CTF.IsDelete = 0
		  AND (CTF.TrnCode LIKE N'%' + @p_TrnCode + '%' OR @p_TrnCode = '' OR @p_TrnCode IS NULL)
		  AND (CTF.TrnDate >= CONVERT(date, @p_TrnDateFrom, 103) OR @p_TrnDateFrom = '' OR @p_TrnDateFrom IS NULL)
		  AND (CTF.TrnDate <= CONVERT(date, @p_TrnDateTo, 103) OR @p_TrnDateTo = '' OR @p_TrnDateTo IS NULL)
		  AND (CTF.CounterFrom = @p_CounterFrom OR @p_CounterFrom = -1 OR @p_CounterFrom IS NULL)
		  AND (CTF.CounterTo = @p_CounterTo OR @p_CounterTo = -1 OR @p_CounterTo IS NULL)
		  AND (CTF.Notes LIKE N'%' + @p_Notes + '%' OR @p_Notes = '' OR @p_Notes IS NULL)
		  AND (CTF.EmpID = @p_EmpID OR @p_EmpID = -1 OR @p_EmpID IS NULL)
		  AND (CTF.StatusCode = @p_StatusCode OR @p_StatusCode = '' OR @p_StatusCode IS NULL)
GO
--=========================================================================================================================================================
--=========================================================================================================================================================
IF EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TRN_COUNTER_TRANSFER_InsUpd]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[TRN_COUNTER_TRANSFER_InsUpd]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[TRN_COUNTER_TRANSFER_InsUpd]
	@p_TrnID bigint = -1,
	@p_TrnCode varchar(15) = '',
	@p_CounterFrom bigint = -1,
	@p_CounterTo bigint = -1,
	@p_Notes nvarchar(max) = '',
	@p_EmpID bigint = -1,
	@p_StatusCode varchar(15) = '',
	@p_UpdateBy bigint = -1,
	@p_xmlDtl xml
AS
BEGIN TRANSACTION
	DECLARE @vMessage nvarchar(max)
	SET @vMessage = ''

	IF(@p_TrnID = -1 OR @p_TrnID IS NULL)
	BEGIN
		INSERT INTO [dbo].[TRN_COUNTER_TRANSFER]
		           (TrnCode,
		            TrnDate,
		            TrnTime,
					CounterFrom,
					CounterTo,
		            Notes,
		            EmpID,
		            StatusCode,
		            UpdateDate,
		            UpdateBy,
		            IsDelete)
		VALUES (@p_TrnCode,
		        CONVERT(date, GETDATE()),
		        CONVERT(time, GETDATE()),
				@p_CounterFrom,
				@p_CounterTo,
		        @p_Notes,
		        @p_EmpID,
		        @p_StatusCode,
		        CONVERT(datetime, GETDATE()),
		        @p_UpdateBy,
		        0)
		IF @@Error <> 0 GOTO ABORT

		SET @p_TrnID = IDENT_CURRENT('TRN_COUNTER_TRANSFER')
		IF @@Error <> 0 GOTO ABORT
	END
	ELSE
	BEGIN
		UPDATE [dbo].[TRN_COUNTER_TRANSFER]
		SET TrnCode = @p_TrnCode,
			CounterFrom = @p_CounterFrom,
			CounterTo = @p_CounterTo,
		    Notes = @p_Notes,
		    EmpID = @p_EmpID,
		    StatusCode = @p_StatusCode,
			UpdateDate = GETDATE(),
			UpdateBy = @p_UpdateBy
		WHERE TrnID = @p_TrnID
		IF @@Error <> 0 GOTO ABORT
	END  

	-----------------------------------------------------------------------------------------------------------
	DELETE FROM TRN_COUNTER_TRANSFER_DT WHERE TrnID = @p_TrnID
	
	DECLARE @tblTRN_COUNTER_TRANSFER TABLE(	OrdinalNumber bigint,
											Currency bigint, 
											Amount numeric(19,8),
											Notes nvarchar(max))
	INSERT INTO @tblTRN_COUNTER_TRANSFER SELECT Tbl.Col.value('(OrdinalNumber/text())[1]', 'bigint') AS OrdinalNumber,	
												Tbl.Col.value('(CurrencyID/text())[1]', 'bigint') AS Currency,																		
												Tbl.Col.value('(Amount/text())[1]', 'numeric(19,8)') AS Amount,
												Tbl.Col.value('(Notes/text())[1]', 'nvarchar(max)') AS Notes
									FROM @p_xmlDtl.nodes('//Transaction') AS Tbl(Col)

	INSERT INTO TRN_COUNTER_TRANSFER_DT ([TrnID]
										,[OrdinalNumber]
										,[Currency]
										,[Amount]
										,[Notes])
	SELECT	@p_TrnID AS TrnID,
			OrdinalNumber,
			Currency,
			Amount,
			ISNULL(Notes,'')
	FROM @tblTRN_COUNTER_TRANSFER
	IF @@Error <> 0 GOTO ABORT

COMMIT TRANSACTION
	SELECT 1 AS Result, @vMessage AS MsgProcedure, @p_TrnID AS TrnID
	RETURN 1
ABORT:
BEGIN
	ROLLBACK TRANSACTION
	IF(@vMessage = '')
	BEGIN
		SET @vMessage = N'Thao tác thất bại'
	END
	SELECT 0 AS Result, @vMessage AS MsgProcedure, @p_TrnID AS TrnID
	RETURN 0
END
GO
--=========================================================================================================================================================
--=========================================================================================================================================================
IF EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TRN_COUNTER_TRANSFER_GetWithID]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[TRN_COUNTER_TRANSFER_GetWithID]
GO
CREATE PROCEDURE [dbo].[TRN_COUNTER_TRANSFER_GetWithID]
	@p_TrnID bigint = -1
AS
	SELECT	CTF.TrnID,
			CTF.TrnCode,
			CTF.TrnDate,
			CTF.TrnTime,
			CTF.CounterFrom AS CounterFromID,
			CNTF.CounterCode AS CounterFromCode,
			CNTF.CounterName AS CounterFromName,
			CTF.CounterTo AS CounterToID,
			CNTT.CounterCode AS CounterToCode,
			CNTT.CounterName AS CounterToName,
			CTF.Notes,
			CTF.EmpID,
			EMP.EmpCode,
			EMP.EmpName,
			CTF.StatusCode,
			STT.StatusName
	FROM TRN_COUNTER_TRANSFER CTF
		 LEFT JOIN SYS_STATUS STT ON STT.StatusCode = CTF.StatusCode AND STT.StatusObject = 'TRN_COUNTER_TRANSFER'
		 LEFT JOIN CAT_EMPLOYEE EMP ON EMP.ID = CTF.EmpID
		 LEFT JOIN CAT_COUNTER CNTF ON CNTF.ID = CTF.CounterFrom
		 LEFT JOIN CAT_COUNTER CNTT ON CNTT.ID = CTF.CounterTo
	WHERE CTF.TrnID = @p_TrnID

	SELECT CTFD.TrnID,
		   CTFD.OrdinalNumber,
	       CTFD.Currency AS CurrencyID,
		   CRC.CurrencyCode,
		   CRC.CurrencyDesc,
	       CTFD.Amount,
	       CTFD.Notes
	FROM TRN_COUNTER_TRANSFER_DT CTFD
		 LEFT JOIN CAT_CURRENCY CRC ON CRC.ID = CTFD.Currency
	WHERE CTFD.TrnID = @p_TrnID
GO
--=========================================================================================================================================================
--=========================================================================================================================================================
IF EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TRN_COUNTER_TRANSFER_GetDtl]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[TRN_COUNTER_TRANSFER_GetDtl]
GO
CREATE PROCEDURE [dbo].[TRN_COUNTER_TRANSFER_GetDtl]
	@p_TrnID bigint = -1
AS
	SELECT CTFD.TrnID,
		   CTFD.OrdinalNumber,
	       CTFD.Currency AS CurrencyID,
		   CRC.CurrencyCode,
		   CRC.CurrencyDesc,
	       CTFD.Amount,
	       CTFD.Notes
	FROM TRN_COUNTER_TRANSFER_DT CTFD
		 LEFT JOIN CAT_CURRENCY CRC ON CRC.ID = CTFD.Currency
	WHERE 1 = 1
		  AND (CTFD.TrnID = @p_TrnID OR @p_TrnID = -1 OR @p_TrnID IS NULL)
GO
--=========================================================================================================================================================
--=========================================================================================================================================================
IF EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TRN_COUNTER_INOUT_Complete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[TRN_COUNTER_INOUT_Complete]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[TRN_COUNTER_INOUT_Complete]
	@p_TrnID bigint = -1,
	@p_UpdateBy bigint = -1
AS
SET XACT_ABORT ON;
BEGIN TRANSACTION
	DECLARE @vMessage nvarchar(max)
	SET @vMessage = ''

	DECLARE @vTrnType bit
	DECLARE @vCurrencyID bigint = -1
	DECLARE @vAmount numeric(19,8) = 0

	DECLARE pCurCounterOutComplete CURSOR FOR SELECT TrnType, Currency, Amount
											  FROM TRN_COUNTER_INOUT_DT WHERE TrnID = @p_TrnID
	OPEN pCurCounterOutComplete
	FETCH NEXT FROM pCurCounterOutComplete INTO @vTrnType, @vCurrencyID, @vAmount
	WHILE @@FETCH_STATUS = 0
	BEGIN	
		-- Cập nhật tồn kho
		DECLARE @vCounterID bigint
		SELECT @vCounterID = CounterID FROM TRN_COUNTER_INOUT WHERE TrnID = @p_TrnID

		IF (@vTrnType = 1)
		BEGIN
			UPDATE SYS_COUNTER_STOCK
			SET InStock = InStock + @vAmount
			WHERE CounterID = @vCounterID AND CurrencyID = @vCurrencyID
		IF @@Error <> 0 GOTO ABORT
		END
		ELSE
		BEGIN
			UPDATE SYS_COUNTER_STOCK
			SET InStock = InStock - @vAmount
			WHERE CounterID = @vCounterID AND CurrencyID = @vCurrencyID
		END

		FETCH NEXT FROM pCurCounterOutComplete INTO @vTrnType, @vCurrencyID, @vAmount
	END
	CLOSE pCurCounterOutComplete
	DEALLOCATE pCurCounterOutComplete
	IF @@Error <> 0 GOTO ABORT

	-- Cập nhật trạng thái thu chi tại quầy
	UPDATE TRN_COUNTER_INOUT 
	SET StatusCode = 'C',
		UpdateBy = @p_UpdateBy,
		UpdateDate = GETDATE()
	WHERE TrnID = @p_TrnID 
	IF @@Error <> 0 GOTO ABORT

COMMIT TRANSACTION
	SELECT 1 AS Result, @vMessage AS MsgProcedure
	RETURN 1
ABORT:
BEGIN
	ROLLBACK TRANSACTION
	IF (SELECT CURSOR_STATUS('global','pCurCounterOutComplete')) >= -1
	BEGIN
		IF (SELECT CURSOR_STATUS('global','pCurCounterOutComplete')) > -1
		BEGIN
			CLOSE pCur
		END
		DEALLOCATE pCur
	END

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
IF EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TRN_COUNTER_INOUT_Del]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[TRN_COUNTER_INOUT_Del]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[TRN_COUNTER_INOUT_Del]
	@p_ID bigint = -1,
	@p_UpdateBy bigint = -1
AS
BEGIN TRANSACTION
	DECLARE @vMessage nvarchar(max)
	SET @vMessage = ''

	UPDATE TRN_COUNTER_INOUT
	SET IsDelete = 1,
		UpdateBy = @p_UpdateBy,
		UpdateDate = GETDATE()
	WHERE TrnID = @p_ID
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
IF EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TRN_COUNTER_INOUT_Lst]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[TRN_COUNTER_INOUT_Lst]
GO
CREATE PROCEDURE [dbo].[TRN_COUNTER_INOUT_Lst]
      @p_TrnCode varchar(15) = '',
      @p_TrnDateFrom varchar(10) = '',
	  @p_TrnDateTo varchar(10) = '',
      @p_Notes nvarchar(max) = '',
      @p_EmpID bigint = -1,
      @p_StatusCode varchar(5) = ''
AS
	SELECT	CIO.TrnID,
			CIO.TrnCode,
			CIO.TrnDate,
			CIO.TrnTime,
			CIO.CounterID,
			CNT.CounterCode,
			CNT.CounterName,
			CIO.Notes,
			CIO.EmpID,
			EMP.EmpCode,
			EMP.EmpName,
			CIO.StatusCode,
			STT.StatusName
	FROM TRN_COUNTER_INOUT CIO
		 LEFT JOIN SYS_STATUS STT ON STT.StatusCode = CIO.StatusCode AND STT.StatusObject = 'TRN_COUNTER_INOUT'
		 LEFT JOIN CAT_EMPLOYEE EMP ON EMP.ID = CIO.EmpID
		 LEFT JOIN CAT_COUNTER CNT ON CNT.ID = CIO.CounterID
	WHERE CIO.IsDelete = 0
		  AND (CIO.TrnCode LIKE N'%' + @p_TrnCode + '%' OR @p_TrnCode = '' OR @p_TrnCode IS NULL)
		  AND (CIO.TrnDate >= CONVERT(date, @p_TrnDateFrom, 103) OR @p_TrnDateFrom = '' OR @p_TrnDateFrom IS NULL)
		  AND (CIO.TrnDate <= CONVERT(date, @p_TrnDateTo, 103) OR @p_TrnDateTo = '' OR @p_TrnDateTo IS NULL)
		  AND (CIO.Notes LIKE N'%' + @p_Notes + '%' OR @p_Notes = '' OR @p_Notes IS NULL)
		  AND (CIO.EmpID = @p_EmpID OR @p_EmpID = -1 OR @p_EmpID IS NULL)
		  AND (CIO.StatusCode = @p_StatusCode OR @p_StatusCode = '' OR @p_StatusCode IS NULL)
GO
--=========================================================================================================================================================
--=========================================================================================================================================================
IF EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TRN_COUNTER_INOUT_InsUpd]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[TRN_COUNTER_INOUT_InsUpd]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[TRN_COUNTER_INOUT_InsUpd]
	@p_TrnID bigint = -1,
	@p_TrnCode varchar(15) = '',
	@p_CounterID bigint = -1,
	@p_Notes nvarchar(max) = '',
	@p_EmpID bigint = -1,
	@p_StatusCode varchar(15) = '',
	@p_UpdateBy bigint = -1,
	@p_xmlDtl xml
AS
BEGIN TRANSACTION
	DECLARE @vMessage nvarchar(max)
	SET @vMessage = ''
	IF(@p_TrnID = -1 OR @p_TrnID IS NULL)
	BEGIN
		INSERT INTO [dbo].[TRN_COUNTER_INOUT]
		           (TrnCode,
		            TrnDate,
		            TrnTime,
					CounterID,
		            Notes,
		            EmpID,
		            StatusCode,
		            UpdateDate,
		            UpdateBy,
		            IsDelete)
		VALUES (@p_TrnCode,
		        CONVERT(date, GETDATE()),
		        CONVERT(time, GETDATE()),
				@p_CounterID,
		        @p_Notes,
		        @p_EmpID,
		        @p_StatusCode,
		        CONVERT(datetime, GETDATE()),
		        @p_UpdateBy,
		        0)
		IF @@Error <> 0 GOTO ABORT

		SET @p_TrnID = IDENT_CURRENT('TRN_COUNTER_INOUT')
		IF @@Error <> 0 GOTO ABORT
	END
	ELSE
	BEGIN
		UPDATE [dbo].[TRN_COUNTER_INOUT]
		SET TrnCode = @p_TrnCode,
		    Notes = @p_Notes,
		    EmpID = @p_EmpID,
		    StatusCode = @p_StatusCode,
			UpdateDate = GETDATE(),
			UpdateBy = @p_UpdateBy
		WHERE TrnID = @p_TrnID
		IF @@Error <> 0 GOTO ABORT
	END  

	-----------------------------------------------------------------------------------------------------------
	DELETE FROM TRN_COUNTER_INOUT_DT WHERE TrnID = @p_TrnID
	
	DECLARE @tblTRN_COUNTER_INOUT TABLE(OrdinalNumber bigint, 
										TrnType bit,
										Currency bigint, 
										Amount numeric(19,8),
										Notes nvarchar(max))
	INSERT INTO @tblTRN_COUNTER_INOUT SELECT Tbl.Col.value('(OrdinalNumber/text())[1]', 'bigint') AS OrdinalNumber,		
											 Tbl.Col.value('(TrnTypeID/text())[1]', 'bit') AS TrnType,
											 Tbl.Col.value('(CurrencyID/text())[1]', 'bigint') AS Currency,																		
											 Tbl.Col.value('(Amount/text())[1]', 'numeric(19,8)') AS Amount,
											 Tbl.Col.value('(Notes/text())[1]', 'nvarchar(max)') AS Notes
									FROM @p_xmlDtl.nodes('//Transaction') AS Tbl(Col)

	INSERT INTO TRN_COUNTER_INOUT_DT ([TrnID]
									 ,[OrdinalNumber]
									 ,[TrnType]
									 ,[Currency]
									 ,[Amount]
									 ,[Notes])
	SELECT	@p_TrnID AS TrnID,
			OrdinalNumber,
			TrnType,
			Currency,
			Amount,
			ISNULL(Notes, '')
	FROM @tblTRN_COUNTER_INOUT
	IF @@Error <> 0 GOTO ABORT

COMMIT TRANSACTION
	SELECT 1 AS Result, @vMessage AS MsgProcedure, @p_TrnID AS TrnID
	RETURN 1
ABORT:
BEGIN
	ROLLBACK TRANSACTION
	IF(@vMessage = '')
	BEGIN
		SET @vMessage = N'Thao tác thất bại'
	END
	SELECT 0 AS Result, @vMessage AS MsgProcedure, @p_TrnID AS TrnID
	RETURN 0
END
GO
--=========================================================================================================================================================
--=========================================================================================================================================================
IF EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TRN_COUNTER_INOUT_GetWithID]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[TRN_COUNTER_INOUT_GetWithID]
GO
CREATE PROCEDURE [dbo].[TRN_COUNTER_INOUT_GetWithID]
      @p_TrnID bigint = -1
AS
	SELECT	CIO.TrnID,
			CIO.TrnCode,
			CIO.TrnDate,
			CIO.TrnTime,
			CIO.CounterID,
			CNT.CounterCode,
			CNT.CounterName,
			CIO.Notes,
			CIO.EmpID,
			EMP.EmpCode,
			EMP.EmpName,
			CIO.StatusCode,
			STT.StatusName
	FROM TRN_COUNTER_INOUT CIO
		 LEFT JOIN SYS_STATUS STT ON STT.StatusCode = CIO.StatusCode AND STT.StatusObject = 'TRN_COUNTER_INOUT'
		 LEFT JOIN CAT_EMPLOYEE EMP ON EMP.ID = CIO.EmpID
		 LEFT JOIN CAT_COUNTER CNT ON CNT.ID = CIO.CounterID
	WHERE CIO.TrnID = @p_TrnID

	SELECT CIOD.TrnID,
		   CIOD.OrdinalNumber,
	       CIOD.TrnType AS TrnTypeID,
		   CASE WHEN CIOD.TrnType = 1 THEN N'Thu' ELSE N'Chi' END AS TrnTypeName,
	       CIOD.Currency AS CurrencyID,
		   CRC.CurrencyCode,
		   CRC.CurrencyDesc,
	       CIOD.Amount,
	       CIOD.Notes
	FROM TRN_COUNTER_INOUT_DT CIOD
		 LEFT JOIN CAT_CURRENCY CRC ON CRC.ID = CIOD.Currency
	WHERE CIOD.TrnID = @p_TrnID
GO
--=========================================================================================================================================================
--=========================================================================================================================================================
IF EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TRN_COUNTER_INOUT_GetDtl]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[TRN_COUNTER_INOUT_GetDtl]
GO
CREATE PROCEDURE [dbo].[TRN_COUNTER_INOUT_GetDtl]
	@p_TrnID bigint = -1
AS
	SELECT CIOD.TrnID,
		   CIOD.OrdinalNumber,
	       CIOD.TrnType AS TrnTypeID,
		   CASE WHEN CIOD.TrnType = 1 THEN N'Thu' ELSE N'Chi' END AS TrnTypeName,
	       CIOD.Currency AS CurrencyID,
		   CRC.CurrencyCode,
		   CRC.CurrencyDesc,
	       CIOD.Amount,
	       CIOD.Notes
	FROM TRN_COUNTER_INOUT_DT CIOD
		 LEFT JOIN CAT_CURRENCY CRC ON CRC.ID = CIOD.Currency
	WHERE 1 = 1
		  AND (CIOD.TrnID = @p_TrnID OR @p_TrnID = -1 OR @p_TrnID IS NULL)
GO
--=========================================================================================================================================================
--=========================================================================================================================================================
IF EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TRN_PRODUCT_SELL_PrintBill]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[TRN_PRODUCT_SELL_PrintBill]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[TRN_PRODUCT_SELL_PrintBill]
	@p_TrnID bigint = -1
AS
	SELECT	PRS.TrnID,
			PRS.TrnCode,
			PRS.TrnDate,
			PRS.TrnTime,
			PRS.CustID,
			CUS.CustCode,
			CUS.CustName,
			PRS.CounterID,
			CNT.CounterCode,
			CNT.CounterName,
			PRS.DiscountTrn,
			PRS.DiscountTotal,
			PRS.AmountTotal,
			PRS.AmountPay,
			PRS.UnitPayment,
			CRC.CurrencyCode,
			CRC.CurrencyDesc,
			PRS.Notes,
			PRS.EmpID,
			EMP.EmpCode,
			EMP.EmpName,
			PRS.StatusCode,
			STT.StatusName
	FROM TRN_PRODUCT_SELL PRS
		 LEFT JOIN SYS_STATUS STT ON STT.StatusCode = PRS.StatusCode AND STT.StatusObject = 'TRN_PRODUCT_SELL'
		 LEFT JOIN CAT_EMPLOYEE EMP ON EMP.ID = PRS.EmpID
		 LEFT JOIN CAT_CURRENCY CRC ON CRC.ID = PRS.UnitPayment
		 LEFT JOIN CAT_CUSTOMER CUS ON CUS.ID = PRS.CustID
		 LEFT JOIN CAT_COUNTER CNT ON CNT.ID = PRS.CounterID
	WHERE PRS.TrnID = @p_TrnID	

	SELECT	PRSD.TrnID,
			PRS.TrnCode,
			PRSD.ProductID,
			PRD.ProductCode,
			PRD.ProductDesc,
			PRD.Descriptions,
			PRSD.StallsID AS StallsID,
			STL.StallsCode AS StallsCode,
			STL.StallsName AS StallsName,
			PRD.ProductType AS ProductTypeID,
			PRDT.ProductTypeCode,
			PRDT.ProductTypeName,
			PRD.ProductGroup AS ProductGroupID,
			PRDG.ProductGroupCode,
			PRDG.ProductGroupName,
			PRD.Supplier AS SupplierID,
			SPL.SupplierCode,
			SPL.SupplierName,
			PRSD.ProductWeight,
			PRSD.Quantity,
			PRSD.UnitSell AS UnitSellID,
			USEL.UnitSellCode,
			USEL.UnitSellDesc,
			ISNULL(PRDR.RateIn, 0) AS RateIn,
			ISNULL(PRDR.RateEstimate, 0) AS RateEstimate,
			ISNULL(PRDR.DiscountPercent, 0) AS DiscountPercent,
			ISNULL(PRDR.Discount, 0) AS Discount,
			PRSD.Discount AS DiscountTotal,
			PRSD.Rate AS RateSell,
			PRSD.Amount,
			PRSD.Notes
	FROM TRN_PRODUCT_SELL_DT PRSD
		 LEFT JOIN TRN_PRODUCT_SELL PRS ON PRS.TrnID = PRSD.TrnID
		 LEFT JOIN OBJ_PRODUCT PRD ON PRD.ID = PRSD.ProductID
		 LEFT JOIN CAT_STALLS STL ON STL.ID = PRSD.StallsID
		 LEFT JOIN CAT_UNIT_SELL USEL ON USEL.ID = PRSD.UnitSell
		 LEFT JOIN SYS_PRODUCT_STOCK PRDS ON PRDS.ProductID = PRD.ID
		 LEFT JOIN SYS_PRODUCT_RATE PRDR ON PRDR.ProductID = PRD.ID
		 LEFT JOIN CAT_SUPPLIER SPL ON SPL.ID = PRD.Supplier
		 LEFT JOIN CAT_PRODUCTTYPE PRDT ON PRDT.ID = PRD.ProductType
		 LEFT JOIN CAT_PRODUCTGROUP PRDG ON PRDG.ID = PRD.ProductGroup
	WHERE PRSD.TrnID = @p_TrnID
		  AND (PRDR.IsSellCurrent = 1 OR PRDR.IsSellCurrent IS NULL)
GO
--=========================================================================================================================================================
--=========================================================================================================================================================
IF EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TRN_PRODUCT_SELL_GetCatProduct]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[TRN_PRODUCT_SELL_GetCatProduct]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[TRN_PRODUCT_SELL_GetCatProduct]
AS
	SELECT	PRD.ID AS ProductID,
			PRDC.ID AS ProductCatID,			
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
			STL.ID AS StallsID,
			STL.StallsCode,
			STL.StallsName,
			PRDC.ProductCatImage,
			USL.ID AS UnitSellID,
			USL.UnitSellCode,
			USL.UnitSellDesc,
			UWG.ID AS UnitWeightID,
			UWG.UnitWeightCode,
			UWG.UnitWeightDesc,
			ISNULL(PRDR.RateIn, 0) AS RateIn,
			ISNULL(PRDR.RateEstimate, 0) AS RateEstimate,
			ISNULL(PRDR.DiscountPercent, 0) AS DiscountPercent,
			ISNULL(PRDR.Discount, 0) AS Discount,
			ISNULL(PRDR.DiscountTotal, 0) AS DiscountTotal,
			ISNULL(PRDR.RateSell, 0) AS RateSell,
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
		 LEFT JOIN OBJ_PRODUCT PRD ON PRD.ProductCode = PRDC.ProductCatCode
		 LEFT JOIN CAT_STALLS STL ON STL.ID = 0
		 LEFT JOIN CAT_UNIT_SELL USL ON USL.ID = 0
		 LEFT JOIN CAT_UNIT_WEIGHT UWG ON UWG.ID = 0
		 LEFT JOIN SYS_PRODUCT_RATE PRDR ON PRDR.ProductID = PRD.ID
	WHERE PRDC.IsDelete = 0 
		  AND PRDC.IsActive = 1
		  AND (PRDR.IsSellCurrent = 1 OR PRDR.IsSellCurrent IS NULL)
GO
--=========================================================================================================================================================
--=========================================================================================================================================================
IF EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TRN_PRODUCT_SELL_Complete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[TRN_PRODUCT_SELL_Complete]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[TRN_PRODUCT_SELL_Complete]
	@p_TrnID bigint = -1,
	@p_UpdateBy bigint = -1
AS
SET XACT_ABORT ON;
BEGIN TRANSACTION
	DECLARE @vMessage nvarchar(max)
	SET @vMessage = ''

	DECLARE @vProductID bigint = -1
	DECLARE @vProductWeight numeric(19,8) = 0
	DECLARE @vQuantity int = 0
	DECLARE @vStallsID bigint

	DECLARE pCurProductSellComplete CURSOR FOR SELECT ProductID, ProductWeight, Quantity, StallsID
											  FROM TRN_PRODUCT_SELL_DT WHERE TrnID = @p_TrnID
	OPEN pCurProductSellComplete
	FETCH NEXT FROM pCurProductSellComplete INTO @vProductID, @vProductWeight, @vQuantity, @vStallsID
	WHILE @@FETCH_STATUS = 0
	BEGIN	
			
		DECLARE @vProductType bigint
		SELECT @vProductType = PRD.ProductType FROM CAT_PRODUCT PRD WHERE PRD.ID = @vProductID		
		IF (@vProductType <> 0)
		BEGIN
			-- Thêm vào log hàng hóa
			UPDATE SYS_PRODUCT_LOG
			SET OutTrnID = @p_TrnID,
				OutTrnType = 'SELL',
				OutDateTime = GETDATE(),
				OutQuantity = @vQuantity,
				OutWeights = @vProductWeight
			IF @@Error <> 0 GOTO ABORT

			-- Cập nhật tồn kho	hàng
			UPDATE SYS_PRODUCT_STOCK
			SET Quantity = Quantity - @vQuantity,
				Weights = Weights - @vProductWeight
			WHERE StallsID = @vStallsID AND ProductID = @vProductID
			IF @@Error <> 0 GOTO ABORT

			-- Cập nhật tình trạng món hàng nếu hết tồn (Không xử lý vì món hàng tồn ở nhiều quầy)
			--IF EXISTS (SELECT TOP 1 1 FROM SYS_PRODUCT_STOCK WHERE Quantity = 0 AND QuantityReal = 0 AND Weights = 0 AND WeightsReal = 0)
			--BEGIN
			--	UPDATE OBJ_PRODUCT 
			--	SET StatusCode = 'S',
			--		UpdateDate = GETDATE(),
			--		UpdateBy = @p_UpdateBy
			--	WHERE ID = @vProductID
			--END
			--IF @@Error <> 0 GOTO ABORT
		END		

		FETCH NEXT FROM pCurProductSellComplete INTO @vProductID, @vProductWeight, @vQuantity, @vStallsID
	END
	CLOSE pCurProductSellComplete
	DEALLOCATE pCurProductSellComplete
	IF @@Error <> 0 GOTO ABORT

	-- Cập nhật tồn kho quầy thu ngân
	DECLARE @vCounterID bigint
	DECLARE @vAmountPay numeric(19,8)
	DECLARE @vUnitPayment numeric(19,8)
	SELECT @vCounterID = CounterID, @vAmountPay = AmountPay,@vUnitPayment = UnitPayment FROM TRN_PRODUCT_SELL WHERE TrnID = @p_TrnID

	IF NOT EXISTS (SELECT TOP 1 1 FROM SYS_COUNTER_STOCK WHERE CounterID = @vCounterID AND CurrencyID = @vUnitPayment)
	BEGIN
		INSERT INTO SYS_COUNTER_STOCK(CounterID, CurrencyID, InStock)
		VALUES (@vCounterID, @vUnitPayment, @vAmountPay)
	END
	ELSE
	BEGIN
		UPDATE SYS_COUNTER_STOCK
		SET InStock = InStock + @vAmountPay
		WHERE CounterID = @vCounterID AND CurrencyID = @vUnitPayment
	END	
	IF @@Error <> 0 GOTO ABORT

	-- Cập nhật trạng thái bán hàng
	UPDATE TRN_PRODUCT_SELL 
	SET StatusCode = 'C',
		UpdateBy = @p_UpdateBy,
		UpdateDate = GETDATE()
	WHERE TrnID = @p_TrnID 
	IF @@Error <> 0 GOTO ABORT

COMMIT TRANSACTION
	SELECT 1 AS Result, @vMessage AS MsgProcedure
	RETURN 1
ABORT:
BEGIN
	ROLLBACK TRANSACTION
	IF (SELECT CURSOR_STATUS('global','pCurProductSellComplete')) >= -1
	BEGIN
		IF (SELECT CURSOR_STATUS('global','pCurProductSellComplete')) > -1
		BEGIN
			CLOSE pCur
		END
		DEALLOCATE pCur
	END

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
IF EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SYS_COUNTER_STOCK_GetWithCounter]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[SYS_COUNTER_STOCK_GetWithCounter]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SYS_COUNTER_STOCK_GetWithCounter]
	@p_CounterID bigint = -1
AS
	SELECT	CNTS.CounterID,
			CNT.CounterCode,
			CNT.CounterName,
      		CNTS.CurrencyID,
			CRC.CurrencyCode,
			CRC.CurrencyDesc,
      		CNTS.InStock
	FROM SYS_COUNTER_STOCK CNTS
		 LEFT JOIN CAT_COUNTER CNT ON CNT.ID = CNTS.CounterID
		 LEFT JOIN CAT_CURRENCY CRC ON CRC.ID = CNTS.CurrencyID
	WHERE 1 = 1
		  AND (CounterID = @p_CounterID OR @p_CounterID = -1 OR @p_CounterID IS NULL)
GO
--=========================================================================================================================================================
--=========================================================================================================================================================
IF EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[OBJ_PRODUCT_GetByCodeForSell]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[OBJ_PRODUCT_GetByCodeForSell]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[OBJ_PRODUCT_GetByCodeForSell]
	@p_ProductCode nvarchar(100)
AS
	DECLARE @vMessage nvarchar(max)
	SET @vMessage = ''

	SELECT 1 AS Result, @vMessage AS MsgProcedure

	-- Kiểm tra mã hàng hợp lệ?
	IF NOT EXISTS(SELECT * FROM OBJ_PRODUCT WHERE ProductCode = @p_ProductCode)
	BEGIN
		SET @vMessage = 'Mã hàng không tồn tại'
		GOTO ABORT
	END

	-- Kiểm tra mã hàng còn đủ số lượng tồn?
	DECLARE @vQuatityStock numeric(19,8)
	SELECT @vQuatityStock = (CASE WHEN PRD.ProductType = 1 THEN PRDS.QuantityReal ELSE PRDS.WeightsReal END)
	FROM SYS_PRODUCT_STOCK PRDS
		 LEFT JOIN OBJ_PRODUCT PRD ON PRD.ID = PRDS.ProductID
	WHERE PRD.ProductCode = @p_ProductCode
		  AND PRD.ProductType <> 0 
	IF (@vQuatityStock = 0)
	BEGIN
		SET @vMessage = 'Mã hàng hết số lượng tồn'
		GOTO ABORT
	END	

	SELECT	PRD.ID AS ProductID,	
			PRD.ProductCode,
			PRD.ProductDesc,
			PRD.Descriptions,
			PRD.ProductType AS ProductTypeID,
			PRDT.ProductTypeCode,
			PRDT.ProductTypeName,			
			PRD.ProductGroup AS ProductGroupID,
			PRDG.ProductGroupCode,
			PRDG.ProductGroupName,
			PRD.Supplier AS SupplierID,
			SPL.SupplierCode,
			SPL.SupplierName,
			STL.ID AS StallsID,
			STL.StallsCode,
			STL.StallsName,
			USL.ID AS UnitSellID,
			USL.UnitSellCode,
			USL.UnitSellDesc,
			UWG.ID AS UnitWeightID,
			UWG.UnitWeightCode,
			UWG.UnitWeightDesc,
			ISNULL(PRDR.RateIn, 0) AS RateIn,
			ISNULL(PRDR.RateEstimate, 0) AS RateEstimate,
			ISNULL(PRDR.DiscountPercent, 0) AS DiscountPercent,
			ISNULL(PRDR.Discount, 0) AS Discount,
			ISNULL(PRDR.DiscountTotal, 0) AS DiscountTotal,
			ISNULL(PRDR.RateSell, 0) AS RateRate,
			PRD.UpdateDate,
			PRD.UpdateBy,
			URS.UserName AS UserUpdate,
			PRD.IsDelete
	FROM OBJ_PRODUCT PRD
		 LEFT JOIN SYS_USERS URS ON URS.ID = PRD.UpdateBy
		 LEFT JOIN CAT_SUPPLIER SPL ON SPL.ID = PRD.Supplier
		 LEFT JOIN CAT_PRODUCTTYPE PRDT ON PRDT.ID = PRD.ProductType
		 LEFT JOIN CAT_PRODUCTGROUP PRDG ON PRDG.ID = PRD.ProductGroup
		 LEFT JOIN CAT_STALLS STL ON STL.ID = 0
		 LEFT JOIN CAT_UNIT_SELL USL ON USL.ID = 0
		 LEFT JOIN CAT_UNIT_WEIGHT UWG ON UWG.ID = 0
		 LEFT JOIN SYS_PRODUCT_RATE PRDR ON PRDR.ProductID = PRD.ID
	WHERE PRD.IsDelete = 0 
		  AND (PRDR.IsSellCurrent = 1 OR PRDR.IsSellCurrent IS NULL)
		  AND PRD.ProductCode = @p_ProductCode
	
	RETURN 1
ABORT:
BEGIN
	SELECT 0 AS Result, @vMessage AS MsgProcedure
	RETURN 0
END
GO
--=========================================================================================================================================================
--=========================================================================================================================================================
IF EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[OBJ_PRODUCT_UpdateRate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[OBJ_PRODUCT_UpdateRate]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[OBJ_PRODUCT_UpdateRate]
	@p_ProductID bigint = -1,
	@p_RateEstimate numeric(19,8) = 0,
	@p_DiscountPercent numeric(19,8) = 0,
	@p_Discount numeric(19,8) = 0,
	@p_DiscountTotal numeric(19,8) = 0,
	@p_RateSell numeric(19,8) = 0
AS
SET XACT_ABORT ON;
BEGIN TRANSACTION
	DECLARE @vMessage nvarchar(max)
	SET @vMessage = ''

	-- Lấy thông tin cập nhật
	DECLARE @vRateIn numeric(19,8)
	SELECT @vRateIn = RateIn FROM SYS_PRODUCT_RATE WHERE ProductID = @p_ProductID AND IsSellCurrent = 1

	-- Bỏ đánh dấu giá hiện tại
	UPDATE SYS_PRODUCT_RATE SET IsSellCurrent = 0 WHERE ProductID = @p_ProductID AND IsSellCurrent = 1

	-- Cập nhật giá
	INSERT INTO SYS_PRODUCT_RATE (ProductID,
								  RateDate,
								  RateIn,
								  RateEstimate,
								  DiscountPercent,
								  Discount,
								  DiscountTotal,
								  RateSell,
								  IsSellCurrent)
	VALUES ( @p_ProductID,
			 GETDATE(),
			 @vRateIn,
			 @p_RateEstimate,
			 @p_DiscountPercent,
			 @p_Discount,
			 @p_DiscountTotal,
			 @p_RateSell,
			 1)
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
IF EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[OBJ_PRODUCT_QueryTransaction]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[OBJ_PRODUCT_QueryTransaction]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[OBJ_PRODUCT_QueryTransaction]
      @p_TrnCode varchar(15) = '',
      @p_TrnDateFrom varchar(10) = '',
	  @p_TrnDateTo varchar(10) = '',
      @p_CustID bigint = -1,
      @p_EmpID bigint = -1,
      @p_StatusCode varchar(5) = ''	
AS
	-- Giao dịch bán hàng
	SELECT	PRDS.TrnID,
			SUM(CASE WHEN PRD.ProductType = 2 THEN PRDS.ProductWeight ELSE PRDS.Quantity END) AS QuantitySell
	INTO #tmpPRDS
	FROM TRN_PRODUCT_SELL_DT PRDS
		 LEFT JOIN OBJ_PRODUCT PRD ON PRD.ID = PRDS.ProductID
		 LEFT JOIN CAT_PRODUCTTYPE PRDT ON PRDT.ID = PRD.ProductType
	GROUP BY PRDS.TrnID

	SELECT	PRS.TrnID,
			PRS.TrnCode,
			PRS.TrnDate,
			PRS.TrnTime,
			PRS.CustID,
			CUS.CustCode,
			CUS.CustName,
			PRS.CounterID,
			CNT.CounterCode,
			CNT.CounterName,
			PRS.DiscountTrn,
			PRS.DiscountTotal,
			PRS.AmountTotal,
			PRS.AmountPay,
			PRS.UnitPayment,
			CRC.CurrencyCode,
			CRC.CurrencyDesc,
			PRS.Notes,
			PRS.EmpID,
			EMP.EmpCode,
			EMP.EmpName,
			PRS.StatusCode,
			STT.StatusName,
			#tmpPRDS.QuantitySell 
	FROM TRN_PRODUCT_SELL PRS
		 LEFT JOIN SYS_STATUS STT ON STT.StatusCode = PRS.StatusCode AND STT.StatusObject = 'TRN_PRODUCT_SELL'
		 LEFT JOIN CAT_EMPLOYEE EMP ON EMP.ID = PRS.EmpID
		 LEFT JOIN CAT_CURRENCY CRC ON CRC.ID = PRS.UnitPayment
		 LEFT JOIN CAT_CUSTOMER CUS ON CUS.ID = PRS.CustID
		 LEFT JOIN CAT_COUNTER CNT ON CNT.ID = PRS.CounterID
		 LEFT JOIN #tmpPRDS ON #tmpPRDS.TrnID = PRS.TrnID
	WHERE PRS.IsDelete = 0
		  AND (PRS.TrnCode LIKE N'%' + @p_TrnCode + '%' OR @p_TrnCode = '' OR @p_TrnCode IS NULL)
		  AND (PRS.TrnDate >= CONVERT(date, @p_TrnDateFrom, 103) OR @p_TrnDateFrom = '' OR @p_TrnDateFrom IS NULL)
		  AND (PRS.TrnDate <= CONVERT(date, @p_TrnDateTo, 103) OR @p_TrnDateTo = '' OR @p_TrnDateTo IS NULL)
		  AND (PRS.CustID = @p_CustID OR @p_CustID = -1 OR @p_CustID IS NULL)
		  AND (PRS.EmpID = @p_EmpID OR @p_EmpID = -1 OR @p_EmpID IS NULL)
		  AND (PRS.StatusCode = @p_StatusCode OR @p_StatusCode = '' OR @p_StatusCode IS NULL)	

	-- Giao dịch xuất hàng
	SELECT	PROD.TrnID,
			SUM(PROD.Quantity) AS QuantityOut
	INTO #tmpPROD
	FROM TRN_PRODUCT_OUT_DT PROD
	GROUP BY PROD.TrnID

	SELECT PRO.TrnID,
	       PRO.TrnCode,
	       PRO.TrnDate,
	       PRO.TrnTime,
		   PRO.StallsID,
		   STL.StallsCode,
		   STL.StallsName,
		   STL.ShopID,
		   SHP.ShopCode,
		   SHP.ShopName,
	       PRO.Notes,
	       PRO.EmpID,
		   EMP.EmpCode,
		   EMP.EmpName,
	       PRO.StatusCode,
		   STT.StatusName,
		   #tmpPROD.QuantityOut
	FROM TRN_PRODUCT_OUT PRO
		 LEFT JOIN SYS_STATUS STT ON STT.StatusCode = PRO.StatusCode AND STT.StatusObject = 'TRN_PRODUCT_OUT'
		 LEFT JOIN CAT_EMPLOYEE EMP ON EMP.ID = PRO.EmpID
		 LEFT JOIN CAT_STALLS STL ON STL.ID = PRO.StallsID
		 LEFT JOIN CAT_SHOP SHP ON SHP.ID = STL.ShopID
		 LEFT JOIN #tmpPROD ON #tmpPROD.TrnID = PRO.TrnID
	WHERE PRO.IsDelete = 0
		  AND (PRO.TrnCode LIKE N'%' + @p_TrnCode + '%' OR @p_TrnCode = '' OR @p_TrnCode IS NULL)
		  AND (PRO.TrnDate >= CONVERT(date, @p_TrnDateFrom, 103) OR @p_TrnDateFrom = '' OR @p_TrnDateFrom IS NULL)
		  AND (PRO.TrnDate <= CONVERT(date, @p_TrnDateTo, 103) OR @p_TrnDateTo = '' OR @p_TrnDateTo IS NULL)
		  AND (PRO.EmpID = @p_EmpID OR @p_EmpID = -1 OR @p_EmpID IS NULL)
		  AND (PRO.StatusCode = @p_StatusCode OR @p_StatusCode = '' OR @p_StatusCode IS NULL)
GO
--=========================================================================================================================================================
--=========================================================================================================================================================
IF EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[OBJ_PRODUCT_GetStock]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[OBJ_PRODUCT_GetStock]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[OBJ_PRODUCT_GetStock]
	@p_StallsID bigint = -1,
	@p_StatusCode varchar(5) = ''
AS
	SELECT  PRD.ID AS ProductID,
			PRD.ProductCode,
			PRD.ProductDesc,
			PRD.Descriptions,
			PRD.ProductType AS ProductTypeID,
			PRDT.ProductTypeCode,
			PRDT.ProductTypeName,
			PRD.ProductGroup AS ProductGroupID,
			PRDG.ProductGroupCode,
			PRDG.ProductGroupName,
			PRD.UnitWeight AS UnitWeightID,
			UWGH.UnitWeightCode,
			UWGH.UnitWeightDesc,
			PRD.UnitSell AS UnitSellID,
			USEL.UnitSellCode,
			USEL.UnitSellDesc,
			PRD.Supplier AS SupplierID,
			SPL.SupplierCode,
			SPL.SupplierName,
			PRD.StatusCode,
			STT.StatusName,
			ISNULL(PRDS.StallsID, -1) AS StallsID,
			ISNULL(STL.StallsCode, '') AS StallsCode,
			ISNULL(STL.StallsName, '') AS StallsName,
			ISNULL(PRDS.Quantity, 0) AS Quantity,
			ISNULL(PRDS.QuantityReal, 0) AS QuantityReal,
			ISNULL(PRDS.Weights, 0) AS Weights,
			ISNULL(PRDS.WeightsReal, 0) AS WeightsReal,
			ISNULL(PRDR.RateIn, 0) AS RateIn,
			ISNULL(PRDR.RateEstimate, 0) AS RateEstimate,
			ISNULL(PRDR.DiscountPercent, 0) AS DiscountPercent,
			ISNULL(PRDR.Discount, 0) AS Discount,
			ISNULL(PRDR.DiscountTotal, 0) AS DiscountTotal,
			ISNULL(PRDR.RateSell, 0) AS RateSell,
			PRD.UpdateDate,
			PRD.UpdateBy,
			URS.UserName AS UserUpdate
	FROM OBJ_PRODUCT PRD
		 LEFT JOIN SYS_USERS URS ON URS.ID = PRD.UpdateBy
		 LEFT JOIN CAT_PRODUCTTYPE PRDT ON PRDT.ID = PRD.ProductType
		 LEFT JOIN CAT_PRODUCTGROUP PRDG ON PRDG.ID = PRD.ProductGroup
		 LEFT JOIN CAT_UNIT_WEIGHT UWGH ON UWGH.ID = PRD.UnitWeight
		 LEFT JOIN CAT_UNIT_SELL USEL ON USEL.ID = PRD.UnitSell
		 LEFT JOIN CAT_SUPPLIER SPL ON SPL.ID = PRD.Supplier
		 LEFT JOIN SYS_STATUS STT ON STT.StatusCode = PRD.StatusCode 
		 LEFT JOIN SYS_PRODUCT_STOCK PRDS ON PRDS.ProductID = PRD.ID
		 LEFT JOIN CAT_STALLS STL ON STL.ID = PRDS.StallsID
		 LEFT JOIN SYS_PRODUCT_RATE PRDR ON PRDR.ProductID = PRD.ID
	WHERE PRD.IsDelete = 0		
		  AND STT.StatusObject = 'OBJ_PRODUCT'  
		  AND (PRDR.IsSellCurrent = 1 OR PRDR.IsSellCurrent IS NULL)
		  AND (PRDS.StallsID = @p_StallsID OR @p_StallsID IS NULL OR @p_StallsID = -1)
		  AND (PRD.StatusCode = @p_StatusCode OR @p_StatusCode IS NULL OR @p_StatusCode = '')
GO
--=========================================================================================================================================================
--=========================================================================================================================================================
IF EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[OBJ_PRODUCT_GetAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[OBJ_PRODUCT_GetAll]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[OBJ_PRODUCT_GetAll]
AS
	SELECT PRD.ID,
       PRD.ProductCode,
       PRD.ProductDesc,
       PRD.Descriptions,
       PRD.ProductType AS ProductTypeID,
	   PRDT.ProductTypeCode,
	   PRDT.ProductTypeName,
       PRD.ProductGroup AS ProductGroupID,
	   PRDG.ProductGroupCode,
	   PRDG.ProductGroupName,
       PRD.UnitWeight AS UnitWeightID,
	   UWGH.UnitWeightCode,
	   UWGH.UnitWeightDesc,
       PRD.UnitSell AS UnitSellID,
	   USEL.UnitSellCode,
	   USEL.UnitSellDesc,
       PRD.Supplier AS SupplierID,
	   SPL.SupplierCode,
	   SPL.SupplierName,
       PRD.StatusCode,
	   STT.StatusName,
       PRD.UpdateDate,
       PRD.UpdateBy,
	   URS.UserName AS UserUpdate,
       PRD.IsDelete
	FROM OBJ_PRODUCT PRD
		 LEFT JOIN SYS_USERS URS ON URS.ID = PRD.UpdateBy
		 LEFT JOIN CAT_PRODUCTTYPE PRDT ON PRDT.ID = PRD.ProductType
		 LEFT JOIN CAT_PRODUCTGROUP PRDG ON PRDG.ID = PRD.ProductGroup
		 LEFT JOIN CAT_UNIT_WEIGHT UWGH ON UWGH.ID = PRD.UnitWeight
		 LEFT JOIN CAT_UNIT_SELL USEL ON USEL.ID = PRD.UnitSell
		 LEFT JOIN CAT_SUPPLIER SPL ON SPL.ID = PRD.Supplier
		 LEFT JOIN SYS_STATUS STT ON STT.StatusCode = PRD.StatusCode AND STT.StatusObject = 'OBJ_PRODUCT'
	WHERE PRD.IsDelete = 0
GO