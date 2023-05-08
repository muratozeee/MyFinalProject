using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System.Net.Http.Headers;

namespace Business.Concrete
{
    public class ProductManager : IProductService

    {
        //validation=it is givin validate... it is giving the message to us to doing something.email or something...
        //construction injection...! //we didnt use Entities framwork just we are using with constructers...!
        IProductDal _productDal;
        ICategoryService _categoryService;
        


        public ProductManager(IProductDal productDal,ICategoryService categoryService)
        {
            _productDal = productDal;
            _categoryService = categoryService;

         
        }

        [ValidationAspect(typeof(ProductValidator))]
        public IResult Add(Product product)
        {
            //same name can not add...
           IResult result = BusinessRules.Run(CheckIfProductCountOfCategoryCorrect(product.CategoryID),
                CheckifProductNameExists(product.ProductName),CheckIfCategoryLimitExceded());

            if (result != null)
            {
                return result;
            }
            _productDal.Add(product);
            return new SuccessResult(Messages.ProductAdded);

            //business codes...


        }

        public IDataResult<List<Product>> GetAll()
        {
            //Business Codes like if statements..!
            //do you have the authority ?
            if (DateTime.Now.Hour == 1)
            {
                return new ErorrDataResult<List<Product>>(Messages.MaintainanceTime);
            }

            return new SuccessDataResult<List<Product>>(_productDal.GetAll(), Messages.ProductsListed);

        }

        public IDataResult<List<Product>> GetAllByCategoryId(int id)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.CategoryID == id));
        }

        public IDataResult<Product> GetById(int productId)
        {
            return new SuccessDataResult<Product>(_productDal.Get(p => p.ProductID == productId));
        }

        public IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.UnitPrice >= min
            && p.UnitPrice <= max));
        }

        public IDataResult<List<ProductDetailDto>> GetProductDetail()
        {
            return new SuccessDataResult<List<ProductDetailDto>>(_productDal.GetProductDetail());
        }

        public IResult Update(Product product)
        {
            var result = _productDal.GetAll(p => p.CategoryID == product.CategoryID).Count();
            if (result <= 10)
            {
                _productDal.Update(product);
                return new SuccessResult(Messages.ProductUpdated);
            }

            return new ErrorResult(Messages.ProductCountCategoryError);

        }

        private IResult CheckIfProductCountOfCategoryCorrect(int categoryId)
        {
            var result = _productDal.GetAll(p => p.CategoryID == categoryId).Count();
            if (result > 15)
            {
                return new ErrorResult(Messages.ProductCountCategoryError);
            }
            return new SuccessResult();

        }

        private IResult CheckifProductNameExists(string productName)
        {
            var result = _productDal.GetAll(p => p.ProductName == productName).Any();
            if (result)
            {
                return new ErrorResult(Messages.ProductNameAlreadyExists);
            }
            return new SuccessResult();

        }

        private IResult CheckIfCategoryLimitExceded()
        {
            var result = _categoryService.GetAll();
            if (result.Data.Count>15)
            {
                return new ErrorResult(Messages.CategoryLimitExceded);
            }
            return new SuccessResult();

        }



    }
    }

