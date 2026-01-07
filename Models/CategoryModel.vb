Imports MySql.Data.MySqlClient
Imports WinFormsApp_Latihan.Models

Namespace Models
   Public Class CategoryModel
      Public Property Id As Integer
      Public Property CategoryDesc As String
      Public Property CreatedAt As DateTime
      Public Property UpdatedAt As DateTime

      ' Constructor for data binding
      Public Sub New()
      End Sub

      Public Sub New(id As Integer, categoryDesc As String)
         Me.Id = id
         Me.CategoryDesc = categoryDesc
      End Sub
   End Class

   ' Category Data Access - should be used via CategoryController
   Public Class CategoryDataAccess
      Private ReadOnly _config As ConfigModel

      Public Sub New(config As ConfigModel)
         _config = config
      End Sub

      Public Function GetAll() As DataTable
         Dim dt As New DataTable()
         Dim query As String = "SELECT id, categoryDesc, created_at, updated_at FROM category ORDER BY updated_at DESC"

         Using conn As New MySqlConnection(_config.GetConnectionString())
            conn.Open()
            Using cmd As New MySqlCommand(query, conn)
               dt.Load(cmd.ExecuteReader())
            End Using
         End Using

         Return dt
      End Function

      Public Function GetById(id As Integer) As CategoryModel
         Dim query As String = "SELECT id, categoryDesc FROM category WHERE id=@id"

         Using conn As New MySqlConnection(_config.GetConnectionString())
            conn.Open()
            Using cmd As New MySqlCommand(query, conn)
               cmd.Parameters.AddWithValue("@id", id)

               Using reader As MySqlDataReader = cmd.ExecuteReader()
                  If reader.Read() Then
                     Return New CategoryModel(
                                Convert.ToInt32(reader("id")),
                                reader("categoryDesc").ToString()
                            )
                  End If
               End Using
            End Using
         End Using

         Return Nothing
      End Function

      Public Function Create(category As CategoryModel) As Boolean
         Dim query As String = "INSERT INTO category (categoryDesc) VALUES (@categoryDesc)"

         Using conn As New MySqlConnection(_config.GetConnectionString())
            conn.Open()
            Using cmd As New MySqlCommand(query, conn)
               cmd.Parameters.AddWithValue("@categoryDesc", category.CategoryDesc)
               Return cmd.ExecuteNonQuery() > 0
            End Using
         End Using
      End Function

      Public Function Update(category As CategoryModel) As Boolean
         Dim query As String = "UPDATE category SET categoryDesc=@categoryDesc WHERE id=@id"

         Using conn As New MySqlConnection(_config.GetConnectionString())
            conn.Open()
            Using cmd As New MySqlCommand(query, conn)
               cmd.Parameters.AddWithValue("@categoryDesc", category.CategoryDesc)
               cmd.Parameters.AddWithValue("@id", category.Id)
               Return cmd.ExecuteNonQuery() > 0
            End Using
         End Using
      End Function

      Public Function Delete(id As Integer) As Boolean
         Dim query As String = "DELETE FROM category WHERE id=@id"

         Using conn As New MySqlConnection(_config.GetConnectionString())
            conn.Open()
            Using cmd As New MySqlCommand(query, conn)
               cmd.Parameters.AddWithValue("@id", id)
               Return cmd.ExecuteNonQuery() > 0
            End Using
         End Using
      End Function
   End Class
End Namespace
