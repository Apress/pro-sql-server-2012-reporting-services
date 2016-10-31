Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports System.Web.Services.Protocols
Imports System.Collections
Imports SSRS_Viewer_RVC_VB.SSRSWebSerivce

Public Class GetParameters

    Private url As String
    Private server As String
    Private report As String
    Private parameters() As Microsoft.Reporting.WinForms.ReportParameter
    Dim rs As ReportingService2010

    Public Sub New(ByVal repurl As String)
        InitializeComponent()

        url = repurl
        Dim reportInfo() As String = url.Split("?")
        server = reportInfo(0)
        report = reportInfo(1)

    End Sub

    Public ReadOnly Property repParameters() As Microsoft.Reporting.WinForms.ReportParameter()
        Get
            Return parameters
        End Get
    End Property

    Private Sub GetParameters_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        rs = New ReportingService2010()
        rs.Credentials = System.Net.CredentialCache.DefaultCredentials

        Dim forRendering As Boolean = True
        Dim historyID As String = Nothing
        Dim values(1) As ParameterValue
        Dim credentials() As DataSourceCredentials = Nothing
        Dim parametersSSRS() As ItemParameter = Nothing
        Dim pvs() As ValidValue = Nothing

        Dim x As Int32 = 5
        Dim y As Int32 = 30

        Try

            values(0) = New ParameterValue()
            values(0).Label = "ServiceYear"
            values(0).Name = "ServiceYear"
            values(0).Value = "2009"

            parametersSSRS = rs.GetItemParameters(report, historyID, forRendering, values, credentials)

            If parametersSSRS IsNot Nothing Then
                For Each rp As ItemParameter In parametersSSRS
                    Me.SuspendLayout()
                    Me.parameterPanel.SuspendLayout()
                    Me.parameterPanel.SendToBack()

                    '' now create a label for the combo box below
                    Dim lbl As Label = New Label()
                    lbl.Anchor = (System.Windows.Forms.AnchorStyles.Top)
                    lbl.Location = New System.Drawing.Point(x, y)
                    lbl.Name = rp.Name
                    lbl.Text = rp.Name
                    lbl.Size = New System.Drawing.Size(150, 20)
                    Me.parameterPanel.Controls.Add(lbl)
                    x = x + 150

                    '' now make a combo box and fill it
                    Dim a As ComboBox = New ComboBox()
                    a.Anchor = (System.Windows.Forms.AnchorStyles.Top)
                    a.Location = New System.Drawing.Point(x, y)
                    a.Name = rp.Name
                    a.Size = New System.Drawing.Size(200, 20)
                    x = 5
                    y = y + 30

                    If rp.ValidValues IsNot Nothing Then
                        ''Build listitems
                        Dim aList As ArrayList = New ArrayList()
                        pvs = rp.ValidValues

                        For Each pv As ValidValue In pvs
                            Dim ci As ComboItem = New ComboItem(pv.Label, pv.Value)

                            aList.Add(ci)
                        Next

                        ''Bind listitems to combobox
                        a.DataSource = aList
                        a.DisplayMember = "displayName"
                        a.ValueMember = "itemValue"
                    End If

                    Me.parameterPanel.Controls.Add(a)
                    Me.parameterPanel.ResumeLayout(False)
                    Me.ResumeLayout(False)
                Next

            End If

        Catch ex As SoapException
            MessageBox.Show(ex.Detail.InnerXml.ToString())
        End Try

    End Sub

    Private Sub buttonOK_Click(sender As System.Object, e As System.EventArgs) Handles buttonOK.Click
        parameters = ViewerParameters()

        Me.DialogResult = DialogResult.OK

        Me.Close()
    End Sub

    Private Function ViewerParameters() As Microsoft.Reporting.WinForms.ReportParameter()
        Dim numCtrls As Int32 = parameterPanel.Controls.Count / 2
        Dim rp(numCtrls - 1) As Microsoft.Reporting.WinForms.ReportParameter
        Dim i As Int32 = 0

        For Each ctrl As Control In parameterPanel.Controls
            If TypeOf ctrl Is ComboBox Then
                Dim a As ComboBox = ctrl
                rp(i) = New Microsoft.Reporting.WinForms.ReportParameter()
                rp(i).Name = a.Name

                If a.SelectedValue IsNot Nothing Then
                    rp(i).Values.Add(a.SelectedValue.ToString())
                Else
                    rp(i).Values.Add(Nothing)
                End If
                i += 1
            End If
        Next

        Return rp
    End Function

End Class

Friend Class ComboItem
    Public display As String
    Public value As String

    Public Sub New(ByVal disp As String, ByVal myvalue As String)
        If disp IsNot Nothing Then
            display = disp
        Else
            display = ""
        End If

        If myvalue IsNot Nothing Then
            value = myvalue
        Else
            value = ""
        End If
    End Sub

    Public Overloads Function ToString() As String
        Return display
    End Function

    Public Property displayName() As String
        Get
            Return display
        End Get
        Set(value As String)
            display = value
        End Set
    End Property

    Public Property itemValue() As String
        Get
            Return value
        End Get
        Set(value As String)
            value = value
        End Set
    End Property

End Class