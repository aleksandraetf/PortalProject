using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using NewsPortal.BusinessLogic.User.Model;
using NewsPortal.Repository.UnitOfWork;
using NewsPortalApplication.Helper;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace NewsPortal.BusinessLogic.User
{
    public class UserService : IUserService
    {

        private readonly IUserUnitOfWork _userUnitOfWork;
        private readonly AppSettings _appSettings;


        public UserService(IUserUnitOfWork newsUnitOfWork, IOptions<AppSettings> appSettings)
        {
            _userUnitOfWork = newsUnitOfWork;
            _appSettings = appSettings.Value;
        }


        public UserModel GetById(int id)
        {
            var user= _userUnitOfWork.User.Get(id);
            return new UserModel
            {
                Id = user.Id,
                Username = user.Username,
                FirstName = user.FirstName,
                LastName = user.LastName
            };

        }

        public AuthenticateResponse Authenticate(AuthenticateRequest model)
        {
            var user = _userUnitOfWork.User.GetUser(model.Username, model.Password);

            // return null if user not found
            if (user == null) return null;

            // authentication successful so generate jwt token
            var token = generateJwtToken(UserToUserModel(user));

            return new AuthenticateResponse(UserToUserModel(user), token);
        }

        private UserModel UserToUserModel(DAL.NewsPortal.User user)
        {
            return new UserModel
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Username = user.Username
            };
        }

        private string generateJwtToken(UserModel user)
        {
            // generate token that is valid for 7 days
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", user.Id.ToString()) }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
           
            return tokenHandler.WriteToken(token);
        }
    }
}
