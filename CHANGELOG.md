# Changelog

All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [1.0.0] - 2025-01-XX

### 🎉 Initial Release

Desktop Sales & Purchase Management System dengan Clean MVC Architecture untuk Tugas Akhir Semester Pemrograman Visual.

### ✨ Features

#### 🔐 Authentication & Security
- Login system dengan PBKDF2 password hashing (10,000 iterations)
- Role-based access control (Admin/User)
- AES encryption untuk data sensitif
- Session management
- Password validation dengan minimum complexity

#### 📦 Master Data Management
- **Kategori Barang**: CRUD operations untuk kategori produk
- **Data Barang**: Manajemen item/produk dengan auto-generate kode
- **Data Supplier**: Kelola informasi supplier dengan lengkap
- **Kelola User**: User management dengan role assignment (Admin only)

#### 💰 Transaction Module
- **Transaksi Penjualan**:
  - Multi-item transaction support
  - Real-time calculation (subtotal & grand total)
  - Auto stock reduction
  - Keyboard shortcuts (F1/F2/F3)
  - Transaction code auto-generation (TRX0001, TRX0002, ...)
  
- **Transaksi Pembelian**:
  - Purchase from suppliers
  - Auto stock increment
  - Multi-item support
  - Purchase code auto-generation (PUR0001, PUR0002, ...)

#### 📊 Reporting System
- **Laporan Penjualan**:
  - Filter by date range
  - Detailed transaction view
  - Summary statistics
  - Export to CSV/Excel
  - Print to PDF/Printer
  
- **Laporan Pembelian**:
  - Supplier-wise report
  - Date range filtering
  - Transaction details
  - Export & print capabilities

#### 🗄️ Database Features
- **8 Core Tables**: users, category, items, suppliers, sales, saledetail, purchase, purchasedetail
- **6 Database Views**: Optimized reporting queries
- **4 Stored Procedures**: Auto-generate unique codes
- **6 Triggers**: Automatic total amount calculation
- **Foreign Key Constraints**: Data integrity enforcement
- **Transaction Support**: Atomic operations (BEGIN, COMMIT, ROLLBACK)

#### 🎨 User Interface
- Clean MDI (Multiple Document Interface) architecture
- Feature-organized Views (Main, Items, Category, Supplier, User, Sale, Purchase, Report)
- Responsive DataGridView with search functionality
- Keyboard navigation support
- Status bar showing user info & login time
- Professional form design

#### ⚙️ Configuration
- INI file-based configuration
- Database connection settings
- Connection testing
- Easy deployment configuration

### 🏗️ Architecture

- **Clean MVC Pattern**:
  - **Models**: Data entities & database operations
  - **Views**: Windows Forms UI (organized by feature)
  - **Controllers**: Business logic & validation
  
- **Layered Architecture**:
  - Presentation Layer (Views)
  - Business Logic Layer (Controllers)
  - Data Access Layer (Models)
  - Cross-Cutting Concerns (Helpers)

### 🛠️ Technical Stack

- **Framework**: .NET 6.0 Windows Forms
- **Language**: Visual Basic .NET
- **Database**: MySQL 8.0+
- **Connector**: MySql.Data 9.5.0
- **Security**: PBKDF2 + AES encryption

### 📚 Documentation

- Complete architecture visualization with Mermaid diagrams
- API documentation for all controllers
- Database schema documentation
- Setup guide & quick start
- User manual (Bahasa Indonesia)
- Developer guide

### 🎓 Academic Information

- **Mata Kuliah**: TIF503 - Pemrograman Visual (Desktop)
- **Semester**: 5 (Ganjil)
- **Universitas**: Universitas Pelita Bangsa
- **Tahun Akademik**: 2024/2025
- **Mahasiswa**: Nandang Duryat (312310233)

### 📦 Package Contents

```
AplikasiPenjualanMVC-v1.0.0/
├── AplikasiPenjualanMVC.exe      # Main executable
├── setting.ini.example           # Configuration template
├── database/
│   └── mysql_setup_complete.sql  # Database setup script
├── docs/                         # Complete documentation
└── README.md                     # Setup instructions
```

### 🔧 System Requirements

- **OS**: Windows 10/11 (64-bit)
- **Runtime**: .NET 6.0 Runtime (included in package)
- **Database**: MySQL Server 8.0 or higher
- **RAM**: Minimum 2 GB
- **Disk Space**: 100 MB

### 📝 Known Limitations

- Single-user mode (no concurrent access)
- Local database only (no cloud support yet)
- Indonesian language only

### 🚀 Getting Started

1. Install MySQL Server
2. Run `database/mysql_setup_complete.sql`
3. Copy `setting.ini.example` to `setting.ini`
4. Configure database credentials
5. Run `AplikasiPenjualanMVC.exe`
6. Login with default credentials (admin/Admin@123456)

---

## Version History

- **v1.0.0** (2025-01-XX) - Initial Release

---

**Maintained by**: Nandang Duryat (nandurstudio)  
**License**: MIT License  
**Repository**: https://github.com/nandurstudio/WinFormsApp_MVC_Architecture
