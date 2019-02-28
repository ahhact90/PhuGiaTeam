Public Class frmXuatXML
    Inherits frmPRTienIch
#Region "Private Var"
    ''' <summary>
    ''' TXT trên lưới
    ''' </summary>
    ''' <remarks></remarks>
    Private WithEvents txtDTG As TextBox
    Private StopFor As Boolean = False
    Private VtrBackGround As Integer = 0
    Private MaxBackGround As Integer = 0
    Dim TrangThaiCHK As Integer = 1
    Dim ChkChange As Boolean = False
    Private CLSXML As String = "4210"
#End Region
#Region "Var Property"

#End Region
#Region "Property"

#End Region
#Region "FormControlEvent"
#Region "Form"
    Private Sub _Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated

    End Sub
    Private Sub _Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.NotDesignMode = True
        Control.CheckForIllegalCrossThreadCalls = False
        txttungay.Text = Now.ToString("dd/MM/yyyy") & " 00:00"
        txtdenngay.Text = Now.ToString("dd/MM/yyyy") & " 23:59"
        SetExtentParam()

    End Sub
    Protected Overrides Function ProcessCmdKey(ByRef msg As System.Windows.Forms.Message, ByVal keyData As System.Windows.Forms.Keys) As Boolean
        Dim _ActiveControl As Control = Me.ActiveControl
        If _ActiveControl IsNot Nothing AndAlso TypeOf _ActiveControl Is SplitContainer Then
            _ActiveControl = CType(_ActiveControl, SplitContainer).ActiveControl
        End If
        Dim dtg As DataGridView = Nothing
        If _ActiveControl IsNot Nothing AndAlso _ActiveControl Is txtDTG Then dtg = CType(_ActiveControl, Object).EditingControlDataGridView

        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function
    Private Sub _Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown

        lblKK.Tag = dtgKK
        dtgKK.Tag = "makk"
        dtgKK.DataSource = dbHis.GetTable("select makk,tenkk from dmkk where maloaikk = 2")
        tenkk.ReadOnly = True

        lblDoiTuong.Tag = dtgDoiTuong
        dtgDoiTuong.Tag = "madt"
        dtgDoiTuong.DataSource = dbHis.GetTable("select madt,tendt from dmdoituong where Exists(select top 1 1 from dmdoituongsd where madt = dmdoituong.madt and matldt=1)")
        tendt.ReadOnly = True


        Dim _dt As New DataTable
        _dt.Columns.Add("ma")
        _dt.Columns.Add("ten")
        _dt.Columns("ma").DataType = GetType(Int32)
        _dt.Columns("ten").DataType = GetType(String)
        _dt.Rows.Add(1, "Nội trú")
        _dt.Rows.Add(2, "Ngoại trú")
        _dt.Rows.Add(4, "Điều trị ngoại trú")
        _dt.Rows.Add(5, "Nội trú điều trị ngoại trú")
        _dt.Rows.Add(6, "Ngoại trú điều trị ngoại trú")
        dtgDangDT.DataSource = _dt
        lblDangDT.Tag = dtgDangDT
        dtgDangDT.Tag = "ma"
        ten.ReadOnly = True
        For Each item In pnHeader.Controls
            If TypeOf item Is GridParam Then
                Select Case True
                    Case item Is dtgKK
                        dtgKK.SelectParam("", "makk") = mini.ReadString(dtgKK.Name, "", Me.Name)
                        dtgDoiTuong_SelectChange(dtgKK)
                    Case item Is dtgDangDT
                        dtgDangDT.SelectParam("", "ma") = mini.ReadString(dtgDangDT.Name, "", Me.Name)
                        dtgDoiTuong_SelectChange(dtgDangDT)
                    Case item Is dtgDoiTuong
                        dtgDoiTuong.SelectParam("", "madt") = mini.ReadString(dtgDoiTuong.Name, "", Me.Name)
                        dtgDoiTuong_SelectChange(dtgDoiTuong)
                End Select
            End If
        Next
        chkAutoEX.Checked = mini.ReadString(chkAutoEX.Name, False, Me.Name)
        chkXuat121.Checked = mini.ReadString(chkXuat121.Name, False, Me.Name)
        chkBH.Checked = mini.ReadString(chkBH.Name, False, Me.Name)
        txtFldSave.Text = mini.ReadString("FldXML121", "", Me.Name)
        aReady = True
    End Sub
