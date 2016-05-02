CREATE TABLE [dbo].[District]
(
	[DistrictId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] VARCHAR(100) NOT NULL
)

CREATE TABLE [dbo].[User]
(
    [Username] VARCHAR(40) NOT NULL PRIMARY KEY, 
    [Name] VARCHAR(100) NOT NULL 
)

CREATE TABLE [dbo].[Manager]
(
	[ManagerUsername] VARCHAR(40) NOT NULL PRIMARY KEY, 
    [HoursApprovalLimit] INT NOT NULL, 
    [CostApprovalLimit] INT NOT NULL, 
    [DistrictId] INT NOT NULL, 
    CONSTRAINT [FK_Manager_User] FOREIGN KEY ([ManagerUsername]) REFERENCES [User]([Username]), 
    CONSTRAINT [FK_Manager_District] FOREIGN KEY ([DistrictId]) REFERENCES [District]([DistrictId])
)

CREATE TABLE [dbo].[Engineer]
(
	[EngineerUsername] VARCHAR(40) NOT NULL PRIMARY KEY, 
    [HoursApprovalLimit] INT NOT NULL, 
    [CostApprovalLimit] INT NOT NULL, 
    [DistrictId] INT NOT NULL, 
    CONSTRAINT [FK_Engineer_User] FOREIGN KEY ([EngineerUsername]) REFERENCES [User]([Username]), 
    CONSTRAINT [FK_Engineer_District] FOREIGN KEY ([DistrictId]) REFERENCES [District]([DistrictId])
)

CREATE TABLE [dbo].[InterventionState]
(
	[InterventionStateId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [InterventionStateName] VARCHAR(100) NOT NULL
)

CREATE TABLE [dbo].[InterventionTemplate]
(
	[InterventionTemplateId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] VARCHAR(150) NOT NULL, 
    [EstimatedHours] INT NOT NULL, 
    [EstimatedCost] INT NOT NULL
)

CREATE TABLE [dbo].[Client]
(
	[ClientId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] VARCHAR(100) NOT NULL, 
    [Location] VARCHAR(150) NOT NULL, 
    [DistrictId] INT NOT NULL, 
    CONSTRAINT [FK_Client_District] FOREIGN KEY ([DistrictId]) REFERENCES [District]([DistrictId])
)

CREATE TABLE [dbo].[Intervention]
(
    [InterventionId] INT NOT NULL PRIMARY KEY IDENTITY,
	[InterventionTemplateId] INT NOT NULL,
    [DatePerformed] DATE NOT NULL,
    [InterventionStateId] INT NOT NULL,
    [Hours] INT NOT NULL,
    [Cost] INT NOT NULL,
    [ProposerUsername] VARCHAR(40) NOT NULL,
    [ApproverUsername] VARCHAR(40) NULL,
    [ClientId] INT NOT NULL,
	[Notes] VARCHAR(2000) NULL,
	[RemainingLife] INT NOT NULL,
	[DateOfLastVisit] DATE NULL,
	CONSTRAINT [FK_Intervention_InterventionTemplate] FOREIGN KEY ([InterventionTemplateId]) REFERENCES [dbo].[InterventionTemplate] ([InterventionTemplateId]),
    CONSTRAINT [FK_Intervention_InterventionState] FOREIGN KEY ([InterventionStateId]) REFERENCES [dbo].[InterventionState] ([InterventionStateId]),
    CONSTRAINT [FK_Intervention_Proposer] FOREIGN KEY ([ProposerUsername]) REFERENCES [dbo].[Engineer] ([EngineerUsername]),
    CONSTRAINT [FK_Intervention_Approver] FOREIGN KEY ([ApproverUsername]) REFERENCES [dbo].[Manager] ([ManagerUsername]),
    CONSTRAINT [FK_Intervention_Client] FOREIGN KEY ([ClientId]) REFERENCES [dbo].[Client] ([ClientId])
);