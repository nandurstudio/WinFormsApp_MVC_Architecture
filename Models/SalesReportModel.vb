Imports MySql.Data.MySqlClient
Imports WinFormsApp_Latihan.Models

Namespace Models
   ' Sales Report Data Access - should be used via SalesReportController
   Public Class SalesReportDataAccess
      Private ReadOnly _config As ConfigModel

      Public Sub New(config As ConfigModel)
         _config = config
      End Sub

      Public Function GetAll() As DataTable
         Dim dt As New DataTable()

         ' Query langsung tanpa VIEW
         Dim query As String = "SELECT " &
                      "S.idTrans as NOTA, " &
                      "S.saleDate as TGL_NOTA, " &
                      "SD.itemID as KODE_BRG, " &
                      "I.itemDesc as NAMA_BRG, " &
                      "SD.qtySale AS QTY, " &
                      "SD.price AS HARGA, " &
                      "I.unit as UNIT, " &
                      "SD.subtotal AS SUBTOTAL, " &
                      "S.totalAmount AS TOTAL_TRANSAKSI " &
                      "FROM sale S " &
                      "INNER JOIN saledetail SD ON S.idTrans = SD.idSale " &
                      "LEFT JOIN items I ON SD.itemID = I.itemID " &
                      "ORDER BY S.saleDate DESC, S.idTrans, SD.itemID"

         Using conn As New MySqlConnection(_config.GetConnectionString())
            conn.Open()
            Using cmd As New MySqlCommand(query, conn)
               Using reader As MySqlDataReader = cmd.ExecuteReader()
                  dt.Load(reader)
               End Using
            End Using
         End Using

         Return dt
      End Function

      Public Function GetByDateRange(startDate As DateTime, endDate As DateTime) As DataTable
         Dim dt As New DataTable()
         ' Gunakan VIEW dengan filter tanggal
         Dim query As String = "SELECT * FROM vw_sales_report " &
                                 "WHERE TGL_NOTA BETWEEN @startDate AND @endDate"

         Using conn As New MySqlConnection(_config.GetConnectionString())
            conn.Open()
            Using cmd As New MySqlCommand(query, conn)
               cmd.Parameters.AddWithValue("@startDate", startDate)
               cmd.Parameters.AddWithValue("@endDate", endDate)
               dt.Load(cmd.ExecuteReader())
            End Using
         End Using

         Return dt
      End Function

      Public Function GetTotalSales(Optional startDate As DateTime? = Nothing, Optional endDate As DateTime? = Nothing) As Decimal
         Dim query As String

         If startDate.HasValue AndAlso endDate.HasValue Then
            query = "SELECT COALESCE(SUM(SD.qtySale * SD.price), 0) AS Total " &
                       "FROM sale S INNER JOIN saledetail SD ON S.idTrans = SD.idSale " &
                       "WHERE S.saleDate BETWEEN @startDate AND @endDate"
         Else
            query = "SELECT COALESCE(SUM(SD.qtySale * SD.price), 0) AS Total " &
                       "FROM sale S INNER JOIN saledetail SD ON S.idTrans = SD.idSale"
         End If

         Using conn As New MySqlConnection(_config.GetConnectionString())
            conn.Open()
            Using cmd As New MySqlCommand(query, conn)
               If startDate.HasValue AndAlso endDate.HasValue Then
                  cmd.Parameters.AddWithValue("@startDate", startDate.Value)
                  cmd.Parameters.AddWithValue("@endDate", endDate.Value)
               End If

               Dim result As Object = cmd.ExecuteScalar()
               Return If(result IsNot Nothing, Convert.ToDecimal(result), 0)
            End Using
         End Using
      End Function
   End Class
End Namespace
