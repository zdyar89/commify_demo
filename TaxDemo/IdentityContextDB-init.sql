IF NOT EXISTS (
	SELECT name 
    FROM sys.databases 
    WHERE name = N'IdentityContext'
)
BEGIN 
	CREATE DATABASE IdentityContext;
END
GO

