using System;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Web;

namespace AtomService
{
    [ServiceContract(Namespace = "")]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class Service1
    {
        //http://localhost:1249/Service1.svc/DoWork
        [WebGet(BodyStyle=WebMessageBodyStyle.WrappedRequest, ResponseFormat=WebMessageFormat.Json)] 
        [OperationContract]
        public void DoWork()
        {
            //it will work without this, but just to be safe
            HttpContext.Current.Response.ContentType = "application/json"; 
            string qs = HttpContext.Current.Request.QueryString["callback"];
            HttpContext.Current.Response.Write(qs + "( [{ \"firstName\": \"Martin\", \"lastName\": \"Blank\"}] )");
        }

        
    }
}
