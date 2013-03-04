using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lemon.DataAccess.DomainModels
{
    public static class OrderStatus
    {
        public const int Openned=1;

        public const int InProgress = 2;

        public const int ClosedByEmployee = 3;

        public const int Closed = 4;
    }
}
