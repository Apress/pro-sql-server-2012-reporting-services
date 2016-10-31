CREATE PROCEDURE [DBO].[ChargeResponsibility_AR_Reports]         
@AcctPeriodYear  smallint=NULL,         
@AcctPeriodMonth int=NULL,                
@BranchID int=NULL,                      
@BillCodeRptCtgryID char(10)=NULL,             
@DateFrom datetime=Null,        
@DateTo datetime=NULL,        
@PatID integer=NULL        
        
As        
       
        
SELECT      
 Trx.PatID,        
 Trx.reversal,         
 rtrim(rtrim(patient.lastname) + ',' + rtrim(patient.firstname)) as [Patient],        
 rtrim(rtrim(Employee.lastname) + ',' + rtrim(Employee.firstname)) as [Employee],        
 Patient.MedicareNum,                        
 branch.branchname as Branch,             
 TRX.Amt,         
 ChargeInfo.Quantity,          
 ChargeInfo.Cost,         
Services.billcodeid as [Bill Code],        
 Services.DSCR as [Bill Code Description],        
Services.PPSDisciplineid,         
 ChargeInfo.StartTime,         
 ChargeInfo.ElapsedTime,        
  ChargeInfo.ExpectedAmt,         
  ChargeInfo.Miles,          
  ChargeInfo.TravelTime,         
  Trx.ChargeServiceStartDate,                
 Cast(DatePart(yyyy,ChargeServiceStartDate) as int) As AcctPeriodYear,        
 Cast(DatePart(mm,ChargeServiceStartDate) as smallint) As AcctPeriodMonth,        
 Trx.TrxTypeid,        
 Case TrxTypeID when 1 then 'Charge'        
 When 2 then 'Payment'        
 when 3 then 'Adjustment'        
 when 4 then 'Unapplied Payment'        
  end as [TRX Type]                             
FROM  TRX         
  Left Outer Join        
 ChargeInfo ON  Trx.ChargeInfoID =  ChargeInfo.ChargeInfoID Left Outer JOIN        
Services on trx.Servicestblid = Services.Servicestblid Inner JOIN         
 branch on trx.branchid = branch.branchid INNER JOIN   
  Patient  ON Patient.PatID =  trx.patid LEFT OUTER JOIN          
  employee on chargeinfo.employeetblid = employee.employeetblid         
 
WHERE          

 (isnull(Branch.BranchID,0) = isnull(@BranchID,isnull(Branch.BranchID,0))) AND       
 (isnull(Services.BillCodeRptCtgryID,0) = isnull(@BillCodeRptCtgryID, isnull(Services.BillCodeRptCtgryID,0)))  AND        
         
         
 1=Case        
  When ( @AcctPeriodYear is  NULL) then 1        
  When ( @AcctPeriodYear is  NOT NULL)  AND @AcctPeriodYear = Cast(DatePart(yyyy,ChargeServiceStartDate) as int)   then 1        
 else 0        
 End        
AND         
 1=Case        
  When (@AcctPeriodMonth is NULL)  then 1         
  When (@AcctPeriodMonth is NOT NULL)  AND @AcctPeriodMonth =Cast(DatePart(mm,ChargeServiceStartDate) as int) then 1        
 else 0        
 End AND        
1=Case        
  When ( @DateFrom is  NULL) then 1        
  When ( @DateFrom is  NOT NULL)  AND ChargeServiceStartDate > @DateFrom or ChargeServiceStartDate = @DateFrom  then 1        
 else 0        
 End AND        
1=Case        
  When ( @DateTo is  NULL) then 1        
  When ( @DateTo is  NOT NULL)  AND ChargeServiceStartDate < @DateTo or ChargeServiceStartDate = @DateTo  then 1        
 else 0        
 End AND        
        
1=Case        
  When ( @PatID is  NULL) then 1        
  When ( @PatID is  NOT NULL)  AND Patient.PatID = @PatID  then 1        
 else 0        
 End      
      
      
      
      
    
    
  





GO
