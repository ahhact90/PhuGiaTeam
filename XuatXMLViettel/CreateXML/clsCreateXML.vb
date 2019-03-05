Public Class clsCreateXML917
    Public XmlReturn_ As String = ""
    Dim BangBN As String = ""
    Dim _drBN As DataRow
    Dim _drConfig As DataRow
    Dim _drThanhToan As DataRow
    Dim _drRaVien As DataRow
    Dim _ngayad = ""
    Dim mIni As New clsIniFile
    Dim snChar As String = ",nChar(0x00) Collate Latin1_General_BIN , N''),nChar(0),N''),nChar(1),N''),nChar(2),N''),nChar(3),N''),nChar(4),N''),nChar(5),N''),nChar(6),N''),nChar(7),N''),nChar(8),N''),nChar(11),N''),nChar(12),N''),nChar(14),N''),nChar(15),N''),nChar(16),N''),nChar(17),N''),nChar(18),N''),nChar(19),N''),nChar(20),N''),nChar(21),N''),nChar(22),N''),nChar(23),N''),nChar(24),N''),nChar(25),N''),nChar(26),N''),nChar(27),N''),nChar(28),N''),nChar(29),N''),nChar(30),N''),nChar(31),N'')"
    Dim sReplace As String = "Replace(Replace(Replace(Replace(Replace(Replace(Replace(Replace(Replace(Replace(Replace(Replace(Replace(Replace(Replace(Replace(Replace(Replace(Replace(Replace(Replace(Replace(Replace(Replace(Replace(Replace(Replace(Replace(Replace(Replace("
    Sub New(ByVal makcb As String, ByVal SDBHis As String, ByVal SDBXML As String)
        Try
            dbHis = New MyData.Database(SDBHis)
            dbXML = New MyData.Database(SDBXML)
            BangBN = TimBangBN(makcb)
            _drBN = dbHis.GetTable("select * from dangky" & BangBN & " where makcb =N'" & makcb & "'").Rows(0)
            _drRaVien = dbHis.GetTable("select * from ravien" & BangBN & " where makcb = '" & makcb & "'").Rows(0)
            Dim _makkCuoi As Integer = _drRaVien!makk
            Dim _dttemp = dbHis.GetTable("select * from ttthanhtoanravien" & BangBN & " where makcb = N'" & makcb & "'")
            If _dttemp.Rows.Count > 0 Then
                _drThanhToan = _dttemp.Rows(0)
            End If
            _drConfig = dbXML.GetTable("select * from tblconfigkk where makk = " & _makkCuoi).Rows(0)
            _ngayad = LayNgayAD(dbHis, CDate(_drBN!ngaydk).ToString("dd/MM/yyyy"), _drBN!madt)
            _CotTenThuoc = dbXML.GetTable("select top 1 * from tblConfigColumn where dichvu = 0").Rows(0)!cotdl.ToString
            _CotTenDV = dbXML.GetTable("select top 1 * from tblconfigcolumn where ngayad = '" & _ngayad & "' and dichvu = 1").Rows(0)!cotdl.ToString
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Function GetDTHC(ByVal makcb As String) As DataTable
        Dim _SQL = <SQL>
declare @makcb as nvarchar(50)
set @makcb ='{0}'
select 
	b1.makcb ma_lk,1 stt,b1.mabn ma_bn,b1.tenbn ho_ten,
	(case when isnull(b1.ngaysinh,'')='' then b1.namsinh else replace(convert(nvarchar,b1.ngaysinh,111),'/','') end) ngay_sinh,
	(case when b2.tenphai like N'%nam%' then 1 else 2 end) gioi_tinh,
	b1.diachithe dia_chi,b1.mathe+ b1.maql + b1.matinh + b1.maquan +b1.madonvi+b1.thutu  ma_the,b1.mandk ma_dkbd,
	replace(convert(nvarchar,b1.ngaybd,111),'/','')  gt_the_tu,replace(convert(nvarchar,b1.ngaykt,111),'/','')  gt_the_den,
	(
		case 
			when 
				b1.dangdt=1 
			then
				(select top 1 b2.tenbenh from chandoanravien{1} b1 join dmbenh b2 on b1.mabenh = b2.mabenh where idravien in (select idravien from ravien{1} where makcb = @makcb) and benhchinh = 1)
			else
				Stuff((select ';' + b2.tenbenh from chandoankhambenh{1} b1 join dmbenh b2 on b1.mabenh = b2.mabenh where idkhambenh in (select idkhambenh from khambenh{1} where makcb = @makcb) and benhchinh = 1 For Xml Path('')),1,1,'')
		end
	)ten_benh,
	(
		case 
			when 
				b1.dangdt=1 
			then
				(select top 1 mabenh from chandoanravien{1} where idravien in (select idravien from ravien{1} where makcb = @makcb) and benhchinh = 1)
			else
				(select top 1  mabenh from chandoankhambenh{1} where idkhambenh = (select top 1 idkhambenh from khambenh{1} where makcb = @makcb order by ngaykham) and benhchinh = 1)
		end
	)
	ma_benh,
	isnull((
		case 
			when 
				b1.dangdt=1 
			then
				Stuff((select ';' + mabenh from chandoanravien{1} where idravien in (select idravien from ravien{1} where makcb = @makcb) and benhchinh = 0 For Xml Path('')),1,1,'')
			else
				Stuff((select ';' + mabenh from chandoankhambenh{1} where idkhambenh in (select idkhambenh from khambenh{1} where makcb = @makcb) and mabenh not in (select top 1 mabenh from chandoankhambenh{1} where idkhambenh = (select top 1 idkhambenh from khambenh{1} where makcb = @makcb order by ngaykham) and benhchinh = 1) For Xml Path('')),1,1,'')
		end
	),'')
	ma_benhkhac,
	isnull((case when isnull(b1.cappcuu,0)=1 then 2 else (case when Exists(select top 1 1 from dmtuyendksd where matdk=b1.matdk and matltdk=1) then 1 else 3 end) end ),'')ma_lydo_vvien,
	isnull(b1.mangt,'') ma_noi_chuyen,isnull((select top 1 phanloaitainan from tainanthuongtich where makcb = @makcb),'')ma_tai_nan,
	(case when b1.dangdt=1 then isnull((select replace(convert(nvarchar,ngay,111),'/','') + replace(left(convert(nvarchar,ngay,108),5),':','') from dangkynhapvien{1} where makcb =@makcb),'') else replace(convert(nvarchar,b1.ngaydk,111),'/','') + replace(left(convert(nvarchar,b1.ngaydk,108),5),':','') end)  ngay_vao,
	replace(convert(nvarchar,b3.ngay,111),'/','') + replace(left(convert(nvarchar,b3.ngay,108),5),':','') ngay_ra,convert(int,b3.songaydieutri) so_ngay_dtri,b3.makq ket_qua_dtri,b3.mahtr tinh_trang_rv,
	replace(convert(nvarchar,b4.ngaytt,111),'/','') + replace(left(convert(nvarchar,b4.ngaytt,108),5),':','') ngay_ttoan,b4.pthuong muc_huong,0 t_thuoc,0 t_vtyt,b4.tongchiphi-b4.tongtientru-b4.tongbn100 t_tongchi,convert(decimal(18,2),b4.tienbntt - b4.tongbn100) t_bntt,
	convert(decimal(18,2),b4.tienbh) t_bhtt,0 t_nguonkhac,0 t_ngoaids,year(b4.ngaytt) nam_qt,month(b4.ngaytt) thang_qt,
	(case when b1.dtngoaitru = 1 then 2 else (case when b1.dangdt=1 then 3 else 1 end) end) ma_loai_kcb,
	b3.makk ma_khoa,isnull((select madonvi from {2}..tblConfigKK where makk = b3.makk),'') ma_cskcb,
	isnull((select tennss from dmnoiss where manss = b1.manss),'') ma_khuvuc,'' ma_pttt_qt,
		(
			case 
				when 
					b1.dangdt = 1 
				then 
					isnull(replace(isnull((select top 1 cannang from dienbien{1} where isnull(cannang,'') &lt;&gt; '' and idthanhtoan in (select idthanhtoan from ttphieuthanhtoan{1} where makcb = @makcb and makk = b3.makk)),''),',','.'),'')
				else 
					isnull(replace(isnull((select top 1 cannang from chisosinhton{1} where isnull(cannang,'') &lt;&gt; '' and idsinhton = (select top 1 idkhambenh from khambenh{1} where makcb = @makcb and makk = b3.makk)),''),',','.'),'')
			end) can_nang
From dangky{1} b1
join dmphai b2 on b1.maphai=b2.maphai
left join ravien{1} b3 on b3.makcb=b1.makcb
left join ttthanhtoanravien{1}	b4 on b4.makcb = b1.makcb
where b1.makcb =@makcb
                   </SQL>.Value
        _SQL = String.Format(_SQL, makcb, BangBN, dbXML.DatabaseName)
        Return dbHis.GetTable(_SQL)
    End Function
    Private Function GetDTThuoc(ByVal makcb As String) As DataTable
        Dim _SQL = <SQL>
declare @makcb as nvarchar(50)
set @makcb ='{0}'
select @makcb ma_lk,1 stt,isnull(b4.{2},'') ma_thuoc,b4.manhombh ma_nhom,b4.tenhh ten_thuoc,
b4.dvt don_vi_tinh,isnull(b4.hamluong,'') ham_luong,b6.maddtt duong_dung,isnull(b3.ghichu,'.') lieu_dung,
isnull(sodangky,'') so_dang_ky,convert(decimal(18,2),b3.soluong-isnull((select Sum(soluong) from tttralaihhchitiet_thuoc{1} where idttchitiet = b3.idttchitiet),0)) so_luong,
convert(decimal(18,2),isnull(b3.giabhytcn,b3.dongia)) don_gia,
convert(decimal(18,0),b3.tyle) tyle_tt, 
convert(decimal(18,2),convert(decimal(18,2),b3.soluong-isnull((select Sum(soluong) from tttralaihhchitiet_thuoc{1} where idttchitiet = b3.idttchitiet),0)) * convert(decimal(18,2),isnull(b3.giabhytcn,b3.dongia)) * convert(decimal(18,0),b3.tyle) / convert(decimal(18,0),100)) thanh_tien,
b2.makk ma_khoa,b5.chungchihn ma_bac_si,
isnull((case when b2.idkhambenh is not null then (select top 1 mabenh from chandoankhambenh{1} where idkhambenh = b2.idkhambenh) else (select top 1 mabenh from chandoandieutri{1} where iddieutri = b2.iddieutri) end),'') ma_benh,
replace(convert(nvarchar,b2.ngay,111),'/','') + left(replace(convert(nvarchar,b2.ngay,108),':',''),4) ngay_yl,0 ma_pttt
From dangky{1} b1
join ttphieuthanhtoan{1} b2 on b1.makcb=b2.makcb
join ttphieuttchitiet_thuoc{1} b3 on b3.idthanhtoan=b2.idthanhtoan and b3.makhoan not in (select makhoan from dmkhoan where maloaik=2 or maloaik = 4)
join dmthuocvattu b4 on b4.idhh=b3.idhh
join dmnhanvien b5 on b5.manv = b2.manv
join dmduongdung b6 on b6.maduongdung=b4.maduongdung
where b1.makcb = @makcb and b3.makhoan not in (select makhoan from dmkhoan where maloaik = 2 or maloaik=4)
and manhombh in (4,5,6,7)
and isnull(b4.{2},'') &lt;&gt; ''

Union All 

select @makcb ma_lk,1 stt,b4.{3} ma_dich_vu,b4.manhombh ma_nhom,b6.tendv ten_thuoc,
b7.tendonvitinh don_vi_tinh,'' ham_luong,'' duong_dung,'.' lieu_dung,'' so_dang_ky,convert(decimal(18,2),b3.soluong-isnull((select Sum(soluong) from tttralaihhchitiet_dichvu{1} where idttchitiet = b3.idttchitiet),0)) so_luong,convert(decimal(18,0),b3.dongia) don_gia,
convert(decimal(18,0),b3.tyle) tyle_tt, 
convert(decimal(18,2),convert(decimal(18,2),b3.soluong-isnull((select Sum(soluong) from tttralaihhchitiet_dichvu{1} where idttchitiet = b3.idttchitiet),0)) * convert(decimal(18,2),b3.dongia) * convert(decimal(18,0),b3.tyle) / convert(decimal(18,0),100)) thanh_tien,
b2.makk ma_khoa,b5.chungchihn ma_bac_si,isnull((case when b2.idkhambenh is not null then isnull((select top 1 mabenh from chandoankhambenh{1} where idkhambenh=b2.idkhambenh and benhchinh = 1),'') else isnull((select top 1 mabenh from chandoandieutri{1} where iddieutri=b2.iddieutri and benhchinh = 1),'') end),'') ma_benh,
replace(convert(nvarchar,b2.ngay,111),'/','') + replace(left(convert(nvarchar,b2.ngay,108),5),':','') ngay_yl,0 ma_pttt
From dangky{1} b1
join ttphieuthanhtoan{1} b2 on b1.makcb=b2.makcb
join ttphieuttchitiet_dichvu{1} b3 on b3.idthanhtoan=b2.idthanhtoan and b3.makhoan not in (select makhoan from dmkhoan where maloaik=2 or maloaik = 4)
join dmdichvu b4 on b4.madv=b3.madv
join dmnhanvien b5 on b5.manv = b2.manv
join tendvtheongay b6 on b6.madv = b4.madv and ngayad='{5}' and b6.madt={4}
join dmdonvitinh b7 on b7.donvitinhid=b4.donvitinhid
where b1.makcb = @makcb and b3.makhoan not in (select makhoan from dmkhoan where maloaik = 2 or maloaik=4)
and manhombh in (4,5,6,7)
and isnull(b4.{3},'')  &lt;&gt; ''
                   </SQL>.Value
        _SQL = String.Format(_SQL, makcb, BangBN, _CotTenThuoc, _CotTenDV, _drBN!madt, _ngayad)
        Return dbHis.GetTable(_SQL)
    End Function
    Private Function GetDTDichVu(ByVal makcb As String) As DataTable
        Dim _SQL = <SQL>
declare @makcb as nvarchar(50)
set @makcb ='{0}'
select @makcb ma_lk,1 stt,b4.{4} ma_dich_vu,'' ma_vat_tu,b4.manhombh ma_nhom,b6.tendv ten_dich_vu,
b7.tendonvitinh don_vi_tinh,convert(decimal(18,2),b3.soluong-isnull((select Sum(soluong) from tttralaihhchitiet_dichvu{1} where idttchitiet = b3.idttchitiet),0)) so_luong,convert(decimal(18,0),b3.dongia) don_gia,
convert(decimal(18,0),b3.tyle) tyle_tt, 
convert(decimal(18,0),convert(decimal(18,2),b3.soluong-isnull((select Sum(soluong) from tttralaihhchitiet_dichvu{1} where idttchitiet = b3.idttchitiet),0)) * convert(decimal(18,0),b3.dongia) * convert(decimal(18,0),b3.tyle) / convert(decimal(18,0),100)) thanh_tien,
b2.makk ma_khoa,b5.chungchihn ma_bac_si,(case when b2.idkhambenh is not null then isnull((select top 1 mabenh from chandoankhambenh{1} where idkhambenh=b2.idkhambenh and benhchinh = 1),'') else isnull((select top 1 mabenh from chandoandieutri{1} where iddieutri=b2.iddieutri and benhchinh = 1),'') end) ma_benh,
replace(convert(nvarchar,b2.ngay,111),'/','') + replace(left(convert(nvarchar,b2.ngay,108),5),':','') ngay_yl,isnull((select top 1 replace(convert(nvarchar,ngay,111),'/','')+ replace(left(convert(nvarchar,ngay,108),5),':','') from dalam{1} where madv =b4.madv and idthanhtoan=b2.idthanhtoan),'') ngay_kq,0 ma_pttt
From dangky{1} b1
join ttphieuthanhtoan{1} b2 on b1.makcb=b2.makcb
join ttphieuttchitiet_dichvu{1} b3 on b3.idthanhtoan=b2.idthanhtoan and b3.makhoan not in (select makhoan from dmkhoan where maloaik=2 or maloaik = 4)
join dmdichvu b4 on b4.madv=b3.madv
join dmnhanvien b5 on b5.manv = b2.manv
join tendvtheongay b6 on b6.madv = b4.madv and ngayad='{2}' and b6.madt={3}
join dmdonvitinh b7 on b7.donvitinhid=b4.donvitinhid
where b1.makcb = @makcb and b3.makhoan not in (select makhoan from dmkhoan where maloaik = 2 or maloaik=4)
and manhombh in (1,2,3,12,13,14,15,8,9)
and isnull(b4.{4},'')  &lt;&gt; ''
Union All 
select @makcb ma_lk,1 stt,'' ma_dich_vu,b4.{5} ma_vat_tu,b4.manhombh ma_nhom,b4.tenhh ten_dich_vu,
b4.dvt don_vi_tinh,convert(decimal(18,2),b3.soluong-isnull((select Sum(soluong) from tttralaihhchitiet_thuoc{1} where idttchitiet = b3.idttchitiet),0)) so_luong,convert(decimal(18,2),isnull(b3.giabhytcn,b3.dongia)) don_gia,
convert(decimal(18,0),b3.tyle) tyle_tt, 
convert(decimal(18,2),convert(decimal(18,2),b3.soluong-isnull((select Sum(soluong) from tttralaihhchitiet_thuoc{1} where idttchitiet = b3.idttchitiet),0)) * convert(decimal(18,2),isnull(b3.giabhytcn,b3.dongia)) * convert(decimal(18,0),b3.tyle) / convert(decimal(18,0),100)) thanh_tien,
b2.makk ma_khoa,b5.chungchihn ma_bac_si,(case when b2.idkhambenh is not null then isnull((select top 1 mabenh from chandoankhambenh{1} where idkhambenh=b2.idkhambenh and benhchinh = 1),'') else isnull((select top 1 mabenh from chandoandieutri{1} where iddieutri=b2.iddieutri and benhchinh = 1),'') end) ma_benh,
replace(convert(nvarchar,b2.ngay,111),'/','') + replace(left(convert(nvarchar,b2.ngay,108),5),':','') ngay_yl,'' ngay_kq,0 ma_pttt
From dangky{1} b1
join ttphieuthanhtoan{1} b2 on b1.makcb=b2.makcb
join ttphieuttchitiet_thuoc{1} b3 on b3.idthanhtoan=b2.idthanhtoan
join dmthuocvattu b4 on b4.idhh=b3.idhh
join dmnhanvien b5 on b5.manv = b2.manv
where b1.makcb = @makcb and b3.makhoan not in (select makhoan from dmkhoan where maloaik = 2 or maloaik = 4)
and manhombh in (10,11)
and isnull(b4.{5},'') &lt;&gt; ''
                   </SQL>.Value
        _SQL = String.Format(_SQL, makcb, BangBN, _ngayad, _drBN!madt, _CotTenDV, _CotTenThuoc)
        Return dbHis.GetTable(_SQL)
    End Function
    Private Function GetDTCLS(ByVal makcb As String) As DataTable
        Dim _sql = <SQL>
