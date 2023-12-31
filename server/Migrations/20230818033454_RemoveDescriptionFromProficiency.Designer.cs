﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using PrimalAPI.Models;

#nullable disable

namespace PrimalAPI.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230818033454_RemoveDescriptionFromProficiency")]
    partial class RemoveDescriptionFromProficiency
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("DietPokemon", b =>
                {
                    b.Property<int>("DietId")
                        .HasColumnType("integer");

                    b.Property<int>("PokemonId")
                        .HasColumnType("integer");

                    b.HasKey("DietId", "PokemonId");

                    b.HasIndex("PokemonId");

                    b.ToTable("DietPokemon");
                });

            modelBuilder.Entity("EggGroupPokemon", b =>
                {
                    b.Property<int>("EggGroupId")
                        .HasColumnType("integer");

                    b.Property<int>("PokemonId")
                        .HasColumnType("integer");

                    b.HasKey("EggGroupId", "PokemonId");

                    b.HasIndex("PokemonId");

                    b.ToTable("EggGroupPokemon");
                });

            modelBuilder.Entity("HabitatPokemon", b =>
                {
                    b.Property<int>("HabitatId")
                        .HasColumnType("integer");

                    b.Property<int>("PokemonId")
                        .HasColumnType("integer");

                    b.HasKey("HabitatId", "PokemonId");

                    b.HasIndex("PokemonId");

                    b.ToTable("HabitatPokemon");
                });

            modelBuilder.Entity("MovePokemon", b =>
                {
                    b.Property<int>("MoveId")
                        .HasColumnType("integer");

                    b.Property<int>("PokemonId")
                        .HasColumnType("integer");

                    b.HasKey("MoveId", "PokemonId");

                    b.HasIndex("PokemonId");

                    b.ToTable("MovePokemon");
                });

            modelBuilder.Entity("MoveProficiency", b =>
                {
                    b.Property<int>("MoveId")
                        .HasColumnType("integer");

                    b.Property<int>("ProficiencyId")
                        .HasColumnType("integer");

                    b.HasKey("MoveId", "ProficiencyId");

                    b.HasIndex("ProficiencyId");

                    b.ToTable("MoveProficiency");
                });

            modelBuilder.Entity("PassivePokemon", b =>
                {
                    b.Property<int>("PassiveId")
                        .HasColumnType("integer");

                    b.Property<int>("PokemonId")
                        .HasColumnType("integer");

                    b.HasKey("PassiveId", "PokemonId");

                    b.HasIndex("PokemonId");

                    b.ToTable("PassivePokemon");
                });

            modelBuilder.Entity("PokemonProficiency", b =>
                {
                    b.Property<int>("PokemonId")
                        .HasColumnType("integer");

                    b.Property<int>("ProficiencieId")
                        .HasColumnType("integer");

                    b.HasKey("PokemonId", "ProficiencieId");

                    b.HasIndex("ProficiencieId");

                    b.ToTable("PokemonProficiency");
                });

            modelBuilder.Entity("PokemonSkill", b =>
                {
                    b.Property<int>("PokemonId")
                        .HasColumnType("integer");

                    b.Property<int>("SkillId")
                        .HasColumnType("integer");

                    b.HasKey("PokemonId", "SkillId");

                    b.HasIndex("SkillId");

                    b.ToTable("PokemonSkill");
                });

            modelBuilder.Entity("PokemonType", b =>
                {
                    b.Property<int>("PokemonId")
                        .HasColumnType("integer");

                    b.Property<int>("TypeId")
                        .HasColumnType("integer");

                    b.HasKey("PokemonId", "TypeId");

                    b.HasIndex("TypeId");

                    b.ToTable("PokemonType");
                });

            modelBuilder.Entity("server.Models.Diet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Diet");
                });

            modelBuilder.Entity("server.Models.EggGroup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("EggGroup");
                });

            modelBuilder.Entity("server.Models.Habitat", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Habitat");
                });

            modelBuilder.Entity("server.Models.Move", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Move");
                });

            modelBuilder.Entity("server.Models.Passive", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Type")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Passive");
                });

            modelBuilder.Entity("server.Models.Pokemon", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("Attack")
                        .HasColumnType("integer");

                    b.Property<int>("Defense")
                        .HasColumnType("integer");

                    b.Property<int>("HP")
                        .HasColumnType("integer");

                    b.Property<string>("HatchRate")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("SizeId")
                        .HasColumnType("integer");

                    b.Property<int>("SpecialAttack")
                        .HasColumnType("integer");

                    b.Property<int>("SpecialDefense")
                        .HasColumnType("integer");

                    b.Property<int>("Speed")
                        .HasColumnType("integer");

                    b.Property<int>("WeightId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Pokemon");
                });

            modelBuilder.Entity("server.Models.Proficiency", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Proficiency");
                });

            modelBuilder.Entity("server.Models.Size", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Space")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Size");
                });

            modelBuilder.Entity("server.Models.Skill", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Skill");
                });

            modelBuilder.Entity("server.Models.Type", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Type");
                });

            modelBuilder.Entity("server.Models.Weight", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Range")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Weight");
                });

            modelBuilder.Entity("DietPokemon", b =>
                {
                    b.HasOne("server.Models.Diet", null)
                        .WithMany()
                        .HasForeignKey("DietId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("server.Models.Pokemon", null)
                        .WithMany()
                        .HasForeignKey("PokemonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EggGroupPokemon", b =>
                {
                    b.HasOne("server.Models.EggGroup", null)
                        .WithMany()
                        .HasForeignKey("EggGroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("server.Models.Pokemon", null)
                        .WithMany()
                        .HasForeignKey("PokemonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("HabitatPokemon", b =>
                {
                    b.HasOne("server.Models.Habitat", null)
                        .WithMany()
                        .HasForeignKey("HabitatId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("server.Models.Pokemon", null)
                        .WithMany()
                        .HasForeignKey("PokemonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MovePokemon", b =>
                {
                    b.HasOne("server.Models.Move", null)
                        .WithMany()
                        .HasForeignKey("MoveId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("server.Models.Pokemon", null)
                        .WithMany()
                        .HasForeignKey("PokemonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MoveProficiency", b =>
                {
                    b.HasOne("server.Models.Move", null)
                        .WithMany()
                        .HasForeignKey("MoveId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("server.Models.Proficiency", null)
                        .WithMany()
                        .HasForeignKey("ProficiencyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PassivePokemon", b =>
                {
                    b.HasOne("server.Models.Passive", null)
                        .WithMany()
                        .HasForeignKey("PassiveId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("server.Models.Pokemon", null)
                        .WithMany()
                        .HasForeignKey("PokemonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PokemonProficiency", b =>
                {
                    b.HasOne("server.Models.Pokemon", null)
                        .WithMany()
                        .HasForeignKey("PokemonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("server.Models.Proficiency", null)
                        .WithMany()
                        .HasForeignKey("ProficiencieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PokemonSkill", b =>
                {
                    b.HasOne("server.Models.Pokemon", null)
                        .WithMany()
                        .HasForeignKey("PokemonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("server.Models.Skill", null)
                        .WithMany()
                        .HasForeignKey("SkillId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PokemonType", b =>
                {
                    b.HasOne("server.Models.Pokemon", null)
                        .WithMany()
                        .HasForeignKey("PokemonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("server.Models.Type", null)
                        .WithMany()
                        .HasForeignKey("TypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
