Public Class frmKhung
    Inherits frmPRTienIch
    Private Sub frmKhung_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not DesignMode Then Me.dtgDSMay.DataSource = dbXML.GetTable("select * from dmmayxn")
    End Sub

End Class