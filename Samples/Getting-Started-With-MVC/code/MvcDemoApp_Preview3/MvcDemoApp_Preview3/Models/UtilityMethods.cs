using System;
using System.Text;

namespace MvcDemoApp_Preview3.Models
{
    public class UtilityMethods
    {
        public static int PagesNeeded(int totalBeers, int beersPerPage)
        {
            int totalPages = totalBeers / beersPerPage;
            if (totalBeers % beersPerPage > 0)
            {
                totalPages = totalPages + 1;
            }

            return totalPages;
        }

        public static string CreateBeerPleaseContent(Beer beer)
        {
            var sb = new StringBuilder();

            sb.Append("<h3>").Append(beer.Name).Append("</h3>");
            sb.Append("<p><b>Type:</b> ").Append(beer.BeerType.Name).Append("</p>");
            sb.Append("<ul>");
            sb.Append("<li><b>Brewery:</b> ").Append(beer.Brewery.Name).Append("</li>");
            sb.Append("<li><b>Location:</b> ").Append(beer.Brewery.Location).Append("</li>");
            sb.Append("<li><b>Established:</b> ").Append(beer.Brewery.Established).Append("</li>");
            sb.Append("</ul>");
            sb.Append("<p>").Append(beer.Description).Append("</p>");

            return sb.ToString();
        }
    }
}