Imports System.Data.Odbc
Imports System.IO
Imports MessagingToolkit.Barcode
Public Class product_management


    Sub displayDgv()
        koneksi()
        da = New OdbcDataAdapter("SELECT * FROM tbl_products", conn)
        ds = New DataSet
        ds.Clear()
        da.Fill(ds, "tbl_products")
        dgv.DataSource = ds.Tables("tbl_products")
    End Sub

    Sub active()
        t1.Enabled = True
        t3.Enabled = True
        t2.Enabled = True
        t4.Enabled = True
        t5.Enabled = True
        t6.Enabled = True

        save.Enabled = True
        edit.Enabled = True
        delete.Enabled = True
    End Sub

    Sub notActive()
        t1.Enabled = False
        t3.Enabled = False
        t2.Enabled = False
        t4.Enabled = False
        t5.Enabled = False
        t6.Enabled = False
        TextBox1.Enabled = False

        save.Enabled = False
        edit.Enabled = False
        delete.Enabled = False
    End Sub

    Sub clearText()
        t1.Clear()
        t2.Text = ""
        t3.Clear()
        t4.Clear()
        t5.Text = ""
        t6.Text = ""
        lbl_id.Text = "-"
        TextBox1.Clear()
        t7.Image = Nothing
    End Sub

    Private Sub save_Click(sender As Object, e As EventArgs) Handles save.Click
        'koneksi()
        'If t7.Image IsNot Nothing Then
        '    Dim ms As New MemoryStream
        '    t7.Image.Save(ms, t7.Image.RawFormat)
        '    Dim imageData As Byte() = ms.ToArray()
        '    cmd = New OdbcCommand("INSERT INTO tbl_event (productName, category, price, quantity, supplierId, expDate, barcode) VALUES (?, ?, ?, ?, ?)", conn)
        '    cmd.Parameters.AddWithValue("@productName", t1.Text)
        '    cmd.Parameters.AddWithValue("@category", t2.Text)
        '    cmd.Parameters.AddWithValue("@price", t3.Text)
        '    cmd.Parameters.AddWithValue("@quantity", t4.Text)
        '    cmd.Parameters.AddWithValue("@supplierId", t5.Text)
        '    cmd.Parameters.AddWithValue("@expDate", t6.Text)
        '    cmd.Parameters.AddWithValue("@barcode", imageData)

        '    If cmd.ExecuteNonQuery() = 1 Then
        '        MessageBox.Show("Image Inserted")
        '        displayDgv()
        '        clearText()
        '        notActive()
        '    Else
        '        MessageBox.Show("Image Not Inserted")
        '    End If
        'ElseIf t1.Text = "" Or t2.Text = "" Or t3.Text = "" Or t4.Text = "" Or t5.Text = "" Then
        '    MessageBox.Show("Please Complete The Data")
        'Else
        '    MessageBox.Show("Please Insert Image/Poster of The Event")
        'End If



        'If t1.Text = "" Or t2.Text = "" Or t3.Text = "" Or t4.Text = "" Or t5ere.Text = "" Then
        '    MessageBox.Show("Please Complete The Data")

        'Else
        '    koneksi()
        '    cmd = New OdbcCommand("INSERT INTO tbl_cashier VALUES ('" + Nothing + "', '" + t1.Text + "', '" + t2.Text + "', '" + t3.Text + "', '" + t4.Text + "', '" + t5ere.Text + "', '" + t6.Text + "')", conn)
        '    cmd.ExecuteNonQuery()
        '    MessageBox.Show("Data is Saved Successfully")
        '    displayDgv()
        '    notActive()
        '    clearText()
        'End If


        ' Check for complete data
        If t1.Text = "" Or t2.Text = "" Or t3.Text = "" Or t4.Text = "" Or t5.Text = "" Then
            MessageBox.Show("Please Complete The Data")
            Return
        End If

        ' Ensure connection
        koneksi()

        ' Construct SQL command based on category
        Dim sql As String
        If t2.Text = "Food" Then
            sql = "INSERT INTO tbl_products (productName, category, price, quantity, supplierId, expDate) VALUES (?, ?, ?, ?, ?, ?)"
        Else
            sql = "INSERT INTO tbl_products (productName, category, price, quantity, supplierId) VALUES (?, ?, ?, ?, ?)"
        End If

        Using cmd As New OdbcCommand(sql, conn)
            ' Add parameters common to both cases
            cmd.Parameters.AddWithValue("@productName", t1.Text)
            cmd.Parameters.AddWithValue("@category", t2.Text)
            cmd.Parameters.AddWithValue("@price", t3.Text)
            cmd.Parameters.AddWithValue("@quantity", t4.Text)
            cmd.Parameters.AddWithValue("@supplierId", t5.Text)

            ' Add expDate parameter only if the category is "Food"
            If t2.Text = "Food" Then
                cmd.Parameters.AddWithValue("@expDate", t6.Value)
            End If

            ' Execute the query and handle the result
            Try
                If cmd.ExecuteNonQuery() = 1 Then
                    MessageBox.Show("Data is Saved Successfully")
                    displayDgv()
                    clearText()
                    notActive()
                Else
                    MessageBox.Show("Data Not Inserted")
                End If
            Catch ex As Exception
                MessageBox.Show("Error executing query: " & ex.Message)
            End Try
        End Using
    End Sub

    Private Sub dgv_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv.CellClick
        'Dim i As Integer
        'i = dgv.CurrentRow.Index
        'lbl_id.Text = dgv.Item(0, i).Value
        't1.Text = dgv.Item(1, i).Value
        't2.Text = dgv.Item(2, i).Value
        't3.Text = dgv.Item(3, i).Value
        't4.Text = dgv.Item(4, i).Value
        't5.Text = dgv.Item(5, i).Value
        't6.Text = dgv.Item(6, i).Value
        'active()
        'save.Enabled = False
        If e.RowIndex >= 0 Then
            Dim i As Integer
            i = e.RowIndex
            lbl_id.Text = dgv.Item(0, i).Value.ToString()
            t1.Text = dgv.Item(1, i).Value.ToString()
            t2.Text = dgv.Item(2, i).Value.ToString()
            t3.Text = dgv.Item(3, i).Value.ToString()
            t4.Text = dgv.Item(4, i).Value.ToString()
            t5.Text = dgv.Item(5, i).Value.ToString()

            ' Handle the expDate column which might be NULL
            If IsDBNull(dgv.Item(6, i).Value) Then
                t6.Format = DateTimePickerFormat.Custom
                t6.CustomFormat = " " ' Set a blank format
                t6.Value = DateTimePicker.MinimumDateTime ' Set a minimum date to avoid exceptions
            Else
                t6.Format = DateTimePickerFormat.Short
                t6.Value = Convert.ToDateTime(dgv.Item(6, i).Value)
            End If

            active()
            save.Enabled = False
        End If
    End Sub

    Private Sub product_management_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        notActive()
        displayDgv()
        supplier()
        namaSupplier()
        Button4.Enabled = False
    End Sub

    Sub supplier()
        koneksi()
        Dim cmd As New OdbcCommand("select * from tbl_supplier", conn)
        Dim adapter As New OdbcDataAdapter(cmd)
        Dim tbl As New DataTable()
        adapter.Fill(tbl)
        t5.DataSource = tbl
        t5.DisplayMember = "supplierId"
        t5.ValueMember = "supplierId"
    End Sub

    Sub namaSupplier()
        koneksi()
        cmd = New OdbcCommand("SELECT * FROM tbl_supplier WHERE supplierId = '" & t5.Text & "'", conn)
        dr = cmd.ExecuteReader()
        dr.Read()
        If dr.HasRows Then
            TextBox1.Text = dr.GetString(1)
        End If
    End Sub


    Private Sub t1_TextChanged(sender As Object, e As EventArgs) Handles t1.TextChanged
        Dim Generator As New MessagingToolkit.Barcode.BarcodeEncoder
        Generator.BackColor = Color.White
        Generator.LabelFont = New Font("Arial", 7, FontStyle.Regular)
        Generator.IncludeLabel = True
        Generator.CustomLabel = t1.Text
        Try
            t7.Image = New Bitmap(Generator.Encode(MessagingToolkit.Barcode.BarcodeFormat.Code93, t1.Text))
        Catch ex As Exception
        End Try
    End Sub

    Private Sub add_Click(sender As Object, e As EventArgs) Handles add.Click
        active()
    End Sub

    Private Sub cancel_Click(sender As Object, e As EventArgs) Handles cancel.Click
        notActive()
        clearText()
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        If t7.Image Is Nothing Then
            MessageBox.Show("Please Generate The Barcode First")

        Else
            Dim SD As New SaveFileDialog
            SD.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.Desktop
            SD.FileName = t1.Text
            SD.SupportMultiDottedExtensions = True
            SD.AddExtension = True
            SD.Filter = "PNG File|*.png"
            If SD.ShowDialog() = DialogResult.OK Then
                Try
                    t7.Image.Save(SD.FileName, Imaging.ImageFormat.Png)
                Catch ex As Exception
                End Try
            End If
        End If

    End Sub

    Private Sub edit_Click(sender As Object, e As EventArgs) Handles edit.Click
        'If t1.Text = "" Or t2.Text = "" Or t3.Text = "" Or t4.Text = "" Or t5.Text = "" Or t6.Text = "" Or lbl_id.Text = "-" Then
        '    MessageBox.Show("Please Choose The Data")
        'Else
        '    koneksi()
        '    cmd = New OdbcCommand("UPDATE tbl_products SET productName = '" & t1.Text & "', category = '" & t2.Text & "', price = '" & t3.Text & "', quantity = '" & t4.Text & "', supplierId '" & t5.Text & "', expDate = '" & t6.Text & "'", conn)
        '    cmd.ExecuteNonQuery()
        '    MessageBox.Show("Data is Updated Successfully")
        '    displayDgv()
        '    clearText()
        '    notActive()
        'End If

        If t1.Text = "" Or t2.Text = "" Or t3.Text = "" Or t4.Text = "" Or t5.Text = "" Or lbl_id.Text = "-" Then
            MessageBox.Show("Please Choose The Data")
        Else
            koneksi()

            ' Construct SQL command based on category
            Dim sql As String
            If t2.Text = "Food" Then
                sql = "UPDATE tbl_products SET productName = ?, category = ?, price = ?, quantity = ?, supplierId = ?, expDate = ? WHERE id = ?"
            Else
                ' Set expDate to NULL if category is NonFood
                sql = "UPDATE tbl_products SET productName = ?, category = ?, price = ?, quantity = ?, supplierId = ?, expDate = NULL WHERE id = ?"
            End If

            Using cmd As New OdbcCommand(sql, conn)
                ' Add parameters common to both cases
                cmd.Parameters.AddWithValue("@productName", t1.Text)
                cmd.Parameters.AddWithValue("@category", t2.Text)
                cmd.Parameters.AddWithValue("@price", t3.Text)
                cmd.Parameters.AddWithValue("@quantity", t4.Text)
                cmd.Parameters.AddWithValue("@supplierId", t5.Text)

                ' Add expDate parameter only if the category is "Food"
                If t2.Text = "Food" Then
                    cmd.Parameters.AddWithValue("@expDate", t6.Value)
                End If

                ' Add the ID parameter
                cmd.Parameters.AddWithValue("@id", lbl_id.Text)

                ' Execute the query and handle the result
                Try
                    If cmd.ExecuteNonQuery() = 1 Then
                        MessageBox.Show("Data is Updated Successfully")
                        displayDgv()
                        clearText()
                        notActive()
                    Else
                        MessageBox.Show("Data Not Updated")
                    End If
                Catch ex As Exception
                    MessageBox.Show("Error executing query: " & ex.Message)
                End Try
            End Using
        End If
    End Sub

    Private Sub delete_Click(sender As Object, e As EventArgs) Handles delete.Click
        If t1.Text = "" Or t2.Text = "" Or t3.Text = "" Or t4.Text = "" Or t5.Text = "" Or t6.Text = "" Or lbl_id.Text = "-" Then
            MessageBox.Show("Please Choose The Data")
        Else
            Dim result As DialogResult = MessageBox.Show("Are you sure to delete the data?", "Caution", MessageBoxButtons.YesNoCancel)
            If result = DialogResult.Cancel Then
                MessageBox.Show("Canceled")
            ElseIf result = DialogResult.No Then
                MessageBox.Show("Canceled")
            ElseIf result = DialogResult.Yes Then
                koneksi()
                cmd = New OdbcCommand("DELETE FROM tbl_products WHERE id = '" & lbl_id.Text & "'", conn)
                cmd.ExecuteNonQuery()
                MessageBox.Show("Data is Deleted Successfully")
                notActive()
                clearText()
                displayDgv()
            End If
        End If
    End Sub

    Private Sub t5_SelectedIndexChanged(sender As Object, e As EventArgs) Handles t5.SelectedIndexChanged
        namaSupplier()
    End Sub

    Private Sub releaseObject(ByVal obj As Object)
        Try
            System.Runtime.InteropServices.Marshal.ReleaseComObject(obj)
            obj = Nothing
        Catch ex As Exception
            obj = Nothing
        Finally
            GC.Collect()
        End Try
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Try
            Button8.Text = "Please Wait..."
            Button8.Enabled = False

            SaveFileDialog1.Filter = "Excel Document (*.xlsx)|*.xlsx"
            If SaveFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                Dim xlApp As Microsoft.Office.Interop.Excel.Application
                Dim xlWorkBook As Microsoft.Office.Interop.Excel.Workbook
                Dim xlWorkSheet As Microsoft.Office.Interop.Excel.Worksheet
                Dim misValue As Object = System.Reflection.Missing.Value
                Dim i As Integer
                Dim j As Integer

                xlApp = New Microsoft.Office.Interop.Excel.Application
                xlWorkBook = xlApp.Workbooks.Add(misValue)
                xlWorkSheet = xlWorkBook.Sheets("sheet1")

                For i = 0 To dgv.RowCount - 2
                    For j = 0 To dgv.ColumnCount - 1
                        For k As Integer = 1 To dgv.Columns.Count
                            xlWorkSheet.Cells(1, k) = dgv.Columns(k - 1).HeaderText
                            xlWorkSheet.Cells(i + 2, j + 1) = dgv(j, i).Value.ToString()
                        Next
                    Next
                Next

                xlWorkSheet.SaveAs(SaveFileDialog1.FileName)
                xlWorkBook.Close()
                xlApp.Quit()

                releaseObject(xlApp)
                releaseObject(xlWorkBook)
                releaseObject(xlWorkSheet)

                MsgBox("Successfully saved" & vbCrLf & "File are saved at : " & SaveFileDialog1.FileName, MsgBoxStyle.Information, "Information")

                Button8.Text = "Print to MS Excel"
                Button8.Enabled = True
            End If
        Catch ex As Exception
            MessageBox.Show("Failed to save !!!", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Hide()
        supplier_management.Show()
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
End Class