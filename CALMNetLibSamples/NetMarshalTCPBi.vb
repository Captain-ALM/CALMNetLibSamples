Imports captainalm.CALMNetLib
Imports System.Net
Imports System.Net.Sockets
Imports System.Threading

Public Class NetMarshalTCPBi
    Inherits NetMarshalBase

    Protected Const buffersize As Integer = 16777216 '65536
    Protected Const tcpmsgsize As Integer = 16777088 '65408
    Protected _clcol As New List(Of Tuple(Of NetTCPClient, Thread, String, Integer))
    Protected _slockcolman As New Object()
    Protected _delay As Boolean
    Public Event clientConnected(ip As String, port As Integer)
    Public Event clientDisconnected(ip As String, port As Integer)

    Public Sub New(iptb As IPAddress, ptb As Integer, Optional cbl As Integer = 1, Optional del As Boolean = False)
        MyBase.New(New NetTCPListener(iptb, ptb) With {.sendBufferSize = tcpmsgsize, .receiveBufferSize = tcpmsgsize, .noDelay = Not del, .connectionBacklog = cbl})
        _delay = del
    End Sub

    Public Overrides Sub start()
        If _cl Is Nothing Then Return
        _cl.open()
        MyBase.start()
    End Sub

    Public Overrides Sub close()
        If _cl IsNot Nothing Then
            _cl.close()
            _cl = Nothing
        End If
        While _clcol.Count > 0
            For i As Integer = _clcol.Count - 1 To 0 Step -1
                Try
                    Dim ct As Tuple(Of NetTCPClient, Thread, String, Integer) = Nothing
                    SyncLock _slockcolman
                        ct = _clcol(i)
                    End SyncLock
                    If ct.Item2.IsAlive Then ct.Item2.Join(500)
                    If ct.Item2.IsAlive Then ct.Item2.Abort()
                    ct.Item1.close()
                    SyncLock _slockcolman
                        _clcol.Remove(ct)
                    End SyncLock
                    RaiseEvent clientDisconnected(CType(ct.Item1, INetConfig).remoteIPAddress, CType(ct.Item1, INetConfig).remotePort)
                    ct = Nothing
                Catch ex As Exception When (TypeOf ex Is ArgumentOutOfRangeException Or TypeOf ex Is IndexOutOfRangeException)
                    raiseExceptionRaised(ex)
                End Try
            Next
            Thread.Sleep(200)
        End While
        SyncLock _slockcolman
            _clcol.Clear()
            _clcol = Nothing
        End SyncLock
        MyBase.close()
    End Sub

    Public Overridable Sub connect(iptc As String, ptc As Integer)
        If _cl IsNot Nothing Then
            Dim ccl As INetSocket = New NetTCPClient(IPAddress.Parse(iptc), ptc) With {.sendBufferSize = tcpmsgsize, .receiveBufferSize = tcpmsgsize, .noDelay = Not _delay}
            ccl.open()
            Dim lip As String = ""
            Dim lport As Integer = 0
            Try
                lip = CType(ccl, INetConfig).localIPAddress
                lport = CType(ccl, INetConfig).localPort
            Catch ex As ObjectDisposedException
                raiseExceptionRaised(ex)
            End Try
            If ccl.connected And ccl.sendBytes(New Serializer().serializeObject(Of EchoMessage)(New EchoMessage(Chr(6)) With {.senderIP = lip, .senderPort = lport, .receiverIP = CType(ccl, INetConfig).remoteIPAddress, .receiverPort = CType(ccl, INetConfig).remotePort})) Then
                Dim bts As Byte() = ccl.receiveBytes()
                If bts.Length > 0 Then
                    Dim msg As EchoMessage = New Serializer().deSerializeObject(Of EchoMessage)(bts)
                    Dim clt As Thread = New Thread(New ParameterizedThreadStart(AddressOf t_cl_exec))
                    clt.IsBackground = True
                    Dim tpl As New Tuple(Of NetTCPClient, Thread, String, Integer)(ccl, clt, lip, lport)
                    clt.Start(tpl)
                    SyncLock _slockcolman
                        _clcol.Add(tpl)
                    End SyncLock
                    RaiseEvent clientConnected(iptc, ptc)
                End If
            End If
        End If
    End Sub

    Public Overridable ReadOnly Property Delay As Boolean
        Get
            Return _delay
        End Get
    End Property

    Public Overridable ReadOnly Property connected(ipr As String, pr As Integer) As Boolean
        Get
            Dim toret As Boolean = False
            If _cl IsNot Nothing Then
                For i As Integer = _clcol.Count - 1 To 0 Step -1
                    Try
                        Dim ct As Tuple(Of NetTCPClient, Thread, String, Integer) = Nothing
                        SyncLock _slockcolman
                            ct = _clcol(i)
                        End SyncLock
                        If CType(ct.Item1, INetConfig).remoteIPAddress = ipr And CType(ct.Item1, INetConfig).remotePort = pr Then
                            If ct.Item1 Is Nothing Or ct.Item2 Is Nothing Then Return False
                            If ct.Item1.connected And ct.Item2.IsAlive And ct.Item1.sendBytes(New Serializer().serializeObject(Of EchoMessage)(New EchoMessage(Chr(6)) With {.senderIP = ct.Item3, .senderPort = ct.Item4, .receiverIP = CType(ct.Item1, INetConfig).remoteIPAddress, .receiverPort = CType(ct.Item1, INetConfig).remotePort})) Then
                                toret = True
                            Else
                                toret = False
                            End If
                            Exit For
                        End If
                    Catch ex As Exception When (TypeOf ex Is ArgumentOutOfRangeException Or TypeOf ex Is IndexOutOfRangeException)
                        raiseExceptionRaised(ex)
                    End Try
                Next
            End If
            Return toret
        End Get
    End Property

    Public Overridable ReadOnly Property internalTCPSocket(ipr As String, pr As Integer) As NetTCPClient
        Get
            Dim toret As NetTCPClient = Nothing
            If _cl IsNot Nothing Then
                For i As Integer = _clcol.Count - 1 To 0 Step -1
                    Try
                        Dim ct As Tuple(Of NetTCPClient, Thread, String, Integer) = Nothing
                        SyncLock _slockcolman
                            ct = _clcol(i)
                        End SyncLock
                        If CType(ct.Item1, INetConfig).remoteIPAddress = ipr And CType(ct.Item1, INetConfig).remotePort = pr Then
                            If ct.Item1 Is Nothing Or ct.Item2 Is Nothing Then Return Nothing
                            toret = ct.Item1
                            Exit For
                        End If
                    Catch ex As Exception When (TypeOf ex Is ArgumentOutOfRangeException Or TypeOf ex Is IndexOutOfRangeException)
                        raiseExceptionRaised(ex)
                    End Try
                Next
            End If
            Return toret
        End Get
    End Property

    Public Overridable Sub disconnect(iptdc As String, ptdc As Integer)
        If _cl IsNot Nothing Then
            For i As Integer = _clcol.Count - 1 To 0 Step -1
                Try
                    Dim ct As Tuple(Of NetTCPClient, Thread, String, Integer) = Nothing
                    SyncLock _slockcolman
                        ct = _clcol(i)
                    End SyncLock
                    If CType(ct.Item1, INetConfig).remoteIPAddress = iptdc And CType(ct.Item1, INetConfig).remotePort = ptdc Then
                        If ct.Item1 Is Nothing Or ct.Item2 Is Nothing Then Return
                        If ct.Item1.connected Then
                            ct.Item1.close()
                        End If
                        Exit For
                    End If
                Catch ex As Exception When (TypeOf ex Is ArgumentOutOfRangeException Or TypeOf ex Is IndexOutOfRangeException)
                    raiseExceptionRaised(ex)
                End Try
            Next
        End If
    End Sub

    Public Overridable Sub disconnectAll()
        If _cl IsNot Nothing Then
            For i As Integer = _clcol.Count - 1 To 0 Step -1
                Try
                    Dim ct As Tuple(Of NetTCPClient, Thread, String, Integer) = Nothing
                    SyncLock _slockcolman
                        ct = _clcol(i)
                    End SyncLock
                    If ct.Item1 Is Nothing Or ct.Item2 Is Nothing Then Return
                    If ct.Item1.connected Then
                        ct.Item1.close()
                    End If
                Catch ex As Exception When (TypeOf ex Is ArgumentOutOfRangeException Or TypeOf ex Is IndexOutOfRangeException)
                    raiseExceptionRaised(ex)
                End Try
            Next
            Thread.Sleep(200)
        End If
    End Sub

    Public Overrides ReadOnly Property ready As Boolean
        Get
            If _cl Is Nothing Then Return False
            Return _cl.listening
        End Get
    End Property

    Public Overrides Function sendMessage(msg As IMessage) As Boolean
        If _cl Is Nothing Then Return False
        Dim toret As Boolean = False
        For i As Integer = _clcol.Count - 1 To 0 Step -1
            Try
                Dim ct As Tuple(Of NetTCPClient, Thread, String, Integer) = Nothing
                SyncLock _slockcolman
                    ct = _clcol(i)
                End SyncLock
                If CType(ct.Item1, INetConfig).remoteIPAddress = msg.receiverIP And CType(ct.Item1, INetConfig).remotePort = msg.receiverPort Then
                    If ct.Item1 Is Nothing Or ct.Item2 Is Nothing Then Return False
                    If ct.Item1.connected And ct.Item2.IsAlive Then
                        toret = ct.Item1.sendBytes(msg.getData)
                    Else
                        toret = False
                    End If
                    Exit For
                End If
            Catch ex As Exception When (TypeOf ex Is ArgumentOutOfRangeException Or TypeOf ex Is IndexOutOfRangeException)
                raiseExceptionRaised(ex)
            End Try
        Next
        Return toret
    End Function

    Public Overridable Function broadcast(msg As IMessage) As Boolean
        If _cl Is Nothing Then Return False
        Dim toret As Boolean = True
        For i As Integer = _clcol.Count - 1 To 0 Step -1
            Try
                Dim ct As Tuple(Of NetTCPClient, Thread, String, Integer) = Nothing
                SyncLock _slockcolman
                    ct = _clcol(i)
                End SyncLock
                If (ct.Item1 IsNot Nothing And ct.Item2 IsNot Nothing) Then
                    If ct.Item1.connected And ct.Item2.IsAlive Then
                        toret = toret And ct.Item1.sendBytes(msg.getData)
                    Else
                        toret = toret And False
                    End If
                End If
            Catch ex As Exception When (TypeOf ex Is ArgumentOutOfRangeException Or TypeOf ex Is IndexOutOfRangeException)
                raiseExceptionRaised(ex)
            End Try
        Next
        Return toret
    End Function

    Protected Overrides Sub t_exec()
        While _cl IsNot Nothing
            Try
                While _cl IsNot Nothing AndAlso _cl.listening
                    If _cl.clientWaiting Then
                        Dim acl As INetSocket = _cl.acceptClient()
                        Dim lip As String = ""
                        Dim lport As Integer = 0
                        Try
                            lip = CType(acl, INetConfig).localIPAddress
                            lport = CType(acl, INetConfig).localPort
                        Catch ex As ObjectDisposedException
                            raiseExceptionRaised(ex)
                        End Try
                        Dim bts As Byte() = acl.receiveBytes()
                        If bts.Length > 0 Then
                            Dim msg As EchoMessage = New Serializer().deSerializeObject(Of EchoMessage)(bts)
                            If acl.connected And acl.sendBytes(New Serializer().serializeObject(Of EchoMessage)(New EchoMessage(Chr(6)) With {.senderIP = lip, .senderPort = lport, .receiverIP = CType(acl, INetConfig).remoteIPAddress, .receiverPort = CType(acl, INetConfig).remotePort})) Then
                                Dim clt As Thread = New Thread(New ParameterizedThreadStart(AddressOf t_cl_exec))
                                clt.IsBackground = True
                                Dim tpl As New Tuple(Of NetTCPClient, Thread, String, Integer)(acl, clt, lip, lport)
                                clt.Start(tpl)
                                SyncLock _slockcolman
                                    _clcol.Add(tpl)
                                End SyncLock
                                RaiseEvent clientConnected(msg.senderIP, msg.senderPort)
                            End If
                        End If
                    End If
                    For i As Integer = _clcol.Count - 1 To 0 Step -1
                        Try
                            Dim ct As Tuple(Of NetTCPClient, Thread, String, Integer) = Nothing
                            SyncLock _slockcolman
                                ct = _clcol(i)
                            End SyncLock
                            If Not (ct.Item1.connected And ct.Item2.IsAlive And ct.Item1.sendBytes(New Serializer().serializeObject(Of EchoMessage)(New EchoMessage(Chr(6)) With {.senderIP = ct.Item3, .senderPort = ct.Item4, .receiverIP = CType(ct.Item1, INetConfig).remoteIPAddress, .receiverPort = CType(ct.Item1, INetConfig).remotePort}))) Then
                                ct.Item1.close()
                                SyncLock _slockcolman
                                    _clcol.Remove(ct)
                                End SyncLock
                                RaiseEvent clientDisconnected(CType(ct.Item1, INetConfig).remoteIPAddress, CType(ct.Item1, INetConfig).remotePort)
                            End If
                            ct = Nothing
                        Catch ex As Exception When (TypeOf ex Is ArgumentOutOfRangeException Or TypeOf ex Is IndexOutOfRangeException)
                            raiseExceptionRaised(ex)
                        End Try
                    Next
                    Thread.Sleep(200)
                End While
            Catch ex As NetLibException
                raiseExceptionRaised(ex)
            End Try
            Thread.Sleep(200)
        End While
    End Sub

    Protected Sub raiseClientConnected(ip As String, port As Integer)
        RaiseEvent clientConnected(ip, port)
    End Sub

    Protected Sub raiseClientDisconnected(ip As String, port As Integer)
        RaiseEvent clientDisconnected(ip, port)
    End Sub

    Protected Overridable Sub t_cl_exec(obj As Object)
        Dim tpl As Tuple(Of NetTCPClient, Thread, String, Integer) = CType(obj, Tuple(Of NetTCPClient, Thread, String, Integer))
        While _cl IsNot Nothing AndAlso tpl.Item1.connected AndAlso tpl.Item1.connected
            Try
                While tpl.Item1.connected
                    Dim bts As Byte() = tpl.Item1.receiveBytes()
                    If bts.Length > 0 Then
                        Dim tech As EchoMessage = New Serializer().deSerializeObject(Of EchoMessage)(bts)
                        If Not (tech.echo = Chr(6)) Then
                            Dim tmsg As IMessage = New Serializer().deSerializeObject(Of IMessage)(bts)
                            raiseMessageRecieved(tmsg)
                        End If
                    End If
                    Thread.Sleep(200)
                End While
                Exit While
            Catch ex As NetLibException
                raiseExceptionRaised(ex)
            End Try
            Thread.Sleep(200)
        End While
    End Sub
End Class