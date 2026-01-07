Imports WinFormsApp_Latihan.Controllers
Imports WinFormsApp_Latihan.Models
Imports System.Globalization
Imports System.IO
Imports System.Text

Public Class FormSalesTransactionDetail
   Private controller As SalesReportController
   Private _config As ConfigModel
   Private indonesianCulture As CultureInfo
   Private _saleID As String
   Private _transactionDate As DateTime
   Private _totalAmount As Decimal

   Public Sub New(saleID As String, transactionDate As DateTime, totalAmount As Decimal)
      InitializeComponent()
      _saleID = saleID
      _transactionDate = transactionDate
      _totalAmount = totalAmount
   End Sub

   Private Sub FormSalesTransactionDetail_Load(sender As Object, e As EventArgs) Handles MyBase.Load
      InitializeControllers()
      InitializeIndonesianCulture()
      LoadTransactionDetail()
   End Sub

   Private Sub InitializeControllers()
      Dim settingController As New SettingController()
      _config = settingController.LoadConfiguration()
      controller = New SalesReportController(_config)
   End Sub

   Private Sub InitializeIndonesianCulture()
      indonesianCulture = New CultureInfo("id-ID")
      indonesianCulture.NumberFormat.CurrencyDecimalDigits = 2
      indonesianCulture.NumberFormat.CurrencyDecimalSeparator = ","
      indonesianCulture.NumberFormat.CurrencyGroupSeparator = "."
      indonesianCulture.NumberFormat.CurrencySymbol = "Rp"
   End Sub

   Private Sub LoadTransactionDetail()
      Try
         ' Set form title and info
         Me.Text = AppInfo.GetWindowTitle($"Sales Detail - {_saleID}")
         LabelNota.Text = $"No. Transaction: {_saleID}"
         LabelTanggal.Text = $"Date: {_transactionDate:dd/MM/yyyy HH:mm}"
         LabelTotal.Text = $"Total Transaction: {_totalAmount.ToString("C2", indonesianCulture)}"

         ' Load detail items
         DataGridView1.DataSource = controller.LoadSalesDetailByTransaction(_saleID)

         ' Configure columns
         If DataGridView1.Columns.Count > 0 Then
            DataGridView1.Columns("KODE_BRG").HeaderText = "Item Code"
            DataGridView1.Columns("NAMA_BRG").HeaderText = "Item Name"
            DataGridView1.Columns("QTY").HeaderText = "Quantity"
            DataGridView1.Columns("UNIT").HeaderText = "Unit"
            DataGridView1.Columns("HARGA").HeaderText = "Price"
            DataGridView1.Columns("SUBTOTAL").HeaderText = "Subtotal"

            ' Format currency - RATA KANAN
            DataGridView1.Columns("HARGA").DefaultCellStyle.Format = "C2"
            DataGridView1.Columns("HARGA").DefaultCellStyle.FormatProvider = indonesianCulture
            DataGridView1.Columns("HARGA").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            DataGridView1.Columns("SUBTOTAL").DefaultCellStyle.Format = "C2"
            DataGridView1.Columns("SUBTOTAL").DefaultCellStyle.FormatProvider = indonesianCulture
            DataGridView1.Columns("SUBTOTAL").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            ' Quantity center align
            DataGridView1.Columns("QTY").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            ' Set widths
            DataGridView1.Columns("KODE_BRG").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            DataGridView1.Columns("NAMA_BRG").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            DataGridView1.Columns("QTY").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            DataGridView1.Columns("UNIT").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            DataGridView1.Columns("HARGA").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            DataGridView1.Columns("SUBTOTAL").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
         End If

      Catch ex As Exception
         MessageBox.Show($"Error loading transaction detail: {ex.Message}", "Error",
                          MessageBoxButtons.OK, MessageBoxIcon.Error)
      End Try
   End Sub

   Private Sub ButtonClose_Click(sender As Object, e As EventArgs) Handles ButtonClose.Click
      Me.Close()
   End Sub

   Private Sub ButtonExport_Click(sender As Object, e As EventArgs) Handles ButtonExport.Click
      If DataGridView1.Rows.Count = 0 Then
         MessageBox.Show("No data to export", "Information",
                          MessageBoxButtons.OK, MessageBoxIcon.Information)
         Return
      End If

      Try
         Dim saveDialog As New SaveFileDialog()
         saveDialog.Filter = "CSV Files (*.csv)|*.csv"
         saveDialog.FileName = $"Sales_Detail_{_saleID}_{DateTime.Now:yyyyMMdd_HHmmss}.csv"

         If saveDialog.ShowDialog() = DialogResult.OK Then
            Me.Cursor = Cursors.WaitCursor

            Using writer As New StreamWriter(saveDialog.FileName, False, Encoding.UTF8)
               ' Write application header
               writer.WriteLine($"# {AppInfo.AppFullName} v{AppInfo.AppVersion}")
               writer.WriteLine($"# {AppInfo.Copyright}")
               writer.WriteLine($"# Generated: {DateTime.Now:dd/MM/yyyy HH:mm:ss}")
               writer.WriteLine()
               
               ' Write transaction header
               writer.WriteLine($"# Sales Transaction Detail")
               writer.WriteLine($"Transaction Number,{_saleID}")
               writer.WriteLine($"Date,{_transactionDate:dd/MM/yyyy HH:mm}")
               writer.WriteLine($"Total,{_totalAmount}")
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

   Private Sub ButtonPrint_Click(sender As Object, e As EventArgs) Handles ButtonPrint.Click
      If DataGridView1.Rows.Count = 0 Then
         MessageBox.Show("No data to print", "Information",
                          MessageBoxButtons.OK, MessageBoxIcon.Information)
         Return
      End If

      Try
         ' Ask user: Print to device or Export to PDF
         Dim message As String = "Select print destination:"
         Dim result = CustomMessageDialog.Show3Options(message, "Print Options",
                                                       "Printer", "PDF File", "Cancel")

         If result = DialogResult.Yes Then
            ' Print to device
            Dim printHelper As New Helpers.PrintHelper()
            Dim title As String = $"Sales Transaction Detail - {_saleID}"
            Dim footer As String = $"Transaction Date: {_transactionDate:dd/MM/yyyy HH:mm} | Total: {_totalAmount.ToString("C2", indonesianCulture)} | Printed: {DateTime.Now:dd/MM/yyyy HH:mm}"
            Dim suggestedName As String = $"Sales_Detail_{_saleID}_{DateTime.Now:yyyyMMdd_HHmmss}.pdf"

            If printHelper.PrintDataGridView(DataGridView1, title, footer, suggestedName) Then
               MessageBox.Show("Document sent to printer successfully!", "Print Success",
                              MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

         ElseIf result = DialogResult.No Then
            ' Export to PDF
            Dim printHelper As New Helpers.PrintHelper()
            Dim title As String = $"Sales Transaction Detail - {_saleID}"
            Dim footer As String = $"Transaction Date: {_transactionDate:dd/MM/yyyy HH:mm} | Total: {_totalAmount.ToString("C2", indonesianCulture)}"
            Dim suggestedName As String = $"Sales_Detail_{_saleID}_{DateTime.Now:yyyyMMdd_HHmmss}.pdf"

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
                  Process.Start("explorer.exe", $"/select,""/{pdfPath}""")
               End If
            End If
         End If

      Catch ex As Exception
         MessageBox.Show($"Error printing: {ex.Message}", "Error",
                          MessageBoxButtons.OK, MessageBoxIcon.Error)
      End Try
   End Sub
End Class
