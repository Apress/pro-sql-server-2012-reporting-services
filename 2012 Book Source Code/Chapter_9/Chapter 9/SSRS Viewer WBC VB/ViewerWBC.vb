Public Class ViewerWBC

    Private Sub reportRun_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles reportRun.Click
        WebBrowser.Navigate(reportURL.Text)
    End Sub
End Class
