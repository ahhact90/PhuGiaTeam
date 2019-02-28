Public Class ConnectSRP
#Region "Mã hóa và giải mã dữ liệu"
    Private key() As Byte = {}
    Private ReadOnly IV As Byte() = {&H12, &H34, &H56, &H78, &H90, &HAB, &HCD, &HEF}
    Private Function GiaiMa(ByVal mStr As String, ByVal mKey As String) As String
        Try
            If (mStr.Length = 0) Then mStr = MaHoa("", mKey)
            Dim inputByteArray(mStr.Length) As Byte
            key = System.Text.Encoding.UTF8.GetBytes(String.Format("{0}12345678", mKey).Substring(0, 8))
            Dim des = New Security.Cryptography.DESCryptoServiceProvider
            inputByteArray = Convert.FromBase64String(mStr)
            Dim ms = New IO.MemoryStream
            Dim cs = New Security.Cryptography.CryptoStream(ms, des.CreateDecryptor(key, IV), Security.Cryptography.CryptoStreamMode.Write)
            cs.Write(inputByteArray, 0, inputByteArray.Length)
            cs.FlushFinalBlock()
            Dim encoding = System.Text.Encoding.UTF8
            Return encoding.GetString(ms.ToArray())
        Catch e As Exception
            Return e.Message
        End Try
    End Function
    Private Function MaHoa(ByVal mStr As String, ByVal mKey As String) As String
        Try
            key = System.Text.Encoding.UTF8.GetBytes(String.Format("{0}12345678", mKey).Substring(0, 8))
            Dim des = New Security.Cryptography.DESCryptoServiceProvider
            Dim inputByteArray = System.Text.Encoding.UTF8.GetBytes(mStr)
            Dim ms = New IO.MemoryStream
            Dim cs = New Security.Cryptography.CryptoStream(ms, des.CreateEncryptor(key, IV), Security.Cryptography.CryptoStreamMode.Write)
            cs.Write(inputByteArray, 0, inputByteArray.Length)
            cs.FlushFinalBlock()
            Return Convert.ToBase64String(ms.ToArray())
        Catch e As Exception
            Return e.Message
        End Try
    End Function
#End Region
    Dim mIni As New clsIniFile
    Public Function GetConnectString(ByVal i As DuLieu, Optional ByVal path As String = "") As String
        If mIni Is Nothing Then Return ""
        If String.IsNullOrEmpty(path) Then path = My.Application.Info.DirectoryPath
        Dim _s = path & "\connect.sys"
        Dim _sqlCon As String = ""
        If IO.File.Exists(_s) Then
            Dim _gm As String = ""
            _gm = GiaiMaKey(mIni.ReadString("A1", "", "DB" & i, _s))
            If Not String.IsNullOrEmpty(_gm) Then _sqlCon &= "Data Source = " & _gm Else Return ""

            _gm = GiaiMaKey(mIni.ReadString("A4", "", "DB" & i, _s))
            If Not String.IsNullOrEmpty(_gm) Then _sqlCon &= ";Initial Catalog = " & _gm Else Return ""

            _gm = GiaiMaKey(mIni.ReadString("A2", "", "DB" & i, _s))
            If Not String.IsNullOrEmpty(_gm) Then _sqlCon &= ";User ID = " & _gm Else Return ""

            _gm = GiaiMaKey(mIni.ReadString("A3", "", "DB" & i, _s))
            If Not String.IsNullOrEmpty(_gm) Then _sqlCon &= ";Password = " & _gm Else Return ""

        End If
        Return _sqlCon
    End Function
    Public Function MaHoaKey(ByVal _s As String) As String
        Return MaHoa(_s, "BVST4.0")
    End Function
    Public Function GiaiMaKey(ByVal _s As String) As String
        Return GiaiMa(_s, "BVST4.0")
    End Function
End Class
Public Enum DuLieu
    <System.ComponentModel.Description("XML")>
    XML = 1
    <System.ComponentModel.Description("His")>
    His = 2
End Enum
