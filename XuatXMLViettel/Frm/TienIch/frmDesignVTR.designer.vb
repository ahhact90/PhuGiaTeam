<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDesignVTR
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
        Me.ctrRightMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.brtof = New System.Windows.Forms.ToolStripMenuItem()
        Me.SendToBackToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripSeparator()
        Me.BangLeft = New System.Windows.Forms.ToolStripMenuItem()
        Me.BangRight = New System.Windows.Forms.ToolStripMenuItem()
        Me.BangLR = New System.Windows.Forms.ToolStripMenuItem()
        Me.BangCenter = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem4 = New System.Windows.Forms.ToolStripSeparator()
        Me.BangT = New System.Windows.Forms.ToolStripMenuItem()
        Me.BangB = New System.Windows.Forms.ToolStripMenuItem()
        Me.BangBT = New System.Windows.Forms.ToolStripMenuItem()
        Me.BangVCenter = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem5 = New System.Windows.Forms.ToolStripSeparator()
        Me.removeLR = New System.Windows.Forms.ToolStripMenuItem()
        Me.RemoveBT = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem6 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuEditColumn = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuSetEV = New System.Windows.Forms.ToolStripMenuItem()
        Me.prpMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem7 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuClose = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem3 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ctrControlB = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.prpGrid1 = New System.Windows.Forms.PropertyGrid()
        Me.lblInviPropGrid = New System.Windows.Forms.Label()
        Me.cbxDSColumn = New System.Windows.Forms.ComboBox()
        Me.ctrRightMenu.SuspendLayout()
        Me.SuspendLayout()
        '
        'ctrRightMenu
        '
        Me.ctrRightMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.brtof, Me.SendToBackToolStripMenuItem, Me.ToolStripMenuItem2, Me.BangLeft, Me.BangRight, Me.BangLR, Me.BangCenter, Me.ToolStripMenuItem4, Me.BangT, Me.BangB, Me.BangBT, Me.BangVCenter, Me.ToolStripMenuItem5, Me.removeLR, Me.RemoveBT, Me.ToolStripMenuItem6, Me.mnuEditColumn, Me.mnuSetEV, Me.prpMenuItem, Me.ToolStripMenuItem7, Me.mnuClose})
        Me.ctrRightMenu.Name = "ContextMenuStrip1"
        Me.ctrRightMenu.Size = New System.Drawing.Size(222, 386)
        '
        'brtof
        '
        Me.brtof.Name = "brtof"
        Me.brtof.Size = New System.Drawing.Size(221, 22)
        Me.brtof.Text = "Bring To Front"
        '
        'SendToBackToolStripMenuItem
        '
        Me.SendToBackToolStripMenuItem.Name = "SendToBackToolStripMenuItem"
        Me.SendToBackToolStripMenuItem.Size = New System.Drawing.Size(221, 22)
        Me.SendToBackToolStripMenuItem.Text = "Send To Back"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(218, 6)
        '
        'BangLeft
        '
        Me.BangLeft.Name = "BangLeft"
        Me.BangLeft.Size = New System.Drawing.Size(221, 22)
        Me.BangLeft.Text = "Căn bằng trái"
        Me.BangLeft.ToolTipText = "Click: Bằng bên trái" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Ctrl + Click: Bằng bên trái + bên phải giữ nguyên"
        '
        'BangRight
        '
        Me.BangRight.Name = "BangRight"
        Me.BangRight.Size = New System.Drawing.Size(221, 22)
        Me.BangRight.Text = "Căn bằng phải"
        Me.BangRight.ToolTipText = "Click: Bằng bên phải" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Ctrl + Click: Bằng bên phải+ bên trái giữ nguyên"
        '
        'BangLR
        '
        Me.BangLR.Name = "BangLR"
        Me.BangLR.Size = New System.Drawing.Size(221, 22)
        Me.BangLR.Text = "Bằng chiều rộng"
        Me.BangLR.ToolTipText = "Click: Độ rộng bằng nhau, lề trái bằng nhau" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Ctrl + Click: Độ rộng bằng nhau, lề " & _
            "trái giữ nguyên"
        '
        'BangCenter
        '
        Me.BangCenter.Name = "BangCenter"
        Me.BangCenter.Size = New System.Drawing.Size(221, 22)
        Me.BangCenter.Text = "Căng bằng chính giữa dọc"
        Me.BangCenter.ToolTipText = "Đường chính giữa theo chiều ngang của các control bằng nhau"
        '
        'ToolStripMenuItem4
        '
        Me.ToolStripMenuItem4.Name = "ToolStripMenuItem4"
        Me.ToolStripMenuItem4.Size = New System.Drawing.Size(218, 6)
        '
        'BangT
        '
        Me.BangT.Name = "BangT"
        Me.BangT.Size = New System.Drawing.Size(221, 22)
        Me.BangT.Text = "Căn bằng trên"
        Me.BangT.ToolTipText = "Click: Lề trên bằng nhau" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Ctr + Click: Lề trên bằng nhau, Lề dưới giữ nguyên"
        '
        'BangB
        '
        Me.BangB.Name = "BangB"
        Me.BangB.Size = New System.Drawing.Size(221, 22)
        Me.BangB.Text = "Căn bằng dưới"
        Me.BangB.ToolTipText = "Click: Lề dưới bằng nhau" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Ctr + Click: Lề dưới bằng nhau, Lề trên giữ nguyên"
        '
        'BangBT
        '
        Me.BangBT.Name = "BangBT"
        Me.BangBT.Size = New System.Drawing.Size(221, 22)
        Me.BangBT.Text = "Bằng chiêu cao"
        Me.BangBT.ToolTipText = "Click: Chiều cao bằng nhau, lề trên bằng nhau" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Ctr + Click: Chiều cao bằng nhau, " & _
            "lề trên giữ nguyên"
        '
        'BangVCenter
        '
        Me.BangVCenter.Name = "BangVCenter"
        Me.BangVCenter.Size = New System.Drawing.Size(221, 22)
        Me.BangVCenter.Text = "Căn bằng chính giữa ngang"
        Me.BangVCenter.ToolTipText = "Đường chính giữa theo chiều đứng của các control trùng nhau"
        '
        'ToolStripMenuItem5
        '
        Me.ToolStripMenuItem5.Name = "ToolStripMenuItem5"
        Me.ToolStripMenuItem5.Size = New System.Drawing.Size(218, 6)
        '
        'removeLR
        '
        Me.removeLR.Name = "removeLR"
        Me.removeLR.Size = New System.Drawing.Size(221, 22)
        Me.removeLR.Text = "Đều khoảng cách ngang"
        Me.removeLR.ToolTipText = "Click: Các control xếp sát nhau theo chiều ngang" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Ctrl + Click: Các control giãn " & _
            "đều khoảng cách theo chiều ngang"
        '
        'RemoveBT
        '
        Me.RemoveBT.Name = "RemoveBT"
        Me.RemoveBT.Size = New System.Drawing.Size(221, 22)
        Me.RemoveBT.Text = "Đều khoảng cách dọc"
        Me.RemoveBT.ToolTipText = "Click: Các control xếp sát nhau theo chiều dọc" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Ctrl + Click: Các control giãn đề" & _
            "u khoảng cách theo chiều dọc"
        '
        'ToolStripMenuItem6
        '
        Me.ToolStripMenuItem6.Name = "ToolStripMenuItem6"
        Me.ToolStripMenuItem6.Size = New System.Drawing.Size(218, 6)
        '
        'mnuEditColumn
        '
        Me.mnuEditColumn.Name = "mnuEditColumn"
        Me.mnuEditColumn.Size = New System.Drawing.Size(221, 22)
        Me.mnuEditColumn.Text = "EditColumn"
        '
        'mnuSetEV
        '
        Me.mnuSetEV.Name = "mnuSetEV"
        Me.mnuSetEV.Size = New System.Drawing.Size(221, 22)
        Me.mnuSetEV.Text = "Set Event"
        '
        'prpMenuItem
        '
        Me.prpMenuItem.Name = "prpMenuItem"
        Me.prpMenuItem.Size = New System.Drawing.Size(221, 22)
        Me.prpMenuItem.Text = "Properties"
        '
        'ToolStripMenuItem7
        '
        Me.ToolStripMenuItem7.Name = "ToolStripMenuItem7"
        Me.ToolStripMenuItem7.Size = New System.Drawing.Size(218, 6)
        '
        'mnuClose
        '
        Me.mnuClose.Name = "mnuClose"
        Me.mnuClose.Size = New System.Drawing.Size(221, 22)
        Me.mnuClose.Text = "Close"
        '
        'ToolStripMenuItem3
        '
        Me.ToolStripMenuItem3.Name = "ToolStripMenuItem3"
        Me.ToolStripMenuItem3.Size = New System.Drawing.Size(225, 6)
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(225, 6)
        '
        'ctrControlB
        '
        Me.ctrControlB.Name = "ctrControlB"
        Me.ctrControlB.Size = New System.Drawing.Size(61, 4)
        '
        'prpGrid1
        '
        Me.prpGrid1.Dock = System.Windows.Forms.DockStyle.Right
        Me.prpGrid1.Location = New System.Drawing.Point(1060, 0)
        Me.prpGrid1.Name = "prpGrid1"
        Me.prpGrid1.Size = New System.Drawing.Size(0, 400)
        Me.prpGrid1.TabIndex = 2
        Me.prpGrid1.Visible = False
        '
        'lblInviPropGrid
        '
        Me.lblInviPropGrid.AutoSize = True
        Me.lblInviPropGrid.Location = New System.Drawing.Point(1646, 7)
        Me.lblInviPropGrid.Name = "lblInviPropGrid"
        Me.lblInviPropGrid.Size = New System.Drawing.Size(19, 13)
        Me.lblInviPropGrid.TabIndex = 10000
        Me.lblInviPropGrid.Text = ">>"
        Me.lblInviPropGrid.Visible = False
        '
        'cbxDSColumn
        '
        Me.cbxDSColumn.FormattingEnabled = True
        Me.cbxDSColumn.Location = New System.Drawing.Point(1671, 3)
        Me.cbxDSColumn.Name = "cbxDSColumn"
        Me.cbxDSColumn.Size = New System.Drawing.Size(144, 21)
        Me.cbxDSColumn.TabIndex = 10000
        Me.cbxDSColumn.Visible = False
        '
        'frmDesignVTR
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1060, 400)
        Me.Controls.Add(Me.cbxDSColumn)
        Me.Controls.Add(Me.lblInviPropGrid)
        Me.Controls.Add(Me.prpGrid1)
        Me.Name = "frmDesignVTR"
        Me.Text = "Form1"
        Me.ctrRightMenu.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ctrRightMenu As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents brtof As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SendToBackToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ctrControlB As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents prpGrid1 As System.Windows.Forms.PropertyGrid
    Friend WithEvents lblInviPropGrid As System.Windows.Forms.Label
    Friend WithEvents prpMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cbxDSColumn As System.Windows.Forms.ComboBox
    Friend WithEvents BangLeft As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BangRight As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BangLR As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents removeLR As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BangT As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BangB As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BangBT As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RemoveBT As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BangCenter As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BangVCenter As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripMenuItem4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripMenuItem5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripMenuItem6 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripMenuItem7 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuClose As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuEditColumn As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuSetEV As System.Windows.Forms.ToolStripMenuItem

End Class
