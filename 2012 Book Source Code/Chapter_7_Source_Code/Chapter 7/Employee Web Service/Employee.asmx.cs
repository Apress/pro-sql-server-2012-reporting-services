using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Data;
using System.Web.Configuration;
using System.Data.SqlClient;

namespace Employee_Web_Service
{
    /// <summary>
    /// Summary description for Service1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    public class Employee : System.Web.Services.WebService
    {

        [WebMethod]
        public decimal GetCost(string employeeID, DateTime visitDate)
        {

            SqlConnection myConnection = new SqlConnection();
            myConnection.ConnectionString = WebConfigurationManager.ConnectionStrings["Pro_SSRS"].ConnectionString;
            
            string queryString = "EmpVisitCost";
            SqlCommand command = new SqlCommand(queryString, myConnection);
            
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@EmployeeID", SqlDbType.Char, 20).Value = employeeID;
            command.Parameters.Add("@VisitDate", SqlDbType.DateTime).Value = visitDate;
            
            SqlParameter parameter = new SqlParameter("@VisitCost", SqlDbType.Decimal);
            parameter.Direction = ParameterDirection.Output;
            command.Parameters.Add(parameter);
            
            myConnection.Open();
            command.ExecuteNonQuery();
            
            decimal cost = (decimal)parameter.Value;
            return cost;

        }
    }
}