Imports WinFormsApp_Latihan.Models
Imports WinFormsApp_Latihan.Controllers
Imports MySql.Data.MySqlClient

Public Class FormCategoryInput
    Private controller As CategoryController
    Private _config As ConfigModel
    Private editedID As Integer = -1

    Sub New()
        InitializeComponent()
        InitializeControllers()
    End Sub

    Sub New(category As CategoryModel)
        InitializeComponent()
        InitializeControllers()

        With category
            editedID = .Id
            txtCategoryDesc.Text = .CategoryDesc
        End With

        ' Check if category is being used by items
        Dim itemCount As Integer = GetItemCountByCategory(editedID)
        If itemCount > 0 Then
         lblWarning.Text = $"⚠ WARNING: This category is currently used by {itemCount} item(s)"
         lblWarning.Visible = True
        End If
    End Sub

    Private Sub InitializeControllers()
        Dim settingController As New SettingController()
        _config = settingController.LoadConfiguration()
        controller = New CategoryController(_config)
    End Sub

    Private Function GetItemCountByCategory(categoryId As Integer) As Integer
        Try
            Using conn As New MySqlConnection(_config.GetConnectionString())
                conn.Open()
                Dim query As String = "SELECT COUNT(*) FROM items WHERE itemCate = @categoryId"
                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@categoryId", categoryId)
                    Return Convert.ToInt32(cmd.ExecuteScalar())
                End Using
            End Using
        Catch ex As Exception
            Return 0
        End Try
    End Function

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If String.IsNullOrWhiteSpace(txtCategoryDesc.Text) Then
            MessageBox.Show("Category description tidak boleh kosong", "Validation",
                          MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtCategoryDesc.Focus()
            Return
        End If

        Try
            Dim category As New CategoryModel With {
                .CategoryDesc = txtCategoryDesc.Text.Trim()
            }

            Dim success As Boolean
            If editedID = -1 Then
                success = controller.Create(category)
            Else
                category.Id = editedID
                
                ' Confirm if category is being used
                Dim itemCount As Integer = GetItemCountByCategory(editedID)
                If itemCount > 0 Then
                    Dim result = MessageBox.Show(
                        $"This category is currently used by {itemCount} item(s).{vbCrLf}{vbCrLf}" &
                        $"Changing this category will affect all those items.{vbCrLf}{vbCrLf}" &
                        $"Are you sure you want to continue?",
                        "Confirmation",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning)
                    
                    If result = DialogResult.No Then
                        Return
                    End If
                End If
                
                success = controller.Update(category)
            End If

            If success Then
                MessageBox.Show("Category berhasil disimpan", "Success",
                              MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.DialogResult = DialogResult.OK
                Me.Close()
            End If
        Catch ex As Exception
            MessageBox.Show($"Error saving category: {ex.Message}", "Error",
                          MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class