#End Region
#Region "DTG"
    Private Sub dtgDoiTuong_SelectChange(ByVal sender As XMLCreator.GridParam) Handles dtgDoiTuong.SelectChange, dtgKK.SelectChange, dtgDangDT.SelectChange
        Dim Valsave As String = ""
        Select Case True
            Case sender Is dtgKK
                Valsave = dtgKK.SelectParam("", "makk")
                If Not String.IsNullOrEmpty(Valsave) Then
                    lblKK.ForeColor = Color.Red
                Else
                    lblKK.ForeColor = Color.Black
                End If
            Case sender Is dtgDangDT
                Valsave = dtgDangDT.SelectParam("", "ma")
                If Not String.IsNullOrEmpty(Valsave) Then
                    lblDangDT.ForeColor = Color.Red
                Else
                    lblDangDT.ForeColor = Color.Black
                End If
            Case sender Is dtgDoiTuong
                Valsave = dtgDoiTuong.SelectParam("", "madt")
                If Not String.IsNullOrEmpty(Valsave) Then
                    lblDoiTuong.ForeColor = Color.Red
                Else
                    lblDoiTuong.ForeColor = Color.Black
                End If
        End Select
        If Not aReady Then Return
        If Not String.IsNullOrEmpty(Valsave) Then mini.WriteString(sender.Name, Me.Name) = Valsave
    End Sub
#End Region
#Region "CHK"
    Private Sub chkDaTT_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkDaTT.CheckedChanged
        If ChkChange Then Return
        If Not aReady Then Return
        TrangThaiCHK += 1
        If TrangThaiCHK Mod 3 = 1 Then ChkChange = True : chkDaTT.CheckState = CheckState.Indeterminate : ChkChange = False
        If TrangThaiCHK Mod 3 = 2 Then ChkChange = True : chkDaTT.CheckState = CheckState.Checked : chkDaTT.Checked = True : ChkChange = False
        If TrangThaiCHK Mod 3 = 0 Then ChkChange = True : chkDaTT.CheckState = CheckState.Unchecked : chkDaTT.Checked = False : ChkChange = False
    End Sub
    Private Sub chkAutoEX_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkAutoEX.CheckedChanged, chkXuat121.CheckedChanged, chkBH.CheckedChanged
        If Not aReady Then Return
        mini.WriteString(sender.name, Me.Name) = sender.Checked
    End Sub
