using Business.Concrete;
using DataAccess.Concrete.InMemory;

namespace ConsoleUI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ProductManager productManager = new ProductManager(new InMemoryProductDal());
            //we used before when we use constructer name we can see the in product manager class..!


            foreach (var product in productManager.GetAll()) //let's see all products in the display..!
            {
                Console.WriteLine($"Product Name={product.ProductName}*** Product Price={product.UnitPrice}");
            }
        }
    }
}