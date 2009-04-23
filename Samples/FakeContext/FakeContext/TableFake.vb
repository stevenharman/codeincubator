Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Collections
Imports System.Linq.Expressions
Imports System.Data.Linq
Imports System.ComponentModel

Namespace FakeContext
    Public Class TableFake(Of TEntity As Class)
        Implements ITable(Of TEntity)
        Private ReadOnly _entities As IList(Of TEntity)

        Public Sub New(ByVal entities As IList(Of TEntity))
            _entities = entities
        End Sub

        Public Function GetEnumerator() As IEnumerator(Of TEntity)
            Return _entities.GetEnumerator()
        End Function

        Private Function GetEnumerator() As IEnumerator Implements IEnumerable.GetEnumerator
            Return _entities.GetEnumerator()
        End Function

        Public ReadOnly Property Expression() As Expression
            Get
                Return _entities.AsQueryable().Expression
            End Get
        End Property

        Public ReadOnly Property ElementType() As Type
            Get
                Return _entities.AsQueryable().ElementType
            End Get
        End Property

        Public ReadOnly Property Provider() As IQueryProvider
            Get
                Return _entities.AsQueryable().Provider
            End Get
        End Property

        Public Function CreateQuery(ByVal expression As Expression) As IQueryable
            Return Provider.CreateQuery(expression)
        End Function

        Public Function CreateQuery(Of TElement)(ByVal expression As Expression) As IQueryable(Of TElement)
            Return Provider.CreateQuery(Of TElement)(expression)
        End Function

        Public Function Execute(ByVal expression As Expression) As Object
            Return Provider.Execute(expression)
        End Function

        Public Function Execute(Of TResult)(ByVal expression As Expression) As TResult
            Return Provider.Execute(Of TResult)(expression)
        End Function

        Public Sub InsertOnSubmit(ByVal entity As Object)
            Attach(entity)
        End Sub

        Public Sub InsertAllOnSubmit(ByVal entities As IEnumerable)
            AttachAll(entities)
        End Sub

        Public Sub Attach(ByVal entity As Object)
            Dim item = TryCast(entity, TEntity)
            If item IsNot Nothing Then
                _entities.Add(item)
            End If
        End Sub

        Public Sub Attach(ByVal entity As Object, ByVal asModified As Boolean)
            Attach(entity)
        End Sub

        Public Sub Attach(ByVal entity As Object, ByVal original As Object)
            Attach(entity)
        End Sub

        Public Sub AttachAll(ByVal entities As IEnumerable)
            For Each entity In entities.OfType(Of TEntity)()
                _entities.Add(entity)
            Next
        End Sub

        Public Sub AttachAll(ByVal entities As IEnumerable, ByVal asModified As Boolean)
            AttachAll(entities)
        End Sub

        Public Sub DeleteOnSubmit(ByVal entity As Object)
            Dim item = TryCast(entity, TEntity)
            If item IsNot Nothing Then
                _entities.Remove(item)
            End If
        End Sub

        Public Sub DeleteAllOnSubmit(ByVal entities As IEnumerable)
            For Each entity In entities.OfType(Of TEntity)()
                DeleteOnSubmit(entity)
            Next
        End Sub

        Public Function GetOriginalEntityState(ByVal entity As Object) As Object
            Return entity
        End Function

        Public Function GetModifiedMembers(ByVal entity As Object) As ModifiedMemberInfo()
            Return New ModifiedMemberInfo(-1) {}
        End Function

        Public ReadOnly Property Context() As DataContext
            Get
                Return Nothing
            End Get
        End Property

        Public ReadOnly Property IsReadOnly() As Boolean
            Get
                Return False
            End Get
        End Property

        Public Function GetList() As IList
            Return _entities.ToList()
        End Function

        Public ReadOnly Property ContainsListCollection() As Boolean
            Get
                Return True
            End Get
        End Property

        Public Sub Attach(ByVal entity As TEntity)
            _entities.Add(entity)
        End Sub

        Public Sub Attach(ByVal entity As TEntity, ByVal asModified As Boolean)
            Attach(entity)
        End Sub

        Public Sub Attach(ByVal entity As TEntity, ByVal original As TEntity)
            Attach(entity)
        End Sub

        Public Sub AttachAll(Of TSubEntity As TEntity)(ByVal entities As IEnumerable(Of TSubEntity))
            For Each entity In entities.ToList()
                Attach(entity)
            Next
        End Sub

        Public Sub AttachAll(Of TSubEntity As TEntity)(ByVal entities As IEnumerable(Of TSubEntity), ByVal asModified As Boolean)
            AttachAll(entities)
        End Sub

        Public Sub DeleteAllOnSubmit(Of TSubEntity As TEntity)(ByVal entities As IEnumerable(Of TSubEntity))
            For Each entity In entities.ToList()
                DeleteOnSubmit(entity)
            Next
        End Sub

        Public Sub DeleteOnSubmit(ByVal entity As TEntity)
            _entities.Remove(entity)
        End Sub

        Public Function GetModifiedMembers(ByVal entity As TEntity) As ModifiedMemberInfo()
            Return New ModifiedMemberInfo(-1) {}
        End Function

        Public Function GetNewBindingList() As IBindingList
            Return New BindingList(Of TEntity)(_entities)
        End Function

        Public Function GetOriginalEntityState(ByVal entity As TEntity) As TEntity
            Return entity
        End Function

        Public Sub InsertAllOnSubmit(Of TSubEntity As TEntity)(ByVal entities As IEnumerable(Of TSubEntity))
            For Each entity In entities.ToList()
                Attach(entity)
            Next
        End Sub

        Public Sub InsertOnSubmit(ByVal entity As TEntity)
            Attach(entity)
        End Sub
    End Class
End Namespace
