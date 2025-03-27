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

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
