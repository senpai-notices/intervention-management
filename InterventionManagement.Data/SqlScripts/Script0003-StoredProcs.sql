CREATE PROCEDURE [dbo].[GetEngineerByUsername]
	@username varchar(40)
AS
	SELECT * FROM [dbo].Engineer
	WHERE EngineerUsername like @username