using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Q.API.Respostories.Migrations
{
    public partial class Add_Article : Migration
    {
        /// <summary>
        /// 本次要执行的操作
        /// </summary>
        /// <param name="migrationBuilder"></param>
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "articles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Submitter = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    Title = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    Category = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Content = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    Traffic = table.Column<int>(type: "int", nullable: false),
                    CommentNum = table.Column<int>(type: "int", nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Remark = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_articles", x => x.Id);
                });
        }
        /// <summary>
        /// 需要回滚的操作
        /// </summary>
        /// <param name="migrationBuilder"></param>
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "articles");
        }
    }
}
