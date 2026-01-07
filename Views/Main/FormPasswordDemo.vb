' ============================================================
' Nama            : Nandang Duryat
' NIM             : 312310233
' Kelas           : TI.23.B1
' Universitas     : Pelita Bangsa
' Pertemuan Ke    : 3
' Mata Kuliah     : Pemrograman Visual (Desktop)
' Dosen Pengampu  : Asep Muhidin, S.Kom., M.Kom.
' ============================================================
Imports WinFormsApp_Latihan.Controllers

Public Class FormPasswordDemo

	Private _passwordController As PasswordController

	Private Sub FormPasswordDemo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
		Text = "Demo Enkripsi Password - AES"
		FormBorderStyle = FormBorderStyle.FixedDialog
		StartPosition = FormStartPosition.CenterParent
		MaximizeBox = False
		MinimizeBox = False

		' Initialize Controller
		_passwordController = New PasswordController()

		' Set default values untuk demo
		TextBoxPlainPassword.Text = "12345678"
		TextBoxUsername.Text = "admin"

		DemoEncryption()
	End Sub

	Private Sub DemoEncryption()
		Try
			If String.IsNullOrEmpty(TextBoxPlainPassword.Text) OrElse String.IsNullOrEmpty(TextBoxUsername.Text) Then
				Return
			End If

			Dim plainPassword As String = TextBoxPlainPassword.Text
			Dim username As String = TextBoxUsername.Text

			' Demo hash password
			Dim hashed As String = _passwordController.HashPassword(plainPassword)
			TextBoxHash.Text = hashed

			' Demo enkripsi dengan key (username sebagai key)
			Dim encrypted As String = _passwordController.EncryptPassword(plainPassword, username)
			TextBoxEncrypted.Text = encrypted
			TextBoxEncryptedWithSalt.Text = encrypted

			' Demo dekripsi
			Dim decrypted As String = _passwordController.DecryptPassword(encrypted, username)
			LabelDecryptedResult.Text = $"Decrypted: {decrypted}"

			' Demo verifikasi hash
			Dim isValid As Boolean = _passwordController.VerifyPassword(plainPassword, hashed)
			LabelVerificationResult.Text = $"Verification: {If(isValid, "VALID ✓", "INVALID ✗")}"
			LabelVerificationResult.ForeColor = If(isValid, Color.Green, Color.Red)

		Catch ex As Exception
			MessageBox.Show($"Error in demo: {ex.Message}", "Demo Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
		End Try
	End Sub

	Private Sub TextBoxPlainPassword_TextChanged(sender As Object, e As EventArgs) Handles TextBoxPlainPassword.TextChanged
		DemoEncryption()
	End Sub

	Private Sub TextBoxUsername_TextChanged(sender As Object, e As EventArgs) Handles TextBoxUsername.TextChanged
		DemoEncryption()
	End Sub

	Private Sub ButtonTestDecrypt_Click(sender As Object, e As EventArgs) Handles ButtonTestDecrypt.Click
		Try
			If String.IsNullOrEmpty(TextBoxTestEncrypted.Text) Then
				MessageBox.Show("Masukkan encrypted password untuk di-test!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
				Return
			End If

			Dim key As String = If(String.IsNullOrEmpty(TextBoxUsername.Text), "admin", TextBoxUsername.Text)
			Dim decrypted As String = _passwordController.DecryptPassword(TextBoxTestEncrypted.Text, key)
			LabelTestDecryptResult.Text = $"Decrypted: {decrypted}"
			LabelTestDecryptResult.ForeColor = Color.Blue

		Catch ex As Exception
			LabelTestDecryptResult.Text = $"Error: {ex.Message}"
			LabelTestDecryptResult.ForeColor = Color.Red
		End Try
	End Sub

	Private Sub ButtonClose_Click(sender As Object, e As EventArgs) Handles ButtonClose.Click
		Close()
	End Sub

	Private Sub ButtonCopyEncrypted_Click(sender As Object, e As EventArgs) Handles ButtonCopyEncrypted.Click
		If Not String.IsNullOrEmpty(TextBoxEncryptedWithSalt.Text) Then
			Clipboard.SetText(TextBoxEncryptedWithSalt.Text)
			MessageBox.Show("Encrypted password copied to clipboard!", "Copy", MessageBoxButtons.OK, MessageBoxIcon.Information)
		End If
	End Sub

End Class