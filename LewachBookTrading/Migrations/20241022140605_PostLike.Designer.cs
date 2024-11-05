﻿// <auto-generated />
using System;
using LewachBookTrading.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LewachBookTrading.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20241022140605_PostLike")]
    partial class PostLike
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("LewachBookTrading.Model.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostalCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Region")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StreetAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SubCity")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int?>("UserId1")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId1");

                    b.ToTable("Address");
                });

            modelBuilder.Entity("LewachBookTrading.Model.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Genre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OwnerId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("OwnerId");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("LewachBookTrading.Model.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CommentDescription")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<int>("CommentedById")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("PostId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CommentedById");

                    b.HasIndex("PostId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("LewachBookTrading.Model.Experience", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("FromUserId")
                        .HasColumnType("int");

                    b.Property<int>("ToBookId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FromUserId");

                    b.HasIndex("ToBookId");

                    b.ToTable("Experiences");
                });

            modelBuilder.Entity("LewachBookTrading.Model.Like", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("LikerId")
                        .HasColumnType("int");

                    b.Property<int?>("PostId")
                        .HasColumnType("int");

                    b.Property<int?>("PostId1")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("LikerId");

                    b.HasIndex("PostId");

                    b.HasIndex("PostId1");

                    b.ToTable("Likes");
                });

            modelBuilder.Entity("LewachBookTrading.Model.Post", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Photos")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PostedById")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("PostedById");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("LewachBookTrading.Model.Trade", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BookId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("FromUserId")
                        .HasColumnType("int");

                    b.Property<int>("ToUserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BookId");

                    b.HasIndex("FromUserId");

                    b.HasIndex("ToUserId");

                    b.ToTable("Trades");
                });

            modelBuilder.Entity("LewachBookTrading.Model.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AddressID")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Photo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AddressID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("LewachBookTrading.Model.Address", b =>
                {
                    b.HasOne("LewachBookTrading.Model.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId1");

                    b.Navigation("User");
                });

            modelBuilder.Entity("LewachBookTrading.Model.Book", b =>
                {
                    b.HasOne("LewachBookTrading.Model.User", "Owner")
                        .WithMany()
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("LewachBookTrading.Model.Comment", b =>
                {
                    b.HasOne("LewachBookTrading.Model.User", "CommentedBy")
                        .WithMany("Comments")
                        .HasForeignKey("CommentedById")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LewachBookTrading.Model.Post", "Post")
                        .WithMany("Comments")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CommentedBy");

                    b.Navigation("Post");
                });

            modelBuilder.Entity("LewachBookTrading.Model.Experience", b =>
                {
                    b.HasOne("LewachBookTrading.Model.User", "FromUser")
                        .WithMany()
                        .HasForeignKey("FromUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LewachBookTrading.Model.Book", "ToBook")
                        .WithMany("Experiences")
                        .HasForeignKey("ToBookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FromUser");

                    b.Navigation("ToBook");
                });

            modelBuilder.Entity("LewachBookTrading.Model.Like", b =>
                {
                    b.HasOne("LewachBookTrading.Model.User", "LikedBy")
                        .WithMany("Likes")
                        .HasForeignKey("LikerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LewachBookTrading.Model.Post", null)
                        .WithMany("Likes")
                        .HasForeignKey("PostId");

                    b.HasOne("LewachBookTrading.Model.Post", "Post")
                        .WithMany()
                        .HasForeignKey("PostId1");

                    b.Navigation("LikedBy");

                    b.Navigation("Post");
                });

            modelBuilder.Entity("LewachBookTrading.Model.Post", b =>
                {
                    b.HasOne("LewachBookTrading.Model.User", "PostedBy")
                        .WithMany("Posts")
                        .HasForeignKey("PostedById");

                    b.Navigation("PostedBy");
                });

            modelBuilder.Entity("LewachBookTrading.Model.Trade", b =>
                {
                    b.HasOne("LewachBookTrading.Model.Book", "Book")
                        .WithMany("Trades")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LewachBookTrading.Model.User", "FromUser")
                        .WithMany()
                        .HasForeignKey("FromUserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("LewachBookTrading.Model.User", "ToUser")
                        .WithMany()
                        .HasForeignKey("ToUserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Book");

                    b.Navigation("FromUser");

                    b.Navigation("ToUser");
                });

            modelBuilder.Entity("LewachBookTrading.Model.User", b =>
                {
                    b.HasOne("LewachBookTrading.Model.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Address");
                });

            modelBuilder.Entity("LewachBookTrading.Model.Book", b =>
                {
                    b.Navigation("Experiences");

                    b.Navigation("Trades");
                });

            modelBuilder.Entity("LewachBookTrading.Model.Post", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("Likes");
                });

            modelBuilder.Entity("LewachBookTrading.Model.User", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("Likes");

                    b.Navigation("Posts");
                });
#pragma warning restore 612, 618
        }
    }
}