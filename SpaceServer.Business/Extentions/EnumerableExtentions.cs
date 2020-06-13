using SpaceServer.Business.Models;
using System.Collections.Generic;
using System.Linq;

namespace SpaceServer.Business.Extentions
{
    public static class EnumerableExtentions
    {
        public static uint GenerateId(this IEnumerable<Uniq> enumerable)
        {
            if (enumerable.Any())
                return enumerable.Max(e => e.Id + 1);
            return 0;
        }
    }
}
