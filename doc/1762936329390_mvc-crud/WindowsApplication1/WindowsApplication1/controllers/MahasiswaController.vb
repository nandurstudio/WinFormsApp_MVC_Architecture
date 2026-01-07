Imports MySql.Data.MySqlClient
Public Class MahasiswaController

    Public Function GetAll() As DataTable
        Dim dt As New DataTable()
        Using conn = Koneksi.OpenConnection()

            Dim query = "SELECT * FROM mahasiswa"
            Using cmd As New MySqlCommand(query, conn)
                Using da As New MySqlDataAdapter(cmd)
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    Public Sub Insert(m As MahasiswaModel)
        Using conn = Koneksi.OpenConnection()

            Dim query = "INSERT INTO mahasiswa (nim, nama, jurusan) VALUES (@nim, @nama, @jurusan)"
            Using cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@nim", m.nim)
                cmd.Parameters.AddWithValue("@nama", m.nama)
                cmd.Parameters.AddWithValue("@jurusan", m.jurusan)
                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    Public Sub Update(m As MahasiswaModel)
        Using conn = Koneksi.OpenConnection()
            Dim query = "UPDATE mahasiswa SET nim=@nim, nama=@nama, jurusan=@jurusan WHERE id=@id"
            Using cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@nim", m.nim)
                cmd.Parameters.AddWithValue("@nama", m.nama)
                cmd.Parameters.AddWithValue("@jurusan", m.jurusan)
                cmd.Parameters.AddWithValue("@id", m.id)
                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    Public Sub Delete(id As Integer)
        Using conn = Koneksi.OpenConnection()
            Dim query = "DELETE FROM mahasiswa WHERE id=@id"
            Using cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@id", id)
                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub

End Class
