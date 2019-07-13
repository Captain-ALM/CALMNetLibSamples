Imports System.Net
Imports System.Windows.Forms

'
' Created by SharpDevelop.
' User: Alfred
' Date: 29/05/2019
' Time: 07:37
' 
' To change this template use Tools | Options | Coding | Edit Standard Headers.
'
Partial Public Class msgve
    Public msg As Mail = Nothing
    Public addrs As New List(Of Reg)
    Friend mode As vemode = vemode.None
    Friend dat As Byte() = Nothing

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
        msg = New Mail()
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
        If mode <> vemode.View Then
            txtbxfp.Enabled = False
            butbrw.Enabled = False
            If txtbxfp.Text = "" Then Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            If Not IO.File.Exists(txtbxfp.Text) Then
                MsgBox("File to Send Not Found.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly)
                Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            End If
            If Me.DialogResult = Windows.Forms.DialogResult.Cancel Then
                Me.Close()
            Else
                Try
                    dat = IO.File.ReadAllBytes(txtbxfp.Text)
                    If dat.Length > 16384 Then
                        MsgBox("File Bigger than 16384 Bytes!", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation)
                        Me.DialogResult = Windows.Forms.DialogResult.Cancel
                        Me.Close()
                    End If
                Catch ex As IO.IOException
                    Me.DialogResult = Windows.Forms.DialogResult.Cancel
                    Me.Close()
                End Try
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
                Me.Close()
            End If
        Else
            Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Me.Close()
        End If
    End Sub

    Sub Cancel_Button_Click(sender As Object, e As EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Sub Txtbxheader_TextChanged(sender As Object, e As EventArgs) Handles txtbxheader.TextChanged
        lblhl.Text = padnum(txtbxheader.Text.Length, 4) & " / 1024"
        If txtbxheader.Text.Length > 1024 Then txtbxheader.Text = txtbxheader.Text.Substring(0, 1024)
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
        For Each c As Reg In addrs
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
            txtbxheader.Enabled = True
            lblhl.Enabled = False
            txtbxheader.ReadOnly = True
            txtbxfp.Enabled = True
            txtbxfp.ReadOnly = True
            txtbxfp.Text = msg.locpth
            butbrw.Enabled = True
            butbrw.Text = "Open..."
            lblnoms.Text = "Sender:"
            txtbxheader.Text = msg.header
            Txtbxheader_TextChanged(Me, New EventArgs())
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
            txtbxheader.Enabled = True
            lblhl.Enabled = True
            txtbxheader.Text = msg.header
            txtbxfp.Enabled = True
            txtbxfp.Text = msg.locpth
            butbrw.Enabled = True
            butbrw.Text = "Browse..."
            If lstreg.exists(msg.sndnom) Then
                addrs.Add(lstreg(msg.sndnom))
            End If
        Else
            Me.Text = "Message Creator"
            lblt.Text = "Message Creator:"
            lblnoms.Text = "Receivers:"
            butrecadd.Enabled = True
            butrecrem.Enabled = True
            txtbxheader.Enabled = True
            lblhl.Enabled = True
            txtbxfp.Enabled = True
            butbrw.Enabled = True
            butbrw.Text = "Browse..."
        End If
        rfreshaddrs()
    End Sub

    Public Function genmsgs() As Mail()
        Dim msgs As New List(Of Mail)
        For Each c As Reg In addrs
            msgs.Add(New Mail(0, txtbxheader.Text, IO.Path.GetFileName(txtbxfp.Text), New Byte() {}, c.pip, c.pport, c.ip, c.port) With {.sndnom = "Me", .locpth = txtbxfp.Text})
        Next
        Return msgs.ToArray()
    End Function

    Public Function getfile() As Byte()
        Return dat
    End Function

    Private Sub butbrw_Click(sender As Object, e As EventArgs) Handles butbrw.Click
        If mode <> vemode.View Then
            Dim ofd As New OpenFileDialog()
            ofd.Title = "Select a File to Send:"
            ofd.Filter = "All Files (*.*)|*.*"
            ofd.Multiselect = False
            If txtbxfp.Text = "" Then ofd.InitialDirectory = execdir
            If IO.File.Exists(txtbxfp.Text) Then
                ofd.InitialDirectory = IO.Path.GetDirectoryName(txtbxfp.Text)
                ofd.FileName = txtbxfp.Text
            Else
                ofd.InitialDirectory = execdir
                ofd.FileName = ""
            End If
            If ofd.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                txtbxfp.Text = ofd.FileName
            End If
            ofd.Dispose()
            ofd = Nothing
        Else
            Try
                If IO.File.Exists(txtbxfp.Text) Then Diagnostics.Process.Start(txtbxfp.Text)
            Catch ex As IO.IOException
            Catch ex As System.ComponentModel.Win32Exception
            End Try
        End If
    End Sub
End Class

Friend Enum vemode As Integer
    None = 0
    View = 1
    Edit = 2
    [New] = 3
End Enum
