CREATE TABLE [dbo].[QualityReport]
(
	[QualityReportId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [DateAdded] DATE NOT NULL, 
    [Notes] VARCHAR(100) NOT NULL, 
    [EffectiveLife] DECIMAL NOT NULL, 
    [InterventionId] INT NOT NULL, 
    CONSTRAINT [FK_QualityReport_Intervention] FOREIGN KEY (InterventionId) REFERENCES [Intervention](InterventionId)
)
