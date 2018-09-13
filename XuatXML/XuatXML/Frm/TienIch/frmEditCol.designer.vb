<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEditCol
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
        Me.dtgDSCol = New System.Windows.Forms.DataGridView()
        Me.ColumnName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.HeaderText = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataFieldsName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Frozen = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.cWidth = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cAutoSizeMode = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.ColumnType = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.cReadOnly = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        CType(Me.dtgDSCol, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dtgDSCol
        '
        Me.dtgDSCol.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtgDSCol.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ColumnName, Me.HeaderText, Me.DataFieldsName, Me.Frozen, Me.cWidth, Me.cAutoSizeMode, Me.ColumnType, Me.cReadOnly})
        Me.dtgDSCol.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dtgDSCol.Location = New System.Drawing.Point(0, 0)
        Me.dtgDSCol.Name = "dtgDSCol"
        Me.dtgDSCol.Size = New System.Drawing.Size(893, 402)
        Me.dtgDSCol.TabIndex = 0
        '
        'ColumnName
        '
        Me.ColumnName.HeaderText = "Name"
        Me.ColumnName.Name = "ColumnName"
        '
        'HeaderText
        '
        Me.HeaderText.DataPropertyName = "HeaderText"
        Me.HeaderText.HeaderText = "Header Text"
        Me.HeaderText.Name = "HeaderText"
        '
        'DataFieldsName
        '
        Me.DataFieldsName.DataPropertyName = "DataFieldsName"
        Me.DataFieldsName.HeaderText = "Data Fields"
        Me.DataFieldsName.Name = "DataFieldsName"
        '
        'Frozen
        '
        Me.Frozen.HeaderText = "Frozen"
        Me.Frozen.Name = "Frozen"
        Me.Frozen.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Frozen.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.Frozen.Width = 50
        '
        'Width
        '
        Me.cWidth.DataPropertyName = "Width"
        Me.cWidth.HeaderText = "Width"
        Me.cWidth.Name = "Width"
        Me.cWidth.Width = 50
        '
        'AutoSizeMode
        '
        Me.cAutoSizeMode.DataPropertyName = "AutoSizeMode"
        Me.cAutoSizeMode.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.[Nothing]
        Me.cAutoSizeMode.HeaderText = "AutoSizeMode"
        Me.cAutoSizeMode.Name = "AutoSizeMode"
        Me.cAutoSizeMode.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.cAutoSizeMode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.cAutoSizeMode.Width = 150
        '
        'ColumnType
        '
        Me.ColumnType.DataPropertyName = "ColumnType"
        Me.ColumnType.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.[Nothing]
        Me.ColumnType.HeaderText = "ColumnType"
        Me.ColumnType.Name = "ColumnType"
        Me.ColumnType.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ColumnType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.ColumnType.Width = 250
        '
        'cReadOnly
        '
        Me.cReadOnly.DataPropertyName = "ReadOnly"
        Me.cReadOnly.HeaderText = "ROL"
        Me.cReadOnly.Name = "cReadOnly"
        Me.cReadOnly.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.cReadOnly.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.cReadOnly.ToolTipText = "Read only"
        Me.cReadOnly.Width = 50
        '
        'frmEditCol
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(893, 402)
        Me.Controls.Add(Me.dtgDSCol)
        Me.Name = "frmEditCol"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cài đặt cột"
        CType(Me.dtgDSCol, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dtgDSCol As System.Windows.Forms.DataGridView
    Friend WithEvents ColumnName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents HeaderText As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataFieldsName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Frozen As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents cWidth As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cAutoSizeMode As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents ColumnType As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents cReadOnly As System.Windows.Forms.DataGridViewCheckBoxColumn
End Class
