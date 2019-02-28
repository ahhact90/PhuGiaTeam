<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmInputBox
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.OK_Button = New System.Windows.Forms.Button()
        Me.Cancel_Button = New System.Windows.Forms.Button()
        Me.lbltitle = New System.Windows.Forms.Label()
        Me.txtGiatri = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmbGiatri = New System.Windows.Forms.ComboBox()
        Me.lblErr = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.SuspendLayout()
        '
        'OK_Button
        '
        Me.OK_Button.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.OK_Button.BackColor = System.Drawing.Color.Transparent
        Me.OK_Button.Location = New System.Drawing.Point(132, 82)
        Me.OK_Button.Margin = New System.Windows.Forms.Padding(4)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(90, 31)
        Me.OK_Button.TabIndex = 0
        Me.OK_Button.Text = "Đồng ý"
        Me.OK_Button.UseVisualStyleBackColor = False
        '
        'Cancel_Button
        '
        Me.Cancel_Button.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Cancel_Button.BackColor = System.Drawing.Color.Transparent
        Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_Button.ForeColor = System.Drawing.Color.Red
        Me.Cancel_Button.Location = New System.Drawing.Point(227, 82)
        Me.Cancel_Button.Margin = New System.Windows.Forms.Padding(4)
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Cancel_Button.Size = New System.Drawing.Size(90, 31)
        Me.Cancel_Button.TabIndex = 1
        Me.Cancel_Button.Text = "Bỏ qua"
        Me.Cancel_Button.UseVisualStyleBackColor = False
        '
        'lbltitle
        '
        Me.lbltitle.AutoSize = True
        Me.lbltitle.Location = New System.Drawing.Point(-1, 2)
        Me.lbltitle.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbltitle.MaximumSize = New System.Drawing.Size(330, 700)
        Me.lbltitle.Name = "lbltitle"
        Me.lbltitle.Size = New System.Drawing.Size(44, 19)
        Me.lbltitle.TabIndex = 1
        Me.lbltitle.Text = "lbltitle"
        '
        'txtGiatri
        '
        Me.txtGiatri.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtGiatri.Location = New System.Drawing.Point(52, 42)
        Me.txtGiatri.Name = "txtGiatri"
        Me.txtGiatri.Size = New System.Drawing.Size(263, 26)
        Me.txtGiatri.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(-1, 46)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(46, 19)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Giá trị"
        '
        'cmbGiatri
        '
        Me.cmbGiatri.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbGiatri.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbGiatri.FormattingEnabled = True
        Me.cmbGiatri.Location = New System.Drawing.Point(52, 73)
        Me.cmbGiatri.Name = "cmbGiatri"
        Me.cmbGiatri.Size = New System.Drawing.Size(38, 27)
        Me.cmbGiatri.TabIndex = 3
        '
        'lblErr
        '
        Me.lblErr.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblErr.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblErr.ForeColor = System.Drawing.Color.Red
        Me.lblErr.Location = New System.Drawing.Point(165, 26)
        Me.lblErr.Name = "lblErr"
        Me.lblErr.Size = New System.Drawing.Size(150, 13)
        Me.lblErr.TabIndex = 4
        Me.lblErr.Text = "Gia tri phai <= 1"
        Me.lblErr.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblErr.Visible = False
        '
        'Timer1
        '
        Me.Timer1.Interval = 500
        '
        'UI_inputBox
        '
        Me.AcceptButton = Me.OK_Button
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 19.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(204, Byte), Integer), CType(CType(209, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(332, 123)
        Me.Controls.Add(Me.lbltitle)
        Me.Controls.Add(Me.lblErr)
        Me.Controls.Add(Me.cmbGiatri)
        Me.Controls.Add(Me.OK_Button)
        Me.Controls.Add(Me.txtGiatri)
        Me.Controls.Add(Me.Cancel_Button)
        Me.Controls.Add(Me.Label2)
        Me.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "UI_inputBox"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents lbltitle As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblErr As System.Windows.Forms.Label
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Public WithEvents txtGiatri As System.Windows.Forms.TextBox
    Public WithEvents cmbGiatri As System.Windows.Forms.ComboBox

End Class
