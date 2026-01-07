Imports MySql.Data.MySqlClient

Namespace Models
   Public Class UserModel
      Public Property UserId As Integer
      Public Property Username As String
      Public Property Password As String
      Public Property Email As String
      Public Property Role As String
      Public Property CreatedAt As DateTime

      Public Sub New()
         Role = "user" ' Default role
      End Sub

      Public Sub New(username As String, password As String)
         Me.Username = username
         Me.Password = password
         Me.Role = "user"
      End Sub

      Public Sub New(userId As Integer, username As String, email As String, createdAt As DateTime)
         Me.UserId = userId
         Me.Username = username
         Me.Email = email
         Me.CreatedAt = createdAt
         Me.Role = "user"
      End Sub

      Public Sub New(userId As Integer, username As String, email As String, role As String, createdAt As DateTime)
         Me.UserId = userId
         Me.Username = username
         Me.Email = email
         Me.Role = role
         Me.CreatedAt = createdAt
      End Sub

      ' Helper methods untuk role checking
      Public Function IsAdmin() As Boolean
         Return Not String.IsNullOrEmpty(Role) AndAlso Role.ToLower() = "admin"
      End Function

      Public Function IsUser() As Boolean
         Return String.IsNullOrEmpty(Role) OrElse Role.ToLower() = "user"
      End Function

      Public Overrides Function ToString() As String
         Return $"User: {Username}, Email: {Email}, Role: {Role}"
      End Function
   End Class
End Namespace
