Public Interface IMessage
    Property senderIP As String
    Property senderPort As Integer
    Property receiverIP As String
    Property receiverPort As Integer
    ReadOnly Property getData() As Byte()
    WriteOnly Property setData() As Byte()
    Property data As Object
    ReadOnly Property dataType As Type
End Interface
