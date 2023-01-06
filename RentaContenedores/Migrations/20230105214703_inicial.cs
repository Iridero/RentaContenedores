using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentaContenedores.Migrations
{
    public partial class inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "cliente",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nombre = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    telefono = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cliente", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "contenedor",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    numero = table.Column<int>(type: "int", nullable: false),
                    pasillo = table.Column<string>(type: "varchar(2)", maxLength: 2, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    dimensiones = table.Column<string>(type: "varchar(5)", maxLength: 5, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ultimo_pago = table.Column<DateOnly>(type: "date", nullable: false),
                    adeudo = table.Column<decimal>(type: "decimal(8,2)", nullable: false, defaultValue: 0m),
                    IdCliente = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_contenedor", x => x.id);
                    table.ForeignKey(
                        name: "fk_contenedor_cliente",
                        column: x => x.IdCliente,
                        principalTable: "cliente",
                        principalColumn: "id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "cliente",
                columns: new[] { "id", "nombre", "telefono" },
                values: new object[] { 1, "Juan Perez", "55523412345" });

            migrationBuilder.InsertData(
                table: "contenedor",
                columns: new[] { "id", "dimensiones", "IdCliente", "numero", "pasillo", "ultimo_pago" },
                values: new object[,]
                {
                    { 1, "3x6", null, 1, "A", new DateOnly(1, 1, 1) },
                    { 2, "3x6", null, 2, "A", new DateOnly(1, 1, 1) },
                    { 3, "3x3", null, 3, "B", new DateOnly(1, 1, 1) }
                });

            migrationBuilder.InsertData(
                table: "contenedor",
                columns: new[] { "id", "dimensiones", "IdCliente", "numero", "pasillo", "ultimo_pago" },
                values: new object[] { 4, "3x3", 1, 4, "B", new DateOnly(1, 1, 1) });

            migrationBuilder.CreateIndex(
                name: "id_cliente",
                table: "contenedor",
                column: "IdCliente");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "contenedor");

            migrationBuilder.DropTable(
                name: "cliente");
        }
    }
}
