using DenounceBeasts.API.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace DenounceBeasts.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Municipality> Municipalities { get; set; }
        public DbSet<Sector> Sectors { get; set; }

        // override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);
        //    // Configuración de la relación entre Municipality y Sector
        //    modelBuilder.Entity<Sector>()
        //        .HasOne(s => s.Municipality)
        //        .WithMany(m => m.Sectors)
        //        .HasForeignKey(s => s.MunicipalityId)
        //        .OnDelete(DeleteBehavior.Cascade); // Configura el comportamiento de eliminación en cascada
        //}
    }

}
