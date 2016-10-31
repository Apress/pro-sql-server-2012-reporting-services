SELECT     
     TOP 10 COUNT(DISTINCT Patient.PatID) AS [Patient Count]
	 , Diag.Dscr AS Diagnosis
FROM
     Admissions 
	 INNER JOIN Patient ON Admissions.PatID = Patient.PatID 
	 INNER JOIN PatDiag ON Admissions.PatProgramID = 
	 PatDiag.PatProgramID 
	 INNER JOIN Diag ON PatDiag.DiagTblID = Diag.DiagTblID
WHERE
     (Admissions.StartOfCare > GETDATE() - 120)
GROUP BY
      Diag.Dscr
ORDER BY
     COUNT(DISTINCT Patient.PatID) DESC
