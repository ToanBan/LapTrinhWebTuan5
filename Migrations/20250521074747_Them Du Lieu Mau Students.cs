using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebBanStore.Migrations
{
    /// <inheritdoc />
    public partial class ThemDuLieuMauStudents : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "StudentId", "FirstName", "LastName", "GradeId" },
                values: new object[] { 1, "Tôn", "Ngộ Không", 1 }
            );

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "StudentId", "FirstName", "LastName", "GradeId" },
                values: new object[] { 2, "Chư", "Bát Giới", 2 }
            );


            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "StudentId", "FirstName", "LastName", "GradeId" },
                values: new object[] { 3, "Sa", "Ngộ Tịnh", 3 }
            );

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "StudentId", "FirstName", "LastName", "GradeId" },
                values: new object[] { 4, "Son", "GoKu", 4}
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
