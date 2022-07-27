Imports System.Data.SqlClient
Imports System
Imports System.Drawing
Imports System.Windows.Forms
Imports System.Data.OleDb
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class Form2
    Dim koneksi = Module2.Koneksi
    Dim con As New OleDbConnection
    'Dim ds As New DataSet
    Dim da As OleDbDataAdapter
    Dim dispoBaris As Integer
    Public nmr_urut As String
    Dim bln_romawi As String
    Dim Sql As String = String.Empty
    Dim Sql2 As String = String.Empty
    Public Kd_Barang, Nm_Barang, Harga_Jual, QtyStok As String
    Public Bln, Thn As String

    Private Sub Form2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

      

        DataGridView1.RowsDefaultCellStyle.BackColor = Color.AliceBlue
        DataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.LightSteelBlue

        With DataGridView1
            .Columns.Add("No", "NO.")
            .Columns.Add("Kode_Barang", "Kode_Barang")
            .Columns.Add("Nama_Barang", "Nama_Barang")
            .Columns.Add("Harga_Beli", "Harga_Beli")
            .Columns.Add("Harga_Jual", "Harga_Jual")
            .Columns.Add("Qty_Stok", "Qty_Stok")
            '.Columns.Add("Saldo_Kredit", "Saldo_Kredit")
            '.Columns.Add("Id_Akun", "Id_Akun")
            '.Columns.Add("Debit", "Debit")
            '.Columns.Add("Kredit", "Kredit")
        End With

        DataGridView1.Columns.Item("No").Width = 50
        DataGridView1.Columns.Item("Kode_Barang").Width = 130
        DataGridView1.Columns.Item("Nama_Barang").Width = 150
        DataGridView1.Columns.Item("Harga_Beli").Width = 150
        DataGridView1.Columns.Item("Harga_Jual").Width = 150
        DataGridView1.Columns.Item("Qty_Stok").Width = 80
        'DataGridView1.Columns.Item("Saldo_Kredit").Width = 150
        'DataGridView1.Columns.Item("Id_Akun").Width = 40
        'DataGridView1.Columns.Item("Debit").Width = 150
        'DataGridView1.Columns.Item("Kredit").Width = 150

        DataGridView1.Columns("No").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridView1.Columns("Kode_Barang").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridView1.Columns("Nama_Barang").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridView1.Columns("Harga_Beli").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridView1.Columns("Harga_Jual").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridView1.Columns("Qty_Stok").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        'DataGridView1.Columns("Saldo_Kredit").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        'DataGridView1.Columns("Id_Akun").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        'DataGridView1.Columns("Debit").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        'DataGridView1.Columns("Kredit").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter


        DataGridView1.Columns("No").DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter
        DataGridView1.Columns("Kode_Barang").DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter
        DataGridView1.Columns("Nama_Barang").DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
        DataGridView1.Columns("Harga_Beli").DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
        DataGridView1.Columns("Harga_Jual").DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
        DataGridView1.Columns("Qty_Stok").DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
        'DataGridView1.Columns("Saldo_Kredit").DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
        'DataGridView1.Columns("Id_Akun").DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter
        'DataGridView1.Columns("Debit").DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
        'DataGridView1.Columns("Kredit").DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft

        'DataGridView1.Columns("Id_Akun").Visible = False
        'DataGridView1.Columns("Tanggal_Input").Visible = False
        tampil2()



    End Sub


    Private Sub tampil2()
        tutupkoneksi()
        bukakoneksi()
        'NomorAgenda()
        'Where Nama_Akun like '" & txtCariAkun.Text & "'
        '%" + strSearchText + "%'"

        Sql = "SELECT * From Table_Barang WHERE Nama_Barang like '%" + Trim(txtCariBarang.Text) + "%' Order by Id asc"

        Dim da2 As New SqlDataAdapter(Sql, conn)
        Dim ds2 As New DataSet
        da2.Fill(ds2, "Table_Barang")
        Dim dt As New DataTable

        Dim i, hitung As Integer
        Dim urutan As String

        DataGridView1.Rows.Clear()
        Dim dsTables As DataTable = ds2.Tables("Table_Barang")

        For i = 0 To ds2.Tables("Table_Barang").Rows.Count - 1
            DataGridView1.Rows.Add()

            With DataGridView1.Rows(i)
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
                .Cells(1).Value = dsTables.Rows(i).Item("Kode_Barang")
                .Cells(2).Value = dsTables.Rows(i).Item("Nama_Barang")
                .Cells(3).Value = dsTables.Rows(i).Item("Harga_Beli")
                .Cells(4).Value = dsTables.Rows(i).Item("Harga_Jual")
                .Cells(5).Value = dsTables.Rows(i).Item("Jumlah_Qty")
                '.Cells(6).Value = dsTables.Rows(i).Item("Saldo_Kredit")
                '.Cells(7).Value = dsTables.Rows(i).Item("Id_Akun")
                '.Cells(8).Value = dsTables.Rows(i).Item("Debit")
                '.Cells(9).Value = dsTables.Rows(i).Item("Kredit")
                '.Cells(7).Value = dsTables.Rows(i).Item("Id")
                '.Cells(8).Value = dsTables.Rows(i).Item("Nmr_agenda")
                '.Cells(9).Value = dsTables.Rows(i).Item("Sifat_surat")
                '.Cells(10).Value = Format(dsTables.Rows(i).Item("Tgl_diteruskan"), "dd-MM-yyyy")



            End With
        Next

        TextBox3.Text = i
        'For Each dt In ds.Tables
        '    DataGridView1.DataSource = dt
        'Next
        'tutupkoneksi()
    End Sub



    Private Sub DataGridView1_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        Dim i As Integer



        i = Me.DataGridView1.CurrentRow.Index
        With DataGridView1.Rows.Item(i)
            Kd_Barang = .Cells(1).Value
            Nm_Barang = .Cells(2).Value
            Harga_Jual = .Cells(4).Value
            QtyStok = .Cells(5).Value


        End With

        'MsgBox(DataGridView1.Item(0, i).Value)
        If DataGridView1.Item(0, i).Value = "" Then
        Else
            Close()

            Me.Hide()

            Form1.txtKodeBarang.Text = Kd_Barang.ToString
            Form1.txtNmBarang.Text = Nm_Barang.ToString
            Form1.txtHargaJual.Text = Harga_Jual.ToString
            Form1.QtyStok.Text = QtyStok.ToString
            Form1.txtJumlah.Focus()

        End If

        'If Not IsDBNull(DataGridView1.Item(0, i).Value) Then
        '    Close()

        '    Me.Hide()

        '    Form1.txtKodeBarang.Text = Kd_Barang.ToString
        '    Form1.txtNmBarang.Text = Nm_Barang.ToString
        'End If
       

        


    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        tampil2()
    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub
End Class