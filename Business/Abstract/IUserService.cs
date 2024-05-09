using Core.Entities.Concrete;
using Core.Utilities;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IUserService
    {


		List<OperationClaim> GetClaims(User user);
		IDataResult<List<User>> GetAll();
		IResult Add(User user);
		IResult Update(User user);
		IResult Delete(User user);

		IDataResult<User> GetById(int userId);
		User GetByMail(string email);
		IResult AddTransactionalTest(User user);
	}
}
