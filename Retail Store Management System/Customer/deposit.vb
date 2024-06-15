Imports System.Data.Odbc
Public Class deposit

    Private Sub deposit_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblUser.Text = atm_management.lblUser.Text
        balance()
        Button17.Enabled = False
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

    Private Sub Button16_Click(sender As Object, e As EventArgs) Handles Button16.Click
        atm_home.Show()
        Me.Hide()
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

    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click
        If TextBox1.Text.Length > 0 Then
            TextBox1.Text = TextBox1.Text.Substring(0, TextBox1.Text.Length - 1)
        End If
    End Sub

    Sub displayDgv()
        koneksi()
        da = New OdbcDataAdapter("SELECT * FROM tbl_atmtransaction", conn)
        ds = New DataSet
        ds.Clear()
        da.Fill(ds, "tbl_cashier")
        transaction_history.dgv.DataSource = ds.Tables("tbl_cashier")
    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        TextBox1.Clear()
    End Sub

    Private Sub Button20_Click(sender As Object, e As EventArgs) Handles Button20.Click
        withdraw.Show()
        Me.Hide()
    End Sub

    Private Sub Button18_Click(sender As Object, e As EventArgs) Handles Button18.Click
        Me.Hide()
        change_pin.Show()
    End Sub

    Private Sub Button19_Click(sender As Object, e As EventArgs) Handles Button19.Click
        transaction_history.Show()
        Me.Hide()
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        Dim value As Integer
        If Not Integer.TryParse(TextBox1.Text, value) Then
            MessageBox.Show("Only Numbers Allowed For Pin")

        Else
            Dim depositAmount As Decimal
            If Not Decimal.TryParse(TextBox1.Text, depositAmount) OrElse depositAmount <= 0 Then
                MessageBox.Show("Please enter a valid deposit amount.")
                Return
            End If

            Dim username As String = lblUser.Text
            Try
                koneksi()
                Dim cmd As New OdbcCommand("SELECT balance FROM tbl_atm WHERE username = ?", conn)
                cmd.Parameters.AddWithValue("@username", username)

                Dim currentBalance As Decimal = Convert.ToDecimal(cmd.ExecuteScalar())
                Dim newBalance As Decimal = currentBalance + depositAmount


                cmd.CommandText = "UPDATE tbl_atm SET balance = ? WHERE username = ?"
                cmd.Parameters.Clear()
                cmd.Parameters.AddWithValue("@balance", newBalance)
                cmd.Parameters.AddWithValue("@username", username)

                If cmd.ExecuteNonQuery() = 1 Then
                    MessageBox.Show("Deposit successful. New balance: " & newBalance.ToString("C"))
                    koneksi()
                    cmd = New OdbcCommand("INSERT INTO tbl_atmtransaction VALUES ('" + Nothing + "','" + lblUser.Text + "', '" + lblDate.Text + "', '" + TextBox1.Text + "', '" + "Deposit" + "')", conn)
                    cmd.ExecuteNonQuery()
                    MessageBox.Show("Withdrawal Recorded Successfully")
                Else
                    MessageBox.Show("Deposit failed.")
                End If
            Catch ex As Exception
                MessageBox.Show("An error occurred: " & ex.Message)
            End Try
            balance()
            TextBox1.Clear()
            displayDgv()
        End If


    End Sub

    'Public Sub LoadUserData(username As String)
    '    lblUser.Text = username

    '    Try
    '        koneksi()
    '            Dim cmd As New OdbcCommand("SELECT balance FROM tbl_atm WHERE username = ?", conn)
    '            cmd.Parameters.AddWithValue("@username", username)
    '            Dim currentBalance As Decimal = Convert.ToDecimal(cmd.ExecuteScalar())
    '    Catch ex As Exception
    '        MessageBox.Show("An error occurred: " & ex.Message)
    '    End Try
    'End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        lblDate.Text = Date.Now.ToString("yyyy/MM/dd")
    End Sub
End Class