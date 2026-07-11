using DenounceBeasts.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DenounceBeasts.Infraestructure.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<ComplaintType> ComplaintTypes { get; set; }
        public DbSet<Municipality> Municipalities { get; set; }
        public DbSet<Sector> Sectors { get; set; }
        public DbSet<Status> Status { get; set; }

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
