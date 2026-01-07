Imports System.Drawing.Printing
Imports System.IO
Imports System.Text
Imports WinFormsApp_Latihan.Models

Namespace Helpers
   ''' <summary>
   ''' Helper class untuk printing DataGridView dengan device selection
   ''' </summary>
   Public Class PrintHelper
      Private printDocument As New PrintDocument()
      Private currentPageIndex As Integer = 0
      Private rowsToPrint As New List(Of DataGridViewRow)()
      Private headerText As String = ""
      Private footerText As String = ""
      Private dataGridView As DataGridView
      Private rowsPerPage As Integer = 0
      Private currentRow As Integer = 0

      ''' <summary>
      ''' Print DataGridView dengan dialog printer
      ''' </summary>
      Public Function PrintDataGridView(dgv As DataGridView, title As String, Optional footer As String = "", Optional suggestedFileName As String = "") As Boolean
         Try
            dataGridView = dgv
            headerText = title
            footerText = footer

            ' Generate dynamic filename for print job
            Dim fileName As String = If(String.IsNullOrEmpty(suggestedFileName),
                                       GenerateFileName(title, "pdf"),
                                       suggestedFileName)

            ' Show printer dialog
            Dim printDialog As New PrintDialog()
            printDialog.Document = printDocument

            ' Set default document name for print queue and PDF printers
            printDocument.DocumentName = Path.GetFileNameWithoutExtension(fileName)

            ' Set default filename for "Print to File" printers (Adobe PDF, Microsoft Print to PDF, etc.)
            printDocument.PrinterSettings.PrintFileName = fileName

            ' Setup print document
            AddHandler printDocument.PrintPage, AddressOf PrintDocument_PrintPage

            If printDialog.ShowDialog() = DialogResult.OK Then
               ' Update document name after user selects printer
               ' This ensures the filename appears in save dialog for PDF printers
               If Not String.IsNullOrEmpty(printDocument.PrinterSettings.PrintFileName) Then
                  printDocument.PrinterSettings.PrintFileName = fileName
               End If

               ' Reset counters
               currentRow = 0
               currentPageIndex = 0

               ' Start printing
               printDocument.Print()
               Return True
            End If

            Return False

         Catch ex As Exception
            Throw New Exception($"Error printing: {ex.Message}", ex)
         Finally
            ' Cleanup
            RemoveHandler printDocument.PrintPage, AddressOf PrintDocument_PrintPage
         End Try
      End Function

      ''' <summary>
      ''' Export DataGridView to PDF (using Microsoft Print to PDF)
      ''' </summary>
      Public Function ExportToPDF(dgv As DataGridView, title As String, Optional footer As String = "", Optional suggestedFileName As String = "") As String
         Try
            dataGridView = dgv
            headerText = title
            footerText = footer

            ' Generate filename
            Dim fileName As String = If(String.IsNullOrEmpty(suggestedFileName), GenerateFileName(title, "pdf"), suggestedFileName)
            Dim saveDialog As New SaveFileDialog()
            saveDialog.Filter = "PDF Files (*.pdf)|*.pdf"
            saveDialog.FileName = fileName
            saveDialog.Title = "Export to PDF"

            If saveDialog.ShowDialog() = DialogResult.OK Then
               ' Create new print document for PDF
               Dim pdfPrintDocument As New PrintDocument()

               ' Set to landscape for wider tables
               pdfPrintDocument.DefaultPageSettings.Landscape = True

               ' Check if Microsoft Print to PDF is available
               Dim hasMicrosoftPDF As Boolean = False
               For Each printer As String In PrinterSettings.InstalledPrinters
                  If printer.Contains("Microsoft Print to PDF") Then
                     hasMicrosoftPDF = True
                     Exit For
                  End If
               Next

               If hasMicrosoftPDF Then
                  pdfPrintDocument.PrinterSettings.PrinterName = "Microsoft Print to PDF"
               End If

               pdfPrintDocument.PrinterSettings.PrintToFile = True
               pdfPrintDocument.PrinterSettings.PrintFileName = saveDialog.FileName

               ' Set document name (this appears in print queue and PDF properties)
               pdfPrintDocument.DocumentName = Path.GetFileNameWithoutExtension(saveDialog.FileName)

               AddHandler pdfPrintDocument.PrintPage, AddressOf PrintDocument_PrintPage

               ' Reset counters
               currentRow = 0
               currentPageIndex = 0

               ' Store the print document temporarily
               Dim originalDoc = printDocument
               printDocument = pdfPrintDocument

               ' Print to PDF
               pdfPrintDocument.Print()

               ' Restore original document
               printDocument = originalDoc

               RemoveHandler pdfPrintDocument.PrintPage, AddressOf PrintDocument_PrintPage
               pdfPrintDocument.Dispose()

               Return saveDialog.FileName
            End If

            Return String.Empty

         Catch ex As Exception
            Throw New Exception($"Error exporting to PDF: {ex.Message}", ex)
         End Try
      End Function

      Private Sub PrintDocument_PrintPage(sender As Object, e As PrintPageEventArgs)
         Try
            Dim font As New Font("Arial", 8)
            Dim headerFont As New Font("Arial", 12, FontStyle.Bold)
            Dim columnHeaderFont As New Font("Arial", 8, FontStyle.Bold)
            Dim footerFont As New Font("Arial", 7)
            Dim brush As New SolidBrush(Color.Black)

            Dim yPos As Integer = e.MarginBounds.Top
            Dim leftMargin As Integer = e.MarginBounds.Left
            Dim rightMargin As Integer = e.MarginBounds.Right

            ' Calculate footer height requirements
            Dim footerTextHeight As Single = 0
            If Not String.IsNullOrEmpty(footerText) Then
               footerTextHeight = e.Graphics.MeasureString(footerText, footerFont, e.MarginBounds.Width).Height
            End If

            Dim appFooter As String = AppInfo.GetPrintFooter(includeTimestamp:=String.IsNullOrEmpty(footerText))
            Dim appFooterHeight As Single = e.Graphics.MeasureString(appFooter, footerFont, e.MarginBounds.Width).Height

            Dim totalFooterHeight As Integer = CInt(footerTextHeight + appFooterHeight + 20) ' 20 for padding/lines
            Dim footerY As Integer = e.MarginBounds.Bottom - totalFooterHeight

            ' Print header
            Dim headerSize As SizeF = e.Graphics.MeasureString(headerText, headerFont)
            Dim headerX As Integer = CInt((e.MarginBounds.Width - headerSize.Width) / 2) + leftMargin
            e.Graphics.DrawString(headerText, headerFont, brush, headerX, yPos)
            yPos += CInt(headerSize.Height) + 15

            ' Draw line under header
            e.Graphics.DrawLine(Pens.Black, leftMargin, yPos, rightMargin, yPos)
            yPos += 10

            ' Get visible columns
            Dim visibleColumns As New List(Of DataGridViewColumn)()
            For Each column As DataGridViewColumn In dataGridView.Columns
               If column.Visible Then
                  visibleColumns.Add(column)
               End If
            Next

            ' Calculate dynamic column widths based on content
            Dim totalWidth As Integer = e.MarginBounds.Width
            Dim columnWidths As New List(Of Integer)()
            Dim totalPreferredWidth As Integer = 0
            Dim preferredWidths As New List(Of Integer)()

            ' Calculate preferred width for each column
            For Each column In visibleColumns
               Dim maxWidth As Integer = 50 ' Minimum width

               ' Measure header width
               Dim headerWidth As Integer = CInt(e.Graphics.MeasureString(column.HeaderText, columnHeaderFont).Width) + 10
               maxWidth = Math.Max(maxWidth, headerWidth)

               ' Sample first 10 rows to determine content width
               Dim rowsToCheck As Integer = Math.Min(10, dataGridView.Rows.Count)
               For i As Integer = 0 To rowsToCheck - 1
                  If Not dataGridView.Rows(i).IsNewRow AndAlso dataGridView.Rows(i).Cells(column.Index).Value IsNot Nothing Then
                     Dim cellText As String = dataGridView.Rows(i).Cells(column.Index).FormattedValue.ToString()
                     Dim cellWidth As Integer = CInt(e.Graphics.MeasureString(cellText, font).Width) + 10
                     maxWidth = Math.Max(maxWidth, cellWidth)
                  End If
               Next

               ' Limit maximum width to prevent extremely wide columns
               maxWidth = Math.Min(maxWidth, 200)

               preferredWidths.Add(maxWidth)
               totalPreferredWidth += maxWidth
            Next

            ' Scale widths proportionally if total exceeds available space
            If totalPreferredWidth > totalWidth Then
               Dim scaleFactor As Double = totalWidth / totalPreferredWidth
               For Each prefWidth In preferredWidths
                  columnWidths.Add(CInt(prefWidth * scaleFactor))
               Next
            Else
               ' Distribute extra space proportionally
               Dim extraSpace As Integer = totalWidth - totalPreferredWidth
               Dim spacePerColumn As Integer = extraSpace \ visibleColumns.Count
               For Each prefWidth In preferredWidths
                  columnWidths.Add(prefWidth + spacePerColumn)
               Next
            End If

            ' Print column headers with background
            Dim xPos As Integer = leftMargin
            Dim headerRect As New Rectangle(leftMargin, yPos, totalWidth, 22)
            e.Graphics.FillRectangle(New SolidBrush(Color.FromArgb(52, 73, 94)), headerRect)

            For i As Integer = 0 To visibleColumns.Count - 1
               Dim column = visibleColumns(i)
               Dim headerStringFormat As New StringFormat()
               headerStringFormat.Alignment = StringAlignment.Center
               headerStringFormat.LineAlignment = StringAlignment.Center
               headerStringFormat.Trimming = StringTrimming.EllipsisCharacter

               e.Graphics.DrawString(column.HeaderText, columnHeaderFont, Brushes.White,
                                    New RectangleF(xPos + 2, yPos, columnWidths(i) - 4, 22),
                                    headerStringFormat)

               ' Draw vertical line between columns
               If i < visibleColumns.Count - 1 Then
                  e.Graphics.DrawLine(Pens.White, xPos + columnWidths(i), yPos, xPos + columnWidths(i), yPos + 22)
               End If

               xPos += columnWidths(i)
            Next
            yPos += 25

            ' Print rows with alternating colors
            Dim rowCount As Integer = 0
            While currentRow < dataGridView.Rows.Count
               If dataGridView.Rows(currentRow).IsNewRow Then
                  currentRow += 1
                  Continue While
               End If

               ' Check if we have space for this row
               If yPos + 20 > footerY - 10 Then
                  e.HasMorePages = True
                  Exit Sub
               End If

               ' Alternating row background
               If rowCount Mod 2 = 0 Then
                  Dim rowRect As New Rectangle(leftMargin, yPos, totalWidth, 18)
                  e.Graphics.FillRectangle(New SolidBrush(Color.FromArgb(240, 240, 240)), rowRect)
               End If

               xPos = leftMargin
               For i As Integer = 0 To visibleColumns.Count - 1
                  Dim column = visibleColumns(i)
                  Dim cellValue As String = ""
                  If dataGridView.Rows(currentRow).Cells(column.Index).Value IsNot Nothing Then
                     cellValue = dataGridView.Rows(currentRow).Cells(column.Index).FormattedValue.ToString()
                  End If

                  ' Determine alignment based on column type
                  Dim stringFormat As New StringFormat()
                  If column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight OrElse
                       column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight OrElse
                       column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight Then
                     stringFormat.Alignment = StringAlignment.Far
                  ElseIf column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter OrElse
                           column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopCenter OrElse
                           column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter Then
                     stringFormat.Alignment = StringAlignment.Center
                  Else
                     stringFormat.Alignment = StringAlignment.Near
                  End If

                  stringFormat.LineAlignment = StringAlignment.Center
                  stringFormat.Trimming = StringTrimming.EllipsisCharacter
                  stringFormat.FormatFlags = StringFormatFlags.NoWrap

                  e.Graphics.DrawString(cellValue, font, brush,
                                        New RectangleF(xPos + 3, yPos, columnWidths(i) - 6, 18),
                                        stringFormat)
                  xPos += columnWidths(i)
               Next

               yPos += 18
               currentRow += 1
               rowCount += 1
            End While

            ' Print footer
            e.Graphics.DrawLine(Pens.Black, leftMargin, footerY, rightMargin, footerY)
            Dim currentFooterY As Single = footerY + 5

            If Not String.IsNullOrEmpty(footerText) Then
               e.Graphics.DrawString(footerText, footerFont, brush, New RectangleF(leftMargin, currentFooterY, e.MarginBounds.Width, footerTextHeight))
               currentFooterY += footerTextHeight + 5
            End If

            e.Graphics.DrawString(appFooter, footerFont, brush, leftMargin, currentFooterY)

            ' Print page number
            currentPageIndex += 1
            Dim pageNum As String = $"Page {currentPageIndex}"
            Dim pageNumSize As SizeF = e.Graphics.MeasureString(pageNum, footerFont)
            e.Graphics.DrawString(pageNum, footerFont, brush, rightMargin - pageNumSize.Width, e.MarginBounds.Bottom - 15)

            e.HasMorePages = False

         Catch ex As Exception
            Throw New Exception($"Error in print page: {ex.Message}", ex)
         End Try
      End Sub

      ''' <summary>
      ''' Generate meaningful filename
      ''' </summary>
      Private Function GenerateFileName(title As String, extension As String) As String
         Dim cleanTitle As String = title.Replace(" ", "_").Replace(":", "").Replace("/", "-")
         Return $"{cleanTitle}_{DateTime.Now:yyyyMMdd_HHmmss}.{extension}"
      End Function

   End Class
End Namespace
