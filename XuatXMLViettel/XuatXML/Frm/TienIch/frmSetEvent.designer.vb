<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSetEvent
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cbxControlName = New System.Windows.Forms.ComboBox()
        Me.cbxFormName = New System.Windows.Forms.ComboBox()
        Me.cbxEventName = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.rtfFunction = New System.Windows.Forms.RichTextBox()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.cbxControlName)
        Me.Panel1.Controls.Add(Me.cbxFormName)
        Me.Panel1.Controls.Add(Me.cbxEventName)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(853, 39)
        Me.Panel1.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(263, 13)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(71, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Control Name"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 13)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(61, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Form Name"
        '
        'cbxControlName
        '
        Me.cbxControlName.Enabled = False
        Me.cbxControlName.FormattingEnabled = True
        Me.cbxControlName.Location = New System.Drawing.Point(340, 10)
        Me.cbxControlName.Name = "cbxControlName"
        Me.cbxControlName.Size = New System.Drawing.Size(185, 21)
        Me.cbxControlName.TabIndex = 1
        '
        'cbxFormName
        '
        Me.cbxFormName.Enabled = False
        Me.cbxFormName.FormattingEnabled = True
        Me.cbxFormName.Location = New System.Drawing.Point(76, 10)
        Me.cbxFormName.Name = "cbxFormName"
        Me.cbxFormName.Size = New System.Drawing.Size(181, 21)
        Me.cbxFormName.TabIndex = 1
        '
        'cbxEventName
        '
        Me.cbxEventName.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbxEventName.FormattingEnabled = True
        Me.cbxEventName.Items.AddRange(New Object() {"Click", "DoubleClick", "Enter", "Paint", "SizeChanged", "TextChanged", "Validated", "Validating"})
        Me.cbxEventName.Location = New System.Drawing.Point(598, 10)
        Me.cbxEventName.Name = "cbxEventName"
        Me.cbxEventName.Size = New System.Drawing.Size(242, 21)
        Me.cbxEventName.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(531, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(63, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "EventName"
        '
        'rtfFunction
        '
        Me.rtfFunction.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.rtfFunction.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rtfFunction.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rtfFunction.Location = New System.Drawing.Point(0, 39)
        Me.rtfFunction.Name = "rtfFunction"
        Me.rtfFunction.Size = New System.Drawing.Size(853, 434)
        Me.rtfFunction.TabIndex = 1
        Me.rtfFunction.Text = ""
        '
        'frmSetEvent
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(853, 473)
        Me.Controls.Add(Me.rtfFunction)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "frmSetEvent"
        Me.Text = "frmSetEvent"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cbxEventName As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cbxControlName As System.Windows.Forms.ComboBox
    Friend WithEvents cbxFormName As System.Windows.Forms.ComboBox
    Friend WithEvents rtfFunction As System.Windows.Forms.RichTextBox
End Class
