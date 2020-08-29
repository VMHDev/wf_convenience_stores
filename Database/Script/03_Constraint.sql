IF EXISTS(SELECT * FROM SYS.DATABASES WHERE NAME = 'PTTKPMCRM')
BEGIN
	USE PTTKPMCRM
END
GO
--=========================================================================================================================================================
-- CAT_COUNTER
-----------------------------------------------------------------------------------------------------------------------------------------------------------
IF NOT EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[FK_CAT_COUNTER_CAT_SHOP]') AND type in (N'F'))
BEGIN
	ALTER TABLE [dbo].[CAT_COUNTER]  WITH CHECK ADD  CONSTRAINT [FK_CAT_COUNTER_CAT_SHOP] FOREIGN KEY([ShopID])
	REFERENCES [dbo].[CAT_SHOP] ([ID])
	ALTER TABLE [dbo].[CAT_COUNTER] CHECK CONSTRAINT [FK_CAT_COUNTER_CAT_SHOP]
END
GO
--=========================================================================================================================================================
-- CAT_EMPLOYEE
-----------------------------------------------------------------------------------------------------------------------------------------------------------
IF NOT EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[FK_CAT_EMPLOYEE_SYS_USERS]') AND type in (N'F'))
BEGIN
	ALTER TABLE [dbo].[CAT_EMPLOYEE]  WITH CHECK ADD  CONSTRAINT [FK_CAT_EMPLOYEE_SYS_USERS] FOREIGN KEY([UserID])
	REFERENCES [dbo].[SYS_USERS] ([ID])
	ALTER TABLE [dbo].[CAT_EMPLOYEE] CHECK CONSTRAINT [FK_CAT_EMPLOYEE_SYS_USERS]
END
GO
-----------------------------------------------------------------------------------------------------------------------------------------------------------
IF NOT EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[FK_CAT_EMPLOYEE_CAT_SHOP]') AND type in (N'F'))
BEGIN
	ALTER TABLE [dbo].[CAT_EMPLOYEE]  WITH CHECK ADD  CONSTRAINT [FK_CAT_EMPLOYEE_CAT_SHOP] FOREIGN KEY([ShopID])
	REFERENCES [dbo].[CAT_SHOP] ([ID])
	ALTER TABLE [dbo].[CAT_EMPLOYEE] CHECK CONSTRAINT [FK_CAT_EMPLOYEE_CAT_SHOP]
END
GO
--=========================================================================================================================================================
-- CAT_CUSTOMER
-----------------------------------------------------------------------------------------------------------------------------------------------------------
IF NOT EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[FK_CAT_CUSTOMER_CAT_CUSTOMERGROUP]') AND type in (N'F'))
BEGIN
	ALTER TABLE [dbo].[CAT_CUSTOMER]  WITH CHECK ADD  CONSTRAINT [FK_CAT_CUSTOMER_CAT_CUSTOMERGROUP] FOREIGN KEY([CustGroupID])
	REFERENCES [dbo].[CAT_CUSTOMERGROUP] ([ID])
	ALTER TABLE [dbo].[CAT_CUSTOMER] CHECK CONSTRAINT [FK_CAT_CUSTOMER_CAT_CUSTOMERGROUP]
END
GO
-----------------------------------------------------------------------------------------------------------------------------------------------------------
IF NOT EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[FK_CAT_CUSTOMER_CAT_CUSTOMERTYPE]') AND type in (N'F'))
BEGIN
	ALTER TABLE [dbo].[CAT_CUSTOMER]  WITH CHECK ADD  CONSTRAINT [FK_CAT_CUSTOMER_CAT_CUSTOMERTYPE] FOREIGN KEY([CustTypeID])
	REFERENCES [dbo].[CAT_CUSTOMERTYPE] ([ID])
	ALTER TABLE [dbo].[CAT_CUSTOMER] CHECK CONSTRAINT [FK_CAT_CUSTOMER_CAT_CUSTOMERTYPE]
END
GO
--=========================================================================================================================================================
-- MAP_USER_USERGROUP
-----------------------------------------------------------------------------------------------------------------------------------------------------------
IF NOT EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[FK_MAP_USER_USERGROUP_CAT_USERGROUP]') AND type in (N'F'))
BEGIN
	ALTER TABLE [dbo].[MAP_USER_USERGROUP]  WITH CHECK ADD  CONSTRAINT [FK_MAP_USER_USERGROUP_CAT_USERGROUP] FOREIGN KEY([GroupID])
	REFERENCES [dbo].[CAT_USERGROUP] ([ID])
	ALTER TABLE [dbo].[MAP_USER_USERGROUP] CHECK CONSTRAINT [FK_MAP_USER_USERGROUP_CAT_USERGROUP]
END
GO
-----------------------------------------------------------------------------------------------------------------------------------------------------------
IF NOT EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[FK_MAP_USER_USERGROUP_SYS_USERS]') AND type in (N'F'))
BEGIN
	ALTER TABLE [dbo].[MAP_USER_USERGROUP]  WITH CHECK ADD  CONSTRAINT [FK_MAP_USER_USERGROUP_SYS_USERS] FOREIGN KEY([UserID])
	REFERENCES [dbo].[SYS_USERS] ([ID])
	ALTER TABLE [dbo].[MAP_USER_USERGROUP] CHECK CONSTRAINT [FK_MAP_USER_USERGROUP_SYS_USERS]
