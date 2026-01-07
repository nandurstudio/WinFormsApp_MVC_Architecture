Public Class FormMahasiswa
    Private controller As New MahasiswaController()

    Private Sub btnSimpan_Click(sender As Object, e As EventArgs) Handles btnSimpan.Click
        Dim m As New MahasiswaModel With {
            .Nim = txtNim.Text,
            .Nama = txtNama.Text,
            .Jurusan = txtJurusan.Text
        }

        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub
End Class