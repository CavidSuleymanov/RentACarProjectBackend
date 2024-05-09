using Business.Abstract;
using Business.Concrete;
using Core.Utilities;
using DataAccess.Concrete.EntityFramework;
using Entities;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        IBrandService brandService;

        public BrandsController(IBrandService _brandService)
        {
            brandService= _brandService;
        }


        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = brandService.GetAll();
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int brandid)
        {
            var result = brandService.GetById(brandid);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("add")]
        public IActionResult Add(Brand brand)
        {
            var result=brandService.Add(brand);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);

        }


        [HttpPost("delete")]
        public IActionResult Delete(Brand brand)
        {

            var result=brandService.Delete(brand);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);


        }

        [HttpPost("update")]
        public IActionResult Update(Brand brand)
        {

            var result = brandService.Update(brand);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);


        }
    }
}
