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

CREATE PROCEDURE [dbo].[UpdateEngineerDistrict]
	@username varchar(40), @targetDistrict INT
AS
	BEGIN TRY

		BEGIN TRAN Main

		SET NOCOUNT ON
	
		UPDATE [dbo].[Engineer]
		SET DistrictId = @targetDistrict
		WHERE (EngineerUsername = @username)

		COMMIT TRAN Main
	END TRY
	BEGIN CATCH
		ROLLBACK TRAN Main
		PRINT 'UpdateEngineerDistrict failed.'
	END CATCH
GO

/*
MANAGER
*/

CREATE PROCEDURE [dbo].[GetManagerByManagerUsername]
	@username varchar(40)
AS
	SELECT * FROM [dbo].Manager
	WHERE ManagerUsername = @username
GO

CREATE PROCEDURE [dbo].[InsertManager]
	@username varchar(40), @name varchar(100), @hours int, @cost int, @districtId int
AS
	BEGIN TRY

		BEGIN TRAN Main
	
		INSERT INTO [dbo].[User](Username, Name)
		VALUES(@username, @name)

		INSERT INTO [dbo].[Manager](ManagerUsername, HoursApprovalLimit, CostApprovalLimit, DistrictId)
		VALUES(@username, @hours, @cost, @districtId)

		COMMIT TRAN Main
	END TRY
	BEGIN CATCH
		ROLLBACK TRAN Main
		PRINT 'InsertManager failed.'
	END CATCH
GO

CREATE PROCEDURE [dbo].[DeleteManager]
	@Original_Username varchar(40)
AS
	BEGIN TRY

		BEGIN TRAN Main

		DELETE FROM [dbo].[Manager]
			WHERE (ManagerUsername = @Original_Username)
	
		DELETE FROM [dbo].[User]
			WHERE (Username = @Original_Username)

		COMMIT TRAN Main
	END TRY
	BEGIN CATCH
		ROLLBACK TRAN Main
		PRINT 'DeleteManager failed.'
	END CATCH
GO

CREATE PROCEDURE [dbo].[UpdateManagerDistrict]
	@username varchar(40), @targetDistrict INT
AS
	BEGIN TRY

		BEGIN TRAN Main

		SET NOCOUNT ON
	
		UPDATE [dbo].[Manager]
		SET DistrictId = @targetDistrict
		WHERE (ManagerUsername = @username)

		COMMIT TRAN Main
	END TRY
	BEGIN CATCH
		ROLLBACK TRAN Main
		PRINT 'UpdateManagerDistrict failed.'
	END CATCH
GO

/*
USER (Accountant)
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
	@districtId INT
AS
	SELECT * FROM [dbo].[Client]
	WHERE (DistrictId = @districtId)
GO

/*
INTERVENTION
*/

CREATE PROCEDURE [dbo].[GetInterventionById]
	@id INT
AS
	SELECT * FROM [dbo].[Intervention]
	WHERE InterventionId = @id
GO

CREATE PROCEDURE [dbo].[InsertIntervention]
	@templateId INT, @datePerformed DATE, @stateId INT, @hours INT, @cost INT, @proposerUser VARCHAR(40), @approverUser VARCHAR(40), @clientId INT, @notes VARCHAR(2000), @remainingLife INT, @dateOfLastVisit DATE

AS
	BEGIN TRY

		BEGIN TRAN Main

		SET NOCOUNT ON
	
		INSERT INTO [dbo].[Intervention](InterventionTemplateId, DatePerformed, InterventionStateId, Hours, Cost, ProposerUsername, ApproverUsername, ClientId, Notes, RemainingLife, DateOfLastVisit)

		VALUES(@templateId, @datePerformed, @stateId, @hours, @cost, @proposerUser, @approverUser, @clientId, @notes, @remainingLife, @dateOfLastVisit)

		COMMIT TRAN Main
	END TRY
	BEGIN CATCH
		ROLLBACK TRAN Main
		PRINT 'InsertIntervention failed.'
	END CATCH
GO

CREATE PROCEDURE [dbo].[DeleteIntervention]
	@Original_Id INT
AS
	BEGIN TRY

		BEGIN TRAN Main
	
		DELETE FROM [dbo].[Intervention]
			WHERE (InterventionId = @Original_Id)

		COMMIT TRAN Main
	END TRY
	BEGIN CATCH
		ROLLBACK TRAN Main
		PRINT 'DeleteIntervention failed.'
	END CATCH
