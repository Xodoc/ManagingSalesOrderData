using ManagingSalesOrderData.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace ManagingSalesOrderData.DAL.Database
{
    public sealed class PrepDb
    {
        public static void SeedData(AppDbContext context, bool isProd)
        {
            if (isProd)
            {
                Console.WriteLine("--> Attempt to apply migrations...");
                try
                {
                    context.Database.Migrate();
                }
                catch (Exception e)
                {
                    Console.WriteLine($"--> Could not run migrations: {e.Message}");
                }
            }

            if (!context.Orders.Any() &&
                !context.Windows.Any() &&
                !context.SubElements.Any())
            {
                Console.WriteLine("--> Seeding Data...");

                var orders = GetOrders();

                try
                {
                    context.Orders.AddRange(orders);
                    context.SaveChanges();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            else
            {
                Console.WriteLine("--> We already have data.");
            }
        }

        private static List<Order> GetOrders()
        {
            return
                [
                    new Order
                    {
                        Name = "New York Building 1",
                        State = "NY",
                        Windows = new List<Window>
                        {
                            new()
                            {
                                Name = "A51",
                                QuantityOfWindows = 4,
                                TotalSubElements = 3,
                                SubElements = new List<SubElement>
                                {
                                    new() { Element = 1, Type = "Doors", Width = 1200, Height = 1850 },
                                    new() { Element = 2, Type = "Window", Width = 800, Height = 1850 },
                                    new() { Element = 3, Type = "Window", Width = 700, Height = 1850 }
                                }
                            },
                            new()
                            {
                                Name = "C Zone 5",
                                QuantityOfWindows = 2,
                                TotalSubElements = 1,
                                SubElements = new List<SubElement>
                                {
                                    new() { Element = 1, Type = "Window", Width = 1500, Height = 2000 }
                                }
                            }
                        }
                    },
                    new Order
                    {
                        Name = "California Hotel AJK",
                        State = "CA",
                        Windows = new List<Window>
                        {
                            new()
                            {
                                Name = "GLB",
                                QuantityOfWindows = 3,
                                TotalSubElements = 2,
                                SubElements = new List<SubElement>
                                {
                                    new() { Element = 1, Type = "Doors", Width = 1400, Height = 2200 },
                                    new() { Element = 2, Type = "Window", Width = 600, Height = 2200 }
                                }
                            },
                            new()
                            {
                                Name = "OHF",
                                QuantityOfWindows = 10,
                                TotalSubElements = 2,
                                SubElements = new List<SubElement>
                                {
                                    new() { Element = 1, Type = "Window", Width = 1500, Height = 2000 },
                                    new() { Element = 1, Type = "Window", Width = 1500, Height = 2000 }
                                }
                            }
                        }
                    }
                ];
        }
    }
}
