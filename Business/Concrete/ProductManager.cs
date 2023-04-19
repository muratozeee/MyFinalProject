using Azure.Core;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal; //construction injection...! //we didnt use Entities framwork just we are using with constructers...!


        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public IResult Add(Product product)
        {
            if (product.ProductName.Length < 2)
            {
                //Magic Strings
                return new ErrorResult(Messages.ProductNameInvalid);
            }
            _productDal.Add(product);

            return new SuccessResult(Messages.ProductAdded);

        }

        public IDataResult<List<Product>> GetAll()
        {
            //Business Codes like if statements..!
            //do you have the authority ?
                if (DateTime.Now.Hour == 23)
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
        }
    }

