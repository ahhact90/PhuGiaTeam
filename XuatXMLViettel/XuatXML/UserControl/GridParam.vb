Imports System.ComponentModel
Imports System.Drawing.Design

Public Class GridParam
    Inherits DataGridView
#Region "Var"
    Public Event SelectChange(ByVal sender As GridParam)
    Private PrGoc As Control
#End Region
#Region "PRP"
#Region "Var"
    Private MaxSizePic_ As Integer = 14
#End Region
#Region "PRP"
    ''' <summary>
    ''' Kích thước tối đa ảnh mũi tên
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Browsable(True)>
    Public Property MaxSizePic As Integer
        Get
            Return MaxSizePic_
        End Get
        Set(ByVal value As Integer)
            MaxSizePic_ = value
            setPointExpant()
        End Set
    End Property
    ''' <summary>
    ''' Lấy ra các value đã chọn
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property SelectParam(ByVal c As DataGridViewColumn) As String
        Get
            Dim _dtS As DataTable
            If Me.DataSource Is Nothing Then Return ""
            If TypeOf Me.DataSource Is DataTable Then _dtS = Me.DataSource Else _dtS = CType(Me.DataSource, DataView).Table
            If c Is Nothing Then Return ""
            If String.IsNullOrEmpty(c.DataPropertyName) Then Return ""
            If _dtS Is Nothing Then Return ""
            If Not _dtS.Columns.Contains("chon") Then Return ""
            Dim _dtt As String = _dtS.Columns(c.DataPropertyName).DataType.Name
            Dim _sReturn As String = ""
            For Each dr In _dtS.Rows
                If Not String.IsNullOrEmpty(dr!chon.ToString) AndAlso dr!chon Then
                    _sReturn &= If(String.IsNullOrEmpty(_sReturn), "", ",") & If(_dtt.ToLower = "string", "'", "") & dr(c.DataPropertyName) & If(_dtt.ToLower = "string", "'", "")
                End If
            Next
            Return _sReturn
        End Get
        Set(ByVal value As String)
            If Me.DataSource Is Nothing Then Return
            Dim _dtS As DataTable
            If TypeOf Me.DataSource Is DataTable Then _dtS = Me.DataSource Else _dtS = CType(Me.DataSource, DataView).Table
            If c Is Nothing Then Return
            If String.IsNullOrEmpty(c.DataPropertyName) Then Return
            If _dtS Is Nothing Then Return
            If Not _dtS.Columns.Contains("chon") Then Return
            Dim _dtt As String = _dtS.Columns(c.DataPropertyName).DataType.Name
            Dim _sReturn As String = ""
            For Each dr In _dtS.Rows
                If ("," & value & ",").Contains("," & dr(c.DataPropertyName) & ",") Then
                    dr!chon = True
                Else
                    dr!chon = False
                End If
            Next
        End Set
    End Property
    ''' <summary>
    ''' Lấy ra các value đã chọn
    ''' </summary> 
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property SelectParam(ByVal s As String, Optional ByVal DataFields As String = "") As String
        Get
            If Not String.IsNullOrEmpty(DataFields) Then
                Dim qq = (From p As DataGridViewColumn In Me.Columns Where p.DataPropertyName.ToLower = DataFields.ToLower Select p).ToList
                If qq.Count > 0 Then Return SelectParam(qq(0))
            Else
                If Me.Columns(s) IsNot Nothing Then Return SelectParam(Me.Columns(s))
            End If
            Return ""
        End Get
        Set(ByVal value As String)
            If Not String.IsNullOrEmpty(DataFields) Then
                Dim qq = (From p As DataGridViewColumn In Me.Columns Where p.DataPropertyName.ToLower = DataFields.ToLower Select p).ToList
                If qq.Count > 0 Then SelectParam(qq(0)) = value
            Else
                If Me.Columns(s) IsNot Nothing Then SelectParam(Me.Columns(s)) = value
            End If
        End Set
    End Property
    ''' <summary>
    ''' Lấy ra các value đã chọn
    ''' </summary> 
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property SelectParam(ByVal i As Integer) As String
        Get
            If i < Me.Columns.Count Then Return SelectParam(Me.Columns(i))
            Return ""
        End Get
        Set(ByVal value As String)
            If i < Me.Columns.Count Then SelectParam(Me.Columns(i)) = value
        End Set
    End Property
