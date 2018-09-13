<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmConfigTheoThe
    Inherits XMLCreator.frmPRTienIch

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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.dtgConfig = New System.Windows.Forms.DataGridView()
        Me.manc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.XmlClass = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FileFolder = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.DataSetNguon, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtgConfig, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnHeader
        '
        Me.pnHeader.Size = New System.Drawing.Size(697, 0)
        '
        'pnAction
        '
        Me.pnAction.Location = New System.Drawing.Point(0, 353)
        Me.pnAction.Size = New System.Drawing.Size(697, 33)
        '
        'dtgConfig
        '
        Me.dtgConfig.AllowUserToAddRows = False
        Me.dtgConfig.AllowUserToResizeRows = False
        Me.dtgConfig.AutoGenerateColumns = False
        Me.dtgConfig.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(245, Byte), Integer))
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(245, Byte), Integer))
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Arial", 10.0!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.Padding = New System.Windows.Forms.Padding(3)
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dtgConfig.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dtgConfig.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtgConfig.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.manc, Me.XmlClass, Me.FileFolder})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Arial", 10.0!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer))
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dtgConfig.DefaultCellStyle = DataGridViewCellStyle2
        Me.dtgConfig.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dtgConfig.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.dtgConfig.EnableHeadersVisualStyles = False
        Me.dtgConfig.Location = New System.Drawing.Point(0, 0)
        Me.dtgConfig.MultiSelect = False
        Me.dtgConfig.Name = "dtgConfig"
        Me.dtgConfig.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black
        Me.dtgConfig.Size = New System.Drawing.Size(697, 353)
        Me.dtgConfig.TabIndex = 8
        '
        'manc
        '
        Me.manc.DataPropertyName = "manc"
        Me.manc.HeaderText = "Nơi cấp"
        Me.manc.Name = "manc"
        Me.manc.ReadOnly = True
        '
        'XmlClass
        '
        Me.XmlClass.DataPropertyName = "XmlClass"
        Me.XmlClass.HeaderText = "Kiểu XML"
        Me.XmlClass.Name = "XmlClass"
        Me.XmlClass.Width = 150
        '
        'FileFolder
        '
        Me.FileFolder.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.FileFolder.DataPropertyName = "FileFolder"
        Me.FileFolder.HeaderText = "Folder"
        Me.FileFolder.Name = "FileFolder"
        '
        'frmConfigTheoThe
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(697, 386)
        Me.Controls.Add(Me.dtgConfig)
        Me.Name = "frmConfigTheoThe"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Xuất XML Theo Thẻ"
        Me.Controls.SetChildIndex(Me.pnHeader, 0)
        Me.Controls.SetChildIndex(Me.pnAction, 0)
        Me.Controls.SetChildIndex(Me.dtgConfig, 0)
        CType(Me.DataSetNguon, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtgConfig, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dtgConfig As System.Windows.Forms.DataGridView
    Friend WithEvents manc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents XmlClass As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FileFolder As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
