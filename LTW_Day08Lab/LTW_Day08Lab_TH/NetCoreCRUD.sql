CREATE DATABASE NetCoreCRUD;
GO
USE NetCoreCRUD;
GO

INSERT INTO Category(Name, Status, CreateDate) values ('Category 1', 1, '2025-10-10 17:01:00');
INSERT INTO Product(Name, Image, Price, SalePrice, Status, Description, CreatedDate, CategoryId) values ('Product 1', '~/Product/product.png', 100.100, 0, 1, 'Nothing', '2025-10-10 17:01:00', 1);
INSERT INTO Banner(Name, Image, Status, Description, CreatedDate) values ('Banner 1', '~/Banner/banner.png', 1, 'Nothing', '2025-10-10 17:01:00');