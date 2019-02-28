Public Class fFile
    Public IdMay As String = ""
    Public ConnectString As String = ""

    Public Sub SetFile(ByVal SavePath As String, ByVal ImagePath As String)
        Dim ms() As Byte = IO.File.ReadAllBytes(ImagePath)
        SetFile(SavePath, ms)
    End Sub
    Public Sub SetFile(ByVal SavePath As String, ByVal ImageByte() As Byte)
        Dim drp As String = (New IO.FileInfo(SavePath)).DirectoryName
        Dim _dif As New IO.DirectoryInfo(drp)
        Dim name As String = _dif.Name
        Dim pr As String = _dif.Parent.FullName
        RunSQL("Exec ExistsDirectory @dr = '" & name & "',@pr='" & pr & "'")

        Dim mSql As String = "DECLARE @ObjectToken INT"
        mSql &= vbNewLine & " EXEC sp_OACreate 'ADODB.Stream', @ObjectToken OUTPUT"
        mSql &= vbNewLine & " EXEC sp_OASetProperty @ObjectToken, 'Type', 1"
        mSql &= vbNewLine & " EXEC sp_OAMethod @ObjectToken, 'Open'"
        mSql &= vbNewLine & " EXEC sp_OAMethod @ObjectToken, 'Write', NULL, @IMG_PATH"
        mSql &= vbNewLine & " EXEC sp_OAMethod @ObjectToken, 'SaveToFile', NULL, @File , 2"
        mSql &= vbNewLine & " EXEC sp_OAMethod @ObjectToken, 'Close' "
        mSql &= vbNewLine & " EXEC sp_OADestroy @ObjectToken"
        Dim msqlCon As New SqlClient.SqlConnection(ConnectString)
        msqlCon.Open()
        Dim mCommand As New SqlClient.SqlCommand(mSql, msqlCon)
        mCommand.CommandType = CommandType.Text
        mCommand.Parameters.Add(New SqlClient.SqlParameter("@IMG_PATH", SqlDbType.Image))
        mCommand.Parameters("@IMG_PATH").Value = ImageByte
        mCommand.Parameters.Add(New SqlClient.SqlParameter("@File", SqlDbType.NVarChar))
        mCommand.Parameters("@File").Value = SavePath
        mCommand.ExecuteNonQuery()
    End Sub
    Public Function GetFile(ByVal ImagePath As String, Optional ByVal StartIndex As Integer = 0, Optional ByVal EndIndex As Integer = -1) As Byte()
        Try
            Dim _byte2 As Byte() = Gettable("SELECT * FROM OPENROWSET(BULK N'" & ImagePath & "', SINGLE_BLOB) AS Contents").Rows(0)(0)
            If EndIndex = -1 Then EndIndex = _byte2.Length - 1
            If EndIndex > StartIndex AndAlso EndIndex - StartIndex < _byte2.Length - 1 Then
                Dim _byte3(EndIndex - StartIndex) As Byte
                For i As Integer = 0 To _byte3.Length - 1
                    _byte3(i) = _byte2(i + StartIndex)
                Next
                _byte2 = _byte3
            End If
            Return _byte2
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Function RunSQL(ByVal Sql As String, Optional ByRef mSg As String = "") As Boolean
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
    Function Gettable(ByVal Sql As String, Optional ByRef Msg As String = "") As DataTable
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
    Public Function UpdateData(ByRef DT As Object, Optional ByVal ChuoiSQL As String = "", Optional ByRef MSG As String = "") As Boolean
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

End Class