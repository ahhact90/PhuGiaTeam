<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmXuatXML
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
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.dtgdata = New System.Windows.Forms.DataGridView()
        Me.MaKCB = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.HoTen = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DangDT = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.NgayTT = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lblKK = New System.Windows.Forms.Label()
        Me.lblDoiTuong = New System.Windows.Forms.Label()
        Me.lblDangDT = New System.Windows.Forms.Label()
        Me.dtgDangDT = New XMLCreator.GridParam()
        Me.ddtchon = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.ma = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ten = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dtgDoiTuong = New XMLCreator.GridParam()
        Me.dChon = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.madt = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tendt = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dtgKK = New XMLCreator.GridParam()
        Me.kchon = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.makk = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tenkk = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txttungay = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtdenngay = New System.Windows.Forms.TextBox()
        Me.chkDaTT = New System.Windows.Forms.CheckBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.btnXuatXML = New System.Windows.Forms.Button()
        Me.txtmakcb = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnLayBN = New System.Windows.Forms.Button()
        Me.lbltrangthai = New System.Windows.Forms.Label()
        Me.chkViewDS = New System.Windows.Forms.CheckBox()
        Me.chkStep5 = New System.Windows.Forms.CheckBox()
        Me.tt = New System.Windows.Forms.ToolTip(Me.components)
        Me.chkXuatLuon = New System.Windows.Forms.CheckBox()
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.btnStop = New System.Windows.Forms.Button()
        Me.btnUpTT = New System.Windows.Forms.Button()
        Me.chkAutoEX = New System.Windows.Forms.CheckBox()
        Me.tmAutoExportXML = New System.Windows.Forms.Timer(Me.components)
        Me.chkXuat121 = New System.Windows.Forms.CheckBox()
        Me.txtFldSave = New System.Windows.Forms.TextBox()
        Me.chkBH = New System.Windows.Forms.CheckBox()
        Me.pnHeader.SuspendLayout()
        Me.pnAction.SuspendLayout()
        CType(Me.DataSetNguon, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtgdata, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtgDangDT, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtgDoiTuong, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtgKK, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnHeader
        '
        Me.pnHeader.Controls.Add(Me.PictureBox1)
        Me.pnHeader.Controls.Add(Me.chkDaTT)
        Me.pnHeader.Controls.Add(Me.txtdenngay)
        Me.pnHeader.Controls.Add(Me.txtmakcb)
        Me.pnHeader.Controls.Add(Me.txttungay)
        Me.pnHeader.Controls.Add(Me.dtgDangDT)
        Me.pnHeader.Controls.Add(Me.lblDangDT)
        Me.pnHeader.Controls.Add(Me.dtgDoiTuong)
        Me.pnHeader.Controls.Add(Me.lblDoiTuong)
        Me.pnHeader.Controls.Add(Me.dtgKK)
        Me.pnHeader.Controls.Add(Me.Label2)
        Me.pnHeader.Controls.Add(Me.Label1)
        Me.pnHeader.Controls.Add(Me.Label3)
        Me.pnHeader.Controls.Add(Me.lblKK)
        Me.pnHeader.Size = New System.Drawing.Size(973, 62)
        Me.pnHeader.TabIndex = 0
        '
        'pnAction
        '
        Me.pnAction.Controls.Add(Me.chkXuatLuon)
        Me.pnAction.Controls.Add(Me.btnXuatXML)
        Me.pnAction.Controls.Add(Me.chkAutoEX)
        Me.pnAction.Controls.Add(Me.chkStep5)
        Me.pnAction.Controls.Add(Me.chkViewDS)
        Me.pnAction.Controls.Add(Me.btnLayBN)
        Me.pnAction.Controls.Add(Me.btnUpTT)
        Me.pnAction.Controls.Add(Me.btnStop)
        Me.pnAction.Controls.Add(Me.lbltrangthai)
        Me.pnAction.Location = New System.Drawing.Point(0, 392)
        Me.pnAction.Size = New System.Drawing.Size(973, 34)
        '
        'dtgdata
        '
        Me.dtgdata.AllowUserToAddRows = False
        Me.dtgdata.AllowUserToDeleteRows = False
        Me.dtgdata.AllowUserToResizeRows = False
        Me.dtgdata.AutoGenerateColumns = False
        Me.dtgdata.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(245, Byte), Integer))
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(245, Byte), Integer))
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Arial", 10.0!)
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle7.Padding = New System.Windows.Forms.Padding(3)
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dtgdata.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle7
        Me.dtgdata.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtgdata.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.MaKCB, Me.HoTen, Me.DangDT, Me.NgayTT})
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Arial", 10.0!)
        DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer))
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dtgdata.DefaultCellStyle = DataGridViewCellStyle8
        Me.dtgdata.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dtgdata.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.dtgdata.EnableHeadersVisualStyles = False
        Me.dtgdata.Location = New System.Drawing.Point(0, 62)
        Me.dtgdata.MultiSelect = False
        Me.dtgdata.Name = "dtgdata"
        Me.dtgdata.ReadOnly = True
        Me.dtgdata.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black
        Me.dtgdata.Size = New System.Drawing.Size(973, 330)
        Me.dtgdata.TabIndex = 9
        '
        'MaKCB
        '
        Me.MaKCB.DataPropertyName = "MaKCB"
        Me.MaKCB.HeaderText = "Mã KCB"
        Me.MaKCB.Name = "MaKCB"
        Me.MaKCB.ReadOnly = True
        Me.MaKCB.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'HoTen
        '
        Me.HoTen.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.HoTen.DataPropertyName = "HoTen"
        Me.HoTen.HeaderText = "Họ tên"
        Me.HoTen.Name = "HoTen"
        Me.HoTen.ReadOnly = True
        '
        'DangDT
        '
        Me.DangDT.DataPropertyName = "DangDT"
        Me.DangDT.HeaderText = "Nội trú"
        Me.DangDT.Name = "DangDT"
        Me.DangDT.ReadOnly = True
        Me.DangDT.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DangDT.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'NgayTT
        '
        Me.NgayTT.DataPropertyName = "NgayTT"
        Me.NgayTT.HeaderText = "Ngày TT"
        Me.NgayTT.Name = "NgayTT"
        Me.NgayTT.ReadOnly = True
        Me.NgayTT.Width = 150
        '
        'lblKK
        '
        Me.lblKK.AutoSize = True
        Me.lblKK.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblKK.Location = New System.Drawing.Point(4, 8)
        Me.lblKK.Name = "lblKK"
        Me.lblKK.Size = New System.Drawing.Size(45, 16)
        Me.lblKK.TabIndex = 0
        Me.lblKK.Text = "Khoa:"
        '
        'lblDoiTuong
        '
        Me.lblDoiTuong.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblDoiTuong.AutoSize = True
        Me.lblDoiTuong.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblDoiTuong.Location = New System.Drawing.Point(405, 8)
        Me.lblDoiTuong.Name = "lblDoiTuong"
        Me.lblDoiTuong.Size = New System.Drawing.Size(75, 16)
        Me.lblDoiTuong.TabIndex = 0
        Me.lblDoiTuong.Text = "Đối tượng:"
        '
        'lblDangDT
        '
        Me.lblDangDT.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblDangDT.AutoSize = True
        Me.lblDangDT.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblDangDT.Location = New System.Drawing.Point(655, 8)
        Me.lblDangDT.Name = "lblDangDT"
        Me.lblDangDT.Size = New System.Drawing.Size(67, 16)
        Me.lblDangDT.TabIndex = 0
        Me.lblDangDT.Text = "Dạng ĐT:"
        '
        'dtgDangDT
        '
        Me.dtgDangDT.AllowUserToAddRows = False
        Me.dtgDangDT.AllowUserToDeleteRows = False
        Me.dtgDangDT.AllowUserToResizeRows = False
        Me.dtgDangDT.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtgDangDT.AutoGenerateColumns = False
        Me.dtgDangDT.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(245, Byte), Integer))
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(245, Byte), Integer))
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Arial", 10.0!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.Padding = New System.Windows.Forms.Padding(3)
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dtgDangDT.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dtgDangDT.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtgDangDT.ColumnHeadersVisible = False
        Me.dtgDangDT.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ddtchon, Me.ma, Me.ten})
        Me.dtgDangDT.Cursor = System.Windows.Forms.Cursors.Default
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Arial", 10.0!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer))
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dtgDangDT.DefaultCellStyle = DataGridViewCellStyle2
        Me.dtgDangDT.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.dtgDangDT.EnableHeadersVisualStyles = False
        Me.dtgDangDT.Location = New System.Drawing.Point(722, 3)
        Me.dtgDangDT.MaximumSize = New System.Drawing.Size(10000, 245)
        Me.dtgDangDT.MaxSizePic = 14
        Me.dtgDangDT.MinimumSize = New System.Drawing.Size(0, 25)
        Me.dtgDangDT.MultiSelect = False
        Me.dtgDangDT.Name = "dtgDangDT"
        Me.dtgDangDT.RowHeadersVisible = False
        Me.dtgDangDT.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black
        Me.dtgDangDT.Size = New System.Drawing.Size(247, 25)
        Me.dtgDangDT.TabIndex = 2
        '
        'ddtchon
        '
        Me.ddtchon.DataPropertyName = "chon"
        Me.ddtchon.HeaderText = ""
        Me.ddtchon.Name = "ddtchon"
        Me.ddtchon.Width = 35
        '
        'ma
        '
        Me.ma.DataPropertyName = "ma"
        Me.ma.HeaderText = "Mã"
        Me.ma.Name = "ma"
        Me.ma.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ma.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ma.Visible = False
        '
        'ten
        '
        Me.ten.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.ten.DataPropertyName = "ten"
        Me.ten.HeaderText = "Tên"
        Me.ten.Name = "ten"
        Me.ten.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ten.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'dtgDoiTuong
        '
        Me.dtgDoiTuong.AllowUserToAddRows = False
        Me.dtgDoiTuong.AllowUserToDeleteRows = False
        Me.dtgDoiTuong.AllowUserToResizeRows = False
        Me.dtgDoiTuong.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtgDoiTuong.AutoGenerateColumns = False
        Me.dtgDoiTuong.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(245, Byte), Integer))
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(245, Byte), Integer))
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Arial", 10.0!)
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.Padding = New System.Windows.Forms.Padding(3)
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dtgDoiTuong.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dtgDoiTuong.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtgDoiTuong.ColumnHeadersVisible = False
        Me.dtgDoiTuong.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dChon, Me.madt, Me.tendt})
        Me.dtgDoiTuong.Cursor = System.Windows.Forms.Cursors.Default
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Arial", 10.0!)
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer))
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dtgDoiTuong.DefaultCellStyle = DataGridViewCellStyle4
        Me.dtgDoiTuong.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.dtgDoiTuong.EnableHeadersVisualStyles = False
        Me.dtgDoiTuong.Location = New System.Drawing.Point(481, 3)
        Me.dtgDoiTuong.MaximumSize = New System.Drawing.Size(10000, 245)
        Me.dtgDoiTuong.MaxSizePic = 14
        Me.dtgDoiTuong.MinimumSize = New System.Drawing.Size(0, 25)
        Me.dtgDoiTuong.MultiSelect = False
        Me.dtgDoiTuong.Name = "dtgDoiTuong"
        Me.dtgDoiTuong.RowHeadersVisible = False
        Me.dtgDoiTuong.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black
        Me.dtgDoiTuong.Size = New System.Drawing.Size(171, 25)
        Me.dtgDoiTuong.TabIndex = 1
        '
        'dChon
        '
        Me.dChon.DataPropertyName = "chon"
        Me.dChon.HeaderText = ""
        Me.dChon.Name = "dChon"
        Me.dChon.Width = 35
        '
        'madt
        '
        Me.madt.DataPropertyName = "madt"
        Me.madt.HeaderText = "Mã DT"
        Me.madt.Name = "madt"
        Me.madt.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.madt.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.madt.Visible = False
        '
        'tendt
        '
        Me.tendt.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.tendt.DataPropertyName = "tendt"
        Me.tendt.HeaderText = "Tên đt"
        Me.tendt.Name = "tendt"
        Me.tendt.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.tendt.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'dtgKK
        '
        Me.dtgKK.AllowUserToAddRows = False
        Me.dtgKK.AllowUserToDeleteRows = False
        Me.dtgKK.AllowUserToResizeRows = False
        Me.dtgKK.AutoGenerateColumns = False
        Me.dtgKK.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(245, Byte), Integer))
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(245, Byte), Integer))
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Arial", 10.0!)
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle5.Padding = New System.Windows.Forms.Padding(3)
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dtgKK.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.dtgKK.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtgKK.ColumnHeadersVisible = False
        Me.dtgKK.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.kchon, Me.makk, Me.tenkk})
        Me.dtgKK.Cursor = System.Windows.Forms.Cursors.Default
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Arial", 10.0!)
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer))
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dtgKK.DefaultCellStyle = DataGridViewCellStyle6
        Me.dtgKK.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.dtgKK.EnableHeadersVisualStyles = False
        Me.dtgKK.Location = New System.Drawing.Point(62, 3)
        Me.dtgKK.MaximumSize = New System.Drawing.Size(10000, 245)
        Me.dtgKK.MaxSizePic = 14
        Me.dtgKK.MinimumSize = New System.Drawing.Size(216, 25)
        Me.dtgKK.MultiSelect = False
        Me.dtgKK.Name = "dtgKK"
        Me.dtgKK.RowHeadersVisible = False
        Me.dtgKK.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black
        Me.dtgKK.Size = New System.Drawing.Size(337, 25)
        Me.dtgKK.TabIndex = 0
        '
        'kchon
        '
        Me.kchon.DataPropertyName = "chon"
        Me.kchon.HeaderText = ""
        Me.kchon.Name = "kchon"
        Me.kchon.Width = 35
        '
        'makk
        '
        Me.makk.DataPropertyName = "makk"
        Me.makk.HeaderText = "Mã KK"
        Me.makk.Name = "makk"
        Me.makk.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.makk.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.makk.Visible = False
        '
        'tenkk
        '
        Me.tenkk.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.tenkk.DataPropertyName = "tenkk"
        Me.tenkk.HeaderText = "Tên khoa"
        Me.tenkk.Name = "tenkk"
        Me.tenkk.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.tenkk.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Label1.Location = New System.Drawing.Point(529, 36)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(65, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Từ ngày:"
        '
        'txttungay
        '
        Me.txttungay.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txttungay.Location = New System.Drawing.Point(601, 33)
        Me.txttungay.Name = "txttungay"
        Me.txttungay.Size = New System.Drawing.Size(121, 23)
        Me.txttungay.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Label2.Location = New System.Drawing.Point(729, 36)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(13, 16)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "-"
        '
        'txtdenngay
        '
        Me.txtdenngay.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtdenngay.Location = New System.Drawing.Point(749, 33)
        Me.txtdenngay.Name = "txtdenngay"
        Me.txtdenngay.Size = New System.Drawing.Size(121, 23)
        Me.txtdenngay.TabIndex = 4
        '
        'chkDaTT
        '
        Me.chkDaTT.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkDaTT.AutoSize = True
        Me.chkDaTT.Checked = True
        Me.chkDaTT.CheckState = System.Windows.Forms.CheckState.Indeterminate
        Me.chkDaTT.Location = New System.Drawing.Point(876, 34)
        Me.chkDaTT.Name = "chkDaTT"
        Me.chkDaTT.Size = New System.Drawing.Size(67, 20)
        Me.chkDaTT.TabIndex = 5
        Me.chkDaTT.Text = "Đã TT"
        Me.chkDaTT.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox1.Image = Global.XMLCreator.My.Resources.Resources.Refresh16
        Me.PictureBox1.Location = New System.Drawing.Point(949, 35)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(20, 19)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 4
        Me.PictureBox1.TabStop = False
        '
        'btnXuatXML
        '
        Me.btnXuatXML.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnXuatXML.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.btnXuatXML.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnXuatXML.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btnXuatXML.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnXuatXML.Font = New System.Drawing.Font("Arial", 10.0!)
        Me.btnXuatXML.Image = Global.XMLCreator.My.Resources.Resources.write
        Me.btnXuatXML.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnXuatXML.Location = New System.Drawing.Point(876, 1)
        Me.btnXuatXML.Name = "btnXuatXML"
        Me.btnXuatXML.Size = New System.Drawing.Size(94, 30)
        Me.btnXuatXML.TabIndex = 0
        Me.btnXuatXML.Text = "Xuất XML"
        Me.btnXuatXML.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnXuatXML.UseVisualStyleBackColor = False
        '
        'txtmakcb
        '
        Me.txtmakcb.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtmakcb.Location = New System.Drawing.Point(62, 33)
        Me.txtmakcb.Name = "txtmakcb"
        Me.txtmakcb.Size = New System.Drawing.Size(463, 23)
        Me.txtmakcb.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Label3.Location = New System.Drawing.Point(4, 36)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(59, 16)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "MaKCB:"
        '
        'btnLayBN
        '
        Me.btnLayBN.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnLayBN.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.btnLayBN.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnLayBN.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btnLayBN.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLayBN.Font = New System.Drawing.Font("Arial", 10.0!)
        Me.btnLayBN.Image = Global.XMLCreator.My.Resources.Resources.report
        Me.btnLayBN.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnLayBN.Location = New System.Drawing.Point(738, 1)
        Me.btnLayBN.Name = "btnLayBN"
        Me.btnLayBN.Size = New System.Drawing.Size(121, 30)
        Me.btnLayBN.TabIndex = 0
        Me.btnLayBN.Text = "Tạo lại XML    "
        Me.btnLayBN.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnLayBN.UseVisualStyleBackColor = False
        '
        'lbltrangthai
        '
        Me.lbltrangthai.AutoSize = True
        Me.lbltrangthai.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lbltrangthai.ForeColor = System.Drawing.Color.Red
        Me.lbltrangthai.Location = New System.Drawing.Point(11, 8)
        Me.lbltrangthai.Name = "lbltrangthai"
        Me.lbltrangthai.Size = New System.Drawing.Size(0, 16)
        Me.lbltrangthai.TabIndex = 0
        '
        'chkViewDS
        '
        Me.chkViewDS.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkViewDS.AutoSize = True
        Me.chkViewDS.Checked = True
        Me.chkViewDS.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkViewDS.Location = New System.Drawing.Point(861, 2)
        Me.chkViewDS.Name = "chkViewDS"
        Me.chkViewDS.Size = New System.Drawing.Size(15, 14)
        Me.chkViewDS.TabIndex = 1
        Me.tt.SetToolTip(Me.chkViewDS, "Lấy ra danh sách bệnh nhân")
        Me.chkViewDS.UseVisualStyleBackColor = True
        '
        'chkStep5
        '
        Me.chkStep5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkStep5.AutoSize = True
        Me.chkStep5.Location = New System.Drawing.Point(861, 17)
        Me.chkStep5.Name = "chkStep5"
        Me.chkStep5.Size = New System.Drawing.Size(15, 14)
        Me.chkStep5.TabIndex = 1
        Me.tt.SetToolTip(Me.chkStep5, "Chạy nền")
        Me.chkStep5.UseVisualStyleBackColor = True
        '
        'tt
        '
        Me.tt.AutomaticDelay = 200
        Me.tt.AutoPopDelay = 5000
        Me.tt.InitialDelay = 200
        Me.tt.ReshowDelay = 40
        Me.tt.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info
        Me.tt.ToolTipTitle = "Info"
        '
        'chkXuatLuon
        '
        Me.chkXuatLuon.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkXuatLuon.AutoSize = True
        Me.chkXuatLuon.Location = New System.Drawing.Point(840, 10)
        Me.chkXuatLuon.Name = "chkXuatLuon"
        Me.chkXuatLuon.Size = New System.Drawing.Size(15, 14)
        Me.chkXuatLuon.TabIndex = 3
        Me.tt.SetToolTip(Me.chkXuatLuon, "Tạo xong xuất luôn")
        Me.chkXuatLuon.UseVisualStyleBackColor = True
        '
        'btnStop
        '
        Me.btnStop.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnStop.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.btnStop.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnStop.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btnStop.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnStop.Font = New System.Drawing.Font("Arial", 10.0!)
        Me.btnStop.Image = Global.XMLCreator.My.Resources.Resources.Delete
        Me.btnStop.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnStop.Location = New System.Drawing.Point(636, 1)
        Me.btnStop.Name = "btnStop"
        Me.btnStop.Size = New System.Drawing.Size(100, 30)
        Me.btnStop.TabIndex = 0
        Me.btnStop.Text = "Tạm dừng"
        Me.btnStop.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnStop.UseVisualStyleBackColor = False
        '
        'btnUpTT
        '
        Me.btnUpTT.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnUpTT.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.btnUpTT.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnUpTT.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btnUpTT.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnUpTT.Font = New System.Drawing.Font("Arial", 10.0!)
        Me.btnUpTT.Image = Global.XMLCreator.My.Resources.Resources.Ok
        Me.btnUpTT.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnUpTT.Location = New System.Drawing.Point(538, 1)
        Me.btnUpTT.Name = "btnUpTT"
        Me.btnUpTT.Size = New System.Drawing.Size(96, 30)
        Me.btnUpTT.TabIndex = 0
        Me.btnUpTT.Text = "Cập nhật"
        Me.btnUpTT.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnUpTT.UseVisualStyleBackColor = False
        '
        'chkAutoEX
        '
        Me.chkAutoEX.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkAutoEX.AutoSize = True
        Me.chkAutoEX.Location = New System.Drawing.Point(393, 6)
        Me.chkAutoEX.Name = "chkAutoEX"
        Me.chkAutoEX.Size = New System.Drawing.Size(142, 20)
        Me.chkAutoEX.TabIndex = 2
        Me.chkAutoEX.Text = "Tự động xuất XML"
        Me.chkAutoEX.UseVisualStyleBackColor = True
        '
        'tmAutoExportXML
        '
        Me.tmAutoExportXML.Enabled = True
        Me.tmAutoExportXML.Interval = 60000
        '
        'chkXuat121
        '
        Me.chkXuat121.AutoSize = True
        Me.chkXuat121.Location = New System.Drawing.Point(210, 66)
        Me.chkXuat121.Name = "chkXuat121"
        Me.chkXuat121.Size = New System.Drawing.Size(51, 20)
        Me.chkXuat121.TabIndex = 2
        Me.chkXuat121.Text = "121"
        Me.chkXuat121.UseVisualStyleBackColor = True
        '
        'txtFldSave
        '
        Me.txtFldSave.Location = New System.Drawing.Point(315, 64)
        Me.txtFldSave.Name = "txtFldSave"
        Me.txtFldSave.Size = New System.Drawing.Size(156, 23)
        Me.txtFldSave.TabIndex = 4
        '
        'chkBH
        '
        Me.chkBH.AutoSize = True
        Me.chkBH.Location = New System.Drawing.Point(267, 66)
        Me.chkBH.Name = "chkBH"
        Me.chkBH.Size = New System.Drawing.Size(45, 20)
        Me.chkBH.TabIndex = 2
        Me.chkBH.Text = "BH"
        Me.chkBH.UseVisualStyleBackColor = True
        '
        'frmXuatXML
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(973, 426)
        Me.Controls.Add(Me.chkBH)
        Me.Controls.Add(Me.chkXuat121)
        Me.Controls.Add(Me.txtFldSave)
        Me.Controls.Add(Me.dtgdata)
        Me.Margin = New System.Windows.Forms.Padding(3, 6, 3, 6)
        Me.Name = "frmXuatXML"
        Me.Text = "Xuất XML"
        Me.Controls.SetChildIndex(Me.pnHeader, 0)
        Me.Controls.SetChildIndex(Me.pnAction, 0)
        Me.Controls.SetChildIndex(Me.dtgdata, 0)
        Me.Controls.SetChildIndex(Me.txtFldSave, 0)
        Me.Controls.SetChildIndex(Me.chkXuat121, 0)
        Me.Controls.SetChildIndex(Me.chkBH, 0)
        Me.pnHeader.ResumeLayout(False)
        Me.pnHeader.PerformLayout()
        Me.pnAction.ResumeLayout(False)
        Me.pnAction.PerformLayout()
        CType(Me.DataSetNguon, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtgdata, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtgDangDT, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtgDoiTuong, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtgKK, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents dtgdata As DataGridView
    Friend WithEvents dtgKK As GridParam
    Friend WithEvents lblKK As Label
    Friend WithEvents kchon As DataGridViewCheckBoxColumn
    Friend WithEvents makk As DataGridViewTextBoxColumn
    Friend WithEvents tenkk As DataGridViewTextBoxColumn
    Friend WithEvents dtgDoiTuong As GridParam
    Friend WithEvents lblDoiTuong As Label
    Friend WithEvents dChon As DataGridViewCheckBoxColumn
    Friend WithEvents madt As DataGridViewTextBoxColumn
    Friend WithEvents tendt As DataGridViewTextBoxColumn
    Friend WithEvents dtgDangDT As GridParam
    Friend WithEvents lblDangDT As Label
    Friend WithEvents ddtchon As DataGridViewCheckBoxColumn
    Friend WithEvents ma As DataGridViewTextBoxColumn
    Friend WithEvents ten As DataGridViewTextBoxColumn
    Friend WithEvents txtdenngay As TextBox
    Friend WithEvents txttungay As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents chkDaTT As CheckBox
    Friend WithEvents btnXuatXML As Button
    Friend WithEvents txtmakcb As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents btnLayBN As System.Windows.Forms.Button
    Friend WithEvents lbltrangthai As System.Windows.Forms.Label
    Friend WithEvents chkStep5 As System.Windows.Forms.CheckBox
    Friend WithEvents chkViewDS As System.Windows.Forms.CheckBox
    Friend WithEvents tt As System.Windows.Forms.ToolTip
    Friend WithEvents MaKCB As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents HoTen As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DangDT As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents NgayTT As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents btnStop As System.Windows.Forms.Button
    Friend WithEvents btnUpTT As System.Windows.Forms.Button
    Friend WithEvents chkAutoEX As System.Windows.Forms.CheckBox
    Friend WithEvents tmAutoExportXML As System.Windows.Forms.Timer
    Friend WithEvents chkXuatLuon As System.Windows.Forms.CheckBox
    Friend WithEvents chkXuat121 As System.Windows.Forms.CheckBox
    Friend WithEvents txtFldSave As System.Windows.Forms.TextBox
    Friend WithEvents chkBH As System.Windows.Forms.CheckBox
End Class
