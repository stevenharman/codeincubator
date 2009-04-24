Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Data.Linq
Imports System.Linq.Expressions
Imports System.Collections
Imports System.ComponentModel


Public Class TableProxy(Of TEntity As Class)
    Implements ITable(Of TEntity)
    Private ReadOnly _table As Table(Of TEntity)

    Public Sub New(ByVal table As Table(Of TEntity))
        _table = table
    End Sub

    Public Sub Attach(ByVal entity As TEntity) Implements ITable(Of TEntity).Attach
        _table.Attach(entity)
    End Sub

    Public Sub Attach(ByVal entity As TEntity, ByVal asModified As Boolean) Implements ITable(Of TEntity).Attach
        _table.Attach(entity, asModified)
    End Sub

    Public Sub Attach(ByVal entity As TEntity, ByVal original As TEntity) Implements ITable(Of TEntity).Attach
        _table.Attach(entity, original)
    End Sub

    Public Sub AttachAll(Of TSubEntity As TEntity)(ByVal entities As IEnumerable(Of TSubEntity)) Implements ITable(Of TEntity).AttachAll
        _table.AttachAll(entities)
    End Sub

    Public Sub AttachAll(Of TSubEntity As TEntity)(ByVal entities As IEnumerable(Of TSubEntity), ByVal asModified As Boolean) Implements ITable(Of TEntity).AttachAll
        _table.AttachAll(entities, asModified)
    End Sub

    Public Sub DeleteAllOnSubmit(Of TSubEntity As TEntity)(ByVal entities As IEnumerable(Of TSubEntity)) Implements ITable(Of TEntity).DeleteAllOnSubmit
        _table.DeleteAllOnSubmit(entities)
    End Sub

    Public Sub DeleteOnSubmit(ByVal entity As TEntity) Implements ITable(Of TEntity).DeleteOnSubmit
        _table.DeleteOnSubmit(entity)
    End Sub

    Public Overrides Function ToString() As String Implements ITable(Of TEntity).ToString
        Return _table.ToString()
    End Function

    Private Function GetEnumerator() As IEnumerator(Of TEntity) Implements IEnumerable(Of TEntity).GetEnumerator
        Return _table.GetEnumerator()
    End Function

    Public Function GetModifiedMembers(ByVal entity As TEntity) As ModifiedMemberInfo() Implements ITable(Of TEntity).GetModifiedMembers
        Return _table.GetModifiedMembers(entity)
    End Function

    Public Function GetNewBindingList() As IBindingList Implements ITable(Of TEntity).GetNewBindingList
        Return _table.GetNewBindingList()
    End Function

    Public Function GetOriginalEntityState(ByVal entity As TEntity) As TEntity Implements ITable(Of TEntity).GetOriginalEntityState
        Return _table.GetOriginalEntityState(entity)
    End Function

    Public Sub InsertAllOnSubmit(Of TSubEntity As TEntity)(ByVal entities As IEnumerable(Of TSubEntity)) Implements ITable(Of TEntity).InsertAllOnSubmit
        _table.InsertAllOnSubmit(entities)
    End Sub

    Public Sub InsertOnSubmit(ByVal entity As TEntity) Implements ITable(Of TEntity).InsertOnSubmit
        _table.InsertOnSubmit(entity)
    End Sub

    Public Sub InsertOnSubmit(ByVal entity As Object) Implements ITable.InsertOnSubmit
        DirectCast(_table, ITable).InsertOnSubmit(entity)
    End Sub

    Public Sub InsertAllOnSubmit(ByVal entities As IEnumerable) Implements ITable.InsertAllOnSubmit
        DirectCast(_table, ITable).InsertAllOnSubmit(entities)
    End Sub

    Public Sub Attach(ByVal entity As Object) Implements ITable.Attach
        DirectCast(_table, ITable).Attach(entity)
    End Sub

    Public Sub Attach(ByVal entity As Object, ByVal asModified As Boolean) Implements ITable.Attach
        DirectCast(_table, ITable).Attach(entity, asModified)
    End Sub

    Public Sub Attach(ByVal entity As Object, ByVal original As Object) Implements ITable.Attach
        DirectCast(_table, ITable).Attach(entity, original)
    End Sub

    Public Sub AttachAll(ByVal entities As IEnumerable) Implements ITable.AttachAll
        DirectCast(_table, ITable).AttachAll(entities)
    End Sub

    Public Sub AttachAll(ByVal entities As IEnumerable, ByVal asModified As Boolean) Implements ITable.AttachAll
        DirectCast(_table, ITable).AttachAll(entities, asModified)
    End Sub

    Public Sub DeleteOnSubmit(ByVal entity As Object) Implements ITable.DeleteOnSubmit
        DirectCast(_table, ITable).DeleteOnSubmit(entity)
    End Sub

    Public Sub DeleteAllOnSubmit(ByVal entities As IEnumerable) Implements ITable.DeleteAllOnSubmit
        DirectCast(_table, ITable).DeleteAllOnSubmit(entities)
    End Sub

    Public Function GetOriginalEntityState(ByVal entity As Object) As Object Implements ITable.GetOriginalEntityState
        Return DirectCast(_table, ITable).GetOriginalEntityState(entity)
    End Function

    Public Function GetModifiedMembers(ByVal entity As Object) As ModifiedMemberInfo() Implements ITable.GetModifiedMembers
        Return DirectCast(_table, ITable).GetModifiedMembers(entity)
    End Function

    Private ReadOnly Property Context() As DataContext Implements ITable.Context
        Get
            Return _table.Context
        End Get
    End Property

    Private ReadOnly Property IsReadOnly() As Boolean Implements ITable.IsReadOnly
        Get
            Return _table.IsReadOnly
        End Get
    End Property

    Private Function GetEnumerator2() As IEnumerator Implements IEnumerable.GetEnumerator
        Return _table.GetEnumerator()
    End Function

    Public ReadOnly Property Expression() As Expression Implements ITable(Of TEntity).Expression
        Get
            Return DirectCast(_table, IQueryable).Expression
        End Get
    End Property

    Public ReadOnly Property ElementType() As Type Implements ITable(Of TEntity).ElementType
        Get
            Return DirectCast(_table, IQueryable).ElementType
        End Get
    End Property

    Public ReadOnly Property Provider() As IQueryProvider Implements ITable(Of TEntity).Provider
        Get
            Return DirectCast(_table, IQueryable).Provider
        End Get
    End Property

    Public Function CreateQuery(ByVal expression As Expression) As IQueryable Implements ITable(Of TEntity).CreateQuery
        Return DirectCast(_table, IQueryProvider).CreateQuery(expression)
    End Function

    Public Function CreateQuery(Of TElement)(ByVal expression As Expression) As IQueryable(Of TElement) Implements ITable(Of TEntity).CreateQuery
        Return DirectCast(_table, IQueryProvider).CreateQuery(Of TElement)(expression)
    End Function

    Public Function Execute(ByVal expression As Expression) As Object Implements ITable(Of TEntity).Execute
        Return DirectCast(_table, IQueryProvider).Execute(expression)
    End Function

    Public Function Execute(Of TResult)(ByVal expression As Expression) As TResult Implements ITable(Of TEntity).Execute
        Return DirectCast(_table, IQueryProvider).Execute(Of TResult)(expression)
    End Function

    Public Function GetList() As IList Implements ITable(Of TEntity).GetList
        Return DirectCast(_table, IListSource).GetList()
    End Function

    Public ReadOnly Property ContainsListCollection() As Boolean Implements ITable(Of TEntity).ContainsListCollection
        Get
            Return DirectCast(_table, IListSource).ContainsListCollection
        End Get
    End Property
End Class

