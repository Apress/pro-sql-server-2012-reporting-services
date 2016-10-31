With Visit_CTE (Visit_Count,Service_Type,Diagnosis)
AS

(SELECT     SUM(ChargeInfo.Quantity) AS Visit_Count, Services.Dscr AS Service_Type, Diag.Dscr AS Diagnosis
FROM         Trx INNER JOIN
                      Services ON Trx.ServicesTblID = Services.ServicesTblID INNER JOIN
                      ChargeInfo ON Trx.ChargeInfoID = ChargeInfo.ChargeInfoID INNER JOIN
                      Diag ON ChargeInfo.DiagTblID = Diag.DiagTblID
WHERE     (Services.ServiceTypeID = 'V')
GROUP BY Services.Dscr, Diag.Dscr)
select * from Visit_CTE where Visit_Count > 20
order by visit_count desc
