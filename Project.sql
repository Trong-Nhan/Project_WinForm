--Tạo CSDL
Create database Project
go
--gọi ra để dùng
use Project
go

Create table Tour
(
TourId varchar(20) primary key, 
TourName nvarchar(200) not null,
Destinations nvarchar(200),
Price float,
Describle nvarchar(1500),
TourTime nvarchar(100),
Vehicle nvarchar(100),
TourType nvarchar(100),
TourGuide nvarchar(100)
)
go
--insert dữ liệu mẫu
Insert into Tour values('T01',N'Khám phá Quảng Ninh',N'Hạ Long, Bãi Cháy',2000000,N'Tắm biển, du thuyền ngắm cảnh',N'Từ 20/4/2021 tới 23/4/2021',N'Ô tô',N'Tiêu chuẩn',N'Nguyễn Văn Quyết')
Insert into Tour values('T02',N'Khám phá Quảng Bình',N'Phong Nha Kẻ Bàng',7000000,N'Thăm hang động',N'Từ 12/1/2021 tới 15/1/2021',N'Ô tô, máy bay',N'Cao cấp',N'Nguyễn Công Phượng')
Insert into Tour values('T03',N'Khám phá Hải Phòng',N'Đồ Sơn',1000000,N'Tắm biển, ngắm cảnh, thưởng thức hải sản',N'Từ 20/5/2021 tới 23/5/2021',N'Ô tô',N'Tiết kiệm',N'Nguyễn Quang Hải')
Insert into Tour values('T04',N'Khám phá Nam Định',N'Quất Lâm',2000000,N'Tắm biển, đi dạo biển ban đêm',N'Từ 12/3/2021 tới 15/3/2021',N'Xe máy',N'Tiêu chuẩn',N'Lương Xuân Trường')
Insert into Tour values('T05',N'Khám phá Thái Bình',N'Alcohol Black, Ancohol Rim',2000000,N'Tắm biển, ăn hải sản',N'Từ 20/6/2021 tới 23/6/2021',N'Ô tô',N'Giá tốt',N'Nguyễn Văn Toàn')
go

Create table Customer
(
CusId varchar(20) primary key, 
CusName nvarchar(50) not null,
Gender bit,
Birthday datetime,
CusAddress nvarchar(100),
Phone nvarchar(20),
Email nvarchar(50),
TourId varchar(20) foreign key references Tour(TourId) 
)
go
--thêm dữ liệu mẫu
Insert into Customer values('C01',N'Bùi Trọng Nhân',1,'1/20/1995',N'Thái Bình','0908070605','nhanbui@gmail.com','T01')
Insert into Customer values('C02',N'Phạm Thành Tài',1,'9/12/1997',N'Vũng Tàu','0908070605','taipham@gmail.com','T02')
Insert into Customer values('C03',N'Lê Hoàng Long',1,'2/10/1997',N'Vũng Tàu','0908070605','longle@gmail.com','T03')
Insert into Customer values('C04',N'Tôn Thất Vĩnh',1,'12/25/1992',N'Thừa Thiên Huế','0908070605','vinhton@gmail.com','T04')
Insert into Customer values('C05',N'Cao Minh Thái',1,'3/12/1995',N'Vũng Tàu','0908070605','thaicao@gmail.com','T03')
Insert into Customer values('C06',N'Bùi Tiến Nguyện',1,'7/20/1995',N'Thái Bình','0908070605','nguyenbui@gmail.com','T05')
Insert into Customer values('C07',N'Đào Minh Hưng',1,'8/15/1995',N'Thái Bình','0908070605','hungdao@gmail.com','T02')
Insert into Customer values('C08',N'Phạm Tiến Năng',1,'1/20/1995',N'Thái Bình','0908070605','nangpham@gmail.com','T01')
Insert into Customer values('C09',N'Nguyễn Thùy Dung',0,'11/1/1995',N'Vũng Tàu','0908070605','dungnguyen@gmail.com','T01')
Insert into Customer values('C10',N'Phạm Tâm Anh',0,'9/5/1995',N'Vũng Tàu','0908070605','tamanhpham@gmail.com','T02')
go
Create table LoginUser(
UserId int not null primary key identity,
UserName nvarchar(50),
Pass nvarchar(50)
)
go
Insert into LoginUser values('admin',1234)
go