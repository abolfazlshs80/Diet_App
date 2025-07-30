using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Diet.Persistence.EF.Migrations
{
    /// <inheritdoc />
    public partial class AddMinMaxDurationAge : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MaxAge",
                table: "DurationAge",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MinAge",
                table: "DurationAge",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MaxAge",
                table: "DurationAge");

            migrationBuilder.DropColumn(
                name: "MinAge",
                table: "DurationAge");
        }
    }
}