END
GO
--=========================================================================================================================================================
-- SYS_RIGHTS
-----------------------------------------------------------------------------------------------------------------------------------------------------------
IF NOT EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[FK_SYS_RIGHTS_SYS_MENUS]') AND type in (N'F'))
BEGIN
	ALTER TABLE [dbo].[SYS_RIGHTS]  WITH CHECK ADD  CONSTRAINT [FK_SYS_RIGHTS_SYS_MENUS] FOREIGN KEY([MenuCode])
	REFERENCES [dbo].[SYS_MENUS] ([MenuCode])
	ALTER TABLE [dbo].[SYS_RIGHTS] CHECK CONSTRAINT [FK_SYS_RIGHTS_SYS_MENUS]
END
GO
-----------------------------------------------------------------------------------------------------------------------------------------------------------
IF NOT EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[FK_SYS_RIGHTS_CAT_USERGROUP]') AND type in (N'F'))
BEGIN
	ALTER TABLE [dbo].[SYS_RIGHTS]  WITH CHECK ADD  CONSTRAINT [FK_SYS_RIGHTS_CAT_USERGROUP] FOREIGN KEY([GroupID])
	REFERENCES [dbo].[CAT_USERGROUP] ([ID])
	ALTER TABLE [dbo].[SYS_RIGHTS] CHECK CONSTRAINT [FK_SYS_RIGHTS_CAT_USERGROUP]
END
GO
--=========================================================================================================================================================
-- OBJ_PRODUCT
-----------------------------------------------------------------------------------------------------------------------------------------------------------
IF NOT EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[FK_OBJ_PRODUCT_CAT_PRODUCTGROUP]') AND type in (N'F'))
BEGIN
	ALTER TABLE [dbo].[OBJ_PRODUCT]  WITH CHECK ADD  CONSTRAINT [FK_OBJ_PRODUCT_CAT_PRODUCTGROUP] FOREIGN KEY([ProductType])
	REFERENCES [dbo].[CAT_PRODUCTGROUP] ([ID])
	ALTER TABLE [dbo].[OBJ_PRODUCT] CHECK CONSTRAINT [FK_OBJ_PRODUCT_CAT_PRODUCTGROUP]
END
GO
-----------------------------------------------------------------------------------------------------------------------------------------------------------
IF NOT EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[FK_OBJ_PRODUCT_CAT_PRODUCTTYPE]') AND type in (N'F'))
BEGIN
	ALTER TABLE [dbo].[OBJ_PRODUCT]  WITH CHECK ADD  CONSTRAINT [FK_OBJ_PRODUCT_CAT_PRODUCTTYPE] FOREIGN KEY([ProductGroup])
	REFERENCES [dbo].[CAT_PRODUCTTYPE] ([ID])
	ALTER TABLE [dbo].[OBJ_PRODUCT] CHECK CONSTRAINT [FK_OBJ_PRODUCT_CAT_PRODUCTTYPE]
END
GO
-----------------------------------------------------------------------------------------------------------------------------------------------------------
IF NOT EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[FK_OBJ_PRODUCT_CAT_UNIT_WEIGHT]') AND type in (N'F'))
BEGIN
	ALTER TABLE [dbo].[OBJ_PRODUCT]  WITH CHECK ADD  CONSTRAINT [FK_OBJ_PRODUCT_CAT_UNIT_WEIGHT] FOREIGN KEY([UnitWeight])
	REFERENCES [dbo].[CAT_UNIT_WEIGHT] ([ID])
	ALTER TABLE [dbo].[OBJ_PRODUCT] CHECK CONSTRAINT [FK_OBJ_PRODUCT_CAT_UNIT_WEIGHT]
END
GO
-----------------------------------------------------------------------------------------------------------------------------------------------------------
IF NOT EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[FK_OBJ_PRODUCT_CAT_UNIT_SELL]') AND type in (N'F'))
BEGIN
	ALTER TABLE [dbo].[OBJ_PRODUCT]  WITH CHECK ADD  CONSTRAINT [FK_OBJ_PRODUCT_CAT_UNIT_SELL] FOREIGN KEY([UnitSell])
	REFERENCES [dbo].[CAT_UNIT_SELL] ([ID])
	ALTER TABLE [dbo].[OBJ_PRODUCT] CHECK CONSTRAINT [FK_OBJ_PRODUCT_CAT_UNIT_SELL]
END
GO
-----------------------------------------------------------------------------------------------------------------------------------------------------------
IF NOT EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[FK_OBJ_PRODUCT_CAT_SUPPLIER]') AND type in (N'F'))
BEGIN
	ALTER TABLE [dbo].[OBJ_PRODUCT]  WITH CHECK ADD  CONSTRAINT [FK_OBJ_PRODUCT_CAT_SUPPLIER] FOREIGN KEY([Supplier])
	REFERENCES [dbo].[CAT_SUPPLIER] ([ID])
	ALTER TABLE [dbo].[OBJ_PRODUCT] CHECK CONSTRAINT [FK_OBJ_PRODUCT_CAT_SUPPLIER]
