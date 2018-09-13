Public Module ModuleChung
#Region "Màu hệ thống"
    ''' <summary>
    ''' màu nền menu
    ''' </summary>
    ''' <remarks></remarks>
    Public MenuColor As Color = Color.FromArgb(183, 194, 211)
    ''' <summary>
    ''' màu nền item con menu
    ''' </summary>
    ''' <remarks></remarks>
    Public ItemMenuColor As Color = Color.FromArgb(233, 236, 238)
    ''' <summary>
    ''' màu nền thanh tiêu đề
    ''' </summary>
    ''' <remarks></remarks>
    Public StartColor As Color = Color.FromArgb(41, 57, 85)
    ''' <summary>
    ''' màu nền active menu
    ''' </summary>
    ''' <remarks></remarks>
    Public ActiveColor As Color = Color.FromArgb(206, 212, 223)
    ''' <summary>
    ''' màu nền form
    ''' </summary>
    ''' <remarks></remarks>
    Public BackGColor As Color = Color.FromArgb(245, 245, 245)
    ''' <summary>
    ''' màu nền select lưới
    ''' </summary>
    ''' <remarks></remarks>
    Public SelectBackColor As Color = Color.FromArgb(230, 230, 230)
    ''' <summary>
    ''' Màu viền cho các control
    ''' </summary>
    ''' <remarks></remarks>
    Public BorderColor As Color = Color.FromArgb(128, 128, 128)
    ''' <summary>
    ''' Màu chữ select trên lưới
    ''' </summary>
    ''' <remarks></remarks>
    Public SelectForeColor As Color = Color.FromArgb(0, 0, 255)
#End Region
#Region "Var"
    Public lblTitleMain_ As Label
    ''' <summary>
    ''' LBL now
    ''' </summary>
    ''' <remarks></remarks>
    Public NowLBL As ToolStripLabel
    Public BuildTime As String = "abc"
    Public dbXML As MyData.Database
    Public dbHis As MyData.Database
    Public MyFileSys As New fFile()
    Public mini As New clsIniFile
    Public TenPhanMem = "Hệ thống quản lý bệnh viện Viettel-His"
    Public TenPhanHe = "Chuyển dữ liệu lên XML"
    Public mdiClient As Control
    ''' <summary>
    ''' Tên / IP máy chủ
    ''' </summary>
    ''' <remarks></remarks>
    Public TenMayChu As String = ""
    ''' <summary>
    ''' Tên máy client
    ''' </summary>
    ''' <remarks></remarks>
    Public TenMayCon As String = ""
    ''' <summary>
    ''' Ip máy client
    ''' </summary>
    ''' <remarks></remarks>
    Public IPMayCon As String = ""
    ''' <summary>
    ''' Tên đăng nhập
    ''' </summary>
    ''' <remarks></remarks>
    Public TenDangNhap As String
