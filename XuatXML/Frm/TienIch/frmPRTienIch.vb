
Public Class frmPRTienIch
    Inherits frmDesignVTR
#Region "Private Val"
    Private WithEvents txtDTG As TextBox
    Private noEnter As Boolean = False
#End Region
#Region "Public Val"
    Public QrLayDL As String = ""
    Public QrUpdateDL As String = ""
    Public DataSetNguon As New DataSet
    Public aReady As Boolean = False
    Public ConfirmClose As Boolean = False
    Public NoClose As Boolean = False
#End Region
#Region "FormControlEvent"
#Region "Form"
    Private Sub frmPRTienIch_DesignChange(ByVal e As Boolean) Handles Me.DesignChange
        AddCol(Me)
    End Sub
    Private Sub _Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.ExtentProperties.Clear()
        Me.ExtentProperties.Add(1, ExtenPropertiesComment.NoMove(pnDeLuuAnhLen))
        Me.ExtentProperties.Add(1, ExtenPropertiesComment.NoMove(pnDeLuuAnhXuong))
        Me.ExtentProperties.Add(1, ExtenPropertiesComment.NoMove(dtgTI))
        Me.ExtentProperties.Add(1, ExtenPropertiesComment.NoMove(cbxDSColumn))
        ' If CNDuLieuThieu Then CNDLThieu()
    End Sub
    Private Sub _Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        AddCol(Me)
        If AllControlInForm.Length = 0 Then
            GetAllCTR(Me)
        End If
    End Sub
    Protected Overrides Function ProcessCmdKey(ByRef msg As System.Windows.Forms.Message, ByVal keyData As System.Windows.Forms.Keys) As Boolean
        If Not NotDesignMode AndAlso keyData = Keys.Control + Keys.Shift + Keys.D Then
            isDesign = Not isDesign
            Return True
        End If
        Dim _ActiveControl As Control = Me.ActiveControl
        While _ActiveControl IsNot Nothing AndAlso TypeOf _ActiveControl Is SplitContainer
            _ActiveControl = CType(_ActiveControl, SplitContainer).ActiveControl
        End While
        Dim dtg As DataGridView = Nothing
        If _ActiveControl IsNot Nothing AndAlso _ActiveControl Is txtDTG Then dtg = CType(_ActiveControl, Object).EditingControlDataGridView
        Select Case keyData
            Case Keys.Escape
                If dtgTI.Visible Then
                    dtgTI.Visible = False
                    Me.ExtentProperties.Remove(_ActiveControl.Name & "-SelectVal")
                    Return True
                ElseIf Not NoClose Then
                    If Not ConfirmClose OrElse (ConfirmClose AndAlso MsgBox("  Bạn chắc chắn đóng form?  ", MsgBoxStyle.YesNo Or MsgBoxStyle.Exclamation) = MsgBoxResult.Yes) Then
                        Me.Close()
                        Return True
                    End If
                End If
            Case Keys.Enter
                If dtgTI.Visible AndAlso dtgTI.CurrentRow IsNot Nothing Then
                    Dim _dt As DataTable = dtgTI.DataSource
                    Dim colKey As String = _dt.ExtendedProperties.Item("ColKey")
                    Dim colVis As String = _dt.ExtendedProperties.Item("ColVis")
                    Me.ExtentProperties.Item(ExtenPropertiesComment.ControlHienLuoi()).Val.Text = _dt.DefaultView(dtgTI.CurrentRow.Index).Row(colVis).ToString
                    If Me.ExtentProperties.Item(ExtenPropertiesComment.ControlHienLuoi()).Val Is txtDTG Then
                        If dtg.DataSource IsNot Nothing Then
                            If CType(dtg.DataSource, DataTable).Columns.Contains(colKey) Then CType(dtg.DataSource, DataTable).DefaultView(dtg.CurrentRow.Index).Row(colKey) = _dt.DefaultView(dtgTI.CurrentRow.Index).Row(colKey).ToString
                        End If
                        Me.ExtentProperties.Add(_dt.DefaultView(dtgTI.CurrentRow.Index).Row(colKey).ToString, Me.ExtentProperties.Item(ExtenPropertiesComment.ControlHienLuoi()).Val.Name & "-" & CType(txtDTG.Parent.Parent, DataGridView).CurrentRow.Index & "-SelectVal")
                    Else
                        Me.ExtentProperties.Add(_dt.DefaultView(dtgTI.CurrentRow.Index).Row(colKey).ToString, Me.ExtentProperties.Item(ExtenPropertiesComment.ControlHienLuoi()).Val.Name & "-SelectVal")
                    End If
                    CType(Me.ExtentProperties.Item(ExtenPropertiesComment.ControlHienLuoi()).Val, TextBox).SelectAll()
                    If TypeOf Me.ActiveControl Is SplitContainer Then CType(Me.ActiveControl, SplitContainer).ActiveControl = Me.ExtentProperties.Item(ExtenPropertiesComment.ControlHienLuoi()).Val Else Me.ActiveControl = Me.ExtentProperties.Item(ExtenPropertiesComment.ControlHienLuoi()).Val
                    dtgTI.Visible = False
                    'Return True
                End If
            Case Keys.F3 'Thêm
                Dim q = (From p In AllControlInForm Where TypeOf p Is Button AndAlso p.Name.ToLower Like "*them" OrElse p.Name.ToLower Like "*add")
                If q.Count > 0 Then CType(q(0), Button).PerformClick()
                Return True
            Case Keys.F4 'Sửa
                Dim q = (From p In AllControlInForm Where TypeOf p Is Button AndAlso p.Name.ToLower Like "*edit" OrElse p.Name.ToLower Like "*sua")
                If q.Count > 0 Then CType(q(0), Button).PerformClick()
                Return True
            Case Keys.F2 'Thêm
                Dim q = (From p In AllControlInForm Where TypeOf p Is Button AndAlso p.Name.ToLower Like "*save" OrElse p.Name.ToLower Like "*luu")
                If q.Count > 0 Then CType(q(0), Button).PerformClick()
                Return True
        End Select
        If _ActiveControl IsNot Nothing Then

            If Not isDesign AndAlso DiChuyenConTro(keyData, _ActiveControl, False, , , dtgTI) Then Return True
            If (Me.ExtentProperties.Item(ExtenPropertiesComment.NhapNgayThang(_ActiveControl)) IsNot Nothing OrElse (dtg IsNot Nothing AndAlso Me.ExtentProperties.Item(ExtenPropertiesComment.NhapNgayThang(dtg.Columns(dtg.CurrentCell.ColumnIndex))) IsNot Nothing)) AndAlso NhapNgay(keyData, _ActiveControl) Then
                Return True
            End If
            If (Me.ExtentProperties.Item(_ActiveControl.Name & "-NhapGioFull") IsNot Nothing OrElse (dtg IsNot Nothing AndAlso Me.ExtentProperties.Item(ExtenPropertiesComment.NhapGioFull(dtg.Columns(dtg.CurrentCell.ColumnIndex))) IsNot Nothing)) AndAlso NhapGio(keyData, _ActiveControl, True) Then
                Return True
            End If
            If (Me.ExtentProperties.Item(_ActiveControl.Name & "-NhapGioPhut") IsNot Nothing OrElse (dtg IsNot Nothing AndAlso Me.ExtentProperties.Item(ExtenPropertiesComment.NhapGioPhut(dtg.Columns(dtg.CurrentCell.ColumnIndex))) IsNot Nothing)) AndAlso NhapGio(keyData, _ActiveControl, False) Then
                Return True
            End If
            If (Me.ExtentProperties.Item(_ActiveControl.Name & "-NhapNgayGio") IsNot Nothing OrElse (dtg IsNot Nothing AndAlso Me.ExtentProperties.Item(ExtenPropertiesComment.NhapNgayGio(dtg.Columns(dtg.CurrentCell.ColumnIndex))) IsNot Nothing)) AndAlso NhapNgayGio(keyData, _ActiveControl, False) Then
                Return True
            End If
            If Me.ExtentProperties.Item(_ActiveControl.Name & "-NhapSoNguyen") IsNot Nothing Then
                If (Me.ExtentProperties.Item(_ActiveControl.Name & "-NhapSoNguyen")).Val = 1 AndAlso NhapSo(True, False, True, keyData, _ActiveControl) Then Return True
                If (Me.ExtentProperties.Item(_ActiveControl.Name & "-NhapSoNguyen")).Val <> 1 AndAlso NhapSo(False, False, True, keyData, _ActiveControl) Then Return True
            End If
            If (dtg IsNot Nothing AndAlso Me.ExtentProperties.Item(ExtenPropertiesComment.NhapSoNguyen(dtg.Columns(dtg.CurrentCell.ColumnIndex))) IsNot Nothing) Then
                If Me.ExtentProperties.Item(ExtenPropertiesComment.NhapSoNguyen(dtg.Columns(dtg.CurrentCell.ColumnIndex))).Val = 1 AndAlso NhapSo(True, False, True, keyData, _ActiveControl) Then Return True
                If Me.ExtentProperties.Item(ExtenPropertiesComment.NhapSoNguyen(dtg.Columns(dtg.CurrentCell.ColumnIndex))).Val <> 1 AndAlso NhapSo(False, False, True, keyData, _ActiveControl) Then Return True
            End If
            If Me.ExtentProperties.Item(_ActiveControl.Name & "-NhapSoLe") IsNot Nothing Then
                If (Me.ExtentProperties.Item(_ActiveControl.Name & "-NhapSoLe")).Val = 1 AndAlso NhapSo(True, False, False, keyData, _ActiveControl) Then Return True
                If (Me.ExtentProperties.Item(_ActiveControl.Name & "-NhapSoLe")).Val <> 1 AndAlso NhapSo(False, False, False, keyData, _ActiveControl) Then Return True
                Return True
            End If
            If dtg IsNot Nothing AndAlso Me.ExtentProperties.Item(ExtenPropertiesComment.NhapSoLe(dtg.Columns(dtg.CurrentCell.ColumnIndex))) IsNot Nothing Then
                If Me.ExtentProperties.Item(ExtenPropertiesComment.NhapSoLe(dtg.Columns(dtg.CurrentCell.ColumnIndex))).Val = 1 AndAlso NhapSo(True, False, False, keyData, _ActiveControl) Then Return True
                If Me.ExtentProperties.Item(ExtenPropertiesComment.NhapSoLe(dtg.Columns(dtg.CurrentCell.ColumnIndex))).Val <> 1 AndAlso NhapSo(False, False, False, keyData, _ActiveControl) Then Return True
                Return True
            End If
        End If
        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function
