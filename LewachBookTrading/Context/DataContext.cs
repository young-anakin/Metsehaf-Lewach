using LewachBookTrading.Model;
using Microsoft.EntityFrameworkCore;

namespace LewachBookTrading.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        // Define your DbSet properties here
        // public DbSet<YourEntity> YourEntities { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<JournalTags> JournalTags { get; set; } = null!;

        public DbSet<Journal> Journals { get; set; } = null!;

        //public DbSet<Address> Address { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                        .HasMany(u => u.JournalTags)
                        .WithOne(j => j.User)
                        .HasForeignKey(j => j.UserId);

            modelBuilder.Entity<User>()
                        .HasMany(u => u.Journals)
                        .WithOne(j => j.User)
                        .HasForeignKey(j => j.UsertId);

            //modelBuilder.Entity<JournalTags>()
            //            .HasMany(jt => jt.Journals)
            //            .WithOne(j => j.Tag)
            //            .HasForeignKey(j => j.JournalTagID);

                        
        }



    }
}
