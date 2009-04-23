Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.ComponentModel
Imports System.Data.Linq

Namespace FakeContext
    Public Interface ITable(Of TEntity As Class)
        Inherits IQueryable(Of TEntity)
        Inherits IQueryProvider
        Inherits ITable
        Inherits IListSource
        Sub Attach(ByVal entity As TEntity)
        Sub Attach(ByVal entity As TEntity, ByVal asModified As Boolean)
        Sub Attach(ByVal entity As TEntity, ByVal original As TEntity)
        Sub AttachAll(Of TSubEntity As TEntity)(ByVal entities As IEnumerable(Of TSubEntity))
        Sub AttachAll(Of TSubEntity As TEntity)(ByVal entities As IEnumerable(Of TSubEntity), ByVal asModified As Boolean)
        Sub DeleteAllOnSubmit(Of TSubEntity As TEntity)(ByVal entities As IEnumerable(Of TSubEntity))
        Sub DeleteOnSubmit(ByVal entity As TEntity)
        Function GetModifiedMembers(ByVal entity As TEntity) As ModifiedMemberInfo()
        Function GetNewBindingList() As IBindingList
        Function GetOriginalEntityState(ByVal entity As TEntity) As TEntity
        Sub InsertAllOnSubmit(Of TSubEntity As TEntity)(ByVal entities As IEnumerable(Of TSubEntity))
        Sub InsertOnSubmit(ByVal entity As TEntity)
        Function ToString() As String
    End Interface

End Namespace