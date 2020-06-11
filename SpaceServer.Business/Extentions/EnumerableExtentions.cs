using SpaceServer.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
