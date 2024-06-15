Imports System.Data.Odbc
Public Class change_pin

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        Dim value As Integer
        If Not Integer.TryParse(TextBox1.Text, value) Then
            MessageBox.Show("Only Numbers Allowed For Pin")
        Else
            koneksi()
            cmd = New OdbcCommand("UPDATE tbl_atm SET pin = '" & TextBox1.Text & "' WHERE username= '" & lblUser.Text & "'", conn)
            cmd.ExecuteNonQuery()
            MessageBox.Show("Pin is Updated:" & TextBox1.Text)
            TextBox1.Clear()
        End If
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

    Private Sub change_pin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblUser.Text = atm_management.lblUser.Text
        balance()
        Button18.Enabled = False
        Timer1.Enabled = True
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        TextBox1.Text &= "1"
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        TextBox1.Text &= "2"
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        TextBox1.Text &= "3"
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        TextBox1.Text &= "4"
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        TextBox1.Text &= "5"
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        TextBox1.Text &= "6"
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        TextBox1.Text &= "7"
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        TextBox1.Text &= "8"
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        TextBox1.Text &= "9"
    End Sub

    Private Sub Button13_Click(sender As Object, e As EventArgs) Handles Button13.Click
        TextBox1.Text &= "0"
    End Sub

    Private Sub Button14_Click(sender As Object, e As EventArgs) Handles Button14.Click
        TextBox1.Text &= "00"
    End Sub

    Private Sub Button15_Click(sender As Object, e As EventArgs) Handles Button15.Click
        TextBox1.Text &= "000"
    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        TextBox1.Clear()
    End Sub

    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click
        If TextBox1.Text.Length > 0 Then
            TextBox1.Text = TextBox1.Text.Substring(0, TextBox1.Text.Length - 1)
        End If
    End Sub

    Private Sub Button20_Click(sender As Object, e As EventArgs) Handles Button20.Click
        Me.Hide()
        withdraw.Show()
    End Sub

    Private Sub Button16_Click(sender As Object, e As EventArgs) Handles Button16.Click
        Me.Hide()
        atm_home.Show()
    End Sub

    Private Sub Button18_Click(sender As Object, e As EventArgs) Handles Button18.Click
    End Sub

    Private Sub Button19_Click(sender As Object, e As EventArgs) Handles Button19.Click
        transaction_history.Show()
        Me.Hide()
    End Sub

    Private Sub Button17_Click(sender As Object, e As EventArgs) Handles Button17.Click
        deposit.Show()
        Me.Hide()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        lblDate.Text = Date.Now.ToString("yyyy/MM/dd")
    End Sub
End Class