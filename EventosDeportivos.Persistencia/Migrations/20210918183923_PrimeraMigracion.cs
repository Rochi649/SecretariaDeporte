using Microsoft.EntityFrameworkCore.Migrations;

namespace EventosDeportivos.Persistencia.Migrations
{
    public partial class PrimeraMigracion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TorneosEquipos_Equipos_EquipoId",
                table: "TorneosEquipos");

            migrationBuilder.DropForeignKey(
                name: "FK_TorneosEquipos_Torneos_TorneoId",
                table: "TorneosEquipos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TorneosEquipos",
                table: "TorneosEquipos");

            migrationBuilder.DropIndex(
                name: "IX_TorneosEquipos_EquipoId",
                table: "TorneosEquipos");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "TorneosEquipos");

            migrationBuilder.DropColumn(
                name: "IdEquipo",
                table: "TorneosEquipos");

            migrationBuilder.DropColumn(
                name: "IdTorneo",
                table: "TorneosEquipos");

            migrationBuilder.AlterColumn<int>(
                name: "TorneoId",
                table: "TorneosEquipos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "EquipoId",
                table: "TorneosEquipos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TorneosEquipos",
                table: "TorneosEquipos",
                columns: new[] { "EquipoId", "TorneoId" });

            migrationBuilder.AddForeignKey(
                name: "FK_TorneosEquipos_Equipos_EquipoId",
                table: "TorneosEquipos",
                column: "EquipoId",
                principalTable: "Equipos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TorneosEquipos_Torneos_TorneoId",
                table: "TorneosEquipos",
                column: "TorneoId",
                principalTable: "Torneos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TorneosEquipos_Equipos_EquipoId",
                table: "TorneosEquipos");

            migrationBuilder.DropForeignKey(
                name: "FK_TorneosEquipos_Torneos_TorneoId",
                table: "TorneosEquipos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TorneosEquipos",
                table: "TorneosEquipos");

            migrationBuilder.AlterColumn<int>(
                name: "TorneoId",
                table: "TorneosEquipos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "EquipoId",
                table: "TorneosEquipos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "TorneosEquipos",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "IdEquipo",
                table: "TorneosEquipos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdTorneo",
                table: "TorneosEquipos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TorneosEquipos",
                table: "TorneosEquipos",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_TorneosEquipos_EquipoId",
                table: "TorneosEquipos",
                column: "EquipoId");

            migrationBuilder.AddForeignKey(
                name: "FK_TorneosEquipos_Equipos_EquipoId",
                table: "TorneosEquipos",
                column: "EquipoId",
                principalTable: "Equipos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TorneosEquipos_Torneos_TorneoId",
                table: "TorneosEquipos",
                column: "TorneoId",
                principalTable: "Torneos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
