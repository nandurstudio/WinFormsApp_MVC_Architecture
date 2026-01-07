Imports MySql.Data.MySqlClient
Imports WinFormsApp_Latihan.Models

Namespace Controllers
    Public Class PurchaseReportController
        Private ReadOnly _configModel As ConfigModel

        Public Sub New(configModel As ConfigModel)
            _configModel = configModel
        End Sub

      ''' <summary>
      ''' Load purchase report GROUPED by transaction
      ''' </summary>
      Public Function LoadPurchaseReportGrouped(startDate As DateTime, endDate As DateTime) As DataTable
         Try
            Using conn As New MySqlConnection(_configModel.GetConnectionString())
               conn.Open()

               Dim query As String = "SELECT 
                        p.idPurchase AS NOTA,
                        p.purchaseDate AS TGL_NOTA,
                        s.supplierName AS NAMA_SUPPLIER,
                        p.totalAmount AS TOTAL_TRANSAKSI,
                        COUNT(pd.id) AS JUMLAH_ITEM,
                        p.status AS STATUS,
                        u.username AS CREATED_BY
                    FROM purchase p
                    LEFT JOIN purchasedetail pd ON p.idPurchase = pd.idPurchase
                    JOIN supplier s ON p.supplierId = s.id
                    LEFT JOIN users u ON p.created_by = u.user_id
                    WHERE p.purchaseDate BETWEEN @startDate AND @endDate 
                    GROUP BY p.idPurchase, p.purchaseDate, s.supplierName, p.totalAmount, p.status, u.username
                    ORDER BY p.purchaseDate DESC, p.idPurchase"

               Using adapter As New MySqlDataAdapter(query, conn)
                  adapter.SelectCommand.Parameters.AddWithValue("@startDate", startDate)
                  adapter.SelectCommand.Parameters.AddWithValue("@endDate", endDate)

                  Dim dt As New DataTable()
                  adapter.Fill(dt)
                  Return dt
               End Using
            End Using
         Catch ex As Exception
            Throw New Exception($"Error loading purchase report: {ex.Message}", ex)
         End Try
      End Function

      ''' <summary>
      ''' Load purchase detail items for specific transaction
      ''' </summary>
      Public Function LoadPurchaseDetailByTransaction(purchaseID As String) As DataTable
         Try
            Using conn As New MySqlConnection(_configModel.GetConnectionString())
               conn.Open()

               Dim query As String = "SELECT 
                        pd.itemID AS KODE_BRG,
                        i.itemDesc AS NAMA_BRG,
                        pd.qtyPurchase AS QTY,
                        i.unit AS UNIT,
                        pd.purchasePrice AS HARGA_BELI,
                        pd.subtotal AS SUBTOTAL
                    FROM purchasedetail pd
                    JOIN items i ON pd.itemID = i.itemID
                    WHERE pd.idPurchase = @purchaseID
                    ORDER BY pd.id"

               Using adapter As New MySqlDataAdapter(query, conn)
                  adapter.SelectCommand.Parameters.AddWithValue("@purchaseID", purchaseID)

                  Dim dt As New DataTable()
                  adapter.Fill(dt)
                  Return dt
               End Using
            End Using
         Catch ex As Exception
            Throw New Exception($"Error loading purchase detail: {ex.Message}", ex)
         End Try
      End Function

      ''' <summary>
      ''' Load purchase report with date filter (OLD - for detail view)
      ''' </summary>
      Public Function LoadPurchaseReport(startDate As DateTime, endDate As DateTime) As DataTable
         Try
            Using conn As New MySqlConnection(_configModel.GetConnectionString())
               conn.Open()

               Dim query As String = "SELECT 
                        NOTA,
                        TGL_NOTA,
                        KODE_SUPPLIER,
                        NAMA_SUPPLIER,
                        KODE_BRG,
                        NAMA_BRG,
                        QTY,
                        HARGA_BELI,
                        UNIT,
                        SUBTOTAL,
                        TOTAL_TRANSAKSI,
                        STATUS,
                        CREATED_BY
                    FROM vw_purchase_report 
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
            Throw New Exception($"Error loading purchase report: {ex.Message}", ex)
         End Try
      End Function

      ''' <summary>
      ''' Load purchase summary
      ''' </summary>
      Public Function LoadPurchaseSummary(startDate As DateTime, endDate As DateTime) As DataTable
         Try
            Using conn As New MySqlConnection(_configModel.GetConnectionString())
               conn.Open()

               Dim query As String = "SELECT 
                        idPurchase,
                        purchaseDate,
                        supplierName,
                        city,
                        total_items,
                        total_quantity,
                        totalAmount,
                        status,
                        created_by
                    FROM vw_purchase_summary 
                    WHERE purchaseDate BETWEEN @startDate AND @endDate 
                    ORDER BY purchaseDate DESC"

               Using adapter As New MySqlDataAdapter(query, conn)
                  adapter.SelectCommand.Parameters.AddWithValue("@startDate", startDate)
                  adapter.SelectCommand.Parameters.AddWithValue("@endDate", endDate)

                  Dim dt As New DataTable()
                  adapter.Fill(dt)
                  Return dt
               End Using
            End Using
         Catch ex As Exception
            Throw New Exception($"Error loading purchase summary: {ex.Message}", ex)
         End Try
      End Function

      ''' <summary>
      ''' Load supplier purchase summary
      ''' </summary>
      Public Function LoadSupplierPurchaseSummary() As DataTable
         Try
            Using conn As New MySqlConnection(_configModel.GetConnectionString())
               conn.Open()

               Dim query As String = "SELECT 
                        supplierCode,
                        supplierName,
                        city,
                        total_transactions,
                        total_items_purchased,
                        total_purchase_value,
                        last_purchase_date
                    FROM vw_supplier_purchase_summary 
                    ORDER BY total_purchase_value DESC"

               Using adapter As New MySqlDataAdapter(query, conn)
                  Dim dt As New DataTable()
                  adapter.Fill(dt)
                  Return dt
               End Using
            End Using
         Catch ex As Exception
            Throw New Exception($"Error loading supplier purchase summary: {ex.Message}", ex)
         End Try
      End Function

      ''' <summary>
      ''' Get total purchase amount for date range
      ''' </summary>
      Public Function GetTotalPurchaseAmount(startDate As DateTime, endDate As DateTime) As Decimal
         Try
            Using conn As New MySqlConnection(_configModel.GetConnectionString())
               conn.Open()

               Dim query As String = "SELECT COALESCE(SUM(totalAmount), 0) FROM purchase WHERE purchaseDate BETWEEN @startDate AND @endDate AND status = 'completed'"
               Using cmd As New MySqlCommand(query, conn)
                  cmd.Parameters.AddWithValue("@startDate", startDate)
                  cmd.Parameters.AddWithValue("@endDate", endDate)

                  Return Convert.ToDecimal(cmd.ExecuteScalar())
               End Using
            End Using
         Catch ex As Exception
            Throw New Exception($"Error getting total purchase amount: {ex.Message}", ex)
         End Try
      End Function

      ''' <summary>
      ''' Get total purchase count for date range
      ''' </summary>
      Public Function GetTotalPurchaseCount(startDate As DateTime, endDate As DateTime) As Integer
         Try
            Using conn As New MySqlConnection(_configModel.GetConnectionString())
               conn.Open()

               Dim query As String = "SELECT COUNT(*) FROM purchase WHERE purchaseDate BETWEEN @startDate AND @endDate AND status = 'completed'"
               Using cmd As New MySqlCommand(query, conn)
                  cmd.Parameters.AddWithValue("@startDate", startDate)
                  cmd.Parameters.AddWithValue("@endDate", endDate)

                  Return Convert.ToInt32(cmd.ExecuteScalar())
               End Using
            End Using
         Catch ex As Exception
            Throw New Exception($"Error getting total purchase count: {ex.Message}", ex)
         End Try
      End Function
   End Class
End Namespace
