<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Tester
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
        Me.VisitDate = New System.Windows.Forms.MaskedTextBox()
        Me.label3 = New System.Windows.Forms.Label()
        Me.wsTest = New System.Windows.Forms.Button()
        Me.label2 = New System.Windows.Forms.Label()
        Me.label1 = New System.Windows.Forms.Label()
        Me.EmployeePayAmt = New System.Windows.Forms.TextBox()
        Me.EmployeeID = New System.Windows.Forms.TextBox()
        Me.xmlTest = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'VisitDate
        '
        Me.VisitDate.Location = New System.Drawing.Point(110, 78)
        Me.VisitDate.Mask = "00/00/0000"
        Me.VisitDate.Name = "VisitDate"
        Me.VisitDate.Size = New System.Drawing.Size(100, 20)
        Me.VisitDate.TabIndex = 10
        Me.VisitDate.ValidatingType = GetType(Date)
        '
        'label3
        '
        Me.label3.AutoSize = True
        Me.label3.Location = New System.Drawing.Point(73, 81)
        Me.label3.Name = "label3"
        Me.label3.Size = New System.Drawing.Size(30, 13)
        Me.label3.TabIndex = 16
        Me.label3.Text = "Date"
        '
        'wsTest
        '
        Me.wsTest.Location = New System.Drawing.Point(81, 210)
        Me.wsTest.Name = "wsTest"
        Me.wsTest.Size = New System.Drawing.Size(75, 23)
        Me.wsTest.TabIndex = 13
        Me.wsTest.Text = "Test WS"
        '
        'label2
        '
        Me.label2.AutoSize = True
        Me.label2.Location = New System.Drawing.Point(44, 120)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(64, 13)
        Me.label2.TabIndex = 15
        Me.label2.Text = "Pay Amount"
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.Location = New System.Drawing.Point(41, 39)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(67, 13)
        Me.label1.TabIndex = 14
        Me.label1.Text = "Employee ID"
        '
        'EmployeePayAmt
        '
        Me.EmployeePayAmt.Location = New System.Drawing.Point(110, 117)
        Me.EmployeePayAmt.Name = "EmployeePayAmt"
        Me.EmployeePayAmt.ReadOnly = True
        Me.EmployeePayAmt.Size = New System.Drawing.Size(100, 20)
        Me.EmployeePayAmt.TabIndex = 11
        Me.EmployeePayAmt.TabStop = False
        '
        'EmployeeID
        '
        Me.EmployeeID.Location = New System.Drawing.Point(110, 39)
        Me.EmployeeID.Name = "EmployeeID"
        Me.EmployeeID.Size = New System.Drawing.Size(100, 20)
        Me.EmployeeID.TabIndex = 9
        '
        'xmlTest
        '
        Me.xmlTest.Location = New System.Drawing.Point(81, 168)
        Me.xmlTest.Name = "xmlTest"
        Me.xmlTest.Size = New System.Drawing.Size(75, 23)
        Me.xmlTest.TabIndex = 12
        Me.xmlTest.Text = "Test XML"
        '
        'Tester
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(251, 273)
        Me.Controls.Add(Me.VisitDate)
        Me.Controls.Add(Me.label3)
        Me.Controls.Add(Me.wsTest)
        Me.Controls.Add(Me.label2)
        Me.Controls.Add(Me.label1)
        Me.Controls.Add(Me.EmployeePayAmt)
        Me.Controls.Add(Me.EmployeeID)
        Me.Controls.Add(Me.xmlTest)
        Me.Name = "Tester"
        Me.Text = "Employee Class Tester"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents VisitDate As System.Windows.Forms.MaskedTextBox
    Private WithEvents label3 As System.Windows.Forms.Label
    Private WithEvents wsTest As System.Windows.Forms.Button
    Private WithEvents label2 As System.Windows.Forms.Label
    Private WithEvents label1 As System.Windows.Forms.Label
    Private WithEvents EmployeePayAmt As System.Windows.Forms.TextBox
    Private WithEvents EmployeeID As System.Windows.Forms.TextBox
    Private WithEvents xmlTest As System.Windows.Forms.Button

End Class
