using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using KoiManagement.Repositories.Models;
using KoiManagement.Repositories.Interfaces;
using KoiManagement.Services.Interfaces;

namespace KoiManagement.WebApplication.Pages.Rating_feedback
{
    public class IndexModel : PageModel
    {
        private readonly IRatingService _ratingService;

        public IndexModel(IRatingService ratingService)
        {
            _ratingService = ratingService;
        }

        public IList<Rating> Rating { get; set; } = new List<Rating>();

        public async Task OnGetAsync()
        {
            Rating = await _ratingService.GetAllAsync();
        }
    }
}
