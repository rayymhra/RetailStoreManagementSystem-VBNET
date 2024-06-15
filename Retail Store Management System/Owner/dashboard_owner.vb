Imports System.Data.Odbc
Imports System.IO
Public Class dashboard_owner
    Dim table As New DataTable()
    Dim rowIndex As Integer

    Sub displayImage()
        Dim imgByte As Byte()
        imgByte = table(rowIndex)(0)
        Dim ms As New MemoryStream(imgByte)
        PictureBox1.Image = Image.FromStream(ms)
    End Sub
    Private Sub dashboard_owner_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        totalAdmin()
        totalCustomer()

        Dim command As New OdbcCommand("SELECT poster FROM tbl_events", conn)
        Dim adapter As New OdbcDataAdapter(command)
        adapter.Fill(table)
        rowIndex = 0
        displayImage()
    End Sub

    Sub totalAdmin()
        koneksi()
        cmd = New OdbcCommand("SELECT COUNT(*) FROM tbl_admin", conn)
        Dim total As String
        total = cmd.ExecuteScalar()
        lblAdm.Text = total
    End Sub

    Sub totalCustomer()
        koneksi()
        cmd = New OdbcCommand("SELECT COUNT(*) FROM tbl_customer", conn)
        Dim total As String
        total = cmd.ExecuteScalar()
        lblCustomer.Text = total
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Hide()
        admin_management.Show()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Hide()
        change_password.Show()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Hide()
        login.Show()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If rowIndex <= table.Rows.Count - 2 Then
            rowIndex = rowIndex + 1
            displayImage()
        End If
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        If rowIndex >= 1 Then
            rowIndex = rowIndex - 1
            displayImage()
        End If
    End Sub
End Class