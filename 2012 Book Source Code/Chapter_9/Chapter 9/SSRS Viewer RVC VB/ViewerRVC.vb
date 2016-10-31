Imports Microsoft.Reporting.WinForms

Public Class ViewerRVC

    Private Sub ViewweRVC_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.reportViewer.RefreshReport()
    End Sub

    Private Sub runServer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles runServer.Click

        reportURL.Text = "/Pro_SSRS/Chapter_9/EmployeeServiceCost" '
        reportViewer.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Remote
        reportViewer.ServerReport.ReportServerUrl = New Uri("http://localhost/reportserver/")
        reportViewer.ServerReport.ReportPath = reportURL.Text
        reportViewer.RefreshReport()

    End Sub

    Private Sub runLocal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles runLocal.Click

        Dim empDS As New Employees()
        empDS.ReadXml("C:\Temp\EmployeePay.xml")
        reportViewer.ProcessingMode = ProcessingMode.Local
        reportViewer.LocalReport.ReportEmbeddedResource = "SSRS_Viewer_RVC_VB.EmployeePay.rdlc"
        reportViewer.LocalReport.DataSources.Add(New ReportDataSource("Employees_EmployeePay", empDS.Tables("EmployeePay")))
        reportViewer.RefreshReport()

    End Sub

    Private Sub getParameters_Click(sender As System.Object, e As System.EventArgs) Handles getParameters.Click

        reportURL.Text = "http://localhost/reportserver?/Pro_SSRS/Chapter_9/EmployeeServiceCost"
        Dim reportParameters = New GetParameters(reportURL.Text)

        If (reportParameters.ShowDialog() = DialogResult.OK) Then

            reportViewer.ProcessingMode = ProcessingMode.Remote
            reportViewer.ServerReport.ReportServerUrl = New Uri("http://localhost/reportserver/")
            reportViewer.ServerReport.ReportPath = "/Pro_SSRS/Chapter_9/EmployeeServiceCost"
            reportViewer.ServerReport.SetParameters(reportParameters.repParameters)
            reportViewer.ShowParameterPrompts = False
            reportViewer.RefreshReport()
        End If

    End Sub
End Class
