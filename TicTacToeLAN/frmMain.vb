Imports System.Net
Imports System.Net.Sockets
Imports System.Text
Imports System.Threading
Public Class frmMain
    Public statusPemain As String = "P1"
    'Public giliran As String = "P1"
    Dim udpClient As UdpClient
    Public connect As Boolean = False
    'ip client / P2
    Public ipConnect As String
    Public portConnect As String
    'Public portConnect As String = "8080"

    Sub isi(btn As Button)
        If btn.Text <> "" Then Exit Sub

        If statusPemain = "P1" Then
            btn.Text = "X"
            statusPemain = "P2"
            lblStatus.Text = "Giliran P2"
            Panel1.BackColor = Color.Red
            If cekWin("X") Then
                playAgain("Player 1 Win!" & vbCrLf & "Play again?")
            ElseIf cekDraw() Then
                playAgain("Draw" & vbCrLf & "Play again?")
            End If

        ElseIf statusPemain = "P2" Then
            btn.Text = "O"
            statusPemain = "P1"
            lblStatus.Text = "Giliran P1"
            Panel1.BackColor = Color.LimeGreen
            If cekWin("O") Then
                playAgain("Player 2 Win!" & vbCrLf & "Play again?")
            ElseIf cekDraw() Then
                playAgain("Draw" & vbCrLf & "Play again?")
            End If
        End If

        disableBtn()
    End Sub
    Private Sub JoinOrHostGameToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles JoinOrHostGameToolStripMenuItem.Click
        frmSetting.Show()
    End Sub

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim thdUDPServer = New Thread(New ThreadStart(AddressOf serverThread))
        thdUDPServer.Start()

        If connect = True Then
            lblStatus.Text = "Giliran Lawan"
            Panel1.BackColor = Color.Red
            'disableBtn()
        End If
    End Sub

    Private Sub UpdateListBox(ByVal teks As String)
        If Me.InvokeRequired Then
            Dim args() As String = {teks}
            Me.Invoke(New Action(Of String)(AddressOf UpdateListBox), args)
            lbHasil.Items.Add(teks)
        End If
    End Sub

    Public Sub serverThread() 'BUAT RECIEVE
        Dim udpClient As New UdpClient(CInt(portConnect))
        While True
            Dim RemoteIpEndPoint As New IPEndPoint(IPAddress.Any, 0)
            Dim receiveBytes As Byte()
            receiveBytes = udpClient.Receive(RemoteIpEndPoint)
            Dim returnData As String = Encoding.ASCII.GetString(receiveBytes)
            Select Case returnData
                Case "btn1"
                    isi(btn1)
                Case "btn2"
                    isi(btn2)
                Case "btn3"
                    isi(btn3)
                Case "btn4"
                    isi(btn4)
                Case "btn5"
                    isi(btn5)
                Case "btn6"
                    isi(btn6)
                Case "btn7"
                    isi(btn7)
                Case "btn8"
                    isi(btn8)
                Case "btn9"
                    isi(btn9)
                Case Else
                    ipConnect = returnData
                    enableBtn()
            End Select
            enableBtn()
            UpdateListBox("From " & RemoteIpEndPoint.Address.ToString() + ":" &
           returnData.ToString())
        End While
    End Sub

    Private Sub sendButton(btn As String) 'BUAT SEND
        Dim udpClient As New Sockets.UdpClient
        udpClient.Connect(IPAddress.Parse(ipConnect), Val(portConnect))
        Dim sendBytes As Byte()
        sendBytes = Encoding.ASCII.GetBytes(btn)
        udpClient.Send(sendBytes, sendBytes.Length)
    End Sub

    Private Sub btn1_Click(sender As Object, e As EventArgs) Handles btn1.Click
        sendButton("btn1")
        isi(btn1)
    End Sub

    Private Sub btn2_Click(sender As Object, e As EventArgs) Handles btn2.Click
        sendButton("btn2")
        isi(btn2)
    End Sub

    Private Sub btn3_Click(sender As Object, e As EventArgs) Handles btn3.Click
        sendButton("btn3")
        isi(btn3)
    End Sub

    Private Sub btn4_Click(sender As Object, e As EventArgs) Handles btn4.Click
        sendButton("btn4")
        isi(btn4)
    End Sub

    Private Sub btn5_Click(sender As Object, e As EventArgs) Handles btn5.Click
        sendButton("btn5")
        isi(btn5)
    End Sub

    Private Sub btn6_Click(sender As Object, e As EventArgs) Handles btn6.Click
        sendButton("btn6")
        isi(btn6)
    End Sub

    Private Sub btn7_Click(sender As Object, e As EventArgs) Handles btn7.Click
        sendButton("btn7")
        isi(btn7)
    End Sub

    Private Sub btn8_Click(sender As Object, e As EventArgs) Handles btn8.Click
        sendButton("btn8")
        isi(btn8)
    End Sub

    Private Sub btn9_Click(sender As Object, e As EventArgs) Handles btn9.Click
        sendButton("btn9")
        isi(btn9)
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

    Private Sub playAgain(resultGame As String)
        Dim result As DialogResult = MessageBox.Show(resultGame, "Tic Tac Toe", MessageBoxButtons.YesNo)
        If result = DialogResult.No Then
            End
        ElseIf result = DialogResult.Yes Then
            clear()
            statusPemain = "P1"
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

    Private Sub enableBtn()
        If btn1.Text = "" Then
            btn1.Enabled = True
        End If
        If btn2.Text = "" Then
            btn2.Enabled = True
        End If
        If btn3.Text = "" Then
            btn3.Enabled = True
        End If
        If btn4.Text = "" Then
            btn4.Enabled = True
        End If
        If btn5.Text = "" Then
            btn5.Enabled = True
        End If
        If btn6.Text = "" Then
            btn6.Enabled = True
        End If
        If btn7.Text = "" Then
            btn7.Enabled = True
        End If
        If btn8.Text = "" Then
            btn8.Enabled = True
        End If
        If btn9.Text = "" Then
            btn9.Enabled = True
        End If
    End Sub

    Private Sub disableBtn()
        btn1.Enabled = False
        btn2.Enabled = False
        btn3.Enabled = False
        btn4.Enabled = False
        btn5.Enabled = False
        btn6.Enabled = False
        btn7.Enabled = False
        btn8.Enabled = False
        btn9.Enabled = False
    End Sub

    Private Sub frmMain_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        End
    End Sub
End Class