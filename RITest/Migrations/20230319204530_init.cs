using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace RITest.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DrillBlocks",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    update_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DrillBlocks", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "DrillBlockPoints",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    drill_block_id = table.Column<int>(type: "integer", nullable: false),
                    sequence = table.Column<int>(type: "integer", nullable: false),
                    x = table.Column<float>(type: "real", nullable: false),
                    y = table.Column<float>(type: "real", nullable: false),
                    z = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DrillBlockPoints", x => x.id);
                    table.ForeignKey(
                        name: "FK_DrillBlockPoints_DrillBlocks_drill_block_id",
                        column: x => x.drill_block_id,
                        principalTable: "DrillBlocks",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Holes",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    drill_block_id = table.Column<int>(type: "integer", nullable: false),
                    DEPTH = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Holes", x => x.id);
                    table.ForeignKey(
                        name: "FK_Holes_DrillBlocks_drill_block_id",
                        column: x => x.drill_block_id,
                        principalTable: "DrillBlocks",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HolePoints",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    hole_id = table.Column<int>(type: "integer", nullable: false),
                    x = table.Column<float>(type: "real", nullable: false),
                    y = table.Column<float>(type: "real", nullable: false),
                    z = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HolePoints", x => x.id);
                    table.ForeignKey(
                        name: "FK_HolePoints_Holes_hole_id",
                        column: x => x.hole_id,
                        principalTable: "Holes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DrillBlockPoints_drill_block_id",
                table: "DrillBlockPoints",
                column: "drill_block_id");

            migrationBuilder.CreateIndex(
                name: "IX_HolePoints_hole_id",
                table: "HolePoints",
                column: "hole_id");

            migrationBuilder.CreateIndex(
                name: "IX_Holes_drill_block_id",
                table: "Holes",
                column: "drill_block_id");

            migrationBuilder.Sql(@"
                 CREATE FUNCTION public.update_date_trigger_fun()
                    RETURNS trigger
                    LANGUAGE 'plpgsql'
                    NOT LEAKPROOF
                AS $BODY$
                BEGIN
                    NEW.update_date:=NOW();
                    RETURN NEW;
                END;
                $BODY$;
            ");

            migrationBuilder.Sql(@"
                 CREATE FUNCTION public.sequence_insert_trigger_fun()
                    RETURNS trigger
                    LANGUAGE 'plpgsql'
                    NOT LEAKPROOF
                AS $BODY$
                BEGIN
                    SELECT COUNT(id) FROM ""DrillBlockPoints"" WHERE drill_block_id=NEW.drill_block_id INTO NEW.""sequence"";
                    RETURN NEW;
                END;
                $BODY$;
            ");

            migrationBuilder.Sql(@"
                 CREATE FUNCTION public.sequence_delete_trigger_fun()
                    RETURNS trigger
                    LANGUAGE 'plpgsql'
                    NOT LEAKPROOF
                AS $BODY$
                BEGIN
                    UPDATE ""DrillBlockPoints"" SET sequence = sequence - 1 WHERE drill_block_id=OLD.""drill_block_id"" AND sequence > OLD.""sequence"";
                    RETURN OLD;
                END;
                $BODY$;
            ");

            migrationBuilder.Sql(@"
                 CREATE TRIGGER sequence_insert_trigger
                    BEFORE INSERT
                    ON ""DrillBlockPoints""
                    FOR EACH ROW
                    EXECUTE PROCEDURE sequence_insert_trigger_fun();
            ");

            migrationBuilder.Sql(@"
                 CREATE TRIGGER sequence_delete_trigger
                    BEFORE DELETE
                    ON ""DrillBlockPoints""
                    FOR EACH ROW
                    EXECUTE PROCEDURE sequence_delete_trigger_fun();
            ");

            migrationBuilder.Sql(@"
                 CREATE TRIGGER update_date_trigger
                    BEFORE INSERT OR UPDATE
                    ON ""DrillBlocks""
                    FOR EACH ROW
                    EXECUTE PROCEDURE update_date_trigger_fun();
            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DrillBlockPoints");

            migrationBuilder.DropTable(
                name: "HolePoints");

            migrationBuilder.DropTable(
                name: "Holes");

            migrationBuilder.DropTable(
                name: "DrillBlocks");
            migrationBuilder.Sql(@"
                 DROP FUNCTION sequene_insert_trigger_fun();
            ");
        }
    }
}
