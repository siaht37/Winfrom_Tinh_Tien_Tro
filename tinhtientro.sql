-- Tạo cơ sở dữ liệu
CREATE DATABASE TinhTienTro;
GO

-- Sử dụng cơ sở dữ liệu vừa tạo
USE TinhTienTro;
GO

-- Tạo bảng Users (Người dùng)
CREATE TABLE Users (
    UserID INT PRIMARY KEY IDENTITY(1,1),
    Username VARCHAR(50) NOT NULL UNIQUE,
    PasswordHash VARCHAR(255) NOT NULL,
    Role VARCHAR(20) NOT NULL,
    FullName VARCHAR(100),
    PhoneNumber VARCHAR(20),
    Email VARCHAR(100)
);
GO

-- Tạo bảng Rooms (Phòng trọ)
CREATE TABLE Rooms (
    RoomID INT PRIMARY KEY IDENTITY(1,1),
    RoomNumber VARCHAR(20) NOT NULL,
    RoomPrice DECIMAL(18, 2) NOT NULL,
    TenantID INT,
    FOREIGN KEY (TenantID) REFERENCES Users(UserID)
);
GO

-- Tạo bảng ElectricityWaterReadings (Chỉ số Điện Nước)
CREATE TABLE ElectricityWaterReadings (
    ReadingID INT PRIMARY KEY IDENTITY(1,1),
    RoomID INT NOT NULL,
    Month DATE NOT NULL,
    ElectricityUsage INT NOT NULL,
    WaterUsage INT NOT NULL,
    ElectricityUnitPrice DECIMAL(18, 2) NOT NULL,
    WaterUnitPrice DECIMAL(18, 2) NOT NULL,
    FOREIGN KEY (RoomID) REFERENCES Rooms(RoomID)
);
GO

-- Tạo bảng Invoices (Hóa đơn)
CREATE TABLE Invoices (
    InvoiceID INT PRIMARY KEY IDENTITY(1,1),
    RoomID INT NOT NULL,
    Month DATE NOT NULL,
    ElectricityCharge DECIMAL(18, 2) NOT NULL,
    WaterCharge DECIMAL(18, 2) NOT NULL,
    RoomCharge DECIMAL(18, 2) NOT NULL,
    TotalAmount DECIMAL(18, 2) NOT NULL,
    Status VARCHAR(20) NOT NULL,
    FOREIGN KEY (RoomID) REFERENCES Rooms(RoomID)
);
GO


-- Chèn 10 người dùng với vai trò khách thuê (tenant)
INSERT INTO Users (Username, PasswordHash, Role, FullName, PhoneNumber, Email)
VALUES 
('tenant1', 'password1', 'tenant', 'Nguyen Van A', '0909123456', 'tenant1@example.com'),
('tenant2', 'password2', 'tenant', 'Le Thi B', '0909123457', 'tenant2@example.com'),
('tenant3', 'password3', 'tenant', 'Tran Van C', '0909123458', 'tenant3@example.com'),
('tenant4', 'password4', 'tenant', 'Pham Thi D', '0909123459', 'tenant4@example.com'),
('tenant5', 'password5', 'tenant', 'Nguyen Van E', '0909123460', 'tenant5@example.com'),
('tenant6', 'password6', 'tenant', 'Le Thi F', '0909123461', 'tenant6@example.com'),
('tenant7', 'password7', 'tenant', 'Tran Van G', '0909123462', 'tenant7@example.com'),
('tenant8', 'password8', 'tenant', 'Pham Thi H', '0909123463', 'tenant8@example.com'),
('tenant9', 'password9', 'tenant', 'Nguyen Van I', '0909123464', 'tenant9@example.com'),
('tenant10', 'password10', 'tenant', 'Le Thi K', '0909123465', 'tenant10@example.com');

-- Chèn 1 người dùng với vai trò admin
INSERT INTO Users (Username, PasswordHash, Role, FullName, PhoneNumber, Email)
VALUES 
('admin', 'adminpassword', 'admin', 'Admin User', '0909123466', 'admin@example.com');


-- Tạo bảng Rooms với dữ liệu phòng
INSERT INTO Rooms (RoomNumber, RoomPrice, TenantID)
VALUES 
('101', FLOOR(RAND(CHECKSUM(NEWID())) * 20) * 100000 + 2000000, 1),
('102', FLOOR(RAND(CHECKSUM(NEWID())) * 20) * 100000 + 2000000, 2),
('103', FLOOR(RAND(CHECKSUM(NEWID())) * 20) * 100000 + 2000000, 3),
('104', FLOOR(RAND(CHECKSUM(NEWID())) * 20) * 100000 + 2000000, 4),
('201', FLOOR(RAND(CHECKSUM(NEWID())) * 20) * 100000 + 2000000, 5),
('202', FLOOR(RAND(CHECKSUM(NEWID())) * 20) * 100000 + 2000000, 6),
('203', FLOOR(RAND(CHECKSUM(NEWID())) * 20) * 100000 + 2000000, 7),
('204', FLOOR(RAND(CHECKSUM(NEWID())) * 20) * 100000 + 2000000, 8),
('301', FLOOR(RAND(CHECKSUM(NEWID())) * 20) * 100000 + 2000000, 9),
('302', FLOOR(RAND(CHECKSUM(NEWID())) * 20) * 100000 + 2000000, 10),
('303', FLOOR(RAND(CHECKSUM(NEWID())) * 20) * 100000 + 2000000, NULL), -- Phòng không có người thuê
('304', FLOOR(RAND(CHECKSUM(NEWID())) * 20) * 100000 + 2000000, NULL); -- Phòng không có người thuê

