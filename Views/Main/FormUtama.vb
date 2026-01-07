' ============================================================
' Nama            : Nandang Duryat
' NIM             : 312310233
' Kelas           : TI.23.B1
' Universitas     : Pelita Bangsa
' Pertemuan Ke    : 3
' Mata Kuliah     : Pemrograman Visual (Desktop)
' Dosen Pengampu  : Asep Muhidin, S.Kom., M.Kom.
' ============================================================
Imports WinFormsApp_Latihan.Models
Imports WinFormsApp_Latihan.Services

Public Class FormUtama

   Private _isUserLoggedIn As Boolean = False
   Private _loggedInUser As UserModel

   ' MenuStrip and Menu Items
   Private mainMenuStrip As MenuStrip
   Private menuMasterData As ToolStripMenuItem
   Private menuTransaksi As ToolStripMenuItem
   Private menuLaporan As ToolStripMenuItem
   Private menuPengaturan As ToolStripMenuItem

   Private Sub FormUtama_Load(sender As Object, e As EventArgs) Handles MyBase.Load
      Text = AppInfo.GetWindowTitle("Main Dashboard")
      WindowState = FormWindowState.Maximized
      IsMdiContainer = True

      ' Initialize MenuStrip
      InitializeMenuStrip()

      ' Setup initial state (update menu visibility now that menus are initialized)
      UpdateUIBasedOnLoginStatus()

      ' Setup welcome message
      If _isUserLoggedIn Then
         LabelWelcome.Text = $"Welcome, {_loggedInUser.Username}! ({_loggedInUser.Role}) - Login: {DateTime.Now:dd/MM/yyyy HH:mm:ss}"
      Else
         LabelWelcome.Text = $"Welcome to {AppInfo.AppFullName}!"
      End If
   End Sub

   Private Sub InitializeMenuStrip()
      ' Create MenuStrip
      mainMenuStrip = New MenuStrip()
      mainMenuStrip.Dock = DockStyle.Top
      mainMenuStrip.BackColor = Color.FromArgb(240, 240, 240)
      mainMenuStrip.Font = New Font("Segoe UI", 10.0F, FontStyle.Regular)
      mainMenuStrip.Name = "MainMenuStrip"

      ' ===== MASTER DATA MENU (Admin Only) =====
      menuMasterData = New ToolStripMenuItem("Master Data")
      menuMasterData.Font = New Font("Segoe UI", 10.0F, FontStyle.Bold)

      Dim menuCategory As New ToolStripMenuItem("Kelola Kategori")
      AddHandler menuCategory.Click, AddressOf MenuCategory_Click
      menuMasterData.DropDownItems.Add(menuCategory)

      Dim menuItems As New ToolStripMenuItem("Kelola Barang")
      AddHandler menuItems.Click, AddressOf MenuItems_Click
      menuMasterData.DropDownItems.Add(menuItems)

      menuMasterData.DropDownItems.Add(New ToolStripSeparator())

      Dim menuSupplier As New ToolStripMenuItem("Kelola Supplier")
      AddHandler menuSupplier.Click, AddressOf MenuSupplier_Click
      menuMasterData.DropDownItems.Add(menuSupplier)

      menuMasterData.DropDownItems.Add(New ToolStripSeparator())

      Dim menuUsers As New ToolStripMenuItem("Kelola User")
      AddHandler menuUsers.Click, AddressOf MenuUsers_Click
      menuMasterData.DropDownItems.Add(menuUsers)

      ' ===== TRANSAKSI MENU (All Users) =====
      menuTransaksi = New ToolStripMenuItem("Transaksi")
      menuTransaksi.Font = New Font("Segoe UI", 10.0F, FontStyle.Bold)

      Dim menuSales As New ToolStripMenuItem("Transaksi Penjualan")
      AddHandler menuSales.Click, AddressOf MenuSales_Click
      menuTransaksi.DropDownItems.Add(menuSales)

      Dim menuPurchase As New ToolStripMenuItem("Transaksi Pembelian")
      AddHandler menuPurchase.Click, AddressOf MenuPurchase_Click
      menuTransaksi.DropDownItems.Add(menuPurchase)

      ' ===== LAPORAN MENU (All Users) =====
      menuLaporan = New ToolStripMenuItem("Laporan")
      menuLaporan.Font = New Font("Segoe UI", 10.0F, FontStyle.Bold)

      Dim menuSalesReport As New ToolStripMenuItem("Laporan Penjualan")
      AddHandler menuSalesReport.Click, AddressOf MenuSalesReport_Click
      menuLaporan.DropDownItems.Add(menuSalesReport)

      Dim menuPurchaseReport As New ToolStripMenuItem("Laporan Pembelian")
      AddHandler menuPurchaseReport.Click, AddressOf MenuPurchaseReport_Click
      menuLaporan.DropDownItems.Add(menuPurchaseReport)

      ' ===== PENGATURAN MENU (Admin Only) =====
      menuPengaturan = New ToolStripMenuItem("Pengaturan")
      menuPengaturan.Font = New Font("Segoe UI", 10.0F, FontStyle.Bold)

      Dim menuPreferences As New ToolStripMenuItem("Preferences")
      AddHandler menuPreferences.Click, AddressOf MenuPreferences_Click
      menuPengaturan.DropDownItems.Add(menuPreferences)

      Dim menuPasswordDemo As New ToolStripMenuItem("Demo Password")
      AddHandler menuPasswordDemo.Click, AddressOf MenuPasswordDemo_Click
      menuPengaturan.DropDownItems.Add(menuPasswordDemo)

      Dim menuAbout As New ToolStripMenuItem("About")
      AddHandler menuAbout.Click, AddressOf MenuAbout_Click
      menuPengaturan.DropDownItems.Add(menuAbout)

      menuPengaturan.DropDownItems.Add(New ToolStripSeparator())

      Dim menuLogoutFromSettings As New ToolStripMenuItem("Logout")
      menuLogoutFromSettings.ForeColor = Color.DarkRed
      AddHandler menuLogoutFromSettings.Click, AddressOf MenuLogout_Click
      menuPengaturan.DropDownItems.Add(menuLogoutFromSettings)

      ' ===== LOGOUT MENU =====
      Dim menuLogout = New ToolStripMenuItem("Logout")
      menuLogout.Font = New Font("Segoe UI", 10.0F, FontStyle.Bold)
      menuLogout.ForeColor = Color.DarkRed
      AddHandler menuLogout.Click, AddressOf MenuLogout_Click

      ' Add all menus to MenuStrip
      mainMenuStrip.Items.Add(menuMasterData)
      mainMenuStrip.Items.Add(menuTransaksi)
      mainMenuStrip.Items.Add(menuLaporan)
      mainMenuStrip.Items.Add(menuPengaturan)
      ' Logout menu removed - now under Pengaturan

      ' Add MenuStrip to form FIRST (so it docks at top)
      Me.Controls.Add(mainMenuStrip)
      Me.mainMenuStrip = mainMenuStrip
   End Sub

   Private Sub UpdateUIBasedOnLoginStatus()
      If _isUserLoggedIn Then
         ' Update UI
         ButtonLogin.Text = "LOGOUT"
         ButtonLogin.BackColor = Color.Tomato
         ButtonSettings.Visible = False ' Hide old settings button
         LabelUserStatus.Text = $"Logged in: {_loggedInUser.Username} | Role: {_loggedInUser.Role} | ID: {_loggedInUser.UserId}"
         LabelUserStatus.ForeColor = Color.Green

         ' Role-based menu visibility (only if menu is initialized)
         If mainMenuStrip IsNot Nothing AndAlso menuMasterData IsNot Nothing Then
            If _loggedInUser.IsAdmin() Then
               ' Admin dapat akses semua menu
               menuMasterData.Visible = True
               menuTransaksi.Visible = True
               menuLaporan.Visible = True
               menuPengaturan.Visible = True
            Else
               ' User biasa hanya dapat akses transaksi, laporan, dan pengaturan (terbatas)
               menuMasterData.Visible = False
               menuTransaksi.Visible = True
               menuLaporan.Visible = True
               menuPengaturan.Visible = True

               ' Hide admin-only items in Pengaturan menu for regular users
               For Each item As ToolStripItem In menuPengaturan.DropDownItems
                  If TypeOf item Is ToolStripMenuItem Then
                     Dim menuItem = CType(item, ToolStripMenuItem)
                     ' Show only About and Logout for regular users
                     If menuItem.Text = "About" OrElse menuItem.Text = "Logout" Then
                        menuItem.Visible = True
                     Else
                        menuItem.Visible = False ' Hide Preferences and Demo Password
                     End If
                  ElseIf TypeOf item Is ToolStripSeparator Then
                     item.Visible = False ' Hide separator for regular users
                  End If
               Next
            End If
         End If
      Else
         ButtonLogin.Text = "LOGIN"
         ButtonLogin.BackColor = Color.ForestGreen
         ButtonSettings.Visible = False
         LabelUserStatus.Text = "Status: Not logged in"
         LabelUserStatus.ForeColor = Color.Red

         ' Hide all menus when not logged in (only if menu is initialized)
         If mainMenuStrip IsNot Nothing AndAlso menuMasterData IsNot Nothing Then
            menuMasterData.Visible = False
            menuTransaksi.Visible = False
            menuLaporan.Visible = False
            menuPengaturan.Visible = False
         End If

         ' Update window title
         Me.Text = AppInfo.GetWindowTitle("Main Dashboard", "Not Logged In")
      End If
   End Sub

   ' Set user yang sudah login
   Public Sub SetUserLoggedIn(userInfo As UserModel)
      _isUserLoggedIn = True
      _loggedInUser = userInfo
      UpdateUIBasedOnLoginStatus()

      ' Update welcome message
      LabelWelcome.Text = $"Welcome, {_loggedInUser.Username}! ({_loggedInUser.Role}) - Login: {DateTime.Now:dd/MM/yyyy HH:mm:ss}"

      ' Update window title with user info
      Me.Text = AppInfo.GetWindowTitle("Main Dashboard", $"{_loggedInUser.Username} ({_loggedInUser.Role})")
   End Sub

   ' ===== HELPER METHOD: Show or Activate Single Instance Form =====
   Private Sub ShowOrActivateForm(Of T As Form)()
      ' Check if form of this type already exists and is open
      For Each childForm As Form In Me.MdiChildren
         If TypeOf childForm Is T Then
            ' Form already exists, just activate it
            childForm.Activate()
            Return
         End If
      Next

      ' Form doesn't exist, create new instance
      Dim newForm As T = Activator.CreateInstance(Of T)()
      newForm.MdiParent = Me
      newForm.Show()
   End Sub

   ' ===== MENU CLICK HANDLERS =====

   Private Sub MenuCategory_Click(sender As Object, e As EventArgs)
      If Not CheckLoginAndPermission(requireAdmin:=True) Then Return
      ShowOrActivateForm(Of FormCategoryList)()
   End Sub

   Private Sub MenuItems_Click(sender As Object, e As EventArgs)
      If Not CheckLoginAndPermission(requireAdmin:=True) Then Return
      ShowOrActivateForm(Of FormItemList)()
   End Sub

   Private Sub MenuUsers_Click(sender As Object, e As EventArgs)
      If Not CheckLoginAndPermission(requireAdmin:=True) Then Return
      ShowOrActivateForm(Of FormUserList)()
   End Sub

   Private Sub MenuSupplier_Click(sender As Object, e As EventArgs)
      If Not CheckLoginAndPermission(requireAdmin:=True) Then Return
      ShowOrActivateForm(Of FormSupplierList)()
   End Sub

   Private Sub MenuSales_Click(sender As Object, e As EventArgs)
      If Not CheckLoginAndPermission(requireAdmin:=False) Then Return
      ShowOrActivateForm(Of FormSale)()
   End Sub

   Private Sub MenuPurchase_Click(sender As Object, e As EventArgs)
      If Not CheckLoginAndPermission(requireAdmin:=False) Then Return
      ShowOrActivateForm(Of FormPurchase)()
   End Sub

   Private Sub MenuSalesReport_Click(sender As Object, e As EventArgs)
      If Not CheckLoginAndPermission(requireAdmin:=False) Then Return
      ShowOrActivateForm(Of FormSalesReport)()
   End Sub

   Private Sub MenuPurchaseReport_Click(sender As Object, e As EventArgs)
      If Not CheckLoginAndPermission(requireAdmin:=False) Then Return
      ShowOrActivateForm(Of FormPurchaseReport)()
   End Sub

   Private Sub MenuPreferences_Click(sender As Object, e As EventArgs)
      If Not CheckLoginAndPermission(requireAdmin:=True) Then Return

      Dim frmSettings As New FormCompleteSettings()
      frmSettings.ShowDialog()
   End Sub

   Private Sub MenuPasswordDemo_Click(sender As Object, e As EventArgs)
      If Not CheckLoginAndPermission(requireAdmin:=True) Then Return

      Dim frmPasswordDemo As New FormPasswordDemo()
      frmPasswordDemo.ShowDialog()
   End Sub

   Private Sub MenuAbout_Click(sender As Object, e As EventArgs)
      ' About can be accessed by anyone logged in
      If Not _isUserLoggedIn Then
         MessageBox.Show("Please login to view application information.",
                        "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning)
         Return
      End If

      Dim frmAbout As New FormAbout()
      frmAbout.ShowDialog()
   End Sub

   Private Sub MenuLogout_Click(sender As Object, e As EventArgs)
      ButtonLogin_Click(sender, e) ' Reuse existing logout logic
   End Sub

   ' Helper function to check login and permission
   Private Function CheckLoginAndPermission(requireAdmin As Boolean) As Boolean
      If Not _isUserLoggedIn Then
         MessageBox.Show("Anda harus login terlebih dahulu untuk mengakses fitur ini!",
                          "Akses Ditolak", MessageBoxButtons.OK, MessageBoxIcon.Warning)
         Return False
      End If

      If requireAdmin AndAlso Not _loggedInUser.IsAdmin() Then
         MessageBox.Show($"Akses ditolak! Fitur ini hanya untuk Admin." & vbCrLf +
                          $"Role Anda: {_loggedInUser.Role}",
                          "Akses Ditolak", MessageBoxButtons.OK, MessageBoxIcon.Warning)
         Return False
      End If

      Return True
   End Function

   Private Sub ButtonLogin_Click(sender As Object, e As EventArgs) Handles ButtonLogin.Click
      If _isUserLoggedIn Then
         ' Logout
         Dim result As DialogResult = MessageBox.Show($"Apakah Anda yakin ingin logout dari akun {_loggedInUser.Username}?",
                                                        "Konfirmasi Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
         If result = DialogResult.Yes Then
            ' Close all MDI children
            For Each childForm As Form In Me.MdiChildren
               childForm.Close()
            Next

            ' Clear saved credentials (logout akan hapus Remember Me)
            RememberMeService.ClearCredentials()

            _isUserLoggedIn = False
            _loggedInUser = Nothing
            UpdateUIBasedOnLoginStatus()
            LabelWelcome.Text = "Selamat datang di Aplikasi Penjualan!"
            Me.Text = "Form Utama - Not Logged In"
         End If
      Else
         ' Login
         Dim formLogin As New FormLogin()
         If formLogin.ShowDialog() = DialogResult.OK Then
            ' User berhasil login, ambil informasi user dari FormLogin
            If formLogin.LoggedInUser IsNot Nothing Then
               SetUserLoggedIn(formLogin.LoggedInUser)
            End If
         End If
      End If
   End Sub

   Private Sub ButtonSettings_Click(sender As Object, e As EventArgs) Handles ButtonSettings.Click
      ' This button should be hidden, but keeping the handler for compatibility
      If Not _isUserLoggedIn Then
         MessageBox.Show("Anda harus login terlebih dahulu untuk mengakses pengaturan.",
                          "Akses Ditolak", MessageBoxButtons.OK, MessageBoxIcon.Warning)
         Return
      End If

      If Not _loggedInUser.IsAdmin() Then
         MessageBox.Show("Hanya admin yang dapat mengakses pengaturan!",
                          "Akses Ditolak", MessageBoxButtons.OK, MessageBoxIcon.Warning)
         Return
      End If

      Dim formSetting As New FormSetting()
      formSetting.ShowDialog()
   End Sub

   Private Sub FormUtama_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
      ' Close all MDI children without confirmation
      For Each childForm As Form In Me.MdiChildren
         childForm.Dispose()
      Next

      ' Only show confirmation when closing main form
      If e.CloseReason = CloseReason.UserClosing Then
         Dim userName As String = If(_isUserLoggedIn, _loggedInUser.Username, "Guest")
         Dim result As DialogResult = MessageBox.Show(
            $"Terima kasih telah menggunakan aplikasi, {userName}!" & vbCrLf &
            "Apakah Anda yakin ingin keluar dari aplikasi?",
            "Konfirmasi Exit",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question)

         If result = DialogResult.No Then
            e.Cancel = True
         Else
            ' User confirms exit, terminate the application
            Application.Exit()
         End If
      End If
   End Sub

   ' Method untuk mengecek apakah user sudah login
   Public Function IsUserLoggedIn() As Boolean
      Return _isUserLoggedIn
   End Function

   ' Method untuk mendapatkan informasi user yang sedang login
   Public Function GetLoggedInUser() As UserModel
      Return _loggedInUser
   End Function

End Class