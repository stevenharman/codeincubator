using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace MvcDemoAppTests.Controllers
{
    public class FakeViewEngine : IViewEngine
    {
        public ViewContext ViewContext { get; private set; }

        public void RenderView(ViewContext viewContext)
        {
            this.ViewContext = viewContext;
        }
    }
}
