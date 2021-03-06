﻿Imports captainalm.CALMNetLibSamples.extlib

<Serializable>
Public Structure Mail
    Public sndnom As String
    Public msg As Message
    Public wassent As Boolean
    Public refnum As Integer
    Public disnom As String

    Public Sub New(m As Message)
        msg = m
    End Sub
    Public Sub New(rn As Integer, head As String, dat As String)
        refnum = rn
        header = head
        data = dat
    End Sub
    Public Sub New(rn As Integer, head As String, dat As String, sa As String, sp As Integer, da As String, dp As Integer)
        refnum = rn
        header = head
        data = dat
        senderaddr = sa
        senderport = sp
        recaddr = da
        recport = dp
    End Sub

    Public Property senderaddr As String
        Get
            Return msg.senderIP
        End Get
        Set(value As String)
            msg.senderIP = value
        End Set
    End Property

    Public Property recaddr As String
        Get
            Return msg.receiverIP
        End Get
        Set(value As String)
            msg.receiverIP = value
        End Set
    End Property

    Public Property senderport As Integer
        Get
            Return msg.senderPort
        End Get
        Set(value As Integer)
            msg.senderPort = value
        End Set
    End Property

    Public Property recport As Integer
        Get
            Return msg.receiverPort
        End Get
        Set(value As Integer)
            msg.receiverPort = value
        End Set
    End Property

    Public Property data As String
        Get
            Return msg.message
        End Get
        Set(value As String)
            msg.message = value
        End Set
    End Property

    Public Property header As String
        Get
            Return msg.header
        End Get
        Set(value As String)
            msg.header = value
        End Set
    End Property
End Structure