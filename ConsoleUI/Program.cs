using Business.Concrete;
using DataAccess.Concrete.EntityFrameWork;
using DataAccess.Concrete.InMemory;

namespace ConsoleUI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ProductTest();
            //CategoryTest();

            //DTO=Data Transformation Object
        }

        private static void CategoryTest()
        {
            CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
            foreach (var categories in categoryManager.Getall())
            {
                Console.WriteLine(categories.CategoryName);
            }
        }

        private static void ProductTest()
        {
            ProductManager productManager = new ProductManager(new EfProductDal());
            //we used before when we use constructer name we can see the in product manager class..!


            foreach (var product in productManager.GetProductDetail()) //let's see all products in the display..!
            {
                Console.WriteLine(product.ProductName + "/" + product.CategoryName);
            }
        }
    }
}