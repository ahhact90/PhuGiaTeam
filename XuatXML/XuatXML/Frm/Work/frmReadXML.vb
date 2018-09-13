Public Class frmReadXML
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
        dtgData.MultiSelect = True
        aReady = True
    End Sub
#End Region
#Region "DTG"
    Private Sub dtgDSFile_RowEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtgDSFile.RowEnter
        If e.RowIndex >= 0 Then
            If Not chkView121.Checked Then
                Dim _file As String = CType(dtgDSFile.DataSource, DataTable).DefaultView(e.RowIndex).Row!DuongDan.ToString
                Dim _ds As New DataSet
                _ds.ReadXml(_file)
                Dim _sT As String = ""
                For Each item In _ds.Tables("filehoso").Rows
                    Dim _sString As String = item!noidungfile.ToString
                    _sT &= vbNewLine & System.Text.Encoding.UTF8.GetString(Convert.FromBase64String(_sString), 0, Convert.FromBase64String(_sString).Length).Replace("﻿<?xml version=""1.0"" encoding=""utf-8""?>", "")
                Next
                _sT = "<?xml version=""1.0"" standalone=""yes""?>" & vbNewLine & "<DataSetName>" & vbNewLine & _sT & vbNewLine & "</DataSetName>"
                Dim srXmlData As New System.IO.StringReader(_sT)
                Dim dsXmlData As New DataSet
                dsXmlData.ReadXml(srXmlData)
                cbxDSTable.Items.Clear()
                dtgData.AutoGenerateColumns = True
                dtgData.DataSource = dsXmlData
                For Each item As DataTable In dsXmlData.Tables
                    If Not item.TableName.ToString.ToLower Like "dsach*" Then
                        cbxDSTable.Items.Add(item.TableName)
                    End If
                Next
                dtgData.DataMember = "Tong_Hop"
            Else
                Dim _file As String = CType(dtgDSFile.DataSource, DataTable).DefaultView(e.RowIndex).Row!DuongDan.ToString
                Dim _ds As New DataSet
                _ds.ReadXml(_file)
                dtgData.AutoGenerateColumns = True
                dtgData.DataSource = _ds.Tables(0)
            End If

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
    Private Sub lblFldPath_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblFldPath.Click
        Dim fff As New folderBrowseDialog
        If IO.Directory.Exists(lblFldPath.Text) Then
            fff.SelectFolder = lblFldPath.Text
        End If
        If fff.ShowDialog = Windows.Forms.DialogResult.OK Then
            lblFldPath.Text = fff.SelectFolder
            LoadDSFile()
        End If
    End Sub
#End Region
#End Region
#Region "Other"
    Sub SetExtentParam()
         
    End Sub
    Sub LoadDSFile()
        If IO.Directory.Exists(lblFldPath.Text) Then
            Dim _ds() As String = IO.Directory.GetFiles(lblFldPath.Text)
            Dim _dt As New DataTable
            _dt.Columns.Add("TenFile")
            _dt.Columns.Add("DuongDan")
            For Each item In _ds
                Dim fif As New IO.FileInfo(item)
                If fif.Extension.ToLower = ".xml" Then
                    _dt.Rows.Add(fif.Name, item)
                End If
            Next
            dtgDSFile.DataSource = _dt
        End If
    End Sub
#End Region

    Private Sub cbxDSTable_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbxDSTable.SelectedIndexChanged
        dtgData.AutoGenerateColumns = True
        dtgData.DataMember = cbxDSTable.Text
    End Sub
End Class