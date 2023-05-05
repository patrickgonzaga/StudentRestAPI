using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StudentRestAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    StudentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    PhotoPath = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.StudentId);
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "StudentId", "DateOfBirth", "DepartmentId", "Email", "FirstName", "Gender", "LastName", "PhotoPath" },
                values: new object[,]
                {
                    { new Guid("738b7c16-e15e-4a54-86aa-52139dcaa74f"), new DateTime(1982, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "robert.gonzaga@yahoo.com", "Robert James", 0, "Gonzaga", "Images/RobertGonzaga.png" },
                    { new Guid("8321334d-4d63-40f4-ad35-042ef9dd63ce"), new DateTime(2015, 8, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "barbra.gonzaga@yahoo.com", "Barbra Joann", 1, "Gonzaga", "Images/BarbraGonzaga.png" },
                    { new Guid("b107100c-74ca-4b67-8444-f268ae74b915"), new DateTime(2010, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "christine.gonzaga@yahoo.com", "Christine Joannn", 1, "Gonzaga", "Images/ChristineGonzaga.png" },
                    { new Guid("b1f108f7-f437-4c2a-a36f-51b0eddd5b29"), new DateTime(2005, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "michael.gonzaga@yahoo.com", "Michael James", 0, "Gonzaga", "Images/MichaelGonzaga.png" },
                    { new Guid("cf5a1241-276e-4b17-9d9a-0a06026724de"), new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "patrick.gonzaga@yahoo.com", "Patrick James", 0, "Gonzaga", "Images/PatrickGonzaga.png" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Students");
        }
    }
}
