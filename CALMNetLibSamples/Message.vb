Imports captainalm.CALMNetLib

<Serializable>
Public Structure Message
    Implements IMessage

    Private senderIP_ As String
    Private senderPort_ As Integer
    Private receiverIP_ As String
    Private receiverPort_ As Integer
    Public header As String
    Public message As String

    Public Property data As Object Implements IMessage.data
        Get
            Return New Tuple(Of String, String)(header, message)
        End Get
        Set(value As Object)
            Dim cc As Tuple(Of String, String) = CType(value, Tuple(Of String, String))
            header = cc.Item1
            message = cc.Item2
        End Set
    End Property

    Public ReadOnly Property dataType As Type Implements IMessage.dataType
        Get
            Return GetType(Tuple(Of String, String))
        End Get
    End Property

    Public ReadOnly Property getData As Byte() Implements IMessage.getData
        Get
            Return New Serializer().serializeObject(Of Message)(Me)
        End Get
    End Property

    Public WriteOnly Property setData As Byte() Implements IMessage.setData
        Set(value As Byte())
            Dim msg As Message = New Serializer().deSerializeObject(Of Message)(value)
            Me.receiverIP_ = msg.receiverIP_
            Me.receiverPort_ = msg.receiverPort_
            Me.senderIP_ = msg.senderIP_
            Me.senderPort_ = msg.senderPort_
            Me.header = msg.header
            Me.message = msg.message
            msg = Nothing
        End Set
    End Property

    Public Property receiverIP As String Implements IMessage.receiverIP
        Get
            Return receiverIP_
        End Get
        Set(value As String)
            receiverIP_ = value
        End Set
    End Property

    Public Property receiverPort As Integer Implements IMessage.receiverPort
        Get
            Return receiverPort_
        End Get
        Set(value As Integer)
            receiverPort_ = value
        End Set
    End Property

    Public Property senderIP As String Implements IMessage.senderIP
        Get
            Return senderIP_
        End Get
        Set(value As String)
            senderIP_ = value
        End Set
    End Property

    Public Property senderPort As Integer Implements IMessage.senderPort
        Get
            Return senderPort_
        End Get
        Set(value As Integer)
            senderPort_ = value
        End Set
    End Property
End Structure