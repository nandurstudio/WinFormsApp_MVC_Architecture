<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormUserList
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
        user_id = New DataGridViewTextBoxColumn()
        username = New DataGridViewTextBoxColumn()
        email = New DataGridViewTextBoxColumn()
        role = New DataGridViewTextBoxColumn()
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
        btnAdd.Size = New Size(71, 30)
        btnAdd.TabIndex = 2
        btnAdd.Text = "Add User"
        btnAdd.UseVisualStyleBackColor = True
        ' 
        ' txtSearch
        ' 
        txtSearch.Location = New Point(88, 17)
        txtSearch.Margin = New Padding(4, 3, 4, 3)
        txtSearch.Name = "txtSearch"
        txtSearch.PlaceholderText = "Cari username atau email..."
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
        DataGridView1.Columns.AddRange(New DataGridViewColumn() {user_id, username, email, role, created_at})
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
        ' user_id
        ' 
        user_id.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        user_id.DataPropertyName = "user_id"
        user_id.HeaderText = "ID"
        user_id.Name = "user_id"
        user_id.ReadOnly = True
        ' 
        ' username
        ' 
        username.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        username.DataPropertyName = "username"
        username.HeaderText = "Username"
        username.Name = "username"
        username.ReadOnly = True
        ' 
        ' email
        ' 
        email.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        email.DataPropertyName = "email"
        email.HeaderText = "Email"
        email.Name = "email"
        email.ReadOnly = True
        ' 
        ' role
        ' 
        role.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        role.DataPropertyName = "role"
        role.HeaderText = "Role"
        role.Name = "role"
        role.ReadOnly = True
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
        ' FormUserList
        ' 
        AutoScaleDimensions = New SizeF(7.0F, 15.0F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1000, 353)
        Controls.Add(DataGridView1)
        Controls.Add(Panel1)
        Margin = New Padding(4, 3, 4, 3)
        Name = "FormUserList"
        Text = "Kelola User"
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
    Friend WithEvents user_id As DataGridViewTextBoxColumn
    Friend WithEvents username As DataGridViewTextBoxColumn
    Friend WithEvents email As DataGridViewTextBoxColumn
    Friend WithEvents role As DataGridViewTextBoxColumn
    Friend WithEvents created_at As DataGridViewTextBoxColumn
End Class
