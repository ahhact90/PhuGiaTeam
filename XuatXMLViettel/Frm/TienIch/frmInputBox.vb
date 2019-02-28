Imports System.Windows.Forms
Public Class frmInputBox
    Protected NotOverridable Overrides Function ProcessCmdKey(ByRef msg As System.Windows.Forms.Message, ByVal KeyData As System.Windows.Forms.Keys) As Boolean
        
        Return False
    End Function
    Private ClickOK As Boolean = False
    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        If Not cmb AndAlso (Style = FMstyle.SoNguyen OrElse Style = FMstyle.SoThuc) Then
            If Not Min Is Nothing AndAlso txtGiatri.Text * 1 < Min Then
                lblErr.Text = "Giá trị phải >= " & Min
                Timer1.Enabled = True
                txtGiatri.Focus()
                txtGiatri.SelectAll()
                Return
            End If
            If Not Max Is Nothing AndAlso txtGiatri.Text * 1 > Max Then
                lblErr.Text = "Giá trị phải <= " & Max
                Timer1.Enabled = True
                txtGiatri.Focus()
                txtGiatri.SelectAll()
                Return
            End If
        End If
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        ClickOK = True
        Me.Close()
    End Sub
    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
   
    Private Style As FMstyle, cmb As Boolean, tblSource As DataTable, Dis, VaMem As String
    Private Min, Max As Object, Wi As Integer
    Private PassWord, cboS As Boolean, PassChar As String
    Public Sub New(ByVal Prompt As String, ByVal Tiltle As String, ByVal Value As String, Optional ByVal mStyle As FMstyle = FMstyle.obj, Optional ByVal cbo As Boolean = False, Optional ByVal cboSource As DataTable = Nothing, Optional ByVal DisplayMember As String = "", Optional ByVal ValueMember As String = "", Optional ByVal TextOK As String = "Đồng ý", Optional ByVal TextCancel As String = "Bỏ qua", Optional ByVal Min As Object = Nothing, Optional ByVal Max As Object = Nothing, Optional ByVal Pass As Boolean = False, Optional ByVal Pchar As String = "", Optional ByVal DisableCancel As Boolean = False, Optional ByVal AllowSearch As Boolean = False, Optional ByVal _Width As Integer = 340)
        InitializeComponent()
        lbltitle.Text = Prompt
        Me.Text = Tiltle
        txtGiatri.Text = Value
        Style = mStyle
        cmb = cbo
        tblSource = cboSource
        Dis = DisplayMember
        VaMem = ValueMember
        OK_Button.Text = TextOK
        Cancel_Button.Text = TextCancel
        Me.Min = Min
        Me.Max = Max
        PassWord = Pass
        PassChar = Pchar
        cboS = AllowSearch
        Wi = _Width
        If DisableCancel Then Cancel_Button.Enabled = False
    End Sub
    Private Sub UI_inputBox_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Timer1.Enabled = False
        lblErr.Visible = False
        cmbGiatri.Width = txtGiatri.Width
        cmbGiatri.Location = txtGiatri.Location
        cmbGiatri.Visible = cmb
        txtGiatri.Visible = Not cmb
        If PassWord Then txtGiatri.PasswordChar = PassChar Else txtGiatri.PasswordChar = ""
        If cmb Then
            cmbGiatri.DataSource = tblSource
            cmbGiatri.DisplayMember = Dis
            cmbGiatri.ValueMember = VaMem
            Me.ActiveControl = cmbGiatri
            If cmbGiatri.Items.Count > 0 Then
                If txtGiatri.Text = "" Then
                    cmbGiatri.SelectedIndex = 0
                Else
                    cmbGiatri.SelectedValue = txtGiatri.Text
                End If
            End If
        Else
            Me.ActiveControl = txtGiatri
            txtGiatri.SelectAll()
        End If
        If cmb AndAlso cboS Then
            cmbGiatri.DropDownStyle = ComboBoxStyle.DropDown
            cmbGiatri.AutoCompleteMode = AutoCompleteMode.Suggest
            cmbGiatri.AutoCompleteSource = AutoCompleteSource.ListItems
        End If
        Me.Width = Wi

    End Sub
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        lblErr.Visible = Not lblErr.Visible
    End Sub
    Private Sub txtGiatri_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtGiatri.TextChanged
        Timer1.Enabled = False
        lblErr.Visible = False
    End Sub
    Private Sub lbltitle_SizeChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbltitle.SizeChanged
        Me.Height = lbltitle.Height + 138
    End Sub
    Private Sub UI_inputBox_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        If Not Cancel_Button.Enabled AndAlso Not ClickOK Then
            e.Cancel = True
            MsgBox("Vui lòng chọn 1 lý do và bấm nút Đồng ý", MsgBoxStyle.OkOnly Or MsgBoxStyle.Critical, "Thông báo")
        End If
    End Sub
End Class
