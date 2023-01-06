using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseManagementSystem
{
    public class Product
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }
        public double Quantity { get; set; }

        public Product(string? name, string? category, decimal price, double quantity)
        {
            NameValidations(name);
            CategoryValidations(category);
            PriceValidations(price);
            QuantityValidations(quantity);


            Name = name!;
            Category = category!;
            Price = price;
            Quantity = quantity;
        }

        private void NameValidations(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("name");
            }
            if (name.Length <= 50)
            {
                Console.WriteLine(name);
            }


        }

        private void CategoryValidations(string category)
        {
            //
        }
        private void PriceValidations(decimal price)
        {
            if (price <= 0)
            {
                Console.WriteLine($"{price} should not be negative ");
            }
        }

        private void QuantityValidations(double quantity)
        {
            if (quantity < 0)
            {
                Console.WriteLine($"{quantity} should not negative ");
            }
        }
        public void Update(decimal price, double quantity)
        {
            Price = price;
            Quantity = quantity;
        }
        public override string ToString()
        {

            return $" Name: {Name}  Category: {Category}  Price: {Price}  Quantity: {Quantity}";
        }
    }
}
