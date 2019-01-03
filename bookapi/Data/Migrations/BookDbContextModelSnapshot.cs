﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using bookapi.Data;

namespace bookapi.Data.Migrations
{
    [DbContext(typeof(BookDbContext))]
    partial class BookDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("bookapi.Data.Entities.Author", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("BookId");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("BookId");

                    b.ToTable("Author");
                });

            modelBuilder.Entity("bookapi.Data.Entities.Book", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("CreateDate");

                    b.Property<DateTime?>("DateOfPublication");

                    b.Property<bool?>("IsDeleted");

                    b.Property<string>("Name");

                    b.Property<int?>("NumberOfPages");

                    b.Property<DateTime?>("UpdateDate");

                    b.HasKey("Id");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("bookapi.Data.Entities.Author", b =>
                {
                    b.HasOne("bookapi.Data.Entities.Book")
                        .WithMany("Authors")
                        .HasForeignKey("BookId");
                });
#pragma warning restore 612, 618
        }
    }
}