#End Region
#Region "Btn"
    Private Sub btnStop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStop.Click
        StopFor = True
    End Sub
    Private Sub btnStUpTT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpTT.Click
        Dim _sqltemp As String = "update xmlfile set DaTT=1,ngaytt=b2.ngaytt From xmlFile b1 join {0}..ttthanhtoanravien@duoibang b2 on b1.makcb = b2.makcb where b1.datt=0 and b2.datt=1"
        Dim _sql As String = ""
        For index = 1 To 12
            _sql &= vbNewLine & String.Format(_sqltemp.Replace("@duoibang", Strings.Right("0" & index, 2) & Strings.Right((Now.Year - 1).ToString, 2)), dbHis.DatabaseName)
        Next
        For index = 1 To 12
            _sql &= vbNewLine & String.Format(_sqltemp.Replace("@duoibang", Strings.Right("0" & index, 2) & Strings.Right((Now.Year).ToString, 2)), dbHis.DatabaseName)
        Next
        _sqltemp = "update xmlfile set DaTT=0,ngaytt=NULL From xmlFile b1 join {0}..ttthanhtoanravien@duoibang b2 on b1.makcb = b2.makcb where b1.datt=1 and b2.datt=0"
        For index = 1 To 12
            _sql &= vbNewLine & String.Format(_sqltemp.Replace("@duoibang", Strings.Right("0" & index, 2) & Strings.Right((Now.Year - 1).ToString, 2)), dbHis.DatabaseName)
        Next
        For index = 1 To 12
            _sql &= vbNewLine & String.Format(_sqltemp.Replace("@duoibang", Strings.Right("0" & index, 2) & Strings.Right((Now.Year).ToString, 2)), dbHis.DatabaseName)
        Next
        _sqltemp = "select makcb from {0}..ttthanhtoanravien@duoibang where datt=1"
        Dim _s As String = ""
        For index = 1 To 12
            _s &= If(String.IsNullOrEmpty(_s), "", "Union All") & vbNewLine & String.Format(_sqltemp.Replace("@duoibang", Strings.Right("0" & index, 2) & Strings.Right((Now.Year - 1).ToString, 2)), dbHis.DatabaseName)
        Next
        For index = 1 To 12
            _s &= If(String.IsNullOrEmpty(_s), "", "Union All") & vbNewLine & String.Format(_sqltemp.Replace("@duoibang", Strings.Right("0" & index, 2) & Strings.Right((Now.Year).ToString, 2)), dbHis.DatabaseName)
        Next
        _sql &= "update xmlfile set datt=0 where makcb not in (" & _s & ")"
        dbXML.RunSQL(_sql)
    End Sub
    Private Sub btnLayBN_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLayBN.Click
        Me.Cursor = Cursors.WaitCursor
        Dim _sqltemp As String = <SQL>
select b2.mabn,b1.makcb,b2.tenbn hoten,b2.dangdt,b1.ngaytt 
from ttthanhtoanravien@duoibang b1 
join dangky@duoibang b2 on b1.makcb = b2.makcb 
    and Exists(select top 1 1 from dmdoituongsd where madt = b2.madt and matldt = 1) 
