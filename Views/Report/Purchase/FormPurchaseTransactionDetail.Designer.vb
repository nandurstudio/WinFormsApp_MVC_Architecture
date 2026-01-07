<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormPurchaseTransactionDetail
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
      LabelTotal = New Label()
      LabelTanggal = New Label()
      LabelSupplier = New Label()
      LabelNota = New Label()
      DataGridView1 = New DataGridView()
      KODE_BRG = New DataGridViewTextBoxColumn()
      NAMA_BRG = New DataGridViewTextBoxColumn()
      QTY = New DataGridViewTextBoxColumn()
      UNIT = New DataGridViewTextBoxColumn()
      HARGA_BELI = New DataGridViewTextBoxColumn()
      SUBTOTAL = New DataGridViewTextBoxColumn()
      Panel2 = New Panel()
      ButtonPrint = New Button()
      ButtonExport = New Button()
      ButtonClose = New Button()
      Panel1.SuspendLayout()
      CType(DataGridView1, ComponentModel.ISupportInitialize).BeginInit()
      Panel2.SuspendLayout()
      SuspendLayout()
      ' 
      ' Panel1
      ' 
      Panel1.BackColor = Color.FromArgb(CByte(46), CByte(125), CByte(50))
      Panel1.Controls.Add(LabelTotal)
      Panel1.Controls.Add(LabelTanggal)
      Panel1.Controls.Add(LabelSupplier)
      Panel1.Controls.Add(LabelNota)
      Panel1.Dock = DockStyle.Top
      Panel1.Location = New Point(0, 0)
      Panel1.Name = "Panel1"
      Panel1.Padding = New Padding(10)
      Panel1.Size = New Size(800, 100)
      Panel1.TabIndex = 0
      ' 
      ' LabelTotal
      ' 
      LabelTotal.AutoSize = True
      LabelTotal.Font = New Font("Segoe UI", 11.0F, FontStyle.Bold, GraphicsUnit.Point)
      LabelTotal.ForeColor = Color.White
      LabelTotal.Location = New Point(13, 70)
      LabelTotal.Name = "LabelTotal"
      LabelTotal.Size = New Size(209, 20)
      LabelTotal.TabIndex = 3
      LabelTotal.Text = "Total Transaction: Rp 0,00"
      ' 
      ' LabelTanggal
      ' 
      LabelTanggal.AutoSize = True
      LabelTanggal.Font = New Font("Segoe UI", 10.0F, FontStyle.Regular, GraphicsUnit.Point)
      LabelTanggal.ForeColor = Color.White
      LabelTanggal.Location = New Point(13, 50)
      LabelTanggal.Name = "LabelTanggal"
      LabelTanggal.Size = New Size(140, 19)
      LabelTanggal.TabIndex = 2
      LabelTanggal.Text = "Date: 01/01/2024 00:00"
      ' 
      ' LabelSupplier
      ' 
      LabelSupplier.AutoSize = True
      LabelSupplier.Font = New Font("Segoe UI", 10.0F, FontStyle.Regular, GraphicsUnit.Point)
      LabelSupplier.ForeColor = Color.White
      LabelSupplier.Location = New Point(13, 30)
      LabelSupplier.Name = "LabelSupplier"
      LabelSupplier.Size = New Size(124, 19)
      LabelSupplier.TabIndex = 1
      LabelSupplier.Text = "Supplier: Supplier X"
      ' 
      ' LabelNota
      ' 
      LabelNota.AutoSize = True
      LabelNota.Font = New Font("Segoe UI", 12.0F, FontStyle.Bold, GraphicsUnit.Point)
      LabelNota.ForeColor = Color.White
      LabelNota.Location = New Point(13, 10)
      LabelNota.Name = "LabelNota"
      LabelNota.Size = New Size(193, 21)
      LabelNota.TabIndex = 0
      LabelNota.Text = "No. Transaction: PUR0001"
      ' 
      ' DataGridView1
      ' 
      DataGridView1.AllowUserToAddRows = False
      DataGridView1.AllowUserToDeleteRows = False
      DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
      DataGridView1.Columns.AddRange(New DataGridViewColumn() {KODE_BRG, NAMA_BRG, QTY, UNIT, HARGA_BELI, SUBTOTAL})
      DataGridView1.Dock = DockStyle.Fill
      DataGridView1.Location = New Point(0, 100)
      DataGridView1.Name = "DataGridView1"
      DataGridView1.ReadOnly = True
      DataGridView1.RowHeadersWidth = 51
      DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect
      DataGridView1.Size = New Size(800, 300)
      DataGridView1.TabIndex = 1
      ' 
      ' KODE_BRG
      ' 
      KODE_BRG.DataPropertyName = "KODE_BRG"
      KODE_BRG.HeaderText = "Item Code"
      KODE_BRG.Name = "KODE_BRG"
      KODE_BRG.ReadOnly = True
      ' 
      ' NAMA_BRG
      ' 
      NAMA_BRG.DataPropertyName = "NAMA_BRG"
      NAMA_BRG.HeaderText = "Item Name"
      NAMA_BRG.Name = "NAMA_BRG"
      NAMA_BRG.ReadOnly = True
      ' 
      ' QTY
      ' 
      QTY.DataPropertyName = "QTY"
      QTY.HeaderText = "Quantity"
      QTY.Name = "QTY"
      QTY.ReadOnly = True
      ' 
      ' UNIT
      ' 
      UNIT.DataPropertyName = "UNIT"
      UNIT.HeaderText = "Unit"
      UNIT.Name = "UNIT"
      UNIT.ReadOnly = True
      ' 
      ' HARGA_BELI
      ' 
      HARGA_BELI.DataPropertyName = "HARGA_BELI"
      HARGA_BELI.HeaderText = "Purchase Price"
      HARGA_BELI.Name = "HARGA_BELI"
      HARGA_BELI.ReadOnly = True
      ' 
      ' SUBTOTAL
      ' 
      SUBTOTAL.DataPropertyName = "SUBTOTAL"
      SUBTOTAL.HeaderText = "Subtotal"
      SUBTOTAL.Name = "SUBTOTAL"
      SUBTOTAL.ReadOnly = True
      ' 
      ' Panel2
      ' 
      Panel2.Controls.Add(ButtonPrint)
      Panel2.Controls.Add(ButtonExport)
      Panel2.Controls.Add(ButtonClose)
      Panel2.Dock = DockStyle.Bottom
      Panel2.Location = New Point(0, 400)
      Panel2.Name = "Panel2"
      Panel2.Padding = New Padding(10)
      Panel2.Size = New Size(800, 50)
      Panel2.TabIndex = 2
      ' 
      ' ButtonPrint
      ' 
      ButtonPrint.Anchor = CType((AnchorStyles.Top Or AnchorStyles.Right), AnchorStyles)
      ButtonPrint.BackColor = Color.FromArgb(CByte(33), CByte(150), CByte(243))
      ButtonPrint.FlatStyle = FlatStyle.Flat
      ButtonPrint.Font = New Font("Segoe UI", 10.0F, FontStyle.Bold, GraphicsUnit.Point)
      ButtonPrint.ForeColor = Color.White
      ButtonPrint.Location = New Point(582, 10)
      ButtonPrint.Name = "ButtonPrint"
      ButtonPrint.Size = New Size(100, 30)
      ButtonPrint.TabIndex = 1
      ButtonPrint.Text = "Print"
      ButtonPrint.UseVisualStyleBackColor = False
      ' 
      ' ButtonExport
      ' 
      ButtonExport.Anchor = CType((AnchorStyles.Top Or AnchorStyles.Right), AnchorStyles)
      ButtonExport.BackColor = Color.FromArgb(CByte(46), CByte(125), CByte(50))
      ButtonExport.FlatStyle = FlatStyle.Flat
      ButtonExport.Font = New Font("Segoe UI", 10.0F, FontStyle.Bold, GraphicsUnit.Point)
      ButtonExport.ForeColor = Color.White
      ButtonExport.Location = New Point(475, 10)
      ButtonExport.Name = "ButtonExport"
      ButtonExport.Size = New Size(100, 30)
      ButtonExport.TabIndex = 0
      ButtonExport.Text = "Export CSV"
      ButtonExport.UseVisualStyleBackColor = False
      ' 
      ' ButtonClose
      ' 
      ButtonClose.Anchor = CType((AnchorStyles.Top Or AnchorStyles.Right), AnchorStyles)
      ButtonClose.BackColor = Color.FromArgb(CByte(198), CByte(40), CByte(40))
      ButtonClose.FlatStyle = FlatStyle.Flat
      ButtonClose.Font = New Font("Segoe UI", 10.0F, FontStyle.Bold, GraphicsUnit.Point)
      ButtonClose.ForeColor = Color.White
      ButtonClose.Location = New Point(690, 10)
      ButtonClose.Name = "ButtonClose"
      ButtonClose.Size = New Size(100, 30)
      ButtonClose.TabIndex = 2
      ButtonClose.Text = "Close"
      ButtonClose.UseVisualStyleBackColor = False
      ' 
      ' FormPurchaseTransactionDetail
      ' 
      AutoScaleDimensions = New SizeF(7.0F, 15.0F)
      AutoScaleMode = AutoScaleMode.Font
      ClientSize = New Size(800, 450)
      Controls.Add(DataGridView1)
      Controls.Add(Panel2)
      Controls.Add(Panel1)
      Name = "FormPurchaseTransactionDetail"
      StartPosition = FormStartPosition.CenterParent
      Text = "Purchase Transaction Detail"
      Panel1.ResumeLayout(False)
      Panel1.PerformLayout()
      CType(DataGridView1, ComponentModel.ISupportInitialize).EndInit()
      Panel2.ResumeLayout(False)
      ResumeLayout(False)

   End Sub

   Friend WithEvents Panel1 As Panel
   Friend WithEvents LabelNota As Label
   Friend WithEvents LabelSupplier As Label
   Friend WithEvents LabelTanggal As Label
   Friend WithEvents LabelTotal As Label
   Friend WithEvents DataGridView1 As DataGridView
   Friend WithEvents Panel2 As Panel
   Friend WithEvents ButtonPrint As Button
   Friend WithEvents ButtonExport As Button
   Friend WithEvents ButtonClose As Button
   Friend WithEvents KODE_BRG As DataGridViewTextBoxColumn
   Friend WithEvents NAMA_BRG As DataGridViewTextBoxColumn
   Friend WithEvents QTY As DataGridViewTextBoxColumn
   Friend WithEvents UNIT As DataGridViewTextBoxColumn
   Friend WithEvents HARGA_BELI As DataGridViewTextBoxColumn
   Friend WithEvents SUBTOTAL As DataGridViewTextBoxColumn
End Class
