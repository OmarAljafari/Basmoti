﻿// <auto-generated />
using System;
using FinalProject.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FinalProject.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.25")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("FinalProject.Models.MasterCategoryMenu", b =>
                {
                    b.Property<int>("MasterCategoryMenuId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MasterCategoryMenuId"), 1L, 1);

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreateUser")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("EditDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("EditUser")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<string>("MasterCategoryMenuName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MasterCategoryMenuId");

                    b.ToTable("MasterCategoryMenus");
                });

            modelBuilder.Entity("FinalProject.Models.MasterContactUsInformation", b =>
                {
                    b.Property<int>("MasterContactUsInformationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MasterContactUsInformationId"), 1L, 1);

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreateUser")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("EditDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("EditUser")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<string>("MasterContactUsInformationIdesc")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MasterContactUsInformationImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MasterContactUsInformationRedirect")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MasterContactUsInformationId");

                    b.ToTable("MasterContactUsInformations");
                });

            modelBuilder.Entity("FinalProject.Models.MasterItemMenu", b =>
                {
                    b.Property<int>("MasterItemMenuId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MasterItemMenuId"), 1L, 1);

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreateUser")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("EditDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("EditUser")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<int?>("MasterCategoryMenuId")
                        .HasColumnType("int");

                    b.Property<string>("MasterItemMenuBreef")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("MasterItemMenuDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("MasterItemMenuDesc")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MasterItemMenuImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("MasterItemMenuPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("MasterItemMenuTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MasterItemUrl")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MasterItemMenuId");

                    b.HasIndex("MasterCategoryMenuId");

                    b.ToTable("MasterItemMenus");
                });

            modelBuilder.Entity("FinalProject.Models.MasterMenu", b =>
                {
                    b.Property<int>("MasterMenuId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MasterMenuId"), 1L, 1);

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreateUser")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("EditDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("EditUser")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<string>("MasterMenuName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MasterMenuUrl")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MasterMenuId");

                    b.ToTable("MasterMenus");
                });

            modelBuilder.Entity("FinalProject.Models.MasterOffer", b =>
                {
                    b.Property<int>("MasterOfferId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MasterOfferId"), 1L, 1);

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreateUser")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("EditDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("EditUser")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<string>("MasterOfferBreef")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MasterOfferDesc")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MasterOfferImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MasterOfferTitle")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MasterOfferId");

                    b.ToTable("MasterOffers");
                });

            modelBuilder.Entity("FinalProject.Models.MasterPartner", b =>
                {
                    b.Property<int>("MasterPartnerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MasterPartnerId"), 1L, 1);

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreateUser")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("EditDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("EditUser")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<string>("MasterPartnerLogoImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MasterPartnerName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MasterPartnerWebsiteUrl")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MasterPartnerId");

                    b.ToTable("MasterPartners");
                });

            modelBuilder.Entity("FinalProject.Models.MasterService", b =>
                {
                    b.Property<int>("MasterServiceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MasterServiceId"), 1L, 1);

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreateUser")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("EditDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("EditUser")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<string>("MasterServiceDesc")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MasterServiceImage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MasterServiceTitle")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MasterServiceId");

                    b.ToTable("MasterServices");
                });

            modelBuilder.Entity("FinalProject.Models.MasterSlider", b =>
                {
                    b.Property<int>("MasterSliderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MasterSliderId"), 1L, 1);

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreateUser")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("EditDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("EditUser")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<string>("MasterSliderBreef")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MasterSliderDesc")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MasterSliderImg")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MasterSliderTitle")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MasterSliderId");

                    b.ToTable("MasterSliders");
                });

            modelBuilder.Entity("FinalProject.Models.MasterSocialMedia", b =>
                {
                    b.Property<int>("MasterSocialMediaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MasterSocialMediaId"), 1L, 1);

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreateUser")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("EditDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("EditUser")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<string>("MasterSocialMediaImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MasterSocialMediaUrl")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MasterSocialMediaId");

                    b.ToTable("MasterSocialMedia");
                });

            modelBuilder.Entity("FinalProject.Models.MasterWorkingHour", b =>
                {
                    b.Property<int>("MasterWorkingHourId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MasterWorkingHourId"), 1L, 1);

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreateUser")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("EditDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("EditUser")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<string>("MasterWorkingHourIdName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MasterWorkingHourIdTimeFormTo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MasterWorkingHourId");

                    b.ToTable("MasterWorkingHours");
                });

            modelBuilder.Entity("FinalProject.Models.MyUserProject", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreateUser")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("EditDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("EditUser")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDelete")
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

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

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

            modelBuilder.Entity("FinalProject.Models.SystemSetting", b =>
                {
                    b.Property<int>("SystemSettingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SystemSettingId"), 1L, 1);

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreateUser")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("EditDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("EditUser")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<string>("SystemSettingCopyright")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SystemSettingLogoImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SystemSettingLogoImageUrl2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SystemSettingMapLocation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SystemSettingWelcomeNoteBreef")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SystemSettingWelcomeNoteDesc")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SystemSettingWelcomeNoteImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SystemSettingWelcomeNoteTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SystemSettingWelcomeNoteUrl")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SystemSettingId");

                    b.ToTable("SystemSettings");
                });

            modelBuilder.Entity("FinalProject.Models.TransactionBookTable", b =>
                {
                    b.Property<int>("TransactionBookTableId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TransactionBookTableId"), 1L, 1);

                    b.Property<DateTime?>("TransactionBookTableDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("TransactionBookTableEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TransactionBookTableFullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TransactionBookTableMobileNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TransactionBookTableId");

                    b.ToTable("TransactionBookTables");
                });

            modelBuilder.Entity("FinalProject.Models.TransactionContactUs", b =>
                {
                    b.Property<int>("TransactionContactUsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TransactionContactUsId"), 1L, 1);

                    b.Property<string>("TransactionContactUsEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TransactionContactUsFullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TransactionContactUsMessage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TransactionContactUsSubject")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TransactionContactUsId");

                    b.ToTable("TransactionContactUs");
                });

            modelBuilder.Entity("FinalProject.Models.TransactionNewsletter", b =>
                {
                    b.Property<int>("TransactionNewsletterId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TransactionNewsletterId"), 1L, 1);

                    b.Property<string>("TransactionNewsletterEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TransactionNewsletterId");

                    b.ToTable("TransactionNewsletters");
                });

            modelBuilder.Entity("FinalProject.Models.WhatPeopleSay", b =>
                {
                    b.Property<int>("WhatPeopleSayId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("WhatPeopleSayId"), 1L, 1);

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreateUser")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("EditDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("EditUser")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<string>("WhatPeopleSayDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WhatPeopleSayImage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WhatPeopleSayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WhatPeopleSayTitle")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("WhatPeopleSayId");

                    b.ToTable("WhatPeopleSay");
                });

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

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

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

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

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
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

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
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("FinalProject.Models.MasterItemMenu", b =>
                {
                    b.HasOne("FinalProject.Models.MasterCategoryMenu", "MasterCategoryMenu")
                        .WithMany("MasterItemMenus")
                        .HasForeignKey("MasterCategoryMenuId");

                    b.Navigation("MasterCategoryMenu");
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
                    b.HasOne("FinalProject.Models.MyUserProject", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("FinalProject.Models.MyUserProject", null)
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

                    b.HasOne("FinalProject.Models.MyUserProject", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("FinalProject.Models.MyUserProject", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FinalProject.Models.MasterCategoryMenu", b =>
                {
                    b.Navigation("MasterItemMenus");
                });
#pragma warning restore 612, 618
        }
    }
}
