Imports System
Imports System.IO
Imports System.Diagnostics
Imports System.Net


Public Class MainForm

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        My.Computer.Network.DownloadFile("http://storefront.steampowered.com/download/hldsupdatetool.exe", "..\updatetool.exe")
        Process.Start("..\HldsUpdateTool.exe")
    End Sub

    Private Sub ServercfgGenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ServercfgGenToolStripMenuItem.Click
        servercfggen.Show()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        ServerProperties.Show()
    End Sub

    Private Sub MainToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MainToolStripMenuItem.Click
        Settings.Show()
    End Sub

    Private Sub ListView1_MouseClick(ByVal sender As Object, ByVal e As MouseEventArgs)

        MessageBox.Show("FUCLAKADSKDAKFKDSAFDSA")
        ' ContextMenuStrip1.Show()
        ' Dim li As ListViewHitTestInfo
        ' If Button = MouseButtons.Left Then
        'li = ListView1.HitTest(x, y)

        '  If Not li Is Nothing Then

        'MsgBox("FUCKS YOUUUUUUUUU")
        '  End If
        '  li = Nothing
        '  End If

    End Sub



 Private Sub ListView1_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ListView1.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Right Then
            ContextMenuStrip1.Show(MousePosition)
        End If
    End Sub

    Private Sub MainForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim appdata As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)
        Dim savepath As DirectoryInfo = New DirectoryInfo(appdata & "/scrds_client")

        Try
            If (savepath.Exists = True) Then
                Return
            Else
                savepath.Create()
            End If

        Catch ex As Exception

        End Try

        Dim serversread As New System.IO.StreamReader(appdata & "/scrds_client")
        Dim Lineread As String
        Dim tempValue As Integer = 0
        Dim lvi As New ListViewItem

        Do While serversread.Peek() <> -1

            Lineread = Lineread & serversread.ReadLine()
            lvi.Text = Lineread

        Loop

        tempValue = tempValue + 1
        lvi.SubItems.Add(tempValue.ToString)
        ListView1.Items.Add(lvi)
    End Sub


    Private Sub AboutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AboutToolStripMenuItem.Click
        About.Show()
    End Sub
End Class