Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.ComponentModel
Imports System.Data.Linq

    Public Interface ITable(Of TEntity As Class)
        Inherits IQueryable(Of TEntity)
        Inherits IQueryProvider
        Inherits ITable
        Inherits IListSource
        Overloads Sub Attach(ByVal entity As TEntity)
        Overloads Sub Attach(ByVal entity As TEntity, ByVal asModified As Boolean)
        Overloads Sub Attach(ByVal entity As TEntity, ByVal original As TEntity)
        Overloads Sub AttachAll(Of TSubEntity As TEntity)(ByVal entities As IEnumerable(Of TSubEntity))
        Overloads Sub AttachAll(Of TSubEntity As TEntity)(ByVal entities As IEnumerable(Of TSubEntity), ByVal asModified As Boolean)
        Overloads Sub DeleteAllOnSubmit(Of TSubEntity As TEntity)(ByVal entities As IEnumerable(Of TSubEntity))
        Overloads Sub DeleteOnSubmit(ByVal entity As TEntity)
        Overloads Function GetModifiedMembers(ByVal entity As TEntity) As ModifiedMemberInfo()
        Overloads Function GetNewBindingList() As IBindingList
        Overloads Function GetOriginalEntityState(ByVal entity As TEntity) As TEntity
        Overloads Sub InsertAllOnSubmit(Of TSubEntity As TEntity)(ByVal entities As IEnumerable(Of TSubEntity))
        Overloads Sub InsertOnSubmit(ByVal entity As TEntity)
        Function ToString() As String
    End Interface
