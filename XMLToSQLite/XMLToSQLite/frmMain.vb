Public Class frmMain
    Private aReady As Boolean = False
    Sub GetXML(_pathDB As String, _pathSource As String)

        Dim sql As New SqliteServer
        sql.DataSource = _pathDB
        sql.CreateDatabase()
        sql.OpenConn()
        Dim _s As String = ""
        _s &= vbNewLine & "CREATE TABLE ""xml123"" ("
        _s &= vbNewLine & "ID  INTEGER,"
        _s &= vbNewLine & "XML1_ID  INTEGER,"
        _s &= vbNewLine & "KY_QT  INTEGER,"
        _s &= vbNewLine & "COSOKCB_ID  INTEGER,"
        _s &= vbNewLine & "MA_CSKCB  TEXT,"
        _s &= vbNewLine & "MA_LK  TEXT,"
        _s &= vbNewLine & "MA_BN  TEXT,"
        _s &= vbNewLine & "HO_TEN  TEXT,"
        _s &= vbNewLine & "NGAY_SINH  TEXT,"
        _s &= vbNewLine & "GIOI_TINH  INTEGER,"
        _s &= vbNewLine & "MA_THE  TEXT,"
        _s &= vbNewLine & "MA_DKBD  TEXT,"
        _s &= vbNewLine & "GT_THE_TU TEXT,"
        _s &= vbNewLine & "GT_THE_DEN TEXT,"
        _s &= vbNewLine & "MIEN_CUNG_CT TEXT,"
        _s &= vbNewLine & "NGAY_VAO  TEXT,"
        _s &= vbNewLine & "NGAY_RA  TEXT,"
        _s &= vbNewLine & "SO_NGAY_DTRI  REAL,"
        _s &= vbNewLine & "MA_LYDO_VVIEN  TEXT,"
        _s &= vbNewLine & "MA_BENH  TEXT,"
        _s &= vbNewLine & "MA_BENHKHAC  TEXT,"
        _s &= vbNewLine & "MUC_HUONG_XML1 REAL,"
        _s &= vbNewLine & "T_TONGCHI  REAL,"
        _s &= vbNewLine & "T_BNTT  REAL,"
        _s &= vbNewLine & "T_BHTT  REAL,"
        _s &= vbNewLine & "T_BNCCT REAL,"
        _s &= vbNewLine & "T_XN  REAL,"
        _s &= vbNewLine & "T_CDHA  REAL,"
        _s &= vbNewLine & "T_THUOC  REAL,"
        _s &= vbNewLine & "T_MAU  REAL,"
        _s &= vbNewLine & "T_TTPT  REAL,"
        _s &= vbNewLine & "T_VTYT  REAL,"
        _s &= vbNewLine & "T_DVKT_TYLE  REAL,"
        _s &= vbNewLine & "T_THUOC_TYLE  REAL,"
        _s &= vbNewLine & "T_VTYT_TYLE  REAL,"
        _s &= vbNewLine & "T_KHAM  REAL,"
        _s &= vbNewLine & "T_GIUONG  REAL,"
        _s &= vbNewLine & "T_VCHUYEN  REAL,"
        _s &= vbNewLine & "T_NGOAIDS  REAL,"
        _s &= vbNewLine & "T_NGUONKHAC  REAL,"
        _s &= vbNewLine & "MA_LOAI_KCB  INTEGER,"
        _s &= vbNewLine & "ID_CP  INTEGER,"
        _s &= vbNewLine & "LOAI_CP  TEXT,"
        _s &= vbNewLine & "MA_CP  TEXT,"
        _s &= vbNewLine & "MA_VAT_TU  TEXT,"
        _s &= vbNewLine & "MA_NHOM  TEXT,"
        _s &= vbNewLine & "TEN_CP  TEXT,"
        _s &= vbNewLine & "DVT  TEXT,"
        _s &= vbNewLine & "SO_DANG_KY TEXT,"
        _s &= vbNewLine & "HAM_LUONG TEXT,"
        _s &= vbNewLine & "DUONG_DUNG TEXT,"
        _s &= vbNewLine & "SO_LUONG  REAL,"
        _s &= vbNewLine & "SO_LUONG_BV  REAL,"
        _s &= vbNewLine & "DON_GIA  REAL,"
        _s &= vbNewLine & "DON_GIA_BV  REAL,"
        _s &= vbNewLine & "THANH_TIEN  REAL,"
        _s &= vbNewLine & "TYLE_TT  REAL,"
        _s &= vbNewLine & "NGAY_YL  TEXT,"
        _s &= vbNewLine & "NGAY_KQ TEXT,"
        _s &= vbNewLine & "T_NGUONKHAC_DTL REAL,"
        _s &= vbNewLine & "T_BNTT_DTL REAL,"
        _s &= vbNewLine & "T_BHTT_DTL REAL,"
        _s &= vbNewLine & "T_BNCCT_DTL REAL,"
        _s &= vbNewLine & "T_NGOAIDS_DTL REAL,"
        _s &= vbNewLine & "MUC_HUONG_DTL REAL,"
        _s &= vbNewLine & "TT_THAU TEXT,"
        _s &= vbNewLine & "PHAM_VI TEXT,"
        _s &= vbNewLine & "MA_GIUONG TEXT,"
        _s &= vbNewLine & "T_TRANTT REAL,"
        _s &= vbNewLine & "GOI_VTYT TEXT,"
        _s &= vbNewLine & "TEN_VAT_TU TEXT,"
        _s &= vbNewLine & "TEN_KHOA  TEXT,"
        _s &= vbNewLine & "MA_KHOA  TEXT,"
        _s &= vbNewLine & "MA_KHOA_XML1  TEXT,"
        _s &= vbNewLine & "TEN_KHOA_XML1  TEXT,"
        _s &= vbNewLine & "TEN_BENH  TEXT,"
        _s &= vbNewLine & "MA_BAC_SI  TEXT,"
        _s &= vbNewLine & "MA_TINH TEXT,"
        _s &= vbNewLine & "MA_TINH_THE TEXT"
        _s &= vbNewLine & ")"
        sql.RunSQL(_s)
        Dim _dt As DataTable = sql.GetTable("select * from sqlite_master")
        Dim _sSourcePath As String = _pathSource
        Dim _ds() As String = IO.Directory.GetFiles(_sSourcePath)
        Dim _idMax As Integer = 1
        Dim _dtMax As DataTable = sql.GetTable("select IfNull(max(id),0) id from xml123")
        If _dtMax.Rows.Count > 0 Then
            _idMax = _dtMax.Rows(0)!id + 1
        End If
        For Each item In _ds
            Try
                Dim ds As New DataSet
                ds.ReadXml(item)
                Dim dt As DataTable = ds.Tables(0)
                If dt.Columns.Contains("T_DKKT_TYLE") Then
                    dt.Columns("T_DKKT_TYLE").ColumnName = "T_DVKT_TYLE"
                End If
                For Each item2 As DataRow In dt.Rows
                    For Each item3 As DataColumn In dt.Columns
                        If String.IsNullOrEmpty(item2(item3.ColumnName).ToString.Trim) Then
                            item2(item3.ColumnName) = DBNull.Value
                        End If
                    Next
                    item2!id = _idMax
                    _idMax += 1
                    item2.AcceptChanges()
                    item2.SetAdded()
                Next
                Dim msg As String = ""
                If sql.UpdateTable(dt, "select * from xml123", msg) Then
                    ds.Dispose()
                    IO.File.Delete(item)
                Else
                    MsgBox("Có lỗi khi cập nhật: " & vbNewLine & msg)
                End If
                Dim _sAdd As String = (vbNewLine & vbNewLine & "__________________________________  " & Now.ToString("dd/MM/yyyy HH:mm:ss") & " " & Now.Millisecond & "  ________________________________________" & vbNewLine)
                _sAdd &= "Cập nhật thành công file " & item
                txtLog.Text = _sAdd & vbNewLine & txtLog.Text
            Catch ex As Exception
                Dim _sAdd As String = (vbNewLine & vbNewLine & "__________________________________  " & Now.ToString("dd/MM/yyyy HH:mm:ss") & " " & Now.Millisecond & "  ________________________________________" & vbNewLine)
                _sAdd &= "Cập nhật lỗi file " & item & vbNewLine & ex.StackTrace & vbNewLine
                txtLog.Text = _sAdd & vbNewLine & txtLog.Text
            End Try
            My.Application.DoEvents()
        Next
        sql.CloseConn()

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Timer1.Enabled = False
        GetXML(txtFolderDB.Text, txtFolderXML.Text)
        Timer1.Enabled = True
    End Sub
     Private Sub txtFolderXML_TextChanged(sender As Object, e As EventArgs) Handles txtFolderXML.TextChanged, txtFolderDB.TextChanged, txtTime.TextChanged
        If Not aReady Then Return
        IO.File.WriteAllText(My.Application.Info.DirectoryPath & "\if.path", If(IsNumeric(txtTime.Text), txtTime.Text, "10") & vbNewLine & txtFolderXML.Text & vbNewLine & txtFolderDB.Text)
        If sender Is txtTime AndAlso IsNumeric(txtTime.Text) Then
            Timer1.Interval = CInt(txtTime.Text) * 1000
        End If
    End Sub

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If IO.File.Exists(My.Application.Info.DirectoryPath & "\if.path") Then
            Dim _s() As String = IO.File.ReadAllLines(My.Application.Info.DirectoryPath & "\if.path")
            If IsNumeric(_s(0)) Then
                txtTime.Text = _s(0)
            Else
                txtTime.Text = "10"
            End If
            If _s.Length > 1 Then
                txtFolderXML.Text = _s(1)
            End If
            If _s.Length > 2 Then
                txtFolderDB.Text = _s(2)
            End If
        End If

        Timer1.Interval = CInt(txtTime.Text) * 1000
    End Sub

    Private Sub frmMain_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        aReady = True
    End Sub
     
    Private Sub btnGetData_Click(sender As Object, e As EventArgs) Handles btnGetData.Click
        Timer1.Enabled = False
        GetXML(txtFolderDB.Text, txtFolderXML.Text)
        Timer1.Enabled = True
    End Sub

    Private Sub btnStartTime_Click(sender As Object, e As EventArgs) Handles btnStartTime.Click
        Timer1.Enabled = True
    End Sub

    Private Sub btnStopTime_Click(sender As Object, e As EventArgs) Handles btnStopTime.Click
        Timer1.Enabled = False
    End Sub

    Private Sub btnThoat_Click(sender As Object, e As EventArgs) Handles btnThoat.Click
        Me.Opacity = 0
        Me.ShowInTaskbar = False
    End Sub

    Private Sub mnuClose_Click(sender As Object, e As EventArgs) Handles mnuClose.Click
        Me.Close()
    End Sub

    Private Sub mnuGetData_Click(sender As Object, e As EventArgs) Handles mnuGetData.Click
        Timer1.Enabled = False
        GetXML(txtFolderDB.Text, txtFolderXML.Text)
        Timer1.Enabled = True
    End Sub

    Private Sub mnuShow_Click(sender As Object, e As EventArgs) Handles mnuShow.Click
        Me.Opacity = 1
        Me.ShowInTaskbar = True
    End Sub
End Class
