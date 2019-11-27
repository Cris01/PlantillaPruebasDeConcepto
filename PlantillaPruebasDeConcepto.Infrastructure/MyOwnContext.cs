using Microsoft.EntityFrameworkCore;
using PlantillaPruebasDeConcepto.Domain.Entities;

namespace PlantillaPruebasDeConcepto.Infrastructure
{
    public class MyOwnContext :DbContext
    {
        public MyOwnContext(DbContextOptions<MyOwnContext> options):base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            if (modelBuilder == null)
            {
                return;
            }
            modelBuilder.Entity<Person>();
            base.OnModelCreating(modelBuilder);
        }
    }
}
