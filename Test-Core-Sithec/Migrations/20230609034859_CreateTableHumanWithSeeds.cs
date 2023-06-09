using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Test_Core_Sithec.Migrations
{
    /// <inheritdoc />
    public partial class CreateTableHumanWithSeeds : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Humans",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Gender = table.Column<bool>(type: "bit", nullable: true),
                    Age = table.Column<byte>(type: "tinyint", nullable: false),
                    Height = table.Column<decimal>(type: "decimal(3,2)", precision: 3, scale: 2, nullable: false),
                    Weight = table.Column<decimal>(type: "decimal(5,2)", precision: 5, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Humans", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Humans",
                columns: new[] { "Id", "Age", "Gender", "Height", "Name", "Weight" },
                values: new object[,]
                {
                    { 1, (byte)23, false, 1.11m, "Human 1", 112m },
                    { 2, (byte)18, true, 1.56m, "Human 2", 112m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Humans");
        }
    }
}
