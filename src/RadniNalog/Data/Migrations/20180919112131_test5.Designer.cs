﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RadniNalog.Data;

namespace RadniNalog.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20180919112131_test5")]
    partial class test5
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.0-preview2-35157")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("RadniNalog.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("RadniNalog.Models.Automobil", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Registracija")
                        .IsRequired();

                    b.HasKey("ID");

                    b.ToTable("Automobil");
                });

            modelBuilder.Entity("RadniNalog.Models.MjestoRada", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Ime")
                        .IsRequired();

                    b.Property<int>("PodrucjeID");

                    b.HasKey("ID");

                    b.HasIndex("PodrucjeID");

                    b.ToTable("MjestoRada");
                });

            modelBuilder.Entity("RadniNalog.Models.Podrucje", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Ime");

                    b.HasKey("ID");

                    b.ToTable("Podrucje");
                });

            modelBuilder.Entity("RadniNalog.Models.RNalog", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AutomobilID");

                    b.Property<string>("Datum");

                    b.Property<int?>("Izvrsitelj2ID");

                    b.Property<int?>("Izvrsitelj3ID");

                    b.Property<string>("KrajRadova");

                    b.Property<string>("Materijal");

                    b.Property<int>("MjestoRadaID");

                    b.Property<string>("Napomena");

                    b.Property<string>("OpisRadova");

                    b.Property<string>("PocetakRadova");

                    b.Property<string>("Prilog");

                    b.Property<string>("PutniNalog");

                    b.Property<string>("RadVezanUZ");

                    b.Property<string>("RadniZadatakBroj");

                    b.Property<int?>("RukovoditeljID");

                    b.Property<int>("VrstaRadaID");

                    b.HasKey("ID");

                    b.HasIndex("AutomobilID");

                    b.HasIndex("Izvrsitelj2ID");

                    b.HasIndex("Izvrsitelj3ID");

                    b.HasIndex("MjestoRadaID");

                    b.HasIndex("RukovoditeljID");

                    b.HasIndex("VrstaRadaID");

                    b.ToTable("RadniNalog");
                });

            modelBuilder.Entity("RadniNalog.Models.VrstaRada", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Naziv")
                        .IsRequired();

                    b.HasKey("ID");

                    b.ToTable("VrstaRada");
                });

            modelBuilder.Entity("RadniNalog.Models.Zaposlenik", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Ime")
                        .IsRequired();

                    b.HasKey("ID");

                    b.ToTable("Zaposlenik");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("RadniNalog.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("RadniNalog.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("RadniNalog.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("RadniNalog.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("RadniNalog.Models.MjestoRada", b =>
                {
                    b.HasOne("RadniNalog.Models.Podrucje", "Podrucje")
                        .WithMany("MjestaRada")
                        .HasForeignKey("PodrucjeID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("RadniNalog.Models.RNalog", b =>
                {
                    b.HasOne("RadniNalog.Models.Automobil", "Automobil")
                        .WithMany("Nalozi")
                        .HasForeignKey("AutomobilID")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("RadniNalog.Models.Zaposlenik", "Izvrsitelj2")
                        .WithMany()
                        .HasForeignKey("Izvrsitelj2ID");

                    b.HasOne("RadniNalog.Models.Zaposlenik", "Izvrsitelj3")
                        .WithMany()
                        .HasForeignKey("Izvrsitelj3ID");

                    b.HasOne("RadniNalog.Models.MjestoRada", "MjestoRada")
                        .WithMany("Nalozi")
                        .HasForeignKey("MjestoRadaID")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("RadniNalog.Models.Zaposlenik", "Rukovoditelj")
                        .WithMany()
                        .HasForeignKey("RukovoditeljID");

                    b.HasOne("RadniNalog.Models.VrstaRada", "VrstaRada")
                        .WithMany("Nalozi")
                        .HasForeignKey("VrstaRadaID")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.OwnsOne("RadniNalog.ModeliPRINT.KategorijaRada", "KategorijaRada", b1 =>
                        {
                            b1.Property<int>("RNalogID")
                                .ValueGeneratedOnAdd()
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<bool>("BeznaponskoStanje");

                            b1.Property<bool>("BlizinaNapona");

                            b1.HasKey("RNalogID");

                            b1.ToTable("RadniNalog");

                            b1.HasOne("RadniNalog.Models.RNalog")
                                .WithOne("KategorijaRada")
                                .HasForeignKey("RadniNalog.ModeliPRINT.KategorijaRada", "RNalogID")
                                .OnDelete(DeleteBehavior.Cascade);
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
