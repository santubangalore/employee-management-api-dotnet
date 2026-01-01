using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeeManagement.Infrastructure.data.migrations
{
    /// <inheritdoc />
    public partial class projectstatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TimeSheetsSummary_Projects_ProjectId",
                table: "TimeSheetsSummary");

            migrationBuilder.DropIndex(
                name: "IX_TimeSheetsSummary_ProjectId",
                table: "TimeSheetsSummary");

            migrationBuilder.AddColumn<string>(
                name: "ProjectStatus",
                table: "Projects",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProjectStatus",
                table: "Projects");

            migrationBuilder.CreateIndex(
                name: "IX_TimeSheetsSummary_ProjectId",
                table: "TimeSheetsSummary",
                column: "ProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_TimeSheetsSummary_Projects_ProjectId",
                table: "TimeSheetsSummary",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "ProjectId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
