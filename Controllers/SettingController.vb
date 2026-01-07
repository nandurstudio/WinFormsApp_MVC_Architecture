Imports WinFormsApp_Latihan.Models

Namespace Controllers
   Public Class SettingController
      Private ReadOnly _configFilePath As String

      Public Sub New(Optional configFilePath As String = Nothing)
         ' If no path specified, look in multiple locations
         If String.IsNullOrEmpty(configFilePath) Then
            ' Try current directory first (bin/Debug)
            _configFilePath = "setting.ini"

            ' If not found, try parent directories (project root)
            If Not System.IO.File.Exists(_configFilePath) Then
               Dim projectRoot As String = System.IO.Path.GetFullPath(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\..\..\"))
               Dim rootConfigPath As String = System.IO.Path.Combine(projectRoot, "setting.ini")

               If System.IO.File.Exists(rootConfigPath) Then
                  _configFilePath = rootConfigPath
               End If
            End If
         Else
            _configFilePath = configFilePath
         End If
      End Sub

      Public Function LoadConfiguration() As ConfigModel
         Dim config As New ConfigModel()

         ' Check if setting.ini exists
         If Not System.IO.File.Exists(_configFilePath) Then
            ' Create default setting.ini if not exists
            CreateDefaultConfigFile()
         End If

         Try
            Dim lines As String() = System.IO.File.ReadAllLines(_configFilePath)
            Dim currentSection As String = ""

            For Each line As String In lines
               Dim trimmedLine As String = line.Trim()

               ' Skip empty lines and comments
               If String.IsNullOrWhiteSpace(trimmedLine) OrElse trimmedLine.StartsWith(";") OrElse trimmedLine.StartsWith("#") Then
                  Continue For
               End If

               ' Check for section headers
               If trimmedLine.StartsWith("[") AndAlso trimmedLine.EndsWith("]") Then
                  currentSection = trimmedLine.Substring(1, trimmedLine.Length - 2).ToLower()
                  Continue For
               End If

               ' Parse key=value pairs
               Dim parts As String() = trimmedLine.Split("="c, 2)
               If parts.Length = 2 Then
                  Dim key As String = parts(0).Trim().ToLower()
                  Dim value As String = parts(1).Trim()

                  ' Only process DatabaseConfig section
                  If currentSection = "databaseconfig" Then
                     Select Case key
                        Case "server"
                           config.Server = value
                        Case "database"
                           config.Database = value
                        Case "uid", "username"
                           config.Username = value
                        Case "pwd", "password"
                           config.Password = value
                        Case "port"
                           config.Port = value
                     End Select
                  End If
               End If
            Next
         Catch ex As Exception
            Throw New Exception($"Error loading configuration: {ex.Message}", ex)
         End Try

         Return config
      End Function

      Private Sub CreateDefaultConfigFile()
         Try
            Dim defaultConfig As New List(Of String) From {
                    "[DatabaseConfig]",
                    "Server=localhost",
                    "Database=penjualan_visual_db",
                    "Uid=root",
                    "Pwd=",
                    "Port=3306",
                    "",
                    "[AppConfig]",
                    "AppName=Aplikasi Penjualan MVC",
                    "Version=2.0.0",
                    "Author=Nandang Duryat (312310233)",
                    "University=Universitas Pelita Bangsa"
                }

            System.IO.File.WriteAllLines(_configFilePath, defaultConfig)
         Catch ex As Exception
            Throw New Exception($"Error creating default configuration file: {ex.Message}", ex)
         End Try
      End Sub

      Public Function SaveConfiguration(config As ConfigModel) As Boolean
         Try
            Dim lines As New List(Of String) From {
                    "[DatabaseConfig]",
                    "Server=" & config.Server,
                    "Database=" & config.Database,
                    "Uid=" & config.Username,
                    "Pwd=" & config.Password,
                    "Port=" & config.Port,
                    "",
                    "[AppConfig]",
                    "AppName=Aplikasi Penjualan MVC",
                    "Version=2.0.0",
                    "Author=Nandang Duryat (312310233)",
                    "University=Universitas Pelita Bangsa"
                }

            System.IO.File.WriteAllLines(_configFilePath, lines)
            Return True
         Catch ex As Exception
            Throw New Exception($"Error saving configuration: {ex.Message}", ex)
         End Try
      End Function

      Public Function TestDatabaseConnection(config As ConfigModel) As Boolean
         Try
            Dim loginController As New LoginController(config)
            Return loginController.TestConnection()
         Catch ex As Exception
            Return False
         End Try
      End Function

      Public Function ValidateConfiguration(config As ConfigModel) As (IsValid As Boolean, ErrorMessage As String)
         If String.IsNullOrWhiteSpace(config.Server) Then
            Return (False, "Server is required")
         End If

         If String.IsNullOrWhiteSpace(config.Database) Then
            Return (False, "Database is required")
         End If

         If String.IsNullOrWhiteSpace(config.Username) Then
            Return (False, "Username is required")
         End If

         If String.IsNullOrWhiteSpace(config.Port) Then
            Return (False, "Port is required")
         End If

         Dim portNumber As Integer
         If Not Integer.TryParse(config.Port, portNumber) OrElse portNumber <= 0 OrElse portNumber > 65535 Then
            Return (False, "Port must be a valid number between 1 and 65535")
         End If

         Return (True, String.Empty)
      End Function

      Public Function ResetToDefaults() As ConfigModel
         Return New ConfigModel()
      End Function
   End Class
End Namespace
