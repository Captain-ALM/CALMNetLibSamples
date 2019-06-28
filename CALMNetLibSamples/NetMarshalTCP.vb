Imports captainalm.CALMNetLib
Imports System.Net
Imports System.Net.Sockets
Imports System.Threading

Public Class NetMarshalTCP
    Inherits NetMarshalBase

    Protected _clcol As New List(Of Tuple(Of NetTCPClient, NetTCPClient, Thread))
    Protected _slockconnect As New Object()
    Protected _slockcolman As New Object()
    Protected _myip As String
    Protected _myport As Integer
    Protected _delay As Boolean
    Public Event clientConnected(ip As String, port As Integer)
    Public Event clientDisconnected(ip As String, port As Integer)

    Public Sub New(iptb As IPAddress, ptb As Integer, Optional cbl As Integer = 1, Optional del As Boolean = False)
        MyBase.New(New NetTCPListener(iptb, ptb) With {.sendBufferSize = UInt16.MaxValue, .receiveBufferSize = UInt16.MaxValue, .noDelay = Not del, .connectionBacklog = cbl})
        _myip = iptb.ToString()
        _myport = ptb
        _delay = del
    End Sub

    Public Sub New(iptb As IPAddress, ptb As Integer, ipts As IPAddress, pts As Integer, Optional cbl As Integer = 1, Optional del As Boolean = False)
        MyBase.New(New NetTCPListener(iptb, ptb) With {.sendBufferSize = UInt16.MaxValue, .receiveBufferSize = UInt16.MaxValue, .noDelay = Not del, .connectionBacklog = cbl})
        _myip = ipts.ToString()
        _myport = pts
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
                    Dim ct As Tuple(Of NetTCPClient, NetTCPClient, Thread) = Nothing
                    SyncLock _slockcolman
                        ct = _clcol(i)
                    End SyncLock
                    If ct.Item3.IsAlive Then ct.Item3.Join(500)
                    If ct.Item3.IsAlive Then ct.Item3.Abort()
                    ct.Item1.close()
                    ct.Item2.close()
                    SyncLock _slockcolman
                        _clcol.Remove(ct)
                    End SyncLock
                    RaiseEvent clientDisconnected(CType(ct.Item2, INetConfig).remoteIPAddress, CType(ct.Item2, INetConfig).remotePort)
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
            SyncLock _slockconnect
                Dim ccl As INetSocket = New NetTCPClient(IPAddress.Parse(iptc), ptc) With {.sendBufferSize = UInt16.MaxValue, .receiveBufferSize = UInt16.MaxValue, .noDelay = Not _delay}
                ccl.open()
                If ccl.connected And ccl.sendBytes(New Serializer().serializeObject(Of EchoMessage)(New EchoMessage(Chr(6)) With {.senderIP = _myip, .senderPort = _myport, .receiverIP = CType(ccl, INetConfig).remoteIPAddress, .receiverPort = CType(ccl, INetConfig).remotePort})) Then
                    Dim acl As INetSocket = _cl.acceptClient()
                    Dim bts As Byte() = acl.recieveBytes()
                    If bts.Length > 0 Then
                        Dim msg As EchoMessage = New Serializer().deSerializeObject(Of EchoMessage)(bts)
                        Dim clt As Thread = New Thread(New ParameterizedThreadStart(AddressOf t_cl_exec))
                        clt.IsBackground = True
                        Dim tpl As New Tuple(Of NetTCPClient, NetTCPClient, Thread)(acl, ccl, clt)
                        clt.Start(tpl)
                        SyncLock _slockcolman
                            _clcol.Add(tpl)
                        End SyncLock
                        RaiseEvent clientConnected(iptc, ptc)
                    End If
                End If
            End SyncLock
        End If
    End Sub

    Public Overridable Sub connect(iptc As String, ptc As Integer, myip As String, myport As Integer)
        If _cl IsNot Nothing Then
            SyncLock _slockconnect
                Dim ccl As INetSocket = New NetTCPClient(IPAddress.Parse(iptc), ptc) With {.sendBufferSize = UInt16.MaxValue, .receiveBufferSize = UInt16.MaxValue, .noDelay = Not _delay}
                ccl.open()
                If ccl.connected And ccl.sendBytes(New Serializer().serializeObject(Of EchoMessage)(New EchoMessage(Chr(6)) With {.senderIP = myip, .senderPort = myport, .receiverIP = CType(ccl, INetConfig).remoteIPAddress, .receiverPort = CType(ccl, INetConfig).remotePort})) Then
                    Dim acl As INetSocket = _cl.acceptClient()
                    Dim bts As Byte() = acl.recieveBytes()
                    If bts.Length > 0 Then
                        Dim msg As EchoMessage = New Serializer().deSerializeObject(Of EchoMessage)(bts)
                        Dim clt As Thread = New Thread(New ParameterizedThreadStart(AddressOf t_cl_exec))
                        clt.IsBackground = True
                        Dim tpl As New Tuple(Of NetTCPClient, NetTCPClient, Thread)(acl, ccl, clt)
                        clt.Start(tpl)
                        SyncLock _slockcolman
                            _clcol.Add(tpl)
                        End SyncLock
                        RaiseEvent clientConnected(iptc, ptc)
                    End If
                End If
            End SyncLock
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
                        Dim ct As Tuple(Of NetTCPClient, NetTCPClient, Thread) = Nothing
                        SyncLock _slockcolman
                            ct = _clcol(i)
                        End SyncLock
                        If CType(ct.Item2, INetConfig).remoteIPAddress = ipr And CType(ct.Item2, INetConfig).remotePort = pr Then
                            If ct.Item1 Is Nothing Or ct.Item2 Is Nothing Or ct.Item3 Is Nothing Then Return False
                            If ct.Item1.connected And ct.Item2.connected And ct.Item3.IsAlive And ct.Item2.sendBytes(New Serializer().serializeObject(Of EchoMessage)(New EchoMessage(Chr(6)) With {.senderIP = _myip, .senderPort = _myport, .receiverIP = CType(ct.Item2, INetConfig).remoteIPAddress, .receiverPort = CType(ct.Item2, INetConfig).remotePort})) Then
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

    Public Overridable ReadOnly Property internalTCPSocket(ipr As String, pr As Integer) As Tuple(Of NetTCPClient, NetTCPClient)
        Get
            Dim toret As Tuple(Of NetTCPClient, NetTCPClient) = Nothing
            If _cl IsNot Nothing Then
                For i As Integer = _clcol.Count - 1 To 0 Step -1
                    Try
                        Dim ct As Tuple(Of NetTCPClient, NetTCPClient, Thread) = Nothing
                        SyncLock _slockcolman
                            ct = _clcol(i)
                        End SyncLock
                        If CType(ct.Item2, INetConfig).remoteIPAddress = ipr And CType(ct.Item2, INetConfig).remotePort = pr Then
                            If ct.Item1 Is Nothing Or ct.Item2 Is Nothing Or ct.Item3 Is Nothing Then Return Nothing
                            toret = New Tuple(Of NetTCPClient, NetTCPClient)(ct.Item1, ct.Item2)
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
                    Dim ct As Tuple(Of NetTCPClient, NetTCPClient, Thread) = Nothing
                    SyncLock _slockcolman
                        ct = _clcol(i)
                    End SyncLock
                    If CType(ct.Item2, INetConfig).remoteIPAddress = iptdc And CType(ct.Item2, INetConfig).remotePort = ptdc Then
                        If ct.Item1 Is Nothing Or ct.Item2 Is Nothing Or ct.Item3 Is Nothing Then Return
                        If ct.Item1.connected Then
                            ct.Item1.close()
                        End If
                        If ct.Item2.connected Then
                            ct.Item2.close()
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
                    Dim ct As Tuple(Of NetTCPClient, NetTCPClient, Thread) = Nothing
                    SyncLock _slockcolman
                        ct = _clcol(i)
                    End SyncLock
                    If ct.Item1 Is Nothing Or ct.Item2 Is Nothing Or ct.Item3 Is Nothing Then Return
                    If ct.Item1.connected Then
                        ct.Item1.close()
                    End If
                    If ct.Item2.connected Then
                        ct.Item2.close()
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
                Dim ct As Tuple(Of NetTCPClient, NetTCPClient, Thread) = Nothing
                SyncLock _slockcolman
                    ct = _clcol(i)
                End SyncLock
                If CType(ct.Item2, INetConfig).remoteIPAddress = msg.receiverIP And CType(ct.Item2, INetConfig).remotePort = msg.receiverPort Then
                    If ct.Item1 Is Nothing Or ct.Item2 Is Nothing Or ct.Item3 Is Nothing Then Return False
                    If ct.Item1.connected And ct.Item2.connected And ct.Item3.IsAlive Then
                        toret = ct.Item2.sendBytes(msg.getData)
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
                Dim ct As Tuple(Of NetTCPClient, NetTCPClient, Thread) = Nothing
                SyncLock _slockcolman
                    ct = _clcol(i)
                End SyncLock
                If (ct.Item1 IsNot Nothing And ct.Item2 IsNot Nothing And ct.Item3 IsNot Nothing) Then
                    If ct.Item1.connected And ct.Item2.connected And ct.Item3.IsAlive Then
                        toret = toret And ct.Item2.sendBytes(msg.getData)
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

    Public Overridable Property IPToSend As IPAddress
        Get
            Return IPAddress.Parse(_myip)
        End Get
        Set(value As IPAddress)
            _myip = value.ToString()
        End Set
    End Property

    Public Overridable Property PortToSend As Integer
        Get
            Return _myport
        End Get
        Set(value As Integer)
            _myport = value
        End Set
    End Property

    Protected Overrides Sub t_exec()
        While _cl IsNot Nothing
            Try
                While _cl IsNot Nothing AndAlso _cl.listening
                    SyncLock _slockconnect
                        If _cl.clientWaiting Then
                            Dim acl As INetSocket = _cl.acceptClient()
                            Dim bts As Byte() = acl.recieveBytes()
                            If bts.Length > 0 Then
                                Dim msg As EchoMessage = New Serializer().deSerializeObject(Of EchoMessage)(bts)
                                Dim ccl As INetSocket = New NetTCPClient(IPAddress.Parse(msg.senderIP), msg.senderPort) With {.sendBufferSize = UInt16.MaxValue, .receiveBufferSize = UInt16.MaxValue, .noDelay = Not _delay}
                                ccl.open()
                                If ccl.connected And ccl.sendBytes(New Serializer().serializeObject(Of EchoMessage)(New EchoMessage(Chr(6)) With {.senderIP = _myip, .senderPort = _myport, .receiverIP = CType(ccl, INetConfig).remoteIPAddress, .receiverPort = CType(ccl, INetConfig).remotePort})) Then
                                    Dim clt As Thread = New Thread(New ParameterizedThreadStart(AddressOf t_cl_exec))
                                    clt.IsBackground = True
                                    Dim tpl As New Tuple(Of NetTCPClient, NetTCPClient, Thread)(acl, ccl, clt)
                                    clt.Start(tpl)
                                    SyncLock _slockcolman
                                        _clcol.Add(tpl)
                                    End SyncLock
                                    RaiseEvent clientConnected(msg.senderIP, msg.senderPort)
                                End If
                            End If
                        End If
                    End SyncLock
                    For i As Integer = _clcol.Count - 1 To 0 Step -1
                        Try
                            Dim ct As Tuple(Of NetTCPClient, NetTCPClient, Thread) = Nothing
                            SyncLock _slockcolman
                                ct = _clcol(i)
                            End SyncLock
                            If Not (ct.Item1.connected And ct.Item2.connected And ct.Item3.IsAlive And ct.Item2.sendBytes(New Serializer().serializeObject(Of EchoMessage)(New EchoMessage(Chr(6)) With {.senderIP = _myip, .senderPort = _myport, .receiverIP = CType(ct.Item2, INetConfig).remoteIPAddress, .receiverPort = CType(ct.Item2, INetConfig).remotePort}))) Then
                                ct.Item1.close()
                                ct.Item2.close()
                                SyncLock _slockcolman
                                    _clcol.Remove(ct)
                                End SyncLock
                                RaiseEvent clientDisconnected(CType(ct.Item2, INetConfig).remoteIPAddress, CType(ct.Item2, INetConfig).remotePort)
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
        Dim tpl As Tuple(Of NetTCPClient, NetTCPClient, Thread) = CType(obj, Tuple(Of NetTCPClient, NetTCPClient, Thread))
        While _cl IsNot Nothing AndAlso tpl.Item1.connected AndAlso tpl.Item2.connected
            Try
                While tpl.Item1.connected
                    Dim bts As Byte() = tpl.Item1.recieveBytes()
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

<Serializable>
Friend Structure EchoMessage
    Public senderIP As String
    Public senderPort As Integer
    Public receiverIP As String
    Public receiverPort As Integer
    Public echo As Char
    Public Sub New(e As Char)
        echo = e
    End Sub
End Structure