#End Region
#Region "Srp"
    ''' <summary>
    ''' Active Form con
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Sub _Activated(ByVal sender As System.Object, ByVal e As System.EventArgs)
        lblTitleMain_.Text = "  " & sender.Text
    End Sub
    ''' <summary>
    ''' Close From con
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Sub _FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs)

    End Sub
    ''' <summary>
    ''' Update lại CurrentCulture
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub UpdateCurrentCulture()
        Dim fcNew = New System.Globalization.CultureInfo("en-NZ", True)
        fcNew.DateTimeFormat.ShortDatePattern = "dd/MM/yyyy"
        fcNew.DateTimeFormat.ShortTimePattern = "HH:mm:ss"
        fcNew.DateTimeFormat.AMDesignator = "AM"
        fcNew.DateTimeFormat.PMDesignator = "PM"
        fcNew.DateTimeFormat.DateSeparator = "/"
        fcNew.NumberFormat.CurrencyDecimalSeparator = ","
        fcNew.NumberFormat.CurrencyGroupSeparator = "."
        fcNew.NumberFormat.NumberDecimalSeparator = ","
        fcNew.NumberFormat.NumberGroupSeparator = "."
        fcNew.TextInfo.ListSeparator = ";"
        System.Threading.Thread.CurrentThread.CurrentCulture = fcNew
        System.Threading.Thread.CurrentThread.CurrentUICulture = fcNew
    End Sub
    Public Sub DongBoBtn(ByVal ParamArray c() As Button)
        For i = 0 To c.Length - 1
            c(i).Height = 30
            c(i).FlatStyle = FlatStyle.Flat
            c(i).FlatAppearance.BorderColor = BorderColor
            c(i).FlatAppearance.BorderSize = 1
            c(i).BackColor = BackGColor
            c(i).Font = New Font("Arial", 10)
            c(i).Cursor = Cursors.Hand
            If c(i).Image IsNot Nothing Then
                c(i).TextAlign = ContentAlignment.MiddleRight
                c(i).ImageAlign = ContentAlignment.MiddleLeft
            End If
        Next
    End Sub
    Sub openForm(ByVal o As Object)
        If My.Application.OpenForms(o.Name) IsNot Nothing Then o = My.Application.OpenForms(o.Name)
        o.MdiParent = MdiClient.FindForm
        o.top = -100000
        AddHandler CType(o, Form).Activated, AddressOf _Activated
        AddHandler CType(o, Form).FormClosed, AddressOf _FormClosed
        o.Top = 0
        o.Show()
        o.WindowState = FormWindowState.Maximized
    End Sub
    ''' <summary>
    ''' Set datasource cho 1 control
    ''' </summary>
    ''' <param name="_dt">Source cần set</param>
    ''' <param name="_val">Value member</param>
    ''' <param name="_dis">Display member</param>
    ''' <param name="_c">Control cần set</param>
    ''' <remarks></remarks>
    Public Sub SetDataSource(ByVal _dt As DataTable, ByVal _val As String, ByVal _dis As String, ByVal _c As Object)
        _c.DisplayMember = _dis
        _c.ValueMember = _val
        _c.DataSource = _dt
    End Sub
    ''' <summary>
    ''' Set 1 label định dạng màu và chữ tiêu để
    ''' </summary>
    ''' <param name="pc">danh sách label cần định dạng</param>
    ''' <remarks></remarks>
    Public Sub SetLBLTitle(ByVal ParamArray pc() As Control)
        For Each item In pc
            If item.GetType.GetProperty("BackColor") IsNot Nothing Then item.BackColor = StartColor
            If item.GetType.GetProperty("ForeColor") IsNot Nothing Then item.ForeColor = Color.White
        Next
    End Sub
#End Region
#Region "SYS"
#Region "Property Now"
    ''' <summary>
    ''' Lấy ngày giờ hiện tại của hệ thống
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property Now As Date
        Get
            Try
                UpdateCurrentCulture()
                Dim _dNow As Date = CDate(dbXML.GetTable("select getdate()").Rows(0)(0).ToString)
                If NowLBL IsNot Nothing Then NowLBL.Text = _dNow.ToString("dd/MM/yyyy HH:mm:ss")
                Return _dNow
            Catch ex As Exception
                Return System.DateTime.Now
            End Try
        End Get
    End Property
#End Region
    Public Function GetConnect(DL As DuLieu) As String
        Dim cnsp As New ConnectSRP
        Return cnsp.GetConnectString(DL)
    End Function
#End Region
#Region "Input Box"
    ''' <summary>
    ''' Make Input box 
    ''' </summary>
    ''' <param name="Prompt">Câu hỏi</param>
    ''' <param name="Title">Tiêu đề</param>
    ''' <param name="DefaultResponse">Giá trị mặc định</param>
    ''' <param name="Xpos">Hoành độ</param>
    ''' <param name="Ypos">Tung độ</param>
    ''' <param name="style">Kiểu</param>
    ''' <param name="cbo">Là combobox</param>
    ''' <param name="cboSource">Source combobox</param>
    ''' <param name="DisplayMember">Field hiển thị</param>
    ''' <param name="ValueMember">Field Giá trị</param>
    ''' <param name="TextOK">Text nút ok</param>
    ''' <param name="TextCancel">Text nút hủy</param>
    ''' <param name="Min">Giá trị min</param>
    ''' <param name="Max">Giá trị max</param>
    ''' <param name="PassWord">Kiểu password</param>
    ''' <param name="PassChar">Password char</param>
    ''' <param name="DisableCancel">Không cho cancel</param>
    ''' <param name="AllowSearch">Cho searc</param>
    ''' <param name="_width">Rộng</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function InputBox(ByVal Prompt As String, Optional ByVal Title As String = "LRCO", Optional ByVal DefaultResponse As Object = "", Optional ByVal Xpos As Integer = -1, Optional ByVal Ypos As Integer = -1, Optional ByVal style As FMstyle = FMstyle.obj, Optional ByVal cbo As Boolean = False, Optional ByVal cboSource As DataTable = Nothing, Optional ByVal DisplayMember As String = "", Optional ByVal ValueMember As String = "", Optional ByVal TextOK As String = "Đồng ý", Optional ByVal TextCancel As String = "Bỏ qua", Optional ByVal Min As Object = Nothing, Optional ByVal Max As Object = Nothing, Optional ByVal PassWord As Boolean = False, Optional ByVal PassChar As String = "", Optional ByVal DisableCancel As Boolean = False, Optional ByVal AllowSearch As Boolean = True, Optional ByVal _width As Integer = 340)
        Dim ipb As New frmInputBox(Prompt, Title, DefaultResponse, style, cbo, cboSource, DisplayMember, ValueMember, TextOK, TextCancel, Min, Max, PassWord, PassChar, DisableCancel, AllowSearch, _width)
        If ipb.ShowDialog() = DialogResult.OK Then
            If Not cbo Then Return ipb.txtGiatri.Text
            Return ipb.cmbGiatri.SelectedValue
        End If
        Return ""
    End Function
#End Region
#Region "Các hàm bắt phím nhập số, ngày tháng, giờ, hủy ký tự đặc biệt"
    ''' <summary>
    ''' Huỷ ký tự đặc biệt
    ''' </summary>
    ''' <param name="Key">Phím đang bấn</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function HuyKTDB(ByVal Key As Integer) As Boolean
        Return (Key >= Keys.Shift + Keys.D0 AndAlso Key <= Keys.Shift + Keys.D9) OrElse Key = Keys.OemQuotes OrElse Key = Keys.Shift + Keys.OemQuotes OrElse Key = Keys.OemSemicolon OrElse Key = Keys.Shift + Keys.OemSemicolon OrElse Key = Keys.OemOpenBrackets OrElse Key = Keys.Shift + Keys.OemOpenBrackets OrElse Key = Keys.OemCloseBrackets OrElse Key = Keys.Shift + Keys.OemCloseBrackets OrElse Key = Keys.OemQuestion OrElse Key = Keys.Shift + Keys.OemQuestion OrElse Key = Keys.OemPeriod OrElse Key = Keys.Shift + Keys.OemPeriod OrElse Key = Keys.Oemcomma OrElse Key = Keys.Shift + Keys.Oemcomma OrElse Key = Keys.Oemtilde OrElse Key = Keys.Shift + Keys.Oemtilde OrElse Key = Keys.OemMinus OrElse Key = Keys.Shift + Keys.OemMinus OrElse Key = Keys.Oemplus OrElse Key = Keys.Shift + Keys.Oemplus OrElse Key = Keys.OemPipe OrElse Key = Keys.Shift + Keys.OemPipe OrElse Key = Keys.Divide OrElse Key = Keys.Shift + Keys.Divide OrElse Key = Keys.Multiply OrElse Key = Keys.Shift + Keys.Multiply OrElse Key = Keys.Subtract OrElse Key = Keys.Shift + Keys.Subtract OrElse Key = Keys.Add OrElse Key = Keys.Shift + Keys.Add
    End Function
    ''' <summary>
    ''' Bắt ký tự đặc biệt
    ''' </summary>
    ''' <param name="K">Chuyền vào là KeyData</param>
    ''' <param name="C">Chuyền vào là Me.ActiveControl</param>
    ''' <param name="L">Chuyền vào danh sách các đối tượng muốn bắt ký tự đặc biệt (Nếu là cột có thể chuyền là tên hoặc chỉ số cột)</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function HuyKTDB(ByVal K As Keys, ByVal C As Object, ByVal ParamArray L() As Object) As Boolean
        If L.Length = 0 Then L = New Object() {C}
        If (K >= Keys.F13 AndAlso K <= Keys.F24) Then
            MsgBox("Phím này có thật không đấy các má?!☺", MsgBoxStyle.Critical, "LRCO")
            Return False
        End If
        HuyKTDB = False
        If (TypeOf C Is DataGridViewTextBoxEditingControl) OrElse (TypeOf C Is DataGridView) Then
            Dim dgv As DataGridView = Nothing
            If TypeOf C Is DataGridView Then dgv = C
            If TypeOf C Is DataGridViewTextBoxEditingControl Then dgv = C.Parent.Parent
            If IsNothing(dgv.CurrentCell) Then Return True
            For i As Byte = 0 To UBound(L)
                If IsNothing(L(i)) Then Continue For
                Select Case L(i).GetType.Name
                    Case "String"
                        If L(i).ToUpper = dgv.Columns(dgv.CurrentCell.ColumnIndex).Name.ToUpper Then HuyKTDB = True : Exit For
                    Case "Int32", "Integer"
                        If L(i) = dgv.CurrentCell.ColumnIndex Then HuyKTDB = True : Exit For
                    Case "DataGridViewTextBoxColumn"
                        If L(i) Is dgv.Columns(dgv.CurrentCell.ColumnIndex) Then HuyKTDB = True : Exit For
                    Case "DataGridViewTextBoxEditingControl"
                        If L(i) Is C Then HuyKTDB = True : Exit For
                End Select
            Next i
        Else
            For i As Byte = 0 To UBound(L)
                If IsNothing(L(i)) Then Continue For
                Select Case L(i).GetType.Name
                    Case "String"
                        If L(i).ToUpper = C.Name.ToUpper Then HuyKTDB = True : Exit For
                    Case Else
                        If L(i) Is C Then HuyKTDB = True : Exit For
                End Select
            Next i
        End If
        If Not HuyKTDB Then Return False
        Return (K >= Keys.Shift + Keys.D0 AndAlso K <= Keys.Shift + Keys.D9) OrElse K = Keys.OemQuotes OrElse K = Keys.Shift + Keys.OemQuotes OrElse K = Keys.OemSemicolon OrElse K = Keys.Shift + Keys.OemSemicolon OrElse K = Keys.OemOpenBrackets OrElse K = Keys.Shift + Keys.OemOpenBrackets OrElse K = Keys.OemCloseBrackets OrElse K = Keys.Shift + Keys.OemCloseBrackets OrElse K = Keys.OemQuestion OrElse K = Keys.Shift + Keys.OemQuestion OrElse K = Keys.OemPeriod OrElse K = Keys.Shift + Keys.OemPeriod OrElse K = Keys.Oemcomma OrElse K = Keys.Shift + Keys.Oemcomma OrElse K = Keys.Oemtilde OrElse K = Keys.Shift + Keys.Oemtilde OrElse K = Keys.OemMinus OrElse K = Keys.Shift + Keys.OemMinus OrElse K = Keys.Oemplus OrElse K = Keys.Shift + Keys.Oemplus OrElse K = Keys.OemPipe OrElse K = Keys.Shift + Keys.OemPipe OrElse K = Keys.Divide OrElse K = Keys.Shift + Keys.Divide OrElse K = Keys.Multiply OrElse K = Keys.Shift + Keys.Multiply OrElse K = Keys.Subtract OrElse K = Keys.Shift + Keys.Subtract OrElse K = Keys.Add OrElse K = Keys.Shift + Keys.Add
    End Function
    ''' <summary>
    ''' Bắt phím nhập ngày tháng
    ''' </summary>
    ''' <param name="K">Chuyền vào là KeyData</param>
    ''' <param name="C">Chuyền vào là Me.ActiveControl</param>
    ''' <param name="L">Chuyền vào danh sách các đối tượng muốn bắt lỗi nhập ngày tháng (Nếu là cột có thể chuyền là tên hoặc chỉ số cột)</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function NhapNgay(ByVal K As Keys, ByVal C As Object, ByVal ParamArray L() As Object) As Boolean
        If L.Length = 0 Then L = New Object() {C}
        If L.Length = 0 OrElse K >= Keys.Shift OrElse (K >= Keys.F1 AndAlso K <= Keys.F12) Then Return False
        If (K >= Keys.F13 AndAlso K <= Keys.F24) Then
            MsgBox("Phím này có thật không đấy các má?!☺", MsgBoxStyle.Critical, "LRCO")
            Return False
        End If
        NhapNgay = False
        If (TypeOf C Is DataGridViewTextBoxEditingControl) OrElse (TypeOf C Is DataGridView) Then
            Dim dgv As DataGridView = Nothing
            If TypeOf C Is DataGridView Then dgv = C
            If TypeOf C Is DataGridViewTextBoxEditingControl Then dgv = C.Parent.Parent
            If IsNothing(dgv.CurrentCell) Then Return True
            For i As Byte = 0 To UBound(L)
                If IsNothing(L(i)) Then Continue For
                Select Case L(i).GetType.Name
                    Case "String"
                        If L(i).ToUpper = dgv.Columns(dgv.CurrentCell.ColumnIndex).Name.ToUpper Then NhapNgay = True : Exit For
                    Case "Int32", "Integer"
                        If L(i) = dgv.CurrentCell.ColumnIndex Then NhapNgay = True : Exit For
                    Case "DataGridViewTextBoxColumn"
                        If L(i) Is dgv.Columns(dgv.CurrentCell.ColumnIndex) Then NhapNgay = True : Exit For
                    Case "DataGridViewTextBoxEditingControl"
                        If L(i) Is C Then NhapNgay = True : Exit For
                End Select
            Next i
            If NhapNgay AndAlso TypeOf C Is DataGridView Then
                Select Case K
                    Case Keys.Enter, Keys.Escape, Keys.Tab, Keys.Left, Keys.Right, Keys.Up, Keys.Down, Keys.Home, Keys.End, (Keys.Shift + Keys.Home), (Keys.Shift + Keys.End), (Keys.Shift + Keys.Left), (Keys.Shift + Keys.Right) : Return False
                    Case Keys.Back, Keys.Delete, Keys.D0, Keys.D1, Keys.D2, Keys.D3, Keys.D4, Keys.D5, Keys.D6, Keys.D7, Keys.D8, Keys.D9 : Return False
                    Case Keys.Subtract, Keys.OemMinus, Keys.NumPad0, Keys.NumPad1, Keys.NumPad2, Keys.NumPad3, Keys.NumPad4, Keys.NumPad5, Keys.NumPad6, Keys.NumPad7, Keys.NumPad8, Keys.NumPad9 : Return False
                    Case Else : Return True
                End Select
            End If
        Else
            For i As Byte = 0 To UBound(L)
                If IsNothing(L(i)) Then Continue For
                Select Case L(i).GetType.Name
                    Case "String"
                        If L(i).ToUpper = C.Name.ToUpper Then NhapNgay = True : Exit For
                    Case Else
                        If L(i) Is C Then NhapNgay = True : Exit For
                End Select
            Next i
        End If
        If Not NhapNgay Then Return False
        If (Not TypeOf C Is ComboBox AndAlso C.ReadOnly) OrElse (TypeOf C Is ComboBox AndAlso C.DropDownStyle = ComboBoxStyle.DropDownList) Then Return False
        Select Case K
            Case Keys.Enter, Keys.Escape, Keys.Tab, Keys.Left, Keys.Right, Keys.Up, Keys.Down, Keys.Home, Keys.End, (Keys.Shift + Keys.Home), (Keys.Shift + Keys.End), (Keys.Shift + Keys.Left), (Keys.Shift + Keys.Right) : Return False
            Case Keys.Back, Keys.Delete, Keys.Divide, Keys.OemQuestion, Keys.D0, Keys.D1, Keys.D2, Keys.D3, Keys.D4, Keys.D5, Keys.D6, Keys.D7, Keys.D8, Keys.D9, Keys.NumPad0, Keys.NumPad1, Keys.NumPad2, Keys.NumPad3, Keys.NumPad4, Keys.NumPad5, Keys.NumPad6, Keys.NumPad7, Keys.NumPad8, Keys.NumPad9
                If (K = Keys.Back OrElse K = Keys.Delete) Then Return False
                C.MaxLength = 10
                If (K = Keys.Divide OrElse K = Keys.OemQuestion) AndAlso C.Text.Length = 0 Then Return True
                If (K = Keys.Divide OrElse K = Keys.OemQuestion) AndAlso System.Text.RegularExpressions.Regex.Matches(C.Text, "/").Count = 2 AndAlso Not C.SelectedText.Contains("/") Then Return True
                If (K = Keys.Divide OrElse K = Keys.OemQuestion) Then K = AscW("/")
                If K > Keys.D9 Then K = (K - 48)
                Dim mStr As String = ChrW(K), mStart1 As Integer = 1
                mStr = (C.Text.Substring(0, C.SelectionStart) & mStr & C.Text.Substring(C.SelectionStart + C.SelectionLength))
                Dim mStart As Integer = (mStr.Length - C.SelectionStart)
                If C.Text.Length < 10 Then
                    Dim st As Integer = C.SelectionStart, st1 As Integer = 0
                    Dim dmy() As String = mStr.Split("/")
                    Select Case UBound(dmy)
                        Case 0
                            If dmy(0).Length > 2 AndAlso dmy(0).Length < 5 Then
                                mStr = dmy(0).Substring(0, 2) & "/" & dmy(0).Substring(2)
                                st1 = -(st = 2)
                            ElseIf dmy(0).Length > 4 Then
                                mStr = dmy(0).Substring(0, 2) & "/" & dmy(0).Substring(2, 2) & "/" & dmy(0).Substring(4)
                            End If
                        Case 1
                            If dmy(0).Length > 2 Then
                                dmy(1) = dmy(0).Substring(2) & dmy(1)
                                dmy(0) = dmy(0).Substring(0, 2)
                            End If
                            If dmy(1).Length < 3 Then
                                mStr = dmy(0) & "/" & dmy(1)
                            ElseIf dmy(1).Length > 2 AndAlso dmy(1).Length < 7 Then
                                mStr = dmy(0) & "/" & dmy(1).Substring(0, 2) & "/" & dmy(1).Substring(2)
                                st1 = -(st = 5)
                            ElseIf dmy(1).Length > 6 Then
                                mStr = dmy(0) & "/" & dmy(1).Substring(0, 2) & "/" & dmy(1).Substring(2, 4)
                            End If
                        Case 2
                            If dmy(0).Length > 2 Then
                                dmy(1) = dmy(0).Substring(2) & dmy(1)
                                dmy(0) = dmy(0).Substring(0, 2)
                            ElseIf dmy(0).Length < 2 Then
                                dmy(0) = "0" & dmy(0)
                            End If
                            If dmy(1).Length > 2 Then
                                dmy(2) = dmy(1).Substring(2) & dmy(2)
                                dmy(1) = dmy(1).Substring(0, 2)
                            ElseIf dmy(1).Length < 2 Then
                                dmy(1) = "0" & dmy(1)
                            End If
                            If dmy(2).Length > 4 Then dmy(2) = dmy(2).Substring(0, 4)
                            mStr = dmy(0) & "/" & dmy(1) & "/" & dmy(2)
                    End Select
                Else
                    mStr = ChrW(K) : mStart1 = 2
                    If (K = Keys.Back OrElse K = Keys.Delete) Then
                        If C.SelectionLength = 10 Then C.SelectedText = "" : Return True
                        mStr = "0" : mStart = -(C.SelectionStart + (K = Keys.Back)) : mStart1 = -10
                        If K = Keys.Back Then
                            If C.SelectionStart = 0 Then Return True
                            If C.SelectionStart = 3 OrElse C.SelectionStart = 6 Then C.SelectionStart -= 2 Else C.SelectionStart -= 1
                            mStart = 10 : mStart1 = C.SelectionStart
                        Else
                            If C.SelectionStart = 10 Then Return True
                            If C.SelectionStart = 2 OrElse C.SelectionStart = 5 Then C.SelectionStart += 1
                            mStart = 10 : mStart1 = C.SelectionStart + 1
                            If C.SelectionStart = 10 Then C.SelectionStart -= 1
                        End If
                    Else
                        If C.Text.Length = C.SelectionLength Then mStart = C.Text.Length : mStart1 = 1
                        If C.SelectionStart = 2 OrElse C.SelectionStart = 5 Then C.SelectionStart += 1 : mStart1 = 3
                        If C.SelectionStart = 10 Then C.SelectionStart -= 1
                    End If
                    mStr = (C.Text.Substring(0, C.SelectionStart) & mStr & C.Text.Substring(C.SelectionStart + 1))
                End If
                C.SelectionStart = 0 : C.SelectionLength = C.MaxLength
                C.SelectedText = mStr : C.SelectionStart = IIf((C.Text.Length - mStart + mStart1) < 0, 0, C.Text.Length - mStart + mStart1)
        End Select
        If Not IsNothing(C.Modified) Then C.Modified = True
        Return NhapNgay
    End Function
    ''' <summary>
    ''' Bắt phím nhập giờ
    ''' </summary>
    ''' <param name="K">Chuyền vào là KeyData</param>
    ''' <param name="C">Chuyền vào là Me.ActiveControl</param>
    ''' <param name="L">Chuyền vào danh sách các đối tượng muốn bắt lỗi nhập ngày tháng (Nếu là cột có thể chuyền là tên hoặc chỉ số cột)</param>
    ''' <param name="Full">True: Nhập dạng 12:00:00; False: Nhập dạng 12:00</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function NhapGio(ByVal K As Keys, ByVal C As Object, ByVal Full As Boolean, ByVal ParamArray L() As Object) As Boolean
        If L.Length = 0 Then L = New Object() {C}
        If (L.Length = 0 OrElse K >= Keys.Shift OrElse (K >= Keys.F1 AndAlso K <= Keys.F12)) AndAlso (K <> (Keys.Shift + Keys.OemSemicolon)) Then Return False
        If (K >= Keys.F13 AndAlso K <= Keys.F24) Then
            MsgBox("Phím này có thật không đấy các má?!☺", MsgBoxStyle.Critical, "LRCO")
            Return False
        End If
        NhapGio = False
        If (TypeOf C Is DataGridViewTextBoxEditingControl) OrElse (TypeOf C Is DataGridView) Then
            Dim dgv As DataGridView = Nothing
            If TypeOf C Is DataGridView Then dgv = C
            If TypeOf C Is DataGridViewTextBoxEditingControl Then dgv = C.Parent.Parent
            If IsNothing(dgv.CurrentCell) Then Return True
            For i As Byte = 0 To UBound(L)
                If IsNothing(L(i)) Then Continue For
                Select Case L(i).GetType.Name
                    Case "String"
                        If L(i).ToUpper = dgv.Columns(dgv.CurrentCell.ColumnIndex).Name.ToUpper Then NhapGio = True : Exit For
                    Case "Int32", "Integer"
                        If L(i) = dgv.CurrentCell.ColumnIndex Then NhapGio = True : Exit For
                    Case "DataGridViewTextBoxColumn"
                        If L(i) Is dgv.Columns(dgv.CurrentCell.ColumnIndex) Then NhapGio = True : Exit For
                    Case "DataGridViewTextBoxEditingControl"
                        If L(i) Is C Then NhapGio = True : Exit For
                End Select
            Next i
            If NhapGio AndAlso TypeOf C Is DataGridView Then
                Select Case K
                    Case Keys.Enter, Keys.Escape, Keys.Tab, Keys.Left, Keys.Right, Keys.Up, Keys.Down, Keys.Home, Keys.End, (Keys.Shift + Keys.Home), (Keys.Shift + Keys.End), (Keys.Shift + Keys.Left), (Keys.Shift + Keys.Right) : Return False
                    Case Keys.Back, Keys.Delete, Keys.D0, Keys.D1, Keys.D2, Keys.D3, Keys.D4, Keys.D5, Keys.D6, Keys.D7, Keys.D8, Keys.D9 : Return False
                    Case Keys.Subtract, Keys.OemMinus, Keys.NumPad0, Keys.NumPad1, Keys.NumPad2, Keys.NumPad3, Keys.NumPad4, Keys.NumPad5, Keys.NumPad6, Keys.NumPad7, Keys.NumPad8, Keys.NumPad9 : Return False
                    Case Else : Return True
                End Select
            End If
        Else
            For i As Byte = 0 To UBound(L)
                If IsNothing(L(i)) Then Continue For
                Select Case L(i).GetType.Name
                    Case "String"
                        If L(i).ToUpper = C.Name.ToUpper Then NhapGio = True : Exit For
                    Case Else
                        If L(i) Is C Then NhapGio = True : Exit For
                End Select
            Next i
        End If
        If Not NhapGio Then Return False
        If (Not TypeOf C Is ComboBox AndAlso C.ReadOnly) OrElse (TypeOf C Is ComboBox AndAlso C.DropDownStyle = ComboBoxStyle.DropDownList) Then Return False
        Select Case K
            Case Keys.Enter, Keys.Escape, Keys.Tab, Keys.Left, Keys.Right, Keys.Home, Keys.End, (Keys.Shift + Keys.Home), (Keys.Shift + Keys.End), (Keys.Shift + Keys.Left), (Keys.Shift + Keys.Right) : Return False
            Case Keys.Up, Keys.Down
                If C.SelectionStart <= IIf(Full, 8, 5) Then Return False
                Dim mStart As Integer = C.SelectionStart
                If C.Text.Contains("AM") Then
                    C.Text = C.Text.Replace("AM", "PM")
                ElseIf C.Text.Contains("PM") Then
                    C.Text = C.Text.Replace("PM", "AM")
                ElseIf C.Text.Contains("SA") Then
                    C.Text = C.Text.Replace("SA", "CH")
                ElseIf C.Text.Contains("CH") Then
                    C.Text = C.Text.Replace("CH", "SA")
                End If
                C.SelectionStart = mStart : Return True
            Case Keys.Back, Keys.Delete, (Keys.Shift + Keys.OemSemicolon), Keys.D0, Keys.D1, Keys.D2, Keys.D3, Keys.D4, Keys.D5, Keys.D6, Keys.D7, Keys.D8, Keys.D9, Keys.NumPad0, Keys.NumPad1, Keys.NumPad2, Keys.NumPad3, Keys.NumPad4, Keys.NumPad5, Keys.NumPad6, Keys.NumPad7, Keys.NumPad8, Keys.NumPad9, Keys.A, Keys.P, Keys.S, Keys.C, Keys.Space
                If (K = Keys.Back OrElse K = Keys.Delete) Then
                    If C.SelectionStart < IIf(Full, 8, 5) Then Return False
                    If K = Keys.Back AndAlso C.SelectionStart = IIf(Full, 8, 5) Then Return False
                    If K = Keys.Back AndAlso C.SelectionStart > IIf(Full, 8, 5) Then C.Text = C.Text.Replace(" CH", "").Replace(" SA", "").Replace(" AM", "").Replace(" PM", "") : C.SelectionStart = C.Text.Length : Return True
                    If K = Keys.Delete AndAlso C.SelectionStart >= IIf(Full, 8, 5) Then C.Text = C.Text.Replace(" CH", "").Replace(" SA", "").Replace(" AM", "").Replace(" PM", "") : C.SelectionStart = C.Text.Length : Return True
                    Return False
                End If
                C.MaxLength = IIf(Full, 11, 8)
                If (K = (Keys.Shift + Keys.OemSemicolon)) AndAlso C.Text.Length = 0 Then Return True
                If (K = (Keys.Shift + Keys.OemSemicolon)) AndAlso ((Full AndAlso System.Text.RegularExpressions.Regex.Matches(C.Text, ":").Count = 2) OrElse (Not Full AndAlso System.Text.RegularExpressions.Regex.Matches(C.Text, ":").Count = 1)) AndAlso Not C.SelectedText.Contains(":") Then Return True
                Select Case K
                    Case (Keys.Shift + Keys.OemSemicolon) : K = AscW(":")
                    Case Keys.A, Keys.P, Keys.S, Keys.C
                        If C.SelectionStart <= IIf(Full, 8, 5) Then Return True
                        Select Case K
                            Case Keys.A : C.Text = C.Text.Substring(0, IIf(Full, 9, 6)) & "AM" : C.SelectionStart = IIf(Full, 9, 6) : C.SelectionLength = 3 : Return True
                            Case Keys.P : C.Text = C.Text.Substring(0, IIf(Full, 9, 6)) & "PM" : C.SelectionStart = IIf(Full, 9, 6) : C.SelectionLength = 3 : Return True
                            Case Keys.S : C.Text = C.Text.Substring(0, IIf(Full, 9, 6)) & "SA" : C.SelectionStart = IIf(Full, 9, 6) : C.SelectionLength = 3 : Return True
                            Case Keys.C : C.Text = C.Text.Substring(0, IIf(Full, 9, 6)) & "CH" : C.SelectionStart = IIf(Full, 9, 6) : C.SelectionLength = 3 : Return True
                        End Select
                        Stop
                    Case Keys.Space
                        If C.SelectionStart <> IIf(Full, 8, 5) Then Return True
                        If Not C.Text.ToString.Contains(" ") Then
                            C.Text &= Now.ToString.Substring(Now.ToString.Length - 3) : C.SelectionStart = IIf(Full, 9, 6) : C.SelectionLength = 3
                        Else
                            C.SelectionStart += 1
                        End If
                        Return True
                    Case Else
                        If C.SelectionStart > IIf(Full, 8, 5) Then Return True
                        If K > Keys.D9 Then K = (K - 48)
                End Select
                Dim mStr As String = ChrW(K), mStart1 As Integer = 1
                mStr = (C.Text.Substring(0, C.SelectionStart) & mStr & C.Text.Substring(C.SelectionStart + C.SelectionLength))
                Dim mStart As Integer = (mStr.Length - C.SelectionStart)
                If C.Text.Length < IIf(Full, 8, 5) Then
                    Dim st As Integer = C.SelectionStart, st1 As Integer = 0
                    Dim hms() As String = mStr.Split(":")
                    Select Case UBound(hms)
                        Case 0
                            If hms(0).Length > 2 AndAlso hms(0).Length < 5 Then
                                mStr = hms(0).Substring(0, 2) & ":" & hms(0).Substring(2)
                                st1 = -(st = 2)
                            ElseIf hms(0).Length > 4 Then
                                mStr = hms(0).Substring(0, 2) & ":" & hms(0).Substring(2, 2) & ":" & hms(0).Substring(4)
                            End If
                        Case 1
                            If hms(0).Length > 2 Then
                                hms(1) = hms(0).Substring(2) & hms(1)
                                hms(0) = hms(0).Substring(0, 2)
                            End If
                            If hms(1).Length < 3 Then
                                mStr = hms(0) & ":" & hms(1)
                            ElseIf hms(1).Length > 2 AndAlso hms(1).Length < 7 Then
                                mStr = hms(0) & ":" & hms(1).Substring(0, 2) & ":" & hms(1).Substring(2)
                                st1 = -(st = 5)
                            ElseIf hms(1).Length > 6 Then
                                mStr = hms(0) & ":" & hms(1).Substring(0, 2) & ":" & hms(1).Substring(2, 4)
                            End If
                        Case 2
                            If hms(0).Length > 2 Then
                                hms(1) = hms(0).Substring(2) & hms(1)
                                hms(0) = hms(0).Substring(0, 2)
                            ElseIf hms(0).Length < 2 Then
                                hms(0) = "0" & hms(0)
                            End If
                            If hms(1).Length > 2 Then
                                hms(2) = hms(1).Substring(2) & hms(2)
                                hms(1) = hms(1).Substring(0, 2)
                            ElseIf hms(1).Length < 2 Then
                                hms(1) = "0" & hms(1)
                            End If
                            If hms(2).Length > 2 Then hms(2) = hms(2).Substring(0, 2)
                            If hms(2).Length = 0 Then hms(2) = "00"
                            mStr = hms(0) & ":" & hms(1) & ":" & hms(2)
                    End Select
                Else
                    mStr = ChrW(K) : mStart1 = 2
                    If (K = Keys.Back OrElse K = Keys.Delete) Then
                        If C.SelectionLength = IIf(Full, 11, 8) Then C.SelectedText = "" : Return True
                        mStr = "0" : mStart = -(C.SelectionStart + (K = Keys.Back)) : mStart1 = -IIf(Full, 11, 8)
                        If K = Keys.Back Then
                            If C.SelectionStart = 0 Then Return True
                            If C.SelectionStart = 3 OrElse C.SelectionStart = 6 Then C.SelectionStart -= 2 Else C.SelectionStart -= 1
                            mStart = 11 : mStart1 = C.SelectionStart
                        Else
                            If C.SelectionStart = IIf(Full, 8, 5) Then Return True
                            If C.SelectionStart = 2 OrElse C.SelectionStart = 5 Then C.SelectionStart += 1
                            mStart = 11 : mStart1 = C.SelectionStart + 1
                            If C.SelectionStart = IIf(Full, 8, 5) Then C.SelectionStart -= 1
                        End If
                    Else
                        If C.Text.Length = C.SelectionLength Then mStart = C.Text.Length : mStart1 = 1
                        If C.SelectionStart = 2 OrElse (Full AndAlso C.SelectionStart = 5) Then C.SelectionStart += 1 : mStart1 = 3
                        If C.SelectionStart = IIf(Full, 8, 5) Then C.SelectionStart -= 1
                    End If
                    mStr = (C.Text.Substring(0, C.SelectionStart) & mStr & C.Text.Substring(C.SelectionStart + 1))
                End If
                C.SelectionStart = 0 : C.SelectionLength = C.MaxLength
                C.SelectedText = mStr : C.SelectionStart = IIf((C.Text.Length - mStart + mStart1) < 0, 0, C.Text.Length - mStart + mStart1)
        End Select
        If Not IsNothing(C.Modified) Then C.Modified = True
        Return NhapGio
    End Function
    ''' <summary>
    ''' Bắt phím nhập giờ
    ''' </summary>
    ''' <param name="K">Chuyền vào là KeyData</param>
    ''' <param name="C">Chuyền vào là Me.ActiveControl</param>
    ''' <param name="L">Chuyền vào danh sách các đối tượng muốn bắt lỗi nhập ngày tháng (Nếu là cột có thể chuyền là tên hoặc chỉ số cột)</param>
    ''' <param name="Full">True: Nhập dạng 01/01/1900 12:00:00; False: Nhập dạng 01/01/1900 12:00</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function NhapNgayGio(ByVal K As Keys, ByVal C As Object, ByVal Full As Boolean, ByVal ParamArray L() As Object) As Boolean
        If L.Length = 0 Then L = New Object() {C}
        If (L.Length = 0 OrElse K >= Keys.Shift OrElse (K >= Keys.F1 AndAlso K <= Keys.F12)) AndAlso (K <> (Keys.Shift + Keys.OemSemicolon)) Then Return False
        If (K >= Keys.F13 AndAlso K <= Keys.F24) Then
            MsgBox("Phím này có thật không đấy các má?!☺", MsgBoxStyle.Critical, "LRCO")
            Return False
        End If
        NhapNgayGio = False
        If (TypeOf C Is DataGridViewTextBoxEditingControl) OrElse (TypeOf C Is DataGridView) Then
            Dim dgv As DataGridView = Nothing
            If TypeOf C Is DataGridView Then dgv = C
            If TypeOf C Is DataGridViewTextBoxEditingControl Then dgv = C.Parent.Parent
            If IsNothing(dgv.CurrentCell) Then Return True
            For i As Byte = 0 To UBound(L)
                If IsNothing(L(i)) Then Continue For
                Select Case L(i).GetType.Name
                    Case "String"
                        If L(i).ToUpper = dgv.Columns(dgv.CurrentCell.ColumnIndex).Name.ToUpper Then NhapNgayGio = True : Exit For
                    Case "Int32", "Integer"
                        If L(i) = dgv.CurrentCell.ColumnIndex Then NhapNgayGio = True : Exit For
                    Case "DataGridViewTextBoxColumn"
                        If L(i) Is dgv.Columns(dgv.CurrentCell.ColumnIndex) Then NhapNgayGio = True : Exit For
                    Case "DataGridViewTextBoxEditingControl"
                        If L(i) Is C Then NhapNgayGio = True : Exit For
                End Select
            Next i
            If NhapNgayGio AndAlso TypeOf C Is DataGridView Then
                Select Case K
                    Case Keys.Enter, Keys.Escape, Keys.Tab, Keys.Left, Keys.Right, Keys.Up, Keys.Down, Keys.Home, Keys.End, (Keys.Shift + Keys.Home), (Keys.Shift + Keys.End), (Keys.Shift + Keys.Left), (Keys.Shift + Keys.Right) : Return False
                    Case Keys.Back, Keys.Delete, Keys.D0, Keys.D1, Keys.D2, Keys.D3, Keys.D4, Keys.D5, Keys.D6, Keys.D7, Keys.D8, Keys.D9 : Return False
                    Case Keys.Subtract, Keys.OemMinus, Keys.NumPad0, Keys.NumPad1, Keys.NumPad2, Keys.NumPad3, Keys.NumPad4, Keys.NumPad5, Keys.NumPad6, Keys.NumPad7, Keys.NumPad8, Keys.NumPad9 : Return False
                    Case Else : Return True
                End Select
            End If
        Else
            For i As Byte = 0 To UBound(L)
                If IsNothing(L(i)) Then Continue For
                Select Case L(i).GetType.Name
                    Case "String"
                        If L(i).ToUpper = C.Name.ToUpper Then NhapNgayGio = True : Exit For
                    Case Else
                        If L(i) Is C Then NhapNgayGio = True : Exit For
                End Select
            Next i
        End If
        If Not NhapNgayGio Then Return False
        If (Not TypeOf C Is ComboBox AndAlso C.ReadOnly) OrElse (TypeOf C Is ComboBox AndAlso C.DropDownStyle = ComboBoxStyle.DropDownList) Then Return False
        Select Case K
            Case Keys.Enter, Keys.Escape, Keys.Tab, Keys.Left, Keys.Right, Keys.Home, Keys.End, (Keys.Shift + Keys.Home), (Keys.Shift + Keys.End), (Keys.Shift + Keys.Left), (Keys.Shift + Keys.Right) : Return False
            Case Keys.Up, Keys.Down
                If C.SelectionStart <= IIf(Full, 19, 16) Then Return False
                Dim mStart As Integer = C.SelectionStart
                If C.Text.Contains("AM") Then
                    C.Text = C.Text.Replace("AM", "PM")
                ElseIf C.Text.Contains("PM") Then
                    C.Text = C.Text.Replace("PM", "AM")
                ElseIf C.Text.Contains("SA") Then
                    C.Text = C.Text.Replace("SA", "CH")
                ElseIf C.Text.Contains("CH") Then
                    C.Text = C.Text.Replace("CH", "SA")
                End If
                C.SelectionStart = mStart : Return True
            Case Keys.Back, Keys.Delete, Keys.Divide, Keys.OemQuestion, (Keys.Shift + Keys.OemSemicolon), Keys.D0, Keys.D1, Keys.D2, Keys.D3, Keys.D4, Keys.D5, Keys.D6, Keys.D7, Keys.D8, Keys.D9, Keys.NumPad0, Keys.NumPad1, Keys.NumPad2, Keys.NumPad3, Keys.NumPad4, Keys.NumPad5, Keys.NumPad6, Keys.NumPad7, Keys.NumPad8, Keys.NumPad9, Keys.A, Keys.P, Keys.S, Keys.C, Keys.Space
                If (K = Keys.Back OrElse K = Keys.Delete) Then
                    If C.SelectionStart < IIf(Full, 19, 16) Then Return False
                    If K = Keys.Back AndAlso C.SelectionStart = IIf(Full, 19, 16) Then Return False
                    If K = Keys.Back AndAlso C.SelectionStart > IIf(Full, 19, 16) Then C.Text = C.Text.Replace(" CH", "").Replace(" SA", "").Replace(" AM", "").Replace(" PM", "") : C.SelectionStart = C.Text.Length : Return True
                    If K = Keys.Delete AndAlso C.SelectionStart >= IIf(Full, 19, 16) Then C.Text = C.Text.Replace(" CH", "").Replace(" SA", "").Replace(" AM", "").Replace(" PM", "") : C.SelectionStart = C.Text.Length : Return True
                    Return False
                End If
                C.MaxLength = IIf(Full, 22, 19)
                If ((K = Keys.Divide) OrElse (K = Keys.OemQuestion)) AndAlso ((C.Text.Length = 0) OrElse (C.SelectionStart > 10)) Then Return True
                If ((K = Keys.Divide) OrElse (K = Keys.OemQuestion)) AndAlso (System.Text.RegularExpressions.Regex.Matches(C.Text, "/").Count = 2) AndAlso Not C.SelectedText.Contains("/") Then Return True
                If (K = (Keys.Shift + Keys.OemSemicolon)) AndAlso (C.SelectionStart < 11) Then Return True
                If (K = (Keys.Shift + Keys.OemSemicolon)) AndAlso ((Full AndAlso System.Text.RegularExpressions.Regex.Matches(C.Text, ":").Count = 2) OrElse (Not Full AndAlso System.Text.RegularExpressions.Regex.Matches(C.Text, ":").Count = 1)) AndAlso Not C.SelectedText.Contains(":") Then Return True
                Select Case K
                    Case (Keys.Shift + Keys.OemSemicolon) : K = AscW(":")
                    Case Keys.Divide, Keys.OemQuestion : K = AscW("/")
                    Case Keys.A, Keys.P, Keys.S, Keys.C
                        If C.SelectionStart <= IIf(Full, 19, 16) Then Return True
                        Select Case K
                            Case Keys.A : C.Text = C.Text.Substring(0, IIf(Full, 20, 17)) & "AM" : C.SelectionStart = IIf(Full, 20, 17) : C.SelectionLength = 3 : Return True
                            Case Keys.P : C.Text = C.Text.Substring(0, IIf(Full, 20, 17)) & "PM" : C.SelectionStart = IIf(Full, 20, 17) : C.SelectionLength = 3 : Return True
                            Case Keys.S : C.Text = C.Text.Substring(0, IIf(Full, 20, 17)) & "SA" : C.SelectionStart = IIf(Full, 20, 17) : C.SelectionLength = 3 : Return True
                            Case Keys.C : C.Text = C.Text.Substring(0, IIf(Full, 20, 17)) & "CH" : C.SelectionStart = IIf(Full, 20, 17) : C.SelectionLength = 3 : Return True
                        End Select
                        Stop
                    Case Keys.Space
                        If (C.SelectionStart <> 10) AndAlso (C.SelectionStart <> IIf(Full, 19, 16)) Then Return True
                        If (System.Text.RegularExpressions.Regex.Matches(C.Text, " ").Count = 1) AndAlso (C.SelectionStart = IIf(Full, 19, 16)) Then
                            C.Text &= Now.ToString.Substring(Now.ToString.Length - 3) : C.SelectionStart = IIf(Full, 20, 17) : C.SelectionLength = 3
                        ElseIf Not C.Text.ToString.Contains(" ") AndAlso (C.SelectionStart = 10) Then
                            C.Text &= " " : C.SelectionStart = 11
                        Else
                            C.SelectionStart += 1
                        End If
                        Return True
                    Case Else
                        If C.SelectionStart > IIf(Full, 19, 16) Then Return True
                        If K > Keys.D9 Then K = (K - 48)
                End Select
                Dim mStr As String = ChrW(K), mStart1 As Integer = 1
                mStr = (C.Text.Substring(0, C.SelectionStart) & mStr & C.Text.Substring(C.SelectionStart + C.SelectionLength))
                Dim mStart As Integer = (mStr.Length - C.SelectionStart)
                If C.Text.Length < IIf(Full, 19, 16) Then
                    Dim st As Integer = C.SelectionStart, st1 As Integer = 0
                    Dim dmyhms() As String = mStr.Split(" ")
                    For i1 As Byte = 0 To 1
                        If (i1 > UBound(dmyhms)) Then Exit For
                        If (i1 = 0) Then
                            Dim dmy() As String = dmyhms(i1).Split("/")
                            Select Case UBound(dmy)
                                Case 0
                                    If dmy(0).Length > 2 AndAlso dmy(0).Length < 5 Then
                                        mStr = dmy(0).Substring(0, 2) & "/" & dmy(0).Substring(2)
                                        st1 = -(st = 2)
                                    ElseIf dmy(0).Length > 4 Then
                                        mStr = dmy(0).Substring(0, 2) & "/" & dmy(0).Substring(2, 2) & "/" & dmy(0).Substring(4)
                                    End If
                                Case 1
                                    If dmy(0).Length > 2 Then
                                        dmy(1) = dmy(0).Substring(2) & dmy(1)
                                        dmy(0) = dmy(0).Substring(0, 2)
                                    End If
                                    If dmy(1).Length < 3 Then
                                        mStr = dmy(0) & "/" & dmy(1)
                                    ElseIf dmy(1).Length > 2 AndAlso dmy(1).Length < 7 Then
                                        mStr = dmy(0) & "/" & dmy(1).Substring(0, 2) & "/" & dmy(1).Substring(2)
                                        st1 = -(st = 5)
                                    ElseIf dmy(1).Length > 6 Then
                                        mStr = dmy(0) & "/" & dmy(1).Substring(0, 2) & "/" & dmy(1).Substring(2, 4)
                                    End If
                                Case 2
                                    If dmy(0).Length > 2 Then
                                        dmy(1) = dmy(0).Substring(2) & dmy(1)
                                        dmy(0) = dmy(0).Substring(0, 2)
                                    ElseIf dmy(0).Length < 2 Then
                                        dmy(0) = "0" & dmy(0)
                                    End If
                                    If dmy(1).Length > 2 Then
                                        dmy(2) = dmy(1).Substring(2) & dmy(2)
                                        dmy(1) = dmy(1).Substring(0, 2)
                                    ElseIf dmy(1).Length < 2 Then
                                        dmy(1) = "0" & dmy(1)
                                    End If
                                    If dmy(2).Length > 4 Then
                                        If (dmy(2).Length >= 4) Then
                                            If (i1 >= UBound(dmyhms)) Then ReDim Preserve dmyhms(i1 + 1)
                                            dmyhms(i1 + 1) = dmy(2).Substring(3) & dmyhms(i1 + 1)
                                        End If
                                        dmy(2) = dmy(2).Substring(0, 4)
                                    End If
                                    mStr = dmy(0) & "/" & dmy(1) & "/" & dmy(2)
                            End Select
                            If (mStr.Length = 10) Then mStr &= " "
                        Else
                            Dim hms() As String = dmyhms(i1).Split(":")
                            Select Case UBound(hms)
                                Case 0
                                    If hms(0).Length > 2 AndAlso hms(0).Length < 5 Then
                                        mStr &= hms(0).Substring(0, 2) & ":" & hms(0).Substring(2)
                                        st1 = -(st = 2)
                                    ElseIf hms(0).Length > 4 Then
                                        mStr &= hms(0).Substring(0, 2) & ":" & hms(0).Substring(2, 2) & ":" & hms(0).Substring(4)
                                    Else
                                        mStr &= hms(0)
                                    End If
                                Case 1
                                    If hms(0).Length > 2 Then
                                        hms(1) = hms(0).Substring(2) & hms(1)
                                        hms(0) = hms(0).Substring(0, 2)
                                    End If
                                    If hms(1).Length < 3 Then
                                        mStr &= hms(0) & ":" & hms(1)
                                    ElseIf hms(1).Length > 2 AndAlso hms(1).Length < 7 Then
                                        mStr &= hms(0) & ":" & hms(1).Substring(0, 2) & ":" & hms(1).Substring(2)
                                        st1 = -(st = 5)
                                    ElseIf hms(1).Length > 6 Then
                                        mStr &= hms(0) & ":" & hms(1).Substring(0, 2) & ":" & hms(1).Substring(2, 4)
                                    End If
                                Case 2
                                    If hms(0).Length > 2 Then
                                        hms(1) = hms(0).Substring(2) & hms(1)
                                        hms(0) = hms(0).Substring(0, 2)
                                    ElseIf hms(0).Length < 2 Then
                                        hms(0) = "0" & hms(0)
                                    End If
                                    If hms(1).Length > 2 Then
                                        hms(2) = hms(1).Substring(2) & hms(2)
                                        hms(1) = hms(1).Substring(0, 2)
                                    ElseIf hms(1).Length < 2 Then
                                        hms(1) = "0" & hms(1)
                                    End If
                                    If hms(2).Length > 2 Then hms(2) = hms(2).Substring(0, 2)
                                    If hms(2).Length = 0 Then hms(2) = "00"
                                    mStr &= hms(0) & ":" & hms(1) & ":" & hms(2)
                            End Select
                        End If
                    Next i1
                Else
                    mStr = ChrW(K) : mStart1 = 2
                    If (K = Keys.Back OrElse K = Keys.Delete) Then
                        If C.SelectionLength = IIf(Full, 22, 19) Then C.SelectedText = "" : Return True
                        mStr = "0" : mStart = -(C.SelectionStart + (K = Keys.Back)) : mStart1 = -IIf(Full, 22, 19)
                        If K = Keys.Back Then
                            If C.SelectionStart = 0 Then Return True
                            If C.SelectionStart = 3 OrElse C.SelectionStart = 6 Then C.SelectionStart -= 2 Else C.SelectionStart -= 1
                            mStart = 11 : mStart1 = C.SelectionStart
                        Else
                            If C.SelectionStart = IIf(Full, 19, 16) Then Return True
                            If C.SelectionStart = 2 OrElse C.SelectionStart = 5 Then C.SelectionStart += 1
                            mStart = 11 : mStart1 = C.SelectionStart + 1
                            If C.SelectionStart = IIf(Full, 19, 16) Then C.SelectionStart -= 1
                        End If
                    Else
                        If C.Text.Length = C.SelectionLength Then mStart = C.Text.Length : mStart1 = 1
                        If (C.SelectionStart = 2) OrElse (C.SelectionStart = 5) OrElse (C.SelectionStart = 10) OrElse (C.SelectionStart = 13) OrElse (Full AndAlso C.SelectionStart = 16) Then C.SelectionStart += 1 : mStart1 = 3
                        If C.SelectionStart = IIf(Full, 19, 16) Then C.SelectionStart -= 1
                    End If
                    mStr = (C.Text.Substring(0, C.SelectionStart) & mStr & C.Text.Substring(C.SelectionStart + 1))
                End If
                C.SelectionStart = 0 : C.SelectionLength = C.MaxLength
                C.SelectedText = mStr : C.SelectionStart = IIf((C.Text.Length - mStart + mStart1) < 0, 0, C.Text.Length - mStart + mStart1)
        End Select
        If Not IsNothing(C.Modified) Then C.Modified = True
        Return NhapNgayGio
    End Function
    ''' <summary>
    ''' Bắt phím nhập số
    ''' </summary>
    ''' <param name="SoAm">True: Cho phép nhập số âm, False: Không nhập số âm</param>
    ''' <param name="SoNguyen">True: Chỉ nhập số nguyên, False: Có thể nhập số thập phân</param>
    ''' <param name="DinhDang">True: Cho phép nhập số có định dạng phân cách, False: Không cho phép dịnh dạng phân cách</param>
    ''' <param name="K">Chuyền vào là KeyData</param>
    ''' <param name="C">Chuyền vào là Me.ActiveControl</param>
    ''' <param name="L">Chuyền vào danh sách các đối tượng muốn bắt lỗi nhập ngày tháng (Nếu là cột có thể chuyền là tên hoặc chỉ số cột)</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function NhapSo(ByVal DinhDang As Boolean, ByVal SoAm As Boolean, ByVal SoNguyen As Boolean, ByVal K As Keys, ByVal C As Object, ByVal ParamArray L() As Object) As Boolean
        If IsNothing(C) Then Return False
        If (TypeOf C Is TextBox) AndAlso (CType(C, TextBox).Text.Length = CType(C, TextBox).MaxLength) Then Return False
        If L.Length = 0 Then L = New Object() {C}
        If L.Length = 0 OrElse K >= Keys.Shift OrElse (K >= Keys.F1 AndAlso K <= Keys.F12) Then Return False
        If (K >= Keys.F13 AndAlso K <= Keys.F24) Then
            MsgBox("Phím này có thật không đấy các má?!☺", MsgBoxStyle.Critical, "LRCO")
            Return False
        End If
        NhapSo = False
        If (TypeOf C Is DataGridViewTextBoxEditingControl) OrElse (TypeOf C Is DataGridView) Then
            Dim dgv As DataGridView = Nothing
            If TypeOf C Is DataGridView Then dgv = C
            If TypeOf C Is DataGridViewTextBoxEditingControl Then dgv = C.Parent.Parent
            If IsNothing(dgv.CurrentCell) Then Return True
            For i As Byte = 0 To UBound(L)
                If IsNothing(L(i)) Then Continue For
                Select Case L(i).GetType.Name
                    Case "String"
                        If L(i).ToUpper = dgv.Columns(dgv.CurrentCell.ColumnIndex).Name.ToUpper Then NhapSo = True : Exit For
                    Case "Int32", "Integer"
                        If L(i) = dgv.CurrentCell.ColumnIndex Then NhapSo = True : Exit For
                    Case "DataGridViewTextBoxColumn"
                        If L(i) Is dgv.Columns(dgv.CurrentCell.ColumnIndex) Then NhapSo = True : Exit For
                    Case "DataGridViewTextBoxEditingControl"
                        If L(i) Is C Then NhapSo = True : Exit For
                End Select
            Next i
            If NhapSo AndAlso TypeOf C Is DataGridView Then
                Select Case K
                    Case Keys.Enter, Keys.Escape, Keys.Tab, Keys.Left, Keys.Right, Keys.Up, Keys.Down, Keys.Home, Keys.End, (Keys.Shift + Keys.Home), (Keys.Shift + Keys.End), (Keys.Shift + Keys.Left), (Keys.Shift + Keys.Right) : Return False
                    Case Keys.Back, Keys.Delete, Keys.D0, Keys.D1, Keys.D2, Keys.D3, Keys.D4, Keys.D5, Keys.D6, Keys.D7, Keys.D8, Keys.D9 : Return False
                    Case Keys.Subtract, Keys.OemMinus, Keys.NumPad0, Keys.NumPad1, Keys.NumPad2, Keys.NumPad3, Keys.NumPad4, Keys.NumPad5, Keys.NumPad6, Keys.NumPad7, Keys.NumPad8, Keys.NumPad9 : Return False
                    Case Else : Return True
                End Select
            End If
        Else
            For i As Byte = 0 To UBound(L)
                If IsNothing(L(i)) Then Continue For
                Select Case L(i).GetType.Name
                    Case "String"
                        If L(i).ToUpper = C.Name.ToUpper Then NhapSo = True : Exit For
                    Case Else
                        If L(i) Is C Then NhapSo = True : Exit For
                End Select
            Next i
        End If
        If Not NhapSo Then Return False
        If (Not TypeOf C Is ComboBox AndAlso C.ReadOnly) OrElse (TypeOf C Is ComboBox AndAlso C.DropDownStyle = ComboBoxStyle.DropDownList) Then Return False
        Select Case K
            Case Keys.Enter, Keys.Escape, Keys.Tab, Keys.Left, Keys.Right, Keys.Up, Keys.Down, Keys.Home, Keys.End, (Keys.Shift + Keys.Home), (Keys.Shift + Keys.End), (Keys.Shift + Keys.Left), (Keys.Shift + Keys.Right) : Return False
            Case Keys.Back, Keys.Delete, Keys.Decimal, Keys.Oemcomma, Keys.D0, Keys.D1, Keys.D2, Keys.D3, Keys.D4, Keys.D5, Keys.D6, Keys.D7, Keys.D8, Keys.D9, Keys.NumPad0, Keys.NumPad1, Keys.NumPad2, Keys.NumPad3, Keys.NumPad4, Keys.NumPad5, Keys.NumPad6, Keys.NumPad7, Keys.NumPad8, Keys.NumPad9
                If (K = Keys.Decimal OrElse K = Keys.Oemcomma) AndAlso Not ((Not C.Text.Contains(",") AndAlso C.SelectionStart > 0) OrElse C.SelectedText.Contains(",")) Then Return True
                If (K = Keys.Decimal OrElse K = Keys.Oemcomma) AndAlso C.Text.Contains("-") AndAlso (C.SelectionStart < 2) Then Return True
                If (K = Keys.Decimal OrElse K = Keys.Oemcomma) Then
                    If SoNguyen Then Return True
                    K = AscW(",")
                End If
                If K > Keys.D9 Then K = (K - 48)
                Dim mStr1 As String = ChrW(K), mStart1 As Integer = 0
                If (K = Keys.Back OrElse K = Keys.Delete) Then mStr1 = ""
                Dim mStrs() As String = (C.Text.Substring(0, C.SelectionStart) & mStr1 & C.Text.Substring(C.SelectionStart + C.SelectionLength)).Split(",")
                If K = Keys.Back OrElse K = Keys.Delete Then
                    If C.Text.Length > 0 AndAlso C.Text.Chars(0) = "-" AndAlso C.SelectionStart = -(K = Keys.Back) Then Return False
                    If C.SelectionLength = 0 Then
                        If K = Keys.Back AndAlso C.SelectionStart = 0 Then Return True
                        If K = Keys.Delete AndAlso C.SelectionStart = C.Text.Length Then Return True
                        If C.SelectionStart <= mStrs(0).Length Then
                            If C.Text.Substring(C.SelectionStart + (K = Keys.Back), 1) = "," Then
                                mStart1 = -(mStrs(1).Length \ 3) + ((mStrs(1).Length Mod 3) <> 0)
                                mStrs(0) = mStrs(0) & mStrs(1)
                                ReDim Preserve mStrs(0)
                            Else
                                mStart1 = (K = Keys.Back)
                                If K = Keys.Back Then mStart1 = mStart1 + (C.Text.Substring(C.SelectionStart + mStart1, 1) = ".")
                                If K = Keys.Delete Then mStart1 = mStart1 - (C.Text.Substring(C.SelectionStart, 1) = ".")
                                mStrs(0) = mStrs(0).Substring(0, C.SelectionStart + mStart1) & mStrs(0).Substring(C.SelectionStart - ((mStart1 - (K = Keys.Delete)) * (K = Keys.Delete)))
                                mStart1 = mStart1 + (mStart1 < -1) * 2
                                mStart1 = mStart1 + (mStart1 = -1)
                                mStart1 = mStart1 + (K = Keys.Delete)
                            End If
                        Else
                            If C.Text.Substring(C.SelectionStart + (K = Keys.Back), 1) = "," Then
                                mStart1 = -1 - (mStrs(1).Length \ 3) + ((mStrs(1).Length Mod 3) <> 0)
                                mStrs(0) = mStrs(0) & mStrs(1)
                                ReDim Preserve mStrs(0)
                            ElseIf mStrs(1).Length = 1 Then
                                ReDim Preserve mStrs(0)
                            Else
                                mStart1 = (K = Keys.Delete)
                                mStrs(1) = mStrs(1).Substring(0, C.SelectionStart + mStart1 - mStrs(0).Length + (K = Keys.Back) * 2) & mStrs(1).Substring(C.SelectionStart + mStart1 - mStrs(0).Length - (K = Keys.Delete) + (K = Keys.Back))
                                mStart1 = (K = Keys.Back) * 2
                            End If
                        End If
                    End If
                End If
                Dim mStart As Integer = (mStrs(0).Length - C.SelectionStart) : mStr1 = ""
                If mStrs.Length > 1 Then mStr1 = "," & mStrs(1).Replace(".", "") : mStart = (mStrs(0).Length + mStr1.Length) - C.SelectionStart
                If SoAm Then SoAm = C.Text.Contains("-")
                Dim mStr As String = mStrs(0).Replace(".", "").Replace("-", "") : mStrs(0) = ""
                If DinhDang Then
                    Do While mStr.Length > 3
                        mStrs(0) = "." & mStr.Substring(mStr.Length - 3, 3) & mStrs(0)
                        mStr = mStr.Substring(0, mStr.Length - 3)
                    Loop
                End If
                If mStr.Length > 0 AndAlso mStrs(0).Length > 0 Then mStrs(0) = mStr & mStrs(0) Else mStrs(0) = mStr
                C.SelectionStart = 0 : C.SelectionLength = C.MaxLength
                C.SelectedText = IIf(SoAm, "-", "") & mStrs(0) & mStr1 : C.SelectionStart = (IIf(((C.Text.Length - mStart) + 1 + mStart1) < 0, 0, ((C.Text.Length - mStart) + 1 + mStart1)))
            Case Keys.Subtract, Keys.OemMinus
                If C.ReadOnly OrElse Not SoAm Then Return True
                If (Not C.Text.Contains("-") AndAlso C.SelectionStart = 0) OrElse C.SelectedText.Contains("-") Then Return False
        End Select
        If Not IsNothing(C.Modified) Then C.Modified = True
        Return NhapSo
    End Function
    Function chuyenthanhkhongdau(ByVal text As String) As String
        For i As Integer = 33 To 47
            text = text.Replace(Chr(i).ToString(), "")
        Next

        For i As Integer = 58 To 64
            text = text.Replace(Chr(i).ToString(), "")
        Next

        For i As Integer = 91 To 96
            text = text.Replace(Chr(i).ToString(), "")
        Next
        For i As Integer = 123 To 126
            text = text.Replace(Chr(i).ToString(), "")
        Next
        text = text.Trim().Replace("-", "")
        text = text.Replace(" ", "-")
        Dim regex As New System.Text.RegularExpressions.Regex("\p{IsCombiningDiacriticalMarks}+")
        Dim strFormD As String = text.Normalize(System.Text.NormalizationForm.FormD)
        Dim kq As String = regex.Replace(strFormD, [String].Empty).Replace("đ"c, "d"c).Replace("Đ"c, "D"c)
        Return kq
    End Function
    ''' <summary>
    ''' Lấy bảng dữ liệu cho background
    ''' </summary>
    ''' <param name="qqq">Câu lệnh lấy nguồn</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function BG_LayBangDL(ByVal qqq As String) As DataTable
        Dim db As New MyData.Database(GetConnect(DuLieu.XML))
        Return db.GetTable(qqq)
    End Function
