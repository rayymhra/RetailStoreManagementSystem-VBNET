Imports System.Data.Odbc
Imports System.IO
Public Class event_management

    Private Sub event_management_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Button3.Enabled = False
        notActive()
        clearText()
        displayDgv()
    End Sub

    Sub active()
        t1.Enabled = True
        t2.Enabled = True
        t3.Enabled = True

        save.Enabled = True
        edit.Enabled = True
        delete.Enabled = True
        choose_image.Enabled = True
    End Sub

    Sub notActive()
        t1.Enabled = False
        t2.Enabled = False
        t3.Enabled = False

        save.Enabled = False
        edit.Enabled = False
        delete.Enabled = False
        choose_image.Enabled = False
    End Sub

    Sub clearText()
        t1.Text = ""
        t4.Image = Nothing
    End Sub

    Private Sub save_Click(sender As Object, e As EventArgs) Handles save.Click
        koneksi()
        If t1.Text = "" Or t4.Image Is Nothing Then
            MessageBox.Show("Please Complete The Data")

        Else
            'If t4.Image IsNot Nothing Then
            '    Dim ms As New MemoryStream
            '    t4.Image.Save(ms, t4.Image.RawFormat)

            '    Dim imageData As Byte() = ms.ToArray()
            '    cmd = New OdbcCommand("INSERT INTO tbl_events (details, startDate, endDate, poster) VALUES (?, ?, ?, ?)", conn)
            '    cmd.Parameters.AddWithValue("@details", t1.Text)
            '    cmd.Parameters.AddWithValue("@startDate", t2.Text)
            '    cmd.Parameters.AddWithValue("@endDate", t3.Text)
            '    cmd.Parameters.AddWithValue("@poster", imageData)

            '    If cmd.ExecuteNonQuery() = 1 Then
            '        MessageBox.Show("Image Inserted")
            '        displayDgv()
            '        clearText()
            '        notActive()
            '    Else
            '        MessageBox.Show("Data is Inserted Successfully")
            '    End If
            'Else
            '    MessageBox.Show("Please Insert Image/Poster of The Event")
            'End If

            koneksi()

            Dim ms As New MemoryStream()
            t4.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Png)
            Dim imageData As Byte() = ms.ToArray()

            Dim sql As String = "INSERT INTO tbl_events (details, startDate, endDate, poster) VALUES (?, ?, ?, ?)"
            cmd = New OdbcCommand(sql, conn)
            cmd.Parameters.AddWithValue("@details", t1.Text)
            cmd.Parameters.AddWithValue("@startDate", t2.Text)
            cmd.Parameters.AddWithValue("@endDate", t3.Text)
            cmd.Parameters.AddWithValue("@poster", imageData)

            Try
                If cmd.ExecuteNonQuery() = 1 Then
                    MessageBox.Show("Data Inserted Successfully")
                    displayDgv()
                    clearText()
                    notActive()
                Else
                    MessageBox.Show("Data Not Inserted")
                End If
            Catch ex As Exception
                MessageBox.Show("Error: " & ex.Message)
            End Try
        End If
    End Sub

    Sub displayDgv()
        koneksi()
        da = New OdbcDataAdapter("SELECT * FROM tbl_events", conn)
        ds = New DataSet
        ds.Clear()
        da.Fill(ds, "tbl_events")
        dgv.DataSource = ds.Tables("tbl_events")
    End Sub

    Private Sub choose_image_Click(sender As Object, e As EventArgs) Handles choose_image.Click
        Dim opf As New OpenFileDialog
        opf.Filter = "Choose Image(*.JPG;*.PNG;*.GIF)|*.jpg;*.png;*.gif"
        If opf.ShowDialog = Windows.Forms.DialogResult.OK Then

            t4.Image = Image.FromFile(opf.FileName)
        End If
    End Sub

    Private Sub edit_Click(sender As Object, e As EventArgs) Handles edit.Click
        'koneksi()
        'If t4.Image IsNot Nothing Then
        '    Dim ms As New MemoryStream
        '    t4.Image.Save(ms, t4.Image.RawFormat)

        '    Dim imageData As Byte() = ms.ToArray()
        '    cmd = New OdbcCommand("UPDATE tbl_events SET details = ?, startDate = ?, endDate = ?, poster = ? WHERE eventId = ?", conn)
        '    cmd.Parameters.AddWithValue("@details", t1.Text)
        '    cmd.Parameters.AddWithValue("@startDate", t2.Text)
        '    cmd.Parameters.AddWithValue("@endDate", t3.Text)
        '    cmd.Parameters.AddWithValue("@poster", imageData)
        '    cmd.Parameters.AddWithValue("@idEvent", lbl_id.Text)

        '    If cmd.ExecuteNonQuery() = 1 Then
        '        MessageBox.Show("Data is Updated Successfully")
        '        displayDgv()
        '        notActive()
        '        clearText()
        '    Else
        '        MessageBox.Show("Failed to update data")
        '    End If
        'Else
        '    MessageBox.Show("Please insert image/poster of the event")
        'End If




        'koneksi()
        'If t4.Image IsNot Nothing Then
        '    Dim ms As New MemoryStream()
        '    t4.Image.Save(ms, t4.Image.RawFormat)
        '    Dim imageData As Byte() = ms.ToArray()

        '    ' Correct the SQL command to match the number of placeholders with parameters
        '    cmd = New OdbcCommand("UPDATE tbl_events SET details = ?, startDate = ?, endDate = ?, poster = ? WHERE eventId = ?", conn)
        '    cmd.Parameters.AddWithValue("@details", t1.Text)
        '    cmd.Parameters.AddWithValue("@startDate", t2.Text)
        '    cmd.Parameters.AddWithValue("@endDate", t3.Text)
        '    cmd.Parameters.AddWithValue("@poster", imageData)
        '    cmd.Parameters.AddWithValue("@eventId", lbl_id.Text)

        '    If cmd.ExecuteNonQuery() = 1 Then
        '        MessageBox.Show("Data is Updated Successfully")
        '        displayDgv()
        '        notActive()
        '        clearText()
        '    Else
        '        MessageBox.Show("Failed to update data")
        '    End If
        'Else
        '    MessageBox.Show("Please insert image/poster of the event")
        'End If

        If t1.Text = "" Or t4.Image Is Nothing Or lbl_id.Text = "-" Then
            MessageBox.Show("Please Complete The Data")
        Else
            koneksi()

            Dim ms As New MemoryStream()
            t4.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Png)
            Dim imageData As Byte() = ms.ToArray()

            Dim sql As String = "UPDATE tbl_events SET details = ?, startDate = ?, endDate = ?, poster = ? WHERE eventId = ?"
            cmd = New OdbcCommand(sql, conn)
            cmd.Parameters.AddWithValue("@details", t1.Text)
            cmd.Parameters.AddWithValue("@startDate", t2.Text)
            cmd.Parameters.AddWithValue("@endDate", t3.Text)
            cmd.Parameters.AddWithValue("@poster", imageData)
            cmd.Parameters.AddWithValue("@eventId", lbl_id.Text)

            Try
                If cmd.ExecuteNonQuery() = 1 Then
                    MessageBox.Show("Data Updated Successfully")
                    displayDgv()
                    clearText()
                    notActive()
                Else
                    MessageBox.Show("Failed to Update Data")
                End If
            Catch ex As Exception
                MessageBox.Show("Error: " & ex.Message)
            End Try
        End If


    End Sub

    Private Sub add_Click(sender As Object, e As EventArgs) Handles add.Click
        active()
    End Sub

    Private Sub cancel_Click(sender As Object, e As EventArgs) Handles cancel.Click
        notActive()
        clearText()
    End Sub

    Private Sub dgv_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv.CellClick
        Dim i As Integer
        i = dgv.CurrentRow.Index
        lbl_id.Text = dgv.Item(0, i).Value
        t1.Text = dgv.Item(1, i).Value
        t2.Text = dgv.Item(2, i).Value
        t3.Text = dgv.Item(3, i).Value

        Dim imageData As Byte() = dgv.Item(4, i).Value
        If imageData IsNot Nothing AndAlso imageData.Length > 0 Then
            Using ms As New MemoryStream(imageData)
                t4.Image = Image.FromStream(ms)
            End Using
        End If
        active()
        save.Enabled = False
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
                cmd = New OdbcCommand("DELETE FROM tbl_events WHERE eventId = '" & lbl_id.Text & "'", conn)
                cmd.ExecuteNonQuery()
                MessageBox.Show("Data is Deleted Successfully")
                notActive()
                clearText()
                displayDgv()
            End If
        End If
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

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Me.Hide()
        cashier_management.Show()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Me.Show()
        reports.Show()
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Me.Hide()
        dashboard_admin.Show()
    End Sub
End Class