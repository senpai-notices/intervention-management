﻿CREATE TABLE [dbo].[User]
(
	[UserId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Username] VARCHAR(50) NOT NULL, 
    [Password] VARCHAR(200) NOT NULL, 
    [Name] VARCHAR(50) NOT NULL 
)