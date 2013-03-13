namespace Lemon.WebApp.Services
{
    using System.Collections.Generic;

    using Lemon.DataAccess.DomainModels;

    public interface IRatingService
    {
        void AddRaiting(UserRating userRating);

        List<UserRating> GetAllRatings(int employeeId);

        int GetPositiveRatingForUser(int userId);
        
        int GetNegativeRatingForUser(int userId);

        List<string> GetAllCommentsForUser(int userId);
    }

}