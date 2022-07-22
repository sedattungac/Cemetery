using BusinessLayer.Abstract;
using Cemetery.Entity.Entity;
using DataAccessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public List<Product> GetProductWithProductCategory()
        {
            return _productDal.GetProductWithProductCategory();
        }
        public List<Product> GetTableById(int id)
        {
            return _productDal.GetListAll(x => x.ProductId == id);
        }
        public void TAdd(Product t)
        {
            _productDal.Insert(t);
        }

        public void TDelete(Product t)
        {
            _productDal.Delete(t);
        }

        public Product TGetById(int id)
        {
            return _productDal.GetById(id);
        }

        public List<Product> TGetList()
        {
            return _productDal.GetList();
        }

        public void TUpdate(Product t)
        {
            _productDal.Update(t);
        }
    }
}
