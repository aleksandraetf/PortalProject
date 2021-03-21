using NewsPortal.BusinessLogic.User.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewsPortal.BusinessLogic.User
{
    public interface IUserService
    {
         UserModel GetById(int id);
        AuthenticateResponse Authenticate(AuthenticateRequest model);
    }
}
