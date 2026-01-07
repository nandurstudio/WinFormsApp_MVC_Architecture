Imports MySql.Data.MySqlClient
Imports WinFormsApp_Latihan.Models

Namespace Models
   Public Class SaleModel
      Public Property IdTrans As String
      Public Property SaleDate As DateTime
      Public Property TotalSale As Decimal
      Public Property Details As List(Of SaleDetailModel)

      Public Sub New()
         Details = New List(Of SaleDetailModel)()
      End Sub

      Public Sub New(idTrans As String, saleDate As DateTime, totalSale As Decimal)
         Me.IdTrans = idTrans
         Me.SaleDate = saleDate
         Me.TotalSale = totalSale
         Me.Details = New List(Of SaleDetailModel)()
      End Sub
   End Class

   Public Class SaleDetailModel
      Public Property Id As Integer
      Public Property IdSale As String
      Public Property ProductId As String
      Public Property Qty As Integer
      Public Property Price As Decimal
      Public Property Subtotal As Decimal

      Public Sub New()
      End Sub

      Public Sub New(productId As String, qty As Integer, price As Decimal)
         Me.ProductId = productId
         Me.Qty = qty
         Me.Price = price
         Me.Subtotal = qty * price
      End Sub
   End Class

   ' Sale Data Access - should be used via SaleController
   Public Class SaleDataAccess
      Private ReadOnly _config As ConfigModel

      Public Sub New(config As ConfigModel)
         _config = config
      End Sub

      Public Function Insert(sale As SaleModel) As Boolean
         Using conn As New MySqlConnection(_config.GetConnectionString())
            conn.Open()

            Using transaction As MySqlTransaction = conn.BeginTransaction()
               Try
                  ' Hitung total dari details
                  Dim totalAmount As Decimal = 0
                  For Each detail In sale.Details
                     totalAmount += detail.Subtotal
                  Next

                  ' Insert Master dengan totalAmount
                  Dim cmdMaster As New MySqlCommand(
                            "INSERT INTO sale (idTrans, saleDate, totalAmount) VALUES (@idTrans, @saleDate, @totalAmount)",
                            conn, transaction)

                  cmdMaster.Parameters.AddWithValue("@idTrans", sale.IdTrans)
                  cmdMaster.Parameters.AddWithValue("@saleDate", sale.SaleDate)
                  cmdMaster.Parameters.AddWithValue("@totalAmount", totalAmount)
                  cmdMaster.ExecuteNonQuery()

                  ' Insert Detail
                  For Each detail In sale.Details
                     Dim cmdDetail As New MySqlCommand(
                                "INSERT INTO saledetail (idSale, itemID, qtySale, price, subtotal) " &
                                "VALUES (@idSale, @itemID, @qtySale, @price, @subtotal)",
                                conn, transaction)

                     cmdDetail.Parameters.AddWithValue("@idSale", sale.IdTrans)
                     cmdDetail.Parameters.AddWithValue("@itemID", detail.ProductId)
                     cmdDetail.Parameters.AddWithValue("@qtySale", detail.Qty)
                     cmdDetail.Parameters.AddWithValue("@price", detail.Price)
                     cmdDetail.Parameters.AddWithValue("@subtotal", detail.Subtotal)
                     cmdDetail.ExecuteNonQuery()
                  Next

                  transaction.Commit()
                  Return True

               Catch ex As Exception
                  transaction.Rollback()
                  Throw New Exception($"Error inserting sale: {ex.Message}", ex)
               End Try
            End Using
         End Using
      End Function

      Public Function GenerateTransactionCode() As String
         Dim newCode As String = "TRX0001"

         Try
            Using conn As New MySqlConnection(_config.GetConnectionString())
               conn.Open()
               Using cmd As New MySqlCommand("SELECT idTrans FROM sale ORDER BY idTrans DESC LIMIT 1", conn)
                  Using reader As MySqlDataReader = cmd.ExecuteReader()
                     If reader.Read() Then
                        Dim lastCode As String = reader("idTrans").ToString()
                        Dim numberPart As Integer = CInt(lastCode.Substring(3)) + 1
                        newCode = "TRX" & numberPart.ToString("0000")
                     End If
                  End Using
               End Using
            End Using
         Catch ex As Exception
            Throw New Exception($"Error generating transaction code: {ex.Message}", ex)
         End Try

         Return newCode
      End Function
   End Class
End Namespace
