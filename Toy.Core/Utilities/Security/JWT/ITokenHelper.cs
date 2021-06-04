using System;
using System.Collections.Generic;
using System.Text;
using Toy.Core.Entities.Concrete;

namespace Toy.Core.Utilities.Security.JWT
{
   public interface ITokenHelper
    {
        AccessToken CreateToken(User user, List<OperationClaim> operationClaims);
    }
}
