﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Persistence.Contexts;

#nullable disable

namespace Persistence.Migrations
{
    [DbContext(typeof(BaseDbContext))]
    partial class BaseDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Core.Security.Moldels.AppRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

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

                    b.ToTable("AppRoles", (string)null);
                });

            modelBuilder.Entity("Core.Security.Moldels.AppRoleClaim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AppRoleClaims", (string)null);
                });

            modelBuilder.Entity("Core.Security.Moldels.AppUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int")
                        .HasColumnName("AccessFailedCount");

                    b.Property<int>("AuthenticatorType")
                        .HasColumnType("int")
                        .HasColumnName("AuthenticatorType");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("ConcurrencyStamp");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)")
                        .HasColumnName("EmailAddress");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit")
                        .HasColumnName("IsEmailConfirmed");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("FirstName");

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true)
                        .HasColumnName("IsActive");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("LastName");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit")
                        .HasColumnName("IsLockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset")
                        .HasColumnName("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)")
                        .HasColumnName("NormalizedEmailAddress");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)")
                        .HasColumnName("NormalizedUserName");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("varbinary(max)")
                        .HasColumnName("PasswordHash");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("varbinary(max)")
                        .HasColumnName("PasswordSalt");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit")
                        .HasColumnName("IsPhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit")
                        .HasColumnName("IsTwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)")
                        .HasColumnName("UserName");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique()
                        .HasFilter("[EmailAddress] IS NOT NULL");

                    b.HasIndex("NormalizedEmail")
                        .IsUnique()
                        .HasDatabaseName("EmailIndex")
                        .HasFilter("[NormalizedEmailAddress] IS NOT NULL");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.HasIndex("UserName")
                        .IsUnique()
                        .HasFilter("[UserName] IS NOT NULL");

                    b.ToTable("AppUsers", (string)null);

                    b.HasDiscriminator<string>("Discriminator").HasValue("AppUser");
                });

            modelBuilder.Entity("Core.Security.Moldels.AppUserClaim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int")
                        .HasColumnName("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AppUserClaims", (string)null);
                });

            modelBuilder.Entity("Core.Security.Moldels.AppUserLogin", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)")
                        .HasColumnName("LoginProvider");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)")
                        .HasColumnName("ProviderKey");

                    b.Property<int>("UserId")
                        .HasColumnType("int")
                        .HasColumnName("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AppUserLogins", (string)null);
                });

            modelBuilder.Entity("Core.Security.Moldels.AppUserRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("RoleId")
                        .HasColumnType("int")
                        .HasColumnName("RoleId");

                    b.Property<int>("UserId")
                        .HasColumnType("int")
                        .HasColumnName("UserId");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserId");

                    b.ToTable("AppUserRoles", (string)null);
                });

            modelBuilder.Entity("Core.Security.Moldels.AppUserToken", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2")
                        .HasColumnName("Created");

                    b.Property<string>("CreatedByIp")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("CreatedByIp");

                    b.Property<DateTime>("Expires")
                        .HasColumnType("datetime2")
                        .HasColumnName("Expires");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("LoginProvider");

                    b.Property<string>("ReasonRevoked")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("ReasonRevoked");

                    b.Property<string>("ReplacedByToken")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("ReplacedByToken");

                    b.Property<DateTime?>("Revoked")
                        .HasColumnType("datetime2")
                        .HasColumnName("Revoked");

                    b.Property<string>("RevokedByIp")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("RevokedByIp");

                    b.Property<string>("Token")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Token");

                    b.Property<int>("UserId")
                        .HasColumnType("int")
                        .HasColumnName("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AppUserTokens", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.ProgrammingLanguage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime2");

                    b.Property<long?>("CreatorUserId")
                        .HasColumnType("bigint");

                    b.Property<long?>("DeleterUserId")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("DeletionTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("LastModificationTime")
                        .HasColumnType("datetime2");

                    b.Property<long?>("LastModifierUserId")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ProgrammingLanguages", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.SocialProfile", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime2");

                    b.Property<long?>("CreatorUserId")
                        .HasColumnType("bigint");

                    b.Property<long?>("DeleterUserId")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("DeletionTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("GithubUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("InstagramUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("LastModificationTime")
                        .HasColumnType("datetime2");

                    b.Property<long?>("LastModifierUserId")
                        .HasColumnType("bigint");

                    b.Property<string>("LinkedInUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PersonalWebSiteUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TwitterUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserProfileId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserProfileId")
                        .IsUnique();

                    b.ToTable("SocialProfiles", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Technology", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime2");

                    b.Property<long?>("CreatorUserId")
                        .HasColumnType("bigint");

                    b.Property<long?>("DeleterUserId")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("DeletionTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("LastModificationTime")
                        .HasColumnType("datetime2");

                    b.Property<long?>("LastModifierUserId")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProgrammingLanguageId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProgrammingLanguageId");

                    b.ToTable("Technologies", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.UserProfile", b =>
                {
                    b.HasBaseType("Core.Security.Moldels.AppUser");

                    b.HasDiscriminator().HasValue("UserProfile");
                });

            modelBuilder.Entity("Core.Security.Moldels.AppRoleClaim", b =>
                {
                    b.HasOne("Core.Security.Moldels.AppRole", "Role")
                        .WithMany("RoleClaims")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("Core.Security.Moldels.AppUserClaim", b =>
                {
                    b.HasOne("Core.Security.Moldels.AppUser", "User")
                        .WithMany("Claims")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Core.Security.Moldels.AppUserLogin", b =>
                {
                    b.HasOne("Core.Security.Moldels.AppUser", "User")
                        .WithMany("Logins")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Core.Security.Moldels.AppUserRole", b =>
                {
                    b.HasOne("Core.Security.Moldels.AppRole", "Role")
                        .WithMany("UserRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Core.Security.Moldels.AppUser", "User")
                        .WithMany("Roles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Core.Security.Moldels.AppUserToken", b =>
                {
                    b.HasOne("Core.Security.Moldels.AppUser", "User")
                        .WithMany("Tokens")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Domain.Entities.SocialProfile", b =>
                {
                    b.HasOne("Domain.Entities.UserProfile", "UserProfileFk")
                        .WithOne("SocialProfile")
                        .HasForeignKey("Domain.Entities.SocialProfile", "UserProfileId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UserProfileFk");
                });

            modelBuilder.Entity("Domain.Entities.Technology", b =>
                {
                    b.HasOne("Domain.Entities.ProgrammingLanguage", "ProgrammingLanguageFk")
                        .WithMany("Technologies")
                        .HasForeignKey("ProgrammingLanguageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ProgrammingLanguageFk");
                });

            modelBuilder.Entity("Core.Security.Moldels.AppRole", b =>
                {
                    b.Navigation("RoleClaims");

                    b.Navigation("UserRoles");
                });

            modelBuilder.Entity("Core.Security.Moldels.AppUser", b =>
                {
                    b.Navigation("Claims");

                    b.Navigation("Logins");

                    b.Navigation("Roles");

                    b.Navigation("Tokens");
                });

            modelBuilder.Entity("Domain.Entities.ProgrammingLanguage", b =>
                {
                    b.Navigation("Technologies");
                });

            modelBuilder.Entity("Domain.Entities.UserProfile", b =>
                {
                    b.Navigation("SocialProfile")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
