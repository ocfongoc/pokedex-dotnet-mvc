﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PokemonDex.Data;

#nullable disable

namespace PokemonDex.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20250126164101_AddInitialPokemonToDb")]
    partial class AddInitialPokemonToDb
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("PokemonDex.Models.Pokemon", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IndexId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Pokemons");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "うまれたときから せなかに しょくぶつの タネが あって すこしづつ おおきく そだつ。",
                            IndexId = "0001",
                            Name = "フシギダネ",
                            Type = "くさ,どく"
                        },
                        new
                        {
                            Id = 2,
                            Description = "つぼみが せなかに ついていて ようぶんを きゅうしゅうしていくと おおきな はなが さくという。",
                            IndexId = "0002",
                            Name = "フシギソウ",
                            Type = "くさ,どく"
                        },
                        new
                        {
                            Id = 3,
                            Description = "はなから うっとりする かおりが ただよい たたかうものの きもちを なだめてしまう。",
                            IndexId = "0003",
                            Name = "フシギバナ",
                            Type = "くさ,どく"
                        },
                        new
                        {
                            Id = 4,
                            Description = "うまれたときから しっぽに ほのおが ともっている。ほのおが きえたとき その いのちは おわって しまう。",
                            IndexId = "0004",
                            Name = "ヒトカゲ",
                            Type = "ほのお"
                        },
                        new
                        {
                            Id = 5,
                            Description = "シッポを ふりまわして あいてを なぎたおし するどい ツメで ズタズタに ひきさいてしまう。",
                            IndexId = "0005",
                            Name = "リザード",
                            Type = "ほのお"
                        },
                        new
                        {
                            Id = 6,
                            Description = "ちじょう 1400メートル まで ハネを つかって とぶことができる。こうねつの ほのおを はく。",
                            IndexId = "0006",
                            Name = "リザードン",
                            Type = "ほのお,ひこう"
                        },
                        new
                        {
                            Id = 7,
                            Description = "ながい くびを こうらのなかに ひっこめるとき いきおいよく みずでっぽうを はっしゃする。",
                            IndexId = "0007",
                            Name = "ゼニガメ",
                            Type = "みず"
                        },
                        new
                        {
                            Id = 8,
                            Description = "ペットとして にんきが たかい。また けで おおわれた しっぽは ながいきする シンボルだ。",
                            IndexId = "0008",
                            Name = "カメール",
                            Type = "みず"
                        },
                        new
                        {
                            Id = 9,
                            Description = "からだが おもたく のしかかって あいてを きぜつさせる。ピンチの ときは カラに かくれる。",
                            IndexId = "0009",
                            Name = "カメックス",
                            Type = "みず"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
