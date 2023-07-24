using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class FullAuiditedForAllEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreationTime",
                table: "Technologies",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<long>(
                name: "CreatorUserId",
                table: "Technologies",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "DeleterUserId",
                table: "Technologies",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionTime",
                table: "Technologies",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Technologies",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModificationTime",
                table: "Technologies",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "LastModifierUserId",
                table: "Technologies",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationTime",
                table: "SocialProfiles",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<long>(
                name: "CreatorUserId",
                table: "SocialProfiles",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "DeleterUserId",
                table: "SocialProfiles",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionTime",
                table: "SocialProfiles",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "SocialProfiles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModificationTime",
                table: "SocialProfiles",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "LastModifierUserId",
                table: "SocialProfiles",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationTime",
                table: "ProgrammingLanguages",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<long>(
                name: "CreatorUserId",
                table: "ProgrammingLanguages",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "DeleterUserId",
                table: "ProgrammingLanguages",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionTime",
                table: "ProgrammingLanguages",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "ProgrammingLanguages",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModificationTime",
                table: "ProgrammingLanguages",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "LastModifierUserId",
                table: "ProgrammingLanguages",
                type: "bigint",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreationTime",
                table: "Technologies");

            migrationBuilder.DropColumn(
                name: "CreatorUserId",
                table: "Technologies");

            migrationBuilder.DropColumn(
                name: "DeleterUserId",
                table: "Technologies");

            migrationBuilder.DropColumn(
                name: "DeletionTime",
                table: "Technologies");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Technologies");

            migrationBuilder.DropColumn(
                name: "LastModificationTime",
                table: "Technologies");

            migrationBuilder.DropColumn(
                name: "LastModifierUserId",
                table: "Technologies");

            migrationBuilder.DropColumn(
                name: "CreationTime",
                table: "SocialProfiles");

            migrationBuilder.DropColumn(
                name: "CreatorUserId",
                table: "SocialProfiles");

            migrationBuilder.DropColumn(
                name: "DeleterUserId",
                table: "SocialProfiles");

            migrationBuilder.DropColumn(
                name: "DeletionTime",
                table: "SocialProfiles");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "SocialProfiles");

            migrationBuilder.DropColumn(
                name: "LastModificationTime",
                table: "SocialProfiles");

            migrationBuilder.DropColumn(
                name: "LastModifierUserId",
                table: "SocialProfiles");

            migrationBuilder.DropColumn(
                name: "CreationTime",
                table: "ProgrammingLanguages");

            migrationBuilder.DropColumn(
                name: "CreatorUserId",
                table: "ProgrammingLanguages");

            migrationBuilder.DropColumn(
                name: "DeleterUserId",
                table: "ProgrammingLanguages");

            migrationBuilder.DropColumn(
                name: "DeletionTime",
                table: "ProgrammingLanguages");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "ProgrammingLanguages");

            migrationBuilder.DropColumn(
                name: "LastModificationTime",
                table: "ProgrammingLanguages");

            migrationBuilder.DropColumn(
                name: "LastModifierUserId",
                table: "ProgrammingLanguages");
        }
    }
}
