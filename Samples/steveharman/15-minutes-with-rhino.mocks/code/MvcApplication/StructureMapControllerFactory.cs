using System;
using System.Web.Mvc;
using StructureMap;

namespace MvcApplication
{
    public class StructureMapControllerFactory : IControllerFactory
    {
        public IController CreateController(RequestContext context, Type controllerType)
        {
            return ObjectFactory.GetNamedInstance<IController>(controllerType.Name);
        }
    }
}
