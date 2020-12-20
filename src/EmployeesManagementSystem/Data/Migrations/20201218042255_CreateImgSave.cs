using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EmployeesManagementSystem.Migrations
{
    public partial class CreateImgSave : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SaveImg",
                columns: table => new
                {
                    ImgId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImgName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Img = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SaveImg", x => x.ImgId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SaveImg");
        }
    }
}