#End Region
#Region "Mã hóa và giải mã dữ liệu"
    Private key() As Byte = {}
    Private ReadOnly IV As Byte() = {&H12, &H34, &H56, &H78, &H90, &HAB, &HCD, &HEF}
    Public Function GiaiMa(ByVal mStr As String, ByVal mKey As String) As String
        Try
            If (mStr.Length = 0) Then mStr = MaHoa("", mKey)
            Dim inputByteArray(mStr.Length) As Byte
            key = System.Text.Encoding.UTF8.GetBytes(String.Format("{0}12345678", mKey).Substring(0, 8))
            Dim des = New Security.Cryptography.DESCryptoServiceProvider
            inputByteArray = Convert.FromBase64String(mStr)
            Dim ms = New IO.MemoryStream
            Dim cs = New Security.Cryptography.CryptoStream(ms, des.CreateDecryptor(key, IV), Security.Cryptography.CryptoStreamMode.Write)
            cs.Write(inputByteArray, 0, inputByteArray.Length)
            cs.FlushFinalBlock()
            Dim encoding = System.Text.Encoding.UTF8
            Return encoding.GetString(ms.ToArray())
        Catch e As Exception
            Return e.Message
        End Try
    End Function
    Public Function MaHoa(ByVal mStr As String, ByVal mKey As String) As String
        Try
            key = System.Text.Encoding.UTF8.GetBytes(String.Format("{0}12345678", mKey).Substring(0, 8))
            Dim des = New Security.Cryptography.DESCryptoServiceProvider
            Dim inputByteArray = System.Text.Encoding.UTF8.GetBytes(mStr)
            Dim ms = New IO.MemoryStream
            Dim cs = New Security.Cryptography.CryptoStream(ms, des.CreateEncryptor(key, IV), Security.Cryptography.CryptoStreamMode.Write)
            cs.Write(inputByteArray, 0, inputByteArray.Length)
            cs.FlushFinalBlock()
            Return Convert.ToBase64String(ms.ToArray())
        Catch e As Exception
            Return e.Message
        End Try
    End Function
