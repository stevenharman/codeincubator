using System;
using System.Web.Services;

namespace AjaxIntroCodeSamples
{
    public partial class callbacks1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {}

        [WebMethod]
        public static string GetPageMethod()
        {
            return "Page Method Call";
        }
    }
}
