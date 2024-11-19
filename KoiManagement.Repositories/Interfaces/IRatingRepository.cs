using KoiManagement.Repositories.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KoiManagement.Repositories.Interfaces
{
    public interface IRatingRepository
    {
        Task<List<Rating>> GetAllRatingsAsync();
        Task<Rating?> GetRatingByIdAsync(string ratingId);
        Task AddRatingAsync(Rating rating);
        Task UpdateRatingAsync(Rating rating);
        Task DeleteRatingAsync(string ratingId);
        Task<bool> RatingExistsAsync(string ratingId);
    }
}
