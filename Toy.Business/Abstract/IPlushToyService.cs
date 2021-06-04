using System;
using System.Collections.Generic;
using System.Text;
using Toy.Core.Utilities.Results;
using Toy.Entities.Concrete;

namespace Toy.Business.Abstract
{
   public interface IPlushToyService
    {
        IResult Add(PlushToy plushToy);
        IResult Delete(PlushToy plushToy);
        IResult Update(PlushToy plushToy);
        IDataResult<PlushToy> GetById(int PlushToyId);
        IDataResult<List<PlushToy>> GetAll();
        IDataResult<List<PlushToy>> GetAllByPlushId(int plushId);
    }
}
