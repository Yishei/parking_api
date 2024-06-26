﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using parking_api.Data;

#nullable disable

namespace parking_api.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240227160254_0055")]
    partial class _0055
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("parking_api.Models.EFModels.CamLog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Archived")
                        .HasColumnType("bit");

                    b.Property<int?>("CameraId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CapturedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("CarImgPath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Color")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CondoId")
                        .HasColumnType("int");

                    b.Property<string>("DataSourceId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Direction")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int?>("LotId")
                        .HasColumnType("int");

                    b.Property<string>("Make")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Model")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PlateImgPath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PlateNo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ResolvedById")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ResolvedDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("ResolvedStatus")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("ResolvedTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Year")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CameraId");

                    b.HasIndex("CondoId");

                    b.HasIndex("LotId");

                    b.HasIndex("ResolvedById");

                    b.ToTable("CamLogs");
                });

            modelBuilder.Entity("parking_api.Models.EFModels.Camera", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("DataSourceId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("LotId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("LotId");

                    b.ToTable("Cameras");
                });

            modelBuilder.Entity("parking_api.Models.EFModels.Car", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Color")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ImgPath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Make")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Model")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("PlateNo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UnitId")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Year")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("UnitId");

                    b.HasIndex("UserId");

                    b.ToTable("Cars");
                });

            modelBuilder.Entity("parking_api.Models.EFModels.Condo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CondoAdminId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("DefaultMaxCarAllowed")
                        .HasColumnType("int");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TowingDriverId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Zip")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CondoAdminId");

                    b.ToTable("Condos");
                });

            modelBuilder.Entity("parking_api.Models.EFModels.Lot", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CondoId")
                        .HasColumnType("int");

                    b.Property<bool>("IsLocked")
                        .HasColumnType("bit");

                    b.Property<string>("LotNo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CondoId");

                    b.ToTable("Lots");
                });

            modelBuilder.Entity("parking_api.Models.EFModels.PollInput", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("PollId")
                        .HasColumnType("int");

                    b.Property<bool>("Required")
                        .HasColumnType("bit");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("PollId");

                    b.ToTable("PollInputs");
                });

            modelBuilder.Entity("parking_api.Models.EFModels.PollInputSelection", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("InputId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("InputId");

                    b.ToTable("PollInputSelections");
                });

            modelBuilder.Entity("parking_api.Models.EFModels.PollResults", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("InputId")
                        .HasColumnType("int");

                    b.Property<string>("Result")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("SubmitTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("InputId");

                    b.ToTable("PollResults");
                });

            modelBuilder.Entity("parking_api.Models.EFModels.Polling", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CondoId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("PollEnd")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("PollStart")
                        .HasColumnType("datetime2");

                    b.Property<string>("Subject")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CondoId");

                    b.ToTable("Pollings");
                });

            modelBuilder.Entity("parking_api.Models.EFModels.Unit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CondoId")
                        .HasColumnType("int");

                    b.Property<int?>("MaxCarsAllowed")
                        .HasColumnType("int");

                    b.Property<string>("UnitNo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("CondoId");

                    b.HasIndex("UserId");

                    b.ToTable("Units");
                });

            modelBuilder.Entity("parking_api.Models.EFModels.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("CreatedByUserId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("Otp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("OtpExpireAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("PhoneSecondary")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("parking_api.Models.EFModels.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("parking_api.Models.EFModels.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("parking_api.Models.EFModels.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("parking_api.Models.EFModels.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("parking_api.Models.EFModels.CamLog", b =>
                {
                    b.HasOne("parking_api.Models.EFModels.Camera", "Camera")
                        .WithMany("CamLogs")
                        .HasForeignKey("CameraId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("parking_api.Models.EFModels.Condo", "Condo")
                        .WithMany("CamLogs")
                        .HasForeignKey("CondoId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("parking_api.Models.EFModels.Lot", "Lot")
                        .WithMany("CamLogs")
                        .HasForeignKey("LotId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("parking_api.Models.EFModels.User", "ResolvedBy")
                        .WithMany("ResolvedLogs")
                        .HasForeignKey("ResolvedById")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("Camera");

                    b.Navigation("Condo");

                    b.Navigation("Lot");

                    b.Navigation("ResolvedBy");
                });

            modelBuilder.Entity("parking_api.Models.EFModels.Camera", b =>
                {
                    b.HasOne("parking_api.Models.EFModels.Lot", "Lot")
                        .WithMany("Cameras")
                        .HasForeignKey("LotId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("Lot");
                });

            modelBuilder.Entity("parking_api.Models.EFModels.Car", b =>
                {
                    b.HasOne("parking_api.Models.EFModels.Unit", "Unit")
                        .WithMany("Cars")
                        .HasForeignKey("UnitId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("parking_api.Models.EFModels.User", null)
                        .WithMany("Cars")
                        .HasForeignKey("UserId");

                    b.Navigation("Unit");
                });

            modelBuilder.Entity("parking_api.Models.EFModels.Condo", b =>
                {
                    b.HasOne("parking_api.Models.EFModels.User", "CondoAdmin")
                        .WithMany("Condos")
                        .HasForeignKey("CondoAdminId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("CondoAdmin");
                });

            modelBuilder.Entity("parking_api.Models.EFModels.Lot", b =>
                {
                    b.HasOne("parking_api.Models.EFModels.Condo", "Condo")
                        .WithMany("Lots")
                        .HasForeignKey("CondoId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("Condo");
                });

            modelBuilder.Entity("parking_api.Models.EFModels.PollInput", b =>
                {
                    b.HasOne("parking_api.Models.EFModels.Polling", "Polling")
                        .WithMany("PollInputs")
                        .HasForeignKey("PollId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Polling");
                });

            modelBuilder.Entity("parking_api.Models.EFModels.PollInputSelection", b =>
                {
                    b.HasOne("parking_api.Models.EFModels.PollInput", "PollInput")
                        .WithMany("PollInputSelections")
                        .HasForeignKey("InputId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PollInput");
                });

            modelBuilder.Entity("parking_api.Models.EFModels.PollResults", b =>
                {
                    b.HasOne("parking_api.Models.EFModels.PollInput", "PollInput")
                        .WithMany("PollResults")
                        .HasForeignKey("InputId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PollInput");
                });

            modelBuilder.Entity("parking_api.Models.EFModels.Polling", b =>
                {
                    b.HasOne("parking_api.Models.EFModels.Condo", "Condo")
                        .WithMany("Pollings")
                        .HasForeignKey("CondoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Condo");
                });

            modelBuilder.Entity("parking_api.Models.EFModels.Unit", b =>
                {
                    b.HasOne("parking_api.Models.EFModels.Condo", "Condo")
                        .WithMany("Units")
                        .HasForeignKey("CondoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("parking_api.Models.EFModels.User", "User")
                        .WithMany("Units")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("Condo");

                    b.Navigation("User");
                });

            modelBuilder.Entity("parking_api.Models.EFModels.Camera", b =>
                {
                    b.Navigation("CamLogs");
                });

            modelBuilder.Entity("parking_api.Models.EFModels.Condo", b =>
                {
                    b.Navigation("CamLogs");

                    b.Navigation("Lots");

                    b.Navigation("Pollings");

                    b.Navigation("Units");
                });

            modelBuilder.Entity("parking_api.Models.EFModels.Lot", b =>
                {
                    b.Navigation("CamLogs");

                    b.Navigation("Cameras");
                });

            modelBuilder.Entity("parking_api.Models.EFModels.PollInput", b =>
                {
                    b.Navigation("PollInputSelections");

                    b.Navigation("PollResults");
                });

            modelBuilder.Entity("parking_api.Models.EFModels.Polling", b =>
                {
                    b.Navigation("PollInputs");
                });

            modelBuilder.Entity("parking_api.Models.EFModels.Unit", b =>
                {
                    b.Navigation("Cars");
                });

            modelBuilder.Entity("parking_api.Models.EFModels.User", b =>
                {
                    b.Navigation("Cars");

                    b.Navigation("Condos");

                    b.Navigation("ResolvedLogs");

                    b.Navigation("Units");
                });
#pragma warning restore 612, 618
        }
    }
}
