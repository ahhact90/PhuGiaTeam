<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class GridParam
    Inherits System.Windows.Forms.DataGridView

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
        Me.picExpant = New System.Windows.Forms.PictureBox()
        CType(Me.picExpant, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'picExpant
        '
        Me.picExpant.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.picExpant.Cursor = System.Windows.Forms.Cursors.Hand
        Me.picExpant.Image = My.Resources.Resources.downdrak
        Me.picExpant.Location = New System.Drawing.Point(270, 3)
        Me.picExpant.Name = "picExpant"
        Me.picExpant.Size = New System.Drawing.Size(20, 20)
        Me.picExpant.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picExpant.TabIndex = 1
        Me.picExpant.TabStop = False
        '
        'GridParam
        '
        Me.Controls.Add(Me.picExpant)
        Me.Size = New System.Drawing.Size(293, 150)
        CType(Me.picExpant, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents picExpant As System.Windows.Forms.PictureBox

End Class
