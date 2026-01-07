# Naskah Video Presentasi YouTube (Durasi ± 5 Menit)
## Judul: Desktop Application Development using MVC Architecture (Studi Kasus Aplikasi Penjualan)

**Target Durasi**: 5 Menit
**Format**: Screencast dengan Voice Over

---

### 0:00 - 0:45 | Pembukaan & Pendahuluan

| Visual (Layar) | Narasi (Voice Over) | Screenshot Wajib |
| :--- | :--- | :--- |
| **Slide Judul**: Judul Tugas, Nama, NIM, Kelas, Mata Kuliah. | "Assalamualaikum Wr. Wb. Halo semuanya. Perkenalkan nama saya [Nama Anda], mahasiswa Teknik Informatika Universitas Pelita Bangsa." | - |
| **Slide Arsitektur**: Diagram sederhana blok MVC (Model - View - Controller). | "Pada video kali ini, saya akan mempresentasikan tugas Ujian Akhir Semester mata kuliah Pemrograman Visual. Tugas ini adalah membangun Aplikasi Penjualan Desktop menggunakan bahasa VB.NET dengan penerapan arsitektur MVC atau Model-View-Controller." | Diagram MVC |
| **Folder Structure**: Tampilkan Solution Explorer di Visual Studio. | "Penerapan MVC ini bertujuan memisahkan logika bisnis, tampilan, dan data agar aplikasi lebih rapi dan mudah dikembangkan. Bisa dilihat di sini, struktur project saya sudah terpisah menjadi folder Models, Views, dan Controllers." | Solution Explorer (Folder Tree) |

---

### 0:45 - 1:30 | Login & Keamanan

| Visual (Layar) | Narasi (Voice Over) | Screenshot Wajib |
| :--- | :--- | :--- |
| **Form Login**: Tampilan awal aplikasi saat dijalankan. | "Kita mulai dari gerbang utama, yaitu Form Login. Di sini user harus memasukkan username dan password." | Form Login (Kosong) |
| **Aksi**: Ketik username/password salah, lalu yang benar. Klik Login. | "Secara teknis, View hanya menerima input. Validasi user dilakukan oleh `LoginController` yang mencocokkan data dengan database. Jika berhasil, sistem akan menyimpan sesi user menggunakan `UserModel`." | Pop-up Pesan Error / Sukses |
| **Fitur**: Tunjuk Checkbox 'Remember Me'. | "Terdapat juga fitur 'Remember Me' untuk menyimpan kredensial secara aman untuk login berikutnya." | - |

---

### 1:30 - 2:30 | Dashboard & Master Data

| Visual (Layar) | Narasi (Voice Over) | Screenshot Wajib |
| :--- | :--- | :--- |
| **Form Utama**: Tampilan dashboard setelah login. | "Setelah login berhasil, kita masuk ke Form Utama. Di bagian bawah (Status Bar), terlihat informasi user yang sedang aktif. Menu di atas menyesuaikan dengan hak akses user." | Form Utama (Full Screen) |
| **Menu Master**: Klik menu Master -> Barang. | "Masuk ke modul Master Data. Salah satu yang terpenting adalah Data Barang." | Menu Dropdown Master |
| **Form Item List**: Tampilkan grid data barang. Coba fitur Search. | "Ini adalah `FormItemList`. Data yang tampil di Grid ini diambil oleh `ItemController` dari database. Kita bisa mencari barang dengan cepat di kolom pencarian ini." | Form Daftar Barang |
| **Form Item Input**: Klik tombol 'Tambah' atau 'Edit'. | "Saat menambah atau mengedit barang, kita menggunakan `FormItemInput`. Form ini berkomunikasi dengan Controller untuk validasi sebelum data disimpan permanen ke database." | Form Input Barang |

---

### 2:30 - 3:45 | Transaksi Penjualan (Fitur Utama)

| Visual (Layar) | Narasi (Voice Over) | Screenshot Wajib |
| :--- | :--- | :--- |
| **Menu Transaksi**: Buka Form Penjualan (`FormSale`). | "Sekarang kita masuk ke fitur inti, yaitu Transaksi Penjualan." | - |
| **Aksi Transaksi**: Tekan F1 (Baru), Masukkan Kode Barang, Enter. | "Form ini dirancang interaktif untuk kasir. Tekan F1 untuk transaksi baru. Saat kode barang diinput, Controller otomatis mengambil Nama dan Harga barang dari Model." | Form Transaksi (Sedang input barang) |
| **Kalkulasi**: Ubah Qty, tunjuk Subtotal yang berubah. | "Perhitungan subtotal dan total dilakukan secara real-time di tampilan (View), memberikan respons yang cepat kepada pengguna." | Grid Detail Transaksi |
| **Simpan**: Klik Simpan / Tekan F3. | "Saat transaksi disimpan, `SaleController` bekerja keras di belakang layar. Ia menyimpan data Header Penjualan dan Detail Barang sekaligus, serta memotong stok barang secara otomatis." | Pesan "Transaksi Berhasil" |

---

### 3:45 - 4:30 | Laporan

| Visual (Layar) | Narasi (Voice Over) | Screenshot Wajib |
| :--- | :--- | :--- |
| **Menu Laporan**: Buka Laporan Penjualan. | "Terakhir, untuk kebutuhan manajemen, tersedia fitur Laporan." | - |
| **Filter Laporan**: Pilih rentang tanggal, klik Tampilkan. | "Di Laporan Penjualan ini, user bisa memfilter data berdasarkan periode tanggal. Data yang tampil adalah hasil rekapitulasi yang diolah oleh `SalesReportController`." | Form Laporan Penjualan (Ada datanya) |
| **Fitur Export**: Tunjuk tombol Export/Print. | "Selain itu, laporan ini juga bisa diekspor ke PDF atau dicetak langsung untuk keperluan arsip fisik." | - |
| **Detail Laporan**: (Opsional) Double click salah satu baris untuk lihat detail. | "Laporan ini membantu pemilik toko memantau performa penjualan harian atau bulanan dengan mudah." | - |

---

### 4:30 - 5:00 | Penutup

| Visual (Layar) | Narasi (Voice Over) | Screenshot Wajib |
| :--- | :--- | :--- |
| **Form About**: Tampilkan Form About atau kembali ke Slide Judul. | "Demikian demonstrasi aplikasi penjualan berbasis MVC ini. Aplikasi ini dibangun menggunakan Visual Basic .NET dan database MySQL." | Form About |
| **Wajah/Slide Penutup**: Ucapan terima kasih. | "Penerapan MVC membuat kode program lebih terstruktur, mudah dibaca, dan mudah dikembangkan di masa depan. Terima kasih atas perhatiannya. Wassalamualaikum Wr. Wb." | - |

---

## Checklist Screenshot untuk Laporan Tertulis (Dokumen Word/PDF):
Berdasarkan naskah di atas, pastikan Anda mengambil screenshot berikut untuk dimasukkan ke dokumen `Laporan_UAS_MVC.md`:

1.  **Solution Explorer** (Menunjukkan folder Controllers, Models, Views).
2.  **Form Login** (Tampilan awal).
3.  **Form Utama** (Dashboard).
4.  **Form Daftar Barang** (Grid barang).
5.  **Form Input Barang** (Dialog tambah/edit).
6.  **Form Transaksi Penjualan** (Kondisi terisi beberapa item).
7.  **Form Laporan Penjualan** (Hasil filter tanggal).
