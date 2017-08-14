using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.WebPages;
using System.Web.Mvc;

namespace WebAPIAngularJs
{
    public class HelperBase:HelperPage
    {
        public static new HtmlHelper Html
        {
            get { return ((WebViewPage)WebPageContext.Current.Page).Html; }
        }
        public static System.Web.Mvc.UrlHelper Url
        {
            get { return ((WebViewPage)WebPageContext.Current.Page).Url; }
        }
    }
}