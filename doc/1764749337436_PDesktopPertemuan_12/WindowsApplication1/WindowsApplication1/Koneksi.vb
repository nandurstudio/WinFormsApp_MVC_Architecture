Imports MySql.Data.MySqlClient

Module Koneksi
    Private ReadOnly server As String = "192.168.100.94"
    Private ReadOnly database As String = "dbpenjualan"
    Private ReadOnly username As String = "root"
    Private ReadOnly password As String = ""

    ' Gunakan satu variabel koneksi global (opsional)
    Private conn As MySqlConnection

    ' Fungsi utama untuk membuka koneksi
    Public Function OpenConnection() As MySqlConnection
        Try
            If conn Is Nothing Then
                Dim connString As String = String.Format("server={0};user id={1};password={2};database={3};", server, username, password, database)
                conn = New MySqlConnection(connString)
            End If

            If conn.State = ConnectionState.Closed OrElse conn.State = ConnectionState.Broken Then
                conn.Open()
            End If

            Return conn

        Catch ex As MySqlException
            MessageBox.Show("Koneksi gagal: " & ex.Message, "Error Koneksi", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return Nothing
        End Try
    End Function

    ' Menutup koneksi
    Public Sub CloseConnection()
        Try
            If conn IsNot Nothing AndAlso conn.State = ConnectionState.Open Then
                conn.Close()
            End If
        Catch ex As Exception
            MessageBox.Show("Gagal menutup koneksi: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            conn = Nothing
        End Try
    End Sub

    ' Mengecek status koneksi
    Public Function IsConnected() As Boolean
        Try
            Return conn IsNot Nothing AndAlso conn.State = ConnectionState.Open
        Catch ex As Exception
            Return False
        End Try
    End Function
End Module
