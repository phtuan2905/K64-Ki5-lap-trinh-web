CREATE DATABASE QLSach;
GO
USE QLSach;
GO

ALTER DATABASE QLSach
SET SINGLE_USER WITH ROLLBACK IMMEDIATE;

DROP DATABASE QLSach;

CREATE TABLE LoaiHang (
    LoaiHangID INT PRIMARY KEY,
    TenLoai VARCHAR(255) NOT NULL
);

CREATE TABLE NhaXuatBan (
    NhaXuatBanID INT PRIMARY KEY,
    TenNhaXuatBan VARCHAR(255) NOT NULL
);

CREATE TABLE Sach (
    SachID INT PRIMARY KEY,
    TenSach VARCHAR(255) NOT NULL,
    DonGia DECIMAL(10,2) NOT NULL,
    NamXuatBan INT NOT NULL,
    Anh VARCHAR(255),
    NhaXuatBanID INT NOT NULL,
    LoaiHangID INT NOT NULL,
    FOREIGN KEY (NhaXuatBanID) REFERENCES NhaXuatBan(NhaXuatBanID),
    FOREIGN KEY (LoaiHangID) REFERENCES LoaiHang(LoaiHangID)
);

INSERT INTO LoaiHang (LoaiHangID, TenLoai) VALUES
(1, 'Văn học'),
(2, 'Khoa học'),
(3, 'Thiếu nhi'),
(4, 'Kinh tế');

INSERT INTO NhaXuatBan (NhaXuatBanID, TenNhaXuatBan) VALUES
(1, 'NXB Kim Đồng'),
(2, 'NXB Giáo Dục'),
(3, 'NXB Trẻ'),
(4, 'NXB Khoa Học & Kỹ Thuật');

INSERT INTO Sach (SachID, TenSach, DonGia, NamXuatBan, Anh, NhaXuatBanID, LoaiHangID) VALUES
(101, 'Dế Mèn Phiêu Lưu Ký', 55000, 2008, '1.jpg', 1, 1),
(102, 'Lão Hạc', 42000, 2010, '2.jpg', 1, 1),
(103, 'Vũ Trụ Trong Vỏ Hạt Dẻ', 120000, 2012, '3.jpg', 4, 2),
(104, 'Bản Chất Không Gian & Thời Gian', 135000, 2017, '4.jpg', 4, 2),
(105, 'Truyện Cổ Grimm', 76000, 2005, '5.jpg', 1, 3),
(106, 'Những Tấm Lòng Cao Cả', 68000, 2009, '6.jpg', 3, 1),
(107, 'Tư Duy Nhanh Và Chậm', 145000, 2018, '7.jpg', 3, 4),
(108, 'Khởi Nghiệp 4.0', 98000, 2020, '8.jpg', 3, 4),
(109, 'Bạn Đọc Nhỏ', 35000, 2006, '9.jpg', 2, 3),
(110, 'Vạn Vật', 110000, 2019, '10.jpg', 4, 2);

