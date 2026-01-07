<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormSupplierList
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
      Panel1 = New Panel()
      btnDelete = New Button()
      btnEdit = New Button()
      btnAdd = New Button()
      txtSearch = New TextBox()
      Label1 = New Label()
      DataGridView1 = New DataGridView()
      id = New DataGridViewTextBoxColumn()
      supplierCode = New DataGridViewTextBoxColumn()
      supplierName = New DataGridViewTextBoxColumn()
      contact = New DataGridViewTextBoxColumn()
      phone = New DataGridViewTextBoxColumn()
      email = New DataGridViewTextBoxColumn()
      address = New DataGridViewTextBoxColumn()
      city = New DataGridViewTextBoxColumn()
      created_at = New DataGridViewTextBoxColumn()
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
      btnAdd.Size = New Size(88, 30)
      btnAdd.TabIndex = 2
      btnAdd.Text = "Add Supplier"
      btnAdd.UseVisualStyleBackColor = True
      ' 
      ' txtSearch
      ' 
      txtSearch.Location = New Point(88, 17)
      txtSearch.Margin = New Padding(4, 3, 4, 3)
      txtSearch.Name = "txtSearch"
      txtSearch.PlaceholderText = "Cari nama supplier atau kota..."
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
      DataGridView1.Columns.AddRange(New DataGridViewColumn() {id, supplierCode, supplierName, contact, phone, email, address, city, created_at})
      DataGridView1.Dock = DockStyle.Fill
      DataGridView1.Location = New Point(0, 54)
      DataGridView1.Margin = New Padding(4, 3, 4, 3)
      DataGridView1.MultiSelect = False
      DataGridView1.Name = "DataGridView1"
      DataGridView1.ReadOnly = True
      DataGridView1.RowHeadersWidth = 51
      DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect
      DataGridView1.Size = New Size(1000, 299)
      DataGridView1.TabIndex = 1
      ' 
      ' id
      ' 
      id.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
      id.DataPropertyName = "id"
      id.HeaderText = "ID"
      id.Name = "id"
      id.ReadOnly = True
      id.Visible = False
      ' 
      ' supplierCode
      ' 
      supplierCode.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
      supplierCode.DataPropertyName = "supplierCode"
      supplierCode.HeaderText = "Kode Supplier"
      supplierCode.Name = "supplierCode"
      supplierCode.ReadOnly = True
      ' 
      ' supplierName
      ' 
      supplierName.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
      supplierName.DataPropertyName = "supplierName"
      supplierName.HeaderText = "Nama Supplier"
      supplierName.Name = "supplierName"
      supplierName.ReadOnly = True
      ' 
      ' contact
      ' 
      contact.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
      contact.DataPropertyName = "contact"
      contact.HeaderText = "Contact Person"
      contact.Name = "contact"
      contact.ReadOnly = True
      ' 
      ' phone
      ' 
      phone.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
      phone.DataPropertyName = "phone"
      phone.HeaderText = "Telepon"
      phone.Name = "phone"
      phone.ReadOnly = True
      ' 
      ' email
      ' 
      email.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
      email.DataPropertyName = "email"
      email.HeaderText = "Email"
      email.Name = "email"
      email.ReadOnly = True
      ' 
      ' address
      ' 
      address.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
      address.DataPropertyName = "address"
      address.HeaderText = "Alamat"
      address.Name = "address"
      address.ReadOnly = True
      ' 
      ' city
      ' 
      city.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
      city.DataPropertyName = "city"
      city.HeaderText = "Kota"
      city.Name = "city"
      city.ReadOnly = True
      ' 
      ' created_at
      ' 
      created_at.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
      created_at.DataPropertyName = "created_at"
      Dim DataGridViewCellStyle1 As DataGridViewCellStyle = New DataGridViewCellStyle()
      DataGridViewCellStyle1.Format = "dd/MM/yyyy HH:mm"
      created_at.DefaultCellStyle = DataGridViewCellStyle1
      created_at.HeaderText = "Created Date"
      created_at.Name = "created_at"
      created_at.ReadOnly = True
      ' 
      ' FormSupplierList
      ' 
      AutoScaleDimensions = New SizeF(7.0F, 15.0F)
      AutoScaleMode = AutoScaleMode.Font
      ClientSize = New Size(1000, 353)
      Controls.Add(DataGridView1)
      Controls.Add(Panel1)
      Margin = New Padding(4, 3, 4, 3)
      Name = "FormSupplierList"
      Text = "Kelola Supplier"
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
   Friend WithEvents id As DataGridViewTextBoxColumn
   Friend WithEvents supplierCode As DataGridViewTextBoxColumn
   Friend WithEvents supplierName As DataGridViewTextBoxColumn
   Friend WithEvents contact As DataGridViewTextBoxColumn
   Friend WithEvents phone As DataGridViewTextBoxColumn
   Friend WithEvents email As DataGridViewTextBoxColumn
   Friend WithEvents address As DataGridViewTextBoxColumn
   Friend WithEvents city As DataGridViewTextBoxColumn
   Friend WithEvents created_at As DataGridViewTextBoxColumn
End Class
