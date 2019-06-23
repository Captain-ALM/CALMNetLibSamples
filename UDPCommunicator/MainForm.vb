Imports captainalm.CALMNetLib
Imports System.Net
Imports System.Net.Sockets
Imports System.Threading
Imports captainalm.CALMNetLibSamples
Imports System.Windows.Forms

'
' Created by SharpDevelop.
' User: Alfred
' Date: 24/05/2019
' Time: 11:47
' 
' To change this template use Tools | Options | Coding | Edit Standard Headers.
'
Partial Public Class MainForm
    Dim drfrsh As Boolean = False
    Dim t_rf As Thread = Nothing
    Private slockrfresh As New Object()

    Public Sub New()
        ' The Me.InitializeComponent call is required for Windows Forms designer support.
        Me.InitializeComponent()

        '
        ' TODO : Add constructor code after InitializeComponents
        '
    End Sub

    Sub MainForm_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        configure()
        If t_rf Is Nothing Then
            t_rf = New Thread(AddressOf rf)
            t_rf.IsBackground = True
            t_rf.Start()
        End If
    End Sub

    Private Sub marshallError(ex As Exception)
        If Not Me.IsDisposed And Not Me.Disposing And Me.Visible Then
            Me.Invoke(Sub() MsgBox("An exception has been raised " & ex.GetType().ToString() & " " & ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Exception Raised"))
        End If
    End Sub

    Private Sub msgRec(msg As captainalm.CALMNetLibSamples.extlib.Message)
        Dim cr As Reg = New Reg(msg.senderIP, msg.senderPort) With {.pip = prip, .pport = prport}
        Dim e As Boolean = exists(cr)
        If Not e Then
            lstreg.add(cr.ID, cr)
        Else
            cr = lstreg(getname(cr))
        End If
        lstmsg.Add(New Mail(msg) With {.wassent = False, .refnum = 0, .sndnom = cr.ID, .disnom = cr.name})
        drfrsh = True
    End Sub

    Sub Butrset_Click(sender As Object, e As EventArgs) Handles butrset.Click
        If cmarshal IsNot Nothing Then
            RemoveHandler cmarshal.exceptionRaised, AddressOf marshallError
            RemoveHandler cmarshal.messageRecieved, AddressOf msgRec
            If cmarshal.ready Then cmarshal.close()
            cmarshal = Nothing
        End If
        If t_rf IsNot Nothing Then
            If t_rf.IsAlive Then
                t_rf.Abort()
            End If
            t_rf = Nothing
        End If
        If t_rf Is Nothing Then
            t_rf = New Thread(AddressOf rf)
            t_rf.IsBackground = True
            t_rf.Start()
        End If
        drfrsh = True
        configure()
    End Sub

    Sub Butscls_Click(sender As Object, e As EventArgs) Handles butscls.Click
        If cmarshal IsNot Nothing Then
            RemoveHandler cmarshal.exceptionRaised, AddressOf marshallError
            RemoveHandler cmarshal.messageRecieved, AddressOf msgRec
            If cmarshal.ready Then cmarshal.close()
            cmarshal = Nothing
        End If
        If t_rf IsNot Nothing Then If t_rf.IsAlive Then t_rf.Abort()
        Me.Close()
    End Sub

    Sub MainForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If cmarshal IsNot Nothing Then
            RemoveHandler cmarshal.exceptionRaised, AddressOf marshallError
            RemoveHandler cmarshal.messageRecieved, AddressOf msgRec
            If cmarshal.ready Then cmarshal.close()
            cmarshal = Nothing
        End If
        If t_rf IsNot Nothing Then If t_rf.IsAlive Then t_rf.Abort()
    End Sub

    Sub MainForm_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
    End Sub

    Sub Butcmadd_Click(sender As Object, e As EventArgs) Handles butcmadd.Click
        Dim frm As New avclient(avmode.New)
        If frm.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
            If Not lstreg.exists(frm.reg.ID) And Not exists(frm.reg) Then lstreg.add(frm.reg.ID, frm.reg)
            drfrsh = True
        End If
        If Not frm.Disposing And Not frm.IsDisposed Then frm.Dispose()
        frm = Nothing
    End Sub

    Sub Butcmrem_Click(sender As Object, e As EventArgs) Handles butcmrem.Click
        If lstvcm.SelectedIndices.Count > 0 Then
            Dim cop As List(Of String) = getst(lstvcm.SelectedItems)
            For Each nom As String In cop
                lstreg.Remove(nom)
            Next
            lstvcm.SelectedIndices.Clear()
            drfrsh = True
        End If
    End Sub

    Sub Butcmsm_Click(sender As Object, e As EventArgs) Handles butcmsm.Click
        Dim frm As New msgve(vemode.[New])
        If lstvcm.SelectedIndices.Count > 0 Then
            Dim cop As List(Of String) = getst(lstvcm.SelectedItems)
            For Each nom As String In cop
                frm.addrs.Add(lstreg(nom))
            Next
        End If
        If frm.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
            For Each msg As Mail In frm.genmsgs()
                msg.wassent = True
                lstmsg.Add(msg)
                cmarshal.sendMessage(msg.msg)
            Next
            drfrsh = True
        End If
        If Not frm.Disposing And Not frm.IsDisposed Then frm.Dispose()
        frm = Nothing
    End Sub

    Sub Butcmcls_Click(sender As Object, e As EventArgs) Handles butcmcls.Click
        lstvcm.SelectedIndices.Clear()
        lstreg.clear()
        drfrsh = True
    End Sub

    Sub Butmmprev_Click(sender As Object, e As EventArgs) Handles butmmprev.Click
        splitContainer2.Panel2Collapsed = False
        drfrsh = True
    End Sub

    Sub Butmmnew_Click(sender As Object, e As EventArgs) Handles butmmnew.Click
        Dim frm As msgve = Nothing
        If lstvmm.SelectedIndices.Count = 1 Then
            Dim smsg As Mail = lstmsg(lstvmm.SelectedIndices(0))
            frm = New msgve(vemode.Edit, smsg)
        Else
            frm = New msgve(vemode.[New])
        End If
        If frm.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
            For Each msg As Mail In frm.genmsgs()
                msg.wassent = True
                lstmsg.Add(msg)
                cmarshal.sendMessage(msg.msg)
            Next
            drfrsh = True
        End If
        If Not frm.Disposing And Not frm.IsDisposed Then frm.Dispose()
        frm = Nothing
    End Sub

    Sub Butmmdel_Click(sender As Object, e As EventArgs) Handles butmmdel.Click
        If lstvmm.SelectedIndices.Count > 0 Then
            Dim cop As List(Of Integer) = getsi(lstvmm.SelectedIndices)
            cop.Sort()
            cop.Reverse()
            For Each i As Integer In cop
                lstmsg.RemoveAt(i)
            Next
            lstvmm.SelectedIndices.Clear()
            drfrsh = True
        End If
    End Sub

    Sub Butmmcls_Click(sender As Object, e As EventArgs) Handles butmmcls.Click
        lstvmm.SelectedIndices.Clear()
        lstmsg.Clear()
        drfrsh = True
    End Sub

    Sub Butmpv_Click(sender As Object, e As EventArgs) Handles butmpv.Click
        If lstvmm.SelectedIndices.Count = 1 Then
            Dim smsg As Mail = lstmsg(lstvmm.SelectedIndices(0))
            Dim frm As New msgve(vemode.View, smsg)
            frm.ShowDialog(Me)
            If Not frm.Disposing And Not frm.IsDisposed Then frm.Dispose()
            frm = Nothing
        End If
    End Sub

    Sub Butmpech_Click(sender As Object, e As EventArgs) Handles butmpech.Click
        If lstvmm.SelectedIndices.Count = 1 Then
            Dim smsg As Mail = lstmsg(lstvmm.SelectedIndices(0))
            If smsg.wassent Then
                cmarshal.sendMessage(smsg.msg)
            Else
                Dim nmsg As Mail = New Mail(smsg.refnum, smsg.header, smsg.data)
                nmsg.recaddr = smsg.senderaddr
                nmsg.recport = smsg.senderport
                If lstreg.exists(smsg.sndnom) Then
                    nmsg.senderaddr = lstreg(smsg.sndnom).pip
                    nmsg.senderport = lstreg(smsg.sndnom).pport
                Else
                    nmsg.senderaddr = prip
                    nmsg.senderport = prport
                End If
                nmsg.wassent = True
                nmsg.sndnom = "Me"
                lstmsg.Add(nmsg)
                cmarshal.sendMessage(nmsg.msg)
            End If
        End If
    End Sub

    Sub Butmpdel_Click(sender As Object, e As EventArgs) Handles butmpdel.Click
        If lstvmm.SelectedIndices.Count > 0 Then
            Dim cop As List(Of Integer) = getsi(lstvmm.SelectedIndices)
            cop.Sort()
            cop.Reverse()
            For Each i As Integer In cop
                lstmsg.RemoveAt(i)
            Next
            lstvmm.SelectedIndices.Clear()
            drfrsh = True
        End If
    End Sub

    Sub Butmpclo_Click(sender As Object, e As EventArgs) Handles butmpclo.Click
        splitContainer2.Panel2Collapsed = True
        txtbxmpv.Text = ""
    End Sub

    Sub Lstvcm_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstvcm.SelectedIndexChanged
    End Sub

    Sub Lstvmm_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstvmm.SelectedIndexChanged
        If Not splitContainer2.Panel2Collapsed Then
            upprev()
        End If
    End Sub

    Private Sub butcmci_Click(sender As Object, e As EventArgs) Handles butcmci.Click
        If lstvcm.SelectedIndices.Count = 1 Then
            Dim frm As New avclient(avmode.View, lstreg(lstvcm.SelectedItems(0).Text))
            If frm.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                lstreg.Item(frm.reg.ID) = frm.reg
                drfrsh = True
            End If
            If Not frm.Disposing And Not frm.IsDisposed Then frm.Dispose()
            frm = Nothing
        End If
    End Sub

    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            If IO.File.Exists(execdir & "\description.txt") Then
                description = IO.File.ReadAllText(execdir & "\description.txt")
            Else
                description = ""
            End If
        Catch ex As IO.IOException
            description = ""
        End Try
        Try
            If IO.File.Exists(execdir & "\license.txt") Then
                license = IO.File.ReadAllText(execdir & "\license.txt")
            Else
                license = ""
            End If
        Catch ex As IO.IOException
            license = ""
        End Try
    End Sub

    Private Sub butabout_Click(sender As Object, e As EventArgs) Handles butabout.Click
        Dim frm As New AboutBx()
        frm.ShowDialog(Me)
        If Not frm.Disposing And Not frm.IsDisposed Then frm.Dispose()
        frm = Nothing
    End Sub
End Class