CREATE TABLE [dbo].[Manager]
(
	[ManagerId] INT NOT NULL PRIMARY KEY, 
    [HoursApprovalLimit] DECIMAL NOT NULL, 
    [CostApprovalLimit] DECIMAL NOT NULL, 
    [DistrictId] INT NOT NULL, 
    CONSTRAINT [FK_Manager_User] FOREIGN KEY ([ManagerId]) REFERENCES [User]([UserId]), 
    CONSTRAINT [FK_Manager_District] FOREIGN KEY ([DistrictId]) REFERENCES [District]([DistrictId])
)
