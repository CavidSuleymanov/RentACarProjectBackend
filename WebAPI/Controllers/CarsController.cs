using Business.Abstract;
using Business.Concrete;
using Core.Utilities;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        ICarService carService;

        public CarsController(ICarService _carService)
        {
            carService = _carService;
        }


        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result=carService.GetAll();
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int carid)
        {
            var result = carService.GetById(carid);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }


        [HttpGet("getcardetail")]
        public IActionResult GetCarDetail()
        {
            var result= carService.GetCarDetail();
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("add")]
        public IActionResult Add(Car car)
        {
            var result=carService.Add(car);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        
        [HttpPost("delete")]
        public IActionResult Delete([FromBody]int carid)
        {
               
            var result=carService.Delete(new Car { Id=carid});
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);

        }

        [HttpPost("update")]
        public IActionResult Update(Car car)
        {

            var result=carService.Update(car);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);

        }




    }
}
