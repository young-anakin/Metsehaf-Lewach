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

        //public DbSet<Address> Address { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Experience> Experiences { get; set; }
        public DbSet<Trade> Trades { get; set; }

        public DbSet<Like> Likes { get; set; }

        public DbSet<Comment> Comments { get; set; }

        public DbSet<Post> Posts { get; set; }


        public DbSet<Journal> Journals { get; set; } = null!;

        public DbSet<JournalPhoto> JournalPhotos { get; set; } = null!;

        public DbSet<UserFriend> UserFriends { get; set; }
        public DbSet<FriendRequest> FriendRequests { get; set; }

        public DbSet<Role> Roles { get; set; }



        //public DbSet<Address> Address { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<User>()

            //    .HasOne(u => u.Address)
            //    .WithMany() // Assuming that an Address can belong to one User
            //    .HasForeignKey(u => u.AddressID); // Foreign key in User pointing to Address
                                                  // Book -> User (Owner)
                                                  // Book -> User (Owner)
            modelBuilder.Entity<Book>()
                .HasOne(b => b.Owner)
                .WithMany() // A user can own many books
                .HasForeignKey(b => b.OwnerId) // Foreign key in Book for Owner
                .OnDelete(DeleteBehavior.Restrict); // Prevent cascading deletes

            // Book -> Experience (One-to-Many)
            modelBuilder.Entity<Book>()
                .HasMany(b => b.Experiences)
                .WithOne(e => e.ToBook) // Each Experience relates to one Book
                .HasForeignKey(e => e.ToBookId)
                .OnDelete(DeleteBehavior.Cascade); // Cascade delete on book deletion

            // Experience -> User (FromUser)
            modelBuilder.Entity<Experience>()
                .HasOne(e => e.FromUser)
                .WithMany() // A user can have many experiences
                .HasForeignKey(e => e.FromUserId)
                .OnDelete(DeleteBehavior.Cascade); // Cascade delete on user deletion

            // Trade -> User (FromUser and ToUser)
            modelBuilder.Entity<Trade>()
                .HasOne(t => t.FromUser)
                .WithMany() // A user can initiate many trades
                .HasForeignKey(t => t.FromUserId)
                .OnDelete(DeleteBehavior.Restrict); // Prevent cascading deletes

            modelBuilder.Entity<Trade>()
                .HasOne(t => t.ToUser)
                .WithMany() // A user can receive many trades
                .HasForeignKey(t => t.ToUserId)
                .OnDelete(DeleteBehavior.Restrict); // Prevent cascading deletes

            // Trade -> Book (A trade involves a book)
            modelBuilder.Entity<Trade>()
                .HasOne(t => t.Book)
                .WithMany(b => b.Trades) // A book can have many trades
                .HasForeignKey(t => t.BookId)
                .OnDelete(DeleteBehavior.Cascade); // Cascade delete on book deletion

            // Post Configuration
            modelBuilder.Entity<Post>()
                .HasKey(p => p.Id); // Setting Id as primary key

            modelBuilder.Entity<Post>()
                .Property(p => p.Title)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<Post>()
                .Property(p => p.Description)
                .HasMaxLength(1000);

            modelBuilder.Entity<Post>()
                .HasOne(p => p.PostedBy) // Relationship with User
                .WithMany(u => u.Posts) // A User can have many Posts
                .HasForeignKey(p => p.PostedById); // Foreign key

            // Comment Configuration
            modelBuilder.Entity<Comment>()
                .HasKey(c => c.Id); // Setting Id as primary key

            modelBuilder.Entity<Comment>()
                .Property(c => c.CommentDescription)
                .HasMaxLength(500);

            modelBuilder.Entity<Comment>()
                .HasOne(c => c.CommentedBy) // Relationship with User
                .WithMany(u => u.Comments) // A User can have many Comments 
                .HasForeignKey(c => c.CommentedById); // Foreign key

            modelBuilder.Entity<Comment>()
                .HasOne(c => c.Post) // Relationship with Post
                .WithMany(p => p.Comments) // A Post can have many Comments
                .HasForeignKey(c => c.PostId); // Foreign key

            // Like Configuration
            modelBuilder.Entity<Like>()
                .HasKey(l => l.Id); // Setting Id as primary key

            modelBuilder.Entity<Like>()
                .HasOne(l => l.LikedBy) // Relationship with User
                .WithMany(u => u.Likes) // A User can have many Likes
                .HasForeignKey(l => l.LikerId); // Foreign key

            modelBuilder.Entity<Like>()
                .HasOne(l => l.Post) // Explicitly specify the relationship with Post
                .WithMany(p => p.Likes) // A Post can have many Likes
                .HasForeignKey(l => l.PostId); // Foreign key
            modelBuilder.Entity<User>()
                        .HasMany(u => u.JournalTags)
                        .WithOne(j => j.User)
                        .HasForeignKey(j => j.UserId);

            modelBuilder.Entity<Role>()
                        .HasMany(r => r.Users)
                        .WithOne(u => u.Role)
                        .HasForeignKey(u => u.RoleId);

            modelBuilder.Entity<User>()
                        .HasMany(u => u.Journals)
                        .WithOne(j => j.User)
                        .HasForeignKey(j => j.UsertId);

            modelBuilder.Entity<Journal>()
                        .HasMany(j => j.JournalPhotos)
                        .WithOne(j => j.Journal)
                        .HasForeignKey(j => j.JournalId);

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
