Imports WinFormsApp_Latihan.Models
Imports WinFormsApp_Latihan.Controllers

Public Class FormUserList
    Private controller As UserController
    Private _config As ConfigModel

    Private Sub FormUserList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        InitializeControllers()
        LoadGrid()
    End Sub

    Private Sub InitializeControllers()
        Dim settingController As New SettingController()
        _config = settingController.LoadConfiguration()
        controller = New UserController(_config)
    End Sub

    Private Sub LoadGrid()
        Try
            DataGridView1.DataSource = controller.LoadUsers()
        Catch ex As Exception
            MessageBox.Show($"Error loading users: {ex.Message}", "Error",
                          MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        If DataGridView1.DataSource IsNot Nothing Then
            Dim dv As DataView = CType(DataGridView1.DataSource, DataTable).DefaultView
            dv.RowFilter = "username LIKE '%" & txtSearch.Text & "%' OR email LIKE '%" & txtSearch.Text & "%'"
        End If
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Dim frm As New FormUserInput()
        If frm.ShowDialog() = DialogResult.OK Then
            LoadGrid()
        End If
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        If DataGridView1.SelectedRows.Count = 0 Then
            MessageBox.Show("Pilih user yang akan diedit", "Warning",
                          MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Try
            Dim userId As Integer = CInt(DataGridView1.SelectedRows(0).Cells("user_id").Value)
            Dim user_selected As UserModel = controller.GetUser(userId)

            If user_selected IsNot Nothing Then
                Dim frm As New FormUserInput(user_selected)
                If frm.ShowDialog() = DialogResult.OK Then
                    LoadGrid()
                End If
            End If
        Catch ex As Exception
            MessageBox.Show($"Error loading user: {ex.Message}", "Error",
                          MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If DataGridView1.SelectedRows.Count = 0 Then
            MessageBox.Show("Pilih user yang akan dihapus", "Warning",
                          MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Try
            Dim userId As Integer = CInt(DataGridView1.SelectedRows(0).Cells("user_id").Value)
            Dim username As String = DataGridView1.SelectedRows(0).Cells("username").Value.ToString()
            Dim role As String = DataGridView1.SelectedRows(0).Cells("role").Value.ToString()

            Dim result = MessageBox.Show(
                $"Apakah Anda yakin ingin menghapus user '{username}' ({role})?{vbCrLf}{vbCrLf}" &
                $"Tindakan ini tidak dapat dibatalkan!",
                "Konfirmasi Hapus",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning)

            If result = DialogResult.Yes Then
                If controller.DeleteUser(userId) Then
                    MessageBox.Show("User berhasil dihapus", "Success",
                                  MessageBoxButtons.OK, MessageBoxIcon.Information)
                    LoadGrid()
                End If
            End If
        Catch ex As Exception
            MessageBox.Show($"Error deleting user: {ex.Message}", "Error",
                          MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class
