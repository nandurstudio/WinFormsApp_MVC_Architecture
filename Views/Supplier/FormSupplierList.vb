Imports WinFormsApp_Latihan.Models
Imports WinFormsApp_Latihan.Controllers

Public Class FormSupplierList
    Private controller As SupplierController
    Private _config As ConfigModel

    Private Sub FormSupplierList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        InitializeControllers()
        LoadGrid()
    End Sub

    Private Sub InitializeControllers()
        Dim settingController As New SettingController()
        _config = settingController.LoadConfiguration()
        controller = New SupplierController(_config)
    End Sub

    Private Sub LoadGrid()
        Try
            DataGridView1.DataSource = controller.LoadSuppliers()
        Catch ex As Exception
            MessageBox.Show($"Error loading suppliers: {ex.Message}", "Error",
                          MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        If DataGridView1.DataSource IsNot Nothing Then
            Dim dv As DataView = CType(DataGridView1.DataSource, DataTable).DefaultView
            dv.RowFilter = "supplierName LIKE '%" & txtSearch.Text & "%' OR city LIKE '%" & txtSearch.Text & "%'"
        End If
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Dim frm As New FormSupplierInput()
        If frm.ShowDialog() = DialogResult.OK Then
            LoadGrid()
        End If
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        If DataGridView1.SelectedRows.Count = 0 Then
            MessageBox.Show("Pilih supplier yang akan diedit", "Warning",
                          MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Try
            Dim id As Integer = CInt(DataGridView1.SelectedRows(0).Cells("id").Value)
            Dim supplier_selected As SupplierModel = controller.GetSupplier(id)

            If supplier_selected IsNot Nothing Then
                Dim frm As New FormSupplierInput(supplier_selected)
                If frm.ShowDialog() = DialogResult.OK Then
                    LoadGrid()
                End If
            End If
        Catch ex As Exception
            MessageBox.Show($"Error loading supplier: {ex.Message}", "Error",
                          MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If DataGridView1.SelectedRows.Count = 0 Then
            MessageBox.Show("Pilih supplier yang akan dihapus", "Warning",
                          MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Try
            Dim id As Integer = CInt(DataGridView1.SelectedRows(0).Cells("id").Value)
            Dim supplierName As String = DataGridView1.SelectedRows(0).Cells("supplierName").Value.ToString()

            Dim result = MessageBox.Show(
                $"Apakah Anda yakin ingin menghapus supplier '{supplierName}'?{vbCrLf}{vbCrLf}" &
                $"Tindakan ini tidak dapat dibatalkan!",
                "Konfirmasi Hapus",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning)

            If result = DialogResult.Yes Then
                If controller.Delete(id) Then
                    MessageBox.Show("Supplier berhasil dihapus", "Success",
                                  MessageBoxButtons.OK, MessageBoxIcon.Information)
                    LoadGrid()
                End If
            End If
        Catch ex As Exception
            MessageBox.Show($"Error deleting supplier: {ex.Message}", "Error",
                          MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class
