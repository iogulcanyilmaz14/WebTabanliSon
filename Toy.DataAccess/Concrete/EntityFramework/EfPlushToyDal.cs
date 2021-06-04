using System;
using System.Collections.Generic;
using System.Text;
using Toy.Core.DataAccess.EntityFramework;
using Toy.DataAccess.Abstract;
using Toy.Entities.Concrete;

namespace Toy.DataAccess.Concrete.EntityFramework
{
    public class EfPlushToyDal : EfEntityRepositoryBase<PlushToy, OyuncakSatisContext>, IPlushToyDal
    {

    }
}
