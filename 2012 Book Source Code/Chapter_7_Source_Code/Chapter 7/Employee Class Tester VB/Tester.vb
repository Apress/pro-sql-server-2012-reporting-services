Public Class Tester

    Private Sub xmlTest_Click(sender As System.Object, e As System.EventArgs) Handles xmlTest.Click
        Dim empID As String
        Dim visDate As DateTime

        Try
            empID = EmployeeID.Text
            visDate = Convert.ToDateTime(VisitDate.Text)
            EmployeePayAmt.Text = Employee_VB.Employee.CostPerVisitXML(empID, visDate).ToString("C")


        Catch ex As Exception
            Throw
        End Try
    End Sub

    Private Sub wsTest_Click(sender As System.Object, e As System.EventArgs) Handles wsTest.Click
        Dim empID As String
        Dim visDate As DateTime

        Try
            empID = EmployeeID.Text
            visDate = Convert.ToDateTime(VisitDate.Text)
            EmployeePayAmt.Text = Employee_VB.Employee.CostPerVisitWS(empID, visDate).ToString("C")
        Catch ex As Exception
            Throw
        End Try
    End Sub
End Class
