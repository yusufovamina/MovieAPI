using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using MovieAPI.Data.Models;

namespace MovieAPI.Data.Contexts;

public partial class MovieDbContext : DbContext
{
    public MovieDbContext()
    {
    }

    public MovieDbContext(DbContextOptions<MovieDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Movie> Movies { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=STHQ0201-10; Initial Catalog = movieDB; User ID=admin;Password=admin;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.CategoryId).HasName("PK__Categori__19093A2BC77B4190");

            entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
            entity.Property(e => e.CategoryName).HasMaxLength(50);
        });

        modelBuilder.Entity<Movie>(entity =>
        {
            entity.HasKey(e => e.MovieId).HasName("PK__Movies__4BD2943A20A528DD");

            entity.Property(e => e.MovieId).HasColumnName("MovieID");
            entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
            entity.Property(e => e.Director).HasMaxLength(100);
            entity.Property(e => e.Rating).HasColumnType("decimal(3, 1)");
            entity.Property(e => e.Title).HasMaxLength(255);

            entity.HasOne(d => d.Category).WithMany(p => p.Movies)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("FK__Movies__Category__3F466844");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
