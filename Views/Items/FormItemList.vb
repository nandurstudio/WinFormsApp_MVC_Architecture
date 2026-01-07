Imports WinFormsApp_Latihan.Models
Imports WinFormsApp_Latihan.Controllers
Imports System.Globalization

Public Class FormItemList
   Private controller As ItemController
   Private _config As ConfigModel
   Private indonesianCulture As CultureInfo

   Private Sub FormItemList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
      InitializeControllers()
      InitializeIndonesianCulture()
      ConfigureDataGridView()
      LoadGrid()
   End Sub

   Private Sub InitializeControllers()
      Dim settingController As New SettingController()
      _config = settingController.LoadConfiguration()
      controller = New ItemController(_config)
   End Sub

   Private Sub InitializeIndonesianCulture()
      indonesianCulture = New CultureInfo("id-ID")
      indonesianCulture.NumberFormat.CurrencyDecimalDigits = 2
      indonesianCulture.NumberFormat.CurrencyDecimalSeparator = ","
      indonesianCulture.NumberFormat.CurrencyGroupSeparator = "."
      indonesianCulture.NumberFormat.CurrencySymbol = "Rp"
   End Sub

   Private Sub ConfigureDataGridView()
      AddHandler DataGridView1.CellFormatting, AddressOf DataGridView1_CellFormatting
   End Sub

   Private Sub DataGridView1_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs)
      If DataGridView1.Columns(e.ColumnIndex).Name = "salesPrice" Then
         If e.Value IsNot Nothing AndAlso IsNumeric(e.Value) Then
            Dim price As Decimal = Convert.ToDecimal(e.Value)
            e.Value = price.ToString("C2", indonesianCulture)
            e.FormattingApplied = True
         End If
      End If
   End Sub

   Private Sub LoadGrid()
      Try
         DataGridView1.DataSource = controller.LoadItems()
      Catch ex As Exception
         MessageBox.Show($"Error loading items: {ex.Message}", "Error",
                          MessageBoxButtons.OK, MessageBoxIcon.Error)
      End Try
   End Sub

   Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
      If DataGridView1.DataSource IsNot Nothing Then
         Dim dv As DataView = CType(DataGridView1.DataSource, DataTable).DefaultView
         dv.RowFilter = "itemDesc LIKE '%" & txtSearch.Text & "%' OR categoryDesc LIKE '%" & txtSearch.Text & "%'"
      End If
   End Sub

   Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
      Dim frm As New FormItemInput()
      If frm.ShowDialog() = DialogResult.OK Then
         LoadGrid()
      End If
   End Sub

   Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
      If DataGridView1.SelectedRows.Count = 0 Then
         MessageBox.Show("Pilih item yang akan dihapus", "Warning",
                          MessageBoxButtons.OK, MessageBoxIcon.Warning)
         Return
      End If

      Dim id = CInt(DataGridView1.SelectedRows(0).Cells("id").Value)

      If MessageBox.Show("Hapus item ini?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
         Try
            If controller.Delete(id) Then
               MessageBox.Show("Item berhasil dihapus", "Success",
                                  MessageBoxButtons.OK, MessageBoxIcon.Information)
               LoadGrid()
            End If
         Catch ex As Exception
            MessageBox.Show($"Error deleting item: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error)
         End Try
      End If
   End Sub

   Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
      If DataGridView1.SelectedRows.Count = 0 Then
         MessageBox.Show("Pilih item yang akan diedit", "Warning",
                          MessageBoxButtons.OK, MessageBoxIcon.Warning)
         Return
      End If

      Try
         Dim id As Integer = CInt(DataGridView1.SelectedRows(0).Cells("id").Value)
         Dim item_selected As ItemModel = controller.GetItemById(id)

         If item_selected IsNot Nothing Then
            Dim frm As New FormItemInput(item_selected)
            If frm.ShowDialog() = DialogResult.OK Then
               LoadGrid()
            End If
         End If
      Catch ex As Exception
         MessageBox.Show($"Error loading item: {ex.Message}", "Error",
                          MessageBoxButtons.OK, MessageBoxIcon.Error)
      End Try
   End Sub
End Class