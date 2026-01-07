# TUGAS UJIAN AKHIR SEMESTER (UAS)
## Desktop Application Development using MVC Architecture
### (Studi Kasus Aplikasi Penjualan)

**Mata Kuliah**: Pemrograman Visual (Desktop)  
**Program Studi**: Teknik Informatika  
**Tahun Akademik**: 2025 / 2026  

---

## 1. Pendahuluan

Dokumen ini berisi dokumentasi teknis mengenai pengembangan aplikasi penjualan berbasis desktop menggunakan bahasa pemrograman Visual Basic .NET (VB.NET) dengan arsitektur Model-View-Controller (MVC). Aplikasi ini dirancang untuk mengelola data master (barang, kategori, supplier, user), transaksi (penjualan, pembelian), serta pelaporan.

Penerapan arsitektur MVC bertujuan untuk memisahkan logika bisnis (Controller), antarmuka pengguna (View), dan struktur data (Model) agar aplikasi lebih mudah dikelola, diuji, dan dikembangkan.

---

## 2. Arsitektur Aplikasi (MVC)

Aplikasi ini menerapkan pola desain MVC sebagai berikut:

*   **Model**: Merepresentasikan struktur data dan logika bisnis dasar. Contoh: `ItemModel`, `UserModel`, `SaleModel`. Model tidak memiliki ketergantungan langsung pada antarmuka pengguna.
*   **View**: Bertanggung jawab untuk menampilkan data kepada pengguna dan menangkap interaksi pengguna. Semua form dalam folder `Views` adalah bagian dari layer ini. View hanya berkomunikasi dengan Controller, tidak langsung ke database.
*   **Controller**: Bertindak sebagai perantara antara View dan Model. Controller menerima input dari View, memprosesnya (misalnya validasi atau logika bisnis), mengakses database, dan mengembalikan hasil ke View.

---

## 3. Analisis Form dan Implementasi MVC

Berikut adalah penjelasan detail mengenai setiap form yang ada dalam aplikasi beserta peran komponen MVC-nya.

### 3.1. Form Login (`FormLogin`)

**Fungsi**:
Form ini berfungsi sebagai gerbang keamanan aplikasi. Pengguna harus memasukkan username dan password yang valid untuk mengakses menu utama.

**Implementasi MVC**:
*   **View**: `Views\Main\FormLogin.vb` menangani input user dan validasi visual (misal: field kosong).
*   **Controller**: `Controllers\LoginController.vb` menangani logika autentikasi.
    *   Method `AuthenticateUser(username, password)` memverifikasi kredensial ke database.
    *   Method `GetUserByUsername(username)` mengambil data lengkap user termasuk role (hak akses).
*   **Model**: `UserModel` digunakan untuk menyimpan sesi pengguna yang berhasil login. `PasswordModel` digunakan untuk hashing dan verifikasi password.

---

### 3.2. Form Utama (`FormUtama`)

**Fungsi**:
Merupakan dashboard utama aplikasi yang menyediakan navigasi ke seluruh modul aplikasi melalui menu bar (File, Master Data, Transaksi, Laporan, Bantuan).

**Implementasi MVC**:
*   **View**: `Views\Main\FormUtama.vb` mengatur visibilitas menu berdasarkan role pengguna yang login (Admin vs User biasa).
*   **Controller**: Tidak memiliki controller khusus logika bisnis yang berat, namun berinteraksi dengan `LoginController` untuk manajemen sesi logout.
*   **Model**: Menggunakan `UserModel` untuk menampilkan informasi pengguna yang sedang aktif di status bar.

---

### 3.3. Modul Master Data Barang

#### A. Form Daftar Barang (`FormItemList`)
**Fungsi**: Menampilkan daftar seluruh barang yang tersedia, dengan fitur pencarian dan tombol untuk Tambah, Edit, dan Hapus.
**MVC**:
*   **View**: Menggunakan `DataGridView` untuk menampilkan data. Event `Load` memanggil controller.
*   **Controller**: `ItemController.LoadItems()` mengambil `DataTable` atau `List(Of ItemModel)` dari database.
*   **Model**: `ItemModel` merepresentasikan satu baris data barang (ID, Nama, Harga, Stok, Satuan).

#### B. Form Input Barang (`FormItemInput`)
**Fungsi**: Form dialog untuk menambah barang baru atau mengedit barang yang sudah ada.
**MVC**:
*   **View**: Form ini memiliki dua mode (Create dan Update). Jika mode Update, form akan terisi data lama.
*   **Controller**:
    *   `ItemController.Create(item)`: Menyimpan data baru.
    *   `ItemController.Update(item)`: Memperbarui data yang ada.
    *   `CategoryController.LoadCategory()`: Digunakan untuk mengisi ComboBox kategori.
*   **Model**: Objek `ItemModel` dikirim dari View ke Controller untuk disimpan.

---

### 3.4. Modul Master Data Kategori

#### A. Form Daftar Kategori (`FormCategoryList`)
**Fungsi**: Manajemen data kategori barang.
**MVC**:
*   **View**: Menampilkan list kategori.
*   **Controller**: `CategoryController` menangani operasi CRUD (Create, Read, Update, Delete) untuk tabel kategori.
*   **Model**: `CategoryModel` (Id, Deskripsi Kategori).

#### B. Form Input Kategori (`FormCategoryInput`)
**Fungsi**: Input/Edit nama kategori.
**MVC**:
*   **Controller**: `CategoryController.Create()` atau `Update()` dipanggil saat tombol Simpan ditekan.

