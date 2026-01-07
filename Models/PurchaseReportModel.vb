Imports MySql.Data.MySqlClient

Namespace Models
    Public Class PurchaseReportModel
        Public Property Nota As String
        Public Property TglNota As DateTime
        Public Property KodeSupplier As String
        Public Property NamaSupplier As String
        Public Property KodeBrg As String
        Public Property NamaBrg As String
        Public Property Qty As Integer
        Public Property HargaBeli As Decimal
        Public Property Unit As String
        Public Property Subtotal As Decimal
        Public Property TotalTransaksi As Decimal
        Public Property Status As String
        Public Property CreatedBy As String

        Public Sub New()
        End Sub

        Public Sub New(nota As String, tglNota As DateTime, kodeSupplier As String, 
                       namaSupplier As String, kodeBrg As String, namaBrg As String,
                       qty As Integer, hargaBeli As Decimal, unit As String, 
                       subtotal As Decimal, totalTransaksi As Decimal, 
                       status As String, createdBy As String)
            Me.Nota = nota
            Me.TglNota = tglNota
            Me.KodeSupplier = kodeSupplier
            Me.NamaSupplier = namaSupplier
            Me.KodeBrg = kodeBrg
            Me.NamaBrg = namaBrg
            Me.Qty = qty
            Me.HargaBeli = hargaBeli
            Me.Unit = unit
            Me.Subtotal = subtotal
            Me.TotalTransaksi = totalTransaksi
            Me.Status = status
            Me.CreatedBy = createdBy
        End Sub

        Public Overrides Function ToString() As String
            Return $"{Nota} - {NamaSupplier} - Rp {TotalTransaksi:N0}"
        End Function
    End Class
End Namespace
