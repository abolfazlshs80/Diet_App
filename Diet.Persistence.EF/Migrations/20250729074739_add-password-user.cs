using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Diet.Persistence.EF.Migrations
{
    /// <inheritdoc />
    public partial class addpassworduser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Disease_Disease_ParentId",
                table: "Disease");

            migrationBuilder.DropIndex(
                name: "IX_Disease_ParentId",
                table: "Disease");

            migrationBuilder.AddColumn<string>(
                name: "MobileNumber",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Salt",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Disease_Disease_DiseaseId",
                table: "Disease");

            migrationBuilder.DropIndex(
                name: "IX_Disease_DiseaseId",
                table: "Disease");

            migrationBuilder.DropColumn(
                name: "MobileNumber",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Salt",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "DiseaseId",
                table: "Disease");

            migrationBuilder.CreateIndex(
                name: "IX_Disease_ParentId",
                table: "Disease",
                column: "ParentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Disease_Disease_ParentId",
                table: "Disease",
                column: "ParentId",
                principalTable: "Disease",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