#End Region
#Region "DTG Surport"
    ''' <summary>
    ''' Đồng bộ lưới
    ''' </summary>
    ''' <param name="Luoi">Truyền vào lưới</param>
    ''' <remarks></remarks>
    Public Sub DongBoLuoi(ByVal Luoi As DataGridView)
        Luoi.AutoGenerateColumns = False
        Luoi.EnableHeadersVisualStyles = False
        Luoi.RowTemplate.DefaultCellStyle.ForeColor = Color.Black
        Luoi.ColumnHeadersDefaultCellStyle.Padding = New System.Windows.Forms.Padding(3)
        Luoi.ColumnHeadersHeight = 25
        Luoi.ColumnHeadersDefaultCellStyle.BackColor = BackGColor
        Luoi.DefaultCellStyle.SelectionBackColor = SelectBackColor
        Luoi.DefaultCellStyle.SelectionForeColor = SelectForeColor
        Luoi.AllowUserToResizeRows = False
        Luoi.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None
        Luoi.MultiSelect = False
        Luoi.BackgroundColor = BackGColor
        Luoi.EditMode = DataGridViewEditMode.EditOnEnter
        For index = 0 To Luoi.ColumnCount - 1
            If String.IsNullOrEmpty(Luoi.Columns(index).DataPropertyName) Then Luoi.Columns(index).DataPropertyName = Luoi.Columns(index).Name
        Next
        With Luoi
            AddHandler .GotFocus, AddressOf sender_GotFocus
            AddHandler .Paint, AddressOf sender_Paint
            AddHandler .RowEnter, AddressOf sender_RowEnter
            AddHandler .DataSourceChanged, AddressOf _DataSourceChanged
        End With
        Call sender_GotFocus(Luoi, Nothing)
    End Sub
    ''' <summary>
    ''' Đồng bộ lưới
    ''' </summary>
    ''' <param name="pc">Truyền vào danh sách lưới</param>
    ''' <remarks></remarks>
    Public Sub DongBoLuoi(ByVal ParamArray pc() As DataGridView)
        For i = 0 To pc.Length - 1
            DongBoLuoi(pc(i))
        Next
    End Sub

