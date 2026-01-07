Imports MySql.Data.MySqlClient
Public Class SaleModel
    Public Property idTrans As String
    Public Property saleDate As DateTime
    Public Property totalSale As Double
    Public Property details As List(Of SaleDetailModel)

    Public Shared Function Insert(sale As SaleModel) As Boolean
        Using conn = Koneksi.OpenConnection()

            Try
                ' Insert Master
                Dim cmd As New MySqlCommand(" INSERT INTO sale (idTrans, saleDate) " & _
                    " VALUES (@kode, @tanggal)", conn)

                cmd.Parameters.AddWithValue("@kode", sale.idTrans)
                cmd.Parameters.AddWithValue("@tanggal", sale.saleDate)
                cmd.ExecuteNonQuery()

                Dim saleId = sale.idTrans

                ' Insert Detail
                For Each d In sale.details
                    Dim cmdDet As New MySqlCommand(" INSERT INTO saledetail" & _
                        "(idSale, itemID, qtySale, price, subtotal) " & _
                        " VALUES (@sale_id, @item_id, @qty, @price, @subtotal)", conn)

                    cmdDet.Parameters.AddWithValue("@sale_id", saleId)
                    cmdDet.Parameters.AddWithValue("@item_id", d.ProductId)
                    cmdDet.Parameters.AddWithValue("@qty", d.Qty)
                    cmdDet.Parameters.AddWithValue("@price", d.Price)
                    cmdDet.Parameters.AddWithValue("@subtotal", d.Subtotal)
                    cmdDet.ExecuteNonQuery()
                Next


                Return True

            Catch ex As Exception
                MessageBox.Show("Error Insert detail Sale: " & ex.Message)
                Return False
            End Try
        End Using
    End Function


    Public Shared Function GenerateKodeTransaksi() As String
        Dim kodeBaru As String = "TRX0001"
        Try
            Using conn = Koneksi.OpenConnection()

                Dim cmd As New MySqlCommand("SELECT idTrans FROM sale ORDER BY idTrans DESC LIMIT 1", conn)
                Dim rd = cmd.ExecuteReader()

                If rd.Read() Then
                    Dim kodeLama As String = rd("idTrans")
                    Dim nomor As Integer = CInt(kodeLama.Substring(3)) + 1
                    kodeBaru = "TRX" & nomor.ToString("0000")
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show("Error generate kode: " & ex.Message)
        End Try
        Return kodeBaru
    End Function
End Class
