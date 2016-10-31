Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.Security.Permissions
Imports System.Data

Public Class Employee

    <PermissionSetAttribute(SecurityAction.Assert, Unrestricted:=True)>
    Public Shared Function CostPerVisitXML(ByVal employeeID As String, ByVal visitDate As DateTime) As Decimal
        Dim empDS As New DataSet()

        empDS.ReadXmlSchema("C:\Temp\EmployeePay.xsd")
        empDS.ReadXml("C:\Temp\EmployeePay.xml")

        Dim empRows() As DataRow = empDS.Tables("EmployeePay").Select("EmployeeID = '" + employeeID + "'")
        Dim empAmt As Decimal

        If (empRows.Length > 0) Then
            empAmt = Convert.ToDecimal(empRows(0)("Amount"))
            Return empAmt
        Else
            Return 0
        End If

    End Function

    <PermissionSetAttribute(SecurityAction.Assert, Unrestricted:=True)>
    Public Shared Function CostPerVisitWS(ByVal employeeID As String, ByVal visitDate As DateTime) As Decimal
        Dim empWS As New EmployeeWS.Employee()
        Dim empAmt As Decimal

        empAmt = empWS.GetCost(employeeID, visitDate)
        Return empAmt
    End Function



End Class
