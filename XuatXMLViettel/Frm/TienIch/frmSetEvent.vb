Public Class frmSetEvent

    Private Sub cbxEventName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbxEventName.SelectedIndexChanged
        Dim _dt As DataTable = dbXML.GetTable("select * from EventControl where FormName = N'" & cbxFormName.Text & "' and ControlName = N'" & cbxControlName.Text & "' and EventName = N'" & cbxEventName.Text & "'")
        If _dt.Rows.Count > 0 Then
            rtfFunction.Text = _dt.Rows(0)!mFunction.ToString
        Else
            rtfFunction.Text = ""
        End If
    End Sub
    Protected Overrides Function ProcessCmdKey(ByRef msg As System.Windows.Forms.Message, ByVal keyData As System.Windows.Forms.Keys) As Boolean
        If keyData = Keys.Control + Keys.S Then
            Dim _dr As DataRow
            Dim _dt As DataTable = dbXML.GetTable("select * from EventControl where FormName = N'" & cbxFormName.Text & "' and ControlName = N'" & cbxControlName.Text & "' and EventName = N'" & cbxEventName.Text & "'")
            If _dt.Rows.Count > 0 Then
                _dr = _dt.Rows(0)
            Else
                _dr = _dt.NewRow
                _dt.Rows.Add(_dr)
                _dr!FormName = cbxFormName.Text
                _dr!ControlName = cbxControlName.Text
                _dr!EventName = cbxEventName.Text
            End If
            _dr!mFunction = rtfFunction.Text
            If dbXML.UpdateData(_dt, "select * from EventControl where FormName = N'" & cbxFormName.Text & "' and ControlName = N'" & cbxControlName.Text & "' and EventName = N'" & cbxEventName.Text & "'") Then
                MsgBox("Cập nhật thành công!")
            Else
                MsgBox("Có lỗi khi cập nhật!")
            End If
            Return True
        End If
        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function
End Class