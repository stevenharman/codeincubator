Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Collections
Imports System.Linq.Expressions
Imports System.Data.Linq
Imports System.ComponentModel


Public Class TableFake(Of TEntity As Class)
    Implements ITable(Of TEntity)
    Private ReadOnly _entities As IList(Of TEntity)

    Public Sub New(ByVal entities As IList(Of TEntity))
        _entities = entities
    End Sub

    Public Function GetEnumerator() As IEnumerator(Of TEntity) Implements IEnumerable(Of TEntity).GetEnumerator
        Return _entities.GetEnumerator()
    End Function

    Private Function GetEnumerator2() As IEnumerator Implements IEnumerable.GetEnumerator
        Return _entities.GetEnumerator()
    End Function

    Public ReadOnly Property Expression() As Expression Implements ITable(Of TEntity).Expression
        Get
            Return _entities.AsQueryable().Expression
        End Get
    End Property

    Public ReadOnly Property ElementType() As Type Implements ITable(Of TEntity).ElementType
        Get
            Return _entities.AsQueryable().ElementType
        End Get
    End Property

    Public ReadOnly Property Provider() As IQueryProvider Implements ITable(Of TEntity).Provider
        Get
            Return _entities.AsQueryable().Provider
        End Get
    End Property

    Public Function CreateQuery(ByVal expression As Expression) As IQueryable Implements ITable(Of TEntity).CreateQuery
        Return Provider.CreateQuery(expression)
    End Function

    Public Function CreateQuery(Of TElement)(ByVal expression As Expression) As IQueryable(Of TElement) Implements ITable(Of TEntity).CreateQuery
        Return Provider.CreateQuery(Of TElement)(expression)
    End Function

    Public Function Execute(ByVal expression As Expression) As Object Implements ITable(Of TEntity).Execute
        Return Provider.Execute(expression)
    End Function

    Public Function Execute(Of TResult)(ByVal expression As Expression) As TResult Implements ITable(Of TEntity).Execute
        Return Provider.Execute(Of TResult)(expression)
    End Function

    Public Sub InsertOnSubmit(ByVal entity As Object) Implements ITable.InsertOnSubmit
        Attach(entity)
    End Sub

    Public Sub InsertAllOnSubmit(ByVal entities As IEnumerable) Implements ITable.InsertAllOnSubmit
        AttachAll(entities)
    End Sub

    Public Sub Attach(ByVal entity As Object) Implements ITable.Attach
        Dim item = TryCast(entity, TEntity)
        If item IsNot Nothing Then
            _entities.Add(item)
        End If
    End Sub

    Public Sub Attach(ByVal entity As Object, ByVal asModified As Boolean) Implements ITable.Attach
        Attach(entity)
    End Sub

    Public Sub Attach(ByVal entity As Object, ByVal original As Object) Implements ITable.Attach
        Attach(entity)
    End Sub

    Public Sub AttachAll(ByVal entities As IEnumerable) Implements ITable.AttachAll
        For Each entity In entities.OfType(Of TEntity)()
            _entities.Add(entity)
        Next
    End Sub

    Public Sub AttachAll(ByVal entities As IEnumerable, ByVal asModified As Boolean) Implements ITable.AttachAll
        AttachAll(entities)
    End Sub

    Public Sub DeleteOnSubmit(ByVal entity As Object) Implements ITable.DeleteOnSubmit
        Dim item = TryCast(entity, TEntity)
        If item IsNot Nothing Then
            _entities.Remove(item)
        End If
    End Sub

    Public Sub DeleteAllOnSubmit(ByVal entities As IEnumerable) Implements ITable.DeleteAllOnSubmit
        For Each entity In entities.OfType(Of TEntity)()
            DeleteOnSubmit(entity)
        Next
    End Sub

    Public Function GetOriginalEntityState(ByVal entity As Object) As Object Implements ITable.GetOriginalEntityState
        Return entity
    End Function

    Public Function GetModifiedMembers(ByVal entity As Object) As ModifiedMemberInfo() Implements ITable.GetModifiedMembers
        Return New ModifiedMemberInfo(-1) {}
    End Function

    Public ReadOnly Property Context() As DataContext Implements ITable.Context
        Get
            Return Nothing
        End Get
    End Property

    Public ReadOnly Property IsReadOnly() As Boolean Implements ITable.IsReadOnly
        Get
            Return False
        End Get
    End Property

    Public Function GetList() As IList Implements ITable(Of TEntity).GetList
        Return _entities.ToList()
    End Function

    Public ReadOnly Property ContainsListCollection() As Boolean Implements ITable(Of TEntity).ContainsListCollection
        Get
            Return True
        End Get
    End Property

    Public Sub Attach(ByVal entity As TEntity) Implements ITable(Of TEntity).Attach
        _entities.Add(entity)
    End Sub

    Public Sub Attach(ByVal entity As TEntity, ByVal asModified As Boolean) Implements ITable(Of TEntity).Attach
        Attach(entity)
    End Sub

    Public Sub Attach(ByVal entity As TEntity, ByVal original As TEntity) Implements ITable(Of TEntity).Attach
        Attach(entity)
    End Sub

    Public Sub AttachAll(Of TSubEntity As TEntity)(ByVal entities As IEnumerable(Of TSubEntity)) Implements ITable(Of TEntity).AttachAll
        For Each entity In entities.ToList()
            Attach(entity)
        Next
    End Sub

    Public Sub AttachAll(Of TSubEntity As TEntity)(ByVal entities As IEnumerable(Of TSubEntity), ByVal asModified As Boolean) Implements ITable(Of TEntity).AttachAll
        AttachAll(entities)
    End Sub

    Public Sub DeleteAllOnSubmit(Of TSubEntity As TEntity)(ByVal entities As IEnumerable(Of TSubEntity)) Implements ITable(Of TEntity).DeleteAllOnSubmit
        For Each entity In entities.ToList()
            DeleteOnSubmit(entity)
        Next
    End Sub

    Public Sub DeleteOnSubmit(ByVal entity As TEntity) Implements ITable(Of TEntity).DeleteOnSubmit
        _entities.Remove(entity)
    End Sub

    Public Function GetModifiedMembers(ByVal entity As TEntity) As ModifiedMemberInfo() Implements ITable(Of TEntity).GetModifiedMembers
        Return New ModifiedMemberInfo(-1) {}
    End Function

    Public Function GetNewBindingList() As IBindingList Implements ITable(Of TEntity).GetNewBindingList
        Return New BindingList(Of TEntity)(_entities)
    End Function

    Public Function GetOriginalEntityState(ByVal entity As TEntity) As TEntity Implements ITable(Of TEntity).GetOriginalEntityState
        Return entity
    End Function

    Public Sub InsertAllOnSubmit(Of TSubEntity As TEntity)(ByVal entities As IEnumerable(Of TSubEntity)) Implements ITable(Of TEntity).InsertAllOnSubmit
        For Each entity In entities.ToList()
            Attach(entity)
        Next
    End Sub

    Public Sub InsertOnSubmit(ByVal entity As TEntity) Implements ITable(Of TEntity).InsertOnSubmit
        Attach(entity)
    End Sub

    Public Overrides Function ToString() As String Implements ITable(Of TEntity).ToString
        Return MyBase.ToString()
    End Function
End Class