declare @makcb as nvarchar(50)
set @makcb ='{0}'
select @makcb ma_lk,1 stt,b5.{2} ma_dich_vu,isnull(b6.macs,'') ma_chi_so,
isnull(b6.tencs,'') ten_chi_so,{3}isnull(b4.ketqua,''){4} gia_tri,isnull(b4.labid,'') ma_may,isnull(b7.mota,'') mo_ta,isnull(b7.ketluan,'') ket_luan,
replace(convert(nvarchar,b3.ngay,111),'/','') 
+ left(replace(convert(nvarchar,b3.ngay,108),':',''),4) ngay_kq
from
ttphieuthanhtoan{1} b1
join ttphieuttchitiet_dichvu{1} b2 on b1.idthanhtoan= b2.idthanhtoan and b2.makhoan not in (select makhoan from dmkhoan where maloaik=2 or maloaik = 4)
join dalam{1} b3 on b3.idthanhtoan=b2.idthanhtoan and b3.madv=b2.madv
left join ketquachiso{1} b4 on b4.idthanhtoan=b2.idthanhtoan and b4.madv=b2.madv
join dmdichvu b5 on b5.madv=b2.madv
left join dmchiso b6 on b6.macs=b4.macs
left join ketquachandoanhinhanh{1} b7 on b7.idthanhtoan=b2.idthanhtoan and b7.madv=b2.madv
where b1.makcb=@makcb and isnull(b5.{2},'') &lt;&gt; ''
                   </SQL>.Value
        _sql = String.Format(_sql, makcb, BangBN, _CotTenDV, sReplace, snChar)
        Return dbHis.GetTable(_sql)
    End Function
    Private Function GetDTDB(ByVal makcb As String) As DataTable
        Dim _sql = <SQL>
declare @makcb as nvarchar(50)
set @makcb ='{0}'
select @makcb ma_lk,1 stt,
isnull(N'Cân nặng: ' + convert(nvarchar,b2.cannang) + N'; ' + N'Chiều cao: ' + convert(nvarchar,b2.chieucao) + N'; ' + N'Mạch: ' + convert(nvarchar,b2.mach) + N'; ' + N'Nhiệt độ: ' + convert(nvarchar,b2.nhietdo) + N'; ' + N'Huyết áp: ' + convert(nvarchar,b2.huyetap),'') dien_bien,
'' hoi_chan,'' phau_thuat, replace(convert(nvarchar,b1.ngaykham,111),'/','') + left(replace(convert(nvarchar,b1.ngaykham,108),':',''),4) ngay_yl
From khambenh{1} b1
join chisosinhton{1} b2 on b1.idkhambenh=b2.idsinhton
Where makcb = @makcb and isnull(N'Cân nặng: ' + convert(nvarchar,b2.cannang) + N'; ' + N'Chiều cao: ' + convert(nvarchar,b2.chieucao) + N'; ' + N'Mạch: ' + convert(nvarchar,b2.mach) + N'; ' + N'Nhiệt độ: ' + convert(nvarchar,b2.nhietdo) + N'; ' + N'Huyết áp: ' + convert(nvarchar,b2.huyetap),'') &lt;&gt; ''
Union All
select @makcb ma_lk,1 stt,
isnull({2}b2.dienbien{3},'') dien_bien,
'' hoi_chan,'' phau_thuat, replace(convert(nvarchar,b1.ngay,111),'/','') + left(replace(convert(nvarchar,b1.ngay,108),':',''),4) ngay_yl
From ttphieuthanhtoan{1} b1
join dienbien{1} b2 on b1.idthanhtoan=b2.idthanhtoan
Where makcb = @makcb and iddieutri is not null and replace(replace(isnull(b2.dienbien,''),char(10),''),char(13),'') &lt;&gt; ''
Union All
select @makcb ma_lk,1 stt,
isnull(b1.mota,'') dien_bien,
'' hoi_chan,'' phau_thuat, replace(convert(nvarchar,b1.ngaychidinh,111),'/','') + left(replace(convert(nvarchar,b1.ngaychidinh,108),':',''),4) ngay_yl
From phauthuat{1} b1
Where makcb = @makcb and iddieutri is not null and  replace(replace(isnull(b1.mota,''),char(10),''),char(13),'') &lt;&gt; ''
and isnull(b1.mota,'')  &lt;&gt; ''
                   </SQL>.Value
        _sql = String.Format(_sql, makcb, BangBN, sReplace, snChar)
        Return dbHis.GetTable(_sql)
    End Function
    Public Function GetXML() As Boolean
        Dim _ds As New DataSet()
        _ds.Tables.Add(GetDTHC(_drBN!makcb))
        _ds.Tables.Add(GetDTThuoc(_drBN!makcb))
        _ds.Tables.Add(GetDTDichVu(_drBN!makcb))
        _ds.Tables.Add(GetDTCLS(_drBN!makcb))
        _ds.Tables.Add(GetDTDB(_drBN!makcb))
        For Each item In _ds.Tables
            For Each item2 As DataColumn In item.Columns
                item2.ColumnName = item2.ColumnName.ToUpper
            Next
        Next
        _ds.Tables(0).Rows(0)!t_thuoc = _ds.Tables(1).Compute("Sum(thanh_tien)", "")
        If _ds.Tables(0).Rows(0)!t_thuoc Is DBNull.Value Then
            _ds.Tables(0).Rows(0)!t_thuoc = 0
        End If
        _ds.Tables(0).Rows(0)!t_vtyt = _ds.Tables(2).Compute("Sum(thanh_tien)", "ma_nhom in (10,11)")
        If _ds.Tables(0).Rows(0)!t_vtyt Is DBNull.Value Then
            _ds.Tables(0).Rows(0)!t_vtyt = 0
        End If
        Return RipXML(_ds)
    End Function
    Function RipXML(ByVal ds As DataSet) As Boolean
        ds.Tables(0).TableName = "TONG_HOP"
        ds.Tables(1).TableName = "CHI_TIET_THUOC"
        ds.Tables(2).TableName = "CHI_TIET_DVKT"
        ds.Tables(3).TableName = "CHI_TIET_CLS"
        ds.Tables(4).TableName = "CHI_TIET_DIEN_BIEN_BENH"

        Dim ioStream As System.IO.MemoryStream, xml As String
        Dim mSql = "<GIAMDINHHS>"
        mSql &= vbNewLine & "	<THONGTINDONVI>"
        mSql &= vbNewLine & "		<MACSKCB>" & _drConfig!madonvi & "</MACSKCB>"
        mSql &= vbNewLine & "	</THONGTINDONVI>"
        mSql &= vbNewLine & "	<THONGTINHOSO>"
        mSql &= vbNewLine & "		<NGAYLAP>" & Today.ToString("yyyyMMdd") & "</NGAYLAP>"
        mSql &= vbNewLine & "		<SOLUONGHOSO>1</SOLUONGHOSO>"
        mSql &= vbNewLine & "		<DANHSACHHOSO>"
        mSql &= vbNewLine & "			<HOSO>"

        If (ds.Tables(0).Rows.Count > 0) Then
            ds.DataSetName = "CHITIEUTONGHOPKCBBHYT"
            ioStream = New System.IO.MemoryStream
            ds.Tables(0).WriteXml(ioStream)
            xml = Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes("﻿<?xml version=""1.0"" encoding=""utf-8""?>" & vbCrLf & System.Text.Encoding.UTF8.GetString(ioStream.ToArray).Replace("<CHITIEUTONGHOPKCBBHYT>" & vbCrLf & "  ", "").Replace(vbCrLf & "</CHITIEUTONGHOPKCBBHYT>", "")))
            ioStream.Close()
            ioStream = Nothing

            mSql &= vbNewLine & "				<FILEHOSO>"
            mSql &= vbNewLine & "					<LOAIHOSO>XML1</LOAIHOSO>"
            mSql &= vbNewLine & "					<NOIDUNGFILE>" & xml & "</NOIDUNGFILE>"
            mSql &= vbNewLine & "				</FILEHOSO>"
        End If
        If (ds.Tables(1).Rows.Count > 0) Then
            ds.DataSetName = "DSACH_CHI_TIET_THUOC"
            ioStream = New System.IO.MemoryStream
            ds.Tables(1).WriteXml(ioStream)
            xml = Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(System.Text.Encoding.UTF8.GetString(ioStream.ToArray())))
            ioStream.Close()
            ioStream = Nothing

            mSql &= vbNewLine & "				<FILEHOSO>"
            mSql &= vbNewLine & "					<LOAIHOSO>XML2</LOAIHOSO>"
            mSql &= vbNewLine & "					<NOIDUNGFILE>" & xml & "</NOIDUNGFILE>"
            mSql &= vbNewLine & "				</FILEHOSO>"
        End If
        If (ds.Tables(2).Rows.Count > 0) Then
            ds.DataSetName = "DSACH_CHI_TIET_DVKT"
            ioStream = New System.IO.MemoryStream
            ds.Tables(2).WriteXml(ioStream)
            xml = Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(System.Text.Encoding.UTF8.GetString(ioStream.ToArray())))
            ioStream.Close()
            ioStream = Nothing

            mSql &= vbNewLine & "				<FILEHOSO>"
            mSql &= vbNewLine & "					<LOAIHOSO>XML3</LOAIHOSO>"
            mSql &= vbNewLine & "					<NOIDUNGFILE>" & xml & "</NOIDUNGFILE>"
            mSql &= vbNewLine & "				</FILEHOSO>"
        End If
        If (ds.Tables(3).Rows.Count > 0) Then
            ds.DataSetName = "DSACH_CHI_TIET_CLS"
            ioStream = New System.IO.MemoryStream
            ds.Tables(3).WriteXml(ioStream)
            xml = Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(System.Text.Encoding.UTF8.GetString(ioStream.ToArray())))
            ioStream.Close()
            ioStream = Nothing

            mSql &= vbNewLine & "				<FILEHOSO>"
            mSql &= vbNewLine & "					<LOAIHOSO>XML4</LOAIHOSO>"
            mSql &= vbNewLine & "					<NOIDUNGFILE>" & xml & "</NOIDUNGFILE>"
            mSql &= vbNewLine & "				</FILEHOSO>"
        End If
        If (ds.Tables(4).Rows.Count > 0) Then
            ds.DataSetName = "DSACH_CHI_TIET_DIEN_BIEN_BENH"
            ioStream = New System.IO.MemoryStream
            ds.Tables(4).WriteXml(ioStream)
            xml = Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(System.Text.Encoding.UTF8.GetString(ioStream.ToArray())))
            ioStream.Close()
            ioStream = Nothing

            mSql &= vbNewLine & "				<FILEHOSO>"
            mSql &= vbNewLine & "					<LOAIHOSO>XML5</LOAIHOSO>"
            mSql &= vbNewLine & "					<NOIDUNGFILE>" & xml & "</NOIDUNGFILE>"
            mSql &= vbNewLine & "				</FILEHOSO>"
        End If
        mSql &= vbNewLine & "			</HOSO>"
        mSql &= vbNewLine & "		</DANHSACHHOSO>"
        mSql &= vbNewLine & "	</THONGTINHOSO>"
        mSql &= vbNewLine & "	<CHUKYDONVI/>"
        mSql &= vbNewLine & "</GIAMDINHHS>"
        Dim FileName As String = "KCB_" & _drConfig!madonvi & "_" & ds.Tables(0).Rows(0)("NGAY_TTOAN").ToString & "_" & _drBN!makcb & ".xml"
        xml = mSql
        XmlReturn_ = xml
        Dim _dt As DataTable = dbXML.GetTable("select * from XmlFile where makcb = N'" & _drBN!makcb & "'")
        If _dt.Rows.Count = 0 Then
            _dt.Rows.Add(_dt.NewRow)
        End If
        _dt.Rows(0)!makk = _drConfig!makk
        _dt.Rows(0)!xml = xml
        _dt.Rows(0)!makcb = _drBN!makcb
        _dt.Rows(0)!dangdt = _drBN!dangdt + 1
        _dt.Rows(0)!madt = _drBN!madt
        _dt.Rows(0)!dtngoaitru = _drBN!dtngoaitru
        _dt.Rows(0)!BangBN = BangBN
        If Not String.IsNullOrEmpty(_drBN!dtngoaitru) AndAlso _drBN!dtngoaitru Then
            _dt.Rows(0)!dangdt += 4
        End If

        If _drThanhToan IsNot Nothing Then
            _dt.Rows(0)!ngaytt = _drThanhToan!ngaytt
            _dt.Rows(0)!datt = _drThanhToan!datt
        End If
        If dbXML.UpdateData(_dt, "select * from xmlfile where makcb = N'" & _drBN!makcb & "'") Then
            Return True
        Else
            Return False
        End If
    End Function
End Class
Public Class clsCreateXML4210
    Public XmlReturn_ As String = ""
    Dim BangBN As String = ""
    Dim _drBN As DataRow
    Dim _drConfig As DataRow
    Dim _drThanhToan As DataRow
    Dim _drRaVien As DataRow
    Dim _ngayad = ""
    Dim _benhBN As String = ""
    Dim muc_huong As Decimal = 0
    Dim pt_the As Decimal = 0
    Dim mIni As New clsIniFile
    Dim snChar As String = ",nChar(0x00) Collate Latin1_General_BIN , N''),nChar(0),N''),nChar(1),N''),nChar(2),N''),nChar(3),N''),nChar(4),N''),nChar(5),N''),nChar(6),N''),nChar(7),N''),nChar(8),N''),nChar(11),N''),nChar(12),N''),nChar(14),N''),nChar(15),N''),nChar(16),N''),nChar(17),N''),nChar(18),N''),nChar(19),N''),nChar(20),N''),nChar(21),N''),nChar(22),N''),nChar(23),N''),nChar(24),N''),nChar(25),N''),nChar(26),N''),nChar(27),N''),nChar(28),N''),nChar(29),N''),nChar(30),N''),nChar(31),N'')"
    Dim sReplace As String = "Replace(Replace(Replace(Replace(Replace(Replace(Replace(Replace(Replace(Replace(Replace(Replace(Replace(Replace(Replace(Replace(Replace(Replace(Replace(Replace(Replace(Replace(Replace(Replace(Replace(Replace(Replace(Replace(Replace(Replace("
    Sub New(ByVal makcb As String, ByVal SDBHis As String, ByVal SDBXML As String)
        dbHis = New MyData.Database(SDBHis)
        dbXML = New MyData.Database(SDBXML)
        BangBN = TimBangBN(makcb)
        _drBN = dbHis.GetTable("select * from dangky" & BangBN & " where makcb =N'" & makcb & "'").Rows(0)
        _drRaVien = dbHis.GetTable("select * from ravien" & BangBN & " where makcb = '" & makcb & "'").Rows(0)
        _benhBN = dbHis.GetTable("select isnull((select top 1 mabenh from chandoanravien" & BangBN & " where benhchinh = 1 and idravien in (select idravien from ravien" & BangBN & " where makcb = '" & makcb & "')),isnull((select top 1 mabenh from chandoandieutri" & BangBN & " where benhchinh = 1 and iddieutri in (select iddieutri from dieutri" & BangBN & " where makcb = '" & makcb & "')),isnull((select top 1 mabenh from chandoankhambenh" & BangBN & " where benhchinh = 1 and idkhambenh in (select idkhambenh from khambenh" & BangBN & " where makcb = '" & makcb & "')),'')))").Rows(0)(0).ToString
        Dim _makkCuoi As Integer = _drRaVien!makk
        Dim _dttemp = dbHis.GetTable("select * from ttthanhtoanravien" & BangBN & " where makcb = N'" & makcb & "'")
        If _dttemp.Rows.Count > 0 Then
            _drThanhToan = _dttemp.Rows(0)
            muc_huong = _drThanhToan!pthuong
        Else
            muc_huong = 0
        End If
        Dim _sql As String = <SQL>
DECLARE	@ptbenhnhanhuong decimal(18, 5),
		@ptthe decimal(18, 5)
EXEC	TimMucHuong
			@laytheoptthe = 0,
			@makcb = N'<%= makcb %>',
			@tienbn = -1,
			@ptbenhnhanhuong = @ptbenhnhanhuong OUTPUT,
			@ptthe = @ptthe OUTPUT
SELECT	@ptbenhnhanhuong as N'ptbenhnhanhuong',
		@ptthe as N'ptthe'
                             </SQL>.Value

        _dttemp = dbHis.GetTable(_sql)
        pt_the = _dttemp.Rows(0)!ptthe

        _drConfig = dbXML.GetTable("select * from tblconfigkk where makk = " & _makkCuoi).Rows(0)
        _ngayad = LayNgayAD(dbHis, CDate(_drBN!ngaydk).ToString("dd/MM/yyyy"), _drBN!madt)
        _CotTenThuoc = dbXML.GetTable("select top 1 * from tblConfigColumn where dichvu = 0").Rows(0)!cotdl.ToString
        _CotTenDV = dbXML.GetTable("select top 1 * from tblconfigcolumn where ngayad = '" & _ngayad & "' and dichvu = 1").Rows(0)!cotdl.ToString
    End Sub
    Private Function GetDTHC(ByVal makcb As String) As DataTable
        Dim _SQL = <SQL>
