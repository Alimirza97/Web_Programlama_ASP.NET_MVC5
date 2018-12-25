namespace Web_Programlama_Odev.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class LeDemyDb : DbContext
    {
        public LeDemyDb()
            : base("name=LeDemyDb")
        {
        }

        public virtual DbSet<Dersler> Derslers { get; set; }
        public virtual DbSet<Kategori> Kategoris { get; set; }
        public virtual DbSet<Uyeler> Uyelers { get; set; }
        public virtual DbSet<Yetkiler> Yetkilers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Dersler>()
                .Property(e => e.Ders_Adi)
                .IsUnicode(false);

            modelBuilder.Entity<Dersler>()
                .Property(e => e.Video)
                .IsUnicode(false);

            modelBuilder.Entity<Dersler>()
                .Property(e => e.Resim)
                .IsUnicode(false);

            modelBuilder.Entity<Dersler>()
                .HasMany(e => e.Kategoris)
                .WithMany(e => e.Derslers)
                .Map(m => m.ToTable("KategoriDers").MapLeftKey("DersId").MapRightKey("KategoriId"));

            modelBuilder.Entity<Kategori>()
                .Property(e => e.Kategori_Adi)
                .IsUnicode(false);

            modelBuilder.Entity<Yetkiler>()
                .HasMany(e => e.Uyelers)
                .WithRequired(e => e.Yetkiler)
                .HasForeignKey(e => e.YektiId)
                .WillCascadeOnDelete(false);
        }
    }
}
