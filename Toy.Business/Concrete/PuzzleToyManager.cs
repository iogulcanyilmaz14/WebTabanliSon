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
   public class PuzzleToyManager : IPuzzleToyService
    {
        IPuzzleToyDal _puzzleToyDal;

        public PuzzleToyManager(IPuzzleToyDal puzzleToyDal)
        {
            _puzzleToyDal = puzzleToyDal;
        }

        [SecuredOperation("admin,user")]
        [ValidationAspect(typeof(PuzzleToyValidator))]
        [CacheRemoveAspect("IPuzzleToyService.Get")]
        public IResult Add(PuzzleToy puzzleToy)
        {
            BusinessRules.Run(CheckIfPuzzleToyNameExists(puzzleToy.Name));

            _puzzleToyDal.Add(puzzleToy);
            return new SuccessResult(Messages.PuzzleToyAdded);
        }

        public IResult Delete(PuzzleToy puzzleToy)
        {
            _puzzleToyDal.Delete(puzzleToy);
            return new SuccessResult(Messages.PuzzleToyDeleted);
        }

        [CacheAspect]
        public IDataResult<List<PuzzleToy>> GetAll()
        {
            return new SuccessDataResult<List<PuzzleToy>>(_puzzleToyDal.GetAll());
        }

        [CacheAspect]
        public IDataResult<List<PuzzleToy>> GetAllByPuzzleId(int puzzleId)
        {
            return new SuccessDataResult<List<PuzzleToy>>(_puzzleToyDal.GetAll(pu => pu.PuzzleId == puzzleId));
        }

        [CacheAspect]
        public IDataResult<PuzzleToy> GetById(int puzzleToyId)
        {
            return new SuccessDataResult<PuzzleToy>(_puzzleToyDal.Get(pu => pu.Id == puzzleToyId));
        }

        public IResult Update(PuzzleToy puzzleToy)
        {
            _puzzleToyDal.Update(puzzleToy);
            return new SuccessResult(Messages.PuzzleToyUpdated);
        }
        private IResult CheckIfPuzzleToyNameExists(string puzzleToyName)
        {
            var result = _puzzleToyDal.GetAll(pu => pu.Name == puzzleToyName).Any();
            if (!result)
            {
                return new SuccessResult();
            }
            return new ErrorResult(Messages.PuzzleToyNameAlreadyExists);
        }
    }
}
