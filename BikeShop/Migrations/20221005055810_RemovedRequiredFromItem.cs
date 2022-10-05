using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BikeShop.Migrations
{
    public partial class RemovedRequiredFromItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Bag_BagId",
                table: "Items");

            migrationBuilder.AlterColumn<int>(
                name: "BagId",
                table: "Items",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Bag_BagId",
                table: "Items",
                column: "BagId",
                principalTable: "Bag",
                principalColumn: "BagId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Bag_BagId",
                table: "Items");

            migrationBuilder.AlterColumn<int>(
                name: "BagId",
                table: "Items",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Bag_BagId",
                table: "Items",
                column: "BagId",
                principalTable: "Bag",
                principalColumn: "BagId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
