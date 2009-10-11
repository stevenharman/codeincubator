using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using StarDestroyer.Core.Entities;
using StarDestroyer.Core.Helpers;
using NHibernate.Linq;
using System.Linq;
using StarDestroyer.Core.Helpers;

namespace StarDestroyer.Core.Repository
{
    public interface IProductRepository : IRepository<Product>
    {
        List<Product> SearchProducts(SearchParameters searchParams);
    }

    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository() : base(CreateSessionFactory()) { }

        public List<Product> SearchProducts(SearchParameters searchParams)
        {
            using (var session = _sessionFactory.OpenSession())
            {
                var source = session.Linq<Product>();
                var result = new List<Product>();

                var param = Expression.Parameter(typeof(Product), "product");

                var sortExpression = Expression.Lambda<Func<Product, object>>(Expression.Property(param, searchParams.SortColumn), param);

                if (searchParams.Ascending)
                    result = source.OrderBy(sortExpression).Skip((searchParams.Page - 1) * searchParams.Count).Take(searchParams.Count).ToList();
                else
                    result = source.OrderByDescending(sortExpression).Skip((searchParams.Page - 1) * searchParams.Count).Take(searchParams.Count).ToList();

                return result;
            }
        }
    }
}