declare @makcb as nvarchar(50)
set @makcb ='{0}'
select 
	b1.makcb ma_lk,1 stt,b1.mabn ma_bn,b1.tenbn ho_ten,
	(case when isnull(b1.ngaysinh,'')='' then convert(nvarchar,b1.namsinh) + '0101' else replace(convert(nvarchar,b1.ngaysinh,111),'/','') end) ngay_sinh,
	(case when b2.tenphai like N'%nam%' then 1 else 2 end) gioi_tinh,
	b1.diachithe dia_chi,b1.mathe+ b1.maql + b1.matinh + b1.maquan +b1.madonvi+b1.thutu + isnull(Stuff((select ';' + mathe + maql + matinh + maquan + madonvi + thutu from thebn where makcb = @makcb For Xml Path('')),1,0,''),'') ma_the,
    b1.mandk  + isnull(Stuff((select ';' + mandk from thebn where makcb = @makcb For Xml Path('')),1,0,''),'') ma_dkbd,
	replace(convert(nvarchar,b1.ngaybd,111),'/','') + isnull(Stuff((select ';' + replace(convert(nvarchar,ngaybd,111),'/','') from thebn where makcb = @makcb For Xml Path('')),1,0,''),'')  gt_the_tu,
    replace(convert(nvarchar,b1.ngaykt,111),'/','') + isnull(Stuff((select ';' + replace(convert(nvarchar,ngaykt,111),'/','') from thebn where makcb = @makcb For Xml Path('')),1,0,''),'')  gt_the_den,
	(
	case 
	    when 
	        b1.dangdt=1 
	    then
	        Stuff((select ';' + b2.tenbenh from chandoandieutri{1} b1 join dmbenh b2 on b1.mabenh = b2.mabenh where iddieutri in (select iddieutri from dieutri{1} where makcb = @makcb) For Xml Path('')),1,1,'')
	    else
	    Stuff((select ';' + b2.tenbenh from chandoankhambenh{1} b1 join dmbenh b2 on b1.mabenh = b2.mabenh where idkhambenh in (select idkhambenh from khambenh{1} where makcb = @makcb) For Xml Path('')),1,1,'')
	end
	)ten_benh,
	(
		case 
			when 
				b1.dangdt=1 
			then
				(select top 1 mabenh from chandoanravien{1} where idravien in (select idravien from ravien{1} where makcb = @makcb) and benhchinh = 1)
			else
				(select top 1  mabenh from chandoankhambenh{1} where idkhambenh = (select top 1 idkhambenh from khambenh{1} where makcb = @makcb order by ngaykham desc) and benhchinh = 1)
		end
	)
	ma_benh,
	isnull((
		case 
			when 
				b1.dangdt=1 
			then
				Stuff((select ';' + mabenh from chandoanravien{1} where idravien in (select idravien from ravien{1} where makcb = @makcb) and benhchinh = 0 For Xml Path('')),1,1,'')
			else
				Stuff((select ';' + mabenh from chandoankhambenh{1} where idkhambenh in (select idkhambenh from khambenh{1} where makcb = @makcb) and mabenh not in (select top 1 mabenh from chandoankhambenh{1} where idkhambenh = (select top 1 idkhambenh from khambenh{1} where makcb = @makcb order by ngaykham) and benhchinh = 1) For Xml Path('')),1,1,'')
		end
	),'')
	ma_benhkhac,
	'isnull((case when isnull(b1.capcuu,0)=1 then 2 else (case when Exists(select top 1 1 from dmtuyendksd where matdk=b1.matdk and matltdk=1) then 1 else 3 end) end ),'')ma_lydo_vvien,
	isnull(b1.mangt,'') ma_noi_chuyen,isnull((select top 1 phanloaitainan from tainanthuongtich where makcb = @makcb),'')ma_tai_nan,
	(case when b1.dangdt=1 then isnull((select replace(convert(nvarchar,ngay,111),'/','') + replace(left(convert(nvarchar,ngay,108),5),':','') from dangkynhapvien{1} where makcb =@makcb),'') else replace(convert(nvarchar,b1.ngaydk,111),'/','') + replace(left(convert(nvarchar,b1.ngaydk,108),5),':','') end)  ngay_vao,
	replace(convert(nvarchar,b3.ngay,111),'/','') + replace(left(convert(nvarchar,b3.ngay,108),5),':','') ngay_ra,convert(int,b3.songaydieutri) so_ngay_dtri,b3.makq ket_qua_dtri,b3.mahtr tinh_trang_rv,
	replace(convert(nvarchar,b4.ngaytt,111),'/','') + replace(left(convert(nvarchar,b4.ngaytt,108),5),':','') ngay_ttoan,convert(decimal(18,2),0) t_thuoc,convert(decimal(18,2),0) t_vtyt,convert(decimal(18,2),b4.tongchiphi-b4.tongtientru-b4.tongbn100) t_tongchi,
(case when isnull((case when isnull(b1.cappcuu,0)=1 then 2 else (case when Exists(select top 1 1 from dmtuyendksd where matdk=b1.matdk and matltdk=1) then 1 else 3 end) end ),'') = 3 then convert(decimal(18,2),b4.tienbntt - b4.tongbn100) else 0 end) t_bntt,
(case when isnull((case when isnull(b1.cappcuu,0)=1 then 2 else (case when Exists(select top 1 1 from dmtuyendksd where matdk=b1.matdk and matltdk=1) then 1 else 3 end) end ),'') = 3 then 0 else convert(decimal(18,2),b4.tienbntt - b4.tongbn100) end) t_bncct,

	convert(decimal(18,2),b4.tienbh) t_bhtt,0 t_nguonkhac,0 t_ngoaids,year(b4.ngaytt) nam_qt,month(b4.ngaytt) thang_qt,isnull(convert(nvarchar,ngay55,112),'') mien_cung_ct,
	(case when b1.dtngoaitru = 1 then 2 else (case when b1.dangdt=1 then 3 else 1 end) end) ma_loai_kcb,
	isnull(b5.mahis,'000' + convert(nvarchar,b3.makk)) ma_khoa,isnull((select madonvi from {2}..tblConfigKK where makk = b3.makk),'') ma_cskcb,
	isnull((select tennss from dmnoiss where manss = b1.manss),'') ma_khuvuc,'' ma_pttt_qt,
		(
			case 
				when 
					b1.dangdt = 1 
				then 
					isnull(replace(isnull((select top 1 cannang from dienbien{1} where isnull(cannang,'') &lt;&gt; '' and idthanhtoan in (select idthanhtoan from ttphieuthanhtoan{1} where makcb = @makcb and makk = b3.makk)),(select top 1 cannang from chisosinhton{1} where isnull(cannang,'') &lt;&gt; '' and idsinhton in (select idkhambenh from khambenh{1} where makcb = @makcb))),',','.'),'')
				else 
					isnull(replace(isnull((select top 1 cannang from chisosinhton{1} where isnull(cannang,'') &lt;&gt; '' and idsinhton = (select top 1 idkhambenh from khambenh{1} where makcb = @makcb and makk = b3.makk)),''),',','.'),'')
			end) can_nang
From dangky{1} b1
join dmphai b2 on b1.maphai=b2.maphai
left join ravien{1} b3 on b3.makcb=b1.makcb
left join ttthanhtoanravien{1}	b4 on b4.makcb = b1.makcb
left join dmkk b5 on b5.makk=b3.makk
where b1.makcb =@makcb
                   </SQL>.Value
        _SQL = String.Format(_SQL, makcb, BangBN, dbXML.DatabaseName)
        Return dbHis.GetTable(_SQL)
    End Function
    Private Function GetDTThuoc(ByVal makcb As String) As DataTable
        Dim _SQL = <SQL>
declare @makcb as nvarchar(50)
set @makcb ='{0}'

    select (select maloaik from dmkhoan where makhoan = b3.makhoan) maloaik,@makcb ma_lk,1 stt,isnull(b4.{2},'') ma_thuoc,b4.manhombh ma_nhom,b4.tenhh ten_thuoc,
    b4.dvt don_vi_tinh,isnull(b4.hamluong,'') ham_luong,b6.maddtt duong_dung,case when isnull(b3.ghichu,'') = '' then '.' else b3.ghichu end lieu_dung,
    isnull(sodangky,'') so_dang_ky,isnull(b4.ttthau,'.') tt_thau,1 pham_vi,convert(decimal(18,3),IsNull(b4.tylesoluongxml,1)*(b3.soluong-isnull((select Sum(soluong) from tttralaihhchitiet_thuoc{1} where idttchitiet = b3.idttchitiet),0))) so_luong,convert(decimal(18,3),isnull(b3.giabhytcn,b3.dongia)/IsNull(b4.tylesoluongxml,1)) don_gia,
    convert(decimal(18,0),b3.tyle) tyle_tt, 
    convert(decimal(18,2),convert(decimal(18,3),b3.soluong-isnull((select Sum(soluong) from tttralaihhchitiet_thuoc{1} where idttchitiet = b3.idttchitiet),0)) * convert(decimal(18,3),isnull(b3.giabhytcn,b3.dongia))) thanh_tien,
    (case when b3.pthuong is not null then b3.pthuong when b3.makhoan in (select makhoan from dmkhoan where maloaik=1) then 100 else {6} end) muc_huong
    ,0 t_nguonkhac, 
(case when isnull((case when isnull(b1.cappcuu,0)=1 then 2 else (case when Exists(select top 1 1 from dmtuyendksd where matdk=b1.matdk and matltdk=1) then 1 else 3 end) end ),'') = 3 then convert(decimal(18,2),b3.tienbn) else 0 end) + (case when isnull(b3.tyle,100) = 100 then 0 else convert(decimal(18,2),convert(decimal(18,2),(b3.soluong-isnull((select Sum(soluong) from tttralaihhchitiet_thuoc<%= BangBN %> where idttchitiet = b3.idttchitiet),0)) * convert(decimal(18,2),isnull(b3.giabhytcn,b3.dongia))) * convert(decimal(18,2),(100 - b3.tyle)) / convert(decimal(18,2),100)) end)
 t_bntt,
convert(decimal(18,2),b3.tienbh) t_bhtt,

0 t_ngoaids,
   
    (
        case 
        when 
            isnull
            (
                (
                    case 
                    when 
                        isnull(b1.cappcuu,0)=1 
                    then 
                        2 
                    else 
                        (
                            case 
                            when 
                                Exists(select top 1 1 from dmtuyendksd where matdk=b1.matdk and matltdk=1) 
                            then 
                                1 
                            else 
                                3 
                            end
                        ) 
                    end 
                )
            ,'') = 3 
        then 
            0 
        else 
            convert(decimal(18,2),b3.tienbn) 
        end
    ) t_bncct,

   isnull(b7.mahis,'000' + convert(nvarchar,b3.makk)) ma_khoa,b5.chungchihn ma_bac_si,isnull((case when b2.idkhambenh is not null then isnull((select top 1 mabenh from chandoankhambenh{1} where idkhambenh = b2.idkhambenh and benhchinh = 1),N'<%= _benhBN %>') else (select top 1 mabenh from chandoandieutri{1} where iddieutri = b2.iddieutri and benhchinh = 1) end),N'<%= _benhBN %>') ma_benh,replace(convert(nvarchar,b2.ngay,111),'/','') + left(replace(convert(nvarchar,b2.ngay,108),':',''),4) ngay_yl,0 ma_pttt
    From dangky{1} b1
    join ttphieuthanhtoan{1} b2 on b1.makcb=b2.makcb
    join ttphieuttchitiet_thuoc{1} b3 on b3.idthanhtoan=b2.idthanhtoan and b3.makhoan not in (select makhoan from dmkhoan where maloaik=2 or maloaik = 4)
    join dmthuocvattu b4 on b4.idhh=b3.idhh
    join dmnhanvien b5 on b5.manv = b2.manv
    join dmduongdung b6 on b6.maduongdung=b4.maduongdung
    join dmkk b7 on b7.makk=b2.makk
    where b1.makcb = @makcb and b3.makhoan not in (select makhoan from dmkhoan where maloaik = 2 or maloaik=4) 
    and convert(decimal(18,2),convert(decimal(18,2),b3.soluong-isnull((select Sum(soluong) from tttralaihhchitiet_thuoc{1} where idttchitiet = b3.idttchitiet),0)) * convert(decimal(18,2),isnull(b3.giabhytcn,b3.dongia)) * convert(decimal(18,0),b3.tyle) / convert(decimal(18,0),100)) &gt; 0
    and manhombh in (4,5,6,7)
    and isnull(b4.{2},'') &lt;&gt; ''
    and isnull(b3.lenphoibh,1)=1
            Union All

    select (select maloaik from dmkhoan where makhoan = b3.makhoan) maloaik,@makcb ma_lk,1 stt,b4.{3} ma_dich_vu,b4.manhombh ma_nhom,b4.tenbhyt ten_thuoc,
    b7.tendonvitinh don_vi_tinh,'' ham_luong,'' duong_dung,'.' lieu_dung,'' so_dang_ky,'' tt_thau,1 pham_vi,convert(decimal(18,3),b3.soluong-isnull((select Sum(soluong) from tttralaihhchitiet_dichvu{1} where idttchitiet = b3.idttchitiet),0)) so_luong,convert(decimal(18,3),b3.dongia) don_gia,
    convert(decimal(18,0),b3.tyle) tyle_tt, 
    convert(decimal(18,2),convert(decimal(18,3),b3.soluong-isnull((select Sum(soluong) from tttralaihhchitiet_dichvu{1} where idttchitiet = b3.idttchitiet),0)) * convert(decimal(18,2),b3.dongia)) thanh_tien,
    (case  when b3.pthuong is not null then b3.pthuong when b3.makhoan in (select makhoan from dmkhoan where maloaik=1) then 100 else {6} end) muc_huong
    ,0 t_nguonkhac,
(case when isnull((case when isnull(b1.cappcuu,0)=1 then 2 else (case when Exists(select top 1 1 from dmtuyendksd where matdk=b1.matdk and matltdk=1) then 1 else 3 end) end ),'') = 3 then convert(decimal(18,2),b3.tienbn) else (case when isnull(b3.tyle,100) = 100 then 0 else convert(decimal(18,2),convert(decimal(18,2),(b3.soluong-isnull((select Sum(soluong) from tttralaihhchitiet_thuoc{1} where idttchitiet = b3.idttchitiet),0)) * convert(decimal(18,2),isnull(b3.giabhytcn,b3.dongia))) * convert(decimal(18,2),(100 - b3.tyle)) / convert(decimal(18,2),100)) end) end)  t_bntt,

convert(decimal(18,2),b3.tienbh) t_bhtt,0 t_ngoaids,

(case when isnull((case when isnull(b1.cappcuu,0)=1 then 2 else (case when Exists(select top 1 1 from dmtuyendksd where matdk=b1.matdk and matltdk=1) then 1 else 3 end) end ),'') &lt;&gt; 3 then convert(decimal(18,2),b3.tienbn) else 0 end) t_bncct,
    isnull(b8.mahis,'000' + convert(nvarchar,b3.makk)) ma_khoa,b5.chungchihn ma_bac_si,isnull((case when b2.idkhambenh is not null then isnull((select top 1 mabenh from chandoankhambenh{1} where idkhambenh=b2.idkhambenh and benhchinh = 1),N'<%= _benhBN %>') else isnull((select top 1 mabenh from chandoandieutri{1} where iddieutri=b2.iddieutri and benhchinh = 1),N'<%= _benhBN %>') end),'') ma_benh,
    replace(convert(nvarchar,b2.ngay,111),'/','') + replace(left(convert(nvarchar,b2.ngay,108),5),':','') ngay_yl,0 ma_pttt
    From dangky{1} b1
    join ttphieuthanhtoan{1} b2 on b1.makcb=b2.makcb
    join ttphieuttchitiet_dichvu{1} b3 on b3.idthanhtoan=b2.idthanhtoan and b3.makhoan not in (select makhoan from dmkhoan where maloaik=2 or maloaik = 4)
    join dmdichvu b4 on b4.madv=b3.madv
    join dmnhanvien b5 on b5.manv = b2.manv
    join tendvtheongay b6 on b6.madv = b4.madv and ngayad='{5}' and b6.madt={4}
    join dmdonvitinh b7 on b7.donvitinhid=b4.donvitinhid
    join dmkk b8 on b8.makk=b2.makk
    where b1.makcb = @makcb and b3.makhoan not in (select makhoan from dmkhoan where maloaik = 2 or maloaik=4)
    and manhombh in (4,5,6,7)
    and isnull(b4.{3},'')  &lt;&gt; ''
    and isnull(b3.lenphoibh,1)=1 
                   </SQL>.Value
        _SQL = String.Format(_SQL, makcb, BangBN, _CotTenThuoc, _CotTenDV, _drBN!madt, _ngayad, muc_huong.ToString.Replace(".", "").Replace(",", "."))
        Return dbHis.GetTable(_SQL)
    End Function
    Private Function GetDTDichVu(ByVal makcb As String) As DataTable
        Dim _SQL = <SQL>
