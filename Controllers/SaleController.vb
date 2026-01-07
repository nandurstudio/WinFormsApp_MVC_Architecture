Imports WinFormsApp_Latihan.Models

Namespace Controllers
    Public Class SaleController
        Private ReadOnly _config As ConfigModel
        Private ReadOnly _dataAccess As SaleDataAccess

        Public Sub New(config As ConfigModel)
            _config = config
            _dataAccess = New SaleDataAccess(_config)
        End Sub

        Public Function SaveNew(sale As SaleModel) As Boolean
            If Not ValidateSale(sale) Then Return False

            Try
                Return _dataAccess.Insert(sale)
            Catch ex As Exception
                Throw New Exception($"Error saving sale: {ex.Message}", ex)
            End Try
        End Function

        Public Function GenerateCode() As String
            Try
                Return _dataAccess.GenerateTransactionCode()
            Catch ex As Exception
                Throw New Exception($"Error generating transaction code: {ex.Message}", ex)
            End Try
        End Function

        Private Function ValidateSale(sale As SaleModel) As Boolean
            If String.IsNullOrWhiteSpace(sale.IdTrans) Then
                MessageBox.Show("Transaction ID tidak boleh kosong", "Validation Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return False
            End If

            If sale.Details Is Nothing OrElse sale.Details.Count = 0 Then
                MessageBox.Show("Tidak ada detail transaksi", "Validation Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return False
            End If

            For Each detail In sale.Details
                If detail.Qty <= 0 Then
                    MessageBox.Show("Quantity harus lebih dari 0", "Validation Error",
                                  MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Return False
                End If

                If detail.Price <= 0 Then
                    MessageBox.Show("Harga harus lebih dari 0", "Validation Error",
                                  MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Return False
                End If
            Next

            Return True
        End Function
    End Class
End Namespace
