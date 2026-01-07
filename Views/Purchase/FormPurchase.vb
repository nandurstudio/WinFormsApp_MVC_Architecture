Imports WinFormsApp_Latihan.Models
Imports WinFormsApp_Latihan.Controllers
Imports System.Globalization

Public Class FormPurchase
    Private ctrl As PurchaseController
    Private itemCtrl As ItemController
    Private supplierCtrl As SupplierController
    Private _config As ConfigModel
    Private indonesianCulture As CultureInfo
    Private _currentUser As UserModel

    Private Sub FormPurchase_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Get logged in user from parent form
        Dim mainForm As FormUtama = TryCast(Me.MdiParent, FormUtama)
        If mainForm IsNot Nothing Then
            _currentUser = mainForm.GetLoggedInUser()
        End If

        InitializeControllers()
        InitializeIndonesianCulture()
        ConfigureDataGridView()
        LoadSuppliers()
        cancelNew()
    End Sub

    Private Sub InitializeControllers()
        Dim settingController As New SettingController()
        _config = settingController.LoadConfiguration()
        ctrl = New PurchaseController(_config)
        itemCtrl = New ItemController(_config)
        supplierCtrl = New SupplierController(_config)
    End Sub

    Private Sub InitializeIndonesianCulture()
        indonesianCulture = New CultureInfo("id-ID")
        indonesianCulture.NumberFormat.CurrencyDecimalDigits = 2
        indonesianCulture.NumberFormat.CurrencyDecimalSeparator = ","
        indonesianCulture.NumberFormat.CurrencyGroupSeparator = "."
        indonesianCulture.NumberFormat.CurrencySymbol = "Rp"
    End Sub

    Private Sub ConfigureDataGridView()
        AddHandler dgvItems.CellFormatting, AddressOf dgvItems_CellFormatting
    End Sub

    Private Sub dgvItems_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs)
        If dgvItems.Columns(e.ColumnIndex).Name = "purchasePrice" OrElse
            dgvItems.Columns(e.ColumnIndex).Name = "SubTotal" Then
            If e.Value IsNot Nothing AndAlso IsNumeric(e.Value) Then
                Dim price As Decimal = Convert.ToDecimal(e.Value)
                e.Value = price.ToString("C2", indonesianCulture)
                e.FormattingApplied = True
            End If
        End If
    End Sub

    Private Sub LoadSuppliers()
        Try
            Dim suppliers = supplierCtrl.GetSuppliersForComboBox()
            cboSupplier.DataSource = suppliers
            cboSupplier.DisplayMember = "SupplierName"
            cboSupplier.ValueMember = "Id"

            If suppliers.Count > 0 Then
                cboSupplier.SelectedIndex = 0
            End If
        Catch ex As Exception
            MessageBox.Show($"Error loading suppliers: {ex.Message}", "Error",
                          MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub createNew()
        txtKode.Text = ctrl.GeneratePurchaseCode()
        txtTglTrans.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")
        cboSupplier.Enabled = True
        dgvItems.ReadOnly = False
        dgvItems.Rows.Clear()
        If dgvItems.Rows.Count > 0 Then
            dgvItems.CurrentCell = dgvItems.Rows(0).Cells("itemID")
            dgvItems.BeginEdit(True)
        End If
        btnNew.Text = "Batal [F2]"
        btnNew.BackColor = Color.IndianRed
        btnSave.Enabled = True
        txtTotal.Text = "Rp 0"
    End Sub

    Private Sub cancelNew()
        txtKode.Text = ""
        txtTglTrans.Text = ""
        txtTotal.Text = "Rp 0"
        cboSupplier.Enabled = False
        dgvItems.ReadOnly = True
        dgvItems.Rows.Clear()
        btnNew.Text = "Pembelian Baru [F1]"
        btnNew.BackColor = Color.LightGreen
        btnSave.Enabled = False
    End Sub

    Private Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        If btnNew.Text.Contains("Batal") Then
            If MessageBox.Show("Batalkan transaksi ini?", "Konfirmasi",
                                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                cancelNew()
            End If
        Else
            createNew()
        End If
    End Sub

    Private Sub FormPurchase_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.F1 And btnNew.Enabled Then
            createNew()
        ElseIf e.KeyCode = Keys.F2 And btnNew.Text.Contains("Batal") Then
            cancelNew()
        ElseIf e.KeyCode = Keys.F3 And btnSave.Enabled Then
            btnSave_Click(sender, e)
        End If
    End Sub

    Private Sub dgvItems_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgvItems.CellEndEdit
        If e.ColumnIndex = dgvItems.Columns("itemID").Index Then
            If dgvItems.Rows(e.RowIndex).Cells("itemID").Value Is Nothing Then
                Exit Sub
            End If

            Dim kode As String = dgvItems.Rows(e.RowIndex).Cells("itemID").Value.ToString()
            If kode <> "" Then
                IsiDetailBarang(e.RowIndex, CInt(kode))
                HitungSubtotal(e.RowIndex)
            End If

        ElseIf e.ColumnIndex = dgvItems.Columns("qtyPurchase").Index Then
            HitungSubtotal(e.RowIndex)
        ElseIf e.ColumnIndex = dgvItems.Columns("purchasePrice").Index Then
            HitungSubtotal(e.RowIndex)
        End If
    End Sub

    Private Sub HitungSubtotal(rowIndex As Integer)
        If dgvItems.Rows(rowIndex).Cells("qtyPurchase").Value Is Nothing OrElse
            dgvItems.Rows(rowIndex).Cells("purchasePrice").Value Is Nothing Then
            Return
        End If

        Dim qty As Decimal = CDec(dgvItems.Rows(rowIndex).Cells("qtyPurchase").Value)
        Dim harga As Decimal = CDec(dgvItems.Rows(rowIndex).Cells("purchasePrice").Value)

        dgvItems.Rows(rowIndex).Cells("SubTotal").Value = qty * harga

        HitungTotalKeseluruhan()
    End Sub

    Private Sub IsiDetailBarang(rowIndex As Integer, itemId As Integer)
        Try
            Dim item As ItemModel = itemCtrl.GetItemById(itemId)

            If item Is Nothing Then
                MessageBox.Show("Item tidak ditemukan", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                dgvItems.Rows(rowIndex).Cells("itemID").Value = ""
                dgvItems.Rows(rowIndex).Cells("itemDesc").Value = ""
                Exit Sub
            End If

            dgvItems.Rows(rowIndex).Cells("itemDesc").Value = item.ItemDesc
            dgvItems.Rows(rowIndex).Cells("purchasePrice").Value = item.SalesPrice * 0.7 ' Default: 70% dari harga jual
            dgvItems.Rows(rowIndex).Cells("unit").Value = item.Unit

            ' Default jumlah = 1 jika kosong
            If dgvItems.Rows(rowIndex).Cells("qtyPurchase").Value Is Nothing OrElse
                dgvItems.Rows(rowIndex).Cells("qtyPurchase").Value.ToString() = "" Then
                dgvItems.Rows(rowIndex).Cells("qtyPurchase").Value = 1
            End If

            HitungSubtotal(rowIndex)
        Catch ex As Exception
            MessageBox.Show($"Error loading item: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub HitungTotalKeseluruhan()
        Dim total As Decimal = 0

        For Each row As DataGridViewRow In dgvItems.Rows
            If Not row.IsNewRow AndAlso row.Cells("SubTotal").Value IsNot Nothing Then
                Dim subTot As Decimal = CDec(If(row.Cells("SubTotal").Value, 0))
                total += subTot
            End If
        Next

        txtTotal.Text = total.ToString("C2", indonesianCulture)
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            ' Validasi supplier
            If cboSupplier.SelectedValue Is Nothing Then
                MessageBox.Show("Pilih supplier terlebih dahulu!", "Validation",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning)
                cboSupplier.Focus()
                Return
            End If

            ' Validasi ada item atau tidak
            Dim hasValidItem As Boolean = False
            For Each row As DataGridViewRow In dgvItems.Rows
                If Not row.IsNewRow AndAlso row.Cells("itemID").Value IsNot Nothing AndAlso
                    row.Cells("itemID").Value.ToString() <> "" Then
                    hasValidItem = True
                    Exit For
                End If
            Next

            If Not hasValidItem Then
                MessageBox.Show("Tidak ada item dalam transaksi!", "Validation",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            ' Buat object purchase
            Dim purchase As New PurchaseModel With {
                .IdPurchase = txtKode.Text,
                .PurchaseDate = DateTime.Now,
                .SupplierId = CInt(cboSupplier.SelectedValue),
                .Status = "completed"
            }

            ' Ambil semua detail item
            Dim details As New List(Of PurchaseDetailModel)
            For Each row As DataGridViewRow In dgvItems.Rows
                If row.IsNewRow Then Continue For

                Dim val = row.Cells("itemID").Value
                If val Is Nothing OrElse val Is DBNull.Value OrElse val.ToString() = "" Then
                    Continue For
                End If

                Dim itemId As Integer = CInt(val)
                Dim item As ItemModel = itemCtrl.GetItemById(itemId)

                If item IsNot Nothing Then
                    Dim qty As Integer = CInt(row.Cells("qtyPurchase").Value)
                    Dim price As Decimal = CDec(row.Cells("purchasePrice").Value)

                    details.Add(New PurchaseDetailModel With {
                        .IdPurchase = purchase.IdPurchase,
                        .ItemID = item.ItemID,
                        .QtyPurchase = qty,
                        .PurchasePrice = price,
                        .Subtotal = qty * price
                    })
                End If
            Next

            ' Hitung total
            purchase.TotalAmount = details.Sum(Function(d) d.Subtotal)

            ' Get user ID
            Dim userId As Integer = If(_currentUser IsNot Nothing, _currentUser.UserId, 1)

            ' Simpan ke database
            If ctrl.CreatePurchase(purchase, details, userId) Then
                Dim supplierName As String = cboSupplier.Text
                MessageBox.Show($"Transaksi pembelian berhasil disimpan!{vbCrLf}" &
                              $"No. Nota: {purchase.IdPurchase}{vbCrLf}" &
                              $"Supplier: {supplierName}{vbCrLf}" &
                              $"Total: {purchase.TotalAmount.ToString("C2", indonesianCulture)}{vbCrLf}" &
                              $"Jumlah Item: {details.Count}",
                              "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                cancelNew()
            End If
        Catch ex As Exception
            MessageBox.Show($"Error saving transaction: {ex.Message}", "Error",
                          MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class