#End Region
#End Region
#Region "ControlEvent"
#Region "DTG"
    Private Sub GridParam_CurrentCellDirtyStateChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.CurrentCellDirtyStateChanged
        If Not Me.IsCurrentCellDirty Then
            If Me.CurrentRow IsNot Nothing AndAlso Not Me.CurrentRow.IsNewRow Then
                Dim _dtS As DataTable
                If TypeOf Me.DataSource Is DataTable Then _dtS = Me.DataSource Else _dtS = CType(Me.DataSource, DataView).Table
                _dtS.DefaultView(Me.CurrentRow.Index).Row.AcceptChanges()
                RaiseEvent SelectChange(Me)
            End If
        End If
        Me.EndEdit()
    End Sub
    Private Sub GridParam_Resize(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Resize
        setPointExpant()
    End Sub
    Private Sub _ColumnHeadersHeightChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Me.ColumnHeadersHeightChanged
        setPointExpant()
    End Sub
    Public Sub VerticalScrollVisibleChange()
        setPointExpant()
    End Sub
    Private Sub GridParam_DataSourceChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.DataSourceChanged
        setPointExpant()
        If Me.DataSource IsNot Nothing Then
            Dim _dtS As DataTable
            If TypeOf Me.DataSource Is DataTable Then _dtS = Me.DataSource Else _dtS = CType(Me.DataSource, DataView).Table
            If Not _dtS.Columns.Contains("chon") Then
                _dtS.Columns.Add("chon")
            End If
            If Me.DataSource.Rows.Count < 10 Then
                Dim maxHeight = Me.DataSource.Rows.Count * Me.RowTemplate.Height + 3
                Me.MaximumSize = New Size(Me.MaximumSize.Width, maxHeight)
            End If
        End If
    End Sub
#End Region
#Region "Pic"
    Private Sub picExpant_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles picExpant.Click
        Me.Cursor = Cursors.WaitCursor
        If Me.Height < Me.MaximumSize.Height Then
            PrGoc = Me.Parent
            AddToParent(Me)
            Me.Height = Me.MaximumSize.Height

            picExpant.Image = My.Resources.updrak
        Else
            If PrGoc IsNot Nothing Then AddToControl(Me, PrGoc)
            Me.Height = Me.MinimumSize.Height
            picExpant.Image = My.Resources.downdrak
        End If
        If Me.FindForm IsNot Nothing Then
            Me.FindForm.ActiveControl = Me 
        End If
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub picExpant_MouseHover(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles picExpant.MouseHover
        If Me.Height < Me.MaximumSize.Height Then
            picExpant.Image = My.Resources.downlight
        Else
            picExpant.Image = My.Resources.uplight
        End If
    End Sub
    Private Sub picExpant_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles picExpant.MouseLeave
        If Me.Height < Me.MaximumSize.Height Then
            picExpant.Image = My.Resources.downdrak
        Else
            picExpant.Image = My.Resources.updrak
        End If
    End Sub
#End Region
#Region "Me"
    Protected Overrides Function ProcessCmdKey(ByRef msg As System.Windows.Forms.Message, ByVal keyData As System.Windows.Forms.Keys) As Boolean
        Select Case keyData
            Case Keys.Control + Keys.Down
                If Me.Height < Me.MaximumSize.Height Then
                    PrGoc = Me.Parent
                    AddToParent(Me)
                    Me.Height = Me.MaximumSize.Height
                    picExpant.Image = My.Resources.updrak
                    Me.Focus()
                    Return True
                End If
            Case Keys.Control + Keys.Up
                If Me.Height >= Me.MaximumSize.Height Then
                    If PrGoc IsNot Nothing Then AddToControl(Me, PrGoc)
                    Me.Height = Me.MinimumSize.Height
                    picExpant.Image = My.Resources.downdrak
                    Me.Focus()
                End If
        End Select
        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function
    Public Sub New()
        InitializeComponent()
    End Sub
    Private Sub _Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Validated
        If Not Me.Height < Me.MaximumSize.Height Then
            If PrGoc IsNot Nothing Then AddToControl(Me, PrGoc)
            Me.Height = Me.MinimumSize.Height
            picExpant.Image = My.Resources.downdrak
        End If
    End Sub
#End Region
#End Region
#Region "Other"
    Public Sub CheckAll(flg As Boolean)
        If Me.DataSource Is Nothing Then Return
        Dim _dtS As DataTable
        If TypeOf Me.DataSource Is DataTable Then _dtS = Me.DataSource Else _dtS = CType(Me.DataSource, DataView).Table
        If _dtS Is Nothing Then Return
        If Not _dtS.Columns.Contains("chon") Then Return
        For Each Itemx In _dtS.Rows
            Itemx!chon = flg
        Next 
    End Sub
    Public Sub setPointExpant()
        Me.Cursor = Cursors.WaitCursor
        If picExpant.Visible Then
            picExpant.Height = Me.ColumnHeadersHeight - 6
            If picExpant.Height > MaxSizePic Then picExpant.Height = MaxSizePic
            picExpant.Width = picExpant.Height
            picExpant.Top = (Me.ColumnHeadersHeight - picExpant.Height) / 2
            picExpant.Left = Me.Width - (Me.ColumnHeadersHeight - picExpant.Height) / 2 - If(Me.VerticalScrollBar.Visible, Me.VerticalScrollBar.Width, 0) - picExpant.Width
            picExpant.BringToFront()
        End If
        Me.Cursor = Cursors.Default
    End Sub
#End Region
End Class

