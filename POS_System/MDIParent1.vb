Imports System.Windows.Forms

Public Class MDIParent1

    Private Sub ShowNewForm(ByVal sender As Object, ByVal e As EventArgs)
        ' Create a new instance of the child form.
        Dim ChildForm As New System.Windows.Forms.Form
        ' Make it a child of this MDI form before showing it.
        ChildForm.MdiParent = Me

        m_ChildFormNumber += 1
        ChildForm.Text = "Window " & m_ChildFormNumber

        ChildForm.Show()
    End Sub

    Private Sub OpenFile(ByVal sender As Object, ByVal e As EventArgs)
        Dim OpenFileDialog As New OpenFileDialog
        OpenFileDialog.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
        OpenFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*"
        If (OpenFileDialog.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK) Then
            Dim FileName As String = OpenFileDialog.FileName
            ' TODO: Add code here to open the file.
        End If
    End Sub

    Private Sub SaveAsToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim SaveFileDialog As New SaveFileDialog
        SaveFileDialog.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
        SaveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*"

        If (SaveFileDialog.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK) Then
            Dim FileName As String = SaveFileDialog.FileName
            ' TODO: Add code here to save the current contents of the form to a file.
        End If
    End Sub


    Private Sub ExitToolsStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.Close()
    End Sub

    Private Sub CutToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        ' Use My.Computer.Clipboard to insert the selected text or images into the clipboard
    End Sub

    Private Sub CopyToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        ' Use My.Computer.Clipboard to insert the selected text or images into the clipboard
    End Sub

    Private Sub PasteToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        'Use My.Computer.Clipboard.GetText() or My.Computer.Clipboard.GetData to retrieve information from the clipboard.
    End Sub

    'Private Sub ToolBarToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ToolBarToolStripMenuItem.Click
    '    Me.ToolStrip.Visible = Me.ToolBarToolStripMenuItem.Checked
    'End Sub

    'Private Sub StatusBarToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
    '    Me.StatusStrip.Visible = Me.StatusBarToolStripMenuItem.Checked
    'End Sub

    Private Sub CascadeToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.LayoutMdi(MdiLayout.Cascade)
    End Sub

    Private Sub TileVerticalToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.LayoutMdi(MdiLayout.TileVertical)
    End Sub

    Private Sub TileHorizontalToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.LayoutMdi(MdiLayout.TileHorizontal)
    End Sub

    Private Sub ArrangeIconsToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.LayoutMdi(MdiLayout.ArrangeIcons)
    End Sub

    Private Sub CloseAllToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        ' Close all child forms of the parent.
        For Each ChildForm As Form In Me.MdiChildren
            ChildForm.Close()
        Next
    End Sub

    Private m_ChildFormNumber As Integer

    Private Sub MDIParent1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Me.ToolStripStatusLabel1.Text = "Ready"


    End Sub

    Private Sub PenjualanBarangPOSToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PenjualanBarangPOSToolStripMenuItem.Click
        'frmInputSantri.Show()
        'Dim newMDIChild As New Form1()
        '' Set the Parent Form of the Child window.
        'newMDIChild.MdiParent = Me
        ' Display the new form.
        'newMDIChild.Show()
        Form1.Show()





    End Sub

    Private Sub MnDataKasir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnDataKasir.Click
        'frmInputSantri.Show()
        Dim newMDIChild As New Form4()
        ' Set the Parent Form of the Child window.
        newMDIChild.MdiParent = Me
        ' Display the new form.
        newMDIChild.Show()
    End Sub

    Private Sub ToolStripStatusLabel1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub MnDataBarang_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnDataBarang.Click
        'frmInputSantri.Show()
        Dim newMDIChild As New Form5()
        ' Set the Parent Form of the Child window.
        newMDIChild.MdiParent = Me
        ' Display the new form.
        newMDIChild.Show()
    End Sub

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

        Me.ToolStripStatusLabel5.Text = hr + ":" + mn + ":" + sc
        'Me.ToolStripStatusLabel1.Text = "Ready"
    End Sub

    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        End
    End Sub
End Class
