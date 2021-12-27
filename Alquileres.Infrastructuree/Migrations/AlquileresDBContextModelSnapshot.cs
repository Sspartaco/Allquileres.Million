﻿// <auto-generated />
using System;
using Alquileres.Infrastructuree.EntityFrameworkDatabaseContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Alquileres.Infrastructuree.Migrations
{
    [DbContext(typeof(AlquileresDBContext))]
    partial class AlquileresDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.1");

            modelBuilder.Entity("Alquileres.Domain.Owner", b =>
                {
                    b.Property<string>("IdOwner")
                        .HasColumnType("TEXT");

                    b.Property<string>("Address")
                        .HasColumnType("TEXT");

                    b.Property<DateTimeOffset>("BirthDay")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Photo")
                        .HasColumnType("TEXT");

                    b.HasKey("IdOwner");

                    b.ToTable("Owners");
                });

            modelBuilder.Entity("Alquileres.Domain.Property", b =>
                {
                    b.Property<string>("IdProperty")
                        .HasColumnType("TEXT");

                    b.Property<string>("Address")
                        .HasColumnType("TEXT");

                    b.Property<string>("CodeInternal")
                        .HasColumnType("TEXT");

                    b.Property<string>("IdOwner")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("OwnersIdOwner")
                        .HasColumnType("TEXT");

                    b.Property<string>("Price")
                        .HasColumnType("TEXT");

                    b.Property<int>("Year")
                        .HasColumnType("INTEGER");

                    b.HasKey("IdProperty");

                    b.HasIndex("OwnersIdOwner");

                    b.ToTable("Property");
                });

            modelBuilder.Entity("Alquileres.Domain.PropertyImage", b =>
                {
                    b.Property<string>("IdPropertyImage")
                        .HasColumnType("TEXT");

                    b.Property<bool>("Enable")
                        .HasColumnType("INTEGER");

                    b.Property<string>("File")
                        .HasColumnType("TEXT");

                    b.Property<string>("IdProperty")
                        .HasColumnType("TEXT");

                    b.Property<string>("PropertiesIdProperty")
                        .HasColumnType("TEXT");

                    b.HasKey("IdPropertyImage");

                    b.HasIndex("PropertiesIdProperty");

                    b.ToTable("PropertyImage");
                });

            modelBuilder.Entity("Alquileres.Domain.PropertyTrace", b =>
                {
                    b.Property<string>("IdPropertyTrace")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DateSale")
                        .HasColumnType("TEXT");

                    b.Property<string>("IdProperty")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("PropertiesIdProperty")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Tax")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Value")
                        .HasColumnType("TEXT");

                    b.HasKey("IdPropertyTrace");

                    b.HasIndex("PropertiesIdProperty");

                    b.ToTable("PropertyTrace");
                });

            modelBuilder.Entity("Alquileres.Domain.Property", b =>
                {
                    b.HasOne("Alquileres.Domain.Owner", "Owners")
                        .WithMany()
                        .HasForeignKey("OwnersIdOwner");

                    b.Navigation("Owners");
                });

            modelBuilder.Entity("Alquileres.Domain.PropertyImage", b =>
                {
                    b.HasOne("Alquileres.Domain.Property", "Properties")
                        .WithMany()
                        .HasForeignKey("PropertiesIdProperty");

                    b.Navigation("Properties");
                });

            modelBuilder.Entity("Alquileres.Domain.PropertyTrace", b =>
                {
                    b.HasOne("Alquileres.Domain.Property", "Properties")
                        .WithMany()
                        .HasForeignKey("PropertiesIdProperty");

                    b.Navigation("Properties");
                });
#pragma warning restore 612, 618
        }
    }
}
