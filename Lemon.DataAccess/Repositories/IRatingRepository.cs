namespace Lemon.DataAccess.Repositories
{
    using System.Collections.Generic;

    using Lemon.DataAccess.DomainModels;

    public interface IRatingRepository
    {
        void AddRaiting(UserRating userRating);

        List<UserRating> GetAllRatings(int employeeId);

        int GetPositiveRatingForUser(int userId);

        int GetNegativeRatingForUser(int userId);
    }
}
