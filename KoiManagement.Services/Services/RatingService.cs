using KoiManagement.Repositories.Interfaces;
using KoiManagement.Repositories.Models;
using KoiManagement.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KoiManagement.Services
{
    public class RatingService : IRatingService
    {
        private readonly IRatingRepository _ratingRepository;

        public RatingService(IRatingRepository ratingRepository)
        {
            _ratingRepository = ratingRepository;
        }

        public async Task<List<Rating>> GetAllAsync()
        {
            return await _ratingRepository.GetAllRatingsAsync();
        }

        public async Task<Rating?> GetByIdAsync(string ratingId)
        {
            return await _ratingRepository.GetRatingByIdAsync(ratingId);
        }

        public async Task AddAsync(Rating rating)
        {
            await _ratingRepository.AddRatingAsync(rating);
        }

        public async Task UpdateAsync(Rating rating)
        {
            await _ratingRepository.UpdateRatingAsync(rating);
        }

        public async Task DeleteAsync(string ratingId)
        {
            await _ratingRepository.DeleteRatingAsync(ratingId);
        }

        public async Task<bool> RatingExistsAsync(string ratingId)
        {
            return await _ratingRepository.RatingExistsAsync(ratingId);
        }
    }
}
