Imports System.Data.Odbc
Module Module1
    Public sql As String
    Public dr As OdbcDataReader
    Public da As OdbcDataAdapter
    Public ds As DataSet
    Public conn As OdbcConnection
    Public dt As DataTable
    Public cmd As OdbcCommand

    Sub koneksi()
        sql = "Driver={MYSQL ODBC 5.1 Driver};server=localhost;uid=root;database=sch_retailstore;port=3306;"
        conn = New OdbcConnection(sql)
        If conn.State = ConnectionState.Closed Then
            conn.Open()
        End If
    End Sub
End Module
