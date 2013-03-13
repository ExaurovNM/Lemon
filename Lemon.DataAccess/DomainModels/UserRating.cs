using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lemon.DataAccess.DomainModels
{
    public class UserRating:  BaseEntity
    {
        public int RatingSenderId { get; set; }

        public int RatingRecieverId { get; set; }

        public bool Rating { get; set; }

        public string Comment { get; set; }
    }
}
