<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ViewerWBC
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.reportURL = New System.Windows.Forms.TextBox()
        Me.reportRun = New System.Windows.Forms.Button()
        Me.WebBrowser2 = New System.Windows.Forms.WebBrowser()
        Me.webBrowser = New System.Windows.Forms.WebBrowser()
        Me.SuspendLayout()
        '
        'reportURL
        '
        Me.reportURL.Location = New System.Drawing.Point(13, 13)
        Me.reportURL.Name = "reportURL"
        Me.reportURL.Size = New System.Drawing.Size(686, 20)
        Me.reportURL.TabIndex = 0
        Me.reportURL.Text = "http://localhost/reportserver/?/Pro_SSRS/Chapter_7/EmployeeServiceCost&rs:Command" & _
            "=Render"
        '
        'reportRun
        '
        Me.reportRun.Location = New System.Drawing.Point(705, 13)
        Me.reportRun.Name = "reportRun"
        Me.reportRun.Size = New System.Drawing.Size(75, 23)
        Me.reportRun.TabIndex = 1
        Me.reportRun.Text = "View"
        Me.reportRun.UseVisualStyleBackColor = True
        '
        'WebBrowser2
        '
        Me.WebBrowser2.Location = New System.Drawing.Point(764, 223)
        Me.WebBrowser2.MinimumSize = New System.Drawing.Size(20, 20)
        Me.WebBrowser2.Name = "WebBrowser2"
        Me.WebBrowser2.Size = New System.Drawing.Size(250, 250)
        Me.WebBrowser2.TabIndex = 3
        '
        'webBrowser
        '
        Me.webBrowser.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.webBrowser.Location = New System.Drawing.Point(1, 39)
        Me.webBrowser.MinimumSize = New System.Drawing.Size(20, 20)
        Me.webBrowser.Name = "webBrowser"
        Me.webBrowser.Size = New System.Drawing.Size(791, 533)
        Me.webBrowser.TabIndex = 4
        '
        'ViewerWBC
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(792, 573)
        Me.Controls.Add(Me.webBrowser)
        Me.Controls.Add(Me.WebBrowser2)
        Me.Controls.Add(Me.reportRun)
        Me.Controls.Add(Me.reportURL)
        Me.Name = "ViewerWBC"
        Me.Text = "SSRS Viewer WBC"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents reportURL As System.Windows.Forms.TextBox
    Friend WithEvents reportRun As System.Windows.Forms.Button
    Friend WithEvents WebBrowser2 As System.Windows.Forms.WebBrowser
    Friend WithEvents webBrowser As System.Windows.Forms.WebBrowser

End Class
