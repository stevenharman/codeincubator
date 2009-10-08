using System.Collections.Generic;
using System.Web.Mvc;
using StarDestroyer.Controllers;
using MvcContrib;

namespace StarDestroyer.Helpers.Filters
{
    public class RequiresSuggestionsFilterAttribute : ActionFilterAttribute
    {
        private ISuggestionRepository _suggestionRepository;

        public RequiresSuggestionsFilterAttribute() : this(new SuggestionRepository())
        {
        }

        public RequiresSuggestionsFilterAttribute(ISuggestionRepository suggestionRepository)
        {
            _suggestionRepository = suggestionRepository;
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            ControllerBase controller = filterContext.Controller;
            var suggestedProducts = _suggestionRepository.GetSuggestedProducts();
            controller.ViewData.Add(suggestedProducts);
        }
    }

    public interface ISuggestionRepository
    {
        List<Product> GetSuggestedProducts();
    }

    public class SuggestionRepository : ISuggestionRepository
    {
        public List<Product> GetSuggestedProducts()
        {
            return new List<Product>()
                       {
                           new Product() {Description = "Featuring forward-firing missile and secret compartment for lightsabers, and includes Anakin, Ahsoka and R2-D2 with The Clone Wars decoration.", Name = "Anakin’s Y-wing Starfighter"},
                           new Product() {Description = "Switching between flying air attack and walking ground assault modes, the Hyena Droid is a powerful multi-purpose weapon for the Separatists as seen in Star Wars: The Clone Wars. Features four dropping bombs and three all-new rocket battle droid minifigures.", Name = "Hyena Droid Bomber"}
                       };
        }
    }
}