using DeckOfCards.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DeckOfCards.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        CardsDAL cardAPI = new CardsDAL();
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {

            return View();
        }
        public IActionResult DrawCards()
        {
            Deck newDeck = cardAPI.GetDeck();
            return RedirectToAction("DealtHand", new {id = newDeck.deck_id });
        }


        public IActionResult DealtHand(string id)
        {
            Hand newHand = cardAPI.GetHand(id);
            return View(newHand);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}