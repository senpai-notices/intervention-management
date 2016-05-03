/*
ENGINEER
*/

CREATE PROCEDURE [dbo].[GetEngineerByEngineerUsername]
	@username varchar(40)
AS
	SELECT * FROM [dbo].Engineer
	WHERE EngineerUsername = @username
GO

CREATE PROCEDURE [dbo].[InsertEngineer]
	@username varchar(40), @name varchar(100), @hours int, @cost int, @districtId int
AS
	BEGIN TRY

		BEGIN TRAN Main
	
		INSERT INTO [dbo].[User](Username, Name)
		VALUES(@username, @name)

		INSERT INTO [dbo].[Engineer](EngineerUsername, HoursApprovalLimit, CostApprovalLimit, DistrictId)
		VALUES(@username, @hours, @cost, @districtId)

		COMMIT TRAN Main
	END TRY
	BEGIN CATCH
		ROLLBACK TRAN Main
		PRINT 'InsertEngineer failed.'
	END CATCH
GO

CREATE PROCEDURE [dbo].[DeleteEngineer]
	@Original_Username varchar(40)
AS
	BEGIN TRY

		BEGIN TRAN Main

		DELETE FROM [dbo].[Engineer]
			WHERE (EngineerUsername = @Original_Username)
	
		DELETE FROM [dbo].[User]
			WHERE (Username = @Original_Username)

		COMMIT TRAN Main
	END TRY
	BEGIN CATCH
		ROLLBACK TRAN Main
		PRINT 'DeleteEngineer failed.'
	END CATCH
GO

/*
MANAGER
*/

/*
USER
*/

CREATE PROCEDURE [dbo].[GetUserByUsername]
	@username varchar(40)
AS
	SELECT * FROM [dbo].[User]
	WHERE Username = @username
GO

CREATE PROCEDURE [dbo].[InsertUser]
	@username varchar(40), @name varchar(100)
AS
	BEGIN TRY

		BEGIN TRAN Main
	
		INSERT INTO [dbo].[User](Username, Name)
		VALUES(@username, @name)

		COMMIT TRAN Main
	END TRY
	BEGIN CATCH
		ROLLBACK TRAN Main
		PRINT 'InsertUser failed.'
	END CATCH
GO

CREATE PROCEDURE [dbo].[DeleteUser]
	@Original_Username varchar(40)
AS
	BEGIN TRY

		BEGIN TRAN Main
	
		DELETE FROM [dbo].[User]
			WHERE (Username = @Original_Username)

		COMMIT TRAN Main
	END TRY
	BEGIN CATCH
		ROLLBACK TRAN Main
		PRINT 'DeleteUser failed.'
	END CATCH
GO

/*
CLIENT
*/

CREATE PROCEDURE [dbo].[GetClientById]
	@id INT
AS
	SELECT * FROM [dbo].[Client]
	WHERE ClientId = @id
GO

CREATE PROCEDURE [dbo].[InsertClient]
	@name VARCHAR(100), @location VARCHAR(150), @districtId INT
AS
	BEGIN TRY

		BEGIN TRAN Main

		SET NOCOUNT ON
	
		INSERT INTO [dbo].[Client](Name, Location, DistrictId)
		VALUES(@name, @location, @districtId)

		COMMIT TRAN Main
	END TRY
	BEGIN CATCH
		ROLLBACK TRAN Main
		PRINT 'InsertClient failed.'
	END CATCH
GO

CREATE PROCEDURE [dbo].[DeleteClient]
	@Original_Id INT
AS
	BEGIN TRY

		BEGIN TRAN Main
	
		DELETE FROM [dbo].[Client]
			WHERE (ClientId = @Original_Id)

		COMMIT TRAN Main
	END TRY
	BEGIN CATCH
		ROLLBACK TRAN Main
		PRINT 'DeleteClient failed.'
	END CATCH
GO

CREATE PROCEDURE [dbo].[GetClientByDistrictId]
	@DistrictId INT
AS
	SELECT * FROM [dbo].[Client]
	WHERE (DistrictId = @DistrictId)
GO