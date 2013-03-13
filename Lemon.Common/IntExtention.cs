using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lemon.Common
{
    public static class IntExtention
    {
        public static string ToStringStatus(this int statusId)
        {
            switch (statusId)
            {
                case 1:
                    return "Openned";
                case 2:
                    return "InProgress";
                case 3:
                    return "ClosedByEmployee";
                case 4:
                    return "Completed";
                case 5:
                    return "Closed";
                default:
                    return "Unknown";

            }
        }
    }
}
