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
    public class PlushToysController : ControllerBase
    {
        IPlushToyService _plushToyService;

        public PlushToysController(IPlushToyService plushToyService)
        {
            _plushToyService = plushToyService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _plushToyService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getallbyplushid")]
        public IActionResult GetAllByPlushId(int plushId)
        {
            var result = _plushToyService.GetAllByPlushId(plushId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _plushToyService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(PlushToy plushToy)
        {
            var result = _plushToyService.Add(plushToy);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(PlushToy plushToy)
        {
            var result = _plushToyService.Delete(plushToy);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(PlushToy plushToy)
        {
            var result = _plushToyService.Update(plushToy);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
