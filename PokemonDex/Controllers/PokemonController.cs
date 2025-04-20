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
            List<Pokemon> pokemons = _db.Pokemons.ToList();
            return View(new PokemonSearchViewModel { pokemons = pokemons });
        }

        [HttpPost]
        public IActionResult Search(PokemonSearchViewModel model)
        {
            List<Pokemon> pokemons = _db.Pokemons.ToList();
            model.pokemons = pokemons;

            if (string.IsNullOrEmpty(model.SearchTerm))
            {
                return View(model);
            }

            var searchTerm = model.SearchTerm.ToLower();
            var matchingPokemon = model.SearchType switch
            {
                "id" => pokemons.FirstOrDefault(p => p.IndexId.ToLower().Contains(searchTerm)),
                "name" => pokemons.FirstOrDefault(p => p.Name.ToLower().Contains(searchTerm)),
                "type" => pokemons.FirstOrDefault(p => p.Type.ToLower().Contains(searchTerm)),
                _ => null
            };

            if (matchingPokemon != null)
            {
                return RedirectToAction("Detail", new { id = matchingPokemon.IndexId });
            }

            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