GO

CREATE PROCEDURE [dbo].[GetInterventionByClientId]
	@clientId INT
AS
	SELECT * FROM [dbo].[Intervention]
	WHERE (ClientId = @clientId)
GO

CREATE PROCEDURE [dbo].[GetInterventionByProposerUser]
	@proposerUser VARCHAR(40)
AS
	SELECT * FROM [dbo].[Intervention]
	WHERE (ProposerUsername = @proposerUser)
GO

CREATE PROCEDURE [dbo].[GetInterventionByApproverUser]
	@approverUser VARCHAR(40)
AS
	SELECT * FROM [dbo].[Intervention]
	WHERE (ApproverUsername = @approverUser)
GO

CREATE PROCEDURE [dbo].[GetInterventionByProposed]
AS
	SELECT * FROM [dbo].[Intervention]
	WHERE (InterventionStateId = 1)
GO


CREATE PROCEDURE [dbo].[UpdateQualityManagement]
	@id INT, @notes VARCHAR(2000), @remainingLife INT
AS
	BEGIN TRY

		BEGIN TRAN Main

		SET NOCOUNT ON
	
		UPDATE [dbo].[Intervention]
		SET Notes = @notes, RemainingLife = @remainingLife
		WHERE (InterventionId = @id)

		COMMIT TRAN Main
	END TRY
	BEGIN CATCH
		ROLLBACK TRAN Main
		PRINT 'UpdateQualityManagement failed.'
	END CATCH
GO

/*this could also be used for approveintervention*/
CREATE PROCEDURE [dbo].[UpdateInterventionState]
	@id INT, @targetState INT
AS
	BEGIN TRY

		BEGIN TRAN Main

		SET NOCOUNT ON
	
		UPDATE [dbo].[Intervention]
		SET InterventionStateId = @targetState
		WHERE (InterventionId = @id)

		COMMIT TRAN Main
	END TRY
	BEGIN CATCH
		ROLLBACK TRAN Main
		PRINT 'UpdateInterventionState failed.'
	END CATCH
GO

/* BELOW are reports i havent implemented yet - VERY UNSURE if it works. also is it okay to use this in a TableView? */
/* these use joins, which i dont know much about. i just adapted it from an example. grand total and monthly total may use nesting? */
/*
CREATE PROCEDURE [dbo].[ReportTotalCostsByEngineer]
AS
	SELECT [dbo].[User].Name, SUM([dbo].[Intervention].Hours) AS TotalHours, SUM([dbo].[Intervention].Cost) AS TotalCost
	FROM ([dbo].[User]
	INNER JOIN [dbo].[Intervention]
	ON [dbo].[User].Username=[dbo].[Intervention].ProposerUsername)
	GROUP BY [dbo].[User].Name
	ORDER BY [dbo].[User].Name ASC
GO

CREATE PROCEDURE [dbo].[ReportAverageCostsByEngineer]
AS
	SELECT [dbo].[User].Name, AVG([dbo].[Intervention].Hours) AS AverageHours, AVG([dbo].[Intervention].Cost) AS AverageCost
	FROM ([dbo].[User]
	INNER JOIN [dbo].[Intervention]
	ON [dbo].[User].Username=[dbo].[Intervention].ProposerUsername)
	GROUP BY [dbo].[User].Name
	ORDER BY [dbo].[User].Name ASC
GO

CREATE PROCEDURE [dbo].[ReportCostsByDistrict]
AS
	SELECT [dbo].[District].Name, SUM([dbo].[Intervention].Hours) AS TotalHours, SUM([dbo].[Intervention].Cost) AS TotalCost
	FROM (([dbo].[District]
	INNER JOIN [dbo].[Intervention]
	ON [dbo].[District].DistrictId=[dbo].[Client].DistrictId)
	INNER JOIN [dbo].[Intervention]
	ON [dbo].[Intervention].DistrictId=[dbo].[Client].DistrictId)
	GROUP BY [dbo].[District].Name
	ORDER BY [dbo].[District].DistrictId ASC
	/* GRAND TOTAL CODE GOES HERE */
GO

CREATE PROCEDURE [dbo].[ReportMonthlyCostsForDistrict]
	@districtId INT
AS

GO
*/