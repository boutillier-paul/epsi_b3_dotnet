﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Program.Migrations
{
    [DbContext(typeof(SqlLiteDbContext))]
    partial class SqlLiteDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

                    b.HasKey("Id");

                    b.ToTable("Commandes");
                });

            modelBuilder.Entity("Plat", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("CommandeId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Etat")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nom")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CommandeId");

                    b.ToTable("Plats");
                });

            modelBuilder.Entity("Plat", b =>
                {
                    b.HasOne("Commande", null)
                        .WithMany("Plats")
                        .HasForeignKey("CommandeId");
                });

            modelBuilder.Entity("Commande", b =>
                {
                    b.Navigation("Plats");
                });
#pragma warning restore 612, 618
        }
    }
}
