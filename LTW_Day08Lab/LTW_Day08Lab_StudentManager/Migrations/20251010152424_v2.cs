using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LTW_Day08Lab_StudentManager.Migrations
{
    /// <inheritdoc />
    public partial class v2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Marks_SubjectId",
                table: "Marks");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Marks",
                table: "Marks",
                columns: new[] { "SubjectId", "StudentId" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Marks",
                table: "Marks");

            migrationBuilder.CreateIndex(
                name: "IX_Marks_SubjectId",
                table: "Marks",
                column: "SubjectId");
        }
    }
}
