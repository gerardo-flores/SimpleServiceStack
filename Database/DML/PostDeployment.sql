/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/


-- verify that at least one login/user is bound to the AppServer role
-- if not, add all non-db_owner users for the db to ensure the IIS sql user has the proper permissions
IF NOT EXISTS (SELECT [name] FROM [sys].[sysusers] INNER JOIN [sys].[sysmembers] ON [islogin] = 1 and [hasdbaccess] = 1 AND [uid] = [memberuid] AND USER_NAME([groupuid]) = 'AppServer')
BEGIN
  PRINT 'The [AppServer] role is empty; adding all non-DBO users to the role.'

  DECLARE @name SYSNAME
  DECLARE c CURSOR STATIC FOR
  SELECT [name] FROM [sys].[sysusers] WHERE [islogin] = 1 and [hasdbaccess] = 1 and IS_ROLEMEMBER('db_owner', [name]) = 0

  OPEN c

  FETCH NEXT FROM c INTO @name
  WHILE @@FETCH_STATUS = 0
  BEGIN
    EXEC sp_addrolemember N'AppServer', @name
    PRINT 'Added user [' + @name + '] to role [AppServer]'
    FETCH NEXT FROM c INTO @name
  END

  CLOSE c
  DEALLOCATE c
END

-- for dev environments add the IIS sql login to the app server role
IF USER_ID('aspnet_wp') IS NOT NULL
BEGIN
  EXEC sp_addrolemember N'AppServer', N'aspnet_wp';
END