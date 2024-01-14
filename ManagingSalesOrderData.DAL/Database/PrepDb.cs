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
                        Id = 1,
                        Name = "New York Building 1",
                        State = "NY",
                        Windows = new List<Window>
                        {
                            new()
                            {
                                Id = 1,
                                Name = "A51",
                                QuantityOfWindows = 4,
                                TotalSubElements = 3,
                                SubElements = new List<SubElement>
                                {
                                    new() { Id = 1, Element = 1, Type = "Doors", Width = 1200, Height = 1850 },
                                    new() { Id = 2, Element = 2, Type = "Window", Width = 800, Height = 1850 },
                                    new() { Id = 3, Element = 3, Type = "Window", Width = 700, Height = 1850 }
                                }
                            },
                            new()
                            {
                                Id = 2,
                                Name = "C Zone 5",
                                QuantityOfWindows = 2,
                                TotalSubElements = 1,
                                SubElements = new List<SubElement>
                                {
                                    new() { Id = 4, Element = 1, Type = "Window", Width = 1500, Height = 2000 }
                                }
                            }
                        }
                    },
                    new Order
                    {
                        Id = 2,
                        Name = "California Hotel AJK",
                        State = "CA",
                        Windows = new List<Window>
                        {
                            new()
                            {
                                Id = 3,
                                Name = "GLB",
                                QuantityOfWindows = 3,
                                TotalSubElements = 2,
                                SubElements = new List<SubElement>
                                {
                                    new() { Id = 5, Element = 1, Type = "Doors", Width = 1400, Height = 2200 },
                                    new() { Id = 6, Element = 2, Type = "Window", Width = 600, Height = 2200 }
                                }
                            },
                            new()
                            {
                                Id = 4,
                                Name = "OHF",
                                QuantityOfWindows = 10,
                                TotalSubElements = 2,
                                SubElements = new List<SubElement>
                                {
                                    new() { Id = 7, Element = 1, Type = "Window", Width = 1500, Height = 2000 },
                                    new() { Id = 8, Element = 1, Type = "Window", Width = 1500, Height = 2000 }
                                }
                            }
                        }
                    }
                ];
        }
    }
}
