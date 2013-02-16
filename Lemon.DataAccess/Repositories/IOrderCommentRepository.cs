using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lemon.DataAccess.Repositories
{
    using Lemon.DataAccess.DomainModels;

    public interface IOrderCommentRepository
    {
        void AddCommentToOrder(OrderComment orderComment);
    }
}
