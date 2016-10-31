Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports SSRS_Viewer_RVC_VB.SSRSWebSerivce
Imports System.Web.Services.Protocols
Imports System.Collections


Public Class GetParameters

    Private url As String
    Private server As String
    Private report As String
    Private parameters() As Microsoft.Reporting.WinForms.ReportParameter '= Nothing
    Dim rs As ReportingService2010

    Public Sub GetParameters(ByVal repurl As String)
        'Change sub from New to GetParameters as C# code does
        InitializeComponent()

        url = repurl
        Dim reportInfo() As String = url.Split("?")
        server = reportInfo(0)
        report = reportInfo(1)

    End Sub


    'Public ReadOnly Property Parameters() As Microsoft.Reporting.WinForms.ReportParameter()
    '    Get
    '        Return parameters
    '    End Get
    'End Property


    'Private Sub GetParameters_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    '    rs = New ReportingService2010()
    '    rs.Credentials = System.Net.CredentialCache.DefaultCredentials

    '    Dim forRendering As Boolean = True
    '    Dim historyID As String = vbNull
    '    Dim values(1) As ParameterValue
    '    Dim credentials() As DataSourceCredentials = Nothing
    '    Dim parametersSSRS() As ItemParameter = Nothing
    '    Dim pvs() As ValidValue = Nothing

    '    Dim x As Int32 = 5
    '    Dim y As Int32 = 30

    '    parametersSSRS = rs.GetItemParameters(report, historyID, forRendering, values, credentials)

    '    Try
    '        values(0) = New ParameterValue()
    '        values(0).Label = "ServiceYear"
    '        values(0).Name = "ServiceYear"
    '        values(0).Value = "2007"

    '        parametersSSRS = rs.GetItemParameters(report, historyID, forRendering, values, credentials)

    '        If parameters IsNot Nothing Then
    '            For Each rp As ItemParameter In parametersSSRS
    '                Me.SuspendLayout()
    '                Me.parameterPanel.SuspendLayout()
    '                Me.parameterPanel.SendToBack()

    '                '' now create a label for the combo box below
    '                Dim lbl As Label = New Label()
    '                lbl.Anchor = (System.Windows.Forms.AnchorStyles.Top)
    '                lbl.Location = New System.Drawing.Point(x, y)
    '                lbl.Name = rp.Name
    '                lbl.Text = rp.Name
    '                lbl.Size = New System.Drawing.Size(150, 20)
    '                Me.parameterPanel.Controls.Add(lbl)
    '                x = x + 150

    '                '' now make a combo box and fill it
    '                Dim a As ComboBox = New ComboBox()
    '                a.Anchor = (System.Windows.Forms.AnchorStyles.Top)
    '                a.Location = New System.Drawing.Point(x, y)
    '                a.Name = rp.Name
    '                a.Size = New System.Drawing.Size(200, 20)
    '                x = 5
    '                y = y + 30

    '                Me.parameterPanel.Controls.Add(a)
    '                Me.parameterPanel.ResumeLayout(False)
    '                Me.ResumeLayout(False)

    '                If rp.ValidValues IsNot Nothing Then
    '                    ''Build listitems
    '                    Dim aList As ArrayList = New ArrayList()
    '                    pvs = rp.ValidValues

    '                    For Each pv As ValidValue In pvs
    '                        aList.Add(New ComboItem(pv.Label, pv.Value))
    '                    Next

    '                    ''Bind listitmes to combobox
    '                    a.DataSource = aList
    '                    a.DisplayMember = "Display"
    '                    a.ValueMember = "Value"
    '                End If
    '            Next

    '        End If



    '    Catch ex As SoapException
    '        MessageBox.Show(ex.Detail.InnerXml.ToString())
    '    End Try



    'End Sub


    'Private Sub buttonOK_Click(sender As System.Object, e As System.EventArgs) Handles buttonOK.Click
    '    parameters = ViewerParameters()
    '    Me.DialogResult = DialogResult.OK
    '    Close()

    'End Sub
    'Private Function ViewerParameters() As Microsoft.Reporting.WinForms.ReportParameter()
    '    Dim numCtrls As Integer = (Me.parameterPanel.Controls.Count / 2)
    '    'Dim rp As List(Of Microsoft.Reporting.WinForms.ReportParameter()) = New List(Of Microsoft.Reporting.WinForms.ReportParameter())
    '    'Dim rp As Microsoft.Reporting.WinForms.ReportParameter() = New Microsoft.Reporting.WinForms.ReportParameter(numCtrls - 1) {}
    '    Dim rp As Microsoft.Reporting.WinForms.ReportParameter() = New Microsoft.Reporting.WinForms.ReportParameter(4) {}

    '    Dim i As Integer = 0

    '    For Each ctrl As Control In Me.parameterPanel.Controls
    '        If TypeOf (ctrl) Is ComboBox Then ' ctrl.GetType = GetType(ComboBox) Then
    '            Dim a As ComboBox = DirectCast(ctrl, ComboBox)
    '            rp(i) = New Microsoft.Reporting.WinForms.ReportParameter()
    '            rp(i).Name = a.Name
    '            If a.SelectedValue IsNot Nothing AndAlso a.SelectedValue.ToString() <> [String].Empty Then
    '                rp(i).Values.Add(a.SelectedValue.ToString())
    '            Else
    '                rp(i).Values.Add(Nothing)
    '            End If
    '            i += 1
    '        End If
    '    Next

    '    Return rp
    'End Function


End Class
Public Class ComboItem
    Public Sub ComboItem(ByVal disp As String, ByVal myvalue As String)
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

    Public display As String
    Public value As String

    Public Overrides Function ToString() As String
        Return display
    End Function

End Class

