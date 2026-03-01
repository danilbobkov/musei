using Microsoft.EntityFrameworkCore;

namespace MuseumAccounting
{
    public class MuseumContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<AssetCategory> AssetCategories { get; set; }
        public DbSet<FixedAsset> FixedAssets { get; set; }
        public DbSet<AssetMovement> AssetMovements { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // Строка подключения задаётся непосредственно в коде
                optionsBuilder.UseSqlServer(@"Server=DESKTOP-3CVUA48\SQLEXPRESS;Database=MuseumAccountingDb;Trusted_Connection=True;MultipleActiveResultSets=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Существующие настройки
            modelBuilder.Entity<FixedAsset>()
                .HasIndex(f => f.InventoryNumber)
                .IsUnique();

            modelBuilder.Entity<Location>()
                .HasIndex(l => l.Name)
                .IsUnique();

            modelBuilder.Entity<AssetCategory>()
                .HasIndex(c => c.Name)
                .IsUnique();

            modelBuilder.Entity<FixedAsset>()
                .Property(f => f.Status)
                .HasConversion<int>();

            modelBuilder.Entity<AssetMovement>()
                .HasOne(m => m.FixedAsset)
                .WithMany(f => f.Movements)
                .HasForeignKey(m => m.FixedAssetId)
                .OnDelete(DeleteBehavior.Cascade);

            // ** Новая конфигурация для связей с Location **
            modelBuilder.Entity<AssetMovement>()
                .HasOne(m => m.OldLocation)
                .WithMany(l => l.OldLocationMovements)
                .HasForeignKey(m => m.OldLocationId)
                .OnDelete(DeleteBehavior.Restrict); // Запрещаем каскадное удаление

            modelBuilder.Entity<AssetMovement>()
                .HasOne(m => m.NewLocation)
                .WithMany(l => l.NewLocationMovements)
                .HasForeignKey(m => m.NewLocationId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}