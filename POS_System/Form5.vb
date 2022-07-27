Imports System.Data.SqlClient
Imports System
Imports System.Drawing
Imports System.Windows.Forms
Imports System.Data.OleDb
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class Form5
    Dim koneksi = Module2.Koneksi
    Dim con As New OleDbConnection
    'Dim ds As New DataSet
    Dim da As OleDbDataAdapter
    Dim dispoBaris As Integer
    Public nmr_urut As String
    Dim bln_romawi As String
    Dim Sql As String = String.Empty
    Dim Sql2 As String = String.Empty
    Dim Sql3 As String = String.Empty
    Dim Sql4 As String = String.Empty
    Dim Sql5 As String = String.Empty
    Dim Sql6 As String = String.Empty
    Dim Kd_Akun, Nm_Akun As String
    Dim trans As String
    Dim urutan As String
    Dim hitung As Long
    Dim bln, thn As String
    Dim TG As Date

    Private Property cmd As SqlCommand

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        waktu()
    End Sub

    Sub waktu()

        'HR'

        Dim hr As String = TimeOfDay.Hour

        If hr = 1 Then

            hr = "0" + hr

        End If

        If hr = 2 Then

            hr = "0" + hr

        End If

        If hr = 3 Then

            hr = "0" + hr

        End If

        If hr = 4 Then

            hr = "0" + hr

        End If

        If hr = 5 Then

            hr = "0" + hr

        End If

        If hr = 6 Then

            hr = "0" + hr

        End If

        If hr = 7 Then

            hr = "0" + hr

        End If

        If hr = 8 Then

            hr = "0" + hr

        End If

        If hr = 9 Then

            hr = "0" + hr

        End If

        If hr = 0 Then

            hr = "0" + hr

        End If

        'MN'

        Dim mn As String = TimeOfDay.Minute

        If mn = 1 Then

            mn = "0" + mn

        End If

        If mn = 2 Then

            mn = "0" + mn

        End If

        If mn = 3 Then

            mn = "0" + mn

        End If

        If mn = 4 Then

            mn = "0" + mn

        End If

        If mn = 5 Then

            mn = "0" + mn

        End If

        If mn = 6 Then

            mn = "0" + mn

        End If

        If mn = 7 Then

            mn = "0" + mn

        End If

        If mn = 8 Then

            mn = "0" + mn

        End If

        If mn = 9 Then

            mn = "0" + mn

        End If

        If mn = 0 Then

            mn = "0" + mn

        End If

        'SC'

        Dim sc As String = TimeOfDay.Second

        If sc = 1 Then

            sc = "0" + sc

        End If

        If sc = 2 Then

            sc = "0" + sc

        End If

        If sc = 3 Then

            sc = "0" + sc

        End If

        If sc = 4 Then

            sc = "0" + sc

        End If

        If sc = 5 Then

            sc = "0" + sc

        End If

        If sc = 6 Then

            sc = "0" + sc

        End If

        If sc = 7 Then

            sc = "0" + sc

        End If

        If sc = 8 Then

            sc = "0" + sc

        End If

        If sc = 9 Then

            sc = "0" + sc

        End If

        If sc = 0 Then

            sc = "0" + sc

        End If

        Label23.Text = hr + ":" + mn + ":" + sc

    End Sub

    Private Sub Form5_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        RoundButton1(Button2)
        RoundButton2(Button4)
        RoundButton3(Button5)
        RoundButton4(Button1)


        DataGridView1.EnableHeadersVisualStyles = False
        DataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.Red


        DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing
        DataGridView1.ColumnHeadersHeight = 40
        DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing


        DataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White


        DataGridView1.RowsDefaultCellStyle.BackColor = Color.AliceBlue
        DataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.LightSteelBlue

        With DataGridView1
            .Columns.Add("No", "No.")
            .Columns.Add("Tanggal", "Tanggal")
            .Columns.Add("KodeBarang", "Kode Barang")
            .Columns.Add("NamaBarang", "Nama Barang")
            .Columns.Add("HargaBeli", "Harga Beli")
            .Columns.Add("HargaJual", "Harga Jual")
            .Columns.Add("Jumlah", "Jumlah")
            '.Columns.Add("Total", "TOTAL")
            '.Columns.Add("Kode_Transaksi", "KODE TRANSAKSI")
            .Columns.Add("Id", "Id")
            '.Columns.Add("NomorAkun", "NOMOR AKUN")
            '.Columns.Add("saldebet", "SALDO DEBET")
            '.Columns.Add("salkredit", "SALDO KREDIT")
            '.Columns.Add("saldebet2", "SALDO DEBET2")
            '.Columns.Add("salkredit2", "SALDO KREDIT2")

        End With

        DataGridView1.Columns("No").HeaderCell.Style.Font = New Font("Ariel", 9, FontStyle.Bold)
        DataGridView1.Columns("Tanggal").HeaderCell.Style.Font = New Font("Ariel", 9, FontStyle.Bold)
        DataGridView1.Columns("KodeBarang").HeaderCell.Style.Font = New Font("Ariel", 9, FontStyle.Bold)
        DataGridView1.Columns("NamaBarang").HeaderCell.Style.Font = New Font("Ariel", 9, FontStyle.Bold)
        DataGridView1.Columns("HargaBeli").HeaderCell.Style.Font = New Font("Ariel", 9, FontStyle.Bold)
        DataGridView1.Columns("HargaJual").HeaderCell.Style.Font = New Font("Ariel", 9, FontStyle.Bold)
        DataGridView1.Columns("Jumlah").HeaderCell.Style.Font = New Font("Ariel", 9, FontStyle.Bold)
        'DataGridView1.Columns("Kode_Transaksi").HeaderCell.Style.Font = New Font("Ariel", 9, FontStyle.Bold)
        DataGridView1.Columns("Id").HeaderCell.Style.Font = New Font("Ariel", 9, FontStyle.Bold)

        DataGridView1.Columns.Item("No").Width = 50
        DataGridView1.Columns.Item("Tanggal").Width = 120
        DataGridView1.Columns.Item("KodeBarang").Width = 120
        DataGridView1.Columns.Item("NamaBarang").Width = 200
        DataGridView1.Columns.Item("HargaBeli").Width = 120
        DataGridView1.Columns.Item("HargaJual").Width = 120
        DataGridView1.Columns.Item("Jumlah").Width = 80
        'DataGridView1.Columns.Item("Kode_Transaksi").Width = 150
        DataGridView1.Columns.Item("Id").Width = 50

        'DataGridView1.Columns.Item("Debit").Width = 150
        'DataGridView1.Columns.Item("Kredit").Width = 150
        'DataGridView1.Columns.Item("Keterangan").Width = 180
        'DataGridView1.Columns.Item("Id").Width = 40
        'DataGridView1.Columns.Item("NomorTrans").Width = 180
        'DataGridView1.Columns.Item("NomorAkun").Width = 180
        'DataGridView1.Columns.Item("saldebet").Width = 180
        'DataGridView1.Columns.Item("salkredit").Width = 180
        'DataGridView1.Columns.Item("saldebet2").Width = 180
        'DataGridView1.Columns.Item("salkredit2").Width = 180


        DataGridView1.Columns("No").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridView1.Columns("Tanggal").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridView1.Columns("KodeBarang").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridView1.Columns("NamaBarang").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridView1.Columns("HargaBeli").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridView1.Columns("HargaJual").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridView1.Columns("Jumlah").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        'DataGridView1.Columns("Kode_Transaksi").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridView1.Columns("Id").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter

        'DataGridView1.Columns("Debit").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        'DataGridView1.Columns("Kredit").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        'DataGridView1.Columns("Keterangan").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        'DataGridView1.Columns("Id").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        'DataGridView1.Columns("NomorTrans").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        'DataGridView1.Columns("NomorAkun").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        'DataGridView1.Columns("saldebet").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        'DataGridView1.Columns("salkredit").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        'DataGridView1.Columns("saldebet2").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        'DataGridView1.Columns("salkredit2").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter


        DataGridView1.Columns("No").DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter
        DataGridView1.Columns("Tanggal").DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter
        DataGridView1.Columns("KodeBarang").DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter
        DataGridView1.Columns("NamaBarang").DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
        DataGridView1.Columns("HargaBeli").DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
        DataGridView1.Columns("HargaJual").DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
        DataGridView1.Columns("Jumlah").DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
        'DataGridView1.Columns("Kode_Transaksi").DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter
        DataGridView1.Columns("Id").DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter

        'DataGridView1.Columns("Kode_Transaksi").Visible = False
        DataGridView1.Columns("Id").Visible = False

        txtTgl_Transaksi.Value = Format(Now, "dd-MM-yyyy")
        Kodenomor()
        tampil()

        Dim rowcount As Integer
        rowcount = DataGridView1.Rows.Count()
        TextBox3.Text = rowcount - 1

    End Sub



    Private Sub tampil()
        tutupkoneksi()
        bukakoneksi()
        'NomorAgenda()
        'WHERE Tanggal_Input='" & Format(txtTgl_Transaksi.Value, "yyyy") & "' 
        Sql = "SELECT * From Table_Barang Order by Id desc"

        Dim da2 As New SqlDataAdapter(Sql, conn)
        Dim ds2 As New DataSet
        da2.Fill(ds2, "DataBarang")
        Dim dt As New DataTable

        Dim i, hitung As Integer
        Dim urutan As String

        Dim totalbeli As Double
        totalbeli = 0

        DataGridView1.Rows.Clear()
        Dim dsTables As DataTable = ds2.Tables("DataBarang")

        For i = 0 To ds2.Tables("DataBarang").Rows.Count - 1

            DataGridView1.Rows.Add()

            With DataGridView1.Rows(i)

                'If Format(dsTables.Rows(i).Item("Tanggal_Input"), "MM") = Format(txtTgl_Transaksi.Value, "MM") And Format(dsTables.Rows(i).Item("Tanggal_Input"), "yyyy") = Format(txtTgl_Transaksi.Value, "yyyy") Then

                hitung = Len(Trim$(i))
                If hitung = 1 Then
                    urutan = "00" & i
                ElseIf hitung = 2 Then
                    urutan = "0" & i
                    'ElseIf hitung = 3 Then
                    '    urutan = "0" & i
                Else
                    urutan = i
                End If

                .Cells(0).Value = urutan
                '.Cells(1).Value = Format(dsTables.Rows(i).Item("Tgl_terima"), "dd-MM-yyyy")
                .Cells(1).Value = Format(dsTables.Rows(i).Item("Tanggal"), "dd-MM-yyyy")
                .Cells(2).Value = dsTables.Rows(i).Item("Kode_Barang")
                .Cells(3).Value = dsTables.Rows(i).Item("Nama_Barang")
                .Cells(4).Value = dsTables.Rows(i).Item("Harga_Beli")
                .Cells(5).Value = dsTables.Rows(i).Item("Harga_Jual")
                .Cells(6).Value = dsTables.Rows(i).Item("Jumlah_Qty")
                '.Cells(6).Value = dsTables.Rows(i).Item("Total_Beli")
                '.Cells(7).Value = dsTables.Rows(i).Item("Kode_Transaksi")
                .Cells(7).Value = dsTables.Rows(i).Item("Id")

                'totalbeli = totalbeli + Val(DataGridView1.Rows(i).Cells(6).Value)

                '.Cells(6).Value = dsTables.Rows(i).Item("Keterangan")
                '.Cells(7).Value = dsTables.Rows(i).Item("Id")
                '.Cells(8).Value = dsTables.Rows(i).Item("Kode_Transaksi")
                '.Cells(9).Value = dsTables.Rows(i).Item("No_Akun")
                '.Cells(10).Value = dsTables.Rows(i).Item("Saldo_Debet")
                '.Cells(11).Value = dsTables.Rows(i).Item("Saldo_Kredit")
                '.Cells(12).Value = dsTables.Rows(i).Item("Saldo_Debet2")
                '.Cells(13).Value = dsTables.Rows(i).Item("Saldo_Kredit2")



                'tutupkoneksi()
                'bukakoneksi()
                'cmd = New SqlCommand("Select * from Table_Akun WHERE Nomor_Akun='" & Trim(CStr(.Cells(9).Value)) & "' AND Bulan='" & Format(txtTgl_Transaksi.Value, "MM") & "' AND Tahun='" & Format(txtTgl_Transaksi.Value, "yyyy") & "'", conn)

                'rd = cmd.ExecuteReader
                'rd.Read()
                'If Not rd.HasRows Then
                '    'MsgBox("Nomor Akun Tidak ada di bulan dan tahun yang Anda Pilih. Sesuaikan Tanggal dengan Tanggal Akun yang ada di Database")
                'Else

                '    MsgBox(CStr(rd.Item("No_Akun")))

                'End If

                '.Cells(6).Value = dsTables.Rows(i).Item("Perihal")
                '.Cells(7).Value = dsTables.Rows(i).Item("Id")
                '.Cells(8).Value = dsTables.Rows(i).Item("Nmr_agenda")
                '.Cells(9).Value = dsTables.Rows(i).Item("Sifat_surat")
                '.Cells(10).Value = Format(dsTables.Rows(i).Item("Tgl_diteruskan"), "dd-MM-yyyy")


                'End If
            End With

        Next

        'TextBox10.Text = FormatCurrency(totalbeli)
        'TextBox4.Text = totalbeli

        'Dim j As Integer
        'For j = DataGridView1.RowCount - 1 To 0 Step -1
        '    If Trim(DataGridView1(0, j).Value) = "" Then DataGridView1.Rows.RemoveAt(j)
        'Next
        'For Each dt In ds.Tables
        '    DataGridView2.DataSource = dt
        'Next
        'tutupkoneksi()
    End Sub



    Private Sub RoundButton1(ByVal btn As Button)

        btn.FlatStyle = FlatStyle.Flat
        btn.FlatAppearance.BorderSize = 0
        btn.BackColor = Color.Red
        btn.ForeColor = Color.White
        btn.Cursor = Cursors.Hand

        btn.Font = New Font("Century Gothic", 10, FontStyle.Bold)

        Dim Raduis As New Drawing2D.GraphicsPath

        Raduis.StartFigure()
        'appends an elliptical arc to the current figure
        'left corner top
        Raduis.AddArc(New Rectangle(0, 0, 30, 30), 180, 90)
        'appends a line segment to the current figure
        Raduis.AddLine(10, 0, btn.Width - 30, 0)
        'appends an elliptical arc to the current figure
        'right corner top
        Raduis.AddArc(New Rectangle(btn.Width - 30, 0, 30, 30), -90, 90)
        'appends a line segment to the current figure
        Raduis.AddLine(Button2.Width, 30, btn.Width, btn.Height - 10)
        'appends an elliptical arc to the current figure 
        'right corner buttom
        Raduis.AddArc(New Rectangle(btn.Width - 30, btn.Height - 30, 30, 30), 0, 90)
        'appends a line segment to the current figure
        'left corner bottom
        Raduis.AddLine(btn.Width - 10, btn.Width, 30, btn.Height)
        'appends an elliptical arc to the current figure
        Raduis.AddArc(New Rectangle(0, btn.Height - 30, 30, 30), 90, 90)
        'Close the current figure and start a new one.
        Raduis.CloseFigure()
        'set the window associated with the control
        Button2.Region = New Region(Raduis)
    End Sub

    Private Sub RoundButton2(ByVal btn As Button)

        btn.FlatStyle = FlatStyle.Flat
        btn.FlatAppearance.BorderSize = 0
        btn.BackColor = Color.Yellow
        btn.ForeColor = Color.Red
        btn.Cursor = Cursors.Hand

        btn.Font = New Font("Century Gothic", 10, FontStyle.Bold)

        Dim Raduis As New Drawing2D.GraphicsPath

        Raduis.StartFigure()
        'appends an elliptical arc to the current figure
        'left corner top
        Raduis.AddArc(New Rectangle(0, 0, 30, 30), 180, 90)
        'appends a line segment to the current figure
        Raduis.AddLine(10, 0, btn.Width - 30, 0)
        'appends an elliptical arc to the current figure
        'right corner top
        Raduis.AddArc(New Rectangle(btn.Width - 30, 0, 30, 30), -90, 90)
        'appends a line segment to the current figure
        Raduis.AddLine(Button2.Width, 30, btn.Width, btn.Height - 10)
        'appends an elliptical arc to the current figure 
        'right corner buttom
        Raduis.AddArc(New Rectangle(btn.Width - 30, btn.Height - 30, 30, 30), 0, 90)
        'appends a line segment to the current figure
        'left corner bottom
        Raduis.AddLine(btn.Width - 10, btn.Width, 30, btn.Height)
        'appends an elliptical arc to the current figure
        Raduis.AddArc(New Rectangle(0, btn.Height - 30, 30, 30), 90, 90)
        'Close the current figure and start a new one.
        Raduis.CloseFigure()
        'set the window associated with the control
        Button4.Region = New Region(Raduis)
    End Sub

    Private Sub RoundButton3(ByVal btn As Button)

        btn.FlatStyle = FlatStyle.Flat
        btn.FlatAppearance.BorderSize = 0
        btn.BackColor = Color.Orange
        btn.ForeColor = Color.White
        btn.Cursor = Cursors.Hand

        btn.Font = New Font("Century Gothic", 10, FontStyle.Bold)

        Dim Raduis As New Drawing2D.GraphicsPath

        Raduis.StartFigure()
        'appends an elliptical arc to the current figure
        'left corner top
        Raduis.AddArc(New Rectangle(0, 0, 30, 30), 180, 90)
        'appends a line segment to the current figure
        Raduis.AddLine(10, 0, btn.Width - 30, 0)
        'appends an elliptical arc to the current figure
        'right corner top
        Raduis.AddArc(New Rectangle(btn.Width - 30, 0, 30, 30), -90, 90)
        'appends a line segment to the current figure
        Raduis.AddLine(Button2.Width, 30, btn.Width, btn.Height - 10)
        'appends an elliptical arc to the current figure 
        'right corner buttom
        Raduis.AddArc(New Rectangle(btn.Width - 30, btn.Height - 30, 30, 30), 0, 90)
        'appends a line segment to the current figure
        'left corner bottom
        Raduis.AddLine(btn.Width - 10, btn.Width, 30, btn.Height)
        'appends an elliptical arc to the current figure
        Raduis.AddArc(New Rectangle(0, btn.Height - 30, 30, 30), 90, 90)
        'Close the current figure and start a new one.
        Raduis.CloseFigure()
        'set the window associated with the control
        Button5.Region = New Region(Raduis)
    End Sub

    Private Sub RoundButton4(ByVal btn As Button)

        btn.FlatStyle = FlatStyle.Flat
        btn.FlatAppearance.BorderSize = 0
        btn.BackColor = Color.LightSkyBlue
        btn.ForeColor = Color.White
        btn.Cursor = Cursors.Hand

        btn.Font = New Font("Century Gothic", 10, FontStyle.Bold)

        Dim Raduis As New Drawing2D.GraphicsPath

        Raduis.StartFigure()
        'appends an elliptical arc to the current figure
        'left corner top
        Raduis.AddArc(New Rectangle(0, 0, 30, 30), 180, 90)
        'appends a line segment to the current figure
        Raduis.AddLine(10, 0, btn.Width - 30, 0)
        'appends an elliptical arc to the current figure
        'right corner top
        Raduis.AddArc(New Rectangle(btn.Width - 30, 0, 30, 30), -90, 90)
        'appends a line segment to the current figure
        Raduis.AddLine(Button2.Width, 30, btn.Width, btn.Height - 10)
        'appends an elliptical arc to the current figure 
        'right corner buttom
        Raduis.AddArc(New Rectangle(btn.Width - 30, btn.Height - 30, 30, 30), 0, 90)
        'appends a line segment to the current figure
        'left corner bottom
        Raduis.AddLine(btn.Width - 10, btn.Width, 30, btn.Height)
        'appends an elliptical arc to the current figure
        Raduis.AddArc(New Rectangle(0, btn.Height - 30, 30, 30), 90, 90)
        'Close the current figure and start a new one.
        Raduis.CloseFigure()
        'set the window associated with the control
        Button1.Region = New Region(Raduis)
    End Sub


    Private Sub PictureBox2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox2.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click
        Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Close()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click


        If (txtNmBarang.Text = "" Or txtHargaBeli.Text = "" Or txtHargaJual.Text = "" Or txtJumlah.Text = "") Then
            MsgBox("Silakan lengkapi dahulu input yang tersedia.", vbInformation, "Konfirmasi")
            txtNmBarang.Focus()

        Else

            If Button2.Text = "Simpan" Then

                Sql3 = "INSERT INTO Table_Barang(Tanggal, Kode_Barang, Jumlah_Qty, Nama_Barang, Harga_Beli, Harga_Jual)" & _
                                          " VALUES ('" & Format(txtTgl_Transaksi.Value, "MM-dd-yyyy") & "','" & txtKodeBarang.Text & "','" & txtJumlah.Text & "','" & txtNmBarang.Text & "','" & txtHargaBeli.Text & "','" & txtHargaJual.Text & "')"

                ' Periksa hati-hati tanda kutip untuk setiap variabel, salah ketik mengakibatkan query anda tidak akan terbaca.
                ' Persiapan execusi Query Insert
                Dim command3 As New SqlCommand(Sql3, Module2.Koneksi)
                command3.ExecuteNonQuery()
                Module2.Koneksi.Close()

                Kodenomor()
                'MsgBox(urutan)

                Sql2 = "UPDATE Table_NomorBarang Set nomor='" & urutan & "'"

                Dim command As New SqlCommand(Sql2, Module2.Koneksi)
                command.ExecuteNonQuery()
                Module2.Koneksi.Close()

                MsgBox("Data berhasil tersimpan.", vbInformation, "Konfirmasi")

                Dim rowcount As Integer
                rowcount = DataGridView1.Rows.Count()
                TextBox3.Text = rowcount - 1

                'Sql2 = "UPDATE Table_NomorBarang Set nomor='" & urutan & "'"

                'Dim command2 As New SqlCommand(Sql2, Module2.Koneksi)
                'command2.ExecuteNonQuery()
                'Module2.Koneksi.Close()

                'Kodenomor()
                'tampil()
                'reset()



            Else


                Sql2 = "UPDATE Table_Barang Set Nama_Barang='" & txtNmBarang.Text & "',Jumlah_Qty='" & txtJumlah.Text & "',Harga_Beli='" & txtHargaBeli.Text & "',Harga_Jual='" & txtHargaJual.Text & "' WHERE Kode_Barang = '" & CStr(txtKodeBarang.Text) & "'"

                Dim command As New SqlCommand(Sql2, Module2.Koneksi)
                command.ExecuteNonQuery()
                Module2.Koneksi.Close()

                MsgBox("Data berhasil terupdate.", vbInformation, "Konfirmasi")

                Dim rowcount As Integer
                rowcount = DataGridView1.Rows.Count()
                TextBox3.Text = rowcount - 1
            End If


            'Sql2 = "UPDATE Table_Barang Set Jumlah_Qty='" & Val(QtyStok.Text) - Val(txtJumlah.Text) & "' WHERE Kode_Barang = '" & CStr(txtKodeBarang.Text) & "'"

            'Dim command As New SqlCommand(Sql2, Module2.Koneksi)
            'command.ExecuteNonQuery()
            'Module2.Koneksi.Close()



            tampil()
            reset()

        End If
        
    End Sub

    Sub reset()
        txtKodeBarang.Text = ""
        txtNmBarang.Text = ""
        txtHargaJual.Text = ""
        txtHargaBeli.Text = ""
        txtJumlah.Text = ""
        'TextBox5.Text = ""

        Kodenomor()
        Button2.Text = "Simpan"

    End Sub

    Sub Kodenomor()




        tutupkoneksi()
        bukakoneksi()
        cmd = New SqlCommand("Select nomor from Table_NomorBarang", conn)

        rd = cmd.ExecuteReader
        rd.Read()

        If Not rd.HasRows Then
            urutan = "001"
        Else
            hitung = Microsoft.VisualBasic.Right(rd.GetString(0), 3) + 1
            urutan = Microsoft.VisualBasic.Right("000" & hitung, 3)

        End If
        bln = Format(txtTgl_Transaksi.Value, "MM")
        thn = Format(txtTgl_Transaksi.Value, "yyyy")
        txtKodeBarang.Text = "N" + urutan + "-" + bln + thn




    End Sub


    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        reset()
    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub DataGridView1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridView1.DoubleClick
        Dim i As Integer
        i = Me.DataGridView1.CurrentRow.Index

        Button2.Text = "Update"

        If DataGridView1.Item(0, i).Value = "" Then
        Else
            With DataGridView1.Rows.Item(i)
                'MsgBox(CStr(Convert.ToDateTime(.Cells(1).Value)))
                If (CStr(Convert.ToDateTime(.Cells(1).Value)) <> "00.00.00") Then

                    txtTgl_Transaksi.Value = Convert.ToDateTime(.Cells(1).Value)
                    txtKodeBarang.Text = .Cells(2).Value
                    txtNmBarang.Text = .Cells(3).Value
                    txtHargaBeli.Text = .Cells(4).Value
                    txtHargaJual.Text = .Cells(5).Value
                    txtJumlah.Text = .Cells(6).Value
                    id.Text = .Cells(7).Value



                    

                    'tutupkoneksi()
                    'bukakoneksi()
                    'cmd = New SqlCommand("Select * from Table_TransaksiDetail WHERE Nomor_Akun='" & Trim(txtNoAkun.Text) & "' AND Bulan='" & Format(txtTgl_Transaksi.Value, "MM") & "' AND Tahun='" & Format(txtTgl_Transaksi.Value, "yyyy") & "'", conn)

                    'rd = cmd.ExecuteReader
                    'rd.Read()
                    'If Not rd.HasRows Then
                    '    'MsgBox("Nomor Akun Tidak ada di bulan dan tahun yang Anda Pilih. Sesuaikan Tanggal dengan Tanggal Akun yang ada di Database")
                    'Else
                    '    '.Cells(14).Value = rd.Item("Saldo_Debet")
                    '    If rd.Item("Saldo_Debet") <> "0" Then
                    '        txtSaldo.Text = rd.Item("Saldo_Debet")
                    '    Else

                    '        txtSaldo.Text = rd.Item("Saldo_Kredit")
                    '    End If
                    'End If



                End If
            End With
        End If
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Dim Sql As String = String.Empty

        Sql = "Delete from Table_Barang where Id = '" & Trim(id.Text) & "'"
        Dim command As New SqlCommand(Sql, Module2.Koneksi)

        command.ExecuteNonQuery()
        Module2.Koneksi.Close()

        tampil()
        reset()

        Dim rowcount As Integer
        rowcount = DataGridView1.Rows.Count()
        TextBox3.Text = rowcount - 1

        txtNmBarang.Focus()
    End Sub
End Class