using System;
using System.Collections.Generic;
using System.Text;
using Toy.Core.Entities.Concrete;
using Toy.Core.Utilities.Results;
using Toy.Core.Utilities.Security.JWT;
using Toy.Entities.Dtos;

namespace Toy.Business.Abstract
{
   public interface IAuthService
    {
        IDataResult<User> Login(UserForLoginDto userForLoginDto);
        IDataResult<User> Register(UserForRegisterDto userForRegisterDto);
        IDataResult<AccessToken> CreateAccessToken(User user);
        IResult UserExists(string email);
    }
}
