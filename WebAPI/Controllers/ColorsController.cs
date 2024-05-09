using Business.Abstract;
using Business.Concrete;
using Core.Utilities;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColorsController : ControllerBase
    {
        IColorService colorService;

        public ColorsController(IColorService _colorService)
        {
            colorService = _colorService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = colorService.GetAll();
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int colorid)
        {
            var result = colorService.GetById(colorid);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("add")]
        public IActionResult Add(Color color)
        {
            var result=colorService.Add(color);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);

        }


        [HttpPost("delete")]
        public IActionResult Delete(int colorid)
        {

            var result=colorService.Delete(new Color { Id=colorid});
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);

        }

        [HttpPost("update")]
        public IActionResult Update(Color color)
        {

            var result=colorService.Update(color);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);

        }
    }
}
