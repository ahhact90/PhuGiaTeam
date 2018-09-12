Public Class frmLogin
    Inherits frmPRTienIch 
    Protected NotOverridable Overrides Function ProcessCmdKey(ByRef msg As System.Windows.Forms.Message, ByVal KeyData As System.Windows.Forms.Keys) As Boolean
        Select Case KeyData
            Case Keys.Enter
                If Me.ActiveControl Is Me.txttendangnhap Then
                    Me.ActiveControl = Me.txtmatkhau
                    Me.txtmatkhau.SelectAll()
                    Return True
                End If
                If Me.ActiveControl Is Me.txtmatkhau Then Me.btnok.PerformClick()
            Case Keys.Escape
                Me.btnThoat.PerformClick()
        End Select
        Return False
    End Function
     
    Private Sub UI_LOGIN_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        NotDesignMode = True
        Me.lblTenPhanHe.Text = TenPhanHe
        Me.BackColor = BackGColor
        SetLBLTitle(lblTenPhanHe)
        DongBoBtn(Me.btnok, Me.btnThoat)
        Me.Timer1.Enabled = True
        Me.txttendangnhap.Text = mIni.ReadString("DangNhap", "admin", "TenDangNhap")
        Me.ActiveControl = Me.txtmatkhau
        Me.txtmatkhau.SelectAll()
    End Sub
    Private Sub btnThoat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThoat.Click
        End
    End Sub
    Private Sub btnok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnok.Click
        If Me.txttendangnhap.Text.Trim = "" OrElse Me.txtmatkhau.Text.Trim = "" Then Return

        Dim hshs = dbHis.GetTable(String.Format("select * from dmnhanvien where tendn = '{0}'", Me.txttendangnhap.Text.Replace("'", "")))
        If hshs.Rows.Count = 0 OrElse hshs.Rows(0)!MatKhau <> MaHoa(String.Format("{0}{1}", Me.txtmatkhau.Text, Me.txttendangnhap.Text.ToLower()), "BVST4.0") Then
            Me.txtmatkhau.SelectAll()
            Me.ActiveControl = Me.txtmatkhau
        Else
            TenDangNhap = Me.txttendangnhap.Text.ToLower
            mIni.WriteString("DangNhap", "TenDangNhap") = Me.txttendangnhap.Text
            MyData.IdDangNhap = hshs.Rows(0)("manv").ToString
            TenDangNhap = hshs.Rows(0)("tendn").ToString
            Me.DialogResult = Windows.Forms.DialogResult.OK
        End If
    End Sub
    Public Sub setViewQuyen()

    End Sub

    Private Sub _Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.DoubleClick
        If Control.ModifierKeys = Keys.Control Then
            Dim fff As New frmConfigConnect
            fff.ShowDialog()
        End If
    End Sub
End Class