# Naskah Video Presentasi YouTube (Durasi ± 5 Menit)
## Judul: Desktop Application Development using MVC Architecture (Studi Kasus Aplikasi Penjualan & Pembelian)

**Target Durasi**: 5-6 Menit  
**Format**: Screencast dengan Voice Over  
**GitHub Repository**: https://github.com/nandurstudio/WinFormsApp_MVC_Architecture  
**Release**: v1.0.0

---

### 0:00 - 0:45 | Pembukaan & Pendahuluan

| Visual (Layar) | Narasi (Voice Over) | Screenshot Wajib |
| :--- | :--- | :--- |
| **Slide Judul**: Judul Tugas, Nama: Nandang Duryat (312310233), Kelas: TI.23.B.1, Mata Kuliah: TIF503 - Pemrograman Visual (Desktop), Dosen: Asep Muhidin, S.Kom., M.Kom., Universitas Pelita Bangsa. | "Assalamualaikum Wr. Wb. Halo semuanya. Perkenalkan nama saya Nandang Duryat, NIM 312310233, mahasiswa Teknik Informatika kelas TI.23.B.1, Universitas Pelita Bangsa." | - |
| **Slide Arsitektur**: Diagram blok MVC dari docs/Architecture_Visualization.md (Konsep Dasar MVC). | "Pada video kali ini, saya akan mempresentasikan tugas Ujian Akhir Semester mata kuliah Pemrograman Visual dengan Dosen Pengampu Bapak Asep Muhidin. Tugas ini adalah membangun Aplikasi Penjualan dan Pembelian Desktop menggunakan bahasa VB.NET dengan penerapan arsitektur Clean MVC atau Model-View-Controller." | Diagram MVC (Mermaid) |
| **GitHub Repository**: Tampilkan halaman repository di browser (https://github.com/nandurstudio/WinFormsApp_MVC_Architecture). | "Sebelum masuk ke demo aplikasi, perlu saya sampaikan bahwa source code lengkap proyek ini sudah saya publish secara open source di GitHub dengan lisensi MIT. Kalian bisa mengakses, mempelajari, bahkan mengembangkannya lebih lanjut." | GitHub Repo Homepage |
| **Folder Structure**: Tampilkan Solution Explorer di Visual Studio (Controllers/, Models/, Views/). | "Penerapan MVC ini bertujuan memisahkan logika bisnis, tampilan, dan data agar aplikasi lebih rapi, mudah di-maintain, dan mudah dikembangkan. Bisa dilihat di sini, struktur project saya sudah terpisah ketat menjadi folder Models untuk data, Views untuk tampilan yang diorganisir per fitur, dan Controllers untuk logika bisnis." | Solution Explorer (Folder Tree) |

---

### 0:45 - 1:30 | Login & Keamanan (Authentication)

| Visual (Layar) | Narasi (Voice Over) | Screenshot Wajib |
| :--- | :--- | :--- |
| **Form Login**: Tampilan awal aplikasi saat dijalankan. | "Kita mulai dari gerbang utama, yaitu Form Login. Di sini user harus memasukkan username dan password untuk autentikasi." | Form Login (Kosong) |
| **Aksi Error**: Ketik username/password salah, klik Login, tampil error. | "Dari sisi keamanan, password di-hash menggunakan algoritma PBKDF2 dengan 10 ribu iterasi. Jadi password tidak disimpan plain text di database. Saat saya coba login dengan password salah..." | Pop-up Pesan Error |
| **Aksi Sukses**: Login dengan kredensial benar (admin/Admin@123456). | "...sistem menolak akses. Sekarang dengan kredensial yang benar. Secara teknis, View hanya menerima input, validasi user dilakukan oleh LoginController yang mencocokkan hash password dengan database, lalu menyimpan sesi user menggunakan UserModel." | Pop-up Sukses / Loading |
| **Form Utama**: Setelah login berhasil, tampil dashboard. | "Setelah autentikasi berhasil, aplikasi membuka Form Utama." | Transisi ke Form Utama |

---

### 1:30 - 2:45 | Dashboard & Master Data Management

| Visual (Layar) | Narasi (Voice Over) | Screenshot Wajib |
| :--- | :--- | :--- |
| **Form Utama**: Tampilan dashboard dengan menu bar dan status bar. | "Di Form Utama ini, kita bisa lihat menu bar yang menyesuaikan dengan role user. Admin mendapat akses penuh, sementara User biasa hanya bisa transaksi dan laporan. Di status bar bawah terlihat informasi user yang sedang login beserta waktu login." | Form Utama (Full Screen) |
| **Menu Master**: Hover ke menu Master Data, tampilkan dropdown (Kategori, Barang, Supplier, Kelola User). | "Masuk ke modul Master Data. Ada 4 menu utama: Kategori Barang, Data Barang, Data Supplier, dan Kelola User." | Menu Dropdown Master |
| **Form Item List**: Klik Master -> Barang. Tampilkan grid data barang. | "Ini adalah Form Daftar Barang. Data yang tampil di Grid ini diambil oleh ItemController dari database menggunakan pattern MVC. Kita bisa search barang dengan cepat menggunakan fitur pencarian." | Form Daftar Barang (dengan data) |
| **Fitur Search**: Ketik di kolom search, grid auto-filter. | "Perhatikan, saat saya ketik di kolom pencarian, grid langsung filter data secara real-time." | Grid ter-filter |
| **Form Item Input**: Klik tombol 'Tambah' atau double-click salah satu baris untuk Edit. | "Saat menambah atau mengedit barang, kita menggunakan Form Input Barang. Kode barang otomatis di-generate menggunakan Stored Procedure di database dengan format B0001, B0002, dan seterusnya. Form ini berkomunikasi dengan ItemController untuk validasi sebelum data disimpan permanen." | Form Input Barang (mode Add/Edit) |
| **Supplier**: (Opsional) Klik menu Supplier untuk tunjukkan modul supplier juga lengkap. | "Sama halnya dengan modul Supplier. Kode supplier juga auto-generate dengan format SUP0001, SUP0002, dan validasi dilakukan di Controller layer." | Form Supplier (glimpse) |

---

### 2:45 - 4:00 | Transaksi Penjualan & Pembelian (Core Features)

| Visual (Layar) | Narasi (Voice Over) | Screenshot Wajib |
| :--- | :--- | :--- |
| **Menu Transaksi**: Buka menu Transaksi -> Penjualan. | "Sekarang kita masuk ke fitur inti aplikasi ini, yaitu modul Transaksi. Pertama, Transaksi Penjualan." | - |
| **Form Sale**: Form Penjualan kosong. | "Form ini dirancang interaktif untuk kasir dengan keyboard shortcuts. F1 untuk transaksi baru, F2 untuk clear, F3 untuk simpan." | Form Transaksi Kosong |
| **Aksi Transaksi**: Tekan F1, muncul no transaksi otomatis (TRX0001). | "Saat tekan F1, no transaksi otomatis di-generate dari Stored Procedure. Sekarang saya input kode barang..." | No Transaksi muncul |
| **Input Barang**: Ketik kode barang di kolom, tekan Enter. Data barang muncul otomatis. | "...Controller otomatis fetch data barang dari Model. Nama barang, harga, dan stok tersedia langsung muncul." | Baris barang ter-isi otomatis |
| **Kalkulasi**: Ubah Qty, tunjuk Subtotal dan Grand Total yang berubah real-time. | "Perhitungan subtotal dan grand total dilakukan secara real-time di layer View, memberikan feedback instan kepada user." | Grid Detail + Total |
| **Simpan Transaksi**: Klik Simpan / Tekan F3. | "Saat transaksi disimpan, SaleController melakukan 3 operasi database sekaligus dalam satu blok transaksi: INSERT header penjualan, INSERT detail barang, dan UPDATE stok barang. Jika salah satu gagal, semua di-rollback untuk menjaga konsistensi data. Ini yang disebut Atomic Transaction." | Pesan "Transaksi Berhasil" |
| **Form Purchase**: (Bonus) Buka menu Transaksi -> Pembelian. | "Untuk transaksi pembelian, prosesnya mirip tapi dengan logic terbalik. Stok barang bertambah, bukan berkurang. Dan ada fitur pilih supplier." | Form Pembelian (glimpse) |

---

### 4:00 - 5:00 | Reporting & Export

| Visual (Layar) | Narasi (Voice Over) | Screenshot Wajib |
| :--- | :--- | :--- |
| **Menu Laporan**: Buka menu Laporan -> Laporan Penjualan. | "Terakhir, untuk kebutuhan manajemen dan monitoring bisnis, tersedia fitur Laporan yang komprehensif." | - |
| **Filter Laporan**: Pilih rentang tanggal (dari - sampai), klik Tampilkan. | "Di Laporan Penjualan ini, owner atau manager bisa filter data berdasarkan periode tanggal. Data yang tampil adalah hasil rekapitulasi yang diolah oleh SalesReportController menggunakan Database View untuk optimasi performa." | Form Laporan Penjualan (Filter Panel) |
| **Hasil Laporan**: Grid menampilkan data transaksi sesuai filter. | "Data laporan mencakup no transaksi, tanggal, total penjualan, dan detail item yang terjual. Semua data sudah ter-agregat dari multiple tables." | Grid Laporan (Ada data) |
| **Fitur Export**: Tunjuk tombol Export to CSV/Excel dan Print. | "Yang menarik, laporan ini bisa diekspor ke format CSV untuk analisis lanjutan di Excel, atau langsung dicetak ke printer untuk arsip fisik. Fitur export ini menggunakan helper class PrintHelper yang saya buat sendiri." | Highlight tombol Export/Print |
| **Demo Export**: (Opsional) Klik Export, tunjuk file hasil export di folder. | "Saat klik Export, file CSV langsung tersimpan di folder yang kita tentukan dan bisa langsung dibuka di Excel." | File Explorer + Excel preview |

---

### 5:00 - 5:45 | Technical Highlights & GitHub

| Visual (Layar) | Narasi (Voice Over) | Screenshot Wajib |
| :--- | :--- | :--- |
| **Database Diagram**: Tampilkan ER Diagram dari docs/Architecture_Visualization.md. | "Dari sisi database, aplikasi ini menggunakan MySQL dengan 8 tabel utama yang saling berelasi. Terdapat 6 Database Views untuk optimasi query laporan, 4 Stored Procedures untuk auto-generate kode, dan 6 Triggers untuk kalkulasi otomatis seperti total amount." | ER Diagram (Mermaid) |
| **GitHub Releases**: Buka halaman Release v1.0.0 di browser. | "Untuk mempermudah deployment, saya sudah menyiapkan Release Package versi 1.0.0 yang bisa langsung di-download dari GitHub Releases. Package ini berisi executable, database script, dokumentasi lengkap, dan panduan instalasi." | GitHub Release Page |
| **GitHub Stars/Fork**: Tunjuk tombol Star dan Fork. | "Jika kalian tertarik mempelajari atau mengembangkan aplikasi ini lebih lanjut, silakan star dan fork repository-nya. Semua source code dan dokumentasi arsitektur sudah saya lengkapi." | - |

---

### 5:45 - 6:00 | Penutup

| Visual (Layar) | Narasi (Voice Over) | Screenshot Wajib |
| :--- | :--- | :--- |
| **Slide Penutup**: Tampilkan informasi akademik + QR Code GitHub repo (opsional). | "Demikian demonstrasi Aplikasi Penjualan dan Pembelian Desktop berbasis Clean MVC Architecture ini. Aplikasi ini dibangun menggunakan Visual Basic .NET dengan framework .NET 6.0 dan database MySQL 8.0." | Slide Akademik |
| **Wajah/Slide Terima Kasih**: | "Penerapan MVC membuat kode program lebih terstruktur, testable, maintainable, dan scalable untuk pengembangan jangka panjang. Terima kasih kepada Bapak Asep Muhidin sebagai Dosen Pengampu, dan terima kasih atas perhatian teman-teman sekalian. Wassalamualaikum Wr. Wb." | - |

---

## Checklist Screenshot untuk Laporan Tertulis & Video:

Pastikan Anda mengambil screenshot/screencast berikut untuk dokumentasi:

### 🎯 **Mandatory Screenshots (Wajib)**:
1. ✅ **Slide Judul** - Informasi lengkap (Nama, NIM, Kelas, Dosen, Mata Kuliah)
2. ✅ **GitHub Repository Homepage** - Menunjukkan project sudah open source
3. ✅ **Solution Explorer** - Struktur folder (Controllers, Models, Views)
4. ✅ **Diagram MVC** - Dari docs/Architecture_Visualization.md
5. ✅ **Form Login** - Tampilan awal
6. ✅ **Form Utama (Dashboard)** - Setelah login berhasil
7. ✅ **Form Daftar Barang** - Grid dengan data
8. ✅ **Form Input Barang** - Mode Add/Edit
9. ✅ **Form Transaksi Penjualan** - Terisi beberapa item + total
10. ✅ **Pesan Sukses Transaksi** - Konfirmasi save
11. ✅ **Form Laporan Penjualan** - Hasil filter tanggal
12. ✅ **ER Diagram Database** - Relasi antar tabel
13. ✅ **GitHub Releases Page** - Release v1.0.0

### 🌟 **Bonus Screenshots (Optional)**:
14. Form Supplier (Master Data Supplier)
15. Form Transaksi Pembelian
16. Form Laporan Pembelian
17. File Export CSV di Excel
18. Database Views/Triggers/Stored Procedures di MySQL Workbench

---

## 📝 Catatan Teknis untuk Recording:

### Persiapan Sebelum Recording:
1. ✅ **Clear desktop** - Tutup aplikasi lain yang tidak perlu
2. ✅ **Set resolusi** - 1920x1080 (Full HD) untuk kualitas optimal
3. ✅ **Prepare data** - Database sudah terisi sample data yang cukup
4. ✅ **Test audio** - Mic check untuk voice over yang jelas
5. ✅ **Browser tabs** - Siapkan tab GitHub repository dan Releases
6. ✅ **Script lengkap** - Print atau tampilkan di monitor kedua

### Software yang Dibutuhkan:
- **Screen Recorder**: OBS Studio / Camtasia / ShareX
- **Audio**: Mic dengan noise cancellation (Krisp.ai jika perlu)
- **Video Editor**: DaVinci Resolve / Adobe Premiere (untuk polish)

### Tips Recording:
- 🎬 **Take your time** - Lebih baik slow tapi jelas daripada terburu-buru
- 🎤 **Speak clearly** - Intonasi jelas, hindari "eee..." atau "hmm..."
- 🖱️ **Mouse movement** - Smooth dan purposeful, highlight area penting
- ⏸️ **Pause antar section** - Mudahkan editing nanti
- 🔄 **Re-take jika perlu** - Jangan ragu ulangi bagian yang kurang bagus

---

## 🎓 Informasi Akademik (untuk Slide):

**Mata Kuliah**: TIF503 - Pemrograman Visual (Desktop)  
**SKS**: 3 SKS  
**Semester**: 5 (Ganjil)  
**Kelas**: TI.23.B.1  
**Dosen**: Asep Muhidin, S.Kom., M.Kom.  
**Mahasiswa**: Nandang Duryat (312310233)  
**Jurusan**: Teknik Informatika  
**Universitas**: Universitas Pelita Bangsa  
**Tahun Akademik**: 2024/2025  

**GitHub Repository**: https://github.com/nandurstudio/WinFormsApp_MVC_Architecture  
**Release**: v1.0.0  
**License**: MIT License

---

**Good luck with your presentation! 🚀🎓**
