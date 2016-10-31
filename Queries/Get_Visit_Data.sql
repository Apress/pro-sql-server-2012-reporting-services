USE Pro_SSRS
GO

IF EXISTS (SELECT name FROM sysobjects WHERE name = 'Get_Visit_Data')
	DROP PROCEDURE Get_Visit_Data 
GO
CREATE PROCEDURE [dbo].[Get_Visit_Data]   
/*===================================================================
This stored procedure just generates sample data to be used to 
display year over year or month over month data.
===================================================================*/
AS

DECLARE @Indicator TABLE 
(
	ID TINYINT IDENTITY(1,1)
	, [Month_Number]	TINYINT
	, [Month_Name]	VARCHAR(15)
	, [Year] CHAR(4)
	, [Visit_Count] INT
)

INSERT INTO @Indicator ([Month_Number], [Month_Name], [Year], [Visit_Count])
VALUES 
	(1, 'January', '2007', 1534)
	, (2, 'February', '2007', 574)
	, (3, 'March', '2007', 3480)
	, (4, 'April', '2007', 3480)
	, (5, 'May', '2007', 3145)
	, (6, 'June', '2007', 3677)
	, (7, 'July', '2007', 136)
	, (8, 'August', '2007', 2346)
	, (9, 'September', '2007', 6321)
	, (10, 'October', '2007', 5354)
	, (11, 'November', '2007', 5354)
	, (12, 'December', '2007', 343)
	, (1, 'January', '2008', 3984)
	, (2, 'February', '2008', 4633)
	, (3, 'March', '2008', 2724)
	, (4, 'April', '2008', 4522)
	, (5, 'May', '2008', 7284)
	, (6, 'June', '2008', 5654)
	, (7, 'July', '2008', 1521)
	, (8, 'August', '2008', 9865)
	, (9, 'September', '2008',4835)
	, (10, 'October', '2008', 4744)
	, (11, 'November', '2008', 4594)
	, (12, 'December', '2008', 2351)
	, (1, 'January', '2009', 1234)
	, (2, 'February', '2009', 534)
	, (3, 'March', '2009', 2500)
	, (4, 'April', '2009', 3002)
	, (5, 'May', '2009', 3103)
	, (6, 'June', '2009', 3307)
	, (7, 'July', '2009', 2806)
	, (8, 'August', '2009', 2456)
	, (9, 'September', '2009', 4321)
	, (10, 'October', '2009', 6354)
	, (11, 'November', '2009', 6542)
	, (12, 'December', '2009', 1343)
	, (1, 'January', '2010', 4984)
	, (2, 'February', '2010', 3633)
	, (3, 'March', '2010', 2724)
	, (4, 'April', '2010', 6522)
	, (5, 'May', '2010', 1284)
	, (6, 'June', '2010', 1654)
	, (7, 'July', '2010', 4521)
	, (8, 'August', '2010', 4865)
	, (9, 'September', '2010',1835)
	, (10, 'October', '2010', 4877)
	, (11, 'November', '2010', 8794)
	, (12, 'December', '2010', 7451)

SELECT 
	i1.[Month_Number]
	, i1.[Month_Name]
	, i1.[Year]
	, i1.[Visit_Count]
	, i2.[Visit_Count] AS Prior_Month_Visit_Count 
	, i1.[Visit_Count] - i2.[Visit_Count] AS Diff
FROM 
	@Indicator i1
	LEFT JOIN @Indicator i2 ON i2.ID = i1.ID - 1
GO

EXEC Get_Visit_Data



