﻿// <auto-generated />
using System;
using BargheNovin.DataLayer.DataBaseContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BargheNovin.DataLayer.Migrations
{
    [DbContext(typeof(BargheNovinDBContext))]
    [Migration("20220108131424_ContentTables")]
    partial class ContentTables
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.13")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BargheNovin.DataLayer.Entities.PageContent.Content", b =>
                {
                    b.Property<int>("ContentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ContentHtml")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ContentNameId")
                        .HasColumnType("int");

                    b.Property<int?>("PageContentPageId")
                        .HasColumnType("int");

                    b.Property<int>("PageId")
                        .HasColumnType("int");

                    b.HasKey("ContentId");

                    b.HasIndex("ContentNameId")
                        .IsUnique();

                    b.HasIndex("PageContentPageId");

                    b.ToTable("Contents");
                });

            modelBuilder.Entity("BargheNovin.DataLayer.Entities.PageContent.ContentName", b =>
                {
                    b.Property<int>("ContentNameId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ContentNameId");

                    b.ToTable("ContentNames");
                });

            modelBuilder.Entity("BargheNovin.DataLayer.Entities.PageContent.PageContent", b =>
                {
                    b.Property<int>("PageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("PageName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PageId");

                    b.ToTable("PageContents");
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
                        .HasForeignKey("PageContentPageId");

                    b.Navigation("ContentName");

                    b.Navigation("PageContent");
                });

            modelBuilder.Entity("BargheNovin.DataLayer.Entities.PageContent.ContentName", b =>
                {
                    b.Navigation("Content");
                });

            modelBuilder.Entity("BargheNovin.DataLayer.Entities.PageContent.PageContent", b =>
                {
                    b.Navigation("Contents");
                });
#pragma warning restore 612, 618
        }
    }
}
