namespace Lemon.DataAccess.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Lemon.DataAccess.Context;
    using Lemon.DataAccess.DomainModels;

    public class RatingRepository : IRatingRepository
    {
        public void AddRaiting(UserRating userRating)
        {
            using (var context=new DataBaseContext())
            {
                userRating.CreatedTime = DateTime.UtcNow;
                context.UserRatings.Add(userRating);
                context.SaveChanges();
            }
        }

        public List<UserRating> GetAllRatings(int employeeId)
        {
            using (var context=new DataBaseContext())
            {
                return context.UserRatings.Where(userRating => userRating.RatingRecieverId == employeeId).ToList();
            }
        }

        public int GetPositiveRatingForUser(int userId)
        {
            using (var context = new DataBaseContext())
            {
                return
                    context.UserRatings.Count(
                        userRating => (userRating.RatingRecieverId == userId && userRating.Rating));
            }
        }

        public int GetNegativeRatingForUser(int userId)
        {
            using (var context = new DataBaseContext())
            {
                return
                    context.UserRatings.Count(
                        userRating => (userRating.RatingRecieverId == userId && !userRating.Rating));
            }
        }
    }
}