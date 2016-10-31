Imports SSRS_Publisher_VB.SSRSWebService
Imports System.IO
Imports System.Text.RegularExpressions
Imports System.Web.Services.Protocols

Public Class Publisher
    Private rs As ReportingService2010

    Private Function GetRSURL() As String

        If (reportServer.Text.StartsWith("http://")) Then
            Return (reportServer.Text + "/reportserver/ReportService2010.asmx")
        Else
            Return ("http://" + reportServer.Text + "/reportserver/ReportService2010.asmx")
        End If

    End Function

    Private Sub getFolders_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles getFolders.Click
        ssrsFolders.Nodes.Clear()
        rs = New ReportingService2010()
        rs.Credentials = System.Net.CredentialCache.DefaultCredentials
        Dim items() As CatalogItem
        rs.Url = GetRSURL()

        Dim root As TreeNode = New TreeNode()
        root.Text = "Root"
        ssrsFolders.Nodes.Add(root)
        ssrsFolders.SelectedNode = ssrsFolders.TopNode

        '' Retrieve a list items from the server 
        Try
            items = rs.ListChildren("/", True)

            Dim j As Integer = 1

            '' Iterate through the list of items and find all of the folders and display them to the user
            For Each ci As CatalogItem In items

                If (ci.TypeName = "Folder") Then

                    Dim rx As Regex = New Regex("/")
                    Dim matchCnt As Integer
                    matchCnt = rx.Matches(ci.Path).Count

                    If (matchCnt > j) Then
                        ssrsFolders.SelectedNode = ssrsFolders.SelectedNode.LastNode
                        j = matchCnt
                    ElseIf (matchCnt < j) Then
                        ssrsFolders.SelectedNode = ssrsFolders.SelectedNode.Parent
                        j = matchCnt
                    End If

                    AddNode(ci.Name)
                End If

			Next

        Catch ex As SoapException
            MessageBox.Show(ex.Detail.InnerXml.ToString())
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

        '' Make sure the user can see that the root folder is selected by default
        ssrsFolders.HideSelection = False
    End Sub

    Private Sub AddNode(ByVal name As String)
        Dim newNode As TreeNode = New TreeNode(name)
        ssrsFolders.SelectedNode.Nodes.Add(newNode)
    End Sub

    Private Sub browseFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles browseFile.Click
        '' Get the full pathname from the treeview control
        Dim pathName As String = ssrsFolders.SelectedNode.FullPath

        If pathName = "Root" Then
            pathName = "/"
        Else
            '' Strip off the Root name from the path and correct the path separators for use with SRS
            pathName = pathName.Substring(4, pathName.Length - 4)
            pathName = pathName.Replace("\", "/")
        End If

        Dim definition() As Byte = Nothing
        Dim warnings() As Warning = Nothing
        Dim warningMsg As String = String.Empty

        Dim openFileDialog As OpenFileDialog
        openFileDialog = New OpenFileDialog()
        openFileDialog.Filter = "RDL files (*.rdl)|*.rdl|All files (*.*)|*.*"
        openFileDialog.FilterIndex = 1

        If openFileDialog.ShowDialog() = DialogResult.OK Then
            Try
                '' Read the file and put it into a byte array to pass to SRS
                Dim stream As FileStream = File.OpenRead(openFileDialog.FileName)
                ReDim definition(stream.Length)

                stream.Read(definition, 0, Integer.Parse(stream.Length))
                stream.Close()

            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try

            '' We are going to use the name of the rdl file as the name of our report
            Dim reportName As String = Path.GetFileNameWithoutExtension(openFileDialog.FileName)
            reportFile.Text = reportName

            Try
                rs.CreateCatalogItem("Report", reportName, pathName, True, definition, Nothing, warnings)
                If Not warnings Is Nothing Then
                    For Each warning As Warning In warnings
                        warningMsg += warning.Message + "\n"
                    Next
                    MessageBox.Show("Report creation failed with the following warnings:\n" + warningMsg)
                Else
                    MessageBox.Show(String.Format("Report: {0} created successfully with no warnings", reportName))
                End If

            Catch ex As SoapException
                MessageBox.Show(ex.Detail.InnerXml.ToString())
            End Try


        End If

    End Sub
End Class
