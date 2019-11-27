using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PlantillaPruebasDeConcepto.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PlantillaPruebasDeConcepto.Infrastructure
{
    class DataGenerator
    {
        public async static Task Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MyOwnContext(
                serviceProvider.GetRequiredService<DbContextOptions<MyOwnContext>>()))
            {
                // Look for any board games.
                if (await context.Set<Person>().AnyAsync())
                {
                    return;   // Data was already seeded
                }

                var person = new Person
                {
                    Age = 28,
                    Id = 1,
                    LastName = "Crizon",
                    Name = "Cristian"
                };
                var person2 = new Person
                {
                    Age = 15,
                    Id = 1,
                    LastName = "Pedro",
                    Name = "Cristian"
                };
                context.Add<Person>(person);
                context.Add<Person>(person2);
                context.SaveChanges();
            }
        }
    }
}
