<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormItemList
	Inherits System.Windows.Forms.Form

	'Form overrides dispose to clean up the component list.
	<System.Diagnostics.DebuggerNonUserCode()>
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
	<System.Diagnostics.DebuggerStepThrough()>
	Private Sub InitializeComponent()
		Dim DataGridViewCellStyle1 As DataGridViewCellStyle = New DataGridViewCellStyle()
		Dim DataGridViewCellStyle2 As DataGridViewCellStyle = New DataGridViewCellStyle()
		Dim DataGridViewCellStyle3 As DataGridViewCellStyle = New DataGridViewCellStyle()
		Dim DataGridViewCellStyle4 As DataGridViewCellStyle = New DataGridViewCellStyle()
		Panel1 = New Panel()
		btnDelete = New Button()
		btnEdit = New Button()
		btnAdd = New Button()
		txtSearch = New TextBox()
		Label1 = New Label()
		DataGridView1 = New DataGridView()
		ID = New DataGridViewTextBoxColumn()
		itemCate = New DataGridViewTextBoxColumn()
		itemID = New DataGridViewTextBoxColumn()
		itemDesc = New DataGridViewTextBoxColumn()
		categoryDesc = New DataGridViewTextBoxColumn()
		unit = New DataGridViewTextBoxColumn()
		salesPrice = New DataGridViewTextBoxColumn()
		minStock = New DataGridViewTextBoxColumn()
		createdAt = New DataGridViewTextBoxColumn()
		updatedAt = New DataGridViewTextBoxColumn()
		Panel1.SuspendLayout()
		CType(DataGridView1, ComponentModel.ISupportInitialize).BeginInit()
		SuspendLayout()
		' 
		' Panel1
		' 
		Panel1.Controls.Add(btnDelete)
		Panel1.Controls.Add(btnEdit)
		Panel1.Controls.Add(btnAdd)
		Panel1.Controls.Add(txtSearch)
		Panel1.Controls.Add(Label1)
		Panel1.Dock = DockStyle.Top
		Panel1.Location = New Point(0, 0)
		Panel1.Margin = New Padding(4, 3, 4, 3)
		Panel1.Name = "Panel1"
		Panel1.Size = New Size(1000, 54)
		Panel1.TabIndex = 0
		' 
		' btnDelete
		' 
		btnDelete.Location = New Point(544, 10)
		btnDelete.Margin = New Padding(4, 3, 4, 3)
		btnDelete.Name = "btnDelete"
		btnDelete.Size = New Size(71, 30)
		btnDelete.TabIndex = 4
		btnDelete.Text = "Delete"
		btnDelete.UseVisualStyleBackColor = True
		' 
		' btnEdit
		' 
		btnEdit.Location = New Point(465, 10)
		btnEdit.Margin = New Padding(4, 3, 4, 3)
		btnEdit.Name = "btnEdit"
		btnEdit.Size = New Size(71, 30)
		btnEdit.TabIndex = 3
		btnEdit.Text = "Edit"
		btnEdit.UseVisualStyleBackColor = True
		' 
		' btnAdd
		' 
		btnAdd.Location = New Point(387, 10)
		btnAdd.Margin = New Padding(4, 3, 4, 3)
		btnAdd.Name = "btnAdd"
		btnAdd.Size = New Size(71, 30)
		btnAdd.TabIndex = 2
		btnAdd.Text = "Add Item"
		btnAdd.UseVisualStyleBackColor = True
		' 
		' txtSearch
		' 
		txtSearch.Location = New Point(88, 17)
		txtSearch.Margin = New Padding(4, 3, 4, 3)
		txtSearch.Name = "txtSearch"
		txtSearch.PlaceholderText = "Cari nama barang..."
		txtSearch.Size = New Size(248, 23)
		txtSearch.TabIndex = 1
		' 
		' Label1
		' 
		Label1.AutoSize = True
		Label1.Location = New Point(14, 21)
		Label1.Margin = New Padding(4, 0, 4, 0)
		Label1.Name = "Label1"
		Label1.Size = New Size(42, 15)
		Label1.TabIndex = 0
		Label1.Text = "Search"
		' 
		' DataGridView1
		' 
		DataGridView1.AllowUserToOrderColumns = True
		DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
		DataGridView1.Columns.AddRange(New DataGridViewColumn() {ID, itemCate, itemID, itemDesc, categoryDesc, unit, salesPrice, minStock, createdAt, updatedAt})
		DataGridView1.Dock = DockStyle.Fill
		DataGridView1.Location = New Point(0, 54)
		DataGridView1.Margin = New Padding(4, 3, 4, 3)
		DataGridView1.Name = "DataGridView1"
		DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect
		DataGridView1.Size = New Size(1000, 299)
		DataGridView1.TabIndex = 1
		' 
		' ID
		' 
		ID.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
		ID.DataPropertyName = "id"
		ID.HeaderText = "ID"
		ID.Name = "ID"
		ID.Visible = False
		' 
		' itemCate
		' 
		itemCate.DataPropertyName = "itemCate"
		itemCate.HeaderText = "itemCate"
		itemCate.Name = "itemCate"
		itemCate.Visible = False
		' 
		' itemID
		' 
		itemID.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
		itemID.DataPropertyName = "itemID"
		itemID.HeaderText = "Item ID"
		itemID.Name = "itemID"
		itemID.Width = 65
		' 
		' itemDesc
		' 
		itemDesc.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
		itemDesc.DataPropertyName = "itemDesc"
		itemDesc.HeaderText = "Item Description"
		itemDesc.Name = "itemDesc"
		' 
		' categoryDesc
		' 
		categoryDesc.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
		categoryDesc.DataPropertyName = "categoryDesc"
		categoryDesc.HeaderText = "Item Category"
		categoryDesc.Name = "categoryDesc"
		categoryDesc.Width = 98
		' 
		' unit
		' 
		unit.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
		unit.DataPropertyName = "unit"
		unit.HeaderText = "Unit"
		unit.Name = "unit"
		unit.Width = 54
		' 
		' salesPrice
		' 
		salesPrice.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
		salesPrice.DataPropertyName = "salesPrice"
		DataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleRight
		salesPrice.DefaultCellStyle = DataGridViewCellStyle1
		salesPrice.HeaderText = "Sales Price"
		salesPrice.Name = "salesPrice"
		salesPrice.Width = 80
		' 
		' minStock
		' 
		minStock.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
		minStock.DataPropertyName = "minStock"
		DataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleRight
		minStock.DefaultCellStyle = DataGridViewCellStyle2
		minStock.HeaderText = "Min. Stock"
		minStock.Name = "minStock"
		minStock.Width = 81
		' 
		' createdAt
		' 
		createdAt.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
		createdAt.DataPropertyName = "created_at"
		DataGridViewCellStyle3.Format = "dd/MM/yyyy HH:mm"
		createdAt.DefaultCellStyle = DataGridViewCellStyle3
		createdAt.HeaderText = "Created Date"
		createdAt.Name = "createdAt"
		createdAt.Width = 92
		' 
		' updatedAt
		' 
		updatedAt.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
		updatedAt.DataPropertyName = "updated_at"
		DataGridViewCellStyle4.Format = "dd/MM/yyyy HH:mm"
		updatedAt.DefaultCellStyle = DataGridViewCellStyle4
		updatedAt.HeaderText = "Updated Date"
		updatedAt.Name = "updatedAt"
		updatedAt.Width = 96
		' 
		' FormItemList
		' 
		AutoScaleDimensions = New SizeF(7F, 15F)
		AutoScaleMode = AutoScaleMode.Font
		ClientSize = New Size(1000, 353)
		Controls.Add(DataGridView1)
		Controls.Add(Panel1)
		Margin = New Padding(4, 3, 4, 3)
		Name = "FormItemList"
		Text = "Kelola Barang"
		Panel1.ResumeLayout(False)
		Panel1.PerformLayout()
		CType(DataGridView1, ComponentModel.ISupportInitialize).EndInit()
		ResumeLayout(False)

	End Sub
	Friend WithEvents Panel1 As System.Windows.Forms.Panel
	Friend WithEvents btnAdd As System.Windows.Forms.Button
	Friend WithEvents txtSearch As System.Windows.Forms.TextBox
	Friend WithEvents Label1 As System.Windows.Forms.Label
	Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
	Friend WithEvents btnDelete As System.Windows.Forms.Button
	Friend WithEvents btnEdit As System.Windows.Forms.Button
	Friend WithEvents ID As DataGridViewTextBoxColumn
	Friend WithEvents itemCate As DataGridViewTextBoxColumn
	Friend WithEvents itemID As DataGridViewTextBoxColumn
	Friend WithEvents itemDesc As DataGridViewTextBoxColumn
	Friend WithEvents categoryDesc As DataGridViewTextBoxColumn
	Friend WithEvents unit As DataGridViewTextBoxColumn
	Friend WithEvents salesPrice As DataGridViewTextBoxColumn
	Friend WithEvents minStock As DataGridViewTextBoxColumn
	Friend WithEvents createdAt As DataGridViewTextBoxColumn
	Friend WithEvents updatedAt As DataGridViewTextBoxColumn
End Class