END
GO
--=========================================================================================================================================================
-- CAT_COUNTER_LOG
-----------------------------------------------------------------------------------------------------------------------------------------------------------
IF NOT EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[FK_CAT_COUNTER_LOG_CAT_COUNTER]') AND type in (N'F'))
BEGIN
	ALTER TABLE [dbo].[CAT_COUNTER_LOG]  WITH CHECK ADD  CONSTRAINT [FK_CAT_COUNTER_LOG_CAT_COUNTER] FOREIGN KEY([CounterID])
	REFERENCES [dbo].[CAT_COUNTER] ([ID])
	ALTER TABLE [dbo].[CAT_COUNTER_LOG] CHECK CONSTRAINT [FK_CAT_COUNTER_LOG_CAT_COUNTER]
END
GO
-----------------------------------------------------------------------------------------------------------------------------------------------------------
IF NOT EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[FK_CAT_COUNTER_LOG_CAT_EMPLOYEE]') AND type in (N'F'))
BEGIN
	ALTER TABLE [dbo].[CAT_COUNTER_LOG]  WITH CHECK ADD  CONSTRAINT [FK_CAT_COUNTER_LOG_CAT_EMPLOYEE] FOREIGN KEY([EmpID])
	REFERENCES [dbo].[CAT_EMPLOYEE] ([ID])
	ALTER TABLE [dbo].[CAT_COUNTER_LOG] CHECK CONSTRAINT [FK_CAT_COUNTER_LOG_CAT_EMPLOYEE]
END
GO
--=========================================================================================================================================================
-- SYS_PRODUCT_LOG
-----------------------------------------------------------------------------------------------------------------------------------------------------------
IF NOT EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[FK_SYS_PRODUCT_LOG_OBJ_PRODUCT]') AND type in (N'F'))
BEGIN
	ALTER TABLE [dbo].[SYS_PRODUCT_LOG]  WITH CHECK ADD  CONSTRAINT [FK_SYS_PRODUCT_LOG_OBJ_PRODUCT] FOREIGN KEY([ProductID])
	REFERENCES [dbo].[OBJ_PRODUCT] ([ID])
	ALTER TABLE [dbo].[SYS_PRODUCT_LOG] CHECK CONSTRAINT [FK_SYS_PRODUCT_LOG_OBJ_PRODUCT]
END
GO
--=========================================================================================================================================================
-- TRN_COUNTER_INOUT
-----------------------------------------------------------------------------------------------------------------------------------------------------------
IF NOT EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[FK_TRN_COUNTER_INOUT_CAT_COUNTER]') AND type in (N'F'))
BEGIN
	ALTER TABLE [dbo].[TRN_COUNTER_INOUT]  WITH CHECK ADD  CONSTRAINT [FK_TRN_COUNTER_INOUT_CAT_COUNTER] FOREIGN KEY([CounterID])
	REFERENCES [dbo].[CAT_COUNTER] ([ID])
	ALTER TABLE [dbo].[TRN_COUNTER_INOUT] CHECK CONSTRAINT [FK_TRN_COUNTER_INOUT_CAT_COUNTER]
END
GO
-----------------------------------------------------------------------------------------------------------------------------------------------------------
IF NOT EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[FK_TRN_COUNTER_INOUT_CAT_EMPLOYEE]') AND type in (N'F'))
BEGIN
	ALTER TABLE [dbo].[TRN_COUNTER_INOUT]  WITH CHECK ADD  CONSTRAINT [FK_TRN_COUNTER_INOUT_CAT_EMPLOYEE] FOREIGN KEY([EmpID])
	REFERENCES [dbo].[CAT_EMPLOYEE] ([ID])
	ALTER TABLE [dbo].[TRN_COUNTER_INOUT] CHECK CONSTRAINT [FK_TRN_COUNTER_INOUT_CAT_EMPLOYEE]
END
GO
--=========================================================================================================================================================
-- TRN_COUNTER_INOUT_DT
-----------------------------------------------------------------------------------------------------------------------------------------------------------
IF NOT EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[FK_TRN_COUNTER_INOUT_DT_TRN_COUNTER_INOUT]') AND type in (N'F'))
BEGIN
	ALTER TABLE [dbo].[TRN_COUNTER_INOUT_DT]  WITH CHECK ADD  CONSTRAINT [FK_TRN_COUNTER_INOUT_DT_TRN_COUNTER_INOUT] FOREIGN KEY([TrnID])
	REFERENCES [dbo].[TRN_COUNTER_INOUT] ([TrnID])
	ALTER TABLE [dbo].[TRN_COUNTER_INOUT_DT] CHECK CONSTRAINT [FK_TRN_COUNTER_INOUT_DT_TRN_COUNTER_INOUT]
END
GO
-----------------------------------------------------------------------------------------------------------------------------------------------------------
IF NOT EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[FK_TRN_COUNTER_INOUT_DT_CAT_CURRENCY]') AND type in (N'F'))
BEGIN
	ALTER TABLE [dbo].[TRN_COUNTER_INOUT_DT]  WITH CHECK ADD  CONSTRAINT [FK_TRN_COUNTER_INOUT_DT_CAT_CURRENCY] FOREIGN KEY([Currency])
	REFERENCES [dbo].[CAT_CURRENCY] ([ID])
	ALTER TABLE [dbo].[TRN_COUNTER_INOUT_DT] CHECK CONSTRAINT [FK_TRN_COUNTER_INOUT_DT_CAT_CURRENCY]
