using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;
using System.Linq.Expressions;
using System.Collections;
using System.ComponentModel;

namespace FakeContext
{
    public class TableProxy<TEntity> : ITable<TEntity>
        where TEntity : class
    {
        private readonly Table<TEntity> _table;

        public TableProxy(Table<TEntity> table)
        {
            _table = table;
        }

        public void Attach(TEntity entity)
        {
            _table.Attach(entity);
        }

        public void Attach(TEntity entity, bool asModified)
        {
            _table.Attach(entity, asModified);
        }

        public void Attach(TEntity entity, TEntity original)
        {
            _table.Attach(entity, original);
        }

        public void AttachAll<TSubEntity>(IEnumerable<TSubEntity> entities) where TSubEntity : TEntity
        {
            _table.AttachAll(entities);
        }

        public void AttachAll<TSubEntity>(IEnumerable<TSubEntity> entities, bool asModified) where TSubEntity : TEntity
        {
            _table.AttachAll(entities, asModified);
        }

        public void DeleteAllOnSubmit<TSubEntity>(IEnumerable<TSubEntity> entities) where TSubEntity : TEntity
        {
            _table.DeleteAllOnSubmit(entities);
        }

        public void DeleteOnSubmit(TEntity entity)
        {
            _table.DeleteOnSubmit(entity);
        }

        string ITable<TEntity>.ToString()
        {
            return _table.ToString();
        }

        IEnumerator<TEntity> IEnumerable<TEntity>.GetEnumerator()
        {
            return _table.GetEnumerator();
        }

        public ModifiedMemberInfo[] GetModifiedMembers(TEntity entity)
        {
            return _table.GetModifiedMembers(entity);
        }

        public IBindingList GetNewBindingList()
        {
            return _table.GetNewBindingList();
        }

        public TEntity GetOriginalEntityState(TEntity entity)
        {
            return _table.GetOriginalEntityState(entity);
        }

        public void InsertAllOnSubmit<TSubEntity>(IEnumerable<TSubEntity> entities) where TSubEntity : TEntity
        {
            _table.InsertAllOnSubmit(entities);
        }

        public void InsertOnSubmit(TEntity entity)
        {
            _table.InsertOnSubmit(entity);
        }

        public void InsertOnSubmit(object entity)
        {
            ((ITable)_table).InsertOnSubmit(entity);
        }

        public void InsertAllOnSubmit(IEnumerable entities)
        {
            ((ITable)_table).InsertAllOnSubmit(entities);
        }

        public void Attach(object entity)
        {
            ((ITable)_table).Attach(entity);
        }

        public void Attach(object entity, bool asModified)
        {
            ((ITable)_table).Attach(entity, asModified);
        }

        public void Attach(object entity, object original)
        {
            ((ITable)_table).Attach(entity, original);
        }

        public void AttachAll(IEnumerable entities)
        {
            ((ITable)_table).AttachAll(entities);
        }

        public void AttachAll(IEnumerable entities, bool asModified)
        {
            ((ITable)_table).AttachAll(entities, asModified);
        }

        public void DeleteOnSubmit(object entity)
        {
            ((ITable)_table).DeleteOnSubmit(entity);
        }

        public void DeleteAllOnSubmit(IEnumerable entities)
        {
            ((ITable)_table).DeleteAllOnSubmit(entities);
        }

        public object GetOriginalEntityState(object entity)
        {
            return ((ITable)_table).GetOriginalEntityState(entity);
        }

        public ModifiedMemberInfo[] GetModifiedMembers(object entity)
        {
            return ((ITable)_table).GetModifiedMembers(entity);
        }

        DataContext ITable.Context
        {
            get { return _table.Context; }
        }

        bool ITable.IsReadOnly
        {
            get { return _table.IsReadOnly; }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _table.GetEnumerator();
        }

        public Expression Expression
        {
            get { return ((IQueryable)_table).Expression; }
        }

        public Type ElementType
        {
            get { return ((IQueryable)_table).ElementType; }
        }

        public IQueryProvider Provider
        {
            get { return ((IQueryable)_table).Provider; }
        }

        public IQueryable CreateQuery(Expression expression)
        {
            return ((IQueryProvider)_table).CreateQuery(expression);
        }

        public IQueryable<TElement> CreateQuery<TElement>(Expression expression)
        {
            return ((IQueryProvider)_table).CreateQuery<TElement>(expression);
        }

        public object Execute(Expression expression)
        {
            return ((IQueryProvider)_table).Execute(expression);
        }

        public TResult Execute<TResult>(Expression expression)
        {
            return ((IQueryProvider)_table).Execute<TResult>(expression);
        }

        public IList GetList()
        {
            return ((IListSource)_table).GetList();
        }

        public bool ContainsListCollection
        {
            get { return ((IListSource)_table).ContainsListCollection; }
        }
    }
}
