using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        ICustomerService customerService ;
        public CustomersController(ICustomerService _customerService)
        {
            customerService = _customerService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = customerService.GetAll();
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int customerid)
        {
            var result = customerService.GetById(customerid);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("add")]
        public IActionResult Add(Customer customer)
        {
            var result=customerService.Add(customer);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);

        }


        [HttpPost("delete")]
        public IActionResult Delete(Customer customer)
        {

            var result=customerService.Delete(customer);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);

        }

        [HttpPost("update")]
        public IActionResult Update(Customer customer)
        {

            var result=customerService.Update(customer);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);

        }
    }
}
