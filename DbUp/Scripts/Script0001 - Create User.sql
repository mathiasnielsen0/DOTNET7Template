CREATE TABLE [dbo].[User](
    [ID] INT NOT NULL IDENTITY(1,1), 
    [Name] NVARCHAR(255) NOT NULL,
    [Email] NVARCHAR(255) NOT NULL,
    [ResetPasswordGuid] UNIQUEIDENTIFIER NULL,
    [PasswordHash] NVARCHAR(255) NOT NULL,
    [Salt] NVARCHAR(255) NOT NULL,
    [Administrator] BIT NOT NULL DEFAULT 0   
)