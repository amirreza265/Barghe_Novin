using BargheNovin.DataLayer.Entities;
using BargheNovin.DataLayer.Entities.PageContent;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BargheNovin.DataLayer.DataBaseContext
{
    public class BargheNovinDBContext : DbContext
    {
        public BargheNovinDBContext(DbContextOptions<BargheNovinDBContext> options) : base(options)
        {

        }

        #region Logo
        #endregion

        #region Content
        public DbSet<Content> Contents { get; set; }
        public DbSet<PageContent> PageContents { get; set; }
        public DbSet<ContentName> ContentNames { get; set; }
        public DbSet<ImageContent> ImageContents { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ContentName>()
                .HasIndex(c => c.Name)
                .IsUnique();

            modelBuilder.Entity<PageContent>()
                .HasIndex(c => c.PageName)
                .IsUnique();
            
            modelBuilder.Entity<PageContent>()
                .HasIndex(c => c.DisplayName)
                .IsUnique();

            modelBuilder.Entity<ImageContent>()
                .HasIndex(img => img.ImageKey)
                .IsUnique();

            base.OnModelCreating(modelBuilder);
        }
    }

}
