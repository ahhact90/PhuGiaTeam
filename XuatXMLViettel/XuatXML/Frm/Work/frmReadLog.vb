Public Class frmReadLog
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
    Private Sub btnReadlog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReadlog.Click
        Dim _s() As String = txtLogFile.Text.Split(New String() {ChrW(10), ChrW(13)}, StringSplitOptions.RemoveEmptyEntries)
        If Not chkLayCaLoi.Checked Then
            txtResult.Text = Join((From p In _s Where p Like "*.xml*" Select GetMaKCB(p)).ToArray, vbNewLine)
        Else
            txtResult.Text = Join((From p In _s Where p Like "*.xml*" Select p.Substring(p.LastIndexOf(".xml") - 10, 10)).ToArray, vbNewLine)
        End If
    End Sub

    Private Sub btnXoayNgang_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnXoayNgang.Click
        Dim _s() As String = txtResult.Text.Split(New String() {ChrW(10), ChrW(13)}, StringSplitOptions.RemoveEmptyEntries)
        txtResult.Text = Join(_s, ",")
    End Sub
#End Region
#Region "Panel"

#End Region
#Region "PicBox"

#End Region
#Region "LBL"
    Private Sub lblLoadTuFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblLoadTuFile.Click
        Dim fff As New OpenFileDialog()
        If fff.ShowDialog = vbOK Then
            lblLoadTuFile.Text = fff.FileName
            txtLogFile.Text = IO.File.ReadAllText(fff.FileName)
        End If
    End Sub
#End Region
#End Region
#Region "Other"
    Sub SetExtentParam()

    End Sub
    Function GetMaKCB(ByVal S As String) As String
        Dim _s() As String = S.Substring(S.LastIndexOf("\") + 1).Split("_")
        Return _s(1)
    End Function
#End Region

    Private Sub btnTach2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTach2.Click
        Dim _s() As String = txtLogFile.Text.Split(New String() {ChrW(10), ChrW(13)}, StringSplitOptions.RemoveEmptyEntries)
        For Each item In _s
            Dim idx As Integer = item.IndexOf("mã liên kết : ")
            If idx >= 0 Then
                txtResult.Text &= vbNewLine & item.Substring(idx + "mã liên kết : ".Length, 10)
            End If
        Next
    End Sub
End Class