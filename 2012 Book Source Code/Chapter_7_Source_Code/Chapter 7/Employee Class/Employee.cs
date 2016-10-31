using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Permissions;
using System.Data;


namespace Pro_SSRS
{
	public class Employee
	{
		public Employee()
		{
		}
		[PermissionSetAttribute(SecurityAction.Assert, Unrestricted = true)]
		public static decimal CostPerVisitXML(string employeeID, DateTime visitDate)
		{

			DataSet empDS = new DataSet();
			empDS.ReadXmlSchema(@"C:\Temp\EmployeePay.xsd");
			empDS.ReadXml(@"C:\Temp\EmployeePay.xml");
			DataRow[] empRows = empDS.Tables["EmployeePay"].Select("EmployeeID = '" + employeeID + "'");
			Decimal empAmt;
			if (empRows.Length > 0)
			{
				empAmt = Convert.ToDecimal(empRows[0]["Amount"]);
				return empAmt;
			}
			else
				return 0;

		}

		[PermissionSetAttribute(SecurityAction.Assert, Unrestricted = true)]
		public static decimal CostPerVisitWS(string employeeID, DateTime visitDate)
		{

			EmployeeWS.Employee empWS = new EmployeeWS.Employee();
			Decimal empAmt;
			empAmt = empWS.GetCost(employeeID, visitDate);
			return empAmt;

		}
	}
}
