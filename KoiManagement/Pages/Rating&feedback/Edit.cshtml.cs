using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using KoiManagement.Repositories.Models;
using KoiManagement.Repositories.Interfaces;
using KoiManagement.Services.Interfaces;

namespace KoiManagement.WebApplication.Pages.Rating_feedback
{
    public class EditModel : PageModel
    {
        private readonly IRatingService _ratingService;

        public EditModel(IRatingService ratingService)
        {
            _ratingService = ratingService;
        }

        [BindProperty]
        public Rating Rating { get; set; } = new Rating();

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (string.IsNullOrEmpty(id))
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

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                await _ratingService.UpdateAsync(Rating);
            }
            catch
            {
                if (!await _ratingService.RatingExistsAsync(Rating.RatingId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }
    }
}
