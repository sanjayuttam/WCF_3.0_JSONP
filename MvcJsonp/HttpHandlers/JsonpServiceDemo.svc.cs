using System.ServiceModel;
using System.ServiceModel.Web;
using System.ServiceModel.Activation;
using System.Web;
using System.ServiceModel.Channels;

namespace MvcJsonp.HttpHandlers
{
    //[ServiceContract(Namespace = "")]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class JsonpServiceDemo : IJsonpServiceDemo
    {
        //jsonpExample/pub/httphandlers/jsonpServiceDemo.svc/GetCustomerAsObject?callback=hi
        public Customer GetCustomerAsObject()
        {
            //Returning like this will mean you don't need to do an eval() in JS 
            string callBack = GetQueryString("callback");
            return new Customer{ firstName = "Martin", lastName= "Blanke" };
        }

        //jsonpExample/pub/httphandlers/jsonpServiceDemo.svc/GetCustomerAsString?callback=hi
        public string GetCustomerAsString()
        {
            //You will need to do an eval() on this, but I'm not sure you can 
            //utlize jsonP without returning a string
            string callBack = GetQueryString("callback");
            return string.Format("{0}({1});", callBack, new Customer { firstName = "xVal", lastName = "yVal" });
        }

        private string GetQueryString(string key) {
            if (OperationContext.Current == null) return string.Empty;
            OperationContext context = OperationContext.Current;
            MessageProperties properties = context.IncomingMessageProperties;
            HttpRequestMessageProperty requestProperty = properties[HttpRequestMessageProperty.Name] as HttpRequestMessageProperty;

            string queryString = requestProperty.QueryString;
            if (!queryString.Contains(key)) return string.Empty;
            return HttpUtility.ParseQueryString(queryString)[key];
        }
    }

    public class Customer 
    {
        public string firstName { get; set; }
        public string lastName { get; set; }  
    }
}
