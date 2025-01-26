using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PokemonDex.Migrations
{
    /// <inheritdoc />
    public partial class AddInitialPokemonToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pokemons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IndexId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pokemons", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Pokemons",
                columns: new[] { "Id", "Description", "IndexId", "Name", "Type" },
                values: new object[,]
                {
                    { 1, "うまれたときから せなかに しょくぶつの タネが あって すこしづつ おおきく そだつ。", "0001", "フシギダネ", "くさ,どく" },
                    { 2, "つぼみが せなかに ついていて ようぶんを きゅうしゅうしていくと おおきな はなが さくという。", "0002", "フシギソウ", "くさ,どく" },
                    { 3, "はなから うっとりする かおりが ただよい たたかうものの きもちを なだめてしまう。", "0003", "フシギバナ", "くさ,どく" },
                    { 4, "うまれたときから しっぽに ほのおが ともっている。ほのおが きえたとき その いのちは おわって しまう。", "0004", "ヒトカゲ", "ほのお" },
                    { 5, "シッポを ふりまわして あいてを なぎたおし するどい ツメで ズタズタに ひきさいてしまう。", "0005", "リザード", "ほのお" },
                    { 6, "ちじょう 1400メートル まで ハネを つかって とぶことができる。こうねつの ほのおを はく。", "0006", "リザードン", "ほのお,ひこう" },
                    { 7, "ながい くびを こうらのなかに ひっこめるとき いきおいよく みずでっぽうを はっしゃする。", "0007", "ゼニガメ", "みず" },
                    { 8, "ペットとして にんきが たかい。また けで おおわれた しっぽは ながいきする シンボルだ。", "0008", "カメール", "みず" },
                    { 9, "からだが おもたく のしかかって あいてを きぜつさせる。ピンチの ときは カラに かくれる。", "0009", "カメックス", "みず" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pokemons");
        }
    }
}
