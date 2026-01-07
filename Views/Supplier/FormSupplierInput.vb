Imports WinFormsApp_Latihan.Models
Imports WinFormsApp_Latihan.Controllers

Public Class FormSupplierInput
    Private controller As SupplierController
    Private _config As ConfigModel
    Private editedId As Integer = -1

    Sub New()
        InitializeComponent()
        InitializeControllers()
    End Sub

    Sub New(supplier As SupplierModel)
        InitializeComponent()
        InitializeControllers()

        With supplier
            editedId = .Id
            txtSupplierName.Text = .SupplierName
            txtContact.Text = .Contact
            txtPhone.Text = .Phone
            txtEmail.Text = .Email
            txtAddress.Text = .Address
            txtCity.Text = .City
        End With

        Label1.Text = "Update Supplier"
        Me.Text = "Edit Supplier Form"
    End Sub

    Private Sub InitializeControllers()
        Dim settingController As New SettingController()
        _config = settingController.LoadConfiguration()
        controller = New SupplierController(_config)
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If String.IsNullOrWhiteSpace(txtSupplierName.Text) Then
            MessageBox.Show("Nama supplier tidak boleh kosong", "Validation",
                          MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtSupplierName.Focus()
            Return
        End If

        Try
            Dim supplier As New SupplierModel With {
                .SupplierName = txtSupplierName.Text.Trim(),
                .Contact = txtContact.Text.Trim(),
                .Phone = txtPhone.Text.Trim(),
                .Email = txtEmail.Text.Trim(),
                .Address = txtAddress.Text.Trim(),
                .City = txtCity.Text.Trim()
            }

            Dim success As Boolean
            If editedId = -1 Then
                success = controller.Create(supplier)
            Else
                supplier.Id = editedId
                success = controller.Update(supplier)
            End If

            If success Then
                MessageBox.Show("Supplier berhasil disimpan", "Success",
                              MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.DialogResult = DialogResult.OK
                Me.Close()
            End If
        Catch ex As Exception
            MessageBox.Show($"Error saving supplier: {ex.Message}", "Error",
                          MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class
