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
            thrd = True
            t_rf.Start()
        End If
    End Sub

    Private Sub marshallError(ex As Exception)
        If Not Me.IsDisposed And Not Me.Disposing And Me.Visible Then
            Me.Invoke(Sub() MsgBox("An exception has been raised " & ex.GetType().ToString() & " " & ex.Message & Chr(13) & Chr(10) & ex.StackTrace, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Exception Raised"))
        End If
    End Sub

    Private Sub msgRec(msg As captainalm.CALMNetLibSamples.extlib.IMessage)
        Dim cr As Reg = New Reg(msg.senderIP, msg.senderPort)
        Dim e As Boolean = exists(cr)
        If Not e Then
            lstreg.add(cr.ID, cr)
        Else
            cr = lstreg(getname(cr))
        End If
        Try
            IO.File.WriteAllBytes(cr.ppath & "\" & CType(msg, FileMsg).name, CType(msg, FileMsg).bytes)
        Catch ex As IO.IOException
        End Try
        lstmsg.Add(New Mail(msg) With {.wassent = False, .refnum = 0, .sndnom = cr.ID, .disnom = cr.name, .locpth = cr.ppath & "\" & CType(msg, FileMsg).name, .data = New Byte() {}})
        drfrsh = True
    End Sub

    Private Sub clCon(ip As String, port As Integer)
        Dim cr As Reg = New Reg(ip, port)
        Dim e As Boolean = exists(cr)
        If Not e Then
            lstreg.Add(cr.id, cr)
            drfrsh = True
        End If
    End Sub

    Private Sub clDCon(ip As String, port As Integer)
        Dim cr As Reg = New Reg(ip, port)
        Dim e As Boolean = exists(cr)
        If e Then
            Dim nom As String = getname(cr)
            lstreg.Remove(nom)
            drfrsh = True
        End If
    End Sub

    Sub Butrset_Click(sender As Object, e As EventArgs) Handles butrset.Click
        If cmarshal IsNot Nothing Then
            RemoveHandler cmarshal.exceptionRaised, AddressOf marshallError
            RemoveHandler cmarshal.messageRecieved, AddressOf msgRec
            RemoveHandler cmarshal.clientConnected, AddressOf clCon
            RemoveHandler cmarshal.clientDisconnected, AddressOf clDCon
            If cmarshal.ready Then cmarshal.close()
            cmarshal = Nothing
        End If
        If t_rf IsNot Nothing Then
            If t_rf.IsAlive Then
                thrd = False
                If t_rf.IsAlive Then t_rf.Join(500)
                If t_rf.IsAlive Then t_rf.Abort()
            End If
            t_rf = Nothing
        End If
        configure()
        Dim vals As Reg() = lstreg.getValues()
        For Each c As Reg In vals
            If cmarshal IsNot Nothing Then cmarshal.connect(c.ip, c.port)
        Next
        If t_rf Is Nothing Then
            t_rf = New Thread(AddressOf rf)
            t_rf.IsBackground = True
            thrd = True
            t_rf.Start()
        End If
        drfrsh = True
    End Sub

    Sub Butscls_Click(sender As Object, e As EventArgs) Handles butscls.Click
        If cmarshal IsNot Nothing Then
            RemoveHandler cmarshal.exceptionRaised, AddressOf marshallError
            RemoveHandler cmarshal.messageRecieved, AddressOf msgRec
            RemoveHandler cmarshal.clientConnected, AddressOf clCon
            RemoveHandler cmarshal.clientDisconnected, AddressOf clDCon
            If cmarshal.ready Then cmarshal.close()
            cmarshal = Nothing
        End If
        If t_rf IsNot Nothing Then
            thrd = False
            If t_rf.IsAlive Then t_rf.Join(500)
            If t_rf.IsAlive Then t_rf.Abort()
            t_rf = Nothing
        End If
        Me.Close()
    End Sub

    Sub MainForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If cmarshal IsNot Nothing Then
            RemoveHandler cmarshal.exceptionRaised, AddressOf marshallError
            RemoveHandler cmarshal.messageRecieved, AddressOf msgRec
            RemoveHandler cmarshal.clientConnected, AddressOf clCon
            RemoveHandler cmarshal.clientDisconnected, AddressOf clDCon
            If cmarshal.ready Then cmarshal.close()
            cmarshal = Nothing
        End If
        If t_rf IsNot Nothing Then
            thrd = False
            If t_rf.IsAlive Then t_rf.Join(500)
            If t_rf.IsAlive Then t_rf.Abort()
            t_rf = Nothing
        End If
    End Sub

    Sub MainForm_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
    End Sub

    Sub Butcmadd_Click(sender As Object, e As EventArgs) Handles butcmadd.Click
        Dim frm As New avclient(avmode.New)
        If frm.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
            If Not lstreg.exists(frm.reg.ID) And Not exists(frm.reg) Then
                lstreg.add(frm.reg.ID, frm.reg)
                cmarshal.connect(frm.reg.ip, frm.reg.port)
            End If
            drfrsh = True
        End If
        If Not frm.Disposing And Not frm.IsDisposed Then frm.Dispose()
        frm = Nothing
    End Sub

    Sub Butcmrem_Click(sender As Object, e As EventArgs) Handles butcmrem.Click
        If lstvcm.SelectedIndices.Count > 0 Then
            Dim cop As List(Of String) = getst(lstvcm.SelectedItems)
            For Each nom As String In cop
                cmarshal.disconnect(lstreg(nom).ip, lstreg(nom).port)
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
                msg.data = frm.getfile()
                cmarshal.sendMessage(msg.msg)
                msg.data = Nothing
            Next
            drfrsh = True
        End If
        frm.dat = Nothing
        If Not frm.Disposing And Not frm.IsDisposed Then frm.Dispose()
        frm = Nothing
    End Sub

    Sub Butcmcls_Click(sender As Object, e As EventArgs) Handles butcmcls.Click
        lstvcm.SelectedIndices.Clear()
        cmarshal.disconnectAll()
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
                msg.data = frm.getfile()
                cmarshal.sendMessage(msg.msg)
                msg.data = Nothing
            Next
            drfrsh = True
        End If
        frm.dat = Nothing
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
            Dim dat As Byte() = Nothing
            If IO.File.Exists(smsg.locpth) Then
                dat = IO.File.ReadAllBytes(smsg.locpth)
            Else
                MsgBox("File to Send Not Found.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly)
                Return
            End If
            If smsg.wassent Then
                smsg.data = dat
                cmarshal.sendMessage(smsg.msg)
                smsg.data = Nothing
            Else
                Dim nmsg As Mail = New Mail(smsg.refnum, smsg.header, smsg.name, smsg.data)
                nmsg.recaddr = smsg.senderaddr
                nmsg.recport = smsg.senderport
                nmsg.senderaddr = cmarshal.internalTCPSocket(nmsg.recaddr, nmsg.recport).localIPAddress
                nmsg.senderport = cmarshal.internalTCPSocket(nmsg.recaddr, nmsg.recport).localPort
                nmsg.wassent = True
                nmsg.sndnom = "Me"
                nmsg.disnom = "Me"
                nmsg.locpth = smsg.locpth
                lstmsg.Add(nmsg)
                nmsg.data = dat
                cmarshal.sendMessage(nmsg.msg)
                nmsg.data = Nothing
                drfrsh = True
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