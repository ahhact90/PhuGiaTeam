Public Class UserDesignTable
    Public TableName As String = ""
    Public connectS As String = ""
    Protected Overrides Function ProcessCmdKey(ByRef msg As System.Windows.Forms.Message, ByVal keyData As System.Windows.Forms.Keys) As Boolean
        If keyData = Keys.Control + Keys.S Then
            Me.Cursor = Cursors.WaitCursor
            Dim _sUpdate As String = ""
            Dim _ds As DataTable = CType(dtgDesign.DataSource, DataTable).GetChanges(DataRowState.Added)
            If _ds IsNot Nothing Then
                For Each item In _ds.Rows
                    _sUpdate &= vbNewLine & "alter table " & TableName & " add " & item!name & " " & item!datatype
                    If String.IsNullOrEmpty(item!allow_null.ToString) OrElse Not item!allow_null Then
                        _sUpdate &= " " & "not null"
                    End If
                Next
            End If
            _ds = CType(dtgDesign.DataSource, DataTable).GetChanges(DataRowState.Modified)
            If _ds IsNot Nothing Then
                For Each item In _ds.Rows
                    _sUpdate &= vbNewLine & "alter table " & TableName & " alter column " & item!name & " " & item!datatype
                    If String.IsNullOrEmpty(item!allow_null.ToString) OrElse Not item!allow_null Then
                        _sUpdate &= " " & "not null"
                    End If
                Next
            End If
            _ds = CType(dtgDesign.DataSource, DataTable).GetChanges(DataRowState.Deleted)
            If _ds IsNot Nothing Then
                For Each item In _ds.Rows
                    _sUpdate &= vbNewLine & "alter table " & TableName & " drop column " & item!name
                Next
            End If
            If Me.Parent.Text(Me.Parent.Text.Length - 1) = "*" Then
                Me.Parent.Text = Me.Parent.Text.Substring(0, Me.Parent.Text.Length - 2)
            End If
            dbXML.RunSQL(_sUpdate)
            Me.Cursor = Cursors.Default
        End If
        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function
    Private Sub UserDesignTable_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim _dt As DataTable = dbXML.GetTable("select *,(case when typename like '%char%' then typename + '('+ (case when max_length > 0 then convert(nvarchar,max_length) else 'MAX' end) +')' else (case when typename like '%decimal%' then typename + '('+ convert(nvarchar,precision) +','+ convert(nvarchar,scale) +')' else typename end) end) datatype from (select b1.name,b2.name typename,case when b2.name Like 'n%' then b1.max_length/2 else b1.max_length end max_length,b1.is_nullable allow_null,b1.precision,b1.scale from sys.columns b1 join sys.types b2 on b1.user_type_id=b2.user_type_id where object_id = object_id('" & TableName & "'))b")
        _dt.Columns("allow_null").DefaultValue = True
        dtgDesign.AutoGenerateColumns = False
        dtgDesign.DataSource = _dt
        Dim _dtType As DataTable = dbXML.GetTable("select name + (case when name like '%char%' then '(500)' else (case when name like '%dec%' then '(18,2)' else '' end) end) name from sys.types Union select (case when typename like '%char%' then typename + '('+ (case when max_length > 0 then convert(nvarchar,max_length) else 'MAX' end) +')' else (case when typename like '%decimal%' then typename + '('+ convert(nvarchar,precision) +','+ convert(nvarchar,scale) +')' else typename end) end) name from (select b1.name,b2.name typename,case when b2.name Like 'n%' then b1.max_length/2 else b1.max_length end max_length,b1.is_nullable allow_null,b1.precision,b1.scale from sys.columns b1 join sys.types b2 on b1.user_type_id=b2.user_type_id where object_id = object_id('" & TableName & "'))b")
        DataType.DisplayMember = "name"
        DataType.ValueMember = "name"
        DataType.DataSource = _dtType
    End Sub

    Private Sub dtgDesign_CurrentCellDirtyStateChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtgDesign.CurrentCellDirtyStateChanged
        Dim _ds As DataTable = CType(dtgDesign.DataSource, DataTable).GetChanges()
        If _ds IsNot Nothing AndAlso Me.Parent.Text(Me.Parent.Text.Length - 1) <> "*" Then
            Me.Parent.Text &= " *"
        End If
    End Sub

    Private Sub dtgDesign_EditingControlShowing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles dtgDesign.EditingControlShowing
        If TypeOf e.Control Is DataGridViewComboBoxEditingControl Then
            CType(e.Control, DataGridViewComboBoxEditingControl).DropDownStyle = ComboBoxStyle.DropDown
        End If
    End Sub

    Private Sub dtgDesign_RowPostPaint(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs) Handles dtgDesign.RowPostPaint
        If dtgDesign.Rows(e.RowIndex).IsNewRow Then Return
        Dim _dtPRKey As DataTable = dbXML.GetTable("SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.KEY_COLUMN_USAGE WHERE OBJECTPROPERTY(OBJECT_ID(CONSTRAINT_SCHEMA + '.' + QUOTENAME(CONSTRAINT_NAME)), 'IsPrimaryKey') = 1 AND TABLE_NAME = '" & TableName & "' AND TABLE_SCHEMA = 'dbo'")
        If _dtPRKey.Select("column_name like '" & dtgDesign.DataSource.DefaultView(e.RowIndex).Row!name & "'").Length > 0 Then
            Dim bitmap = My.Resources.key
            Dim myIcon As Icon = Icon.FromHandle(bitmap.GetHicon)
            Dim graphics As Graphics = e.Graphics
            Dim iconHeight As Integer = 14
            Dim iconWidth As Integer = 14
            Dim xPosition As Integer = e.RowBounds.X + (dtgDesign.RowHeadersWidth / 2)
            Dim yPosition As Integer = e.RowBounds.Y + ((dtgDesign.Rows(e.RowIndex).Height - iconHeight) / 2)
            Dim rectangle As New Rectangle(xPosition, yPosition, iconWidth, iconHeight)
            graphics.DrawIcon(myIcon, rectangle)
        End If
    End Sub
End Class
