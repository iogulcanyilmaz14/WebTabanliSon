using System;
using System.Collections.Generic;
using System.Text;
using Toy.Core.DataAccess;
using Toy.Core.Entities.Concrete;

namespace Toy.DataAccess.Abstract
{
    public interface IUserDal : IEntityRepository<User>
    {
        List<OperationClaim> GetOperationClaims(User user);
    }
}
