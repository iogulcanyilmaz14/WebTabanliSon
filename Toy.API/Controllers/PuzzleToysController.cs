using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Toy.Business.Abstract;
using Toy.Entities.Concrete;

namespace Toy.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PuzzleToysController : ControllerBase
    {
        IPuzzleToyService _puzzleToyService;

        public PuzzleToysController(IPuzzleToyService puzzleToyService)
        {
            _puzzleToyService = puzzleToyService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _puzzleToyService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getallbypuzzleid")]
        public IActionResult GetAllByPuzzleId(int puzzleId)
        {
            var result = _puzzleToyService.GetAllByPuzzleId(puzzleId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _puzzleToyService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(PuzzleToy puzzleToy)
        {
            var result = _puzzleToyService.Add(puzzleToy);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(PuzzleToy puzzleToy)
        {
            var result = _puzzleToyService.Delete(puzzleToy);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(PuzzleToy puzzleToy)
        {
            var result = _puzzleToyService.Update(puzzleToy);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
