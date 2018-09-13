Imports System.Data.SQLite
Public Class SqliteServer
    Private DataSource_ As String = ""
    Property DataSource As String
        Get
            Return DataSource_
        End Get
        Set(value As String)
            DataSource_ = value
           
        End Set
    End Property
    Protected sConnectString_ As String
    Protected oSqlConn As SQLiteConnection
    Public Function OpenConn(Optional ByRef msg As String = "") As Boolean
        Try
            sConnectString_ = "Data Source = " & DataSource
            oSqlConn = New SQLiteConnection(sConnectString_)
            oSqlConn.Open()
            Return True
        Catch ex As Exception
            msg = ex.StackTrace
            Return False
        End Try
    End Function
    Public Function GetTable(sql As String, Optional ByRef msg As String = "") As DataTable
        Try
            Dim oCmd As New SQLiteCommand(sql, oSqlConn)
            Dim ds As New DataSet
            Dim oSda As New SQLiteDataAdapter(oCmd)
            oSda.Fill(ds)
            oCmd.Dispose()
            oSda.Dispose()
            Return ds.Tables(0)
        Catch ex As Exception
            msg = ex.StackTrace
            Return Nothing
        End Try
    End Function
    Public Function RunSQL(sql As String, Optional ByRef msg As String = "") As Boolean
        Try
            Dim oCmd As New SQLiteCommand(sql, oSqlConn)
            oCmd.ExecuteNonQuery()
            oCmd.Dispose()
            Return True
        Catch ex As Exception
            msg = ex.StackTrace
            Return False
        End Try
    End Function
    Public Function UpdateTable(dt As Object, sql As String, Optional ByRef msg As String = "") As Boolean
        Try
            Dim sSda As New SQLiteDataAdapter(sql, oSqlConn)
            Dim sCmb As SQLiteCommandBuilder = Nothing
            If sql.Contains(";") Then
                Dim dsSQL = sql.Split(";")
                For i As Integer = 0 To dt.Tables.Count - 1
                    sSda.SelectCommand.CommandText = dsSQL(i)
                    sCmb = New SQLiteCommandBuilder(sSda)
                    sSda.Update(dt.Tables(i))
                    sCmb.DataAdapter = Nothing
                Next
            Else
                If TypeOf dt Is DataSet AndAlso dt.ExtendedProperties.Count <> 0 Then
                    sSda.InsertCommand = dt.ExtendedProperties("Insert")
                    sSda.DeleteCommand = dt.ExtendedProperties("Delete")
                    sSda.UpdateCommand = dt.ExtendedProperties("Update")
                Else
                    sSda.SelectCommand.CommandText = sql
                    sCmb = New SQLiteCommandBuilder(sSda)
                End If
                sSda.SelectCommand.CommandTimeout = 900
                sSda.Update(dt)
                sCmb.DataAdapter = Nothing
            End If
            sSda.Dispose()
            sCmb.Dispose()
            Return True
        Catch ex As Exception
            msg = ex.Message
            Return False
        End Try
    End Function
    Public Function CloseConn(Optional ByRef msg As String = "") As Boolean
        Try
            If oSqlConn.State = ConnectionState.Open Then
                oSqlConn.Clone()
            End If
            Return True
        Catch ex As Exception
            msg = ex.StackTrace
            Return False
        End Try
    End Function
    Public Function CreateDatabase(Optional ByRef msg As String = "")
        Try
            If Not IO.File.Exists(DataSource) Then
                SQLiteConnection.CreateFile(DataSource)
            End If
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
End Class
