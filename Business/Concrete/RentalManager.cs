using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Utilities;
using Core.Utilities.Business;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

		[CacheRemoveAspect("IRentalService.Get")]
		[ValidationAspect(typeof(RentalValidator))]
		public IResult Add(Rental rental)
        {
            IResult result = BusinessRules.Run(CheckIfReturnDateCarId(rental));

            if (result!=null)
            {
                return result;
            }

            _rentalDal.Add(rental);
            return new SuccessResult(Messages.AddedRental);
        }

		[CacheRemoveAspect("IRentalService.Get")]
		public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult();
        }

		[CacheAspect]
		public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll());
        }

        public IDataResult<Rental> GetById(int id)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(p => p.Id == id));
        }

        public IDataResult<List<RentalDetailDto>> GetRentalDetail()
        {
            return _rentalDal.GetRentalDetail();
        }

		[CacheRemoveAspect("IRentalService.Get")]
		public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);

            Task.Factory.StartNew(() =>
            {
                System.Threading.Thread.Sleep(11100);
                if (rental.ReturnDate != null)
                {
                    Delete(rental);
                }
            });
            
            return new SuccessResult();
        }

        public IResult CheckIfReturnDateCarId(Rental rental)
        {
            var isRented = _rentalDal.Get(r => r.ReturnDate == null && r.CarId == rental.CarId);

            if (isRented != null)
            {
                return new ErrorResult(Messages.AddedRentalErrorRentedCar);
            }

            return new SuccessResult();
        }
    }
}
