using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using KoiManagement.Repositories.Models;
using KoiManagement.Repositories.Interfaces;
using KoiManagement.Services.Interfaces;

namespace KoiManagement.WebApplication.Pages.Rating_feedback
{
    public class CreateModel : PageModel
    {
        private readonly IRatingService _ratingService;

        [BindProperty]
        public Rating Rating { get; set; } = new Rating();

        public CreateModel(IRatingService ratingService)
        {
            _ratingService = ratingService;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _ratingService.AddAsync(Rating);
            return RedirectToPage("./Index");
        }
    }
}
