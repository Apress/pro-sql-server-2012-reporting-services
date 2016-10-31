SELECT     
	Trx.PatID
	, RTRIM(RTRIM(Patient.LastName) + ', ' + RTRIM(Patient.FirstName)) AS [Patient Name]
	, Employee.EmployeeID
	, RTRIM(RTRIM(Employee.LastName) + ', ' + RTRIM(Employee.FirstName)) AS [Employee Name]
	, Employee.EmployeeClassID
	, ServicesLogCtgry.Service AS [Service Type]
	, SUM(ChargeInfo.Cost) AS [Estimated Cost]
	, COUNT(Trx.ServicesTblID) AS Visit_Count
	, Diag.Dscr AS Diagnosis
	, DATENAME(mm, Trx.ChargeServiceStartDate) AS Month
	, DATEPART(yy, Trx.ChargeServiceStartDate) AS Year
	, Branch.BranchName AS Branch
FROM         
	Trx 
	INNER JOIN ChargeInfo ON Trx.ChargeInfoID = ChargeInfo.ChargeInfoID 
	INNER JOIN Patient ON Trx.PatID = Patient.PatID 
	INNER JOIN Services ON Trx.ServicesTblID = Services.ServicesTblID 
	INNER JOIN ServicesLogCtgry ON Services.ServicesLogCtgryID = ServicesLogCtgry.ServicesLogCtgryID 
	INNER JOIN Employee ON ChargeInfo.EmployeeTblID = Employee.EmployeeTblID 
	INNER JOIN Diag ON ChargeInfo.DiagTblID = Diag.DiagTblID 
	INNER JOIN Branch ON Trx.BranchID = Branch.BranchID
WHERE     
	(Trx.TrxTypeID = 1) 
	AND (Services.ServiceTypeID = 'v')
GROUP BY 
	ServicesLogCtgry.Service
	, Diag.Dscr
	, Trx.PatID
	, RTRIM(RTRIM(Patient.LastName) + ', ' + RTRIM(Patient.FirstName))
	, RTRIM(RTRIM(Employee.LastName) + ', ' + RTRIM(Employee.FirstName))
	, Employee.EmployeeID, DATENAME(mm, Trx.ChargeServiceStartDate)
	, DATEPART(yy, Trx.ChargeServiceStartDate)
	, Branch.BranchName
	, Employee.EmployeeClassID
ORDER BY 
	Trx.PatID