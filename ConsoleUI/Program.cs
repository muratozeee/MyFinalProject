using Business.Concrete;
using DataAccess.Concrete.EntityFrameWork;
using DataAccess.Concrete.InMemory;

namespace ConsoleUI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //ProductTest();
            //CategoryTest();
            //ProductManager productManager = new ProductManager(new EfProductDal());
            
            //foreach (var item in productManager.GetAll().Data)
            //{
            //    Console.WriteLine(item.ProductName);
            //}
            //Console.WriteLine("çalıştı");
            //DTO=Data Transformation Object


        }

        

        private static void ProductTest()
        {
            //ProductManager productManager = new ProductManager(new EfProductDal(),new CategoryManager(new EfCategoryDal()));
            ////we used before when we use constructer name we can see the in product manager class..!

            //var result = productManager.GetProductDetail();
            //if (result.Succes==true)
            //{
            //    foreach (var product in result.Data)
            //    {
            //        Console.WriteLine(product.ProductName + "/" + product.CategoryName);
            //    }
            //}
            //else
            //{
            //    Console.WriteLine(result.Message);
            //}


        }
    }
}