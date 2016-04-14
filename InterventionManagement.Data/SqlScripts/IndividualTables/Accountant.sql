CREATE TABLE [dbo].[Accountant]
(
	[AccountantId] INT NOT NULL PRIMARY KEY, 
    CONSTRAINT [FK_Accountant_User] FOREIGN KEY ([AccountantId]) REFERENCES [User]([UserId]) 
)