-- Chèn dữ liệu điện nước cho tháng 1, 2, 3 năm 2024
INSERT INTO ElectricityWaterReadings (RoomID, Month, ElectricityUsage, WaterUsage, ElectricityUnitPrice, WaterUnitPrice)
VALUES 
-- Tháng 1/2024
(1, '2024-01-01', 100, 20, 3000, 5000),
(2, '2024-01-01', 120, 25, 3000, 5000),
(3, '2024-01-01', 90, 18, 3000, 5000),
(4, '2024-01-01', 110, 22, 3000, 5000),
(5, '2024-01-01', 130, 24, 3000, 5000),
(6, '2024-01-01', 140, 26, 3000, 5000),
(7, '2024-01-01', 105, 21, 3000, 5000),
(8, '2024-01-01', 115, 23, 3000, 5000),
(9, '2024-01-01', 125, 20, 3000, 5000),
(10, '2024-01-01', 95, 19, 3000, 5000),

-- Tháng 2/2024
(1, '2024-02-01', 105, 22, 3000, 5000),
(2, '2024-02-01', 125, 27, 3000, 5000),
(3, '2024-02-01', 95, 19, 3000, 5000),
(4, '2024-02-01', 115, 24, 3000, 5000),
(5, '2024-02-01', 135, 25, 3000, 5000),
(6, '2024-02-01', 145, 28, 3000, 5000),
(7, '2024-02-01', 110, 23, 3000, 5000),
(8, '2024-02-01', 120, 26, 3000, 5000),
(9, '2024-02-01', 130, 21, 3000, 5000),
(10, '2024-02-01', 100, 20, 3000, 5000),

-- Tháng 3/2024
(1, '2024-03-01', 110, 24, 3000, 5000),
(2, '2024-03-01', 130, 28, 3000, 5000),
(3, '2024-03-01', 100, 20, 3000, 5000),
(4, '2024-03-01', 120, 26, 3000, 5000),
(5, '2024-03-01', 140, 27, 3000, 5000),
(6, '2024-03-01', 150, 30, 3000, 5000),
(7, '2024-03-01', 115, 25, 3000, 5000),
(8, '2024-03-01', 125, 28, 3000, 5000),
(9, '2024-03-01', 135, 23, 3000, 5000),
(10, '2024-03-01', 105, 22, 3000, 5000);



-- Chèn hóa đơn cho tháng 1/2024
INSERT INTO Invoices (RoomID, Month, RoomCharge, ElectricityCharge, WaterCharge, TotalAmount)
VALUES 
(1, '2024-01-01', 2000000, 100 * 3000, 20 * 5000, 2000000 + 100 * 3000 + 20 * 5000),
(2, '2024-01-01', 2200000, 120 * 3000, 25 * 5000, 2200000 + 120 * 3000 + 25 * 5000),
(3, '2024-01-01', 2400000, 90 * 3000, 18 * 5000, 2400000 + 90 * 3000 + 18 * 5000),
(4, '2024-01-01', 2600000, 110 * 3000, 22 * 5000, 2600000 + 110 * 3000 + 22 * 5000),
(5, '2024-01-01', 2800000, 130 * 3000, 24 * 5000, 2800000 + 130 * 3000 + 24 * 5000),
(6, '2024-01-01', 3000000, 140 * 3000, 26 * 5000, 3000000 + 140 * 3000 + 26 * 5000),
(7, '2024-01-01', 3200000, 105 * 3000, 21 * 5000, 3200000 + 105 * 3000 + 21 * 5000),
(8, '2024-01-01', 3400000, 115 * 3000, 23 * 5000, 3400000 + 115 * 3000 + 23 * 5000),
(9, '2024-01-01', 3600000, 125 * 3000, 20 * 5000, 3600000 + 125 * 3000 + 20 * 5000),
(10, '2024-01-01', 3800000, 95 * 3000, 19 * 5000, 3800000 + 95 * 3000 + 19 * 5000);

-- Chèn hóa đơn cho tháng 2/2024
INSERT INTO Invoices (RoomID, Month, RoomCharge, ElectricityCharge, WaterCharge, TotalAmount)
VALUES 
(1, '2024-02-01', 2000000, 105 * 3000, 22 * 5000, 2000000 + 105 * 3000 + 22 * 5000),
(2, '2024-02-01', 2200000, 125 * 3000, 27 * 5000, 2200000 + 125 * 3000 + 27 * 5000),
(3, '2024-02-01', 2400000, 95 * 3000, 19 * 5000, 2400000 + 95 * 3000 + 19 * 5000),
(4, '2024-02-01', 2600000, 115 * 3000, 24 * 5000, 2600000 + 115 * 3000 + 24 * 5000),
(5, '2024-02-01', 2800000, 135 * 3000, 25 * 5000, 2800000 + 135 * 3000 + 25 * 5000),
(6, '2024-02-01', 3000000, 145 * 3000, 28 * 5000, 3000000 + 145 * 3000 + 28 * 5000),
(7, '2024-02-01', 3200000, 110 * 3000, 23 * 5000, 3200000 + 110 * 3000 + 23 * 5000),
(8, '2024-02-01', 3400000, 120 * 3000, 26 * 5000, 3400000 + 120 * 3000 + 26 * 5000),
(9, '2024-02-01', 3600000, 130 * 3000, 21 * 5000, 3600000 + 130 * 3000 + 21 * 5000),
(10, '2024-02-01', 3800000, 100 * 3000, 20 * 5000, 3800000 + 100 * 3000 + 20 * 5000);