Imports WinFormsApp_Latihan.Models
Imports WinFormsApp_Latihan.Controllers

Public Class FormUserInput
    Private controller As UserController
    Private _config As ConfigModel
    Private editedUserId As Integer = -1
    Private isEditMode As Boolean = False

    Sub New()
        InitializeComponent()
        InitializeControllers()
        InitializeForm()
    End Sub

    Sub New(user As UserModel)
        InitializeComponent()
        InitializeControllers()
        InitializeForm()

        ' Set form to edit mode
        isEditMode = True
        editedUserId = user.UserId

        ' Fill form with user data
        txtUsername.Text = user.Username
        txtEmail.Text = user.Email
        cboRole.SelectedItem = user.Role

        ' Show password note for edit mode
        lblPasswordNote.Visible = True

        ' Update form title
        Label1.Text = "Update User"
        Me.Text = "Edit User Form"
    End Sub

    Private Sub InitializeControllers()
        Dim settingController As New SettingController()
        _config = settingController.LoadConfiguration()
        controller = New UserController(_config)
    End Sub

    Private Sub InitializeForm()
        ' Set default role
        cboRole.SelectedIndex = 0 ' "user" as default
    End Sub

    Private Sub chkShowPassword_CheckedChanged(sender As Object, e As EventArgs) Handles chkShowPassword.CheckedChanged
        txtPassword.UseSystemPasswordChar = Not chkShowPassword.Checked
        txtConfirmPassword.UseSystemPasswordChar = Not chkShowPassword.Checked
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        ' Validation
        If String.IsNullOrWhiteSpace(txtUsername.Text) Then
            MessageBox.Show("Username tidak boleh kosong", "Validation",
                          MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtUsername.Focus()
            Return
        End If

        If String.IsNullOrWhiteSpace(txtEmail.Text) Then
            MessageBox.Show("Email tidak boleh kosong", "Validation",
                          MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtEmail.Focus()
            Return
        End If

        ' Validate email format
        If Not IsValidEmail(txtEmail.Text) Then
            MessageBox.Show("Format email tidak valid", "Validation",
                          MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtEmail.Focus()
            Return
        End If

        If cboRole.SelectedItem Is Nothing Then
            MessageBox.Show("Pilih role untuk user", "Validation",
                          MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboRole.Focus()
            Return
        End If

        ' Password validation (only for new user or if password is being changed)
        If Not isEditMode Then
            ' For new user, password is required
            If String.IsNullOrWhiteSpace(txtPassword.Text) Then
                MessageBox.Show("Password tidak boleh kosong", "Validation",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtPassword.Focus()
                Return
            End If

            If txtPassword.Text.Length < 6 Then
                MessageBox.Show("Password minimal 6 karakter", "Validation",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtPassword.Focus()
                Return
            End If

            If txtPassword.Text <> txtConfirmPassword.Text Then
                MessageBox.Show("Password dan Confirm Password tidak cocok", "Validation",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtConfirmPassword.Focus()
                Return
            End If
        Else
            ' For edit mode, only validate if password is not empty
            If Not String.IsNullOrWhiteSpace(txtPassword.Text) Then
                If txtPassword.Text.Length < 6 Then
                    MessageBox.Show("Password minimal 6 karakter", "Validation",
                                  MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    txtPassword.Focus()
                    Return
                End If

                If txtPassword.Text <> txtConfirmPassword.Text Then
                    MessageBox.Show("Password dan Confirm Password tidak cocok", "Validation",
                                  MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    txtConfirmPassword.Focus()
                    Return
                End If
            End If
        End If

        Try
            Dim user As New UserModel With {
                .Username = txtUsername.Text.Trim(),
                .Email = txtEmail.Text.Trim(),
                .Role = cboRole.SelectedItem.ToString()
            }

            Dim success As Boolean
            If Not isEditMode Then
                ' Create new user
                success = controller.CreateUser(user, txtPassword.Text)
            Else
                ' Update existing user
                user.UserId = editedUserId
                
                ' Pass new password only if it's not empty
                Dim newPassword As String = If(String.IsNullOrWhiteSpace(txtPassword.Text), Nothing, txtPassword.Text)
                success = controller.UpdateUser(user, newPassword)
            End If

            If success Then
                MessageBox.Show("User berhasil disimpan", "Success",
                              MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.DialogResult = DialogResult.OK
                Me.Close()
            End If
        Catch ex As Exception
            MessageBox.Show($"Error saving user: {ex.Message}", "Error",
                          MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Function IsValidEmail(email As String) As Boolean
        Try
            Dim addr = New System.Net.Mail.MailAddress(email)
            Return addr.Address = email
        Catch
            Return False
        End Try
    End Function
End Class
