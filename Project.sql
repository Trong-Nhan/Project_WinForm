--Tạo CSDL
Create database Project
go
--gọi ra để dùng
use Project
go

Create table Vehicle(
Id int primary key identity,
Name nvarchar(50)
)
go
--thêm dữ liệu mẫu
Insert into Vehicle values(N'Ô tô'),(N'Máy bay'),(N'Tàu hỏa'),(N'Du thuyền'),(N'Xe máy'),(N'Xe đạp')
go

Create table TourType(
Id int primary key identity,
Name nvarchar(50)
)
go
--thêm dữ liệu mẫu
Insert into TourType values(N'Tiêu chuẩn'),(N'Cao cấp'),(N'Tiết kiệm'),(N'Giá tốt')
go

Create table TourGuide(
Id int primary key identity,
Name nvarchar(50)
)
go
--thêm dữ liệu mẫu
Insert into TourGuide values(N'Nguyễn Văn Quyết'),(N'Nguyễn Công Phượng'),(N'Nguyễn Quang Hải'),(N'Lương Xuân Trường'),
(N'Nguyễn Văn Toàn'),(N'Bùi Hoàng Việt Anh'),(N'Nguyễn Tuấn Hải'),(N'Phan Tấn Tài'),(N'Lê Văn Đô'),
(N'Ngô Bảo Châu'),(N'Phan Thị Hà Dương'),(N'Nguyễn Ngọc Trường Sơn')
go

Create table Tour
(
TourId varchar(20) primary key, 
TourName nvarchar(200) not null,
Destinations nvarchar(200),
Price float,
Describle nvarchar(1500),
TourTime nvarchar(100),
VehicleId int foreign key references Vehicle(Id),
TourTypeId int foreign key references TourType(Id),
TourGuideId int foreign key references TourGuide(Id)
)
go
--insert dữ liệu mẫu
Insert into Tour values('T01',N'Khám phá Quảng Ninh',N'Hạ Long, Bãi Cháy',2000000,N'Tắm biển, du thuyền ngắm cảnh',N'Từ 20/4/2021 tới 23/4/2021',1,2,3)
Insert into Tour values('T02',N'Khám phá Quảng Bình',N'Phong Nha Kẻ Bàng',7000000,N'Thăm hang động',N'Từ 12/1/2021 tới 15/1/2021',2,3,2)
Insert into Tour values('T03',N'Khám phá Hải Phòng',N'Đồ Sơn',1000000,N'Tắm biển, ngắm cảnh, thưởng thức hải sản',N'Từ 20/5/2021 tới 23/5/2021',2,2,2)
Insert into Tour values('T04',N'Khám phá Nam Định',N'Quất Lâm',2000000,N'Tắm biển, đi dạo biển ban đêm',N'Từ 12/3/2021 tới 15/3/2021',3,1,1)
Insert into Tour values('T05',N'Khám phá Thái Bình',N'Alcohol Black, Ancohol Rim',2000000,N'Tắm biển, ăn hải sản',N'Từ 20/6/2021 tới 23/6/2021',3,3,3)
go

Create table CusAddress(
Id int primary key identity,
Name nvarchar(100)
)
go
--thêm dữ liệu mẫu
Insert into CusAddress values(N'An Giang'),(N'Bà Rịa – Vũng Tàu'),(N'Bạc Liêu'),(N'Bắc Giang'),(N'Bắc Kạn'),(N'Bắc Ninh'),(N'Bến Tre'),
(N'Bình Dương'),(N'Bình Phước'),(N'Bình Thuận'),(N'Cà Mau'),(N'Cần Thơ'),(N'Cao Bằng'),(N'Đà Nẵng'),(N'Đắk Lắk'),(N'Đắk Nông'),
(N'Điện Biên'),(N'Đồng Nai'),(N'Đồng Tháp'),(N'Gia Lai'),(N'Hà Giang'),(N'Hà Nam'),(N'Hà Nội'),(N'Hà Tĩnh'),(N'Hải Dương'),(N'Hải Phòng'),
(N'Hậu Giang'),(N'Hòa Bình'),(N'Hưng Yên'),(N'Khánh Hòa'),(N'Kiên Giang'),(N'Kon Tum'),(N'Lai Châu'),(N'Lâm Đồng'),(N'Lạng Sơn'),
(N'Lào Cai'),(N'Long An'),(N'Nam Định'),(N'Nghệ An'),(N'Ninh Bình'),(N'Ninh Thuận'),(N'Phú Thọ'),(N'Phú Yên'),(N'Quảng Bình'),
(N'Quảng Nam'),(N'Quảng Ngãi'),(N'Quảng Ninh'),(N'Quảng Trị'),(N'Sóc Trăng'),(N'Sơn La'),(N'Tây Ninh'),(N'Thái Bình'),(N'Thái Nguyên'),
(N'Thanh Hóa'),(N'Thừa Thiên Huế'),(N'Tiền Giang'),(N'TP Hồ Chí Minh'),(N'Trà Vinh'),(N'Tuyên Quang'),(N'Vĩnh Long'),(N'Vĩnh Phúc'),
(N'Yên Bái')
go

Create table Gender(
Id int primary key identity,
Name nvarchar(50)
)
go
--thêm dữ liệu mẫu
Insert into Gender values(N'Nam'),(N'Nữ'),(N'LGBTQ+')
go

Create table Customer
(
CusId varchar(20) primary key, 
CusName nvarchar(50) not null,
GenderId int foreign key references Gender(Id),
Birthday datetime,
CusAddressId int foreign key references CusAddress(Id),
Phone nvarchar(20),
Email nvarchar(50),
TourId varchar(20) foreign key references Tour(TourId) 
)
go
--thêm dữ liệu mẫu
Insert into Customer values('C01',N'Bùi Trọng Nhân',1,'1/20/1995',1,'0908070605','nhanbui@gmail.com','T01')
Insert into Customer values('C02',N'Phạm Thành Tài',1,'9/12/1997',2,'0908070605','taipham@gmail.com','T02')
Insert into Customer values('C03',N'Lê Hoàng Long',1,'2/10/1997',3,'0908070605','longle@gmail.com','T03')
Insert into Customer values('C04',N'Tôn Thất Vĩnh',3,'12/25/1992',4,'0908070605','vinhton@gmail.com','T04')
Insert into Customer values('C05',N'Cao Minh Thái',3,'3/12/1995',5,'0908070605','thaicao@gmail.com','T03')
Insert into Customer values('C06',N'Bùi Tiến Nguyện',1,'7/20/1995',6,'0908070605','nguyenbui@gmail.com','T05')
Insert into Customer values('C07',N'Đào Minh Hưng',1,'8/15/1995',7,'0908070605','hungdao@gmail.com','T02')
Insert into Customer values('C08',N'Phạm Tiến Năng',3,'1/20/1995',8,'0908070605','nangpham@gmail.com','T01')
Insert into Customer values('C09',N'Nguyễn Thùy Dung',2,'11/1/1995',9,'0908070605','dungnguyen@gmail.com','T01')
Insert into Customer values('C10',N'Phạm Tâm Anh',3,'9/5/1995',10,'0908070605','tamanhpham@gmail.com','T02')
go

Create table LoginUser(
UserId int not null primary key identity,
UserName nvarchar(50),
Pass nvarchar(50)
)
go
Insert into LoginUser values('admin',1234)
go