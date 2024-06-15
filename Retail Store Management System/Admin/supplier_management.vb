Imports System.Data.Odbc
Public Class supplier_management

    Private Sub supplier_management_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Button1.Enabled = False
        displayDgv()
        notActive()
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

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Me.Hide()
        cashier_management.Show()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Me.Hide()
        reports.Show()
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Me.Hide()
        dashboard_admin.Show()
    End Sub

    Sub displayDgv()
        koneksi()
        da = New OdbcDataAdapter("SELECT * FROM tbl_supplier", conn)
        ds = New DataSet
        ds.Clear()
        da.Fill(ds, "tbl_supplier")
        dgv.DataSource = ds.Tables("tbl_supplier")
    End Sub

    Sub active()
        t1.Enabled = True
        t2.Enabled = True
        t3.Enabled = True

        save.Enabled = True
        edit.Enabled = True
        delete.Enabled = True
    End Sub

    Sub notActive()
        t1.Enabled = False
        t2.Enabled = False
        t3.Enabled = False

        save.Enabled = False
        edit.Enabled = False
        delete.Enabled = False
    End Sub

    Sub clearText()
        t1.Clear()
        t2.Clear()
        t3.Clear()

        lbl_id.Text = "-"
    End Sub

    Private Sub add_Click(sender As Object, e As EventArgs) Handles add.Click
        active()
    End Sub

    Private Sub dgv_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv.CellClick
        Dim i As Integer
        i = dgv.CurrentRow.Index
        lbl_id.Text = dgv.Item(0, i).Value
        t1.Text = dgv.Item(1, i).Value
        t2.Text = dgv.Item(2, i).Value
        t3.Text = dgv.Item(3, i).Value
        active()
        save.Enabled = False
    End Sub

    Private Sub save_Click(sender As Object, e As EventArgs) Handles save.Click
        If t1.Text = "" Or t2.Text = "" Or t3.Text = "" Then
            MessageBox.Show("Please Complete The Data")

        Else
            koneksi()
            cmd = New OdbcCommand("INSERT INTO tbl_supplier VALUES ('" + Nothing + "', '" + t1.Text + "', '" + t2.Text + "', '" + t3.Text + "')", conn)
            cmd.ExecuteNonQuery()
            MessageBox.Show("Data is Saved Successfully")
            displayDgv()
            notActive()
            clearText()
        End If
    End Sub

    Private Sub edit_Click(sender As Object, e As EventArgs) Handles edit.Click
        If t1.Text = "" Or t2.Text = "" Or t3.Text = "" Or lbl_id.Text = "-" Then
            MessageBox.Show("Please Choose The Data")

        Else
            koneksi()
            cmd = New OdbcCommand("UPDATE tbl_supplier SET name = '" & t1.Text & "', telp = '" & t2.Text & "', email = '" & t3.Text & "' WHERE supplierId = '" & lbl_id.Text & "'", conn)
            cmd.ExecuteNonQuery()
            MessageBox.Show("Data is Saved Successfully")
            displayDgv()
            notActive()
            clearText()
        End If
    End Sub

    Private Sub delete_Click(sender As Object, e As EventArgs) Handles delete.Click
        If t1.Text = "" Or t2.Text = "" Or t3.Text = "" Or lbl_id.Text = "-" Then
            MessageBox.Show("Please Choose The Data")
        Else
            Dim result As DialogResult = MessageBox.Show("Are you sure to delete the data?", "Caution", MessageBoxButtons.YesNoCancel)
            If result = DialogResult.Cancel Then
                MessageBox.Show("Canceled")
            ElseIf result = DialogResult.No Then
                MessageBox.Show("Canceled")
            ElseIf result = DialogResult.Yes Then
                koneksi()
                cmd = New OdbcCommand("DELETE FROM tbl_supplier WHERE supplierId = '" & lbl_id.Text & "'", conn)
                cmd.ExecuteNonQuery()
                MessageBox.Show("Data is Deleted Successfully")
                notActive()
                clearText()
                displayDgv()
            End If
        End If
    End Sub

    Private Sub cancel_Click(sender As Object, e As EventArgs) Handles cancel.Click
        clearText()
        notActive()
    End Sub
End Class