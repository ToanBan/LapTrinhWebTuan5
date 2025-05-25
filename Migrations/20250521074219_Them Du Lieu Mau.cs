using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebBanStore.Migrations
{
    /// <inheritdoc />
    public partial class ThemDuLieuMau : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Grades",
                columns: new[] { "GradeId", "GradeName" },
                values: new object[] { 1, "22DTHG4" }
            );

            migrationBuilder.InsertData(
                table: "Grades",
                columns: new[] { "GradeId", "GradeName" },
                values: new object[] { 2, "22DTHG5" }
            );

            migrationBuilder.InsertData(
                table: "Grades",
                columns: new[] { "GradeId", "GradeName" },
                values: new object[] { 3, "22DTHG6" }
            );

            migrationBuilder.InsertData(
                table: "Grades",
                columns: new[] { "GradeId", "GradeName" },
                values: new object[] { 4, "22DTHG7" }
            );

            migrationBuilder.InsertData(
                table: "Grades",
                columns: new[] { "GradeId", "GradeName" },
                values: new object[] { 5, "22DTHG8" }
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
