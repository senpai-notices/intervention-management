SET IDENTITY_INSERT [dbo].[District] ON
INSERT INTO [dbo].[District] ([DistrictId], [Name]) VALUES (1, N'UrbanIndonesia')
INSERT INTO [dbo].[District] ([DistrictId], [Name]) VALUES (2, N'RuralIndonesia')
INSERT INTO [dbo].[District] ([DistrictId], [Name]) VALUES (3, N'UrbanPapuaNewGuinea')
INSERT INTO [dbo].[District] ([DistrictId], [Name]) VALUES (4, N'RuralPapuaNewGuinea')
INSERT INTO [dbo].[District] ([DistrictId], [Name]) VALUES (5, N'Sydney')
SET IDENTITY_INSERT [dbo].[District] OFF

SET IDENTITY_INSERT [dbo].[InterventionState] ON
INSERT INTO [dbo].[InterventionState] ([InterventionStateId], [InterventionStateName]) VALUES (1, N'Proposed')
INSERT INTO [dbo].[InterventionState] ([InterventionStateId], [InterventionStateName]) VALUES (2, N'Approved')
INSERT INTO [dbo].[InterventionState] ([InterventionStateId], [InterventionStateName]) VALUES (3, N'Completed')
INSERT INTO [dbo].[InterventionState] ([InterventionStateId], [InterventionStateName]) VALUES (4, N'Cancelled')
SET IDENTITY_INSERT [dbo].[InterventionState] OFF

SET IDENTITY_INSERT [dbo].[User] ON
INSERT INTO [dbo].[User] ([UserId], [Username], [Password], [Name]) VALUES (1, N'alice@example.com', N'password', N'Alice Nelson')
INSERT INTO [dbo].[User] ([UserId], [Username], [Password], [Name]) VALUES (2, N'sam@example.com', N'password', N'Sam Franklin')
INSERT INTO [dbo].[User] ([UserId], [Username], [Password], [Name]) VALUES (3, N'george@example.com', N'password', N'George Glass')
INSERT INTO [dbo].[User] ([UserId], [Username], [Password], [Name]) VALUES (4, N'davy@example.com', N'password', N'Davy Jones')
INSERT INTO [dbo].[User] ([UserId], [Username], [Password], [Name]) VALUES (5, N'dena@example.com', N'password', N'Dena Dittmeyer')
INSERT INTO [dbo].[User] ([UserId], [Username], [Password], [Name]) VALUES (6, N'carol@example.com', N'password', N'Carol Brady')
SET IDENTITY_INSERT [dbo].[User] OFF

INSERT INTO [dbo].[Accountant] ([AccountantId]) VALUES (6)

INSERT INTO [dbo].[Manager] ([ManagerId], [HoursApprovalLimit], [CostApprovalLimit], [DistrictId]) VALUES (4, CAST(200 AS Decimal(18, 0)), CAST(50000 AS Decimal(18, 0)), 4)
INSERT INTO [dbo].[Manager] ([ManagerId], [HoursApprovalLimit], [CostApprovalLimit], [DistrictId]) VALUES (5, CAST(1000 AS Decimal(18, 0)), CAST(200000 AS Decimal(18, 0)), 5)

INSERT INTO [dbo].[Engineer] ([EngineerId], [HoursApprovalLimit], [CostApprovalLimit], [DistrictId]) VALUES (1, CAST(50 AS Decimal(18, 0)), CAST(2000 AS Decimal(18, 0)), 4)
INSERT INTO [dbo].[Engineer] ([EngineerId], [HoursApprovalLimit], [CostApprovalLimit], [DistrictId]) VALUES (2, CAST(100 AS Decimal(18, 0)), CAST(5200 AS Decimal(18, 0)), 4)
INSERT INTO [dbo].[Engineer] ([EngineerId], [HoursApprovalLimit], [CostApprovalLimit], [DistrictId]) VALUES (3, CAST(10 AS Decimal(18, 0)), CAST(10000 AS Decimal(18, 0)), 5)