declare @makcb as nvarchar(50)
set @makcb ='{0}'

    select (select maloaik from dmkhoan where makhoan = b3.makhoan) maloaik,@makcb ma_lk,1 stt,b4.{4} ma_dich_vu,'' ma_vat_tu,b4.manhombh ma_nhom,'' goi_vtyt,'' ten_vat_tu,b4.tenbhyt ten_dich_vu,
    b7.tendonvitinh don_vi_tinh,1 pham_vi,convert(decimal(18,2),b3.soluong-isnull((select Sum(soluong) from tttralaihhchitiet_dichvu{1} where idttchitiet = b3.idttchitiet),0)) so_luong,convert(decimal(18,3),b3.dongia) don_gia,'' tt_thau,
    convert(decimal(18,0),b3.tyle) tyle_tt, 
    convert(decimal(18,2),convert(decimal(18,2),b3.soluong-isnull((select Sum(soluong) from tttralaihhchitiet_dichvu{1} where idttchitiet = b3.idttchitiet),0)) * convert(decimal(18,3),b3.dongia) * convert(decimal(18,2),b3.tyle) / convert(decimal(18,2),100)) thanh_tien
    ,'' t_trantt,(case when b3.pthuong is not null then b3.pthuong  when b3.makhoan in (select makhoan from dmkhoan where maloaik=1) then 100 else {6} end) muc_huong,0 t_nguonkhac,(case when isnull((case when isnull(b1.cappcuu,0)=1 then 2 else (case when Exists(select top 1 1 from dmtuyendksd where matdk=b1.matdk and matltdk=1) then 1 else 3 end) end ),'') = 3 then convert(decimal(18,2),b3.tienbn) else 0 end) t_bntt,

convert(decimal(18,2),b3.tienbh) t_bhtt,

(case when isnull((case when isnull(b1.cappcuu,0)=1 then 2 else (case when Exists(select top 1 1 from dmtuyendksd where matdk=b1.matdk and matltdk=1) then 1 else 3 end) end ),'') = 3 then 0 else convert(decimal(18,2),b3.tienbn) end) t_bncct,
0 t_ngoaids,
    isnull(b8.mahis,'000' + convert(nvarchar,b3.makk)) ma_khoa,<%= If(dbHis.GetTable("select top 1 1 from sys.columns where object_id=object_id('dmdichvu') and name = 'magiuong'").Rows.Count > 0, "IsNull(b4.magiuong,'')", "IsNull((select maxml from dmgiuong where magiuong = b3.magiuongxml),'')") %> ma_giuong,b5.chungchihn ma_bac_si,(case when b2.idkhambenh is not null then isnull((select top 1 mabenh from chandoankhambenh{1} where idkhambenh=b2.idkhambenh and benhchinh = 1),N'<%= _benhBN %>') else isnull((select top 1 mabenh from chandoandieutri{1} where iddieutri=b2.iddieutri and benhchinh = 1),N'<%= _benhBN %>') end) ma_benh,
    replace(convert(nvarchar,b2.ngay,111),'/','') + replace(left(convert(nvarchar,b2.ngay,108),5),':','') ngay_yl,isnull((select top 1 replace(convert(nvarchar,ngay,111),'/','')+ replace(left(convert(nvarchar,ngay,108),5),':','') from dalam{1} where madv =b4.madv and idthanhtoan=b2.idthanhtoan),'') ngay_kq,0 ma_pttt
    From dangky{1} b1
    join ttphieuthanhtoan{1} b2 on b1.makcb=b2.makcb
    join ttphieuttchitiet_dichvu{1} b3 on b3.idthanhtoan=b2.idthanhtoan and b3.makhoan not in (select makhoan from dmkhoan where maloaik=2 or maloaik = 4)
    join dmdichvu b4 on b4.madv=b3.madv
    join dmnhanvien b5 on b5.manv = b2.manv
    join tendvtheongay b6 on b6.madv = b4.madv and ngayad='{2}' and b6.madt={3}
    join dmdonvitinh b7 on b7.donvitinhid=b4.donvitinhid
    join dmkk b8 on b8.makk=b2.makk
    where b1.makcb = @makcb and b3.makhoan not in (select makhoan from dmkhoan where maloaik = 2 or maloaik=4)
    and convert(decimal(18,2),b3.soluong-isnull((select Sum(soluong) from tttralaihhchitiet_dichvu{1} where idttchitiet = b3.idttchitiet),0)) &gt; 0
    and manhombh in (1,2,3,12,13,14,15,8,9)
    and isnull(b4.{4},'')  &lt;&gt; ''
    and isnull(b3.lenphoibh,1)=1

    Union All 

    select (select maloaik from dmkhoan where makhoan = b3.makhoan) maloaik,@makcb ma_lk,1 stt,IsNull((select {4} from dmdichvu where madv = (select madv from ttphieuttchitiet_dichvu{1} where idttchitiet = b2.idctpt)),'') ma_dich_vu,b4.{5} ma_vat_tu,b4.manhombh ma_nhom,'' goi_vtyt,b4.tenhh ten_vat_tu,IsNull((select tendv from tendvtheongay where madv = (select madv from ttphieuttchitiet_dichvu{1} where idttchitiet = b2.idctpt) and madt = b1.madt and ngayad = '{2}'),'') ten_dich_vu,
    b4.dvt don_vi_tinh,1 pham_vi,convert(decimal(18,2),IsNull(b4.tylesoluongxml,1)*(b3.soluong-isnull((select Sum(soluong) from tttralaihhchitiet_thuoc{1} where idttchitiet = b3.idttchitiet),0))) so_luong,
convert(decimal(18,3),isnull(b3.giabhytcn,b3.dongia)/IsNull(b4.tylesoluongxml,1)) don_gia,isnull(b4.ttthau,'.') tt_thau,
    convert(decimal(18,0),b3.tyle) tyle_tt,
    convert(decimal(18,2),convert(decimal(18,3),b3.soluong-isnull((select Sum(soluong) from tttralaihhchitiet_thuoc{1} where idttchitiet = b3.idttchitiet),0)) * convert(decimal(18,3),isnull(b3.giabhytcn,b3.dongia))) thanh_tien
    ,'' t_trantt,(case when b3.pthuong is not null then b3.pthuong  when b3.makhoan in (select makhoan from dmkhoan where maloaik=1) then 100 else {6} end) muc_huong,0 t_nguonkhac,

(case when isnull((case when isnull(b1.cappcuu,0)=1 then 2 else (case when Exists(select top 1 1 from dmtuyendksd where matdk=b1.matdk and matltdk=1) then 1 else 3 end) end ),'') = 3 then convert(decimal(18,2),b3.tienbn) else 0 end) + (case when isnull(b3.tyle,100) = 100 then 0 else convert(decimal(18,2),convert(decimal(18,2),(b3.soluong-isnull((select Sum(soluong) from tttralaihhchitiet_thuoc{1} where idttchitiet = b3.idttchitiet),0)) * convert(decimal(18,2),isnull(b3.giabhytcn,b3.dongia))) * convert(decimal(18,2),(100 - b3.tyle)) / convert(decimal(18,2),100)) end)
 t_bntt,
convert(decimal(18,2),b3.tienbh) t_bhtt,
(case when isnull((case when isnull(b1.cappcuu,0)=1 then 2 else (case when Exists(select top 1 1 from dmtuyendksd where matdk=b1.matdk and matltdk=1) then 1 else 3 end) end ),'') = 3 then 0 else convert(decimal(18,2),b3.tienbn) end) t_bncct,0 t_ngoaids,
    isnull(b6.mahis,'000' + convert(nvarchar,b3.makk)) ma_khoa,'' ma_giuong,b5.chungchihn ma_bac_si,(case when b2.idkhambenh is not null then isnull((select top 1 mabenh from chandoankhambenh{1} where idkhambenh=b2.idkhambenh and benhchinh = 1),N'<%= _benhBN %>') else isnull((select top 1 mabenh from chandoandieutri{1} where iddieutri=b2.iddieutri and benhchinh = 1),N'<%= _benhBN %>') end) ma_benh,
    replace(convert(nvarchar,b2.ngay,111),'/','') + replace(left(convert(nvarchar,b2.ngay,108),5),':','') ngay_yl,'' ngay_kq,0 ma_pttt
    From dangky{1} b1
    join ttphieuthanhtoan{1} b2 on b1.makcb=b2.makcb
    join ttphieuttchitiet_thuoc{1} b3 on b3.idthanhtoan=b2.idthanhtoan
    join dmthuocvattu b4 on b4.idhh=b3.idhh
    join dmnhanvien b5 on b5.manv = b2.manv
    join dmkk b6 on b6.makk=b2.makk
    where b1.makcb = @makcb and b3.makhoan not in (select makhoan from dmkhoan where maloaik = 2 or maloaik = 4)  and convert(decimal(18,2),convert(decimal(18,2),b3.soluong-isnull((select Sum(soluong) from tttralaihhchitiet_thuoc{1} where idttchitiet = b3.idttchitiet),0)) * convert(decimal(18,2),isnull(b3.giabhytcn,b3.dongia)) * convert(decimal(18,0),b3.tyle) / convert(decimal(18,0),100)) &gt; 0
    and manhombh in (10,11)
    and isnull(b4.{5},'') &lt;&gt; '' 
    and isnull(b3.lenphoibh,1)=1
                   </SQL>.Value
        _SQL = String.Format(_SQL, makcb, BangBN, _ngayad, _drBN!madt, _CotTenDV, _CotTenThuoc, muc_huong.ToString.Replace(".", "").Replace(",", "."))
        Return dbHis.GetTable(_SQL)
    End Function
    Private Function GetDTCLS(ByVal makcb As String) As DataTable
        Dim _sql = <SQL>
declare @makcb as nvarchar(50)
set @makcb ='{0}'
select @makcb ma_lk,1 stt,b5.{2} ma_dich_vu,isnull(b6.chisoxml,'') ma_chi_so,
isnull(b6.tencs,'') ten_chi_so,{3}isnull(b4.ketqua,''){4} gia_tri,isnull(b8.mamayxn,'') ma_may,isnull(b7.mota,'') mo_ta,isnull(b7.ketluan,'') ket_luan,
replace(convert(nvarchar,b3.ngay,111),'/','') 
+ left(replace(convert(nvarchar,b3.ngay,108),':',''),4) ngay_kq
from
ttphieuthanhtoan{1} b1
join ttphieuttchitiet_dichvu{1} b2 on b1.idthanhtoan= b2.idthanhtoan and b2.makhoan not in (select makhoan from dmkhoan where maloaik=2 or maloaik = 4)
join dalam{1} b3 on b3.idthanhtoan=b2.idthanhtoan and b3.madv=b2.madv
left join ketquachiso{1} b4 on b4.idthanhtoan=b2.idthanhtoan and b4.madv=b2.madv
join dmdichvu b5 on b5.madv=b2.madv
left join dmchiso b6 on b6.macs=b4.macs
left join ketquachandoanhinhanh{1} b7 on b7.idthanhtoan=b2.idthanhtoan and b7.madv=b2.madv
Left Join dmmayxetnghiem b8 on b8.labid=b4.labid or b8.labid = b7.labid
where b1.makcb=@makcb and isnull(b5.{2},'') &lt;&gt; '' and isnull(b8.mamay,'') &lt;&gt; ''
                   </SQL>.Value
        _sql = String.Format(_sql, makcb, BangBN, _CotTenDV, sReplace, snChar)
        Return dbHis.GetTable(_sql)
    End Function
    Private Function GetDTDB(ByVal makcb As String) As DataTable
        Dim _sql = <SQL>
