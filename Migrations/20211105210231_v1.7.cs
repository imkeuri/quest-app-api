using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BackEnd.Migrations
{
    public partial class v17 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "QuestAnswer",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameParticipant = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Active = table.Column<int>(type: "int", nullable: false),
                    QuestId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestAnswer", x => x.id);
                    table.ForeignKey(
                        name: "FK_QuestAnswer_Quest_QuestId",
                        column: x => x.QuestId,
                        principalTable: "Quest",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "QuestAnswerDetail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AnswerQuestId = table.Column<int>(type: "int", nullable: false),
                    QuestAnswerid = table.Column<int>(type: "int", nullable: true),
                    AnswerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestAnswerDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuestAnswerDetail_Answer_AnswerId",
                        column: x => x.AnswerId,
                        principalTable: "Answer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QuestAnswerDetail_QuestAnswer_QuestAnswerid",
                        column: x => x.QuestAnswerid,
                        principalTable: "QuestAnswer",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_QuestAnswer_QuestId",
                table: "QuestAnswer",
                column: "QuestId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestAnswerDetail_AnswerId",
                table: "QuestAnswerDetail",
                column: "AnswerId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestAnswerDetail_QuestAnswerid",
                table: "QuestAnswerDetail",
                column: "QuestAnswerid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "QuestAnswerDetail");

            migrationBuilder.DropTable(
                name: "QuestAnswer");
        }
    }
}
