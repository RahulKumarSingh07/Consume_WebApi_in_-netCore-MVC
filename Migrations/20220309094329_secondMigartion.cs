using Microsoft.EntityFrameworkCore.Migrations;

namespace First.Migrations
{
    public partial class secondMigartion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "students",
                columns: table => new
                {
                    studentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    studentName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    studentClass = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    studentAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    mobileNumber = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_students", x => x.studentId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "students");

            
        }
    }
}
