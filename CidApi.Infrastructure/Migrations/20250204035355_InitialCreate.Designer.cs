﻿// <auto-generated />
using CidApi.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CidApi.Infrastructure.Migrations
{
    [DbContext(typeof(CidDbContext))]
    [Migration("20250204035355_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CidApi.Domain.Models.Cid", b =>
                {
                    b.Property<string>("Codigo")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Codigo");

                    b.ToTable("Cids");

                    b.HasData(
                        new
                        {
                            Codigo = "A00",
                            Descricao = "Cólera"
                        },
                        new
                        {
                            Codigo = "A01",
                            Descricao = "Febre tifóide e paratifóide"
                        },
                        new
                        {
                            Codigo = "B01",
                            Descricao = "Varicela"
                        },
                        new
                        {
                            Codigo = "J18",
                            Descricao = "Pneumonia não especificada"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
