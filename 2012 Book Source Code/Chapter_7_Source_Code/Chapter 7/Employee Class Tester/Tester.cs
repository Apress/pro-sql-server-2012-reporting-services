using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Pro_SSRS
{
	public partial class Tester : Form
	{
		public Tester()
		{
			InitializeComponent();
		}

		private void xmlTest_Click(object sender, EventArgs e)
		{
			string employeeID;
			DateTime visitDate;
			try
			{
				employeeID = EmployeeID.Text;
				visitDate = Convert.ToDateTime(VisitDate.Text);
				EmployeePayAmt.Text = Employee.CostPerVisitXML(employeeID, visitDate).ToString("C");
			}
			catch (Exception)
			{
				throw;
			}
		}

		private void wsTest_Click(object sender, EventArgs e)
		{
			string employeeID;
			DateTime visitDate;
			try
			{
				employeeID = EmployeeID.Text;
				visitDate = Convert.ToDateTime(VisitDate.Text);
				EmployeePayAmt.Text = Employee.CostPerVisitWS(employeeID, visitDate).ToString("C");
			}
			catch (Exception)
			{
				throw;
			}
		}
	}
}