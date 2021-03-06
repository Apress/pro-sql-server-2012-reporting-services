USE [Pro_SSRS]
GO


IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.ROUTINES 
	WHERE ROUTINE_NAME = 'Emp_Svc_Cost_By_Patient_State_RB3_Drill'
	AND ROUTINE_SCHEMA = 'dbo')
	DROP PROCEDURE [dbo].[Emp_Svc_Cost_By_Patient_State_RB3_Drill] 
GO


CREATE PROCEDURE [dbo].[Emp_Svc_Cost_By_Patient_State_RB3_Drill]
(

	@ServiceYear INT = 2009
	, @BranchState CHAR(2) = 'OH'
/*===========================================================================
Author:	Brian K. McDonald, MCDBA, MCSD
Purpose:
	The purpose of this script is to return a listing of Patient and Branch
	States along with Estimated Cost and Visit Count for each. This example
	will be used in Chapter 13 with Report Builder 3.0.
===========================================================================*/
)
AS 

SELECT     
	T.PatID
	, RTRIM(RTRIM(P.LastName) + ', ' + RTRIM(P.FirstName)) AS [Patient Name]
	, B.BranchName
	, S2.[StateName]
	, E.EmployeeID
	, RTRIM(RTRIM(E.LastName) + ', ' + RTRIM(E.FirstName)) AS [Employee Name]
	, E.EmployeeClassID
	, SLC.Service AS [Service Type]
	, SUM(CI.Cost) AS [Estimated Cost]
	, COUNT(T.ServicesTblID) AS Visit_Count
	, D.Dscr AS Diagnosis
	, S.ServiceTypeID
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
	INNER JOIN States AS S2 ON S2.StateAbbr = B.[State]
WHERE
    (T.TrxTypeID = 1) 
	AND B.[State] = @BranchState
	AND ((CAST(DATEPART(yy, T.ChargeServiceStartDate) AS INT) = @ServiceYear 
		AND @ServiceYear IS NOT NULL)
		OR @ServiceYear IS NULL)
GROUP BY
	SLC.Service 
	, D.Dscr 
	, T.PatID
	, B.BranchName
	, S2.[StateName]
	, RTRIM(RTRIM(P.LastName) + ', ' + RTRIM(P.FirstName))
	, RTRIM(RTRIM(E.LastName)  + ', ' + RTRIM(E.FirstName))
	, E.EmployeeClassid
	, E.EmployeeID
	, S.ServiceTypeID
ORDER BY 
     T.PatID
GO

EXEC Emp_Svc_Cost_By_Patient_State_RB3_Drill
