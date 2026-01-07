Imports System
Imports WinFormsApp_Latihan.Services

Module Program
   <STAThread>
   Sub Main()
      Application.EnableVisualStyles()
      Application.SetCompatibleTextRenderingDefault(False)

      ' Cek apakah ada saved credentials untuk auto-login
      Dim hasRememberMe As Boolean = RememberMeService.HasSavedCredentials()

      ' Show Login Form
      Dim loginForm As New FormLogin()

      ' Set flag auto-login jika ada saved credentials
      If hasRememberMe Then
         loginForm.IsAutoLogin = True
      End If

      Dim loginResult As DialogResult = loginForm.ShowDialog()

      ' Only show main form if login was successful
      If loginResult = DialogResult.OK AndAlso loginForm.LoggedInUser IsNot Nothing Then
         ' Show Main Form if login successful
         Dim mainForm As New FormUtama()
         mainForm.SetUserLoggedIn(loginForm.LoggedInUser)
         Application.Run(mainForm)
      Else
         ' Login cancelled or failed - exit application
         Application.Exit()
      End If
   End Sub
End Module
