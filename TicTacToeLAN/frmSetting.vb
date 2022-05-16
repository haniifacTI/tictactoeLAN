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
        Dim port As Integer = 8083
        udpClient.Connect(IPAddress.Parse(txtIp.Text), port)
        Dim sendBytes As Byte()
        sendBytes = Encoding.ASCII.GetBytes("Connected to game")
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
End Class