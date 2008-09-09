using System.Collections.Generic;

namespace MvcApplication.Models
{
    public interface IProductRepository
    {
        IProduct Get(int ProductId);
        IEnumerable<IProduct> Select();
        bool Save(IProduct product);
    }
}