using System;
using System.Collections.Generic;
using System.Text;
using Toy.Core.Utilities.Results;
using Toy.Entities.Concrete;

namespace Toy.Business.Abstract
{
   public interface IPuzzleToyService
    {
        IResult Add(PuzzleToy puzzleToy);
        IResult Delete(PuzzleToy puzzleToy);
        IResult Update(PuzzleToy puzzleToy);
        IDataResult<PuzzleToy> GetById(int puzzleToyId);
        IDataResult<List<PuzzleToy>> GetAll();
        IDataResult<List<PuzzleToy>> GetAllByPuzzleId(int puzzleId);
    }
}
