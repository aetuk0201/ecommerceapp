using Microsoft.EntityFrameworkCore.Migrations;

namespace Shop.Infrastructure.Data.Migrations
{
    public partial class InitialData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(200)", nullable: false),
                    Description = table.Column<string>(type: "varchar(500)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Department",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(200)", nullable: false),
                    Description = table.Column<string>(type: "varchar(500)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(200)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(200)", nullable: false),
                    Description = table.Column<string>(type: "varchar(2000)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DepartmentId = table.Column<int>(nullable: false),
                    CategoryId = table.Column<int>(nullable: false),
                    ProductTypeId = table.Column<int>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    QtyInStock = table.Column<int>(nullable: false),
                    Code = table.Column<string>(type: "varchar(10)", nullable: true),
                    Rating = table.Column<int>(nullable: false),
                    ImageName = table.Column<string>(type: "varchar(100)", nullable: true),
                    ImagePath = table.Column<string>(type: "varchar(500)", nullable: true),
                    ImageUrl = table.Column<string>(type: "varchar(500)", nullable: true),
                    ImageMimeType = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Product_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Product_Department_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Department",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Product_ProductType_ProductTypeId",
                        column: x => x.ProductTypeId,
                        principalTable: "ProductType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Self Help", "Self-Help" },
                    { 2, "Anything technical", "Technical" },
                    { 3, "Ball", "Ball" }
                });

            migrationBuilder.InsertData(
                table: "Department",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Books", "Books" },
                    { 2, "Sports", "Sports" }
                });

            migrationBuilder.InsertData(
                table: "ProductType",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Self Development" },
                    { 2, "Mathematics" },
                    { 3, "Soccer Ball" },
                    { 4, "NFL Ball" }
                });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "CategoryId", "Code", "DepartmentId", "Description", "ImageMimeType", "ImageName", "ImagePath", "ImageUrl", "Name", "Price", "ProductTypeId", "QtyInStock", "Quantity", "Rating" },
                values: new object[,]
                {
                    { 1, 1, null, 1, "The journey to self discovery", null, "", "", null, "Ultimate Triumph", 20m, 1, 5, 0, 0 },
                    { 2, 1, null, 1, "Finding truth in the midst of deception and supression", null, "", "", null, "The Truth", 25m, 1, 3, 0, 0 },
                    { 3, 2, null, 1, "Algorithms for solving equations", null, "", "", null, "Higher Order Differential Equations", 25m, 2, 3, 0, 0 },
                    { 4, 3, null, 2, "FIFA-approved size and weight", null, "", "", null, "Dazzle Ball", 25m, 3, 3, 0, 0 },
                    { 5, 3, null, 2, "NFL-approved ball", null, "", "", null, "Spiralling Ball", 15m, 4, 3, 0, 0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CategoryName",
                table: "Category",
                column: "Name",
                unique: true)
                .Annotation("SqlServer:Clustered", false);

            migrationBuilder.CreateIndex(
                name: "IX_DepartmentName",
                table: "Department",
                column: "Name",
                unique: true)
                .Annotation("SqlServer:Clustered", false);

            migrationBuilder.CreateIndex(
                name: "IX_Product_CategoryId",
                table: "Product",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_DepartmentId",
                table: "Product",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_ProductTypeId",
                table: "Product",
                column: "ProductTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_DeptCaegoryProdType",
                table: "Product",
                columns: new[] { "Name", "DepartmentId", "CategoryId", "ProductTypeId" },
                unique: true)
                .Annotation("SqlServer:Clustered", false);

            migrationBuilder.CreateIndex(
                name: "IX_ProductTypeName",
                table: "ProductType",
                column: "Name",
                unique: true)
                .Annotation("SqlServer:Clustered", false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Department");

            migrationBuilder.DropTable(
                name: "ProductType");
        }
    }
}
