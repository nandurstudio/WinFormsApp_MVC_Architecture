Imports WinFormsApp_Latihan.Models

Namespace Controllers
    Public Class PasswordController
        Public Function HashPassword(password As String) As String
            Return PasswordModel.HashPassword(password)
        End Function

        Public Function VerifyPassword(password As String, hashedPassword As String) As Boolean
            Return PasswordModel.VerifyPassword(password, hashedPassword)
        End Function

        Public Function EncryptPassword(password As String, key As String) As String
            Return PasswordModel.EncryptPassword(password, key)
        End Function

        Public Function DecryptPassword(encryptedPassword As String, key As String) As String
            Return PasswordModel.DecryptPassword(encryptedPassword, key)
        End Function

        Public Function GenerateSalt() As String
            Return PasswordModel.GenerateSalt()
        End Function

        Public Function ValidatePasswordStrength(password As String) As (IsValid As Boolean, Message As String)
            If String.IsNullOrWhiteSpace(password) Then
                Return (False, "Password cannot be empty")
            End If

            If password.Length < 8 Then
                Return (False, "Password must be at least 8 characters long")
            End If

            Dim hasUpper As Boolean = password.Any(Function(c) Char.IsUpper(c))
            Dim hasLower As Boolean = password.Any(Function(c) Char.IsLower(c))
            Dim hasDigit As Boolean = password.Any(Function(c) Char.IsDigit(c))
            Dim hasSpecial As Boolean = password.Any(Function(c) Not Char.IsLetterOrDigit(c))

            If Not hasUpper Then
                Return (False, "Password must contain at least one uppercase letter")
            End If

            If Not hasLower Then
                Return (False, "Password must contain at least one lowercase letter")
            End If

            If Not hasDigit Then
                Return (False, "Password must contain at least one digit")
            End If

            If Not hasSpecial Then
                Return (False, "Password must contain at least one special character")
            End If

            Return (True, "Password is strong")
        End Function

        Public Function GetPasswordStrength(password As String) As String
            If String.IsNullOrWhiteSpace(password) Then
                Return "None"
            End If

            Dim score As Integer = 0

            If password.Length >= 8 Then score += 1
            If password.Length >= 12 Then score += 1
            If password.Any(Function(c) Char.IsUpper(c)) Then score += 1
            If password.Any(Function(c) Char.IsLower(c)) Then score += 1
            If password.Any(Function(c) Char.IsDigit(c)) Then score += 1
            If password.Any(Function(c) Not Char.IsLetterOrDigit(c)) Then score += 1

            Select Case score
                Case 0 To 2
                    Return "Weak"
                Case 3 To 4
                    Return "Medium"
                Case Else
                    Return "Strong"
            End Select
        End Function
    End Class
End Namespace
