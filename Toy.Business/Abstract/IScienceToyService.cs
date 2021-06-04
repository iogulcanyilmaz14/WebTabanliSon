using System;
using System.Collections.Generic;
using System.Text;
using Toy.Core.Utilities.Results;
using Toy.Entities.Concrete;

namespace Toy.Business.Abstract
{
   public interface IScienceToyService
    {
        IResult Add(ScienceToy scienceToy);
        IResult Delete(ScienceToy scienceToy);
        IResult Update(ScienceToy scienceToy);
        IDataResult<ScienceToy> GetById(int scienceToyId);
        IDataResult<List<ScienceToy>> GetAll();
        IDataResult<List<ScienceToy>> GetAllByScienceId(int scienceId);
    }
}
