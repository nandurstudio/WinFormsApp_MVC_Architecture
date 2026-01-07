' ============================================================
' Nama            : Nandang Duryat
' NIM             : 312310233
' Kelas           : TI.23.B1
' Universitas     : Pelita Bangsa
' Pertemuan Ke    : 3
' Mata Kuliah     : Pemrograman Visual (Desktop)
' Dosen Pengampu  : Asep Muhidin, S.Kom., M.Kom.
' ============================================================
Imports MySql.Data.MySqlClient
Imports WinFormsApp_Latihan.Models
Imports WinFormsApp_Latihan.Controllers
Imports WinFormsApp_Latihan.Services

Public Class FormLogin

   ' Controllers
   Private _loginController As LoginController
   Private _settingController As SettingController
   Private _config As ConfigModel
   Private _initializationSuccess As Boolean = False

   ' Menyimpan informasi user yang berhasil login
   Public Property LoggedInUser As UserModel

   ' Flag untuk auto login
   Public Property IsAutoLogin As Boolean = False

   Private Sub FormLogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
      Text = "Login Form - MVC Application"
      FormBorderStyle = FormBorderStyle.FixedDialog
      StartPosition = FormStartPosition.CenterScreen
      MaximizeBox = False
      MinimizeBox = False
      TextBoxPassword.PasswordChar = "*"

      ' ALWAYS hide settings button (removed from UI completely)
      If ButtonSetting IsNot Nothing Then
         ButtonSetting.Visible = False
      End If

      ' Initialize Controllers
      Dim initResult As InitializationResult = InitializeControllers()

      If Not initResult.Success Then
         ' Show error to user
         MessageBox.Show(initResult.ErrorMessage,
                        "Initialization Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error)

         ' Exit application - don't show login form
         _initializationSuccess = False
         Me.DialogResult = DialogResult.Cancel
         Application.Exit()
         Return
      End If

      _initializationSuccess = True

      ' Load saved credentials jika ada
      LoadSavedCredentials()

      ' Set focus to username field
      If String.IsNullOrEmpty(TextBoxUserName.Text) Then
         TextBoxUserName.Focus()
      Else
         TextBoxPassword.Focus()
      End If
   End Sub

   Private Sub LoadSavedCredentials()
      Try
         Dim savedData = RememberMeService.LoadCredentials()
         If savedData IsNot Nothing AndAlso savedData.RememberMe Then
            TextBoxUserName.Text = savedData.Username
            ' Decrypt password dan isi textbox
            Dim decryptedPassword As String = RememberMeService.GetDecryptedPassword(savedData.EncryptedPassword)
            TextBoxPassword.Text = decryptedPassword
            CheckBoxRememberMe.Checked = True

            ' Jika IsAutoLogin = True, langsung login tanpa user interaction
            If IsAutoLogin Then
               ' Delay sedikit agar form tampil dulu
               Application.DoEvents()
               ButtonLogin_Click(Nothing, Nothing)
            End If
         End If
      Catch ex As Exception
         ' Silent fail - tidak ganggu user
         Console.WriteLine($"Error loading saved credentials: {ex.Message}")
      End Try
   End Sub

   Private Function InitializeControllers() As InitializationResult
      Try
         ' Step 1: Load configuration
         _settingController = New SettingController()
         _config = _settingController.LoadConfiguration()

         If _config Is Nothing Then
            Return New InitializationResult With {
               .Success = False,
               .ErrorMessage = "Unable to load database configuration." & vbCrLf &
                             "setting.ini file not found or invalid." & vbCrLf & vbCrLf &
                             "Application will be closed."
            }
         End If

         ' Step 2: Create LoginController
         _loginController = New LoginController(_config)

         ' Step 3: Test connection
         If Not _loginController.TestConnection() Then
            Return New InitializationResult With {
               .Success = False,
               .ErrorMessage = "Unable to connect to database." & vbCrLf &
                             "Please check your database configuration." & vbCrLf & vbCrLf &
                             "Server: " & _config.Server & vbCrLf &
                             "Database: " & _config.Database & vbCrLf & vbCrLf &
                             "Application will be closed."
            }
         End If

         ' Step 4: Create default admin user (silent, ignore errors)
         Try
            _loginController.CreateDefaultAdminUser()
         Catch ex As Exception
            ' Ignore - user might already exist
         End Try

         ' Success!
         Return New InitializationResult With {
            .Success = True,
            .ErrorMessage = String.Empty
         }

      Catch ex As Exception
         ' Unexpected error
         Return New InitializationResult With {
            .Success = False,
            .ErrorMessage = "Unexpected error during application initialization:" & vbCrLf &
                          ex.Message & vbCrLf & vbCrLf &
                          "Application will be closed."
         }
      End Try
   End Function

   Private Sub ButtonLogin_Click(sender As Object, e As EventArgs) Handles ButtonLogin.Click
      ' Don't allow login if initialization failed
      If Not _initializationSuccess Then
         MessageBox.Show("Application not ready. Please restart the application.",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
         Return
      End If

      Dim inputUser As String = TextBoxUserName.Text.Trim()
      Dim inputPass As String = TextBoxPassword.Text.Trim()

      If Not IsInputValid(inputUser, inputPass) Then Exit Sub
      If Not IsPasswordValid(inputPass) Then Exit Sub

      DoLogin(inputUser, inputPass)
   End Sub

   ' ================== Functions & Subs ==================

   Private Function IsInputValid(user As String, pass As String) As Boolean
      If user = "" And pass = "" Then
         MessageBox.Show("Username and Password must be filled", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
         TextBoxUserName.Focus()
         Return False
      ElseIf user = "" Then
         MessageBox.Show("Username must be filled", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
         TextBoxUserName.Focus()
         Return False
      ElseIf pass = "" Then
         MessageBox.Show("Password must be filled", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
         TextBoxPassword.Focus()
         Return False
      End If
      Return True
   End Function

   Private Function IsPasswordValid(pass As String) As Boolean
      If pass.Length < 8 Then
         MessageBox.Show("Password must be at least 8 characters", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
         TextBoxPassword.Focus()
         Return False
      End If
      Return True
   End Function

   Private Sub DoLogin(user As String, pass As String)
      ' Tampilkan loading cursor
      Me.Cursor = Cursors.WaitCursor

      Try
         ' Autentikasi menggunakan LoginController
         If _loginController.AuthenticateUser(user, pass) Then
            ' Get user info (including role)
            LoggedInUser = _loginController.GetUserByUsername(user)

            If LoggedInUser IsNot Nothing Then
               ' Save credentials jika checkbox Remember Me dicentang
               If CheckBoxRememberMe.Checked Then
                  RememberMeService.SaveCredentials(user, pass)
               Else
                  ' Clear saved credentials jika checkbox tidak dicentang
                  RememberMeService.ClearCredentials()
               End If

               ' Hanya tampilkan pesan jika bukan auto login
               If Not IsAutoLogin Then
                  MessageBox.Show($"Login successful!" & vbCrLf &
                                $"Welcome, {LoggedInUser.Username}!" & vbCrLf &
                                $"Role: {LoggedInUser.Role}",
                                "Login Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
               End If

               ' Set DialogResult untuk memberitahu parent form bahwa login berhasil
               Me.DialogResult = DialogResult.OK

               ' Jika FormUtama tidak ada (aplikasi dimulai dari FormLogin)
               If Application.OpenForms.OfType(Of FormUtama).Count = 0 Then
                  ' Buka Form Utama
                  Dim formUtama As New FormUtama()
                  formUtama.SetUserLoggedIn(LoggedInUser)
                  Me.Hide()
                  formUtama.ShowDialog()
                  Me.Show()
               Else
                  ' Jika dipanggil dari FormUtama, tutup dialog login
                  Me.Close()
               End If
            Else
               MessageBox.Show("Login failed!" & vbCrLf &
                             "Unable to retrieve user information.",
                             "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

         Else
            MessageBox.Show("Login failed!" & vbCrLf &
                          "Invalid username or password." & vbCrLf &
                          "Please check your username and password.",
                          "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
            TextBoxPassword.Clear()
            TextBoxUserName.Focus()
         End If

      Catch ex As Exception
         MessageBox.Show($"Error during login: {ex.Message}", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   ' =======================================================

   Private Sub CheckBoxShowPassword_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxShowPassword.CheckedChanged
      If CheckBoxShowPassword.Checked = True Then
         TextBoxPassword.PasswordChar = ""
      Else
         TextBoxPassword.PasswordChar = "*"
      End If
   End Sub

   Private Sub ButtonCancel_Click(sender As Object, e As EventArgs) Handles ButtonCancel.Click
      LoggedInUser = Nothing
      Me.DialogResult = DialogResult.Cancel
      Application.Exit()
   End Sub

   ' Settings button handler (kept for compatibility but hidden)
   Private Sub ButtonSetting_Click(sender As Object, e As EventArgs) Handles ButtonSetting.Click
      ' This should never be called as button is hidden
      ' But kept for designer compatibility
   End Sub

   ' About button handler
   Private Sub ButtonAbout_Click(sender As Object, e As EventArgs) Handles ButtonAbout.Click
      Dim formAbout As New FormAbout()
      formAbout.ShowDialog(Me)
   End Sub

   ' Event untuk enter key pada textbox password
   Private Sub TextBoxPassword_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBoxPassword.KeyDown
      If e.KeyCode = Keys.Enter Then
         ButtonLogin_Click(sender, e)
      End If
   End Sub

   ' Event untuk enter key pada textbox username
   Private Sub TextBoxUserName_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBoxUserName.KeyDown
      If e.KeyCode = Keys.Enter Then
         TextBoxPassword.Focus()
      End If
   End Sub

   ' Helper class for initialization result
   Private Class InitializationResult
      Public Property Success As Boolean
      Public Property ErrorMessage As String
   End Class

End Class
