/*===========================================================================
Author:	Brian K. McDonald, MCDBA, MCSD

Purpose:
	This view was created to simplify the model creation and general usage
	for creating reports using Report Builder.
===========================================================================*/
USE Pro_SSRS
GO

IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'vw_Patient_Census')
	DROP VIEW dbo.vw_Patient_Census
GO
CREATE VIEW dbo.vw_Patient_Census
AS
SELECT     
	A.PatProgramID
	, E.EmployeeID
	, E.LastName AS Emp_LastName
	, E.FirstName AS Emp_Firstname
	, D2.Dscr AS Discipline
	, B.BranchName
	, P.PatID
	, P.LastName AS Pat_LastName
	, P.FirstName AS Pat_FirstName
	, D.DiagID
	, D.Dscr AS Diagnosis
	, PD.DiagOnset
	, PD.DiagOrder
	, A.StartOfCare
	, A.DischargeDate
	, P.MI
	, P.Address1
	, P.Address2
	, P.City
	, P.HomePhone
	, P.Zip
	, P.State
	, P.WorkPhone
	, P.DOB
	, P.SSN
	, P.Sex
	, P.RaceID
	, P.MaritalStatusID
	, EMR.DateEntered
	, EMR.Dscr AS EMR_Document
	, DS.Dscr AS [Discharge Reason]
	, DATEDIFF(dd, A.StartOfCare, A.DischargeDate) + 1 AS [Length of Stay]
FROM         
	Admissions AS A 
	INNER JOIN Patient AS P ON A.PatID = P.PatID 
	INNER JOIN Branch AS B ON B.BranchID = P.OrigBranchID 
	LEFT OUTER JOIN PatDiag AS PD ON A.PatProgramID = PD.PatProgramID 
	INNER JOIN Diag AS D ON PD.DiagTblID = D.DiagTblID 
	LEFT OUTER JOIN Employee AS E ON A.EmployeeTblID = E.EmployeeTblID 
	LEFT OUTER JOIN Discipline AS D2 ON D2.DisciplineTblID = E.DisciplineTblID 
	LEFT OUTER JOIN PatEMRDoc AS EMR ON A.PatProgramID = EMR.PatProgramID 
	LEFT OUTER JOIN DocumentImage AS DI ON DI.DocumentImageID = EMR.DocumentImageID 
	LEFT OUTER JOIN Dischg AS DS ON A.DischargeTblID = DS.DischgTblID
WHERE     
	(PD.DiagOrder = 1)
GO
