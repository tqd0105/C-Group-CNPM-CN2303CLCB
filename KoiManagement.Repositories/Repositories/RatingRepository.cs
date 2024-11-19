using KoiManagement.Repositories.Interfaces;
using KoiManagement.Repositories.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KoiManagement.Repositories.Repositories
{
    public class RatingRepository : IRatingRepository
    {
        private readonly AppDbContext _context;

        public RatingRepository(AppDbContext context)
        {
            _context = context;
        }

        // Lấy tất cả các đánh giá
        public async Task<List<Rating>> GetAllRatingsAsync()
        {
            return await _context.Ratings.ToListAsync();
        }

        // Lấy đánh giá theo ID
        public async Task<Rating?> GetRatingByIdAsync(string ratingId)
        {
            return await _context.Ratings.FirstOrDefaultAsync(r => r.RatingId == ratingId);
        }

        // Kiểm tra nếu đánh giá tồn tại theo ID
        public async Task<bool> RatingExistsAsync(string ratingId)
        {
            return await _context.Ratings.AnyAsync(r => r.RatingId == ratingId);
        }

        // Thêm mới một đánh giá
        public async Task AddRatingAsync(Rating rating)
        {
            await _context.Ratings.AddAsync(rating);
            await _context.SaveChangesAsync();
        }

        // Cập nhật một đánh giá
        public async Task UpdateRatingAsync(Rating rating)
        {
            _context.Ratings.Update(rating);
            await _context.SaveChangesAsync();
        }

        // Xóa đánh giá theo ID
        public async Task DeleteRatingAsync(string ratingId)
        {
            var rating = await GetRatingByIdAsync(ratingId);
            if (rating != null)
            {
                _context.Ratings.Remove(rating);
                await _context.SaveChangesAsync();
            }
        }
    }
}
