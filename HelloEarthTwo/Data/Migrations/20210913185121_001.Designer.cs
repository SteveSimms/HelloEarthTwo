﻿// <auto-generated />
using HelloEarthTwo.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace HelloEarthTwo.Data.Migrations
{
    [DbContext(typeof(EFContext))]
    [Migration("20210913185121_001")]
    partial class _001
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("HelloEarthTwo.Hero", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("CodeName")
                        .HasColumnType("text");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("HomeWorld")
                        .HasColumnType("text");

                    b.Property<string>("IsClone")
                        .HasColumnType("text");

                    b.Property<string>("Powers")
                        .HasColumnType("text");

                    b.Property<string>("SecretId")
                        .HasColumnType("text");

                    b.Property<string>("TeamAffiliation")
                        .HasColumnType("text");

                    b.Property<string>("TimeStamp")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Heroes");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Hero");
                });

            modelBuilder.Entity("HelloEarthTwo.Models.AntiHero", b =>
                {
                    b.HasBaseType("HelloEarthTwo.Hero");

                    b.Property<bool>("IsAntiHero")
                        .HasColumnType("boolean");

                    b.HasDiscriminator().HasValue("AntiHero");
                });

            modelBuilder.Entity("HelloEarthTwo.Models.Villain", b =>
                {
                    b.HasBaseType("HelloEarthTwo.Hero");

                    b.Property<bool>("IsVillian")
                        .HasColumnType("boolean");

                    b.HasDiscriminator().HasValue("Villain");
                });
#pragma warning restore 612, 618
        }
    }
}
