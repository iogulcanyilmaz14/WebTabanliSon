using System;
using System.Collections.Generic;
using System.Text;
using Toy.Core.Utilities.Results;
using Toy.Entities.Concrete;

namespace Toy.Business.Abstract
{
   public interface IEducationalToyService
    {
        IResult Add(EducationalToy educationalToy);
        IResult Delete(EducationalToy educationalToy);
        IResult Update(EducationalToy educationalToy);
        IDataResult<EducationalToy> GetById(int educationalToyId);
        IDataResult<List<EducationalToy>> GetAll();
        IDataResult<List<EducationalToy>> GetAllByEducationalId(int educationalId);
    }
}
