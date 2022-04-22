using Microsoft.AspNetCore.Mvc;
using Flashcards.Data;
using Flashcards.Models;

namespace Flashcards.Controllers
{
    public class FlashcardsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        private readonly FlashcardsDbContext _flashcardsDbContext;
        public FlashcardsController(FlashcardsDbContext flashcardsDbContext) => _flashcardsDbContext = flashcardsDbContext;

        [Route("flashcards")]
        public async Task<List<Flashcard>> Get() => await _flashcardsDbContext.GetAsync();

        [Route("flashcards/{id}")]
        public async Task<ActionResult<Flashcard>> Get(string id)
        {
            var flashcard = await _flashcardsDbContext.GetAsync(id);

            if (flashcard is null)
            {
                return NotFound();
            }

            return flashcard;
        }
    }
}
