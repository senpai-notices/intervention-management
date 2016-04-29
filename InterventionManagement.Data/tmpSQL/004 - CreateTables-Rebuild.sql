
CREATE TABLE [dbo].[District]
(
	[DistrictId]	INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name]			VARCHAR(50) NOT NULL
)

CREATE TABLE [dbo].[Employee]
(
	[EmployeeId]			INT NOT NULL PRIMARY KEY, 
    [HoursApprovalLimit]	INT NOT NULL, 
    [CostApprovalLimit]		INT NOT NULL, 
    [DistrictId]			INT NOT NULL, 
    CONSTRAINT [FK_Employee_User]		FOREIGN KEY ([EmployeeId]) REFERENCES [Users]([Id]), 
    CONSTRAINT [FK_Employee_District]	FOREIGN KEY ([DistrictId]) REFERENCES [District]([DistrictId])
)

CREATE TABLE [dbo].[InterventionState]
(
	[InterventionStateId]		INT NOT NULL PRIMARY KEY IDENTITY, 
    [InterventionStateName]		VARCHAR(50) NOT NULL
)

CREATE TABLE [dbo].[InterventionType]
(
	[InterventionTypeId]	INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name]					VARCHAR(50) NOT NULL, 
    [Hours]					INT NOT NULL, 
    [Cost]					INT NOT NULL
)

CREATE TABLE [dbo].[Client]
(
	[ClientId]		INT NOT NULL PRIMARY KEY, 
    [Name]			VARCHAR(50) NOT NULL, 
    [Location]		VARCHAR(100) NOT NULL, 
    [DistrictId]	INT NOT NULL, 
    CONSTRAINT [FK_Client_District]		FOREIGN KEY ([DistrictId]) REFERENCES [District]([DistrictId])
)

CREATE TABLE [dbo].[Intervention] (
    [InterventionId]      INT          IDENTITY (1, 1) NOT NULL,
    [DatePerformed]       DATE         NOT NULL,
    [InterventionStateId] INT          NOT NULL,
    [Hours]               INT          NOT NULL,
    [Cost]                INT          NOT NULL,
    [ProposerId]          INT          NOT NULL,
    [ApproverId]          INT          NULL,
    [ClientId]            INT          NOT NULL,
    PRIMARY KEY CLUSTERED ([InterventionId] ASC),
    CONSTRAINT [FK_Intervention_InterventionState]	FOREIGN KEY ([InterventionStateId])	REFERENCES [dbo].[InterventionState] ([InterventionStateId]),
    CONSTRAINT [FK_Intervention_UserProposer]		FOREIGN KEY ([ProposerId])			REFERENCES [dbo].[Employee] ([EmployeeId]),
    CONSTRAINT [FK_Intervention_UserApprover]		FOREIGN KEY ([ApproverId])			REFERENCES [dbo].[Employee] ([EmployeeId]),
    CONSTRAINT [FK_Intervention_Client]				FOREIGN KEY ([ClientId])			REFERENCES [dbo].[Client] ([ClientId])
);

CREATE TABLE [dbo].[QualityReport]
(
	[QualityReportId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [DateAdded] DATE NOT NULL, 
    [Notes] VARCHAR(100) NOT NULL, 
    [EffectiveLife] INT NOT NULL, 
    [InterventionId] INT NOT NULL, 
    CONSTRAINT [FK_QualityReport_Intervention] FOREIGN KEY (InterventionId) REFERENCES [Intervention](InterventionId)
)
