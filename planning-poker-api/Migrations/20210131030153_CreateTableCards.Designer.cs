// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using PlanningPokerApi.Src.Shared.Database.Contexts;

namespace PlanningPokerApi.Migrations
{
  [DbContext(typeof(ApiContext))]
  [Migration("20210131030153_CreateTableCards")]
  partial class CreateTableCards
  {
    protected override void BuildTargetModel(ModelBuilder modelBuilder)
    {
#pragma warning disable 612, 618
      modelBuilder
          .UseIdentityByDefaultColumns()
          .HasAnnotation("Relational:MaxIdentifierLength", 63)
          .HasAnnotation("ProductVersion", "5.0.2");

      modelBuilder.Entity("PlanningPokerApi.Src.Shared.Database.Entities.CardEntity", b =>
          {
            b.Property<Guid>("Id")
                      .ValueGeneratedOnAdd()
                      .HasColumnType("uuid")
                      .HasColumnName("id");

            b.Property<int>("Value")
                      .HasColumnType("integer")
                      .HasColumnName("value");

            b.HasKey("Id");

            b.ToTable("cards");
          });

      modelBuilder.Entity("PlanningPokerApi.Src.Shared.Database.Entities.UserEntity", b =>
          {
            b.Property<Guid>("Id")
                      .ValueGeneratedOnAdd()
                      .HasColumnType("uuid")
                      .HasColumnName("id");

            b.Property<string>("Name")
                      .HasMaxLength(50)
                      .HasColumnType("character varying(50)")
                      .HasColumnName("name");

            b.HasKey("Id");

            b.ToTable("users");
          });
#pragma warning restore 612, 618
    }
  }
}
