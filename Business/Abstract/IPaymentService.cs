using Core.Utilities;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
	public interface IPaymentService

	{
		IResult Update(Payment payment);
		IDataResult<List<Payment>> GetAll();
		IDataResult<Payment> Get(Payment payment);
		IResult Delete(Payment payment);
		IResult Add(Payment payment);

		IDataResult<Payment> GetByPaymentId(int paymentId);

		IDataResult<Payment> GetPaymentByUserId(int userId);
	}
}
