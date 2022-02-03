using BargheNovin.DataLayer.Entities;
using BargheNovin.DataLayer.Entities.PageContent;
using BargheNovin.DataLayer.Entities.User;
using BargheNovin.DataLayer.Entities.WorkSamples;
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

        #region Portfolio
        public DbSet<Portfolio> Portfolio { get; set; }
        public DbSet<PortfolioCategory> PortfolioCategories { get; set; }
        #endregion

        #region User
        public DbSet<User> Users { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Unique Columns
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

            modelBuilder.Entity<Portfolio>()
                .HasQueryFilter(p => !p.IsDeleted);

            modelBuilder.Entity<PortfolioCategory>()
                .HasIndex(pc => pc.FilterName)
                .IsUnique();

            modelBuilder.Entity<User>()
                .HasIndex(u => u.UserName)
                .IsUnique();

            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();
            #endregion

            modelBuilder.Entity<User>()
                .HasQueryFilter(u => !u.IsDeleted);

            base.OnModelCreating(modelBuilder);
        }
    }

}
