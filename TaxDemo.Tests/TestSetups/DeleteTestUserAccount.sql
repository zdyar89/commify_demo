DECLARE @User VARCHAR(50) = @UserParam;

BEGIN
	DELETE FROM dbo.AspNetUsers
	WHERE UserName = @User;
END