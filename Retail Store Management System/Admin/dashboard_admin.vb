Imports System.Data.Odbc
Public Class dashboard_admin

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub dashboard_admin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        comboDate()
        displayDgv()
    End Sub

    Sub displayDgv()
        koneksi()
        da = New OdbcDataAdapter("SELECT * FROM tbl_logactivity", conn)
        ds = New DataSet
        ds.Clear()
        da.Fill(ds, "tbl_logactivity")
        dgv.DataSource = ds.Tables("tbl_logactivity")
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        If ComboBox1.Text = "" Then
            displayDgv()
        Else
            displayRow()
        End If
    End Sub

    Sub displayRow()
        Dim selectedDate As Date = DateTime.Parse(ComboBox1.Text)
        Dim startDate As Date = selectedDate.Date
        Dim endDate As Date = startDate.AddDays(1).AddSeconds(-1)

        Dim query As String = "SELECT * FROM tbl_logactivity WHERE time >= ? AND time <= ?"
        Dim cmd As New OdbcCommand(query, conn)
        cmd.Parameters.AddWithValue("@startDate", startDate)
        cmd.Parameters.AddWithValue("@endDate", endDate)

        Dim da As New OdbcDataAdapter(cmd)
        Dim ds As New DataSet
        Dim dataTable As New DataTable()
        da.Fill(ds)
        dgv.DataSource = ds.Tables(0)
    End Sub

    Sub comboDate()
        Dim cmd As New OdbcCommand("SELECT DISTINCT DATE(time) AS date FROM tbl_logactivity", conn)
        Dim dr As OdbcDataReader = cmd.ExecuteReader
        ComboBox1.Items.Clear()
        While dr.Read
            ComboBox1.Items.Add(dr("date"))
        End While
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        supplier_management.Show()
        Me.Hide()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        product_management.Show()
        Me.Hide()

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        customer_management.Show()
        Me.Hide()

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        event_management.Show()
        Me.Hide()

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        cashier_management.Show()
        Me.Hide()

    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        reports.Show()
        Me.Hide()

    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        login.Show()
        Me.Hide()
    End Sub
End Class