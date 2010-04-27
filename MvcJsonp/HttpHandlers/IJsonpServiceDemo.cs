using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;

namespace MvcJsonp.HttpHandlers
{
    // NOTE: If you change the interface name "IJsonpServiceDemo" here, you must also update the reference to "IJsonpServiceDemo" in Web.config.
    [ServiceContract]
    public interface IJsonpServiceDemo
    {
        [OperationContract]
        [WebGet( 
            ResponseFormat = WebMessageFormat.Json)]
        Customer GetCustomerAsObject();

        [OperationContract]
        [WebGet(
            ResponseFormat = WebMessageFormat.Json)]
        string GetCustomerAsString();
    }
}
