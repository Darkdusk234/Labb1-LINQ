using Labb1_LINQ.Models;
using Microsoft.EntityFrameworkCore;

namespace Labb1_LINQ
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Menu();
        }

        public static void Menu()
        {
            bool loopActive = true;
            while(loopActive)
            {
                Console.Clear();
                Console.WriteLine("Skriv nummret av den metod du vill testa.");
                Console.WriteLine("1. Hämta alla produkter i Elektronics kategorin sorterat efter största pris.");
                Console.WriteLine("2. Hämta alla levrantörer som har produkter där lagersaldot är under tio.");
                Console.WriteLine("3. Hämta det totala order värdet för alla ordrar gjorda den senaste månaden");
                Console.WriteLine("4. Hämta de tre mest köpta produkterna");
                Console.WriteLine("5. Avsluta programmet.");

                int choice = 0;

                while (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Skriv endast siffror. Tryck på enter för att försöka igen.");
                    Console.ReadLine();
                }

                switch(choice)
                {
                    case 1:
                        PrintProductsByCategoryPriceOrder("Electronics");
                        break;
                    case 2:
                        PrintSupplierWithLowStockAmount();
                        break;
                    case 3:
                        PrintTotalOrderValueOfLastMonthsOrders();
                        break;
                    case 4:
                        PrintThreeMostOrderedProducts();
                        break;
                    case 5:
                        loopActive = false;
                        break;
                    default:
                        Console.WriteLine("Ogiltligt val, skriv endast de siffor som finns som alternativ. Tryck på enter för att försöka igen");
                        Console.ReadLine();
                        break;
                }
            }
        }

        public static void PrintProductsByCategoryPriceOrder(string category)
        {
            using (var context = new InternetShopContext())
            {
                try
                {
                    var products = context.Products
                        .Where(p => p.Category.Name == category)
                        .Select(p => new { p.Name, p.Description, p.Price, p.StockQuantity })
                        .OrderByDescending(p => p.Price);

                    if (products != null)
                    {
                        Console.Clear();
                        Console.WriteLine("| Namn | Beskrivning | Pris | Lagermängd |");

                        foreach (var product in products)
                        {
                            Console.WriteLine($"| {product.Name} |  {(product.Description != null ? product.Description : "N/A")} |  {product.Price} |  {product.StockQuantity} |");
                        }

                        Console.WriteLine();
                        Console.WriteLine("Tryck enter för att gå tillbaka till menyn.");
                        Console.ReadLine();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public static void PrintSupplierWithLowStockAmount()
        {
            using (var context = new InternetShopContext()) 
            {
                try
                {
                    var suppliers = context.Products
                        .Include(p => p.Supplier)
                        .Where(p => p.StockQuantity < 10)
                        .Select(s => new { s.Supplier.Name, s.Supplier.ContactPerson, s.Supplier.Email, s.Supplier.Phone })
                        .ToList();

                    if (suppliers != null)
                    {
                        suppliers = suppliers.Distinct().ToList();

                        Console.Clear();
                        Console.WriteLine("| Företags Namn | Kontaktperson | Email | Telefonnummer |");

                        foreach (var supplier in suppliers)
                        {
                            Console.WriteLine($"| {supplier.Name} | {supplier.ContactPerson} | {(supplier.Email != null ? supplier.Email : "N/A")} | {(supplier.Phone != null ? supplier.Phone : "N/A")} |");
                        }

                        Console.WriteLine();
                        Console.WriteLine("Tryck enter för att gå tillbaka till menyn.");
                        Console.ReadLine();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public static void PrintTotalOrderValueOfLastMonthsOrders()
        {
            using(var context = new InternetShopContext())
            {
                try
                {
                    var orderTotal = context.Orders
                        .Where(o => o.OrderDate >= DateTime.Now.AddDays(-31))
                        .Select(o => o.TotalAmount)
                        .Sum();

                    if(orderTotal != 0)
                    {
                        Console.Clear();
                        Console.WriteLine($"Totala värdet av alla ordrar gjorda inom 30 dagar är: {orderTotal} kr.");

                        Console.WriteLine();
                        Console.WriteLine("Tryck enter för att gå tillbaka till menyn.");
                        Console.ReadLine();
                    }
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public static void PrintThreeMostOrderedProducts()
        {
            using( var context = new InternetShopContext())
            {
                try
                {
                    var popularProducts = context.OrderDetails
                        .Include(p => p.Product)
                        .GroupBy(p => p.ProductId)
                        .OrderByDescending(g => g.Count())
                        .Take(3)
                        .Select(p => new { p.First().Product.Name, p.First().Product.Description, p.First().Product.Price });

                    if (popularProducts != null)
                    {
                        Console.Clear();
                        Console.WriteLine("| Produkt namn |  Produkt beskrvning | Produkt pris |");

                        foreach (var product in popularProducts)
                        {
                            Console.WriteLine($"| {product.Name} | {product.Description} | {product.Price} |");
                        }

                        Console.WriteLine();
                        Console.WriteLine("Tryck enter för att gå tillbaka till menyn.");
                        Console.ReadLine();
                    }
                }
                catch ( Exception ex )
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
