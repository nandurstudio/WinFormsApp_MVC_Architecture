Imports MySql.Data.MySqlClient
Imports WinFormsApp_Latihan.Models

Namespace Models
   Public Class ItemModel
      Public Property Id As Integer
      Public Property ItemID As String
      Public Property ItemDesc As String
      Public Property ItemCate As Integer
      Public Property Unit As String
      Public Property SalesPrice As Decimal
      Public Property MinStock As Integer
      Public Property CreatedAt As DateTime
      Public Property UpdatedAt As DateTime

      Public Sub New()
      End Sub

      Public Sub New(id As Integer, itemID As String, itemDesc As String, itemCate As Integer, unit As String, salesPrice As Decimal, minStock As Integer)
         Me.Id = id
         Me.ItemID = itemID
         Me.ItemDesc = itemDesc
         Me.ItemCate = itemCate
         Me.Unit = unit
         Me.SalesPrice = salesPrice
         Me.MinStock = minStock
      End Sub
   End Class

   ' Item Data Access - should be used via ItemController
   Public Class ItemDataAccess
      Private ReadOnly _config As ConfigModel

      Public Sub New(config As ConfigModel)
         _config = config
      End Sub

      Public Function GetAll() As DataTable
         Dim dt As New DataTable()
         Dim query As String = "SELECT items.id, items.itemID, items.itemDesc, items.itemCate, " &
                                 "category.categoryDesc, items.unit, items.salesPrice, items.minStock, " &
                                 "items.created_at, items.updated_at " &
                                 "FROM items LEFT JOIN category ON items.itemCate = category.id " &
                                 "ORDER BY items.updated_at DESC"

         Using conn As New MySqlConnection(_config.GetConnectionString())
            conn.Open()
            Using cmd As New MySqlCommand(query, conn)
               dt.Load(cmd.ExecuteReader())
            End Using
         End Using

         Return dt
      End Function

      Public Function GetById(id As Integer) As ItemModel
         Dim query As String = "SELECT * FROM items WHERE id=@id"

         Using conn As New MySqlConnection(_config.GetConnectionString())
            conn.Open()
            Using cmd As New MySqlCommand(query, conn)
               cmd.Parameters.AddWithValue("@id", id)

               Using reader As MySqlDataReader = cmd.ExecuteReader()
                  If reader.Read() Then
                     Return New ItemModel(
                                Convert.ToInt32(reader("id")),
                                reader("itemID").ToString(),
                                reader("itemDesc").ToString(),
                                Convert.ToInt32(reader("itemCate")),
                                reader("unit").ToString(),
                                Convert.ToDecimal(reader("salesPrice")),
                                Convert.ToInt32(reader("minStock"))
                            )
                  End If
               End Using
            End Using
         End Using

         Return Nothing
      End Function

      Public Function Create(item As ItemModel) As Boolean
         Dim query As String = "INSERT INTO items (itemID, itemDesc, itemCate, unit, salesPrice, minStock) " &
                                 "VALUES (@itemID, @itemDesc, @itemCate, @unit, @salesPrice, @minStock)"

         Using conn As New MySqlConnection(_config.GetConnectionString())
            conn.Open()
            Using cmd As New MySqlCommand(query, conn)
               cmd.Parameters.AddWithValue("@itemID", item.ItemID)
               cmd.Parameters.AddWithValue("@itemDesc", item.ItemDesc)
               cmd.Parameters.AddWithValue("@itemCate", item.ItemCate)
               cmd.Parameters.AddWithValue("@unit", item.Unit)
               cmd.Parameters.AddWithValue("@salesPrice", item.SalesPrice)
               cmd.Parameters.AddWithValue("@minStock", item.MinStock)

               Return cmd.ExecuteNonQuery() > 0
            End Using
         End Using
      End Function

      Public Function Update(item As ItemModel) As Boolean
         Dim query As String = "UPDATE items SET itemID=@itemID, itemDesc=@itemDesc, itemCate=@itemCate, " &
                                 "unit=@unit, salesPrice=@salesPrice, minStock=@minStock WHERE id=@id"

         Using conn As New MySqlConnection(_config.GetConnectionString())
            conn.Open()
            Using cmd As New MySqlCommand(query, conn)
               cmd.Parameters.AddWithValue("@itemID", item.ItemID)
               cmd.Parameters.AddWithValue("@itemDesc", item.ItemDesc)
               cmd.Parameters.AddWithValue("@itemCate", item.ItemCate)
               cmd.Parameters.AddWithValue("@unit", item.Unit)
               cmd.Parameters.AddWithValue("@salesPrice", item.SalesPrice)
               cmd.Parameters.AddWithValue("@minStock", item.MinStock)
               cmd.Parameters.AddWithValue("@id", item.Id)

               Return cmd.ExecuteNonQuery() > 0
            End Using
         End Using
      End Function

      Public Function Delete(id As Integer) As Boolean
         Dim query As String = "DELETE FROM items WHERE id=@id"

         Using conn As New MySqlConnection(_config.GetConnectionString())
            conn.Open()
            Using cmd As New MySqlCommand(query, conn)
               cmd.Parameters.AddWithValue("@id", id)
               Return cmd.ExecuteNonQuery() > 0
            End Using
         End Using
      End Function

      Public Function GenerateItemCode() As String
         Dim newCode As String = "B0001"
         Dim query As String = "SELECT itemID FROM items ORDER BY itemID DESC LIMIT 1"

         Try
            Using conn As New MySqlConnection(_config.GetConnectionString())
               conn.Open()
               Using cmd As New MySqlCommand(query, conn)
                  Dim lastCode As Object = cmd.ExecuteScalar()

                  If lastCode IsNot Nothing AndAlso Not IsDBNull(lastCode) Then
                     Dim numberPart As Integer = CInt(Mid(lastCode.ToString(), 2))
                     numberPart += 1
                     newCode = "B" & numberPart.ToString("0000")
                  End If
               End Using
            End Using
         Catch ex As Exception
            Throw New Exception($"Error generating item code: {ex.Message}", ex)
         End Try

         Return newCode
      End Function
   End Class
End Namespace
