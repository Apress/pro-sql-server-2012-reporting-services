USE [Pro_SSRS]
GO
/****** Object:  StoredProcedure [dbo].[Emp_Svc_Cost_Survey]    Script Date: 11/20/2011 7:35:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


ALTER PROCEDURE [dbo].[Emp_Svc_Cost_Survey] 
(
	@ServiceMonth Int = NULL
	, @ServiceYear Int = NULL
	, @BranchID Int = NULL
	, @EmployeeTblID Int = NULL
	, @ServicesLogCtgryID char(5) = NULL
	, @PatID int = NULL
)
AS
SET NOCOUNT ON
SELECT     
	T.PatID
	, RTRIM(RTRIM(P.LastName) + ',' + RTRIM(P.FirstName)) AS [Patient Name]
	, B.BranchName
	, E.EmployeeID 
	, RTRIM(RTRIM(E.LastName) + ',' + RTRIM(E.FirstName)) AS [Employee Name]
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
     Trx T
	 JOIN Branch B on T.Branchid = B.BranchID 
	 JOIN ChargeInfo CI ON T.ChargeInfoID = CI.ChargeInfoID 
     JOIN Patient P ON T.PatID = P.PatID 
	 JOIN Services S ON T.ServicesTblID = S.ServicesTblID 
	 JOIN ServicesLogCtgry SLC ON S.ServicesLogCtgryID = SLC.ServicesLogCtgryID 
	 JOIN Employee E ON CI.EmployeeTblID = E.EmployeeTblID 
	 JOIN Diag D ON CI.DiagTblID = D.DiagTblID  
WHERE
     (T.TrxTypeID = 1) 
	 AND (ISNULL(B.BranchID,0) = ISNULL(@BranchID,ISNULL(B.BranchID,0))) 
	 AND (ISNULL(T.PatID,0) = ISNULL(@PatID,ISNULL(T.PatID,0))) 
	 AND (ISNULL(S.ServicesLogCtgryID,0) = ISNULL(@ServicesLogCtgryID,
        ISNULL(S.ServicesLogCtgryID,0)))  
	 AND (ISNULL(E.EmployeeTblID,0) = ISNULL(@EmployeeTblID,
        ISNULL(E.EmployeeTblID,0))) AND

--Case to determine if Year and Month was passed in
     1=Case
          When ( @ServiceYear is  NULL) then 1
          When ( @ServiceYear is  NOT NULL)  
          AND @ServiceYear = Cast(DatePart(YY,T.ChargeServiceStartDate) as int)
Then 1
     ELSE 0
     End
AND 
     1=Case
          When (@ServiceMonth is NULL)  then 1     
          When (@ServiceMonth is NOT NULL)  
          AND @ServiceMonth = Cast(DatePart(MM,T.ChargeServiceStartDate) as int)
Then 1
     ELSE 0
     END
GROUP BY
     SLC.Service, 
     D.Dscr, 
     T.PatID, 
     B.BranchName,
     RTRIM(RTRIM(P.LastName) + ',' + RTRIM(P.FirstName)), 
     RTRIM(RTRIM(E.LastName)  + ',' + RTRIM(E.FirstName)),
     E.EmployeeClassid,
     E.EmployeeID, 
     DATENAME(mm, T.ChargeServiceStartDate), 
     DATEPART(yy, T.ChargeServiceStartDate),
     S.ServiceTypeID,
	 T.ChargeServiceStartDate
ORDER BY 
     T.PatID


