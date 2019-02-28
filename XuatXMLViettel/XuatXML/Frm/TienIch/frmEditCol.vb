Public Class frmEditCol
#Region "Private Val"
    Private FormName_ As String = ""
    Private ControlName_ As String = ""
    Private ControlChaName_ As String = ""
    Private TrangThai As Integer = 0
#End Region
#Region "Public Val"
    Public dtDSAutoResizeColMode As DataTable
    Public dtDSColumnType As DataTable
#End Region
#Region "Form Control Event"
#Region "form"
    Private Sub frmEditCol_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ColumnType.DisplayMember = "Name"
        ColumnType.ValueMember = "ID"
        cAutoSizeMode.DisplayMember = "Name"
        cAutoSizeMode.ValueMember = "ID"
    End Sub
    Protected Overrides Function ProcessCmdKey(ByRef msg As System.Windows.Forms.Message, ByVal keyData As System.Windows.Forms.Keys) As Boolean
        Select Case keyData
            Case Keys.Escape
                If TrangThai <> 0 Then
                    CType(dtgDSCol.DataSource, DataTable).RejectChanges()
                    dtgDSCol.EndEdit()
                    TrangThai = 0
                End If
            Case Keys.F7
                If MsgBox("Bạn chắc chắn xóa cột này không?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    dtgDSCol.Rows.Remove(dtgDSCol.CurrentRow)
                    dbXML.UpdateData(dtgDSCol.DataSource, "select * from ColumnGrid")
                End If
        End Select
        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function
#End Region
#Region "dtg"
    Private Sub dtgDSCol_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dtgDSCol.DataError

    End Sub
    Private Sub dtgDSCol_RowValidated(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtgDSCol.RowValidated
        If TrangThai = 0 Then Return
        Dim _dt As DataTable = dtgDSCol.DataSource
        For Each item In _dt.Rows
            If String.IsNullOrEmpty(item!FormName.ToString) Then
                item!FormName = FormName_
            End If
            If String.IsNullOrEmpty(item!ControlName.ToString) Then
                item!ControlName = ControlName_
            End If
            If String.IsNullOrEmpty(item!ControlChaName.ToString) Then
                item!ControlChaName = ControlChaName_
            End If
        Next
        dbXML.UpdateData(_dt, "select * from ColumnGrid")
    End Sub
    Private Sub dtgDSCol_CurrentCellDirtyStateChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtgDSCol.CurrentCellDirtyStateChanged
        If TrangThai = 0 Then TrangThai = 2
    End Sub
    Private Sub dtgDSCol_UserAddedRow(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowEventArgs) Handles dtgDSCol.UserAddedRow
        TrangThai = 1
    End Sub
    Private Sub dtgDSCol_RowValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles dtgDSCol.RowValidating
        Dim _tenColNew As String = dtgDSCol.Rows(e.RowIndex).Cells(ColumnName.Name).Value.ToString
        For Each item As DataGridViewRow In dtgDSCol.Rows
            If item.Index <> e.RowIndex AndAlso item.Cells(ColumnName.Name).Value = _tenColNew Then
                MsgBox("Đã có tên cột rồi!", MsgBoxStyle.Critical)
                e.Cancel = True
                dtgDSCol.CurrentCell = dtgDSCol.Rows(e.RowIndex).Cells(ColumnName.Name)
            End If
        Next
    End Sub
#End Region
#End Region
#Region "Multipe Control Event"

#End Region
#Region "Property"
    Property FormName As String
        Get
            Return FormName_
        End Get
        Set(ByVal value As String)
            FormName_ = value
        End Set
    End Property
    Property ControlName As String
        Get
            Return ControlName_
        End Get
        Set(ByVal value As String)
            ControlName_ = value
        End Set
    End Property
    Property ControlChaName As String
        Get
            Return ControlChaName_
        End Get
        Set(ByVal value As String)
            ControlChaName_ = value
        End Set
    End Property
#End Region
#Region "Other"
    Public Sub LoadData()
        DongBoLuoi(dtgDSCol)
        If dtDSAutoResizeColMode Is Nothing Then
            dtDSAutoResizeColMode = New DataTable
            dtDSAutoResizeColMode.Columns.Add("Name")
            dtDSAutoResizeColMode.Columns.Add("ID")
            dtDSAutoResizeColMode.Columns("ID").DataType = GetType(Integer)
            For Each item In [Enum].GetValues(GetType(DataGridViewAutoSizeColumnMode))
                If item IsNot Nothing Then dtDSAutoResizeColMode.Rows.Add(item.ToString, CInt(item))
            Next
        End If
        If dtDSColumnType Is Nothing Then
            dtDSColumnType = New DataTable
            dtDSColumnType.Columns.Add("Name")
            dtDSColumnType.Columns.Add("ID")
            dtDSColumnType.Columns("ID").DataType = GetType(Integer)
            dtDSColumnType.Rows.Add("DataGridViewCheckBoxColumn", 0)
            dtDSColumnType.Rows.Add("DataGridViewTextBoxColumn", 1)
        End If
        ColumnType.DataSource = dtDSColumnType
        cAutoSizeMode.DataSource = dtDSAutoResizeColMode
        Dim _sql As String = String.Format("select * from columnGrid where FormName = N'{0}' and ControlName = N'{1}' and ControlChaName =N'{2}'", FormName_, ControlName_, ControlChaName_)
        dtgDSCol.DataSource = dbXML.GetTable(_sql)
    End Sub
#End Region

End Class