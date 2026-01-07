Imports WinFormsApp_Latihan.Models
Imports WinFormsApp_Latihan.Controllers

Public Class FormCategoryList
   Private controller As CategoryController
   Private _config As ConfigModel

   Private Sub FormCategoryList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
      InitializeControllers()
      LoadGrid()
   End Sub

   Private Sub InitializeControllers()
      Dim settingController As New SettingController()
      _config = settingController.LoadConfiguration()
      controller = New CategoryController(_config)
   End Sub

   Private Sub LoadGrid()
      Try
         DataGridView1.DataSource = controller.LoadCategory()
      Catch ex As Exception
         MessageBox.Show($"Error loading categories: {ex.Message}", "Error",
                       MessageBoxButtons.OK, MessageBoxIcon.Error)
      End Try
   End Sub

   Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
      If DataGridView1.DataSource IsNot Nothing Then
         Dim dv As DataView = CType(DataGridView1.DataSource, DataTable).DefaultView
         dv.RowFilter = "categoryDesc LIKE '%" & txtSearch.Text & "%'"
      End If
   End Sub

   Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
      Dim frm As New FormCategoryInput()
      If frm.ShowDialog() = DialogResult.OK Then
         LoadGrid()
      End If
   End Sub

   Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
      If DataGridView1.SelectedRows.Count = 0 Then
         MessageBox.Show("Pilih category yang akan diedit", "Warning",
                       MessageBoxButtons.OK, MessageBoxIcon.Warning)
         Return
      End If

      Try
         Dim id As Integer = CInt(DataGridView1.SelectedRows(0).Cells("id").Value)
         Dim category_selected As CategoryModel = controller.GetCategory(id)

         If category_selected IsNot Nothing Then
            Dim frm As New FormCategoryInput(category_selected)
            If frm.ShowDialog() = DialogResult.OK Then
               LoadGrid()
            End If
         End If
      Catch ex As Exception
         MessageBox.Show($"Error loading category: {ex.Message}", "Error",
                       MessageBoxButtons.OK, MessageBoxIcon.Error)
      End Try
   End Sub
End Class
