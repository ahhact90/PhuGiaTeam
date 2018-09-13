Imports MyData
Public Class frmSqlServer
    Private Sub frmSqlServer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim nodeRoot As New TreeNode()
        nodeRoot.Text = dbXML.DatabaseName
        nodeRoot.Name = "root"
        AddNodeTab(nodeRoot)
        AddNodeView(nodeRoot)
        trvDatabase.Nodes.Add(nodeRoot)
        nodeRoot.Expand()
    End Sub
    Sub AddNodeTab(ByRef node As TreeNode)
        Dim nodeTab As New TreeNode
        nodeTab.Text = "Tables"
        nodeTab.Name = "Tab"
        Dim _dt As DataTable = dbXML.GetTable("select name from sys.tables")
        For Each item In _dt.Rows
            Dim nodeNew As New TreeNode
            nodeNew.Text = item!name.ToString
            nodeNew.Name = "Tab/catdl/" & item!name.ToString
            nodeTab.Nodes.Add(nodeNew)
            nodeNew.ContextMenuStrip = ctxTab
            Dim nodecol As New TreeNode
            nodecol.Text = "Columns"
            nodeNew.Nodes.Add(nodecol)
        Next
        node.Nodes.Add(nodeTab)
    End Sub
    Sub AddNodeView(ByRef node As TreeNode)
        Dim nodeTab As New TreeNode
        nodeTab.Text = "Views"
        nodeTab.Name = "View"
        Dim _dt As DataTable = dbXML.GetTable("select name from sys.views")
        For Each item In _dt.Rows
            Dim nodeNew As New TreeNode
            nodeNew.Text = item!name.ToString
            nodeNew.Name = "View/catdl/" & item!name.ToString
            nodeTab.Nodes.Add(nodeNew)
            nodeNew.ContextMenuStrip = ctxTab
            Dim nodecol As New TreeNode
            nodecol.Text = "Columns"
            nodeNew.Nodes.Add(nodecol)
        Next
        node.Nodes.Add(nodeTab)
    End Sub
    Sub AddColumn(ByVal node As TreeNode)
        node.Nodes.Clear()
        Dim nodeTab As New TreeNode
        nodeTab.Text = "Columns"
        nodeTab.Name = "columns/catdl/" & node.Name
        Dim _dt As DataTable = dbXML.GetTable("select b1.name,b2.name typeName,case when b2.name Like 'n%' then b1.max_length/2 else b1.max_length end max_length,b1.is_nullable from sys.columns b1 join sys.types b2 on b1.user_type_id=b2.user_type_id where object_id = object_id('" & node.Name.Split(New String() {"/catdl/"}, StringSplitOptions.RemoveEmptyEntries)(1) & "')")
        For Each item In _dt.Rows
            Dim nodeNew As New TreeNode
            nodeNew.Text = item!name.ToString & " ( " & item!typename & ", " & item!max_length & ", " & If(item!is_nullable, "null", "not null") & " )"
            nodeNew.Name = "Column/catdl/" & item!name.ToString & "/catdl/" & node.Name
            nodeTab.Nodes.Add(nodeNew)
        Next
        node.Nodes.Add(nodeTab)
    End Sub
    Private Sub trvDatabase_AfterExpand(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles trvDatabase.AfterExpand
        If e.Node.Name Like "Tab/catdl/*" OrElse e.Node.Name Like "View/catdl/*" Then
            AddColumn(e.Node)
        End If
    End Sub
    Private Sub mnuOpenTab_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuOpenTab.Click
        Dim _tabName As String = trvDatabase.SelectedNode.Name.Split(New String() {"/catdl/"}, StringSplitOptions.RemoveEmptyEntries)(1)
        If Not tabCTr.TabPages("ViewTable_" & _tabName) IsNot Nothing Then
            tabCTr.TabPages.Add("ViewTable_" & _tabName, _tabName)
            Dim dtg As New DataGridView()
            dtg.AllowUserToAddRows = True
            dtg.AllowUserToDeleteRows = True
            dtg.EditMode = DataGridViewEditMode.EditOnEnter
            dtg.BackgroundColor = Color.White
            dtg.Tag = "select * from  " & _tabName
            dtg.DataSource = dbXML.GetTable("select * from  " & _tabName)
            tabCTr.TabPages("ViewTable_" & _tabName).Controls.Add(dtg)
            dtg.Dock = DockStyle.Fill
        End If
        tabCTr.SelectedTab = tabCTr.TabPages("ViewTable_" & _tabName)
    End Sub
    Private Sub trvDatabase_NodeMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeNodeMouseClickEventArgs) Handles trvDatabase.NodeMouseClick
        trvDatabase.SelectedNode = e.Node
    End Sub

    Private Sub mnuNewQuery_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuNewQuery.Click
        Dim i As Integer = (From p In tabCTr.TabPages Where p.Name.ToString Like "RunSQL_*" Select p).Count
        tabCTr.TabPages.Add("RunSQL_" & (i + 1), "Run SQL " & (i + 1))
        Dim userrunSQL As New userRunSQL()
        userrunSQL.sqlConn = New SqlClient.SqlConnection(GetConnect(DuLieu.XML))
        userrunSQL.Name = "UserRunSQL_" & (i + 1)
        tabCTr.TabPages("RunSQL_" & (i + 1)).Controls.Add(userrunSQL)
        userrunSQL.Dock = DockStyle.Fill
        tabCTr.SelectedTab = tabCTr.TabPages("RunSQL_" & (i + 1))
    End Sub
    Private Sub ctxTab_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ctxTab.Opening
        mnuOpenTab.Visible = ctxTab.SourceControl Is trvDatabase
        mnuNewQuery.Visible = ctxTab.SourceControl Is trvDatabase
        mnuDesignTab.Visible = ctxTab.SourceControl Is trvDatabase
        mnuClose.Visible = ctxTab.SourceControl Is tabCTr
        mnuCloseAllButThis.Visible = ctxTab.SourceControl Is tabCTr
        mnuCloseAllLeft.Visible = ctxTab.SourceControl Is tabCTr
        mnuCloseAllRight.Visible = ctxTab.SourceControl Is tabCTr
    End Sub


    Private Sub tabCTr_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles tabCTr.MouseUp
        For index = 0 To tabCTr.TabPages.Count - 1
            Dim rec As Rectangle = tabCTr.GetTabRect(index)
            If rec.Contains(e.Location) Then
                tabCTr.SelectedTab = tabCTr.TabPages(index)
            End If
        Next
    End Sub

    Private Sub mnuClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuClose.Click
        tabCTr.TabPages.Remove(tabCTr.SelectedTab)
    End Sub

    Private Sub mnuCloseAllButThis_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuCloseAllButThis.Click
        For Each item In tabCTr.TabPages
            If item IsNot tabCTr.SelectedTab Then
                tabCTr.TabPages.Remove(item)
            End If
        Next
    End Sub

    Private Sub mnuCloseAllRight_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuCloseAllRight.Click
        Dim idx As Integer = tabCTr.TabPages.IndexOf(tabCTr.SelectedTab) + 1
        While idx < tabCTr.TabPages.Count
            tabCTr.TabPages.Remove(tabCTr.TabPages(idx))
        End While
    End Sub

    Private Sub mnuCloseAllLeft_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuCloseAllLeft.Click
        Dim idx As Integer = tabCTr.TabPages.IndexOf(tabCTr.SelectedTab) - 1
        While idx >= 0
            tabCTr.TabPages.Remove(tabCTr.TabPages(idx))
            idx -= 1
        End While
    End Sub

    Private Sub picInfomation_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles picInfomation.Click
        If trvDatabase.SelectedNode.Name Like "Tab_*" OrElse trvDatabase.SelectedNode.Name Like "View_*" Then
            Dim fff As New frmTableProperties()
            fff.TableName = trvDatabase.SelectedNode.Name.Split(New String() {"/catdl/"}, StringSplitOptions.RemoveEmptyEntries)(1)
            fff.ShowDialog()
        End If
    End Sub

    Private Sub picRunSql_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles picRunSql.Click
        If tabCTr.SelectedTab.Name Like "RunSQL_*" Then
            Me.Cursor = Cursors.WaitCursor
            CType(tabCTr.SelectedTab.Controls("User" & tabCTr.SelectedTab.Name), userRunSQL).Excute()
            Me.Cursor = Cursors.Default
        End If
    End Sub

    Private Sub mnuDesignTab_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuDesignTab.Click
        Dim _tabName As String = trvDatabase.SelectedNode.Name.Split(New String() {"/catdl/"}, StringSplitOptions.RemoveEmptyEntries)(1)
        If Not tabCTr.TabPages("DesignTable_" & _tabName) IsNot Nothing Then
            tabCTr.TabPages.Add("DesignTable_" & _tabName, "Edit " & _tabName)
            Dim usr As New UserDesignTable()
            usr.TableName = _tabName
            usr.connectS = (GetConnect(DuLieu.XML))
            usr.Name = "UserDesignTable_" & _tabName
            tabCTr.TabPages("DesignTable_" & _tabName).Controls.Add(usr)
            usr.Dock = DockStyle.Fill
        End If
        tabCTr.SelectedTab = tabCTr.TabPages("DesignTable_" & _tabName)
    End Sub

    Private Sub txtFindTab_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFindTab.TextChanged
        Dim nodePR As TreeNode = trvDatabase.SelectedNode.Parent
        For Each item In nodePR.Nodes
            item.BackColor = Color.White
            item.ForeColor = Color.Black
        Next
        Dim p As List(Of TreeNode) = (From q As TreeNode In nodePR.Nodes Where q.Text.ToLower Like "*" + txtFindTab.Text.ToLower + "*" Select q).ToList
        For Each item As TreeNode In p
            item.BackColor = SystemColors.Highlight
            item.ForeColor = Color.White
        Next
        If p.Count > 0 Then
            trvDatabase.SelectedNode = p(0)
        End If
    End Sub

    Private Sub pnAction_Resize(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pnAction.Resize
        txtFindTab.Width = SplitContainer1.Panel1.Width
    End Sub

    Private Sub frmSqlServer_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        txtFindTab.Width = SplitContainer1.Panel1.Width - 5
    End Sub

    Private Sub picKey_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles picKey.Click
        If tabCTr.SelectedTab.Name Like "DesignTable_*" Then
            Dim urs As UserDesignTable = tabCTr.SelectedTab.Controls("User" & tabCTr.SelectedTab.Name)
            Dim TableName As String = urs.Name.Split(New String() {"/catdl/"}, StringSplitOptions.RemoveEmptyEntries)(1)
            Dim _dtPRKey As DataTable = dbXML.GetTable("SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.KEY_COLUMN_USAGE WHERE OBJECTPROPERTY(OBJECT_ID(CONSTRAINT_SCHEMA + '.' + QUOTENAME(CONSTRAINT_NAME)), 'IsPrimaryKey') = 1 AND TABLE_NAME = '" & TableName & "' AND TABLE_SCHEMA = 'dbo'")
            dbXML.RunSQL("declare @s as nvarchar(max) declare @tab as nvarchar(max) set @tab='" & TableName & "' select @s='alter table ' + @tab + ' DROP CONSTRAINT ' + name from sys.key_constraints where parent_object_id = object_id('" & TableName & "') exec (@s)")
            Dim ds = urs.dtgDesign.SelectedRows
            If ds.Count = 0 Then Return
            Dim _sUpdate = "ALTER TABLE " & TableName
            _sUpdate &= " ADD CONSTRAINT PK_" & TableName & " PRIMARY KEY ("
            For Each item In ds
                _sUpdate &= CType(urs.dtgDesign.DataSource, DataTable).DefaultView(item.Index).Row("name") & ","
            Next
            _sUpdate = _sUpdate.Substring(0, _sUpdate.Length - 1)
            _sUpdate &= ");"
            If Not dbXML.RunSQL(_sUpdate) Then
                _sUpdate = "ALTER TABLE " & TableName
                _sUpdate &= " ADD CONSTRAINT PK_" & TableName & " PRIMARY KEY ("
                For Each item In _dtPRKey.Rows
                    _sUpdate &= item("column_name") & ","
                Next
                _sUpdate = _sUpdate.Substring(0, _sUpdate.Length - 1)
                _sUpdate &= ");"
                dbXML.RunSQL(_sUpdate)
            End If
            urs.dtgDesign.Refresh()
        End If
    End Sub
End Class