using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Diet.Persistence.EF.Migrations
{
    /// <inheritdoc />
    public partial class DropColumnDiseaseId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Disease_Disease_DiseaseId",
                table: "Disease");

            migrationBuilder.DropIndex(
                name: "IX_Disease_DiseaseId",
                table: "Disease");

            migrationBuilder.DropColumn(
                name: "DiseaseId",
                table: "Disease");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "DiseaseId",
                table: "Disease",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Disease_DiseaseId",
                table: "Disease",
                column: "DiseaseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Disease_Disease_DiseaseId",
                table: "Disease",
                column: "DiseaseId",
                principalTable: "Disease",
                principalColumn: "Id");
        }
    }
}
