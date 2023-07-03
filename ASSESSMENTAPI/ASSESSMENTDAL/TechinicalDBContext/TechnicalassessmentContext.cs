using ASSESSMENTDAL.DBConnection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace ASSESSMENTDAL.TechinicalDBContext;

public partial class TechnicalassessmentContext : DbContext
{
    public TechnicalassessmentContext()
    {
    }

    public TechnicalassessmentContext(DbContextOptions<TechnicalassessmentContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Book> Books { get; set; }

    public virtual DbSet<ExceptionHandling> ExceptionHandlings { get; set; }
    public virtual DbSet<BookInfo> BookList { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        IConfigurationRoot configuration = new ConfigurationBuilder()
        .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
        .AddJsonFile("appsettings.json")
        .Build();
        optionsBuilder.UseSqlServer(configuration.GetConnectionString("Database"));
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Book>(entity =>
        {
            entity.HasKey(e => e.BookId).HasName("PK__Book__3DE0C2279552FB95");

            entity.ToTable("Book");

            entity.Property(e => e.BookId).HasColumnName("BookID");
            entity.Property(e => e.AuthorFirstName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.AuthorLastName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Publisher)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Title)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<ExceptionHandling>(entity =>
        {
            entity.HasKey(e => e.ExceptionId).HasName("PK__Exceptio__26981DA80949929D");

            entity.ToTable("ExceptionHandling");

            entity.Property(e => e.ExceptionId).HasColumnName("ExceptionID");
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.ExceptionMessage)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.ExceptionSource)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.ExceptionStackTrace)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Method)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Module)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.TargetSiteName)
                .HasMaxLength(200)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
