using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;

namespace VendingMachine.WebApp.Helpers
{
    public static class MvcHelper
    {
        public static IHtmlString ToJson(this HtmlHelper htmlHelper, object obj, bool addQuotes = false, bool encode = true)
        {
            var json = JsonConvert.SerializeObject(obj, new JavaScriptDateTimeConverter());
            if (addQuotes)
            {
                json = string.Concat("'", json, "'");
            }

            if (!encode)
            {
                json = htmlHelper.Encode(json);
            }

            return new HtmlString(json);
        }

    }
}