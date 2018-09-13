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
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.btnThoat = New System.Windows.Forms.Button()
        Me.btnGetData = New System.Windows.Forms.Button()
        Me.btnStartTime = New System.Windows.Forms.Button()
        Me.btnStopTime = New System.Windows.Forms.Button()
        Me.FlowLayoutPanel2 = New System.Windows.Forms.FlowLayoutPanel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtTime = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtFolderXML = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtFolderDB = New System.Windows.Forms.TextBox()
        Me.ntfMain = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuShow = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuGetData = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuClose = New System.Windows.Forms.ToolStripMenuItem()
        Me.txtLog = New System.Windows.Forms.TextBox()
        Me.Panel1.SuspendLayout()
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.FlowLayoutPanel2.SuspendLayout()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 10000
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.FlowLayoutPanel1)
        Me.Panel1.Controls.Add(Me.FlowLayoutPanel2)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 406)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1003, 30)
        Me.Panel1.TabIndex = 2
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.Controls.Add(Me.btnThoat)
        Me.FlowLayoutPanel1.Controls.Add(Me.btnGetData)
        Me.FlowLayoutPanel1.Controls.Add(Me.btnStartTime)
        Me.FlowLayoutPanel1.Controls.Add(Me.btnStopTime)
        Me.FlowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FlowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(554, 0)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(449, 30)
        Me.FlowLayoutPanel1.TabIndex = 2
        '
        'btnThoat
        '
        Me.btnThoat.Location = New System.Drawing.Point(373, 1)
        Me.btnThoat.Margin = New System.Windows.Forms.Padding(1)
        Me.btnThoat.Name = "btnThoat"
        Me.btnThoat.Size = New System.Drawing.Size(75, 28)
        Me.btnThoat.TabIndex = 0
        Me.btnThoat.Text = "&Exit"
        Me.btnThoat.UseVisualStyleBackColor = True
        '
        'btnGetData
        '
        Me.btnGetData.Location = New System.Drawing.Point(296, 1)
        Me.btnGetData.Margin = New System.Windows.Forms.Padding(1)
        Me.btnGetData.Name = "btnGetData"
        Me.btnGetData.Size = New System.Drawing.Size(75, 28)
        Me.btnGetData.TabIndex = 1
        Me.btnGetData.Text = "&Get data"
        Me.btnGetData.UseVisualStyleBackColor = True
        '
        'btnStartTime
        '
        Me.btnStartTime.Location = New System.Drawing.Point(219, 1)
        Me.btnStartTime.Margin = New System.Windows.Forms.Padding(1)
        Me.btnStartTime.Name = "btnStartTime"
        Me.btnStartTime.Size = New System.Drawing.Size(75, 28)
        Me.btnStartTime.TabIndex = 2
        Me.btnStartTime.Text = "&Auto get"
        Me.btnStartTime.UseVisualStyleBackColor = True
        '
        'btnStopTime
        '
        Me.btnStopTime.Location = New System.Drawing.Point(127, 1)
        Me.btnStopTime.Margin = New System.Windows.Forms.Padding(1)
        Me.btnStopTime.Name = "btnStopTime"
        Me.btnStopTime.Size = New System.Drawing.Size(90, 28)
        Me.btnStopTime.TabIndex = 3
        Me.btnStopTime.Text = "&Stop Auto"
        Me.btnStopTime.UseVisualStyleBackColor = True
        '
        'FlowLayoutPanel2
        '
        Me.FlowLayoutPanel2.Controls.Add(Me.Label1)
        Me.FlowLayoutPanel2.Controls.Add(Me.txtTime)
        Me.FlowLayoutPanel2.Controls.Add(Me.Label2)
        Me.FlowLayoutPanel2.Controls.Add(Me.txtFolderXML)
        Me.FlowLayoutPanel2.Controls.Add(Me.Label3)
        Me.FlowLayoutPanel2.Controls.Add(Me.txtFolderDB)
        Me.FlowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Left
        Me.FlowLayoutPanel2.Location = New System.Drawing.Point(0, 0)
        Me.FlowLayoutPanel2.Name = "FlowLayoutPanel2"
        Me.FlowLayoutPanel2.Size = New System.Drawing.Size(554, 30)
        Me.FlowLayoutPanel2.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(8, 8)
        Me.Label1.Margin = New System.Windows.Forms.Padding(8, 8, 0, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(44, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Time(s):"
        '
        'txtTime
        '
        Me.txtTime.Location = New System.Drawing.Point(52, 4)
        Me.txtTime.Margin = New System.Windows.Forms.Padding(0, 4, 5, 5)
        Me.txtTime.Name = "txtTime"
        Me.txtTime.Size = New System.Drawing.Size(32, 20)
        Me.txtTime.TabIndex = 1
        Me.txtTime.Text = "10"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(89, 8)
        Me.Label2.Margin = New System.Windows.Forms.Padding(0, 8, 0, 8)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(64, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Folder XML:"
        '
        'txtFolderXML
        '
        Me.txtFolderXML.Location = New System.Drawing.Point(153, 4)
        Me.txtFolderXML.Margin = New System.Windows.Forms.Padding(0, 4, 5, 5)
        Me.txtFolderXML.Name = "txtFolderXML"
        Me.txtFolderXML.Size = New System.Drawing.Size(121, 20)
        Me.txtFolderXML.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(279, 8)
        Me.Label3.Margin = New System.Windows.Forms.Padding(0, 8, 0, 8)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(57, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Folder DB:"
        '
        'txtFolderDB
        '
        Me.txtFolderDB.Location = New System.Drawing.Point(336, 4)
        Me.txtFolderDB.Margin = New System.Windows.Forms.Padding(0, 4, 5, 5)
        Me.txtFolderDB.Name = "txtFolderDB"
        Me.txtFolderDB.Size = New System.Drawing.Size(121, 20)
        Me.txtFolderDB.TabIndex = 5
        '
        'ntfMain
        '
        Me.ntfMain.ContextMenuStrip = Me.ContextMenuStrip1
        Me.ntfMain.Icon = CType(resources.GetObject("ntfMain.Icon"), System.Drawing.Icon)
        Me.ntfMain.Text = "Chuyển dữ liệu xml nội viện sang SQLite"
        Me.ntfMain.Visible = True
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuShow, Me.ToolStripMenuItem1, Me.mnuGetData, Me.ToolStripMenuItem2, Me.mnuClose})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(119, 82)
        '
        'mnuShow
        '
        Me.mnuShow.Name = "mnuShow"
        Me.mnuShow.Size = New System.Drawing.Size(118, 22)
        Me.mnuShow.Text = "Show"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(115, 6)
        '
        'mnuGetData
        '
        Me.mnuGetData.Name = "mnuGetData"
        Me.mnuGetData.Size = New System.Drawing.Size(118, 22)
        Me.mnuGetData.Text = "Get data"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(115, 6)
        '
        'mnuClose
        '
        Me.mnuClose.Name = "mnuClose"
        Me.mnuClose.Size = New System.Drawing.Size(118, 22)
        Me.mnuClose.Text = "Thoát"
        '
        'txtLog
        '
        Me.txtLog.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtLog.Font = New System.Drawing.Font("Times New Roman", 10.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(163, Byte))
        Me.txtLog.ForeColor = System.Drawing.Color.DarkGray
        Me.txtLog.Location = New System.Drawing.Point(0, 0)
        Me.txtLog.Multiline = True
        Me.txtLog.Name = "txtLog"
        Me.txtLog.Size = New System.Drawing.Size(1003, 406)
        Me.txtLog.TabIndex = 4
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1003, 436)
        Me.Controls.Add(Me.txtLog)
        Me.Controls.Add(Me.Panel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmMain"
        Me.Text = "Form1"
        Me.Panel1.ResumeLayout(False)
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.FlowLayoutPanel2.ResumeLayout(False)
        Me.FlowLayoutPanel2.PerformLayout()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents FlowLayoutPanel1 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents btnThoat As System.Windows.Forms.Button
    Friend WithEvents btnGetData As System.Windows.Forms.Button
    Friend WithEvents btnStartTime As System.Windows.Forms.Button
    Friend WithEvents btnStopTime As System.Windows.Forms.Button
    Friend WithEvents FlowLayoutPanel2 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtTime As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtFolderXML As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtFolderDB As System.Windows.Forms.TextBox
    Friend WithEvents ntfMain As System.Windows.Forms.NotifyIcon
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents mnuShow As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuGetData As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuClose As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents txtLog As System.Windows.Forms.TextBox

End Class
