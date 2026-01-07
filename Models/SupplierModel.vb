Imports MySql.Data.MySqlClient

Namespace Models
    Public Class SupplierModel
        Public Property Id As Integer
        Public Property SupplierCode As String
        Public Property SupplierName As String
        Public Property Contact As String
        Public Property Phone As String
        Public Property Email As String
        Public Property Address As String
        Public Property City As String
        Public Property CreatedAt As DateTime
        Public Property UpdatedAt As DateTime

        Public Sub New()
            ' Default constructor
        End Sub

        Public Sub New(id As Integer, supplierCode As String, supplierName As String, 
                       contact As String, phone As String, email As String, 
                       address As String, city As String)
            Me.Id = id
            Me.SupplierCode = supplierCode
            Me.SupplierName = supplierName
            Me.Contact = contact
            Me.Phone = phone
            Me.Email = email
            Me.Address = address
            Me.City = city
        End Sub

        Public Overrides Function ToString() As String
            Return $"{SupplierCode} - {SupplierName} ({City})"
        End Function
    End Class
End Namespace
