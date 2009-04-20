Public Class ActionHelper(Of T)

    Private _methodName As String
    Public Property MethodName() As String
        Get
            Return _methodName
        End Get
        Set(ByVal value As String)
            _methodName = value
        End Set
    End Property

    Private _parameters() As Object
    Public Property Parameters() As Object()
        Get
            Return _parameters
        End Get
        Set(ByVal value As Object())
            _parameters = value
        End Set
    End Property

    Private _types() As Type
    Public Property Types() As Type()
        Get
            Return _types
        End Get
        Set(ByVal value As Type())
            _types = value
        End Set
    End Property

    Public Sub Action(ByVal obj As T)
        Dim types() As Type = {}

        If _types Is Nothing Then
            If Parameters IsNot Nothing Then
                types = Parameters.Select(Function(o) o.GetType()).ToArray()
            End If
        Else
            types = _types
        End If

        GetType(T).GetMethod(MethodName, types).Invoke(obj, Parameters)
    End Sub

End Class