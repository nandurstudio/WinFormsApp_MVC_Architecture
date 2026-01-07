Imports MySql.Data.MySqlClient
Imports WinFormsApp_Latihan.Models

Namespace Controllers
   Public Class LoginController
      Private ReadOnly _configModel As ConfigModel

      Public Sub New(configModel As ConfigModel)
         _configModel = configModel
      End Sub

      Public Function AuthenticateUser(username As String, password As String) As Boolean
         Try
            Using conn As New MySqlConnection(_configModel.GetConnectionString())
               conn.Open()

               Dim query As String = "SELECT password FROM users WHERE username = @username"
               Using cmd As New MySqlCommand(query, conn)
                  cmd.Parameters.AddWithValue("@username", username)

                  Dim hashedPassword As Object = cmd.ExecuteScalar()

                  If hashedPassword IsNot Nothing Then
                     Return PasswordModel.VerifyPassword(password, hashedPassword.ToString())
                  End If
               End Using
            End Using
         Catch ex As Exception
            Throw New Exception($"Authentication error: {ex.Message}", ex)
         End Try

         Return False
      End Function

      Public Function RegisterUser(username As String, password As String, email As String, Optional role As String = "user") As Boolean
         Try
            Using conn As New MySqlConnection(_configModel.GetConnectionString())
               conn.Open()

               Dim checkQuery As String = "SELECT COUNT(*) FROM users WHERE username = @username"
               Using checkCmd As New MySqlCommand(checkQuery, conn)
                  checkCmd.Parameters.AddWithValue("@username", username)
                  Dim count As Integer = Convert.ToInt32(checkCmd.ExecuteScalar())

                  If count > 0 Then
                     Throw New Exception("Username already exists")
                  End If
               End Using

               Dim hashedPassword As String = PasswordModel.HashPassword(password)

               Dim insertQuery As String = "INSERT INTO users (username, password, email, role, created_at) VALUES (@username, @password, @email, @role, @created_at)"
               Using insertCmd As New MySqlCommand(insertQuery, conn)
                  insertCmd.Parameters.AddWithValue("@username", username)
                  insertCmd.Parameters.AddWithValue("@password", hashedPassword)
                  insertCmd.Parameters.AddWithValue("@email", email)
                  insertCmd.Parameters.AddWithValue("@role", role)
                  insertCmd.Parameters.AddWithValue("@created_at", DateTime.Now)

                  Dim result As Integer = insertCmd.ExecuteNonQuery()
                  Return result > 0
               End Using
            End Using
         Catch ex As Exception
            Throw New Exception($"Registration error: {ex.Message}", ex)
         End Try

         Return False
      End Function

      Public Function GetUserByUsername(username As String) As UserModel
         Try
            Using conn As New MySqlConnection(_configModel.GetConnectionString())
               conn.Open()

               ' Include role in SELECT query
               Dim query As String = "SELECT user_id, username, email, role, created_at FROM users WHERE username = @username"
               Using cmd As New MySqlCommand(query, conn)
                  cmd.Parameters.AddWithValue("@username", username)

                  Using reader As MySqlDataReader = cmd.ExecuteReader()
                     If reader.Read() Then
                        Return New UserModel(
                            Convert.ToInt32(reader("user_id")),
                            reader("username").ToString(),
                            reader("email").ToString(),
                            If(reader("role") IsNot DBNull.Value, reader("role").ToString(), "user"),
                            Convert.ToDateTime(reader("created_at"))
                        )
                     End If
                  End Using
               End Using
            End Using
         Catch ex As Exception
            Throw New Exception($"Error retrieving user: {ex.Message}", ex)
         End Try

         Return Nothing
      End Function

      Public Function TestConnection() As Boolean
         Try
            Using conn As New MySqlConnection(_configModel.GetConnectionString())
               conn.Open()
               Return conn.State = ConnectionState.Open
            End Using
         Catch ex As Exception
            Return False
         End Try
      End Function

      ' Create default admin user if not exists
      Public Function CreateDefaultAdminUser() As Boolean
         Try
            Using conn As New MySqlConnection(_configModel.GetConnectionString())
               conn.Open()

               ' Check if admin exists
               Dim checkQuery As String = "SELECT COUNT(*) FROM users WHERE username = 'admin'"
               Using checkCmd As New MySqlCommand(checkQuery, conn)
                  Dim count As Integer = Convert.ToInt32(checkCmd.ExecuteScalar())

                  If count > 0 Then
                     Return True ' Admin already exists
                  End If
               End Using

               ' Create admin user
               Dim hashedPassword As String = PasswordModel.HashPassword("Admin@123456")
               Dim insertQuery As String = "INSERT INTO users (username, password, email, role, created_at) VALUES (@username, @password, @email, @role, @created_at)"

               Using insertCmd As New MySqlCommand(insertQuery, conn)
                  insertCmd.Parameters.AddWithValue("@username", "admin")
                  insertCmd.Parameters.AddWithValue("@password", hashedPassword)
                  insertCmd.Parameters.AddWithValue("@email", "admin@localhost.com")
                  insertCmd.Parameters.AddWithValue("@role", "admin")
                  insertCmd.Parameters.AddWithValue("@created_at", DateTime.Now)

                  Return insertCmd.ExecuteNonQuery() > 0
               End Using
            End Using
         Catch ex As Exception
            Return False
         End Try
      End Function
   End Class
End Namespace
