using Microsoft.EntityFrameworkCore;
using PokemonDex.Models;

namespace PokemonDex.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Pokemon> Pokemons { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pokemon>().HasData(

               new Pokemon
               {
                   Id = 1,
                   IndexId = "0001",
                   Name = "フシギダネ",
                   Type = "くさ,どく",
                   Description = "うまれたときから せなかに しょくぶつの タネが あって すこしづつ おおきく そだつ。"
               },
               new Pokemon
               {
                   Id = 2,
                   IndexId = "0002",
                   Name = "フシギソウ",
                   Type = "くさ,どく",
                   Description = "つぼみが せなかに ついていて ようぶんを きゅうしゅうしていくと おおきな はなが さくという。"
               },
               new Pokemon
               {
                   Id = 3,
                   IndexId = "0003",
                   Name = "フシギバナ",
                   Type = "くさ,どく",
                   Description = "はなから うっとりする かおりが ただよい たたかうものの きもちを なだめてしまう。"
               },
               new Pokemon
               {
                   Id = 4,
                   IndexId = "0004",
                   Name = "ヒトカゲ",
                   Type = "ほのお",
                   Description = "うまれたときから しっぽに ほのおが ともっている。ほのおが きえたとき その いのちは おわって しまう。"
               },
               new Pokemon
               {
                   Id = 5,
                   IndexId = "0005",
                   Name = "リザード",
                   Type = "ほのお",
                   Description = "シッポを ふりまわして あいてを なぎたおし するどい ツメで ズタズタに ひきさいてしまう。"
               },
               new Pokemon
               {
                   Id = 6,
                   IndexId = "0006",
                   Name = "リザードン",
                   Type = "ほのお,ひこう",
                   Description = "ちじょう 1400メートル まで ハネを つかって とぶことができる。こうねつの ほのおを はく。"
               },
               new Pokemon
               {
                   Id = 7,
                   IndexId = "0007",
                   Name = "ゼニガメ",
                   Type = "みず",
                   Description = "ながい くびを こうらのなかに ひっこめるとき いきおいよく みずでっぽうを はっしゃする。"
               },
               new Pokemon
               {
                   Id = 8,
                   IndexId = "0008",
                   Name = "カメール",
                   Type = "みず",
                   Description = "ペットとして にんきが たかい。また けで おおわれた しっぽは ながいきする シンボルだ。"
               },
               new Pokemon
               {
                   Id = 9,
                   IndexId = "0009",
                   Name = "カメックス",
                   Type = "みず",
                   Description = "からだが おもたく のしかかって あいてを きぜつさせる。ピンチの ときは カラに かくれる。"
               });

        }
    }

}
