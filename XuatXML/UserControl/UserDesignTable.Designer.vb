<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UserDesignTable
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Me.dtgDesign = New System.Windows.Forms.DataGridView()
        Me.ColumnName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataType = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.Max_Length = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Allow_Null = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        CType(Me.dtgDesign, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dtgDesign
        '
        Me.dtgDesign.BackgroundColor = System.Drawing.Color.White
        Me.dtgDesign.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtgDesign.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ColumnName, Me.DataType, Me.Max_Length, Me.Allow_Null})
        Me.dtgDesign.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dtgDesign.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnF2
        Me.dtgDesign.Location = New System.Drawing.Point(0, 0)
        Me.dtgDesign.Name = "dtgDesign"
        Me.dtgDesign.Size = New System.Drawing.Size(598, 402)
        Me.dtgDesign.TabIndex = 0
        '
        'ColumnName
        '
        Me.ColumnName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.ColumnName.DataPropertyName = "Name"
        Me.ColumnName.HeaderText = "ColumnName"
        Me.ColumnName.Name = "ColumnName"
        '
        'DataType
        '
        Me.DataType.DataPropertyName = "DataType"
        Me.DataType.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.[Nothing]
        Me.DataType.HeaderText = "DataType"
        Me.DataType.Name = "DataType"
        Me.DataType.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.DataType.Width = 120
        '
        'Max_Length
        '
        Me.Max_Length.DataPropertyName = "Max_Length"
        Me.Max_Length.HeaderText = "Max Length"
        Me.Max_Length.Name = "Max_Length"
        Me.Max_Length.Visible = False
        '
        'Allow_Null
        '
        Me.Allow_Null.DataPropertyName = "Allow_Null"
        Me.Allow_Null.HeaderText = "Allow Null"
        Me.Allow_Null.Name = "Allow_Null"
        Me.Allow_Null.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Allow_Null.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.Allow_Null.Width = 80
        '
        'UserDesignTable
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.dtgDesign)
        Me.Name = "UserDesignTable"
        Me.Size = New System.Drawing.Size(598, 402)
        CType(Me.dtgDesign, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dtgDesign As System.Windows.Forms.DataGridView
    Friend WithEvents ColumnName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataType As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents Max_Length As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Allow_Null As System.Windows.Forms.DataGridViewCheckBoxColumn

End Class
