Imports WinFormsApp_Latihan.Models
Imports WinFormsApp_Latihan.Controllers

Public Class FormItemInput
   Private controller As ItemController
   Private categoryController As CategoryController
   Private _config As ConfigModel
   Private editedID As Integer = -1

   Sub New()
      InitializeComponent()
      InitializeControllers()
      loadCategoryList()
      txtItemId.Text = controller.GenerateItemCode()
      txtItemId.Enabled = False
   End Sub

   Sub New(item As ItemModel)
      InitializeComponent()
      InitializeControllers()
      loadCategoryList()

      Dim category As CategoryModel = categoryController.GetCategory(item.ItemCate)
      If category IsNot Nothing Then
         Dim index As Integer = cboItemCate.FindStringExact(category.CategoryDesc)
         If index >= 0 Then
            cboItemCate.SelectedIndex = index
         End If
      End If

      With item
         editedID = .Id
         txtItemId.Text = .ItemID
         txtItemDesc.Text = .ItemDesc
         cboItemCate.SelectedValue = .ItemCate
         txtUnit.Text = .Unit
         txtSalesPrice.Text = .SalesPrice.ToString()
         txtMinStock.Text = .MinStock.ToString()
      End With
   End Sub

   Private Sub InitializeControllers()
      Dim settingController As New SettingController()
      _config = settingController.LoadConfiguration()
      controller = New ItemController(_config)
      categoryController = New CategoryController(_config)
   End Sub

   Sub loadCategoryList()
      Try
         Dim dt As DataTable = categoryController.LoadCategory()

         ' Add special row for adding new category
         Dim newRow As DataRow = dt.NewRow()
         newRow("id") = 999
         newRow("categoryDesc") = "--Add category--"
         dt.Rows.Add(newRow)

         cboItemCate.DataSource = dt
         cboItemCate.DisplayMember = "categoryDesc"
         cboItemCate.ValueMember = "id"
         cboItemCate.SelectedIndex = -1
      Catch ex As Exception
         MessageBox.Show($"Error loading categories: {ex.Message}", "Error",
                       MessageBoxButtons.OK, MessageBoxIcon.Error)
      End Try
   End Sub

   Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
      Try
         Dim item As New ItemModel With {
             .ItemID = txtItemId.Text,
             .ItemDesc = txtItemDesc.Text,
             .Unit = txtUnit.Text,
             .SalesPrice = CDec(txtSalesPrice.Text),
             .MinStock = CInt(txtMinStock.Text),
             .ItemCate = Convert.ToInt32(cboItemCate.SelectedValue)
         }

         Dim success As Boolean
         If editedID = -1 Then
            success = controller.Create(item)
         Else
            item.Id = editedID
            success = controller.Update(item)
         End If

         If success Then
            MessageBox.Show("Item berhasil disimpan", "Success",
                          MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.DialogResult = DialogResult.OK
            Me.Close()
         End If
      Catch ex As Exception
         MessageBox.Show($"Error saving item: {ex.Message}", "Error",
                       MessageBoxButtons.OK, MessageBoxIcon.Error)
      End Try
   End Sub

   Private Sub cboItemCate_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboItemCate.SelectedIndexChanged
      If cboItemCate.SelectedValue IsNot Nothing AndAlso
         cboItemCate.SelectedValue.ToString() = "999" Then
         Dim frm As New FormCategoryInput()
         If frm.ShowDialog() = DialogResult.OK Then
            loadCategoryList()
         Else
            cboItemCate.SelectedIndex = -1
         End If
      End If
   End Sub
End Class