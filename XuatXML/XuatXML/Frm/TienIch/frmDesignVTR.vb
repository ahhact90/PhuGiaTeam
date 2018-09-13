Imports MyData
Imports System.CodeDom.Compiler
Imports System.Reflection
Public Class frmDesignVTR
#Region "PrivateVal"
    Private curentControl As New Collection
    Private msClick As Boolean = False
    Private msPoint As Point
    Private WithEvents lblLeft As New Label
    Private WithEvents lblRight As New Label
    Private WithEvents lblTop As New Label
    Private WithEvents lblBottom As New Label
    Private sangtrai As Boolean = False
    Private sangphai As Boolean = False
    Private lentren As Boolean = False
    Private xuongduoi As Boolean = False
    Private SelectColor As Color = Color.FromArgb(200, 200, 200)
    Private ViewLBL As Boolean = False
    Private WithEvents PropCol As New ExtentPropCollection
    Private ctrBocDuocCtr As String = "/Panel/GroupBox/TabPage/" & Me.GetType.Name & "/"
    Private ControlColorList As New Dictionary(Of String, Color)
    Public controlProperties(-1) As PropertiesObject
    Private DSPropSave() As String = New String() {"Anchor", "AutoSize", "BackColor", "Dock", "Enabled", "Font", "ForeColor", "MaximumSize", "MinimumSize", "Name", "TabIndex", "Text", "UseWaitCursor", "Visible", "Padding"}
    Private _dtControlList As New DataTable
    Private DSControlContaner As String = "/Panel/GroupBox/Form/TabPage/"
    Private isDesign_ As Boolean = False
    Private noCloseCtrMenu As Boolean = False
    Private code As String = ""
    Private vbProv = New VBCodeProvider()
    Private vbParams = New CompilerParameters()
    Private compResults As CompilerResults
    Private objCompiler As Object

