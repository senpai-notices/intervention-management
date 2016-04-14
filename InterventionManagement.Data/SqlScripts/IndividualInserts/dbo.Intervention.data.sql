SET IDENTITY_INSERT [dbo].[Intervention] ON
INSERT INTO [dbo].[Intervention] ([InterventionId], [DatePerformed], [InterventionStateId], [Name], [Hours], [Cost], [ProposerId], [ApproverId], [ClientId]) VALUES (7, N'2016-02-15', 1, N'Supply Mosquito Net', CAST(0 AS Decimal(18, 0)), CAST(25 AS Decimal(18, 0)), 1, NULL, 21)
INSERT INTO [dbo].[Intervention] ([InterventionId], [DatePerformed], [InterventionStateId], [Name], [Hours], [Cost], [ProposerId], [ApproverId], [ClientId]) VALUES (8, N'2016-02-16', 1, N'Prepare Sewerage Trench', CAST(50 AS Decimal(18, 0)), CAST(0 AS Decimal(18, 0)), 1, NULL, 21)
INSERT INTO [dbo].[Intervention] ([InterventionId], [DatePerformed], [InterventionStateId], [Name], [Hours], [Cost], [ProposerId], [ApproverId], [ClientId]) VALUES (9, N'2016-02-17', 1, N'Hepatitis Avoidance Training', CAST(3 AS Decimal(18, 0)), CAST(0 AS Decimal(18, 0)), 2, NULL, 23)
SET IDENTITY_INSERT [dbo].[Intervention] OFF
