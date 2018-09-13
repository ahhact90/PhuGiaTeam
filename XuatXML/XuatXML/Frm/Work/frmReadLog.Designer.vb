<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmReadLog
    Inherits XMLCreator.frmPRTienIch

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
        Me.txtLogFile = New System.Windows.Forms.RichTextBox()
        Me.txtResult = New System.Windows.Forms.RichTextBox()
        Me.lblLoadTuFile = New System.Windows.Forms.Label()
        Me.btnReadlog = New System.Windows.Forms.Button()
        Me.btnXoayNgang = New System.Windows.Forms.Button()
        Me.chkLayCaLoi = New System.Windows.Forms.CheckBox()
        Me.btnTach2 = New System.Windows.Forms.Button()
        Me.pnHeader.SuspendLayout()
        Me.pnAction.SuspendLayout()
        CType(Me.DataSetNguon, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnHeader
        '
        Me.pnHeader.Controls.Add(Me.lblLoadTuFile)
        Me.pnHeader.Size = New System.Drawing.Size(868, 30)
        '
        'pnAction
        '
        Me.pnAction.Controls.Add(Me.chkLayCaLoi)
        Me.pnAction.Controls.Add(Me.btnXoayNgang)
        Me.pnAction.Controls.Add(Me.btnTach2)
        Me.pnAction.Controls.Add(Me.btnReadlog)
        Me.pnAction.Location = New System.Drawing.Point(0, 360)
        Me.pnAction.Size = New System.Drawing.Size(868, 34)
        '
        'txtLogFile
        '
        Me.txtLogFile.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtLogFile.Location = New System.Drawing.Point(0, 30)
        Me.txtLogFile.Name = "txtLogFile"
        Me.txtLogFile.Size = New System.Drawing.Size(503, 330)
        Me.txtLogFile.TabIndex = 8
        Me.txtLogFile.Text = ""
        '
        'txtResult
        '
        Me.txtResult.Dock = System.Windows.Forms.DockStyle.Right
        Me.txtResult.Location = New System.Drawing.Point(503, 30)
        Me.txtResult.Name = "txtResult"
        Me.txtResult.Size = New System.Drawing.Size(365, 330)
        Me.txtResult.TabIndex = 9
        Me.txtResult.Text = ""
        '
        'lblLoadTuFile
        '
        Me.lblLoadTuFile.AutoSize = True
        Me.lblLoadTuFile.Font = New System.Drawing.Font("Times New Roman", 10.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
        Me.lblLoadTuFile.Location = New System.Drawing.Point(11, 6)
        Me.lblLoadTuFile.Name = "lblLoadTuFile"
        Me.lblLoadTuFile.Size = New System.Drawing.Size(69, 17)
        Me.lblLoadTuFile.TabIndex = 0
        Me.lblLoadTuFile.Text = "Lấy từ file"
        '
        'btnReadlog
        '
        Me.btnReadlog.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnReadlog.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.btnReadlog.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnReadlog.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btnReadlog.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnReadlog.Font = New System.Drawing.Font("Arial", 10.0!)
        Me.btnReadlog.Location = New System.Drawing.Point(769, 1)
        Me.btnReadlog.Name = "btnReadlog"
        Me.btnReadlog.Size = New System.Drawing.Size(96, 30)
        Me.btnReadlog.TabIndex = 0
        Me.btnReadlog.Text = "Tách log  "
        Me.btnReadlog.UseVisualStyleBackColor = False
        '
        'btnXoayNgang
        '
        Me.btnXoayNgang.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnXoayNgang.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.btnXoayNgang.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnXoayNgang.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btnXoayNgang.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnXoayNgang.Font = New System.Drawing.Font("Arial", 10.0!)
        Me.btnXoayNgang.Location = New System.Drawing.Point(672, 1)
        Me.btnXoayNgang.Name = "btnXoayNgang"
        Me.btnXoayNgang.Size = New System.Drawing.Size(96, 30)
        Me.btnXoayNgang.TabIndex = 0
        Me.btnXoayNgang.Text = "Xoay ngang"
        Me.btnXoayNgang.UseVisualStyleBackColor = False
        '
        'chkLayCaLoi
        '
        Me.chkLayCaLoi.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkLayCaLoi.AutoSize = True
        Me.chkLayCaLoi.Location = New System.Drawing.Point(846, 10)
        Me.chkLayCaLoi.Name = "chkLayCaLoi"
        Me.chkLayCaLoi.Size = New System.Drawing.Size(15, 14)
        Me.chkLayCaLoi.TabIndex = 1
        Me.chkLayCaLoi.UseVisualStyleBackColor = True
        '
        'btnTach2
        '
        Me.btnTach2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnTach2.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.btnTach2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnTach2.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btnTach2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnTach2.Font = New System.Drawing.Font("Arial", 10.0!)
        Me.btnTach2.Location = New System.Drawing.Point(575, 1)
        Me.btnTach2.Name = "btnTach2"
        Me.btnTach2.Size = New System.Drawing.Size(96, 30)
        Me.btnTach2.TabIndex = 0
        Me.btnTach2.Text = "Tách từ web"
        Me.btnTach2.UseVisualStyleBackColor = False
        '
        'frmReadLog
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(868, 394)
        Me.Controls.Add(Me.txtLogFile)
        Me.Controls.Add(Me.txtResult)
        Me.Name = "frmReadLog"
        Me.Text = "Tách makcb từ log"
        Me.Controls.SetChildIndex(Me.pnHeader, 0)
        Me.Controls.SetChildIndex(Me.pnAction, 0)
        Me.Controls.SetChildIndex(Me.txtResult, 0)
        Me.Controls.SetChildIndex(Me.txtLogFile, 0)
        Me.pnHeader.ResumeLayout(False)
        Me.pnHeader.PerformLayout()
        Me.pnAction.ResumeLayout(False)
        Me.pnAction.PerformLayout()
        CType(Me.DataSetNguon, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents txtLogFile As System.Windows.Forms.RichTextBox
    Friend WithEvents txtResult As System.Windows.Forms.RichTextBox
    Friend WithEvents lblLoadTuFile As System.Windows.Forms.Label
    Friend WithEvents btnReadlog As System.Windows.Forms.Button
    Friend WithEvents btnXoayNgang As System.Windows.Forms.Button
    Friend WithEvents chkLayCaLoi As System.Windows.Forms.CheckBox
    Friend WithEvents btnTach2 As System.Windows.Forms.Button
End Class
