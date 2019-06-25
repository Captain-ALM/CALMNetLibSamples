Imports captainalm.CALMNetLib
Imports System.Threading

Public MustInherit Class NetMarshalBase
    Protected _cl As INetSocket
    Protected _t As Thread = New Thread(AddressOf t_exec)
    Public Event exceptionRaised(ex As Exception)
    Public Event MessageRecieved(msg As IMessage)

    Public Sub New(cl As INetSocket)
        _cl = cl
    End Sub

    Public Overridable Sub start()
        If _t IsNot Nothing Then
            If _t.ThreadState = ThreadState.Unstarted Then
                _t.IsBackground = True
                _t.Start()
            End If
        End If
    End Sub

    Public Overridable Sub close()
        If _t IsNot Nothing Then
            If _t.IsAlive Then
                _t.Join(500)
            End If
            If _t.IsAlive Then
                _t.Abort()
            End If
            _t = Nothing
        End If
    End Sub

    Public MustOverride ReadOnly Property ready As Boolean

    Public Overridable ReadOnly Property internalSocket As INetSocket
        Get
            Return _cl
        End Get
    End Property

    Public MustOverride Function sendMessage(msg As IMessage) As Boolean

    Protected MustOverride Sub t_exec()

    Protected Sub raiseExceptionRaised(ex As Exception)
        RaiseEvent exceptionRaised(ex)
    End Sub

    Protected Sub raiseMessageRecieved(msg As IMessage)
        RaiseEvent MessageRecieved(msg)
    End Sub
End Class
