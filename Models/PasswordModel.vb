Imports System.Security.Cryptography
Imports System.Text

Namespace Models
   Public Class PasswordModel
      Private Const SaltSize As Integer = 16
      Private Const HashSize As Integer = 20
      Private Const Iterations As Integer = 10000

      Public Shared Function HashPassword(password As String) As String
         Dim salt As Byte() = New Byte(SaltSize - 1) {}
         Using rng As New RNGCryptoServiceProvider()
            rng.GetBytes(salt)
         End Using

         Dim pbkdf2 As New Rfc2898DeriveBytes(password, salt, Iterations)
         Dim hash As Byte() = pbkdf2.GetBytes(HashSize)

         Dim hashBytes As Byte() = New Byte(SaltSize + HashSize - 1) {}
         Array.Copy(salt, 0, hashBytes, 0, SaltSize)
         Array.Copy(hash, 0, hashBytes, SaltSize, HashSize)

         Return Convert.ToBase64String(hashBytes)
      End Function

      Public Shared Function VerifyPassword(password As String, hashedPassword As String) As Boolean
         Try
            Dim hashBytes As Byte() = Convert.FromBase64String(hashedPassword)

            Dim salt As Byte() = New Byte(SaltSize - 1) {}
            Array.Copy(hashBytes, 0, salt, 0, SaltSize)

            Dim pbkdf2 As New Rfc2898DeriveBytes(password, salt, Iterations)
            Dim hash As Byte() = pbkdf2.GetBytes(HashSize)

            For i As Integer = 0 To HashSize - 1
               If hashBytes(i + SaltSize) <> hash(i) Then
                  Return False
               End If
            Next

            Return True
         Catch ex As Exception
            Return False
         End Try
      End Function

      Public Shared Function GenerateSalt() As String
         Dim salt As Byte() = New Byte(SaltSize - 1) {}
         Using rng As New RNGCryptoServiceProvider()
            rng.GetBytes(salt)
         End Using
         Return Convert.ToBase64String(salt)
      End Function

      Public Shared Function EncryptPassword(password As String, key As String) As String
         Dim keyBytes As Byte() = Encoding.UTF8.GetBytes(key.PadRight(32).Substring(0, 32))
         Using aes As Aes = Aes.Create()
            aes.Key = keyBytes
            aes.GenerateIV()

            Using encryptor = aes.CreateEncryptor(aes.Key, aes.IV)
               Dim passwordBytes As Byte() = Encoding.UTF8.GetBytes(password)
               Dim encryptedBytes As Byte() = encryptor.TransformFinalBlock(passwordBytes, 0, passwordBytes.Length)

               Dim result As Byte() = New Byte(aes.IV.Length + encryptedBytes.Length - 1) {}
               Array.Copy(aes.IV, 0, result, 0, aes.IV.Length)
               Array.Copy(encryptedBytes, 0, result, aes.IV.Length, encryptedBytes.Length)

               Return Convert.ToBase64String(result)
            End Using
         End Using
      End Function

      Public Shared Function DecryptPassword(encryptedPassword As String, key As String) As String
         Try
            Dim keyBytes As Byte() = Encoding.UTF8.GetBytes(key.PadRight(32).Substring(0, 32))
            Dim fullBytes As Byte() = Convert.FromBase64String(encryptedPassword)

            Using aes As Aes = Aes.Create()
               aes.Key = keyBytes

               Dim iv As Byte() = New Byte(aes.IV.Length - 1) {}
               Array.Copy(fullBytes, 0, iv, 0, iv.Length)
               aes.IV = iv

               Dim encryptedBytes As Byte() = New Byte(fullBytes.Length - iv.Length - 1) {}
               Array.Copy(fullBytes, iv.Length, encryptedBytes, 0, encryptedBytes.Length)

               Using decryptor = aes.CreateDecryptor(aes.Key, aes.IV)
                  Dim decryptedBytes As Byte() = decryptor.TransformFinalBlock(encryptedBytes, 0, encryptedBytes.Length)
                  Return Encoding.UTF8.GetString(decryptedBytes)
               End Using
            End Using
         Catch ex As Exception
            Return String.Empty
         End Try
      End Function
   End Class
End Namespace
