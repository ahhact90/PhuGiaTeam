Imports System.Data.Sql

Public Class frmConfigConnect
    Dim cnsp As New ConnectSRP()
    Private Sub frmConfigConnect_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim _dt As New DataTable
        _dt.Columns.Add("id", GetType(Integer))
        _dt.Columns.Add("name")
        For Each item In GetType(DuLieu).GetMembers
            If item.GetCustomAttributes(GetType(System.ComponentModel.DescriptionAttribute), False) IsNot Nothing AndAlso item.GetCustomAttributes(GetType(System.ComponentModel.DescriptionAttribute), False).Length > 0 Then
                _dt.Rows.Add([Enum].Parse(GetType(DuLieu), item.Name), item.GetCustomAttributes(GetType(System.ComponentModel.DescriptionAttribute), False)(0).Description)
            End If

        Next
        cbxDuLieu.DataSource = _dt
        cbxDuLieu.ValueMember = "id"
        cbxDuLieu.DisplayMember = "name"
        Dim _s As String = ToolTip1.GetToolTip(btnSetupDD)
        If String.IsNullOrEmpty(_s) Then
            _s = My.Application.Info.DirectoryPath
            ToolTip1.SetToolTip(btnSetupDD, _s)
        End If
    End Sub
    Private Sub Label3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label3.Click
        If Control.ModifierKeys = Keys.Control Then
            If txtPass.PasswordChar <> " " AndAlso txtPass.PasswordChar <> "" Then txtPass.PasswordChar = "" Else txtPass.PasswordChar = " * "" Then"
        End If
    End Sub
    Private Sub btnGetAllDataSource_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGetAllDataSource.Click
        Me.Cursor = Cursors.WaitCursor
        Dim servers As DataTable = SqlDataSourceEnumerator.Instance.GetDataSources()
        Dim _dt As New DataTable
        _dt.Columns.Add("c")
        For Each item In servers.Rows
            _dt.Rows.Add(item!ServerName.ToString & If(Not String.IsNullOrEmpty(item!InstanceName.ToString), "\" & item!InstanceName.ToString, ""))
        Next
        cbxServer.DisplayMember = "c"
        cbxServer.ValueMember = "c"
        cbxServer.DataSource = _dt
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub btnGetDatabase_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGetDatabase.Click
        Me.Cursor = Cursors.WaitCursor
        Try
            Dim _dt As DataTable = Gettable("Data Source = " & cbxServer.Text & ";Initial Catalog = master;User ID = " & txtUser.Text & ";Password=" & txtPass.Text, "select name from sys.databases where name not in ('master','tempdb','model','msdb','ReportServer','ReportServerTempDB')")
            If _dt Is Nothing Then
                MsgBox("Bạn chưa nhập đúng mật khẩu và password!")
            Else
                cbxDatabase.DisplayMember = "name"
                cbxDatabase.ValueMember = "name"
                cbxDatabase.DataSource = _dt
            End If
        Catch
            MsgBox("Bạn chưa nhập đúng mật khẩu và password!")
        End Try
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub btnLuu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLuu.Click
        If cbxDuLieu.SelectedValue Is Nothing Then Return
        If Not String.IsNullOrEmpty(cbxServer.Text) AndAlso Not String.IsNullOrEmpty(txtPass.Text) AndAlso Not String.IsNullOrEmpty(txtUser.Text) AndAlso Not String.IsNullOrEmpty(txtPass.Text) Then
            Dim _s As String = ToolTip1.GetToolTip(btnSetupDD)
            If Not IO.Directory.Exists(_s) Then
                _s = My.Application.Info.DirectoryPath
            End If
            _s &= "\connect.sys"
            mIni.WriteString("A1", "DB" & cbxDuLieu.SelectedValue, _s) = cnsp.MaHoaKey(cbxServer.Text)
            mIni.WriteString("A2", "DB" & cbxDuLieu.SelectedValue, _s) = cnsp.MaHoaKey(txtUser.Text)
            mIni.WriteString("A3", "DB" & cbxDuLieu.SelectedValue, _s) = cnsp.MaHoaKey(txtPass.Text)
            mIni.WriteString("A4", "DB" & cbxDuLieu.SelectedValue, _s) = cnsp.MaHoaKey(cbxDatabase.Text)
        End If
    End Sub
    Private Sub btnSetupDD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSetupDD.Click
        Dim off As New FolderBrowserDialog()
        off.Description = "Chọn đường dẫn phần mềm."
        If off.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            ToolTip1.SetToolTip(btnSetupDD, off.SelectedPath)
        End If
    End Sub
    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
    Private Sub btnCreateDB_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCreateDB.Click
        Dim _sConnect As String = "Data Source = " & cbxServer.Text & ";Initial Catalog = master;User ID = " & txtUser.Text & ";Password=" & txtPass.Text
        Dim _s As String = cbxDatabase.Text
        If Not String.IsNullOrEmpty(_s) Then
            RunSQL(_sConnect, "CREATE DATABASE " & _s)
            cbxDatabase.Text = _s
        End If
    End Sub
#Region "SRP"

    Private Function Gettable(ByVal ConnectString As String, ByVal Sql As String, Optional ByRef Msg As String = "") As DataTable
        Dim _sqlconnect As New SqlClient.SqlConnection(ConnectString)
        _sqlconnect.Open()
        If Not Sql.ToLower.Contains("set dateformat dmy") Then Sql = "set dateformat dmy " & vbNewLine & Sql
        Dim dt As New DataTable
        Try
            Dim _SqlAdapter = New SqlClient.SqlDataAdapter(Sql, _sqlconnect)
            _SqlAdapter.SelectCommand.CommandTimeout = 36000
            _SqlAdapter.SelectCommand.CommandType = CommandType.Text
            _SqlAdapter.Fill(dt)
            dt.Locale = My.Application.Culture
            _sqlconnect.Close()
            Return dt
        Catch ex As Exception
            Msg = ex.Message
            _sqlconnect.Close()
            Return Nothing
        End Try
    End Function
    Private Function RunSQL(ByVal ConnectString As String, ByVal Sql As String, Optional ByRef mSg As String = "") As Boolean
        Dim _sqlconnect As New SqlClient.SqlConnection(ConnectString)
        _sqlconnect.Open()
        Dim _SqlAdapter = New SqlClient.SqlDataAdapter(Sql, _sqlconnect)
        _SqlAdapter.SelectCommand.CommandTimeout = 36000
        _SqlAdapter.SelectCommand.CommandType = CommandType.Text
        Try
            _SqlAdapter.SelectCommand.ExecuteNonQuery()
            _sqlconnect.Close()
            Return True
        Catch ex As Exception
            mSg = ex.Message
            _sqlconnect.Close()
            Return False
        End Try
    End Function
    Private Function UpdateData(ByVal ConnectString As String, ByRef DT As Object, Optional ByVal ChuoiSQL As String = "", Optional ByRef MSG As String = "") As Boolean
        Try
            Dim _sqlconnect As New SqlClient.SqlConnection(ConnectString)
            _sqlconnect.Open()
            Dim _SqlAdapter As New SqlClient.SqlDataAdapter()
            _SqlAdapter = New SqlClient.SqlDataAdapter(ChuoiSQL, _sqlconnect)
            Dim _SqlBuild As New SqlClient.SqlCommandBuilder
            If ChuoiSQL.Contains(";") Then
                Dim SQL = ChuoiSQL.Split(";")
                For i As Integer = 0 To DT.Tables.Count - 1
                    _SqlAdapter.SelectCommand.CommandText = SQL(i)
                    _SqlBuild = New SqlClient.SqlCommandBuilder(_SqlAdapter)
                    _SqlAdapter.Update(DT.Tables(i))
                    _SqlBuild.DataAdapter = Nothing
                Next
            Else
                If TypeOf DT Is DataSet AndAlso DT.ExtendedProperties.Count <> 0 Then
                    _SqlAdapter.InsertCommand = DT.ExtendedProperties("Insert")
                    _SqlAdapter.DeleteCommand = DT.ExtendedProperties("Delete")
                    _SqlAdapter.UpdateCommand = DT.ExtendedProperties("Update")
                Else
                    _SqlAdapter.SelectCommand.CommandText = ChuoiSQL
                    _SqlBuild = New SqlClient.SqlCommandBuilder(_SqlAdapter)
                End If
                _SqlAdapter.SelectCommand.CommandTimeout = 900
                _SqlAdapter.Update(DT)
                _SqlBuild.DataAdapter = Nothing
            End If
            Return True
        Catch ex As Exception
            MSG = ex.Message : Return False
        End Try
    End Function
    Private Function chuyenthanhkhongdau(ByVal text As String) As String
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
        text = text.Trim().Replace("-", "").Replace(ChrW(10), "").Replace(ChrW(13), "")
        text = text.Replace(" ", "-")
        Dim regex As New System.Text.RegularExpressions.Regex("\p{IsCombiningDiacriticalMarks}+")
        Dim strFormD As String = text.Normalize(System.Text.NormalizationForm.FormD)
        Dim kq As String = regex.Replace(strFormD, [String].Empty).Replace("đ"c, "d"c).Replace("Đ"c, "D"c)
        Return kq
    End Function
#End Region

    Private Sub cbxDuLieu_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbxDuLieu.SelectedIndexChanged
        If cbxDuLieu.SelectedValue Is Nothing Then Return
        Dim _s As String = ToolTip1.GetToolTip(btnSetupDD)
        _s &= "\connect.sys"
        If IO.File.Exists(_s) Then
            Dim _gm = ""
            _gm = cnsp.GiaiMaKey(mIni.ReadString("A1", "", "DB" & cbxDuLieu.SelectedValue, _s))
            If Not String.IsNullOrEmpty(_gm) Then cbxServer.Text = _gm
            _gm = cnsp.GiaiMaKey(mIni.ReadString("A2", "", "DB" & cbxDuLieu.SelectedValue, _s))
            If Not String.IsNullOrEmpty(_gm) Then txtUser.Text = _gm
            _gm = cnsp.GiaiMaKey(mIni.ReadString("A3", "", "DB" & cbxDuLieu.SelectedValue, _s))
            If Not String.IsNullOrEmpty(_gm) Then txtPass.Text = _gm
            _gm = cnsp.GiaiMaKey(mIni.ReadString("A4", "", "DB" & cbxDuLieu.SelectedValue, _s))
            If Not String.IsNullOrEmpty(_gm) Then cbxDatabase.Text = _gm
        End If
    End Sub
    
End Class
Public Class ConnectSRP
    Public Function GetConnectString(ByVal i As DuLieu, Optional ByVal path As String = "") As String
        If mIni Is Nothing Then Return ""
        If String.IsNullOrEmpty(path) Then path = My.Application.Info.DirectoryPath
        Dim _s = path & "\connect.sys"
        Dim _sqlCon As String = ""
        If IO.File.Exists(_s) Then
            Dim _gm As String = ""
            _gm = GiaiMaKey(mIni.ReadString("A1", "", "DB" & i, _s))
            If Not String.IsNullOrEmpty(_gm) Then _sqlCon &= "Data Source = " & _gm Else Return ""

            _gm = GiaiMaKey(mIni.ReadString("A4", "", "DB" & i, _s))
            If Not String.IsNullOrEmpty(_gm) Then _sqlCon &= ";Initial Catalog = " & _gm Else Return ""

            _gm = GiaiMaKey(mIni.ReadString("A2", "", "DB" & i, _s))
            If Not String.IsNullOrEmpty(_gm) Then _sqlCon &= ";User ID = " & _gm Else Return ""

            _gm = GiaiMaKey(mIni.ReadString("A3", "", "DB" & i, _s))
            If Not String.IsNullOrEmpty(_gm) Then _sqlCon &= ";Password = " & _gm Else Return ""

        End If
        Return _sqlCon
    End Function
    Public Function MaHoaKey(ByVal _s As String) As String
        Return MaHoa(_s, "BVST4.0")
    End Function
    Public Function GiaiMaKey(ByVal _s As String) As String
        Return GiaiMa(_s, "BVST4.0")
    End Function
End Class
Public Enum DuLieu
    <System.ComponentModel.Description("XML")>
    XML = 1
    <System.ComponentModel.Description("His")>
    His = 2
End Enum
