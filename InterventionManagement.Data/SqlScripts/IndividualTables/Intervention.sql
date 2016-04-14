CREATE TABLE [dbo].[Intervention] (
    [InterventionId]      INT          IDENTITY (1, 1) NOT NULL,
    [DatePerformed]       DATE         NOT NULL,
    [InterventionStateId] INT          NOT NULL,
    [Name]                VARCHAR (50) NOT NULL,
    [Hours]               DECIMAL (18) NOT NULL,
    [Cost]                DECIMAL (18) NOT NULL,
    [ProposerId]          INT          NOT NULL,
    [ApproverId]          INT          NULL,
    [ClientId]            INT          NOT NULL,
    PRIMARY KEY CLUSTERED ([InterventionId] ASC),
    CONSTRAINT [FK_Intervention_InterventionState] FOREIGN KEY ([InterventionStateId]) REFERENCES [dbo].[InterventionState] ([InterventionStateId]),
    CONSTRAINT [FK_Intervention_UserProposer] FOREIGN KEY ([ProposerId]) REFERENCES [dbo].[User] ([UserId]),
    CONSTRAINT [FK_Intervention_UserApprover] FOREIGN KEY ([ApproverId]) REFERENCES [dbo].[User] ([UserId]),
    CONSTRAINT [FK_Intervention_Client] FOREIGN KEY ([ClientId]) REFERENCES [dbo].[Client] ([ClientId])
);

