Imports System.Net
Imports System.Net.Sockets
Imports System.Text
Public Class frmSetting
    Dim frmMain As New frmMain

    Private Sub btnHost_Click(sender As Object, e As EventArgs) Handles btnHost.Click
        Me.Hide()
        frmMain.ShowDialog()
    End Sub

    Private Sub btnConnect_Click(sender As Object, e As EventArgs) Handles btnConnect.Click
        Dim udpClient As New Sockets.UdpClient
        'Dim port As Integer = 8080
        Dim port As Integer = txtPort.Text
        'udpClient.Connect(IPAddress.Parse(txtIp.Text), port)
        udpClient.Connect(txtIp.Text, port)
        Dim sendBytes As Byte()
        sendBytes = Encoding.ASCII.GetBytes(GetIPv4Address.ToString)
        udpClient.Send(sendBytes, sendBytes.Length)
        frmMain.connect = True
        frmMain.ipConnect = txtIp.Text
        frmMain.portConnect = txtPort.Text

        Me.Hide()
        frmMain.ShowDialog()
    End Sub

    Private Sub frmSetting_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        End
    End Sub

    Private Function GetIPv4Address() As String
        GetIPv4Address = String.Empty
        Dim strHostName As String = System.Net.Dns.GetHostName()
        Dim iphe As System.Net.IPHostEntry = System.Net.Dns.GetHostEntry(strHostName)

        For Each ipheal As System.Net.IPAddress In iphe.AddressList
            If ipheal.AddressFamily = System.Net.Sockets.AddressFamily.InterNetwork Then
                GetIPv4Address = ipheal.ToString()
            End If
        Next

        Return GetIPv4Address
    End Function
End Class