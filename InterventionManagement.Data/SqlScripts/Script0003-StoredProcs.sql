CREATE PROCEDURE [dbo].[GetEngineerByEngineerUsername]
	@username varchar(40)
AS
	SELECT * FROM [dbo].Engineer
	WHERE EngineerUsername like @username