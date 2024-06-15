Imports System.Data.Odbc
Public Class sale_management

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Me.Hide()
        login.Show()
    End Sub

    Private Sub sale_management_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        t1.Text = login.TextBox1.Text
        Timer1.Enabled = True
        t1.Enabled = False
        customer()
        notActive()
        displayDgv()
        product()
        'custId()
        stock()


        'If t6.Text = "ATM" Then
        '    balance()

        'Else
        '    t8.Text = ""
        'End If
    End Sub

    'Sub custId()
    '    koneksi()
    '    cmd = New OdbcCommand("SELECT * FROM tbl_customer WHERE customerId = '" & t3.Text & "'", conn)
    '    dr = cmd.ExecuteReader()
    '    dr.Read()
    '    If dr.HasRows Then
    '        lblCust.Text = dr.GetString(3)
    '    End If
    'End Sub

    'Sub balance()
    '    koneksi()
    '    cmd = New OdbcCommand("SELECT * FROM tbl_atm WHERE username = '" & lblCust.Text & "'", conn)
    '    dr = cmd.ExecuteReader()
    '    dr.Read()
    '    If dr.HasRows Then
    '        t9.Text = dr.GetString(3)
    '    End If
    'End Sub

    Sub customer()
        koneksi()
        Dim cmd As New OdbcCommand("select * from tbl_customer", conn)
        Dim adapter As New OdbcDataAdapter(cmd)
        Dim tbl As New DataTable()
        adapter.Fill(tbl)
        t3.DataSource = tbl
        t3.DisplayMember = "customerId"
        t3.ValueMember = "customerId"
    End Sub

    Sub product()
        koneksi()
        Dim cmd As New OdbcCommand("select * from tbl_products", conn)
        Dim adapter As New OdbcDataAdapter(cmd)
        Dim tbl As New DataTable()
        adapter.Fill(tbl)
        t4.DataSource = tbl
        t4.DisplayMember = "productName"
        t4.ValueMember = "productName"
    End Sub

    Sub price()
        koneksi()
        cmd = New OdbcCommand("SELECT * FROM tbl_products WHERE productName = '" & t4.Text & "'", conn)
        dr = cmd.ExecuteReader()
        dr.Read()
        If dr.HasRows Then
            lblPrice.Text = dr.GetString(3)
        End If
    End Sub

    Sub stock()
        koneksi()
        cmd = New OdbcCommand("SELECT * FROM tbl_products WHERE productName = '" & t4.Text & "'", conn)
        dr = cmd.ExecuteReader()
        dr.Read()
        If dr.HasRows Then
            lblStock.Text = dr.GetString(4)
        End If
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        lbl_time.Text = Date.Now.ToString("yyyy/MM/dd")
    End Sub

    Sub displayDgv()
        koneksi()
        da = New OdbcDataAdapter("SELECT * FROM tbl_sales", conn)
        ds = New DataSet
        ds.Clear()
        da.Fill(ds, "tbl_sales")
        dgv.DataSource = ds.Tables("tbl_sales")
    End Sub

    Sub active()
        t2.Enabled = True
        t3.Enabled = True
        t4.Enabled = True
        t5.Enabled = True
        t6.Enabled = True
        't7.Enabled = True
        t8.Enabled = True

        save.Enabled = True
        
    End Sub

    Sub notActive()
        t1.Enabled = False
        t2.Enabled = False
        t3.Enabled = False
        t4.Enabled = False
        t5.Enabled = False
        t6.Enabled = False
        't7.Enabled = False
        t8.Enabled = False
        't9.Enabled = False

        save.Enabled = False
       
    End Sub

    Sub quantity()
        koneksi()
        cmd = New OdbcCommand("SELECT * FROM tbl_products WHERE productName = '" & t4.Text & "'", conn)
        dr = cmd.ExecuteReader()
        dr.Read()
        If dr.HasRows Then
            lblStock.Text = dr.GetString(4)
        End If
    End Sub

    Private Sub t4_SelectedIndexChanged(sender As Object, e As EventArgs) Handles t4.SelectedIndexChanged
        price()
    End Sub

    Private Sub t6_SelectedIndexChanged(sender As Object, e As EventArgs) Handles t6.SelectedIndexChanged
        'If t6.Text = "ATM" Then
        '    balance()

        'Else
        '    t9.Text = "-"
        'End If
    End Sub



    Private Sub save_Click(sender As Object, e As EventArgs) Handles save.Click
        If t1.Text = "" Or t2.Text = "" Or t3.Text = "" Or t4.Text = "" Or t5.Text = "" Or t6.Text = "" Or t8.Text = "" Then
            MessageBox.Show("Please Complete The Data")

        Else
            koneksi()
            cmd = New OdbcCommand("INSERT INTO tbl_sales VALUES ('" + Nothing + "', '" + t1.Text + "', '" + t2.Text + "', '" + t3.Text + "','" + t4.Text + "', '" + t6.Text + "', '" + t8.Text + "')", conn)
            cmd.ExecuteNonQuery()
            MessageBox.Show("Data is Saved Successfully")
            displayDgv()
            notActive()
            clearText()
        End If
    End Sub

    Private Sub dgv_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv.CellClick

    End Sub

    Private Sub add_Click(sender As Object, e As EventArgs) Handles add.Click
        active()

    End Sub

    Private Sub cancel_Click(sender As Object, e As EventArgs) Handles cancel.Click
        notActive()

    End Sub

    Sub clearText()
        t1.Clear()
        t3.Text = ""
        t4.Text = "'"
        't5.Clear()
        t6.Text = ""
        't7.Clear()
        lbl_id.Text = "-"
    End Sub

    Sub transaksi()
        Dim stok As Integer
        stok = lblStock.Text

        If t5.Text > stok Then
            MessageBox.Show("Not Enough Stock")
            t5.Value = 0

        Else
            Dim total As Integer
            Dim harga As Integer

            harga = lblPrice.Text
            total = harga * t5.Text
            t8.Text = total

        End If



    End Sub

    Private Sub t3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles t3.SelectedIndexChanged
        'custId()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub t5_TextChanged(sender As Object, e As EventArgs)
        transaksi()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        PrintPreviewDialog1.Document = PrintDocument1
        PrintPreviewDialog1.PrintPreviewControl.Zoom = 1
        PrintPreviewDialog1.ShowDialog()
    End Sub

    Private Sub PrintDocument1_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        Dim imagebitmap As New Bitmap(Me.dgv.Width, Me.dgv.Height)
        dgv.DrawToBitmap(imagebitmap, New Rectangle(0, 0, Me.dgv.Width, Me.dgv.Height))
        e.Graphics.DrawImage(imagebitmap, 120, 20)
    End Sub
End Class