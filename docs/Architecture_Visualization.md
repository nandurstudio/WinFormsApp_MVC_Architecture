# Visualisasi Arsitektur Aplikasi (MVC)

Dokumen ini memvisualisasikan struktur dan alur kerja aplikasi penjualan berbasis Desktop (VB.NET) yang telah dibangun. Visualisasi ini menggunakan diagram untuk menjelaskan bagaimana komponen Model, View, dan Controller saling berinteraksi.

---

## 1. Konsep Dasar MVC (Model-View-Controller)

Diagram ini menggambarkan aliran data umum dalam aplikasi ini.

```mermaid
graph LR
    User((User)) -->|Interaksi| View[View / UI Forms]
    View -->|Event / Input| Controller[Controller Logic]
    Controller -->|CRUD Operations| Model[Model Data]
    Model <-->|Query / Result| DB[(MySQL Database)]
    Controller -->|Update UI| View
```

*   **View**: Menangani tampilan (Form) dan input user.
*   **Controller**: Menangani logika bisnis, validasi, dan komunikasi database.
*   **Model**: Merepresentasikan struktur data (Object).

---

## 2. Struktur Folder Proyek

Visualisasi struktur file dalam Solution Explorer yang mencerminkan pemisahan concern (tanggung jawab).

```
WinFormsApp_Latihan/
├── 🎮 Controllers/          (Otak Aplikasi)
│   ├── LoginController.vb
│   ├── ItemController.vb
│   ├── SaleController.vb
│   ├── PurchaseController.vb
│   ├── SupplierController.vb
│   ├── UserController.vb
│   └── ...
│
├── 📦 Models/               (Struktur Data)
│   ├── UserModel.vb
│   ├── ItemModel.vb
│   ├── SaleModel.vb
│   ├── PurchaseModel.vb
│   ├── SupplierModel.vb
│   ├── ConfigModel.vb
│   └── ...
│
├── 🖥️ Views/                (Tampilan / GUI)
│   ├── 📂 Main/             (Form Utama, Login, Setting)
│   ├── 📂 Items/            (Master Barang)
│   ├── 📂 Category/         (Master Kategori)
│   ├── 📂 Supplier/         (Master Supplier)
│   ├── 📂 User/             (Kelola User)
│   ├── 📂 Sale/             (Transaksi Penjualan)
│   ├── 📂 Purchase/         (Transaksi Pembelian)
│   ├── 📂 Report/           (Laporan)
│   └── ...
│
└── 🛠️ Helpers/              (Fungsi Pendukung)
    ├── PrintHelper.vb
    └── CustomMessageDialog.vb
```

---

## 3. Diagram Alur Modul (Sequence Diagrams)

Berikut adalah visualisasi detail bagaimana kode bekerja di belakang layar untuk fitur-fitur utama.

### A. Alur Login (Authentication)

```mermaid
sequenceDiagram
    participant User
    participant View as FormLogin
    participant Ctrl as LoginController
    participant Model as UserModel
    participant DB as Database

    User->>View: Input Username & Password
    User->>View: Klik Login
    View->>Ctrl: AuthenticateUser(user, pass)
    Ctrl->>DB: SELECT password FROM users...
    DB-->>Ctrl: Return Hashed Password
    Ctrl->>Ctrl: Verify Password (Hash Check)
    
    alt Password Valid
        Ctrl->>DB: GetUserByUsername(user)
        DB-->>Ctrl: Return User Data
        Ctrl-->>View: Return True
        View->>Model: Set LoggedInUser
        View->>User: Show FormUtama
    else Password Invalid
        Ctrl-->>View: Return False
        View->>User: Show Error Message
    end
```

### B. Alur Transaksi Penjualan (Sales Transaction)

