<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.mspmain = New System.Windows.Forms.MenuStrip()
        Me.tspMain = New System.Windows.Forms.ToolStrip()
        Me.lblMayChu = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.lblClient = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.lblIpMayCon = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.lblBuildTime = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.lblUser = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.lblNowTime = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.lblTitleMain = New System.Windows.Forms.Label()
        Me.tmUpdateTime = New System.Windows.Forms.Timer(Me.components)
        Me.ttMain = New System.Windows.Forms.ToolTip(Me.components)
        Me.mnuSetting = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuExportForm = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuReadXML = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuTachLog = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuWindow = New System.Windows.Forms.ToolStripMenuItem()
        Me.mspmain.SuspendLayout()
        Me.tspMain.SuspendLayout()
        Me.SuspendLayout()
        '
        'mspmain
        '
        Me.mspmain.AutoSize = False
        Me.mspmain.Font = New System.Drawing.Font("Arial", 10.0!)
        Me.mspmain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuSetting, Me.mnuExportForm, Me.mnuReadXML, Me.mnuTachLog, Me.mnuWindow})
        Me.mspmain.Location = New System.Drawing.Point(0, 0)
        Me.mspmain.MdiWindowListItem = Me.mnuWindow
        Me.mspmain.Name = "mspmain"
        Me.mspmain.Padding = New System.Windows.Forms.Padding(7, 2, 0, 2)
        Me.mspmain.Size = New System.Drawing.Size(875, 30)
        Me.mspmain.TabIndex = 0
        Me.mspmain.Text = "MenuStrip1"
        '
        'tspMain
        '
        Me.tspMain.AutoSize = False
        Me.tspMain.BackColor = System.Drawing.Color.FromArgb(CType(CType(41, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(85, Byte), Integer))
        Me.tspMain.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.tspMain.Font = New System.Drawing.Font("Arial", 10.0!)
        Me.tspMain.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.tspMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblMayChu, Me.ToolStripSeparator1, Me.lblClient, Me.ToolStripSeparator2, Me.lblIpMayCon, Me.ToolStripSeparator3, Me.lblBuildTime, Me.ToolStripSeparator4, Me.lblUser, Me.ToolStripSeparator5, Me.lblNowTime, Me.ToolStripSeparator6})
        Me.tspMain.Location = New System.Drawing.Point(0, 352)
        Me.tspMain.Name = "tspMain"
        Me.tspMain.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.tspMain.Size = New System.Drawing.Size(875, 30)
        Me.tspMain.TabIndex = 1
        Me.tspMain.Text = "ToolStrip1"
        '
        'lblMayChu
        '
        Me.lblMayChu.ForeColor = System.Drawing.Color.White
        Me.lblMayChu.Name = "lblMayChu"
        Me.lblMayChu.Size = New System.Drawing.Size(50, 27)
        Me.lblMayChu.Text = "Server"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 30)
        '
        'lblClient
        '
        Me.lblClient.ForeColor = System.Drawing.Color.White
        Me.lblClient.Name = "lblClient"
        Me.lblClient.Size = New System.Drawing.Size(44, 27)
        Me.lblClient.Text = "Client"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 30)
        '
        'lblIpMayCon
        '
        Me.lblIpMayCon.ForeColor = System.Drawing.Color.White
        Me.lblIpMayCon.Name = "lblIpMayCon"
        Me.lblIpMayCon.Size = New System.Drawing.Size(56, 27)
        Me.lblIpMayCon.Text = "IPClient"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 30)
        '
        'lblBuildTime
        '
        Me.lblBuildTime.ForeColor = System.Drawing.Color.White
        Me.lblBuildTime.Name = "lblBuildTime"
        Me.lblBuildTime.Size = New System.Drawing.Size(73, 27)
        Me.lblBuildTime.Text = "Build Time"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 30)
        '
        'lblUser
        '
        Me.lblUser.ForeColor = System.Drawing.Color.White
        Me.lblUser.Name = "lblUser"
        Me.lblUser.Size = New System.Drawing.Size(37, 27)
        Me.lblUser.Text = "User"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 30)
        '
        'lblNowTime
        '
        Me.lblNowTime.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.lblNowTime.ForeColor = System.Drawing.Color.White
        Me.lblNowTime.Name = "lblNowTime"
        Me.lblNowTime.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblNowTime.Size = New System.Drawing.Size(120, 27)
        Me.lblNowTime.Text = "99/99/9999 99:99"
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(6, 30)
        '
        'lblTitleMain
        '
        Me.lblTitleMain.BackColor = System.Drawing.Color.FromArgb(CType(CType(41, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(85, Byte), Integer))
        Me.lblTitleMain.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblTitleMain.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitleMain.ForeColor = System.Drawing.Color.White
        Me.lblTitleMain.Location = New System.Drawing.Point(0, 30)
        Me.lblTitleMain.Name = "lblTitleMain"
        Me.lblTitleMain.Size = New System.Drawing.Size(875, 30)
        Me.lblTitleMain.TabIndex = 3
        Me.lblTitleMain.Text = "  Xuất XML"
        Me.lblTitleMain.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tmUpdateTime
        '
        Me.tmUpdateTime.Enabled = True
        Me.tmUpdateTime.Interval = 1000
        '
        'mnuSetting
        '
        Me.mnuSetting.Image = Global.XMLCreator.My.Resources.Resources.config1
        Me.mnuSetting.Name = "mnuSetting"
        Me.mnuSetting.Size = New System.Drawing.Size(141, 26)
        Me.mnuSetting.Text = "Cài đặt hệ thống"
        '
        'mnuExportForm
        '
        Me.mnuExportForm.Image = Global.XMLCreator.My.Resources.Resources.crystal_xml
        Me.mnuExportForm.Name = "mnuExportForm"
        Me.mnuExportForm.Size = New System.Drawing.Size(95, 26)
        Me.mnuExportForm.Text = "Xuất XML"
        '
        'mnuReadXML
        '
        Me.mnuReadXML.Image = Global.XMLCreator.My.Resources.Resources.List
        Me.mnuReadXML.Name = "mnuReadXML"
        Me.mnuReadXML.Size = New System.Drawing.Size(110, 26)
        Me.mnuReadXML.Text = "Đọc lại XML"
        '
        'mnuTachLog
        '
        Me.mnuTachLog.Image = Global.XMLCreator.My.Resources.Resources.infomation
        Me.mnuTachLog.Name = "mnuTachLog"
        Me.mnuTachLog.Size = New System.Drawing.Size(162, 26)
        Me.mnuTachLog.Text = "Tách mã kcb từ Log"
        '
        'mnuWindow
        '
        Me.mnuWindow.Image = Global.XMLCreator.My.Resources.Resources.windown
        Me.mnuWindow.Name = "mnuWindow"
        Me.mnuWindow.Size = New System.Drawing.Size(82, 26)
        Me.mnuWindow.Text = "Cửa sổ"
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(875, 382)
        Me.Controls.Add(Me.lblTitleMain)
        Me.Controls.Add(Me.tspMain)
        Me.Controls.Add(Me.mspmain)
        Me.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.IsMdiContainer = True
        Me.MainMenuStrip = Me.mspmain
        Me.Name = "frmMain"
        Me.Text = "Xuất XML"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.mspmain.ResumeLayout(False)
        Me.mspmain.PerformLayout()
        Me.tspMain.ResumeLayout(False)
        Me.tspMain.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents mspmain As System.Windows.Forms.MenuStrip
    Friend WithEvents tspMain As System.Windows.Forms.ToolStrip
    Friend WithEvents lblMayChu As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents lblClient As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents lblBuildTime As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents lblUser As System.Windows.Forms.ToolStripLabel
    Friend WithEvents lblTitleMain As System.Windows.Forms.Label
    Friend WithEvents lblIpMayCon As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents lblNowTime As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tmUpdateTime As System.Windows.Forms.Timer
    Friend WithEvents ttMain As System.Windows.Forms.ToolTip
    Friend WithEvents mnuSetting As ToolStripMenuItem
    Friend WithEvents mnuExportForm As ToolStripMenuItem
    Friend WithEvents mnuWindow As ToolStripMenuItem
    Friend WithEvents mnuReadXML As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuTachLog As System.Windows.Forms.ToolStripMenuItem
End Class
