using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameDevJobs.Migrations
{
    /// <inheritdoc />
    public partial class AddedCompanyUrl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Link",
                table: "Companies",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Link",
                table: "Companies");
        }
    }
}
