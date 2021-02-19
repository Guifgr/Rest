﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Rest.Models.Context;

namespace Rest.Migrations
{
    [DbContext(typeof(MySqlContext))]
    [Migration("20210219183434_usersTable")]
    partial class usersTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.3");

            modelBuilder.Entity("Rest.models.Book", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    b.Property<string>("Author")
                        .HasColumnType("longtext")
                        .HasColumnName("author");

                    b.Property<DateTime>("LaunchDate")
                        .HasColumnType("datetime")
                        .HasColumnName("launch_date");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(65,30)")
                        .HasColumnName("price");

                    b.Property<string>("Title")
                        .HasColumnType("longtext")
                        .HasColumnName("title");

                    b.HasKey("Id");

                    b.ToTable("book");
                });

            modelBuilder.Entity("Rest.models.Person", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    b.Property<string>("Address")
                        .HasColumnType("longtext")
                        .HasColumnName("adress");

                    b.Property<string>("FirstName")
                        .HasColumnType("longtext")
                        .HasColumnName("first_name");

                    b.Property<string>("Gender")
                        .HasColumnType("longtext")
                        .HasColumnName("gender");

                    b.Property<string>("LastName")
                        .HasColumnType("longtext")
                        .HasColumnName("last_name");

                    b.HasKey("Id");

                    b.ToTable("person");
                });

            modelBuilder.Entity("Rest.models.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    b.Property<string>("FullName")
                        .HasColumnType("longtext")
                        .HasColumnName("full_name");

                    b.Property<string>("Password")
                        .HasColumnType("longtext")
                        .HasColumnName("password");

                    b.Property<string>("RefreshToken")
                        .HasColumnType("longtext")
                        .HasColumnName("refresh_token");

                    b.Property<DateTime>("RefreshTokenExpiryTime")
                        .HasColumnType("datetime")
                        .HasColumnName("refresh_token_expiry_time");

                    b.Property<string>("UserName")
                        .HasColumnType("longtext")
                        .HasColumnName("User_name");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
