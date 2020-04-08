using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace PeopleManager.Data.Seed
{
    class Program
    {
        static void Main()
        {
            var config = ConfigureApp();
            var services = SetupServices(config);
            SeedDatabase(services);
        }

        private static IConfiguration ConfigureApp()
        {
            IConfiguration config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", true, true)
                .Build();
            return config;
        }

        private static ServiceProvider SetupServices(IConfiguration config)
        {
            return new ServiceCollection()
                .AddSingleton<ManagementContext, ManagementContext>()
                .AddDbContext<ManagementContext>(options =>
                    options.UseSqlServer(config.GetConnectionString("ManagementDatabase")))
                .BuildServiceProvider();
        }

        private static void SeedDatabase(ServiceProvider services)
        {
            using (var context = services.GetService<ManagementContext>())
            {
                context.Database.EnsureCreated();

                if (!context.Persons.Any())
                {
                    Console.WriteLine("Seeding data...");
                    AddSeedDataTo(context);
                    context.SaveChanges();
                    Console.WriteLine("Seeding complete...");
                }
                else
                {
                    Console.WriteLine("Database already contains data, no seeding needed.");
                }
            }
        }

        private static void AddSeedDataTo(ManagementContext context)
        {
            var d1 = new Department {Name = "Department 1", Persons = new List<Person>()};
            var d2 = new Department {Name = "Department 2", Persons = new List<Person>()};
            
            var p1 = new Person { Name = "Alf Stokes", AddedAt = DateTime.UtcNow};
            var p2 = new Person { Name = "Bender Rodriguez", AddedAt = DateTime.UtcNow };
            var p3 = new Person { Name = "Kenny McCormick", AddedAt = DateTime.UtcNow };
            var p4 = new Person { Name = "Richard Hendricks", AddedAt = DateTime.UtcNow };
            var p5 = new Person { Name = "King Richard I of England", AddedAt = DateTime.UtcNow };
            
            d1.Persons.Add(p1);
            d1.Persons.Add(p2);
            d1.Persons.Add(p3);
            d2.Persons.Add(p4);
            d2.Persons.Add(p5);
            
            context.Departments.Add(d1);
            context.Departments.Add(d2);
        }
    }
}