---

### 3.5. Modul Master Data Supplier

#### A. Form Daftar Supplier (`FormSupplierList`)
**Fungsi**: Manajemen data pemasok barang.
**MVC**:
*   **View**: Menampilkan tabel supplier (Kode, Nama, Alamat, Telp).
*   **Controller**: `SupplierController` mengelola akses data ke tabel supplier.
*   **Model**: `SupplierModel`.

#### B. Form Input Supplier (`FormSupplierInput`)
**Fungsi**: Form isian detail supplier.
**MVC**:
*   **Controller**: `SupplierController` memvalidasi dan menyimpan data supplier ke database.

---

### 3.6. Modul Master Data User

#### A. Form Daftar User (`FormUserList`)
**Fungsi**: Manajemen pengguna aplikasi (hanya dapat diakses oleh Admin).
**MVC**:
*   **View**: Menampilkan list user dan role-nya.
*   **Controller**: `UserController` menangani CRUD user.
*   **Model**: `UserModel`.

#### B. Form Input User (`FormUserInput`)
**Fungsi**: Menambah user baru atau mereset password user.
**MVC**:
*   **Controller**: `UserController` bekerja sama dengan `PasswordModel` untuk melakukan hashing password sebelum disimpan ke database demi keamanan.

---

### 3.7. Modul Transaksi Penjualan (`FormSale`)

**Fungsi**:
Form kasir untuk memproses transaksi penjualan kepada pelanggan. Mendukung input banyak item dalam satu transaksi (Master-Detail).

**Implementasi MVC**:
*   **View**: `Views\Sale\FormSale.vb`.
    *   Menggunakan `DataGridView` interaktif untuk input item belanjaan.
    *   Menghitung Subtotal dan Total secara *real-time* di UI.
    *   Menangani shortcut keyboard (F1: Baru, F2: Batal, F3: Bayar).
*   **Controller**: `SaleController`.
    *   `GenerateCode()`: Membuat nomor faktur otomatis.
    *   `SaveNew(saleModel)`: Menyimpan data transaksi secara atomik (Header penjualan dan Detail item disimpan sekaligus).
    *   `ItemController.GetItemById()`: Digunakan saat kasir memasukkan kode barang untuk mengambil nama dan harga.
*   **Model**:
    *   `SaleModel`: Header transaksi (No Faktur, Tanggal, Total).
    *   `SaleDetailModel`: Detail item (Kode Barang, Qty, Harga, Subtotal).

---

### 3.8. Modul Transaksi Pembelian (`FormPurchase`)

**Fungsi**:
Mencatat pembelian stok barang dari supplier untuk menambah persediaan.

**Implementasi MVC**:
*   **View**: `Views\Purchase\FormPurchase.vb`. Mirip dengan form penjualan namun memiliki pemilihan Supplier.
*   **Controller**: `PurchaseController`.
    *   Menangani penyimpanan transaksi pembelian.
    *   Secara otomatis menambah stok barang (`ItemController` atau logic di database) saat transaksi disimpan.
*   **Model**: `PurchaseModel` dan `PurchaseDetailModel`.

---

### 3.9. Modul Laporan

#### A. Laporan Penjualan (`FormSalesReport`)
**Fungsi**: Menampilkan rekapitulasi penjualan berdasarkan periode tanggal.
**MVC**:
*   **View**: Filter tanggal (Dari - Sampai) dan tombol "Tampilkan".
*   **Controller**: `SalesReportController.GetReport(startDate, endDate)` menjalankan query agregasi untuk mendapatkan data penjualan.
*   **Model**: `SalesReportModel`.
*   **Fitur Tambahan**:
    *   **Export to CSV**: Mengekspor data laporan ke format CSV untuk diolah lebih lanjut di Excel.
    *   **Print / Export to PDF**: Mencetak laporan langsung ke printer atau menyimpannya sebagai file PDF menggunakan `PrintHelper`.

#### B. Laporan Pembelian (`FormPurchaseReport`)
**Fungsi**: Menampilkan riwayat pembelian dari supplier.
**MVC**:
*   **Controller**: `PurchaseReportController` mengambil data historis pembelian.
*   **Fitur Tambahan**:
    *   **Export to CSV**: Mengekspor data laporan pembelian ke format CSV.
    *   **Print / Export to PDF**: Mencetak laporan pembelian atau menyimpannya sebagai PDF.

---

### 3.10. Form Pengaturan & Utilitas

#### A. Form Pengaturan Database (`FormSetting`)
**Fungsi**: Mengkonfigurasi koneksi database (Server, Database, User, Password) saat pertama kali aplikasi dijalankan.
**MVC**:
*   **Controller**: `SettingController` membaca dan menulis file konfigurasi (`setting.ini` atau Registry).
*   **Model**: `ConfigModel` menyimpan properti konfigurasi koneksi.

#### B. Form Tentang (`FormAbout`)
**Fungsi**: Menampilkan informasi pembuat aplikasi dan versi aplikasi.
**MVC**: Form statis sederhana, namun tetap merupakan bagian dari View layer.

---

## 4. Kesimpulan

Aplikasi Penjualan ini telah berhasil mengimplementasikan arsitektur MVC secara konsisten. Pemisahan tanggung jawab antara View (Form), Controller (Logika), dan Model (Data) membuat kode program lebih terstruktur, mudah dibaca, dan memudahkan pemeliharaan di masa depan.
