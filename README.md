# WinFormsApp - MVC Architecture

> Windows Forms Application dengan arsitektur MVC menggunakan VB.NET dan MySQL

## 📋 Project Information

**Tugas Akhir Semester** - Pemrograman Visual (Desktop)

| Detail | Keterangan |
|--------|------------|
| **Mata Kuliah** | TIF503 - Pemrograman Visual (Desktop) |
| **SKS** | 3 SKS |
| **Semester** | 5 (Ganjil) |
| **Kelas** | TI.23.B.1 |
| **Dosen** | Asep Muhidin, S.Kom., M.Kom. |
| **Jurusan** | Teknik Informatika |
| **Universitas** | Universitas Pelita Bangsa |
| **Tahun Akademik** | 2024/2025 |
| **Mahasiswa** | Nandang Duryat (312310233) |

---

## 🚀 Quick Start (5 Menit)

### Prerequisites
- Visual Studio 2019+
- .NET 6.0
- MySQL Server 8.0+

### 1️⃣ Clone Repository
```bash
git clone https://github.com/YOUR_USERNAME/YOUR_REPO_NAME.git
cd YOUR_REPO_NAME
```

### 2️⃣ Setup Database
```sql
-- Login MySQL
mysql -u root -p

-- Jalankan script setup lengkap
source database/mysql_setup_complete.sql
```

### 3️⃣ Konfigurasi Aplikasi
**IMPORTANT:** Copy file template konfigurasi dan sesuaikan dengan environment Anda:

```bash
# Copy template
copy setting.ini.example setting.ini

# Edit setting.ini dengan kredensial database Anda
# JANGAN commit file setting.ini ke Git!
```

Edit file `setting.ini`:
```ini
[DatabaseConfig]
Server=localhost
Database=penjualan_visual_db
Uid=root
Pwd=YOUR_MYSQL_PASSWORD    # Ganti dengan password MySQL Anda
Port=3306

[AppConfig]
AppName=Aplikasi Penjualan MVC
Version=2.0.0
Author=Nandang Duryat (312310233)
University=Universitas Pelita Bangsa
```

### 4️⃣ Restore NuGet Packages
```bash
# Di Visual Studio: Tools > NuGet Package Manager > Restore NuGet Packages
# Atau via command line:
dotnet restore
```

### 5️⃣ Build & Run
1. Buka solution di Visual Studio
2. Build (Ctrl+Shift+B)
3. Run (F5)

### 6️⃣ Login Pertama Kali
```
Username: admin
Password: Admin@123456
```

---

## 📂 Project Structure (Clean MVC)

```
WinFormsApp_Latihan/
├── Models/                          # 📦 Data & Business Logic
│   ├── UserModel.vb                # User entity
│   ├── ConfigModel.vb              # Database configuration
│   ├── PasswordModel.vb            # Password security (PBKDF2 + AES)
│   ├── CategoryModel.vb            # Category entity & operations
│   ├── ItemModel.vb                # Item/Product entity & operations
│   ├── SaleModel.vb                # Sales transaction
│   ├── SaleDetailModel.vb          # Sales detail
│   ├── SalesReportModel.vb         # Sales reporting
│   └── Koneksi.vb                  # Database connection helper
│
├── Views/                           # 🖥️ User Interface
│   ├── Main/
│   │   ├── FormLogin.vb            # Login form
│   │   ├── FormUtama.vb            # Main form
│   │   ├── FormSetting.vb          # Settings form
│   │   └── FormPasswordDemo.vb     # Password demo
│   ├── Category/
│   │   └── FormCategoryAdd.vb      # Category management
│   ├── Items/
│   │   ├── FormItemList.vb         # Item list view
│   │   └── FormItemInput.vb        # Item input form
│   ├── Sale/
│   │   └── FormSale.vb             # Sales transaction form
│   └── Report/
│       └── Sales/
│           └── FormSalesReport.vb  # Sales report viewer
│
├── Controllers/                     # 🎮 Business Logic
│   ├── LoginController.vb          # Authentication & user management
│   ├── SettingController.vb        # Configuration management
│   ├── PasswordController.vb       # Password operations
│   ├── CategoryController.vb       # Category business logic
│   ├── ItemController.vb           # Item business logic
│   ├── SaleController.vb           # Sales business logic
│   └── SalesReportController.vb    # Reporting logic
│
├── Program.vb                       # Entry point
├── README.md                        # This file
├── setting.ini                      # Configuration file
├── docs/                            # 📚 Documentation
│   ├── Laporan_UAS_MVC.md          # Main Report
│   ├── Architecture_Visualization.md # Architecture Diagrams
│   └── ...
└── database/                        # 🗄️ Database Scripts
    ├── mysql_setup_complete.sql    # Complete setup script
    └── ...
```

