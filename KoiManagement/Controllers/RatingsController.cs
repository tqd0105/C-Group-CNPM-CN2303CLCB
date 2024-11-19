using KoiManagement.Services.Interfaces;
using KoiManagement.Repositories.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KoiManagement.WebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RatingsController : ControllerBase
    {
        private readonly IRatingService _ratingService;

        public RatingsController(IRatingService ratingService)
        {
            _ratingService = ratingService;
        }

        // Lấy tất cả các đánh giá
        [HttpGet]
        public async Task<ActionResult<List<Rating>>> GetAllRatings()
        {
            var ratings = await _ratingService.GetAllAsync();
            return Ok(ratings);
        }

        // Lấy đánh giá theo ID
        [HttpGet("{id}")]
        public async Task<ActionResult<Rating>> GetRatingById(string id)
        {
            var rating = await _ratingService.GetByIdAsync(id);
            if (rating == null)
            {
                return NotFound(new { message = "Rating not found" });
            }
            return Ok(rating);
        }

        // Thêm mới một đánh giá
        [HttpPost]
        public async Task<ActionResult> AddRating([FromBody] Rating rating)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _ratingService.AddAsync(rating);
            return CreatedAtAction(nameof(GetRatingById), new { id = rating.RatingId }, rating);
        }

        // Cập nhật đánh giá theo ID
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateRating(string id, [FromBody] Rating rating)
        {
            if (id != rating.RatingId)
            {
                return BadRequest(new { message = "ID mismatch" });
            }

            var existingRating = await _ratingService.GetByIdAsync(id);
            if (existingRating == null)
            {
                return NotFound(new { message = "Rating not found" });
            }

            await _ratingService.UpdateAsync(rating);
            return NoContent();
        }

        // Xóa đánh giá theo ID
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteRating(string id)
        {
            var existingRating = await _ratingService.GetByIdAsync(id);
            if (existingRating == null)
            {
                return NotFound(new { message = "Rating not found" });
            }

            await _ratingService.DeleteAsync(id);
            return NoContent();
        }
    }
}
