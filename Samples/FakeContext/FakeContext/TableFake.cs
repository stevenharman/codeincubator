using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Linq.Expressions;
using System.Data.Linq;
using System.ComponentModel;

namespace FakeContext
{
    public class TableFake<TEntity> : ITable<TEntity>
        where TEntity : class
    {
        private readonly IList<TEntity> _entities;

        public TableFake(IList<TEntity> entities)
        {
            _entities = entities;
        }

        public IEnumerator<TEntity> GetEnumerator()
        {
            return _entities.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _entities.GetEnumerator();
        }

        public Expression Expression
        {
            get { return _entities.AsQueryable().Expression; }
        }

        public Type ElementType
        {
            get { return _entities.AsQueryable().ElementType; }
        }

        public IQueryProvider Provider
        {
            get { return _entities.AsQueryable().Provider; }
        }

        public IQueryable CreateQuery(Expression expression)
        {
            return Provider.CreateQuery(expression);
        }

        public IQueryable<TElement> CreateQuery<TElement>(Expression expression)
        {
            return Provider.CreateQuery<TElement>(expression);
        }

        public object Execute(Expression expression)
        {
            return Provider.Execute(expression);
        }

        public TResult Execute<TResult>(Expression expression)
        {
            return Provider.Execute<TResult>(expression);
        }

        public void InsertOnSubmit(object entity)
        {
            Attach(entity);
        }

        public void InsertAllOnSubmit(IEnumerable entities)
        {
            AttachAll(entities);
        }

        public void Attach(object entity)
        {
            var item = entity as TEntity;
            if (item != null)
                _entities.Add(item);
        }

        public void Attach(object entity, bool asModified)
        {
            Attach(entity);
        }

        public void Attach(object entity, object original)
        {
            Attach(entity);
        }

        public void AttachAll(IEnumerable entities)
        {
            foreach (var entity in entities.OfType<TEntity>())
                _entities.Add(entity);
        }

        public void AttachAll(IEnumerable entities, bool asModified)
        {
            AttachAll(entities);
        }

        public void DeleteOnSubmit(object entity)
        {
            var item = entity as TEntity;
            if (item != null)
                _entities.Remove(item);
        }

        public void DeleteAllOnSubmit(IEnumerable entities)
        {
            foreach (var entity in entities.OfType<TEntity>())
                DeleteOnSubmit(entity);
        }

        public object GetOriginalEntityState(object entity)
        {
            return entity;
        }

        public ModifiedMemberInfo[] GetModifiedMembers(object entity)
        {
            return new ModifiedMemberInfo[0];
        }

        public DataContext Context
        {
            get { return null; }
        }

        public bool IsReadOnly
        {
            get { return false; }
        }

        public IList GetList()
        {
            return _entities.ToList();
        }

        public bool ContainsListCollection
        {
            get { return true; }
        }

        public void Attach(TEntity entity)
        {
            _entities.Add(entity);
        }

        public void Attach(TEntity entity, bool asModified)
        {
            Attach(entity);
        }

        public void Attach(TEntity entity, TEntity original)
        {
            Attach(entity);
        }

        public void AttachAll<TSubEntity>(IEnumerable<TSubEntity> entities) where TSubEntity : TEntity
        {
            foreach (var entity in entities.ToList())
                Attach(entity);
        }

        public void AttachAll<TSubEntity>(IEnumerable<TSubEntity> entities, bool asModified) where TSubEntity : TEntity
        {
            AttachAll(entities);
        }

        public void DeleteAllOnSubmit<TSubEntity>(IEnumerable<TSubEntity> entities) where TSubEntity : TEntity
        {
            foreach (var entity in entities.ToList())
                DeleteOnSubmit(entity);
        }

        public void DeleteOnSubmit(TEntity entity)
        {
            _entities.Remove(entity);
        }

        public ModifiedMemberInfo[] GetModifiedMembers(TEntity entity)
        {
            return new ModifiedMemberInfo[0];
        }

        public IBindingList GetNewBindingList()
        {
            return new BindingList<TEntity>(_entities);
        }

        public TEntity GetOriginalEntityState(TEntity entity)
        {
            return entity;
        }

        public void InsertAllOnSubmit<TSubEntity>(IEnumerable<TSubEntity> entities) where TSubEntity : TEntity
        {
            foreach (var entity in entities.ToList())
                Attach(entity);
        }

        public void InsertOnSubmit(TEntity entity)
        {
            Attach(entity);
        }
    }
}
