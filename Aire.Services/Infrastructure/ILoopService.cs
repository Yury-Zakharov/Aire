using Aire.Domain;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace Aire.Services.Infrastructure
{
    [ServiceContract]
    public interface ILoopService
    {        
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "/events", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        [return: MessageParameter(Name = "events") ]
        IEnumerable<LoopEvent> GetEvents();

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "/apps", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        void AddApplication(IEnumerable<LoopApplication> applications);
    }
}