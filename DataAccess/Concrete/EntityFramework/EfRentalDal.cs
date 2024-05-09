using Core.DataAccess.EntityFramework;
using Core.Utilities;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, RenteCarContext>, IRentalDal
    {
        public IDataResult<List<RentalDetailDto>> GetRentalDetail()
        {
            using (RenteCarContext context = new RenteCarContext())
            {
                var result = from r in context.Rentals
                             join c in context.Cars
                             on r.CarId equals c.Id
                             join d in context.Customers
                             on r.CustomerId equals d.UserId
                             join e in context.Users
                             on r.CustomerId equals e.Id
                             select new RentalDetailDto
                             {
                                 UserName = e.FirstName,
                                 CompanyName = d.CompanyName,
                                 CarName = c.Name,
                                 RentDate = r.RentDate,
                                 ReturnDate =r.ReturnDate
                             };
                return new SuccessDataResult<List<RentalDetailDto>>(result.ToList());
            }
        }
    }
}
