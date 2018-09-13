<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class folderBrowseDialog
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(folderBrowseDialog))
        Me.txtfldSelect = New System.Windows.Forms.TextBox()
        Me.trvFLD = New System.Windows.Forms.TreeView()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.picSaveAnh = New System.Windows.Forms.PictureBox()
        CType(Me.picSaveAnh, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtfldSelect
        '
        Me.txtfldSelect.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtfldSelect.Location = New System.Drawing.Point(6, 5)
        Me.txtfldSelect.Name = "txtfldSelect"
        Me.txtfldSelect.Size = New System.Drawing.Size(415, 20)
        Me.txtfldSelect.TabIndex = 0
        '
        'trvFLD
        '
        Me.trvFLD.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.trvFLD.Location = New System.Drawing.Point(6, 31)
        Me.trvFLD.Name = "trvFLD"
        Me.trvFLD.Size = New System.Drawing.Size(415, 379)
        Me.trvFLD.TabIndex = 1
        '
        'btnOK
        '
        Me.btnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnOK.Location = New System.Drawing.Point(356, 413)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(65, 23)
        Me.btnOK.TabIndex = 2
        Me.btnOK.Text = "Chọn"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Location = New System.Drawing.Point(6, 413)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(65, 23)
        Me.Button2.TabIndex = 2
        Me.Button2.Text = "Tạo folder"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'picSaveAnh
        '
        Me.picSaveAnh.Image = Global.XMLCreator.My.Resources.Resources.folderopened_yellow
        Me.picSaveAnh.Location = New System.Drawing.Point(-11191, 292)
        Me.picSaveAnh.Name = "picSaveAnh"
        Me.picSaveAnh.Size = New System.Drawing.Size(100, 50)
        Me.picSaveAnh.TabIndex = 3
        Me.picSaveAnh.TabStop = False
        '
        'folderBrowseDialog
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(427, 439)
        Me.Controls.Add(Me.picSaveAnh)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.trvFLD)
        Me.Controls.Add(Me.txtfldSelect)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "folderBrowseDialog"
        Me.Text = "Tìm folder"
        CType(Me.picSaveAnh, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtfldSelect As System.Windows.Forms.TextBox
    Friend WithEvents trvFLD As System.Windows.Forms.TreeView
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents picSaveAnh As System.Windows.Forms.PictureBox
End Class
