Imports System.Data.SqlClient

Public Class userRunSQL
    Public WithEvents sqlConn As New SqlClient.SqlConnection
    Public Sub Excute()
        tabrs.Controls.Clear()
        tabms.Controls.Clear()
        Try
            Dim Sql As String = RichTextBox1.Text
            If RichTextBox1.SelectedText.Length > 0 Then Sql = RichTextBox1.SelectedText
            Using cn As New SqlConnection(sqlConn.ConnectionString)
                cn.Open()
                AddHandler cn.InfoMessage, Function(sender, e) AnonymousMethod1(sender, e)
                Dim cmd As New SqlCommand(Sql, cn)
                cmd.CommandType = CommandType.Text
                Dim _ds As New DataSet
                Dim _dad As New SqlDataAdapter(cmd)
                _dad.Fill(_ds)

                If _ds.Tables.Count > 0 Then
                    Dim begintop As Integer = 0
                    For Each item In _ds.Tables
                        Dim _dtg As New DataGridView
                        _dtg.AllowUserToDeleteRows = False
                        _dtg.AllowUserToAddRows = False
                        _dtg.ReadOnly = True
                        _dtg.BackgroundColor = Color.White
                        _dtg.AutoGenerateColumns = True
                        _dtg.DataSource = item
                        _dtg.Top = begintop
                        _dtg.Left = 0
                        tabrs.Controls.Add(_dtg)
                        _dtg.Width = tabrs.Width
                        _dtg.Height = tabrs.Height / 2 - 4
                        begintop += _dtg.Height + 2
                    Next
                End If
            End Using
        Catch ex As Exception
            Dim lbl As New Label()
            lbl.Text = ex.Message
            lbl.AutoSize = True
            lbl.ForeColor = Color.Red
            lbl.Top = 5
            lbl.Left = 5
            lbl.Font = New Font("times new roman", 10)
            tabms.Controls.Add(lbl)
            TabControl1.SelectedTab = tabms
        End Try

    End Sub
    Private Function AnonymousMethod1(ByVal sender As Object, ByVal e As SqlInfoMessageEventArgs) As Boolean
        MsgBox(Constants.vbLf + e.Message)
        Return True
    End Function
    Protected Overrides Function ProcessCmdKey(ByRef msg As System.Windows.Forms.Message, ByVal keyData As System.Windows.Forms.Keys) As Boolean
        If keyData = Keys.Control + Keys.Up AndAlso Me.ActiveControl Is RichTextBox1 Then
            Panel1.Height -= 3
        End If
        If keyData = Keys.Control + Keys.Down AndAlso Me.ActiveControl Is RichTextBox1 Then
            Panel1.Height += 3
        End If
        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function
End Class
