Imports System.Net
Imports System.IO
Imports System.Text
Imports System.Threading

Public Class ServerProperties

    Dim xip As System.Threading.Thread
    Dim iip As System.Threading.Thread

    Private Sub internalip()
        Dim strHostName As String
        Dim strIPAddress As String
        strHostName = System.Net.Dns.GetHostName()
        strIPAddress = System.Net.Dns.Resolve(strHostName).AddressList(0).ToString()
        Me.TextBox1.Text = (strIPAddress)
    End Sub

    Private Sub externalip()
        Dim req As HttpWebRequest = WebRequest.Create("http://automation.whatismyip.com/n09230945.asp")
        Dim res As HttpWebResponse = req.GetResponse()
        Dim Stream As Stream = res.GetResponseStream()
        Dim sr As StreamReader = New StreamReader(Stream)
        Me.TextBox1.Text = (sr.ReadToEnd())
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        iip = New System.Threading.Thread(AddressOf Me.externalip)
        iip.Start()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        xip = New System.Threading.Thread(AddressOf Me.internalip)
        xip.Start()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        ServerSaveBrowse.ShowDialog()
        TextBox3.Text = ServerSaveBrowse.SelectedPath
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Me.Close()
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Dim appdata As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)
        Dim serverproperties As New System.IO.StreamWriter(appdata & "/scrds_client/servers.ini", True)

        If TextBox1.Text.Length > 0 Then

            serverproperties.WriteLine("[Server]")
            serverproperties.WriteLine("[Name]" & TextBox2.Text)
            serverproperties.WriteLine("[Location]" & TextBox3.Text)
            serverproperties.WriteLine("[Game]" & ComboBox1.Text)
            serverproperties.WriteLine("[IpAddress]" & TextBox1.Text)
            serverproperties.WriteLine("[Port]" & TextBox4.Text)
            serverproperties.WriteLine("[Exec]" & TextBox5.Text)
            serverproperties.WriteLine("[Start Map]" & TextBox6.Text)
            serverproperties.WriteLine("[Players]" & NumericUpDown1.Value)
            serverproperties.WriteLine("[Vac]" & CheckBox1.Checked)
            serverproperties.WriteLine("[Parameters]" & TextBox7.Text)
            serverproperties.Close()
            Me.Close()
        Else
            MessageBox.Show("Please fill all fields")
        End If

    End Sub


    Private Sub ServerProperties_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Control.CheckForIllegalCrossThreadCalls = False
    End Sub
End Class