# Fitur Kelola User

## Deskripsi
Fitur ini memungkinkan admin untuk mengelola user (menambah, mengubah, dan menghapus user).

## Akses
- **Hanya Admin** yang dapat mengakses fitur ini
- Menu: **Master Data > Kelola User**

## File yang Dibuat

### Controller
- `Controllers\UserController.vb` - Controller untuk mengelola operasi CRUD user

### Views
- `Views\User\FormUserList.vb` - Form untuk menampilkan daftar user
- `Views\User\FormUserList.Designer.vb` - Designer untuk FormUserList
- `Views\User\FormUserInput.vb` - Form untuk input/edit user
- `Views\User\FormUserInput.Designer.vb` - Designer untuk FormUserInput

## Fitur-fitur

### 1. FormUserList (Daftar User)
- **Menampilkan semua user** dalam DataGridView dengan kolom:
  - ID
  - Username
  - Email
  - Role (user/admin)
  - Tanggal Dibuat
  
- **Pencarian**: Dapat mencari user berdasarkan username atau email
- **Tombol Tambah User**: Membuka form input untuk menambah user baru
- **Tombol Edit User**: Membuka form input untuk mengubah data user yang dipilih
- **Tombol Hapus User**: Menghapus user yang dipilih (dengan konfirmasi)

### 2. FormUserInput (Input/Edit User)
- **Field Input**:
  - Username (required)
  - Email (required, dengan validasi format)
  - Password (required untuk user baru, optional untuk edit)
  - Confirm Password
  - Role (pilihan: user/admin)

- **Validasi**:
  - Username tidak boleh kosong
  - Email tidak boleh kosong dan harus format yang valid
  - Password minimal 6 karakter (untuk user baru)
  - Password dan Confirm Password harus sama
  - Username tidak boleh duplikat

- **Mode Edit**:
  - Menampilkan data user yang ada
  - Password bersifat optional (kosongkan jika tidak ingin mengubah)
  - Ada label petunjuk untuk password di mode edit

- **Checkbox Show Password**: Untuk menampilkan/menyembunyikan password

### 3. UserController
- **LoadUsers()**: Mengambil semua data user dari database
- **GetUser(userId)**: Mengambil data user berdasarkan ID
- **CreateUser(user, password)**: Membuat user baru
  - Mengecek duplikasi username
  - Hash password menggunakan PasswordModel
  
- **UpdateUser(user, newPassword)**: Mengupdate data user
  - Mengecek duplikasi username (kecuali username sendiri)
  - Update password hanya jika newPassword tidak null/empty
  
- **DeleteUser(userId)**: Menghapus user
  - Proteksi: Tidak bisa menghapus admin terakhir

## Keamanan
1. **Role-based Access**: Hanya admin yang dapat mengakses menu Kelola User
2. **Password Hashing**: Password di-hash menggunakan BCrypt
3. **Validasi Username**: Tidak boleh duplikat
4. **Proteksi Admin**: Tidak bisa menghapus admin terakhir dalam sistem

## Cara Penggunaan

### Menambah User Baru
1. Login sebagai admin
2. Buka menu **Master Data > Kelola User**
3. Klik tombol **Tambah User**
4. Isi semua field yang required:
   - Username
   - Email (format email yang valid)
   - Password (minimal 6 karakter)
   - Confirm Password
   - Pilih Role (user/admin)
5. Klik **Save**

### Mengubah Data User
1. Di FormUserList, pilih user yang ingin diubah
2. Klik tombol **Edit User**
3. Ubah data yang diperlukan
4. Untuk mengubah password, isi field Password dan Confirm Password
5. Untuk tidak mengubah password, kosongkan field Password
6. Klik **Save**

### Menghapus User
1. Di FormUserList, pilih user yang ingin dihapus
2. Klik tombol **Hapus User**
3. Konfirmasi penghapusan
4. User akan dihapus dari database

### Pencarian User
1. Di FormUserList, ketik username atau email di field pencarian
2. List akan otomatis difilter sesuai pencarian

## Catatan Penting
- Password yang tersimpan di database sudah dalam bentuk hash (BCrypt)
- Tidak bisa menghapus admin terakhir untuk menjaga akses admin ke sistem
- Username bersifat unik, tidak boleh ada duplikat
- Email harus format yang valid (menggunakan validasi email .NET)

## Integrasi dengan Sistem
Fitur ini terintegrasi dengan:
- **LoginController**: Menggunakan fungsi yang sama untuk hashing password
- **UserModel**: Menggunakan model yang sudah ada
- **PasswordModel**: Untuk hashing dan verifikasi password
- **FormUtama**: Menu baru di Master Data
