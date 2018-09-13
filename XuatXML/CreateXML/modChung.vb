Public Enum Kieu
    Chuoi = 1
    So = 2
    Ngay = 3
End Enum
Module modChung
    Public dbHis As MyData.Database
    Public dbXML As MyData.Database
    Public _CotTenThuoc = ""
    Public _CotTenDV = ""
    Private Function GetConnect(ByVal DL As Integer) As String
        Dim cnsp As New ConnectSRP
        Return cnsp.GetConnectString(DL)
    End Function
    ''' <summary>
    ''' Trả về bảng của bệnh nhân
    ''' </summary>
    ''' <param name="makcb_"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function TimBangBN(ByVal makcb_ As String) As String
        Dim _dt As DataTable = dbHis.GetTable("EXECUTE BC_" & dbHis.DatabaseName.Substring(0, dbHis.DatabaseName.Length - 4) & "..laydanhsachngaytheomakcb '" & makcb_ & "'")
        Return CDate(_dt.Rows(0)("ngaydk").ToString).ToString("MMyy")
        Return ""
    End Function
    ''' <summary>
    ''' Lấy ra ngày áp dụng giá
    ''' </summary>
    ''' <param name="db"></param>
    ''' <param name="ngaydk"></param>
    ''' <param name="madt"></param>
    ''' <param name="ngayke"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function LayNgayAD(ByVal db As MyData.Database, ByVal ngaydk As Date, ByVal madt As Integer, Optional ByVal ngayke As String = "01/01/1900") As String
        Dim ngayok As Date = CDate(ngayke)
        If ngayke = CDate("01/01/1900") Then ngayok = ngaydk
        Dim _sql As String = "select top 1 ngayad from tendvtheongay where madt = {0} and ngayad <= '{1:dd/MM/yyyy}' order by ngayad DESC"
        If Not IsDate(ngayke) OrElse CDate(ngayke).Year < 1990 Then
            ngayok = ngaydk
        End If
        _sql = String.Format(_sql, madt, ngayok)
        Dim _dt As DataTable = db.GetTable(_sql)
        If _dt.Rows.Count = 0 Then
            Return ""
        End If
        Return CDate(_dt.Rows(0)!ngayad.ToString).ToString("dd/MM/yyyy")
    End Function

#Region "Lọc biến"
    ''' <summary>
    ''' Chuyển kiểu dữ liệu phù hợ với biến
    ''' </summary>
    ''' <param name="Bien">Dữ liệu muốn chuyển</param>
    ''' <param name="K">Kiểu dữ liệu xẽ nhận để chuyển đổi</param>
    ''' <param name="Def">Giá trị mặc định trả về khi biển không đúng kiểu dữ liệu</param>
    ''' <param name="Dang">Định dạng kiểu dữ liệu muốn trả về</param>
    ''' <param name="hopphapkytu">True: Hợp pháp chuổi đưa ghép vào câu lệnh SQL Replace("'", "''").Replace("[", "[[]").Replace("%", "[%]").Replace("*", "[*]")</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function LocBien(ByVal Bien As Object, ByVal K As Kieu, Optional ByVal Def As Object = "", Optional ByVal Dang As String = "", Optional ByVal hopphapkytu As Boolean = False) As Object
        Dim mV As Object = Bien
        If IsDBNull(Def) OrElse IsNothing(Def) Then Def = ""
        If K = Kieu.Chuoi AndAlso (IsDBNull(Bien) OrElse IsNothing(Bien)) Then Return Def
        If K = Kieu.So AndAlso (IsDBNull(Bien) OrElse IsNothing(Bien) OrElse Not IsNumeric(Bien)) Then
            If Def.ToString <> "" AndAlso IsNumeric(Def) AndAlso Dang <> "" Then Return Format(Def * 1, Dang)
            If Def.ToString <> "" AndAlso IsNumeric(Def) Then Return Def * 1
            Return ""
        End If
        If K = Kieu.So AndAlso Dang <> "" Then Return Format(Bien * 1, Dang)
        If K = Kieu.So Then Return Bien * 1
        If K = Kieu.Ngay AndAlso (IsDBNull(Bien) OrElse IsNothing(Bien) OrElse Not fKiemTraNgay(Bien, , False, False)) Then
            mV = Def
            If Def.ToString <> "" AndAlso fKiemTraNgay(mV, , False, False) AndAlso Dang <> "" Then Return Format(Convert.ToDateTime(Def), Dang)
            If Def.ToString <> "" AndAlso fKiemTraNgay(mV, , False, False) Then Return Convert.ToDateTime(Def).ToShortDateString
            Return ""
        End If
        If K = Kieu.Ngay AndAlso Dang <> "" Then Return Format(Convert.ToDateTime(Bien), Dang)
        If K = Kieu.Ngay Then Return Convert.ToDateTime(Bien).ToShortDateString
        If K = Kieu.Chuoi AndAlso hopphapkytu Then Return Bien.ToString.Replace("'", "''").Replace("[", "[[]").Replace("%", "[%]").Replace("*", "[*]")
        Return Bien
    End Function
    ''' <summary>
    ''' Kiểm tra xem có đúng kiểu ngày hay không
    ''' Nếu đúng xẽ tự chuyển đổi về dạng ngày tháng năm (dd/MM/yyyy)
    ''' </summary>
    ''' <param name="D">Dữ liệu muốn kiểm tra và xẽ nhận trở vè thông qua tham số này</param>
    ''' <param name="msg">Thông báo đưa ra khi kiểu dữ liệu không đúng kiểu ngày</param>
    ''' <param name="TrueDate">True: Tự động trả về ngày gần đúng nhất (Trường hợp này msg và AllowNull không có tác dụng)</param>
    ''' <param name="AllowNull">True: Tự động trả về "" (Trường hợp này msg không có tác dụng)</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function fKiemTraNgay(ByRef D As Object, Optional ByVal msg As String = "", Optional ByVal TrueDate As Boolean = False, Optional ByVal AllowNull As Boolean = True) As Boolean
        If IsDBNull(D) OrElse D Is Nothing OrElse ((D.GetType.Name = "String") AndAlso (D.Replace(" ", "").Replace("/", "") = "")) Then
            If Not AllowNull Then
                If msg <> "" Then
                    MsgBox(msg, MsgBoxStyle.Information)
                    Return False
                Else
                    D = Format(Date.Today, "dd/MM/yyyy")
                    Return True
                End If
            Else
                D = ""
                Return True
            End If
        End If
        Dim mDay As Integer, mArray() As String
        D = Replace(D, ".", "")
        D = Replace(D, ",", "")
        mArray = D.ToString.Split(" ")(0).Split("/")
        If mArray.Length <> 3 Then
            If TrueDate Then
                D = Format(Date.Today, "dd/MM/yyyy")
                Return True
            Else
                If msg <> "" Then MsgBox(msg, MsgBoxStyle.Information)
                Return False
            End If
        End If
        For i As Integer = 0 To mArray.Length - 1
            If Not IsNumeric(mArray(i)) Then
                Select Case i
                    Case 0
                        If TrueDate Then
                            mArray(i) = Date.Today.Day
                        Else
                            If msg <> "" Then MsgBox(msg, MsgBoxStyle.Information)
                            Return False
                        End If
                    Case 1
                        If TrueDate Then
                            mArray(i) = Date.Today.Month
                        Else
                            If msg <> "" Then MsgBox(msg, MsgBoxStyle.Information)
                            Return False
                        End If
                    Case 2
                        If TrueDate Then
                            mArray(i) = Date.Today.Year
                        Else
                            If msg <> "" Then MsgBox(msg, MsgBoxStyle.Information)
                            Return False
                        End If
                End Select
            End If
        Next i
        For i As Integer = mArray.Length - 1 To 0 Step -1
            Select Case i
                Case 2
                    If mArray(i) * 1 < 1900 Or mArray(i) * 1 > 9999 Then
                        If TrueDate Then
                            If mArray(i).Length < 4 Then
                                mArray(i) = Today.Year.ToString.Substring(0, Today.Year.ToString.Length - mArray(i).Length) & mArray(i)
                            Else
                                mArray(i) = Today.Year
                            End If
                        Else
                            If msg <> "" Then MsgBox(msg, MsgBoxStyle.Information)
                            Return False
                        End If
                    End If
                Case 1
                    If mArray(i) * 1 < 1 Or mArray(i) * 1 > 12 Then mDay = mArray(i) : mArray(i) = mArray(i - 1) : mArray(i - 1) = mDay
                    If mArray(i) * 1 < 1 Or mArray(i) * 1 > 12 Then
                        If TrueDate Then
                            mArray(i) = Date.Today.Month
                        Else
                            If msg <> "" Then MsgBox(msg, MsgBoxStyle.Information)
                            Return False
                        End If
                    End If
                Case 0
                    If mArray(i) * 1 < 1 Or mArray(i) * 1 > Date.DaysInMonth(mArray(2) * 1, mArray(1) * 1) Then
                        If TrueDate Then
                            mArray(i) = Date.DaysInMonth(mArray(2) * 1, mArray(1) * 1)
                        Else
                            If msg <> "" Then MsgBox(msg, MsgBoxStyle.Information)
                            Return False
                        End If
                    End If
            End Select
        Next i
        D = Format(CDate(mArray(0) * 1 & "/" & mArray(1) * 1 & "/" & mArray(2) * 1), "dd/MM/yyyy")
        Return True
    End Function

#End Region
End Module
