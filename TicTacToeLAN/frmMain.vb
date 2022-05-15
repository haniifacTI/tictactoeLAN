Imports System.Net
Imports System.Net.Sockets
Imports System.Text
Public Class frmMain
    Dim statusPemain As String = "P1"

    Sub isi(btn As Button)
        If btn.Text <> "" Then Exit Sub

        If statusPemain = "P1" Then
            btn.Text = "X"
            If cekWin("X") Then
                MsgBox("Player 1 Win!" & vbCrLf & "Play again?", MsgBoxStyle.YesNo, "Game Over")
                playAgain()
            ElseIf cekDraw() Then
                MsgBox("Draw" & vbCrLf & "Play again?", MsgBoxStyle.YesNo, "Game Over")
                playAgain()
            End If
            statusPemain = "P2"
            lblStatus.Text = "Giliran Lawan"
        Else
            btn.Text = "O"
            If cekWin("O") Then
                MsgBox("Player 2 Win!" & vbCrLf & "Play again?", MsgBoxStyle.YesNo, "Game Over")
                playAgain()
            ElseIf cekDraw() Then
                MsgBox("Draw" & vbCrLf & "Play again?", MsgBoxStyle.YesNo, "Game Over")
                playAgain()
            End If
            statusPemain = "P1"
            lblStatus.Text = "Giliran Mu"
        End If
    End Sub

    Private Sub playAgain()
        If MsgBoxResult.Yes Then
            clear()
        ElseIf MsgBoxResult.No Then
            MsgBox("Thank You for playing our game",, "Tic Tac Toe")
        End If
    End Sub

    Private Sub clear()
        btn1.Text = ""
        btn2.Text = ""
        btn3.Text = ""
        btn4.Text = ""
        btn5.Text = ""
        btn6.Text = ""
        btn7.Text = ""
        btn8.Text = ""
        btn9.Text = ""
    End Sub

    Private Sub JoinOrHostGameToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles JoinOrHostGameToolStripMenuItem.Click
        frmSetting.Show()
    End Sub

    Public Sub serverThread()
        Dim udpClient As New UdpClient(8083)
        While True
            Dim RemoteIpEndPoint As New IPEndPoint(IPAddress.Any, 0)
            Dim receiveBytes As Byte()
            receiveBytes = udpClient.Receive(RemoteIpEndPoint)
            Dim returnData As String = Encoding.ASCII.GetString(receiveBytes)
            MsgBox("From " & RemoteIpEndPoint.Address.ToString() + ":" & returnData.ToString())
        End While
    End Sub

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Function cekWin(s As String) As Boolean
        If (btn1.Text = s And btn2.Text = s And btn3.Text = s) Or
            (btn4.Text = s And btn5.Text = s And btn6.Text = s) Or
            (btn7.Text = s And btn8.Text = s And btn9.Text = s) Or
            (btn1.Text = s And btn4.Text = s And btn7.Text = s) Or
            (btn2.Text = s And btn5.Text = s And btn8.Text = s) Or
            (btn3.Text = s And btn6.Text = s And btn9.Text = s) Or
            (btn1.Text = s And btn5.Text = s And btn9.Text = s) Or
            (btn3.Text = s And btn5.Text = s And btn7.Text = s) Then
            Return True
        Else
            Return False
        End If
    End Function

    Function cekDraw() As Boolean
        If btn1.Text <> "" And btn2.Text <> "" And btn3.Text <> "" And btn4.Text <> "" And btn5.Text <> "" And btn6.Text <> "" And btn7.Text <> "" And btn8.Text <> "" And btn9.Text <> "" Then
            Return True
        Else
            Return False
        End If
    End Function

    Private Sub sendButton(btn As String)
        Dim udpClient As New Sockets.UdpClient
        Dim port As Integer = 8083
        udpClient.Connect(IPAddress.Parse(frmSetting.txtIp.Text), port)
        Dim sendBytes As Byte()
        sendBytes = Encoding.ASCII.GetBytes(btn)
        udpClient.Send(sendBytes, sendBytes.Length)
    End Sub

    Private Sub btn1_Click(sender As Object, e As EventArgs) Handles btn1.Click
        isi(btn1)
        sendButton(1)
    End Sub

    Private Sub btn2_Click(sender As Object, e As EventArgs) Handles btn2.Click
        isi(btn2)
        'sendButton(2)
    End Sub

    Private Sub btn3_Click(sender As Object, e As EventArgs) Handles btn3.Click
        isi(btn3)
        'sendButton(3)
    End Sub

    Private Sub btn4_Click(sender As Object, e As EventArgs) Handles btn4.Click
        isi(btn4)
        'sendButton(4)
    End Sub

    Private Sub btn5_Click(sender As Object, e As EventArgs) Handles btn5.Click
        isi(btn5)
        'sendButton(5)
    End Sub

    Private Sub btn6_Click(sender As Object, e As EventArgs) Handles btn6.Click
        isi(btn6)
        'sendButton(6)
    End Sub

    Private Sub btn7_Click(sender As Object, e As EventArgs) Handles btn7.Click
        isi(btn7)
        'sendButton(7)
    End Sub

    Private Sub btn8_Click(sender As Object, e As EventArgs) Handles btn8.Click
        isi(btn8)
        'sendButton(8)
    End Sub

    Private Sub btn9_Click(sender As Object, e As EventArgs) Handles btn9.Click
        isi(btn9)
        'sendButton(9)
    End Sub
End Class