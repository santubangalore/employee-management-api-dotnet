using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeeManagement.Infrastructure.data.migrations
{
    /// <inheritdoc />
    public partial class setuptablechanged : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AdminUser",
                table: "CompanySetup",
                newName: "SuperAdminUserName");

            migrationBuilder.RenameColumn(
                name: "AdminEmail",
                table: "CompanySetup",
                newName: "SuperAdminUserId");

            migrationBuilder.AddColumn<string>(
                name: "AdminUserId",
                table: "CompanySetup",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AdminUserName",
                table: "CompanySetup",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ClientEmail",
                table: "CompanySetup",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "CompanySetup",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdationDate",
                table: "CompanySetup",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "SuperAdminPassword",
                table: "CompanySetup",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AdminUserId",
                table: "CompanySetup");

            migrationBuilder.DropColumn(
                name: "AdminUserName",
                table: "CompanySetup");

            migrationBuilder.DropColumn(
                name: "ClientEmail",
                table: "CompanySetup");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "CompanySetup");

            migrationBuilder.DropColumn(
                name: "LastUpdationDate",
                table: "CompanySetup");

            migrationBuilder.DropColumn(
                name: "SuperAdminPassword",
                table: "CompanySetup");

            migrationBuilder.RenameColumn(
                name: "SuperAdminUserName",
                table: "CompanySetup",
                newName: "AdminUser");

            migrationBuilder.RenameColumn(
                name: "SuperAdminUserId",
                table: "CompanySetup",
                newName: "AdminEmail");
        }
    }
}
