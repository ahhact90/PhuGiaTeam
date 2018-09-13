<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSqlServer
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
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.trvDatabase = New System.Windows.Forms.TreeView()
        Me.tabCTr = New System.Windows.Forms.TabControl()
        Me.ctxTab = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuOpenTab = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuNewQuery = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuDesignTab = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuClose = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuCloseAllButThis = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuCloseAllRight = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuCloseAllLeft = New System.Windows.Forms.ToolStripMenuItem()
        Me.pnAction = New System.Windows.Forms.Panel()
        Me.txtFindTab = New System.Windows.Forms.TextBox()
        Me.picKey = New System.Windows.Forms.PictureBox()
        Me.picInfomation = New System.Windows.Forms.PictureBox()
        Me.picRunSql = New System.Windows.Forms.PictureBox()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.ctxTab.SuspendLayout()
        Me.pnAction.SuspendLayout()
        CType(Me.picKey, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picInfomation, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picRunSql, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 28)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.trvDatabase)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.tabCTr)
        Me.SplitContainer1.Size = New System.Drawing.Size(874, 449)
        Me.SplitContainer1.SplitterDistance = 291
        Me.SplitContainer1.SplitterWidth = 1
        Me.SplitContainer1.TabIndex = 0
        '
        'trvDatabase
        '
        Me.trvDatabase.Dock = System.Windows.Forms.DockStyle.Fill
        Me.trvDatabase.Font = New System.Drawing.Font("Times New Roman", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.trvDatabase.Location = New System.Drawing.Point(0, 0)
        Me.trvDatabase.Name = "trvDatabase"
        Me.trvDatabase.Size = New System.Drawing.Size(291, 449)
        Me.trvDatabase.TabIndex = 0
        '
        'tabCTr
        '
        Me.tabCTr.ContextMenuStrip = Me.ctxTab
        Me.tabCTr.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tabCTr.ItemSize = New System.Drawing.Size(62, 23)
        Me.tabCTr.Location = New System.Drawing.Point(0, 0)
        Me.tabCTr.Name = "tabCTr"
        Me.tabCTr.SelectedIndex = 0
        Me.tabCTr.Size = New System.Drawing.Size(582, 449)
        Me.tabCTr.TabIndex = 0
        '
        'ctxTab
        '
        Me.ctxTab.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuOpenTab, Me.mnuNewQuery, Me.mnuDesignTab, Me.mnuClose, Me.mnuCloseAllButThis, Me.mnuCloseAllRight, Me.mnuCloseAllLeft})
        Me.ctxTab.Name = "ctxTab"
        Me.ctxTab.Size = New System.Drawing.Size(167, 158)
        '
        'mnuOpenTab
        '
        Me.mnuOpenTab.Name = "mnuOpenTab"
        Me.mnuOpenTab.Size = New System.Drawing.Size(166, 22)
        Me.mnuOpenTab.Text = "Open Table"
        '
        'mnuNewQuery
        '
        Me.mnuNewQuery.Name = "mnuNewQuery"
        Me.mnuNewQuery.Size = New System.Drawing.Size(166, 22)
        Me.mnuNewQuery.Text = "New Query"
        '
        'mnuDesignTab
        '
        Me.mnuDesignTab.Name = "mnuDesignTab"
        Me.mnuDesignTab.Size = New System.Drawing.Size(166, 22)
        Me.mnuDesignTab.Text = "Design"
        '
        'mnuClose
        '
        Me.mnuClose.Name = "mnuClose"
        Me.mnuClose.Size = New System.Drawing.Size(166, 22)
        Me.mnuClose.Text = "Close"
        '
        'mnuCloseAllButThis
        '
        Me.mnuCloseAllButThis.Name = "mnuCloseAllButThis"
        Me.mnuCloseAllButThis.Size = New System.Drawing.Size(166, 22)
        Me.mnuCloseAllButThis.Text = "Close All But This"
        '
        'mnuCloseAllRight
        '
        Me.mnuCloseAllRight.Name = "mnuCloseAllRight"
        Me.mnuCloseAllRight.Size = New System.Drawing.Size(166, 22)
        Me.mnuCloseAllRight.Text = "Close All Right"
        '
        'mnuCloseAllLeft
        '
        Me.mnuCloseAllLeft.Name = "mnuCloseAllLeft"
        Me.mnuCloseAllLeft.Size = New System.Drawing.Size(166, 22)
        Me.mnuCloseAllLeft.Text = "Close All Left"
        '
        'pnAction
        '
        Me.pnAction.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnAction.Controls.Add(Me.txtFindTab)
        Me.pnAction.Controls.Add(Me.picKey)
        Me.pnAction.Controls.Add(Me.picInfomation)
        Me.pnAction.Controls.Add(Me.picRunSql)
        Me.pnAction.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnAction.Location = New System.Drawing.Point(0, 0)
        Me.pnAction.Name = "pnAction"
        Me.pnAction.Size = New System.Drawing.Size(874, 28)
        Me.pnAction.TabIndex = 1
        '
        'txtFindTab
        '
        Me.txtFindTab.Location = New System.Drawing.Point(3, 3)
        Me.txtFindTab.Name = "txtFindTab"
        Me.txtFindTab.Size = New System.Drawing.Size(287, 20)
        Me.txtFindTab.TabIndex = 1
        '
        'picKey
        '
        Me.picKey.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.picKey.Cursor = System.Windows.Forms.Cursors.Hand
        Me.picKey.Image = My.Resources.Resources.key
        Me.picKey.Location = New System.Drawing.Point(807, 4)
        Me.picKey.Name = "picKey"
        Me.picKey.Size = New System.Drawing.Size(21, 18)
        Me.picKey.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.picKey.TabIndex = 0
        Me.picKey.TabStop = False
        '
        'picInfomation
        '
        Me.picInfomation.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.picInfomation.Cursor = System.Windows.Forms.Cursors.Hand
        Me.picInfomation.Image = My.Resources.Resources.infomation
        Me.picInfomation.Location = New System.Drawing.Point(828, 4)
        Me.picInfomation.Name = "picInfomation"
        Me.picInfomation.Size = New System.Drawing.Size(21, 18)
        Me.picInfomation.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.picInfomation.TabIndex = 0
        Me.picInfomation.TabStop = False
        '
        'picRunSql
        '
        Me.picRunSql.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.picRunSql.Cursor = System.Windows.Forms.Cursors.Hand
        Me.picRunSql.Image = My.Resources.Resources.Exclamation_mark_2_svg
        Me.picRunSql.Location = New System.Drawing.Point(849, 4)
        Me.picRunSql.Name = "picRunSql"
        Me.picRunSql.Size = New System.Drawing.Size(21, 18)
        Me.picRunSql.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.picRunSql.TabIndex = 0
        Me.picRunSql.TabStop = False
        '
        'frmSqlServer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(874, 477)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.pnAction)
        Me.Name = "frmSqlServer"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmSqlServer"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.ctxTab.ResumeLayout(False)
        Me.pnAction.ResumeLayout(False)
        Me.pnAction.PerformLayout()
        CType(Me.picKey, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picInfomation, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picRunSql, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents trvDatabase As System.Windows.Forms.TreeView
    Friend WithEvents ctxTab As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents mnuOpenTab As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuNewQuery As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuDesignTab As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tabCTr As System.Windows.Forms.TabControl
    Friend WithEvents pnAction As System.Windows.Forms.Panel
    Friend WithEvents picRunSql As System.Windows.Forms.PictureBox
    Friend WithEvents mnuClose As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuCloseAllButThis As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuCloseAllRight As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuCloseAllLeft As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents picInfomation As System.Windows.Forms.PictureBox
    Friend WithEvents txtFindTab As System.Windows.Forms.TextBox
    Friend WithEvents picKey As System.Windows.Forms.PictureBox
End Class
