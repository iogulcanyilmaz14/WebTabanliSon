using System;
using System.Collections.Generic;
using System.Text;
using Toy.Core.DataAccess.EntityFramework;
using Toy.Core.Entities.Concrete;
using Toy.DataAccess.Abstract;
using System.Linq;


namespace Toy.DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, OyuncakSatisContext>, IUserDal
    {
        public List<OperationClaim> GetOperationClaims(User user)
        {
            using (OyuncakSatisContext context = new OyuncakSatisContext()) 
            {
                var result = from userOperationClaim in context.UserOperationClaims
                             join operationClaim in context.OperationClaims
                             on userOperationClaim.OperationClaimId equals operationClaim.Id
                             where userOperationClaim.UserId == user.Id
                             select new OperationClaim { Id = operationClaim.Id, Name = operationClaim.Name };
                
                return result.ToList();

            }
        }
    }
}
