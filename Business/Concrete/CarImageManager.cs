using Business.Abstract;
using Business.Constant;
using Core.Utilities.Business;
using Core.Utilities.Helpers.FileHelper;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {

        ICarImageDal _carImageDal;
        IFileHelper _fileHelper;

        public CarImageManager(ICarImageDal carImageDal, IFileHelper fileHelper)
        {
            _carImageDal = carImageDal;
            _fileHelper = fileHelper;
        }

        public IResult Add(IFormFile file, CarImage carImage)
        {
            IResult result = BusinessRules.Run(CheckIfImageCountPerCarExceeds(carImage.CarId));
            if (result != null)
            {
                return result;
            }
            var imagePath = _fileHelper.Upload(file, PathConstants.ImagesPath);
            carImage.Date = DateTime.Now;
            carImage.ImagePath = imagePath;
            _carImageDal.Add(carImage);
            return new SuccessResult(Messages.EntityAdded);

        }

        public IResult Delete(CarImage carImage)
        {
            _fileHelper.Delete(PathConstants.ImagesPath+carImage.ImagePath);
            var carImageToBeDeleted = _carImageDal.Get(c => c.ImagePath == carImage.ImagePath);
            _carImageDal.Delete(carImageToBeDeleted);
            return new SuccessResult(Messages.EntityDeleted);
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
        }

        public IDataResult<CarImage> GetById(int carImageId)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(carImage => carImage.Id == carImageId));
        }

        public IDataResult<List<CarImage>> GetListOfImagesByCar(int carId)
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(carImage => carImage.CarId == carId));
        }

        public IResult Update(IFormFile file, CarImage carImage)
        {
            _fileHelper.Update(file,PathConstants.ImagesPath,carImage.ImagePath);
            var carImageToBeUpdated = _carImageDal.Get(c => c.ImagePath == carImage.ImagePath);
            _carImageDal.Update(carImageToBeUpdated);
            return new SuccessResult();
        }

        private IResult CheckIfImageCountPerCarExceeds(int carId)
        {
            var result = _carImageDal.GetAll(carImage => carImage.CarId == carId);
            if (result.Count >= 5)
            {
                return new ErrorResult(Messages.CarImageLimitError);
            }
            return new SuccessResult();
        }
    }
}
