<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormPurchaseReport
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
      Me.Panel1 = New System.Windows.Forms.Panel()
      Me.LabelTitle = New System.Windows.Forms.Label()
      Me.Panel2 = New System.Windows.Forms.Panel()
      Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
      Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
      Me.BtnRefresh = New System.Windows.Forms.Button()
      Me.Label1 = New System.Windows.Forms.Label()
      Me.dtpStart = New System.Windows.Forms.DateTimePicker()
      Me.Label2 = New System.Windows.Forms.Label()
      Me.dtpEnd = New System.Windows.Forms.DateTimePicker()
      Me.btnLoad = New System.Windows.Forms.Button()
      Me.FlowLayoutPanel2 = New System.Windows.Forms.FlowLayoutPanel()
      Me.BtnExportCSV = New System.Windows.Forms.Button()
      Me.BtnPrint = New System.Windows.Forms.Button()
      Me.DataGridView1 = New System.Windows.Forms.DataGridView()
      Me.Panel3 = New System.Windows.Forms.Panel()
      Me.LabelTotal = New System.Windows.Forms.Label()
      Me.Panel1.SuspendLayout()
      Me.Panel2.SuspendLayout()
      Me.TableLayoutPanel1.SuspendLayout()
      Me.FlowLayoutPanel1.SuspendLayout()
      Me.FlowLayoutPanel2.SuspendLayout()
      CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.Panel3.SuspendLayout()
      Me.SuspendLayout()
      '
      'Panel1
      '
      Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(94, Byte), Integer))
      Me.Panel1.Controls.Add(Me.LabelTitle)
      Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
      Me.Panel1.Location = New System.Drawing.Point(0, 0)
      Me.Panel1.Name = "Panel1"
      Me.Panel1.Size = New System.Drawing.Size(1100, 60)
      Me.Panel1.TabIndex = 0
      '
      'LabelTitle
      '
      Me.LabelTitle.Dock = System.Windows.Forms.DockStyle.Fill
      Me.LabelTitle.Font = New System.Drawing.Font("Segoe UI", 16.0!, System.Drawing.FontStyle.Bold)
      Me.LabelTitle.ForeColor = System.Drawing.Color.White
      Me.LabelTitle.Location = New System.Drawing.Point(0, 0)
      Me.LabelTitle.Name = "LabelTitle"
      Me.LabelTitle.Size = New System.Drawing.Size(1100, 60)
      Me.LabelTitle.TabIndex = 0
      Me.LabelTitle.Text = "LAPORAN PEMBELIAN"
      Me.LabelTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      '
      'Panel2
      '
      Me.Panel2.BackColor = System.Drawing.Color.WhiteSmoke
      Me.Panel2.Controls.Add(Me.TableLayoutPanel1)
      Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
      Me.Panel2.Location = New System.Drawing.Point(0, 60)
      Me.Panel2.Name = "Panel2"
      Me.Panel2.Padding = New System.Windows.Forms.Padding(10)
      Me.Panel2.Size = New System.Drawing.Size(1100, 80)
      Me.Panel2.TabIndex = 1
      '
      'TableLayoutPanel1
      '
      Me.TableLayoutPanel1.ColumnCount = 2
      Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
      Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 280.0!))
      Me.TableLayoutPanel1.Controls.Add(Me.FlowLayoutPanel1, 0, 0)
      Me.TableLayoutPanel1.Controls.Add(Me.FlowLayoutPanel2, 1, 0)
      Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
      Me.TableLayoutPanel1.Location = New System.Drawing.Point(10, 10)
      Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
      Me.TableLayoutPanel1.RowCount = 1
      Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
      Me.TableLayoutPanel1.Size = New System.Drawing.Size(1080, 60)
      Me.TableLayoutPanel1.TabIndex = 0
      '
      'FlowLayoutPanel1
      '
      Me.FlowLayoutPanel1.Controls.Add(Me.BtnRefresh)
      Me.FlowLayoutPanel1.Controls.Add(Me.Label1)
      Me.FlowLayoutPanel1.Controls.Add(Me.dtpStart)
      Me.FlowLayoutPanel1.Controls.Add(Me.Label2)
      Me.FlowLayoutPanel1.Controls.Add(Me.dtpEnd)
      Me.FlowLayoutPanel1.Controls.Add(Me.btnLoad)
      Me.FlowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
      Me.FlowLayoutPanel1.Location = New System.Drawing.Point(0, 0)
      Me.FlowLayoutPanel1.Margin = New System.Windows.Forms.Padding(0)
      Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
      Me.FlowLayoutPanel1.Padding = New System.Windows.Forms.Padding(0, 12, 0, 0)
      Me.FlowLayoutPanel1.Size = New System.Drawing.Size(800, 60)
      Me.FlowLayoutPanel1.TabIndex = 0
      '
      'BtnRefresh
      '
      Me.BtnRefresh.BackColor = System.Drawing.Color.FromArgb(CType(CType(41, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(185, Byte), Integer))
      Me.BtnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat
      Me.BtnRefresh.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
      Me.BtnRefresh.ForeColor = System.Drawing.Color.White
      Me.BtnRefresh.Location = New System.Drawing.Point(3, 15)
      Me.BtnRefresh.Name = "BtnRefresh"
      Me.BtnRefresh.Size = New System.Drawing.Size(110, 35)
      Me.BtnRefresh.TabIndex = 0
      Me.BtnRefresh.Text = "🔄 Refresh"
      Me.BtnRefresh.UseVisualStyleBackColor = False
      '
      'Label1
      '
      Me.Label1.AutoSize = True
      Me.Label1.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
      Me.Label1.Location = New System.Drawing.Point(119, 22)
      Me.Label1.Margin = New System.Windows.Forms.Padding(3, 10, 3, 0)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(84, 15)
      Me.Label1.TabIndex = 1
      Me.Label1.Text = "Dari Tanggal:"
      '
      'dtpStart
      '
      Me.dtpStart.Format = System.Windows.Forms.DateTimePickerFormat.Short
      Me.dtpStart.Location = New System.Drawing.Point(209, 18)
      Me.dtpStart.Margin = New System.Windows.Forms.Padding(3, 6, 3, 3)
      Me.dtpStart.Name = "dtpStart"
      Me.dtpStart.Size = New System.Drawing.Size(130, 22)
      Me.dtpStart.TabIndex = 2
      '
      'Label2
      '
      Me.Label2.AutoSize = True
      Me.Label2.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
      Me.Label2.Location = New System.Drawing.Point(345, 22)
      Me.Label2.Margin = New System.Windows.Forms.Padding(3, 10, 3, 0)
      Me.Label2.Name = "Label2"
      Me.Label2.Size = New System.Drawing.Size(53, 15)
      Me.Label2.TabIndex = 3
      Me.Label2.Text = "s/d Tgl:"
      '
      'dtpEnd
      '
      Me.dtpEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short
      Me.dtpEnd.Location = New System.Drawing.Point(404, 18)
      Me.dtpEnd.Margin = New System.Windows.Forms.Padding(3, 6, 3, 3)
      Me.dtpEnd.Name = "dtpEnd"
      Me.dtpEnd.Size = New System.Drawing.Size(130, 22)
      Me.dtpEnd.TabIndex = 4
      '
      'btnLoad
      '
      Me.btnLoad.BackColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(76, Byte), Integer), CType(CType(60, Byte), Integer))
      Me.btnLoad.FlatStyle = System.Windows.Forms.FlatStyle.Flat
      Me.btnLoad.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
      Me.btnLoad.ForeColor = System.Drawing.Color.White
      Me.btnLoad.Location = New System.Drawing.Point(540, 15)
      Me.btnLoad.Name = "btnLoad"
      Me.btnLoad.Size = New System.Drawing.Size(120, 35)
      Me.btnLoad.TabIndex = 5
      Me.btnLoad.Text = "📋 Tampilkan"
      Me.btnLoad.UseVisualStyleBackColor = False
      '
      'FlowLayoutPanel2
      '
      Me.FlowLayoutPanel2.Controls.Add(Me.BtnPrint)
      Me.FlowLayoutPanel2.Controls.Add(Me.BtnExportCSV)
      Me.FlowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
      Me.FlowLayoutPanel2.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft
      Me.FlowLayoutPanel2.Location = New System.Drawing.Point(800, 0)
      Me.FlowLayoutPanel2.Margin = New System.Windows.Forms.Padding(0)
      Me.FlowLayoutPanel2.Name = "FlowLayoutPanel2"
      Me.FlowLayoutPanel2.Padding = New System.Windows.Forms.Padding(0, 12, 0, 0)
      Me.FlowLayoutPanel2.Size = New System.Drawing.Size(280, 60)
      Me.FlowLayoutPanel2.TabIndex = 1
      '
      'BtnExportCSV
      '
      Me.BtnExportCSV.BackColor = System.Drawing.Color.FromArgb(CType(CType(39, Byte), Integer), CType(CType(174, Byte), Integer), CType(CType(96, Byte), Integer))
      Me.BtnExportCSV.FlatStyle = System.Windows.Forms.FlatStyle.Flat
      Me.BtnExportCSV.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
      Me.BtnExportCSV.ForeColor = System.Drawing.Color.White
      Me.BtnExportCSV.Location = New System.Drawing.Point(137, 15)
      Me.BtnExportCSV.Name = "BtnExportCSV"
      Me.BtnExportCSV.Size = New System.Drawing.Size(130, 35)
      Me.BtnExportCSV.TabIndex = 1
      Me.BtnExportCSV.Text = "📊 Export CSV"
      Me.BtnExportCSV.UseVisualStyleBackColor = False
      '
      'BtnPrint
      '
      Me.BtnPrint.BackColor = System.Drawing.Color.FromArgb(CType(CType(142, Byte), Integer), CType(CType(68, Byte), Integer), CType(CType(173, Byte), Integer))
      Me.BtnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat
      Me.BtnPrint.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
      Me.BtnPrint.ForeColor = System.Drawing.Color.White
      Me.BtnPrint.Location = New System.Drawing.Point(7, 15)
      Me.BtnPrint.Margin = New System.Windows.Forms.Padding(3, 3, 10, 3)
      Me.BtnPrint.Name = "BtnPrint"
      Me.BtnPrint.Size = New System.Drawing.Size(120, 35)
      Me.BtnPrint.TabIndex = 0
      Me.BtnPrint.Text = "🖨️ Print"
      Me.BtnPrint.UseVisualStyleBackColor = False
      '
      'DataGridView1
      '
      Me.DataGridView1.AllowUserToAddRows = False
      Me.DataGridView1.AllowUserToDeleteRows = False
      Me.DataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
      Me.DataGridView1.BackgroundColor = System.Drawing.Color.White
      Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
      Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
      Me.DataGridView1.Location = New System.Drawing.Point(0, 140)
      Me.DataGridView1.Name = "DataGridView1"
      Me.DataGridView1.ReadOnly = True
      Me.DataGridView1.RowHeadersWidth = 51
      Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
      Me.DataGridView1.Size = New System.Drawing.Size(1100, 460)
      Me.DataGridView1.TabIndex = 2
      '
      'Panel3
      '
      Me.Panel3.BackColor = System.Drawing.Color.FromArgb(CType(CType(236, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(241, Byte), Integer))
      Me.Panel3.Controls.Add(Me.LabelTotal)
      Me.Panel3.Dock = System.Windows.Forms.DockStyle.Bottom
      Me.Panel3.Location = New System.Drawing.Point(0, 600)
      Me.Panel3.Name = "Panel3"
      Me.Panel3.Size = New System.Drawing.Size(1100, 50)
      Me.Panel3.TabIndex = 3
      '
      'LabelTotal
      '
      Me.LabelTotal.Dock = System.Windows.Forms.DockStyle.Fill
      Me.LabelTotal.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
      Me.LabelTotal.Location = New System.Drawing.Point(0, 0)
      Me.LabelTotal.Name = "LabelTotal"
      Me.LabelTotal.Padding = New System.Windows.Forms.Padding(20, 0, 20, 0)
      Me.LabelTotal.Size = New System.Drawing.Size(1100, 50)
      Me.LabelTotal.TabIndex = 0
      Me.LabelTotal.Text = "Total Pembelian: Rp 0 | Jumlah Transaksi: 0"
      Me.LabelTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'FormPurchaseReport
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(1100, 650)
      Me.Controls.Add(Me.DataGridView1)
      Me.Controls.Add(Me.Panel3)
      Me.Controls.Add(Me.Panel2)
      Me.Controls.Add(Me.Panel1)
      Me.MinimumSize = New System.Drawing.Size(1000, 600)
      Me.Name = "FormPurchaseReport"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
      Me.Text = "Laporan Pembelian"
      Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
      Me.Panel1.ResumeLayout(False)
      Me.Panel2.ResumeLayout(False)
      Me.TableLayoutPanel1.ResumeLayout(False)
      Me.FlowLayoutPanel1.ResumeLayout(False)
      Me.FlowLayoutPanel1.PerformLayout()
      Me.FlowLayoutPanel2.ResumeLayout(False)
      CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
      Me.Panel3.ResumeLayout(False)
      Me.ResumeLayout(False)

   End Sub
   Friend WithEvents Panel1 As System.Windows.Forms.Panel
   Friend WithEvents LabelTitle As System.Windows.Forms.Label
   Friend WithEvents Panel2 As System.Windows.Forms.Panel
   Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
   Friend WithEvents Panel3 As System.Windows.Forms.Panel
   Friend WithEvents LabelTotal As System.Windows.Forms.Label
   Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
   Friend WithEvents FlowLayoutPanel1 As FlowLayoutPanel
   Friend WithEvents BtnRefresh As Button
   Friend WithEvents Label1 As Label
   Friend WithEvents dtpStart As DateTimePicker
   Friend WithEvents Label2 As Label
   Friend WithEvents dtpEnd As DateTimePicker
   Friend WithEvents btnLoad As Button
   Friend WithEvents FlowLayoutPanel2 As FlowLayoutPanel
   Friend WithEvents BtnExportCSV As Button
   Friend WithEvents BtnPrint As Button
End Class
