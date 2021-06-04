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
using Toy.Core.Utilities.Business;
using Toy.Core.Utilities.Results;
using Toy.DataAccess.Abstract;
using Toy.Entities.Concrete;

namespace Toy.Business.Concrete
{
    public class PlushToyManager : IPlushToyService
    {
        IPlushToyDal _plushToyDal;

        public PlushToyManager(IPlushToyDal plushToyDal)
        {
            _plushToyDal = plushToyDal;
        }

        [SecuredOperation("admin,user")]
        [ValidationAspect(typeof(PlushToyValidator))]
        [CacheRemoveAspect("IPlushToyService.Get")]
        public IResult Add(PlushToy plushToy)
        {
            BusinessRules.Run(CheckIfPlushToyNameExists(plushToy.Name));

            _plushToyDal.Add(plushToy);
            return new SuccessResult(Messages.PlushToyAdded);
        }

        public IResult Delete(PlushToy plushToy)
        {
            _plushToyDal.Delete(plushToy);
            return new SuccessResult(Messages.PlushToyDeleted);
        }

        [CacheAspect]
        public IDataResult<List<PlushToy>> GetAll()
        {
            return new SuccessDataResult<List<PlushToy>>(_plushToyDal.GetAll());
        }

        [CacheAspect]
        public IDataResult<List<PlushToy>> GetAllByPlushId(int plushId)
        {
            return new SuccessDataResult<List<PlushToy>>(_plushToyDal.GetAll(p => p.PlushId == plushId));
        }

        [CacheAspect]
        public IDataResult<PlushToy> GetById(int PlushToyId)
        {
            return new SuccessDataResult<PlushToy>(_plushToyDal.Get(p => p.Id == PlushToyId));
        }

        public IResult Update(PlushToy plushToy)
        {
            _plushToyDal.Update(plushToy);
            return new SuccessResult(Messages.PlushToyUpdated);
        }
        private IResult CheckIfPlushToyNameExists(string plushToyName)
        {
            var result = _plushToyDal.GetAll(p => p.Name == plushToyName).Any();
            if (!result)
            {
                return new SuccessResult();
            }
            return new ErrorResult(Messages.PlushToyNameAlreadyExists);
        }
    }
}
