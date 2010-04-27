using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace MvcJsonp.HttpHandlers
{
    /// <summary>
    /// Summary description for $codebehindclassname$
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class JsonpHandlerDemo : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            //it will work without this, but just to be safe
            HttpContext.Current.Response.ContentType = "application/json";
            string qs = HttpContext.Current.Request.QueryString["callback"];
            HttpContext.Current.Response.Write(qs + "( [{ \"firstName\": \"Martin\", \"lastName\": \"Blank\"}] )");
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}
