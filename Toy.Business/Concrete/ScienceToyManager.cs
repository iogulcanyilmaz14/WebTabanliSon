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
   public class ScienceToyManager : IScienceToyService
    {
        IScienceToyDal _scienceToyDal;
        public ScienceToyManager(IScienceToyDal scienceToyDal)
        {
            _scienceToyDal = scienceToyDal;
        }

        [SecuredOperation("admin,user")]
        [ValidationAspect(typeof(ScienceToyValidator))]
        [CacheRemoveAspect("IScienceToyService.Get")]
        public IResult Add(ScienceToy scienceToy)
        {
            BusinessRules.Run(CheckIfScienceToyNameExists(scienceToy.Name));

            _scienceToyDal.Add(scienceToy);
            return new SuccessResult(Messages.ScienceToyAdded);
        }

        public IResult Delete(ScienceToy scienceToy)
        {
            _scienceToyDal.Delete(scienceToy);
            return new SuccessResult(Messages.ScienceToyDeleted);
        }

        [CacheAspect]
        public IDataResult<List<ScienceToy>> GetAll()
        {
            return new SuccessDataResult<List<ScienceToy>>(_scienceToyDal.GetAll());
        }

        [CacheAspect]
        public IDataResult<List<ScienceToy>> GetAllByScienceId(int scienceId)
        {
            return new SuccessDataResult<List<ScienceToy>>(_scienceToyDal.GetAll(s => s.ScienceId == scienceId));
        }

        [CacheAspect]
        public IDataResult<ScienceToy> GetById(int scienceToyId)
        {
            return new SuccessDataResult<ScienceToy>(_scienceToyDal.Get(s => s.Id == scienceToyId));
        }

        public IResult Update(ScienceToy scienceToy)
        {
            _scienceToyDal.Update(scienceToy);
            return new SuccessResult(Messages.ScienceToyUpdated);
        }
        private IResult CheckIfScienceToyNameExists(string scienceToyName)
        {
            var result = _scienceToyDal.GetAll(s => s.Name == scienceToyName).Any();
            if (!result)
            {
                return new SuccessResult();
            }
            return new ErrorResult(Messages.ScienceToyNameAlreadyExists);
        }
    }
}
