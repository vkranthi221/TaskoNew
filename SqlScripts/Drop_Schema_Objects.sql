DECLARE @dropSqlCommand NVARCHAR(max) 
DECLARE @schemaName NVARCHAR(100) 

SET @dropSqlCommand = '' 
SET @schemaName = 'dbo'

SELECT @dropSqlCommand = @dropSqlCommand + 'ALTER TABLE [' 
                         + Schema_name(fk.schema_id) + '].[' 
                         + Object_name(fk.parent_object_id) 
                         + '] DROP CONSTRAINT [' + fk.name + ']' + Char(13) 
FROM   sys.foreign_keys fk 
       JOIN sys.tables t 
         ON t.object_id = fk.referenced_object_id 
WHERE  t.schema_id = Schema_id(@schemaName) 
       AND fk.schema_id <> t.schema_id 
ORDER  BY fk.name DESC 

IF (@dropSqlCommand <> '') 
BEGIN
	PRINT N'Dropping FK constrains on PK...'
	PRINT @dropSqlCommand
	EXEC(@dropSqlCommand) 	
	PRINT N'Ok' + Char(13) 
	SET @dropSqlCommand = ''
END

SELECT @dropSqlCommand = @dropSqlCommand + 'ALTER TABLE [' 
                         + Schema_name(t.schema_id) + '].[' 
                         + Object_name(fk.parent_object_id) 
                         + '] DROP CONSTRAINT [' + fk.[name] + ']' 
                         + Char(13) 
FROM   sys.objects fk 
       JOIN sys.tables t 
         ON t.object_id = fk.parent_object_id 
WHERE  t.schema_id = Schema_id(@schemaName) 
       AND fk.type IN ( 'D', 'C', 'F' ) 

IF (@dropSqlCommand <> '') 
BEGIN
	PRINT N'Dropping FK constrains...'
	PRINT @dropSqlCommand
	EXEC(@dropSqlCommand) 	
	PRINT N'Ok' + Char(13) 
	SET @dropSqlCommand = ''
END
	   
SELECT @dropSqlCommand = @dropSqlCommand + 
	CASE WHEN SO.type='U' THEN 
		 'DROP TABLE [' + Schema_name(SO.schema_id) + '].[' + SO.[name] + ']' 
		 WHEN SO.type='V' THEN 
		 'DROP VIEW ['+ Schema_name(SO.schema_id) +'].['+ SO.[name] + ']' 
		 WHEN SO.type='P' THEN 
         'DROP PROCEDURE [' + Schema_name(SO.schema_id) + '].[' + SO.[name] + ']'
	     WHEN SO.type='TR' THEN 
         'DROP TRIGGER [' + Schema_name(SO.schema_id) + '].[' + SO.[name] + ']' 
		 WHEN SO.type IN ('FN', 'TF', 'IF', 'FS', 'FT') THEN 
		 'DROP FUNCTION [' + Schema_name(SO.schema_id) + '].[' + SO.[name] + ']' END + Char(13) 
FROM   sys.objects SO 
WHERE  SO.schema_id = Schema_id(@schemaName) 
AND SO.type IN ('FN', 'TF', 'TR', 'V', 'U', 'P') 
ORDER  BY CASE WHEN type IN ('FN', 'TF', 'P', 'IF', 'FS', 'FT') THEN 1 
               WHEN type = 'TR' THEN 2 
               WHEN type = 'V' THEN 3 
               WHEN type = 'U' THEN 4 
               ELSE 5 
           END 
SELECT @dropSqlCommand = @dropSqlCommand + 
     CASE WHEN SO.type='TT' THEN 
          'DROP TYPE [' + @schemaName + '].' + stt.name END + Char(13) 
FROM   sys.objects SO JOIN sys.table_types stt on stt.type_table_object_id = SO.object_id 
and stt.schema_id = Schema_id(@schemaName)

IF (@dropSqlCommand <> '') 
BEGIN
	PRINT N'Dropping database objects...'
	PRINT @dropSqlCommand
	EXEC(@dropSqlCommand) 	
	PRINT N'Ok' + Char(13) 
	SET @dropSqlCommand = ''
END
	
WHILE(EXISTS(SELECT 1 
               FROM   sys.database_principals 
               WHERE  name LIKE 'kfx%' 
                      AND type = 'R' 
                      AND is_fixed_role = 0) ) 
  BEGIN 
      DECLARE @RoleName SYSNAME 

      SET @RoleName = '' 
      SET @RoleName = (SELECT TOP(1) sys.database_principals.name 
                       FROM   sys.database_principals 
                       WHERE  name LIKE 'kfx%' 
                              AND type = 'R' 
                              AND is_fixed_role = 0) 

      DECLARE @RoleMemberName SYSNAME 
      DECLARE member_cursor CURSOR FOR 
        SELECT [name] 
        FROM   sys.database_principals 
        WHERE  principal_id IN (SELECT member_principal_id 
                                FROM   sys.database_role_members 
                                WHERE  role_principal_id IN 
                                       (SELECT principal_id 
                                        FROM   sys.database_principals 
                                        WHERE  [name] = @RoleName 
                                               AND type = 'R')) 

      OPEN member_cursor; 
      FETCH next FROM member_cursor INTO @RoleMemberName  

      WHILE @@FETCH_STATUS = 0 
        BEGIN 
            SET @dropSqlCommand = 'ALTER ROLE ' + Quotename(@RoleName, '[') 
                       + ' DROP MEMBER ' 
                       + Quotename(@RoleMemberName, '[') 

            IF (@dropSqlCommand <> '') 
			  BEGIN			
				EXEC(@dropSqlCommand) 	
				PRINT @dropSqlCommand	
			  END	

            FETCH next FROM member_cursor INTO @RoleMemberName 
        END; 

      CLOSE member_cursor; 
      DEALLOCATE member_cursor; 

      SET @dropSqlCommand = 'DROP ROLE' + Quotename(@RoleName, '[') 

      IF (@dropSqlCommand <> '') 
	    BEGIN			
			EXEC(@dropSqlCommand) 	
			PRINT @dropSqlCommand	
		END
  END 