using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PokemonDex.Data;
using PokemonDex.Models;
using PokemonDex.Models.ViewModels;

namespace PokemonDex.Controllers
{
    public class PokemonController : Controller
    {
        private readonly ApplicationDbContext _db;

        public PokemonController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            List<Pokemon> pokemons = _db.Pokemons.ToList();
            return View(pokemons);
        }

        public IActionResult Detail(string? id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return RedirectToAction(nameof(Index));
            }

            List<Pokemon> pokemons = _db.Pokemons.ToList();
            Pokemon? pokemon = _db.Pokemons.FirstOrDefault(p => p.IndexId == id);

            if (pokemon == null)
            {
                return RedirectToAction(nameof(Index));
            }

            PokemonDetailViewModel pokemonDetailViewModel = new PokemonDetailViewModel { 
                pokemon = pokemon,
                pokemons = pokemons
            };
            return View(pokemonDetailViewModel);
        }

        public IActionResult Search()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Search(PokemonSearch model)
        {
            Pokemon? pokemon = null;
            if (model.IndexId != null) { 
                pokemon = _db.Pokemons.FirstOrDefault(p => p.IndexId == model.IndexId);
            }
            if (model.Name != null)
            {
                pokemon = _db.Pokemons.FirstOrDefault(p => p.Name == model.Name);
            }

            if (pokemon != null)
            {
                return RedirectToAction("Detail", new { id = pokemon.IndexId });
            }

            return View(model);
        }

        [HttpPost]
        public IActionResult SearchAjax(PokemonSearch model)
        {
            if (string.IsNullOrEmpty(model.IndexId) && string.IsNullOrEmpty(model.Name))
            {
                return Json(new { success = false, message = "検索内容を入力してください" });
            }

            var pokemon = _db.Pokemons.FirstOrDefault(p => 
                (!string.IsNullOrEmpty(model.IndexId) && p.IndexId.Contains(model.IndexId)) ||
                (!string.IsNullOrEmpty(model.Name) && p.Name.Contains(model.Name))
            );

            if (pokemon != null)
            {
                return Json(new { success = true, redirectUrl = Url.Action("Detail", new { id = pokemon.IndexId }) });
            }

            return Json(new { success = false, message = "ポケモンが見つからない" });
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
