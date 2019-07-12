Public NotInheritable Class IDCollection(Of t As IID)
    Private _col As New List(Of KeyValuePair(Of String, t))
    Private _slock As New Object()
    Private _slockmr As New Object()
    Public Sub add(item As t)
        SyncLock _slockmr
            Dim e As Boolean = exists(item)
            If Not e Then
                SyncLock _slock
                    _col.Add(New KeyValuePair(Of String, t)(item.ID, item))
                End SyncLock
            End If
        End SyncLock
    End Sub
    Public Sub add(id As String, item As t)
        SyncLock _slockmr
            Dim e As Boolean = exists(item) Or exists(id)
            If Not e Then
                SyncLock _slock
                    _col.Add(New KeyValuePair(Of String, t)(id, item))
                End SyncLock
            End If
        End SyncLock
    End Sub
    Public Sub remove(id As String)
        SyncLock _slockmr
            Dim e As Boolean = exists(id)
            If e Then
                SyncLock _slock
                    Dim pos As Integer = -1
                    Dim i As Integer = 0
                    For Each c As KeyValuePair(Of String, t) In _col
                        If c.Key = c.Value.ID And c.Key = id And c.Value.ID = id Then
                            pos = i
                        End If
                        i += 1
                    Next
                    If pos > -1 Then
                        _col.RemoveAt(pos)
                    End If
                End SyncLock
            End If
        End SyncLock
    End Sub
    Public Function exists(id As String) As Boolean
        Dim toret As Boolean = False
        SyncLock _slock
            For Each c As KeyValuePair(Of String, t) In _col
                If c.Key = c.Value.ID And c.Key = id And c.Value.ID = id Then
                    toret = True
                End If
            Next
        End SyncLock
        Return toret
    End Function
    Public Function exists(item As t) As Boolean
        Dim toret As Boolean = False
        SyncLock _slock
            For Each c As KeyValuePair(Of String, t) In _col
                If (c.Key = c.Value.ID And c.Key = item.ID And c.Value.ID = item.ID) Or item.Equals(c) Then
                    toret = True
                End If
            Next
        End SyncLock
        Return toret
    End Function
    Public Sub clear()
        SyncLock _slockmr
            SyncLock _slock
                _col.Clear()
            End SyncLock
        End SyncLock
    End Sub
    Default Public Property Item(id As String) As t
        Get
            Dim toret As t = Nothing
            SyncLock _slockmr
                toret = retrieve(id)
            End SyncLock
            Return toret
        End Get
        Set(value As t)
            SyncLock _slockmr
                place(id, value)
            End SyncLock
        End Set
    End Property
    Public ReadOnly Property getIDs() As String()
        Get
            Dim toret As New List(Of String)
            SyncLock _slock
                For Each c As KeyValuePair(Of String, t) In _col
                    toret.Add(c.Key)
                Next
            End SyncLock
            Return toret.ToArray()
        End Get
    End Property
    Public ReadOnly Property getValues() As t()
        Get
            Dim toret As New List(Of t)
            SyncLock _slock
                For Each c As KeyValuePair(Of String, t) In _col
                    toret.Add(c.Value)
                Next
            End SyncLock
            Return toret.ToArray()
        End Get
    End Property
    Private Function retrieve(id As String) As t
        Dim toret As t = Nothing
        SyncLock _slock
            For Each c As KeyValuePair(Of String, t) In _col
                If c.Key = c.Value.ID And c.Key = id And c.Value.ID = id Then
                    toret = c.Value
                End If
            Next
        End SyncLock
        Return toret
    End Function
    Private Sub place(id As String, val As t)
        SyncLock _slock
            Dim pos As Integer = -1
            Dim i As Integer = 0
            For Each c As KeyValuePair(Of String, t) In _col
                If c.Key = c.Value.ID And c.Key = id And c.Value.ID = id Then
                    pos = i
                End If
                i += 1
            Next
            If pos > -1 Then
                _col(pos) = New KeyValuePair(Of String, t)(id, val)
            End If
        End SyncLock
    End Sub
End Class

Public Interface IID
    Property ID As String
End Interface
