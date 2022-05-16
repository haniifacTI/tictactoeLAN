<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSetting
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSetting))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtIp = New System.Windows.Forms.TextBox()
        Me.btnConnect = New System.Windows.Forms.Button()
        Me.btnHost = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtPort = New System.Windows.Forms.TextBox()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(27, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(126, 20)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Connect To Game"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(29, 57)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(43, 20)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "IPv4 :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(197, 165)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(29, 20)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "OR"
        '
        'txtIp
        '
        Me.txtIp.Location = New System.Drawing.Point(64, 31)
        Me.txtIp.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtIp.Name = "txtIp"
        Me.txtIp.Size = New System.Drawing.Size(326, 27)
        Me.txtIp.TabIndex = 3
        '
        'btnConnect
        '
        Me.btnConnect.Location = New System.Drawing.Point(304, 73)
        Me.btnConnect.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnConnect.Name = "btnConnect"
        Me.btnConnect.Size = New System.Drawing.Size(86, 31)
        Me.btnConnect.TabIndex = 4
        Me.btnConnect.Text = "Connect"
        Me.btnConnect.UseVisualStyleBackColor = True
        '
        'btnHost
        '
        Me.btnHost.Location = New System.Drawing.Point(29, 196)
        Me.btnHost.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnHost.Name = "btnHost"
        Me.btnHost.Size = New System.Drawing.Size(374, 48)
        Me.btnHost.TabIndex = 5
        Me.btnHost.Text = "Host Game"
        Me.btnHost.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.txtPort)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.btnConnect)
        Me.Panel1.Controls.Add(Me.txtIp)
        Me.Panel1.Location = New System.Drawing.Point(12, 25)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(413, 127)
        Me.Panel1.TabIndex = 7
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(16, 78)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(42, 20)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Port :"
        '
        'txtPort
        '
        Me.txtPort.Location = New System.Drawing.Point(64, 75)
        Me.txtPort.Name = "txtPort"
        Me.txtPort.Size = New System.Drawing.Size(149, 27)
        Me.txtPort.TabIndex = 1
        '
        'frmSetting
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(437, 266)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnHost)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Panel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "frmSetting"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Main Menu"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents txtIp As TextBox
    Friend WithEvents btnConnect As Button
    Friend WithEvents btnHost As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents txtPort As TextBox
    Friend WithEvents Label4 As Label
End Class
