<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormSale
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.  
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> _
	Private Sub InitializeComponent()
		Dim DataGridViewCellStyle1 As DataGridViewCellStyle = New DataGridViewCellStyle()
		Dim DataGridViewCellStyle2 As DataGridViewCellStyle = New DataGridViewCellStyle()
		Dim DataGridViewCellStyle3 As DataGridViewCellStyle = New DataGridViewCellStyle()
		Panel1 = New Panel()
		btnSave = New Button()
		btnNew = New Button()
		Label2 = New Label()
		txtTglTrans = New TextBox()
		Label1 = New Label()
		txtKode = New TextBox()
		dgvItems = New DataGridView()
		ItemID = New DataGridViewTextBoxColumn()
		itemDesc = New DataGridViewTextBoxColumn()
		qtySale = New DataGridViewTextBoxColumn()
		unit = New DataGridViewTextBoxColumn()
		priceSale = New DataGridViewTextBoxColumn()
		SubTotal = New DataGridViewTextBoxColumn()
		Panel3 = New Panel()
		Label3 = New Label()
		txtTotal = New TextBox()
		Panel1.SuspendLayout()
		CType(dgvItems, ComponentModel.ISupportInitialize).BeginInit()
		Panel3.SuspendLayout()
		SuspendLayout()
		' 
		' Panel1
		' 
		Panel1.Controls.Add(btnSave)
		Panel1.Controls.Add(btnNew)
		Panel1.Controls.Add(Label2)
		Panel1.Controls.Add(txtTglTrans)
		Panel1.Controls.Add(Label1)
		Panel1.Controls.Add(txtKode)
		Panel1.Dock = DockStyle.Top
		Panel1.Location = New Point(0, 0)
		Panel1.Margin = New Padding(4, 3, 4, 3)
		Panel1.Name = "Panel1"
		Panel1.Size = New Size(1000, 65)
		Panel1.TabIndex = 0
		' 
		' btnSave
		' 
		btnSave.Enabled = False
		btnSave.Location = New Point(761, 14)
		btnSave.Margin = New Padding(4, 3, 4, 3)
		btnSave.Name = "btnSave"
		btnSave.Size = New Size(118, 40)
		btnSave.TabIndex = 8
		btnSave.Text = "Simpan [F3]"
		btnSave.UseVisualStyleBackColor = True
		' 
		' btnNew
		' 
		btnNew.Location = New Point(636, 14)
		btnNew.Margin = New Padding(4, 3, 4, 3)
		btnNew.Name = "btnNew"
		btnNew.Size = New Size(118, 40)
		btnNew.TabIndex = 7
		btnNew.Text = "Transaksi Baru [F1]"
		btnNew.UseVisualStyleBackColor = True
		' 
		' Label2
		' 
		Label2.AutoSize = True
		Label2.Location = New Point(252, 24)
		Label2.Margin = New Padding(4, 0, 4, 0)
		Label2.Name = "Label2"
		Label2.Size = New Size(49, 15)
		Label2.TabIndex = 6
		Label2.Text = "Tanggal"
		' 
		' txtTglTrans
		' 
		txtTglTrans.Enabled = False
		txtTglTrans.Location = New Point(313, 21)
		txtTglTrans.Margin = New Padding(4, 3, 4, 3)
		txtTglTrans.Name = "txtTglTrans"
		txtTglTrans.Size = New Size(200, 23)
		txtTglTrans.TabIndex = 7
		' 
		' Label1
		' 
		Label1.AutoSize = True
		Label1.Location = New Point(14, 24)
		Label1.Margin = New Padding(4, 0, 4, 0)
		Label1.Name = "Label1"
		Label1.Size = New Size(66, 15)
		Label1.TabIndex = 4
		Label1.Text = "No. Nota"
		' 
		' txtKode
		' 
		txtKode.Enabled = False
		txtKode.Location = New Point(88, 21)
		txtKode.Margin = New Padding(4, 3, 4, 3)
		txtKode.Name = "txtKode"
		txtKode.Size = New Size(150, 23)
		txtKode.TabIndex = 5
		' 
		' dgvItems
		' 
		dgvItems.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
		dgvItems.Columns.AddRange(New DataGridViewColumn() {ItemID, itemDesc, qtySale, unit, priceSale, SubTotal})
		dgvItems.Dock = DockStyle.Fill
		dgvItems.Location = New Point(0, 65)
		dgvItems.Margin = New Padding(4, 3, 4, 3)
		dgvItems.Name = "dgvItems"
		dgvItems.ReadOnly = True
		dgvItems.SelectionMode = DataGridViewSelectionMode.FullRowSelect
		dgvItems.Size = New Size(1000, 335)
		dgvItems.TabIndex = 1
		' 
		' ItemID
		' 
		ItemID.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
		ItemID.HeaderText = "Kode"
		ItemID.Name = "ItemID"
		ItemID.ReadOnly = True
		' 
		' itemDesc
		' 
		itemDesc.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
		itemDesc.HeaderText = "Nama Barang"
		itemDesc.Name = "itemDesc"
		itemDesc.ReadOnly = True
		' 
		' qtySale
		' 
		qtySale.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
		DataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleRight
		qtySale.DefaultCellStyle = DataGridViewCellStyle1
		qtySale.HeaderText = "Jumlah"
		qtySale.Name = "qtySale"
		qtySale.ReadOnly = True
		' 
		' unit
		' 
		unit.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
		unit.HeaderText = "Satuan"
		unit.Name = "unit"
		unit.ReadOnly = True
		' 
		' priceSale
		' 
		priceSale.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
		DataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleRight
		priceSale.DefaultCellStyle = DataGridViewCellStyle2
		priceSale.HeaderText = "Harga"
		priceSale.Name = "priceSale"
		priceSale.ReadOnly = True
		' 
		' SubTotal
		' 
		SubTotal.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
		DataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleRight
		SubTotal.DefaultCellStyle = DataGridViewCellStyle3
		SubTotal.HeaderText = "Sub Total"
		SubTotal.Name = "SubTotal"
		SubTotal.ReadOnly = True
		' 
		' Panel3
		' 
		Panel3.Controls.Add(Label3)
		Panel3.Controls.Add(txtTotal)
		Panel3.Dock = DockStyle.Bottom
		Panel3.Location = New Point(0, 400)
		Panel3.Margin = New Padding(4, 3, 4, 3)
		Panel3.Name = "Panel3"
		Panel3.Size = New Size(1000, 50)
		Panel3.TabIndex = 2
		' 
		' Label3
		' 
		Label3.AutoSize = True
		Label3.Font = New Font("Microsoft Sans Serif", 12.0F, FontStyle.Bold, GraphicsUnit.Point)
		Label3.Location = New Point(650, 15)
		Label3.Margin = New Padding(4, 0, 4, 0)
		Label3.Name = "Label3"
		Label3.Size = New Size(70, 20)
		Label3.TabIndex = 6
		Label3.Text = "TOTAL:"
		' 
		' txtTotal
		' 
		txtTotal.Font = New Font("Microsoft Sans Serif", 12.0F, FontStyle.Bold, GraphicsUnit.Point)
		txtTotal.Location = New Point(730, 12)
		txtTotal.Margin = New Padding(4, 3, 4, 3)
		txtTotal.Name = "txtTotal"
		txtTotal.ReadOnly = True
		txtTotal.Size = New Size(250, 26)
		txtTotal.TabIndex = 7
		txtTotal.Text = "Rp 0"
		txtTotal.TextAlign = HorizontalAlignment.Right
		' 
		' FormSale
		' 
		AutoScaleDimensions = New SizeF(7.0F, 15.0F)
		AutoScaleMode = AutoScaleMode.Font
		ClientSize = New Size(1000, 450)
		Controls.Add(dgvItems)
		Controls.Add(Panel3)
		Controls.Add(Panel1)
		KeyPreview = True
		Margin = New Padding(4, 3, 4, 3)
		Name = "FormSale"
		Text = "Transaksi Penjualan"
		Panel1.ResumeLayout(False)
		Panel1.PerformLayout()
		CType(dgvItems, ComponentModel.ISupportInitialize).EndInit()
		Panel3.ResumeLayout(False)
		Panel3.PerformLayout()
		ResumeLayout(False)

	End Sub
	Friend WithEvents Panel1 As System.Windows.Forms.Panel
	Friend WithEvents Label2 As System.Windows.Forms.Label
	Friend WithEvents txtTglTrans As System.Windows.Forms.TextBox
	Friend WithEvents Label1 As System.Windows.Forms.Label
	Friend WithEvents txtKode As System.Windows.Forms.TextBox
	Friend WithEvents dgvItems As System.Windows.Forms.DataGridView
	Friend WithEvents Panel3 As System.Windows.Forms.Panel
	Friend WithEvents Label3 As System.Windows.Forms.Label
	Friend WithEvents txtTotal As System.Windows.Forms.TextBox
	Friend WithEvents btnNew As System.Windows.Forms.Button
	Friend WithEvents ItemID As System.Windows.Forms.DataGridViewTextBoxColumn
	Friend WithEvents itemDesc As System.Windows.Forms.DataGridViewTextBoxColumn
	Friend WithEvents qtySale As System.Windows.Forms.DataGridViewTextBoxColumn
	Friend WithEvents unit As System.Windows.Forms.DataGridViewTextBoxColumn
	Friend WithEvents priceSale As System.Windows.Forms.DataGridViewTextBoxColumn
	Friend WithEvents SubTotal As System.Windows.Forms.DataGridViewTextBoxColumn
	Friend WithEvents btnSave As System.Windows.Forms.Button
End Class
