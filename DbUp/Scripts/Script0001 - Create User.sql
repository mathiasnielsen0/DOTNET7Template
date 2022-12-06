CREATE TABLE [dbo].[Bruger]
    ADD [ID] INT NOT NULL IDENTITY(1,1), 
    [Navn] NVARCHAR(255) NOT NULL,
    [Email] NVARCHAR(255) NOT NULL,
    [ResetPasswordGuid] UUID NULL,
    [PasswordHash] NVARCHAR(255) NOT NULL,
    [Salt] NVARCHAR(255) NOT NULL,
    [Administrator] BIT NOT NULL DEFAULT 0,
    