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
    Private thrd As Boolean = False
    Private Sub rfresh()
        If Me.InvokeRequired Then
            Me.Invoke(Sub() rfresh())
        Else
            SyncLock slockrfresh
                Try
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
                Catch ex As Exception
                    If Not Me.IsDisposed And Not Me.Disposing And Me.Visible Then
                        MsgBox("An exception has been raised " & ex.GetType().ToString() & " " & ex.Message & Chr(13) & Chr(10) & ex.StackTrace, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Exception Raised")
                    End If
                End Try
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
            cmarshal = New extlib.NetMarshalTCPBi(frm.selected_interface, frm.port, frm.backlog, frm.buffer)
            addrfam = frm.selected_interface.AddressFamily
            drfrsh = True
        End If
        If Not frm.Disposing And Not frm.IsDisposed Then frm.Dispose()
        frm = Nothing
        If cmarshal Is Nothing Then Environment.Exit(1)
        AddHandler cmarshal.exceptionRaised, AddressOf marshallError
        AddHandler cmarshal.messageRecieved, AddressOf msgRec
        AddHandler cmarshal.clientConnected, AddressOf clCon
        AddHandler cmarshal.clientDisconnected, AddressOf clDCon
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
                        txtbxmpv.Text &= "File Name: " & Chr(13) & Chr(10)
                        txtbxmpv.Text &= smsg.name & Chr(13) & Chr(10)
                    Else
                        txtbxmpv.Text &= "Sender: " & smsg.senderaddr & ":" & smsg.senderport & Chr(13) & Chr(10)
                        txtbxmpv.Text &= "Header: " & Chr(13) & Chr(10)
                        txtbxmpv.Text &= smsg.header & Chr(13) & Chr(10)
                        txtbxmpv.Text &= "File Name: " & Chr(13) & Chr(10)
                        txtbxmpv.Text &= smsg.name & Chr(13) & Chr(10)
                    End If
                Catch ex As Exception When (TypeOf ex Is ArgumentOutOfRangeException Or TypeOf ex Is IndexOutOfRangeException)
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
                    Catch ex As Exception When (TypeOf ex Is ArgumentOutOfRangeException Or TypeOf ex Is IndexOutOfRangeException)
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
        Dim rtr As New List(Of String)
        SyncLock slockregen
            For Each c As Reg In lstreg.getValues()
                If Not cmarshal.connected(c.ip, c.port) Then
                    rtr.Add(c.ID)
                Else
                    Dim lvi As New ListViewItem(c.ID)
                    lvi.SubItems.Add(c.name)
                    lvi.SubItems.Add(c.ip)
                    lvi.SubItems.Add(c.port)
                    lstvcm.Items.Add(lvi)
                End If
            Next
        End SyncLock
        For Each c As String In rtr
            lstreg.remove(c)
        Next
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
                lvi = New ListViewItem("<" & c.disnom & ">")
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
            For Each c As Reg In lstreg.getValues()
                If r.ip = c.ip And r.port = c.port Then Return True
            Next
        End SyncLock
        Return False
    End Function
    Private Function getname(r As Reg) As String
        SyncLock slockregen
            For Each c As String In lstreg.getIDs()
                Dim c2 As Reg = lstreg(c)
                If r.ip = c2.ip And r.port = c2.port Then Return c
            Next
        End SyncLock
        Return False
    End Function
    Private Sub rf()
        While thrd
            If drfrsh Then
                drfrsh = False
                rfresh()
            Else
                Thread.Sleep(125)
            End If
        End While
    End Sub
End Class