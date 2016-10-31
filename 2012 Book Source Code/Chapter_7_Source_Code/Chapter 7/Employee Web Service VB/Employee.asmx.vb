Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.ComponentModel
Imports System.Data
Imports System.Web.Configuration
Imports System.Data.SqlClient

<System.Web.Services.WebService(Namespace:="http://tempuri.org/")> _
<System.Web.Services.WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<ToolboxItem(False)> _
Public Class Employee
    Inherits System.Web.Services.WebService

    <WebMethod()> _
    Public Function GetCost(ByVal employeeID As String, ByVal visitDate As DateTime) As Decimal

        Dim myConnection As New SqlConnection()
        myConnection.ConnectionString = WebConfigurationManager.ConnectionStrings("Pro_SSRS").ConnectionString

        Dim queryString As String = "EmpVisitCost"

        Dim command As New SqlCommand(queryString, myConnection)
        command.CommandType = CommandType.StoredProcedure
        command.Parameters.Add("@EmployeeID", SqlDbType.Char, 20).Value = employeeID
        command.Parameters.Add("@VisitDate", SqlDbType.DateTime).Value = visitDate

        Dim parameter As SqlParameter = New SqlParameter("@VisitCost", SqlDbType.Decimal)
        parameter.Direction = ParameterDirection.Output
        command.Parameters.Add(parameter)

        myConnection.Open()
        command.ExecuteNonQuery()

        Return Decimal.Parse(parameter.Value)

    End Function

End Class