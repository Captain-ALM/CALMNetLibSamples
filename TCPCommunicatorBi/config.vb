Imports System.Windows.Forms
Imports System.Net
Imports System.Net.NetworkInformation
Imports System.Net.Sockets

Public Class config
    Public selected_interface As IPAddress = IPAddress.Any
    Public port As Integer = 5432
    Public buffer As Boolean = True
    Public interfaces As Dictionary(Of String, IPAddress)
    Public backlog As Integer = 1

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        combbxif.Enabled = False
        nudport.Enabled = False
        nudrport.Enabled = False
        nudbl.Enabled = False
        chkbxbf.Enabled = False
        selected_interface = interfaces(combbxif.SelectedItem.ToString)
        port = CInt(nudport.Value)
        buffer = chkbxbf.Checked
        backlog = CInt(nudbl.Value)
        If port > 65535 Then
            MsgBox("The Port you entered was too Big! The Port is now 65535.", MsgBoxStyle.Exclamation, "Information!")
            port = 65535
        End If
        If port < 1 Then
            MsgBox("The Port you entered was too Small! The Port is now 1.", MsgBoxStyle.Exclamation, "Information!")
            port = 1
        End If
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub config_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        combbxif.Enabled = False
        nudport.Enabled = False
        nudrport.Enabled = False
        chkbxbf.Enabled = False
        nudbl.Enabled = False
        interfaces = getNetworkAdapterIPsAndNames()
        interfaces.Add("Listen on All Interfaces : 0.0.0.0", IPAddress.Any)
        interfaces.Add("Listen on All Interfaces : ::", IPAddress.IPv6Any)
        nudport.Value = 5432
        nudrport.Value = 5432
        nudbl.Value = 1
        txtbxripaddress.Text = ""
        For Each current As String In interfaces.Keys
            combbxif.Items.Add(current)
        Next
        combbxif.SelectedItem = "Listen on All Interfaces : 0.0.0.0"
        chkbxbf.Checked = True
        combbxif.Enabled = True
        nudport.Enabled = True
        nudrport.Enabled = False
        txtbxripaddress.Enabled = False
        chkbxbf.Enabled = True
        nudbl.Enabled = True
    End Sub
    
    Friend Function getNetworkAdapterIPsAndNames() As Dictionary(Of String, IPAddress)
        Dim list As New Dictionary(Of String, IPAddress)
        Dim allNetworkInterfaces As NetworkInterface() = NetworkInterface.GetAllNetworkInterfaces()
        For i As Integer = 0 To allNetworkInterfaces.Length - 1
            Dim networkInterface As NetworkInterface = allNetworkInterfaces(i)
            If networkInterface.OperationalStatus = OperationalStatus.Up Then
                For Each current As UnicastIPAddressInformation In networkInterface.GetIPProperties().UnicastAddresses
                    If current.Address.AddressFamily = AddressFamily.InterNetwork Or current.Address.AddressFamily = AddressFamily.InterNetworkV6 Then
                        list.Add(networkInterface.Name & " : " & current.Address.ToString, current.Address)
                    End If
                Next
            End If
        Next
        Return list
    End Function
End Class
