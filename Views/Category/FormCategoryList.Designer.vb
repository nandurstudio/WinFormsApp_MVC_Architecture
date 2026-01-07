<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormCategoryList
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
		Panel1 = New Panel()
		btnEdit = New Button()
		btnAdd = New Button()
		txtSearch = New TextBox()
		Label1 = New Label()
		DataGridView1 = New DataGridView()
		ID = New DataGridViewTextBoxColumn()
		categoryID = New DataGridViewTextBoxColumn()
		categoryDesc = New DataGridViewTextBoxColumn()
		created_at = New DataGridViewTextBoxColumn()
		updated_at = New DataGridViewTextBoxColumn()
		Panel1.SuspendLayout()
		CType(DataGridView1, ComponentModel.ISupportInitialize).BeginInit()
		SuspendLayout()
		' 
		' Panel1
		' 
		Panel1.Controls.Add(btnEdit)
		Panel1.Controls.Add(btnAdd)
		Panel1.Controls.Add(txtSearch)
		Panel1.Controls.Add(Label1)
		Panel1.Dock = DockStyle.Top
		Panel1.Location = New Point(0, 0)
		Panel1.Margin = New Padding(4, 3, 4, 3)
		Panel1.Name = "Panel1"
		Panel1.Size = New Size(700, 54)
		Panel1.TabIndex = 0
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
		btnAdd.Text = "Add"
		btnAdd.UseVisualStyleBackColor = True
		' 
		' txtSearch
		' 
		txtSearch.Location = New Point(88, 17)
		txtSearch.Margin = New Padding(4, 3, 4, 3)
		txtSearch.Name = "txtSearch"
		txtSearch.PlaceholderText = "Cari deskripsi kategori..."
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
		DataGridView1.AllowUserToAddRows = False
		DataGridView1.AllowUserToDeleteRows = False
		DataGridView1.AllowUserToOrderColumns = True
		DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
		DataGridView1.Columns.AddRange(New DataGridViewColumn() {ID, categoryID, categoryDesc, created_at, updated_at})
		DataGridView1.Dock = DockStyle.Fill
		DataGridView1.Location = New Point(0, 54)
		DataGridView1.Margin = New Padding(4, 3, 4, 3)
		DataGridView1.Name = "DataGridView1"
		DataGridView1.ReadOnly = True
		DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect
		DataGridView1.Size = New Size(700, 346)
		DataGridView1.TabIndex = 1
		' 
		' ID
		' 
		ID.DataPropertyName = "id"
		ID.HeaderText = "ID"
		ID.Name = "ID"
		ID.ReadOnly = True
		ID.Visible = False
		' 
		' categoryID
		' 
		categoryID.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
		categoryID.DataPropertyName = "id"
		categoryID.HeaderText = "Category ID"
		categoryID.Name = "categoryID"
		categoryID.ReadOnly = True
		categoryID.Width = 87
		' 
		' categoryDesc
		' 
		categoryDesc.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
		categoryDesc.DataPropertyName = "categoryDesc"
		categoryDesc.HeaderText = "Category Description"
		categoryDesc.Name = "categoryDesc"
		categoryDesc.ReadOnly = True
		' 
		' created_at
		' 
		created_at.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
		created_at.DataPropertyName = "created_at"
		DataGridViewCellStyle1.Format = "dd/MM/yyyy HH:mm"
		created_at.DefaultCellStyle = DataGridViewCellStyle1
		created_at.HeaderText = "Created Date"
		created_at.Name = "created_at"
		created_at.ReadOnly = True
		created_at.Width = 92
		' 
		' updated_at
		' 
		updated_at.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
		updated_at.DataPropertyName = "updated_at"
		DataGridViewCellStyle2.Format = "dd/MM/yyyy HH:mm"
		updated_at.DefaultCellStyle = DataGridViewCellStyle2
		updated_at.HeaderText = "Updated Date"
		updated_at.Name = "updated_at"
		updated_at.ReadOnly = True
		updated_at.Width = 96
		' 
		' FormCategoryList
		' 
		AutoScaleDimensions = New SizeF(7F, 15F)
		AutoScaleMode = AutoScaleMode.Font
		ClientSize = New Size(700, 400)
		Controls.Add(DataGridView1)
		Controls.Add(Panel1)
		Margin = New Padding(4, 3, 4, 3)
		Name = "FormCategoryList"
		Text = "Kelola Kategori"
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
	Friend WithEvents btnEdit As System.Windows.Forms.Button
	Friend WithEvents ID As DataGridViewTextBoxColumn
	Friend WithEvents categoryID As DataGridViewTextBoxColumn
	Friend WithEvents categoryDesc As DataGridViewTextBoxColumn
	Friend WithEvents created_at As DataGridViewTextBoxColumn
	Friend WithEvents updated_at As DataGridViewTextBoxColumn
End Class
