Public Class frmConfig
    Inherits frmPRTienIch
#Region "Private Var"
    ''' <summary>
    ''' TXT trên lưới
    ''' </summary>
    ''' <remarks></remarks>
    Private WithEvents txtDTG As TextBox
#End Region
#Region "Var Property"

#End Region
#Region "Property"

#End Region
#Region "FormControlEvent"
#Region "Form"
    Private Sub _Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated

    End Sub
    Private Sub _Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.NotDesignMode = True
        SetExtentParam()
        lblduongdan.Text = mini.ReadString("savefolder", "Chọn đường dẫn", Me.Name)
    End Sub
    Protected Overrides Function ProcessCmdKey(ByRef msg As System.Windows.Forms.Message, ByVal keyData As System.Windows.Forms.Keys) As Boolean
        Dim _ActiveControl As Control = Me.ActiveControl
        If _ActiveControl IsNot Nothing AndAlso TypeOf _ActiveControl Is SplitContainer Then
            _ActiveControl = CType(_ActiveControl, SplitContainer).ActiveControl
        End If
        Dim dtg As DataGridView = Nothing
        If _ActiveControl IsNot Nothing AndAlso _ActiveControl Is txtDTG Then dtg = CType(_ActiveControl, Object).EditingControlDataGridView

        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function
    Private Sub _Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        NgayAD.ReadOnly = True
        makk.ReadOnly = True
        aReady = True
    End Sub
#End Region
#Region "DTG"

#End Region
#Region "CHK"

#End Region
#Region "TXT"

#End Region
#Region "CBX"

#End Region
#Region "BTN"

#End Region
#Region "Panel"

#End Region
#Region "PicBox"

#End Region
#Region "LBL"

#End Region
#End Region
#Region "Other"
    Sub SetExtentParam()
        SetDataSource(dbHis.GetTable("select name from sys.columns where object_id=object_id('dmdichvu')"), "name", "name", CotDL)
        SetDataSource(dbHis.GetTable("select makk,tenkk from " & dbHis.DatabaseName & "..dmkk where maloaikk=2"), "makk", "tenkk", makk)
        SetDataSource(dbHis.GetTable("select name from sys.columns where object_id=object_id('dmthuocvattu')"), "name", "name", cbxDSCotThuoc)
        Dim _dt As DataTable = dbXML.GetTable("select * from tblconfigcolumn where dichvu = 0")
        If _dt.Rows.Count > 0 Then
            cbxDSCotThuoc.SelectedValue = _dt.Rows(0)!cotdl.ToString
        End If
        Dim _SQL As String = <SQL>
select b1.ngayad,b2.CotDL,b2.DichVu from 
(select distinct ngayad from {0}..tendvtheongay) b1
left join {1}..tblConfigColumn b2 on b1.ngayad=b2.NgayAD
order by DichVu
                             </SQL>
        _SQL = String.Format(_SQL, dbHis.DatabaseName, dbXML.DatabaseName)
        dtgCotDV.AutoGenerateColumns = False
        dtgCotDV.DataSource = dbHis.GetTable(_SQL)
        _SQL = <SQL>
select b1.makk,b2.madonvi,b2.maxml
From {0}..dmkk b1
left join {1}..tblconfigkk b2 on b1.makk = b2.makk
where maloaikk=2
               </SQL>
        dtgTLKK.DataSource = dbHis.GetTable(String.Format(_SQL, dbHis.DatabaseName, dbXML.DatabaseName))
    End Sub

    Private Sub cbxDSCotThuoc_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxDSCotThuoc.SelectedIndexChanged
        If cbxDSCotThuoc.SelectedValue Is Nothing Then Return
        If Not aReady Then Return
        Dim _dt As DataTable = dbXML.GetTable("select * from tblconfigcolumn where dichvu = 0")
        If _dt.Rows.Count = 0 Then
            _dt.Rows.Add(_dt.NewRow)
        End If
        _dt.Rows(0)!ngayad = "01/01/1900"
        _dt.Rows(0)!cotdl = cbxDSCotThuoc.SelectedValue.ToString
        _dt.Rows(0)!dichvu = 0
        dbXML.UpdateData(_dt, "select * from tblconfigcolumn")
    End Sub

    Private Sub dtgCotDV_CSTC(sender As Object, e As EventArgs) Handles dtgCotDV.CurrentCellDirtyStateChanged
        If Not dtgCotDV.IsCurrentCellDirty Then
            Dim _dr As DataRow = dtgCotDV.DataSource.DefaultView(dtgCotDV.CurrentRow.Index).Row
            If Not String.IsNullOrEmpty(_dr!cotdl.ToString) Then
                Dim _dt As DataTable = dbXML.GetTable("select * from tblconfigcolumn where ngayad = '" & CDate(_dr!ngayad.ToString).ToString("dd/MM/yyyy") & "' and dichvu=1 and cotdl = N'" & _dr!cotdl.ToString & "'")
                If _dt.Rows.Count = 0 Then
                    _dt.Rows.Add(_dt.NewRow)
                End If
                _dt.Rows(0)!ngayad = _dr!ngayad
                _dt.Rows(0)!dichvu = 1
                _dt.Rows(0)!cotdl = _dr!cotdl.ToString
                dbXML.UpdateData(_dt, "select * from tblconfigcolumn")
            End If
        End If
        dtgCotDV.EndEdit()
    End Sub

    Private Sub dtgTLKK_CellValidated(sender As Object, e As DataGridViewCellEventArgs) Handles dtgTLKK.CellValidated
        If dtgTLKK.Columns(e.ColumnIndex).ReadOnly Then Return
        SaveKK(e.RowIndex)
        For Each item As DataGridViewRow In dtgTLKK.Rows
            If item.Index <> e.RowIndex AndAlso (item.Cells(e.ColumnIndex).Value Is Nothing OrElse item.Cells(e.ColumnIndex).Value.ToString = "") Then
                item.Cells(e.ColumnIndex).Value = dtgTLKK.Rows(e.RowIndex).Cells(e.ColumnIndex).Value
                SaveKK(item.Index)
            End If
        Next
    End Sub
    Sub SaveKK(index As Integer)
        Dim _dr As DataRow = dtgTLKK.DataSource.DefaultView(index).Row
        Dim _dt As DataTable = dbXML.GetTable("select * from tblconfigkk where makk = " & _dr!makk)
        If _dt.Rows.Count = 0 Then
            _dt.Rows.Add(_dt.NewRow)
        End If
        _dt.Rows(0)!makk = _dr!makk
        _dt.Rows(0)!madonvi = _dr!madonvi
        _dt.Rows(0)!maxml = _dr!maxml
        dbXML.UpdateData(_dt, "select * from tblconfigkk")
    End Sub

    Private Sub lblduongdan_Click(sender As Object, e As EventArgs) Handles lblduongdan.Click
        Dim ofd As New folderBrowseDialog()
        ofd.SelectFolder = lblduongdan.Text
        If ofd.ShowDialog = DialogResult.OK Then
            lblduongdan.Text = ofd.SelectFolder
            mini.WriteString("savefolder", Me.Name) = lblduongdan.Text
        End If
    End Sub
#End Region

    Private Sub btnCauHinhTheoThe_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCauHinhTheoThe.Click
        Dim fff As New frmConfigTheoThe
        fff.ShowDialog()
    End Sub
End Class