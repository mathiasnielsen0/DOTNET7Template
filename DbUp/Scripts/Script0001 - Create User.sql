CREATE TABLE [dbo].[User](
    
    [ID] INT NOT NULL IDENTITY(1,1), 
    [CreatedAt] [datetime2] NOT NULL,
    [CreatedBy] [nvarchar](255) NOT NULL,
    [UpdatedAt] [datetime2] NOT NULL,
    [UpdatedBy] [nvarchar](255) NOT NULL,
    
    [Name] NVARCHAR(255) NOT NULL,
    [Email] NVARCHAR(255) NOT NULL,
    [ResetPasswordGuid] UNIQUEIDENTIFIER NULL,
    [PasswordHash] [varbinary](max) NULL,
    [PasswordSalt] [varbinary](max) NULL,
    [Administrator] BIT NOT NULL DEFAULT 0   
)