<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPRTienIch
    Inherits frmDesignVTR

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPRTienIch))
        Me.dtgTI = New System.Windows.Forms.DataGridView()
        Me.pnDeLuuAnhXuong = New System.Windows.Forms.Panel()
        Me.pnDeLuuAnhLen = New System.Windows.Forms.Panel()
        Me.pnHeader = New System.Windows.Forms.Panel()
        Me.pnAction = New System.Windows.Forms.Panel()
        CType(Me.dtgTI, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dtgTI
        '
        Me.dtgTI.AllowUserToAddRows = False
        Me.dtgTI.AllowUserToDeleteRows = False
        Me.dtgTI.AllowUserToResizeColumns = False
        Me.dtgTI.AllowUserToResizeRows = False
        Me.dtgTI.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtgTI.Location = New System.Drawing.Point(180, 1404)
        Me.dtgTI.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.dtgTI.Name = "dtgTI"
        Me.dtgTI.ReadOnly = True
        Me.dtgTI.RowHeadersVisible = False
        Me.dtgTI.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.dtgTI.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dtgTI.Size = New System.Drawing.Size(280, 185)
        Me.dtgTI.TabIndex = 4
        Me.dtgTI.Visible = False
        '
        'pnDeLuuAnhXuong
        '
        Me.pnDeLuuAnhXuong.BackgroundImage = CType(resources.GetObject("pnDeLuuAnhXuong.BackgroundImage"), System.Drawing.Image)
        Me.pnDeLuuAnhXuong.Location = New System.Drawing.Point(441, 1532)
        Me.pnDeLuuAnhXuong.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.pnDeLuuAnhXuong.Name = "pnDeLuuAnhXuong"
        Me.pnDeLuuAnhXuong.Size = New System.Drawing.Size(26, 28)
        Me.pnDeLuuAnhXuong.TabIndex = 5
        Me.pnDeLuuAnhXuong.Visible = False
        '
        'pnDeLuuAnhLen
        '
        Me.pnDeLuuAnhLen.BackgroundImage = CType(resources.GetObject("pnDeLuuAnhLen.BackgroundImage"), System.Drawing.Image)
        Me.pnDeLuuAnhLen.Location = New System.Drawing.Point(548, 1492)
        Me.pnDeLuuAnhLen.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.pnDeLuuAnhLen.Name = "pnDeLuuAnhLen"
        Me.pnDeLuuAnhLen.Size = New System.Drawing.Size(26, 28)
        Me.pnDeLuuAnhLen.TabIndex = 5
        Me.pnDeLuuAnhLen.Visible = False
        '
        'pnHeader
        '
        Me.pnHeader.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnHeader.Location = New System.Drawing.Point(0, 0)
        Me.pnHeader.Name = "pnHeader"
        Me.pnHeader.Size = New System.Drawing.Size(584, 34)
        Me.pnHeader.TabIndex = 6
        '
        'pnAction
        '
        Me.pnAction.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnAction.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnAction.Location = New System.Drawing.Point(0, 202)
        Me.pnAction.Name = "pnAction"
        Me.pnAction.Size = New System.Drawing.Size(584, 34)
        Me.pnAction.TabIndex = 7
        '
        'frmPRTienIch
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(584, 236)
        Me.Controls.Add(Me.pnAction)
        Me.Controls.Add(Me.pnHeader)
        Me.Controls.Add(Me.dtgTI)
        Me.Controls.Add(Me.pnDeLuuAnhXuong)
        Me.Controls.Add(Me.pnDeLuuAnhLen)
        Me.Font = New System.Drawing.Font("Arial", 10.0!)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.Name = "frmPRTienIch"
        Me.Text = "frmPRTienIch"
        Me.Controls.SetChildIndex(Me.pnDeLuuAnhLen, 0)
        Me.Controls.SetChildIndex(Me.pnDeLuuAnhXuong, 0)
        Me.Controls.SetChildIndex(Me.dtgTI, 0)
        Me.Controls.SetChildIndex(Me.pnHeader, 0)
        Me.Controls.SetChildIndex(Me.pnAction, 0)
        CType(Me.dtgTI, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dtgTI As System.Windows.Forms.DataGridView
    Friend WithEvents pnDeLuuAnhXuong As System.Windows.Forms.Panel
    Friend WithEvents pnDeLuuAnhLen As System.Windows.Forms.Panel
    Public WithEvents pnHeader As Panel
    Public WithEvents pnAction As Panel
End Class
