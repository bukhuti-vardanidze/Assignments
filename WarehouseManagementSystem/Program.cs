using System.Diagnostics;
using WarehouseManagementSystem;

namespace WarehouseSystem
{

    class Program
    {
        static void Main(string[] args)
        {

            var warehouse = new WareHouseSys();
            var exit = false;
            while (!exit)
            {
                MenuOptions();
            }

            void MenuOptions()
            {
                Console.WriteLine("1 - Register");
                Console.WriteLine("2 - Update");
                Console.WriteLine("3 - Delete");
                Console.WriteLine("4 - Show all");
                Console.WriteLine("5 - Exit");

                Console.Write("Please enter the index: ");
                var options = int.Parse(Console.ReadLine());

                switch (options)
                {
                    case 1:
                        Register();
                        break;
                    case 2:
                        Update();
                        break;
                    case 3:
                        Delete();
                        break;
                    case 4:
                        ShowAll();
                        break;
                    case 5:
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Choose numbers between 1 to 5");
                        break;
                }

            }


            void Register()
            {
                Console.Write("Name: ");
                var productName = Console.ReadLine();

                Console.Write("Category: ");
                var category = Console.ReadLine();

                Console.Write("Price: ");
                var price = decimal.Parse(Console.ReadLine());

                Console.Write("Quantity: ");
                var quantity = double.Parse(Console.ReadLine());

                warehouse.ProductAdd(productName, category, price, quantity);
            }

            void Update()
            {
                Console.Write("Name: ");
                var productName = Console.ReadLine();

                Console.Write("Category: ");
                var category = Console.ReadLine();

                Console.Write("Price: ");
                var price = decimal.Parse(Console.ReadLine());

                Console.Write("Quantity: ");
                var quantity = double.Parse(Console.ReadLine());

                warehouse.UpdateProduct(productName, price, quantity);
            }

            void Delete()
            {
                Console.Write("Name: ");
                var productName = Console.ReadLine();
                warehouse.ProductRemove(productName);
            }

            void ShowAll()
            {
                warehouse.ShowAllProduct();

            }



        }
    }
}