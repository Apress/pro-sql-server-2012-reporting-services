USE Pro_SSRS
GO

--Query from text
SELECT DISTINCT 
	EmployeeTblid, Email, HWUserLogin, ActivityDate
FROM
	Employee E (NOLOCK) 
	JOIN Activity A (NOLOCK) ON E.EmployeeTblid = A.ProviderID 
WHERE
	E.Email IS NOT NULL
	AND A.ActivityDate BETWEEN GETDATE() AND GETDATE() + 1


/*====================================================================================================
Author: Brian K. McDonald, MCDBA, MCSD
Purpose:
	- This script can be used for the data driven subscription example provided in Chapter 10.
	- The script gets the maximum date in the Activity table and returns records for that date.
	- In a real world scenario where you need to get yesterday's data, you would use the script
	provided in the text which utilizes the GETDATE() and GETDATE() + 1
===================================================================================================*/
/*


DECLARE @MaxDate DATE
SET @MaxDate =	(SELECT MAX(ActivityDate) FROM Employee E (NOLOCK)
				INNER JOIN Activity A (NOLOCK) ON E.EmployeeTblID = A.ProviderID
				WHERE Email IS NOT NULL)


SELECT DISTINCT 
	EmployeeTblID
	, Email
	, HWUserLogin
	, ActivityDate 
FROM
	Employee E (NOLOCK)
	JOIN Activity A (NOLOCK) ON E.EmployeeTblID = A.ProviderID
WHERE
	Email IS NOT NULL 
	AND ActivityDate BETWEEN @MaxDate AND DATEADD(dd, 1, @MaxDate)



*/

