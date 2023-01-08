using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;

namespace ConsoleUI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //ProductTest();
            //CategoryTest();

            ProductManager productManager = new ProductManager(new EfProductDal(), new CategoryManager(new EfCategoryDal()));

            var result = productManager.GetProductDetails();

            if (result.Success)
            {
                int i = 1;
                foreach (var product in result.Data)
                {
                    Console.WriteLine(i + ". " + product.ProductName + " - " + product.CategoryName + " - " +product.UnitPrice);
                    i++;
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }


            Console.ReadLine();
        }

        private static void CategoryTest()
        {
            CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());

            foreach (var category in categoryManager.GetAll().Data)
            {
                Console.WriteLine(category.CategoryName);
            }
        }

        private static void ProductTest()
        {
            ProductManager productManager = new ProductManager(new EfProductDal(),new CategoryManager(new EfCategoryDal()));

            int i = 1;
            foreach (var product in productManager.GetAll().Data)
            {
                Console.WriteLine(i + ". " + product.ProductName);
                i++;
            }

            Console.WriteLine("-----------------------------------------");

            i = 1;
            foreach (var product in productManager.GetByUnitPrice(10, 20).Data)
            {
                Console.WriteLine(i + ". " + product.ProductName);
                i++;
            }

            Console.WriteLine("-----------------------------------------");

            i = 1;
            foreach (var product in productManager.GetAllByCategoryId(1).Data)
            {
                Console.WriteLine(i + ". " + product.ProductName);
                i++;
            }
        }
    }
}