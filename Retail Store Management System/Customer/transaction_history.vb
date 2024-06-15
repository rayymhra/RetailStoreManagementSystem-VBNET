Imports System.Data.Odbc
Imports System.Drawing.Printing
Public Class transaction_history

    Private Sub transaction_history_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblUser.Text = atm_management.lblUser.Text
        balance()
        displayDgv()
        Button19.Enabled = False
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

    Sub displayDgv()
        koneksi()
        da = New OdbcDataAdapter("SELECT * FROM tbl_atmtransaction", conn)
        ds = New DataSet
        ds.Clear()
        da.Fill(ds, "tbl_cashier")
        dgv.DataSource = ds.Tables("tbl_cashier")
    End Sub

    Private Sub Button16_Click(sender As Object, e As EventArgs) Handles Button16.Click
        Me.Hide()
        atm_home.Show()
    End Sub

    Private Sub Button20_Click(sender As Object, e As EventArgs) Handles Button20.Click
        withdraw.Show()
        Me.Hide()
    End Sub

    Private Sub Button18_Click(sender As Object, e As EventArgs) Handles Button18.Click
        change_pin.Show()
        Me.Hide()
    End Sub

    Private Sub Button17_Click(sender As Object, e As EventArgs) Handles Button17.Click
        deposit.Show()
        Me.Hide()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        lblDate.Text = Date.Now.ToString("yyyy/MM/dd")
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        PrintDocument1.DefaultPageSettings.PaperSize = New PaperSize("MySize", 250, 600)
        PrintPreviewDialog1.WindowState = FormWindowState.Maximized
        PrintPreviewDialog1.PrintPreviewControl.Zoom = 2.5
        PrintPreviewDialog1.Document = PrintDocument1
        PrintPreviewDialog1.ShowDialog()
    End Sub

    Private Sub PrintDocument1_PrintPage(sender As Object, e As PrintPageEventArgs) Handles PrintDocument1.PrintPage
        'set fonts
        Dim f8 As New Font("Arial", 8, FontStyle.Regular)
        Dim f8b As New Font("Verbana", 7, FontStyle.Regular)

        'set alignment
        Dim left As New StringFormat
        Dim center As New StringFormat
        Dim right As New StringFormat

        left.Alignment = StringAlignment.Near
        center.Alignment = StringAlignment.Center
        right.Alignment = StringAlignment.Far

        'rectangles
        'header
        Dim rect1 As New Rectangle(5, 5, 240, 17)
        Dim rect2 As New Rectangle(5, 22, 240, 17)
        Dim rect3 As New Rectangle(5, 39, 240, 17)

        e.Graphics.DrawRectangle(Pens.Black, rect1)
        e.Graphics.DrawRectangle(Pens.Black, rect2)
        e.Graphics.DrawRectangle(Pens.Black, rect3)

        e.Graphics.DrawString("Retail Store ATM", f8, Brushes.Black, rect1, center)
        e.Graphics.DrawString("Transaction History", f8, Brushes.Black, rect2, center)
        e.Graphics.DrawString(lblUser.Text, f8, Brushes.Black, rect3, center)

        'header dari isi
        Dim rect4 As New Rectangle(5, 73, 60, 17)
        Dim rect5 As New Rectangle(65, 73, 60, 17)
        Dim rect6 As New Rectangle(125, 73, 60, 17)
        Dim rect7 As New Rectangle(185, 73, 60, 17)

        e.Graphics.DrawRectangle(Pens.Black, rect4)
        e.Graphics.DrawRectangle(Pens.Black, rect5)
        e.Graphics.DrawRectangle(Pens.Black, rect6)
        e.Graphics.DrawRectangle(Pens.Black, rect7)

        e.Graphics.DrawString("Username", f8, Brushes.Black, rect4, center)
        e.Graphics.DrawString("Date", f8, Brushes.Black, rect5, center)
        e.Graphics.DrawString("Amount", f8, Brushes.Black, rect6, center)
        e.Graphics.DrawString("Type", f8, Brushes.Black, rect7, center)

        'isinya
        'Dim rect8 As New Rectangle(5, 90, 60, 17)
        'Dim rect9 As New Rectangle(65, 90, 60, 17)
        'Dim rect10 As New Rectangle(125, 90, 60, 17)
        'Dim rect11 As New Rectangle(185, 90, 60, 17)

        'e.Graphics.DrawRectangle(Pens.Black, rect8)
        'e.Graphics.DrawRectangle(Pens.Black, rect9)
        'e.Graphics.DrawRectangle(Pens.Black, rect10)
        'e.Graphics.DrawRectangle(Pens.Black, rect11)

        'e.Graphics.DrawString(dgv.Rows(0).Cells(0).Value, f8b, Brushes.Black, rect8, center)
        'e.Graphics.DrawString(dgv.Rows(0).Cells(1).Value, f8b, Brushes.Black, rect9, center)
        'e.Graphics.DrawString(dgv.Rows(0).Cells(2).Value, f8b, Brushes.Black, rect10, center)
        'e.Graphics.DrawString(dgv.Rows(0).Cells(3).Value, f8b, Brushes.Black, rect11, center)


        'loop buat lanjutin sebanyak datanya
        Dim y As Integer = 90
        For i = 0 To dgv.Rows.Count - 1
            Dim rect8 As New Rectangle(5, y, 60, 17)
            Dim rect9 As New Rectangle(65, y, 60, 17)
            Dim rect10 As New Rectangle(125, y, 60, 17)
            Dim rect11 As New Rectangle(185, y, 60, 17)

            e.Graphics.DrawRectangle(Pens.Black, rect8)
            e.Graphics.DrawRectangle(Pens.Black, rect9)
            e.Graphics.DrawRectangle(Pens.Black, rect10)
            e.Graphics.DrawRectangle(Pens.Black, rect11)

            e.Graphics.DrawString(dgv.Rows(i).Cells(1).Value, f8b, Brushes.Black, rect8, center)
            e.Graphics.DrawString(dgv.Rows(i).Cells(2).Value, f8b, Brushes.Black, rect9, center)
            e.Graphics.DrawString(dgv.Rows(i).Cells(3).Value, f8b, Brushes.Black, rect10, center)
            e.Graphics.DrawString(dgv.Rows(i).Cells(4).Value, f8b, Brushes.Black, rect11, center)

            y += 17
        Next
    End Sub
End Class