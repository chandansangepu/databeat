using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace WebApplication1.Models
{
    public partial class DataContext : DbContext
    {
        public DataContext()
            : base("name=DataContext")
        {
        }

        public virtual DbSet<abstract_display> abstract_display { get; set; }
        public virtual DbSet<author_display> author_display { get; set; }
        public virtual DbSet<Document> Documents { get; set; }
        public virtual DbSet<General> Generals { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<abstract_display>()
                .Property(e => e.abstract_display_name)
                .IsUnicode(false);

            modelBuilder.Entity<author_display>()
                .Property(e => e.author_display_name)
                .IsUnicode(false);

            modelBuilder.Entity<Document>()
                .Property(e => e.score)
                .HasPrecision(18, 7);

            modelBuilder.Entity<Document>()
                .Property(e => e.id)
                .IsUnicode(false);

            modelBuilder.Entity<Document>()
                .Property(e => e.journal)
                .IsUnicode(false);

            modelBuilder.Entity<Document>()
                .Property(e => e.eissn)
                .IsUnicode(false);

            modelBuilder.Entity<Document>()
                .Property(e => e.article_type)
                .IsUnicode(false);

            modelBuilder.Entity<General>()
                .Property(e => e.maxScore)
                .HasPrecision(18, 7);
        }
    }
}
