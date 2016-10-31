/*====================================================
Author: Brian K. McDonald, MCDBA, MCSD
Purpose: 
	Sample script used in Pro_SSRS book for 
	various report examples.
====================================================*/
SET NOCOUNT ON 

--Declare Variables and set Sample Dates
DECLARE 
	@DateFrom DATE = '12/1/2007'
	, @DateTo DATE = '12/31/2011'

SELECT        
	RTRIM(E.EmployeeID) AS EmployeeID
	, E.LastName
	, E.FirstName
	, E.EmployeeTblID AS EmpTblID
	, E.EmploymentTypeID AS EmploymentType
	, E.HireDate
	, D.Dscr AS Discipline
	, P.LastName AS patLastName
	, P.FirstName AS patFirstName
	, T.ChargeServiceStartDate
	, D.DisciplineID
	, P.PatID
FROM            
	Trx AS T
	JOIN ChargeInfo AS CI ON T.ChargeInfoID = CI.ChargeInfoID 
	JOIN Employee AS E ON E.EmployeeTblID = CI.EmployeeTblID 
	JOIN Discipline AS D ON E.DisciplineTblID = D.DisciplineTblID 
	JOIN Patient AS P ON T.PatID = P.PatID
WHERE     
	(T.ChargeServiceStartDate BETWEEN @DateFrom AND @DateTo)