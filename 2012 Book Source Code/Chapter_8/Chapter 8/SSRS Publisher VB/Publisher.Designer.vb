<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Publisher
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.reportServer = New System.Windows.Forms.TextBox()
        Me.getFolders = New System.Windows.Forms.Button()
        Me.ssrsFolders = New System.Windows.Forms.TreeView()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.reportFile = New System.Windows.Forms.TextBox()
        Me.browseFile = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(73, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Report Server"
        '
        'reportServer
        '
        Me.reportServer.Location = New System.Drawing.Point(90, 9)
        Me.reportServer.Name = "reportServer"
        Me.reportServer.Size = New System.Drawing.Size(302, 20)
        Me.reportServer.TabIndex = 1
        '
        'getFolders
        '
        Me.getFolders.Location = New System.Drawing.Point(398, 7)
        Me.getFolders.Name = "getFolders"
        Me.getFolders.Size = New System.Drawing.Size(75, 23)
        Me.getFolders.TabIndex = 2
        Me.getFolders.Text = "Go"
        Me.getFolders.UseVisualStyleBackColor = True
        '
        'ssrsFolders
        '
        Me.ssrsFolders.Location = New System.Drawing.Point(13, 37)
        Me.ssrsFolders.Name = "ssrsFolders"
        Me.ssrsFolders.Size = New System.Drawing.Size(461, 503)
        Me.ssrsFolders.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(15, 553)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(58, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Report File"
        '
        'reportFile
        '
        Me.reportFile.Location = New System.Drawing.Point(79, 549)
        Me.reportFile.Name = "reportFile"
        Me.reportFile.Size = New System.Drawing.Size(313, 20)
        Me.reportFile.TabIndex = 5
        '
        'browseFile
        '
        Me.browseFile.Location = New System.Drawing.Point(398, 547)
        Me.browseFile.Name = "browseFile"
        Me.browseFile.Size = New System.Drawing.Size(75, 23)
        Me.browseFile.TabIndex = 6
        Me.browseFile.Text = "Browse"
        Me.browseFile.UseVisualStyleBackColor = True
        '
        'Publisher
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(486, 579)
        Me.Controls.Add(Me.browseFile)
        Me.Controls.Add(Me.reportFile)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.ssrsFolders)
        Me.Controls.Add(Me.getFolders)
        Me.Controls.Add(Me.reportServer)
        Me.Controls.Add(Me.Label1)
        Me.Name = "Publisher"
        Me.Text = "Publisher (VB)"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents reportServer As System.Windows.Forms.TextBox
    Friend WithEvents getFolders As System.Windows.Forms.Button
    Friend WithEvents ssrsFolders As System.Windows.Forms.TreeView
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents reportFile As System.Windows.Forms.TextBox
    Friend WithEvents browseFile As System.Windows.Forms.Button

End Class
