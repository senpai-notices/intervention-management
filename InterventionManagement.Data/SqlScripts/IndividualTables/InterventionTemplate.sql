CREATE TABLE [dbo].[InterventionTemplate]
(
	[InterventionTemplateId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] VARCHAR(50) NOT NULL, 
    [Hours] DECIMAL NOT NULL, 
    [Cost] DECIMAL NOT NULL
)
