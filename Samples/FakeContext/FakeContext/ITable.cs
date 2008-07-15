using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Data.Linq;

namespace FakeContext
{
    public interface ITable<TEntity> : IQueryable<TEntity>, IQueryProvider, ITable, IListSource
        where TEntity : class
    {
        void Attach(TEntity entity);
        void Attach(TEntity entity, bool asModified);
        void Attach(TEntity entity, TEntity original);
        void AttachAll<TSubEntity>(IEnumerable<TSubEntity> entities) where TSubEntity : TEntity;
        void AttachAll<TSubEntity>(IEnumerable<TSubEntity> entities, bool asModified) where TSubEntity : TEntity;
        void DeleteAllOnSubmit<TSubEntity>(IEnumerable<TSubEntity> entities) where TSubEntity : TEntity;
        void DeleteOnSubmit(TEntity entity);
        ModifiedMemberInfo[] GetModifiedMembers(TEntity entity);
        IBindingList GetNewBindingList();
        TEntity GetOriginalEntityState(TEntity entity);
        void InsertAllOnSubmit<TSubEntity>(IEnumerable<TSubEntity> entities) where TSubEntity : TEntity;
        void InsertOnSubmit(TEntity entity);
        string ToString();
    }
}
