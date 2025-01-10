using Microsoft.EntityFrameworkCore;
using StripsBL.Models;
using StripsDL.Models;

namespace StripDL
{
    public class StripsContext : DbContext
    {
        public DbSet<Strip> Strip { get; set; }
        public DbSet<Auteur> Auteur { get; set; }
        public DbSet<Reeks> Reeks { get; set; }
        public DbSet<Uitgeverij> Uitgeverij { get; set; }
        public DbSet<AuteurStrip> AuteurStrip { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Server explorer daar uw string ophalen
            optionsBuilder.UseSqlServer("Data Source=MSI;Initial Catalog=Strips;Integrated Security=True;Trust Server Certificate=True");
            //View > other windows > package manager console
            // add-migration initCreate
            // update-database
        }
    }
}
