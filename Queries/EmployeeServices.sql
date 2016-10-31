SELECT
	Trx.PatID
	, RTRIM(RTRIM(Patient.LastName) + ', ' + RTRIM(Patient.FirstName)) AS [Patient Name]
	, Employee.EmployeeID
	, RTRIM(RTRIM(Employee.LastName) + ', ' + RTRIM(Employee.FirstName)) AS [Employee Name]
	, ServicesLogCtgry.Service AS  [Service Type]
	, SUM(ChargeInfo.Cost) AS [Estimated Cost]
	, COUNT(Trx.ServicesTblID) AS Visit_Count
	, Diag.Dscr AS Diagnosis
	, DATENAME(mm, Trx.ChargeServiceStartDate) AS [Month]
	, DATEPART(yy, Trx.ChargeServiceStartDate) AS [Year]
	, Branch.BranchName AS Branch
FROM
	Trx 
	JOIN ChargeInfo ON Trx.ChargeInfoID = ChargeInfo.ChargeInfoID
	JOIN Patient ON Trx.PatID = Patient.PatID 
	JOIN Services ON Trx.ServicesTblID = Services.ServicesTblID 
	JOIN ServicesLogCtgry ON Services.ServicesLogCtgryID = ServicesLogCtgry.ServicesLogCtgryID 
	JOIN Employee ON ChargeInfo.EmployeeTblID = Employee.EmployeeTblID 
	JOIN Diag ON ChargeInfo.DiagTblID = Diag.DiagTblID 
	JOIN Branch ON TRX.BranchID = Branch.BranchID 
WHERE
	(Trx.TrxTypeID = 1) AND (Services.ServiceTypeID =   'v') 
GROUP BY
	ServicesLogCtgry.Service
	, Diag.Dscr
	, Trx.PatID
	, RTRIM(RTRIM(Patient.LastName) + ', ' + RTRIM(Patient.FirstName))
	, RTRIM(RTRIM(Employee.LastName)  +  ', ' + RTRIM(Employee.FirstName))
	, Employee.EmployeeID
	, DATENAME(mm, Trx.ChargeServiceStartDate)
	, DATEPART(yy, Trx.ChargeServiceStartDate)
	, Branch.BranchName 
ORDER BY
	Trx.PatID

