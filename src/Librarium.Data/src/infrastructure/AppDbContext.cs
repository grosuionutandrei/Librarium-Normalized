using Librarium.Data.repositories.entities;
using Microsoft.EntityFrameworkCore;
using BookDto = Librarium.Data.repositories.entities.BookDto;
using MemberDto = Librarium.Data.repositories.entities.MemberDto;

namespace Librarium.Data.infrastructure;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<BookDto> Books { get; set; }
    public DbSet<MemberDto> Members { get; set; }
    public DbSet<LoanEntity> Loans { get; set; }
    public DbSet<AuthorDto> Authors { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<BookDto>(entity =>
        {
            entity.HasKey(e => e.BookId);
            entity.Property(e => e.BookId).IsRequired();
            entity.HasIndex(e => e.Isbn).IsUnique();
            entity.Property(e => e.Isbn).HasMaxLength(20).IsRequired();
            entity.Property(e => e.Title).HasMaxLength(500).IsRequired();
            entity.Property(e => e.PublicationYear).IsRequired();
            entity.ToTable("Books");
        });

        modelBuilder.Entity<MemberDto>(entity =>
        {
            entity.HasKey(e => e.MemberId);
            entity.Property(e => e.MemberId).IsRequired();
            entity.HasIndex(e => e.Email).IsUnique();
            entity.Property(e => e.Email).HasMaxLength(255).IsRequired();
            entity.Property(e => e.FirstName).HasMaxLength(100).IsRequired();
            entity.Property(e => e.LastName).HasMaxLength(100).IsRequired();
            entity.ToTable("Members");
        });
        
        modelBuilder.Entity<AuthorDto>(entity =>
        {
            entity.HasKey(e => e.AuthorId);
            entity.Property(e => e.AuthorId).IsRequired();
            entity.Property(e => e.FirstName).HasMaxLength(100).IsRequired();
            entity.Property(e => e.LastName).HasMaxLength(100).IsRequired();
            entity.Property(e => e.Biography).HasMaxLength(2000).IsRequired(false);
            entity.ToTable("Authors");
        });

        modelBuilder.Entity<BookDto>()
            .HasMany(b => b.Authors)
            .WithMany(a => a.BooksDto)
            .UsingEntity(j => j.ToTable("BookAuthors"));
    
        

        modelBuilder.Entity<LoanEntity>(entity =>
        {
            entity.HasKey(e => e.LoanId);
            entity.Property(e => e.LoanId).IsRequired();

            entity.HasIndex(e => e.MemberId);
            entity.HasIndex(e => e.BookId);

            entity.HasOne<MemberDto>(e => e.Member)
                .WithMany()
                .HasForeignKey(e => e.MemberId)
                .HasPrincipalKey(m => m.MemberId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne<BookDto>(e => e.Book)
                .WithMany()
                .HasForeignKey(e => e.BookId)
                .HasPrincipalKey(b => b.BookId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.Property(e => e.LoanDate).IsRequired();
            entity.Property(e => e.ReturnDate).IsRequired(false);

            entity.ToTable("Loans");
        });
    }
}
