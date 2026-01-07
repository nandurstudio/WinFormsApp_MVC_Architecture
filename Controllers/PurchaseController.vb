Imports MySql.Data.MySqlClient
Imports WinFormsApp_Latihan.Models

Namespace Controllers
    Public Class PurchaseController
        Private ReadOnly _configModel As ConfigModel

        Public Sub New(configModel As ConfigModel)
            _configModel = configModel
        End Sub

        ''' <summary>
        ''' Generate next purchase code (PUR0001, PUR0002, etc)
        ''' </summary>
        Public Function GeneratePurchaseCode() As String
            Try
                Using conn As New MySqlConnection(_configModel.GetConnectionString())
                    conn.Open()
                    Dim query As String = "SELECT idPurchase FROM purchase ORDER BY idPurchase DESC LIMIT 1"
                    Using cmd As New MySqlCommand(query, conn)
                        Dim lastCode As Object = cmd.ExecuteScalar()

                        If lastCode Is Nothing OrElse IsDBNull(lastCode) Then
                            Return "PUR0001"
                        End If

                        Dim lastCodeStr As String = lastCode.ToString()
                        Dim numberPart As String = lastCodeStr.Substring(3) ' Remove "PUR" prefix
                        Dim nextNumber As Integer = Integer.Parse(numberPart) + 1

                        Return $"PUR{nextNumber:D4}"
                    End Using
                End Using
            Catch ex As Exception
                Throw New Exception($"Error generating purchase code: {ex.Message}", ex)
            End Try
        End Function

        ''' <summary>
        ''' Create new purchase transaction with details
        ''' </summary>
        Public Function CreatePurchase(purchase As PurchaseModel, details As List(Of PurchaseDetailModel), userId As Integer) As Boolean
            Dim transaction As MySqlTransaction = Nothing
            Try
                Using conn As New MySqlConnection(_configModel.GetConnectionString())
                    conn.Open()
                    transaction = conn.BeginTransaction()

                    ' Insert purchase master
                    Dim queryMaster As String = "INSERT INTO purchase (idPurchase, purchaseDate, supplierId, totalAmount, notes, status, created_by) VALUES (@idPurchase, @purchaseDate, @supplierId, @totalAmount, @notes, @status, @created_by)"
                    Using cmdMaster As New MySqlCommand(queryMaster, conn, transaction)
                        cmdMaster.Parameters.AddWithValue("@idPurchase", purchase.IdPurchase)
                        cmdMaster.Parameters.AddWithValue("@purchaseDate", purchase.PurchaseDate)
                        cmdMaster.Parameters.AddWithValue("@supplierId", purchase.SupplierId)
                        cmdMaster.Parameters.AddWithValue("@totalAmount", 0) ' Will be updated by trigger
                        cmdMaster.Parameters.AddWithValue("@notes", If(String.IsNullOrEmpty(purchase.Notes), DBNull.Value, purchase.Notes))
                        cmdMaster.Parameters.AddWithValue("@status", purchase.Status)
                        cmdMaster.Parameters.AddWithValue("@created_by", userId)

                        cmdMaster.ExecuteNonQuery()
                    End Using

                    ' Insert purchase details
                    Dim queryDetail As String = "INSERT INTO purchasedetail (idPurchase, itemID, qtyPurchase, purchasePrice, subtotal) VALUES (@idPurchase, @itemID, @qtyPurchase, @purchasePrice, @subtotal)"
                    For Each detail In details
                        Using cmdDetail As New MySqlCommand(queryDetail, conn, transaction)
                            cmdDetail.Parameters.AddWithValue("@idPurchase", purchase.IdPurchase)
                            cmdDetail.Parameters.AddWithValue("@itemID", detail.ItemID)
                            cmdDetail.Parameters.AddWithValue("@qtyPurchase", detail.QtyPurchase)
                            cmdDetail.Parameters.AddWithValue("@purchasePrice", detail.PurchasePrice)
                            cmdDetail.Parameters.AddWithValue("@subtotal", detail.Subtotal)

                            cmdDetail.ExecuteNonQuery()
                        End Using
                    Next

                    transaction.Commit()
                    Return True
                End Using
            Catch ex As Exception
                If transaction IsNot Nothing Then
                    Try
                        transaction.Rollback()
                    Catch rollbackEx As Exception
                        ' Log rollback error
                    End Try
                End If
                Throw New Exception($"Error creating purchase: {ex.Message}", ex)
            End Try
        End Function

        ''' <summary>
        ''' Load all purchases
        ''' </summary>
        Public Function LoadPurchases() As DataTable
            Try
                Using conn As New MySqlConnection(_configModel.GetConnectionString())
                    conn.Open()
                    Dim query As String = "SELECT p.idPurchase, p.purchaseDate, s.supplierName, p.totalAmount, p.status, u.username AS created_by FROM purchase p LEFT JOIN supplier s ON p.supplierId = s.id LEFT JOIN users u ON p.created_by = u.user_id ORDER BY p.purchaseDate DESC"
                    Using adapter As New MySqlDataAdapter(query, conn)
                        Dim dt As New DataTable()
                        adapter.Fill(dt)
                        Return dt
                    End Using
                End Using
            Catch ex As Exception
                Throw New Exception($"Error loading purchases: {ex.Message}", ex)
            End Try
        End Function

        ''' <summary>
        ''' Get purchase details for a specific purchase
        ''' </summary>
        Public Function GetPurchaseDetails(idPurchase As String) As DataTable
            Try
                Using conn As New MySqlConnection(_configModel.GetConnectionString())
                    conn.Open()
                    Dim query As String = "SELECT pd.itemID, i.itemDesc, pd.qtyPurchase, i.unit, pd.purchasePrice, pd.subtotal FROM purchasedetail pd LEFT JOIN items i ON pd.itemID = i.itemID WHERE pd.idPurchase = @idPurchase ORDER BY pd.id"
                    Using adapter As New MySqlDataAdapter(query, conn)
                        adapter.SelectCommand.Parameters.AddWithValue("@idPurchase", idPurchase)
                        Dim dt As New DataTable()
                        adapter.Fill(dt)
                        Return dt
                    End Using
                End Using
            Catch ex As Exception
                Throw New Exception($"Error loading purchase details: {ex.Message}", ex)
            End Try
        End Function

        ''' <summary>
        ''' Delete purchase transaction
        ''' </summary>
        Public Function DeletePurchase(idPurchase As String) As Boolean
            Try
                Using conn As New MySqlConnection(_configModel.GetConnectionString())
                    conn.Open()

                    ' Details will be deleted automatically by CASCADE
                    Dim query As String = "DELETE FROM purchase WHERE idPurchase = @idPurchase"
                    Using cmd As New MySqlCommand(query, conn)
                        cmd.Parameters.AddWithValue("@idPurchase", idPurchase)
                        Return cmd.ExecuteNonQuery() > 0
                    End Using
                End Using
            Catch ex As Exception
                Throw New Exception($"Error deleting purchase: {ex.Message}", ex)
            End Try
        End Function
    End Class
End Namespace
