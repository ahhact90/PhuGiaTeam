Imports MyData
Imports System.Globalization
Imports System.Management
Imports System.Threading
Imports System.Reflection
Public Class frmMain
#Region "Private Var"
    ''' <summary>
    ''' TXT trên lưới
    ''' </summary>
    ''' <remarks></remarks>
    Private WithEvents txtDTG As TextBox
    Private dsMenuItem(-1) As ToolStripMenuItem
    Private notdfclose As Boolean = False

#End Region
#Region "Var Property"

#End Region
#Region "Property"

#End Region
#Region "FormControlEvent"
#Region "Form"
    Private Sub frmMain_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        If notdfclose OrElse MsgBox("Bạn chắc chắn đóng chương trình?", MsgBoxStyle.Question Or MsgBoxStyle.YesNo, "Thoát chương trình") = MsgBoxResult.Yes Then
        Else
            e.Cancel = True
        End If
    End Sub
    Private Sub frmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Dim c = New CreateXML.clsCreateXML("1700001713", dbHis.ConnectString, dbXML.ConnectString)
        
        mdiClient = (From p In Me.Controls Where TypeOf p Is MdiClient Select p).ToList(0)
        AddHandler mdiClient.Paint, AddressOf _Paint
        AddHandler mdiClient.SizeChanged, AddressOf _SizeChanged
        AddHandler mdiClient.ControlRemoved, AddressOf _ControlRemoved
        NowLBL = lblNowTime
        lblTitleMain_ = lblTitleMain
        Dim t = Now
        GetThongTinStart()
        mspmain.BackColor = MenuColor
    End Sub
    Protected Overrides Sub SetVisibleCore(ByVal value As Boolean)
        Dim flg As New frmLogin()
        If Debugger.IsAttached Then

        Else
            If Not flg.ShowDialog = Windows.Forms.DialogResult.OK Then
                End
            End If
        End If

        MyBase.SetVisibleCore(value)
    End Sub
    Private Sub frmMain_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        mnuExportForm.PerformClick()
        Me.Cursor = Cursors.Default
    End Sub
#End Region
#Region "MDI Client"
    Private Sub _Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs)
        Dim g As Graphics = sender.CreateGraphics
        Dim fontDong1 As Font = New Font("Arial", 24)
        Dim fontDong2 As Font = New Font("Arial", 22)
        Dim SizeDong1 As Size = TextRenderer.MeasureText(TenPhanMem, fontDong1)
        Dim SizeDong2 As Size = TextRenderer.MeasureText(TenPhanHe, fontDong2)
        'Dim topDong1 As Double = sender.Height / 3
        'Dim leftDong1 As Double = (sender.Width - SizeDong1.Width) / 2
        'Dim topDong2 As Double = sender.Height / 3 + SizeDong1.Height + 5
        'Dim leftDong2 As Double = (sender.Width - SizeDong2.Width) / 2
        Dim topDong1 As Double = 15
        Dim leftDong1 As Double = sender.Width - SizeDong1.Width - 25
        Dim topDong2 As Double = 55
        Dim leftDong2 As Double = leftDong1 + SizeDong1.Width / 2 - SizeDong2.Width / 2
        g.DrawString(TenPhanMem, fontDong1, Brushes.MidnightBlue, New Point(leftDong1, topDong1))
        g.DrawString(TenPhanHe, fontDong2, Brushes.MidnightBlue, New Point(leftDong2, topDong2))
    End Sub
    Private Sub _SizeChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim g As Graphics = sender.CreateGraphics
        g.Clear(Color.White)
        
        Dim fontDong1 As Font = New Font("Arial", 24)
        Dim fontDong2 As Font = New Font("Arial", 22)
        Dim SizeDong1 As Size = TextRenderer.MeasureText(TenPhanMem, fontDong1)
        Dim SizeDong2 As Size = TextRenderer.MeasureText(TenPhanHe, fontDong2)
        Dim topDong1 As Double = 15
        Dim leftDong1 As Double = sender.Width - SizeDong1.Width - 25
        Dim topDong2 As Double = 55
        Dim leftDong2 As Double = leftDong1 + SizeDong1.Width / 2 - SizeDong2.Width / 2
        g.DrawString(TenPhanMem, fontDong1, Brushes.MidnightBlue, New Point(leftDong1, topDong1))
        g.DrawString(TenPhanHe, fontDong2, Brushes.MidnightBlue, New Point(leftDong2, topDong2))
    End Sub
    Private Sub _ControlRemoved(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ControlEventArgs)
        Dim g = mdiClient.Controls
        If g.Count = 0 Then
            lblTitleMain.Text = "  Hệ thống quản lý cận lâm sàng"
        End If
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
#Region "MNU"
    Private Sub mnuReadXML_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuReadXML.Click
        openForm(New frmReadXML)
    End Sub
    Private Sub mnuSetting_Click(ByVal sender As Object, ByVal e As EventArgs) Handles mnuSetting.Click
        openForm(New frmConfig)
    End Sub
    Private Sub mnuExportForm_Click(ByVal sender As Object, ByVal e As EventArgs) Handles mnuExportForm.Click
        openForm(New frmXuatXML)
    End Sub
    Private Sub mnuTachLog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuTachLog.Click
        openForm(New frmReadLog)
    End Sub