#End Region
#Region "PublicVal"
    ''' <summary>
    ''' Tất cả control có trên form
    ''' </summary>
    ''' <remarks></remarks>
    Public AllControlInForm(-1) As Control
    ''' <summary>
    ''' Tự động cập nhật lại bảng thiếu khi load form
    ''' </summary>
    ''' <remarks></remarks>
    Public CNDuLieuThieu As Boolean = False
    ''' <summary>
    ''' Giữ đè phím contorl (không cần giữ phím contorl)
    ''' </summary>
    ''' <remarks></remarks>
    Public deControl As Boolean = False
    ''' <summary>
    ''' Không dùng chuột di chuyển + resize
    ''' </summary>
    ''' <remarks></remarks>
    Public noMouse As Boolean = False
    ''' <summary>
    ''' Độ rộng viền để resize control
    ''' </summary>
    ''' <remarks></remarks>
    Public rvien As Integer = 4
    ''' <summary>
    ''' Độ dời khi bấm di chuyển
    ''' </summary>
    ''' <remarks></remarks>
    Public doDoi As Integer = 1
    ''' <summary>
    ''' Connect string to database
    ''' </summary>
    ''' <remarks></remarks>
    Public ConectS As String = "Data Source =.;Initial Catalog =BAST2016;User ID = sa;Password=1"
    ''' <summary>
    ''' Danh sách các control brigtofront
    ''' </summary>
    ''' <remarks></remarks>
    Public ControlBrigToF() As Control
    ''' <summary>
    ''' Danh sách control trên form
    ''' </summary>
    ''' <remarks></remarks>
    Public ControlList() As Control
    ''' <summary>
    ''' Event khi add ExtentProperties
    ''' </summary>
    ''' <param name="o">Đối tượng đã được Add</param>
    ''' <remarks></remarks>
    Public Event ExtentAdd(ByVal o As Object)
    ''' <summary>
    ''' Event khi remove ExtentProperties
    ''' </summary>
    ''' <param name="o">Đối tượng đang được gỡ</param>
    ''' <param name="RollBack">True: Hủy Remove,False: Remove</param>
    ''' <remarks></remarks>
    Public Event ExtentRemove(ByVal o As Object, ByRef RollBack As Boolean)
    Public Event DesignChange(ByVal e As Boolean)
    Public dtDSAutoResizeColMode As DataTable
    Public dtDSColumnType As DataTable
    Public NotDesignMode As Boolean = False
#End Region
#Region "MultipeControlEvent"
    Private Sub _MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        If noMouse Then Return
        If Me.ExtentProperties.Item(ExtenPropertiesComment.NoMove(sender)) IsNot Nothing Then Return
        If sender Is Me Then Return
        If isDesign_ AndAlso e.Button = System.Windows.Forms.MouseButtons.Left Then
            If Not (Control.ModifierKeys = Keys.Control OrElse deControl) Then
                For i = 1 To curentControl.Count
                    If ControlColorList.ContainsKey(curentControl.Item(i).Name) Then
                        curentControl.Item(i).BackColor = ControlColorList(curentControl.Item(i).Name)
                    End If
                Next
                curentControl = New Collection()
            End If
            AddToArray(curentControl, sender)
            msClick = True
            msPoint = New Point(e.X, e.Y)
            sender.BackColor = SelectColor
            dinhvilbl(sender)
            showlbl(True)

            If TypeOf ctrRightMenu.SourceControl Is DataGridView Then
                Dim c = CType(ctrRightMenu.SourceControl, DataGridView)
                cbxDSColumn.Tag = c
                Dim _dtCol As New DataTable
                _dtCol.Columns.Add("Name")
                _dtCol.Columns.Add("HeaderText")
                For Each item As DataGridViewColumn In c.Columns
                    _dtCol.Rows.Add(item.Name, item.HeaderText)
                Next
                cbxDSColumn.DataSource = _dtCol
                cbxDSColumn.Enabled = True
                If cbxDSColumn.Items.Count > 0 Then
                    cbxDSColumn.SelectedIndex = 0
                End If
            Else
                cbxDSColumn.Enabled = False
                mnuEditColumn.Visible = (TypeOf sender Is DataGridView)
                prpGrid1.SelectedObject = getPropByControl(sender)
            End If
        End If
    End Sub
    Private Sub _MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        If noMouse Then Return
        If isDesign_ AndAlso msClick AndAlso e.Button = System.Windows.Forms.MouseButtons.Left Then
            msClick = False
            showlbl(False)
            If ViewLBL Then showlbl(ViewLBL)
            Dim _ds(-1) As Control
            Dim ppp As Point = FindLocation(sender)
            FindControlB(_ds, Me, New Point(e.X + ppp.X, e.Y + ppp.Y))
            If _ds.Length > 0 Then
                ctrControlB.Items.Clear()
                For Each qqq As Control In _ds
                    If qqq.Name <> sender.Parent.Name AndAlso qqq.Name <> sender.Name Then
                        Dim lacha As Boolean = False
                        If sender.Parent Is Nothing OrElse sender.Parent.Parent Is Nothing Then
                            lacha = False
                        Else
                            Dim c = sender.Parent.Parent
                            While c IsNot Nothing
                                If c.Name = qqq.Name Then
                                    lacha = True
                                    Exit While
                                Else
                                    c = c.Parent
                                End If
                            End While
                        End If
                        If lacha Then
                            If sender.Left < 0 OrElse sender.Top < 0 OrElse sender.Left + sender.Width > sender.Parent.Width OrElse sender.Top + sender.Height > sender.Parent.Height Then
                                ctrControlB.Items.Add(qqq.Name)
                                AddHandler ctrControlB.Items(ctrControlB.Items.Count - 1).Click, AddressOf Mn_Click
                                ctrControlB.Items(ctrControlB.Items.Count - 1).Tag = qqq
                            End If
                        Else
                            ctrControlB.Items.Add(qqq.Name)
                            AddHandler ctrControlB.Items(ctrControlB.Items.Count - 1).Click, AddressOf Mn_Click
                            ctrControlB.Items(ctrControlB.Items.Count - 1).Tag = qqq
                        End If
                    End If
                Next
                ctrControlB.Tag = sender
                ctrControlB.Show()
                ctrControlB.Top = Me.PointToScreen(ppp).Y + sender.Height
                ctrControlB.Left = Me.PointToScreen(ppp).X
            End If
        End If
    End Sub
    Private Sub _MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        If noMouse Then Return
        If Me.ExtentProperties.Item(ExtenPropertiesComment.NoMove(sender)) IsNot Nothing Then Return
        If msClick AndAlso isDesign_ Then
            If sender.Cursor = Cursors.SizeAll Then
                For i = 1 To curentControl.Count + 1 - 1
                    curentControl.Item(i).Left += e.X - msPoint.X
                    curentControl.Item(i).Top += e.Y - msPoint.Y
                Next
                dinhvilbl(sender)
            Else
                Dim MsCrPoit As Point = e.Location
                If sangphai Then
                    For i = 1 To curentControl.Count + 1 - 1
                        curentControl.Item(i).Width += MsCrPoit.X - msPoint.X
                    Next
                End If
                If sangtrai Then
                    For i = 1 To curentControl.Count + 1 - 1
                        curentControl.Item(i).Left += MsCrPoit.X - msPoint.X
                        curentControl.Item(i).Width -= MsCrPoit.X - msPoint.X
                    Next
                End If
                If xuongduoi Then
                    For i = 1 To curentControl.Count + 1 - 1
                        curentControl.Item(i).Height += MsCrPoit.Y - msPoint.Y
                    Next
                End If
                If lentren Then
                    For i = 1 To curentControl.Count + 1 - 1
                        curentControl.Item(i).Top += MsCrPoit.Y - msPoint.Y
                        curentControl.Item(i).Height -= MsCrPoit.Y - msPoint.Y
                    Next
                End If
                If sangphai OrElse xuongduoi Then msPoint = MsCrPoit
                dinhvilbl(sender)
            End If
        ElseIf isDesign_ Then
            sangtrai = (e.X < rvien)
            lentren = (e.Y < rvien)
            sangphai = (e.X > sender.Width - rvien)
            xuongduoi = (e.Y > sender.Height - rvien)
            If sangtrai OrElse sangphai Then
                If lentren Then
                    sender.Cursor = If(sangtrai, Cursors.SizeNWSE, Cursors.SizeNESW)
                ElseIf xuongduoi Then
                    sender.Cursor = If(sangtrai, Cursors.SizeNESW, Cursors.SizeNWSE)
                Else
                    sender.Cursor = Cursors.SizeWE
                End If
            ElseIf lentren OrElse xuongduoi Then
                sender.Cursor = Cursors.SizeNS
            Else
                sender.Cursor = Cursors.SizeAll
            End If
        End If
    End Sub
    Private Sub _MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub _MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        If isDesign_ AndAlso Me.ExtentProperties.Item(ExtenPropertiesComment.NoMove(sender)) Is Nothing Then
            showlbl(Not ViewLBL)
            ViewLBL = Not ViewLBL
        End If

    End Sub
#End Region
#Region "ExtenProp"
    Private Sub PropCol_AddItem(ByVal e As ExtentObject) Handles PropCol.AddItem
        RaiseEvent ExtentAdd(e)
    End Sub
    Private Sub PropCol_RemoveItem(ByVal e As ExtentObject, ByRef RollBack As Boolean) Handles PropCol.RemoveItem
        RaiseEvent ExtentRemove(e, RollBack)
    End Sub
#End Region
#Region "FormControlEvent"
#Region "Form"
    Protected Overrides Function ProcessCmdKey(ByRef msg As System.Windows.Forms.Message, ByVal keyData As System.Windows.Forms.Keys) As Boolean

        If Not NotDesignMode Then
            Dim dich As Integer = doDoi
            If keyData = Keys.Control Then
                dich = doDoi * 3
            End If
            If keyData = Keys.Control + Keys.C Then

            End If
            Select Case keyData
                Case Keys.Control + Keys.Delete
                    If isDesign Then
                        If MsgBox("Bạn chắc chắn xóa hết thiết lập form?", MsgBoxStyle.YesNo Or MsgBoxStyle.Question) = MsgBoxResult.Yes Then
                            dbXML.RunSQL("delete vitrictrbase where tenform = N'" & Me.Name & "'")
                            dbXML.RunSQL("delete Stylecontrol where formName = N'" & Me.Name & "'")
                        End If
                    End If
                Case Keys.Control + Keys.N
                    If isDesign_ Then
                        Dim TypeName As String = InputBox("Chọn kiểu control cần thêm:", "New control", "TextBox", , , FMstyle.obj, True, _dtControlList, "TypeName", "TypeName")
                        Dim ControlName As String = InputBox("Nhập vào tên control cần thêm", "New control", TypeName & Me.AllControlInForm.Length)
                        AddNewControl(TypeName, ControlName)
                        Return True
                    End If
                Case Keys.Shift + Keys.Right, Keys.Shift + Keys.Right + Keys.Control
                    For i = 1 To curentControl.Count + 1 - 1
                        If Me.ExtentProperties.Item(ExtenPropertiesComment.NoMove(curentControl.Item(i))) IsNot Nothing Then Continue For
                        curentControl.Item(i).Width += dich
                        lblRight.Left += dich
                    Next
                    If isDesign_ Then Return True
                Case Keys.Shift + Keys.Left, Keys.Control + Keys.Shift + Keys.Left
                    For i = 1 To curentControl.Count + 1 - 1
                        If Me.ExtentProperties.Item(ExtenPropertiesComment.NoMove(curentControl.Item(i))) IsNot Nothing Then Continue For
                        curentControl.Item(i).Width -= dich
                        lblRight.Left -= dich
                    Next
                Case Keys.Shift + Keys.Up, Keys.Control + Keys.Shift + Keys.Up
                    For i = 1 To curentControl.Count + 1 - 1
                        If Me.ExtentProperties.Item(ExtenPropertiesComment.NoMove(curentControl.Item(i))) IsNot Nothing Then Continue For
                        curentControl.Item(i).Height -= dich
                        lblBottom.Top -= dich
                    Next
                    If isDesign_ Then Return True
                Case Keys.Shift + Keys.Down, Keys.Control + Keys.Shift + Keys.Down
                    For i = 1 To curentControl.Count + 1 - 1
                        If Me.ExtentProperties.Item(ExtenPropertiesComment.NoMove(curentControl.Item(i))) IsNot Nothing Then Continue For
                        curentControl.Item(i).Height += dich
                        lblBottom.Top += dich
                    Next
                    If isDesign_ Then Return True
                Case Keys.Left, Keys.Control + Keys.Left
                    For i = 1 To curentControl.Count + 1 - 1
                        If Me.ExtentProperties.Item(ExtenPropertiesComment.NoMove(curentControl.Item(i))) IsNot Nothing Then Continue For
                        curentControl.Item(i).Left -= dich
                        lblRight.Left -= dich
                        lblLeft.Left -= dich
                    Next
                    If isDesign_ Then Return True
                Case Keys.Right, Keys.Control + Keys.Right
                    For i = 1 To curentControl.Count + 1 - 1
                        If Me.ExtentProperties.Item(ExtenPropertiesComment.NoMove(curentControl.Item(i))) IsNot Nothing Then Continue For
                        curentControl.Item(i).Left += dich
                        lblRight.Left += dich
                        lblLeft.Left += dich
                    Next
                    If isDesign_ Then Return True
                Case Keys.Up, Keys.Control + Keys.Up
                    For i = 1 To curentControl.Count + 1 - 1
                        If Me.ExtentProperties.Item(ExtenPropertiesComment.NoMove(curentControl.Item(i))) IsNot Nothing Then Continue For
                        curentControl.Item(i).Top -= dich
                        lblTop.Top -= dich
                        lblBottom.Top -= dich
                    Next
                    If isDesign_ Then Return True
                Case Keys.Down, Keys.Control + Keys.Down
                    For i = 1 To curentControl.Count + 1 - 1
                        If Me.ExtentProperties.Item(ExtenPropertiesComment.NoMove(curentControl.Item(i))) IsNot Nothing Then Continue For
                        curentControl.Item(i).Top += dich
                        lblTop.Top += dich
                        lblBottom.Top += dich
                    Next
                    If isDesign_ Then Return True
                Case Keys.Control + Keys.S
                    SaveVTR()
                    If isDesign_ Then Return True
                Case Keys.Delete
                    For i = 1 To curentControl.Count + 1 - 1
                        If Me.ExtentProperties.Item(ExtenPropertiesComment.NoMove(curentControl.Item(i))) IsNot Nothing Then Continue For
                        Dim _dt As DataTable = dbXML.GetTable("select * from vitriCTRBase where tenForm = '" & Me.Name & "' and tenControl = '" & curentControl(i).Name & "'")
                        Dim _dtStyle As DataTable = dbXML.GetTable("select * from stylecontrol where formName = '" & Me.Name & "' and controlName = '" & curentControl(i).Name & "'")
                        If _dt.Rows.Count > 0 Then
                            _dt.Rows(0).Delete()
                            If dbXML.UpdateData(_dt, "select * from vitriCTRBase") Then
                                If _dtStyle.Rows.Count > 0 Then
                                    For j = 0 To _dtStyle.Rows.Count - 1
                                        _dtStyle.Rows(j).Delete()
                                    Next
                                    dbXML.UpdateData(_dtStyle, "select * from stylecontrol")
                                End If
                            End If
                        End If
                        If curentControl(i).Parent IsNot Nothing Then curentControl(i).Parent.Controls.Remove(curentControl(i))
                    Next
                    If isDesign_ AndAlso curentControl.Count > 0 Then Return True
                Case Keys.Escape
                    If ctrRightMenu.Visible Then
                        ctrRightMenu.Visible = False
                        noCloseCtrMenu = False
                        Return True
                    End If
            End Select
        End If
        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function
    Private Sub _Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown

        If Not NotDesignMode AndAlso Not DesignMode Then
            Me.ExtentProperties.Add(1, ExtenPropertiesComment.NoMove(lblTop))
            Me.ExtentProperties.Add(1, ExtenPropertiesComment.NoMove(lblBottom))
            Me.ExtentProperties.Add(1, ExtenPropertiesComment.NoMove(lblLeft))
            Me.ExtentProperties.Add(1, ExtenPropertiesComment.NoMove(lblRight))
            Me.ExtentProperties.Add(1, ExtenPropertiesComment.NoMove(lblInviPropGrid))
            Me.ExtentProperties.Add(1, ExtenPropertiesComment.NoMove(prpGrid1))
            GetAllCTR(Me)
            Dim _dtctr As DataTable = dbXML.GetTable("select * from ViTriCTRBase where TenForm = N'" & Me.Name & "'")
            Dim _dtStyle As DataTable = dbXML.GetTable("select * from Stylecontrol where formName = N'" & Me.Name & "'")
            RenderVTR(Me, _dtctr, _dtStyle)
            _dtctr.DefaultView.RowFilter = "mBrigIndex > =0"
            _dtctr.DefaultView.Sort = "mBrigIndex"
            RenderBring(Me, _dtctr.DefaultView.ToTable)
            If ControlBrigToF IsNot Nothing Then
                For i = 0 To ControlBrigToF.Length - 1
                    ControlBrigToF(i).BringToFront()
                Next
            End If
            Add_HandLer(Me)
            lblLeft.Height = Me.Height
            lblRight.Height = Me.Height
            lblTop.Width = Me.Width
            lblBottom.Width = Me.Width
            RenStringCode()
        End If
    End Sub
    Private Sub _Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Font = New Font("Arial", 10)
        If Not NotDesignMode AndAlso Not DesignMode Then

            ReDim ControlBrigToF(-1)
            lblLeft.AutoSize = False
            lblLeft.Width = 1
            lblLeft.Top = 0
            lblLeft.Name = "lblvitritrai-nomo"

            lblRight.AutoSize = False
            lblRight.Width = 1
            lblRight.Top = 0
            lblLeft.Name = "lblvitriphai-nomo"

            lblTop.AutoSize = False
            lblTop.Height = 1
            lblTop.Left = 0
            lblLeft.Name = "lblvitritren-nomo"

            lblBottom.AutoSize = False
            lblBottom.Height = 1
            lblBottom.Left = 0
            lblLeft.Name = "lblvitriduoi-nomo"

            Me.Controls.AddRange(New Control() {lblLeft, lblRight, lblTop, lblBottom})

            showlbl(False)


            If CNDuLieuThieu Then CNDLThieu()

            _dtControlList.Columns.Add("TypeName")
            _dtControlList.Rows.Add("CheckBox")
            _dtControlList.Rows.Add("TextBox")
            _dtControlList.Rows.Add("DateTimePicker")
            _dtControlList.Rows.Add("Panel")
            _dtControlList.Rows.Add("GroupBox")
            _dtControlList.Rows.Add("Label")
            _dtControlList.Rows.Add("MonthCalendar")
            _dtControlList.Rows.Add("NumericUpDown")
            _dtControlList.Rows.Add("RadioButton")
            _dtControlList.Rows.Add("RichTextBox")
            _dtControlList.Rows.Add("SplitContainer")
            _dtControlList.Rows.Add("TabControl")
            _dtControlList.Rows.Add("DataGridView")

            AddHandler Me.MouseDown, AddressOf _PRMouseDown
            AddHandler Me.MouseUp, AddressOf _PRMouseUp
            AddHandler Me.MouseMove, AddressOf _PRMouseMove

        End If
    End Sub
    Private Sub _PRMouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        If isDesign_ Then
            msPoint = e.Location
            msClick = True
        End If
        noMouse = True
    End Sub
    Private Sub _PRMouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        If isDesign_ AndAlso msClick Then
            Me.CreateGraphics().Clear(Me.BackColor)
            msClick = False
            Dim minX As Integer = If(e.X > msPoint.X, msPoint.X, e.X)
            Dim minY As Integer = If(e.Y > msPoint.Y, msPoint.Y, e.Y)
            Dim width As Integer = Math.Abs(e.X - msPoint.X)
            Dim height As Integer = Math.Abs(e.Y - msPoint.Y)
            curentControl = New Collection
            For Each item As Control In Me.Controls
                If ControlColorList.ContainsKey(item.Name) Then
                    item.BackColor = ControlColorList(item.Name)
                End If
                If item.Left >= minX AndAlso item.Top >= minY AndAlso item.Left + item.Width <= minX + width AndAlso item.Top + item.Height <= minY + height Then
                    AddToArray(curentControl, item)
                    item.BackColor = SelectColor
                End If
            Next
        End If
        noMouse = False
    End Sub
    Private Sub _PRMouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        If isDesign_ AndAlso msClick Then
            Me.CreateGraphics().Clear(Me.BackColor)
            Dim p As New Pen(Brushes.Black)
            p.DashStyle = Drawing2D.DashStyle.DashDot
            Me.CreateGraphics().DrawRectangle(p, If(e.X > msPoint.X, msPoint.X, e.X), If(e.Y > msPoint.Y, msPoint.Y, e.Y), Math.Abs(e.X - msPoint.X), Math.Abs(e.Y - msPoint.Y))
        End If
    End Sub
#End Region
#Region "MenuItem"
    Private Sub brtof_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles brtof.Click
        If Not isDesign_ Then Return
        If ControlBrigToF Is Nothing Then
            ReDim ControlBrigToF(0)
        End If
        ReDim Preserve ControlBrigToF(ControlBrigToF.Length)
        ControlBrigToF(ControlBrigToF.Length - 1) = ctrRightMenu.SourceControl
        ctrRightMenu.SourceControl.BringToFront()
        For i = 1 To curentControl.Count
            If ControlColorList.ContainsKey(curentControl.Item(i).Name) Then
                curentControl.Item(i).BackColor = ControlColorList(curentControl.Item(i).Name)
            End If
        Next
        curentControl = New Collection
    End Sub
    Private Sub Mn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Not isDesign_ Then Return
        Dim ctr As Control = ctrControlB.Tag
        Dim cPar As Control = ctr.Parent
        Dim cTo As Control = sender.Tag
        Dim pcu = FindLocation(cPar)
        Dim pmo = FindLocation(cTo)
        ctr.Left -= pmo.X - pcu.X
        ctr.Top -= pmo.Y - pcu.Y
        cPar.Controls.Remove(ctr)
        cTo.Controls.Add(ctr)
    End Sub
    Private Sub SendToBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SendToBackToolStripMenuItem.Click
        If Not isDesign_ Then Return
        If ControlBrigToF IsNot Nothing Then
            Dim c = ctrRightMenu.SourceControl
            Dim ctrBR(-1) As Control
            For i = 0 To ControlBrigToF.Length - 1
                If Not ControlBrigToF(i) Is c Then
                    ReDim Preserve ctrBR(ctrBR.Length)
                    ctrBR(ctrBR.Length - 1) = ControlBrigToF(i)
                End If
            Next
            ControlBrigToF = ctrBR
        End If
        ctrRightMenu.SourceControl.SendToBack()
        For i = 1 To curentControl.Count
            If ControlColorList.ContainsKey(curentControl.Item(i).Name) Then
                curentControl.Item(i).BackColor = ControlColorList(curentControl.Item(i).Name)
            End If
        Next
        curentControl = New Collection
    End Sub
    Private Sub prpMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles prpMenuItem.Click
        If Not isDesign_ Then Return
        prpGrid1.Visible = True
        prpGrid1.Width = 260
        prpGrid1.BringToFront()

        lblInviPropGrid.Visible = True
        cbxDSColumn.Visible = True
        If TypeOf ctrRightMenu.SourceControl Is DataGridView Then
            Dim c = CType(ctrRightMenu.SourceControl, DataGridView)
            cbxDSColumn.Tag = c
            Dim _dtCol As New DataTable
            _dtCol.Columns.Add("Name")
            _dtCol.Columns.Add("HeaderText")
            For Each item As DataGridViewColumn In c.Columns
                _dtCol.Rows.Add(item.Name, item.HeaderText)
            Next
            cbxDSColumn.DataSource = _dtCol
            cbxDSColumn.Enabled = True
            If cbxDSColumn.Items.Count > 0 Then
                cbxDSColumn.SelectedIndex = 0
            End If
        Else
            cbxDSColumn.Enabled = False
            Dim pp = getPropByControl(ctrRightMenu.SourceControl)
            If pp Is Nothing Then controlToProp(ctrRightMenu.SourceControl) : pp = controlProperties(controlProperties.Length - 1)
            prpGrid1.SelectedObject = getPropByControl(ctrRightMenu.SourceControl)
        End If

    End Sub
    Private Sub BangLeft_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BangLeft.Click
        If curentControl.Count < 2 Then Return
        If Control.ModifierKeys = Keys.Control Then
            For i = 2 To curentControl.Count
                curentControl(i).Width = curentControl(i).Width + curentControl(i).Left - curentControl(1).Left
                curentControl(i).Left = curentControl(1).Left
            Next
        Else
            For i = 2 To curentControl.Count
                curentControl(i).Left = curentControl(1).Left
            Next
        End If
        noCloseCtrMenu = True
    End Sub
    Private Sub BangRight_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BangRight.Click
        If curentControl.Count < 2 Then Return

        If Control.ModifierKeys = Keys.Control Then
            For i = 2 To curentControl.Count
                curentControl(i).Width = curentControl(1).Width + curentControl(1).Left - curentControl(i).Left
            Next
        Else
            For i = 2 To curentControl.Count
                curentControl(i).Left = curentControl(1).Left + curentControl(1).Width - curentControl(i).Width
            Next
        End If
        noCloseCtrMenu = True
    End Sub
    Private Sub BangLR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BangLR.Click
        If curentControl.Count < 2 Then Return
        If Control.ModifierKeys = Keys.Control Then
            For i = 2 To curentControl.Count
                curentControl(i).Width = curentControl(1).Width
            Next
        Else
            For i = 2 To curentControl.Count
                curentControl(i).Left = curentControl(1).Left
                curentControl(i).Width = curentControl(1).Width
            Next
        End If
        noCloseCtrMenu = True
    End Sub
    Private Sub removeLR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles removeLR.Click
        If curentControl.Count <= 1 Then Return
        If Control.ModifierKeys = Keys.Control Then
            Dim _l As List(Of Object) = (From c In curentControl Order By c.Left Select c).ToList
            Dim kcach As Integer = _l(1).Left - _l(0).Left - _l(0).Width + 1
            For i = 1 To _l.Count - 1
                _l(i).Left = _l(i - 1).Left + _l(i - 1).Width + kcach
            Next
        ElseIf Control.ModifierKeys = Keys.Alt Then
            Dim _l As List(Of Object) = (From c In curentControl Order By c.Left Select c).ToList
            Dim kcach As Integer = _l(1).Left - _l(0).Left - _l(0).Width - 1
            If kcach < 0 Then kcach = 0
            For i = 1 To _l.Count - 1
                _l(i).Left = _l(i - 1).Left + _l(i - 1).Width + kcach
            Next
        Else
            Dim _l As List(Of Object) = (From c In curentControl Order By c.Left Select c).ToList
            For i = 1 To _l.Count - 1
                _l(i).Left = _l(i - 1).Left + _l(i - 1).Width
            Next
        End If
        noCloseCtrMenu = True
    End Sub
    Private Sub BangCenter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BangCenter.Click
        If curentControl.Count < 2 Then Return
        For i = 2 To curentControl.Count
            curentControl(i).Left = curentControl(1).Left + curentControl(1).Width / 2 - curentControl(i).Width / 2
        Next
        noCloseCtrMenu = True
    End Sub
    Private Sub BangT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BangT.Click
        If curentControl.Count < 2 Then Return
        If Control.ModifierKeys = Keys.Control Then
            For i = 2 To curentControl.Count
                curentControl(i).Height = curentControl(i).Height - curentControl(1).Top + curentControl(i).Top
                curentControl(i).Top = curentControl(1).Top
            Next
        Else
            For i = 2 To curentControl.Count
                curentControl(i).Top = curentControl(1).Top
            Next
        End If
        noCloseCtrMenu = True
    End Sub
    Private Sub BangB_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BangB.Click
        If curentControl.Count < 2 Then Return
        If Control.ModifierKeys = Keys.Control Then
            For i = 2 To curentControl.Count
                curentControl(i).Height = curentControl(i).Height + curentControl(1).Top - curentControl(i).Top
                curentControl(i).Top = curentControl(1).Top + curentControl(1).Height - curentControl(i).Height
            Next
        Else
            For i = 2 To curentControl.Count
                curentControl(i).Top = curentControl(1).Top + curentControl(1).Height - curentControl(i).Height
            Next
        End If
        noCloseCtrMenu = True
    End Sub
    Private Sub BangVCenter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BangVCenter.Click
        If curentControl.Count < 2 Then Return
        For i = 2 To curentControl.Count
            curentControl(i).Top = curentControl(1).Top + curentControl(1).Height / 2 - curentControl(i).Height / 2
        Next
        noCloseCtrMenu = True
    End Sub
    Private Sub BangBT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BangBT.Click
        If curentControl.Count < 2 Then Return
        If Control.ModifierKeys = Keys.Control Then
            For i = 2 To curentControl.Count
                curentControl(i).Height = curentControl(1).Height
            Next
        Else
            For i = 2 To curentControl.Count
                curentControl(i).Top = curentControl(1).Top
                curentControl(i).Height = curentControl(1).Height
            Next
        End If
        noCloseCtrMenu = True
    End Sub
    Private Sub RemoveBT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RemoveBT.Click
        If curentControl.Count <= 1 Then Return
        If Control.ModifierKeys = Keys.Control Then
            Dim _l As List(Of Object) = (From c In curentControl Order By c.Top Select c).ToList
            Dim kcach As Integer = _l(1).Top - _l(0).Top - _l(0).Height + 1
            For i = 1 To _l.Count - 1
                _l(i).Top = _l(i - 1).Top + _l(i - 1).Height + kcach
            Next
        ElseIf Control.ModifierKeys = Keys.Alt Then
            Dim _l As List(Of Object) = (From c In curentControl Order By c.Top Select c).ToList
            Dim kcach As Integer = _l(1).Top - _l(0).Top - _l(0).Height - 1
            If kcach < 0 Then kcach = 0
            For i = 1 To _l.Count - 1
                _l(i).Top = _l(i - 1).Top + _l(i - 1).Height + kcach
            Next
        Else
            Dim _l As List(Of Object) = (From c In curentControl Order By c.Top Select c).ToList
            For i = 1 To _l.Count - 1
                _l(i).Top = _l(i - 1).Top + _l(i - 1).Height
            Next
        End If
        noCloseCtrMenu = True
    End Sub
    Private Sub MenuItem_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles BangLeft.MouseDown, BangB.MouseDown, BangRight.MouseDown, BangT.MouseDown, BangLR.MouseDown, BangBT.MouseDown, BangVCenter.MouseDown, BangCenter.MouseDown, RemoveBT.MouseDown, removeLR.MouseDown
        noCloseCtrMenu = True
    End Sub
    Private Sub mnuEditColumn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuEditColumn.Click
        Dim fff As New frmEditCol
        fff.ControlName = ctrRightMenu.SourceControl.Name
        If ctrRightMenu.SourceControl.Parent IsNot Nothing Then fff.ControlChaName = ctrRightMenu.SourceControl.Parent.Name
        fff.FormName = Me.Name
        fff.LoadData()
        fff.ShowDialog()
    End Sub
#End Region
#Region "Label"
    Private Sub lblInviPropGrid_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblInviPropGrid.Click
        prpGrid1.Visible = False
        prpGrid1.Width = 0
    End Sub
#End Region
#Region "Combobox"
    Private Sub cbxDSColumn_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbxDSColumn.SelectedIndexChanged
        Try
            Dim dataGrid As DataGridView = cbxDSColumn.Tag
            Dim col As Object = dataGrid.Columns(cbxDSColumn.SelectedValue)
            prpGrid1.SelectedObject = getPropByControl(col)
        Catch
        End Try
    End Sub
#End Region
#Region "Properties Grid"
    Private Sub prpGrid1_PropertyValueChanged(ByVal s As System.Object, ByVal e As System.Windows.Forms.PropertyValueChangedEventArgs) Handles prpGrid1.PropertyValueChanged

        CType(prpGrid1.SelectedObject, PropertiesObject).RenControl()
    End Sub
    Private Sub prpGrid1_VisibleChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles prpGrid1.VisibleChanged
        If prpGrid1.Visible Then
            lblInviPropGrid.Parent = prpGrid1
            lblInviPropGrid.Top = 7
            lblInviPropGrid.Left = 230
            lblInviPropGrid.Visible = prpGrid1.Visible
            lblInviPropGrid.BringToFront()

            cbxDSColumn.DisplayMember = "HeaderText"
            cbxDSColumn.ValueMember = "Name"
            cbxDSColumn.Parent = prpGrid1
            cbxDSColumn.Top = 2
            cbxDSColumn.Left = 80
            cbxDSColumn.Visible = prpGrid1.Visible
            cbxDSColumn.BringToFront()
        End If
    End Sub
#End Region
#Region "ContexMenu"
    Private Sub ctrRightMenu_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ctrRightMenu.Opening
        e.Cancel = Not isDesign_
    End Sub
    Private Sub ctrRightMenu_Closing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripDropDownClosingEventArgs) Handles ctrRightMenu.Closing
        e.Cancel = noCloseCtrMenu
    End Sub
    Private Sub ctrRightMenu_Closed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripDropDownClosedEventArgs) Handles ctrRightMenu.Closed
        noCloseCtrMenu = False
    End Sub
    Private Sub mnuClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuClose.Click
        ctrRightMenu.Visible = False
        noCloseCtrMenu = False
    End Sub
#End Region
#End Region
#Region "Other Func"
    Private Sub AddColToGrid(ByVal c As Control)
        If Not DesignMode Then

            Dim _sql As String = String.Format("select * from columnGrid where FormName = N'{0}' and ControlName = N'{1}' and ControlChaName =N'{2}' order by STT", Me.Name, c.Name, c.Parent.Name)
            Dim _dt As DataTable = dbXML.GetTable(_sql)
            CType(c, DataGridView).Columns.Clear()
            If dtDSAutoResizeColMode Is Nothing Then
                dtDSAutoResizeColMode = New DataTable
                dtDSAutoResizeColMode.Columns.Add("Name")
                dtDSAutoResizeColMode.Columns.Add("ID")
                For Each item In [Enum].GetValues(GetType(DataGridViewAutoSizeColumnMode))
                    If item IsNot Nothing Then dtDSAutoResizeColMode.Rows.Add(item.ToString, CInt(item))
                Next
            End If
            If dtDSColumnType Is Nothing Then
                dtDSColumnType = New DataTable
                dtDSColumnType.Columns.Add("Name")
                dtDSColumnType.Columns.Add("ID")
                dtDSColumnType.Rows.Add("DataGridViewCheckBoxColumn", 0)
                dtDSColumnType.Rows.Add("DataGridViewTextBoxColumn", 1)
            End If

            For Each item In _dt.Rows
                Dim _dr() As DataRow = dtDSColumnType.Select("ID = " & item!ColumnType.ToString)
                Dim ctrType = GetType(Control).Assembly.[GetType]("System.Windows.Forms." & _dr(0)!Name, True)
                Dim col As Object = Activator.CreateInstance(ctrType)
                col.Name = item!ColumnName.ToString
                col.HeaderText = item!HeaderText.ToString
                col.Width = item!Width
                col.AutoSizeMode = item!AutoSizeMode
                col.ReadOnly = item!ReadOnly
                col.Frozen = item!Frozen
                col.DataPropertyName = item!DataFieldsName
                CType(c, DataGridView).Columns.Add(col)
            Next
            For Each colit As DataGridViewColumn In CType(c, DataGridView).Columns
                controlToProp(colit)
            Next
        End If
    End Sub
    Private Sub showlbl(ByVal e As Boolean)
        lblTop.BackColor = Color.Red
        lblBottom.BackColor = Color.Red
        lblLeft.BackColor = Color.Red
        lblRight.BackColor = Color.Red

        lblTop.Visible = (e AndAlso isDesign_)
        lblBottom.Visible = (e AndAlso isDesign_)
        lblLeft.Visible = (e AndAlso isDesign_)
        lblRight.Visible = (e AndAlso isDesign_)
        If e Then
            lblTop.BringToFront()
            lblBottom.BringToFront()
            lblLeft.BringToFront()
            lblRight.BringToFront()
        End If
    End Sub
    Private Sub dinhvilbl(ByVal c As Control)
        Dim p As Point = FindLocation(c)
        lblTop.Top = -1 + p.Y
        lblBottom.Top = c.Height + p.Y
        lblLeft.Left = -1 + p.X
        lblRight.Left = c.Width + p.X
    End Sub
    Private Sub Add_HandLer(ByVal c As Object)
        RemoveHandler CType(c, Control).MouseDown, AddressOf _MouseDown
        RemoveHandler CType(c, Control).MouseUp, AddressOf _MouseUp
        RemoveHandler CType(c, Control).MouseMove, AddressOf _MouseMove
        RemoveHandler CType(c, Control).MouseDoubleClick, AddressOf _MouseDoubleClick

        AddHandler CType(c, Control).MouseDown, AddressOf _MouseDown
        AddHandler CType(c, Control).MouseUp, AddressOf _MouseUp
        AddHandler CType(c, Control).MouseMove, AddressOf _MouseMove
        AddHandler CType(c, Control).MouseDoubleClick, AddressOf _MouseDoubleClick

        CType(c, Control).ContextMenuStrip = ctrRightMenu
        If ControlList Is Nothing Then
            ReDim ControlList(0)
        Else
            ReDim Preserve ControlList(ControlList.Length)
        End If
        ControlList(ControlList.Length - 1) = CType(c, Control)
        If Not ControlColorList.ContainsKey(CType(c, Control).Name) Then
            ControlColorList.Add(CType(c, Control).Name, CType(c, Control).BackColor)
        End If

        If TypeOf c Is TabControl Then
            For Each item2 As TabPage In CType(c, TabControl).TabPages
                Add_HandLer(item2)
            Next
        Else
            For Each item2 As Control In c.Controls
                Add_HandLer(item2)
            Next
        End If
    End Sub
    Private Sub AddToArray(ByRef _ar As Collection, ByVal c As Control)
        If _ar.Contains(c.Name) Then
            _ar.Remove(c.Name)
        End If
        _ar.Add(c, c.Name)
    End Sub
    Private Sub RemoveFromArray(ByRef _ar As Collection, ByVal c As Control)
        If _ar.Contains(c.Name) Then
            _ar.Remove(c.Name)
        End If
    End Sub
    Private Sub SaveVTR()
        Me.Cursor = Cursors.WaitCursor
        Dim _dt As DataTable = dbXML.GetTable("select * from ViTriCTRBase where tenform =N'" & Me.Name & "'")
        Dim _dtStyle As DataTable = dbXML.GetTable("select * from Stylecontrol where formName = N'" & Me.Name & "'")
        updateDTS(_dt, _dtStyle, Me)
        If dbXML.UpdateData(_dt, "select * from ViTriCTRBase ") Then
            dbXML.UpdateData(_dtStyle, "select * from stylecontrol")
        End If
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub updateDTS(ByRef dt As DataTable, ByRef dtStyle As DataTable, ByVal c As Object)
        If Me.ExtentProperties.Item(ExtenPropertiesComment.NoMove(c)) IsNot Nothing Then Return
        Dim pp As PropertiesObject = getPropByControl(c)
        If pp Is Nothing Then controlToProp(c) : pp = controlProperties(controlProperties.Length - 1)
        If c Is lblLeft OrElse c Is lblRight OrElse c Is lblBottom OrElse c Is lblBottom Then
            Return
        End If
        Dim _dr() As DataRow = dt.Select("tencontrol ='" & pp.Name & "'")
        Dim _drr As DataRow
        If _dr.Length = 0 Then
            _drr = dt.NewRow
            dt.Rows.Add(_drr)
        Else
            _drr = _dr(0)
        End If
        _drr!TenForm = Me.Name
        _drr!TenControl = pp.Name
        If c.Parent IsNot Nothing Then _drr!TenControlCha = c.Parent.Name()
        _drr!mTop = c.Top
        _drr!mLeft = c.Left
        _drr!mWidth = c.Width
        _drr!mHeight = c.Height
        _drr!mType = c.GetType
        Dim lastBrig As Integer = -1
        If ControlBrigToF IsNot Nothing Then
            While Array.IndexOf(ControlBrigToF, c, lastBrig + 1) >= 0
                lastBrig = Array.IndexOf(ControlBrigToF, c, lastBrig + 1)
            End While
        End If
        If lastBrig >= 0 Then
            _drr!mBrigIndex = lastBrig
        Else
            If String.IsNullOrEmpty(_drr!mBrigIndex.ToString) Then
                _drr!mBrigIndex = -1
            End If
        End If
        If Not String.IsNullOrEmpty(c.Name) Then
            ' If c.Name.ToString.ToLower = "txthoten" Then Stop

            For Each iStyle In pp.GetType.GetProperties
                If iStyle.Name.ToLower = "control" Then Continue For
                If pp.Name <> c.Name Then
                    dbXML.RunSQL("delete vitrictrbase where TenControl = N'" & c.Name & "'; delete stylecontrol where controlName = N'" & c.Name & "'")

                End If
                Dim _drStyle() As DataRow = dtStyle.Select("controlName = '" & pp.Name & "' and propName = '" & iStyle.Name & "'")
                Dim _drSNew As DataRow
                If _drStyle.Length = 0 Then
                    _drSNew = dtStyle.NewRow
                    _drSNew!formName = Me.Name
                    _drSNew!controlName = pp.Name
                    _drSNew!propName = iStyle.Name
                    dtStyle.Rows.Add(_drSNew)
                Else
                    _drSNew = _drStyle(0)
                End If
                _drSNew!value = StyleValue(CallByName(pp, iStyle.Name, CallType.Get), iStyle.Name)
            Next
            If TypeOf c Is DataGridView Then
                For Each cx In CType(c, DataGridView).Columns
                    pp = getPropByControl(cx)
                    For Each iStyle In pp.GetType.GetProperties
                        If iStyle.Name.ToLower = "control" Then Continue For
                        Dim _drStyle() As DataRow = dtStyle.Select("controlName = '" & cx.Name & "' and propName = '" & iStyle.Name & "'")
                        Dim _drSNew As DataRow
                        If _drStyle.Length = 0 Then
                            _drSNew = dtStyle.NewRow
                            _drSNew!formName = Me.Name
                            _drSNew!controlName = cx.Name
                            _drSNew!propName = iStyle.Name
                            dtStyle.Rows.Add(_drSNew)
                        Else
                            _drSNew = _drStyle(0)
                        End If
                        _drSNew!value = StyleValue(CallByName(pp, iStyle.Name, CallType.Get), iStyle.Name)
                    Next
                Next
            End If
        End If
        If TypeOf c Is TabControl Then
            For Each c2 As TabPage In CType(c, TabControl).TabPages
                updateDTS(dt, dtStyle, c2)
            Next
        Else
            For Each cqq As Control In c.Controls
                updateDTS(dt, dtStyle, cqq)
            Next
        End If


    End Sub
    Public Sub GetAllCTR(ByVal c As Control)
        ReDim Preserve AllControlInForm(AllControlInForm.Length)
        AllControlInForm(AllControlInForm.Length - 1) = c
        If TypeOf c Is TabControl Then
            For Each item As TabPage In CType(c, TabControl).TabPages
                GetAllCTR(item)
            Next
        Else
            For Each item As Control In c.Controls
                GetAllCTR(item)
            Next
        End If

    End Sub
    Private Sub RenderVTR(ByVal qqq As Control, ByVal _dtctr As DataTable, ByVal _dtStyle As DataTable)
        If String.IsNullOrEmpty(qqq.Name) OrElse qqq Is lblLeft OrElse qqq Is lblRight OrElse qqq Is lblBottom OrElse qqq Is lblBottom Then
            Return
        End If
        Dim _row() As DataRow = _dtctr.Select("tencontrol ='" & qqq.Name & "'")
        If _row.Length > 0 Then
            qqq.Top = _row(0)!mTop
            qqq.Left = _row(0)!mLeft
            qqq.Width = _row(0)!mWidth
            qqq.Height = _row(0)!mHeight
        End If
        controlToProp(qqq)
        Dim pp = controlProperties(controlProperties.Length - 1)
        Dim _rowstyle() As DataRow = _dtStyle.Select("controlName = '" & qqq.Name & "'")
        If _rowstyle.Length > 0 Then
            For i = 0 To _rowstyle.Length - 1
                If RenderStyle(_rowstyle(i)!value, _rowstyle(i)!propName) IsNot Nothing Then If _rowstyle(i)!propName.ToString.ToLower <> "control" Then CallByName(pp, _rowstyle(i)!propName.ToString, CallType.Set, RenderStyle(_rowstyle(i)!value, _rowstyle(i)!propName))
            Next
        End If
        pp.RenControl()
        If TypeOf qqq Is DataGridView Then
            AddColToGrid(qqq)
            For Each colit As DataGridViewColumn In CType(qqq, DataGridView).Columns
                controlToProp(colit)
                pp = controlProperties(controlProperties.Length - 1)
                _rowstyle = _dtStyle.Select("controlName = '" & colit.Name & "'")
                If _rowstyle.Length > 0 Then
                    For i = 0 To _rowstyle.Length - 1
                        If RenderStyle(_rowstyle(i)!value, _rowstyle(i)!propName) IsNot Nothing Then If _rowstyle(i)!propName.ToString.ToLower <> "control" Then CallByName(pp, _rowstyle(i)!propName.ToString, CallType.Set, RenderStyle(_rowstyle(i)!value, _rowstyle(i)!propName))
                    Next
                End If
                pp.RenControl()
            Next
        End If

        Dim _drcon() As DataRow = _dtctr.Select("tencontrolcha ='" & qqq.Name & "'")
        For Each item As DataRow In _drcon
            If String.IsNullOrEmpty(item!TenControl.ToString) Then
                Continue For
            End If
            Dim c As Control = FindInL(item!TenControl.ToString)
            If c Is Nothing Then
                Dim ctrType = GetType(Control).Assembly.[GetType](item("mType").ToString, True)
                c = Activator.CreateInstance(ctrType)
                c.Top = item!mTop
                c.Left = item!mLeft
                c.Width = item!mWidth
                c.Height = item!mHeight
                c.Name = item!TenControl.ToString
                qqq.Controls.Add(c)
                ReDim Preserve AllControlInForm(AllControlInForm.Length)
                AllControlInForm(AllControlInForm.Length - 1) = c
                controlToProp(c)
                pp = controlProperties(controlProperties.Length - 1)
                _rowstyle = _dtStyle.Select("controlName = '" & c.Name & "'")
                If _rowstyle.Length > 0 Then
                    For i = 0 To _rowstyle.Length - 1
                        If _rowstyle(i)!propName.ToString.ToLower <> "control" Then CallByName(pp, _rowstyle(i)!propName.ToString, CallType.Set, RenderStyle(_rowstyle(i)!value, _rowstyle(i)!propName))
                    Next
                End If
                pp.RenControl()
                If TypeOf c Is DataGridView Then
                    For Each colit As DataGridViewColumn In CType(c, DataGridView).Columns
                        controlToProp(colit)
                        pp = controlProperties(controlProperties.Length - 1)
                        _rowstyle = _dtStyle.Select("controlName = '" & colit.Name & "'")
                        If _rowstyle.Length > 0 Then
                            For i = 0 To _rowstyle.Length - 1
                                If RenderStyle(_rowstyle(i)!value, _rowstyle(i)!propName) IsNot Nothing Then If _rowstyle(i)!propName.ToString.ToLower <> "control" Then CallByName(pp, _rowstyle(i)!propName.ToString, CallType.Set, RenderStyle(_rowstyle(i)!value, _rowstyle(i)!propName))
                            Next
                        End If
                        pp.RenControl()
                    Next
                End If
            Else
                If c.Parent IsNot Nothing Then c.Parent = qqq
                c.BringToFront()
            End If
        Next
        If TypeOf qqq Is TabControl Then
            For Each item As Control In CType(qqq, TabControl).TabPages
                RenderVTR(item, _dtctr, _dtStyle)
            Next
        End If
        For Each item As Control In qqq.Controls
            RenderVTR(item, _dtctr, _dtStyle)
        Next
    End Sub
    Private Sub RenderBring(ByVal qqq As Control, ByVal _dtctr As DataTable)
        If _dtctr.Rows.Count = 0 Then Return
        For i = 0 To _dtctr.Rows.Count - 1
            Dim c As Control = qqq.Controls(_dtctr.Rows(i)!TenControl.ToString)
            If c IsNot Nothing AndAlso _dtctr.Rows(i)!mBrigIndex > 0 Then
                ReDim Preserve ControlBrigToF(ControlBrigToF.Length)
                ControlBrigToF(ControlBrigToF.Length - 1) = c
            End If

            If TypeOf qqq Is TabControl Then
                For Each item As Control In CType(qqq, TabControl).TabPages
                    RenderBring(item, _dtctr)
                Next
            Else
                For Each item As Control In qqq.Controls
                    RenderBring(item, _dtctr)
                Next
            End If
        Next
    End Sub
    Private Function FindLocation(ByVal c As Control) As Point
        Dim top As Integer = 0, left As Int16 = 0

        While (c.Parent IsNot Nothing AndAlso (Not TypeOf c.Parent Is MdiClient))
            top += c.Top
            left += c.Left
            c = c.Parent
        End While
        Return New Point(left, top)
    End Function
    Private Sub FindControlB(ByRef _dsCtr() As Control, ByVal cg As Control, ByVal p As Point)
        If Not cg.Visible Then Return
        If Array.IndexOf(_dsCtr, cg) < 0 AndAlso ctrBocDuocCtr.Contains("/" & cg.GetType().Name & "/") Then
            Dim ppp As Point = FindLocation(cg)
            If ppp.X <= p.X AndAlso ppp.Y <= p.Y AndAlso ppp.X + cg.Width >= p.X AndAlso ppp.Y + cg.Height >= p.Y Then
                ReDim Preserve _dsCtr(_dsCtr.Length)
                _dsCtr(_dsCtr.Length - 1) = cg
            End If
        End If
        If TypeOf cg Is TabControl Then
            For Each item As TabPage In CType(cg, TabControl).TabPages
                FindControlB(_dsCtr, item, p)
            Next
        Else
            For Each item As Control In cg.Controls
                FindControlB(_dsCtr, item, p)
            Next
        End If
    End Sub
    Private Function FindInL(ByVal s As String) As Control
        For i = 0 To AllControlInForm.Length - 1
            If AllControlInForm(i).Name.ToLower = s.ToLower Then
                Return AllControlInForm(i)
            End If
        Next
        Return Nothing
    End Function
    Private Sub CNDLThieu()
        Dim _s As String = "if not exists(select name from sys.tables where name ='VitriCtrBase') begin CREATE TABLE VitriCtrBase(TenControl nvarchar(50) NULL,TenControlCha nvarchar(50) NULL,mTop int NULL,mLeft int NULL,mWidth int NULL,mHeight int NULL,mBrigIndex int NULL,VitriCtrBaseID int IDENTITY(1,1) PRIMARY KEY NOT NULL,TenForm nvarchar(50) NULL,mType nvarchar(50) NULL) end"
        dbXML.RunSQL(_s)
    End Sub
    Private Function StyleValue(ByVal o As Object, ByVal c As String) As Object
        Select Case c
            Case "Anchor", "Dock", "Height", "Left", "TabIndex", "Top", "Width", "KieuNhapLieu", "BorderStyle", "NapNguocDanhMuc"
                Return CInt(o)
            Case "AutoSize", "Enabled", "RightToLeft", "UseWaitCursor", "Visible", "NoMove"
                Return CBool(o)
            Case "BackColor", "ForeColor"
                Return CType(o, Color).ToArgb()
            Case "Name", "Text", "DataSource", "DataFields"
                Return o.ToString
            Case "Font"
                Dim fff As Font = CType(o, Font)
                Return fff.FontFamily.Name & "/*/" & fff.Size & "/*/" & CInt(fff.Style)
            Case "MaximumSize", "MinimumSize"
                Dim sz As Size = CType(o, Size)
                Return sz.Width & "," & sz.Height
            Case "Padding"
                Dim pd As Padding = CType(o, Padding)
                Return pd.Top & "," & pd.Right & "," & pd.Bottom & "," & pd.Left
            Case Else
                Return Nothing
        End Select
    End Function
    Private Function RenderStyle(ByVal o As Object, ByVal c As String) As Object
        Select Case c
            Case "Anchor", "Dock", "Height", "Left", "TabIndex", "Top", "Width", "Name", "Text", "AutoSize", "Enabled", "RightToLeft", "UseWaitCursor", "Visible", "KieuNhapLieu", "NoMove", "NapNguocDanhMuc", "DataSource", "DataFields", "BorderStyle"
                Return o
            Case "BackColor", "ForeColor"
                Return Color.FromArgb(o)
            Case "Font"

                Dim _ds() As String = o.ToString.Split(New String() {"/*/"}, StringSplitOptions.RemoveEmptyEntries)
                Return New Font(_ds(0), CSng(_ds(1)), CType(_ds(2), FontStyle))
            Case "MaximumSize", "MinimumSize"
                Dim _ds() As String = o.ToString.Split(",")
                Return New Size(_ds(0), _ds(1))
            Case "Padding"
                Dim _ds() As String = o.ToString.Split(",")
                Return New Padding(_ds(3), _ds(0), _ds(1), _ds(2))
            Case Else
                Return Nothing
        End Select
    End Function
    Public Sub controlToProp(ByVal item As Object)
        Dim pp = getPropByControl(item)
        If pp Is Nothing Then
            pp = New PropertiesObject()
        End If
        Dim d = GetType(Control).GetProperties()
        For Each xxx In d
            If item.GetType().GetProperty(xxx.Name) IsNot Nothing AndAlso CallByName(item, xxx.Name, CallType.Get) IsNot Nothing AndAlso Array.IndexOf(DSPropSave, xxx.Name) >= 0 Then
                CallByName(pp, xxx.Name, CallType.Set, CallByName(item, xxx.Name, CallType.Get))
            End If
        Next
        If Me.ExtentProperties.Item(ExtenPropertiesComment.NapNguocDM(item)) IsNot Nothing Then
            pp.NapNguocDanhMuc = Me.ExtentProperties.Item(ExtenPropertiesComment.NapNguocDM(item)).Val
        End If
        If Me.ExtentProperties.Item(ExtenPropertiesComment.DataSourceControl(item)) IsNot Nothing Then
            pp.DataSource = Me.ExtentProperties.Item(ExtenPropertiesComment.DataSourceControl(item)).Val
        End If
        If Me.ExtentProperties.Item(ExtenPropertiesComment.ColumnDataFill(item)) IsNot Nothing Then
            pp.DataFields = Me.ExtentProperties.Item(ExtenPropertiesComment.ColumnDataFill(item)).Val
        End If
        If Me.ExtentProperties.Item(ExtenPropertiesComment.ColumnDataFill(item)) IsNot Nothing Then
            pp.DataFields = Me.ExtentProperties.Item(ExtenPropertiesComment.ColumnDataFill(item)).Val
        End If
        If Me.ExtentProperties.Item(ExtenPropertiesComment.NoMove(item)) IsNot Nothing Then
            pp.NoMove = Me.ExtentProperties.Item(ExtenPropertiesComment.NoMove(item)).Val
        End If
        If Me.ExtentProperties.Item(ExtenPropertiesComment.NhapNgayThang(item)) IsNot Nothing Then
            pp.KieuNhapLieu = KieuNhapLieu.NhapNgayThang
        ElseIf Me.ExtentProperties.Item(ExtenPropertiesComment.NhapGioFull(item)) IsNot Nothing Then
            pp.KieuNhapLieu = KieuNhapLieu.NhapGioFull
        ElseIf Me.ExtentProperties.Item(ExtenPropertiesComment.NhapGioPhut(item)) IsNot Nothing Then
            pp.KieuNhapLieu = KieuNhapLieu.NhapGioPhut
        ElseIf Me.ExtentProperties.Item(ExtenPropertiesComment.NhapNgayGio(item)) IsNot Nothing Then
            pp.KieuNhapLieu = KieuNhapLieu.NhapNgayGio
        ElseIf Me.ExtentProperties.Item(ExtenPropertiesComment.NhapSoLe(item)) IsNot Nothing Then
            pp.KieuNhapLieu = KieuNhapLieu.NhapSoLe
        ElseIf Me.ExtentProperties.Item(ExtenPropertiesComment.NhapSoNguyen(item)) IsNot Nothing Then
            pp.KieuNhapLieu = KieuNhapLieu.NhapSoNguyen
        End If
        pp.Control = item
        ReDim Preserve controlProperties(controlProperties.Length)
        controlProperties(controlProperties.Length - 1) = pp
    End Sub
    Private Function getPropByControl(ByVal c As Object) As PropertiesObject
        For i = 0 To controlProperties.Length - 1
            If controlProperties(i).Control.Name = c.Name Then
                Return controlProperties(i)
            End If
        Next
        Return Nothing
    End Function
    Public Sub AddNewControl(ByVal mType As String, ByVal mName As String, Optional ByVal _mx As Integer = 20, Optional ByVal _my As Integer = 20, Optional ByVal _mWidth As Integer = 100)
        Dim ctrType = GetType(Control).Assembly.[GetType]("System.Windows.Forms." & mType, False)
        If ctrType Is Nothing Then
            MsgBox("Chọn kiểu control cần thêm!", MsgBoxStyle.Critical)
            Return
        End If
        If String.IsNullOrEmpty(mName) Then
            MsgBox("Nhập tên control cần thêm!", MsgBoxStyle.Critical)
            Return
        End If
        Dim c = Activator.CreateInstance(ctrType)
        c.Top = _mx
        c.Left = _my
        c.Width = _mWidth
        c.Name = chuyenthanhkhongdau(mName).Replace("-", "")
        Try
            c.Text = c.Name
        Catch ex As Exception

        End Try

        Dim themvaoform As Boolean = True
        If curentControl.Count > 0 Then
            For i = 1 To curentControl.Count
                If DSControlContaner.Contains("/" & curentControl(i).GetType().Name & "/") Then
                    curentControl(1).Controls.Add(c)
                    themvaoform = False
                    Exit For
                End If
            Next
        End If
        If themvaoform Then Me.Controls.Add(c)
        c.BringToFront()
        controlToProp(c)
        ReDim Preserve AllControlInForm(AllControlInForm.Length)
        AllControlInForm(AllControlInForm.Length - 1) = c
        CType(c, Control).ContextMenuStrip = ctrRightMenu
        AddHandler CType(c, Control).MouseDown, AddressOf _MouseDown
        AddHandler CType(c, Control).MouseUp, AddressOf _MouseUp
        AddHandler CType(c, Control).MouseMove, AddressOf _MouseMove
        AddHandler CType(c, Control).MouseDoubleClick, AddressOf _MouseDoubleClick
    End Sub
    Private Sub RendStringFunc(ByVal c As Object, ByRef s As String, ByVal _dt As DataTable)
        If _dt Is Nothing Then Return
        If TypeOf c Is TabControl Then
            For Each item In c.TabPages
                RendStringFunc(item, s, _dt)
            Next
        Else
            For Each item In c.Controls
                RendStringFunc(item, s, _dt)
            Next
        End If
        CType(c, Control).ContextMenuStrip = ctrRightMenu
        Dim _dr() As DataRow = _dt.Select("ControlName = '" & c.Name & "'")

        If _dr.Length > 0 Then
            For i = 0 To _dr.Length - 1
                Dim item As DataRow = _dr(i)
                Select Case item!EventName.ToString
                    Case "Click"
                        RemoveHandler CType(c, Control).Click, AddressOf _DyamicEvent
                        AddHandler CType(c, Control).Click, AddressOf _DyamicEvent
                    Case "DoubleClick"
                        RemoveHandler CType(c, Control).DoubleClick, AddressOf _DyamicEvent
                        AddHandler CType(c, Control).DoubleClick, AddressOf _DyamicEvent
                    Case "Enter"
                        RemoveHandler CType(c, Control).Enter, AddressOf _DyamicEvent
                        AddHandler CType(c, Control).Enter, AddressOf _DyamicEvent
                    Case "Paint"
                        RemoveHandler CType(c, Control).Paint, AddressOf _DyamicEvent
                        AddHandler CType(c, Control).Paint, AddressOf _DyamicEvent
                    Case "SizeChanged"
                        RemoveHandler CType(c, Control).SizeChanged, AddressOf _DyamicEvent
                        AddHandler CType(c, Control).SizeChanged, AddressOf _DyamicEvent
                    Case "TextChanged"
                        RemoveHandler CType(c, Control).TextChanged, AddressOf _DyamicEvent
                        AddHandler CType(c, Control).TextChanged, AddressOf _DyamicEvent
                    Case "Validated"
                        RemoveHandler CType(c, Control).Validated, AddressOf _DyamicEvent
                        AddHandler CType(c, Control).Validated, AddressOf _DyamicEvent
                    Case "Validating"
                        RemoveHandler CType(c, Control).Validating, AddressOf _DyamicEvent
                        AddHandler CType(c, Control).Validating, AddressOf _DyamicEvent
                End Select
                CType(c, Control).AccessibleDescription = item!EventName
                s &= vbNewLine & "Public Sub " & c.Name & "_" & item!EventName & "(f as Object,o as Object,e as Object)"
                s &= vbNewLine & "Dim publicClass As Object = f.GetType().Assembly.CreateInstance(""CodeDyamic.PublicFuncs"")"
                s &= vbNewLine & "With f"
                s &= vbNewLine & item!mFunction.ToString
                s &= vbNewLine & "End With"
                s &= vbNewLine & "End Sub"
            Next
        End If
    End Sub
    Private Sub _DyamicEvent(ByVal sender As Object, ByVal e As Object)
        Dim args() As Object = {Me, sender, e}
        Try
            Dim t As Type = objCompiler.GetType().InvokeMember(sender.name & "_" & sender.AccessibleDescription, BindingFlags.InvokeMethod, Nothing, objCompiler, args)
        Catch ex As Exception
            MsgBox("Lỗi: " & ex.InnerException.ToString)
        End Try
    End Sub
    Private Sub RenStringCode()
        Dim _dt As DataTable = dbXML.GetTable("select * from EventControl where FormName = N'" & Me.Name & "'")
        code = "Imports System"
        code &= vbNewLine & "Imports System.Windows.Forms "
        code &= vbNewLine & "Imports Microsoft.VisualBasic"
        code &= vbNewLine & "Public Class DyamicFormSurportClass"
        Dim _s As String = ""
        RendStringFunc(Me, _s, _dt)
        code &= _s
        code &= vbNewLine & "End Class"
        vbParams.ReferencedAssemblies.Add("mscorlib.dll")
        vbParams.ReferencedAssemblies.Add("System.dll")
        vbParams.ReferencedAssemblies.Add("System.Windows.Forms.dll")
        vbParams.GenerateExecutable = False
        vbParams.GenerateInMemory = True
        compResults = vbProv.CompileAssemblyFromSource(vbParams, code)

        If compResults.Errors.Count > 0 Then
            For Each er In compResults.Errors
                MessageBox.Show(er.ToString())
            Next
        Else
            objCompiler = compResults.CompiledAssembly.CreateInstance("DyamicFormSurportClass")
        End If
    End Sub
#End Region
#Region "Property"
    ''' <summary>
    ''' properties mở rộng của form
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property ExtentProperties As ExtentPropCollection
        Get
            Return PropCol
        End Get
    End Property
    ''' <summary>
    ''' True: Cho phép kéo thả control;False: Không cho phép kéo thả control
    ''' </summary>
    ''' <remarks></remarks>
    Public Property isDesign As Boolean
        Get
            Return isDesign_
        End Get
        Set(ByVal value As Boolean)
            isDesign_ = value
            Add_HandLer(Me)
            RaiseEvent DesignChange(value)
        End Set
    End Property
#End Region
    Private Sub mnuSetEV_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSetEV.Click
        Me.Cursor = Cursors.WaitCursor
        Dim fff As New frmSetEvent
        fff.cbxControlName.Text = ctrRightMenu.SourceControl.Name
        fff.cbxFormName.Text = Me.Name
        fff.cbxEventName.SelectedIndex = 0
        fff.ShowDialog()
        RenStringCode()
        Me.Cursor = Cursors.Default
    End Sub
End Class

