using KoiManagement.Repositories.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KoiManagement.Services.Interfaces
{
    public interface IRatingService
    {
        Task<List<Rating>> GetAllAsync();
        Task<Rating?> GetByIdAsync(string ratingId);
        Task AddAsync(Rating rating);
        Task UpdateAsync(Rating rating);
        Task DeleteAsync(string ratingId);
        Task<bool> RatingExistsAsync(string ratingId);
    }
}
