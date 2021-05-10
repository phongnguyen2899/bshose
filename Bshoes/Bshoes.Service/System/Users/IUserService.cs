using Bshoes.ViewModel.System;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Bshoes.Service.System.Users
{
   public interface IUserService
    {
        AuthenticateResponse Authenticate(AuthenticateRequest model,string ip);
        AuthenticateResponse RefreshToken(string token, string ip);
        bool RevokeToken(string token, string ipAddress);

        // get user

        List<UserViewModel>  GetAllUser();

    }
}
