Imports MySql.Data.MySqlClient
Imports WinFormsApp_Latihan.Models

Namespace Controllers
   Public Class SalesReportController
      Private ReadOnly _configModel As ConfigModel

      Public Sub New(configModel As ConfigModel)
         _configModel = configModel
      End Sub

      ''' <summary>
      ''' Load sales report GROUPED by transaction
      ''' </summary>
      Public Function LoadSalesReportGrouped(startDate As DateTime, endDate As DateTime) As DataTable
         Try
            Using conn As New MySqlConnection(_configModel.GetConnectionString())
               conn.Open()

               Dim query As String = "SELECT 
                        s.idTrans AS NOTA,
                        s.saleDate AS TGL_NOTA,
                        DATE_FORMAT(s.saleDate, '%W') AS HARI,
                        DATE_FORMAT(s.saleDate, '%H:%i') AS WAKTU,
                        s.totalAmount AS TOTAL_TRANSAKSI,
                        COUNT(sd.id) AS JUMLAH_ITEM,
                        SUM(sd.qtySale) AS TOTAL_QTY
                    FROM sale s
                    LEFT JOIN saledetail sd ON s.idTrans = sd.idSale
                    WHERE s.saleDate BETWEEN @startDate AND @endDate 
                    GROUP BY s.idTrans, s.saleDate
                    ORDER BY s.saleDate DESC, s.idTrans"

               Using adapter As New MySqlDataAdapter(query, conn)
                  adapter.SelectCommand.Parameters.AddWithValue("@startDate", startDate)
                  adapter.SelectCommand.Parameters.AddWithValue("@endDate", endDate)

                  Dim dt As New DataTable()
                  adapter.Fill(dt)
                  Return dt
               End Using
            End Using
         Catch ex As Exception
            Throw New Exception($"Error loading sales report: {ex.Message}", ex)
         End Try
      End Function

      ''' <summary>
      ''' Load sales detail items for specific transaction
      ''' </summary>
      Public Function LoadSalesDetailByTransaction(transID As String) As DataTable
         Try
            Using conn As New MySqlConnection(_configModel.GetConnectionString())
               conn.Open()

               Dim query As String = "SELECT 
                        sd.itemID AS KODE_BRG,
                        i.itemDesc AS NAMA_BRG,
                        sd.qtySale AS QTY,
                        i.unit AS UNIT,
                        sd.price AS HARGA,
                        sd.subtotal AS SUBTOTAL
                    FROM saledetail sd
                    JOIN items i ON sd.itemID = i.itemID
                    WHERE sd.idSale = @transID
                    ORDER BY sd.id"

               Using adapter As New MySqlDataAdapter(query, conn)
                  adapter.SelectCommand.Parameters.AddWithValue("@transID", transID)

                  Dim dt As New DataTable()
                  adapter.Fill(dt)
                  Return dt
               End Using
            End Using
         Catch ex As Exception
            Throw New Exception($"Error loading sales detail: {ex.Message}", ex)
         End Try
      End Function

      ''' <summary>
      ''' Load sales report with date filter (OLD - for detail view)
      ''' </summary>
      Public Function LoadSalesReport(startDate As DateTime, endDate As DateTime) As DataTable
         Try
            Using conn As New MySqlConnection(_configModel.GetConnectionString())
               conn.Open()

               Dim query As String = "SELECT 
                        NOTA,
                        TGL_NOTA,
                        KODE_BRG,
                        NAMA_BRG,
                        QTY,
                        HARGA,
                        UNIT,
                        SUBTOTAL,
                        TOTAL_TRANSAKSI
                    FROM vw_sales_report 
                    WHERE TGL_NOTA BETWEEN @startDate AND @endDate 
                    ORDER BY TGL_NOTA DESC, NOTA"

               Using adapter As New MySqlDataAdapter(query, conn)
                  adapter.SelectCommand.Parameters.AddWithValue("@startDate", startDate)
                  adapter.SelectCommand.Parameters.AddWithValue("@endDate", endDate)

                  Dim dt As New DataTable()
                  adapter.Fill(dt)
                  Return dt
               End Using
            End Using
         Catch ex As Exception
            Throw New Exception($"Error loading sales report: {ex.Message}", ex)
         End Try
      End Function

      ''' <summary>
      ''' Get total sales amount for date range
      ''' </summary>
      Public Function GetTotalSalesAmount(startDate As DateTime, endDate As DateTime) As Decimal
         Try
            Using conn As New MySqlConnection(_configModel.GetConnectionString())
               conn.Open()

               Dim query As String = "SELECT COALESCE(SUM(totalAmount), 0) FROM sale WHERE saleDate BETWEEN @startDate AND @endDate"
               Using cmd As New MySqlCommand(query, conn)
                  cmd.Parameters.AddWithValue("@startDate", startDate)
                  cmd.Parameters.AddWithValue("@endDate", endDate)

                  Return Convert.ToDecimal(cmd.ExecuteScalar())
               End Using
            End Using
         Catch ex As Exception
            Throw New Exception($"Error getting total sales amount: {ex.Message}", ex)
         End Try
      End Function

      ''' <summary>
      ''' Get total sales count for date range
      ''' </summary>
      Public Function GetTotalSalesCount(startDate As DateTime, endDate As DateTime) As Integer
         Try
            Using conn As New MySqlConnection(_configModel.GetConnectionString())
               conn.Open()

               Dim query As String = "SELECT COUNT(*) FROM sale WHERE saleDate BETWEEN @startDate AND @endDate"
               Using cmd As New MySqlCommand(query, conn)
                  cmd.Parameters.AddWithValue("@startDate", startDate)
                  cmd.Parameters.AddWithValue("@endDate", endDate)

                  Return Convert.ToInt32(cmd.ExecuteScalar())
               End Using
            End Using
         Catch ex As Exception
            Throw New Exception($"Error getting total sales count: {ex.Message}", ex)
         End Try
      End Function
   End Class
End Namespace
