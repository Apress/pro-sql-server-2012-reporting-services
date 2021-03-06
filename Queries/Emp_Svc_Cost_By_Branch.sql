USE Pro_SSRS
GO

IF EXISTS (SELECT name FROM sysobjects WHERE name = 'Emp_Svc_Cost_By_Branch')
	DROP PROCEDURE Emp_Svc_Cost_By_Branch 
GO
CREATE PROCEDURE [dbo].[Emp_Svc_Cost_By_Branch]
(
	@ServiceMonth INT = NULL
	, @ServiceYear INT = NULL
)
AS 

SELECT     
	B.BranchName
	, B.State
	, B.Zip
	, T.ChargeServiceStartDate 
	, DATENAME(mm, T.ChargeServiceStartDate) AS [Month]
	, DATEPART(yy, T.ChargeServiceStartDate) AS [Year]
	, DATEPART(dd, T.ChargeServiceStartDate) AS [Day]
	, SUM(CI.Cost) AS [Estimated Cost]
	, COUNT(T.ServicesTblID) AS Visit_Count
FROM
	Trx AS T
	INNER JOIN Branch AS B ON T.Branchid = B.BranchID 
	INNER JOIN ChargeInfo AS CI ON T.ChargeInfoID = CI.ChargeInfoID 
	INNER JOIN Patient AS P ON T.PatID = P.PatID 
	INNER JOIN Services AS S ON T.ServicesTblID = S.ServicesTblID 
	INNER JOIN ServicesLogCtgry AS SLC ON S.ServicesLogCtgryID = 
	SLC.ServicesLogCtgryID 
	INNER JOIN Employee AS E ON CI.EmployeeTblID = E.EmployeeTblID 
	INNER JOIN Diag AS D ON CI.DiagTblID = D.DiagTblID  
WHERE
	--Case to determine if Year and Month was passed in
	1 = CASE
		WHEN (@ServiceYear IS NULL) THEN 1
		WHEN (@ServiceYear IS NOT NULL)  
		AND @ServiceYear = CAST(DATEPART(yy, ChargeServiceStartDate) AS INT)
		THEN 1 ELSE 0 END
	AND 
	1 = CASE
        WHEN (@ServiceMonth IS NULL)  THEN 1     
        WHEN (@ServiceMonth IS NOT NULL)  
        AND @ServiceMonth = CAST(DATEPART(mm, ChargeServiceStartDate) AS INT)
		THEN 1 ELSE 0 END
GROUP BY
	B.BranchName
	, B.State
	, B.Zip
	, T.ChargeServiceStartDate
	, DATENAME(mm, T.ChargeServiceStartDate) 
	, DATEPART(yy, T.ChargeServiceStartDate)
	, DATEPART(dd, T.ChargeServiceStartDate)
ORDER BY 
	B.BranchName
	, T.ChargeServiceStartDate

GO
