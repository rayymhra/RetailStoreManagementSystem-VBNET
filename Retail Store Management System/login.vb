Imports System.Data.Odbc
Public Class login

    Private Sub Label1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub cek_CheckedChanged(sender As Object, e As EventArgs) Handles cek.CheckedChanged
        If TextBox2.UseSystemPasswordChar = True Then
            ' show password
            TextBox2.UseSystemPasswordChar = False
        Else
            ' hide password
            TextBox2.UseSystemPasswordChar = True
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'Store Owner
        'Admin
        'Cashier
        'Customer
        koneksi()
        If TextBox1.Text = "" Or TextBox2.Text = "" Or ComboBox1.Text = "" Then
            MessageBox.Show("Mohon Lengkapi Data")
        Else
            If ComboBox1.Text = "Admin" Then
                cmd = New OdbcCommand("select * from tbl_admin where username = '" & TextBox1.Text & "' and password = '" & TextBox2.Text & "'", conn)
                dr = cmd.ExecuteReader
                If dr.Read Then
                    Me.Hide()
                    dashboard_admin.Show()

                    Dim cmd2 As New OdbcCommand("INSERT INTO tbl_logactivity VALUES ('" + Nothing + "', '" + "Admin" + "', '" + TextBox1.Text + "', '" + lbl_time.Text + "', '" + "Login" + "')", conn)
                    cmd2.ExecuteNonQuery()
                    MessageBox.Show("Successfully Login as an Admin")
                Else
                    MessageBox.Show("Wrong Username/Password")
                End If


            ElseIf ComboBox1.Text = "Cashier" Then
                cmd = New OdbcCommand("select * from tbl_cashier where username = '" & TextBox1.Text & "' and password = '" & TextBox2.Text & "'", conn)
                dr = cmd.ExecuteReader
                If dr.Read Then
                    Me.Hide()
                    sale_management.Show()
                    koneksi()
                    Dim cmd2 As New OdbcCommand("INSERT INTO tbl_logactivity VALUES ('" + Nothing + "', '" + "Cashier" + "', '" + TextBox1.Text + "', '" + lbl_time.Text + "', '" + "Login" + "')", conn)
                    cmd2.ExecuteNonQuery()
                    MessageBox.Show("Successfully Login as a Cashier")
                Else
                    MessageBox.Show("Wrong Username/Password")
                End If

            ElseIf ComboBox1.Text = "Customer" Then
                cmd = New OdbcCommand("select * from tbl_customer where username = '" & TextBox1.Text & "' and password = '" & TextBox2.Text & "'", conn)
                dr = cmd.ExecuteReader
                If dr.Read Then
                    Me.Hide()
                    atm_management.Show()
                    koneksi()
                    Dim cmd2 As New OdbcCommand("INSERT INTO tbl_logactivity VALUES ('" + Nothing + "', '" + "Customer" + "', '" + TextBox1.Text + "', '" + lbl_time.Text + "', '" + "Login" + "')", conn)
                    cmd2.ExecuteNonQuery()
                    MessageBox.Show("Successfully Login as a Customer")
                Else
                    MessageBox.Show("Wrong Username/Password")
                End If

            ElseIf ComboBox1.Text = "Store Owner" Then
                cmd = New OdbcCommand("select * from tbl_owner where username = '" & TextBox1.Text & "' and password = '" & TextBox2.Text & "'", conn)
                dr = cmd.ExecuteReader
                If dr.Read Then
                    Me.Hide()
                    dashboard_owner.Show()
                Else
                    MessageBox.Show("Wrong Username/Password")
                End If
            End If
        End If

        koneksi()
        da = New OdbcDataAdapter("SELECT * FROM tbl_logactivity", conn)
        ds = New DataSet
        ds.Clear()
        da.Fill(ds, "tbl_logactivity")
        dashboard_admin.dgv.DataSource = ds.Tables("tbl_logactivity")
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        lbl_time.Text = Date.Now.ToString("yyyy-MM-dd HH:mm:ss.ffffff")
    End Sub

    Private Sub login_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Timer1.Enabled = True
    End Sub
End Class