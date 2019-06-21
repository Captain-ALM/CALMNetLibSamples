Public Structure Reg
    Public name As String
    Public ip As String
    Public port As Integer
    Public pip As String
    Public pport As String
    Public Sub New(i_p As String, p As Integer)
        ip = i_p
        port = p
        name = i_p.ToString() & ":" & p
    End Sub
    Public Sub New(nom As String, i_p As String, p As Integer)
        name = nom
        ip = i_p
        port = p
    End Sub
End Structure