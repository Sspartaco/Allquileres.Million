using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Alquileres.Infrastructuree.Migrations
{
    public partial class Adicionforeignkeys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PropertiesIdProperty",
                table: "PropertyTrace",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PropertiesIdProperty",
                table: "PropertyImage",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OwnersIdOwner",
                table: "Property",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PropertyTrace_PropertiesIdProperty",
                table: "PropertyTrace",
                column: "PropertiesIdProperty");

            migrationBuilder.CreateIndex(
                name: "IX_PropertyImage_PropertiesIdProperty",
                table: "PropertyImage",
                column: "PropertiesIdProperty");

            migrationBuilder.CreateIndex(
                name: "IX_Property_OwnersIdOwner",
                table: "Property",
                column: "OwnersIdOwner");

            migrationBuilder.AddForeignKey(
                name: "FK_Property_Owners_OwnersIdOwner",
                table: "Property",
                column: "OwnersIdOwner",
                principalTable: "Owners",
                principalColumn: "IdOwner");

            migrationBuilder.AddForeignKey(
                name: "FK_PropertyImage_Property_PropertiesIdProperty",
                table: "PropertyImage",
                column: "PropertiesIdProperty",
                principalTable: "Property",
                principalColumn: "IdProperty");

            migrationBuilder.AddForeignKey(
                name: "FK_PropertyTrace_Property_PropertiesIdProperty",
                table: "PropertyTrace",
                column: "PropertiesIdProperty",
                principalTable: "Property",
                principalColumn: "IdProperty");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Property_Owners_OwnersIdOwner",
                table: "Property");

            migrationBuilder.DropForeignKey(
                name: "FK_PropertyImage_Property_PropertiesIdProperty",
                table: "PropertyImage");

            migrationBuilder.DropForeignKey(
                name: "FK_PropertyTrace_Property_PropertiesIdProperty",
                table: "PropertyTrace");

            migrationBuilder.DropIndex(
                name: "IX_PropertyTrace_PropertiesIdProperty",
                table: "PropertyTrace");

            migrationBuilder.DropIndex(
                name: "IX_PropertyImage_PropertiesIdProperty",
                table: "PropertyImage");

            migrationBuilder.DropIndex(
                name: "IX_Property_OwnersIdOwner",
                table: "Property");

            migrationBuilder.DropColumn(
                name: "PropertiesIdProperty",
                table: "PropertyTrace");

            migrationBuilder.DropColumn(
                name: "PropertiesIdProperty",
                table: "PropertyImage");

            migrationBuilder.DropColumn(
                name: "OwnersIdOwner",
                table: "Property");
        }
    }
}
