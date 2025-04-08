using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CooperativaAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cooperativas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Descricao = table.Column<string>(type: "text", nullable: false),
                    Ativo = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cooperativas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cooperados",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ContaCorrente = table.Column<string>(type: "text", nullable: false),
                    Nome = table.Column<string>(type: "text", nullable: false),
                    Ativo = table.Column<bool>(type: "boolean", nullable: false),
                    CooperativaId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cooperados", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cooperados_Cooperativas_CooperativaId",
                        column: x => x.CooperativaId,
                        principalTable: "Cooperativas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ContatosFavoritos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "text", nullable: false),
                    TipoChavePix = table.Column<int>(type: "integer", nullable: false),
                    ChavePix = table.Column<string>(type: "text", nullable: false),
                    CooperadoId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContatosFavoritos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContatosFavoritos_Cooperados_CooperadoId",
                        column: x => x.CooperadoId,
                        principalTable: "Cooperados",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Cooperativas",
                columns: new[] { "Id", "Ativo", "Descricao" },
                values: new object[,]
                {
                    { 1, true, "Cooperativa A" },
                    { 2, true, "Cooperativa B" },
                    { 3, true, "Cooperativa C" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ContatosFavoritos_CooperadoId",
                table: "ContatosFavoritos",
                column: "CooperadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Cooperados_CooperativaId",
                table: "Cooperados",
                column: "CooperativaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContatosFavoritos");

            migrationBuilder.DropTable(
                name: "Cooperados");

            migrationBuilder.DropTable(
                name: "Cooperativas");
        }
    }
}
