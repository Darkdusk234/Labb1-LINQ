using Labb1_LINQ.Models;
using Microsoft.EntityFrameworkCore;

namespace Labb1_LINQ
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //GetProductsByCategoryPriceOrder("Electronics");
            GetSupplierWithLowStockAmount();
        }

        public static void GetProductsByCategoryPriceOrder(string category)
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
                        Console.WriteLine("| Namn | Beskrivning | Pris | Lagermängd |");

                        foreach (var product in products)
                        {
                            Console.WriteLine($"| {product.Name} |  {(product.Description != null ? product.Description : "N/A")} |  {product.Price} |  {product.StockQuantity} |");
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public static void GetSupplierWithLowStockAmount()
        {
            using (var context = new InternetShopContext()) {
                try
                {
                    var suppliers = context.Products
                        .Include(p => p.Supplier)
                        .Where(p => p.StockQuantity < 10)
                        .Select(s => new { s.Supplier.Name, s.Supplier.ContactPerson, s.Supplier.Email, s.Supplier.Phone });

                    if (suppliers != null)
                    {
                        Console.WriteLine("| Företags Namn |  Kontaktperson | Email | Telefonnummer |");

                        foreach (var supplier in suppliers)
                        {
                            Console.WriteLine($"| {supplier.Name} | {supplier.ContactPerson} | {(supplier.Email != null ? supplier.Email : "N/A")} | {(supplier.Phone != null ? supplier.Phone : "N/A")} |");
                        }
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
