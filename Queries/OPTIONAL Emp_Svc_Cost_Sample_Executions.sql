EXEC [Emp_Svc_Cost] 09, 2009, NULL, NULL, NULL

--Alternate method of executing stored procedure by using parameter names
EXEC [Emp_Svc_Cost] 
	@ServiceMonth = 09
	, @ServiceYear = 2009
	, @BranchID = NULL
	, @EmployeeTblID = NULL
	, @ServicesLogCtgryID = NULL
