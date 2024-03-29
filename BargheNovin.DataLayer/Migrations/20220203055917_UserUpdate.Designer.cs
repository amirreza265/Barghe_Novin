﻿// <auto-generated />
using System;
using BargheNovin.DataLayer.DataBaseContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BargheNovin.DataLayer.Migrations
{
    [DbContext(typeof(BargheNovinDBContext))]
    [Migration("20220203055917_UserUpdate")]
    partial class UserUpdate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("BargheNovin.DataLayer.Entities.PageContent.Content", b =>
                {
                    b.Property<int>("ContentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ContentId"), 1L, 1);

                    b.Property<string>("ContentHtml")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ContentNameId")
                        .HasColumnType("int");

                    b.Property<string>("ContentTitle")
                        .HasMaxLength(400)
                        .HasColumnType("nvarchar(400)");

                    b.Property<int>("PageId")
                        .HasColumnType("int");

                    b.HasKey("ContentId");

                    b.HasIndex("ContentNameId")
                        .IsUnique();

                    b.HasIndex("PageId");

                    b.ToTable("Contents");
                });

            modelBuilder.Entity("BargheNovin.DataLayer.Entities.PageContent.ContentName", b =>
                {
                    b.Property<int>("ContentNameId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ContentNameId"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.HasKey("ContentNameId");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("ContentNames");
                });

            modelBuilder.Entity("BargheNovin.DataLayer.Entities.PageContent.ImageContent", b =>
                {
                    b.Property<int>("ImageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ImageId"), 1L, 1);

                    b.Property<string>("ContentTitle")
                        .HasMaxLength(400)
                        .HasColumnType("nvarchar(400)");

                    b.Property<string>("ImageKey")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("ImageName")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<int>("PageId")
                        .HasColumnType("int");

                    b.HasKey("ImageId");

                    b.HasIndex("ImageKey")
                        .IsUnique();

                    b.HasIndex("PageId");

                    b.ToTable("ImageContents");
                });

            modelBuilder.Entity("BargheNovin.DataLayer.Entities.PageContent.PageContent", b =>
                {
                    b.Property<int>("PageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PageId"), 1L, 1);

                    b.Property<string>("DisplayName")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<string>("PageName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("PageId");

                    b.HasIndex("DisplayName")
                        .IsUnique();

                    b.HasIndex("PageName")
                        .IsUnique();

                    b.ToTable("PageContents");
                });

            modelBuilder.Entity("BargheNovin.DataLayer.Entities.User.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"), 1L, 1);

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("RemoveDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("UserId");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("UserName")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("BargheNovin.DataLayer.Entities.WorkSamples.Portfolio", b =>
                {
                    b.Property<int>("PortfolioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PortfolioId"), 1L, 1);

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageName")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<bool>("ShowInMainPage")
                        .HasColumnType("bit");

                    b.HasKey("PortfolioId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Portfolio");
                });

            modelBuilder.Entity("BargheNovin.DataLayer.Entities.WorkSamples.PortfolioCategory", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoryId"), 1L, 1);

                    b.Property<string>("FilterName")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("CategoryId");

                    b.HasIndex("FilterName")
                        .IsUnique();

                    b.ToTable("PortfolioCategories");
                });

            modelBuilder.Entity("BargheNovin.DataLayer.Entities.PageContent.Content", b =>
                {
                    b.HasOne("BargheNovin.DataLayer.Entities.PageContent.ContentName", "ContentName")
                        .WithOne("Content")
                        .HasForeignKey("BargheNovin.DataLayer.Entities.PageContent.Content", "ContentNameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BargheNovin.DataLayer.Entities.PageContent.PageContent", "PageContent")
                        .WithMany("Contents")
                        .HasForeignKey("PageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ContentName");

                    b.Navigation("PageContent");
                });

            modelBuilder.Entity("BargheNovin.DataLayer.Entities.PageContent.ImageContent", b =>
                {
                    b.HasOne("BargheNovin.DataLayer.Entities.PageContent.PageContent", "PageContent")
                        .WithMany("Images")
                        .HasForeignKey("PageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PageContent");
                });

            modelBuilder.Entity("BargheNovin.DataLayer.Entities.WorkSamples.Portfolio", b =>
                {
                    b.HasOne("BargheNovin.DataLayer.Entities.WorkSamples.PortfolioCategory", "Category")
                        .WithMany("Portfolio")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("BargheNovin.DataLayer.Entities.PageContent.ContentName", b =>
                {
                    b.Navigation("Content");
                });

            modelBuilder.Entity("BargheNovin.DataLayer.Entities.PageContent.PageContent", b =>
                {
                    b.Navigation("Contents");

                    b.Navigation("Images");
                });

            modelBuilder.Entity("BargheNovin.DataLayer.Entities.WorkSamples.PortfolioCategory", b =>
                {
                    b.Navigation("Portfolio");
                });
#pragma warning restore 612, 618
        }
    }
}
