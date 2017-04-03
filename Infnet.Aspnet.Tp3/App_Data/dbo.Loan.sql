CREATE TABLE [dbo].[Loan]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [LoanDate] DATETIME NOT NULL, 
    [DevolutionDate] DATETIME NOT NULL, 
    [BookId] INT NOT NULL, 
    CONSTRAINT [FK_Loan_Book] FOREIGN KEY ([BookId]) REFERENCES [Books]([Id])
)
