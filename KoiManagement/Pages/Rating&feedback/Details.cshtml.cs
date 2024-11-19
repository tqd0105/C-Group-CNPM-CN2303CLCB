using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using KoiManagement.Repositories.Models;
using KoiManagement.Repositories.Interfaces;
using KoiManagement.Services.Interfaces;

namespace KoiManagement.WebApplication.Pages.Rating_feedback
{
    public class DetailsModel : PageModel
    {
        private readonly IRatingService _ratingService;

        public DetailsModel(IRatingService ratingService)
        {
            _ratingService = ratingService;
        }

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
    }
}