declare @makcb as nvarchar(50)
set @makcb ='{0}'
select @makcb ma_lk,1 stt,
isnull(N'Cân nặng: ' + convert(nvarchar,b2.cannang) + N'; ' + N'Chiều cao: ' + convert(nvarchar,b2.chieucao) + N'; ' + N'Mạch: ' + convert(nvarchar,b2.mach) + N'; ' + N'Nhiệt độ: ' + convert(nvarchar,b2.nhietdo) + N'; ' + N'Huyết áp: ' + convert(nvarchar,b2.huyetap),'') dien_bien,
'' hoi_chan,'' phau_thuat, replace(convert(nvarchar,b1.ngaykham,111),'/','') + left(replace(convert(nvarchar,b1.ngaykham,108),':',''),4) ngay_yl
From khambenh{1} b1
join chisosinhton{1} b2 on b1.idkhambenh=b2.idsinhton
Where makcb = @makcb and isnull(N'Cân nặng: ' + convert(nvarchar,b2.cannang) + N'; ' + N'Chiều cao: ' + convert(nvarchar,b2.chieucao) + N'; ' + N'Mạch: ' + convert(nvarchar,b2.mach) + N'; ' + N'Nhiệt độ: ' + convert(nvarchar,b2.nhietdo) + N'; ' + N'Huyết áp: ' + convert(nvarchar,b2.huyetap),'') &lt;&gt; ''
Union All
select @makcb ma_lk,1 stt,
isnull({2}b2.dienbien{3},'') dien_bien,
'' hoi_chan,'' phau_thuat, replace(convert(nvarchar,b1.ngay,111),'/','') + left(replace(convert(nvarchar,b1.ngay,108),':',''),4) ngay_yl
From ttphieuthanhtoan{1} b1
join dienbien{1} b2 on b1.idthanhtoan=b2.idthanhtoan
Where makcb = @makcb and iddieutri is not null and replace(replace(isnull(b2.dienbien,''),char(10),''),char(13),'') &lt;&gt; ''
Union All
select @makcb ma_lk,1 stt,
isnull(b1.mota,'') dien_bien,
'' hoi_chan,'' phau_thuat, replace(convert(nvarchar,b1.ngaychidinh,111),'/','') + left(replace(convert(nvarchar,b1.ngaychidinh,108),':',''),4) ngay_yl
From phauthuat{1} b1
Where makcb = @makcb and iddieutri is not null and  replace(replace(isnull(b1.mota,''),char(10),''),char(13),'') &lt;&gt; ''
and isnull(b1.mota,'')  &lt;&gt; ''
                   </SQL>.Value
        _sql = String.Format(_sql, makcb, BangBN, sReplace, snChar)
        Return dbHis.GetTable(_sql)
    End Function
    Public Function GetXML() As Boolean
        Dim _ds As New DataSet()
        _ds.Tables.Add(GetDTHC(_drBN!makcb))
        _ds.Tables.Add(GetDTThuoc(_drBN!makcb))
        _ds.Tables.Add(GetDTDichVu(_drBN!makcb))
        _ds.Tables.Add(GetDTCLS(_drBN!makcb))
        _ds.Tables.Add(GetDTDB(_drBN!makcb))

        If _ds.Tables(0).Rows(0)!ma_lydo_vvien = 3 Then
            Dim _dt = _ds.Tables(1)
            For Each item In _dt.Rows
                If item!maloaik = 1 Then Continue For
                Dim _tongtienbn = item!t_bntt
                Dim _tiencct = Math.Round(item!thanh_tien * item!tyle_tt * pt_the / 10000, 2) - item!t_bhtt
                Dim _tienbntt = Math.Round(_tongtienbn - _tiencct, 2)
                item!t_bncct = _tiencct
                item!t_bntt = _tienbntt
                If Not String.IsNullOrEmpty(_ds.Tables(0).Rows(0)!ma_khuvuc.ToString) Then
                    Dim oVal = item!t_bncct
                    item!t_bncct = item!t_bntt
                    item!t_bntt = oVal
                End If
            Next
            _dt = _ds.Tables(2)
            For Each item In _dt.Rows
                If item!maloaik = 1 Then Continue For
                If item!ma_nhom = 8 OrElse item!ma_nhom = 13 OrElse item!ma_nhom = 14 OrElse item!ma_nhom = 15 Then
                    Dim _tongtienbn = item!t_bntt
                    Dim _tiencct = Math.Round(item!thanh_tien * pt_the / 100, 2) - LocBien(item!t_bhtt, Kieu.So, 0)
                    Dim _tienbntt = Math.Round(_tongtienbn - _tiencct, 2)
                    item!t_bncct = _tiencct
                    item!t_bntt = _tienbntt
                Else
                    Dim _tongtienbn = item!t_bntt
                    Dim _tiencct = Math.Round(item!thanh_tien * item!tyle_tt * pt_the / 10000, 2) - LocBien(item!t_bhtt, Kieu.So, 0)
                    Dim _tienbntt = Math.Round(_tongtienbn - _tiencct, 2)
                    item!t_bncct = _tiencct
                    item!t_bntt = _tienbntt
                End If
                If Not String.IsNullOrEmpty(_ds.Tables(0).Rows(0)!ma_khuvuc.ToString) Then
                    Dim oVal = item!t_bncct
                    item!t_bncct = item!t_bntt
                    item!t_bntt = oVal
                End If
            Next
        End If

        _ds.Tables(1).Columns.Remove("maloaik")
        _ds.Tables(2).Columns.Remove("maloaik")
        For Each item In _ds.Tables
            For Each item2 As DataColumn In item.Columns
                item2.ColumnName = item2.ColumnName.ToUpper
            Next
        Next

        Try
            _ds.Tables(0).Rows(0)!t_bncct = CDec(FormatNumber(_ds.Tables(1).Compute("Sum(t_bncct)", ""), 2))
            If _ds.Tables(0).Rows(0)!t_bncct Is DBNull.Value Then
                _ds.Tables(0).Rows(0)!t_bncct = 0
            End If

        Catch ex As Exception
            _ds.Tables(0).Rows(0)!t_bncct = 0
        End Try
        Try
            Dim d2 As Decimal = CDec(FormatNumber(_ds.Tables(2).Compute("Sum(t_bncct)", ""), 2))
            If d2 > 0 Then
                _ds.Tables(0).Rows(0)!t_bncct += d2
            End If
        Catch ex As Exception
        End Try

        Try
            _ds.Tables(0).Rows(0)!t_bntt = CDec(FormatNumber(_ds.Tables(1).Compute("Sum(t_bntt)", ""), 2))
            If _ds.Tables(0).Rows(0)!t_bntt Is DBNull.Value Then
                _ds.Tables(0).Rows(0)!t_bntt = 0
            End If

        Catch ex As Exception
            _ds.Tables(0).Rows(0)!t_bntt = 0
        End Try
        Try
            Dim d2 As Decimal = CDec(FormatNumber(_ds.Tables(2).Compute("Sum(t_bntt)", ""), 2))
            If d2 > 0 Then
                _ds.Tables(0).Rows(0)!t_bntt += d2
            End If
        Catch ex As Exception
        End Try


        Try
            _ds.Tables(0).Rows(0)!t_tongchi = CDec(FormatNumber(_ds.Tables(1).Compute("Sum(thanh_tien)", ""), 2))
            If _ds.Tables(0).Rows(0)!t_tongchi Is DBNull.Value Then
                _ds.Tables(0).Rows(0)!t_tongchi = 0
            End If
        Catch ex As Exception
            _ds.Tables(0).Rows(0)!t_tongchi = 0
        End Try
        Try
            Dim d2 As Decimal = CDec(FormatNumber(_ds.Tables(2).Compute("Sum(thanh_tien)", ""), 2))
            If d2 > 0 Then
                _ds.Tables(0).Rows(0)!t_tongchi += d2
            End If
        Catch ex As Exception
        End Try


        Try
            _ds.Tables(0).Rows(0)!t_thuoc = CDec(FormatNumber(_ds.Tables(1).Compute("Sum(thanh_tien)", ""), 2))
            If _ds.Tables(0).Rows(0)!t_thuoc Is DBNull.Value Then
                _ds.Tables(0).Rows(0)!t_thuoc = 0
            End If
        Catch ex As Exception
            _ds.Tables(0).Rows(0)!t_thuoc = 0
        End Try
        Try
            _ds.Tables(0).Rows(0)!t_vtyt = CDec(FormatNumber(_ds.Tables(2).Compute("Sum(thanh_tien)", "ma_nhom in (10,11)"), 2))
            If _ds.Tables(0).Rows(0)!t_vtyt Is DBNull.Value Then
                _ds.Tables(0).Rows(0)!t_vtyt = 0
            End If
        Catch ex As Exception
            _ds.Tables(0).Rows(0)!t_vtyt = 0
        End Try

        Return RipXML(_ds)
    End Function
    Function RipXML(ByVal ds As DataSet) As Boolean
        ds.Tables(0).TableName = "TONG_HOP"
        ds.Tables(1).TableName = "CHI_TIET_THUOC"
        ds.Tables(2).TableName = "CHI_TIET_DVKT"
        ds.Tables(3).TableName = "CHI_TIET_CLS"
        ds.Tables(4).TableName = "CHI_TIET_DIEN_BIEN_BENH"

        Dim ioStream As System.IO.MemoryStream, xml As String
        Dim mSql = "<GIAMDINHHS>"
        mSql &= vbNewLine & "	<THONGTINDONVI>"
        mSql &= vbNewLine & "		<MACSKCB>" & _drConfig!madonvi & "</MACSKCB>"
        mSql &= vbNewLine & "	</THONGTINDONVI>"
        mSql &= vbNewLine & "	<THONGTINHOSO>"
        mSql &= vbNewLine & "		<NGAYLAP>" & Today.ToString("yyyyMMdd") & "</NGAYLAP>"
        mSql &= vbNewLine & "		<SOLUONGHOSO>1</SOLUONGHOSO>"
        mSql &= vbNewLine & "		<DANHSACHHOSO>"
        mSql &= vbNewLine & "			<HOSO>"

        If (ds.Tables(0).Rows.Count > 0) Then
            ds.DataSetName = "CHITIEUTONGHOPKCBBHYT"
            ioStream = New System.IO.MemoryStream
            ds.Tables(0).WriteXml(ioStream)
            xml = Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes("﻿<?xml version=""1.0"" encoding=""utf-8""?>" & vbCrLf & System.Text.Encoding.UTF8.GetString(ioStream.ToArray).Replace("<CHITIEUTONGHOPKCBBHYT>" & vbCrLf & "  ", "").Replace(vbCrLf & "</CHITIEUTONGHOPKCBBHYT>", "")))
            ioStream.Close()
            ioStream = Nothing

            mSql &= vbNewLine & "				<FILEHOSO>"
            mSql &= vbNewLine & "					<LOAIHOSO>XML1</LOAIHOSO>"
            mSql &= vbNewLine & "					<NOIDUNGFILE>" & xml & "</NOIDUNGFILE>"
            mSql &= vbNewLine & "				</FILEHOSO>"
        End If
        If (ds.Tables(1).Rows.Count > 0) Then
            ds.DataSetName = "DSACH_CHI_TIET_THUOC"
            ioStream = New System.IO.MemoryStream
            ds.Tables(1).WriteXml(ioStream)
            xml = Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(System.Text.Encoding.UTF8.GetString(ioStream.ToArray())))
            ioStream.Close()
            ioStream = Nothing

            mSql &= vbNewLine & "				<FILEHOSO>"
            mSql &= vbNewLine & "					<LOAIHOSO>XML2</LOAIHOSO>"
            mSql &= vbNewLine & "					<NOIDUNGFILE>" & xml & "</NOIDUNGFILE>"
            mSql &= vbNewLine & "				</FILEHOSO>"
        End If
        If (ds.Tables(2).Rows.Count > 0) Then
            ds.DataSetName = "DSACH_CHI_TIET_DVKT"
            ioStream = New System.IO.MemoryStream
            ds.Tables(2).WriteXml(ioStream)
            xml = Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(System.Text.Encoding.UTF8.GetString(ioStream.ToArray())))
            ioStream.Close()
            ioStream = Nothing

            mSql &= vbNewLine & "				<FILEHOSO>"
            mSql &= vbNewLine & "					<LOAIHOSO>XML3</LOAIHOSO>"
            mSql &= vbNewLine & "					<NOIDUNGFILE>" & xml & "</NOIDUNGFILE>"
            mSql &= vbNewLine & "				</FILEHOSO>"
        End If
        If (ds.Tables(3).Rows.Count > 0) Then
            ds.DataSetName = "DSACH_CHI_TIET_CLS"
            ioStream = New System.IO.MemoryStream
            ds.Tables(3).WriteXml(ioStream)
            xml = Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(System.Text.Encoding.UTF8.GetString(ioStream.ToArray())))
            ioStream.Close()
            ioStream = Nothing

            mSql &= vbNewLine & "				<FILEHOSO>"
            mSql &= vbNewLine & "					<LOAIHOSO>XML4</LOAIHOSO>"
            mSql &= vbNewLine & "					<NOIDUNGFILE>" & xml & "</NOIDUNGFILE>"
            mSql &= vbNewLine & "				</FILEHOSO>"
        End If
        If (ds.Tables(4).Rows.Count > 0) Then
            ds.DataSetName = "DSACH_CHI_TIET_DIEN_BIEN_BENH"
            ioStream = New System.IO.MemoryStream
            ds.Tables(4).WriteXml(ioStream)
            xml = Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(System.Text.Encoding.UTF8.GetString(ioStream.ToArray())))
            ioStream.Close()
            ioStream = Nothing

            mSql &= vbNewLine & "				<FILEHOSO>"
            mSql &= vbNewLine & "					<LOAIHOSO>XML5</LOAIHOSO>"
            mSql &= vbNewLine & "					<NOIDUNGFILE>" & xml & "</NOIDUNGFILE>"
            mSql &= vbNewLine & "				</FILEHOSO>"
        End If
        mSql &= vbNewLine & "			</HOSO>"
        mSql &= vbNewLine & "		</DANHSACHHOSO>"
        mSql &= vbNewLine & "	</THONGTINHOSO>"
        mSql &= vbNewLine & "	<CHUKYDONVI/>"
        mSql &= vbNewLine & "</GIAMDINHHS>"
        Dim FileName As String = "KCB_" & _drConfig!madonvi & "_" & ds.Tables(0).Rows(0)("NGAY_TTOAN").ToString & "_" & _drBN!makcb & ".xml"
        xml = mSql
        XmlReturn_ = xml
        Dim _dt As DataTable = dbXML.GetTable("select * from XmlFile where makcb = N'" & _drBN!makcb & "'")
        If _dt.Rows.Count = 0 Then
            _dt.Rows.Add(_dt.NewRow)
        End If
        _dt.Rows(0)!makk = _drConfig!makk
        _dt.Rows(0)!xml = xml
        _dt.Rows(0)!makcb = _drBN!makcb
        _dt.Rows(0)!dangdt = _drBN!dangdt + 1
        _dt.Rows(0)!madt = _drBN!madt
        _dt.Rows(0)!dtngoaitru = _drBN!dtngoaitru
        _dt.Rows(0)!BangBN = BangBN
        If Not String.IsNullOrEmpty(_drBN!dtngoaitru) AndAlso _drBN!dtngoaitru Then
            _dt.Rows(0)!dangdt += 4
        End If

        If _drThanhToan IsNot Nothing Then
            _dt.Rows(0)!ngaytt = _drThanhToan!ngaytt
            _dt.Rows(0)!datt = _drThanhToan!datt
        End If
        MyData.LuuVetNguoiDung(MyData.DuLieu.ThanhToan, "XML", "Tạo xml cho bệnh nhân: " & _drBN!makcb)
        If dbXML.UpdateData(_dt, "select * from xmlfile where makcb = N'" & _drBN!makcb & "'") Then
            Return True
        Else
            Return False
        End If
    End Function
End Class
Public Class clsCreateXML121
    Public XmlReturn_ As String = ""
    Dim BangBN As String = ""
    Dim _drBN As DataRow
    Dim _drConfig As DataRow
    Dim _drThanhToan As DataRow
    Dim _drRaVien As DataRow
    Dim _ngayad = ""
    Dim _benhBN As String = ""
    Dim muc_huong As Decimal = 0
    Dim pt_the As Decimal = 0
    Dim mIni As New clsIniFile
    Dim snChar As String = ",nChar(0x00) Collate Latin1_General_BIN , N''),nChar(0),N''),nChar(1),N''),nChar(2),N''),nChar(3),N''),nChar(4),N''),nChar(5),N''),nChar(6),N''),nChar(7),N''),nChar(8),N''),nChar(11),N''),nChar(12),N''),nChar(14),N''),nChar(15),N''),nChar(16),N''),nChar(17),N''),nChar(18),N''),nChar(19),N''),nChar(20),N''),nChar(21),N''),nChar(22),N''),nChar(23),N''),nChar(24),N''),nChar(25),N''),nChar(26),N''),nChar(27),N''),nChar(28),N''),nChar(29),N''),nChar(30),N''),nChar(31),N'')"
    Dim sReplace As String = "Replace(Replace(Replace(Replace(Replace(Replace(Replace(Replace(Replace(Replace(Replace(Replace(Replace(Replace(Replace(Replace(Replace(Replace(Replace(Replace(Replace(Replace(Replace(Replace(Replace(Replace(Replace(Replace(Replace(Replace("
    Sub New(ByVal makcb As String, ByVal SDBHis As String, ByVal SDBXML As String)
        dbHis = New MyData.Database(SDBHis)
        dbXML = New MyData.Database(SDBXML)
        BangBN = TimBangBN(makcb)
        _drBN = dbHis.GetTable("select * from dangky" & BangBN & " where makcb =N'" & makcb & "'").Rows(0)
        _drRaVien = dbHis.GetTable("select * from ravien" & BangBN & " where makcb = '" & makcb & "'").Rows(0)
        _benhBN = dbHis.GetTable("select isnull((select top 1 mabenh from chandoanravien" & BangBN & " where benhchinh = 1 and idravien in (select idravien from ravien" & BangBN & " where makcb = '" & makcb & "')),isnull((select top 1 mabenh from chandoandieutri" & BangBN & " where benhchinh = 1 and iddieutri in (select iddieutri from dieutri" & BangBN & " where makcb = '" & makcb & "')),isnull((select top 1 mabenh from chandoankhambenh" & BangBN & " where benhchinh = 1 and idkhambenh in (select idkhambenh from khambenh" & BangBN & " where makcb = '" & makcb & "')),'')))").Rows(0)(0).ToString
        Dim _makkCuoi As Integer = _drRaVien!makk
        Dim _dttemp = dbHis.GetTable("select * from ttthanhtoanravien" & BangBN & " where makcb = N'" & makcb & "'")
        If _dttemp.Rows.Count > 0 Then
            _drThanhToan = _dttemp.Rows(0)
            muc_huong = _drThanhToan!pthuong
        Else
            muc_huong = 0
        End If
        Dim _sql As String = <SQL>
DECLARE	@ptbenhnhanhuong decimal(18, 5),
		@ptthe decimal(18, 5)
EXEC	TimMucHuong
			@laytheoptthe = 0,
			@makcb = N'<%= makcb %>',
			@tienbn = -1,
			@ptbenhnhanhuong = @ptbenhnhanhuong OUTPUT,
			@ptthe = @ptthe OUTPUT
SELECT	@ptbenhnhanhuong as N'ptbenhnhanhuong',
		@ptthe as N'ptthe'
                             </SQL>.Value

        _dttemp = dbHis.GetTable(_sql)
        pt_the = _dttemp.Rows(0)!ptthe

        _drConfig = dbXML.GetTable("select * from tblconfigkk where makk = " & _makkCuoi).Rows(0)
        _ngayad = LayNgayAD(dbHis, CDate(_drBN!ngaydk).ToString("dd/MM/yyyy"), _drBN!madt)
        _CotTenThuoc = dbXML.GetTable("select top 1 * from tblConfigColumn where dichvu = 0").Rows(0)!cotdl.ToString
        _CotTenDV = dbXML.GetTable("select top 1 * from tblconfigcolumn where ngayad = '" & _ngayad & "' and dichvu = 1").Rows(0)!cotdl.ToString
    End Sub
    Private Function GetDTHC(ByVal makcb As String) As DataTable
        Dim _SQL = <SQL>
declare @makcb as nvarchar(50)
set @makcb ='{0}'
select 
	b1.makcb ma_lk,1 stt,b1.mabn ma_bn,b1.tenbn ho_ten,
	(case when isnull(b1.ngaysinh,'')='' then convert(nvarchar,b1.namsinh) + '-01-01' else replace(convert(nvarchar,b1.ngaysinh,111),'/','-') end) ngay_sinh,
	(case when b2.tenphai like N'%nam%' then 1 else 2 end) gioi_tinh,
	b1.diachithe dia_chi,b1.mathe+ b1.maql + b1.matinh + b1.maquan +b1.madonvi+b1.thutu + isnull(Stuff((select ';' + mathe + maql + matinh + maquan + madonvi + thutu from thebn where makcb = @makcb For Xml Path('')),1,0,''),'') ma_the,
    b1.mandk  + isnull(Stuff((select ';' + mandk from thebn where makcb = @makcb For Xml Path('')),1,0,''),'') ma_dkbd,
	replace(convert(nvarchar,b1.ngaybd,111),'/','') + isnull(Stuff((select ';' + replace(convert(nvarchar,ngaybd,111),'/','') from thebn where makcb = @makcb For Xml Path('')),1,0,''),'')  gt_the_tu,
    replace(convert(nvarchar,b1.ngaykt,111),'/','') + isnull(Stuff((select ';' + replace(convert(nvarchar,ngaykt,111),'/','') from thebn where makcb = @makcb For Xml Path('')),1,0,''),'')  gt_the_den,
	(
	    case 
	        when 
	            b1.dangdt=1 
	        then
	            Stuff((select ';' + b2.tenbenh from chandoandieutri{1} b1 join dmbenh b2 on b1.mabenh = b2.mabenh where iddieutri in (select iddieutri from dieutri{1} where makcb = @makcb) For Xml Path('')),1,1,'')
	        else
	        Stuff((select ';' + b2.tenbenh from chandoankhambenh{1} b1 join dmbenh b2 on b1.mabenh = b2.mabenh where idkhambenh in (select idkhambenh from khambenh{1} where makcb = @makcb) For Xml Path('')),1,1,'')
	    end
	)ten_benh,
	(
		case 
			when 
				b1.dangdt=1 
			then
				(select top 1 mabenh from chandoanravien{1} where idravien in (select idravien from ravien{1} where makcb = @makcb) and benhchinh = 1)
			else
				(select top 1  mabenh from chandoankhambenh{1} where idkhambenh = (select top 1 idkhambenh from khambenh{1} where makcb = @makcb order by ngaykham desc) and benhchinh = 1)
		end
	)
	ma_benh,
	isnull((
		case 
			when 
				b1.dangdt=1 
			then
				Stuff((select ';' + mabenh from chandoanravien{1} where idravien in (select idravien from ravien{1} where makcb = @makcb) and benhchinh = 0 For Xml Path('')),1,1,'')
			else
				Stuff((select ';' + mabenh from chandoankhambenh{1} where idkhambenh in (select idkhambenh from khambenh{1} where makcb = @makcb) and mabenh not in (select top 1 mabenh from chandoankhambenh{1} where idkhambenh = (select top 1 idkhambenh from khambenh{1} where makcb = @makcb order by ngaykham) and benhchinh = 1) For Xml Path('')),1,1,'')
		end
	),'')
	ma_benhkhac,
	isnull((case when isnull(b1.cappcuu,0)=1 then 2 else (case when Exists(select top 1 1 from dmtuyendksd where matdk=b1.matdk and matltdk=1) then 1 else 3 end) end ),'')ma_lydo_vvien,
	isnull(b1.mangt,'') ma_noi_chuyen,isnull((select top 1 phanloaitainan from tainanthuongtich where makcb = @makcb),'')ma_tai_nan,
	(
        case when b1.dangdt=1 then 
            isnull((select replace(convert(nvarchar,ngay,111),'/','-') + ' ' + convert(nvarchar,ngay,108) from dangkynhapvien{1} where makcb =@makcb),'') 
        else 
            replace(convert(nvarchar,b1.ngaydk,111),'/','-') + ' ' + convert(nvarchar,b1.ngaydk,108) 
        end
    )  ngay_vao,
	replace(convert(nvarchar,b3.ngay,111),'/','-') + ' ' + convert(nvarchar,b3.ngay,108) ngay_ra,
    convert(int,b3.songaydieutri) so_ngay_dtri,b3.makq ket_qua_dtri,b3.mahtr tinh_trang_rv,
	replace(convert(nvarchar,b4.ngaytt,111),'/','') + replace(left(convert(nvarchar,b4.ngaytt,108),5),':','') ngay_ttoan,convert(decimal(18,2),0) t_thuoc,convert(decimal(18,2),0) t_vtyt,convert(decimal(18,2),b4.tongchiphi-b4.tongtientru-b4.tongbn100) t_tongchi,