where datt=1
<%= If(Not String.IsNullOrEmpty(txtMaNoiCap.Text), "And b2.manc " & If(chkLayNguocLai.Checked, "Not", "") & " in ('" & txtMaNoiCap.Text.Replace(",", "','") & "')", "") %>
                                 </SQL>.Value
        If Not String.IsNullOrEmpty(txtmakcb.Text) Then
            Dim _ds() As String = txtmakcb.Text.Split(",")
            For i = 0 To _ds.Length - 1
                _ds(i) = ChuanHoaS(_ds(i))
            Next
            _sqltemp &= vbNewLine & "and b1.makcb in ('" & Join(_ds, "','") & "')"
        End If


        Dim _dkkk As String = dtgKK.SelectParam("", "makk")
        If Not String.IsNullOrEmpty(_dkkk) Then
            _sqltemp &= vbNewLine & "and b1.makk in (" & _dkkk & ")"
        End If
        Dim _dkdt As String = dtgDoiTuong.SelectParam("", "madt")
        If Not String.IsNullOrEmpty(_dkdt) Then
            _sqltemp &= vbNewLine & "and b2.madt in (" & _dkdt & ")"
        End If
        Dim _dtdangdt As String = dtgDangDT.SelectParam("", "ma")
        If Not String.IsNullOrEmpty(_dtdangdt) Then
            _sqltemp &= vbNewLine & "and b2.dangdt in (" & _dtdangdt & ")"
        End If
        If Not String.IsNullOrEmpty(txtmakcb.Text) Then
            Dim _ds() As String = txtmakcb.Text.Split(",")
            For i = 0 To _ds.Length - 1
                _ds(i) = ChuanHoaS(_ds(i))
            Next
            _sqltemp &= vbNewLine & "and b2.makcb in ('" & Join(_ds, "','") & "')"
        End If
        If String.IsNullOrEmpty(txtmakcb.Text) Then
            If chkDaTT.CheckState = CheckState.Indeterminate Then
                _sqltemp &= vbNewLine & "and ((b1.ngaytt >= '" & txttungay.Text & "' and b1.ngaytt <='" & txtdenngay.Text & "') or b1.ngaytt is null)"
            Else
                If chkDaTT.Checked Then
                    _sqltemp &= vbNewLine & "and (b1.datt = 1 and (b1.ngaytt >= '" & txttungay.Text & "' and b1.ngaytt <='" & txtdenngay.Text & "'))"
                Else
                    _sqltemp &= vbNewLine & "and (isnull(b1.datt,0) = 0)"
                End If
            End If
        End If
        Dim _dsDuoiBang As DataTable = dbHis.GetTable("select distinct right(name,4) tenbang from sys.tables where name like 'dangky____'")
        Dim _sql As String = ""
        For Each item In _dsDuoiBang.Rows
            _sql &= If(String.IsNullOrEmpty(_sql), "", vbNewLine & "Union All") & vbNewLine & _sqltemp.Replace("@duoibang", item!tenbang)
        Next

        Dim _dtBN = dbHis.GetTable(_sql)
        _dtBN.DefaultView.Sort = "MaKCB"
        _dtBN = _dtBN.DefaultView.ToTable
        _dtBN.DefaultView.Sort = "MaKCB"
        If chkViewDS.Checked Then dtgdata.DataSource = _dtBN
        If _dtBN IsNot Nothing AndAlso _dtBN.Rows.Count > 0 Then
            StopFor = False
            If Not chkStep5.Checked Then
                Dim q = Nothing
                Dim i = 0
                Dim begin As DateTime = DateTime.Now
                For Each item In _dtBN.Rows
                    If StopFor Then Exit For
                    Dim vtr As Integer = 0
                    If chkViewDS.Checked Then
                        vtr = _dtBN.DefaultView.Find(item!makcb)
                        If vtr >= 0 Then
                            dtgdata.CurrentCell = dtgdata.Rows(vtr).Cells(MaKCB.Name)
                            dtgdata.CurrentRow.DefaultCellStyle.ForeColor = Color.Blue
                            dtgdata.Refresh()
                        End If
                    End If
                    i += 1

                    q = NewCLSXML(item!makcb, dbHis.ConnectString, dbXML.ConnectString)
                    q.GetXML()
                    If vtr >= 0 AndAlso chkViewDS.Checked Then
                        dtgdata.CurrentRow.DefaultCellStyle.ForeColor = Color.Red
                    End If
                    Dim timex = (DateTime.Now.Subtract(begin).TotalMilliseconds)
                    Dim DK = (CDec(_dtBN.Rows.Count) * CDec(timex) / CDec(i))
                    If chkXuatLuon.Checked AndAlso chkBH.Checked Then
                        Try
                            IO.File.WriteAllText(LayFLDSave(item!makcb.ToString, False) & "\" & Now.ToString("ddMMyy") & "_" & item!makcb & "_" & chuyenthanhkhongdau(item!hoten.ToString).Replace("-", "_") & "_" & item!mabn.ToString & ".xml", q.XmlReturn_)
                        Catch ex As Exception
                        End Try
                    End If
                    If chkXuat121.Checked Then
                        Dim q2 As New CreateXML.clsCreateXML121(item!makcb, dbHis.ConnectString, dbXML.ConnectString)
                        Dim dt As DataTable = q2.GetXML()
                        dt.DataSet.WriteXml(LayFLDSave(item!makcb.ToString, True) & "\121File_" & Now.ToString("ddMMyy") & "_" & item!makcb & "_" & chuyenthanhkhongdau(item!hoten.ToString).Replace("-", "_") & "_" & item!mabn.ToString & ".xml", XmlWriteMode.WriteSchema)
                    End If
                    lbltrangthai.Text = "Đang xuất: " & i & " / " & _dtBN.Rows.Count & "  - " & FormatNumber(timex, 2) & " ms - " & (timex \ 60000) & ":" & ((timex \ 1000) - (timex \ 60000) * 60) & " ( dự kiến: " & FormatNumber(DK, 2) & " - " & (DK \ 60000) & ":" & ((DK \ 1000) - (DK \ 60000) * 60) & ")"
                    lbltrangthai.Refresh()
                    Application.DoEvents()
                Next
            Else
                VtrBackGround = 0
                MaxBackGround = _dtBN.Rows.Count
                For Each item In _dtBN.Rows
                    If StopFor Then Exit For
                    Dim _bgw As New System.ComponentModel.BackgroundWorker
                    AddHandler _bgw.DoWork, AddressOf _DoWork
                    AddHandler _bgw.RunWorkerCompleted, AddressOf _RunWorkerCompleted
                    _bgw.RunWorkerAsync(New Object() {item!makcb, _dtBN})
                    Application.DoEvents()
                Next
            End If
        End If
        Me.Cursor = Cursors.Default
    End Sub
#End Region
#Region "Panel"

#End Region
#Region "PicBox"
    Private Sub PictureBox1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles PictureBox1.Click
        loaddsBN()
    End Sub
#End Region
#Region "LBL"
    Private Sub lbl_DBClick(ByVal sender As Object, ByVal e As EventArgs) Handles lblKK.DoubleClick, lblDoiTuong.DoubleClick, lblDangDT.DoubleClick, Label2.DoubleClick
        Dim dtg As GridParam = sender.Tag
        If String.IsNullOrEmpty(dtg.SelectParam(dtg.Tag.ToString)) Then
            dtg.CheckAll(True)
        Else
            dtg.CheckAll(False)
        End If
        dtgDoiTuong_SelectChange(dtg)
    End Sub
#End Region
#Region "BGW"

    Private Sub _DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs)
        Dim _makcb As String = e.Argument(0)
        Dim _dtBN As DataTable = e.Argument(1)
        Dim vtr As Integer = 0
        If chkViewDS.Checked Then
            vtr = _dtBN.DefaultView.Find(_makcb)
            If vtr >= 0 Then
                dtgdata.Rows(vtr).DefaultCellStyle.ForeColor = Color.Blue
            End If
        End If
        Dim q = NewCLSXML(_makcb, dbHis.ConnectString, dbXML.ConnectString)
        q.GetXML()
        If chkViewDS.Checked Then
            If vtr >= 0 Then
                dtgdata.Rows(vtr).DefaultCellStyle.ForeColor = Color.Red
            End If
        End If
        Application.DoEvents()
    End Sub
    Private Sub _RunWorkerCompleted(ByVal sender As System.Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs)
        VtrBackGround += 1
        If VtrBackGround >= 0 AndAlso VtrBackGround < dtgdata.Rows.Count Then dtgdata.CurrentCell = dtgdata.Rows(VtrBackGround).Cells(MaKCB.Name)
        lbltrangthai.Text = "Đang xuất: " & VtrBackGround & " / " & MaxBackGround
        lbltrangthai.Refresh()
        Application.DoEvents()
    End Sub
