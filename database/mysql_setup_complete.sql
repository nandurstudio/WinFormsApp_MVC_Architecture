-- ============================================================
-- COMPLETE DATABASE SETUP - ALL IN ONE
-- Aplikasi Penjualan & Pembelian - VB.NET
-- Untuk Nilai 100 - Pemrograman Visual
-- 
-- Nama: Nandang Duryat
-- NIM: 312310233
-- Kelas: TI.23.B1
-- Universitas: Pelita Bangsa
-- ============================================================

-- INSTRUCTIONS:
-- Run this single file to setup COMPLETE database
-- mysql -u root -p < mysql_setup_complete.sql

-- ============================================================
-- CREATE DATABASE
-- ============================================================
CREATE DATABASE IF NOT EXISTS penjualan_visual_db;
USE penjualan_visual_db;

SET FOREIGN_KEY_CHECKS = 0;

-- Drop all tables
DROP TABLE IF EXISTS purchasedetail;
DROP TABLE IF EXISTS purchase;
DROP TABLE IF EXISTS supplier;
DROP TABLE IF EXISTS saledetail;
DROP TABLE IF EXISTS sale;
DROP TABLE IF EXISTS items;
DROP TABLE IF EXISTS category;
DROP TABLE IF EXISTS users;

-- Drop all views
DROP VIEW IF EXISTS vw_sales_report;
DROP VIEW IF EXISTS vw_purchase_report;
DROP VIEW IF EXISTS vw_purchase_summary;
DROP VIEW IF EXISTS vw_item_stock;
DROP VIEW IF EXISTS vw_sales_by_category;
DROP VIEW IF EXISTS vw_supplier_purchase_summary;

-- Drop all procedures
DROP PROCEDURE IF EXISTS sp_get_next_item_code;
DROP PROCEDURE IF EXISTS sp_get_next_transaction_code;
DROP PROCEDURE IF EXISTS sp_get_next_supplier_code;
DROP PROCEDURE IF EXISTS sp_get_next_purchase_code;

SET FOREIGN_KEY_CHECKS = 1;