### ⚠️ Note on Naming Convention:
File forms di folder **Views/** tetap menggunakan nama standard WinForms (`FormLogin.vb`, bukan `FormLoginView.vb`) karena:
- ✅ **WinForms Designer compatibility** - Designer files (.Designer.vb) tightly coupled dengan nama class
- ✅ **Avoid breaking changes** - Rename via IDE (not command line) untuk avoid Designer corruption  
- ✅ **Struktur folder sudah MVC** - Lokasi di `Views/` folder sudah jelas menunjukkan layer MVC
- ✅ **Class implementation MVC** - Forms menggunakan Controllers & Models (full MVC pattern)

**Yang penting:** Forms sudah mengikuti pattern MVC dengan menggunakan Controllers, bukan suffix nama file! 👍

---

## 🏗️ MVC Architecture

```
┌───────────────┐      ┌────────────────┐      ┌─────────────┐
│    VIEW       │─────>│  CONTROLLER    │─────>│   MODEL     │
│    (UI)       │<─────│   (Logic)      │<─────│   (Data)    │
└───────────────┘      └────────────────┘      └─────────────┘
     │                      │                     │
     │                      │                     │
User Input            Business Logic         Database
Display              Validation            Operations
```

### Implementation:
- **Views/**: Forms (UI layer) organized by feature
  - `Main/` - Core application forms
  - `Category/` - Category management
  - `Items/` - Product/Item management
  - `Sale/` - Sales transaction
  - `Report/` - Reporting features
- **Controllers/**: Business logic - independent dari UI
- **Models/**: Data structures & database operations
  - `Koneksi.vb` - Centralized database connection helper

### ✅ Full MVC Benefits:
- 🎯 **Separation of Concerns** - UI, Logic, Data terpisah
- 🧪 **Testability** - Setiap layer bisa di-test independently
- 🔧 **Maintainability** - Mudah maintain & modify
- ♻️ **Reusability** - Controllers & Models bisa digunakan kembali
- 🧹 **Clean Code** - Struktur jelas & organized
- 📂 **Feature Organization** - Views organized by feature modules

---

## ✨ Features

### 🔒 Security & Authentication
- **PBKDF2 Password Hashing** - 10,000 iterations dengan salt
- **AES Encryption/Decryption** - Untuk data sensitif
- **Password Validation** - Minimum length & complexity
- **User login system** - Database-based authentication

### 📦 Product Management (Items)
- Add, Edit, Delete products/items
- View all items in list
- Category-based organization
- Stock management

### 🏷️ Category Management
- Create new categories
- Edit existing categories
- Delete categories
- View all categories

### 💰 Sales Transaction
- Create sales transactions
- Multiple items per transaction
- Transaction details tracking
- Sales history

### 📊 Sales Reporting
- View sales reports
- Filter by date range
- Transaction summaries
- Sales analytics
- **Export to CSV**
- **Print to PDF / Printer**

### 🛒 Purchase Module (New)
- Manage Suppliers
- Purchase Transactions
- Purchase Reporting (with Export/Print)

### ⚙️ Configuration Management
- Database connection settings
- INI file management
- Connection testing
- Validation

---

## 🔌 Database Helper (Koneksi)

Class `Koneksi.vb` menyediakan centralized database connection:

```vb
' Automatic configuration loading
Using conn = Koneksi.OpenConnection()
    ' Your database operations
End Using

' Refresh configuration if settings changed
Koneksi.RefreshConfiguration()
```

**Benefits:**
- 🎯 Single source of truth untuk connection
- 🔄 Auto-load dari ConfigModel
- 🛡️ Consistent error handling
- 🛠️ Easy to maintain

---

## 🧩 Module Structure

### Main Module
- Login & Authentication
- Main Dashboard
- Configuration
- Password Demo

### Category Module
- Category List
- Add/Edit Category
- Delete Category

### Item Module
- Item List (DataGridView)
- Add/Edit Item
- Delete Item
- Category Assignment

### Sales Module
- Create Sales Transaction
- Add Items to Transaction
- Calculate Totals
- Save Transaction

### Report Module
- Sales Report
- Filter by Date
- Transaction Details
- Export Options

---

## 🛠️ Technologies

- **VB.NET** - Programming language
- **.NET 6.0** - Framework
- **Windows Forms** - UI framework
- **MySQL** - Database server
- **MySql.Data** (v9.1.0) - Database connector
- **PBKDF2** - Password hashing algorithm
- **AES** - Symmetric encryption algorithm

---

## 🗄️ Database Schema

### Core Tables
- `users` - User authentication
- `category` - Product categories
- `items` - Products/Items
- `suppliers` - Suppliers data
- `sales` - Sales transactions
- `sale_details` - Transaction line items
- `purchases` - Purchase transactions
- `purchase_details` - Purchase line items

---

## 📚 Documentation

Detailed documentation can be found in the `docs/` folder:
- [Laporan UAS (Main Report)](docs/Laporan_UAS_MVC.md)
- [Architecture Visualization](docs/Architecture_Visualization.md)
- [Purchase Module Documentation](docs/MODUL_PEMBELIAN_DOKUMENTASI.md)
- [Checklist Nilai 100](docs/CHECKLIST_NILAI_100.md)

---

## 💡 Usage Examples

### Example 1: Category Operations
```vb
' Get all categories
Dim categories = CategoryModel.getAll()

' Add new category
Dim category As New CategoryModel With {.category_desc = "Electronics"}
category.CreateCategory(category)

' Update category
category.UpdateCategory(category)

' Delete category
category.DeleteCategory(id)
```

### Example 2: Item Operations
```vb
' Get all items
Dim items = ItemModel.GetAllItems()

' Add new item
Dim item As New ItemModel With {
    .ItemName = "Laptop",
    .CategoryId = 1,
    .Price = 5000000,
    .Stock = 10
}
item.CreateItem(item)
```

### Example 3: Sales Transaction
```vb
' Create sale
Dim sale As New SaleModel With {
    .SaleDate = DateTime.Now,
    .TotalAmount = 5000000
}
sale.CreateSale(sale)

' Add sale details
Dim detail As New SaleDetailModel With {
    .SaleId = sale.Id,
    .ItemId = 1,
    .Quantity = 2,
    .UnitPrice = 2500000
}
```

---

## 📝 Notes

### ✅ Completed:
- Full MVC structure implemented
- All forms refactored to use Controllers
- Clean & organized codebase
- Build successful
- Proper folder structure (Views/, Controllers/, Models/)
- Feature-based Views organization
- Centralized database connection (Koneksi.vb)
- Complete CRUD operations for Category, Items, Sales
- Sales reporting functionality

### 🌟 Benefits:
- **Clean Architecture** - Clear separation of concerns
- **Easy to Test** - Each layer can be tested independently
- **Maintainable** - Easy to find & fix bugs
- **Scalable** - Easy to add new features
- **Professional** - Industry-standard architecture
- **Feature Modules** - Organized by business functionality

### 🔧 Fixed Issues:
- ✅ Koneksi class created untuk database connections
- ✅ All Models updated to use Koneksi.OpenConnection()
- ✅ References fixed from copied files
- ✅ Namespace conflicts resolved
- ✅ Build successful without errors

---

## 📜 License

MIT License

## 👨‍💻 Author

**Nandang Duryat**  
NIM: 312310233  
Kelas: TI.23.B.1  
Jurusan: Teknik Informatika  
Universitas Pelita Bangsa

---

**© 2025 Nandang Duryat** | Tugas UAS Pemrograman Visual
