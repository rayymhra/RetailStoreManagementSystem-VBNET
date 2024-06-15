Imports System.Data.Odbc
Public Class atm_home

    Private Sub Button16_Click(sender As Object, e As EventArgs) Handles Button16.Click
        atm_management.Show()
        Me.Hide()
    End Sub

    Private Sub Button20_Click(sender As Object, e As EventArgs) Handles Button20.Click
        withdraw.Show()
        Me.Hide()
    End Sub

    Private Sub Button18_Click(sender As Object, e As EventArgs) Handles Button18.Click
        change_pin.Show()
        Me.Hide()
    End Sub

    Private Sub Button19_Click(sender As Object, e As EventArgs) Handles Button19.Click
        transaction_history.Show()
        Me.Hide()
    End Sub

    Private Sub Button17_Click(sender As Object, e As EventArgs) Handles Button17.Click
        deposit.Show()
        Me.Hide()
    End Sub

    Private Sub atm_home_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblUser.Text = atm_management.lblUser.Text
        balance()
        Timer1.Enabled = True
    End Sub

    Sub balance()
        koneksi()
        cmd = New OdbcCommand("SELECT * FROM tbl_atm WHERE username = '" & lblUser.Text & "'", conn)
        dr = cmd.ExecuteReader()
        dr.Read()
        If dr.HasRows Then
            lblBalance.Text = dr.GetString(3)
        End If
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        lblDate.Text = Date.Now.ToString("yyyy/MM/dd")
    End Sub
End Class