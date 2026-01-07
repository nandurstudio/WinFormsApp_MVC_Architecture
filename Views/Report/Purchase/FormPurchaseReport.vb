Imports WinFormsApp_Latihan.Models
Imports WinFormsApp_Latihan.Controllers
Imports System.Globalization
Imports System.IO
Imports System.Text

Public Class FormPurchaseReport
    Private controller As PurchaseReportController
    Private _config As ConfigModel
    Private indonesianCulture As CultureInfo

    Private Sub FormPurchaseReport_Load(sender As Object, e As EventArgs) Handles MyBase.Load
      Me.Text = AppInfo.GetWindowTitle("Purchase Report")
      InitializeControllers()
      InitializeIndonesianCulture()
      InitializeDateRange()
      ConfigureDataGridView()
      LoadReport() ' Auto-load on form load
   End Sub

   Private Sub ConfigureDataGridView()
      ' Responsive DataGridView settings
      DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
      DataGridView1.AllowUserToResizeColumns = True
      DataGridView1.AllowUserToResizeRows = False
      DataGridView1.RowHeadersVisible = True
      DataGridView1.RowHeadersWidth = 30
      DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect
      DataGridView1.MultiSelect = False
      DataGridView1.ReadOnly = True
      DataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(240, 240, 240)

      ' Header styling
      With DataGridView1.ColumnHeadersDefaultCellStyle
         .BackColor = Color.FromArgb(52, 73, 94)
         .ForeColor = Color.White
         .Font = New Font("Segoe UI", 9, FontStyle.Bold)
         .Alignment = DataGridViewContentAlignment.MiddleCenter
      End With

      DataGridView1.EnableHeadersVisualStyles = False
      DataGridView1.ColumnHeadersHeight = 35
   End Sub

   Private Sub InitializeControllers()
      Dim settingController As New SettingController()
      _config = settingController.LoadConfiguration()
      controller = New PurchaseReportController(_config)
   End Sub

   Private Sub InitializeIndonesianCulture()
      indonesianCulture = New CultureInfo("id-ID")
      indonesianCulture.NumberFormat.CurrencyDecimalDigits = 2
      indonesianCulture.NumberFormat.CurrencyDecimalSeparator = ","
      indonesianCulture.NumberFormat.CurrencyGroupSeparator = "."
      indonesianCulture.NumberFormat.CurrencySymbol = "Rp"
   End Sub

   Private Sub InitializeDateRange()
      ' Default: bulan ini
      dtpStart.Value = New DateTime(DateTime.Now.Year, DateTime.Now.Month, 1)
      dtpEnd.Value = DateTime.Now
   End Sub

   Private Sub btnLoad_Click(sender As Object, e As EventArgs) Handles btnLoad.Click
      LoadReport()
   End Sub

   Private Sub BtnRefresh_Click(sender As Object, e As EventArgs) Handles BtnRefresh.Click
      LoadReport()
   End Sub

   Private Sub LoadReport()
      Try
         ' Validasi tanggal
         If dtpStart.Value > dtpEnd.Value Then
            MessageBox.Show("Start date cannot be greater than end date", "Validation",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
         End If

         ' Show loading cursor
         Me.Cursor = Cursors.WaitCursor

         ' Load data GROUPED by transaction
         Dim startDate As DateTime = dtpStart.Value.Date
         Dim endDate As DateTime = dtpEnd.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59)

         DataGridView1.DataSource = controller.LoadPurchaseReportGrouped(startDate, endDate)

         ' Customize columns
         If DataGridView1.Columns.Count > 0 Then
            DataGridView1.Columns("NOTA").HeaderText = "No. Transaction"
            DataGridView1.Columns("TGL_NOTA").HeaderText = "Date"
            DataGridView1.Columns("NAMA_SUPPLIER").HeaderText = "Supplier"
            DataGridView1.Columns("TOTAL_TRANSAKSI").HeaderText = "Total Amount"
            DataGridView1.Columns("JUMLAH_ITEM").HeaderText = "Total Items"
            DataGridView1.Columns("STATUS").HeaderText = "Status"
            DataGridView1.Columns("CREATED_BY").HeaderText = "Created By"

            ' Format currency columns
            DataGridView1.Columns("TOTAL_TRANSAKSI").DefaultCellStyle.Format = "C2"
            DataGridView1.Columns("TOTAL_TRANSAKSI").DefaultCellStyle.FormatProvider = indonesianCulture
            DataGridView1.Columns("TOTAL_TRANSAKSI").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            ' Format date column
            DataGridView1.Columns("TGL_NOTA").DefaultCellStyle.Format = "dd/MM/yyyy HH:mm"

            ' Set column widths - NAMA_SUPPLIER uses Fill to occupy remaining space
            DataGridView1.Columns("NOTA").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            DataGridView1.Columns("TGL_NOTA").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            DataGridView1.Columns("NAMA_SUPPLIER").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            DataGridView1.Columns("TOTAL_TRANSAKSI").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            DataGridView1.Columns("JUMLAH_ITEM").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            DataGridView1.Columns("STATUS").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            DataGridView1.Columns("CREATED_BY").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells

            ' Set minimum widths for better appearance
            DataGridView1.Columns("NOTA").MinimumWidth = 120
            DataGridView1.Columns("TGL_NOTA").MinimumWidth = 140
            DataGridView1.Columns("NAMA_SUPPLIER").MinimumWidth = 150
            DataGridView1.Columns("TOTAL_TRANSAKSI").MinimumWidth = 150
            DataGridView1.Columns("JUMLAH_ITEM").MinimumWidth = 90
            DataGridView1.Columns("STATUS").MinimumWidth = 90
            DataGridView1.Columns("CREATED_BY").MinimumWidth = 100

            ' Center align qty and status
            DataGridView1.Columns("JUMLAH_ITEM").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DataGridView1.Columns("STATUS").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
         End If

         ' Update summary
         UpdateSummary(startDate, endDate)

      Catch ex As Exception
         MessageBox.Show($"Error loading purchase report: {ex.Message}", "Error",
                          MessageBoxButtons.OK, MessageBoxIcon.Error)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub UpdateSummary(startDate As DateTime, endDate As DateTime)
      Try
         Dim totalAmount As Decimal = controller.GetTotalPurchaseAmount(startDate, endDate)
         Dim totalCount As Integer = controller.GetTotalPurchaseCount(startDate, endDate)

         LabelTotal.Text = $"Total Purchase: {totalAmount.ToString("C2", indonesianCulture)} | " &
                            $"Total Transactions: {totalCount} | " &
                            $"Period: {startDate:dd/MM/yyyy} - {endDate:dd/MM/yyyy}"
      Catch ex As Exception
         LabelTotal.Text = "Error loading summary information"
      End Try
   End Sub

   Private Sub DataGridView1_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
      If e.RowIndex >= 0 Then
         Try
            Dim purchaseID As String = DataGridView1.Rows(e.RowIndex).Cells("NOTA").Value.ToString()
            Dim transactionDate As DateTime = Convert.ToDateTime(DataGridView1.Rows(e.RowIndex).Cells("TGL_NOTA").Value)
            Dim totalAmount As Decimal = Convert.ToDecimal(DataGridView1.Rows(e.RowIndex).Cells("TOTAL_TRANSAKSI").Value)
            Dim supplierName As String = DataGridView1.Rows(e.RowIndex).Cells("NAMA_SUPPLIER").Value.ToString()

            ' Open detail form
            Dim detailForm As New FormPurchaseTransactionDetail(purchaseID, transactionDate, totalAmount, supplierName)
            detailForm.ShowDialog(Me)

         Catch ex As Exception
            MessageBox.Show($"Error opening transaction detail: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error)
         End Try
      End If
   End Sub

   Private Sub BtnExportCSV_Click(sender As Object, e As EventArgs) Handles BtnExportCSV.Click
      If DataGridView1.Rows.Count = 0 Then
         MessageBox.Show("No data to export", "Information",
                          MessageBoxButtons.OK, MessageBoxIcon.Information)
         Return
      End If

      Try
         ' Get date range for file name and header
         Dim startDate As DateTime = dtpStart.Value.Date
         Dim endDate As DateTime = dtpEnd.Value.Date

         Dim saveDialog As New SaveFileDialog()
         saveDialog.Filter = "CSV Files (*.csv)|*.csv"
         saveDialog.FileName = $"Purchase_Report_{dtpStart.Value:yyyyMMdd}_{dtpEnd.Value:yyyyMMdd}_{DateTime.Now:HHmmss}.csv"

         If saveDialog.ShowDialog() = DialogResult.OK Then
            Me.Cursor = Cursors.WaitCursor

            Using writer As New StreamWriter(saveDialog.FileName, False, Encoding.UTF8)
               ' Write application header
               writer.WriteLine($"# {AppInfo.AppFullName} v{AppInfo.AppVersion}")
               writer.WriteLine($"# {AppInfo.Copyright}")
               writer.WriteLine($"# Generated: {DateTime.Now:dd/MM/yyyy HH:mm:ss}")
               writer.WriteLine()
               writer.WriteLine($"# Purchase Report")
               writer.WriteLine($"# Period: {startDate:dd/MM/yyyy} - {endDate:dd/MM/yyyy}")
               writer.WriteLine()

               ' Write detail headers
               Dim headers As New List(Of String)
               For Each column As DataGridViewColumn In DataGridView1.Columns
                  headers.Add(column.HeaderText)
               Next
               writer.WriteLine(String.Join(",", headers))

               ' Write data rows
               For Each row As DataGridViewRow In DataGridView1.Rows
                  If Not row.IsNewRow Then
                     Dim values As New List(Of String)
                     For Each cell As DataGridViewCell In row.Cells
                        Dim value As String = If(cell.Value IsNot Nothing, cell.Value.ToString().Replace(",", ";"), "")
                        values.Add($"""{value}""")
                     Next
                     writer.WriteLine(String.Join(",", values))
                  End If
               Next

               ' Write summary footer
               writer.WriteLine()
               writer.WriteLine($"# Summary:")
               writer.WriteLine($"# Total Purchase,{controller.GetTotalPurchaseAmount(startDate, endDate)}")
               writer.WriteLine($"# Total Transactions,{controller.GetTotalPurchaseCount(startDate, endDate)}")
            End Using

            Me.Cursor = Cursors.Default

            ' Show custom dialog with 3 options
            Dim message As String = $"File saved successfully!{vbCrLf}{Path.GetFileName(saveDialog.FileName)}"
            Dim result = CustomMessageDialog.Show3Options(message, "Export Successful",
                                                              "Open File", "Open Location", "Close")

            If result = DialogResult.Yes Then
               ' Open file
               Process.Start(New ProcessStartInfo(saveDialog.FileName) With {.UseShellExecute = True})
            ElseIf result = DialogResult.No Then
               ' Open location
               Process.Start("explorer.exe", $"/select,""{saveDialog.FileName}""")
            End If
         End If

      Catch ex As Exception
         Me.Cursor = Cursors.Default
         MessageBox.Show($"Error exporting to CSV: {ex.Message}", "Error",
                          MessageBoxButtons.OK, MessageBoxIcon.Error)
      End Try
   End Sub

   Private Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles BtnPrint.Click
      If DataGridView1.Rows.Count = 0 Then
         MessageBox.Show("No data to print", "Information",
                          MessageBoxButtons.OK, MessageBoxIcon.Information)
         Return
      End If

      Try
         ' Calculate totals for footer
         Dim startDate As DateTime = dtpStart.Value.Date
         Dim endDate As DateTime = dtpEnd.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59)
         Dim totalAmount As Decimal = controller.GetTotalPurchaseAmount(startDate, endDate)
         Dim totalCount As Integer = controller.GetTotalPurchaseCount(startDate, endDate)
         Dim summaryText As String = $"Total Purchase: {totalAmount.ToString("C2", indonesianCulture)}   |   Total Transactions: {totalCount}"

         ' Ask user: Print to device or Export to PDF
         Dim message As String = "Select print destination:"
         Dim result = CustomMessageDialog.Show3Options(message, "Print Options",
                                                          "Printer", "PDF File", "Cancel")

         If result = DialogResult.Yes Then
            ' Print to device
            Dim printHelper As New Helpers.PrintHelper()
            Dim title As String = $"Purchase Report - {dtpStart.Value:dd/MM/yyyy} to {dtpEnd.Value:dd/MM/yyyy}"
            Dim footer As String = $"{summaryText}{vbCrLf}Printed on: {DateTime.Now:dd/MM/yyyy HH:mm}"
            Dim suggestedName As String = $"Purchase_Report_{dtpStart.Value:yyyyMMdd}_{dtpEnd.Value:yyyyMMdd}_{DateTime.Now:HHmmss}.pdf"

            If printHelper.PrintDataGridView(DataGridView1, title, footer, suggestedName) Then
               MessageBox.Show("Document sent to printer successfully!", "Print Success",
                                  MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

         ElseIf result = DialogResult.No Then
            ' Export to PDF
            Dim printHelper As New Helpers.PrintHelper()
            Dim title As String = $"Purchase Report - {dtpStart.Value:dd/MM/yyyy} to {dtpEnd.Value:dd/MM/yyyy}"
            Dim footer As String = $"{summaryText}{vbCrLf}Generated on: {DateTime.Now:dd/MM/yyyy HH:mm}"
            Dim suggestedName As String = $"Purchase_Report_{dtpStart.Value:yyyyMMdd}_{dtpEnd.Value:yyyyMMdd}_{DateTime.Now:HHmmss}.pdf"

            Dim pdfPath As String = printHelper.ExportToPDF(DataGridView1, title, footer, suggestedName)

            If Not String.IsNullOrEmpty(pdfPath) Then
               ' Show custom dialog with 3 options
               Dim pdfMessage As String = $"PDF created successfully!{vbCrLf}{Path.GetFileName(pdfPath)}"
               Dim pdfResult = CustomMessageDialog.Show3Options(pdfMessage, "PDF Export Successful",
                                                                   "Open PDF", "Open Location", "Close")

               If pdfResult = DialogResult.Yes Then
                  ' Open PDF file
                  Process.Start(New ProcessStartInfo(pdfPath) With {.UseShellExecute = True})
               ElseIf pdfResult = DialogResult.No Then
                  ' Open location
                  Process.Start("explorer.exe", $"/select,""{pdfPath}""")
               End If
            End If
         End If

      Catch ex As Exception
         MessageBox.Show($"Error printing: {ex.Message}", "Error",
                          MessageBoxButtons.OK, MessageBoxIcon.Error)
      End Try
   End Sub

   Private Sub FormPurchaseReport_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
      ' Adjust label font size based on form width
      If Me.Width < 1024 Then
         LabelTotal.Font = New Font("Segoe UI", 9, FontStyle.Bold)
      ElseIf Me.Width < 1280 Then
         LabelTotal.Font = New Font("Segoe UI", 10, FontStyle.Bold)
      Else
         LabelTotal.Font = New Font("Segoe UI", 11, FontStyle.Bold)
      End If
   End Sub
End Class