END
GO
--=========================================================================================================================================================
-- TRN_COUNTER_TRANSFER
-----------------------------------------------------------------------------------------------------------------------------------------------------------
IF NOT EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[FK_TRN_COUNTER_TRANSFER_CAT_EMPLOYEE]') AND type in (N'F'))
BEGIN
	ALTER TABLE [dbo].[TRN_COUNTER_TRANSFER]  WITH CHECK ADD  CONSTRAINT [FK_TRN_COUNTER_TRANSFER_CAT_EMPLOYEE] FOREIGN KEY([EmpID])
	REFERENCES [dbo].[CAT_EMPLOYEE] ([ID])
	ALTER TABLE [dbo].[TRN_COUNTER_TRANSFER] CHECK CONSTRAINT [FK_TRN_COUNTER_TRANSFER_CAT_EMPLOYEE]
END
GO
-----------------------------------------------------------------------------------------------------------------------------------------------------------
IF NOT EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[FK_TRN_COUNTER_TRANSFER_CAT_COUNTER_FROM]') AND type in (N'F'))
BEGIN
	ALTER TABLE [dbo].[TRN_COUNTER_TRANSFER]  WITH CHECK ADD  CONSTRAINT [FK_TRN_COUNTER_TRANSFER_CAT_COUNTER_FROM] FOREIGN KEY([CounterFrom])
	REFERENCES [dbo].[CAT_COUNTER] ([ID])
	ALTER TABLE [dbo].[TRN_COUNTER_TRANSFER] CHECK CONSTRAINT [FK_TRN_COUNTER_TRANSFER_CAT_COUNTER_FROM]
END
GO
-----------------------------------------------------------------------------------------------------------------------------------------------------------
IF NOT EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[FK_TRN_COUNTER_TRANSFER_CAT_COUNTER_TO]') AND type in (N'F'))
BEGIN
	ALTER TABLE [dbo].[TRN_COUNTER_TRANSFER]  WITH CHECK ADD  CONSTRAINT [FK_TRN_COUNTER_TRANSFER_CAT_COUNTER_TO] FOREIGN KEY([CounterTo])
	REFERENCES [dbo].[CAT_COUNTER] ([ID])
	ALTER TABLE [dbo].[TRN_COUNTER_TRANSFER] CHECK CONSTRAINT [FK_TRN_COUNTER_TRANSFER_CAT_COUNTER_TO]
END
GO
--=========================================================================================================================================================
-- TRN_COUNTER_TRANSFER_DT
-----------------------------------------------------------------------------------------------------------------------------------------------------------
IF NOT EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[FK_TRN_COUNTER_TRANSFER_DT_TRN_COUNTER_TRANSFER]') AND type in (N'F'))
BEGIN
	ALTER TABLE [dbo].[TRN_COUNTER_TRANSFER_DT]  WITH CHECK ADD  CONSTRAINT [FK_TRN_COUNTER_TRANSFER_DT_TRN_COUNTER_TRANSFER] FOREIGN KEY([TrnID])
	REFERENCES [dbo].[TRN_COUNTER_TRANSFER] ([TrnID])
	ALTER TABLE [dbo].[TRN_COUNTER_TRANSFER_DT] CHECK CONSTRAINT [FK_TRN_COUNTER_TRANSFER_DT_TRN_COUNTER_TRANSFER]
END
GO
-----------------------------------------------------------------------------------------------------------------------------------------------------------
IF NOT EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[FK_TRN_COUNTER_TRANSFER_DT_CAT_CURRENCY]') AND type in (N'F'))
BEGIN
	ALTER TABLE [dbo].[TRN_COUNTER_TRANSFER_DT]  WITH CHECK ADD  CONSTRAINT [FK_TRN_COUNTER_TRANSFER_DT_CAT_CURRENCY] FOREIGN KEY([Currency])
	REFERENCES [dbo].[CAT_CURRENCY] ([ID])
	ALTER TABLE [dbo].[TRN_COUNTER_TRANSFER_DT] CHECK CONSTRAINT [FK_TRN_COUNTER_TRANSFER_DT_CAT_CURRENCY]
END
GO
--=========================================================================================================================================================
-- TRN_PRODUCT_IN
-----------------------------------------------------------------------------------------------------------------------------------------------------------
IF NOT EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[FK_TRN_PRODUCT_IN_CAT_EMPLOYEE]') AND type in (N'F'))
BEGIN
	ALTER TABLE [dbo].[TRN_PRODUCT_IN]  WITH CHECK ADD  CONSTRAINT [FK_TRN_PRODUCT_IN_CAT_EMPLOYEE] FOREIGN KEY([EmpID])
	REFERENCES [dbo].[CAT_EMPLOYEE] ([ID])
	ALTER TABLE [dbo].[TRN_PRODUCT_IN] CHECK CONSTRAINT [FK_TRN_PRODUCT_IN_CAT_EMPLOYEE]
END
GO
-----------------------------------------------------------------------------------------------------------------------------------------------------------
IF NOT EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[FK_TRN_PRODUCT_IN_CAT_STALLS]') AND type in (N'F'))
BEGIN
	ALTER TABLE [dbo].[TRN_PRODUCT_IN]  WITH CHECK ADD  CONSTRAINT [FK_TRN_PRODUCT_IN_CAT_STALLS] FOREIGN KEY([StallsID])
	REFERENCES [dbo].[CAT_STALLS] ([ID])
	ALTER TABLE [dbo].[TRN_PRODUCT_IN] CHECK CONSTRAINT [FK_TRN_PRODUCT_IN_CAT_STALLS]
