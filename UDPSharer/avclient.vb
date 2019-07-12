Imports System.Net
Imports System.Net.Sockets
Imports System.Windows.Forms

'
' Created by SharpDevelop.
' User: Alfred
' Date: 29/05/2019
' Time: 07:02
' 
' To change this template use Tools | Options | Coding | Edit Standard Headers.
'
Partial Public Class avclient
    Public reg As Reg
    Friend mode As avmode = avmode.None

    Public Sub New()
        ' The Me.InitializeComponent call is required for Windows Forms designer support.
        Me.InitializeComponent()

        '
        ' TODO : Add constructor code after InitializeComponents
        '
    End Sub

    Friend Sub New(m As avmode)
        Me.InitializeComponent()
        mode = m
    End Sub
    Friend Sub New(m As avmode, r As Reg)
        Me.InitializeComponent()
        mode = m
        reg = r
    End Sub

    Sub OK_Button_Click(sender As Object, e As EventArgs) Handles OK_Button.Click
        OK_Button.Enabled = False
        Cancel_Button.Enabled = False
        txtbxipaddress.Enabled = False
        nudport.Enabled = False
        txtbxripaddress.Enabled = False
        nudrport.Enabled = False
        txtbxnom.Enabled = False
        txtbxdsp.Enabled = False
        butbrw.Enabled = False
        Dim gok As Boolean = False
        Dim gok2 As Boolean = False
        Dim cip As Boolean = False
        Dim cip2 As Boolean = False
        Dim ip As IPAddress = IPAddress.None
        Dim port As Integer = 5432
        Dim ip2 As IPAddress = IPAddress.None
        Dim port2 As Integer = 5432
        Try
            ip = IPAddress.Parse(txtbxipaddress.Text)
            If ip.AddressFamily <> addrfam Then Throw New ArgumentException()
            gok = True
        Catch ex As InvalidCastException
            cip = True
        Catch ex As FormatException
            cip = True
        Catch ex As ArgumentException
            cip = True
        End Try
        If cip Then
            cip = False
            Try
                Dim ips As IPAddress() = Dns.GetHostAddresses(txtbxipaddress.Text)
                If ips Is Nothing Then Throw New ArgumentException()
                If ips.Length = 0 Then Throw New ArgumentException()
                For Each c As IPAddress In ips
                    If c.AddressFamily = addrfam Then
                        ip = c
                        gok = True
                        cip = False
                        Exit For
                    Else
                        cip = True
                        gok = False
                    End If
                Next
            Catch ex As ArgumentException
                cip = True
            Catch ex As SocketException
                cip = True
            End Try
        End If
        Try
            ip2 = IPAddress.Parse(txtbxripaddress.Text)
            If ip2.AddressFamily <> addrfam Then Throw New ArgumentException()
            gok2 = True
        Catch ex As InvalidCastException
            cip2 = True
        Catch ex As FormatException
            cip2 = True
        Catch ex As ArgumentException
            cip2 = True
        End Try
        If cip2 Then
            cip2 = False
            Try
                Dim ips As IPAddress() = Dns.GetHostAddresses(txtbxripaddress.Text)
                If ips Is Nothing Then Throw New ArgumentException()
                If ips.Length = 0 Then Throw New ArgumentException()
                For Each c As IPAddress In ips
                    If c.AddressFamily = addrfam Then
                        ip2 = c
                        gok2 = True
                        cip2 = False
                        Exit For
                    Else
                        cip2 = True
                        gok2 = False
                    End If
                Next
            Catch ex As ArgumentException
                cip2 = True
            Catch ex As SocketException
                cip2 = True
            End Try
        End If
        port = CInt(nudport.Value)
        If port > 65535 Then
            MsgBox("The Port you entered was too Big! The Port is now 65535.", MsgBoxStyle.Exclamation, "Information!")
            port = 65535
            nudport.Value = 65535
        End If
        If port < 1 Then
            MsgBox("The Port you entered was too Small! The Port is now 1.", MsgBoxStyle.Exclamation, "Information!")
            port = 1
            nudport.Value = 1
        End If
        port2 = CInt(nudrport.Value)
        If port2 > 65535 Then
            MsgBox("The Port you entered was too Big! The Port is now 65535.", MsgBoxStyle.Exclamation, "Information!")
            port2 = 65535
            nudrport.Value = 65535
        End If
        If port2 < 1 Then
            MsgBox("The Port you entered was too Small! The Port is now 1.", MsgBoxStyle.Exclamation, "Information!")
            port2 = 1
            nudrport.Value = 1
        End If
        If txtbxdsp.Text = "" Then txtbxdsp.Text = prpath
        If Not IO.Directory.Exists(txtbxdsp.Text) Then txtbxdsp.Text = prpath
        If gok And gok2 Then
            If txtbxnom.Text <> "" Then
                reg = New Reg(txtbxnom.Text, ip.ToString(), port) With {.pip = ip2.ToString(), .pport = port2, .ppath = txtbxdsp.Text}
                reg.ppath = txtbxdsp.Text
            Else
                reg = New Reg(ip.ToString(), port) With {.pip = ip2.ToString(), .pport = port2, .ppath = txtbxdsp.Text}
                reg.ppath = txtbxdsp.Text
            End If
            Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Me.Close()
        Else
            If cip Then
                If addrfam = AddressFamily.InterNetwork Then
                    txtbxipaddress.Text = IPAddress.None.ToString()
                ElseIf addrfam = AddressFamily.InterNetworkV6 Then
                    txtbxipaddress.Text = IPAddress.IPv6None.ToString()
                End If
            End If
            If cip2 Then
                txtbxripaddress.Text = prip
            End If
            OK_Button.Enabled = True
            Cancel_Button.Enabled = True
            txtbxipaddress.Enabled = True
            nudport.Enabled = True
            txtbxripaddress.Enabled = True
            nudrport.Enabled = True
            txtbxnom.Enabled = True
            txtbxdsp.Enabled = True
            butbrw.Enabled = True
        End If
    End Sub

    Sub Cancel_Button_Click(sender As Object, e As EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Sub Addclient_Load(sender As Object, e As EventArgs) Handles Me.Load
        OK_Button.Enabled = False
        Cancel_Button.Enabled = False
        txtbxipaddress.Enabled = False
        nudport.Enabled = False
        txtbxripaddress.Enabled = False
        nudrport.Enabled = False
        txtbxnom.Enabled = False
        txtbxdsp.Enabled = False
        butbrw.Enabled = False
        If mode = avmode.New Then
            Me.Text = "Add UDP Client"
            Label2.Text = "Add Client:"
            If addrfam = AddressFamily.InterNetwork Then
                txtbxipaddress.Text = IPAddress.None.ToString()
            ElseIf addrfam = AddressFamily.InterNetworkV6 Then
                txtbxipaddress.Text = IPAddress.IPv6None.ToString()
            End If
            nudport.Value = 5432
            txtbxripaddress.Text = prip
            nudrport.Value = prport
            txtbxipaddress.Enabled = True
            nudport.Enabled = True
            txtbxripaddress.Enabled = True
            nudrport.Enabled = True
            txtbxnom.Enabled = True
            OK_Button.Enabled = True
            Cancel_Button.Enabled = True
            txtbxdsp.Enabled = True
            butbrw.Enabled = True
            txtbxdsp.Text = prpath
        ElseIf mode = avmode.View Then
            Me.Text = "View UDP Client"
            Label2.Text = "View Client:"
            txtbxnom.Text = reg.ID
            txtbxipaddress.Text = reg.ip
            txtbxripaddress.Text = reg.pip
            nudport.Value = reg.port
            nudrport.Value = reg.pport
            txtbxipaddress.Enabled = True
            txtbxipaddress.ReadOnly = True
            nudport.ReadOnly = True
            nudport.Increment = 0
            nudport.Controls(0).Enabled = False
            nudport.Enabled = True
            txtbxripaddress.Enabled = True
            txtbxripaddress.ReadOnly = True
            nudrport.ReadOnly = True
            nudrport.Increment = 0
            nudrport.Controls(0).Enabled = False
            nudrport.Enabled = True
            txtbxnom.Enabled = True
            OK_Button.Enabled = True
            Cancel_Button.Enabled = True
            txtbxdsp.Enabled = True
            butbrw.Enabled = True
            txtbxdsp.Text = reg.ppath
        End If
    End Sub

    Private Sub butbrw_Click(sender As Object, e As EventArgs) Handles butbrw.Click
        Dim ofd As New FolderBrowserDialog()
        ofd.Description = "Select a default save Folder:"
        If txtbxdsp.Text = "" Then ofd.SelectedPath = prpath
        If IO.Directory.Exists(txtbxdsp.Text) Then ofd.SelectedPath = txtbxdsp.Text Else ofd.SelectedPath = prpath
        ofd.ShowNewFolderButton = True
        If ofd.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
            txtbxdsp.Text = ofd.SelectedPath
        End If
        ofd.Dispose()
        ofd = Nothing
    End Sub
End Class

Friend Enum avmode As Integer
    None = 0
    View = 1
    [New] = 2
End Enum
