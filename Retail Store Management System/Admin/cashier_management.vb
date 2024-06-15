Imports System.Data.Odbc
Public Class cashier_management

    Private Sub cashier_management_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Button5.Enabled = False
        displayDgv()
        notActive()
    End Sub

    Sub displayDgv()
        koneksi()
        da = New OdbcDataAdapter("SELECT * FROM tbl_cashier", conn)
        ds = New DataSet
        ds.Clear()
        da.Fill(ds, "tbl_cashier")
        dgv.DataSource = ds.Tables("tbl_cashier")
    End Sub

    Sub active()
        t1.Enabled = True
        t2.Enabled = True
        t3.Enabled = True
        t4.Enabled = True
        t5.Enabled = True
        t6.Enabled = True
        t7.Enabled = True

        save.Enabled = True
        edit.Enabled = True
        delete.Enabled = True
    End Sub

    Sub notActive()
        t1.Enabled = False
        t2.Enabled = False
        t3.Enabled = False
        t4.Enabled = False
        t5.Enabled = False
        t6.Enabled = False
        t7.Enabled = False

        save.Enabled = False
        edit.Enabled = False
        delete.Enabled = False
    End Sub

    Sub clearText()
        t1.Clear()
        t3.Text = ""
        t4.Clear()
        t5.Clear()
        t6.Text = ""
        t7.Clear()
        lbl_id.Text = "-"
    End Sub

    Private Sub save_Click(sender As Object, e As EventArgs) Handles save.Click
        If t1.Text = "" Or t2.Text = "" Or t3.Text = "" Or t4.Text = "" Or t5.Text = "" Or t6.Text = "" Or t7.Text = "" Then
            MessageBox.Show("Please Complete The Data")

        Else
            koneksi()
            cmd = New OdbcCommand("INSERT INTO tbl_cashier VALUES ('" + Nothing + "', '" + t1.Text + "', '" + t2.Text + "', '" + t3.Text + "', '" + t4.Text + "', '" + t5.Text + "', '" + t6.Text + "', '" + t7.Text + "')", conn)
            cmd.ExecuteNonQuery()
            MessageBox.Show("Data is Saved Successfully")
            displayDgv()
            notActive()
            clearText()
        End If
    End Sub

    Private Sub delete_Click(sender As Object, e As EventArgs) Handles delete.Click
        If t1.Text = "" Or t2.Text = "" Or t3.Text = "" Or t4.Text = "" Or t5.Text = "" Or t6.Text = "" Or t7.Text = "" Then
            MessageBox.Show("Please Choose The Data")
        Else
            Dim result As DialogResult = MessageBox.Show("Are you sure to delete the data?", "Caution", MessageBoxButtons.YesNoCancel)
            If result = DialogResult.Cancel Then
                MessageBox.Show("Canceled")
            ElseIf result = DialogResult.No Then
                MessageBox.Show("Canceled")
            ElseIf result = DialogResult.Yes Then
                koneksi()
                cmd = New OdbcCommand("DELETE FROM tbl_cashier WHERE cashierId = '" & lbl_id.Text & "'", conn)
                cmd.ExecuteNonQuery()
                MessageBox.Show("Data is Deleted Successfully")
                notActive()
                clearText()
                displayDgv()
            End If
        End If
    End Sub

    Private Sub edit_Click(sender As Object, e As EventArgs) Handles edit.Click
        If t1.Text = "" Or t2.Text = "" Or t3.Text = "" Or t4.Text = "" Or t5.Text = "" Or t6.Text = "" Or t7.Text = "" Or lbl_id.Text = "-" Then
            MessageBox.Show("Please Choose The Data")
        Else
            koneksi()
            cmd = New OdbcCommand("UPDATE tbl_cashier SET fullName = '" & t1.Text & "', dateOfBirth = '" & t2.Text & "', gender = '" & t3.Text & "', address = '" & t4.Text & "', telp = '" & t5.Text & "', username = '" & t6.Text & "', password = '" & t7.Text & "' WHERE cashierId = '" & lbl_id.Text & "';", conn)
            cmd.ExecuteNonQuery()
            MessageBox.Show("Data is Updated Successfully")
            displayDgv()
            clearText()
            notActive()
        End If
    End Sub

    Private Sub dgv_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv.CellClick
        Dim i As Integer
        i = dgv.CurrentRow.Index
        lbl_id.Text = dgv.Item(0, i).Value
        t1.Text = dgv.Item(1, i).Value
        t2.Text = dgv.Item(2, i).Value
        t3.Text = dgv.Item(3, i).Value
        t4.Text = dgv.Item(4, i).Value
        t5.Text = dgv.Item(5, i).Value
        t6.Text = dgv.Item(6, i).Value
        t7.Text = dgv.Item(7, i).Value
        active()
        save.Enabled = False
    End Sub

    Private Sub add_Click(sender As Object, e As EventArgs) Handles add.Click
        active()
    End Sub

    Private Sub cancel_Click(sender As Object, e As EventArgs) Handles cancel.Click
        notActive()
        clearText()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Hide()
        supplier_management.Show()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Me.Hide()
        product_management.Show()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Hide()
        customer_management.Show()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Hide()
        event_management.Show()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Me.Hide()
        reports.Show()
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Me.Hide()
        dashboard_admin.Show()
    End Sub
End Class