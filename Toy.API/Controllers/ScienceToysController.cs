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
    public class ScienceToysController : ControllerBase
    {
        IScienceToyService _scienceToyService;

        public ScienceToysController(IScienceToyService scienceToyService)
        {
            _scienceToyService = scienceToyService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _scienceToyService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getallbyscienceid")]
        public IActionResult GetAllByScienceId(int scienceId)
        {
            var result = _scienceToyService.GetAllByScienceId(scienceId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _scienceToyService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(ScienceToy scienceToy)
        {
            var result = _scienceToyService.Add(scienceToy);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(ScienceToy scienceToy)
        {
            var result = _scienceToyService.Delete(scienceToy);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(ScienceToy scienceToy)
        {
            var result = _scienceToyService.Update(scienceToy);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

    }
}