```mermaid
sequenceDiagram
    participant Kasir
    participant Form as FormSale
    participant SaleCtrl as SaleController
    participant ItemCtrl as ItemController
    participant DB as Database

    Kasir->>Form: Tekan F1 (Transaksi Baru)
    Form->>SaleCtrl: GenerateCode()
    SaleCtrl-->>Form: Return "TRX-2025..."
    
    loop Input Barang
        Kasir->>Form: Input Kode Barang
        Form->>ItemCtrl: GetItemById(kode)
        ItemCtrl->>DB: Query Item
        DB-->>ItemCtrl: Result
        ItemCtrl-->>Form: Return ItemModel
        Form->>Form: Hitung Subtotal & Update Grid
    end

    Kasir->>Form: Klik Simpan (F3)
    Form->>SaleCtrl: SaveNew(SaleModel)
    
    rect rgb(240, 248, 255)
        note right of SaleCtrl: Transaction Block
        SaleCtrl->>DB: INSERT INTO sales (Header)
        SaleCtrl->>DB: INSERT INTO sales_detail (Items)
        SaleCtrl->>DB: UPDATE items SET stock = stock - qty
    end
    
    DB-->>SaleCtrl: Success
    SaleCtrl-->>Form: Return True
    Form->>Kasir: Tampilkan Pesan Sukses & Reset Form
```

### C. Alur Master Data (CRUD Barang)

```mermaid
graph TD
    Start((Start)) --> List[Buka FormItemList]
    List --> Load[ItemController.LoadItems]
    Load --> DB[(Database)]
    DB --> Grid[Tampil Data di Grid]
    
    Grid --> Choice{"User Action?"}
    
    Choice -->|Tambah| Add["Buka FormItemInput (Mode Baru)"]
    Choice -->|Edit| Edit["Buka FormItemInput (Mode Edit)"]
    Choice -->|Hapus| Del[Konfirmasi Hapus]
    
    Add --> Save[ItemController.Create]
    Edit --> Update[ItemController.Update]
    Del --> Delete[ItemController.Delete]
    
    Save --> DB
    Update --> DB
    Delete --> DB
    
    DB --> Refresh[Refresh Grid]
    Refresh --> Grid
```

### D. Alur Transaksi Pembelian (Purchase Transaction)

```mermaid
sequenceDiagram
    participant Staff
    participant Form as FormPurchase
    participant PurchCtrl as PurchaseController
    participant SuppCtrl as SupplierController
    participant DB as Database

    Staff->>Form: Buka Form Pembelian
    Form->>SuppCtrl: LoadSuppliers()
    SuppCtrl-->>Form: List Supplier
    Staff->>Form: Pilih Supplier
    
    loop Input Barang
        Staff->>Form: Input Kode Barang
        Form->>DB: Get Item Info
        DB-->>Form: Item Details
        Staff->>Form: Input Qty & Harga Beli
        Form->>Form: Hitung Subtotal
    end

    Staff->>Form: Klik Simpan (F3)
    Form->>PurchCtrl: CreatePurchase(PurchaseModel)
    
    rect rgb(255, 240, 240)
        note right of PurchCtrl: Transaction Block
        PurchCtrl->>DB: INSERT INTO purchase
        PurchCtrl->>DB: INSERT INTO purchasedetail
        PurchCtrl->>DB: UPDATE items SET stock = stock + qty
    end
    
    DB-->>PurchCtrl: Success
    PurchCtrl-->>Form: Return True
    Form->>Staff: Tampilkan Pesan Sukses
```

---

## 4. Skema Database (Entity Relationship)

Visualisasi relasi antar tabel yang digunakan dalam aplikasi (berdasarkan analisis Model).

```mermaid
erDiagram
    USERS {
        int user_id PK
        string username
        string password
        string role
    }

    CATEGORIES {
        int id PK
        string categoryDesc
    }

    ITEMS {
        int id PK
        string itemID "Kode Barang"
        string itemDesc
        decimal salesPrice
        int stock
        int itemCate FK
    }

    SUPPLIERS {
        int id PK
        string supplierName
        string contact
    }

    SALES {
        string idTrans PK "No Faktur"
        datetime saleDate
        decimal totalSale
    }

    SALES_DETAIL {
        int id PK
        string idTrans FK
        int productId FK
        int qty
        decimal price
        decimal subtotal
    }

    PURCHASE {
        string idPurchase PK "No Nota"
        datetime purchaseDate
        int supplierId FK
        decimal totalAmount
        string status
        int created_by FK
    }

    PURCHASE_DETAIL {
        int id PK
        string idPurchase FK
        string itemID FK
        int qty
        decimal price
        decimal subtotal
    }

    CATEGORIES ||--|{ ITEMS : "has"
    ITEMS ||--|{ SALES_DETAIL : "sold in"
    SALES ||--|{ SALES_DETAIL : "contains"
    
    SUPPLIERS ||--|{ PURCHASE : "supplies"
    PURCHASE ||--|{ PURCHASE_DETAIL : "contains"
    ITEMS ||--|{ PURCHASE_DETAIL : "purchased in"
    USERS ||--|{ PURCHASE : "creates"
```

