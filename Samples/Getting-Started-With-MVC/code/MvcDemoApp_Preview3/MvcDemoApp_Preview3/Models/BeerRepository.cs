using System.Collections.Generic;
using System.Linq;

namespace MvcDemoApp_Preview3.Models
{
    public class BeerRepository : IBeerRepository
    {
        private BeerDataContext db = new BeerDataContext();

        public Beer GetBeerById(int id)
        {
            return db.Beers.Single(b => b.id == id);
        }

        public IList<Beer> GetAllBeers()
        {
            return db.Beers.ToList();
        }

        public IList<Beer> GetBeersForPage(int pageNumber, int numPerPage)
        {
            int numberToSkip = (pageNumber - 1) * numPerPage;

            return db.Beers.OrderBy(b =>b.Name).Skip(numberToSkip).Take(numPerPage).ToList();
        }

        public IList<BeerType> GetAllBeerTypes()
        {
            return db.BeerTypes.OrderBy(t => t.Name).ToList();
        }

        public IList<Brewery> GetAllBreweries()
        {
            return db.Breweries.OrderBy(b => b.Name).ToList();
        }
    }
}