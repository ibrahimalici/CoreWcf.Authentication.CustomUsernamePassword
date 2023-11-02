using CoreWCF;
using CoreWCF.Web;

namespace CoreWcf.Authentication.CustomUsernamePassword
{
    public class Service : IService
    {
        public string GetStr()
        {
            return "Test";
        }
    }
}
