USE Pro_SSRS
GO

IF EXISTS (SELECT name FROM sysobjects WHERE name = 'Emp_Svc_Cost_Indicator')
	DROP PROCEDURE Emp_Svc_Cost_Indicator 
GO
CREATE PROCEDURE [dbo].[Emp_Svc_Cost_Indicator]   
(
	@ServiceYear INT = NULL
)
AS 

BEGIN
WITH cte_Indicator
AS
(
SELECT
	MONTH(T.ChargeServiceStartDate) AS [MonthNumber]
	, DATENAME(mm, T.ChargeServiceStartDate) AS [Month]
	, DATEPART(yy, T.ChargeServiceStartDate) AS [Year]   
	, SUM(CI.Cost) AS [Estimated Cost]
	, COUNT(T.ServicesTblID) AS Visit_Count
FROM
	(SELECT ChargeServiceStartDate, Branchid, PatID
	, ServicesTblID, ChargeInfoID  
	FROM Trx
	WHERE TrxTypeID = 1 
	AND ChargeServiceStartDate BETWEEN '9/1/2009' AND '12/31/2009') AS T
	INNER JOIN Branch AS B ON T.Branchid = B.BranchID 
	INNER JOIN ChargeInfo AS CI ON T.ChargeInfoID = CI.ChargeInfoID 
	INNER JOIN Patient AS P ON T.PatID = P.PatID 
	INNER JOIN Services AS S ON T.ServicesTblID = S.ServicesTblID 
	INNER JOIN ServicesLogCtgry AS SLC ON S.ServicesLogCtgryID = 
	SLC.ServicesLogCtgryID 
	INNER JOIN Employee AS E ON CI.EmployeeTblID = E.EmployeeTblID 
	INNER JOIN Diag AS D ON CI.DiagTblID = D.DiagTblID  
WHERE
	1 = CASE
		WHEN (@ServiceYear IS NULL) THEN 1
		WHEN (@ServiceYear IS NOT NULL)  
		AND @ServiceYear = CAST(DATEPART(yy, ChargeServiceStartDate) AS INT)
		THEN 1 ELSE 0 END
GROUP BY
	MONTH(T.ChargeServiceStartDate)
	, DATENAME(mm, T.ChargeServiceStartDate)
	, DATEPART(yy, T.ChargeServiceStartDate)
)

SELECT 
	cm.*
	, pm.Visit_Count AS Prior_Month_Visit_Count 
	, cm.Visit_Count - pm.Visit_Count AS Diff
FROM 
	cte_Indicator cm
	LEFT JOIN cte_Indicator pm ON pm.MonthNumber = cm.MonthNumber-1
ORDER BY 
	cm.[MonthNumber], cm.[Year]
;
END

GO

EXEC [Emp_Svc_Cost_Indicator]
