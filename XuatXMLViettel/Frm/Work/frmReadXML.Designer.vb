<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmReadXML
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.lblFldPath = New System.Windows.Forms.Label()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.dtgDSFile = New System.Windows.Forms.DataGridView()
        Me.TenFile = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DuongDan = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dtgData = New System.Windows.Forms.DataGridView()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.cbxDSTable = New System.Windows.Forms.ComboBox()
        Me.chkView121 = New System.Windows.Forms.CheckBox()
        Me.pnHeader.SuspendLayout()
        CType(Me.DataSetNguon, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.dtgDSFile, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtgData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnHeader
        '
        Me.pnHeader.Controls.Add(Me.chkView121)
        Me.pnHeader.Controls.Add(Me.lblFldPath)
        Me.pnHeader.Size = New System.Drawing.Size(806, 30)
        '
        'pnAction
        '
        Me.pnAction.Location = New System.Drawing.Point(0, 431)
        Me.pnAction.Size = New System.Drawing.Size(806, 0)
        '
        'lblFldPath
        '
        Me.lblFldPath.AutoSize = True
        Me.lblFldPath.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblFldPath.Font = New System.Drawing.Font("Times New Roman", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblFldPath.ForeColor = System.Drawing.Color.Gray
        Me.lblFldPath.Location = New System.Drawing.Point(6, 5)
        Me.lblFldPath.Name = "lblFldPath"
        Me.lblFldPath.Size = New System.Drawing.Size(200, 17)
        Me.lblFldPath.TabIndex = 0
        Me.lblFldPath.Text = "Chọn đường dẫn folder đọc xml"
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 30)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.dtgDSFile)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.dtgData)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Panel1)
        Me.SplitContainer1.Size = New System.Drawing.Size(806, 401)
        Me.SplitContainer1.SplitterDistance = 268
        Me.SplitContainer1.SplitterWidth = 2
        Me.SplitContainer1.TabIndex = 8
        '
        'dtgDSFile
        '
        Me.dtgDSFile.AllowUserToAddRows = False
        Me.dtgDSFile.AllowUserToDeleteRows = False
        Me.dtgDSFile.AllowUserToResizeRows = False
        Me.dtgDSFile.AutoGenerateColumns = False
        Me.dtgDSFile.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(245, Byte), Integer))
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(245, Byte), Integer))
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Arial", 10.0!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.Padding = New System.Windows.Forms.Padding(3)
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dtgDSFile.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dtgDSFile.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtgDSFile.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.TenFile, Me.DuongDan})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Arial", 10.0!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer))
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dtgDSFile.DefaultCellStyle = DataGridViewCellStyle2
        Me.dtgDSFile.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dtgDSFile.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.dtgDSFile.EnableHeadersVisualStyles = False
        Me.dtgDSFile.Location = New System.Drawing.Point(0, 0)
        Me.dtgDSFile.MultiSelect = False
        Me.dtgDSFile.Name = "dtgDSFile"
        Me.dtgDSFile.ReadOnly = True
        Me.dtgDSFile.RowHeadersVisible = False
        Me.dtgDSFile.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black
        Me.dtgDSFile.Size = New System.Drawing.Size(268, 401)
        Me.dtgDSFile.TabIndex = 0
        '
        'TenFile
        '
        Me.TenFile.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.TenFile.DataPropertyName = "TenFile"
        Me.TenFile.HeaderText = "File"
        Me.TenFile.Name = "TenFile"
        Me.TenFile.ReadOnly = True
        '
        'DuongDan
        '
        Me.DuongDan.DataPropertyName = "DuongDan"
        Me.DuongDan.HeaderText = "Đường dẫn"
        Me.DuongDan.Name = "DuongDan"
        Me.DuongDan.ReadOnly = True
        Me.DuongDan.Visible = False
        '
        'dtgData
        '
        Me.dtgData.AllowUserToAddRows = False
        Me.dtgData.AllowUserToDeleteRows = False
        Me.dtgData.AllowUserToResizeRows = False
        Me.dtgData.AutoGenerateColumns = False
        Me.dtgData.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(245, Byte), Integer))
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(245, Byte), Integer))
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Arial", 10.0!)
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.Padding = New System.Windows.Forms.Padding(3)
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dtgData.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dtgData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Arial", 10.0!)
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer))
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dtgData.DefaultCellStyle = DataGridViewCellStyle4
        Me.dtgData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dtgData.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.dtgData.EnableHeadersVisualStyles = False
        Me.dtgData.Location = New System.Drawing.Point(0, 0)
        Me.dtgData.MultiSelect = False
        Me.dtgData.Name = "dtgData"
        Me.dtgData.ReadOnly = True
        Me.dtgData.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black
        Me.dtgData.Size = New System.Drawing.Size(536, 371)
        Me.dtgData.TabIndex = 1
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.cbxDSTable)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 371)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(536, 30)
        Me.Panel1.TabIndex = 0
        '
        'cbxDSTable
        '
        Me.cbxDSTable.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbxDSTable.FormattingEnabled = True
        Me.cbxDSTable.Location = New System.Drawing.Point(310, 3)
        Me.cbxDSTable.Name = "cbxDSTable"
        Me.cbxDSTable.Size = New System.Drawing.Size(220, 24)
        Me.cbxDSTable.TabIndex = 0
        '
        'chkView121
        '
        Me.chkView121.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkView121.AutoSize = True
        Me.chkView121.Location = New System.Drawing.Point(748, 6)
        Me.chkView121.Name = "chkView121"
        Me.chkView121.Size = New System.Drawing.Size(51, 20)
        Me.chkView121.TabIndex = 1
        Me.chkView121.Text = "121"
        Me.chkView121.UseVisualStyleBackColor = True
        '
        'frmReadXML
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(806, 431)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Margin = New System.Windows.Forms.Padding(3, 6, 3, 6)
        Me.Name = "frmReadXML"
        Me.Tag = ""
        Me.Text = "Đọc lại XML"
        Me.Controls.SetChildIndex(Me.pnHeader, 0)
        Me.Controls.SetChildIndex(Me.SplitContainer1, 0)
        Me.Controls.SetChildIndex(Me.pnAction, 0)
        Me.pnHeader.ResumeLayout(False)
        Me.pnHeader.PerformLayout()
        CType(Me.DataSetNguon, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.dtgDSFile, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtgData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lblFldPath As System.Windows.Forms.Label
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents dtgDSFile As System.Windows.Forms.DataGridView
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents cbxDSTable As System.Windows.Forms.ComboBox
    Friend WithEvents dtgData As System.Windows.Forms.DataGridView
    Friend WithEvents TenFile As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DuongDan As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents chkView121 As System.Windows.Forms.CheckBox
End Class
