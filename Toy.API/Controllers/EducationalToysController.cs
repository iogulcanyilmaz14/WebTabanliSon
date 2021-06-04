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
    public class EducationalToysController : ControllerBase
    {
        IEducationalToyService _educationalToyService;

        public EducationalToysController(IEducationalToyService educationalToyService)
        {
            _educationalToyService = educationalToyService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _educationalToyService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getallbyeducationalid")]
        public IActionResult GetAllByEducationalId(int educationalId)
        {
            var result = _educationalToyService.GetAllByEducationalId(educationalId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _educationalToyService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(EducationalToy educationalToy)
        {
            var result = _educationalToyService.Add(educationalToy);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(EducationalToy educationalToy)
        {
            var result = _educationalToyService.Delete(educationalToy);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(EducationalToy educationalToy)
        {
            var result = _educationalToyService.Update(educationalToy);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
