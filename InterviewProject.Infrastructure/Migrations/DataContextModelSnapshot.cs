﻿// <auto-generated />
using System;
using InterviewProject.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace InterviewProject.Infrastructure.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("InterviewProject.Domains.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Category");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryName = "Candy"
                        },
                        new
                        {
                            Id = 2,
                            CategoryName = "Cake"
                        });
                });

            modelBuilder.Entity("InterviewProject.Domains.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("PricePerUnit")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<int>("UnitOfMeasureId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("UnitOfMeasureId");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("InterviewProject.Domains.ProductImage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<byte[]>("Binary")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<int?>("ProductId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductImage");
                });

            modelBuilder.Entity("InterviewProject.Domains.UnitOfMeasure", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("UnitName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("UnitOfMeasure");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            UnitName = "Pack"
                        },
                        new
                        {
                            Id = 2,
                            UnitName = "Bar"
                        },
                        new
                        {
                            Id = 3,
                            UnitName = "Kilo"
                        });
                });

            modelBuilder.Entity("InterviewProject.Domains.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DOB")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("User");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DOB = new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "ProjectAdmin123@gmail.com",
                            Gender = 0,
                            PasswordHash = new byte[] { 253, 54, 46, 208, 46, 213, 232, 95, 64, 176, 78, 237, 49, 73, 240, 220, 157, 245, 62, 245, 83, 77, 161, 162, 233, 114, 168, 14, 50, 2, 48, 98, 107, 225, 18, 143, 122, 48, 29, 251, 14, 132, 76, 96, 155, 102, 255, 38, 66, 199, 195, 36, 221, 235, 46, 15, 134, 185, 100, 177, 105, 237, 212, 245 },
                            PasswordSalt = new byte[] { 193, 61, 201, 57, 246, 27, 33, 9, 67, 144, 74, 2, 111, 155, 171, 109, 10, 13, 73, 238, 99, 108, 9, 79, 214, 199, 129, 112, 106, 26, 30, 254, 249, 134, 247, 249, 74, 190, 166, 208, 141, 63, 2, 90, 152, 98, 250, 38, 45, 58, 164, 208, 212, 123, 206, 208, 198, 250, 211, 28, 28, 17, 94, 241, 18, 189, 10, 98, 210, 19, 21, 150, 67, 229, 126, 140, 82, 20, 167, 61, 91, 63, 7, 4, 217, 242, 145, 217, 77, 85, 157, 6, 137, 27, 208, 82, 115, 32, 138, 138, 49, 4, 89, 101, 203, 183, 202, 135, 214, 145, 189, 244, 116, 249, 154, 173, 51, 13, 129, 197, 187, 162, 114, 67, 128, 62, 11, 44 },
                            UpdatedDate = new DateTime(2022, 5, 9, 12, 10, 6, 481, DateTimeKind.Local).AddTicks(9118),
                            Username = "admin"
                        });
                });

            modelBuilder.Entity("InterviewProject.Domains.Product", b =>
                {
                    b.HasOne("InterviewProject.Domains.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("InterviewProject.Domains.UnitOfMeasure", "UnitOfMeasure")
                        .WithMany()
                        .HasForeignKey("UnitOfMeasureId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("UnitOfMeasure");
                });

            modelBuilder.Entity("InterviewProject.Domains.ProductImage", b =>
                {
                    b.HasOne("InterviewProject.Domains.Product", "Product")
                        .WithMany("Images")
                        .HasForeignKey("ProductId");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("InterviewProject.Domains.Product", b =>
                {
                    b.Navigation("Images");
                });
#pragma warning restore 612, 618
        }
    }
}
