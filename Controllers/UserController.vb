Imports MySql.Data.MySqlClient
Imports WinFormsApp_Latihan.Models

Namespace Controllers
    Public Class UserController
        Private ReadOnly _configModel As ConfigModel

        Public Sub New(configModel As ConfigModel)
            _configModel = configModel
        End Sub

        Public Function LoadUsers() As DataTable
            Try
                Using conn As New MySqlConnection(_configModel.GetConnectionString())
                    conn.Open()
                    Dim query As String = "SELECT user_id, username, email, role, created_at FROM users ORDER BY created_at DESC"
                    Using adapter As New MySqlDataAdapter(query, conn)
                        Dim dt As New DataTable()
                        adapter.Fill(dt)
                        Return dt
                    End Using
                End Using
            Catch ex As Exception
                Throw New Exception($"Error loading users: {ex.Message}", ex)
            End Try
        End Function

        Public Function GetUser(userId As Integer) As UserModel
            Try
                Using conn As New MySqlConnection(_configModel.GetConnectionString())
                    conn.Open()
                    Dim query As String = "SELECT user_id, username, email, role, created_at FROM users WHERE user_id = @userId"
                    Using cmd As New MySqlCommand(query, conn)
                        cmd.Parameters.AddWithValue("@userId", userId)

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

        Public Function CreateUser(user As UserModel, password As String) As Boolean
            Try
                Using conn As New MySqlConnection(_configModel.GetConnectionString())
                    conn.Open()

                    ' Check if username already exists
                    Dim checkQuery As String = "SELECT COUNT(*) FROM users WHERE username = @username"
                    Using checkCmd As New MySqlCommand(checkQuery, conn)
                        checkCmd.Parameters.AddWithValue("@username", user.Username)
                        Dim count As Integer = Convert.ToInt32(checkCmd.ExecuteScalar())

                        If count > 0 Then
                            Throw New Exception("Username sudah digunakan")
                        End If
                    End Using

                    ' Hash password
                    Dim hashedPassword As String = PasswordModel.HashPassword(password)

                    ' Insert new user
                    Dim insertQuery As String = "INSERT INTO users (username, password, email, role, created_at) VALUES (@username, @password, @email, @role, @created_at)"
                    Using insertCmd As New MySqlCommand(insertQuery, conn)
                        insertCmd.Parameters.AddWithValue("@username", user.Username)
                        insertCmd.Parameters.AddWithValue("@password", hashedPassword)
                        insertCmd.Parameters.AddWithValue("@email", user.Email)
                        insertCmd.Parameters.AddWithValue("@role", user.Role)
                        insertCmd.Parameters.AddWithValue("@created_at", DateTime.Now)

                        Return insertCmd.ExecuteNonQuery() > 0
                    End Using
                End Using
            Catch ex As Exception
                Throw New Exception($"Error creating user: {ex.Message}", ex)
            End Try
        End Function

        Public Function UpdateUser(user As UserModel, Optional newPassword As String = Nothing) As Boolean
            Try
                Using conn As New MySqlConnection(_configModel.GetConnectionString())
                    conn.Open()

                    ' Check if username already exists (excluding current user)
                    Dim checkQuery As String = "SELECT COUNT(*) FROM users WHERE username = @username AND user_id != @userId"
                    Using checkCmd As New MySqlCommand(checkQuery, conn)
                        checkCmd.Parameters.AddWithValue("@username", user.Username)
                        checkCmd.Parameters.AddWithValue("@userId", user.UserId)
                        Dim count As Integer = Convert.ToInt32(checkCmd.ExecuteScalar())

                        If count > 0 Then
                            Throw New Exception("Username sudah digunakan oleh user lain")
                        End If
                    End Using

                    ' Update user
                    Dim updateQuery As String
                    If String.IsNullOrEmpty(newPassword) Then
                        ' Update without password
                        updateQuery = "UPDATE users SET username = @username, email = @email, role = @role WHERE user_id = @userId"
                    Else
                        ' Update with password
                        updateQuery = "UPDATE users SET username = @username, email = @email, role = @role, password = @password WHERE user_id = @userId"
                    End If

                    Using updateCmd As New MySqlCommand(updateQuery, conn)
                        updateCmd.Parameters.AddWithValue("@username", user.Username)
                        updateCmd.Parameters.AddWithValue("@email", user.Email)
                        updateCmd.Parameters.AddWithValue("@role", user.Role)
                        updateCmd.Parameters.AddWithValue("@userId", user.UserId)

                        If Not String.IsNullOrEmpty(newPassword) Then
                            Dim hashedPassword As String = PasswordModel.HashPassword(newPassword)
                            updateCmd.Parameters.AddWithValue("@password", hashedPassword)
                        End If

                        Return updateCmd.ExecuteNonQuery() > 0
                    End Using
                End Using
            Catch ex As Exception
                Throw New Exception($"Error updating user: {ex.Message}", ex)
            End Try
        End Function

        Public Function DeleteUser(userId As Integer) As Boolean
            Try
                Using conn As New MySqlConnection(_configModel.GetConnectionString())
                    conn.Open()

                    ' Check if trying to delete the last admin
                    Dim checkQuery As String = "SELECT COUNT(*) FROM users WHERE role = 'admin'"
                    Using checkCmd As New MySqlCommand(checkQuery, conn)
                        Dim adminCount As Integer = Convert.ToInt32(checkCmd.ExecuteScalar())

                        ' Check if current user is admin
                        Dim roleQuery As String = "SELECT role FROM users WHERE user_id = @userId"
                        Using roleCmd As New MySqlCommand(roleQuery, conn)
                            roleCmd.Parameters.AddWithValue("@userId", userId)
                            Dim userRole As String = roleCmd.ExecuteScalar()?.ToString()

                            If adminCount <= 1 AndAlso userRole = "admin" Then
                                Throw New Exception("Tidak dapat menghapus satu-satunya admin")
                            End If
                        End Using
                    End Using

                    ' Delete user
                    Dim deleteQuery As String = "DELETE FROM users WHERE user_id = @userId"
                    Using deleteCmd As New MySqlCommand(deleteQuery, conn)
                        deleteCmd.Parameters.AddWithValue("@userId", userId)
                        Return deleteCmd.ExecuteNonQuery() > 0
                    End Using
                End Using
            Catch ex As Exception
                Throw New Exception($"Error deleting user: {ex.Message}", ex)
            End Try
        End Function
    End Class
End Namespace
