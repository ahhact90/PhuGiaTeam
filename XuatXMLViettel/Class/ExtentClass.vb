#Region "Class"
Public Class ExtentPropCollection
    Inherits CollectionBase
    Public Event AddItem(ByVal e As ExtentObject)
    Public Event RemoveItem(ByVal e As ExtentObject, ByRef RollBack As Boolean)
    ''' <summary>
    ''' Thêm dữ liệu vào extent property 
    ''' </summary>
    ''' <param name="c">object cần thêm</param>
    ''' <remarks></remarks>
    Sub Add(ByVal c As ExtentObject)
        If Me.Item(c.key) IsNot Nothing Then
            List.Remove(Me.Item(c.key))
        End If
        List.Add(c)
        RaiseEvent AddItem(Item(c.key))
    End Sub
    ''' <summary>
    ''' Thêm dữ liệu vào extent property
    ''' </summary>
    ''' <param name="c">object cần thêm</param>
    ''' <param name="k">key để tìm kiếm</param>
    ''' <remarks></remarks>
    Sub Add(ByVal c As Object, ByVal k As String)
        Add(New ExtentObject(k, c))
        RaiseEvent AddItem(Item(k))
    End Sub
    ''' <summary>
    ''' Gỡ ra khỏi properties
    ''' </summary>
    ''' <param name="K">Khóa để gỡ</param>
    ''' <remarks></remarks>
    Sub Remove(ByVal K As String)
        Dim _RollBack As Boolean = False
        RaiseEvent RemoveItem(Item(K), _RollBack)
        If Not _RollBack AndAlso Me.Item(K) IsNot Nothing Then List.Remove(Me.Item(K))
    End Sub
    ''' <summary>
    ''' Lấy ra item trong properties
    ''' </summary>   
    ReadOnly Property Items As System.Collections.IList
        Get
            Return List
        End Get
    End Property
    ''' <summary>
    ''' Lấy ra item trong properties
    ''' </summary>
    ''' <param name="i">Index của item</param>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property Item(ByVal i As Integer) As ExtentObject
        Get
            Return List(i)
        End Get
        Set(ByVal value As ExtentObject)
            List(i) = value
        End Set
    End Property
    ''' <summary>
    ''' Lấy ra item trong properties
    ''' </summary>
    ''' <param name="s">Key của item</param>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property Item(ByVal s As String) As ExtentObject
        Get
            If List Is Nothing Then Return Nothing
            For i = 0 To List.Count - 1
                If List(i) IsNot Nothing AndAlso List(i).key = s Then
                    Return List(i)
                End If
            Next
            Return Nothing
        End Get
    End Property
End Class
Public Class ExtentObject
    Private _key As String
    Property key As String
        Get
            Return _key
        End Get
        Set(ByVal value As String)
            _key = value
        End Set
    End Property
    Public _Val As Object
    Overloads Property Val As Object
        Get
            Return _Val
        End Get
        Set(ByVal value As Object)
            _Val = value
        End Set
    End Property
    Sub New(ByVal k As String, ByVal o As Object)
        _key = k
        _Val = o
    End Sub
    Sub New()

    End Sub
End Class
Public Class ExtenPropertiesComment
    ''' <summary>
    ''' Data source cho các control
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared Function DataSourceControl(ByVal c As Object) As String
        Return c.Name & "-DataSource"
    End Function
    ''' <summary>
    ''' Datatable cho các DataSource
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared Function DataSourceTable(ByVal c As Object) As String
        Return c.Name & "-SourceTI"
    End Function
    ''' <summary>
    ''' Data Fields để find dữ liệu cho các control: [idx bảng]![idx dòng]![tên cột dữ liệu]
    ''' </summary>
    ''' <param name="c"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function ColumnDataFill(ByVal c As Object) As String
        Return c.Name & "-GetFields"
    End Function
    ''' <summary>
    ''' Render Column Fill Data
    ''' </summary>
    ''' <param name="ColName">Tên cột dữ liệu</param>
    ''' <param name="TabIndex">Index bảng</param>
    ''' <param name="RowIndex">Index Dòng</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetFieldsSurport(ByVal ColName As String, Optional ByVal TabIndex As Integer = 0, Optional ByVal RowIndex As Integer = 0) As String
        Return TabIndex & "!" & RowIndex & "!" & ColName
    End Function
    ''' <summary>
    ''' Định nghĩa control nhập liệu kiểu số nguyên
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared Function NhapSoNguyen(ByVal c As Object) As String
        Return c.Name & "-NhapSoNguyen"
    End Function
    ''' <summary>
    ''' Định nghĩa control nhập số thập phân
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared Function NhapSoLe(ByVal c As Object) As String
        Return c.Name & "-NhapSoLe"
    End Function
    ''' <summary>
    ''' Định nghĩa control nhập ngày tháng
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared Function NhapNgayThang(ByVal c As Object) As String
        Return c.Name & "-NhapNgayThang"
    End Function
    ''' <summary>
    ''' Định nghĩa control nhập giờ HH:mm:ss
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared Function NhapGioFull(ByVal c As Object) As String
        Return c.Name & "-NhapGioFull"
    End Function
    ''' <summary>
    ''' Định nghĩa control nhập giờ HH:mm
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared Function NhapGioPhut(ByVal c As Object) As String
        Return c.Name & "-NhapGioPhut"
    End Function
    ''' <summary>
    ''' Định nghĩa control nhập  ngày giờ
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared Function NhapNgayGio(ByVal c As Object) As String
        Return c.Name & "-NhapNgayGio"
    End Function
    ''' <summary>
    ''' Định nghĩa select value của control dạng combobox
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared Function SelectVal(ByVal c As Object) As String
        Return c.Name & "-SelectVal"
    End Function
    ''' <summary>
    ''' Định nghĩa select value của cột trên datagrid dạng combobox
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared Function SelectVal(ByVal c As Object, ByVal rowIndex As Integer) As String
        Return c.Name & "-" & rowIndex & "-SelectVal"
    End Function
    ''' <summary>
    ''' Định nghĩa các control không được kéo thả
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared Function NoMove(ByVal c As Object) As String
        Return c.Name & "-NoMove"
    End Function
    ''' <summary>
    ''' Định nghĩa control nạp ngược nhắc lệnh vào danh mục nhắc lệnh
    ''' </summary>
    ''' <param name="c"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function NapNguocDM(ByVal c As Object) As String
        Return c.Name & "-NapNguocDanhMuc"
    End Function
    ''' <summary>
    ''' Định nghĩa control đang hiển thị lưới tiện ích
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function ControlHienLuoi() As String
        Return "DTGTI-ControlHienLuoi"
    End Function
    ''' <summary>
    ''' Định nghĩa control nhập họ tên
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function NhapHoTen(ByVal c As Object) As String
        Return c.Name & "-NhapHoTen"
    End Function
    ''' <summary>
    ''' Định nghĩa control not null
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function NotNull(ByVal c As Object) As String
        Return c.Name & "-NotNull"
    End Function
    ''' <summary>
    ''' Định nghĩa giá trị max của control
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function MaxValue(ByVal c As Object) As String
        Return c.Name & "-MaxValue"
    End Function
    ''' <summary>
    ''' Định nghĩa giá trị min của control
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function MinValue(ByVal c As Object) As String
        Return c.Name & "-MinValue"
    End Function
End Class
Public Class PropertiesObject
    Private Anchor_ As AnchorStyles = AnchorStyles.Top Or AnchorStyles.Left
    Private AutoSize_ As Boolean = True
    Private BackColor_ As Color = Color.White
    Private Dock_ As DockStyle = DockStyle.None
    Private Enabled_ As Boolean = True
    Private Font_ As Font = New Font("Arial", 10, FontStyle.Regular)
    Private ForeColor_ As Color = Color.Black
    Private MaximumSize_ As Size = New Size(0, 0)
    Private MinimumSize_ As Size = New Size(0, 0)
    Private Name_ As String = ""
    Private TabIndex_ As Integer = 1
    Private Text_ As String = ""
    Private UseWaitCursor_ As Boolean = False
    Private Visible_ As Boolean = True
    Private Padding_ As Padding = New Padding(0)
    Private BorderStyle_ As BorderStyle = BorderStyle.None
    Private DataSource_ As String = ""
    Private DataFields_ As String = ""
    Private KieuNhapLieu_ As KieuNhapLieu = KieuNhapLieu.KhongChon
    Private NoMove_ As Boolean = False
    Private NapNguocDM_ As Integer = 0
    Private Control_ As Object = Nothing
    <System.ComponentModel.Category("From Control")>
    Property Anchor As AnchorStyles
        Get
            Return Anchor_
        End Get
        Set(ByVal value As AnchorStyles)
            Anchor_ = value
        End Set
    End Property
    <System.ComponentModel.Category("From Control")>
    Property AutoSize As Boolean
        Get
            Return AutoSize_
        End Get
        Set(ByVal value As Boolean)
            AutoSize_ = value
        End Set
    End Property
    <System.ComponentModel.Category("From Control")>
    Property BackColor As Color
        Get
            Return BackColor_
        End Get
        Set(ByVal value As Color)
            BackColor_ = value
        End Set
    End Property
    <System.ComponentModel.Category("From Control")>
    Property Dock As DockStyle
        Get
            Return Dock_
        End Get
        Set(ByVal value As DockStyle)
            Dock_ = value
        End Set
    End Property
    <System.ComponentModel.Category("From Control")>
    Property Enabled As Boolean
        Get
            Return Enabled_
        End Get
        Set(ByVal value As Boolean)
            Enabled_ = value
        End Set
    End Property
    <System.ComponentModel.Category("From Control")>
    Property Font As Font
        Get
            Return Font_
        End Get
        Set(ByVal value As Font)
            Font_ = value
        End Set
    End Property
    <System.ComponentModel.Category("From Control")>
    Property ForeColor As Color
        Get
            Return ForeColor_
        End Get
        Set(ByVal value As Color)
            ForeColor_ = value
        End Set
    End Property
    <System.ComponentModel.Category("From Control")>
    Property MaximumSize As Size
        Get
            Return MaximumSize_
        End Get
        Set(ByVal value As Size)
            MaximumSize_ = value
        End Set
    End Property
    <System.ComponentModel.Category("From Control")>
    Property MinimumSize As Size
        Get
            Return MinimumSize_
        End Get
        Set(ByVal value As Size)
            MinimumSize_ = value
        End Set
    End Property
    <System.ComponentModel.Category("From Control")>
    Property Name As String
        Get
            Return Name_
        End Get
        Set(ByVal value As String)
            If Not String.IsNullOrEmpty(value) Then Name_ = value
        End Set
    End Property
    <System.ComponentModel.Category("From Control")>
    Property TabIndex As Integer
        Get
            Return TabIndex_
        End Get
        Set(ByVal value As Integer)
            TabIndex_ = value
        End Set
    End Property
    <System.ComponentModel.Category("From Control"), System.ComponentModel.Localizable(True), System.ComponentModel.Editor("System.ComponentModel.Design.MultilineStringEditor", GetType(System.Drawing.Design.UITypeEditor))>
    Property Text As String
        Get
            Return Text_
        End Get
        Set(ByVal value As String)
            Text_ = value
        End Set
    End Property
    <System.ComponentModel.Category("From Control")>
    Property UseWaitCursor As Boolean
        Get
            Return UseWaitCursor_
        End Get
        Set(ByVal value As Boolean)
            UseWaitCursor_ = value
        End Set
    End Property
    <System.ComponentModel.Category("From Control")>
    Property Visible As Boolean
        Get
            Return Visible_
        End Get
        Set(ByVal value As Boolean)
            Visible_ = value
        End Set
    End Property
    <System.ComponentModel.Category("From Control")>
    Property Padding As Padding
        Get
            Return Padding_
        End Get
        Set(ByVal value As Padding)
            Padding_ = value
        End Set
    End Property
    <System.ComponentModel.Category("From Control")>
    Property BorderStyle As BorderStyle
        Get
            Return BorderStyle_
        End Get
        Set(ByVal value As BorderStyle)
            BorderStyle_ = value
        End Set
    End Property
    <System.ComponentModel.Category("Extent Properties"), System.ComponentModel.Localizable(True), System.ComponentModel.Editor("System.ComponentModel.Design.MultilineStringEditor, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", GetType(System.Drawing.Design.UITypeEditor))>
    Property DataSource As String
        Get
            Return DataSource_
        End Get
        Set(ByVal value As String)
            DataSource_ = value
        End Set
    End Property
    <System.ComponentModel.Category("Extent Properties")>
    Property DataFields As String
        Get
            Return DataFields_
        End Get
        Set(ByVal value As String)
            DataFields_ = value
        End Set
    End Property
    <System.ComponentModel.Category("Extent Properties")>
    Property KieuNhapLieu As KieuNhapLieu
        Get
            Return KieuNhapLieu_
        End Get
        Set(ByVal value As KieuNhapLieu)
            KieuNhapLieu_ = value
        End Set
    End Property
    <System.ComponentModel.Category("Extent Properties")>
    Property NoMove As Boolean
        Get
            Return NoMove_
        End Get
        Set(ByVal value As Boolean)
            NoMove_ = value
        End Set
    End Property
    <System.ComponentModel.Category("Extent Properties")>
    Property NapNguocDanhMuc As Integer
        Get
            Return NapNguocDM_
        End Get
        Set(ByVal value As Integer)
            NapNguocDM_ = value
        End Set
    End Property
    <System.ComponentModel.Browsable(False)>
    Property Control As Object
        Get
            Return Control_
        End Get
        Set(ByVal value As Object)
            Control_ = value
        End Set
    End Property
    Public Sub RenControl()
        If Control.GetType().GetProperty("Anchor") IsNot Nothing Then Control.Anchor = Anchor_
        If Control.GetType().GetProperty("AutoSize") IsNot Nothing Then Control.AutoSize = AutoSize_
        If Control.GetType().GetProperty("BackColor") IsNot Nothing Then Control.BackColor = BackColor_
        If Control.GetType().GetProperty("Dock") IsNot Nothing Then Control.Dock = Dock_
        If Control.GetType().GetProperty("Enabled") IsNot Nothing Then Control.Enabled = Enabled_
        If Control.GetType().GetProperty("Font") IsNot Nothing Then Control.Font = Font_
        If Control.GetType().GetProperty("ForeColor") IsNot Nothing Then Control.ForeColor = ForeColor_
        If Control.GetType().GetProperty("MaximumSize") IsNot Nothing Then Control.MaximumSize = MaximumSize_
        If Control.GetType().GetProperty("MinimumSize") IsNot Nothing Then Control.MinimumSize = MinimumSize_
        'If Not String.IsNullOrEmpty(Name_) Then Control.Name = Name_
        If Control.GetType().GetProperty("TabIndex") IsNot Nothing Then Control.TabIndex = TabIndex_
        If Control.GetType().GetProperty("Text") IsNot Nothing Then Control.Text = Text_
        If Control.GetType().GetProperty("UseWaitCursor") IsNot Nothing Then Control.UseWaitCursor = UseWaitCursor_
        If Control.GetType().GetProperty("Visible") IsNot Nothing Then Control.Visible = Visible_
        If Control.GetType().GetProperty("Padding") IsNot Nothing Then Control.Padding = Padding_
        If Control.GetType().GetProperty("BorderStyle") IsNot Nothing Then
            Control.BorderStyle = BorderStyle_
            If BorderStyle_ = System.Windows.Forms.BorderStyle.None AndAlso TypeOf Control Is TextBox Then
                Control.BorderStyle = BorderStyle.Fixed3D
            End If
        End If

        Dim fff As Object
        If Control.GetType().GetProperty("DataGridView") IsNot Nothing Then
            fff = Control.DataGridView.FindForm()
        Else
            fff = Control.FindForm()
        End If
        If Not String.IsNullOrEmpty(DataSource_) Then
            CType(fff, frmDesignVTR).ExtentProperties.Add(DataSource_, ExtenPropertiesComment.DataSourceControl(Control))
        End If
        If NoMove_ Then
            CType(fff, frmDesignVTR).ExtentProperties.Add(1, ExtenPropertiesComment.NoMove(Control))
        End If
        If Not String.IsNullOrEmpty(DataFields_) Then
            CType(fff, frmDesignVTR).ExtentProperties.Add(DataFields_, ExtenPropertiesComment.ColumnDataFill(Control))
        End If
        If NapNguocDM_ > 0 Then
            CType(fff, frmDesignVTR).ExtentProperties.Add(NapNguocDM_, ExtenPropertiesComment.NapNguocDM(Control))
        End If
        If KieuNhapLieu_ = KieuNhapLieu.NhapGioFull Then
            CType(fff, frmDesignVTR).ExtentProperties.Add(1, ExtenPropertiesComment.NhapGioFull(Control))
        ElseIf KieuNhapLieu_ = KieuNhapLieu.NhapGioPhut Then
            CType(fff, frmDesignVTR).ExtentProperties.Add(1, ExtenPropertiesComment.NhapGioPhut(Control))
        ElseIf KieuNhapLieu_ = KieuNhapLieu.NhapNgayGio Then
            CType(fff, frmDesignVTR).ExtentProperties.Add(1, ExtenPropertiesComment.NhapNgayGio(Control))
        ElseIf KieuNhapLieu_ = KieuNhapLieu.NhapNgayThang Then
            CType(fff, frmDesignVTR).ExtentProperties.Add(1, ExtenPropertiesComment.NhapNgayThang(Control))
        ElseIf KieuNhapLieu_ = KieuNhapLieu.NhapSoLe Then
            CType(fff, frmDesignVTR).ExtentProperties.Add(1, ExtenPropertiesComment.NhapSoLe(Control))
        ElseIf KieuNhapLieu_ = KieuNhapLieu.NhapSoNguyen Then
            CType(fff, frmDesignVTR).ExtentProperties.Add(1, ExtenPropertiesComment.NhapSoNguyen(Control))
        End If
    End Sub

End Class
Public Class DataSourceProp
    Private sourceS_ As String
    Private colVis_ As String
    Public colKey_ As String
    Public colDis_ As String
    Public ControlName_ As String
    Public ColFid_ As String

    Public RowCount_ As Integer

    Public HienColumnHeaderHeigh_ As Boolean

    ''' <summary>
    ''' Query lay dl
    ''' </summary>
    ''' <remarks></remarks>
    Property sourceS As String
        Get
            Return sourceS_
        End Get
        Set(ByVal value As String)
            sourceS_ = value
        End Set
    End Property
    ''' <summary>
    ''' Display Member
    ''' </summary>
    ''' <remarks></remarks>
    Property colVis As String
        Get
            Return colVis_
        End Get
        Set(ByVal value As String)
            colVis_ = value
        End Set
    End Property
    ''' <summary>
    ''' Value Member
    ''' </summary>
    ''' <remarks></remarks>
    Property colKey As String
        Get
            Return colKey_
        End Get
        Set(ByVal value As String)
            colKey_ = value
        End Set
    End Property
    ''' <summary>
    ''' Ds cột thể hiện trên lưới tiện ích /Tên cột/Rộng cột/
    ''' </summary>
    ''' <remarks></remarks>
    Property colDis As String
        Get
            Return colDis_
        End Get
        Set(ByVal value As String)
            colDis_ = value
        End Set
    End Property
    ''' <summary>
    ''' Tên control
    ''' </summary>
    ''' <remarks></remarks>
    Property ControlName As String
        Get
            Return ControlName_
        End Get
        Set(ByVal value As String)
            ControlName_ = value
        End Set
    End Property
    ''' <summary>
    ''' DS cột để tìm kiếm /tên cột/
    ''' </summary>
    ''' <remarks></remarks>
    Property ColFid As String
        Get
            Return ColFid_
        End Get
        Set(ByVal value As String)
            ColFid_ = value
        End Set
    End Property
    ''' <summary>
    ''' Số dòng hiển thị lưới tiện ích
    ''' </summary>
    ''' <remarks></remarks>
    Property RowCount As Integer
        Get
            Return RowCount_
        End Get
        Set(ByVal value As Integer)
            RowCount_ = value
        End Set
    End Property
    ''' <summary>
    ''' Hiện tiêu đề cột lưới tiện ích
    ''' </summary>
    ''' <remarks></remarks>
    Property HienColumnHeaderHeigh As Boolean
        Get
            Return HienColumnHeaderHeigh_
        End Get
        Set(ByVal value As Boolean)
            HienColumnHeaderHeigh_ = value
        End Set
    End Property
    ''' <summary>
    ''' Render ra datasource
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function RenderSource() As String
        Return sourceS & ";" & ControlName & ";" & colKey & ";" & colVis & ";" & colDis & ";" & ColFid & ";" & RowCount & ";" & HienColumnHeaderHeigh
    End Function
    ''' <summary>
    ''' Khởi tạo Datasoure Properties
    ''' </summary>
    ''' <param name="_sourcS">Query lay dl</param>
    ''' <param name="_colKey">Value Member</param>
    ''' <param name="_colVis">Display Member</param>
    ''' <param name="_colDis">Ds cột thể hiện trên lưới tiện ích /Tên cột/Rộng cột/</param>
    ''' <param name="_colFid">DS cột để tìm kiếm /tên cột/</param>
    ''' <param name="_colName">Tên control</param>
    ''' <param name="_rowCount">Số dòng hiển thị lưới tiện ích</param>
    ''' <param name="_hienCH">Hiện tiêu đề cột lưới tiện ích</param>
    ''' <remarks></remarks>
    Sub New(Optional ByVal _sourcS As String = "", Optional ByVal _colKey As String = "", Optional ByVal _colVis As String = "", Optional ByVal _colDis As String = "", Optional ByVal _colFid As String = "", Optional ByVal _colName As String = "", Optional ByVal _rowCount As Integer = 6, Optional ByVal _hienCH As Boolean = True)
        sourceS_ = _sourcS
        colKey_ = _colKey
        colVis_ = _colVis
        colDis_ = _colDis
        ColFid_ = _colFid
        ControlName_ = _colName
        RowCount_ = _rowCount
        HienColumnHeaderHeigh_ = _hienCH
    End Sub
End Class
#End Region
#Region "Enum"
Public Enum KieuNhapLieu
    KhongChon = 0
    NhapSoNguyen = 1
    NhapSoLe = 2
    NhapNgayThang = 3
    NhapGioFull = 4
    NhapGioPhut = 5
    NhapNgayGio = 6
End Enum
Public Enum FMstyle
    obj = 0
    Ngay = 1
    SoNguyen = 2
    SoThuc = 3
    NgayGio = 4
End Enum
Public Enum mK
    ''' <summary>
    ''' Sinh mã mới
    ''' </summary>
    ''' <remarks></remarks>
    SinhMa
    ''' <summary>
    ''' Bỏ nhớ sinh mã trên hàng đợi sinh mã
    ''' </summary>
    ''' <remarks></remarks>
    BoNhoSinhMa
    ''' <summary>
    ''' Huỷ bỏ mã vừa mới sinh ra
    ''' </summary>
    ''' <remarks></remarks>
    BoMaVuaSinh
    ''' <summary>
    ''' Coi như chưa sinh mã lần nào để bắt đầu lấy lại mã lớn nhất từ bảng trong CSDL
    ''' </summary>
    ''' <remarks></remarks>
    SinhLuon
End Enum
Public Enum Kieu
    Chuoi = 1
    So = 2
    Ngay = 3
End Enum
Public Enum NgayBenhNhan
    NgayDangKy = 1
    NgayKhamBenh = 2
    NgayVaoKhoa = 3
    NgayLapPhieu = 4
    NgayChuyenVien = 5
    NgayRaVien = 6
    NgayThanhToan = 7
    NgayLamCLS = 8
    NgayTuVong = 9
    NgayDuyetThuoc = 10
    NgayTaiNan = 11
    NgayLuuTruBenhAn = 12
    NgayXNNgheo = 13
    NgayTTNgheo = 14
    NgayTUTC = 15
    NgayDKNV = 16
    NgayChuyenKhoa = 17
End Enum
#End Region
#Region "Print"

#End Region