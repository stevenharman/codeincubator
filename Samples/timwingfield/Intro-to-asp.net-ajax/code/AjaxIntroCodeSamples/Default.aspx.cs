using System;

namespace AjaxIntroCodeSamples
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblMessage.Text = DateTime.Now.ToString();
        }

        protected void Button1_onClick(object sender, EventArgs e)
        {
            Label1.Text = DateTime.Now.ToString();
        }
    }
}
