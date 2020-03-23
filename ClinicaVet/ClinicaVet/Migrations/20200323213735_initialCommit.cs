using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ClinicaVet.Migrations
{
    public partial class initialCommit : Migration
    {
        /// <summary>
        /// Cria condições para que a BD seja criada -> 'Fazer Update-Database' para criar BD
        /// </summary>
        /// <param name="migrationBuilder"></param>
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Donos",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(nullable: true),
                    NIF = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Donos", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Veterinarios",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(nullable: true),
                    NumCedulaProf = table.Column<string>(nullable: true),
                    Foto = table.Column<string>(nullable: true)
                },
                //definição da chave primária
                constraints: table =>
                {
                    table.PrimaryKey("PK_Veterinarios", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Animais",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(nullable: true),
                    Especie = table.Column<string>(nullable: true),
                    Peso = table.Column<float>(nullable: false),
                    Raca = table.Column<string>(nullable: true),
                    Foto = table.Column<string>(nullable: true),
                    DonoPK = table.Column<int>(nullable: false)
                },
                // definição da chave estrangeira
                constraints: table =>
                {
                    table.PrimaryKey("PK_Animais", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Animais_Donos_DonoPK",
                        column: x => x.DonoPK,
                        principalTable: "Donos",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Consulta",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Data = table.Column<DateTime>(nullable: false),
                    Observacoes = table.Column<string>(nullable: true),
                    VeterinarioFK = table.Column<int>(nullable: false),
                    AnimalFK = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consulta", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Consulta_Animais_AnimalFK",
                        column: x => x.AnimalFK,
                        principalTable: "Animais",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Consulta_Veterinarios_VeterinarioFK",
                        column: x => x.VeterinarioFK,
                        principalTable: "Veterinarios",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });
            //criação do indice para as chaves
            migrationBuilder.CreateIndex(
                name: "IX_Animais_DonoPK",
                table: "Animais",
                column: "DonoPK");

            migrationBuilder.CreateIndex(
                name: "IX_Consulta_AnimalFK",
                table: "Consulta",
                column: "AnimalFK");

            migrationBuilder.CreateIndex(
                name: "IX_Consulta_VeterinarioFK",
                table: "Consulta",
                column: "VeterinarioFK");
        }

        //desfaz as alterações criadas no UP, caso queiramos destruir a BD
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Consulta");

            migrationBuilder.DropTable(
                name: "Animais");

            migrationBuilder.DropTable(
                name: "Veterinarios");

            migrationBuilder.DropTable(
                name: "Donos");
        }
    }
}
