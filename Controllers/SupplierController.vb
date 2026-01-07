Imports MySql.Data.MySqlClient
Imports WinFormsApp_Latihan.Models

Namespace Controllers
    Public Class SupplierController
        Private ReadOnly _configModel As ConfigModel

        Public Sub New(configModel As ConfigModel)
            _configModel = configModel
        End Sub

        ''' <summary>
        ''' Load all suppliers
        ''' </summary>
        Public Function LoadSuppliers() As DataTable
            Try
                Using conn As New MySqlConnection(_configModel.GetConnectionString())
                    conn.Open()
                    Dim query As String = "SELECT id, supplierCode, supplierName, contact, phone, email, address, city, created_at FROM supplier ORDER BY supplierName"
                    Using adapter As New MySqlDataAdapter(query, conn)
                        Dim dt As New DataTable()
                        adapter.Fill(dt)
                        Return dt
                    End Using
                End Using
            Catch ex As Exception
                Throw New Exception($"Error loading suppliers: {ex.Message}", ex)
            End Try
        End Function

        ''' <summary>
        ''' Get supplier by ID
        ''' </summary>
        Public Function GetSupplier(id As Integer) As SupplierModel
            Try
                Using conn As New MySqlConnection(_configModel.GetConnectionString())
                    conn.Open()
                    Dim query As String = "SELECT id, supplierCode, supplierName, contact, phone, email, address, city FROM supplier WHERE id = @id"
                    Using cmd As New MySqlCommand(query, conn)
                        cmd.Parameters.AddWithValue("@id", id)

                        Using reader As MySqlDataReader = cmd.ExecuteReader()
                            If reader.Read() Then
                                Return New SupplierModel(
                                    Convert.ToInt32(reader("id")),
                                    reader("supplierCode").ToString(),
                                    reader("supplierName").ToString(),
                                    If(reader("contact") IsNot DBNull.Value, reader("contact").ToString(), ""),
                                    If(reader("phone") IsNot DBNull.Value, reader("phone").ToString(), ""),
                                    If(reader("email") IsNot DBNull.Value, reader("email").ToString(), ""),
                                    If(reader("address") IsNot DBNull.Value, reader("address").ToString(), ""),
                                    If(reader("city") IsNot DBNull.Value, reader("city").ToString(), "")
                                )
                            End If
                        End Using
                    End Using
                End Using
            Catch ex As Exception
                Throw New Exception($"Error retrieving supplier: {ex.Message}", ex)
            End Try

            Return Nothing
        End Function

        ''' <summary>
        ''' Create new supplier
        ''' </summary>
        Public Function Create(supplier As SupplierModel) As Boolean
            Try
                Using conn As New MySqlConnection(_configModel.GetConnectionString())
                    conn.Open()

                    ' Generate supplier code
                    Dim supplierCode As String = GenerateSupplierCode(conn)

                    Dim query As String = "INSERT INTO supplier (supplierCode, supplierName, contact, phone, email, address, city) VALUES (@supplierCode, @supplierName, @contact, @phone, @email, @address, @city)"
                    Using cmd As New MySqlCommand(query, conn)
                        cmd.Parameters.AddWithValue("@supplierCode", supplierCode)
                        cmd.Parameters.AddWithValue("@supplierName", supplier.SupplierName)
                        cmd.Parameters.AddWithValue("@contact", If(String.IsNullOrEmpty(supplier.Contact), DBNull.Value, supplier.Contact))
                        cmd.Parameters.AddWithValue("@phone", If(String.IsNullOrEmpty(supplier.Phone), DBNull.Value, supplier.Phone))
                        cmd.Parameters.AddWithValue("@email", If(String.IsNullOrEmpty(supplier.Email), DBNull.Value, supplier.Email))
                        cmd.Parameters.AddWithValue("@address", If(String.IsNullOrEmpty(supplier.Address), DBNull.Value, supplier.Address))
                        cmd.Parameters.AddWithValue("@city", If(String.IsNullOrEmpty(supplier.City), DBNull.Value, supplier.City))

                        Return cmd.ExecuteNonQuery() > 0
                    End Using
                End Using
            Catch ex As Exception
                Throw New Exception($"Error creating supplier: {ex.Message}", ex)
            End Try
        End Function

        ''' <summary>
        ''' Update existing supplier
        ''' </summary>
        Public Function Update(supplier As SupplierModel) As Boolean
            Try
                Using conn As New MySqlConnection(_configModel.GetConnectionString())
                    conn.Open()

                    Dim query As String = "UPDATE supplier SET supplierName = @supplierName, contact = @contact, phone = @phone, email = @email, address = @address, city = @city WHERE id = @id"
                    Using cmd As New MySqlCommand(query, conn)
                        cmd.Parameters.AddWithValue("@supplierName", supplier.SupplierName)
                        cmd.Parameters.AddWithValue("@contact", If(String.IsNullOrEmpty(supplier.Contact), DBNull.Value, supplier.Contact))
                        cmd.Parameters.AddWithValue("@phone", If(String.IsNullOrEmpty(supplier.Phone), DBNull.Value, supplier.Phone))
                        cmd.Parameters.AddWithValue("@email", If(String.IsNullOrEmpty(supplier.Email), DBNull.Value, supplier.Email))
                        cmd.Parameters.AddWithValue("@address", If(String.IsNullOrEmpty(supplier.Address), DBNull.Value, supplier.Address))
                        cmd.Parameters.AddWithValue("@city", If(String.IsNullOrEmpty(supplier.City), DBNull.Value, supplier.City))
                        cmd.Parameters.AddWithValue("@id", supplier.Id)

                        Return cmd.ExecuteNonQuery() > 0
                    End Using
                End Using
            Catch ex As Exception
                Throw New Exception($"Error updating supplier: {ex.Message}", ex)
            End Try
        End Function

        ''' <summary>
        ''' Delete supplier
        ''' </summary>
        Public Function Delete(id As Integer) As Boolean
            Try
                Using conn As New MySqlConnection(_configModel.GetConnectionString())
                    conn.Open()

                    ' Check if supplier is used in purchases
                    Dim checkQuery As String = "SELECT COUNT(*) FROM purchase WHERE supplierId = @id"
                    Using checkCmd As New MySqlCommand(checkQuery, conn)
                        checkCmd.Parameters.AddWithValue("@id", id)
                        Dim count As Integer = Convert.ToInt32(checkCmd.ExecuteScalar())

                        If count > 0 Then
                            Throw New Exception($"Supplier tidak dapat dihapus karena masih digunakan dalam {count} transaksi pembelian")
                        End If
                    End Using

                    Dim query As String = "DELETE FROM supplier WHERE id = @id"
                    Using cmd As New MySqlCommand(query, conn)
                        cmd.Parameters.AddWithValue("@id", id)
                        Return cmd.ExecuteNonQuery() > 0
                    End Using
                End Using
            Catch ex As Exception
                Throw New Exception($"Error deleting supplier: {ex.Message}", ex)
            End Try
        End Function

        ''' <summary>
        ''' Get all suppliers for ComboBox
        ''' </summary>
        Public Function GetSuppliersForComboBox() As List(Of SupplierModel)
            Dim suppliers As New List(Of SupplierModel)
            Try
                Using conn As New MySqlConnection(_configModel.GetConnectionString())
                    conn.Open()
                    Dim query As String = "SELECT id, supplierCode, supplierName, city FROM supplier ORDER BY supplierName"
                    Using cmd As New MySqlCommand(query, conn)
                        Using reader As MySqlDataReader = cmd.ExecuteReader()
                            While reader.Read()
                                suppliers.Add(New SupplierModel With {
                                    .Id = Convert.ToInt32(reader("id")),
                                    .SupplierCode = reader("supplierCode").ToString(),
                                    .SupplierName = reader("supplierName").ToString(),
                                    .City = If(reader("city") IsNot DBNull.Value, reader("city").ToString(), "")
                                })
                            End While
                        End Using
                    End Using
                End Using
            Catch ex As Exception
                Throw New Exception($"Error loading suppliers: {ex.Message}", ex)
            End Try
            Return suppliers
        End Function

        ''' <summary>
        ''' Generate next supplier code (SUP0001, SUP0002, etc)
        ''' </summary>
        Private Function GenerateSupplierCode(conn As MySqlConnection) As String
            Try
                Dim query As String = "SELECT supplierCode FROM supplier ORDER BY supplierCode DESC LIMIT 1"
                Using cmd As New MySqlCommand(query, conn)
                    Dim lastCode As Object = cmd.ExecuteScalar()

                    If lastCode Is Nothing OrElse IsDBNull(lastCode) Then
                        Return "SUP0001"
                    End If

                    Dim lastCodeStr As String = lastCode.ToString()
                    Dim numberPart As String = lastCodeStr.Substring(3) ' Remove "SUP" prefix
                    Dim nextNumber As Integer = Integer.Parse(numberPart) + 1

                    Return $"SUP{nextNumber:D4}"
                End Using
            Catch ex As Exception
                Throw New Exception($"Error generating supplier code: {ex.Message}", ex)
            End Try
        End Function
    End Class
End Namespace
