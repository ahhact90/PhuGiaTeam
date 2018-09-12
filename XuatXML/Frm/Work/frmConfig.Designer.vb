<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmConfig
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
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmConfig))
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.dtgCotDV = New System.Windows.Forms.DataGridView()
        Me.NgayAD = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CotDL = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.cbxDSCotThuoc = New System.Windows.Forms.ComboBox()
        Me.dtgTLKK = New System.Windows.Forms.DataGridView()
        Me.makk = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.madonvi = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.maxml = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblduongdan = New System.Windows.Forms.Label()
        Me.btnCauHinhTheoThe = New System.Windows.Forms.Button()
        Me.btnThoat = New System.Windows.Forms.Button()
        CType(Me.DataSetNguon, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.dtgCotDV, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtgTLKK, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnHeader
        '
        Me.pnHeader.Size = New System.Drawing.Size(952, 0)
        '
        'pnAction
        '
        Me.pnAction.Location = New System.Drawing.Point(0, 416)
        Me.pnAction.Size = New System.Drawing.Size(952, 0)
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.dtgCotDV)
        Me.SplitContainer1.Panel1.Controls.Add(Me.cbxDSCotThuoc)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.dtgTLKK)
        Me.SplitContainer1.Size = New System.Drawing.Size(952, 382)
        Me.SplitContainer1.SplitterDistance = 317
        Me.SplitContainer1.SplitterWidth = 2
        Me.SplitContainer1.TabIndex = 8
        '
        'dtgCotDV
        '
        Me.dtgCotDV.AllowUserToAddRows = False
        Me.dtgCotDV.AllowUserToDeleteRows = False
        Me.dtgCotDV.AllowUserToResizeRows = False
        Me.dtgCotDV.AutoGenerateColumns = False
        Me.dtgCotDV.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(245, Byte), Integer))
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(245, Byte), Integer))
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Arial", 10.0!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.Padding = New System.Windows.Forms.Padding(3)
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dtgCotDV.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dtgCotDV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtgCotDV.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.NgayAD, Me.CotDL})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Arial", 10.0!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer))
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dtgCotDV.DefaultCellStyle = DataGridViewCellStyle2
        Me.dtgCotDV.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dtgCotDV.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.dtgCotDV.EnableHeadersVisualStyles = False
        Me.dtgCotDV.Location = New System.Drawing.Point(0, 0)
        Me.dtgCotDV.MultiSelect = False
        Me.dtgCotDV.Name = "dtgCotDV"
        Me.dtgCotDV.RowHeadersVisible = False
        Me.dtgCotDV.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black
        Me.dtgCotDV.Size = New System.Drawing.Size(317, 358)
        Me.dtgCotDV.TabIndex = 0
        '
        'NgayAD
        '
        Me.NgayAD.DataPropertyName = "NgayAD"
        Me.NgayAD.HeaderText = "Ngày AD"
        Me.NgayAD.Name = "NgayAD"
        Me.NgayAD.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'CotDL
        '
        Me.CotDL.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.CotDL.DataPropertyName = "CotDL"
        Me.CotDL.HeaderText = "Cột dữ liệu"
        Me.CotDL.Name = "CotDL"
        Me.CotDL.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.CotDL.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'cbxDSCotThuoc
        '
        Me.cbxDSCotThuoc.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.cbxDSCotThuoc.FormattingEnabled = True
        Me.cbxDSCotThuoc.Location = New System.Drawing.Point(0, 358)
        Me.cbxDSCotThuoc.Name = "cbxDSCotThuoc"
        Me.cbxDSCotThuoc.Size = New System.Drawing.Size(317, 24)
        Me.cbxDSCotThuoc.TabIndex = 1
        '
        'dtgTLKK
        '
        Me.dtgTLKK.AllowUserToAddRows = False
        Me.dtgTLKK.AllowUserToDeleteRows = False
        Me.dtgTLKK.AllowUserToResizeRows = False
        Me.dtgTLKK.AutoGenerateColumns = False
        Me.dtgTLKK.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(245, Byte), Integer))
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(245, Byte), Integer))
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Arial", 10.0!)
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.Padding = New System.Windows.Forms.Padding(3)
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dtgTLKK.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dtgTLKK.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtgTLKK.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.makk, Me.madonvi, Me.maxml})
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Arial", 10.0!)
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer))
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dtgTLKK.DefaultCellStyle = DataGridViewCellStyle4
        Me.dtgTLKK.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dtgTLKK.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.dtgTLKK.EnableHeadersVisualStyles = False
        Me.dtgTLKK.Location = New System.Drawing.Point(0, 0)
        Me.dtgTLKK.MultiSelect = False
        Me.dtgTLKK.Name = "dtgTLKK"
        Me.dtgTLKK.RowHeadersVisible = False
        Me.dtgTLKK.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black
        Me.dtgTLKK.Size = New System.Drawing.Size(633, 382)
        Me.dtgTLKK.TabIndex = 1
        '
        'makk
        '
        Me.makk.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.makk.DataPropertyName = "makk"
        Me.makk.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.[Nothing]
        Me.makk.HeaderText = "Khoa"
        Me.makk.Name = "makk"
        Me.makk.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        '
        'madonvi
        '
        Me.madonvi.DataPropertyName = "madonvi"
        Me.madonvi.HeaderText = "Mã đơn vị"
        Me.madonvi.Name = "madonvi"
        Me.madonvi.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.madonvi.Width = 120
        '
        'maxml
        '
        Me.maxml.DataPropertyName = "maxml"
        Me.maxml.HeaderText = "Mã XML"
        Me.maxml.Name = "maxml"
        Me.maxml.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.maxml.Width = 120
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.lblduongdan)
        Me.Panel1.Controls.Add(Me.btnCauHinhTheoThe)
        Me.Panel1.Controls.Add(Me.btnThoat)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 382)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(952, 34)
        Me.Panel1.TabIndex = 9
        '
        'lblduongdan
        '
        Me.lblduongdan.AutoSize = True
        Me.lblduongdan.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblduongdan.Font = New System.Drawing.Font("Times New Roman", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
        Me.lblduongdan.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.lblduongdan.Location = New System.Drawing.Point(7, 7)
        Me.lblduongdan.Name = "lblduongdan"
        Me.lblduongdan.Size = New System.Drawing.Size(123, 19)
        Me.lblduongdan.TabIndex = 1
        Me.lblduongdan.Text = "Chọn đường dẫn"
        '
        'btnCauHinhTheoThe
        '
        Me.btnCauHinhTheoThe.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCauHinhTheoThe.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.btnCauHinhTheoThe.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCauHinhTheoThe.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btnCauHinhTheoThe.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCauHinhTheoThe.Font = New System.Drawing.Font("Arial", 10.0!)
        Me.btnCauHinhTheoThe.Image = Global.XMLCreator.My.Resources.Resources.config
        Me.btnCauHinhTheoThe.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCauHinhTheoThe.Location = New System.Drawing.Point(729, 1)
        Me.btnCauHinhTheoThe.Name = "btnCauHinhTheoThe"
        Me.btnCauHinhTheoThe.Size = New System.Drawing.Size(145, 30)
        Me.btnCauHinhTheoThe.TabIndex = 0
        Me.btnCauHinhTheoThe.Text = "Cấu hình theo thẻ"
        Me.btnCauHinhTheoThe.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCauHinhTheoThe.UseVisualStyleBackColor = False
        '
        'btnThoat
        '
        Me.btnThoat.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnThoat.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.btnThoat.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnThoat.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btnThoat.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnThoat.Font = New System.Drawing.Font("Arial", 10.0!)
        Me.btnThoat.Image = CType(resources.GetObject("btnThoat.Image"), System.Drawing.Image)
        Me.btnThoat.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnThoat.Location = New System.Drawing.Point(874, 1)
        Me.btnThoat.Name = "btnThoat"
        Me.btnThoat.Size = New System.Drawing.Size(75, 30)
        Me.btnThoat.TabIndex = 0
        Me.btnThoat.Text = "Thoát"
        Me.btnThoat.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnThoat.UseVisualStyleBackColor = False
        '
        'frmConfig
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(952, 416)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.Panel1)
        Me.Margin = New System.Windows.Forms.Padding(3, 6, 3, 6)
        Me.Name = "frmConfig"
        Me.Text = "Cấu hình hệ thống"
        Me.Controls.SetChildIndex(Me.pnHeader, 0)
        Me.Controls.SetChildIndex(Me.pnAction, 0)
        Me.Controls.SetChildIndex(Me.Panel1, 0)
        Me.Controls.SetChildIndex(Me.SplitContainer1, 0)
        CType(Me.DataSetNguon, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.dtgCotDV, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtgTLKK, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents dtgCotDV As DataGridView
    Friend WithEvents dtgTLKK As DataGridView
    Friend WithEvents Panel1 As Panel
    Friend WithEvents btnThoat As Button
    Friend WithEvents cbxDSCotThuoc As ComboBox
    Friend WithEvents NgayAD As DataGridViewTextBoxColumn
    Friend WithEvents CotDL As DataGridViewComboBoxColumn
    Friend WithEvents makk As DataGridViewComboBoxColumn
    Friend WithEvents madonvi As DataGridViewTextBoxColumn
    Friend WithEvents maxml As DataGridViewTextBoxColumn
    Friend WithEvents lblduongdan As Label
    Friend WithEvents btnCauHinhTheoThe As System.Windows.Forms.Button
End Class
