using System.ComponentModel;
using System.Linq;
using System.Web.Services;
using System.Text;

namespace AjaxIntroCodeSamples
{
    /// <summary>
    /// Summary description for callbacks
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [ToolboxItem(false)]
    [System.Web.Script.Services.ScriptService]
    public class callback : WebService
    {
        private const int RecordsPerPage = 3;

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]
        public myObject getMyObject()
        {
            var obj = new myObject {Name = "Rick Nash", Number=61, Sport = Sports.Hockey};
            return obj;
        }

        #region callbackPaging methods
        [WebMethod]
        public string PagingLinks()
        {
            var pages = ObjectHelper.GetAllMyObjects().Count / RecordsPerPage;

            var sb = new StringBuilder();
            sb.Append("Page: ");
            for(var i=1; i <= pages; i++)
            {
                sb.Append("<a href=\"javascript: LoadDataForPageNumber(")
                    .Append(i)
                    .Append(")\">")
                    .Append(i)
                    .Append("</a>&nbsp;&nbsp;");
            }
            return sb.ToString();
        }

        [WebMethod]
        public string GetTableForPageNumber(int pageNumber)
        {
            var myObjects = ObjectHelper.GetAllMyObjects().Skip((pageNumber - 1) * RecordsPerPage).Take(RecordsPerPage).ToList();

            var sb = new StringBuilder();
            sb.Append("<table width=\"400\" cellpadding=\"2\" cellspacing=\"0\" border=\"1\">");
            sb.Append("<tr>")
                .Append(MakeCell("Name"))
                .Append(MakeCell("Number"))
                .Append(MakeCell("Sport"))
                .Append("</tr>");

            foreach(var o in myObjects)
            {
                sb.Append("<tr>")
                    .Append(MakeCell(o.Name))
                    .Append(MakeCell(o.Number.ToString()))
                    .Append(MakeCell(o.Sport))
                    .Append("</tr>");
            }

            sb.Append("</table>");
            return sb.ToString();
        }

        private static string MakeCell(string cellContents)
        {
            var sb = new StringBuilder();
                    sb.Append("<td>")
                    .Append(cellContents)
                    .Append("</td>");
            return sb.ToString();
        }
        #endregion
    }
}
