﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Program.Migrations
{
    [DbContext(typeof(SqlLiteDbContext))]
    [Migration("20230625074054_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.5");

            modelBuilder.Entity("Commande", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Livre")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Plats")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Commandes");
                });

            modelBuilder.Entity("Plat", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Etat")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nom")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Plats");
                });
#pragma warning restore 612, 618
        }
    }
}
