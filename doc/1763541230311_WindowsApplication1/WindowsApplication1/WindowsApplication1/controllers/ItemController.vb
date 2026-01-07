Public Class ItemController
    Public Function LoadItems() As DataTable
        Return ItemModel.getAll()
    End Function
End Class