---

## 5. Kesimpulan Arsitektur

Aplikasi ini menggunakan **Layered Architecture** yang ketat:

1.  **Presentation Layer (Views)**: Tidak boleh ada query SQL di sini. Hanya logika tampilan.
2.  **Business Logic Layer (Controllers)**: Pusat logika. Mengatur transaksi dan validasi data.
3.  **Data Access Layer (Integrated in Controllers/Models)**: Menggunakan ADO.NET (MySqlClient) untuk akses data langsung.
4.  **Cross-Cutting Concerns**: Helper classes untuk fungsi umum seperti pencetakan dan pesan dialog.

---

## 6. Alur Kerja Aplikasi (Application Flow)

Visualisasi alur kerja sistem yang mengedepankan keamanan dan kenyamanan pengguna, mulai dari inisialisasi hingga manajemen transaksi atomik.

```mermaid
graph TD
    %% Node Definitions
    Start((Start))
    Config["Inisialisasi Konfigurasi<br/>(Silent Loading)"]
    Login{"Form Login"}
    Auth["LoginController<br/>Verify PBKDF2 Hash"]
    RoleCheck{"Cek Role?"}
    
    MainForm["Form Utama<br/>(MDI Parent Container)"]
    
    subgraph Nav ["Navigasi MDI & Hak Akses"]
        AdminMenu["Menu Admin<br/>(Full Access)"]
        UserMenu["Menu User<br/>(Limited Access)"]
    end
    
    subgraph Trans ["Manajemen Transaksi (Atomic)"]
        TransForm["Form Transaksi<br/>(MDI Child)"]
        SaveBtn["Simpan (F3)"]
        DB_Trans["Database Transaction<br/>Begin - Commit/Rollback"]
        DB[("MySQL Database")]
    end

    %% Flow Connections
    Start --> Config
    Config --> Login
    Login -->|Input Creds| Auth
    Auth -->|Valid| RoleCheck
    Auth -->|Invalid| Login
    
    RoleCheck -->|Admin| AdminMenu
    RoleCheck -->|User| UserMenu
    
    AdminMenu --> MainForm
    UserMenu --> MainForm
    
    MainForm -->|Open Child| TransForm
    TransForm --> SaveBtn
    SaveBtn --> DB_Trans
    DB_Trans -->|Atomic Write| DB
    
    %% Styling
    style Start fill:#f9f,stroke:#333,stroke-width:2px
    style DB_Trans fill:#ff9,stroke:#f66,stroke-width:2px,stroke-dasharray: 5 5
    style DB fill:#bbf,stroke:#333,stroke-width:2px
```

---

## 7. Metrik Pengembangan & Pengujian

Visualisasi statistik pengembangan dan cakupan pengujian untuk memvalidasi keberhasilan sistem.

### A. Distribusi Komponen Kode

```mermaid
pie title Komponen MVC & Database
    "Views (UI)" : 22
    "Controllers" : 11
    "Models" : 10
    "Database" : 15
    "Helpers" : 5
```

### B. Checklist Validasi Sistem

```mermaid
mindmap
  root((Pengujian<br/>Sistem))
    Keamanan
      (PBKDF2 Hashing)
      (Role Based Access)
      (SQL Injection Prevent)
      (Hidden Settings)
    Fungsionalitas Utama
      [Login Module]
      [Master Data Items]
      [Master Supplier]
      [Kelola User]
    Transaksi
      (Penjualan - Multi Item)
      (Pembelian - Stok Update)
      (Atomic Save)
    Laporan
      [Laporan Penjualan]
      [Laporan Pembelian]
      [Export PDF/CSV]
