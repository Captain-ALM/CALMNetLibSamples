Imports captainalm.CALMNetLib
Imports System.Net
Imports System.Net.Sockets
Imports System.Threading

Public Class NetMarshalUDP
    Inherits NetMarshalBase

    Protected Const udpmsgsize As Integer = 65500
    Protected _f As AddressFamily

    Public Sub New(iptb As IPAddress, ptb As Integer)
        MyBase.New(New NetUDPClient(iptb, ptb, UDPIPPortSpecification.Local) With {.sendBufferSize = udpmsgsize, .receiveBufferSize = udpmsgsize})
        _f = iptb.AddressFamily
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
        MyBase.close()
    End Sub

    Public Overrides ReadOnly Property ready As Boolean
        Get
            If _cl Is Nothing Then Return False
            Return _cl.listening
        End Get
    End Property

    Public Overrides Function sendMessage(msg As Message) As Boolean
        If _cl Is Nothing Then Return False
        Dim bts As Byte() = New Serializer().serializeObject(Of Message)(msg)
        If bts.Length > udpmsgsize Then Return False
        Return CType(_cl, INetSocketConnectionless).sendBytesTo(bts, msg.receiverIP, msg.receiverPort)
    End Function

    Protected Overrides Sub t_exec()
        While _cl IsNot Nothing
            Try
                While _cl.listening
                    Dim bts As Byte() = Nothing
                    If _f = AddressFamily.InterNetwork Then
                        bts = CType(_cl, INetSocketConnectionless).recieveBytesFrom(IPAddress.Any.ToString, 0)
                    ElseIf _f = AddressFamily.InterNetworkV6 Then
                        bts = CType(_cl, INetSocketConnectionless).recieveBytesFrom(IPAddress.IPv6Any.ToString, 0)
                    End If
                    Dim umsg As Message = New Serializer().deSerializeObject(Of Message)(bts)
                    raiseMessageRecieved(umsg)
                    Thread.Sleep(200)
                End While
            Catch ex As NetLibException
                raiseExceptionRaised(ex)
            End Try
            Thread.Sleep(200)
        End While
    End Sub
End Class
