using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace StarDestroyer.Models
{
    public class PartialRequest
    {
        public RouteValueDictionary RouteValues { get; set; }

        public PartialRequest(object routeValues)
        {
            RouteValues = new RouteValueDictionary(routeValues);
        }

        public void Inoke(ControllerContext context)
        {
            var rd = new RouteData {Route = context.RouteData.Route, RouteHandler = context.RouteData.RouteHandler};
            foreach (var pair in RouteValues)
            {
                rd.Values.Add(pair.Key, pair.Value);
            }

            IHttpHandler handler = new MvcHandler(new RequestContext(context.HttpContext, rd));
            handler.ProcessRequest(HttpContext.Current);
        }
    }
}