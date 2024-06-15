Imports System.Data.Odbc
Public Class create_account

    Private Sub create_account_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        t1.Enabled = False
        t1.Text = login.TextBox1.Text
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim value As Integer
        If Not Integer.TryParse(t3.Text, value) Then
            MessageBox.Show("Only Numbers Allowed For Pin")

        ElseIf t1.Text = "" Or t2.Text = "" Or t3.Text = "" Then
            MessageBox.Show("Please Complete the Fields")

        Else
            'koneksi()
            'cmd = New OdbcCommand("INSERT INTO tbl_atm VALUES ('" + t1.Text + "', '" + t2.Text + "', '" + t3.Text + "', '" + "0" + "')", conn)
            'cmd.ExecuteNonQuery()
            'MessageBox.Show("Account is Created Successfully")
            'MessageBox.Show("Please Remember Your Pin:" & t3.Text)
            't2.Text = ""
            't3.Clear()
            'Me.Hide()
            'atm_management.Show()

            Dim username As String = t1.Text
            Dim bankName As String = t2.Text
            Dim pin As String = t3.Text

            If String.IsNullOrEmpty(username) OrElse String.IsNullOrEmpty(bankName) OrElse String.IsNullOrEmpty(pin) Then
                MessageBox.Show("Please fill in all the fields.")
                Return
            End If

            Try
                koneksi()
                ' Check if the username already exists in tbl_atm untuk menghindari error
                Dim checkQuery As String = "SELECT COUNT(*) FROM tbl_atm WHERE username = ?"
                cmd = New OdbcCommand(checkQuery, conn)
                cmd.Parameters.AddWithValue("@username", username)

                Dim count As Integer = Convert.ToInt32(cmd.ExecuteScalar())
                If count > 0 Then
                    MessageBox.Show("You already have an account.")
                Else
                    Dim insertQuery As String = "INSERT INTO tbl_atm (username, bankName, pin, balance) VALUES (?, ?, ?, 0)"
                    cmd = New OdbcCommand(insertQuery, conn)
                    cmd.Parameters.AddWithValue("@username", username)
                    cmd.Parameters.AddWithValue("@bankName", bankName)
                    cmd.Parameters.AddWithValue("@pin", pin)

                    If cmd.ExecuteNonQuery() > 0 Then
                        MessageBox.Show("Account registered successfully!")
                        Me.Hide()
                        atm_management.Show()
                        t1.Clear()
                        t2.Text = ""
                        t3.Clear()
                    Else
                        MessageBox.Show("Account registration failed.")
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show("An error occurred: " & ex.Message)
            End Try
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        atm_management.Show()
    End Sub
End Class