END
GO
--=========================================================================================================================================================
-- TRN_PRODUCT_IN_DT
-----------------------------------------------------------------------------------------------------------------------------------------------------------
IF NOT EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[FK_TRN_PRODUCT_IN_DT_TRN_PRODUCT_IN]') AND type in (N'F'))
BEGIN
	ALTER TABLE [dbo].[TRN_PRODUCT_IN_DT]  WITH CHECK ADD  CONSTRAINT [FK_TRN_PRODUCT_IN_DT_TRN_PRODUCT_IN] FOREIGN KEY([TrnID])
	REFERENCES [dbo].[TRN_PRODUCT_IN] ([TrnID])
	ALTER TABLE [dbo].[TRN_PRODUCT_IN_DT] CHECK CONSTRAINT [FK_TRN_PRODUCT_IN_DT_TRN_PRODUCT_IN]
END
GO
-----------------------------------------------------------------------------------------------------------------------------------------------------------
IF NOT EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[FK_TRN_PRODUCT_IN_DT_CAT_PRODUCTTYPE]') AND type in (N'F'))
BEGIN
	ALTER TABLE [dbo].[TRN_PRODUCT_IN_DT]  WITH CHECK ADD  CONSTRAINT [FK_TRN_PRODUCT_IN_DT_CAT_PRODUCTTYPE] FOREIGN KEY([ProductType])
	REFERENCES [dbo].[CAT_PRODUCTTYPE] ([ID])
	ALTER TABLE [dbo].[TRN_PRODUCT_IN_DT] CHECK CONSTRAINT [FK_TRN_PRODUCT_IN_DT_CAT_PRODUCTTYPE]
END
GO
-----------------------------------------------------------------------------------------------------------------------------------------------------------
IF NOT EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[FK_TRN_PRODUCT_IN_DT_CAT_PRODUCTGROUP]') AND type in (N'F'))
BEGIN
	ALTER TABLE [dbo].[TRN_PRODUCT_IN_DT]  WITH CHECK ADD  CONSTRAINT [FK_TRN_PRODUCT_IN_DT_CAT_PRODUCTGROUP] FOREIGN KEY([ProductGroup])
	REFERENCES [dbo].[CAT_PRODUCTGROUP] ([ID])
	ALTER TABLE [dbo].[TRN_PRODUCT_IN_DT] CHECK CONSTRAINT [FK_TRN_PRODUCT_IN_DT_CAT_PRODUCTGROUP]
END
GO
-----------------------------------------------------------------------------------------------------------------------------------------------------------
IF NOT EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[FK_TRN_PRODUCT_IN_DT_CAT_UNIT_WEIGHT]') AND type in (N'F'))
BEGIN
	ALTER TABLE [dbo].[TRN_PRODUCT_IN_DT]  WITH CHECK ADD  CONSTRAINT [FK_TRN_PRODUCT_IN_DT_CAT_UNIT_WEIGHT] FOREIGN KEY([UnitWeight])
	REFERENCES [dbo].[CAT_UNIT_WEIGHT] ([ID])
	ALTER TABLE [dbo].[TRN_PRODUCT_IN_DT] CHECK CONSTRAINT [FK_TRN_PRODUCT_IN_DT_CAT_UNIT_WEIGHT]
END
GO
-----------------------------------------------------------------------------------------------------------------------------------------------------------
IF NOT EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[FK_TRN_PRODUCT_IN_DT_CAT_UNIT_IN]') AND type in (N'F'))
BEGIN
	ALTER TABLE [dbo].[TRN_PRODUCT_IN_DT]  WITH CHECK ADD  CONSTRAINT [FK_TRN_PRODUCT_IN_DT_CAT_UNIT_IN] FOREIGN KEY([UnitIn])
	REFERENCES [dbo].[CAT_UNIT_IN] ([ID])
	ALTER TABLE [dbo].[TRN_PRODUCT_IN_DT] CHECK CONSTRAINT [FK_TRN_PRODUCT_IN_DT_CAT_UNIT_IN]
END
GO
-----------------------------------------------------------------------------------------------------------------------------------------------------------
IF NOT EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[FK_TRN_PRODUCT_IN_DT_CAT_UNIT_SELL]') AND type in (N'F'))
BEGIN
	ALTER TABLE [dbo].[TRN_PRODUCT_IN_DT]  WITH CHECK ADD  CONSTRAINT [FK_TRN_PRODUCT_IN_DT_CAT_UNIT_SELL] FOREIGN KEY([UnitSell])
	REFERENCES [dbo].[CAT_UNIT_SELL] ([ID])
	ALTER TABLE [dbo].[TRN_PRODUCT_IN_DT] CHECK CONSTRAINT [FK_TRN_PRODUCT_IN_DT_CAT_UNIT_SELL]
END
GO
-----------------------------------------------------------------------------------------------------------------------------------------------------------
IF NOT EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[FK_TRN_PRODUCT_IN_DT_CAT_SUPPLIER]') AND type in (N'F'))
BEGIN
	ALTER TABLE [dbo].[TRN_PRODUCT_IN_DT]  WITH CHECK ADD  CONSTRAINT [FK_TRN_PRODUCT_IN_DT_CAT_SUPPLIER] FOREIGN KEY([Supplier])
	REFERENCES [dbo].[CAT_SUPPLIER] ([ID])
	ALTER TABLE [dbo].[TRN_PRODUCT_IN_DT] CHECK CONSTRAINT [FK_TRN_PRODUCT_IN_DT_CAT_SUPPLIER]