(case when isnull((case when isnull(b1.cappcuu,0)=1 then 2 else (case when Exists(select top 1 1 from dmtuyendksd where matdk=b1.matdk and matltdk=1) then 1 else 3 end) end ),'') = 3 then convert(decimal(18,2),b4.tienbntt - b4.tongbn100) else 0 end) t_bntt,
(case when isnull((case when isnull(b1.cappcuu,0)=1 then 2 else (case when Exists(select top 1 1 from dmtuyendksd where matdk=b1.matdk and matltdk=1) then 1 else 3 end) end ),'') = 3 then 0 else convert(decimal(18,2),b4.tienbntt - b4.tongbn100) end) t_bncct,

	convert(decimal(18,2),b4.tienbh) t_bhtt,0 t_nguonkhac,0 t_ngoaids,year(b4.ngaytt) nam_qt,month(b4.ngaytt) thang_qt,isnull(convert(nvarchar,ngay55,112),'') mien_cung_ct,
	(case when b1.dtngoaitru = 1 then 2 else (case when b1.dangdt=1 then 3 else 1 end) end) ma_loai_kcb,
	isnull(b5.mahis,'000' + convert(nvarchar,b3.makk)) ma_khoa,b5.tenkk tenkhoa,isnull((select madonvi from {2}..tblConfigKK where makk = b3.makk),'') ma_cskcb,
	isnull((select tennss from dmnoiss where manss = b1.manss),'') ma_khuvuc,'' ma_pttt_qt,
		(
			case 
				when 
					b1.dangdt = 1 
				then 
					isnull(replace(isnull((select top 1 cannang from dienbien{1} where isnull(cannang,'') &lt;&gt; '' and idthanhtoan in (select idthanhtoan from ttphieuthanhtoan{1} where makcb = @makcb and makk = b3.makk)),(select top 1 cannang from chisosinhton{1} where isnull(cannang,'') &lt;&gt; '' and idsinhton in (select idkhambenh from khambenh{1} where makcb = @makcb))),',','.'),'')
				else 
					isnull(replace(isnull((select top 1 cannang from chisosinhton{1} where isnull(cannang,'') &lt;&gt; '' and idsinhton = (select top 1 idkhambenh from khambenh{1} where makcb = @makcb and makk = b3.makk)),''),',','.'),'')
			end) can_nang
From dangky{1} b1
join dmphai b2 on b1.maphai=b2.maphai
left join ravien{1} b3 on b3.makcb=b1.makcb
left join ttthanhtoanravien{1}	b4 on b4.makcb = b1.makcb
left join dmkk b5 on b5.makk=b3.makk
where b1.makcb =@makcb
                   </SQL>.Value
        _SQL = String.Format(_SQL, makcb, BangBN, dbXML.DatabaseName)
        Return dbHis.GetTable(_SQL)
    End Function
    Private Function GetDTThuoc(ByVal makcb As String) As DataTable
        Dim _SQL = <SQL>
declare @makcb as nvarchar(50)
set @makcb ='{0}'

    select (select maloaik from dmkhoan where makhoan = b3.makhoan) maloaik,@makcb ma_lk,1 stt,isnull(b4.{2},'') ma_thuoc,b4.manhombh ma_nhom,b4.tenhh ten_thuoc,
    b4.dvt don_vi_tinh,isnull(b4.hamluong,'') ham_luong,b6.maddtt duong_dung,case when isnull(b3.ghichu,'') = '' then '.' else b3.ghichu end lieu_dung,
    isnull(sodangky,'') so_dang_ky,isnull(b4.ttthau,'.') tt_thau,1 pham_vi,convert(decimal(18,3),IsNull(b4.tylesoluongxml,1) * (b3.soluong-isnull((select Sum(soluong) from tttralaihhchitiet_thuoc{1} where idttchitiet = b3.idttchitiet),0))) so_luong,
    convert(decimal(18,3),isnull(b3.giabhytcn,b3.dongia)/IsNull(b4.tylesoluongxml,1)) don_gia,
    convert(decimal(18,0),b3.tyle) tyle_tt, 
    convert(decimal(18,2),convert(decimal(18,3),b3.soluong-isnull((select Sum(soluong) from tttralaihhchitiet_thuoc{1} where idttchitiet = b3.idttchitiet),0)) * convert(decimal(18,3),isnull(b3.giabhytcn,b3.dongia))) thanh_tien,(case when b3.pthuong is not null then b3.pthuong  when b3.makhoan in (select makhoan from dmkhoan where maloaik=1) then 100 else {6} end) muc_huong
    ,0 t_nguonkhac, 
(case when isnull((case when isnull(b1.cappcuu,0)=1 then 2 else (case when Exists(select top 1 1 from dmtuyendksd where matdk=b1.matdk and matltdk=1) then 1 else 3 end) end ),'') = 3 then convert(decimal(18,2),b3.tienbn) else 0 end) + (case when isnull(b3.tyle,100) = 100 then 0 else convert(decimal(18,2),convert(decimal(18,2),(b3.soluong-isnull((select Sum(soluong) from tttralaihhchitiet_thuoc<%= BangBN %> where idttchitiet = b3.idttchitiet),0)) * convert(decimal(18,2),isnull(b3.giabhytcn,b3.dongia))) * convert(decimal(18,2),(100 - b3.tyle)) / convert(decimal(18,2),100)) end)
 t_bntt,
convert(decimal(18,2),b3.tienbh) t_bhtt,
0 t_ngoaids,
   
    (
        case 
        when 
            isnull
            (
                (
                    case 
                    when 
                        isnull(b1.cappcuu,0)=1 
                    then 
                        2 
                    else 
                        (
                            case 
                            when 
                                Exists(select top 1 1 from dmtuyendksd where matdk=b1.matdk and matltdk=1) 
                            then 
                                1 
                            else 
                                3 
                            end
                        ) 
                    end 
                )
            ,'') = 3 
        then 
            0 
        else 
            convert(decimal(18,2),b3.tienbn) 
        end
    ) t_bncct,

   isnull(b7.mahis,'000' + convert(nvarchar,b3.makk)) ma_khoa,b7.tenkk tenkhoa,b5.chungchihn ma_bac_si,isnull((case when b2.idkhambenh is not null then isnull((select top 1 mabenh from chandoankhambenh{1} where idkhambenh = b2.idkhambenh and benhchinh = 1),N'<%= _benhBN %>') else (select top 1 mabenh from chandoandieutri{1} where iddieutri = b2.iddieutri and benhchinh = 1) end),N'<%= _benhBN %>') ma_benh,replace(convert(nvarchar,b2.ngay,111),'/','-') + ' ' + convert(nvarchar,b2.ngay,108) ngay_yl,0 ma_pttt
    From dangky{1} b1
    join ttphieuthanhtoan{1} b2 on b1.makcb=b2.makcb
    join ttphieuttchitiet_thuoc{1} b3 on b3.idthanhtoan=b2.idthanhtoan and b3.makhoan not in (select makhoan from dmkhoan where maloaik=2 or maloaik = 4)
    join dmthuocvattu b4 on b4.idhh=b3.idhh
    join dmnhanvien b5 on b5.manv = b2.manv
    join dmduongdung b6 on b6.maduongdung=b4.maduongdung
    join dmkk b7 on b7.makk=b2.makk
    where b1.makcb = @makcb and b3.makhoan not in (select makhoan from dmkhoan where maloaik = 2 or maloaik=4) 
    and convert(decimal(18,2),convert(decimal(18,2),b3.soluong-isnull((select Sum(soluong) from tttralaihhchitiet_thuoc{1} where idttchitiet = b3.idttchitiet),0)) * convert(decimal(18,2),isnull(b3.giabhytcn,b3.dongia)) * convert(decimal(18,0),b3.tyle) / convert(decimal(18,0),100)) &gt; 0
    and manhombh in (4,5,6,7)
    and isnull(b4.{2},'') &lt;&gt; ''
    and isnull(b3.lenphoibh,1)=1
            Union All

    select (select maloaik from dmkhoan where makhoan = b3.makhoan) maloaik,@makcb ma_lk,1 stt,b4.{3} ma_dich_vu,b4.manhombh ma_nhom,b4.tenbhyt ten_thuoc,
    b7.tendonvitinh don_vi_tinh,'' ham_luong,'' duong_dung,'.' lieu_dung,'' so_dang_ky,'' tt_thau,1 pham_vi,convert(decimal(18,3),b3.soluong-isnull((select Sum(soluong) from tttralaihhchitiet_dichvu{1} where idttchitiet = b3.idttchitiet),0)) so_luong,convert(decimal(18,3),b3.dongia) don_gia,
    convert(decimal(18,0),b3.tyle) tyle_tt, 
    convert(decimal(18,2),convert(decimal(18,3),b3.soluong-isnull((select Sum(soluong) from tttralaihhchitiet_dichvu{1} where idttchitiet = b3.idttchitiet),0)) * convert(decimal(18,2),b3.dongia)) thanh_tien,(case when b3.pthuong is not null then b3.pthuong  when b3.makhoan in (select makhoan from dmkhoan where maloaik=1) then 100 else {6} end) muc_huong
    ,0 t_nguonkhac,
(case when isnull((case when isnull(b1.cappcuu,0)=1 then 2 else (case when Exists(select top 1 1 from dmtuyendksd where matdk=b1.matdk and matltdk=1) then 1 else 3 end) end ),'') = 3 then convert(decimal(18,2),b3.tienbn) else (case when isnull(b3.tyle,100) = 100 then 0 else convert(decimal(18,2),convert(decimal(18,2),(b3.soluong-isnull((select Sum(soluong) from tttralaihhchitiet_thuoc{1} where idttchitiet = b3.idttchitiet),0)) * convert(decimal(18,2),isnull(b3.giabhytcn,b3.dongia))) * convert(decimal(18,2),(100 - b3.tyle)) / convert(decimal(18,2),100)) end) end)  t_bntt,

convert(decimal(18,2),b3.tienbh) t_bhtt,0 t_ngoaids,

(case when isnull((case when isnull(b1.cappcuu,0)=1 then 2 else (case when Exists(select top 1 1 from dmtuyendksd where matdk=b1.matdk and matltdk=1) then 1 else 3 end) end ),'') &lt;&gt; 3 then convert(decimal(18,2),b3.tienbn) else 0 end) t_bncct,
    isnull(b8.mahis,'000' + convert(nvarchar,b3.makk)) ma_khoa,b8.tenkk tenkhoa,b5.chungchihn ma_bac_si,isnull((case when b2.idkhambenh is not null then isnull((select top 1 mabenh from chandoankhambenh{1} where idkhambenh=b2.idkhambenh and benhchinh = 1),N'<%= _benhBN %>') else isnull((select top 1 mabenh from chandoandieutri{1} where iddieutri=b2.iddieutri and benhchinh = 1),N'<%= _benhBN %>') end),'') ma_benh,
    replace(convert(nvarchar,b2.ngay,111),'/','-') + ' ' + convert(nvarchar,b2.ngay,108) ngay_yl,0 ma_pttt
    From dangky{1} b1
    join ttphieuthanhtoan{1} b2 on b1.makcb=b2.makcb
    join ttphieuttchitiet_dichvu{1} b3 on b3.idthanhtoan=b2.idthanhtoan and b3.makhoan not in (select makhoan from dmkhoan where maloaik=2 or maloaik = 4)
    join dmdichvu b4 on b4.madv=b3.madv
    join dmnhanvien b5 on b5.manv = b2.manv
    join tendvtheongay b6 on b6.madv = b4.madv and ngayad='{5}' and b6.madt={4}
    join dmdonvitinh b7 on b7.donvitinhid=b4.donvitinhid
    join dmkk b8 on b8.makk=b2.makk
    where b1.makcb = @makcb and b3.makhoan not in (select makhoan from dmkhoan where maloaik = 2 or maloaik=4)
    and manhombh in (4,5,6,7)
    and isnull(b4.{3},'')  &lt;&gt; ''
    and isnull(b3.lenphoibh,1)=1 
                   </SQL>.Value
        _SQL = String.Format(_SQL, makcb, BangBN, _CotTenThuoc, _CotTenDV, _drBN!madt, _ngayad, muc_huong.ToString.Replace(".", "").Replace(",", "."))
        Return dbHis.GetTable(_SQL)
    End Function
    Private Function GetDTDichVu(ByVal makcb As String) As DataTable
        Dim _SQL = <SQL>
declare @makcb as nvarchar(50)
set @makcb ='{0}'

    select (select maloaik from dmkhoan where makhoan = b3.makhoan) maloaik,
    @makcb ma_lk,
    1 stt,
    b4.{4} ma_dich_vu,
    '' ma_vat_tu,
    b4.manhombh ma_nhom,
    '' goi_vtyt,
    '' ten_vat_tu,
    b4.tenbhyt ten_dich_vu,
    b7.tendonvitinh don_vi_tinh,
    1 pham_vi,convert(decimal(18,2),b3.soluong-isnull((select Sum(soluong) from tttralaihhchitiet_dichvu{1} where idttchitiet = b3.idttchitiet),0)) so_luong,convert(decimal(18,3),b3.dongia) don_gia,'' tt_thau,
    convert(decimal(18,0),b3.tyle) tyle_tt, 
    convert(decimal(18,2),convert(decimal(18,2),b3.soluong-isnull((select Sum(soluong) from tttralaihhchitiet_dichvu{1} where idttchitiet = b3.idttchitiet),0)) * convert(decimal(18,3),b3.dongia) * convert(decimal(18,2),b3.tyle) / convert(decimal(18,2),100)) thanh_tien
    ,'' t_trantt,(case when b3.pthuong is not null then b3.pthuong  when b3.makhoan in (select makhoan from dmkhoan where maloaik=1) then 100 else {6} end) muc_huong,
    0 t_nguonkhac,
    (case when isnull((case when isnull(b1.cappcuu,0)=1 then 2 else (case when Exists(select top 1 1 from dmtuyendksd where matdk=b1.matdk and matltdk=1) then 1 else 3 end) end ),'') = 3 then convert(decimal(18,2),b3.tienbn) else 0 end) t_bntt,
    convert(decimal(18,2),b3.tienbh) t_bhtt,
    (case when isnull((case when isnull(b1.cappcuu,0)=1 then 2 else (case when Exists(select top 1 1 from dmtuyendksd where matdk=b1.matdk and matltdk=1) then 1 else 3 end) end ),'') = 3 then 0 else convert(decimal(18,2),b3.tienbn) end) t_bncct,
    0 t_ngoaids,
    isnull(b8.mahis,'000' + convert(nvarchar,b3.makk)) ma_khoa,
    b8.tenkk tenkhoa,
    <%= If(dbHis.GetTable("select top 1 1 from sys.columns where object_id=object_id('dmdichvu') and name = 'magiuong'").Rows.Count > 0, "IsNull(b4.magiuong,'')", "IsNull((select maxml from dmgiuong where magiuong = b3.magiuongxml),'')") %> ma_giuong,
    b5.chungchihn ma_bac_si,
    (case when b2.idkhambenh is not null then isnull((select top 1 mabenh from chandoankhambenh{1} where idkhambenh=b2.idkhambenh and benhchinh = 1),N'<%= _benhBN %>') else isnull((select top 1 mabenh from chandoandieutri{1} where iddieutri=b2.iddieutri and benhchinh = 1),N'<%= _benhBN %>') end) ma_benh,
    replace(convert(nvarchar,b2.ngay,111),'/','-') + ' ' + convert(nvarchar,b2.ngay,108) ngay_yl,
    isnull((select top 1 replace(convert(nvarchar,ngay,111),'/','-') + ' ' + convert(nvarchar,ngay,108) from dalam{1} where madv =b4.madv and idthanhtoan=b2.idthanhtoan),'') ngay_kq,
    0 ma_pttt
    From dangky{1} b1
    join ttphieuthanhtoan{1} b2 on b1.makcb=b2.makcb
    join ttphieuttchitiet_dichvu{1} b3 on b3.idthanhtoan=b2.idthanhtoan and b3.makhoan not in (select makhoan from dmkhoan where maloaik=2 or maloaik = 4)
    join dmdichvu b4 on b4.madv=b3.madv
    join dmnhanvien b5 on b5.manv = b2.manv
    join tendvtheongay b6 on b6.madv = b4.madv and ngayad='{2}' and b6.madt={3}
    join dmdonvitinh b7 on b7.donvitinhid=b4.donvitinhid
    join dmkk b8 on b8.makk=b2.makk
    where b1.makcb = @makcb and b3.makhoan not in (select makhoan from dmkhoan where maloaik = 2 or maloaik=4)
    and convert(decimal(18,2),b3.soluong-isnull((select Sum(soluong) from tttralaihhchitiet_dichvu{1} where idttchitiet = b3.idttchitiet),0)) &gt; 0
    and manhombh in (1,2,3,12,13,14,15,8,9)
    and isnull(b4.{4},'')  &lt;&gt; ''
    and isnull(b3.lenphoibh,1)=1

    Union All 

    select (select maloaik from dmkhoan where makhoan = b3.makhoan) maloaik,
    @makcb ma_lk,1 stt,IsNull((select {4} from dmdichvu where madv = (select madv from ttphieuttchitiet_dichvu{1} where idttchitiet = b2.idctpt)),'') ma_dich_vu,b4.{5} ma_vat_tu,b4.manhombh ma_nhom,'' goi_vtyt,b4.tenhh ten_vat_tu,IsNull((select tendv from tendvtheongay where madv = (select madv from ttphieuttchitiet_dichvu{1} where idttchitiet = b2.idctpt) and madt = b1.madt and ngayad = '{2}'),'') ten_dich_vu,
    b4.dvt don_vi_tinh,1 pham_vi,convert(decimal(18,2),IsNull(b4.tylesoluongxml,1) * (b3.soluong-isnull((select Sum(soluong) from tttralaihhchitiet_thuoc{1} where idttchitiet = b3.idttchitiet),0))) so_luong,
    convert(decimal(18,3),isnull(b3.giabhytcn,b3.dongia)/IsNull(b4.tylesoluongxml,1)) don_gia,isnull(b4.ttthau,'.') tt_thau,
    convert(decimal(18,0),b3.tyle) tyle_tt,
    convert(decimal(18,2),convert(decimal(18,3),b3.soluong-isnull((select Sum(soluong) from tttralaihhchitiet_thuoc{1} where idttchitiet = b3.idttchitiet),0)) * convert(decimal(18,3),isnull(b3.giabhytcn,b3.dongia))) thanh_tien
    ,'' t_trantt,(case when b3.pthuong is not null then b3.pthuong  when b3.makhoan in (select makhoan from dmkhoan where maloaik=1) then 100 else {6} end) muc_huong,0 t_nguonkhac,

