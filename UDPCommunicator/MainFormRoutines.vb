Imports captainalm.CALMNetLib
Imports System.Net
Imports System.Net.Sockets
Imports System.Threading
Imports captainalm.CALMNetLibSamples
Imports System.Windows.Forms

'
' Created by SharpDevelop.
' User: Alfred
' Date: 08/06/2019
' Time: 10:33
' 
' To change this template use Tools | Options | Coding | Edit Standard Headers.
'

Partial Public Class MainForm
    Private Sub rfresh()
        If Me.InvokeRequired Then
            Me.Invoke(Sub() rfresh())
        Else
            SyncLock slockrfresh
                upinfo()
                uplstvcm()
                uplstvmm()
                upprev()
                If cmarshal Is Nothing Then
                    lblstatus.Text = ""
                Else
                    If cmarshal.ready Then
                        lblstatus.Text = "Listening."
                    Else
                        lblstatus.Text = "Not Listening."
                    End If
                End If
            End SyncLock
        End If
    End Sub

    Private Sub configure()
        Dim frm As New config()
        If frm.ShowDialog(Me) = DialogResult.OK Then
            lip = New List(Of String)
            Dim col As Dictionary(Of String, IPAddress) = frm.getNetworkAdapterIPsAndNames()
            If frm.selected_interface.ToString() = IPAddress.Any.ToString() Then
                For Each ip As IPAddress In col.Values
                    If ip.AddressFamily = AddressFamily.InterNetwork Then
                        lip.Add(ip.ToString())
                    End If
                Next
            ElseIf frm.selected_interface.ToString() = IPAddress.IPv6Any.ToString() Then
                For Each ip As IPAddress In col.Values
                    If ip.AddressFamily = AddressFamily.InterNetworkV6 Then
                        lip.Add(ip.ToString())
                    End If
                Next
            Else
                lip.Add(frm.selected_interface.ToString())
            End If
            lport = frm.port
            cmarshal = New extlib.NetMarshalUDP(frm.selected_interface, frm.port)
            addrfam = frm.selected_interface.AddressFamily
            drfrsh = True
        End If
        If Not frm.Disposing And Not frm.IsDisposed Then frm.Dispose()
        frm = Nothing
        If cmarshal Is Nothing Then Environment.Exit(1)
        AddHandler cmarshal.exceptionRaised, AddressOf marshallError
        AddHandler cmarshal.messageRecieved, AddressOf msgRec
        cmarshal.start()
    End Sub

    Private slockupprev As New Object()
    Private Sub upprev()
        SyncLock slockupprev
            txtbxmpv.Text = ""
            If lstvmm.SelectedIndices.Count = 1 Then
                Try
                    Dim smsg As Mail = lstmsg(lstvmm.SelectedIndices(0))
                    If smsg.wassent Then
                        txtbxmpv.Text &= "Reciver: " & smsg.recaddr & ":" & smsg.recport & Chr(13) & Chr(10)
                        txtbxmpv.Text &= "Header: " & Chr(13) & Chr(10)
                        txtbxmpv.Text &= smsg.header & Chr(13) & Chr(10)
                        txtbxmpv.Text &= "Message: " & Chr(13) & Chr(10)
                        txtbxmpv.Text &= smsg.data & Chr(13) & Chr(10)
                    Else
                        txtbxmpv.Text &= "Sender: " & smsg.senderaddr & ":" & smsg.senderport & Chr(13) & Chr(10)
                        txtbxmpv.Text &= "Header: " & Chr(13) & Chr(10)
                        txtbxmpv.Text &= smsg.header & Chr(13) & Chr(10)
                        txtbxmpv.Text &= "Message: " & Chr(13) & Chr(10)
                        txtbxmpv.Text &= smsg.data & Chr(13) & Chr(10)
                    End If
                Catch ex As ArgumentOutOfRangeException
                    drfrsh = True
                End Try
            ElseIf lstvmm.SelectedIndices.Count > 0 Then
                Dim smc As Integer = 0
                Dim rmc As Integer = 0
                For Each i As Integer In lstvmm.SelectedIndices
                    Try
                        Dim smsg As Mail = lstmsg(i)
                        If smsg.wassent Then
                            smc += 1
                        Else
                            rmc += 1
                        End If
                    Catch ex As ArgumentOutOfRangeException
                        drfrsh = True
                    End Try
                Next
                txtbxmpv.Text &= "Selected: " & Chr(13) & Chr(10)
                If smc > 0 Then txtbxmpv.Text &= smc & " sent messages." & Chr(13) & Chr(10)
                If rmc > 0 Then txtbxmpv.Text &= rmc & " received messages." & Chr(13) & Chr(10)
            End If
        End SyncLock
    End Sub

    Private Sub upinfo()
        Dim si As Integer = dudla.SelectedIndex
        dudla.Items.Clear()
        dudla.Items.AddRange(lip)
        If si < dudla.Items.Count And si >= -1 Then dudla.SelectedIndex = si
        If si = -1 And dudla.Items.Count > 0 Then dudla.SelectedIndex = 0
        txtbxlp.Text = CStr(lport)
    End Sub
    Dim slockregen As New Object()
    Private Sub uplstvcm()
        Dim si As List(Of Integer) = getsi(lstvcm.SelectedIndices)
        lstvcm.SelectedIndices.Clear()
        lstvcm.Items.Clear()
        SyncLock slockregen
            For Each c As Reg In lstreg.Values
                Dim lvi As New ListViewItem(c.name)
                lvi.SubItems.Add(c.ip.ToString())
                lvi.SubItems.Add(c.port)
                lvi.SubItems.Add(c.pip)
                lvi.SubItems.Add(c.port)
                lstvcm.Items.Add(lvi)
            Next
        End SyncLock
        For Each i As Integer In si
            If i < lstvcm.Items.Count And i >= 0 Then lstvcm.SelectedIndices.Add(i)
        Next
    End Sub

    Private Sub uplstvmm()
        Dim si As List(Of Integer) = getsi(lstvmm.SelectedIndices)
        lstvmm.SelectedIndices.Clear()
        lstvmm.Items.Clear()
        For Each c As Mail In lstmsg
            Dim lvi As ListViewItem = Nothing
            If c.wassent Then
                lvi = New ListViewItem("<Me>")
            Else
                lvi = New ListViewItem("<" & c.sndnom & ">")
            End If
            lvi.SubItems.Add(c.recaddr)
            lvi.SubItems.Add(c.recport)
            If c.header.Length > 259 Then lvi.SubItems.Add(c.header.Substring(0, 256) & "...") Else lvi.SubItems.Add(c.header)
            lstvmm.Items.Add(lvi)
        Next
        For Each i As Integer In si
            If i < lstvmm.Items.Count And i >= 0 Then lstvmm.SelectedIndices.Add(i)
        Next
    End Sub
    Private slockgs As New Object()
    Private Function getsi(sic As ListView.SelectedIndexCollection) As List(Of Integer)
        Dim toret As New List(Of Integer)
        SyncLock slockgs
            For i As Integer = 0 To sic.Count - 1 Step 1
                toret.Add(sic(i))
            Next
        End SyncLock
        Return toret
    End Function
    Private Function getst(stc As ListView.SelectedListViewItemCollection) As List(Of String)
        Dim toret As New List(Of String)
        SyncLock slockgs
            For i As Integer = 0 To stc.Count - 1 Step 1
                toret.Add(stc(i).Text)
            Next
        End SyncLock
        Return toret
    End Function
    Private Function exists(r As Reg) As Boolean
        SyncLock slockregen
            For Each c As Reg In lstreg.Values
                If r.ip = c.ip And r.port = c.port Then Return True
            Next
        End SyncLock
        Return False
    End Function
    Private Function getname(r As Reg) As String
        SyncLock slockregen
            For Each c As String In lstreg.Keys
                Dim c2 As Reg = lstreg(c)
                If r.ip = c2.ip And r.port = c2.port Then Return c
            Next
        End SyncLock
        Return False
    End Function
    Private Sub rf()
        While True
            If drfrsh Then
                drfrsh = False
                rfresh()
            Else
                Thread.Sleep(100)
            End If
        End While
    End Sub
End Class