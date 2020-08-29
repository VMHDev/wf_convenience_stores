IF EXISTS(SELECT * FROM SYS.DATABASES WHERE NAME = 'PTTKPMCRM')
BEGIN
	USE PTTKPMCRM
END
GO
--=========================================================================================================================================================
--=========================================================================================================================================================
IF EXISTS (SELECT * FROM  sys.objects WHERE  object_id = OBJECT_ID(N'[dbo].[fn_GenCode]') AND type IN ( N'FN', N'IF', N'TF', N'FS', N'FT' ))
DROP FUNCTION [dbo].[fn_GenCode]
GO
CREATE FUNCTION [dbo].[fn_GenCode]
(    
      @pTableName varchar(100),
      @pID bigint
)
RETURNS varchar(max)
AS
BEGIN
	DECLARE @vCodeGen varchar(max)
	SET @vCodeGen = ''
	IF @pTableName = 'OBJ_PRODUCT'
	BEGIN
		RETURN @vCodeGen
	END

	DECLARE @vPrefix varchar(15)
	DECLARE @vLengthCode int
	DECLARE @vFormatCode varchar(max)
	
	SELECT @vPrefix = Prefix, @vLengthCode = LengthCode, @vFormatCode = FormatCode FROM SYS_GENCODE WHERE TableName = @pTableName

	IF(@vLengthCode = 0)
	BEGIN -- TH 1: 'SP1,SP2, ... SP10, SP11, ..., SP100, SP101, ...
		SET @vCodeGen = @vPrefix + CAST(@pID as varchar(max))
	END
	ELSE
	BEGIN
		DECLARE @vCharReplace nvarchar(50) -- Nếu LengthCode > 100 thì phải bổ sung thêm kí tự 0 cho chuỗi
		SET @vCharReplace = '0000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000'
		DECLARE @vCurValueLen int
		SET @vCurValueLen = LEN(CAST(@pID AS varchar(max)))
	
		IF(@vFormatCode = '')
		BEGIN -- TH 2: SP-00000001,SP-00000002, ... SP-00000010, SP-00000011, ..., SP-00000100, SP-00000101, ...
			SET @vCodeGen = @vPrefix + LEFT(@vCharReplace, @vLengthCode - @vCurValueLen) + CAST(@pID AS varchar(max))
		END
	END
	RETURN @vCodeGen
END
GO
--=========================================================================================================================================================
--=========================================================================================================================================================
IF EXISTS (SELECT * FROM  sys.objects WHERE  object_id = OBJECT_ID(N'[dbo].[fn_GenCodeProduct]') AND type IN ( N'FN', N'IF', N'TF', N'FS', N'FT' ))
DROP FUNCTION [dbo].[fn_GenCodeProduct]
GO
CREATE FUNCTION [dbo].[fn_GenCodeProduct]
(    
      @pTableName varchar(100),
      @pID bigint,
	  @pIDProductType bigint,
	  @pIDProductGroup bigint
)
RETURNS varchar(max)
AS
BEGIN
	DECLARE @vCodeGen varchar(max)
	SET @vCodeGen = ''
	IF @pTableName <> 'OBJ_PRODUCT'
	BEGIN
		RETURN @vCodeGen
	END
		
	DECLARE @vPrefix varchar(15)
	DECLARE @vLengthCode int
	DECLARE @vFormatCode varchar(max)
	SELECT @vPrefix = Prefix, @vLengthCode = LengthCode, @vFormatCode = FormatCode FROM SYS_GENCODE WHERE TableName = @pTableName

	DECLARE @vCharReplace nvarchar(50) -- Nếu LengthCode > 100 thì phải bổ sung thêm kí tự 0 cho chuỗi
	SET @vCharReplace = '0000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000'
	DECLARE @vCurValueLen int
	SET @vCurValueLen = LEN(CAST(@pID AS varchar(max)))
	
	-- TH 3: PR-PT1-PG1-0001, PR-PT1-PG1-0002, ... PR-PT1-PG1-0010, PR-PT1-PG1-0011, ..., PR-PT1-PG1-0100, PR-PT1-PG1-0101  ...
	DECLARE @vFindStr varchar(max)
	DECLARE @vFindIdx int
	DECLARE @vCode varchar(15)
	
	SET @vFindStr = '<CAT_PRODUCTGROUP>'
	SET @vFindIdx = CHARINDEX(@vFindStr, @vFormatCode)
	IF(@vFindIdx != 0)
	BEGIN
		SELECT @vCode = PRDG.ProductGroupCode 
		FROM CAT_PRODUCTGROUP PRDG
		WHERE PRDG.ID = @pIDProductGroup
		SET @vFormatCode = REPLACE(@vFormatCode, @vFindStr, @vCode)
	END
	
	SET @vFindStr = '<CAT_PRODUCTTYPE>'
	SET @vFindIdx = CHARINDEX(@vFindStr, @vFormatCode)
	IF(@vFindIdx != 0)
	BEGIN
		SELECT @vCode =  PRDT.ProductTypeCode
		FROM CAT_PRODUCTTYPE PRDT
		WHERE PRDT.ID = @pIDProductType
		SET @vFormatCode = REPLACE(@vFormatCode, @vFindStr, @vCode)
	END
	
	SET @vCodeGen = @vPrefix + @vFormatCode + LEFT(@vCharReplace, @vLengthCode - @vCurValueLen) + CAST(@pID AS varchar(max))

	RETURN @vCodeGen
END
GO