END
GO
--=========================================================================================================================================================
-- TRN_PRODUCT_OUT
-----------------------------------------------------------------------------------------------------------------------------------------------------------
IF NOT EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[FK_TRN_PRODUCT_OUT_CAT_STALLS]') AND type in (N'F'))
BEGIN
	ALTER TABLE [dbo].[TRN_PRODUCT_OUT]  WITH CHECK ADD  CONSTRAINT [FK_TRN_PRODUCT_OUT_CAT_STALLS] FOREIGN KEY([StallsID])
	REFERENCES [dbo].[CAT_STALLS] ([ID])
	ALTER TABLE [dbo].[TRN_PRODUCT_OUT] CHECK CONSTRAINT [FK_TRN_PRODUCT_OUT_CAT_STALLS]
END
GO
-----------------------------------------------------------------------------------------------------------------------------------------------------------
IF NOT EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[FK_TRN_PRODUCT_OUT_CAT_EMPLOYEE]') AND type in (N'F'))
BEGIN
	ALTER TABLE [dbo].[TRN_PRODUCT_OUT]  WITH CHECK ADD  CONSTRAINT [FK_TRN_PRODUCT_OUT_CAT_EMPLOYEE] FOREIGN KEY([EmpID])
	REFERENCES [dbo].[CAT_EMPLOYEE] ([ID])
	ALTER TABLE [dbo].[TRN_PRODUCT_OUT] CHECK CONSTRAINT [FK_TRN_PRODUCT_OUT_CAT_EMPLOYEE]
END
GO
--=========================================================================================================================================================
-- TRN_PRODUCT_OUT_DT
-----------------------------------------------------------------------------------------------------------------------------------------------------------
IF NOT EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[FK_TRN_PRODUCT_OUT_DT_TRN_PRODUCT_OUT]') AND type in (N'F'))
BEGIN
	ALTER TABLE [dbo].[TRN_PRODUCT_OUT_DT]  WITH CHECK ADD  CONSTRAINT [FK_TRN_PRODUCT_OUT_DT_TRN_PRODUCT_OUT] FOREIGN KEY([TrnID])
	REFERENCES [dbo].[TRN_PRODUCT_OUT] ([TrnID])
	ALTER TABLE [dbo].[TRN_PRODUCT_OUT_DT] CHECK CONSTRAINT [FK_TRN_PRODUCT_OUT_DT_TRN_PRODUCT_OUT]
END
GO
-----------------------------------------------------------------------------------------------------------------------------------------------------------
IF NOT EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[FK_TRN_PRODUCT_OUT_DT_OBJ_PRODUCT]') AND type in (N'F'))
BEGIN
	ALTER TABLE [dbo].[TRN_PRODUCT_OUT_DT]  WITH CHECK ADD  CONSTRAINT [FK_TRN_PRODUCT_OUT_DT_OBJ_PRODUCT] FOREIGN KEY([ProductID])
	REFERENCES [dbo].[OBJ_PRODUCT] ([ID])
	ALTER TABLE [dbo].[TRN_PRODUCT_OUT_DT] CHECK CONSTRAINT [FK_TRN_PRODUCT_OUT_DT_OBJ_PRODUCT]
END
GO
--=========================================================================================================================================================
-- TRN_PRODUCT_TRANSFER
-----------------------------------------------------------------------------------------------------------------------------------------------------------
IF NOT EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[FK_TRN_PRODUCT_TRANSFER_CAT_EMPLOYEE]') AND type in (N'F'))
BEGIN
	ALTER TABLE [dbo].[TRN_PRODUCT_TRANSFER]  WITH CHECK ADD  CONSTRAINT [FK_TRN_PRODUCT_TRANSFER_CAT_EMPLOYEE] FOREIGN KEY([EmpID])
	REFERENCES [dbo].[CAT_EMPLOYEE] ([ID])
	ALTER TABLE [dbo].[TRN_PRODUCT_TRANSFER] CHECK CONSTRAINT [FK_TRN_PRODUCT_TRANSFER_CAT_EMPLOYEE]
END
GO
-----------------------------------------------------------------------------------------------------------------------------------------------------------
IF NOT EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[FK_TRN_PRODUCT_TRANSFER_CAT_STALLS_FROM]') AND type in (N'F'))
BEGIN
	ALTER TABLE [dbo].[TRN_PRODUCT_TRANSFER]  WITH CHECK ADD  CONSTRAINT [FK_TRN_PRODUCT_TRANSFER_CAT_STALLS_FROM] FOREIGN KEY([StallsFrom])
	REFERENCES [dbo].[CAT_STALLS] ([ID])
	ALTER TABLE [dbo].[TRN_PRODUCT_TRANSFER] CHECK CONSTRAINT [FK_TRN_PRODUCT_TRANSFER_CAT_STALLS_FROM]
