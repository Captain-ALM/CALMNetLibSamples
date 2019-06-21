Imports captainalm.CALMNetLibSamples.extlib
'
' Created by SharpDevelop.
' User: Alfred
' Date: 09/06/2019
' Time: 11:43
' 
' To change this template use Tools | Options | Coding | Edit Standard Headers.
'
Public Module [Global]
    Public cmarshal As NetMarshalUDP = Nothing
    Public lstreg As New Dictionary(Of String, Reg)
    Public lstmsg As New List(Of Mail)
	Public lip As New List(Of String)
    Public lport As Integer = 0
    Public prip As String
    Public prport As Integer
End Module
