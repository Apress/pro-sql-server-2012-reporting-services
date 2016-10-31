<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ViewerRVC
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
        Me.getParameters = New System.Windows.Forms.Button()
        Me.runLocal = New System.Windows.Forms.Button()
        Me.runServer = New System.Windows.Forms.Button()
        Me.reportURL = New System.Windows.Forms.TextBox()
        Me.reportViewer = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.SuspendLayout()
        '
        'getParameters
        '
        Me.getParameters.Location = New System.Drawing.Point(697, 12)
        Me.getParameters.Name = "getParameters"
        Me.getParameters.Size = New System.Drawing.Size(75, 23)
        Me.getParameters.TabIndex = 0
        Me.getParameters.Text = "Parameters"
        Me.getParameters.UseVisualStyleBackColor = True
        '
        'runLocal
        '
        Me.runLocal.Location = New System.Drawing.Point(616, 12)
        Me.runLocal.Name = "runLocal"
        Me.runLocal.Size = New System.Drawing.Size(75, 23)
        Me.runLocal.TabIndex = 1
        Me.runLocal.Text = "Run Local"
        Me.runLocal.UseVisualStyleBackColor = True
        '
        'runServer
        '
        Me.runServer.Location = New System.Drawing.Point(535, 12)
        Me.runServer.Name = "runServer"
        Me.runServer.Size = New System.Drawing.Size(75, 23)
        Me.runServer.TabIndex = 2
        Me.runServer.Text = "Run Server"
        Me.runServer.UseVisualStyleBackColor = True
        '
        'reportURL
        '
        Me.reportURL.Location = New System.Drawing.Point(13, 13)
        Me.reportURL.Name = "reportURL"
        Me.reportURL.Size = New System.Drawing.Size(516, 20)
        Me.reportURL.TabIndex = 3
        '
        'reportViewer
        '
        Me.reportViewer.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.reportViewer.Location = New System.Drawing.Point(13, 40)
        Me.reportViewer.Name = "reportViewer"
        Me.reportViewer.Size = New System.Drawing.Size(759, 510)
        Me.reportViewer.TabIndex = 4
        '
        'ViewerRVC
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(784, 562)
        Me.Controls.Add(Me.reportViewer)
        Me.Controls.Add(Me.reportURL)
        Me.Controls.Add(Me.runServer)
        Me.Controls.Add(Me.runLocal)
        Me.Controls.Add(Me.getParameters)
        Me.Name = "ViewerRVC"
        Me.Text = "SSRS Viewer RVC"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents getParameters As System.Windows.Forms.Button
    Friend WithEvents runLocal As System.Windows.Forms.Button
    Friend WithEvents runServer As System.Windows.Forms.Button
    Friend WithEvents reportURL As System.Windows.Forms.TextBox
    Friend WithEvents reportViewer As Microsoft.Reporting.WinForms.ReportViewer

End Class
