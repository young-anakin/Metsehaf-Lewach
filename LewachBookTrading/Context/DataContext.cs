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

        public DbSet<UserFriend> UserFriends { get; set; }
        public DbSet<FriendRequest> FriendRequests { get; set; }



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



            //modelBuilder.Entity<UserFriend>()
            //    .HasKey(uf => new { uf.UserId, uf.FriendId });
            modelBuilder.Entity<UserFriend>()
                .HasKey(uf => new { uf.UserId, uf.FriendId }); // Composite key

            modelBuilder.Entity<UserFriend>()
                .HasOne(uf => uf.User)
                .WithMany(u => u.Friends)
                .HasForeignKey(uf => uf.UserId)
                .OnDelete(DeleteBehavior.Restrict); // Or NoAction as discussed before

            modelBuilder.Entity<UserFriend>()
                .HasOne(uf => uf.Friend)
                .WithMany()
                .HasForeignKey(uf => uf.FriendId)
                .OnDelete(DeleteBehavior.Restrict); // Or NoAction

            modelBuilder.Entity<FriendRequest>()
                .HasOne(fr => fr.Sender)
                .WithMany() // Assuming a User can have many sent FriendRequests
                .HasForeignKey(fr => fr.SenderId)
                .OnDelete(DeleteBehavior.NoAction); // Prevent cascading deletes

            modelBuilder.Entity<FriendRequest>()
                .HasOne(fr => fr.Receiver)
                .WithMany() // Assuming a User can have many received FriendRequests
                .HasForeignKey(fr => fr.ReceiverId)
                .OnDelete(DeleteBehavior.NoAction); // Prevent cascading deletes


        }



    }
}
