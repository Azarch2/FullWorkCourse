using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace WpfApp6
{
    public partial class VideoStorageContext : DbContext
    {
        public VideoStorageContext()
        {
        }

        public VideoStorageContext(DbContextOptions<VideoStorageContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AuthorOfVideo> AuthorOfVideo { get; set; }
        public virtual DbSet<Catalog> Catalog { get; set; }
        public virtual DbSet<PlaceOfVideo> PlaceOfVideo { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<Video> Video { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseLazyLoadingProxies();
                optionsBuilder.UseSqlite("DataSource=C:\\Users\\vbnf0\\OneDrive\\Desktop\\555\\VideoStorage.db");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AuthorOfVideo>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasColumnType("TEXT (100)");

                entity.Property(e => e.Country)
                    .IsRequired()
                    .HasColumnType("TEXT (100)");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnType("TEXT (100)");

                entity.Property(e => e.House)
                    .IsRequired()
                    .HasColumnType("TEXT (100)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("TEXT (100)");

                entity.Property(e => e.Street)
                    .IsRequired()
                    .HasColumnType("TEXT (100)");

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasColumnType("TEXT (100)");

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.AuthorOfVideo)
                    .HasForeignKey<AuthorOfVideo>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Catalog>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Name).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Catalog)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<PlaceOfVideo>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasColumnType("TEXT (100)");

                entity.Property(e => e.Country)
                    .IsRequired()
                    .HasColumnType("TEXT (100)");

                entity.Property(e => e.Street)
                    .IsRequired()
                    .HasColumnType("TEXT (100)");

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.PlaceOfVideo)
                    .HasForeignKey<PlaceOfVideo>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnType("TEXT (100)");

                entity.Property(e => e.Login)
                    .IsRequired()
                    .HasColumnType("TEXT (100)");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnType("TEXT (100)");

                entity.Property(e => e.Role)
                    .IsRequired()
                    .HasColumnType("TEXT (100)");
            });

            modelBuilder.Entity<Video>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Format)
                    .IsRequired()
                    .HasColumnType("TEXT (4)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("TEXT (100)");

                entity.Property(e => e.Preview).IsRequired();

                entity.Property(e => e.Resolution).HasColumnType("TEXT (100)");

                entity.Property(e => e.Time).IsRequired();

                entity.Property(e => e.VideoData).IsRequired();

                entity.HasOne(d => d.Catalog)
                    .WithMany(p => p.Video)
                    .HasForeignKey(d => d.CatalogId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
