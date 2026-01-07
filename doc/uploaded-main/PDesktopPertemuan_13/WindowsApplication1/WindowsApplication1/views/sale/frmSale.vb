Public Class frmSale
    Dim ctrl As New SaleController()
    Private Sub createNew()
        txtKode.Text = ctrl.generateCode()
        txtTglTrans.Text = DateTime.Now
        dgvItems.ReadOnly = False
        dgvItems.Rows.Clear()
        dgvItems.CurrentCell = dgvItems.Rows(0).Cells("itemID")
        dgvItems.BeginEdit(True)
        btnNew.Text = "Batalkan Transaksi [F2]"
        btnNew.BackColor = Color.Aqua
        btnSave.Enabled = True
    End Sub
    Private Sub cancelNew()
        txtKode.Text = ""
        txtTglTrans.Text = ""
        dgvItems.ReadOnly = True
        dgvItems.Rows.Clear()
        btnNew.Text = "Transaksi Baru [F1]"
        btnNew.BackColor = Color.AliceBlue
        btnSave.Enabled = False
    End Sub
    Private Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        If btnNew.Text = "Transaksi Baru [F1]" Then
            createNew()
        Else
            cancelNew()
        End If

    End Sub

    Private Sub frmSale_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.F1 Then
            createNew()
        End If

        If e.KeyCode = Keys.F2 Then
            cancelNew()
        End If
    End Sub

    
    Private Sub dgvItems_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgvItems.CellEndEdit
        If e.ColumnIndex = dgvItems.Columns("itemID").Index Then

            If dgvItems.Rows(e.RowIndex).Cells("itemID").Value Is Nothing Then
                Exit Sub
            End If

            Dim kode As String = dgvItems.Rows(e.RowIndex).Cells("itemID").Value.ToString()

            If kode <> "" Then
                IsiDetailBarang(e.RowIndex, kode)
                HitungSubtotal(e.RowIndex)
            End If

        ElseIf e.ColumnIndex = dgvItems.Columns("qtySale").Index Then
            HitungSubtotal(e.RowIndex)

        End If
    End Sub
    Private Sub HitungSubtotal(rowIndex As Integer)
        Dim qty = CDec(dgvItems.Rows(rowIndex).Cells("qtySale").Value)
        Dim harga = CDec(dgvItems.Rows(rowIndex).Cells("priceSale").Value)

        dgvItems.Rows(rowIndex).Cells("SubTotal").Value = qty * harga

        HitungTotalKeseluruhan()
    End Sub
    Private Sub IsiDetailBarang(rowIndex As Integer, kode As String)
        Dim rowBarang = New ItemController().GetItemById(kode)

        If rowBarang Is Nothing Then
            MsgBox("Kode barang tidak ditemukan")
            dgvItems.Rows(rowIndex).Cells("itemID").Value = ""
            dgvItems.Rows(rowIndex).Cells("itemDesc").Value = ""
            Exit Sub
        End If

        dgvItems.Rows(rowIndex).Cells("itemDesc").Value = rowBarang.itemDesc
        dgvItems.Rows(rowIndex).Cells("priceSale").Value = CDec(rowBarang.salesPrice)
        dgvItems.Rows(rowIndex).Cells("unit").Value = rowBarang.unit

        ' Default jumlah = 1 jika kosong
        If dgvItems.Rows(rowIndex).Cells("qtySale").Value Is Nothing OrElse dgvItems.Rows(rowIndex).Cells("qtySale").Value = "" Then
            dgvItems.Rows(rowIndex).Cells("qtySale").Value = 1
        End If

        HitungSubtotal(rowIndex)
    End Sub

    Private Sub HitungTotalKeseluruhan()
        Dim total As Decimal = 0

        For Each row As DataGridViewRow In dgvItems.Rows
            If Not row.IsNewRow Then
                Dim subTot = CDec(If(row.Cells("SubTotal").Value, 0))
                total += subTot
            End If
        Next

        txtTotal.Text = total.ToString("N0")
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim sale As New SaleModel With {
            .idTrans = txtKode.Text,
            .saleDate = DateTime.Now,
            .details = New List(Of SaleDetailModel)
        }

        For Each row As DataGridViewRow In dgvItems.Rows

            If row.IsNewRow Then Continue For
            Dim val = row.Cells("itemID").Value

            If val Is Nothing OrElse val Is DBNull.Value Then
                Continue For
            End If

            Dim kode As String = val.ToString()
            If kode <> "" Then
                Dim product = New ItemController().GetItemById(kode)

                sale.details.Add(New SaleDetailModel With {
                    .ProductId = product.id,
                    .Qty = CInt(row.Cells(2).Value),
                    .Price = CDec(row.Cells(4).Value),
                    .Subtotal = CDec(row.Cells(5).Value)
                })
            End If

        Next

        If ctrl.SaveNew(sale) Then
            MessageBox.Show("Transaksi berhasil disimpan")
            dgvItems.Rows.Clear()
            txtTotal.Text = "0"
            cancelNew()
        End If
    End Sub
End Class