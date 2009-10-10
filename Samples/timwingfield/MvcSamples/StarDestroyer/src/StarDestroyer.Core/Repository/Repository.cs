using System;
using System.Collections.Generic;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using StarDestroyer.Core.Entities;

namespace StarDestroyer.Core.Repository
{
    public interface IRepository<T>
    {
        T GetById(int Id);
        int Save(T entity);
        void Update(T entity);
        void Delete(T entity);
        IList<T> GetAll();
    }

    public class Repository<T> : IRepository<T>
    {
        private ISessionFactory _sessionFactory;

        public Repository() : this(CreateSessionFactory()){ }

        public Repository(ISessionFactory sessionFactory)
        {
            _sessionFactory = sessionFactory;
        }

        public T GetById(int Id)
        {
            using (var session = _sessionFactory.OpenSession())
            {
                return session.Get<T>(Id);
            }
        }

        public int Save(T entity)
        {
            using (var session = _sessionFactory.OpenSession())
            {
                return (int)session.Save(entity);
            }
        }

        public void Update(T entity)
        {
            using (var session = _sessionFactory.OpenSession())
            {
                session.SaveOrUpdate(entity);
                session.Flush();
            }
        }

        public void Delete(T entity)
        {
            using (var session = _sessionFactory.OpenSession())
            {
                session.Delete(entity);
                session.Flush();
            }
        }

        public IList<T> GetAll()
        {
            using (var session = _sessionFactory.OpenSession())
            {
                return session.CreateCriteria(typeof (T)).List<T>();
            }
        }

        private static ISessionFactory CreateSessionFactory()
        {
            const string dbFile = @"StarDestroyerCLAIMS.db";

            return Fluently.Configure()
                .Database(SQLiteConfiguration.Standard
                    .UsingFile(dbFile))
                .Mappings(m =>
                    m.FluentMappings.AddFromAssemblyOf<AssaultItem>())
                .BuildSessionFactory();
        }
    }
}