END
GO
-----------------------------------------------------------------------------------------------------------------------------------------------------------
IF NOT EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[FK_TRN_PRODUCT_TRANSFER_CAT_STALLS_TO]') AND type in (N'F'))
BEGIN
	ALTER TABLE [dbo].[TRN_PRODUCT_TRANSFER]  WITH CHECK ADD  CONSTRAINT [FK_TRN_PRODUCT_TRANSFER_CAT_STALLS_TO] FOREIGN KEY([StallsTo])
	REFERENCES [dbo].[CAT_STALLS] ([ID])
	ALTER TABLE [dbo].[TRN_PRODUCT_TRANSFER] CHECK CONSTRAINT [FK_TRN_PRODUCT_TRANSFER_CAT_STALLS_TO]
END
GO
--=========================================================================================================================================================
-- TRN_PRODUCT_TRANSFER_DT
-----------------------------------------------------------------------------------------------------------------------------------------------------------
IF NOT EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[FK_TRN_PRODUCT_TRANSFER_DT_TRN_PRODUCT_TRANSFER]') AND type in (N'F'))
BEGIN
	ALTER TABLE [dbo].[TRN_PRODUCT_TRANSFER_DT]  WITH CHECK ADD  CONSTRAINT [FK_TRN_PRODUCT_TRANSFER_DT_TRN_PRODUCT_TRANSFER] FOREIGN KEY([TrnID])
	REFERENCES [dbo].[TRN_PRODUCT_TRANSFER] ([TrnID])
	ALTER TABLE [dbo].[TRN_PRODUCT_TRANSFER_DT] CHECK CONSTRAINT [FK_TRN_PRODUCT_TRANSFER_DT_TRN_PRODUCT_TRANSFER]
END
GO
-----------------------------------------------------------------------------------------------------------------------------------------------------------
IF NOT EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[FK_TRN_PRODUCT_TRANSFER_DT_OBJ_PRODUCT]') AND type in (N'F'))
BEGIN
	ALTER TABLE [dbo].[TRN_PRODUCT_TRANSFER_DT]  WITH CHECK ADD  CONSTRAINT [FK_TRN_PRODUCT_TRANSFER_DT_OBJ_PRODUCT] FOREIGN KEY([ProductID])
	REFERENCES [dbo].[OBJ_PRODUCT] ([ID])
	ALTER TABLE [dbo].[TRN_PRODUCT_TRANSFER_DT] CHECK CONSTRAINT [FK_TRN_PRODUCT_TRANSFER_DT_OBJ_PRODUCT]
END
GO
--=========================================================================================================================================================
-- TRN_PRODUCT_SELL
-----------------------------------------------------------------------------------------------------------------------------------------------------------
IF NOT EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[FK_TRN_PRODUCT_SELL_CAT_COUNTER]') AND type in (N'F'))
BEGIN
	ALTER TABLE [dbo].[TRN_PRODUCT_SELL]  WITH CHECK ADD  CONSTRAINT [FK_TRN_PRODUCT_SELL_CAT_COUNTER] FOREIGN KEY([CounterID])
	REFERENCES [dbo].[CAT_COUNTER] ([ID])
	ALTER TABLE [dbo].[TRN_PRODUCT_SELL] CHECK CONSTRAINT [FK_TRN_PRODUCT_SELL_CAT_COUNTER]
END
GO
-----------------------------------------------------------------------------------------------------------------------------------------------------------
IF NOT EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[FK_TRN_PRODUCT_SELL_CAT_EMPLOYEE]') AND type in (N'F'))
BEGIN
	ALTER TABLE [dbo].[TRN_PRODUCT_SELL]  WITH CHECK ADD  CONSTRAINT [FK_TRN_PRODUCT_SELL_CAT_EMPLOYEE] FOREIGN KEY([EmpID])
	REFERENCES [dbo].[CAT_EMPLOYEE] ([ID])
	ALTER TABLE [dbo].[TRN_PRODUCT_SELL] CHECK CONSTRAINT [FK_TRN_PRODUCT_SELL_CAT_EMPLOYEE]
END
GO
-----------------------------------------------------------------------------------------------------------------------------------------------------------
IF NOT EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[FK_TRN_PRODUCT_SELL_CAT_CUSTOMER]') AND type in (N'F'))
BEGIN
	ALTER TABLE [dbo].[TRN_PRODUCT_SELL]  WITH CHECK ADD  CONSTRAINT [FK_TRN_PRODUCT_SELL_CAT_CUSTOMER] FOREIGN KEY([CustID])
	REFERENCES [dbo].[CAT_CUSTOMER] ([ID])
	ALTER TABLE [dbo].[TRN_PRODUCT_SELL] CHECK CONSTRAINT [FK_TRN_PRODUCT_SELL_CAT_CUSTOMER]
END
GO
-----------------------------------------------------------------------------------------------------------------------------------------------------------
IF NOT EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[FK_TRN_PRODUCT_SELL_CAT_CURRENCY]') AND type in (N'F'))
BEGIN
	ALTER TABLE [dbo].[TRN_PRODUCT_SELL]  WITH CHECK ADD  CONSTRAINT [FK_TRN_PRODUCT_SELL_CAT_CURRENCY] FOREIGN KEY([UnitPayment])
	REFERENCES [dbo].[CAT_CURRENCY] ([ID])
	ALTER TABLE [dbo].[TRN_PRODUCT_SELL] CHECK CONSTRAINT [FK_TRN_PRODUCT_SELL_CAT_CURRENCY]
