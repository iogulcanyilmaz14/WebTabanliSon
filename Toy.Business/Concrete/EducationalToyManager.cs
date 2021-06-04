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
   public class EducationalToyManager : IEducationalToyService
    {
        IEducationalToyDal _educationalToyDal;

        public EducationalToyManager(IEducationalToyDal educationalToyDal)
        {
            _educationalToyDal = educationalToyDal;
        }

        [SecuredOperation("admin,user")]
        [ValidationAspect(typeof(EducationalToyValidator))]
        [CacheRemoveAspect("IEducationalToyService.Get")]
        public IResult Add(EducationalToy educationalToy)
        {
            BusinessRules.Run(CheckIfEducationalToyNameExists(educationalToy.Name));

            _educationalToyDal.Add(educationalToy);
            return new SuccessResult(Messages.EducationalToyAdded);
        }

        public IResult Delete(EducationalToy educationalToy)
        {
            _educationalToyDal.Delete(educationalToy);
            return new SuccessResult(Messages.EducationalToyDeleted);
        }

        [CacheAspect]
        public IDataResult<List<EducationalToy>> GetAll()
        {
            return new SuccessDataResult<List<EducationalToy>>(_educationalToyDal.GetAll());
        }

        [CacheAspect]
        public IDataResult<List<EducationalToy>> GetAllByEducationalId(int educationalId)
        {
            return new SuccessDataResult<List<EducationalToy>>(_educationalToyDal.GetAll(e => e.EducationalId == educationalId));
        }

        [CacheAspect]
        public IDataResult<EducationalToy> GetById(int educationalToyId)
        {
            return new SuccessDataResult<EducationalToy>(_educationalToyDal.Get(e => e.Id == educationalToyId));
        }

        public IResult Update(EducationalToy educationalToy)
        {
            _educationalToyDal.Update(educationalToy);
            return new SuccessResult(Messages.EducationalToyUpdated);
        }
        private IResult CheckIfEducationalToyNameExists(string educationalToyName)
        {
            var result = _educationalToyDal.GetAll(e => e.Name == educationalToyName).Any();
            if (!result)
            {
                return new SuccessResult();
            }
            return new ErrorResult(Messages.EducationalToyNameAlreadyExists);
        }
    }
}
