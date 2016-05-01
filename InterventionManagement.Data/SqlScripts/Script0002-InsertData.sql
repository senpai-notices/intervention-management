SET IDENTITY_INSERT [dbo].[District] ON
INSERT INTO [dbo].[District] ([DistrictId], [Name]) VALUES (1, N'Urban Indonesia')
INSERT INTO [dbo].[District] ([DistrictId], [Name]) VALUES (2, N'Rural Indonesia')
INSERT INTO [dbo].[District] ([DistrictId], [Name]) VALUES (3, N'Urban Papua New Guinea')
INSERT INTO [dbo].[District] ([DistrictId], [Name]) VALUES (4, N'Rural Papua New Guinea')
INSERT INTO [dbo].[District] ([DistrictId], [Name]) VALUES (5, N'Sydney')
INSERT INTO [dbo].[District] ([DistrictId], [Name]) VALUES (6, N'Rural New South Wales')
SET IDENTITY_INSERT [dbo].[District] OFF

SET IDENTITY_INSERT [dbo].[InterventionState] ON
INSERT INTO [dbo].[InterventionState] ([InterventionStateId], [InterventionStateName]) VALUES (1, N'Proposed')
INSERT INTO [dbo].[InterventionState] ([InterventionStateId], [InterventionStateName]) VALUES (2, N'Approved')
INSERT INTO [dbo].[InterventionState] ([InterventionStateId], [InterventionStateName]) VALUES (3, N'Completed')
INSERT INTO [dbo].[InterventionState] ([InterventionStateId], [InterventionStateName]) VALUES (4, N'Cancelled')
SET IDENTITY_INSERT [dbo].[InterventionState] OFF

SET IDENTITY_INSERT [dbo].[InterventionTemplate] ON
INSERT INTO [dbo].[InterventionTemplate] ([InterventionTemplateId], [Name], [EstimatedHours], [EstimatedCost]) VALUES (2, N'Supply and Install Portable Toilet', CAST(2 AS Decimal(18, 0)), CAST(600 AS Decimal(18, 0)))
INSERT INTO [dbo].[InterventionTemplate] ([InterventionTemplateId], [Name], [EstimatedHours], [EstimatedCost]) VALUES (3, N'Hepatitis Avoidance Training', CAST(3 AS Decimal(18, 0)), CAST(0 AS Decimal(18, 0)))
INSERT INTO [dbo].[InterventionTemplate] ([InterventionTemplateId], [Name], [EstimatedHours], [EstimatedCost]) VALUES (4, N'Supply and Install Storm-proof Home Kit', CAST(8 AS Decimal(18, 0)), CAST(500 AS Decimal(18, 0)))
INSERT INTO [dbo].[InterventionTemplate] ([InterventionTemplateId], [Name], [EstimatedHours], [EstimatedCost]) VALUES (5, N'Supply Mosquito Net', CAST(0 AS Decimal(18, 0)), CAST(25 AS Decimal(18, 0)))
INSERT INTO [dbo].[InterventionTemplate] ([InterventionTemplateId], [Name], [EstimatedHours], [EstimatedCost]) VALUES (6, N'Install Water Pump', CAST(80 AS Decimal(18, 0)), CAST(1200 AS Decimal(18, 0)))
INSERT INTO [dbo].[InterventionTemplate] ([InterventionTemplateId], [Name], [EstimatedHours], [EstimatedCost]) VALUES (7, N'Supply High-Volume Water Filter and Train Users', CAST(1 AS Decimal(18, 0)), CAST(2000 AS Decimal(18, 0)))
INSERT INTO [dbo].[InterventionTemplate] ([InterventionTemplateId], [Name], [EstimatedHours], [EstimatedCost]) VALUES (8, N'Prepare Sewerage Trench', CAST(50 AS Decimal(18, 0)), CAST(0 AS Decimal(18, 0)))
SET IDENTITY_INSERT [dbo].[InterventionTemplate] OFF

SET IDENTITY_INSERT [dbo].[Client] ON
INSERT INTO [dbo].[Client] ([ClientId], [Name], [Location], [DistrictId]) VALUES (1, N'Jane Doe', N'1 Main Street, (Blue House)', 6)
INSERT INTO [dbo].[Client] ([ClientId], [Name], [Location], [DistrictId]) VALUES (2, N'Josiah and Ruth Family', N'1 Tropical Street', 3)
INSERT INTO [dbo].[Client] ([ClientId], [Name], [Location], [DistrictId]) VALUES (3, N'David Bowie', N'Cloud 1, Heaven', 5)
SET IDENTITY_INSERT [dbo].[Client] OFF

SET IDENTITY_INSERT [dbo].[Intervention] ON
INSERT INTO [dbo].[Intervention] ([InterventionId],	[InterventionTemplateId], [DatePerformed], [InterventionStateId], [Hours], [Cost], [ProposerId], [ApproverId], [ClientId], [Notes],	[RemainingLife], [DateOfLastVisit]) VALUES (1, 1, '2016-01-01', 1, CAST(25 AS Decimal(18, 0)), CAST(25 AS Decimal(18, 0)), 1, 1, 1, N'Example Intervention', 100, '2016-01-02')
SET IDENTITY_INSERT [dbo].[Intervention] OFF