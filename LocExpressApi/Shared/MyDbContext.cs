using LocExpressApi.Shared.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LocExpressApi.Shared
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }
        public MyDbContext() { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new RentalAdEntityTypeConfiguration().Configure(modelBuilder.Entity<RentalAd>());
            new PictureEntityTypeConfiguration().Configure(modelBuilder.Entity<Picture>());
            new UserEntityTypeConfiguration().Configure(modelBuilder.Entity<User>());
            new ConversationEntityTypeConfiguration().Configure(modelBuilder.Entity<Conversation>());
        }

        public DbSet<RentalAd> RentalAds { get; set; }
        public DbSet<Picture> Pictures { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<PropertyType> PropertyTypes { get; set; }
        public DbSet<EnergyCategory> EnergyCategories { get; set; }
        public DbSet<UserFavorite> UserFavorites { get; set; }
        public DbSet<Conversation> Conversations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("Host=localhost;Port=5460;Username=locexpress;Password=postgres;Database=locexpress");
            }
        }
    }

    //Entity configuration 

    //RentalAd
    public class RentalAdEntityTypeConfiguration : IEntityTypeConfiguration<RentalAd>
    {
        public void Configure(EntityTypeBuilder<RentalAd> builder)
        {
            builder
                .HasOne<User>(a => a.Owner)
                .WithMany(u => u.OwnedRentalAds)
                .HasForeignKey(a => a.OwnerId);

            builder
                .HasMany<Picture>(l => l.Pictures)
                .WithOne(p => p.RentalAd);

            builder
                .HasOne<PropertyType>(l => l.Type)
                .WithMany()
                .HasForeignKey(l => l.TypeId);

            builder
                .HasOne<EnergyCategory>(l => l.EnergyCategory)
                .WithMany()
                .HasForeignKey(l => l.EnergyCategoryId);
        }
    }

    //Picture
    public class PictureEntityTypeConfiguration : IEntityTypeConfiguration<Picture>
    {
        public void Configure(EntityTypeBuilder<Picture> builder)
        {
            builder
                .HasOne<RentalAd>(p => p.RentalAd)
                .WithMany(l => l.Pictures)
                .HasForeignKey(p => p.RentalAdId);
        }
    }


    //User
    public class UserEntityTypeConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder
                .HasMany<RentalAd>(u => u.OwnedRentalAds)
                .WithOne(l => l.Owner);

            builder
                .HasMany<RentalAd>(u => u.Favorites)
                .WithMany()
                .UsingEntity("UserFavorite");
        }
    }

    public class ConversationEntityTypeConfiguration : IEntityTypeConfiguration<Conversation>
    {
        public void Configure(EntityTypeBuilder<Conversation> builder)
        {
            builder
                .HasOne<User>(c => c.User1)
                .WithMany()
                .HasForeignKey(c => c.User1Id);

            builder
                .HasOne<User>(c => c.User2)
                .WithMany()
                .HasForeignKey(c => c.User2Id);

            builder
                .Property(c => c.JsonContent)
                .HasColumnType("jsonb");

            builder
                .HasOne<RentalAd>(c => c.RentalAd)
                .WithMany()
                .HasForeignKey(c => c.RentalAdId);
        }
    }

}