#Region "Hanler"
    Private Sub sender_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        If sender.Controls(String.Format("lbl{0}", sender.Name)) Is Nothing Then
            For Each Ctrl As Object In sender.Controls
                If TypeOf Ctrl Is Label Then
                    Ctrl.Name = String.Format("lbl{0}", sender.Name)
                    Exit Sub
                End If
            Next Ctrl
            Dim lblGrid = New Label
            lblGrid.Parent = sender
            lblGrid.Height = 1
            lblGrid.Text = "              "
            lblGrid.Name = String.Format("lbl{0}", sender.Name)
            lblGrid.BackColor = Color.Red
        End If
    End Sub
    Private Sub sender_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)
        If sender.Controls(String.Format("lbl{0}", sender.Name)) Is Nothing Then Exit Sub
        sender.Controls(String.Format("lbl{0}", sender.Name)).Tag = e.RowIndex
    End Sub
    Private Sub sender_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs)
        On Error Resume Next
        If sender.Controls(String.Format("lbl{0}", sender.Name)) Is Nothing Then Exit Sub
        If sender.Controls(String.Format("lbl{0}", sender.Name)).Tag > sender.RowCount - 1 Then sender.Controls(String.Format("lbl{0}", sender.Name)).Tag = sender.RowCount - 1
        If sender.Controls(String.Format("lbl{0}", sender.Name)).Tag < 0 AndAlso sender.RowCount = 0 Then sender.Controls(String.Format("lbl{0}", sender.Name)).Hide() : Exit Sub
        Dim ColumnsViewMin As Integer = sender.Columns.GetFirstColumn(DataGridViewElementStates.Displayed).Index
        sender.Controls(String.Format("lbl{0}", sender.Name)).Left = sender.GetCellDisplayRectangle(ColumnsViewMin, sender.Controls(String.Format("lbl{0}", sender.Name)).Tag, True).Left
        sender.Controls(String.Format("lbl{0}", sender.Name)).Top = sender.GetCellDisplayRectangle(ColumnsViewMin, sender.Controls(String.Format("lbl{0}", sender.Name)).Tag, True).Bottom - 1
        If sender.Columns.GetColumnsWidth(DataGridViewElementStates.Visible) > sender.DisplayRectangle.Width Then
            If sender.Height < CType(sender, DataGridView).RowTemplate.Height * 2 Then
                sender.Controls(String.Format("lbl{0}", sender.Name)).Width = sender.DisplayRectangle.Width / 3
            Else
                sender.Controls(String.Format("lbl{0}", sender.Name)).Width = sender.DisplayRectangle.Width
            End If
        Else
            If sender.Height < CType(sender, DataGridView).RowTemplate.Height * 2 Then
                sender.Controls(String.Format("lbl{0}", sender.Name)).Width = sender.Columns.GetColumnsWidth(DataGridViewElementStates.Visible) / 3
            Else
                sender.Controls(String.Format("lbl{0}", sender.Name)).Width = sender.Columns.GetColumnsWidth(DataGridViewElementStates.Visible)
            End If
        End If
        sender.Controls(String.Format("lbl{0}", sender.Name)).Visible = (sender.Controls(String.Format("lbl{0}", sender.Name)).Top > If(CType(sender, DataGridView).ColumnHeadersVisible, sender.ColumnHeadersHeight, 0))
        sender.Controls(String.Format("lbl{0}", sender.Name)).BringToFront()
    End Sub
    Private Sub _DataSourceChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        If sender.DataSource Is Nothing Then Return
        Dim fff As Object = sender.FindForm()
        If fff Is Nothing Then Return
        If fff.GetType().BaseType.Name.ToLower <> "frmPRTienIch".ToLower Then Return
        fff = CType(fff, frmPRTienIch)
        Dim _dt As DataTable
        If Not TypeOf sender.DataSource Is DataTable AndAlso Not TypeOf sender.DataSource Is DataView Then Return
        If TypeOf sender.DataSource Is DataTable Then _dt = sender.DataSource Else _dt = CType(sender.DataSource, DataView).Table
        For Each item As DataGridViewColumn In CType(sender, DataGridView).Columns
            If item.DataPropertyName IsNot Nothing AndAlso Not String.IsNullOrEmpty(item.DataPropertyName) AndAlso _dt.Columns.Contains(item.DataPropertyName) Then
                Dim dtType_ As String = _dt.Columns(item.DataPropertyName).DataType.Name.ToLower
                If dtType_.Contains("int") OrElse dtType_.Contains("long") OrElse dtType_.Contains("byte") OrElse dtType_.Contains("short") Then
                    fff.ExtentProperties.Add(1, ExtenPropertiesComment.NhapSoNguyen(item))
                ElseIf dtType_.Contains("date") OrElse dtType_.Contains("datetime") Then
                    fff.ExtentProperties.Add(1, ExtenPropertiesComment.NhapNgayThang(item))
                ElseIf dtType_.Contains("dec") OrElse dtType_.Contains("single") OrElse dtType_.Contains("double") Then
                    fff.ExtentProperties.Add(1, ExtenPropertiesComment.NhapSoLe(item))
                End If
                If _dt.ExtendedProperties("Object_Table") IsNot Nothing Then
                    Dim tabname As String = _dt.ExtendedProperties("Object_Table").ToString
                    Dim tobj As Type = Type.GetType("CDHA4._0." & tabname)
                    Dim _obj As Object = Activator.CreateInstance(tobj)
                    If _obj.GetType.GetField(item.DataPropertyName) IsNot Nothing Then
                        Dim desc_ As String = dbXML.GetDescription(tobj, item.DataPropertyName).ToLower
                        If desc_.Contains("not null") Then
                            fff.ExtentProperties.Add(1, ExtenPropertiesComment.NotNull(item))
                        End If
                    End If
                End If
            End If
        Next
    End Sub
