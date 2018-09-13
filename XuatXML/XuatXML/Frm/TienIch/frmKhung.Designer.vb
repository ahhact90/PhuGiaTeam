<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmKhung
    Inherits frmPRTienIch

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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.dtgDSMay = New System.Windows.Forms.DataGridView()
        Me.mamay = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tenmay = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.DataSetNguon, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtgDSMay, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnHeader
        '
        Me.pnHeader.Location = New System.Drawing.Point(250, 0)
        Me.pnHeader.Size = New System.Drawing.Size(334, 34)
        '
        'dtgDSMay
        '
        Me.dtgDSMay.AllowUserToAddRows = False
        Me.dtgDSMay.AllowUserToDeleteRows = False
        Me.dtgDSMay.AllowUserToResizeRows = False
        Me.dtgDSMay.AutoGenerateColumns = False
        Me.dtgDSMay.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(245, Byte), Integer))
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(245, Byte), Integer))
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Arial", 10.0!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.Padding = New System.Windows.Forms.Padding(3)
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dtgDSMay.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dtgDSMay.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtgDSMay.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.mamay, Me.tenmay})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Arial", 10.0!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer))
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dtgDSMay.DefaultCellStyle = DataGridViewCellStyle2
        Me.dtgDSMay.Dock = System.Windows.Forms.DockStyle.Left
        Me.dtgDSMay.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.dtgDSMay.EnableHeadersVisualStyles = False
        Me.dtgDSMay.Location = New System.Drawing.Point(0, 0)
        Me.dtgDSMay.MultiSelect = False
        Me.dtgDSMay.Name = "dtgDSMay"
        Me.dtgDSMay.ReadOnly = True
        Me.dtgDSMay.RowHeadersVisible = False
        Me.dtgDSMay.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black
        Me.dtgDSMay.Size = New System.Drawing.Size(250, 202)
        Me.dtgDSMay.TabIndex = 8
        '
        'mamay
        '
        Me.mamay.DataPropertyName = "mamay"
        Me.mamay.HeaderText = "Mã"
        Me.mamay.Name = "mamay"
        Me.mamay.ReadOnly = True
        Me.mamay.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.mamay.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.mamay.Visible = False
        '
        'tenmay
        '
        Me.tenmay.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.tenmay.DataPropertyName = "tenmay"
        Me.tenmay.HeaderText = "Máy XN"
        Me.tenmay.Name = "tenmay"
        Me.tenmay.ReadOnly = True
        '
        'frmKhung
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(584, 236)
        Me.Controls.Add(Me.dtgDSMay)
        Me.Name = "frmKhung"
        Me.Text = "frmKhung"
        Me.Controls.SetChildIndex(Me.pnAction, 0)
        Me.Controls.SetChildIndex(Me.dtgDSMay, 0)
        Me.Controls.SetChildIndex(Me.pnHeader, 0)
        CType(Me.DataSetNguon, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtgDSMay, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents mamay As DataGridViewTextBoxColumn
    Friend WithEvents tenmay As DataGridViewTextBoxColumn
    Public WithEvents dtgDSMay As DataGridView
End Class
