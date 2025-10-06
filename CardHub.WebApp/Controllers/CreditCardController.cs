using ApplicationLayer.Interfaces;
using ApplicationLayer.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CardHub.WebApp.Controllers
{
    public class CreditCardController : Controller
    {
        private readonly ICreditCardService _cardService;
        public CreditCardController(ICreditCardService cardService)
        {
            _cardService = cardService;
        }

        //GET: CreditCard
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var cards = await _cardService.GetAllAsync();
            return View(cards);
        }
        //GET: CreditCard/Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        //POST: CreditCard/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreditCardViewModel cardModel)
        {
            if (!ModelState.IsValid) return View(cardModel);

            await _cardService.AddAsync(cardModel);
            return RedirectToAction(nameof(Index));
        }
        //Get: CreditCard/Edit
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var card = await _cardService.GetByIdAsync(id);
            if (card == null)
            {
                return NotFound();
            }
            return View(card);

        }

        //Post: CreditCard/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Edit(CreditCardViewModel cardModel)
        {
            if (!ModelState.IsValid) return View(cardModel);

            var updatedCard = await _cardService.UpdateAsync(cardModel);

            if (!updatedCard) { NotFound(); }
            return RedirectToAction(nameof(Index));


        }

        //Get: CreditCard/Delete
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var card = await _cardService.GetByIdAsync(id);
            if (card == null)
            {
                return NotFound();
            }
            return View(card);

        }

        //Post: CreditCard/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _cardService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));

        }
    }
}
