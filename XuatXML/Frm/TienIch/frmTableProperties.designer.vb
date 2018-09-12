<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTableProperties
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
        Me.dtgPro = New System.Windows.Forms.DataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PropertyGrid1 = New System.Windows.Forms.PropertyGrid()
        CType(Me.dtgPro, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dtgPro
        '
        Me.dtgPro.AllowUserToAddRows = False
        Me.dtgPro.AllowUserToDeleteRows = False
        Me.dtgPro.AllowUserToResizeRows = False
        Me.dtgPro.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dtgPro.BackgroundColor = System.Drawing.Color.White
        Me.dtgPro.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtgPro.ColumnHeadersVisible = False
        Me.dtgPro.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1})
        Me.dtgPro.Dock = System.Windows.Forms.DockStyle.Left
        Me.dtgPro.Location = New System.Drawing.Point(0, 0)
        Me.dtgPro.Name = "dtgPro"
        Me.dtgPro.ReadOnly = True
        Me.dtgPro.RowHeadersVisible = False
        Me.dtgPro.Size = New System.Drawing.Size(240, 521)
        Me.dtgPro.TabIndex = 0
        '
        'Column1
        '
        Me.Column1.HeaderText = "Column1"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        '
        'PropertyGrid1
        '
        Me.PropertyGrid1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PropertyGrid1.Location = New System.Drawing.Point(240, 0)
        Me.PropertyGrid1.Name = "PropertyGrid1"
        Me.PropertyGrid1.Size = New System.Drawing.Size(523, 521)
        Me.PropertyGrid1.TabIndex = 1
        '
        'frmTableProperties
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(763, 521)
        Me.Controls.Add(Me.PropertyGrid1)
        Me.Controls.Add(Me.dtgPro)
        Me.Name = "frmTableProperties"
        Me.Text = "Table Properties"
        CType(Me.dtgPro, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dtgPro As System.Windows.Forms.DataGridView
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PropertyGrid1 As System.Windows.Forms.PropertyGrid
End Class
