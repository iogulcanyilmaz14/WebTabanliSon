using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Toy.Business.Abstract;
using Toy.Business.BusinessAspects.Autofac;
using Toy.Business.Constants;
using Toy.Business.ValidationRules.FluentValidation;
using Toy.Core.Aspects.Autofac.Caching;
using Toy.Core.Aspects.Autofac.Validation;
using Toy.Core.Entities.Concrete;
using Toy.Core.Utilities.Business;
using Toy.Core.Utilities.Results;
using Toy.DataAccess.Abstract;

namespace Toy.Business.Concrete
{
   public class UserManager : IUserService
    {
        private IUserDal _userDal;



        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        [SecuredOperation("admin,user")]
        [ValidationAspect(typeof(UserValidator))]
        [CacheRemoveAspect("IUserService.Get")]
        public IResult Add(User user)
        {
            BusinessRules.Run(CheckIfUserNameExists(user.FirstName));

            _userDal.Add(user);
            return new SuccessResult(Messages.UserAdded);
        }

        public IResult Delete(User user)
        {
            _userDal.Delete(user);
            return new SuccessResult(Messages.UserDeleted);
        }

        [CacheAspect]
        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll());
        }

        [CacheAspect]
        public IDataResult<List<User>> GetAllByUserId(int userId)
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll(u => u.userId == userId));
        }

        [CacheAspect]
        public IDataResult<User> GetById(int userId)
        {
            return new SuccessDataResult<User>(_userDal.Get(u => u.Id == userId));
        }

        public IDataResult<User> GetByMail(string email)
        {
            return new SuccessDataResult<User>(_userDal.Get(u => u.Email == email));
        }

        public IDataResult<List<OperationClaim>> GetClaims(User user)
        {
            return new SuccessDataResult<List<OperationClaim>>(_userDal.GetOperationClaims(user));
        }

        public IResult Update(User user)
        {
            _userDal.Update(user);
            return new SuccessResult(Messages.UserUpdated);
        }

        private IResult CheckIfUserNameExists(string userName)
        {
            var result = _userDal.GetAll(u => u.FirstName == userName).Any();
            if (!result)
            {
                return new SuccessResult();
            }
            return new ErrorResult(Messages.UserNameAlreadyExists);
        }
    }
}
