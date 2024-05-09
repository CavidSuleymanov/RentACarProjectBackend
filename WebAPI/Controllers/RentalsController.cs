using Business.Abstract;
using Business.Concrete;
using Core.Utilities;
using DataAccess.Concrete.EntityFramework;
using Entities;
using Entities.Concrete;
using Entities.Dtos;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentalsController : ControllerBase
    {
        IRentalService rentalService;

        public RentalsController(IRentalService _rentalService)
        {
            rentalService = _rentalService;
        }
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = rentalService.GetAll();
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int rental)
        {
            var result = rentalService.GetById(rental);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("getrentaldetail")]
        public IActionResult GetCarDetail()
        {
            var result=rentalService.GetRentalDetail();
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("add")]
        public IActionResult Add(Rental rental)
        {
            var result=rentalService.Add(rental);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);

        }


        [HttpPost("delete")]
        public IActionResult Delete(Rental rental)
        {

            var result = rentalService.Delete(rental);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);

        }

        [HttpPost("update")]
        public IActionResult Update(Rental rental)
        {

            var result=rentalService.Update(rental);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);

        }
    }
}
