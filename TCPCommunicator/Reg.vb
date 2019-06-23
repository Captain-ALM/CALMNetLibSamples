Public Structure Reg
    Implements IID

    Private _id As String
    Public name As String
    Public ip As String
    Public port As Integer
    Public pip As String
    Public pport As String
    Public Sub New(i_p As String, p As Integer)
        ip = i_p
        port = p
        _id = i_p & ":" & p
        name = _id
    End Sub
    Public Sub New(nom As String, i_p As String, p As Integer)
        name = nom
        ip = i_p
        port = p
        _id = i_p & ":" & p
    End Sub
    Public Property ID As String Implements IID.ID
        Get
            Return _id
        End Get
        Set(value As String)
            _id = value
        End Set
    End Property
End Structure