<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class GetParameters
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
        Me.parameterPanel = New System.Windows.Forms.FlowLayoutPanel()
        Me.buttonOK = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'parameterPanel
        '
        Me.parameterPanel.Location = New System.Drawing.Point(13, 13)
        Me.parameterPanel.Name = "parameterPanel"
        Me.parameterPanel.Size = New System.Drawing.Size(371, 209)
        Me.parameterPanel.TabIndex = 0
        '
        'buttonOK
        '
        Me.buttonOK.Location = New System.Drawing.Point(160, 237)
        Me.buttonOK.Name = "buttonOK"
        Me.buttonOK.Size = New System.Drawing.Size(75, 23)
        Me.buttonOK.TabIndex = 1
        Me.buttonOK.Text = "OK"
        Me.buttonOK.UseVisualStyleBackColor = True
        '
        'GetParameters
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(396, 272)
        Me.Controls.Add(Me.buttonOK)
        Me.Controls.Add(Me.parameterPanel)
        Me.Name = "GetParameters"
        Me.Text = "Parameters"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents parameterPanel As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents buttonOK As System.Windows.Forms.Button
End Class
