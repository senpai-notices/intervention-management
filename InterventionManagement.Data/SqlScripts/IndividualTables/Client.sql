CREATE TABLE [dbo].[Client]
(
	[ClientId] INT NOT NULL PRIMARY KEY, 
    [Name] VARCHAR(50) NOT NULL, 
    [Location] VARCHAR(100) NOT NULL, 
    [DistrictId] INT NOT NULL, 
    CONSTRAINT [FK_Client_District] FOREIGN KEY ([DistrictId]) REFERENCES [District]([DistrictId])
)
