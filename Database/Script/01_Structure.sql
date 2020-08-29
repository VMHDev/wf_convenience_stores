IF EXISTS(SELECT * FROM SYS.DATABASES WHERE NAME = 'PTTKPMCRM')
BEGIN
	USE master
	DROP DATABASE PTTKPMCRM
END
GO
--=========================================================================================================================================================
USE master
IF NOT EXISTS(SELECT * FROM SYS.DATABASES WHERE NAME = 'PTTKPMCRM')
BEGIN
	CREATE DATABASE PTTKPMCRM
END
GO
IF EXISTS(SELECT * FROM SYS.DATABASES WHERE NAME = 'PTTKPMCRM')
BEGIN
	USE PTTKPMCRM
END
GO
--#########################################################################################################################################################
--=========================================================================================================================================================
--=========================================================================================================================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Cửa hàng
IF NOT EXISTS (SELECT TOP 1 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'CAT_SHOP')
BEGIN
CREATE TABLE [dbo].[CAT_SHOP](
	[ID] [bigint] IDENTITY(0,1) NOT NULL,
	[ShopCode] [varchar](15) NOT NULL,
	[ShopName] [nvarchar](max) NULL,
	[ShopAddress] [nvarchar](max) NULL,
	[ShopTel] [varchar](100) NULL,
	[ShopFax] [varchar](100) NULL,
	[ShopTax] [varchar](100) NULL,
	[ShopWebsite] [varchar](200) NULL,
	[OrderBy] [bigint] NULL,
	[IsActive] [bit] NULL,
	[UpdateDate] [datetime] NOT NULL,
	[UpdateBy] [bigint] NULL,
	[IsDelete] [bit] NULL,
 CONSTRAINT [PK_CAT_SHOP] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
--=========================================================================================================================================================
--=========================================================================================================================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Người dùng
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SYS_USERS]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[SYS_USERS](
	[ID] [bigint] IDENTITY(0,1) NOT NULL,
	[UserName] [nvarchar](255) NOT NULL,
	[Password] [varchar](255) NOT NULL,
	[ShopID] [bigint] NULL,
	[IsAdmin] [bit] NULL,
	[OrderBy] [bigint] NULL,
	[IsActive] [bit] NULL,
	[UpdateDate] [datetime] NOT NULL,
	[UpdateBy] [bigint] NULL,
	[IsDelete] [bit] NULL,
CONSTRAINT [PK_SYS_USERS] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
--=========================================================================================================================================================
--=========================================================================================================================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Nhà cung cấp
IF NOT EXISTS (SELECT TOP 1 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'CAT_SUPPLIER')
BEGIN
CREATE TABLE [dbo].[CAT_SUPPLIER](
	[ID] [bigint] IDENTITY(0,1) NOT NULL,
	[SupplierCode] [varchar](15) NULL,
	[SupplierName] [nvarchar](500) NULL,
	[SupplierAddress] [nvarchar](500) NULL,
	[Phone] [varchar](15) NULL,
	[OrderBy] [bigint] NULL,
	[IsActive] [bit] NULL,
	[UpdateDate] [datetime] NOT NULL,
	[UpdateBy] [bigint] NOT NULL,
	[IsDelete] [bit] NULL,
 CONSTRAINT [PK_CAT_SUPPLIER] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
--=========================================================================================================================================================
--=========================================================================================================================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Loại tiền tệ
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CAT_CURRENCY]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[CAT_CURRENCY](
	[ID] [bigint] IDENTITY(0,1) NOT NULL,
	[CurrencyCode] [varchar](15) NULL,
	[CurrencyDesc] [nvarchar](500) NULL,
	[OrderBy] [bigint] NULL,
	[IsActive] [bit] NULL,
	[UpdateDate] [datetime] NOT NULL,
	[UpdateBy] [bigint] NOT NULL,
	[IsDelete] [bit] NULL,
 CONSTRAINT [PK_CAT_CURRENCY] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
--=========================================================================================================================================================
--=========================================================================================================================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Quầy thu ngân
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CAT_COUNTER]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[CAT_COUNTER](
	[ID] [bigint] IDENTITY(0,1) NOT NULL,
	[CounterCode] [varchar](15) NULL,
	[CounterName] [nvarchar](500) NULL,
	[StatusCode] [varchar](15) NULL,
	[ShopID] [bigint] NULL,
	[OrderBy] [bigint] NULL,
	[IsActive] [bit] NULL,
	[UpdateDate] [datetime] NOT NULL,
	[UpdateBy] [bigint] NOT NULL,
	[IsDelete] [bit] NULL,
 CONSTRAINT [PK_CAT_COUNTER] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
--=========================================================================================================================================================
--=========================================================================================================================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Nhân viên
IF NOT EXISTS (SELECT TOP 1 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'CAT_EMPLOYEE')
BEGIN
CREATE TABLE [dbo].[CAT_EMPLOYEE](
	[ID] [bigint] IDENTITY(0,1) NOT NULL,
	[EmpCode] [varchar](15) NULL,
	[EmpName] [nvarchar](500) NULL,
	[UserID] [bigint] NULL,
	[ShopID] [bigint] NULL,
	[OrderBy] [bigint] NULL,
	[IsActive] [bit] NULL,
	[UpdateDate] [datetime] NOT NULL,
	[UpdateBy] [bigint] NOT NULL,
	[IsDelete] [bit] NULL,
 CONSTRAINT [PK_CAT_EMPLOYEE] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
--=========================================================================================================================================================
--=========================================================================================================================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Nhóm khách hàng
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CAT_CUSTOMERGROUP]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[CAT_CUSTOMERGROUP](
	[ID] [bigint] IDENTITY(0,1) NOT NULL,
	[CustGroupCode] [varchar](15) NOT NULL,
	[CustGroupName] [nvarchar](500) NULL,
	[Notes] [nvarchar](max) NULL,
	[OrderBy] [bigint] NULL,
	[IsActive] [bit] NULL,
	[UpdateDate] [datetime] NOT NULL,
	[UpdateBy] [bigint] NOT NULL,
	[IsDelete] [bit] NULL,
 CONSTRAINT [PK_CAT_CUSTOMERGROUP] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
--=========================================================================================================================================================
--=========================================================================================================================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Loại khách hàng
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CAT_CUSTOMERTYPE]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[CAT_CUSTOMERTYPE](
	[ID] [bigint] IDENTITY(0,1) NOT NULL,
	[CustTypeCode] [varchar](15) NOT NULL,
	[CustTypeName] [nvarchar](500) NULL,
	[Notes] [nvarchar](1000) NULL,
	[OrderBy] [bigint] NULL,
	[IsActive] [bit] NULL,
	[UpdateDate] [datetime] NOT NULL,
	[UpdateBy] [bigint] NOT NULL,
	[IsDelete] [bit] NULL,
 CONSTRAINT [PK_CAT_CUSTOMERTYPE] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
--=========================================================================================================================================================
--=========================================================================================================================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Nhóm hàng
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CAT_PRODUCTGROUP]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[CAT_PRODUCTGROUP](
	[ID] [bigint] IDENTITY(0,1) NOT NULL,
	[ProductGroupCode] [varchar](15) NULL,
	[ProductGroupName] [nvarchar](300) NULL,
	[Descriptions] [nvarchar](max) NULL,
	[OrderBy] [bigint] NULL,
	[IsActive] [bit] NULL,
	[UpdateDate] [datetime] NOT NULL,
	[UpdateBy] [bigint] NOT NULL,
	[IsDelete] [bit] NULL,
 CONSTRAINT [PK_CAT_PRODUCTGROUP] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
--=========================================================================================================================================================
--=========================================================================================================================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Loại hàng
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CAT_PRODUCTTYPE]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[CAT_PRODUCTTYPE](
	[ID] [bigint] IDENTITY(0,1) NOT NULL,
	[ProductTypeCode] [varchar](15) NOT NULL,
	[ProductTypeName] [nvarchar](100) NULL,
	[Descriptions] [nvarchar](max) NULL,
	[OrderBy] [bigint] NULL,
	[IsActive] [bit] NULL,
	[UpdateDate] [datetime] NOT NULL,
	[UpdateBy] [bigint] NOT NULL,
	[IsDelete] [bit] NULL,
 CONSTRAINT [PK_CAT_PRODUCTTYPE] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
--=========================================================================================================================================================
--=========================================================================================================================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Quầy hàng
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CAT_STALLS]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[CAT_STALLS](
	[ID] [bigint] IDENTITY(0,1) NOT NULL,
	[StallsCode] [varchar](15) NULL,
	[StallsName] [nvarchar](500) NULL,
	[ShopID] [bigint] NULL,
	[OrderBy] [bigint] NULL,
	[IsActive] [bit] NULL,
	[UpdateDate] [datetime] NOT NULL,
	[UpdateBy] [bigint] NOT NULL,
	[IsDelete] [bit] NULL,
 CONSTRAINT [PK_CAT_STALLS] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
--=========================================================================================================================================================
--=========================================================================================================================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Khách hàng
IF NOT EXISTS (SELECT TOP 1 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'CAT_CUSTOMER')
BEGIN
CREATE TABLE [dbo].[CAT_CUSTOMER](
	[ID] [bigint] IDENTITY(0,1) NOT NULL,
	[CustCode] [varchar](15) NULL,
	[CustName] [nvarchar](500) NULL,
	[CustAddress] [nvarchar](max) NULL,
	[Phone] [varchar](30) NULL,
	[Notes] [nvarchar](max) NULL,
	[IdentificationCard] [varchar](20) NULL,
	[BirthDate] [datetime] NOT NULL,
	[Gender] [bit] NULL,
	[Email] [varchar](128) NULL,
	[CustGroupID] [bigint] NULL,
	[CustTypeID] [bigint] NULL,
	[OrderBy] [bigint] NULL,
	[IsActive] [bit] NULL,
	[UpdateDate] [datetime] NOT NULL,
	[UpdateBy] [bigint] NOT NULL,
	[IsDelete] [bit] NULL,
 CONSTRAINT [PK_CAT_CUSTOMER] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
--=========================================================================================================================================================
--=========================================================================================================================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Đơn vị bán - Cũng chính là đơn vị lưu trữ tồn kho
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CAT_UNIT_SELL]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[CAT_UNIT_SELL](
	[ID] [bigint] IDENTITY(0,1) NOT NULL,
	[UnitSellCode] [varchar](15) NULL,
	[UnitSellDesc] [nvarchar](500) NULL,
	[OrderBy] [bigint] NULL,
	[IsActive] [bit] NULL,
	[UpdateDate] [datetime] NOT NULL,
	[UpdateBy] [bigint] NOT NULL,
	[IsDelete] [bit] NULL,
 CONSTRAINT [PK_CAT_UNIT_SELL] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
--=========================================================================================================================================================
--=========================================================================================================================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--Đơn vị trọng lượng
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CAT_UNIT_WEIGHT]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[CAT_UNIT_WEIGHT](
	[ID] [bigint] IDENTITY(0,1) NOT NULL,
	[UnitWeightCode] [varchar](15) NULL,
	[UnitWeightDesc] [nvarchar](500) NULL,
	[OrderBy] [bigint] NULL,
	[IsActive] [bit] NULL,
	[UpdateDate] [datetime] NOT NULL,
	[UpdateBy] [bigint] NOT NULL,
	[IsDelete] [bit] NULL,
 CONSTRAINT [PK_CAT_UNIT_WEIGHT] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
--=========================================================================================================================================================
--=========================================================================================================================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Đơn vị nhập
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CAT_UNIT_IN]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[CAT_UNIT_IN](
	[ID] [bigint] IDENTITY(0,1) NOT NULL,
	[UnitInCode] [varchar](15) NULL,     -- Mã đơn vị nhập
	[UnitInDesc] [nvarchar](500) NULL,   -- Tên đơn vị nhập
	[ScaleChange] [numeric](19,8) NULL,  -- Tỷ lệ quy đổi giữa đơn vị nhập và đơn vị bán/lưu kho
	[OrderBy] [bigint] NULL,
	[IsActive] [bit] NULL,
	[UpdateDate] [datetime] NOT NULL,
	[UpdateBy] [bigint] NOT NULL,
	[IsDelete] [bit] NULL,
 CONSTRAINT [PK_CAT_UNIT_IN] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
--=========================================================================================================================================================
--=========================================================================================================================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Danh mục hàng hóa
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CAT_PRODUCT]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[CAT_PRODUCT](
	[ID] [bigint] IDENTITY(0,1) NOT NULL,
	[ProductCatCode] [varchar](15) NULL,
	[ProductCatName] [nvarchar](300) NULL,
	[Descriptions] [nvarchar](max) NULL,
	[ProductType] [bigint] NULL,
	[ProductGroup] [bigint] NULL,
	[Supplier] [bigint] NULL,
	[ProductCatImage] [image] NULL,
	[OrderBy] [bigint] NULL,
	[IsActive] [bit] NULL,
	[UpdateDate] [datetime] NOT NULL,
	[UpdateBy] [bigint] NOT NULL,
	[IsDelete] [bit] NULL,
 CONSTRAINT [PK_CAT_PRODUCT] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
--=========================================================================================================================================================
--=========================================================================================================================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Nhóm người sử dụng
IF NOT EXISTS (SELECT TOP 1 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'CAT_USERGROUP')
BEGIN
CREATE TABLE [dbo].[CAT_USERGROUP](
	[ID] [bigint] IDENTITY(0,1) NOT NULL,
	[GroupCode] [varchar](15) NULL,
	[GroupName] [nvarchar](500) NULL,
	[Descriptions] [nvarchar](max) NULL,
	[IsAdmin] [bit] NULL,
	[OrderBy] [bigint] NULL,
	[IsActive] [bit] NULL,
	[UpdateDate] [datetime] NOT NULL,
	[UpdateBy] [bigint] NOT NULL,
	[IsDelete] [bit] NULL,
 CONSTRAINT [PK_CAT_USERGROUP] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
--=========================================================================================================================================================
--=========================================================================================================================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Map giữa Người sử dụng và Nhóm người sử dụng
IF NOT EXISTS (SELECT TOP 1 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'MAP_USER_USERGROUP')
BEGIN
CREATE TABLE [dbo].[MAP_USER_USERGROUP](
	[GroupID] [bigint] NOT NULL,
	[UserID] [bigint] NOT NULL
 CONSTRAINT [PK_MAP_USER_USERGROUP] PRIMARY KEY CLUSTERED 
(
	[GroupID] ASC,
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
--=========================================================================================================================================================
--=========================================================================================================================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--Bảng tạo mã:
IF NOT EXISTS (SELECT TOP 1 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME='SYS_GENCODE')
BEGIN
	CREATE TABLE [dbo].[SYS_GENCODE](
		[TableName] [varchar](100) NOT NULL,  -- Tên của bảng cần gen mã
		[Prefix] [varchar](15) NOT NULL,      -- Tiền tố của mã (Mỗi bảng có 1 tiền tố khác nhau)
		[LengthCode] [int] NOT NULL,          -- Chiều dài của mã (Không bao gồm prefix, Code của danh mục)
		[FormatCode] [varchar](max) NOT NULL, -- Định dạng chuỗi gen mã với danh mục
		[Descriptions] [nvarchar](max) NULL,  -- Mô tả
	 CONSTRAINT [PK_SYS_GENCODE] PRIMARY KEY CLUSTERED 
	(
		[TableName] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]
END
GO
--=========================================================================================================================================================
--=========================================================================================================================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--Bảng tạo mã:
IF NOT EXISTS (SELECT TOP 1 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME='SYS_GENCODE_AUTOINCREMENT')
BEGIN
	CREATE TABLE [dbo].[SYS_GENCODE_AUTOINCREMENT](
		[TableName] [varchar](100) NOT NULL,	-- Tên của bảng cần gen mã
		[CurrentID] bigint NULL,				-- ID tự tăng hiện tại
	 CONSTRAINT [PK_SYS_GENCODE_AUTOINCREMENT] PRIMARY KEY CLUSTERED 
	(
		[TableName] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]
END
GO
--=========================================================================================================================================================
--=========================================================================================================================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--Bảng tạo mã:
IF NOT EXISTS (SELECT TOP 1 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME='SYS_GENCODE')
BEGIN
	CREATE TABLE [dbo].[SYS_GENCODE](
		[TableName] [varchar](100) NOT NULL,  -- Tên của bảng cần gen mã
		[Prefix] [varchar](15) NOT NULL,      -- Tiền tố của mã (Mỗi bảng có 1 tiền tố khác nhau)
		[LengthCode] [int] NOT NULL,          -- Chiều dài của mã (Không bao gồm prefix, Code của danh mục)
		[FormatCode] [varchar](max) NOT NULL, -- Định dạng chuỗi gen mã với danh mục
		[Descriptions] [nvarchar](max) NULL,  -- Mô tả
	 CONSTRAINT [PK_SYS_GENCODE] PRIMARY KEY CLUSTERED 
	(
		[TableName] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]
END
GO
--=========================================================================================================================================================
--=========================================================================================================================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Danh sách các menu trên phần mềm (Dùng để phân quyền)
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SYS_MENUS]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[SYS_MENUS](
	[MenuCode] [varchar](100) NOT NULL,
	[MenuDesc] [nvarchar](max) NULL,
	[MenuParent] [varchar](100) NULL,
	[FormName] [varchar](200) NULL,
	[OrderBy] [int] NULL,
	[IsActive] [bit] NULL,
 CONSTRAINT [PK_SYS_MENUS] PRIMARY KEY CLUSTERED 
(
	[MenuCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
--=========================================================================================================================================================
--=========================================================================================================================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Phân quyền người dùng
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SYS_RIGHTS]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[SYS_RIGHTS](
	[MenuCode] [varchar](100) NOT NULL,
	[GroupID] [bigint] NOT NULL,
	[AccessRights] [tinyint] NOT NULL,
 CONSTRAINT [PK_SYS_RIGHTS] PRIMARY KEY CLUSTERED 
(
	[MenuCode] ASC,
	[GroupID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
--=========================================================================================================================================================
--=========================================================================================================================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SYS_STATUS]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[SYS_STATUS](
	[StatusObject] [varchar](100) NOT NULL,
	[StatusCode] [varchar](5) NOT NULL,
	[StatusName] [nvarchar](500) NULL,
	[Notes] [nvarchar](max) NULL,
	[IsActive] [bit] NULL,
 CONSTRAINT [PK_SYS_STATUS] PRIMARY KEY CLUSTERED 
(
	[StatusObject] ASC,
	[StatusCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
--=========================================================================================================================================================
--=========================================================================================================================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Hàng hóa
IF NOT EXISTS (SELECT TOP 1 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'OBJ_PRODUCT')
BEGIN
CREATE TABLE [dbo].[OBJ_PRODUCT](
	[ID] [bigint] IDENTITY(0,1) NOT NULL,
	[ProductCode] [varchar](15) NOT NULL,
	[ProductDesc] [nvarchar](max) NOT NULL,
	[Descriptions] [nvarchar](max) NOT NULL,
	[ProductType] [bigint] NULL,
	[ProductGroup] [bigint] NULL,
	[UnitWeight] [bigint] NULL,
	[UnitSell] [bigint] NULL,
	[Supplier] [bigint] NULL,
	[StatusCode] [varchar](5) NULL,
	[UpdateDate] [datetime] NOT NULL,
	[UpdateBy] [bigint] NOT NULL,
	[IsDelete] [bit] NULL,
 CONSTRAINT [PK_OBJ_PRODUCT] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
--=========================================================================================================================================================
--=========================================================================================================================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Lịch sử đóng mở quầy thu ngân
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CAT_COUNTER_LOG]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[CAT_COUNTER_LOG](
	[CounterID] [bigint] NOT NULL,
	[EmpID] [bigint] NOT NULL,
	[CounterDateTime] [datetime] NOT NULL,
	[StatusCode] [varchar](5) NULL,
 CONSTRAINT [PK_CAT_COUNTER_LOG] PRIMARY KEY CLUSTERED 
(
	[CounterID] ASC,
	[EmpID] ASC,
	[CounterDateTime] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
--=========================================================================================================================================================
--=========================================================================================================================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Lịch sử giao dịch của hàng hóa
IF NOT EXISTS (SELECT TOP 1 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'SYS_PRODUCT_LOG')
BEGIN
CREATE TABLE [dbo].[SYS_PRODUCT_LOG](
	[ProductID] [bigint] NOT NULL,
	[InTrnID] [bigint]  NOT NULL,
	[InDateTime] [datetime] NOT NULL,
	[InQuantity] int NULL, 
	[InWeights] numeric(19,8) NULL, 
	[OutTrnID] [bigint] NOT NULL,
	[OutTrnType] varchar(10) NULL,
	[OutDateTime] [datetime] NULL,
	[OutQuantity] int NULL, 
	[OutWeights] numeric(19,8) NULL,
 CONSTRAINT [PK_SYS_PRODUCT_LOG] PRIMARY KEY CLUSTERED 
(
	[ProductID] ASC,
	[InTrnID] ASC,
	[InDateTime] ASC,
	[OutTrnID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
--=========================================================================================================================================================
--=========================================================================================================================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Giá bán hàng
IF NOT EXISTS (SELECT TOP 1 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME='SYS_PRODUCT_RATE')
BEGIN
	CREATE TABLE [dbo].[SYS_PRODUCT_RATE](
		[ProductID] [bigint] NOT NULL,
		[RateDate] datetime NOT NULL,
		[RateIn] [numeric](19, 8) NULL,
		[RateEstimate] [numeric](19, 8) NULL,
		[DiscountPercent] [numeric](19, 8) NULL,
		[Discount] [numeric](19, 8) NULL,
		[DiscountTotal] [numeric](19, 8) NULL,
		[RateSell] [numeric](19, 8) NULL,
		[IsSellCurrent] bit NULL,
	 CONSTRAINT [PK_SYS_PRODUCT_RATE] PRIMARY KEY CLUSTERED 
	(
		[ProductID] ASC,
		[RateDate] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]
END
GO
--=========================================================================================================================================================
--=========================================================================================================================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Tồn kho hàng
IF NOT EXISTS (SELECT TOP 1 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME='SYS_PRODUCT_STOCK')
BEGIN
	CREATE TABLE [dbo].[SYS_PRODUCT_STOCK](
		[StallsID] bigint NOT NULL,
		[ProductID] bigint NOT NULL,
		[Quantity] int NULL,
		[QuantityReal] int NULL,
		[Weights] [numeric](19, 8) NULL,
		[WeightsReal] [numeric](19, 8) NULL,
	 CONSTRAINT [PK_SYS_PRODUCT_STOCK] PRIMARY KEY CLUSTERED 
	(
		[StallsID] ASC,
		[ProductID] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]
END
GO
--=========================================================================================================================================================
--=========================================================================================================================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Giao dịch thu chi tại quầy
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TRN_COUNTER_INOUT]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[TRN_COUNTER_INOUT](
	[TrnID] [bigint] IDENTITY(0,1) NOT NULL,
	[TrnCode] [varchar](15) NOT NULL,
	[TrnDate] [date] NOT NULL,
	[TrnTime] [time](7) NOT NULL,
	[CounterID] [bigint] NULL,
	[Notes] [nvarchar](max) NULL,
	[EmpID] [bigint] NULL,
	[StatusCode] [varchar](5) NULL,
	[UpdateDate] [datetime] NOT NULL,
	[UpdateBy] [bigint] NOT NULL,
	[IsDelete] [bit] NULL,
 CONSTRAINT [PK_TRN_COUNTER_INOUT] PRIMARY KEY CLUSTERED 
(
	[TrnID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
--=========================================================================================================================================================
--=========================================================================================================================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Giao dịch thu chi tại quầy chi tiết
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TRN_COUNTER_INOUT_DT]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[TRN_COUNTER_INOUT_DT](
	[OrdinalNumber] [bigint] NOT NULL,
	[TrnID] [bigint] NOT NULL,
	[TrnType] bit NOT NULL,			-- 1: Thu | 0: Chi
	[Currency] [bigint] NOT NULL,
	[Amount] [numeric](19, 8) NULL,
	[Notes] [nvarchar](max) NULL,
 CONSTRAINT [PK_TRN_COUNTER_INOUT_DT] PRIMARY KEY CLUSTERED 
(
	[OrdinalNumber] ASC,
	[TrnID] ASC,
	[TrnType] ASC,
	[Currency] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
--=========================================================================================================================================================
--=========================================================================================================================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Giao dịch thu chi tại quầy
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TRN_COUNTER_TRANSFER]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[TRN_COUNTER_TRANSFER](
	[TrnID] [bigint] IDENTITY(0,1) NOT NULL,
	[TrnCode] [varchar](15) NOT NULL,
	[TrnDate] [date] NOT NULL,
	[TrnTime] [time](7) NOT NULL,
	[CounterFrom] [bigint] NULL,
	[CounterTo] [bigint] NULL,
	[Notes] [nvarchar](max) NULL,
	[EmpID] [bigint] NULL,
	[StatusCode] [varchar](5) NULL,
	[UpdateDate] [datetime] NOT NULL,
	[UpdateBy] [bigint] NOT NULL,
	[IsDelete] [bit] NULL,
 CONSTRAINT [PK_TRN_COUNTER_TRANSFER] PRIMARY KEY CLUSTERED 
(
	[TrnID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
--=========================================================================================================================================================
--=========================================================================================================================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Giao dịch chuyển quầy
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TRN_COUNTER_TRANSFER_DT]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[TRN_COUNTER_TRANSFER_DT](
	[OrdinalNumber] [bigint] NOT NULL,
	[TrnID] [bigint] NOT NULL,
	[Currency] [bigint] NOT NULL,
	[Amount] [numeric](19, 8) NULL,
	[Notes] [nvarchar](max) NULL,
 CONSTRAINT [PK_TRN_COUNTER_TRANSFER_DT] PRIMARY KEY CLUSTERED 
(
	[OrdinalNumber] ASC,
	[TrnID] ASC,
	[Currency] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
--=========================================================================================================================================================
--=========================================================================================================================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Giao dịch nhập hàng
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TRN_PRODUCT_IN]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[TRN_PRODUCT_IN](
	[TrnID] [bigint] IDENTITY(0,1) NOT NULL,
	[TrnCode] [varchar](15) NOT NULL,
	[TrnDate] [date] NOT NULL,
	[TrnTime] [time](7) NOT NULL,
	[StallsID] [bigint] NULL,
	[Notes] [nvarchar](max) NULL,
	[EmpID] [bigint] NULL,
	[StatusCode] [varchar](5) NULL,
	[UpdateDate] [datetime] NOT NULL,
	[UpdateBy] [bigint] NOT NULL,
	[IsDelete] [bit] NULL,
 CONSTRAINT [PK_TRN_PRODUCT_IN] PRIMARY KEY CLUSTERED 
(
	[TrnID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
--=========================================================================================================================================================
--=========================================================================================================================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Giao dịch nhập hàng
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TRN_PRODUCT_IN_DT]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[TRN_PRODUCT_IN_DT](
	[TrnID] [bigint] NOT NULL,
	[ProductCode] [varchar](15) NOT NULL,
	[ProductDesc] [nvarchar](max) NULL,
	[ProductType] [bigint] NULL,
	[ProductGroup] [bigint] NULL,
	[Descriptions] [nvarchar](max) NULL,
	[ProductWeight] [numeric](19, 8) NULL,
	[Quantity] [int] NULL,
	[UnitWeight] [bigint] NULL,
	[UnitIn] [bigint] NULL,
	[UnitSell] [bigint] NULL,
	[RateIn] [numeric](19, 8) NULL,
	[RateSell] [numeric](19, 8) NULL,
	[Supplier] [bigint] NULL,
 CONSTRAINT [PK_TRN_PRODUCT_IN_DT] PRIMARY KEY CLUSTERED 
(
	[TrnID] ASC,
	[ProductCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
--=========================================================================================================================================================
--=========================================================================================================================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Giao dịch xuất hàng
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TRN_PRODUCT_OUT]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[TRN_PRODUCT_OUT](
	[TrnID] [bigint] IDENTITY(0,1) NOT NULL,
	[TrnCode] [varchar](15) NOT NULL,
	[TrnDate] [date] NULL,
	[TrnTime] [time](7) NULL,
	[StallsID] [bigint] NULL,
	[Notes] [nvarchar](max) NULL,
	[EmpID] [bigint] NULL,
	[StatusCode] [varchar](5) NULL,
	[UpdateDate] [datetime] NOT NULL,
	[UpdateBy] [bigint] NOT NULL,
	[IsDelete] [bit] NULL,
 CONSTRAINT [PK_TRN_PRODUCT_OUT] PRIMARY KEY CLUSTERED 
(
	[TrnID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
--=========================================================================================================================================================
--=========================================================================================================================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Giao dịch xuất hàng chi tiết
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TRN_PRODUCT_OUT_DT]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[TRN_PRODUCT_OUT_DT](
	[TrnID] [bigint] NOT NULL,
	[ProductID] [bigint] NOT NULL,
	[ProductWeight] [numeric](19, 8) NULL,
	[Quantity] [int] NULL,
	[Notes] [nvarchar](max) NULL,
 CONSTRAINT [PK_TRN_PRODUCT_OUT_DT] PRIMARY KEY CLUSTERED 
(
	[TrnID] ASC,
	[ProductID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
--=========================================================================================================================================================
--=========================================================================================================================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Giao dịch chuyển hàng
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TRN_PRODUCT_TRANSFER]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[TRN_PRODUCT_TRANSFER](
	[TrnID] [bigint] IDENTITY(0,1) NOT NULL,
	[TrnCode] [varchar](15) NOT NULL,
	[TrnDate] [date] NOT NULL,
	[TrnTime] [time](7) NOT NULL,
	[StallsFrom] [bigint] NULL,
	[StallsTo] [bigint] NULL,
	[Notes] [nvarchar](max) NULL,
	[EmpID] [bigint] NULL,
	[StatusCode] [varchar](5) NULL,
	[UpdateDate] [datetime] NOT NULL,
	[UpdateBy] [bigint] NOT NULL,
	[IsDelete] [bit] NULL,
 CONSTRAINT [PK_TRN_PRODUCT_TRANSFER] PRIMARY KEY CLUSTERED 
(
	[TrnID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
--=========================================================================================================================================================
--=========================================================================================================================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Giao dịch nhập hàng
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TRN_PRODUCT_TRANSFER_DT]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[TRN_PRODUCT_TRANSFER_DT](
	[TrnID] [bigint] NOT NULL,
	[ProductID] [bigint] NOT NULL,
	[ProductWeight] [numeric](19, 8) NULL,
	[Quantity] [int] NULL,
	[Notes] [nvarchar](max) NULL,
 CONSTRAINT [PK_TRN_PRODUCT_TRANSFER_DT] PRIMARY KEY CLUSTERED 
(
	[TrnID] ASC,
	[ProductID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
--=========================================================================================================================================================
--=========================================================================================================================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Giao dịch bán hàng
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TRN_PRODUCT_SELL]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[TRN_PRODUCT_SELL](
	[TrnID] [bigint] IDENTITY(0,1) NOT NULL,
	[TrnCode] [varchar](15) NOT NULL,
	[TrnDate] [date] NOT NULL,
	[TrnTime] [time](7) NOT NULL,
	[CustID] [bigint] NOT NULL,
	[CounterID] [bigint] NULL,
	[DiscountTrn] [numeric](19, 8) NULL,
	[DiscountTotal] [numeric](19, 8) NULL,
	[AmountTotal] [numeric](19, 8) NULL,
	[AmountPay] [numeric](19, 8) NULL,
	[UnitPayment] [bigint] NULL,
	[Notes] [nvarchar](max) NULL,
	[EmpID] [bigint] NULL,
	[StatusCode] [varchar](5) NULL,
	[UpdateDate] [datetime] NOT NULL,
	[UpdateBy] [bigint] NOT NULL,
	[IsDelete] [bit] NULL,
 CONSTRAINT [PK_TRN_PRODUCT_SELL] PRIMARY KEY CLUSTERED 
(
	[TrnID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
--=========================================================================================================================================================
--=========================================================================================================================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Giao dịch bán hàng chi tiết
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TRN_PRODUCT_SELL_DT]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[TRN_PRODUCT_SELL_DT](
	[TrnID] [bigint] NOT NULL,
	[ProductID] [bigint] NOT NULL,
	[StallsID] [bigint] NOT NULL,
	[ProductWeight] [numeric](19, 8) NULL,
	[Quantity] [int] NULL,
	[UnitSell] [bigint] NULL,
	[Rate] [numeric](19, 8) NULL,
	[Discount] [numeric](19, 8) NULL,
	[Amount] [numeric](19, 8) NULL,
	[Notes] [nvarchar](max) NULL,
 CONSTRAINT [PK_TRN_PRODUCT_SELL_DT] PRIMARY KEY CLUSTERED 
(
	[TrnID] ASC,
	[ProductID] ASC,
	[StallsID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
--=========================================================================================================================================================
--=========================================================================================================================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Tồn quầy thu ngân
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SYS_COUNTER_STOCK]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[SYS_COUNTER_STOCK](
	[CounterID] [bigint] NOT NULL,
	[CurrencyID] [bigint] NOT NULL,
	[InStock] [numeric](19,2) NULL,
 CONSTRAINT [PK_SYS_COUNTER_STOCK] PRIMARY KEY CLUSTERED 
(
	[CounterID] ASC,
	[CurrencyID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
