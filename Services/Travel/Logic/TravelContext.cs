using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;

namespace Logic
{
    public partial class TravelContext : DbContext
    {
        public TravelContext(DbContextOptions<TravelContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Authors> Authors { get; set; }
        public virtual DbSet<Books> Books { get; set; }
        public virtual DbSet<Editorials> Editorials { get; set; }
        public virtual DbSet<Authors_has_Books> Authors_has_Books { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Authors>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<Authors>()
                .Property(e => e.surnames)
                .IsUnicode(false);

            modelBuilder.Entity<Authors>()
                .HasMany(e => e.Books)
                .WithMany(e => e.Authors);

            modelBuilder.Entity<Books>()
                .Property(e => e.title)
                .IsUnicode(false);

            modelBuilder.Entity<Books>()
                .Property(e => e.synopsis)
                .IsUnicode(false);

            modelBuilder.Entity<Books>()
                .Property(e => e.n_pages)
                .IsUnicode(false);

            modelBuilder.Entity<Editorials>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<Editorials>()
                .Property(e => e.campus)
                .IsUnicode(false);

            modelBuilder.Entity<Editorials>()
                .HasMany(e => e.Books)
                .WithOne(e => e.Editorials)
                .HasForeignKey(e => e.editorials_id);

            modelBuilder.Entity<Authors_has_Books>()
                .HasKey(e => e.authors_id);

            modelBuilder.Entity<Authors_has_Books>()
                .HasKey(e => e.books_ISBN);

            modelBuilder.Entity<Users>()
                .HasKey(e => e.userName);
        }
    }
}
