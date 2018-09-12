<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSelectFolder
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
        Me.trvFld = New System.Windows.Forms.TreeView()
        Me.pnAddfolder = New System.Windows.Forms.Panel()
        Me.ListFile = New System.Windows.Forms.ListView()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.picUpload = New System.Windows.Forms.PictureBox()
        Me.picDownload = New System.Windows.Forms.PictureBox()
        Me.btnSelect = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.cbxView = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.txtSelectFLD = New System.Windows.Forms.TextBox()
        Me.pnAddfolder.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.picUpload, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picDownload, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.SuspendLayout()
        '
        'trvFld
        '
        Me.trvFld.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.trvFld.Dock = System.Windows.Forms.DockStyle.Fill
        Me.trvFld.Location = New System.Drawing.Point(0, 23)
        Me.trvFld.Name = "trvFld"
        Me.trvFld.Size = New System.Drawing.Size(270, 440)
        Me.trvFld.TabIndex = 0
        '
        'pnAddfolder
        '
        Me.pnAddfolder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnAddfolder.Controls.Add(Me.ListFile)
        Me.pnAddfolder.Controls.Add(Me.Panel2)
        Me.pnAddfolder.Controls.Add(Me.Panel1)
        Me.pnAddfolder.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnAddfolder.Location = New System.Drawing.Point(0, 0)
        Me.pnAddfolder.Name = "pnAddfolder"
        Me.pnAddfolder.Size = New System.Drawing.Size(588, 463)
        Me.pnAddfolder.TabIndex = 1
        '
        'ListFile
        '
        Me.ListFile.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ListFile.Location = New System.Drawing.Point(0, 30)
        Me.ListFile.Name = "ListFile"
        Me.ListFile.Size = New System.Drawing.Size(586, 401)
        Me.ListFile.TabIndex = 0
        Me.ListFile.UseCompatibleStateImageBehavior = False
        Me.ListFile.View = System.Windows.Forms.View.List
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.picUpload)
        Me.Panel2.Controls.Add(Me.picDownload)
        Me.Panel2.Controls.Add(Me.btnSelect)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 431)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(586, 30)
        Me.Panel2.TabIndex = 2
        '
        'picUpload
        '
        Me.picUpload.Cursor = System.Windows.Forms.Cursors.Hand
        Me.picUpload.Image = Global.XMLCreator.My.Resources.Resources.ImgUpload
        Me.picUpload.Location = New System.Drawing.Point(30, 5)
        Me.picUpload.Name = "picUpload"
        Me.picUpload.Size = New System.Drawing.Size(20, 20)
        Me.picUpload.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picUpload.TabIndex = 1
        Me.picUpload.TabStop = False
        '
        'picDownload
        '
        Me.picDownload.Cursor = System.Windows.Forms.Cursors.Hand
        Me.picDownload.Image = Global.XMLCreator.My.Resources.Resources.ImgDownload
        Me.picDownload.Location = New System.Drawing.Point(4, 5)
        Me.picDownload.Name = "picDownload"
        Me.picDownload.Size = New System.Drawing.Size(20, 20)
        Me.picDownload.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picDownload.TabIndex = 1
        Me.picDownload.TabStop = False
        '
        'btnSelect
        '
        Me.btnSelect.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSelect.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSelect.Location = New System.Drawing.Point(505, 2)
        Me.btnSelect.Name = "btnSelect"
        Me.btnSelect.Size = New System.Drawing.Size(75, 23)
        Me.btnSelect.TabIndex = 0
        Me.btnSelect.Text = "Chọn"
        Me.btnSelect.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.cbxView)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(586, 30)
        Me.Panel1.TabIndex = 1
        '
        'cbxView
        '
        Me.cbxView.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbxView.FormattingEnabled = True
        Me.cbxView.Location = New System.Drawing.Point(433, 3)
        Me.cbxView.Name = "cbxView"
        Me.cbxView.Size = New System.Drawing.Size(148, 21)
        Me.cbxView.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(394, 7)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(33, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "View:"
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.trvFld)
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtSelectFLD)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.pnAddfolder)
        Me.SplitContainer1.Size = New System.Drawing.Size(859, 463)
        Me.SplitContainer1.SplitterDistance = 270
        Me.SplitContainer1.SplitterWidth = 1
        Me.SplitContainer1.TabIndex = 2
        '
        'txtSelectFLD
        '
        Me.txtSelectFLD.Dock = System.Windows.Forms.DockStyle.Top
        Me.txtSelectFLD.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSelectFLD.Location = New System.Drawing.Point(0, 0)
        Me.txtSelectFLD.Name = "txtSelectFLD"
        Me.txtSelectFLD.Size = New System.Drawing.Size(270, 23)
        Me.txtSelectFLD.TabIndex = 1
        '
        'frmSelectFolder
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(859, 463)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Name = "frmSelectFolder"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmSelectFolder"
        Me.pnAddfolder.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        CType(Me.picUpload, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picDownload, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents trvFld As System.Windows.Forms.TreeView
    Friend WithEvents pnAddfolder As System.Windows.Forms.Panel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents ListFile As System.Windows.Forms.ListView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cbxView As System.Windows.Forms.ComboBox
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents btnSelect As System.Windows.Forms.Button
    Friend WithEvents picDownload As PictureBox
    Friend WithEvents picUpload As PictureBox
    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents txtSelectFLD As TextBox
End Class
