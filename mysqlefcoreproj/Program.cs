using Microsoft.EntityFrameworkCore;
using System;
using System.Text;
using System.Linq;

namespace mysqlefcore
{
    class Program
    {
        static void Main(string[] args)
        {
                InsertTools();
                PrintTools();
        }

        private static void InsertTools()
        {
            using (var context = new HardwareStoreContext())
            {
                //Creates the database if it doesn’t exist
                context.Database.EnsureCreated();

                //Add brands
                var cat1 = new Category { Name = "Hand Tools" };
                context.Category.Add(cat1);
                var cat2 = new Category { Name = "Power Tools" };
                context.Category.Add(cat2);

                //Add brands
                var brand1 = new Brand { Name = "Bosch" };
                context.Brand.Add(brand1);
                var brand2 = new Brand { Name = "Ryobi" };
                context.Brand.Add(brand2);
                var brand3 = new Brand { Name = "Makita" };
                context.Brand.Add(brand3);

                //Adds tools
                context.Tool.Add(new Tool
                {
                    ID = "B123",
                    Name = "Hammer",
                    Price = 80.00,
                    Brand = brand1,
                    Category = cat1
                });
                context.Tool.Add(new Tool
                {
                    ID = "RY1884",
                    Name = "Hammer",
                    Price = 75.00,
                    Brand = brand2,
                    Category = cat1
                });
                context.Tool.Add(new Tool
                {
                    ID = "M002435",
                    Name = "Hammer",
                    Price = 90.00,
                    Brand = brand3,
                    Category = cat1
                });

                context.Tool.Add(new Tool
                {
                    ID = "B546",
                    Name = "Circular Saw",
                    Price = 500.00,
                    Brand = brand1,
                    Category = cat2
                });
                context.Tool.Add(new Tool
                {
                    ID = "RY2086",
                    Name = "Circular Saw",
                    Price = 320.00,
                    Brand = brand2,
                    Category = cat2
                });
                context.Tool.Add(new Tool
                {
                    ID = "M003980",
                    Name = "Circular Saw",
                    Price = 750.00,
                    Brand = brand3,
                    Category = cat2
                });

                context.Tool.Add(new Tool
                {
                    ID = "B357",
                    Name = "Impact Driver",
                    Price = 750.00,
                    Brand = brand1,
                    Category = cat2
                });
                context.Tool.Add(new Tool
                {
                    ID = "RY1902",
                    Name = "Impact Driver",
                    Price = 480.00,
                    Brand = brand2,
                    Category = cat2
                });
                context.Tool.Add(new Tool
                {
                    ID = "M005860",
                    Name = "Impact Driver",
                    Price = 810.00,
                    Brand = brand3,
                    Category = cat2
                });

                //Saves changes
                context.SaveChanges();
            }
        }

        private static void PrintTools()
        {
            //Prints all tools from the database to console
            using (var context = new HardwareStoreContext())
            {
                var tools = context.Tool
                  .Include(b => b.Brand)
                  .Include(b => b.Category);
                foreach (var tool in tools)
                {
                    var data = new StringBuilder();
                    data.AppendLine($"ID: {tool.ID}");
                    data.AppendLine($"Name: {tool.Name}");
                    data.AppendLine($"Price: {tool.Price}");
                    data.AppendLine($"Brand: {tool.Brand.Name}");
                    data.AppendLine($"Category: {tool.Category.Name}");
                    Console.WriteLine(data.ToString());
                }
            }
        }
    }
}
