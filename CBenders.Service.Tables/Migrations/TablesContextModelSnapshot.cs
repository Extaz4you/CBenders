﻿// <auto-generated />
using CBenders.Service.Tables.Db;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace CBenders.Service.Tables.Migrations
{
    [DbContext(typeof(TablesContext))]
    partial class TablesContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("CBenders.Service.Tables.Model.TablesModel", b =>
                {
                    b.Property<int>("TableId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("TableId"));

                    b.Property<int>("TableNumber")
                        .HasColumnType("integer");

                    b.Property<bool>("isReserved")
                        .HasColumnType("boolean");

                    b.HasKey("TableId");

                    b.ToTable("Tables");
                });
#pragma warning restore 612, 618
        }
    }
}
