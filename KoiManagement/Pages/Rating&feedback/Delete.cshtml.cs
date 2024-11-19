using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using KoiManagement.Repositories.Models;
using KoiManagement.Repositories.Interfaces;
using KoiManagement.Services.Interfaces;

namespace KoiManagement.WebApplication.Pages.Rating_feedback
{
    public class DeleteModel : PageModel
    {
        private readonly IRatingService _ratingService;

        public DeleteModel(IRatingService ratingService)
        {
            _ratingService = ratingService;
        }

        [BindProperty]
        public Rating Rating { get; set; } = new Rating();

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Rating = await _ratingService.GetByIdAsync(id);
            if (Rating == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            await _ratingService.DeleteAsync(id);
            return RedirectToPage("./Index");
        }
    }
}
