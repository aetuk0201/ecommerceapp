using Microsoft.EntityFrameworkCore.Migrations;

namespace Shop.Infrastructure.Data.Migrations
{
    public partial class OrderItemUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_ProductOrdered_ItemOrderedProductOrderedId",
                table: "OrderItems");

            migrationBuilder.DropTable(
                name: "ProductOrdered");

            migrationBuilder.DropIndex(
                name: "IX_OrderItems_ItemOrderedProductOrderedId",
                table: "OrderItems");

            migrationBuilder.DropColumn(
                name: "ItemOrderedProductOrderedId",
                table: "OrderItems");

            migrationBuilder.AddColumn<string>(
                name: "ItemOrdered_ImageUrl",
                table: "OrderItems",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ItemOrdered_ProductName",
                table: "OrderItems",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ItemOrdered_ProductOrderedId",
                table: "OrderItems",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ItemOrdered_ImageUrl",
                table: "OrderItems");

            migrationBuilder.DropColumn(
                name: "ItemOrdered_ProductName",
                table: "OrderItems");

            migrationBuilder.DropColumn(
                name: "ItemOrdered_ProductOrderedId",
                table: "OrderItems");

            migrationBuilder.AddColumn<int>(
                name: "ItemOrderedProductOrderedId",
                table: "OrderItems",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ProductOrdered",
                columns: table => new
                {
                    ProductOrderedId = table.Column<int>(type: "int", nullable: false),
                    ImageUrl = table.Column<string>(type: "varchar(200)", nullable: true),
                    ProductName = table.Column<string>(type: "varchar(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductOrdered", x => x.ProductOrderedId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_ItemOrderedProductOrderedId",
                table: "OrderItems",
                column: "ItemOrderedProductOrderedId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_ProductOrdered_ItemOrderedProductOrderedId",
                table: "OrderItems",
                column: "ItemOrderedProductOrderedId",
                principalTable: "ProductOrdered",
                principalColumn: "ProductOrderedId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
