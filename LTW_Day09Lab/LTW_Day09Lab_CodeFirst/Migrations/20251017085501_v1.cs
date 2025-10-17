using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LTW_Day09Lab_CodeFirst.Migrations
{
    /// <inheritdoc />
    public partial class v1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TvcLoaiSanPham",
                columns: table => new
                {
                    tvcId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tvcMaLoai = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    tvcTenLoai = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    tvcTrangThai = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TvcLoaiSanPham", x => x.tvcId);
                });

            migrationBuilder.CreateTable(
                name: "TvcSanPham",
                columns: table => new
                {
                    tvcID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tvcMaSanPham = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    tvcTenSanPham = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    tvcHinhAnh = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    tvcSoLuong = table.Column<int>(type: "int", nullable: false),
                    tvcDonGia = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    tvcLoaiSanPhamID = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TvcSanPham", x => x.tvcID);
                    table.ForeignKey(
                        name: "FK_TvcSanPham_TvcLoaiSanPham_tvcLoaiSanPhamID",
                        column: x => x.tvcLoaiSanPhamID,
                        principalTable: "TvcLoaiSanPham",
                        principalColumn: "tvcId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TvcLoaiSanPham_tvcMaLoai",
                table: "TvcLoaiSanPham",
                column: "tvcMaLoai",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TvcSanPham_tvcLoaiSanPhamID",
                table: "TvcSanPham",
                column: "tvcLoaiSanPhamID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TvcSanPham");

            migrationBuilder.DropTable(
                name: "TvcLoaiSanPham");
        }
    }
}
