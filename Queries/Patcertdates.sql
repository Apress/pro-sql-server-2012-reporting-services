CREATE PROCEDURE [dbo].[PatRecertListing_SelectReport]

@BranchID int=NULL,

@DateFrom datetime= Null,
@DateTo datetime=Null


 AS




SELECT        Patient.PatID, Patient.LastName, Patient.FirstName, PatCertDates.CertStart, PatCertDates.CertEnd, DocumentType.Dscr as [Document Type],
                      Patient.MedicareNum, Patient.MedicaidNum, PatCertDates.DatePrinted, Branch.BranchName,
                      PatCertDates.DateSentToPhysician, PatCertDates.DateRcvdFromPhysician, PatCertDates.DocumentTypeID
	        
FROM         PatCertDates inner JOIN
                      Admissions ON PatCertDates.PatProgramID =Admissions.PatProgramID inner JOIN
	        DocumentType on patcertdates.documenttypeid = documenttype.documenttypeid inner Join
                      Patient ON Admissions.PatID = Patient.PatID inner JOIN
                      
                      
                      Branch ON Patient.OrigBranchID = Branch.BranchID
                      
--inner Join
	         --PatPhysician on patcertdates.patprogramid = patphysician.patprogramid inner  Join
	         --Physician on patphysician.physicianid = physician.physicianid
WHERE     



	(isnull(Branch.BranchID,0) = isnull(@BranchID,isnull(Branch.BranchID,0)))
	AND
PatCertDates.CertEnd between @DateFrom and @DateTo and 
Admissions.DischargeDate IS NULL And





1=Case
		When ( @DateFrom is  NULL) then 1
		When ( @DateFrom is  NOT NULL)  AND CertEnd > @DateFrom  then 1
	else 0
	End AND
1=Case
		When ( @DateTo is  NULL) then 1
		When ( @DateTo is  NOT NULL)  AND CertEnd < @DateTo  then 1
	else 0
	End



GO
