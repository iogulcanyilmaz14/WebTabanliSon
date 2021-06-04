using System;
using System.Collections.Generic;
using System.Text;
using Toy.Core.Entities.Concrete;
using Toy.Core.Utilities.Results;

namespace Toy.Business.Abstract
{
    public interface IUserService
    {
        IResult Add(User user);
        IResult Delete(User user);
        IResult Update(User user);
        IDataResult<List<OperationClaim>> GetClaims(User user);
        IDataResult<User> GetByMail(string email);
        IDataResult<User> GetById(int userId);
        IDataResult<List<User>> GetAll();
        IDataResult<List<User>> GetAllByUserId(int userId);
    }
}
