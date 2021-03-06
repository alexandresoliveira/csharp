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
    [Migration("20210131193805_AddCreatedAtAndUpdatedAtColumnsOnTableCards")]
    partial class AddCreatedAtAndUpdatedAtColumnsOnTableCards
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

                    b.Property<DateTime>("CreatedAt")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("created_at");

                    b.Property<DateTime>("UpdatedAt")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("updated_at");

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

                    b.Property<DateTime>("CreatedAt")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("created_at");

                    b.Property<string>("Name")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("name");

                    b.Property<DateTime>("UpdatedAt")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("updated_at");

                    b.HasKey("Id");

                    b.ToTable("users");
                });

            modelBuilder.Entity("PlanningPokerApi.Src.Shared.Database.Entities.UsersHistoryEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("Description")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("description");

                    b.HasKey("Id");

                    b.ToTable("users_history");
                });

            modelBuilder.Entity("PlanningPokerApi.Src.Shared.Database.Entities.VoteEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<Guid?>("cardId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("userId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("usersHistoryId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("cardId");

                    b.HasIndex("userId");

                    b.HasIndex("usersHistoryId");

                    b.ToTable("votes");
                });

            modelBuilder.Entity("PlanningPokerApi.Src.Shared.Database.Entities.VoteEntity", b =>
                {
                    b.HasOne("PlanningPokerApi.Src.Shared.Database.Entities.CardEntity", "card")
                        .WithMany()
                        .HasForeignKey("cardId");

                    b.HasOne("PlanningPokerApi.Src.Shared.Database.Entities.UserEntity", "user")
                        .WithMany()
                        .HasForeignKey("userId");

                    b.HasOne("PlanningPokerApi.Src.Shared.Database.Entities.UsersHistoryEntity", "usersHistory")
                        .WithMany()
                        .HasForeignKey("usersHistoryId");

                    b.Navigation("card");

                    b.Navigation("user");

                    b.Navigation("usersHistory");
                });
#pragma warning restore 612, 618
        }
    }
}
