using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public IDataResult<List<Product>> GetAll()
        {
            //if (DateTime.Now.Hour == 15)
            //{
            //    return new ErrorDataResult<List<Product>>(Messages.MaintenanceTime);
            //}

            return new SuccessDataResult<List<Product>>(_productDal.GetAll(),Messages.ProductsListed);
        }

        public IDataResult<List<Product>> GetAllByCategoryId(int id)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.CategoryId == id));
        }

        public IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max));
        }

        public IDataResult<List<ProductDetailDto>> GetProductDetails()
        {
            //if (DateTime.Now.Hour == 14)
            //{
            //    return new ErrorDataResult<List<ProductDetailDto>>(Messages.MaintenanceTime);
            //}
            return new SuccessDataResult<List<ProductDetailDto>>(_productDal.GetProductDetails());
        }

        [ValidationAspect(typeof(ProductValidator))]
        public IResult Add(Product product)
        {
            // Bu kurallar ValidationRules içerisinde ProductValidatorda yazıldı.
            //if (product.ProductName.Length<2)
            //{
            //    return new ErrorResult(Messages.ProductNameInvalid);
            //}

            // Bu kısım refoctor edilerek core katmanına taşındı.
            //var context = new ValidationContext<Product>(product);
            //ProductValidator productValidator = new ProductValidator();
            //var result = productValidator.Validate(context);
            //if (!result.IsValid)
            //{
            //    throw new ValidationException(result.Errors);
            //}

            // Yukarıya attribute olarak eklendi.
            //ValidationTool.Validate(new ProductValidator(), product);

            _productDal.Add(product);

            return new SuccessResult(Messages.ProductAdded);
        }

        public IDataResult<Product> GetById(int productId)
        {
            return new SuccessDataResult<Product>(_productDal.Get(p => p.ProductId == productId));
        }
    }
}
