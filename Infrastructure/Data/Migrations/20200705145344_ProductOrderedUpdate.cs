using Microsoft.EntityFrameworkCore.Migrations;

namespace Shop.Infrastructure.Data.Migrations
{
    public partial class ProductOrderedUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // migrationBuilder.AlterColumn<int>(
            //     name: "ProductOrderedId",
            //     table: "ProductOrdered",
            //     nullable: false,
            //     oldClrType: typeof(int),
            //     oldType: "int")
            //     .OldAnnotation("SqlServer:Identity", "1, 1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // migrationBuilder.AlterColumn<int>(
            //     name: "ProductOrderedId",
            //     table: "ProductOrdered",
            //     type: "int",
            //     nullable: false,
            //     oldClrType: typeof(int))
            //     .Annotation("SqlServer:Identity", "1, 1");
        }
    }
}
