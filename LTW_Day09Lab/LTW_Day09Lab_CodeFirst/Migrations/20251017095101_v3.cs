using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LTW_Day09Lab_CodeFirst.Migrations
{
    /// <inheritdoc />
    public partial class v3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TvcSanPham_TvcLoaiSanPham_tvcLoaiSanPhamID",
                table: "TvcSanPham");

            migrationBuilder.AddForeignKey(
                name: "FK_TvcSanPham_TvcLoaiSanPham_tvcLoaiSanPhamID",
                table: "TvcSanPham",
                column: "tvcLoaiSanPhamID",
                principalTable: "TvcLoaiSanPham",
                principalColumn: "tvcId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TvcSanPham_TvcLoaiSanPham_tvcLoaiSanPhamID",
                table: "TvcSanPham");

            migrationBuilder.AddForeignKey(
                name: "FK_TvcSanPham_TvcLoaiSanPham_tvcLoaiSanPhamID",
                table: "TvcSanPham",
                column: "tvcLoaiSanPhamID",
                principalTable: "TvcLoaiSanPham",
                principalColumn: "tvcId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
