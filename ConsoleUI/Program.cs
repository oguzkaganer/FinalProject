using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;

namespace ConsoleUI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ProductManager productManager = new ProductManager(new EfProductDal());

            int i = 1;
            foreach (var product in productManager.GetAll())
            {
                Console.WriteLine(i + ". " + product.ProductName);
                i++;
            }

            Console.WriteLine("-----------------------------------------");

            i = 1;
            foreach (var product in productManager.GetByUnitPrice(10, 20))
            {
                Console.WriteLine(i + ". " + product.ProductName);
                i++;
            }

            Console.WriteLine("-----------------------------------------");

            i = 1;
            foreach (var product in productManager.GetAllByCategoryId(1))
            {
                Console.WriteLine(i + ". " + product.ProductName);
                i++;
            }


            Console.ReadLine();
        }
    }
}