(case when isnull((case when isnull(b1.cappcuu,0)=1 then 2 else (case when Exists(select top 1 1 from dmtuyendksd where matdk=b1.matdk and matltdk=1) then 1 else 3 end) end ),'') = 3 then convert(decimal(18,2),b3.tienbn) else 0 end) + (case when isnull(b3.tyle,100) = 100 then 0 else convert(decimal(18,2),convert(decimal(18,2),(b3.soluong-isnull((select Sum(soluong) from tttralaihhchitiet_thuoc{1} where idttchitiet = b3.idttchitiet),0)) * convert(decimal(18,2),isnull(b3.giabhytcn,b3.dongia))) * convert(decimal(18,2),(100 - b3.tyle)) / convert(decimal(18,2),100)) end)
 t_bntt,
convert(decimal(18,2),b3.tienbh) t_bhtt,
(case when isnull((case when isnull(b1.cappcuu,0)=1 then 2 else (case when Exists(select top 1 1 from dmtuyendksd where matdk=b1.matdk and matltdk=1) then 1 else 3 end) end ),'') = 3 then 0 else convert(decimal(18,2),b3.tienbn) end) t_bncct,0 t_ngoaids,
    isnull(b6.mahis,'000' + convert(nvarchar,b3.makk)) ma_khoa,b6.tenkk tenkhoa,'' ma_giuong,b5.chungchihn ma_bac_si,(case when b2.idkhambenh is not null then isnull((select top 1 mabenh from chandoankhambenh{1} where idkhambenh=b2.idkhambenh and benhchinh = 1),N'<%= _benhBN %>') else isnull((select top 1 mabenh from chandoandieutri{1} where iddieutri=b2.iddieutri and benhchinh = 1),N'<%= _benhBN %>') end) ma_benh,
    replace(convert(nvarchar,b2.ngay,111),'/','-') + ' ' + convert(nvarchar,b2.ngay,108) ngay_yl,'' ngay_kq,0 ma_pttt
    From dangky{1} b1
    join ttphieuthanhtoan{1} b2 on b1.makcb=b2.makcb
    join ttphieuttchitiet_thuoc{1} b3 on b3.idthanhtoan=b2.idthanhtoan
    join dmthuocvattu b4 on b4.idhh=b3.idhh
    join dmnhanvien b5 on b5.manv = b2.manv
    join dmkk b6 on b6.makk=b2.makk
    where b1.makcb = @makcb and b3.makhoan not in (select makhoan from dmkhoan where maloaik = 2 or maloaik = 4)  and convert(decimal(18,2),convert(decimal(18,2),b3.soluong-isnull((select Sum(soluong) from tttralaihhchitiet_thuoc{1} where idttchitiet = b3.idttchitiet),0)) * convert(decimal(18,2),isnull(b3.giabhytcn,b3.dongia)) * convert(decimal(18,0),b3.tyle) / convert(decimal(18,0),100)) &gt; 0
    and manhombh in (10,11)
    and isnull(b4.{5},'') &lt;&gt; '' 
    and isnull(b3.lenphoibh,1)=1
                   </SQL>.Value
        _SQL = String.Format(_SQL, makcb, BangBN, _ngayad, _drBN!madt, _CotTenDV, _CotTenThuoc, muc_huong.ToString.Replace(".", "").Replace(",", "."))
        Return dbHis.GetTable(_SQL)
    End Function
    Private Function GetDTCLS(ByVal makcb As String) As DataTable
        Dim _sql = <SQL>
declare @makcb as nvarchar(50)
set @makcb ='{0}'
select @makcb ma_lk,1 stt,b5.{2} ma_dich_vu,isnull(b6.chisoxml,'') ma_chi_so,
isnull(b6.tencs,'') ten_chi_so,{3}isnull(b4.ketqua,''){4} gia_tri,isnull(b8.mamayxn,'') ma_may,isnull(b7.mota,'') mo_ta,isnull(b7.ketluan,'') ket_luan,
replace(convert(nvarchar,b3.ngay,111),'/','') 
+ left(replace(convert(nvarchar,b3.ngay,108),':',''),4) ngay_kq
from
ttphieuthanhtoan{1} b1
join ttphieuttchitiet_dichvu{1} b2 on b1.idthanhtoan= b2.idthanhtoan and b2.makhoan not in (select makhoan from dmkhoan where maloaik=2 or maloaik = 4)
join dalam{1} b3 on b3.idthanhtoan=b2.idthanhtoan and b3.madv=b2.madv
left join ketquachiso{1} b4 on b4.idthanhtoan=b2.idthanhtoan and b4.madv=b2.madv
join dmdichvu b5 on b5.madv=b2.madv
left join dmchiso b6 on b6.macs=b4.macs
left join ketquachandoanhinhanh{1} b7 on b7.idthanhtoan=b2.idthanhtoan and b7.madv=b2.madv
Left Join dmmayxetnghiem b8 on b8.labid=b4.labid or b8.labid = b7.labid
where b1.makcb=@makcb and isnull(b5.{2},'') &lt;&gt; '' and isnull(b8.mamay,'') &lt;&gt; ''
                   </SQL>.Value
        _sql = String.Format(_sql, makcb, BangBN, _CotTenDV, sReplace, snChar)
        Return dbHis.GetTable(_sql)
    End Function
    Private Function GetDTDB(ByVal makcb As String) As DataTable
        Dim _sql = <SQL>
