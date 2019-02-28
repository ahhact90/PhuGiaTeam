Public Class frmConfigTheoThe
    Inherits frmPRTienIch
#Region "Private Var"
    ''' <summary>
    ''' TXT trên lưới
    ''' </summary>
    ''' <remarks></remarks>
    Private WithEvents txtDTG As TextBox
#End Region
#Region "Var Property"

#End Region
#Region "Property"

#End Region
#Region "FormControlEvent"
#Region "Form"
    Private Sub _Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated

    End Sub
    Private Sub _Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.NotDesignMode = True
        SetExtentParam()
    End Sub
    Protected Overrides Function ProcessCmdKey(ByRef msg As System.Windows.Forms.Message, ByVal keyData As System.Windows.Forms.Keys) As Boolean
        Dim _ActiveControl As Control = Me.ActiveControl
        If _ActiveControl IsNot Nothing AndAlso TypeOf _ActiveControl Is SplitContainer Then
            _ActiveControl = CType(_ActiveControl, SplitContainer).ActiveControl
        End If
        Dim dtg As DataGridView = Nothing
        If _ActiveControl IsNot Nothing AndAlso _ActiveControl Is txtDTG Then dtg = CType(_ActiveControl, Object).EditingControlDataGridView

        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function
    Private Sub _Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown

        aReady = True
    End Sub
#End Region
#Region "DTG"
    Private Sub dtgConfig_RowValidated(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtgConfig.RowValidated
        Dim _dt = dtgConfig.DataSource.GetChanges()
        If _dt IsNot Nothing Then
            For Each item As DataRow In _dt.Rows
                Dim _manc As String = item!manc.ToString
                Dim _FileFolder As String = item!filefolder.ToString
                Dim _XmlClass As String = item!xmlclass.ToString
                Dim _sql As String = <SQL>
if Exists(select top 1 1 from cauhinhnoicap where manc = N'{0}')
Begin
    update cauhinhnoicap set filefolder =N'{1}',xmlclass=N'{2}' where manc =N'{0}'
End
Else
Begin
    Insert into cauhinhnoicap(manc,filefolder,xmlclass) values(N'{0}',N'{1}',N'{2}')
End
                                    </SQL>.Value
                dbXML.RunSQL(String.Format(_sql, _manc, _FileFolder, _XmlClass))
            Next
        End If 
    End Sub
#End Region
#Region "CHK"

#End Region
#Region "TXT"

#End Region
#Region "CBX"

#End Region
#Region "BTN"

#End Region
#Region "Panel"

#End Region
#Region "PicBox"

#End Region
#Region "LBL"

#End Region
#End Region
#Region "Other"
    Sub SetExtentParam()
        Dim _sql As String = "select b1.manc,b2.xmlclass,b2.filefolder from dmnoicap b1 left join " & dbXML.DatabaseName & "..cauhinhnoicap b2 on b1.manc = b2.manc"
        dtgConfig.DataSource = dbHis.GetTable(_sql)
    End Sub
#End Region
End Class