#End Region
#Region "Time"
    Private Sub tmAutoExportXML_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmAutoExportXML.Tick
        tmAutoExportXML.Enabled = False
        If chkAutoEX.Checked Then
            Dim _dsBangDK As DataTable = dbHis.GetTable("select right(name,4) name from sys.tables where name like 'dangky____'")
            Dim _sDK As String = ""
            For Each item In _dsBangDK.Rows
                _sDK &= If(String.IsNullOrEmpty(_sDK), "", " Union All ") & "select b1.makcb,tenbn hoten,mabn  from " & dbHis.DatabaseName & "..ttthanhtoanravien" & item!name.ToString & " b1 join " & dbHis.DatabaseName & "..dangky" & item!name.ToString & " b2 on b1.makcb = b2.makcb where datt=1 "

                If Not String.IsNullOrEmpty(txtmakcb.Text) Then
                    Dim _ds() As String = txtmakcb.Text.Split(",")
                    For i = 0 To _ds.Length - 1
                        _ds(i) = ChuanHoaS(_ds(i))
                    Next
                    _sDK &= vbNewLine & "and b1.makcb in ('" & Join(_ds, "','") & "')"
                End If


                Dim _dkkk As String = dtgKK.SelectParam("", "makk")
                If Not String.IsNullOrEmpty(_dkkk) Then
                    _sDK &= vbNewLine & "and b1.makk in (" & _dkkk & ")"
                End If
                Dim _dkdt As String = dtgDoiTuong.SelectParam("", "madt")
                If Not String.IsNullOrEmpty(_dkdt) Then
                    _sDK &= vbNewLine & "and b2.madt in (" & _dkdt & ")"
                End If
                Dim _dtdangdt As String = dtgDangDT.SelectParam("", "ma")
                If Not String.IsNullOrEmpty(_dtdangdt) Then
                    _sDK &= vbNewLine & "and b2.dangdt in (" & _dtdangdt & ")"
                End If
                If Not String.IsNullOrEmpty(txtmakcb.Text) Then
                    Dim _ds() As String = txtmakcb.Text.Split(",")
                    For i = 0 To _ds.Length - 1
                        _ds(i) = ChuanHoaS(_ds(i))
                    Next
                    _sDK &= vbNewLine & "and b2.makcb in ('" & Join(_ds, "','") & "')"
                End If
                If chkDaTT.CheckState = CheckState.Indeterminate Then
                    _sDK &= vbNewLine & "and ((b1.ngaytt >= '" & txttungay.Text & "' and b1.ngaytt <='" & txtdenngay.Text & "') or b1.ngaytt is null)"
                Else
                    If chkDaTT.Checked Then
                        _sDK &= vbNewLine & "and (b1.datt = 1 and (b1.ngaytt >= '" & txttungay.Text & "' and b1.ngaytt <='" & txtdenngay.Text & "'))"
                    Else
                        _sDK &= vbNewLine & "and (isnull(b1.datt,0) = 0)"
                    End If
                End If

            Next
            Dim _dt As DataTable = dbXML.GetTable("select * from (" & _sDK & ") b1 where makcb not in (select makcb from xmlfile)")
            For Each item In _dt.Rows
                If chkBH.Checked Then
                    Try
                        Dim q = NewCLSXML(item!makcb, dbHis.ConnectString, dbXML.ConnectString)
                        q.GetXML()
                        Dim _xml As String = q.XmlReturn_
                        IO.File.WriteAllText(LayFLDSave(item!makcb.ToString, False) & "\" & Now.ToString("ddMMyy") & "_" & item!makcb & "_" & chuyenthanhkhongdau(item!hoten.ToString).Replace("-", "_") & "_" & item!mabn.ToString & ".xml", _xml)
                    Catch ex As Exception
                    End Try
                End If
                If chkXuat121.Checked Then
                    Dim q2 As New CreateXML.clsCreateXML121(item!makcb, dbHis.ConnectString, dbXML.ConnectString)
                    Dim dt As DataTable = q2.GetXML()
                    dt.DataSet.WriteXml(LayFLDSave(item!makcb.ToString, True) & "\121File_" & Now.ToString("ddMMyy") & "_" & item!makcb & "_" & chuyenthanhkhongdau(item!hoten.ToString).Replace("-", "_") & "_" & item!mabn.ToString & ".xml", XmlWriteMode.WriteSchema)
                End If
                My.Application.DoEvents()
            Next
        End If
        tmAutoExportXML.Enabled = True
    End Sub
#End Region
#End Region
#Region "Other"
    Sub SetExtentParam()
        SetNhapNgayGio(txttungay, txtdenngay)
    End Sub
    Private Sub loaddsBN()
        Me.Cursor = Cursors.WaitCursor
        btnUpTT.PerformClick()
        Dim _sql = <SQL>
select MaKCB
      ,MaKK
      ,XML
      ,(case when DangDT=1 or DangDT=5 then 0 else 1 end) DangDT
      ,MaDT
      ,DaTT
      ,NgayTT
      ,DTNgoaiTru
      ,BangBN
      ,'' hoten,'' mabn from {0}..xmlFile b1
where 1=1
                   </SQL>.Value
        Dim _dkkk As String = dtgKK.SelectParam("", "makk")
        If Not String.IsNullOrEmpty(_dkkk) Then
            _sql &= vbNewLine & "and b1.makk in (" & _dkkk & ")"
        End If
        Dim _dkdt As String = dtgDoiTuong.SelectParam("", "madt")
        If Not String.IsNullOrEmpty(_dkdt) Then
            _sql &= vbNewLine & "and b1.madt in (" & _dkdt & ")"
        End If
        Dim _dtdangdt As String = dtgDangDT.SelectParam("", "ma")
        If Not String.IsNullOrEmpty(_dtdangdt) Then
            _sql &= vbNewLine & "and b1.dangdt in (" & _dtdangdt & ")"
        End If
        If Not String.IsNullOrEmpty(txtmakcb.Text) Then
            Dim _ds() As String = txtmakcb.Text.Split(",")
            For i = 0 To _ds.Length - 1
                _ds(i) = ChuanHoaS(_ds(i))
            Next
            _sql &= vbNewLine & "and b1.makcb in ('" & Join(_ds, "','") & "')"
        End If
        If chkDaTT.CheckState = CheckState.Indeterminate Then
            _sql &= vbNewLine & "and ((b1.ngaytt >= '" & txttungay.Text & "' and b1.ngaytt <='" & txtdenngay.Text & "') or b1.ngaytt is null)"
        Else
            If chkDaTT.Checked Then
                _sql &= vbNewLine & "and (b1.datt = 1 and (b1.ngaytt >= '" & txttungay.Text & "' and b1.ngaytt <='" & txtdenngay.Text & "'))"
            Else
                _sql &= vbNewLine & "and (isnull(b1.datt,0) = 0)"
            End If
        End If
        _sql &= vbNewLine & "and madt in (select madt from {1}..dmdoituongsd where matldt=1)"
        _sql = String.Format(_sql, dbXML.DatabaseName, dbHis.DatabaseName)
        Dim _dt = dbXML.GetTable(_sql)
        For Each item In _dt.Rows
            Dim _dtx As DataTable = dbHis.GetTable("select tenbn,mabn from dangky" & item!bangbn & " where makcb = '" & item!makcb & "'")
            If _dtx.Rows.Count > 0 Then
                item!hoten = _dtx.Rows(0)!tenbn.ToString
                item!mabn = _dtx.Rows(0)!mabn.ToString
            End If
        Next
        dtgdata.DataSource = _dt
        If _dt IsNot Nothing Then
            lbltrangthai.Text = "Tổng: " & _dt.Rows.Count & " bệnh nhân"
        End If
        Me.Cursor = Cursors.Default
    End Sub
    Function ChuanHoaS(s As String) As String
        If s.Length < 10 Then
            If s.Length <= 8 Then
                s = Strings.Right(Now.ToString("yyyy"), 2) & New String("0", 8 - s.Length) & s
            Else
                s = New String("0", 10 - s.Length) & s
            End If
        End If
        Return s
    End Function
    Private Sub btnXuatXML_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnXuatXML.Click
        If CType(dtgdata.DataSource, DataTable).Columns.Contains("XML") Then
            For Each itemR As DataGridViewRow In dtgdata.Rows
                If StopFor Then Exit For
                Dim item As DataRow = dtgdata.DataSource.DefaultView(itemR.Index).Row
                dtgdata.CurrentCell = itemR.Cells(MaKCB.Name)
                dtgdata.Refresh()
                Dim _xml = item!xml
                IO.File.WriteAllText(LayFLDSave(item!makcb.ToString, False) & "\" & Now.ToString("ddMMyy") & "_" & item!makcb & "_" & chuyenthanhkhongdau(item!hoten.ToString).Replace("-", "_") & "_" & item!mabn.ToString & ".xml", _xml)
            Next
        End If
    End Sub
    Public Function NewCLSXML(ByVal makcb As String, ByVal dbhiscn As String, ByVal dbxmlcn As String) As Object
        Dim _temptype = New CreateXML.ConnectSRP
        Dim _bangbn As String = TimBangBN(makcb)
        Dim _manc As String = dbHis.GetTable("select manc from dangky" & _bangbn & " where makcb = '" & makcb & "'").Rows(0)(0).ToString
        Dim _dt As DataTable = dbXML.GetTable("select * from cauhinhnoicap where manc ='" & _manc & "'")
        Dim _clsXML As String = "4210"
        If _dt.Rows.Count = 0 Then
            Dim _t As Type = _temptype.GetType.Assembly.GetType("CreateXML.clsCreateXML" & CLSXML)
            Return Activator.CreateInstance(_t, makcb, dbhiscn, dbxmlcn)
        Else
            If _dt.Rows(0)!xmlclass.ToString = "" Then
                Dim _t As Type = _temptype.GetType.Assembly.GetType("CreateXML.clsCreateXML" & CLSXML)
                Return Activator.CreateInstance(_t, makcb, dbhiscn, dbxmlcn)
            Else
                Dim _t As Type = _temptype.GetType.Assembly.GetType("CreateXML.clsCreateXML" & _dt.Rows(0)!xmlclass.ToString)
                Return Activator.CreateInstance(_t, makcb, dbhiscn, dbxmlcn)
            End If
        End If
    End Function
    Public Function LayFLDSave(ByVal _makcb As String, noivien As Boolean) As String
        If noivien Then
            Dim _filefolder As String = txtFldSave.Text
            Dim _bangbn As String = TimBangBN(_makcb)
            Dim _manc As String = dbHis.GetTable("select manc from dangky" & _bangbn & " where makcb = '" & _makcb & "'").Rows(0)(0).ToString
            Dim _dt As DataTable = dbXML.GetTable("select * from cauhinhnoicap where manc ='" & _manc & "'")
            If _dt.Rows.Count > 0 AndAlso _dt.Rows(0)!filefolder.ToString <> "" Then
                _filefolder = txtFldSave.Text & "\QP"
            Else
                _filefolder = txtFldSave.Text & "\CT"
            End If
            Return _filefolder
        Else
            Dim _filefolder As String = mini.ReadString("savefolder", My.Application.Info.DirectoryPath, "frmConfig")
            Dim _bangbn As String = TimBangBN(_makcb)
            Dim _manc As String = dbHis.GetTable("select manc from dangky" & _bangbn & " where makcb = '" & _makcb & "'").Rows(0)(0).ToString
            Dim _dt As DataTable = dbXML.GetTable("select * from cauhinhnoicap where manc ='" & _manc & "'")
            If _dt.Rows.Count > 0 AndAlso _dt.Rows(0)!filefolder.ToString <> "" Then
                _filefolder = _dt.Rows(0)!filefolder.ToString
            End If
            Return _filefolder
        End If
    End Function


    Public Function TimBangBN(ByVal makcb_ As String) As String
        Dim _dt As DataTable = dbHis.GetTable("EXECUTE BC_" & dbHis.DatabaseName.Substring(0, dbHis.DatabaseName.Length - 4) & "..laydanhsachngaytheomakcb '" & makcb_ & "'")
        Return CDate(_dt.Rows(0)("ngaydk").ToString).ToString("MMyy")
        Return ""
    End Function
#End Region

    Private Sub txtFldSave_TextChanged(sender As Object, e As EventArgs) Handles txtFldSave.TextChanged
        mini.WriteString("FldXML121", Me.Name) = txtFldSave.Text
    End Sub
End Class