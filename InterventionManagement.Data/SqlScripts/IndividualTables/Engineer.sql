CREATE TABLE [dbo].[Engineer]
(
	[EngineerId] INT NOT NULL PRIMARY KEY, 
    [HoursApprovalLimit] DECIMAL NOT NULL, 
    [CostApprovalLimit] DECIMAL NOT NULL, 
    [DistrictId] INT NOT NULL, 
    CONSTRAINT [FK_Engineer_User] FOREIGN KEY ([EngineerId]) REFERENCES [User]([UserId]), 
    CONSTRAINT [FK_Engineer_District] FOREIGN KEY ([DistrictId]) REFERENCES [District]([DistrictId])
)
