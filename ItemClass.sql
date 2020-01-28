USE [BCErpDb]
GO

/****** Object:  StoredProcedure [dbo].[SpEditItemClass]    Script Date: 01/28/2020 20:05:26 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
Create PROCEDURE [dbo].[SpEditItemClass]
@Id int,@Code varchar(50),@Name nvarchar(50),
@ModifiedBy int,@Active bit
AS
BEGIN          
           UPDATE [Inventory].[TblItemClass]
           SET    [Code]=@Code,[Name]=@Name,
           [ModifiedOn]=GETDATE(),
           [ModifiedBy]=@ModifiedBy,[Active]=@Active
           where Id=@Id
END

GO
---------------------------------------------------------
USE [BCErpDb]
GO

/****** Object:  StoredProcedure [dbo].[SpCreateItemClass]    Script Date: 01/28/2020 20:05:36 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
Create PROCEDURE [dbo].[SpCreateItemClass]
@Code varchar(50),@Name nvarchar(50),
@CreatedBy int,@Active bit
AS
BEGIN
INSERT INTO [Inventory].[TblItemClass]
           ([Code],[Name],
            [CreatedOn],[CreatedBy],[Active])
     VALUES
           (@Code,@Name,GETDATE(),@CreatedBy,@Active)
END

GO
--------------------------------------------------------------------------

USE [BCErpDb]
GO

/****** Object:  StoredProcedure [dbo].[SpEditItemClass]    Script Date: 01/28/2020 20:05:26 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
Create PROCEDURE [dbo].[SpEditItemClass]
@Id int,@Code varchar(50),@Name nvarchar(50),
@ModifiedBy int,@Active bit
AS
BEGIN          
           UPDATE [Inventory].[TblItemClass]
           SET    [Code]=@Code,[Name]=@Name,
           [ModifiedOn]=GETDATE(),
           [ModifiedBy]=@ModifiedBy,[Active]=@Active
           where Id=@Id
END

GO