#End Region
#Region "Timer"
    Private Sub tmUpdateTime_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmUpdateTime.Tick
        If IsDate(lblNowTime.Text) Then lblNowTime.Text = CDate(lblNowTime.Text).AddSeconds(1).ToString("dd/MM/yyyy HH:mm:ss")
    End Sub
    
#End Region
#End Region
#Region "MultipeControlEvent"


#End Region
#Region "Other"
    Sub GanMauItem(ByVal o As ToolStripMenuItem)
        ReDim Preserve dsMenuItem(dsMenuItem.Length)
        dsMenuItem(dsMenuItem.Length - 1) = o
        For Each item In o.DropDownItems
            GanMauItem(item)
        Next
    End Sub
    Private Sub ganmauhethong()
        lblTitleMain.BackColor = StartColor
        tspMain.BackColor = StartColor
        For Each item As ToolStripMenuItem In mspmain.Items
            ReDim Preserve dsMenuItem(dsMenuItem.Length)
            dsMenuItem(dsMenuItem.Length - 1) = item
            GanMauItem(item)
        Next
    End Sub
    Private Sub GetThongTinStart()
        Dim objSearcher = New ManagementObjectSearcher("SELECT * FROM Win32_NetworkAdapterConfiguration")
        For Each obj As ManagementObject In objSearcher.Get()
            If obj("DHCPEnabled") Then
                Dim sss = DirectCast(obj("IPAddress"), String())
                If sss IsNot Nothing AndAlso sss.Length > 0 AndAlso sss(0) <> "0.0.0.0" Then
                    IPMayCon = sss(0)
                End If
            End If
        Next
        Dim _scon As New SqlClient.SqlConnection(GetConnect(DuLieu.His))
        TenMayChu = _scon.DataSource
        TenMayCon = System.Windows.Forms.SystemInformation.ComputerName
        lblClient.Text = "    Máy làm việc: " & TenMayCon & "    "
        lblIpMayCon.Text = "    Ip: " & IPMayCon & "    "
        lblMayChu.Text = "    Máy chủ: " & TenMayChu & "    "
        lblUser.Text = "    Tên đăng nhập: Admin    "
        lblBuildTime.Text = "    Build: " & BuildTime & "    "
        MyFileSys.IdMay = chuyenthanhkhongdau(TenMayCon & "-" & IPMayCon.Replace(".", "")).Replace("-", "")
        MyFileSys.ConnectString = GetConnect(DuLieu.His)
    End Sub

 
#End Region


End Class