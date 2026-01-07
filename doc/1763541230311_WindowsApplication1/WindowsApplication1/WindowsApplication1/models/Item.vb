Imports MySql.Data.MySqlClient

Public Class ItemModel
    Public Property id As Integer
    Public Property itemID As String
    Public Property itemDesc As String
    Public Property itemCate As Integer
    Public Property unit As String
    Public Property salesPrice As Integer
    Public Property minStock As Integer


    Public Shared Function getAll() As DataTable
        Dim dt As New DataTable
        Dim query As String = "SELECT items.*,categoryDesc " & _
        " FROM items LEFT JOIN category ON items.itemCate = category.id "

        Using conn = Koneksi.OpenConnection()
            Using cmd As New MySqlCommand(query, conn)
                dt.Load(cmd.ExecuteReader())
            End Using
        End Using

        Return dt

    End Function


End Class