-- ============================================================
-- TABLE: users
-- ============================================================
CREATE TABLE users (
    user_id INT AUTO_INCREMENT PRIMARY KEY,
    username VARCHAR(50) UNIQUE NOT NULL,
    password VARCHAR(500) NOT NULL,
    email VARCHAR(100),
    role ENUM('admin', 'user') DEFAULT 'user',
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    updated_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
    INDEX idx_username (username),
    INDEX idx_role (role)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- ============================================================
-- TABLE: category
-- ============================================================
CREATE TABLE category (
    id INT AUTO_INCREMENT PRIMARY KEY,
    categoryDesc VARCHAR(100) NOT NULL,
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    updated_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
    INDEX idx_category_desc (categoryDesc)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- ============================================================
-- TABLE: items
-- ============================================================
CREATE TABLE items (
    id INT AUTO_INCREMENT PRIMARY KEY,
    itemID VARCHAR(20) UNIQUE NOT NULL,
    itemDesc VARCHAR(200) NOT NULL,
    itemCate INT NOT NULL,
    unit VARCHAR(20) DEFAULT 'PCS',
    salesPrice DECIMAL(15,2) NOT NULL DEFAULT 0.00,
    minStock INT DEFAULT 0,
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    updated_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
    FOREIGN KEY (itemCate) REFERENCES category(id) ON DELETE RESTRICT,
    INDEX idx_item_id (itemID),
    INDEX idx_item_desc (itemDesc)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- ============================================================
-- TABLE: supplier
-- ============================================================
CREATE TABLE supplier (
    id INT AUTO_INCREMENT PRIMARY KEY,
    supplierCode VARCHAR(20) UNIQUE NOT NULL,
    supplierName VARCHAR(200) NOT NULL,
    contact VARCHAR(100),
    phone VARCHAR(20),
    email VARCHAR(100),
    address TEXT,
    city VARCHAR(100),
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    updated_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
    INDEX idx_supplier_code (supplierCode),
    INDEX idx_supplier_name (supplierName)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- ============================================================
-- TABLE: sale
-- ============================================================
CREATE TABLE sale (
    idTrans VARCHAR(20) PRIMARY KEY,
    saleDate DATETIME NOT NULL,
    totalAmount DECIMAL(15,2) DEFAULT 0.00,
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    INDEX idx_sale_date (saleDate)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- ============================================================
-- TABLE: saledetail
-- ============================================================
CREATE TABLE saledetail (
    id INT AUTO_INCREMENT PRIMARY KEY,
    idSale VARCHAR(20) NOT NULL,
    itemID VARCHAR(20) NOT NULL,
    qtySale INT NOT NULL,
    price DECIMAL(15,2) NOT NULL,
    subtotal DECIMAL(15,2) NOT NULL,
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (idSale) REFERENCES sale(idTrans) ON DELETE CASCADE,
    INDEX idx_sale_id (idSale)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- ============================================================
-- TABLE: purchase
-- ============================================================
CREATE TABLE purchase (
    idPurchase VARCHAR(20) PRIMARY KEY,
    purchaseDate DATETIME NOT NULL,
    supplierId INT NOT NULL,
    totalAmount DECIMAL(15,2) DEFAULT 0.00,
    notes TEXT,
    status ENUM('pending', 'completed', 'cancelled') DEFAULT 'completed',
    created_by INT,
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    updated_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
    FOREIGN KEY (supplierId) REFERENCES supplier(id) ON DELETE RESTRICT,
    FOREIGN KEY (created_by) REFERENCES users(user_id) ON DELETE SET NULL,
    INDEX idx_purchase_date (purchaseDate),
    INDEX idx_supplier_id (supplierId)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- ============================================================
-- TABLE: purchasedetail
-- ============================================================
CREATE TABLE purchasedetail (
    id INT AUTO_INCREMENT PRIMARY KEY,
    idPurchase VARCHAR(20) NOT NULL,
    itemID VARCHAR(20) NOT NULL,
    qtyPurchase INT NOT NULL,
    purchasePrice DECIMAL(15,2) NOT NULL,
    subtotal DECIMAL(15,2) NOT NULL,
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (idPurchase) REFERENCES purchase(idPurchase) ON DELETE CASCADE,
    FOREIGN KEY (itemID) REFERENCES items(itemID) ON DELETE RESTRICT,
    INDEX idx_purchase_id (idPurchase),
    INDEX idx_item_id (itemID)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- ============================================================
-- INSERT SAMPLE DATA
-- ============================================================

-- Users (password will be set by application)
INSERT INTO users (username, password, email, role) VALUES
('admin', 'TEMP', 'admin@penjualan.com', 'admin');

-- Categories
INSERT INTO category (categoryDesc) VALUES
('Elektronik'),
('Pakaian'),
('Makanan & Minuman'),
('Peralatan Rumah Tangga'),
('Buku & Alat Tulis'),
('Olahraga'),
('Kesehatan & Kecantikan'),
('Mainan & Hobi');

-- Items
INSERT INTO items (itemID, itemDesc, itemCate, unit, salesPrice, minStock) VALUES
('B0001', 'Laptop ASUS ROG', 1, 'UNIT', 15000000.00, 5),
('B0002', 'Mouse Gaming Logitech', 1, 'PCS', 500000.00, 10),
('B0003', 'Keyboard Mechanical', 1, 'PCS', 800000.00, 10),
('B0004', 'Kaos Polos Premium', 2, 'PCS', 75000.00, 50),
('B0005', 'Celana Jeans', 2, 'PCS', 250000.00, 30),
('B0006', 'Kopi Arabica 250gr', 3, 'PACK', 50000.00, 100),
('B0007', 'Teh Hijau Premium', 3, 'BOX', 35000.00, 80),
('B0008', 'Panci Set Stainless', 4, 'SET', 350000.00, 20);

-- Suppliers
INSERT INTO supplier (supplierCode, supplierName, contact, phone, email, address, city) VALUES
('SUP0001', 'PT. Elektronik Jaya', 'Budi Santoso', '021-1234567', 'budi@elektronikjaya.com', 'Jl. Sudirman No. 123', 'Jakarta'),
('SUP0002', 'CV. Fashion Indonesia', 'Siti Rahayu', '022-9876543', 'siti@fashionid.com', 'Jl. Dago No. 45', 'Bandung'),
('SUP0003', 'UD. Sumber Rezeki', 'Ahmad Yani', '031-5551234', 'ahmad@sumberrezeki.com', 'Jl. Tunjungan No. 78', 'Surabaya'),
('SUP0004', 'PT. Global Tech', 'Linda Wijaya', '021-7778888', 'linda@globaltech.com', 'Jl. Gatot Subroto No. 90', 'Jakarta'),
('SUP0005', 'CV. Mitra Sejahtera', 'Andi Pratama', '0274-555999', 'andi@mitrasejahtera.com', 'Jl. Malioboro No. 12', 'Yogyakarta');

-- Sample Sales
INSERT INTO sale (idTrans, saleDate, totalAmount) VALUES
('TRX0001', '2024-01-15 10:30:00', 0),
('TRX0002', '2024-01-15 14:20:00', 0),
('TRX0003', '2024-01-16 09:15:00', 0);

INSERT INTO saledetail (idSale, itemID, qtySale, price, subtotal) VALUES
('TRX0001', 'B0001', 1, 15000000.00, 15000000.00),
('TRX0001', 'B0002', 2, 500000.00, 1000000.00),
('TRX0002', 'B0004', 5, 75000.00, 375000.00),
('TRX0002', 'B0006', 3, 50000.00, 150000.00),
('TRX0003', 'B0003', 1, 800000.00, 800000.00),
('TRX0003', 'B0005', 2, 250000.00, 500000.00);

-- Sample Purchases
INSERT INTO purchase (idPurchase, purchaseDate, supplierId, totalAmount, status, created_by) VALUES
('PUR0001', '2024-01-10 09:30:00', 1, 0, 'completed', 1),
('PUR0002', '2024-01-12 14:20:00', 2, 0, 'completed', 1),
('PUR0003', '2024-01-15 10:15:00', 3, 0, 'completed', 1);

INSERT INTO purchasedetail (idPurchase, itemID, qtyPurchase, purchasePrice, subtotal) VALUES
('PUR0001', 'B0001', 5, 12000000.00, 60000000.00),
('PUR0001', 'B0002', 10, 400000.00, 4000000.00),
('PUR0002', 'B0004', 50, 50000.00, 2500000.00),
('PUR0002', 'B0005', 30, 200000.00, 6000000.00),
('PUR0003', 'B0006', 100, 35000.00, 3500000.00),
('PUR0003', 'B0007', 80, 25000.00, 2000000.00);

-- ============================================================
-- CREATE VIEWS
-- ============================================================

-- Sales Report View
CREATE OR REPLACE VIEW vw_sales_report AS
SELECT 
    s.idTrans AS NOTA,
    s.saleDate AS TGL_NOTA,
    sd.itemID AS KODE_BRG,
    i.itemDesc AS NAMA_BRG,
    sd.qtySale AS QTY,
    sd.price AS HARGA,
    i.unit AS UNIT,
    sd.subtotal AS SUBTOTAL,
    s.totalAmount AS TOTAL_TRANSAKSI
FROM sale s
INNER JOIN saledetail sd ON s.idTrans = sd.idSale
LEFT JOIN items i ON sd.itemID = i.itemID
ORDER BY s.saleDate DESC, s.idTrans;

-- Purchase Report View
CREATE OR REPLACE VIEW vw_purchase_report AS
SELECT 
    p.idPurchase AS NOTA,
    p.purchaseDate AS TGL_NOTA,
    s.supplierCode AS KODE_SUPPLIER,
    s.supplierName AS NAMA_SUPPLIER,
    pd.itemID AS KODE_BRG,
    i.itemDesc AS NAMA_BRG,
    pd.qtyPurchase AS QTY,
    pd.purchasePrice AS HARGA_BELI,
    i.unit AS UNIT,
    pd.subtotal AS SUBTOTAL,
    p.totalAmount AS TOTAL_TRANSAKSI,
    p.status AS STATUS,
    u.username AS CREATED_BY
FROM purchase p
INNER JOIN purchasedetail pd ON p.idPurchase = pd.idPurchase
LEFT JOIN supplier s ON p.supplierId = s.id
LEFT JOIN items i ON pd.itemID = i.itemID
LEFT JOIN users u ON p.created_by = u.user_id
ORDER BY p.purchaseDate DESC, p.idPurchase;

-- Purchase Summary View
CREATE OR REPLACE VIEW vw_purchase_summary AS
SELECT 
    p.idPurchase,
    p.purchaseDate,
    s.supplierName,
    s.city,
    COUNT(pd.id) AS total_items,
    SUM(pd.qtyPurchase) AS total_quantity,
    p.totalAmount,
    p.status,
    u.username AS created_by
FROM purchase p
LEFT JOIN supplier s ON p.supplierId = s.id
LEFT JOIN purchasedetail pd ON p.idPurchase = pd.idPurchase
LEFT JOIN users u ON p.created_by = u.user_id
GROUP BY p.idPurchase, p.purchaseDate, s.supplierName, s.city, p.totalAmount, p.status, u.username
ORDER BY p.purchaseDate DESC;

-- Item Stock Summary View
CREATE OR REPLACE VIEW vw_item_stock AS
SELECT 
    i.id,
    i.itemID,
    i.itemDesc,
    c.categoryDesc,
    i.unit,
    i.salesPrice,
    i.minStock,
    COALESCE(SUM(sd.qtySale), 0) AS total_sold,
    i.minStock - COALESCE(SUM(sd.qtySale), 0) AS stock_remaining
FROM items i
LEFT JOIN category c ON i.itemCate = c.id
LEFT JOIN saledetail sd ON i.itemID = sd.itemID
GROUP BY i.id, i.itemID, i.itemDesc, c.categoryDesc, i.unit, i.salesPrice, i.minStock
ORDER BY i.itemDesc;

-- Sales Summary by Category View
CREATE OR REPLACE VIEW vw_sales_by_category AS
SELECT 
    c.id AS category_id,
    c.categoryDesc AS category_name,
    COUNT(DISTINCT s.idTrans) AS total_transactions,
    SUM(sd.qtySale) AS total_items_sold,
    SUM(sd.subtotal) AS total_revenue
FROM category c
LEFT JOIN items i ON c.id = i.itemCate
LEFT JOIN saledetail sd ON i.itemID = sd.itemID
LEFT JOIN sale s ON sd.idSale = s.idTrans
GROUP BY c.id, c.categoryDesc
ORDER BY total_revenue DESC;

-- Supplier Purchase Summary View
CREATE OR REPLACE VIEW vw_supplier_purchase_summary AS
SELECT 
    s.id AS supplier_id,
    s.supplierCode,
    s.supplierName,
    s.city,
    COUNT(DISTINCT p.idPurchase) AS total_transactions,
    SUM(pd.qtyPurchase) AS total_items_purchased,
    SUM(p.totalAmount) AS total_purchase_value,
    MAX(p.purchaseDate) AS last_purchase_date
FROM supplier s
LEFT JOIN purchase p ON s.id = p.supplierId
LEFT JOIN purchasedetail pd ON p.idPurchase = pd.idPurchase
GROUP BY s.id, s.supplierCode, s.supplierName, s.city
ORDER BY total_purchase_value DESC;

-- ============================================================
-- STORED PROCEDURES
-- ============================================================

DELIMITER //

-- Procedure: Get Next Item Code
CREATE PROCEDURE sp_get_next_item_code()
BEGIN
    DECLARE next_code VARCHAR(20);
    DECLARE last_number INT;
    
    SELECT CAST(SUBSTRING(itemID, 2) AS UNSIGNED) INTO last_number
    FROM items
    ORDER BY itemID DESC
    LIMIT 1;
    
    IF last_number IS NULL THEN
        SET next_code = 'B0001';
    ELSE
        SET next_code = CONCAT('B', LPAD(last_number + 1, 4, '0'));
    END IF;
    
    SELECT next_code AS NextItemCode;
END//

-- Procedure: Get Next Transaction Code
CREATE PROCEDURE sp_get_next_transaction_code()
BEGIN
    DECLARE next_code VARCHAR(20);
    DECLARE last_number INT;
    
    SELECT CAST(SUBSTRING(idTrans, 4) AS UNSIGNED) INTO last_number
    FROM sale
    ORDER BY idTrans DESC
    LIMIT 1;
    
    IF last_number IS NULL THEN
        SET next_code = 'TRX0001';
    ELSE
        SET next_code = CONCAT('TRX', LPAD(last_number + 1, 4, '0'));
    END IF;
    
    SELECT next_code AS NextTransCode;
END//

-- Procedure: Get Next Supplier Code
CREATE PROCEDURE sp_get_next_supplier_code()
BEGIN
    DECLARE next_code VARCHAR(20);
    DECLARE last_number INT;
    
    SELECT CAST(SUBSTRING(supplierCode, 4) AS UNSIGNED) INTO last_number
    FROM supplier
    ORDER BY supplierCode DESC
    LIMIT 1;
    
    IF last_number IS NULL THEN
        SET next_code = 'SUP0001';
    ELSE
        SET next_code = CONCAT('SUP', LPAD(last_number + 1, 4, '0'));
    END IF;
    
    SELECT next_code AS NextSupplierCode;
END//

-- Procedure: Get Next Purchase Code
CREATE PROCEDURE sp_get_next_purchase_code()
BEGIN
    DECLARE next_code VARCHAR(20);
    DECLARE last_number INT;
    
    SELECT CAST(SUBSTRING(idPurchase, 4) AS UNSIGNED) INTO last_number
    FROM purchase
    ORDER BY idPurchase DESC
    LIMIT 1;
    
    IF last_number IS NULL THEN
        SET next_code = 'PUR0001';
    ELSE
        SET next_code = CONCAT('PUR', LPAD(last_number + 1, 4, '0'));
    END IF;
    
    SELECT next_code AS NextPurchaseCode;
END//

DELIMITER ;

-- ============================================================
-- CREATE TRIGGERS
-- ============================================================

DELIMITER //

-- Triggers for Sale Total
CREATE TRIGGER trg_update_sale_total_after_insert
AFTER INSERT ON saledetail
FOR EACH ROW
BEGIN
    UPDATE sale
    SET totalAmount = (SELECT SUM(subtotal) FROM saledetail WHERE idSale = NEW.idSale)
    WHERE idTrans = NEW.idSale;
END//

CREATE TRIGGER trg_update_sale_total_after_update
AFTER UPDATE ON saledetail
FOR EACH ROW
BEGIN
    UPDATE sale
    SET totalAmount = (SELECT SUM(subtotal) FROM saledetail WHERE idSale = NEW.idSale)
    WHERE idTrans = NEW.idSale;
END//

CREATE TRIGGER trg_update_sale_total_after_delete
AFTER DELETE ON saledetail
FOR EACH ROW
BEGIN
    UPDATE sale
    SET totalAmount = (SELECT COALESCE(SUM(subtotal), 0) FROM saledetail WHERE idSale = OLD.idSale)
    WHERE idTrans = OLD.idSale;
END//

-- Triggers for Purchase Total
CREATE TRIGGER trg_update_purchase_total_after_insert
AFTER INSERT ON purchasedetail
FOR EACH ROW
BEGIN
    UPDATE purchase
    SET totalAmount = (SELECT SUM(subtotal) FROM purchasedetail WHERE idPurchase = NEW.idPurchase)
    WHERE idPurchase = NEW.idPurchase;
END//

CREATE TRIGGER trg_update_purchase_total_after_update
AFTER UPDATE ON purchasedetail
FOR EACH ROW
BEGIN
    UPDATE purchase
    SET totalAmount = (SELECT SUM(subtotal) FROM purchasedetail WHERE idPurchase = NEW.idPurchase)
    WHERE idPurchase = NEW.idPurchase;
END//

CREATE TRIGGER trg_update_purchase_total_after_delete
AFTER DELETE ON purchasedetail
FOR EACH ROW
BEGIN
    UPDATE purchase
    SET totalAmount = (SELECT COALESCE(SUM(subtotal), 0) FROM purchasedetail WHERE idPurchase = OLD.idPurchase)
    WHERE idPurchase = OLD.idPurchase;
END//

DELIMITER ;

-- ============================================================
-- VERIFICATION
-- ============================================================

SELECT '✅ DATABASE SETUP COMPLETE!' AS Status;
SELECT 'Database: penjualan_visual_db' AS Info;
SELECT 'Tables: 8 (users, category, items, supplier, sale, saledetail, purchase, purchasedetail)' AS Tables;
SELECT 'Views: 6 (vw_sales_report, vw_purchase_report, vw_purchase_summary, vw_item_stock, vw_sales_by_category, vw_supplier_purchase_summary)' AS Views;
SELECT 'Procedures: 4 (sp_get_next_item_code, sp_get_next_transaction_code, sp_get_next_supplier_code, sp_get_next_purchase_code)' AS Procedures;
SELECT 'Triggers: 6 (auto-update totals)' AS Triggers;
SELECT 'Sample Data: YES (categories, items, suppliers, transactions)' AS SampleData;
SELECT 'Default Admin: username=admin, password will be set by app' AS DefaultUser;

-- Show counts
SELECT 'RECORD COUNTS:' AS Info;
SELECT 'Users' AS TableName, COUNT(*) AS Count FROM users
UNION ALL SELECT 'Categories', COUNT(*) FROM category
UNION ALL SELECT 'Items', COUNT(*) FROM items
UNION ALL SELECT 'Suppliers', COUNT(*) FROM supplier
UNION ALL SELECT 'Sales', COUNT(*) FROM sale
UNION ALL SELECT 'Sale Details', COUNT(*) FROM saledetail
UNION ALL SELECT 'Purchases', COUNT(*) FROM purchase
UNION ALL SELECT 'Purchase Details', COUNT(*) FROM purchasedetail;

SELECT '🚀 READY FOR APPLICATION!' AS FinalStatus;