#End Region
#Region "Hỗ trợ extent control"
    ''' <summary>
    ''' Set control dạng nhập ngày tháng (dd/MM/yyyy)
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub SetNhapNgayThang(ByVal ParamArray p() As Object)
        For Each item In p
            If TypeOf item Is DataGridViewColumn Then
                Dim fff As frmPRTienIch = TryCast(CType(item, DataGridViewColumn).DataGridView.FindForm(), frmPRTienIch)
                If fff IsNot Nothing Then
                    CType(CType(item, DataGridViewColumn).DataGridView.FindForm, frmPRTienIch).ExtentProperties.Add(1, ExtenPropertiesComment.NhapNgayThang(item))
                End If
            Else
                Dim fff As frmPRTienIch = TryCast(item.FindForm, frmPRTienIch)
                If fff IsNot Nothing Then
                    CType(item.FindForm, frmPRTienIch).ExtentProperties.Add(1, ExtenPropertiesComment.NhapNgayThang(item))
                End If
            End If

        Next
    End Sub
    ''' <summary>
    ''' Set control dạng nhập ngày giờ (dd/MM/yyyy HH:MM)
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub SetNhapNgayGio(ByVal ParamArray p() As Control)
        For Each item In p
            Dim fff As frmPRTienIch = TryCast(item.FindForm, frmPRTienIch)
            If fff IsNot Nothing Then
                CType(item.FindForm, frmPRTienIch).ExtentProperties.Add(1, ExtenPropertiesComment.NhapNgayGio(item))
            End If
        Next
    End Sub
    ''' <summary>
    ''' Set control dạng nhập giờ (HH:MM:SS)
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub SetNhapGioFull(ByVal ParamArray p() As Object)
        For Each item In p
            If TypeOf item Is DataGridViewColumn Then
                Dim fff As frmPRTienIch = TryCast(CType(item, DataGridViewColumn).DataGridView.FindForm(), frmPRTienIch)
                If fff IsNot Nothing Then
                    CType(CType(item, DataGridViewColumn).DataGridView.FindForm, frmPRTienIch).ExtentProperties.Add(1, ExtenPropertiesComment.NhapGioFull(item))
                End If
            Else
                Dim fff As frmPRTienIch = TryCast(item.FindForm, frmPRTienIch)
                If fff IsNot Nothing Then
                    CType(item.FindForm, frmPRTienIch).ExtentProperties.Add(1, ExtenPropertiesComment.NhapGioFull(item))
                End If
            End If
        Next
    End Sub
    ''' <summary>
    ''' Set control dạng nhập giờ (HH:MM)
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub SetNhapGioPhut(ByVal ParamArray p() As Object)
        For Each item In p
            If TypeOf item Is DataGridViewColumn Then
                Dim fff As frmPRTienIch = TryCast(CType(item, DataGridViewColumn).DataGridView.FindForm(), frmPRTienIch)
                If fff IsNot Nothing Then
                    CType(CType(item, DataGridViewColumn).DataGridView.FindForm, frmPRTienIch).ExtentProperties.Add(1, ExtenPropertiesComment.NhapGioPhut(item))
                End If
            Else
                Dim fff As frmPRTienIch = TryCast(item.FindForm, frmPRTienIch)
                If fff IsNot Nothing Then
                    CType(item.FindForm, frmPRTienIch).ExtentProperties.Add(1, ExtenPropertiesComment.NhapGioPhut(item))
                End If
            End If
        Next
    End Sub
    ''' <summary>
    ''' Set control dạng nhập họ tên (hoa đầu từ)
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub SetNhapHoTen(ByVal ParamArray p() As Control)
        For Each item In p
            Dim fff As frmPRTienIch = TryCast(item.FindForm, frmPRTienIch)
            If fff IsNot Nothing Then
                CType(item.FindForm, frmPRTienIch).ExtentProperties.Add(1, ExtenPropertiesComment.NhapHoTen(item))
            End If
        Next
    End Sub
    ''' <summary>
    ''' Set control dạng nhập số thập phân
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub SetNhapSoLe(ByVal ParamArray p() As Object)
        For Each item In p
            If TypeOf item Is DataGridViewColumn Then
                Dim fff As frmPRTienIch = TryCast(CType(item, DataGridViewColumn).DataGridView.FindForm(), frmPRTienIch)
                If fff IsNot Nothing Then
                    CType(CType(item, DataGridViewColumn).DataGridView.FindForm, frmPRTienIch).ExtentProperties.Add(1, ExtenPropertiesComment.NhapSoLe(item))
                End If
            Else
                Dim fff As frmPRTienIch = TryCast(item.FindForm, frmPRTienIch)
                If fff IsNot Nothing Then
                    CType(item.FindForm, frmPRTienIch).ExtentProperties.Add(1, ExtenPropertiesComment.NhapSoLe(item))
                End If
            End If
        Next
    End Sub
    ''' <summary>
    ''' Set control dạng nhập số nguyên
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub SetNhapSoNguyen(ByVal ParamArray p() As Object)
        For Each item In p
            If TypeOf item Is DataGridViewColumn Then
                Dim fff As frmPRTienIch = TryCast(CType(item, DataGridViewColumn).DataGridView.FindForm(), frmPRTienIch)
                If fff IsNot Nothing Then
                    CType(CType(item, DataGridViewColumn).DataGridView.FindForm, frmPRTienIch).ExtentProperties.Add(1, ExtenPropertiesComment.NhapSoNguyen(item))
                End If
            Else
                Dim fff As frmPRTienIch = TryCast(item.FindForm, frmPRTienIch)
                If fff IsNot Nothing Then
                    CType(item.FindForm, frmPRTienIch).ExtentProperties.Add(1, ExtenPropertiesComment.NhapSoNguyen(item))
                End If
            End If
        Next
    End Sub
    ''' <summary>
    ''' Set control không được trắng
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub SetNotNull(ByVal ParamArray p() As Object)
        For Each item In p
            If TypeOf item Is Control Then
                Dim fff As frmPRTienIch = TryCast(item.FindForm, frmPRTienIch)
                If fff IsNot Nothing Then
                    CType(item.FindForm, frmPRTienIch).ExtentProperties.Add(1, ExtenPropertiesComment.NotNull(item))
                End If
            ElseIf TypeOf item Is DataGridViewColumn Then
                Dim fff As frmPRTienIch = TryCast(CType(item, DataGridViewColumn).DataGridView.FindForm(), frmPRTienIch)
                If fff IsNot Nothing Then
                    CType(CType(item, DataGridViewColumn).DataGridView.FindForm, frmPRTienIch).ExtentProperties.Add(1, ExtenPropertiesComment.NotNull(item))
                End If
            End If
        Next
    End Sub
    ''' <summary>
    ''' Set max value control 
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub SetMaxVal(ByVal ParamArray p() As Object)
        For index = 0 To p.Length - 1
            Dim item = p(index)
            If TypeOf item Is Control Then
                Dim fff As frmPRTienIch = TryCast(item.FindForm, frmPRTienIch)
                If fff IsNot Nothing Then
                    CType(item.FindForm, frmPRTienIch).ExtentProperties.Add(p(index + 1), ExtenPropertiesComment.MaxValue(item))
                End If
            ElseIf TypeOf item Is DataGridViewColumn Then
                Dim fff As frmPRTienIch = TryCast(CType(item, DataGridViewColumn).DataGridView.FindForm(), frmPRTienIch)
                If fff IsNot Nothing Then
                    CType(CType(item, DataGridViewColumn).DataGridView.FindForm, frmPRTienIch).ExtentProperties.Add(p(index + 1), ExtenPropertiesComment.MaxValue(item))
                End If
            End If
        Next
    End Sub
    ''' <summary>
    ''' Set min value control 
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub SetMinVal(ByVal ParamArray p() As Object)

        For index = 0 To p.Length - 1
            Dim item = p(index)
            If TypeOf item Is Control Then
                Dim fff As frmPRTienIch = TryCast(item.FindForm, frmPRTienIch)
                If fff IsNot Nothing Then
                    CType(item.FindForm, frmPRTienIch).ExtentProperties.Add(p(index + 1), ExtenPropertiesComment.MinValue(item))
                End If
            ElseIf TypeOf item Is DataGridViewColumn Then
                Dim fff As frmPRTienIch = TryCast(CType(item, DataGridViewColumn).DataGridView.FindForm(), frmPRTienIch)
                If fff IsNot Nothing Then
                    CType(CType(item, DataGridViewColumn).DataGridView.FindForm, frmPRTienIch).ExtentProperties.Add(p(index + 1), ExtenPropertiesComment.MinValue(item))
                End If
            End If
        Next
    End Sub
    ''' <summary>
    ''' Set control nạp ngược lại vào danh mục
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub SetNapNguoc(ByVal ParamArray p() As Object)
        For index = 0 To p.Length - 2
            Dim item = p(index)
            Dim fff As frmPRTienIch = TryCast(item.FindForm, frmPRTienIch)
            If fff IsNot Nothing Then
                CType(item.FindForm, frmPRTienIch).ExtentProperties.Add(p(index + 1), ExtenPropertiesComment.NapNguocDM(item))
            End If
        Next
    End Sub
    ''' <summary>
    ''' Định nghĩa cột cần cài đặt qua bảng trung gian
    ''' </summary>
    ''' <param name="p"></param>
    ''' <remarks></remarks>
    Public Sub SetMultipeTab(ByVal ParamArray p() As Object)
        For index = 0 To p.Length - 2
            Dim item = p(index)
            Dim fff As frmPRTienIch = TryCast(CType(item, DataGridViewColumn).DataGridView.FindForm(), frmPRTienIch)
            If fff IsNot Nothing Then
                CType(item.DataGridView.FindForm, frmPRTienIch).ExtentProperties.Add(p(index + 1), item.Name & "-MultipeTab")
            End If
        Next
    End Sub

    ''' <summary>
    ''' Trả về vị trí tuyệt đối của control trên form so với form
    ''' </summary>
    ''' <param name="c">Control cần tìm vị trí</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function PointFromForm(ByVal c As Control) As Point
        Dim f = c.FindForm()
        Dim p As Point = c.Location
        If f IsNot Nothing Then
            Dim pr = c.Parent
            If pr IsNot Nothing Then
                While pr IsNot Nothing AndAlso pr IsNot f
                    p.X += pr.Location.X
                    p.Y += pr.Location.Y
                    pr = pr.Parent
                End While
            End If
        End If
        Return p
    End Function
    ''' <summary>
    ''' Ném control ra form
    ''' </summary>
    ''' <param name="c">Control cần ném</param>
    ''' <remarks></remarks>
    Public Sub AddToParent(ByVal c As Control)
        Dim f = c.FindForm()
        Dim p = c.Parent()
        If f IsNot Nothing AndAlso p IsNot Nothing AndAlso f IsNot p Then
            p.Controls.Remove(c)
            f.Controls.Add(c)
            c.Location = PointFromForm(c)
            c.BringToFront()
        End If
    End Sub
    ''' <summary>
    ''' Ném control vào trong 1 control khác
    ''' </summary>
    ''' <param name="c">Control cần ném</param>
    ''' <param name="prNew">Control cần ném vào</param>
    ''' <remarks></remarks>
    Public Sub AddToControl(ByVal c As Control, ByVal prNew As Control)
        c.Parent = prNew
        Dim pcha As Point = PointFromForm(prNew)
        c.Left -= pcha.X
        c.Top -= pcha.Y
        c.BringToFront()
    End Sub
#End Region
#End Region
End Module
