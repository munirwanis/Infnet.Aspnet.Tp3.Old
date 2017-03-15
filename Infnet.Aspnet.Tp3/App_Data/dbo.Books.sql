CREATE TABLE [dbo].[Books]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Title] VARCHAR(255) NOT NULL, 
    [Author] VARCHAR(255) NOT NULL, 
    [Publisher] VARCHAR(255) NOT NULL, 
    [Year] INT NOT NULL
)
