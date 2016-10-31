USE Pro_SSRS
GO

IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.ROUTINES 
	WHERE ROUTINE_NAME = 'Emp_Svc_Cost'
	AND ROUTINE_SCHEMA = 'dbo')
	DROP PROCEDURE dbo.Emp_Svc_Cost 
GO

CREATE PROCEDURE [dbo].[Emp_Svc_Cost]
(
	@ServiceMonth INT = NULL
	, @ServiceYear INT = NULL
	, @BranchID INT = NULL
	, @EmployeeTblID INT = NULL
	, @ServicesLogCtgryID CHAR(5) = NULL
)
AS 
SELECT     
	T.PatID
	, RTRIM(RTRIM(P.LastName) + ', ' + RTRIM(P.FirstName)) AS [Patient Name]
	, B.BranchName
	, E.EmployeeID
	, RTRIM(RTRIM(E.LastName) + ', ' + RTRIM(E.FirstName)) AS [Employee Name]
	, E.EmployeeClassID
	, SLC.Service AS [Service Type]
	, SUM(CI.Cost) AS [Estimated Cost]
	, COUNT(T.ServicesTblID) AS Visit_Count
	, D.Dscr AS Diagnosis
	, DATENAME(mm, T.ChargeServiceStartDate) AS [Month]
	, DATEPART(yy, T.ChargeServiceStartDate) AS [Year]
	, S.ServiceTypeID
	, T.ChargeServiceStartDate 
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
    (T.TrxTypeID = 1) 
	AND (ISNULL(B.BranchID,0) = ISNULL(@BranchID,ISNULL(B.BranchID,0)))
	AND (ISNULL(S.ServicesLogCtgryID,0) = ISNULL(@ServicesLogCtgryID,
		ISNULL(S.ServicesLogCtgryID,0)))  
	AND (ISNULL(E.EmployeeTblID,0) = ISNULL(@EmployeeTblID,
        ISNULL(E.EmployeeTblID,0))) 
	AND
	--Determine if Year and Month was passed in
	((CAST(DATEPART(yy, T.ChargeServiceStartDate) AS INT) = @ServiceYear 
		AND @ServiceYear IS NOT NULL)
		OR @ServiceYear IS NULL)
	AND 
	((CAST(DATEPART(mm, T.ChargeServiceStartDate) AS INT) = @ServiceMonth 
		AND @ServiceMonth IS NOT NULL)
		OR @ServiceMonth IS NULL)
GROUP BY
	SLC.Service 
	, D.Dscr 
	, T.PatID
	, B.BranchName
	, RTRIM(RTRIM(P.LastName) + ', ' + RTRIM(P.FirstName))
	, RTRIM(RTRIM(E.LastName)  + ', ' + RTRIM(E.FirstName))
	, E.EmployeeClassid
	, E.EmployeeID
	, DATENAME(mm, T.ChargeServiceStartDate) 
	, DATEPART(yy, T.ChargeServiceStartDate)
	, S.ServiceTypeID
	, T.ChargeServiceStartDate
ORDER BY 
     T.PatID