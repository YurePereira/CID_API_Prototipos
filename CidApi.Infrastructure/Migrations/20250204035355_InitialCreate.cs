using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CidApi.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cids",
                columns: table => new
                {
                    Codigo = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cids", x => x.Codigo);
                });

            migrationBuilder.InsertData(
                table: "Cids",
                columns: new[] { "Codigo", "Descricao" },
                values: new object[,]
                {
                    { "A00", "Cólera" },
                    { "A01", "Febre tifóide e paratifóide" },
                    { "B01", "Varicela" },
                    { "J18", "Pneumonia não especificada" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cids");
        }
    }
}
