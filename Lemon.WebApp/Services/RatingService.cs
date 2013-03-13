namespace Lemon.WebApp.Services
{
    using System.Collections.Generic;
    using System.Linq;

    using Lemon.DataAccess.DomainModels;
    using Lemon.DataAccess.Repositories;

    public class RatingService : IRatingService
    {
        private readonly IRatingRepository ratingRepository;

        public RatingService(IRatingRepository ratingRepository)
        {
            this.ratingRepository = ratingRepository;
        }

        public void AddRaiting(UserRating userRating)
        {
            this.ratingRepository.AddRaiting(userRating);
        }

        public List<UserRating> GetAllRatings(int employeeId)
        {
            return this.ratingRepository.GetAllRatings(employeeId);
        }

        public int GetPositiveRatingForUser(int userId)
        {
            return this.ratingRepository.GetPositiveRatingForUser(userId);
        }

        public int GetNegativeRatingForUser(int userId)
        {
            return this.ratingRepository.GetNegativeRatingForUser(userId);
        }

        public List<string> GetAllCommentsForUser(int userId)
        {
            return
                this.GetAllRatings(userId)
                    .Select(userRating => userRating.Comment)
                    .Where(comment => comment != null)
                    .ToList();
        }
    }
}