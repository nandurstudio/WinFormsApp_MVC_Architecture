Imports WinFormsApp_Latihan.Models

Namespace Controllers
    Public Class CategoryController
        Private ReadOnly _config As ConfigModel
        Private ReadOnly _dataAccess As CategoryDataAccess

        Public Sub New(config As ConfigModel)
            _config = config
            _dataAccess = New CategoryDataAccess(_config)
        End Sub

        Public Function LoadCategory() As DataTable
            Try
                Return _dataAccess.GetAll()
            Catch ex As Exception
                Throw New Exception($"Error loading categories: {ex.Message}", ex)
            End Try
        End Function

        Public Function GetCategory(id As Integer) As CategoryModel
            Try
                Return _dataAccess.GetById(id)
            Catch ex As Exception
                Throw New Exception($"Error getting category: {ex.Message}", ex)
            End Try
        End Function

        Public Function Create(category As CategoryModel) As Boolean
            If Not ValidateCategory(category) Then Return False

            Try
                Return _dataAccess.Create(category)
            Catch ex As Exception
                Throw New Exception($"Error creating category: {ex.Message}", ex)
            End Try
        End Function

        Public Function Update(category As CategoryModel) As Boolean
            If Not ValidateCategory(category) Then Return False

            Try
                Return _dataAccess.Update(category)
            Catch ex As Exception
                Throw New Exception($"Error updating category: {ex.Message}", ex)
            End Try
        End Function

        Public Function Delete(id As Integer) As Boolean
            Try
                Return _dataAccess.Delete(id)
            Catch ex As Exception
                Throw New Exception($"Error deleting category: {ex.Message}", ex)
            End Try
        End Function

        Private Function ValidateCategory(category As CategoryModel) As Boolean
            If String.IsNullOrWhiteSpace(category.CategoryDesc) Then
                MessageBox.Show("Category description tidak boleh kosong", "Validation Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return False
            End If

            Return True
        End Function
    End Class
End Namespace
