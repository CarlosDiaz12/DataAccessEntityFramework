using Microsoft.EntityFrameworkCore.Migrations;

namespace DAEntity.Migrations
{
    public partial class metrica_linea : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // migrationBuilder.DropForeignKey(
            //     name: "FK_BlogPostTag_Tag_TagsId",
            //     table: "BlogPostTag");

            // migrationBuilder.DropPrimaryKey(
            //     name: "PK_Tag",
            //     table: "Tags");

            // migrationBuilder.RenameTable(
            //     name: "Tags",
            //     newName: "Tags");

            // migrationBuilder.AddPrimaryKey(
            //     name: "PK_Tags",
            //     table: "Tags",
            //     column: "Id");

            migrationBuilder.CreateTable(
                name: "Lineas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Description = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lineas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Metricas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Description = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Metricas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MetricasLineas",
                columns: table => new
                {
                    MetricaId = table.Column<int>(type: "INTEGER", nullable: false),
                    LineaId = table.Column<int>(type: "INTEGER", nullable: false),
                    Meta = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MetricasLineas", x => new { x.LineaId, x.MetricaId });
                    table.ForeignKey(
                        name: "FK_MetricasLineas_Lineas_LineaId",
                        column: x => x.LineaId,
                        principalTable: "Lineas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MetricasLineas_Metricas_MetricaId",
                        column: x => x.MetricaId,
                        principalTable: "Metricas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MetricasLineas_MetricaId",
                table: "MetricasLineas",
                column: "MetricaId");

            migrationBuilder.AddForeignKey(
                name: "FK_BlogPostTag_Tags_TagsId",
                table: "BlogPostTag",
                column: "TagsId",
                principalTable: "Tags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BlogPostTag_Tags_TagsId",
                table: "BlogPostTag");

            migrationBuilder.DropTable(
                name: "MetricasLineas");

            migrationBuilder.DropTable(
                name: "Lineas");

            migrationBuilder.DropTable(
                name: "Metricas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tags",
                table: "Tags");

            migrationBuilder.RenameTable(
                name: "Tags",
                newName: "Tag");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tag",
                table: "Tag",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BlogPostTag_Tag_TagsId",
                table: "BlogPostTag",
                column: "TagsId",
                principalTable: "Tag",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
