create database quanlydienthoai

use quanlydienthoai

create table HANGSX(
mahang char(10),
tenhang nvarchar(30),
primary key (mahang)
)



insert into HANGSX values('MH01',N'Chanhminion')
insert into HANGSX values('MH02',N'Vietpromises')
insert into HANGSX values('MH03',N'Tiendatmagic')


create table DIENTHOAI(
ma char(10),
ten nvarchar(30),
dongia int,
tonkho int,
mahang char(10),
primary key (ma)
)



insert into DIENTHOAI values('M01',N'Iphone',3000000,30,'MH01')
insert into DIENTHOAI values('M02',N'Vsmart',1000000,10,'MH02')
insert into DIENTHOAI values('M03',N'Xiaomi',1400000,10,'MH03')
insert into DIENTHOAI values('M04',N'Oppo',1400000,10,'MH03')
insert into DIENTHOAI values('M05',N'Samsung',2400000,10,'MH02') 

--truy vấn

SELECT tenhang FROM HANGSX

select * from dienthoai
select DIENTHOAI.ma, DIENTHOAI.ten, DIENTHOAI.dongia, DIENTHOAI.tonkho, DIENTHOAI.mahang from DIENTHOAI,HANGSX where DIENTHOAI.mahang = HANGSX.mahang and HANGSX.tenhang='Chanhminion'
