SET IDENTITY_INSERT [dbo].[User] ON
INSERT INTO [dbo].[User] ([UserId], [Username], [Password], [Name]) VALUES (1, N'alice@example.com', N'password', N'Alice Nelson')
INSERT INTO [dbo].[User] ([UserId], [Username], [Password], [Name]) VALUES (2, N'sam@example.com', N'password', N'Sam Franklin')
INSERT INTO [dbo].[User] ([UserId], [Username], [Password], [Name]) VALUES (3, N'george@example.com', N'password', N'George Glass')
INSERT INTO [dbo].[User] ([UserId], [Username], [Password], [Name]) VALUES (4, N'davy@example.com', N'password', N'Davy Jones')
INSERT INTO [dbo].[User] ([UserId], [Username], [Password], [Name]) VALUES (5, N'dena@example.com', N'password', N'Dena Dittmeyer')
INSERT INTO [dbo].[User] ([UserId], [Username], [Password], [Name]) VALUES (6, N'carol@example.com', N'password', N'Carol Brady')
SET IDENTITY_INSERT [dbo].[User] OFF
