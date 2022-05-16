Imports System.Net
Imports System.Net.Sockets
Imports System.Text
Imports System.Threading
Public Class frmMain
    Public statusPemain As String
    Public giliran As String = "P1"

    Dim udpClient As UdpClient
    Public connect As Boolean = False
    Public ipConnect As String = "192.168.0.104"
    Public portConnect As String = "8080"

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
            lblStatus.Text = "Giliran P1"
            giliran = "P2"
        End If

        If statusPemain = "P2" Then
            btn.Text = "O"
            If cekWin("O") Then
                MsgBox("Player 2 Win!" & vbCrLf & "Play again?", MsgBoxStyle.YesNo, "Game Over")
                playAgain()
            ElseIf cekDraw() Then
                MsgBox("Draw" & vbCrLf & "Play again?", MsgBoxStyle.YesNo, "Game Over")
                playAgain()
            End If
            statusPemain = "P1"
            lblStatus.Text = "Giliran P2"
            Panel1.BackColor = Color.LimeGreen
        End If

        'disableBtn()
    End Sub
    Private Sub JoinOrHostGameToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles JoinOrHostGameToolStripMenuItem.Click
        frmSetting.Show()
    End Sub

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim thdUDPServer = New Thread(New ThreadStart(AddressOf serverThread))
        thdUDPServer.Start()

        If connect = True Then
            statusPemain = "P!"
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
            End Select

            UpdateListBox("From " & RemoteIpEndPoint.Address.ToString() + ":" &
           returnData.ToString())
        End While



        'If connect = False Then
        '    udpClient = New UdpClient(CInt(port))
        'End If
        'Dim nameBtnClicked As String = ""

        'While True
        '    Dim RemoteIpEndPoint As New IPEndPoint(IPAddress.Any, 0)
        '    Dim receiveBytes As Byte()
        '    Try
        '        receiveBytes = udpClient.Receive(RemoteIpEndPoint)
        '    Catch
        '        Continue While
        '    End Try
        '    Dim returnData As String = Encoding.ASCII.GetString(receiveBytes)
        '    nameBtnClicked = returnData
        '    UpdateListBox("From " & RemoteIpEndPoint.Address.ToString() + " : " & returnData.ToString())
        'End While

        'Dim btnClicked As Button = DirectCast(Controls(nameBtnClicked), Button)
        'enableBtn()
        'isi(btnClicked)
    End Sub

    Private Sub sendButton(btn As String) 'BUAT SEND
        Dim udpClient As New Sockets.UdpClient
        udpClient.Connect(IPAddress.Parse(ipConnect), Val(portConnect))
        Dim sendBytes As Byte()
        sendBytes = Encoding.ASCII.GetBytes(btn)
        udpClient.Send(sendBytes, sendBytes.Length)
    End Sub

    Private Sub btn1_Click(sender As Object, e As EventArgs) Handles btn1.Click
        isi(btn1)
        'sendButton(btn1)
        sendButton("btn1")
    End Sub

    Private Sub btn2_Click(sender As Object, e As EventArgs) Handles btn2.Click
        isi(btn2)
        'sendButton(btn2)
        sendButton("btn2")
    End Sub

    Private Sub btn3_Click(sender As Object, e As EventArgs) Handles btn3.Click
        isi(btn3)
        'sendButton(btn3)
        sendButton("btn3")
    End Sub

    Private Sub btn4_Click(sender As Object, e As EventArgs) Handles btn4.Click
        isi(btn4)
        'sendButton(btn4)
        sendButton("btn4")
    End Sub

    Private Sub btn5_Click(sender As Object, e As EventArgs) Handles btn5.Click
        isi(btn5)
        'sendButton(btn5)
        sendButton("btn5")
    End Sub

    Private Sub btn6_Click(sender As Object, e As EventArgs) Handles btn6.Click
        isi(btn6)
        'sendButton(btn6)
        sendButton("btn6")
    End Sub

    Private Sub btn7_Click(sender As Object, e As EventArgs) Handles btn7.Click
        isi(btn7)
        'sendButton(btn7)
        sendButton("btn7")
    End Sub

    Private Sub btn8_Click(sender As Object, e As EventArgs) Handles btn8.Click
        isi(btn8)
        'sendButton(btn8)
        sendButton("btn8")
    End Sub

    Private Sub btn9_Click(sender As Object, e As EventArgs) Handles btn9.Click
        isi(btn9)
        'sendButton(btn9)
        sendButton("btn9")
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

    Private Sub playAgain()
        If MsgBoxResult.Yes Then
            clear()
        ElseIf MsgBoxResult.No Then
            MsgBox("Thank You for playing our game",, "Tic Tac Toe")
            End
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
        btn1.Enabled = True
        btn2.Enabled = True
        btn3.Enabled = True
        btn4.Enabled = True
        btn5.Enabled = True
        btn6.Enabled = True
        btn7.Enabled = True
        btn8.Enabled = True
        btn9.Enabled = True
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