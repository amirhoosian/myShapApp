using Microsoft.EntityFrameworkCore.Migrations;

namespace myShopApp.Migrations
{
    public partial class MyInitial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "catgoryid",
                table: "product",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "factorDetailproduct",
                columns: table => new
                {
                    factordetailsid = table.Column<int>(type: "int", nullable: false),
                    productsid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_factorDetailproduct", x => new { x.factordetailsid, x.productsid });
                    table.ForeignKey(
                        name: "FK_factorDetailproduct_factorDetails_factordetailsid",
                        column: x => x.factordetailsid,
                        principalTable: "factorDetails",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_factorDetailproduct_product_productsid",
                        column: x => x.productsid,
                        principalTable: "product",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_product_catgoryid",
                table: "product",
                column: "catgoryid");

            migrationBuilder.CreateIndex(
                name: "IX_factorDetails_factorid",
                table: "factorDetails",
                column: "factorid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_factorDetailproduct_productsid",
                table: "factorDetailproduct",
                column: "productsid");

            migrationBuilder.AddForeignKey(
                name: "FK_factorDetails_factors_factorid",
                table: "factorDetails",
                column: "factorid",
                principalTable: "factors",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_product_catgory_catgoryid",
                table: "product",
                column: "catgoryid",
                principalTable: "catgory",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_factorDetails_factors_factorid",
                table: "factorDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_product_catgory_catgoryid",
                table: "product");

            migrationBuilder.DropTable(
                name: "factorDetailproduct");

            migrationBuilder.DropIndex(
                name: "IX_product_catgoryid",
                table: "product");

            migrationBuilder.DropIndex(
                name: "IX_factorDetails_factorid",
                table: "factorDetails");

            migrationBuilder.DropColumn(
                name: "catgoryid",
                table: "product");
        }
    }
}
