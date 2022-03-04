using Microsoft.EntityFrameworkCore.Migrations;

namespace First.Migrations
{
    public partial class New : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Designations_Col",
                columns: table => new
                {
                    Did = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Designations = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Designations_Col", x => x.Did);
                });

            migrationBuilder.CreateTable(
                name: "Emptypes",
                columns: table => new
                {
                    Tid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Types = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Emptypes", x => x.Tid);
                });

            migrationBuilder.CreateTable(
                name: "NewEmployees",
                columns: table => new
                {
                    Empid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DegisnationDid = table.Column<int>(type: "int", nullable: true),
                    salary = table.Column<int>(type: "int", nullable: false),
                    Bonus = table.Column<int>(type: "int", nullable: true),
                    EmptypeTid = table.Column<int>(type: "int", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pincode = table.Column<int>(type: "int", nullable: false),
                    Website = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewEmployees", x => x.Empid);
                    table.ForeignKey(
                        name: "FK_NewEmployees_Designations_Col_DegisnationDid",
                        column: x => x.DegisnationDid,
                        principalTable: "Designations_Col",
                        principalColumn: "Did",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_NewEmployees_Emptypes_EmptypeTid",
                        column: x => x.EmptypeTid,
                        principalTable: "Emptypes",
                        principalColumn: "Tid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NewEmployees_DegisnationDid",
                table: "NewEmployees",
                column: "DegisnationDid");

            migrationBuilder.CreateIndex(
                name: "IX_NewEmployees_EmptypeTid",
                table: "NewEmployees",
                column: "EmptypeTid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NewEmployees");

            migrationBuilder.DropTable(
                name: "Designations_Col");

            migrationBuilder.DropTable(
                name: "Emptypes");
        }
    }
}
