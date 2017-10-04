using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace StudyGuide.Api.Models
{
    public partial class studyguideContext : DbContext
    {
        public virtual DbSet<Card> Card { get; set; }
        public virtual DbSet<Test> Test { get; set; }


        public studyguideContext(DbContextOptions options)
            : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Card>(entity =>
            {
                entity.HasKey(e => e.RowId)
                    .HasName("PK_Card");

                entity.Property(e => e.Answer).HasColumnType("varchar(2000)");

                entity.Property(e => e.Question).HasColumnType("varchar(2000)");

                entity.HasOne(d => d.Test)
                    .WithMany(p => p.Card)
                    .HasForeignKey(d => d.TestId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Card_TestId_Test_RowId");
            });

            modelBuilder.Entity<Test>(entity =>
            {
                entity.HasKey(e => e.RowId)
                    .HasName("PK_Test");

                entity.Property(e => e.CreateDate).HasColumnType("date");

                entity.Property(e => e.TestName).HasColumnType("varchar(100)");
            });
        }
    }
}