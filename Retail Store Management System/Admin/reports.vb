Imports System.Data.Odbc
Public Class reports

    Private Sub reports_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GenerateChart()
    End Sub
    Sub GenerateChart()
        Dim query As String
        Dim reader As OdbcDataReader
        query = "SELECT * FROM tbl_sales"
        cmd = New OdbcCommand(query, conn)
        reader = cmd.ExecuteReader
        While reader.Read()
            Dim transactionDate As String = reader.GetString(2)
            Dim totalPrice As Long = reader.GetInt64(6)
            Chart1.Series("Series1").Points.AddXY(transactionDate, totalPrice)
        End While
    End Sub

    Sub displayDgv()
        koneksi()
        da = New OdbcDataAdapter("SELECT * FROM tbl_sales", conn)
        ds = New DataSet
        ds.Clear()
        da.Fill(ds, "tbl_sales")
        dgv.DataSource = ds.Tables("tbl_sales")
    End Sub

End Class