#End Region
#Region "DTG"

    Private Sub _CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtgTI.CellClick

        Dim _ActiveControl = Me.ExtentProperties.Item(ExtenPropertiesComment.ControlHienLuoi).Val
        While _ActiveControl IsNot Nothing AndAlso TypeOf _ActiveControl Is SplitContainer
            _ActiveControl = CType(_ActiveControl, SplitContainer).ActiveControl
        End While
        Dim dtg As DataGridView = Nothing

        If _ActiveControl Is txtDTG Then dtg = CType(_ActiveControl, Object).EditingControlDataGridView
        If dtgTI.Visible AndAlso Me.ExtentProperties.Item(ExtenPropertiesComment.ControlHienLuoi) IsNot Nothing Then
            Dim _dt As DataTable = dtgTI.DataSource
            Dim colKey As String = _dt.ExtendedProperties.Item("ColKey")
            Dim colVis As String = _dt.ExtendedProperties.Item("ColVis")
            If _ActiveControl Is txtDTG Then
                Me.ExtentProperties.Add(_dt.DefaultView(dtgTI.CurrentRow.Index).Row(colKey).ToString, _ActiveControl.Name & "-" & CType(dtg, DataGridView).CurrentRow.Index & "-SelectVal")
                If dtg.DataSource IsNot Nothing Then
                    If CType(dtg.DataSource, DataTable).Columns.Contains(colKey) Then CType(dtg.DataSource, DataTable).DefaultView(dtg.CurrentRow.Index).Row(colKey) = _dt.DefaultView(dtgTI.CurrentRow.Index).Row(colKey).ToString
                End If
            Else
                Me.ExtentProperties.Add(_dt.DefaultView(dtgTI.CurrentRow.Index).Row(colKey).ToString, _ActiveControl.Name & "-SelectVal")
            End If

            CType(_ActiveControl, Object).Text = _dt.DefaultView(dtgTI.CurrentRow.Index).Row(colVis).ToString
            If dtg IsNot Nothing Then dtg.CurrentCell.Value = CType(_ActiveControl, Object).Text
            CType(_ActiveControl, Object).SelectAll()
        End If
    End Sub
    Private Sub _CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtgTI.CellDoubleClick
        Dim _ActiveControl = Me.ExtentProperties.Item(ExtenPropertiesComment.ControlHienLuoi()).Val
        Dim dtg As DataGridView = Nothing
        If _ActiveControl Is txtDTG Then dtg = CType(_ActiveControl, Object).EditingControlDataGridView
        If dtgTI.Visible AndAlso Me.ExtentProperties.Item(ExtenPropertiesComment.ControlHienLuoi) IsNot Nothing Then
            Dim _dt As DataTable = dtgTI.DataSource
            Dim colKey As String = _dt.ExtendedProperties.Item("ColKey")
            Dim colVis As String = _dt.ExtendedProperties.Item("ColVis")
            If Me.ExtentProperties.Item(ExtenPropertiesComment.ControlHienLuoi()).Val Is txtDTG Then
                Me.ExtentProperties.Add(_dt.DefaultView(dtgTI.CurrentRow.Index).Row(colKey).ToString, Me.ExtentProperties.Item(ExtenPropertiesComment.ControlHienLuoi()).Val.Name & "-" & CType(txtDTG, Object).EditingControlDataGridView.CurrentRow.Index & "-SelectVal")
                If dtg.DataSource IsNot Nothing Then
                    If CType(dtg.DataSource, DataTable).Columns.Contains(colKey) Then CType(dtg.DataSource, DataTable).DefaultView(dtg.CurrentRow.Index).Row(colKey) = _dt.DefaultView(dtgTI.CurrentRow.Index).Row(colKey).ToString
                End If
            Else
                Me.ExtentProperties.Add(_dt.DefaultView(dtgTI.CurrentRow.Index).Row(colKey).ToString, _dt.ExtendedProperties("ControlName") & "-SelectVal")
            End If

            CType(_ActiveControl, Object).Text = _dt.DefaultView(dtgTI.CurrentRow.Index).Row(colVis).ToString
            If dtg IsNot Nothing Then dtg.CurrentCell.Value = CType(_ActiveControl, Object).Text
            CType(_ActiveControl, Object).SelectAll()
            Dim picBox As Object = Nothing
            If Not Me.ExtentProperties.Item(ExtenPropertiesComment.ControlHienLuoi()).Val Is txtDTG Then
                picBox = Me.ExtentProperties.Item(ExtenPropertiesComment.ControlHienLuoi()).Val.Parent.Controls("Pic" & Me.ExtentProperties.Item(ExtenPropertiesComment.ControlHienLuoi()).Val.Name)
            End If
            If picBox IsNot Nothing Then
                picBox.Image = pnDeLuuAnhXuong.BackgroundImage
            End If
            If Me.ExtentProperties.Item(ExtenPropertiesComment.ControlHienLuoi()).Val Is txtDTG Then Me.ActiveControl = CType(txtDTG, Object).EditingControlDataGridView Else Me.ActiveControl = Me.ExtentProperties.Item(ExtenPropertiesComment.ControlHienLuoi()).Val
            dtgTI.Visible = False
        End If
    End Sub
    Private Sub dtgTI_MouseWheel(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dtgTI.MouseWheel
        If dtgTI.Visible = True Then
            Dim i As Integer = dtgTI.FirstDisplayedScrollingRowIndex
            i += (-e.Delta / 120)
            If i >= dtgTI.Rows.Count Then
                i = dtgTI.Rows.Count
            End If
            dtgTI.FirstDisplayedScrollingRowIndex = i
        End If
    End Sub
#End Region
#End Region
#Region "MultipeControlEvent"
    Private Sub _DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs)
        UpdateCurrentCulture()
        Dim qqq() As String = e.Argument.ToString.Split(";")
        Dim _dt As DataTable = BG_LayBangDL(qqq(0))
        _dt.ExtendedProperties.Add("ControlName", qqq(1))
        _dt.ExtendedProperties.Add("ColKey", qqq(2))
        _dt.ExtendedProperties.Add("ColVis", qqq(3))
        _dt.ExtendedProperties.Add("ColDis", qqq(4))
        _dt.ExtendedProperties.Add("ColFid", qqq(5))
        _dt.ExtendedProperties.Add("RowCount", qqq(6))
        _dt.ExtendedProperties.Add("HienCoH", qqq(7))
        ExtentProperties.Add(New ExtentObject(qqq(1) & "-SourceTI", _dt))
    End Sub
    Private Sub _Enter(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If noEnter OrElse Not aReady Then Return
        Dim _dt As DataTable = ExtentProperties.Item(ExtenPropertiesComment.DataSourceTable(sender)).Val
        If ExtentProperties.Item(ExtenPropertiesComment.DataSourceTable(sender)) IsNot Nothing Then
            Dim ControlName As String = _dt.ExtendedProperties("ControlName")
            Dim HienCoH As Boolean = CBool(_dt.ExtendedProperties("HienCoH"))
            dtgTI.DataSource = _dt
            dtgTI.Height = CInt(_dt.ExtendedProperties("RowCount").ToString) * dtgTI.RowTemplate.Height + If(HienCoH, dtgTI.ColumnHeadersHeight, 3)
            dtgTI.ColumnHeadersVisible = HienCoH
        End If
        If sender.Text = "" Then
            dtgTI.Visible = False
        End If
        Dim widthDTG As Integer = 0
        Dim ColDis() As String = _dt.ExtendedProperties("ColDis").ToString.ToLower.Split(New String() {"/"}, StringSplitOptions.RemoveEmptyEntries)
        For i = 0 To dtgTI.ColumnCount - 1
            If Array.IndexOf(ColDis, dtgTI.Columns(i).DataPropertyName.ToLower) >= 0 Then
                dtgTI.Columns(i).Visible = True
                dtgTI.Columns(i).Width = CInt(ColDis(Array.IndexOf(ColDis, dtgTI.Columns(i).DataPropertyName.ToLower) + 1))
                widthDTG += dtgTI.Columns(i).Width + 1
            Else
                dtgTI.Columns(i).Visible = False
            End If
        Next
        dtgTI.Width = widthDTG
        DinhViTienIch(dtgTI, sender)
        dtgTI.Left -= 2
        dtgTI.Top -= 2
        Me.ExtentProperties.Add(sender, ExtenPropertiesComment.ControlHienLuoi())
    End Sub
    Private Sub _Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Not aReady Then Return
        _Enter(sender, Nothing)
    End Sub
    Private Sub _TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Not aReady Then Return
        If sender.Text.Length = 0 Then
            Me.dtgTI.Visible = False
            Me.ExtentProperties.Remove(ExtenPropertiesComment.SelectVal(sender))
        End If
        If Not sender.Modified Then Return
        If sender.Text.Length > 0 Then
            If Me.ExtentProperties.Item(ExtenPropertiesComment.DataSourceTable(sender)) IsNot Nothing Then
                Dim _dt As DataTable = Me.ExtentProperties.Item(ExtenPropertiesComment.DataSourceTable(sender)).Val
                Me.dtgTI.DataSource = _dt
                Dim colFid() As String = _dt.ExtendedProperties("ColFid").ToString.ToLower.Split(New String() {"/"}, StringSplitOptions.RemoveEmptyEntries)

                Dim sFilter As String = ""
                For i = 0 To colFid.Length - 1
                    sFilter &= If(Not String.IsNullOrEmpty(sFilter), " or ", "") & "convert(" & colFid(i) & ",System.String) like '%" & sender.Text & "%'"
                Next
                _dt.DefaultView.RowFilter = sFilter

                If _dt.DefaultView.Count > 0 Then
                    Me.dtgTI.Visible = True

                Else
                    Me.dtgTI.Visible = False
                End If
            End If
        End If
    End Sub
    Private Sub _TextChangedti(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Not sender.Modified Then Return
    End Sub
    Private Sub _Resize(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim c As Control = sender.Parent.Controls("Pic" & sender.Name)
        If c IsNot Nothing Then
            c.Left = sender.Left + sender.Width - 20
            c.Top = sender.Top + (sender.Height - 15) / 2
        End If
    End Sub
    Private Sub _PicClick(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim _ActiveControl = Me.ActiveControl
        While _ActiveControl IsNot Nothing AndAlso TypeOf _ActiveControl Is SplitContainer
            _ActiveControl = CType(_ActiveControl, SplitContainer).ActiveControl
        End While
        If Not aReady Then Return
        Me.Cursor = Cursors.WaitCursor
        If dtgTI.Visible Then
            dtgTI.Visible = False
            sender.Image = pnDeLuuAnhXuong.BackgroundImage
        Else
            Dim c As Control = Me.ExtentProperties.Item("PicBoxTI-" & sender.Name).Val
nhan:
            If Me.ExtentProperties.Item(ExtenPropertiesComment.DataSourceTable(c)) Is Nothing Then
                Threading.Thread.Sleep(100)
                GoTo nhan
            End If
            _Enter(c, Nothing)
            Dim ColDis() As String = dtgTI.DataSource.ExtendedProperties("ColDis").ToString.ToLower.Split("/")
            Dim widthDTG As Integer = 0
            For i = 0 To dtgTI.ColumnCount - 1
                If Array.IndexOf(ColDis, dtgTI.Columns(i).DataPropertyName.ToLower) >= 0 Then
                    dtgTI.Columns(i).Visible = True
                    dtgTI.Columns(i).Width = CInt(ColDis(Array.IndexOf(ColDis, dtgTI.Columns(i).DataPropertyName.ToLower) + 1))
                    widthDTG += dtgTI.Columns(i).Width + 1
                Else
                    dtgTI.Columns(i).Visible = False
                End If
            Next
            dtgTI.Width = widthDTG
            DinhViTienIch(dtgTI, c)
            dtgTI.Left -= 2
            dtgTI.Top -= 2
            dtgTI.Visible = True
            Me.ExtentProperties.Add(c, ExtenPropertiesComment.ControlHienLuoi())
            dtgTI.BringToFront()
            sender.Image = pnDeLuuAnhLen.BackgroundImage
        End If
        noEnter = True
        _ActiveControl = Me.ExtentProperties.Item("PicBoxTI-" & sender.Name).Val
        noEnter = False
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub _EditingControlShowing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs)
        If TypeOf CType(sender, DataGridView).CurrentCell Is DataGridViewTextBoxCell Then
            txtDTG = e.Control
        End If
        If Me.ExtentProperties.Item(sender.Columns(sender.CurrentCell.ColumnIndex).Name & "-DataSource") IsNot Nothing Then

            txtDTG.Name = sender.Columns(sender.CurrentCell.ColumnIndex).Name
            AddHandler txtDTG.Enter, AddressOf _Enter
            AddHandler txtDTG.TextChanged, AddressOf _TextChanged
            AddHandler txtDTG.Click, AddressOf _Click
        End If
    End Sub
    Private Sub _LocationChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim c As Control = sender.Parent.Controls("Pic" & sender.Name)
        If c IsNot Nothing Then
            c.Left = sender.Left + sender.Width - 20
            c.Top = sender.Top + (sender.Height - 15) / 2
        End If
    End Sub
    Private Sub _Validated(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Not String.IsNullOrEmpty(sender.Text) AndAlso Me.ExtentProperties.Item(ExtenPropertiesComment.DataSourceTable(sender)) IsNot Nothing Then

            Dim _dt As DataTable = Me.ExtentProperties.Item(ExtenPropertiesComment.DataSourceTable(sender)).Val
            If _dt IsNot Nothing Then
                Dim _dr() As DataRow = _dt.Select("NoiDung ='" & sender.Text & "'")
                If _dr.Length = 0 Then
                    Dim _drNew As DataRow = _dt.NewRow
                    _dt.Rows.Add(_drNew)
                    _drNew("formName") = Me.Name
                    _drNew("controlName") = sender.Name
                    _drNew("NoiDung") = sender.Text
                    dbXML.UpdateData(_dt, "select * from nhaclenhdm")
                End If
            End If

        End If
    End Sub
    Private Sub _MouseWheel(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        If dtgTI.Visible = True Then
            Dim i As Integer = dtgTI.FirstDisplayedScrollingRowIndex
            i += (-e.Delta / 120)
            If i >= dtgTI.Rows.Count Then
                i = dtgTI.Rows.Count
            End If
            dtgTI.FirstDisplayedScrollingRowIndex = i
        End If
    End Sub
#End Region
#Region "Other Func"
    Public Sub AddCol(ByVal c As Control)
        If TypeOf c Is TextBox AndAlso ExtentProperties.Item(c.Name & "-DataSource") IsNot Nothing AndAlso c.Parent.Controls("Pic" & c.Name) Is Nothing Then
            Dim _s As String = ExtentProperties.Item(c.Name & "-DataSource").Val.ToString
            Dim bgw As New System.ComponentModel.BackgroundWorker()
            AddHandler bgw.DoWork, AddressOf _DoWork
            bgw.RunWorkerAsync(_s)
            RemoveHandler c.Enter, AddressOf _Enter
            RemoveHandler c.Click, AddressOf _Click
            RemoveHandler c.TextChanged, AddressOf _TextChanged
            RemoveHandler c.MouseWheel, AddressOf _MouseWheel
            AddHandler c.Enter, AddressOf _Enter
            AddHandler c.Click, AddressOf _Click
            AddHandler c.TextChanged, AddressOf _TextChanged
            AddHandler c.MouseWheel, AddressOf _MouseWheel
            Dim picBox As New PictureBox()
            picBox.Width = 13
            picBox.Height = 13
            picBox.Parent = c
            picBox.Left = c.Left + c.Width - 20
            picBox.Top = c.Top + (c.Height - 15) / 2
            c.Parent.Controls.Add(picBox)
            picBox.Image = pnDeLuuAnhXuong.BackgroundImage
            picBox.SizeMode = PictureBoxSizeMode.StretchImage
            picBox.BringToFront()
            picBox.Name = "Pic" & c.Name
            picBox.Cursor = Cursors.Hand
            Me.ExtentProperties.Add("1", ExtenPropertiesComment.NoMove(picBox))
            Me.ExtentProperties.Add(c, "PicBoxTI-" & picBox.Name)
            AddHandler CType(c, TextBox).ReadOnlyChanged, Sub()
                                                              picBox.Enabled = Not CType(c, TextBox).ReadOnly
                                                          End Sub
            RemoveHandler picBox.Click, AddressOf _PicClick
            RemoveHandler c.LocationChanged, AddressOf _LocationChanged
            RemoveHandler c.Resize, AddressOf _Resize
            AddHandler picBox.Click, AddressOf _PicClick
            AddHandler c.LocationChanged, AddressOf _LocationChanged
            AddHandler c.Resize, AddressOf _Resize
            _Enter(c, Nothing)
        End If
        If TypeOf c Is TextBox AndAlso ExtentProperties.Item(ExtenPropertiesComment.NapNguocDM(c)) IsNot Nothing Then

            Dim pext As New DataSourceProp("select * from NhacLenhDM where formName = N'" & Me.Name & "' and controlName =N'" & c.Name & "'", "Noidung", "NoiDung", "/NoiDung/400/", "/NoiDung/", c.Name, ExtentProperties.Item(ExtenPropertiesComment.NapNguocDM(c)).Val, False)
            Dim _s As String = pext.RenderSource()
            Dim bgw As New System.ComponentModel.BackgroundWorker()
            AddHandler bgw.DoWork, AddressOf _DoWork
            bgw.RunWorkerAsync(_s)

            RemoveHandler c.Enter, AddressOf _Enter
            RemoveHandler c.Click, AddressOf _Click
            RemoveHandler c.TextChanged, AddressOf _TextChanged
            RemoveHandler c.Validated, AddressOf _Validated
            RemoveHandler c.MouseWheel, AddressOf _MouseWheel

            AddHandler c.Enter, AddressOf _Enter
            AddHandler c.Click, AddressOf _Click
            AddHandler c.TextChanged, AddressOf _TextChanged
            AddHandler c.Validated, AddressOf _Validated
            AddHandler c.MouseWheel, AddressOf _MouseWheel
            _Enter(c, Nothing)
        End If

        If TypeOf c Is DataGridView AndAlso Not (Me.ExtentProperties.Item(ExtenPropertiesComment.NoMove(c)) IsNot Nothing) Then
            DongBoLuoi(CType(c, DataGridView))
            CType(c, DataGridView).AutoGenerateColumns = False
        End If
        If TypeOf c Is Button Then
            If c.Name.ToLower Like "*thoat" OrElse c.Name.ToLower Like "*dong" OrElse c.Name.ToLower Like "*close" Then
                AddHandler c.Click, Sub()
                                        Me.Close()
                                    End Sub
                CType(c, Button).Image = My.Resources.Close
            End If
            If c.Name.ToLower Like "*them" OrElse c.Name.ToLower Like "*add" OrElse c.Name.ToLower Like "*new" Then
                CType(c, Button).Image = My.Resources.ImgNew
            End If
            If c.Name.ToLower Like "*sua" OrElse c.Name.ToLower Like "*edit" Then
                CType(c, Button).Image = My.Resources.write
            End If
            If c.Name.ToLower Like "*xoa" OrElse c.Name.ToLower Like "*delete" Then
                CType(c, Button).Image = My.Resources.Delete
            End If
            If c.Name.ToLower Like "*them" OrElse c.Name.ToLower Like "*add" OrElse c.Name.ToLower Like "*new" Then
                CType(c, Button).Image = My.Resources.ImgNew
            End If
            If c.Name.ToLower Like "*save" OrElse c.Name.ToLower Like "*luu" Then
                CType(c, Button).Image = My.Resources.Save
            End If
            If c.Name.ToLower Like "*print" OrElse c.Name.ToLower Like "*in" Then
                CType(c, Button).Image = My.Resources.printer
            End If
            DongBoBtn(c)
        End If
        If TypeOf c Is TabControl Then
            Dim i As Integer = 0
            While i < c.Controls.Count
                AddCol(c.Controls(i))
                i += 1
            End While
        ElseIf TypeOf c Is DataGridView Then
            For i = 0 To CType(c, DataGridView).Columns.Count - 1
                If ExtentProperties.Item(CType(c, DataGridView).Columns(i).Name & "-DataSource") IsNot Nothing Then
                    Dim _s As String = ExtentProperties.Item(CType(c, DataGridView).Columns(i).Name & "-DataSource").Val.ToString
                    Dim bgw As New System.ComponentModel.BackgroundWorker()
                    AddHandler bgw.DoWork, AddressOf _DoWork
                    bgw.RunWorkerAsync(_s)
                End If
                If ExtentProperties.Item(ExtenPropertiesComment.NhapNgayThang(CType(c, DataGridView).Columns(i))) IsNot Nothing Then
                    CType(c, DataGridView).Columns(i).DefaultCellStyle.Format = "dd/MM/yyyy"
                End If
                If ExtentProperties.Item(ExtenPropertiesComment.NhapNgayGio(CType(c, DataGridView).Columns(i))) IsNot Nothing Then
                    CType(c, DataGridView).Columns(i).DefaultCellStyle.Format = "dd/MM/yyyy HH:mm"
                End If
                If ExtentProperties.Item(ExtenPropertiesComment.NhapGioFull(CType(c, DataGridView).Columns(i))) IsNot Nothing Then
                    CType(c, DataGridView).Columns(i).DefaultCellStyle.Format = "HH:mm:ss"
                End If
                If ExtentProperties.Item(ExtenPropertiesComment.NhapGioPhut(CType(c, DataGridView).Columns(i))) IsNot Nothing Then
                    CType(c, DataGridView).Columns(i).DefaultCellStyle.Format = "HH:mm"
                End If
            Next
            AddHandler CType(c, DataGridView).EditingControlShowing, AddressOf _EditingControlShowing
        Else
            Dim i As Integer = 0
            While i < c.Controls.Count
                AddCol(c.Controls(i))
                i += 1
            End While

        End If
    End Sub
    Public Sub DinhViTienIch(ByVal Dong As Object, ByVal CoDinh As Object, Optional ByVal Column As Integer = -1, Optional ByVal Row As Integer = -1, Optional ByVal giasoTOP As Integer = 0, Optional ByVal giasoLEFT As Integer = 0)
        If (Not IsNothing(CoDinh.Parent.Parent) AndAlso TypeOf CoDinh.Parent.Parent Is DataGridView) Then CoDinh = CoDinh.Parent.Parent
        Dim p1 As Point = CoDinh.FindForm.PointToScreen(New Point)
        Dim p2 As Point = CoDinh.PointToScreen(New Point)
        If Not CoDinh.FindForm.Controls.Contains(Dong) Then Dong.Parent = CoDinh.FindForm
        If TypeOf CoDinh Is DataGridView Then
            If Column = -1 Then Column = CoDinh.CurrentCell.ColumnIndex
            If Row = -1 Then Row = CoDinh.CurrentCell.rowIndex
            Dim mColumn As Rectangle = CoDinh.GetColumnDisplayRectangle(Column, True)
            Dim mRow As Rectangle = CoDinh.GetRowDisplayRectangle(Row, True)
            If p2.Y - p1.Y + mRow.Bottom + Dong.Height < CoDinh.FindForm.Height Then
                Dong.Top = p2.Y - p1.Y + mRow.Bottom + giasoTOP
            Else
                Dong.Top = p2.Y - p1.Y + mRow.Top - Dong.Height + giasoTOP
            End If
            If p2.X - p1.X + mColumn.Left + Dong.Width < (p1.X + CoDinh.FindForm.Width) Then
                Dong.Left = p2.X - p1.X + mColumn.Left + giasoLEFT
            Else
                Dong.Left = (p2.X - p1.X + mColumn.Right) - Dong.Width + giasoLEFT
            End If
        Else
            If p2.Y - p1.Y + CoDinh.Height + Dong.Height < CoDinh.FindForm.Height Then
                Dong.Top = p2.Y - p1.Y + CoDinh.Height + giasoTOP
            Else
                Dong.Top = p2.Y - p1.Y - Dong.Height + giasoTOP
            End If
            If p2.X - p1.X + Dong.Width < CoDinh.FindForm.Width Then
                Dong.Left = p2.X - p1.X + giasoLEFT
            Else
                Dong.Left = (p2.X - p1.X + CoDinh.Width) - Dong.Width + giasoLEFT
            End If
        End If
        Dong.BringToFront()
    End Sub
    Public Function DiChuyenConTro(ByVal K As System.Windows.Forms.Keys, ByVal C As Object, Optional ByVal ChiDiChuyenTrenLuoi As Boolean = True, Optional ByVal CotBatDau As String = Nothing, Optional ByVal CotKetThuc As String = Nothing, Optional ByVal LuoiTienIch As DataGridView = Nothing, Optional ByRef TimThay As Boolean = False, Optional ByVal UpDown As Boolean = True) As Boolean
        Dim Obj As Object = C, Obj1 As DataGridViewTextBoxEditingControl = Nothing
        If IsNothing(Obj) Then Return True
        If Not Obj.Parent Is Nothing AndAlso Not Obj.Parent.Parent Is Nothing AndAlso TypeOf Obj.Parent.Parent Is DataGridView Then Obj = C.Parent.Parent
        If TypeOf C Is DataGridViewTextBoxEditingControl Then Obj1 = C
        If Not IsNothing(LuoiTienIch) AndAlso LuoiTienIch.Visible Then
            If LuoiTienIch.RowCount = 0 OrElse LuoiTienIch.ColumnCount = 0 Then LuoiTienIch.Visible = False : Return True
            Dim RowsNext As Integer = LuoiTienIch.Rows.GetFirstRow(DataGridViewElementStates.Visible)
            Dim ColumnsNext As Integer = LuoiTienIch.Columns.GetFirstColumn(DataGridViewElementStates.Visible).Index
            Dim ColumnsViewMax As Integer = LuoiTienIch.Columns.GetLastColumn(DataGridViewElementStates.Visible, Nothing).Index
            If IsNothing(LuoiTienIch.CurrentCell) Then LuoiTienIch.CurrentCell = LuoiTienIch.Item(ColumnsNext, RowsNext)
            Select Case K
                Case Keys.Up
                    TimThay = True : ColumnsNext = LuoiTienIch.CurrentCell.ColumnIndex
                    If Not LuoiTienIch.Columns(ColumnsNext).ReadOnly AndAlso TypeOf LuoiTienIch.Columns(ColumnsNext) Is DataGridViewComboBoxColumn AndAlso UpDown Then Return True
                    RowsNext = LuoiTienIch.Rows.GetPreviousRow(LuoiTienIch.CurrentCell.RowIndex, DataGridViewElementStates.Visible)
                    If RowsNext < 0 Then RowsNext = LuoiTienIch.RowCount - 1
                    If RowsNext < 0 Then RowsNext = 0
                    LuoiTienIch.CurrentCell = LuoiTienIch.Item(ColumnsNext, RowsNext)
                    Return True
                Case Keys.Down
                    TimThay = True : ColumnsNext = LuoiTienIch.CurrentCell.ColumnIndex
                    If Not LuoiTienIch.Columns(ColumnsNext).ReadOnly AndAlso TypeOf LuoiTienIch.Columns(ColumnsNext) Is DataGridViewComboBoxColumn AndAlso UpDown Then Return True
                    RowsNext = LuoiTienIch.Rows.GetNextRow(LuoiTienIch.CurrentCell.RowIndex, DataGridViewElementStates.Visible)
                    If RowsNext < 0 Then RowsNext = 0
                    LuoiTienIch.CurrentCell = LuoiTienIch.Item(ColumnsNext, RowsNext)
                    Return True
                Case Keys.Left, Keys.Right
                    TimThay = True
                    Select Case K
                        Case Keys.Right
                            Select Case LuoiTienIch.CurrentCell.ColumnIndex
                                Case ColumnsViewMax
                                    If LuoiTienIch.CurrentCell.RowIndex < (LuoiTienIch.RowCount - 1) Then
                                        RowsNext = LuoiTienIch.Rows.GetNextRow(LuoiTienIch.CurrentCell.RowIndex, DataGridViewElementStates.Visible)
                                        LuoiTienIch.CurrentCell = LuoiTienIch.Item(ColumnsNext, RowsNext)
                                        LuoiTienIch.FirstDisplayedScrollingColumnIndex = ColumnsNext
                                    Else
                                        LuoiTienIch.CurrentCell = LuoiTienIch.Item(ColumnsNext, LuoiTienIch.CurrentCell.RowIndex)
                                        LuoiTienIch.FirstDisplayedScrollingColumnIndex = ColumnsNext
                                    End If
                                Case Else
                                    ColumnsNext = LuoiTienIch.Columns.GetNextColumn(LuoiTienIch.Columns(LuoiTienIch.CurrentCell.ColumnIndex), DataGridViewElementStates.Visible, Nothing).Index
                                    LuoiTienIch.CurrentCell = LuoiTienIch.Item(ColumnsNext, LuoiTienIch.CurrentCell.RowIndex)
                                    LuoiTienIch.FirstDisplayedScrollingColumnIndex = ColumnsNext
                            End Select
                        Case Keys.Left
                            Select Case LuoiTienIch.CurrentCell.ColumnIndex
                                Case ColumnsNext
                                    If LuoiTienIch.CurrentCell.RowIndex > 0 Then
                                        RowsNext = LuoiTienIch.Rows.GetPreviousRow(LuoiTienIch.CurrentCell.RowIndex, DataGridViewElementStates.Visible)
                                        LuoiTienIch.CurrentCell = LuoiTienIch.Item(ColumnsViewMax, RowsNext)
                                        LuoiTienIch.FirstDisplayedScrollingColumnIndex = ColumnsViewMax
                                    Else
                                        LuoiTienIch.CurrentCell = LuoiTienIch.Item(ColumnsViewMax, LuoiTienIch.CurrentCell.RowIndex)
                                        LuoiTienIch.FirstDisplayedScrollingColumnIndex = ColumnsViewMax
                                    End If
                                Case Else
                                    ColumnsNext = LuoiTienIch.Columns.GetPreviousColumn(LuoiTienIch.Columns(LuoiTienIch.CurrentCell.ColumnIndex), DataGridViewElementStates.Visible, Nothing).Index
                                    LuoiTienIch.CurrentCell = LuoiTienIch.Item(ColumnsNext, LuoiTienIch.CurrentCell.RowIndex)
                                    LuoiTienIch.FirstDisplayedScrollingColumnIndex = ColumnsNext
                            End Select
                    End Select
                    Return True
                Case Keys.Enter
                    Return True
            End Select
            TimThay = False
        End If
        Select Case K
            Case Keys.Enter, Keys.Left, Keys.Right, Keys.Up, Keys.Down, (Keys.Shift + Keys.Enter)
                If TypeOf Obj Is DataGridView Then
                    On Error GoTo nhan
                    Dim RowsNext As Integer = Obj.Rows.GetFirstRow(DataGridViewElementStates.Visible)
                    Dim ColumnsNext As Integer = Obj.Columns.GetFirstColumn(DataGridViewElementStates.Visible).Index
                    If Not IsNothing(CotBatDau) AndAlso Obj.Columns(CotBatDau).Index <= Obj.CurrentCell.ColumnIndex Then ColumnsNext = Obj.Columns(CotBatDau).Index
                    Dim ColumnsViewMax As Integer = Obj.Columns.GetLastColumn(DataGridViewElementStates.Visible, Nothing).Index
                    If Not IsNothing(CotKetThuc) AndAlso Obj.Columns(CotKetThuc).Index >= Obj.CurrentCell.ColumnIndex Then ColumnsViewMax = Obj.Columns(CotKetThuc).Index
                    Select Case K
                        Case Keys.Up, Keys.Down : Return False
                        Case Keys.Left
                            If (Not Obj1 Is Nothing AndAlso (Obj1.SelectedText = Obj1.Text OrElse Obj1.SelectionStart = 0)) Then
                                K = (Keys.Shift + Keys.Enter)
                            Else
                                If Obj.CurrentCell.ColumnIndex <> ColumnsNext Then Return False
                                If Not (Not Obj1 Is Nothing AndAlso (Obj1.SelectedText = Obj1.Text OrElse Obj1.SelectionStart = 0)) Then Return False
                                K = (Keys.Shift + Keys.Enter)
                            End If
                        Case Keys.Right
                            If (Not Obj1 Is Nothing AndAlso (Obj1.SelectedText = Obj1.Text OrElse Obj1.SelectionStart = Obj1.TextLength)) Then
                                K = Keys.Enter
                            Else
                                If Obj.CurrentCell.ColumnIndex < ColumnsViewMax Then Return False
                                If Not (Not Obj1 Is Nothing AndAlso (Obj1.SelectedText = Obj1.Text OrElse Obj1.SelectionStart = Obj1.TextLength)) Then Return False
                                K = Keys.Enter
                            End If
                    End Select
                    Select Case K
                        Case Keys.Enter
                            Select Case Obj.CurrentCell.ColumnIndex
                                Case ColumnsViewMax
                                    If Obj.CurrentCell.RowIndex < (Obj.RowCount - 1) Then
                                        RowsNext = Obj.Rows.GetNextRow(Obj.CurrentCell.RowIndex, DataGridViewElementStates.Visible)
                                        Obj.CurrentCell = Obj.Item(ColumnsNext, RowsNext)
                                        Obj.FirstDisplayedScrollingColumnIndex = ColumnsNext
                                    Else
                                        Obj.CurrentCell = Obj.Item(ColumnsNext, Obj.CurrentCell.RowIndex)
                                        Obj.FirstDisplayedScrollingColumnIndex = ColumnsNext
                                    End If
                                Case Else
                                    ColumnsNext = Obj.Columns.GetNextColumn(Obj.Columns(Obj.CurrentCell.ColumnIndex), DataGridViewElementStates.Visible, Nothing).Index
                                    Obj.CurrentCell = Obj.Item(ColumnsNext, Obj.CurrentCell.RowIndex)
                                    Obj.FirstDisplayedScrollingColumnIndex = ColumnsNext
                            End Select
                        Case (Keys.Shift + Keys.Enter)
                            Select Case Obj.CurrentCell.ColumnIndex
                                Case ColumnsNext
                                    If Obj.CurrentCell.RowIndex > 0 Then
                                        RowsNext = Obj.Rows.GetPreviousRow(Obj.CurrentCell.RowIndex, DataGridViewElementStates.Visible)
                                        Obj.CurrentCell = Obj.Item(ColumnsViewMax, RowsNext)
                                        Obj.FirstDisplayedScrollingColumnIndex = ColumnsViewMax
                                    Else
                                        Obj.CurrentCell = Obj.Item(ColumnsViewMax, Obj.CurrentCell.RowIndex)
                                        Obj.FirstDisplayedScrollingColumnIndex = ColumnsViewMax
                                    End If
                                Case Else
                                    ColumnsNext = Obj.Columns.GetPreviousColumn(Obj.Columns(Obj.CurrentCell.ColumnIndex), DataGridViewElementStates.Visible, Nothing).Index
                                    Obj.CurrentCell = Obj.Item(ColumnsNext, Obj.CurrentCell.RowIndex)
                                    Obj.FirstDisplayedScrollingColumnIndex = ColumnsNext
                            End Select
                    End Select
nhan:
                    Return True
                ElseIf Not ChiDiChuyenTrenLuoi AndAlso Not TypeOf Obj Is Button Then
                    Select Case K
                        Case Keys.Left, Keys.Up
                            If (TypeOf Obj Is TextBox OrElse TypeOf Obj Is ComboBox OrElse TypeOf Obj Is RichTextBox) Then If Not (Obj.SelectedText = Obj.Text OrElse Obj.SelectionStart = 0) OrElse (K = Keys.Up AndAlso TypeOf Obj Is ComboBox) Then Return False
                            K = (Keys.Shift + Keys.Enter)
                        Case Keys.Right, Keys.Down
                            If (TypeOf Obj Is TextBox OrElse TypeOf Obj Is ComboBox OrElse TypeOf Obj Is RichTextBox) Then If Not ((TypeOf Obj Is ComboBox AndAlso Obj.DropDownStyle = ComboBoxStyle.DropDownList) OrElse Obj.SelectedText = Obj.Text OrElse Obj.SelectionStart = Obj.Text.Length) OrElse (K = Keys.Down AndAlso TypeOf Obj Is ComboBox) Then Return False
                            K = Keys.Enter
                    End Select
                    Call Obj.FindForm.SelectNextControl(C, K = Keys.Enter, True, True, True)
                    If Not IsNothing(LuoiTienIch) Then LuoiTienIch.Visible = False
                    Return True
                End If
        End Select
    End Function
    ''' <summary>
    ''' Load data theo thiết lập query lấy dữ liệu vào các control trên form
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub LoadData()
        Dim _s As String = QrLayDL
        ChuanSql(_s, Me)
        DataSetNguon = dbXML.GetDataset(_s)
    End Sub
    ''' <summary>
    ''' Fill data từ dataset chung vào các control trên form 
    ''' </summary>
    ''' <param name="c"></param>
    ''' <remarks></remarks>
    Public Sub FillData(ByVal c As Control)
        If DataSetNguon Is Nothing Then Return
        If TypeOf c Is TabControl Then
            For Each item As TabPage In CType(c, TabControl).TabPages
                FillData(c)
            Next
        Else
            For Each item As Control In c.Controls
                'If item.Name = "txtTrinhDoVanHoa" Then Stop
                If Me.ExtentProperties.Item(item.Name & "-GetFields") IsNot Nothing Then
                    Dim fields() As String = Me.ExtentProperties.Item(item.Name & "-GetFields").Val.ToString.Split("!")
                    If fields.Length < 3 Then Continue For
                    If Not IsNumeric(fields(0)) OrElse Not IsNumeric(fields(1)) Then Continue For
                    Dim _tabIndex = CInt(fields(0))
                    Dim _rowIndex = CInt(fields(1))
                    If DataSetNguon.Tables.Count <= _tabIndex Then Continue For
                    If DataSetNguon.Tables(_tabIndex).Rows.Count <= _rowIndex Then Continue For
                    Dim Val As Object = DataSetNguon.Tables(CInt(fields(0))).Rows(CInt(fields(1)))(fields(2))
                    Try
                        SetVal(item, Val)
                    Catch ex As Exception
                        Dim a = "'"
                    End Try

                End If
                FillData(item)
            Next
        End If
    End Sub
    ''' <summary>
    ''' Đổ data vào các grid
    ''' </summary>
    ''' <param name="c"></param>
    ''' <remarks></remarks>
    Public Sub FillSubGrid(ByVal c As Control)
        If TypeOf c Is TabControl Then
            For Each item As TabPage In CType(c, TabControl).TabPages
                FillSubGrid(item)
            Next
        Else
            If TypeOf c Is DataGridView Then
                If Me.ExtentProperties.Item(ExtenPropertiesComment.DataSourceControl(c)) IsNot Nothing Then
                    Dim _sql As String = Me.ExtentProperties.Item(ExtenPropertiesComment.DataSourceControl(c)).Val
                    ChuanSql(_sql, Me)
                    CType(c, DataGridView).DataSource = dbXML.GetTable(_sql)
                End If
            End If
            For Each item As Control In c.Controls
                FillSubGrid(item)
            Next
        End If
    End Sub
    ''' <summary>
    ''' Save lại các grid
    ''' </summary>
    ''' <param name="c"></param>
    ''' <remarks></remarks>
    Public Sub SaveSubGrid(ByVal c As Control)
        If TypeOf c Is TabControl Then
            For Each item As TabPage In CType(c, TabControl).TabPages
                SaveSubGrid(item)
            Next
        Else
            If TypeOf c Is DataGridView Then
                If Me.ExtentProperties.Item(ExtenPropertiesComment.DataSourceControl(c)) IsNot Nothing Then
                    Dim _sql As String = Me.ExtentProperties.Item(ExtenPropertiesComment.DataSourceControl(c)).Val
                    Dim _dsVal() As String = _sql.Split(New String() {"{", "}"}, StringSplitOptions.RemoveEmptyEntries)
                    Dim _dt As DataTable = CType(c, DataGridView).DataSource
                    If _dt IsNot Nothing Then
                        For idxr = 1 To _dsVal.Length - 1 Step 2
                            If idxr < _dsVal.Length Then
                                Dim cVal = (From p In AllControlInForm Where p.Name.ToLower = _dsVal(idxr).ToLower Select p).ToList
                                If cVal.Count > 0 Then

                                End If
                            End If
                        Next
                    End If
                End If
            End If
            For Each item As Control In c.Controls
                SaveSubGrid(item)
            Next
        End If
    End Sub
    ''' <summary>
    ''' Đổ daata từ các control trên form vào dataset chung
    ''' </summary>
    ''' <param name="c">Truyền vào Me</param>
    ''' <remarks></remarks>
    Public Sub SaveVal(ByVal c As Control)
        If DataSetNguon Is Nothing Then Return
        If TypeOf c Is TabControl Then
            For Each item As TabPage In CType(c, TabControl).TabPages
                SaveVal(c)
            Next
        Else
            For Each item As Control In c.Controls
                If Me.ExtentProperties.Item(item.Name & "-GetFields") IsNot Nothing Then
                    Dim fields() As String = Me.ExtentProperties.Item(item.Name & "-GetFields").Val.ToString.Split("!")
                    Select Case item.GetType.Name
                        Case "TextBox", "Label"
                            If Not String.IsNullOrEmpty(item.Text) Then
                                If Me.ExtentProperties.Item(item.Name & "-SelectVal") IsNot Nothing Then
                                    DataSetNguon.Tables(CInt(fields(0))).Rows(CInt(fields(1)))(fields(2)) = Me.ExtentProperties.Item(item.Name & "-SelectVal").Val
                                Else
                                    DataSetNguon.Tables(CInt(fields(0))).Rows(CInt(fields(1)))(fields(2)) = item.Text
                                End If
                            End If
                        Case "ComboBox"
                            If CType(item, ComboBox).SelectedValue IsNot Nothing Then DataSetNguon.Tables(CInt(fields(0))).Rows(CInt(fields(1)))(fields(2)) = CType(item, ComboBox).SelectedValue
                        Case "CheckBox", "RadioButton"
                            DataSetNguon.Tables(CInt(fields(0))).Rows(CInt(fields(1)))(fields(2)) = CType(item, Object).Checked
                    End Select
                End If
                SaveVal(item)
            Next
        End If
    End Sub
    ''' <summary>
    ''' Chuẩn lại query theo các control trên lưới
    ''' </summary>
    ''' <param name="_s">Query cần chuẩn, vị trí cần đổ định dạng {tên control}</param>
    ''' <param name="c">Truyền vào Me</param>
    ''' <remarks></remarks>
    Sub ChuanSql(ByRef _s As String, ByVal c As Control)
        If TypeOf c Is TabControl Then
            For Each item As TabPage In CType(c, TabControl).TabPages
                ChuanSql(_s, item)
            Next
        Else
            For Each item As Control In c.Controls
                Select Case item.GetType.Name
                    Case "TextBox", "Label"
                        _s = _s.Replace("{" & item.Name & "}", item.Text)
                    Case "ComboBox"
                        _s = _s.Replace("{" & item.Name & "}", CType(item, ComboBox).SelectedValue)
                    Case "CheckBox", "RadioButton"
                        _s = _s.Replace("{" & item.Name & "}", Math.Abs(CType(item, Object).Checked * -1))
                End Select
                ChuanSql(_s, item)
            Next
        End If
    End Sub
    ''' <summary>
    ''' Kiểm tra dữ liệu trước lưu
    ''' </summary>
    ''' <remarks></remarks>
    Function CheckData(ByVal c As Control, Optional ByVal checkGrid As Boolean = False) As Boolean
        ' If c.Name = "txtNgaySinh" Then Stop
        If TypeOf c Is TabControl Then
            For Each item As TabPage In CType(c, TabControl).TabPages
                If Not CheckData(item) Then Return False
            Next
        Else
            If TypeOf c Is TextBox AndAlso (Me.ExtentProperties.Item(ExtenPropertiesComment.NhapNgayThang(c)) IsNot Nothing OrElse Me.ExtentProperties.Item(ExtenPropertiesComment.NhapGioFull(c)) IsNot Nothing OrElse Me.ExtentProperties.Item(ExtenPropertiesComment.NhapGioPhut(c)) IsNot Nothing OrElse Me.ExtentProperties.Item(ExtenPropertiesComment.NhapNgayGio(c)) IsNot Nothing) AndAlso Not String.IsNullOrEmpty(c.Text) AndAlso Not IsDate(c.Text) Then
                MsgBox("Nhập sai định dạng ngày giờ!", MsgBoxStyle.Critical)
                CType(c, TextBox).SelectAll()
                Dim f As Form = c.FindForm()
                Dim _activecontrol = f.ActiveControl
                If TypeOf _activecontrol Is SplitContainer Then
                    CType(_activecontrol, SplitContainer).ActiveControl = c
                Else
                    f.ActiveControl = c
                End If
                Return False
            End If
            If TypeOf c Is TextBox AndAlso (Me.ExtentProperties.Item(ExtenPropertiesComment.NhapSoLe(c)) IsNot Nothing OrElse Me.ExtentProperties.Item(ExtenPropertiesComment.NhapSoNguyen(c)) IsNot Nothing) AndAlso Not String.IsNullOrEmpty(c.Text) AndAlso Not IsNumeric(c.Text) Then
                MsgBox("Nhập sai định dạng số!", MsgBoxStyle.Critical)
                CType(c, TextBox).SelectAll()
                Dim f As Form = c.FindForm()
                Dim _activecontrol = f.ActiveControl
                If TypeOf _activecontrol Is SplitContainer Then
                    CType(_activecontrol, SplitContainer).ActiveControl = c
                Else
                    f.ActiveControl = c
                End If
                Return False
            End If
            If TypeOf c Is TextBox AndAlso Me.ExtentProperties.Item(ExtenPropertiesComment.MaxValue(c)) IsNot Nothing AndAlso IsNumeric(Me.ExtentProperties.Item(ExtenPropertiesComment.MaxValue(c)).Val.ToString) AndAlso Not String.IsNullOrEmpty(c.Text) AndAlso IsNumeric(c.Text) AndAlso CDec(c.Text) > CDec(Me.ExtentProperties.Item(ExtenPropertiesComment.MaxValue(c)).Val.ToString) Then
                MsgBox("Giá trị nhập lớn hơn giá trị lớn nhất: " & Me.ExtentProperties.Item(ExtenPropertiesComment.MaxValue(c)).Val.ToString, MsgBoxStyle.Critical)
                CType(c, TextBox).SelectAll()
                Dim f As Form = c.FindForm()
                Dim _activecontrol = f.ActiveControl
                If TypeOf _activecontrol Is SplitContainer Then
                    CType(_activecontrol, SplitContainer).ActiveControl = c
                Else
                    f.ActiveControl = c
                End If
                Return False
            End If
            If TypeOf c Is TextBox AndAlso Me.ExtentProperties.Item(ExtenPropertiesComment.MinValue(c)) IsNot Nothing AndAlso IsNumeric(Me.ExtentProperties.Item(ExtenPropertiesComment.MinValue(c)).Val.ToString) AndAlso Not String.IsNullOrEmpty(c.Text) AndAlso IsNumeric(c.Text) AndAlso CDec(c.Text) < CDec(Me.ExtentProperties.Item(ExtenPropertiesComment.MinValue(c)).Val.ToString) Then
                MsgBox("Giá trị nhập bé hơn giá trị nhỏ nhất: " & Me.ExtentProperties.Item(ExtenPropertiesComment.MinValue(c)).Val.ToString, MsgBoxStyle.Critical)
                CType(c, TextBox).SelectAll()
                Dim f As Form = c.FindForm()
                Dim _activecontrol = f.ActiveControl
                If TypeOf _activecontrol Is SplitContainer Then
                    CType(_activecontrol, SplitContainer).ActiveControl = c
                Else
                    f.ActiveControl = c
                End If
                Return False
            End If
            If TypeOf c Is TextBox AndAlso (Me.ExtentProperties.Item(ExtenPropertiesComment.NotNull(c)) IsNot Nothing) AndAlso String.IsNullOrEmpty(c.Text) Then
                MsgBox("Thông tin không được để trống!", MsgBoxStyle.Critical)
                CType(c, TextBox).SelectAll()
                Dim f As Form = c.FindForm()
                Dim _activecontrol = f.ActiveControl
                If TypeOf _activecontrol Is SplitContainer Then
                    CType(_activecontrol, SplitContainer).ActiveControl = c
                Else
                    f.ActiveControl = c
                End If
                Return False
            End If
            If TypeOf c Is ComboBox AndAlso (Me.ExtentProperties.Item(ExtenPropertiesComment.NotNull(c)) IsNot Nothing) AndAlso (CType(c, ComboBox).SelectedValue Is Nothing) Then
                MsgBox("Thông tin không được để trống!", MsgBoxStyle.Critical)
                Dim f As Form = c.FindForm()
                Dim _activecontrol = f.ActiveControl
                If TypeOf _activecontrol Is SplitContainer Then
                    CType(_activecontrol, SplitContainer).ActiveControl = c
                Else
                    f.ActiveControl = c
                End If
                Return False
            End If
            If checkGrid AndAlso TypeOf c Is DataGridView Then
                Dim luoi As DataGridView = c
                If luoi.CurrentRow IsNot Nothing Then
                    For Each item As DataGridViewColumn In luoi.Columns
                        If Not item.Visible Then Continue For
                        If TypeOf item Is DataGridViewTextBoxColumn AndAlso (Me.ExtentProperties.Item(ExtenPropertiesComment.NhapNgayThang(item)) IsNot Nothing OrElse Me.ExtentProperties.Item(ExtenPropertiesComment.NhapGioFull(item)) IsNot Nothing OrElse Me.ExtentProperties.Item(ExtenPropertiesComment.NhapGioPhut(item)) IsNot Nothing OrElse Me.ExtentProperties.Item(ExtenPropertiesComment.NhapNgayGio(item)) IsNot Nothing) AndAlso luoi.CurrentRow.Cells(item.Name).Value IsNot Nothing AndAlso Not String.IsNullOrEmpty(luoi.CurrentRow.Cells(item.Name).Value.ToString) AndAlso Not IsDate(luoi.CurrentRow.Cells(item.Name).Value.ToString) Then
                            MsgBox("Nhập sai định dạng ngày giờ!", MsgBoxStyle.Critical)
                            luoi.CurrentCell = luoi.CurrentRow.Cells(item.Name)
                            CType(txtDTG, TextBox).SelectAll()
                            Dim f As Form = c.FindForm()
                            Dim _activecontrol = f.ActiveControl
                            If TypeOf _activecontrol Is SplitContainer Then
                                CType(_activecontrol, SplitContainer).ActiveControl = c
                            Else
                                f.ActiveControl = c
                            End If
                            Return False
                        End If
                        If TypeOf item Is DataGridViewTextBoxColumn AndAlso (Me.ExtentProperties.Item(ExtenPropertiesComment.NhapSoLe(item)) IsNot Nothing OrElse Me.ExtentProperties.Item(ExtenPropertiesComment.NhapSoNguyen(item)) IsNot Nothing) AndAlso luoi.CurrentRow.Cells(item.Name).Value IsNot Nothing AndAlso Not String.IsNullOrEmpty(luoi.CurrentRow.Cells(item.Name).Value.ToString) AndAlso Not IsNumeric(luoi.CurrentRow.Cells(item.Name).Value.ToString) Then
                            MsgBox("Nhập sai định dạng số!", MsgBoxStyle.Critical)
                            luoi.CurrentCell = luoi.CurrentRow.Cells(item.Name)
                            CType(txtDTG, TextBox).SelectAll()
                            Dim f As Form = c.FindForm()
                            Dim _activecontrol = f.ActiveControl
                            If TypeOf _activecontrol Is SplitContainer Then
                                CType(_activecontrol, SplitContainer).ActiveControl = c
                            Else
                                f.ActiveControl = c
                            End If
                            Return False
                        End If
                        If Me.ExtentProperties.Item(ExtenPropertiesComment.MaxValue(item)) IsNot Nothing AndAlso IsNumeric(Me.ExtentProperties.Item(ExtenPropertiesComment.MaxValue(item)).Val.ToString) AndAlso luoi.CurrentRow.Cells(item.Name).Value IsNot Nothing AndAlso Not String.IsNullOrEmpty(luoi.CurrentRow.Cells(item.Name).Value.ToString) AndAlso IsNumeric(luoi.CurrentRow.Cells(item.Name).Value.ToString) AndAlso CDec(luoi.CurrentRow.Cells(item.Name).Value.ToString) > CDec(Me.ExtentProperties.Item(ExtenPropertiesComment.MaxValue(item)).Val.ToString) Then
                            MsgBox("Giá trị nhập lớn hơn giá trị lớn nhất: " & Me.ExtentProperties.Item(ExtenPropertiesComment.MaxValue(item)).Val.ToString, MsgBoxStyle.Critical)
                            luoi.CurrentCell = luoi.CurrentRow.Cells(item.Name)
                            CType(txtDTG, TextBox).SelectAll()
                            Dim f As Form = c.FindForm()
                            Dim _activecontrol = f.ActiveControl
                            If TypeOf _activecontrol Is SplitContainer Then
                                CType(_activecontrol, SplitContainer).ActiveControl = c
                            Else
                                f.ActiveControl = c
                            End If
                            Return False
                        End If
                        If Me.ExtentProperties.Item(ExtenPropertiesComment.MinValue(item)) IsNot Nothing AndAlso IsNumeric(Me.ExtentProperties.Item(ExtenPropertiesComment.MinValue(item)).Val.ToString) AndAlso luoi.CurrentRow.Cells(item.Name).Value IsNot Nothing AndAlso Not String.IsNullOrEmpty(luoi.CurrentRow.Cells(item.Name).Value.ToString) AndAlso IsNumeric(luoi.CurrentRow.Cells(item.Name).Value.ToString) AndAlso CDec(luoi.CurrentRow.Cells(item.Name).Value.ToString) < CDec(Me.ExtentProperties.Item(ExtenPropertiesComment.MinValue(item)).Val.ToString) Then
                            MsgBox("Giá trị nhập bé hơn giá trị nhỏ nhất: " & Me.ExtentProperties.Item(ExtenPropertiesComment.MinValue(item)).Val.ToString, MsgBoxStyle.Critical)
                            luoi.CurrentCell = luoi.CurrentRow.Cells(item.Name)
                            CType(txtDTG, TextBox).SelectAll()
                            Dim f As Form = c.FindForm()
                            Dim _activecontrol = f.ActiveControl
                            If TypeOf _activecontrol Is SplitContainer Then
                                CType(_activecontrol, SplitContainer).ActiveControl = c
                            Else
                                f.ActiveControl = c
                            End If
                            Return False
                        End If
                        If (Me.ExtentProperties.Item(ExtenPropertiesComment.NotNull(item)) IsNot Nothing) AndAlso (luoi.CurrentRow.Cells(item.Name).Value Is Nothing OrElse String.IsNullOrEmpty(luoi.CurrentRow.Cells(item.Name).Value.ToString)) Then
                            MsgBox("Thông tin không được để trống!", MsgBoxStyle.Critical)
                            luoi.CurrentCell = luoi.CurrentRow.Cells(item.Name)
                            CType(txtDTG, TextBox).SelectAll()
                            Dim f As Form = c.FindForm()
                            Dim _activecontrol = f.ActiveControl
                            If TypeOf _activecontrol Is SplitContainer Then
                                CType(_activecontrol, SplitContainer).ActiveControl = c
                            Else
                                f.ActiveControl = c
                            End If
                            Return False
                        End If

                    Next
                End If
            End If
            For Each item As Control In c.Controls
                If Not CheckData(item) Then Return False
            Next
        End If
        Return True
    End Function
    Sub CNDLThieu()
        Dim _s As String = "if not exists(select name from sys.tables where name = 'NhacLenhDM') begin CREATE TABLE NhacLenhDM(NhacLenhDMID int IDENTITY(1,1) PRIMARY KEY NOT NULL,formName nvarchar(50) NULL,controlName nvarchar(50) NULL,NoiDung nvarchar(max) NULL) end"
        dbXML.RunSQL(_s)
    End Sub
    ''' <summary>
    ''' set Val cho control trên form
    ''' </summary>
    ''' <param name="item"></param>
    ''' <param name="val"></param>
    ''' <remarks></remarks>
    Public Sub SetVal(ByVal item As Control, ByVal val As Object)
        Select Case item.GetType.Name
            Case "TextBox", "Label"
                If Me.ExtentProperties.Item(item.Name & "-DataSource") IsNot Nothing Then
                    Dim dem As Integer = 1
NhanTTT:
                    If ExtentProperties.Item(ExtenPropertiesComment.DataSourceTable(item)) Is Nothing Then
                        dem += 1
                        System.Threading.Thread.Sleep(200)
                        If dem < 20 Then GoTo NhanTTT
                    End If
                    Dim _dt As DataTable = ExtentProperties.Item(ExtenPropertiesComment.DataSourceTable(item)).Val
                    If _dt IsNot Nothing Then
                        Dim colKey As String = _dt.ExtendedProperties("ColKey").ToString
                        Dim colVis As String = _dt.ExtendedProperties("ColVis").ToString
                        Dim _dr() As DataRow = _dt.Select("convert(" & colKey & ",System.String) = '" & val.ToString & "'")
                        If _dr.Length > 0 Then
                            item.Text = _dr(0)(colVis).ToString
                            Me.ExtentProperties.Add(_dr(0)(colKey).ToString, item.Name & "-SelectVal")
                        Else
                            item.Text = ""
                            Me.ExtentProperties.Remove(item.Name & "-SelectVal")
                        End If
                    End If
                ElseIf Me.ExtentProperties.Item(ExtenPropertiesComment.NhapNgayThang(item)) IsNot Nothing Then
                    If IsDate(val.ToString) Then
                        item.Text = CDate(val.ToString).ToString("dd/MM/yyyy")
                    Else
                        item.Text = val.ToString
                    End If
                ElseIf Me.ExtentProperties.Item(ExtenPropertiesComment.NhapNgayGio(item)) IsNot Nothing Then
                    If IsDate(val.ToString) Then
                        item.Text = CDate(val.ToString).ToString("dd/MM/yyyy HH:mm")
                    Else
                        item.Text = val.ToString
                    End If
                ElseIf Me.ExtentProperties.Item(ExtenPropertiesComment.NhapSoNguyen(item)) IsNot Nothing Then
                    If IsNumeric(val.ToString) Then
                        item.Text = CInt(val.ToString)
                    Else
                        item.Text = val.ToString
                    End If
                Else
                    item.Text = val.ToString
                End If
            Case "ComboBox"
                CType(item, ComboBox).SelectedValue = val
            Case "CheckBox", "RadioButton"
                CType(item, Object).Checked = val
        End Select
    End Sub
#End Region
End Class
