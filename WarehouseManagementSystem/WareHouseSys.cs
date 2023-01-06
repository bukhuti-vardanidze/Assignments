using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseManagementSystem
{
    public class WareHouseSys
    {
        public List<Product> Products { get; set; }
        public WareHouseSys()
        {
            Products = new List<Product>();
        }

        public void ProductAdd(string? name, string? category, decimal price, double quantity)
        {
            var product = new Product(name, category, price, quantity);
            Products.Add(product);

        }

        public void UpdateProduct(string? name, decimal price, double quantity)
        {
            var product = FindProductByName(name);
            if (product == null)
            {
                return;
            }
            product.Price = price;
            product.Quantity = quantity;

        }


        public void ProductRemove(string? name)
        {
            var product = FindProductByName(name);
            if (product == null)
            {
                return;
            }
            Products.Remove(product);
        }

        public void ShowAllProduct()
        {
            foreach (var product in Products)
            {
                Console.WriteLine(product.ToString());
            }
        }



        private Product? FindProductByName(string? name)
        {
            var product = Products.FirstOrDefault(k => k.Name == name);
            return product;
        }


    }
}
