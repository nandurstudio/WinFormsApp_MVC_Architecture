Imports WinFormsApp_Latihan.Models

Namespace Controllers
    Public Class ItemController
        Private ReadOnly _config As ConfigModel
        Private ReadOnly _dataAccess As ItemDataAccess

        Public Sub New(config As ConfigModel)
            _config = config
            _dataAccess = New ItemDataAccess(_config)
        End Sub

        Public Function LoadItems() As DataTable
            Try
                Return _dataAccess.GetAll()
            Catch ex As Exception
                Throw New Exception($"Error loading items: {ex.Message}", ex)
            End Try
        End Function

        Public Function GetItemById(id As Integer) As ItemModel
            Try
                Return _dataAccess.GetById(id)
            Catch ex As Exception
                Throw New Exception($"Error getting item: {ex.Message}", ex)
            End Try
        End Function

        Public Function Create(item As ItemModel) As Boolean
            If Not ValidateItem(item) Then Return False

            Try
                Return _dataAccess.Create(item)
            Catch ex As Exception
                Throw New Exception($"Error creating item: {ex.Message}", ex)
            End Try
        End Function

        Public Function Update(item As ItemModel) As Boolean
            If Not ValidateItem(item) Then Return False

            Try
                Return _dataAccess.Update(item)
            Catch ex As Exception
                Throw New Exception($"Error updating item: {ex.Message}", ex)
            End Try
        End Function

        Public Function Delete(id As Integer) As Boolean
            Try
                Return _dataAccess.Delete(id)
            Catch ex As Exception
                Throw New Exception($"Error deleting item: {ex.Message}", ex)
            End Try
        End Function

        Public Function GenerateItemCode() As String
            Try
                Return _dataAccess.GenerateItemCode()
            Catch ex As Exception
                Throw New Exception($"Error generating item code: {ex.Message}", ex)
            End Try
        End Function

        Private Function ValidateItem(item As ItemModel) As Boolean
            If String.IsNullOrWhiteSpace(item.ItemID) Then
                MessageBox.Show("Item ID tidak boleh kosong", "Validation Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return False
            End If

            If String.IsNullOrWhiteSpace(item.ItemDesc) Then
                MessageBox.Show("Item description tidak boleh kosong", "Validation Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return False
            End If

            If item.SalesPrice < 0 Then
                MessageBox.Show("Harga tidak boleh negatif", "Validation Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return False
            End If

            If item.MinStock < 0 Then
                MessageBox.Show("Minimum stock tidak boleh negatif", "Validation Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return False
            End If

            Return True
        End Function
    End Class
End Namespace
