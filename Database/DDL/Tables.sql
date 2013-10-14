-- =============================================
-- Script Template
-- =============================================

CREATE TABLE [dbo].[Players](
	[ID]	INT NOT NULL IDENTITY(1,1),
	[FirstName]	NVARCHAR(100), 
    [LastName] NVARCHAR(100) NULL, 
    [Email] NVARCHAR(255) NULL
);
GO