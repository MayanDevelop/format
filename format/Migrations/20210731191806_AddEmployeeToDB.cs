using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace format.Migrations
{
    public partial class AddEmployeeToDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    f_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    f_Name = table.Column<string>(nullable: false),
                    f_Email = table.Column<string>(nullable: false),
                    f_Mobile = table.Column<string>(nullable: false),
                    f_Designation = table.Column<string>(nullable: false),
                    f_Gender = table.Column<string>(nullable: false),
                    f_Course = table.Column<string>(nullable: false),
                    f_Image = table.Column<string>(nullable: false),
                    f_Createdate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.f_Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employee");
        }
    }
}
