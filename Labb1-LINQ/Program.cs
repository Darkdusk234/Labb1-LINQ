using Labb1_LINQ.Models;

namespace Labb1_LINQ
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }

        public void GetProductsByCategoryOrderPrice(string category)
        {
            using (var context = new InternetShopContext())
            {
                try
                {
                    var products = context.Products
                        .Where(p => p.Category.Name == category)
                        .Select(p => new { p.Name, p.Description, p.Price, p.StockQuantity })
                        .OrderByDescending(p => p.Price);

                    Console.WriteLine("| Namn |  Beskrivning |  Pris |  Lagermängd |");

                    foreach (var product in products)
                    {
                        Console.WriteLine($"| {product.Name} |  {product.Description} |  {product.Price} |  {product.StockQuantity} |");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

    }
}
