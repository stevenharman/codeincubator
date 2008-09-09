using System;
using System.Threading;

namespace AjaxIntroCodeSamples
{
    public partial class __addPrm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblMessage.Text = DateTime.Now.ToString();
        }

        protected void btnError_Click(object sender, EventArgs e)
        {
            throw new Exception("Something bad happened.");
        }

        protected void btnTimeout_Click(object sender, EventArgs e)
        {
            Thread.Sleep(4000);
        }

        protected void btnShowTime_Click(object sender, EventArgs e)
        {
            lblMessage.Text = DateTime.Now.ToString();
        }
    }
}
