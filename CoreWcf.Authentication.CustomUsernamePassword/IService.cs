using CoreWCF.Web;
using CoreWCF;

namespace CoreWcf.Authentication.CustomUsernamePassword
{
    [ServiceContract]
    public interface IService
    {
        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        string GetStr();
    }
}
