using System.Collections.Generic;

namespace MvcDemoApp_Preview3.Models
{
    public interface IBeerRepository
    {
        Beer GetBeerById(int id);
        IList<Beer> GetAllBeers();
        IList<Beer> GetBeersForPage(int pageNumber, int numPerPage);
    }
}