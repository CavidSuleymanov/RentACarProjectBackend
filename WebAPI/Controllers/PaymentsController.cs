﻿using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class PaymentsController : ControllerBase
	{

		private IPaymentService _paymentService;
		public PaymentsController(IPaymentService paymentService)
		{
			_paymentService = paymentService;
		}

		[HttpPost("add")]
		public IActionResult Add(Payment payment)
		{
			var result = _paymentService.Add(payment);
			if (result.Success)
			{
				return Ok(result);
			}
			return BadRequest(result);
		}

		[HttpPost("update")]
		public IActionResult Update(Payment payment)
		{
			var result = _paymentService.Update(payment);
			if (result.Success)
			{
				return Ok(result);
			}
			return BadRequest(result);
		}

		[HttpPost("delete")]
		public IActionResult Delete(Payment payment)
		{
			var result = _paymentService.Delete(payment);
			if (result.Success)
			{
				return Ok(result);
			}
			return BadRequest(result);
		}

		[HttpGet]
		public IActionResult Get(Payment payment)
		{
			var result = _paymentService.Get(payment);
			if (result.Success)
			{
				return Ok(result);
			}
			return BadRequest(result);
		}

		[HttpGet("getall")]
		public IActionResult GetAll()
		{
			var result = _paymentService.GetAll();
			if (result.Success)
			{
				return Ok(result);
			}
			return BadRequest(result);
		}

		[HttpGet("getbyid")]

		public IActionResult GetById(int paymentId)
		{
			var result = _paymentService.GetByPaymentId(paymentId);
			if (result.Success)
			{
				return Ok(result);
			}
			return BadRequest(result);
		}
		[HttpGet("getbyuserId")]
		public IActionResult GetByUserId(int userId)
		{
			var result = _paymentService.GetPaymentByUserId(userId);
			if (result.Success)
			{
				return Ok(result);
			}
			return BadRequest(result);
		}


	}
}

