USE Pro_SSRS
GO
--Get_Image Dataset (Chapter 3: Implementing an Image)
SELECT        
	I.DocumentImage, D.Dscr, P.PatID, P.LastName, P.FirstName
	, P.Address1, P.State, P.Zip, P.City, P.DOB, P.DoNotResuscitate
	, I.DocumentLength
FROM            
	Patient AS P 
	INNER JOIN PatEMRDoc AS D ON P.PatID = D.PatID 
	INNER JOIN DocumentImage AS I ON D.DocumentImageID = I.DocumentImageID
WHERE        
	(I.UpdatedDate > '06/01/2011')