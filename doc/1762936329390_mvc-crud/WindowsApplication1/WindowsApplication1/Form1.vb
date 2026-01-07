Public Class Form1
    Private controller As New MahasiswaController()

    Private Sub FormMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadData()
    End Sub

    Private Sub LoadData()
        dgvMahasiswa.DataSource = controller.GetAll()
    End Sub

    Private Sub btnTambah_Click(sender As Object, e As EventArgs) Handles btnTambah.Click
        Dim f As New FormMahasiswa()
        If f.ShowDialog() = DialogResult.OK Then
            LoadData()
        End If
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        If dgvMahasiswa.CurrentRow IsNot Nothing Then
            Dim f As New FormMahasiswa()
            f.txtNim.Text = dgvMahasiswa.CurrentRow.Cells("nim").Value.ToString()
            f.txtNama.Text = dgvMahasiswa.CurrentRow.Cells("nama").Value.ToString()
            f.txtJurusan.Text = dgvMahasiswa.CurrentRow.Cells("jurusan").Value.ToString()
            If f.ShowDialog() = DialogResult.OK Then
                LoadData()
            End If
        End If
    End Sub

    Private Sub btnHapus_Click(sender As Object, e As EventArgs) Handles btnHapus.Click
        If dgvMahasiswa.CurrentRow IsNot Nothing Then
            Dim id = CInt(dgvMahasiswa.CurrentRow.Cells("id").Value)
            If MessageBox.Show("Yakin ingin menghapus data ini?", "Konfirmasi", MessageBoxButtons.YesNo) = DialogResult.Yes Then
                controller.Delete(id)
                LoadData()
            End If
        End If
    End Sub

End Class
