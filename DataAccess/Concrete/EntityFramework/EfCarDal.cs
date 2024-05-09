using Core.DataAccess.EntityFramework;
using Core.Utilities;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, RenteCarContext>, ICarDal
    {
        public IDataResult<List<CarDetailDto>> GetCarDetail()
        {
            using (RenteCarContext context=new RenteCarContext())
            {
                var result=from p in context.Cars
                           join c in context.Brands
                           on p.BrandId equals c.Id
                           join d in context.Colors
                           on p.ColorId equals d.Id
                           select new CarDetailDto
                           {
                               CarName = p.Name,
                               BrandName = c.Name,
                               ColorName = d.Name,
                               DailyPrice = p.DailyPrice
                           };
                return new SuccessDataResult<List <CarDetailDto>>(result.ToList());

            }
        }
    }
}
