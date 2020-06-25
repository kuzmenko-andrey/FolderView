using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoldreView.Models.Database
{
    public class Folder
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<FolderTree> AncestorTree { get; set; }
        public ICollection<FolderTree> DescendantTree { get; set; }
    }

    public class FolderTree
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("AncestorFolder"), Column(Order = 0)]
        public int AncestorId { get; set; }
        [ForeignKey("DescendantFolder"), Column(Order = 1)]
        public int DescendantId { get; set; }

        [ForeignKey("AncestorId")]
        public Folder AncestorFolder { get; set; }
        [ForeignKey("DescendantId")]
        public Folder DescendantFolder { get; set; }
    }

    public class FolderContext : DbContext
    {
        public DbSet<Folder> Folders { get; set; }
        public DbSet<FolderTree> FolderTree { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            //options.UseSqlServer("Server=EMS-Agent;User Id=sa;Password=Password1;Initial Catalog=FolderView;Pooling=False;");
            options.UseSqlite("Data Source=folderview.db", x => x.MigrationsAssembly("FolderView.Models"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FolderTree>()
                .HasOne(ft => ft.AncestorFolder)
                .WithMany(f => f.AncestorTree)
                .HasForeignKey(ft => ft.AncestorId);

            modelBuilder.Entity<FolderTree>()
                .HasOne(ft => ft.DescendantFolder)
                .WithMany(f => f.DescendantTree)
                .HasForeignKey(ft => ft.DescendantId);

            modelBuilder.Entity<Folder>().HasData(new { Id = 1, Name = "Creating Digital Images" });
            modelBuilder.Entity<Folder>().HasData(new { Id = 2, Name = "Resources" });
            modelBuilder.Entity<Folder>().HasData(new { Id = 3, Name = "Evidence" });
            modelBuilder.Entity<Folder>().HasData(new { Id = 4, Name = "Graphic Products" });
            modelBuilder.Entity<Folder>().HasData(new { Id = 5, Name = "Primary Sources" });
            modelBuilder.Entity<Folder>().HasData(new { Id = 6, Name = "Secondary Sourcess" });
            modelBuilder.Entity<Folder>().HasData(new { Id = 7, Name = "Process" });
            modelBuilder.Entity<Folder>().HasData(new { Id = 8, Name = "Final Procuct" });

            modelBuilder.Entity<FolderTree>().HasData(new { Id = 1, AncestorId = 1, DescendantId = 2 });
            modelBuilder.Entity<FolderTree>().HasData(new { Id = 2, AncestorId = 1, DescendantId = 3 });
            modelBuilder.Entity<FolderTree>().HasData(new { Id = 3, AncestorId = 1, DescendantId = 4 });
            modelBuilder.Entity<FolderTree>().HasData(new { Id = 4, AncestorId = 2, DescendantId = 5 });
            modelBuilder.Entity<FolderTree>().HasData(new { Id = 5, AncestorId = 2, DescendantId = 6 });
            modelBuilder.Entity<FolderTree>().HasData(new { Id = 6, AncestorId = 4, DescendantId = 7 });
            modelBuilder.Entity<FolderTree>().HasData(new { Id = 7, AncestorId = 4, DescendantId = 8 });

        }
    }
}
