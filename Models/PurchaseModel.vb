Imports MySql.Data.MySqlClient

Namespace Models
    Public Class PurchaseModel
        Public Property IdPurchase As String
        Public Property PurchaseDate As DateTime
        Public Property SupplierId As Integer
        Public Property SupplierName As String ' For display purposes
        Public Property TotalAmount As Decimal
        Public Property Notes As String
        Public Property Status As String
        Public Property CreatedBy As Integer
        Public Property CreatedAt As DateTime

        Public Sub New()
            PurchaseDate = DateTime.Now
            Status = "completed"
            TotalAmount = 0
        End Sub

        Public Sub New(idPurchase As String, purchaseDate As DateTime, supplierId As Integer, 
                       totalAmount As Decimal, status As String)
            Me.IdPurchase = idPurchase
            Me.PurchaseDate = purchaseDate
            Me.SupplierId = supplierId
            Me.TotalAmount = totalAmount
            Me.Status = status
        End Sub

        Public Overrides Function ToString() As String
            Return $"Purchase: {IdPurchase} - {PurchaseDate:dd/MM/yyyy} - Rp {TotalAmount:N0}"
        End Function
    End Class

    Public Class PurchaseDetailModel
        Public Property Id As Integer
        Public Property IdPurchase As String
        Public Property ItemID As String
        Public Property ItemDesc As String ' For display purposes
        Public Property QtyPurchase As Integer
        Public Property PurchasePrice As Decimal
        Public Property Subtotal As Decimal
        Public Property Unit As String ' For display purposes

        Public Sub New()
            QtyPurchase = 1
            PurchasePrice = 0
            Subtotal = 0
        End Sub

        Public Sub New(idPurchase As String, itemID As String, qtyPurchase As Integer, 
                       purchasePrice As Decimal)
            Me.IdPurchase = idPurchase
            Me.ItemID = itemID
            Me.QtyPurchase = qtyPurchase
            Me.PurchasePrice = purchasePrice
            Me.Subtotal = qtyPurchase * purchasePrice
        End Sub

        Public Sub CalculateSubtotal()
            Subtotal = QtyPurchase * PurchasePrice
        End Sub

        Public Overrides Function ToString() As String
            Return $"{ItemID} - Qty: {QtyPurchase} x Rp {PurchasePrice:N0} = Rp {Subtotal:N0}"
        End Function
    End Class
End Namespace
