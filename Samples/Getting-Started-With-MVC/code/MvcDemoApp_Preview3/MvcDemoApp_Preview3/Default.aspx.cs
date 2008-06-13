using System;
using System.Collections.Generic;
using System.Web.UI;

namespace MvcDemoApp_Preview3
{
    public partial class _Default : Page
    {
        public void Page_Load(object sender, System.EventArgs e)
        {
            Response.Redirect("~/Home");
        }
    }
}
