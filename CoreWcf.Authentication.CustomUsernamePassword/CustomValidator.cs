using CoreWCF.IdentityModel.Selectors;
using CoreWCF.IdentityModel.Tokens;

namespace CoreWcf.Authentication.CustomUsernamePassword
{
    public class CustomValidator : UserNamePasswordValidator
    {
        public override void Validate(string userName, string password)
        {
            if (userName == "deneme" && password == "1234")
            {
                return;
            }
            else
                throw new SecurityTokenException();
        }
    }
}
