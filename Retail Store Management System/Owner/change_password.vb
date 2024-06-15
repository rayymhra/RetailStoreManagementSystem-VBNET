Imports System.Data.Odbc
Public Class change_password

    Private Sub change_password_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Button2.Enabled = False
        displayDgv()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If t1.Text = "" Or t2.Text = "" Then
            MessageBox.Show("Please Complete the Data")
        Else
            koneksi()
            cmd = New OdbcCommand("UPDATE tbl_owner SET username='" & t1.Text & "', password='" & t2.Text & "' WHERE tbl_owner.id = '" & lbl_id.Text & "'", conn)
            MessageBox.Show("Username and Password is Updated")
            cmd.ExecuteNonQuery()
            t1.Clear()
            t2.Clear()
            displayDgv()
        End If
    End Sub

    Sub displayDgv()
        koneksi()
        da = New OdbcDataAdapter("SELECT username, password FROM tbl_owner", conn)
        ds = New DataSet
        ds.Clear()
        da.Fill(ds, "tbl_owner")
        dgv.DataSource = ds.Tables("tbl_owner")
    End Sub

    Private Sub dgv_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv.CellClick
        Dim i As Integer
        i = dgv.CurrentRow.Index
        t1.Text = dgv.Item(0, i).Value
        t2.Text = dgv.Item(1, i).Value
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Hide()
        admin_management.Show()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Hide()
        dashboard_owner.Show()
    End Sub
End Class