declare @makcb as nvarchar(50)
set @makcb ='{0}'
select @makcb ma_lk,1 stt,
isnull(N'Cân nặng: ' + convert(nvarchar,b2.cannang) + N'; ' + N'Chiều cao: ' + convert(nvarchar,b2.chieucao) + N'; ' + N'Mạch: ' + convert(nvarchar,b2.mach) + N'; ' + N'Nhiệt độ: ' + convert(nvarchar,b2.nhietdo) + N'; ' + N'Huyết áp: ' + convert(nvarchar,b2.huyetap),'') dien_bien,
'' hoi_chan,'' phau_thuat, replace(convert(nvarchar,b1.ngaykham,111),'/','') + left(replace(convert(nvarchar,b1.ngaykham,108),':',''),4) ngay_yl
From khambenh{1} b1
join chisosinhton{1} b2 on b1.idkhambenh=b2.idsinhton
Where makcb = @makcb and isnull(N'Cân nặng: ' + convert(nvarchar,b2.cannang) + N'; ' + N'Chiều cao: ' + convert(nvarchar,b2.chieucao) + N'; ' + N'Mạch: ' + convert(nvarchar,b2.mach) + N'; ' + N'Nhiệt độ: ' + convert(nvarchar,b2.nhietdo) + N'; ' + N'Huyết áp: ' + convert(nvarchar,b2.huyetap),'') &lt;&gt; ''
Union All
select @makcb ma_lk,1 stt,
isnull({2}b2.dienbien{3},'') dien_bien,
'' hoi_chan,'' phau_thuat, replace(convert(nvarchar,b1.ngay,111),'/','') + left(replace(convert(nvarchar,b1.ngay,108),':',''),4) ngay_yl
From ttphieuthanhtoan{1} b1
join dienbien{1} b2 on b1.idthanhtoan=b2.idthanhtoan
Where makcb = @makcb and iddieutri is not null and replace(replace(isnull(b2.dienbien,''),char(10),''),char(13),'') &lt;&gt; ''
Union All
select @makcb ma_lk,1 stt,
isnull(b1.mota,'') dien_bien,
'' hoi_chan,'' phau_thuat, replace(convert(nvarchar,b1.ngaychidinh,111),'/','') + left(replace(convert(nvarchar,b1.ngaychidinh,108),':',''),4) ngay_yl
From phauthuat{1} b1
Where makcb = @makcb and iddieutri is not null and  replace(replace(isnull(b1.mota,''),char(10),''),char(13),'') &lt;&gt; ''
and isnull(b1.mota,'')  &lt;&gt; ''
                   </SQL>.Value
        _sql = String.Format(_sql, makcb, BangBN, sReplace, snChar)
        Return dbHis.GetTable(_sql)
    End Function
    Public Function GetXML() As DataTable
        Dim _ds As New DataSet()
        _ds.Tables.Add(GetDTHC(_drBN!makcb))
        _ds.Tables.Add(GetDTThuoc(_drBN!makcb))
        _ds.Tables.Add(GetDTDichVu(_drBN!makcb))
        _ds.Tables.Add(GetDTCLS(_drBN!makcb))
        _ds.Tables.Add(GetDTDB(_drBN!makcb))

        If _ds.Tables(0).Rows(0)!ma_lydo_vvien = 3 Then
            Dim _dt = _ds.Tables(1)
            For Each item In _dt.Rows
                If item!maloaik = 1 Then Continue For
                Dim _tongtienbn = item!t_bntt
                Dim _tiencct = Math.Round(item!thanh_tien * item!tyle_tt * pt_the / 10000, 2) - item!t_bhtt
                Dim _tienbntt = Math.Round(_tongtienbn - _tiencct, 2)
                item!t_bncct = _tiencct
                item!t_bntt = _tienbntt
                If Not String.IsNullOrEmpty(_ds.Tables(0).Rows(0)!ma_khuvuc.ToString) Then
                    Dim oVal = item!t_bncct
                    item!t_bncct = item!t_bntt
                    item!t_bntt = oVal
                End If
            Next
            _dt = _ds.Tables(2)
            For Each item In _dt.Rows
                If item!maloaik = 1 Then Continue For
                If item!ma_nhom = 8 OrElse item!ma_nhom = 13 OrElse item!ma_nhom = 14 OrElse item!ma_nhom = 15 Then
                    Dim _tongtienbn = item!t_bntt
                    Dim _tiencct = Math.Round(item!thanh_tien * pt_the / 100, 2) - item!t_bhtt
                    Dim _tienbntt = Math.Round(_tongtienbn - _tiencct, 2)
                    item!t_bncct = _tiencct
                    item!t_bntt = _tienbntt
                Else
                    Dim _tongtienbn = item!t_bntt
                    Dim _tiencct = Math.Round(item!thanh_tien * item!tyle_tt * pt_the / 10000, 2) - item!t_bhtt
                    Dim _tienbntt = Math.Round(_tongtienbn - _tiencct, 2)
                    item!t_bncct = _tiencct
                    item!t_bntt = _tienbntt
                End If
                If Not String.IsNullOrEmpty(_ds.Tables(0).Rows(0)!ma_khuvuc.ToString) Then
                    Dim oVal = item!t_bncct
                    item!t_bncct = item!t_bntt
                    item!t_bntt = oVal
                End If
            Next
        End If

        _ds.Tables(1).Columns.Remove("maloaik")
        _ds.Tables(2).Columns.Remove("maloaik")
        For Each item In _ds.Tables
            For Each item2 As DataColumn In item.Columns
                item2.ColumnName = item2.ColumnName.ToUpper
            Next
        Next

        Try
            _ds.Tables(0).Rows(0)!t_bncct = CDec(FormatNumber(_ds.Tables(1).Compute("Sum(t_bncct)", ""), 2))
            If _ds.Tables(0).Rows(0)!t_bncct Is DBNull.Value Then
                _ds.Tables(0).Rows(0)!t_bncct = 0
            End If

        Catch ex As Exception
            _ds.Tables(0).Rows(0)!t_bncct = 0
        End Try
        Try
            Dim d2 As Decimal = CDec(FormatNumber(_ds.Tables(2).Compute("Sum(t_bncct)", ""), 2))
            If d2 > 0 Then
                _ds.Tables(0).Rows(0)!t_bncct += d2
            End If
        Catch ex As Exception
        End Try

        Try
            _ds.Tables(0).Rows(0)!t_bntt = CDec(FormatNumber(_ds.Tables(1).Compute("Sum(t_bntt)", ""), 2))
            If _ds.Tables(0).Rows(0)!t_bntt Is DBNull.Value Then
                _ds.Tables(0).Rows(0)!t_bntt = 0
            End If

        Catch ex As Exception
            _ds.Tables(0).Rows(0)!t_bntt = 0
        End Try
        Try
            Dim d2 As Decimal = CDec(FormatNumber(_ds.Tables(2).Compute("Sum(t_bntt)", ""), 2))
            If d2 > 0 Then
                _ds.Tables(0).Rows(0)!t_bntt += d2
            End If
        Catch ex As Exception
        End Try


        Try
            _ds.Tables(0).Rows(0)!t_tongchi = CDec(FormatNumber(_ds.Tables(1).Compute("Sum(thanh_tien)", ""), 2))
            If _ds.Tables(0).Rows(0)!t_tongchi Is DBNull.Value Then
                _ds.Tables(0).Rows(0)!t_tongchi = 0
            End If
        Catch ex As Exception
            _ds.Tables(0).Rows(0)!t_tongchi = 0
        End Try
        Try
            Dim d2 As Decimal = CDec(FormatNumber(_ds.Tables(2).Compute("Sum(thanh_tien)", ""), 2))
            If d2 > 0 Then
                _ds.Tables(0).Rows(0)!t_tongchi += d2
            End If
        Catch ex As Exception
        End Try


        Try
            _ds.Tables(0).Rows(0)!t_thuoc = CDec(FormatNumber(_ds.Tables(1).Compute("Sum(thanh_tien)", ""), 2))
            If _ds.Tables(0).Rows(0)!t_thuoc Is DBNull.Value Then
                _ds.Tables(0).Rows(0)!t_thuoc = 0
            End If
        Catch ex As Exception
            _ds.Tables(0).Rows(0)!t_thuoc = 0
        End Try
        Try
            _ds.Tables(0).Rows(0)!t_vtyt = CDec(FormatNumber(_ds.Tables(2).Compute("Sum(thanh_tien)", "ma_nhom in (10,11)"), 2))
            If _ds.Tables(0).Rows(0)!t_vtyt Is DBNull.Value Then
                _ds.Tables(0).Rows(0)!t_vtyt = 0
            End If
        Catch ex As Exception
            _ds.Tables(0).Rows(0)!t_vtyt = 0
        End Try

        Return RipXML(_ds)
    End Function
    Public Function KtaoDataTable() As DataTable
        Dim dsRip As New DataSet
        Dim dtNew As New DataTable
        dsRip.Tables.Add(dtNew)
        dtNew.Columns.Add("ID", GetType(Integer))
        dtNew.Columns.Add("XML1_ID", GetType(Integer))
        dtNew.Columns.Add("KY_QT", GetType(String))
        dtNew.Columns.Add("COSOKCB_ID", GetType(Integer))
        dtNew.Columns.Add("MA_CSKCB")
        dtNew.Columns.Add("MA_LK")
        dtNew.Columns.Add("MA_BN")
        dtNew.Columns.Add("HO_TEN")
        dtNew.Columns.Add("NGAY_SINH")
        dtNew.Columns.Add("GIOI_TINH", GetType(Integer))
        dtNew.Columns.Add("MA_THE")
        dtNew.Columns.Add("MA_DKBD")
        dtNew.Columns.Add("GT_THE_TU")
        dtNew.Columns.Add("GT_THE_DEN")
        dtNew.Columns.Add("MIEN_CUNG_CT")
        dtNew.Columns.Add("NGAY_VAO")
        dtNew.Columns.Add("NGAY_RA")
        dtNew.Columns.Add("SO_NGAY_DTRI", GetType(Decimal)).DefaultValue = 0
        dtNew.Columns.Add("MA_LYDO_VVIEN")
        dtNew.Columns.Add("MA_BENH")
        dtNew.Columns.Add("MA_BENHKHAC")
        dtNew.Columns.Add("MUC_HUONG_XML1", GetType(Decimal)).DefaultValue = 0
        dtNew.Columns.Add("T_TONGCHI", GetType(Decimal)).DefaultValue = 0
        dtNew.Columns.Add("T_BNTT", GetType(Decimal)).DefaultValue = 0
        dtNew.Columns.Add("T_BHTT", GetType(Decimal)).DefaultValue = 0
        dtNew.Columns.Add("T_BNCCT", GetType(Decimal)).DefaultValue = 0
        dtNew.Columns.Add("T_XN", GetType(Decimal)).DefaultValue = 0
        dtNew.Columns.Add("T_CDHA", GetType(Decimal)).DefaultValue = 0
        dtNew.Columns.Add("T_THUOC", GetType(Decimal)).DefaultValue = 0
        dtNew.Columns.Add("T_MAU", GetType(Decimal)).DefaultValue = 0
        dtNew.Columns.Add("T_TTPT", GetType(Decimal)).DefaultValue = 0
        dtNew.Columns.Add("T_VTYT", GetType(Decimal)).DefaultValue = 0
        dtNew.Columns.Add("T_DKKT_TYLE", GetType(Decimal)).DefaultValue = 0
        dtNew.Columns.Add("T_THUOC_TYLE", GetType(Decimal)).DefaultValue = 0
        dtNew.Columns.Add("T_VTYT_TYLE", GetType(Decimal)).DefaultValue = 0
        dtNew.Columns.Add("T_KHAM", GetType(Decimal)).DefaultValue = 0
        dtNew.Columns.Add("T_GIUONG", GetType(Decimal)).DefaultValue = 0
        dtNew.Columns.Add("T_VCHUYEN", GetType(Decimal)).DefaultValue = 0
        dtNew.Columns.Add("T_NGOAIDS", GetType(Decimal)).DefaultValue = 0
        dtNew.Columns.Add("T_NGUONKHAC", GetType(Decimal)).DefaultValue = 0
        dtNew.Columns.Add("MA_LOAI_KCB", GetType(Integer))
        dtNew.Columns.Add("ID_CP", GetType(Integer))
        dtNew.Columns.Add("LOAI_CP").DefaultValue = ""
        dtNew.Columns.Add("MA_CP").DefaultValue = ""
        dtNew.Columns.Add("MA_VAT_TU").DefaultValue = ""
        dtNew.Columns.Add("MA_NHOM").DefaultValue = ""
        dtNew.Columns.Add("TEN_CP").DefaultValue = ""
        dtNew.Columns.Add("DVT").DefaultValue = ""
        dtNew.Columns.Add("SO_DANG_KY").DefaultValue = ""
        dtNew.Columns.Add("HAM_LUONG").DefaultValue = ""
        dtNew.Columns.Add("DUONG_DUNG").DefaultValue = ""
        dtNew.Columns.Add("SO_LUONG", GetType(Decimal)).DefaultValue = 0
        dtNew.Columns.Add("SO_LUONG_BV", GetType(Decimal)).DefaultValue = 0
        dtNew.Columns.Add("DON_GIA", GetType(Decimal)).DefaultValue = 0
        dtNew.Columns.Add("DON_GIA_BV", GetType(Decimal)).DefaultValue = 0
        dtNew.Columns.Add("THANH_TIEN", GetType(Decimal)).DefaultValue = 0
        dtNew.Columns.Add("TYLE_TT", GetType(Decimal)).DefaultValue = 0
        dtNew.Columns.Add("NGAY_YL").DefaultValue = ""
        dtNew.Columns.Add("NGAY_KQ").DefaultValue = ""
        dtNew.Columns.Add("T_NGUONKHAC_DTL", GetType(Decimal)).DefaultValue = 0
        dtNew.Columns.Add("T_BNTT_DTL", GetType(Decimal)).DefaultValue = 0
        dtNew.Columns.Add("T_BHTT_DTL", GetType(Decimal)).DefaultValue = 0
        dtNew.Columns.Add("T_BNCCT_DTL", GetType(Decimal)).DefaultValue = 0
        dtNew.Columns.Add("T_NGOAIDS_DTL", GetType(Decimal)).DefaultValue = 0
        dtNew.Columns.Add("MUC_HUONG_DTL", GetType(Decimal)).DefaultValue = 0
        dtNew.Columns.Add("TT_THAU").DefaultValue = ""
        dtNew.Columns.Add("PHAM_VI")
        dtNew.Columns.Add("MA_GIUONG").DefaultValue = ""
        dtNew.Columns.Add("T_TRANTT", GetType(Decimal)).DefaultValue = 0
        dtNew.Columns.Add("GOI_VTYT")
        dtNew.Columns.Add("TEN_VAT_TU").DefaultValue = ""
        dtNew.Columns.Add("TEN_KHOA").DefaultValue = ""
        dtNew.Columns.Add("MA_KHOA").DefaultValue = ""
        dtNew.Columns.Add("MA_KHOA_XML1").DefaultValue = ""
        dtNew.Columns.Add("TEN_KHOA_XML1").DefaultValue = ""
        dtNew.Columns.Add("TEN_BENH").DefaultValue = ""
        dtNew.Columns.Add("MA_BAC_SI").DefaultValue = 0
        dtNew.Columns.Add("MA_TINH").DefaultValue = 92
        dtNew.Columns.Add("MA_TINH_THE").DefaultValue = 0
        dtNew.Columns.Add("LIEU_DUNG").DefaultValue = ""
        dtNew.Columns.Add("NGAYNHAN_CONG").DefaultValue = ""
        Return dtNew
    End Function
    Function RipXML(ByVal ds As DataSet) As DataTable
        Dim dtHC = ds.Tables(0)
        Dim dtThuoc = ds.Tables(1)
        Dim dtDichVu = ds.Tables(2)

        Dim dtReturn As DataTable = KtaoDataTable()
        Dim dem As Integer = 1
        For Each itemThuoc In ds.Tables(1).Rows
            Dim item As DataRow = dtReturn.NewRow
            dtReturn.Rows.Add(item)
            Dim itemHC As DataRow = dtHC.Rows(0)
            item("ID") = 1
            item("XML1_ID") = dtHC.Rows(0)!ma_lk
            item("KY_QT") = dtHC.Rows(0)!nam_qt & Strings.Right("0" & dtHC.Rows(0)!thang_qt, 2)
            item("COSOKCB_ID") = 92001
            item("MA_CSKCB") = itemHC!ma_cskcb
            item("MA_LK") = itemHC!ma_lk
            item("MA_BN") = itemHC!ma_bn
            item("HO_TEN") = itemHC!ho_ten
            item("NGAY_SINH") = itemHC!ngay_sinh
            item("GIOI_TINH") = itemHC!gioi_tinh
            item("MA_THE") = itemHC!ma_the
            item("MA_DKBD") = itemHC!ma_dkbd
            item("GT_THE_TU") = itemHC!gt_the_tu
            item("GT_THE_DEN") = itemHC!gt_the_den
            item("MIEN_CUNG_CT") = itemHC!MIEN_CUNG_CT
            item("NGAY_VAO") = itemHC!NGAY_VAO
            item("NGAY_RA") = itemHC!NGAY_RA
            item("SO_NGAY_DTRI") = LocBien(itemHC!SO_NGAY_DTRI, Kieu.So, 0)
            item("MA_LYDO_VVIEN") = itemHC!MA_LYDO_VVIEN
            item("MA_BENH") = itemHC!MA_BENH
            item("MA_BENHKHAC") = itemHC!MA_BENHKHAC
            item("MUC_HUONG_XML1") = itemThuoc!MUC_HUONG
            item("T_TONGCHI") = itemHC!t_tongchi
            item("T_BNTT") = itemHC!T_BNTT
            item("T_BHTT") = itemHC!T_BHTT
            item("T_BNCCT") = itemHC!T_BNCCT
            '
            item("T_XN") = LocBien(dtDichVu.Compute("Sum(thanh_tien)", "ma_nhom='1'"), Kieu.So, 0)
            item("T_CDHA") = LocBien(dtDichVu.Compute("Sum(thanh_tien)", "ma_nhom='2'"), Kieu.So, 0)
            item("T_THUOC") = LocBien(dtThuoc.Compute("Sum(thanh_tien)", "ma_nhom='4'"), Kieu.So, 0)
            item("T_MAU") = LocBien(dtThuoc.Compute("Sum(thanh_tien)", "ma_nhom='7'"), Kieu.So, 0)
            item("T_TTPT") = LocBien(dtDichVu.Compute("Sum(thanh_tien)", "ma_nhom='8'"), Kieu.So, 0)
            item("T_VTYT") = LocBien(dtDichVu.Compute("Sum(thanh_tien)", "ma_nhom='10'"), Kieu.So, 0)
            item("T_DKKT_TYLE") = LocBien(dtDichVu.Compute("Sum(thanh_tien)", "ma_nhom='9'"), Kieu.So, 0)
            item("T_THUOC_TYLE") = LocBien(dtThuoc.Compute("Sum(thanh_tien)", "ma_nhom='6'"), Kieu.So, 0)
            item("T_VTYT_TYLE") = LocBien(dtDichVu.Compute("Sum(thanh_tien)", "ma_nhom='11'"), Kieu.So, 0)
            item("T_KHAM") = LocBien(dtDichVu.Compute("Sum(thanh_tien)", "ma_nhom='13'"), Kieu.So, 0)
            item("T_GIUONG") = LocBien(dtDichVu.Compute("Sum(thanh_tien)", "ma_nhom='14'"), Kieu.So, 0) + LocBien(dtDichVu.Compute("Sum(thanh_tien)", "ma_nhom='15'"), Kieu.So, 0)
            item("T_VCHUYEN") = LocBien(dtDichVu.Compute("Sum(thanh_tien)", "ma_nhom='12'"), Kieu.So, 0)
            item("T_NGOAIDS") = 0
            item("T_NGUONKHAC") = 0
            '
            item("MA_LOAI_KCB") = itemHC!MA_LOAI_KCB
            item("ID_CP") = dem : dem += 1
            item("LOAI_CP") = "xml2"
            '
            item("MA_CP") = itemThuoc!ma_thuoc.ToString
            '
            item("MA_VAT_TU") = ""
            item("MA_NHOM") = itemThuoc!ma_nhom.ToString
            item("TEN_CP") = itemThuoc!ten_thuoc.ToString
            item("DVT") = itemThuoc!don_vi_tinh.ToString
            item("SO_DANG_KY") = itemThuoc!so_dang_ky.ToString
            item("HAM_LUONG") = itemThuoc!ham_luong.ToString
            item("DUONG_DUNG") = itemThuoc!duong_dung.ToString
            item("SO_LUONG") = itemThuoc!so_luong
            item("SO_LUONG_BV") = itemThuoc!so_luong
            item("DON_GIA") = itemThuoc!don_gia
            item("DON_GIA_BV") = itemThuoc!don_gia
            item("THANH_TIEN") = itemThuoc!thanh_tien
            item("TYLE_TT") = itemThuoc!tyle_tt
            item("NGAY_YL") = itemThuoc!ngay_yl
            item("NGAY_KQ") = ""
            item("T_NGUONKHAC_DTL") = 0
            item("T_BNTT_DTL") = itemThuoc!t_bntt
            item("T_BHTT_DTL") = itemThuoc!t_bhtt
            item("T_BNCCT_DTL") = itemThuoc!t_bncct
            item("T_NGOAIDS_DTL") = 0
            item("MUC_HUONG_DTL") = itemThuoc!muc_huong
            item("TT_THAU") = itemThuoc!tt_thau
            item("PHAM_VI") = itemThuoc!pham_vi
            item("MA_GIUONG") = ""
            item("T_TRANTT") = 0
            item("GOI_VTYT") = ""
            item("TEN_VAT_TU") = ""
            item("TEN_KHOA") = itemThuoc!tenkhoa
            item("TEN_KHOA_XML1") = itemHC!tenkhoa
            item("MA_KHOA") = itemThuoc!ma_khoa
            item("MA_KHOA_XML1") = itemHC!ma_khoa
            item("TEN_BENH") = dbHis.GetTable("select tenbenh from dmbenh where mabenh like '" & itemThuoc!ma_benh.ToString & "'").Rows(0)(0).ToString
            item("MA_BAC_SI") = itemThuoc!ma_bac_si
            item("MA_TINH") = "92"
            item("MA_TINH_THE") = itemHC!ma_the.ToString.Substring(3, 2)
        Next
        dem = 1
        For Each itemThuoc In ds.Tables(2).Rows
            Dim item As DataRow = dtReturn.NewRow
            dtReturn.Rows.Add(item)
            Dim itemHC As DataRow = dtHC.Rows(0)
            item("ID") = 1
            item("XML1_ID") = dtHC.Rows(0)!ma_lk
            item("KY_QT") = dtHC.Rows(0)!nam_qt & Strings.Right("0" & dtHC.Rows(0)!thang_qt, 2)
            '
            item("COSOKCB_ID") = 92001
            '
            item("MA_CSKCB") = itemHC!ma_cskcb
            item("MA_LK") = itemHC!ma_lk
            item("MA_BN") = itemHC!ma_bn
            item("HO_TEN") = itemHC!ho_ten
            item("NGAY_SINH") = itemHC!ngay_sinh
            item("GIOI_TINH") = itemHC!gioi_tinh
            item("MA_THE") = itemHC!ma_the
            item("MA_DKBD") = itemHC!ma_dkbd
            item("GT_THE_TU") = itemHC!gt_the_tu
            item("GT_THE_DEN") = itemHC!gt_the_den
            item("MIEN_CUNG_CT") = itemHC!MIEN_CUNG_CT
            item("NGAY_VAO") = itemHC!NGAY_VAO
            item("NGAY_RA") = itemHC!NGAY_RA
            item("SO_NGAY_DTRI") = itemHC!SO_NGAY_DTRI
            item("MA_LYDO_VVIEN") = itemHC!MA_LYDO_VVIEN
            item("MA_BENH") = itemHC!MA_BENH
            item("MA_BENHKHAC") = itemHC!MA_BENHKHAC
            item("MUC_HUONG_XML1") = itemThuoc!MUC_HUONG
            item("T_TONGCHI") = itemHC!t_tongchi
            item("T_BNTT") = itemHC!T_BNTT
            item("T_BHTT") = itemHC!T_BHTT
            item("T_BNCCT") = itemHC!T_BNCCT
            '
            item("T_XN") = LocBien(dtDichVu.Compute("Sum(thanh_tien)", "ma_nhom='1'"), Kieu.So, 0)
            item("T_CDHA") = LocBien(dtDichVu.Compute("Sum(thanh_tien)", "ma_nhom='2'"), Kieu.So, 0)
            item("T_THUOC") = LocBien(dtThuoc.Compute("Sum(thanh_tien)", "ma_nhom='4'"), Kieu.So, 0)
            item("T_MAU") = LocBien(dtThuoc.Compute("Sum(thanh_tien)", "ma_nhom='7'"), Kieu.So, 0)
            item("T_TTPT") = LocBien(dtDichVu.Compute("Sum(thanh_tien)", "ma_nhom='8'"), Kieu.So, 0)
            item("T_VTYT") = LocBien(dtDichVu.Compute("Sum(thanh_tien)", "ma_nhom='10'"), Kieu.So, 0)
            item("T_DKKT_TYLE") = LocBien(dtDichVu.Compute("Sum(thanh_tien)", "ma_nhom='9'"), Kieu.So, 0)
            item("T_THUOC_TYLE") = LocBien(dtThuoc.Compute("Sum(thanh_tien)", "ma_nhom='6'"), Kieu.So, 0)
            item("T_VTYT_TYLE") = LocBien(dtDichVu.Compute("Sum(thanh_tien)", "ma_nhom='11'"), Kieu.So, 0)
            item("T_KHAM") = LocBien(dtDichVu.Compute("Sum(thanh_tien)", "ma_nhom='13'"), Kieu.So, 0)
            item("T_GIUONG") = LocBien(dtDichVu.Compute("Sum(thanh_tien)", "ma_nhom='14'"), Kieu.So, 0) + LocBien(dtDichVu.Compute("Sum(thanh_tien)", "ma_nhom='15'"), Kieu.So, 0)
            item("T_VCHUYEN") = LocBien(dtDichVu.Compute("Sum(thanh_tien)", "ma_nhom='12'"), Kieu.So, 0)
            item("T_NGOAIDS") = 0
            item("T_NGUONKHAC") = 0
            '
            item("MA_LOAI_KCB") = itemHC!MA_LOAI_KCB
            item("ID_CP") = dem : dem += 1
            item("LOAI_CP") = "xml3"
            '
            If (Not String.IsNullOrEmpty(itemThuoc!ma_dich_vu.ToString)) Then
                item("MA_CP") = itemThuoc!ma_dich_vu.ToString
                item("MA_VAT_TU") = itemThuoc!ma_vat_tu.ToString
            Else
                item("MA_CP") = itemThuoc!ma_vat_tu.ToString
                item("MA_VAT_TU") = ""
            End If
            '

            item("MA_NHOM") = itemThuoc!ma_nhom.ToString
            item("TEN_CP") = If(Not String.IsNullOrEmpty(itemThuoc!ten_vat_tu.ToString), itemThuoc!ten_vat_tu.ToString, itemThuoc!ten_dich_vu.ToString)
            item("DVT") = itemThuoc!don_vi_tinh.ToString
            item("SO_DANG_KY") = ""
            item("HAM_LUONG") = ""
            item("DUONG_DUNG") = ""
            item("SO_LUONG") = itemThuoc!so_luong
            item("SO_LUONG_BV") = itemThuoc!so_luong
            item("DON_GIA") = itemThuoc!don_gia
            item("DON_GIA_BV") = itemThuoc!don_gia
            item("THANH_TIEN") = itemThuoc!thanh_tien
            item("TYLE_TT") = itemThuoc!tyle_tt
            item("NGAY_YL") = itemThuoc!ngay_yl
            item("NGAY_KQ") = ""
            item("T_NGUONKHAC_DTL") = 0
            item("T_BNTT_DTL") = itemThuoc!t_bntt
            item("T_BHTT_DTL") = itemThuoc!t_bhtt
            item("T_BNCCT_DTL") = itemThuoc!t_bncct
            item("T_NGOAIDS_DTL") = 0
            item("MUC_HUONG_DTL") = itemThuoc!muc_huong
            item("TT_THAU") = ""
            item("PHAM_VI") = itemThuoc!pham_vi
            item("MA_GIUONG") = ""
            item("T_TRANTT") = LocBien(itemThuoc!t_trantt, Kieu.So, 0)
            item("GOI_VTYT") = ""
            item("TEN_VAT_TU") = itemThuoc!ten_vat_tu.ToString
            item("TEN_KHOA") = itemThuoc!tenkhoa
            item("TEN_KHOA_XML1") = itemHC!tenkhoa
            item("MA_KHOA") = itemThuoc!ma_khoa
            item("MA_KHOA_XML1") = itemHC!ma_khoa
            item("TEN_BENH") = dbHis.GetTable("select tenbenh from dmbenh where mabenh like '" & itemThuoc!ma_benh.ToString & "'").Rows(0)(0).ToString
            item("MA_BAC_SI") = itemThuoc!MA_BAC_SI
            item("MA_TINH") = "92"
            item("MA_TINH_THE") = itemHC!ma_the.ToString.Substring(3, 2)
        Next
        Return dtReturn
    End Function
End Class