END
GO
--=========================================================================================================================================================
-- TRN_PRODUCT_SELL_DT
-----------------------------------------------------------------------------------------------------------------------------------------------------------
IF NOT EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[FK_TRN_PRODUCT_SELL_DT_TRN_PRODUCT_SELL]') AND type in (N'F'))
BEGIN
	ALTER TABLE [dbo].[TRN_PRODUCT_SELL_DT]  WITH CHECK ADD  CONSTRAINT [FK_TRN_PRODUCT_SELL_DT_TRN_PRODUCT_SELL] FOREIGN KEY([TrnID])
	REFERENCES [dbo].[TRN_PRODUCT_SELL] ([TrnID])
	ALTER TABLE [dbo].[TRN_PRODUCT_SELL_DT] CHECK CONSTRAINT [FK_TRN_PRODUCT_SELL_DT_TRN_PRODUCT_SELL]
END
GO
-----------------------------------------------------------------------------------------------------------------------------------------------------------
IF NOT EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[FK_TRN_PRODUCT_SELL_DT_CAT_STALLS]') AND type in (N'F'))
BEGIN
	ALTER TABLE [dbo].[TRN_PRODUCT_SELL_DT]  WITH CHECK ADD  CONSTRAINT [FK_TRN_PRODUCT_SELL_DT_CAT_STALLS] FOREIGN KEY([StallsID])
	REFERENCES [dbo].[CAT_STALLS] ([ID])
	ALTER TABLE [dbo].[TRN_PRODUCT_SELL_DT] CHECK CONSTRAINT [FK_TRN_PRODUCT_SELL_DT_CAT_STALLS]
END
GO
-----------------------------------------------------------------------------------------------------------------------------------------------------------
IF NOT EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[FK_TRN_PRODUCT_SELL_DT_OBJ_PRODUCT]') AND type in (N'F'))
BEGIN
	ALTER TABLE [dbo].[TRN_PRODUCT_SELL_DT]  WITH CHECK ADD  CONSTRAINT [FK_TRN_PRODUCT_SELL_DT_OBJ_PRODUCT] FOREIGN KEY([ProductID])
	REFERENCES [dbo].[OBJ_PRODUCT] ([ID])
	ALTER TABLE [dbo].[TRN_PRODUCT_SELL_DT] CHECK CONSTRAINT [FK_TRN_PRODUCT_SELL_DT_OBJ_PRODUCT]
END
GO
--=========================================================================================================================================================
-- SYS_COUNTER_STOCK
-----------------------------------------------------------------------------------------------------------------------------------------------------------
IF NOT EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[FK_SYS_COUNTER_STOCK_CAT_COUNTER]') AND type in (N'F'))
BEGIN
	ALTER TABLE [dbo].[SYS_COUNTER_STOCK]  WITH CHECK ADD  CONSTRAINT [FK_SYS_COUNTER_STOCK_CAT_COUNTER] FOREIGN KEY([CounterID])
	REFERENCES [dbo].[CAT_COUNTER] ([ID])
	ALTER TABLE [dbo].[SYS_COUNTER_STOCK] CHECK CONSTRAINT [FK_SYS_COUNTER_STOCK_CAT_COUNTER]
END
GO
-----------------------------------------------------------------------------------------------------------------------------------------------------------
IF NOT EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[FK_SYS_COUNTER_STOCK_CAT_CURRENCY]') AND type in (N'F'))
BEGIN
	ALTER TABLE [dbo].[SYS_COUNTER_STOCK]  WITH CHECK ADD  CONSTRAINT [FK_SYS_COUNTER_STOCK_CAT_CURRENCY] FOREIGN KEY([CurrencyID])
	REFERENCES [dbo].[CAT_CURRENCY] ([ID])
	ALTER TABLE [dbo].[SYS_COUNTER_STOCK] CHECK CONSTRAINT [FK_SYS_COUNTER_STOCK_CAT_CURRENCY]
END
GO
--=========================================================================================================================================================
-- CAT_COUNTER_LOG
-----------------------------------------------------------------------------------------------------------------------------------------------------------
IF NOT EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[FK_CAT_COUNTER_LOG_CAT_COUNTER]') AND type in (N'F'))
BEGIN
	ALTER TABLE [dbo].[CAT_COUNTER_LOG]  WITH CHECK ADD  CONSTRAINT [FK_CAT_COUNTER_LOG_CAT_COUNTER] FOREIGN KEY([CounterID])
	REFERENCES [dbo].[CAT_COUNTER] ([ID])
	ALTER TABLE [dbo].[CAT_COUNTER_LOG] CHECK CONSTRAINT [FK_CAT_COUNTER_LOG_CAT_COUNTER]
END
GO
-----------------------------------------------------------------------------------------------------------------------------------------------------------
IF NOT EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[FK_CAT_COUNTER_LOG_CAT_EMPLOYEE]') AND type in (N'F'))
BEGIN
	ALTER TABLE [dbo].[CAT_COUNTER_LOG]  WITH CHECK ADD  CONSTRAINT [FK_CAT_COUNTER_LOG_CAT_EMPLOYEE] FOREIGN KEY([EmpID])
	REFERENCES [dbo].[CAT_EMPLOYEE] ([ID])
	ALTER TABLE [dbo].[CAT_COUNTER_LOG] CHECK CONSTRAINT [FK_CAT_COUNTER_LOG_CAT_EMPLOYEE]
END
GO