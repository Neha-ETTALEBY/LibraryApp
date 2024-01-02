using Microsoft.EntityFrameworkCore;
using Library.Models;

namespace Library.DAO
{
    internal class LibraryDBContext : DbContext
    {
        public DbSet<Adherent> Adherents { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Employe> Employees { get; set; }
        public DbSet<Livre> Livres { get; set; }
        public DbSet<Reservation> Reservations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=ETTALEBY\\SQLEXPRESS;Initial Catalog=Library;Integrated Security=True;Encrypt=False;Trust Server Certificate=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuration de la clé primaire pour chaque entité
            modelBuilder.Entity<Adherent>().HasKey(adherent => adherent.IdAdherent);
            modelBuilder.Entity<Admin>().HasKey(admin => admin.IdAdmin);
            modelBuilder.Entity<Employe>().HasKey(employe => employe.IdEmploye);
            modelBuilder.Entity<Livre>().HasKey(livre => livre.IdLivre);
            modelBuilder.Entity<Reservation>().HasKey(reservation => reservation.IdReservation);

        }
    }
}
