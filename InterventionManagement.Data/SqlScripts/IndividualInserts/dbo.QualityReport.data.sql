SET IDENTITY_INSERT [dbo].[QualityReport] ON
INSERT INTO [dbo].[QualityReport] ([QualityReportId], [DateAdded], [Notes], [EffectiveLife], [InterventionId]) VALUES (1, N'2016-04-01', N'Notes!', CAST(90 AS Decimal(18, 0)), 7)
INSERT INTO [dbo].[QualityReport] ([QualityReportId], [DateAdded], [Notes], [EffectiveLife], [InterventionId]) VALUES (2, N'2016-04-02', N'Some notes!', CAST(75 AS Decimal(18, 0)), 8)
INSERT INTO [dbo].[QualityReport] ([QualityReportId], [DateAdded], [Notes], [EffectiveLife], [InterventionId]) VALUES (3, N'2016-04-03', N'Depreciation', CAST(60 AS Decimal(18, 0)), 7)
INSERT INTO [dbo].[QualityReport] ([QualityReportId], [DateAdded], [Notes], [EffectiveLife], [InterventionId]) VALUES (5, N'2016-04-04', N'Important notes', CAST(28 AS Decimal(18, 0)), 9)
SET IDENTITY_INSERT [dbo].[QualityReport] OFF
