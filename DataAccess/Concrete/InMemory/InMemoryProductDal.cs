using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {

        //we can imagine there is a data we will control it...
        List<Product> _products; // we used (_) it should be global variable that's why we used it...! calling as a Name Convention...!

        public InMemoryProductDal() //ctor+tap to call constructer block...!
        {
            //we can add many products in this list..!
            //we can imagine that  this information is coming from Oracle,Sql Server,Postgres,MongoDb or etc...!
            _products = new List<Product> { 
                new Product {ProductId=1,CategoryId=1,ProductName="Glass",UnitPrice=15,UnitsInStock=15},//101 address in heap
                new Product {ProductId=2,CategoryId=1,ProductName="Camera",UnitPrice=500,UnitsInStock=3},//102
                new Product {ProductId=3,CategoryId=2,ProductName="Phone",UnitPrice=1500,UnitsInStock=2},//103
                new Product {ProductId=4,CategoryId=2,ProductName="Keyboard",UnitPrice=150,UnitsInStock=65 },
                new Product {ProductId=5,CategoryId=2,ProductName="Mouse",UnitPrice=85,UnitsInStock=1},
                //we can inside Ctr+Space then we can reach the properties...!


            }; 

        }
        public void Add(Product product)
        {
           _products.Add(product); //_product is list and we added the list product from entities product...!
        }
        //LinQ--LAnguage integrated Query
        //=> Lambda
        public void Delete(Product product) //adress coming from UI(İUser Interface) thats why heap is 200 for example.... it is different
        {
            //_products.Remove(product); this code why it is not working
            //because heap is different that's why it can not work
            //then we can controll the CategoryID and match the same id and we can remove it... in this case we can use linq methods...!
            //LİNQ=Language İntegrated Queary=We can filtered like Sql properties codes... it is very usefull in C#
            Product productToDelete=_products.SingleOrDefault(p=>p.ProductId==product.ProductId); //it working like a foreach ... it is loop every each productId and cheking statement...!
           //p=_products it is alias...! then loop the productId and check the coming from (UI).ProductId if it is same then defined the productToDelete with reference number...
           //SingleOrDefault= it is search just 1 item or default...
            _products.Remove(productToDelete); //after we remove it... it means we deleted the Same product Id what we want it...!



        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll()
        {
            return _products; //we should give from database to business
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAllByCategory(int categoryId)
        {
            //I should write the select...and ı can write very easy with LİNQ

          return  _products.Where(p=>p.CategoryId==categoryId).ToList(); 
            //where=if statement is correct in the list then they can list them and (where) can loop them...



        }

        public void Update(Product product)


        {
            //when ı send the product id,ProductToUpdate  can find the same productid in the list... then we can update them...

            Product productToUpdate= _products.SingleOrDefault(p => p.ProductId == product.ProductId);

            productToUpdate.ProductName=product.ProductName;
            productToUpdate.CategoryId = product.CategoryId; //we updated all parameters with LİNQ
            productToUpdate.UnitPrice = product.UnitPrice;
            productToUpdate.UnitsInStock = product.UnitsInStock;


           


         

        }
    }
}
