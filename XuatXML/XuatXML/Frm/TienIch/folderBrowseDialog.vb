Imports System.IO

Public Class folderBrowseDialog
    Private SelectFolder_ As String
    Private NoFidFLD As Boolean = False
    Protected Overrides Function ProcessCmdKey(ByRef msg As System.Windows.Forms.Message, ByVal keyData As System.Windows.Forms.Keys) As Boolean
        If keyData = Keys.Enter AndAlso Me.ActiveControl Is txtfldSelect Then
            SelectFolder = txtfldSelect.Text
        End If
        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function
    Property SelectFolder As String
        Get
            Return SelectFolder_
        End Get
        Set(ByVal value As String)
            SelectFolder_ = value
            FindFolder(trvFLD, 0)
        End Set
    End Property
    Public Sub FindFolder(ByVal c As Object, ByVal lever As Integer)
        If NoFidFLD Then Return
        GetSubNode(c)
        Dim _ds() As String = SelectFolder_.Split("\")
        Dim findS As String = ""

        For i = 0 To _ds.Length - 1
            If i > lever Then Continue For
            findS &= If(String.IsNullOrEmpty(findS), "", "\") & _ds(i)
        Next

        Dim p As Object

        If TypeOf c Is TreeView Then
            p = (From q In CType(c, TreeView).Nodes Where q.Name.ToString.ToLower = findS.ToLower Select q).ToList
        Else
            p = (From q In CType(c, TreeNode).Nodes Where q.Name.ToString.ToLower = findS.ToLower Select q).ToList
        End If
        If p.Count = 0 Then Return
        If findS.ToLower = SelectFolder_.ToLower Then
            trvFLD.SelectedNode = p(0)
            Me.ActiveControl = trvFLD
            Exit Sub
        Else
            FindFolder(p(0), lever + 1)
        End If
    End Sub
    Private Sub folderBrowseDialog_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
    Sub GetSubNode(ByVal nodepr As Object)
        Try
            Dim _dsFLD() As String = IO.Directory.GetDirectories(nodepr.Name & "\")
            For Each item In _dsFLD
                If item.Contains("$") Then Continue For
                Dim node As New TreeNode((New DirectoryInfo(item)).Name)
                node.Name = item
                node.ImageIndex = 0
                If TypeOf nodepr Is TreeNode Then
                    Dim q = (From p As TreeNode In CType(nodepr, TreeNode).Nodes Where p.Name = node.Name Select p).Count
                    If q = 0 Then nodepr.Nodes.Add(node)
                Else
                    Dim q = (From p As TreeNode In CType(nodepr, TreeView).Nodes Where p.Name = node.Name Select p).Count
                    If q = 0 Then nodepr.Nodes.Add(node)
                End If
            Next
        Catch ex As Exception
        End Try
    End Sub
    Private Sub trvFld_AfterExpand(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles trvFLD.AfterExpand
        GetSubNode(e.Node)
        For Each item In e.Node.Nodes
            GetSubNode(item)
        Next
        SelectFolder = e.Node.Name
        NoFidFLD = True
        txtfldSelect.Text = e.Node.Name
        NoFidFLD = False
    End Sub
    Private Sub trvFld_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles trvFLD.AfterSelect
        GetSubNode(e.Node)
        For Each item In e.Node.Nodes
            GetSubNode(item)
        Next
        SelectFolder = e.Node.Name
        NoFidFLD = True
        txtfldSelect.Text = e.Node.Name
        NoFidFLD = False
    End Sub

    Public Sub New()
        InitializeComponent()
        For Each item As DriveInfo In IO.DriveInfo.GetDrives()
            Dim node As New TreeNode(item.Name)
            node.Name = item.Name.Replace("\", "")
            trvFLD.Nodes.Add(node)
        Next
        For Each item As TreeNode In trvFLD.Nodes
            GetSubNode(item)
        Next
        Dim img As New ImageList()
        img.Images.Add(picSaveAnh.Image)
        trvFLD.ImageList = img
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

End Class