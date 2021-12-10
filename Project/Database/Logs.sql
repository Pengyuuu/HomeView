CREATE TABLE [dbo].[Logs]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [timestamp] NCHAR(10) NULL, 
    [level] NCHAR(10) NULL, 
    [user] NCHAR(10) NULL, 
    [category] NCHAR(10) NULL, 
    [description] NCHAR(10) NULL
)
