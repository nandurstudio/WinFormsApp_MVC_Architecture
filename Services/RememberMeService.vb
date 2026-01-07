Imports System.IO
Imports System.Security.Cryptography
Imports System.Text

Namespace Services
   ''' <summary>
   ''' Service untuk mengelola fitur Remember Me (Selalu Login)
   ''' Menyimpan kredensial login secara aman dengan enkripsi
   ''' </summary>
   Public Class RememberMeService
      Private Const REMEMBER_FILE As String = "remember.dat"
      Private Const ENCRYPTION_KEY As String = "W!nF0rms@pp#2025$RememberMe"

      ''' <summary>
      ''' Model untuk menyimpan data Remember Me
      ''' </summary>
      Public Class RememberMeData
         Public Property Username As String
         Public Property EncryptedPassword As String
         Public Property RememberMe As Boolean
      End Class

      ''' <summary>
      ''' Simpan kredensial login ke file terenkripsi
      ''' </summary>
      Public Shared Sub SaveCredentials(username As String, password As String)
         Try
            Dim data As New RememberMeData With {
                .Username = username,
                .EncryptedPassword = EncryptString(password),
                .RememberMe = True
            }

            Dim filePath As String = Path.Combine(Application.StartupPath, REMEMBER_FILE)
            Dim content As String = $"{data.Username}|{data.EncryptedPassword}|{data.RememberMe}"
            Dim encryptedContent As String = EncryptString(content)

            File.WriteAllText(filePath, encryptedContent)
         Catch ex As Exception
            ' Silent fail - jangan ganggu user experience
            Console.WriteLine($"Error saving credentials: {ex.Message}")
         End Try
      End Sub

      ''' <summary>
      ''' Load kredensial yang tersimpan
      ''' </summary>
      Public Shared Function LoadCredentials() As RememberMeData
         Try
            Dim filePath As String = Path.Combine(Application.StartupPath, REMEMBER_FILE)

            If Not File.Exists(filePath) Then
               Return Nothing
            End If

            Dim encryptedContent As String = File.ReadAllText(filePath)
            Dim content As String = DecryptString(encryptedContent)

            Dim parts() As String = content.Split("|"c)
            If parts.Length >= 3 Then
               Return New RememberMeData With {
                   .Username = parts(0),
                   .EncryptedPassword = parts(1),
                   .RememberMe = Boolean.Parse(parts(2))
               }
            End If
         Catch ex As Exception
            ' Silent fail - jangan ganggu user experience
            Console.WriteLine($"Error loading credentials: {ex.Message}")
         End Try

         Return Nothing
      End Function

      ''' <summary>
      ''' Decrypt password untuk login
      ''' </summary>
      Public Shared Function GetDecryptedPassword(encryptedPassword As String) As String
         Try
            Return DecryptString(encryptedPassword)
         Catch ex As Exception
            Console.WriteLine($"Error decrypting password: {ex.Message}")
            Return String.Empty
         End Try
      End Function

      ''' <summary>
      ''' Hapus kredensial yang tersimpan (untuk logout)
      ''' </summary>
      Public Shared Sub ClearCredentials()
         Try
            Dim filePath As String = Path.Combine(Application.StartupPath, REMEMBER_FILE)
            If File.Exists(filePath) Then
               File.Delete(filePath)
            End If
         Catch ex As Exception
            ' Silent fail
            Console.WriteLine($"Error clearing credentials: {ex.Message}")
         End Try
      End Sub

      ''' <summary>
      ''' Cek apakah ada kredensial yang tersimpan
      ''' </summary>
      Public Shared Function HasSavedCredentials() As Boolean
         Dim filePath As String = Path.Combine(Application.StartupPath, REMEMBER_FILE)
         Return File.Exists(filePath)
      End Function

      ' ==================== ENKRIPSI / DEKRIPSI ====================

      Private Shared Function EncryptString(plainText As String) As String
         Try
            Dim key As Byte() = DeriveKeyFromPassword(ENCRYPTION_KEY)
            Dim iv As Byte() = New Byte(15) {} ' 16 bytes untuk AES

            Using aes As Aes = Aes.Create()
               aes.Key = key
               aes.IV = iv
               aes.Mode = CipherMode.CBC
               aes.Padding = PaddingMode.PKCS7

               Using encryptor As ICryptoTransform = aes.CreateEncryptor()
                  Dim plainBytes As Byte() = Encoding.UTF8.GetBytes(plainText)
                  Dim encryptedBytes As Byte() = encryptor.TransformFinalBlock(plainBytes, 0, plainBytes.Length)
                  Return Convert.ToBase64String(encryptedBytes)
               End Using
            End Using
         Catch ex As Exception
            Throw New Exception("Encryption failed: " & ex.Message)
         End Try
      End Function

      Private Shared Function DecryptString(encryptedText As String) As String
         Try
            Dim key As Byte() = DeriveKeyFromPassword(ENCRYPTION_KEY)
            Dim iv As Byte() = New Byte(15) {} ' 16 bytes untuk AES

            Using aes As Aes = Aes.Create()
               aes.Key = key
               aes.IV = iv
               aes.Mode = CipherMode.CBC
               aes.Padding = PaddingMode.PKCS7

               Using decryptor As ICryptoTransform = aes.CreateDecryptor()
                  Dim encryptedBytes As Byte() = Convert.FromBase64String(encryptedText)
                  Dim decryptedBytes As Byte() = decryptor.TransformFinalBlock(encryptedBytes, 0, encryptedBytes.Length)
                  Return Encoding.UTF8.GetString(decryptedBytes)
               End Using
            End Using
         Catch ex As Exception
            Throw New Exception("Decryption failed: " & ex.Message)
         End Try
      End Function

      Private Shared Function DeriveKeyFromPassword(password As String) As Byte()
         Dim salt As Byte() = Encoding.UTF8.GetBytes("WinFormsAppSalt2025")
         Using deriveBytes As New Rfc2898DeriveBytes(password, salt, 1000, HashAlgorithmName.SHA256)
            Return deriveBytes.GetBytes(32) ' 256 bits untuk AES-256
         End Using
      End Function

   End Class
End Namespace
