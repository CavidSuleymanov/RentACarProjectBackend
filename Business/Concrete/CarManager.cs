using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities;
using Core.Utilities.Business;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.Dtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        [SecuredOperation("car.add,admin")]
        [ValidationAspect(typeof(CarValidator))]
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Add(Car car)
        {
            IResult carresult = BusinessRules.Run(CheckIfCarNameisColor(car));
            if (carresult!=null)
            {
                return carresult;
            }
            _carDal.Add(car);
            return new SuccessResult(Messages.CarAdded);
        }

        [CacheRemoveAspect("ICarService.Get")]
        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult();
        }

        [CacheAspect]
        [PerformanceAspect(5)]
        public IDataResult<List<Car>> GetAll()
        {
           return new SuccessDataResult<List<Car>>(_carDal.GetAll());   
        }

        [CacheAspect]
        public IDataResult<Car> GetById(int id)
        {
            return new SuccessDataResult<Car>(_carDal.Get(p=>p.Id==id));
        }

        public IDataResult<List<CarDetailDto>> GetCarDetail()
        {
            return _carDal.GetCarDetail();
        }

        [CacheRemoveAspect("ICarService.Get")]
        public IResult Update(Car car)
        {
           _carDal.Update(car);
            return new SuccessResult();
        }

        public IResult CheckIfCarNameisColor(Car car)
        {
            var isRented = _carDal.GetAll(r => r.Name == car.Name && r.ColorId == car.ColorId);

            if (isRented != null)
            {
                return new ErrorResult(Messages.AddedCarErrorNameisColor);
            }

            return new SuccessResult();
        }
    }
}
