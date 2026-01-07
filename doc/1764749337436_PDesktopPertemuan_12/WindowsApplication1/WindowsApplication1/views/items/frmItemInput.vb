Public Class frmItemInput

    Dim controller As New ItemController
    Dim categoryController As New CategoryController
    Dim editedID As Integer = -1

    Sub loadCategoryList()
        Dim dt As New DataTable
        dt = categoryController.LoadCategory()
        Dim row As DataRow = dt.NewRow()
        cboItemCate.DataSource = Nothing

        row("id") = 0
        row("categoryDesc") = "--Add Category--"
        dt.Rows.InsertAt(row, 999)

        If dt.Rows.Count = 0 Then
            cboItemCate.Items.Clear()
            MessageBox.Show("Data kategori kosong.")
            Return
        End If

        cboItemCate.DataSource = dt
        cboItemCate.DisplayMember = "categoryDesc"
        cboItemCate.ValueMember = "id"
        cboItemCate.SelectedIndex = -1
    End Sub
    Sub New()
        InitializeComponent()
        loadCategoryList()
        txtItemId.Text = New ItemModel().GenerateItemCode()

    End Sub
    Sub New(item As ItemModel)
        InitializeComponent()
        loadCategoryList()

        Dim category = categoryController.getCategory(item.itemCate)
        Dim index As Integer = cboItemCate.FindStringExact(category.category_desc)

        cboItemCate.SelectedIndex = index

        With item
            editedID = .id
            txtItemId.Text = .itemID
            txtItemDesc.Text = .itemDesc
            cboItemCate.Text = .itemCate
            txtUnit.Text = .unit
            txtSalesPrice.Text = .salesPrice
            txtMinStock.Text = .minStock
        End With

    End Sub
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim item As New ItemModel With {
        .itemID = txtItemId.Text,
        .itemDesc = txtItemDesc.Text,
        .unit = txtUnit.Text,
        .salesPrice = txtSalesPrice.Text,
        .minStock = txtMinStock.Text,
        .itemCate = Convert.ToInt32(cboItemCate.SelectedValue)
       }

        If editedID = -1 Then
            controller.Create(item)
        Else
            item.id = editedID
            controller.Update(item)
        End If

        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub

    Private Sub cboItemCate_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboItemCate.SelectedIndexChanged
        If cboItemCate.SelectedIndex = cboItemCate.Items.Count - 1 Then
            Dim frm As New frmAddCategory
            If frm.ShowDialog() = DialogResult.OK Then
                loadCategoryList()
                Dim index As Integer = cboItemCate.FindStringExact(frm.txtCategory.Text)
                cboItemCate.SelectedIndex = index
            Else
                loadCategoryList()
            End If
        End If
    End Sub
End Class