SET IDENTITY_INSERT [dbo].[InterventionTemplate] ON
INSERT INTO [dbo].[InterventionTemplate] ([InterventionTemplateId], [Name], [Hours], [Cost]) VALUES (2, N'Supply and Install Portable Toilet', CAST(2 AS Decimal(18, 0)), CAST(600 AS Decimal(18, 0)))
INSERT INTO [dbo].[InterventionTemplate] ([InterventionTemplateId], [Name], [Hours], [Cost]) VALUES (3, N'Hepatitis Avoidance Training', CAST(3 AS Decimal(18, 0)), CAST(0 AS Decimal(18, 0)))
INSERT INTO [dbo].[InterventionTemplate] ([InterventionTemplateId], [Name], [Hours], [Cost]) VALUES (4, N'Supply and Install Storm-proof Home Kit', CAST(8 AS Decimal(18, 0)), CAST(500 AS Decimal(18, 0)))
INSERT INTO [dbo].[InterventionTemplate] ([InterventionTemplateId], [Name], [Hours], [Cost]) VALUES (5, N'Supply Mosquito Net', CAST(0 AS Decimal(18, 0)), CAST(25 AS Decimal(18, 0)))
INSERT INTO [dbo].[InterventionTemplate] ([InterventionTemplateId], [Name], [Hours], [Cost]) VALUES (6, N'Install Water Pump', CAST(80 AS Decimal(18, 0)), CAST(1200 AS Decimal(18, 0)))
INSERT INTO [dbo].[InterventionTemplate] ([InterventionTemplateId], [Name], [Hours], [Cost]) VALUES (7, N'Supply High-Volume Water Filter and Train Users', CAST(1 AS Decimal(18, 0)), CAST(2000 AS Decimal(18, 0)))
INSERT INTO [dbo].[InterventionTemplate] ([InterventionTemplateId], [Name], [Hours], [Cost]) VALUES (8, N'Prepare Sewerage Trench', CAST(50 AS Decimal(18, 0)), CAST(0 AS Decimal(18, 0)))
SET IDENTITY_INSERT [dbo].[InterventionTemplate] OFF

INSERT INTO [dbo].[Client] ([ClientId], [Name], [Location], [DistrictId]) VALUES (21, N'The Client', N'24 Main St, blue house', 4)
INSERT INTO [dbo].[Client] ([ClientId], [Name], [Location], [DistrictId]) VALUES (22, N'Community A', N'24 Big Rd, black house', 4)
INSERT INTO [dbo].[Client] ([ClientId], [Name], [Location], [DistrictId]) VALUES (23, N'UTS Students', N'Broadway, brown building', 5)

SET IDENTITY_INSERT [dbo].[Intervention] ON
INSERT INTO [dbo].[Intervention] ([InterventionId], [DatePerformed], [InterventionStateId], [Name], [Hours], [Cost], [ProposerId], [ApproverId], [ClientId]) VALUES (7, N'2016-02-15', 1, N'Supply Mosquito Net', CAST(0 AS Decimal(18, 0)), CAST(25 AS Decimal(18, 0)), 1, NULL, 21)
INSERT INTO [dbo].[Intervention] ([InterventionId], [DatePerformed], [InterventionStateId], [Name], [Hours], [Cost], [ProposerId], [ApproverId], [ClientId]) VALUES (8, N'2016-02-16', 1, N'Prepare Sewerage Trench', CAST(50 AS Decimal(18, 0)), CAST(0 AS Decimal(18, 0)), 1, NULL, 21)
INSERT INTO [dbo].[Intervention] ([InterventionId], [DatePerformed], [InterventionStateId], [Name], [Hours], [Cost], [ProposerId], [ApproverId], [ClientId]) VALUES (9, N'2016-02-17', 1, N'Hepatitis Avoidance Training', CAST(3 AS Decimal(18, 0)), CAST(0 AS Decimal(18, 0)), 2, NULL, 23)
SET IDENTITY_INSERT [dbo].[Intervention] OFF

SET IDENTITY_INSERT [dbo].[QualityReport] ON
INSERT INTO [dbo].[QualityReport] ([QualityReportId], [DateAdded], [Notes], [EffectiveLife], [InterventionId]) VALUES (1, N'2016-04-01', N'Notes!', CAST(90 AS Decimal(18, 0)), 7)
INSERT INTO [dbo].[QualityReport] ([QualityReportId], [DateAdded], [Notes], [EffectiveLife], [InterventionId]) VALUES (2, N'2016-04-02', N'Some notes!', CAST(75 AS Decimal(18, 0)), 8)
INSERT INTO [dbo].[QualityReport] ([QualityReportId], [DateAdded], [Notes], [EffectiveLife], [InterventionId]) VALUES (3, N'2016-04-03', N'Depreciation', CAST(60 AS Decimal(18, 0)), 7)
INSERT INTO [dbo].[QualityReport] ([QualityReportId], [DateAdded], [Notes], [EffectiveLife], [InterventionId]) VALUES (5, N'2016-04-04', N'Important notes', CAST(28 AS Decimal(18, 0)), 9)
SET IDENTITY_INSERT [dbo].[QualityReport] OFF
