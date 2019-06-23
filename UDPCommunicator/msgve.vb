Imports System.Net
'
' Created by SharpDevelop.
' User: Alfred
' Date: 29/05/2019
' Time: 07:37
' 
' To change this template use Tools | Options | Coding | Edit Standard Headers.
'
Public Partial Class msgve
    Public msg As Mail = Nothing
    Public addrs As New List(Of Reg)
    Friend mode As vemode = vemode.None

    Public Sub New()
        ' The Me.InitializeComponent call is required for Windows Forms designer support.
        Me.InitializeComponent()

        '
        ' TODO : Add constructor code after InitializeComponents
        '
    End Sub
    Friend Sub New(m As vemode)
        Me.InitializeComponent()
        mode = m
        msg = New mail()
    End Sub
    Friend Sub New(m1 As vemode, m2 As Mail)
        Me.InitializeComponent()
        mode = m1
        msg = m2
    End Sub
    Friend Sub New(m As vemode, paddr As List(Of Reg))
        Me.InitializeComponent()
        mode = m
        addrs.AddRange(paddr)
    End Sub

    Sub OK_Button_Click(sender As Object, e As EventArgs) Handles OK_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Ok
        Me.Close()
    End Sub

    Sub Cancel_Button_Click(sender As Object, e As EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Sub Txtbxheader_TextChanged(sender As Object, e As EventArgs) Handles txtbxheader.TextChanged
        lblhl.Text = padnum(txtbxheader.Text.Length, 4) & " / 1024"
        If txtbxheader.Text.Length > 1024 Then txtbxheader.Text = txtbxheader.Text.Substring(0, 1024)
    End Sub

    Sub Txtbxdat_TextChanged(sender As Object, e As EventArgs) Handles txtbxdat.TextChanged
        lbldl.Text = padnum(txtbxdat.Text.Length, 5) & " / 16384"
        If txtbxdat.Text.Length > 16384 Then txtbxdat.Text = txtbxdat.Text.Substring(0, 16384)
    End Sub

    Private Function padnum(num As Integer, len As Integer) As String
        Dim str As String = num.ToString()
        If str.Length < len Then
            While str.Length < len
                str = " " & str
            End While
        End If
        Return str
    End Function

    Sub Butrecadd_Click(sender As Object, e As EventArgs) Handles butrecadd.Click
        Dim frm As New addrec()
        If frm.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
            If Not addrs.Contains(frm.sreg) Then addrs.Add(frm.sreg)
        End If
        If Not frm.Disposing And Not frm.IsDisposed Then frm.Dispose()
        frm = Nothing
        rfreshaddrs()
    End Sub

    Sub Butrecrem_Click(sender As Object, e As EventArgs) Handles butrecrem.Click
        addrs.RemoveAll(New Predicate(Of Reg)(Function(x As Reg) As Boolean
                                                  Return (x.name & " <" & x.ID & ">") = CStr(dudrap.Items(dudrap.SelectedIndex))
                                              End Function))
        rfreshaddrs()
    End Sub

    Friend Sub rfreshaddrs()
        dudrap.Items.Clear()
        dudrap.Text = ""
        For Each c As reg In addrs
            dudrap.Items.Add(c.name & " <" & c.ID & ">")
        Next
        If dudrap.Items.Count > 0 Then dudrap.SelectedIndex = 0 Else dudrap.SelectedIndex = -1
    End Sub

    Sub Msgve_Load(sender As Object, e As EventArgs) Handles Me.Load
        If mode = vemode.View Then
            Me.Text = "Message Viewer"
            lblt.Text = "Message Viewer:"
            butrecadd.Enabled = False
            butrecrem.Enabled = False
            txtbxdat.Enabled = True
            txtbxheader.Enabled = True
            lblhl.Enabled = False
            lbldl.Enabled = False
            txtbxdat.ReadOnly = True
            txtbxheader.ReadOnly = True
            lblnoms.Text = "Sender:"
            txtbxheader.Text = msg.header
            Txtbxheader_TextChanged(Me, New EventArgs())
            txtbxdat.Text = msg.data
            Txtbxdat_TextChanged(Me, New EventArgs())
            If lstreg.exists(msg.sndnom) Then
                addrs.Add(lstreg(msg.sndnom))
            Else
                addrs.Add(New Reg(msg.senderaddr, msg.senderport))
            End If
        ElseIf mode = vemode.Edit Then
            Me.Text = "Message Editor"
            lblt.Text = "Message Editor:"
            lblnoms.Text = "Receivers:"
            butrecadd.Enabled = True
            butrecrem.Enabled = True
            txtbxdat.Enabled = True
            txtbxheader.Enabled = True
            lblhl.Enabled = True
            lbldl.Enabled = True
            txtbxheader.Text = msg.header
            txtbxdat.Text = msg.data
            If lstreg.exists(msg.sndnom) Then
                addrs.Add(lstreg(msg.sndnom))
            Else
                addrs.Add(New Reg(msg.senderaddr, msg.senderport))
            End If
        Else
            Me.Text = "Message Creator"
            lblt.Text = "Message Creator:"
            lblnoms.Text = "Receivers:"
            butrecadd.Enabled = True
            butrecrem.Enabled = True
            txtbxdat.Enabled = True
            txtbxheader.Enabled = True
            lblhl.Enabled = True
            lbldl.Enabled = True
        End If
        rfreshaddrs()
    End Sub

    Public Function genmsgs() As Mail()
        Dim msgs As New List(Of mail)
        For Each c As Reg In addrs
            msgs.Add(New Mail(0, txtbxheader.Text, txtbxdat.Text, c.pip, c.pport, c.ip.ToString(), c.port) With {.sndnom = "Me"})
        Next
        Return msgs.ToArray()
    End Function
End Class

Friend Enum vemode As Integer
	None = 0
	View = 1
	Edit = 2
	[New] = 3
End Enum
