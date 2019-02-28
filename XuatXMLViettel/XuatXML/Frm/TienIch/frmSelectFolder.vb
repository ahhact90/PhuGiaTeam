Imports System.Drawing
Imports System.Runtime.InteropServices

Public Class frmSelectFolder
    Public MyFileSys As New fFile()
    Public SelectFld As String = ""
    Private txtDTG As DataGridViewTextBoxEditingControl
    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
        Dim _ActiveControl As Control = Me.ActiveControl
        If _ActiveControl IsNot Nothing AndAlso TypeOf _ActiveControl Is SplitContainer Then
            _ActiveControl = CType(_ActiveControl, SplitContainer).ActiveControl
        End If
        Dim dtg As DataGridView = Nothing
        If _ActiveControl IsNot Nothing AndAlso _ActiveControl Is txtDTG Then dtg = CType(_ActiveControl, Object).EditingControlDataGridView
        If _ActiveControl Is txtSelectFLD AndAlso keyData = Keys.Enter Then
            SelectFld = txtSelectFLD.Text
            For Each item In Me.trvFld.Nodes
                FindSelectNode(item, 0)
            Next
        End If
        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function
    Private Sub frmSelectFolder_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim _dt As DataTable = MyFileSys.Gettable("EXEC xp_fixeddrives")
        For Each item In _dt.Rows
            Dim node As New TreeNode(item!drive.ToString)
            node.Name = item!drive.ToString & ":"
            trvFld.Nodes.Add(node)
        Next
        For Each item As TreeNode In trvFld.Nodes
            GetSubNode(item)
        Next
        Dim _dtView As DataTable = New DataTable()
        _dtView.Columns.Add("ma")
        _dtView.Columns.Add("ten")
        For Each item In [Enum].GetValues(GetType(System.Windows.Forms.View))
            If item <> View.Details Then _dtView.Rows.Add(CInt(item), item.ToString())
        Next
        cbxView.DisplayMember = "ten"
        cbxView.ValueMember = "ma"
        cbxView.DataSource = _dtView
        cbxView.SelectedValue = View.List
        Dim imgList As New ImageList()
        ListFile.LargeImageList = imgList
        ListFile.SmallImageList = imgList
        FindSelectNode(trvFld, 0)
    End Sub
    Sub FindSelectNode(ByVal c As Object, ByVal lever As Integer)
        If String.IsNullOrEmpty(SelectFld) Then Return

        Dim _ds() As String = SelectFld.Split("\")
        Dim findS As String = ""

        For i = 0 To _ds.Length - 1
            If i > lever Then Exit For
            findS &= If(String.IsNullOrEmpty(findS), "", "\") & _ds(i)
        Next
        If Not c.Name.ToString.ToLower = findS.ToLower Then Return

        If findS.ToLower = SelectFld.ToLower Then
            trvFld.SelectedNode = c
            Exit Sub
        Else
            GetSubNode(c)
            For Each itemx In c.Nodes
                FindSelectNode(itemx, lever + 1)
            Next
        End If
    End Sub
    Sub GetSubNode(ByVal nodepr As Object)
        Dim _dt As DataTable = MyFileSys.Gettable("EXEC xp_dirtree '" & nodepr.Name & "',1")
        For Each item In _dt.Rows
            If item!subdirectory.ToString.Length = 0 OrElse item!subdirectory.ToString.Substring(0, 1) = "$" Then Continue For
            Dim node As New TreeNode(item!subdirectory.ToString)
            node.Name = nodepr.Name & "\" & item!subdirectory.ToString
            If TypeOf nodepr Is TreeNode Then
                Dim q = (From p As TreeNode In CType(nodepr, TreeNode).Nodes Where p.Name = node.Name Select p).Count
                If q = 0 Then nodepr.Nodes.Add(node)
            Else
                Dim q = (From p As TreeNode In CType(nodepr, TreeView).Nodes Where p.Name = node.Name Select p).Count
                If q = 0 Then nodepr.Nodes.Add(node)
            End If
        Next
    End Sub
    Private Sub trvFld_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles trvFld.AfterSelect
        GetSubNode(trvFld.SelectedNode)
        For Each item In trvFld.SelectedNode.Nodes
            GetSubNode(item)
        Next
        ListFile.Items.Clear()
        pnAddfolder.Tag = trvFld.SelectedNode.Name
        Dim l As ImageList = ListFile.LargeImageList
        Dim _dt As DataTable = MyFileSys.Gettable("EXEC xp_dirtree '" & trvFld.SelectedNode.Name & "',1,1")
        For Each item In _dt.Rows
            If item!file = 1 Then
                Dim ix As New ListViewItem()
                ix.Text = item!subdirectory.ToString
                Dim extentf As String = (New IO.FileInfo(trvFld.SelectedNode.Name & "\" & item!subdirectory.ToString)).Extension
                If Not l.Images.ContainsKey(extentf) Then
                    l.Images.Add(extentf, My.Resources.report)
                    ListFile.LargeImageList = l
                    ListFile.SmallImageList = l
                End If
                ix.ImageKey = extentf
                ListFile.Items.Add(ix)
            End If
        Next
        SelectFld = e.Node.Name
        txtSelectFLD.Text = SelectFld
    End Sub
    Private Sub cbxView_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbxView.SelectedIndexChanged
        If cbxView.SelectedValue Is Nothing Then Return
        ListFile.View = cbxView.SelectedValue
    End Sub
    Private Sub trvFld_AfterExpand(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles trvFld.AfterExpand
        GetSubNode(e.Node)
        For Each item In e.Node.Nodes
            GetSubNode(item)
        Next
        Dim l As ImageList = ListFile.LargeImageList
        ListFile.Items.Clear()
        pnAddfolder.Tag = e.Node.Name
        Dim _dt As DataTable = MyFileSys.Gettable("EXEC xp_dirtree '" & e.Node.Name & "',1,1")
        For Each item In _dt.Rows
            If item!file = 1 Then
                Dim ix As New ListViewItem()
                ix.Text = item!subdirectory.ToString
                Dim extentf As String = (New IO.FileInfo(trvFld.SelectedNode.Name & "\" & item!subdirectory.ToString)).Extension
                If Not l.Images.ContainsKey(extentf) Then
                    l.Images.Add(extentf, My.Resources.report)
                    ListFile.LargeImageList = l
                    ListFile.SmallImageList = l
                End If
                ix.ImageKey = extentf
                ListFile.Items.Add(ix)
            End If
        Next
        SelectFld = e.Node.Name
    End Sub

    Private Sub btnSelect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelect.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
    End Sub

    Private Sub picDownload_Click(sender As Object, e As EventArgs) Handles picDownload.Click
        If Me.ListFile.SelectedItems.Count = 0 Then Return
        Dim _pathfile As String = Me.SelectFld & "\" & Me.ListFile.SelectedItems(0).Text
        Dim fileif As New IO.FileInfo(_pathfile)
        Dim _byte() As Byte = Me.MyFileSys.GetFile(_pathfile)
        If _byte IsNot Nothing Then
            Dim svf As New SaveFileDialog()
            svf.Filter = fileif.Extension & " File|*" & fileif.Extension
            If svf.ShowDialog = DialogResult.OK Then
                IO.File.WriteAllBytes(svf.FileName, _byte)
            End If
        End If
    End Sub

    Private Sub picUpload_Click(sender As Object, e As EventArgs) Handles picUpload.Click
        Dim opf As New OpenFileDialog()
        If opf.ShowDialog = DialogResult.OK Then
            Dim fileif As New IO.FileInfo(opf.FileName)
            MyFileSys.SetFile(Me.SelectFld & "\" & fileif.Name, opf.FileName)
        End If
    End Sub
End Class