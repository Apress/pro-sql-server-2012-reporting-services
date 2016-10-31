Public Class _Default
    Inherits System.Web.UI.Page

    Dim rs As SSRS_WebService.ReportingService2010 = Nothing

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            rs = New SSRS_WebService.ReportingService2010()
            rs.Credentials = System.Net.CredentialCache.DefaultCredentials

            Dim listItems() As SSRS_WebService.CatalogItem = rs.ListChildren("/Pro_SSRS/Chapter_7", False)
            For Each thisItem As SSRS_WebService.CatalogItem In listItems
                If thisItem.TypeName = "Report" Then
                    reportList.Items.Add(thisItem.Name)
                End If
            Next 
        Catch ex As Exception
            Response.Write(ex.Message)
        End Try
    End Sub

    Protected Sub renderReport_Click(ByVal sender As Object, ByVal e As EventArgs) Handles renderReport.Click
        reportViewerWeb.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Remote
        reportViewerWeb.ServerReport.ReportServerUrl = New Uri("http://localhost/reportserver/")
        reportViewerWeb.ServerReport.ReportPath = "/Pro_SSRS/Chapter_7/" + reportList.SelectedItem.Value
        reportViewerWeb.ServerReport.Refresh()
    End Sub
End Class