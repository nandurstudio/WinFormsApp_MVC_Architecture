Public Class frmListItem
    Dim controller As New ItemController
    Private Sub frmListItem_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadGrid()
    End Sub
    Sub LoadGrid()
        DataGridView1.AutoGenerateColumns = False
        Dim dt As DataTable = controller.LoadItems()

        DataGridView1.DataSource = dt
        DataGridView1.Columns("salesPrice").HeaderCell.Style.Alignment =
    DataGridViewContentAlignment.MiddleRight

    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        Dim dv As DataView = CType(DataGridView1.DataSource, DataTable).DefaultView
        dv.RowFilter = "itemDesc LIKE '%" & txtSearch.Text & "%' OR categoryDesc LIKE '%" & txtSearch.Text & "%'"
    End Sub
End Class