Namespace Models
   Public Class ConfigModel
      Public Property Server As String
      Public Property Database As String
      Public Property Username As String
      Public Property Password As String
      Public Property Port As String

      ' Empty constructor - NO defaults
      ' Configuration MUST come from setting.ini
      Public Sub New()
         Server = String.Empty
         Database = String.Empty
         Username = String.Empty
         Password = String.Empty
         Port = String.Empty
      End Sub

      Public Sub New(server As String, database As String, username As String, password As String, port As String)
         Me.Server = server
         Me.Database = database
         Me.Username = username
         Me.Password = password
         Me.Port = port
      End Sub

      Public Function GetConnectionString() As String
         Return $"Server={Server};Database={Database};Uid={Username};Pwd={Password};Port={Port};"
      End Function

      Public Function IsValid() As Boolean
         Return Not String.IsNullOrWhiteSpace(Server) AndAlso
                Not String.IsNullOrWhiteSpace(Database) AndAlso
                Not String.IsNullOrWhiteSpace(Username) AndAlso
                Not String.IsNullOrWhiteSpace(Port)
      End Function
   End Class
End Namespace
