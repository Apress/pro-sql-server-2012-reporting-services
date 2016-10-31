

WITH cte_Visits
AS
(
	SELECT 
		YEAR(ChargeServiceStartDate) AS [Year]
		, COUNT(*) AS NumRecs
		, COUNT(DISTINCT ChargeServiceStartDate) AS NumDaysForPeriod
	FROM 
		Trx
	GROUP BY 
		YEAR(ChargeServiceStartDate)
)
SELECT NumRecs / NumDaysForPeriod AS [Average Visits Per Day]
FROM cte_Visits
WHERE [Year] = '2009'