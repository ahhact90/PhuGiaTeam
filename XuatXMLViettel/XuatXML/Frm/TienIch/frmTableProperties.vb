Public Class frmTableProperties

    Public TableName As String = ""


    Private Sub frmTableProperties_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        dtgPro.Rows.Add("General")
        dtgPro.Rows.Add("Extended Properties") 
    End Sub
End Class